using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using X_Service.Db;
using X_Service.Login;
using X_Service.Util;
using X_Service.Web;
using System.Windows.Forms;
using System.Collections.Generic;
using X_Service.Files;


namespace ConsoleServer {
    class Program {

        static List<ClientItem> clientList = new List<ClientItem>();

        class ClientItem {
            public ModelMember clientMember;
            public Socket clientSocket;
        }

        ClientItem CheckUserExist(ModelMember member) {
            foreach (ClientItem item in clientList) {
                if (item.clientMember.netname == member.netname) {
                    return item;
                }
            }
            return null;
        }

        ClientItem GetUser(ModelMember member) {
            foreach (ClientItem ci in clientList) {
                if (ci.clientMember.netname == member.netname && ci.clientMember.ipaddress == member.ipaddress) {
                    return ci;
                }
            }
            return null;
        }

        private static byte[] result = new byte[1024];
        private static int myProt = 9778;   //端口  
        static Socket serverSocket;
        static DbTools db = new DbTools();

        #region Windows Api加载
        /// <summary>
        /// 查找窗体句柄
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 查找菜单句柄
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="bRevert"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        extern static IntPtr GetSystemMenu(IntPtr hWnd, IntPtr bRevert);
        /// <summary>
        /// 移除某个菜单
        /// </summary>
        /// <param name="hMenu"></param>
        /// <param name="uPosition"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        extern static IntPtr RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);
        #endregion

        #region 静态方法

        #region 灰掉控制台上面的X
        /// <summary>
        /// 灰掉控制台上面的X
        /// </summary>
        static void DisClose() {
            IntPtr windowHandle = FindWindow(null, Console.Title);
            IntPtr closeMenu = GetSystemMenu(windowHandle, IntPtr.Zero);
            uint SC_CLOSE = 0xF060;
            RemoveMenu(closeMenu, SC_CLOSE, 0x0);
        }
        #endregion

        #endregion

        static void Main(string[] args) {
            int clientWidth = Screen.PrimaryScreen.Bounds.Width;
            if (clientWidth > 1000) {
                Console.SetWindowSize(120, 44 / 2);
            } else {
                EchoHelper.Echo("推荐使用的分辨率是：1024*800以上", null, EchoHelper.EchoType.普通信息);
            }

            DisClose();
            //设置标题
            Console.Title = "忍者X2智能站群系统 服务端状态监控中..."; //设置控制台窗口的标题 
            //初始化内容
            Console.ForegroundColor = ConsoleColor.Magenta;

            #region 待更新的，美丽的CMD字体效果。
            Console.WriteLine("");
            Console.WriteLine("      ┏━┓　　　　　　┏━┓┏┓　　　　　　　　　　　　　　　");
            Console.WriteLine("      ┃┃┃┏━┓┏━┓┣━┃┃┗┓┏━┓　　┏━┓┏┳┓┏━┓");
            Console.WriteLine("      ┃　┫┃┻┫┃┃┃┃━┫┃┃┃┃┻┫┏┓┃┃┃┃┏┛┃┃┃");
            Console.WriteLine("      ┗┻┛┗━┛┗┻┛┗━┛┗┻┛┗━┛┗┛┗━┛┗┛　┣┓┃");
            Console.WriteLine("      　　　　　　　　　　　　　　　　　　    　　　　　　┗━┛");


            #endregion

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                  --官方服务端：www.RenZhe.org");
            Console.WriteLine("");
            EchoHelper.Echo("忍者X2服务端控制台初始化完毕！", null, EchoHelper.EchoType.普通信息);


            //服务器IP地址  
            IPAddress ip = IPAddress.Parse("116.255.139.227");//administrator,Zqowner3
            //IPAddress ip = IPAddress.Parse("223.4.173.93");
            //IPAddress ip = IPAddress.Parse("192.168.1.103");


            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myProt));  //绑定IP地址：端口  
            serverSocket.Listen(1000);    //设定最多10个排队连接请求
            EchoHelper.Echo("启动监听9778端口成功！", "系统启动", EchoHelper.EchoType.普通信息);

            Thread myThread = new Thread(ListenClientConnect);
            myThread.IsBackground = true;
            myThread.Start();

            Console.ReadLine();
        }

        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private static void ListenClientConnect() {
            while (true) {
                Socket clientSocket = serverSocket.Accept();
                clientSocket.Send(Encoding.ASCII.GetBytes("http://www.renzhe.org"));
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.IsBackground = true;
                receiveThread.Start(clientSocket);
            }
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private static void ReceiveMessage(object clientSocket) {
            Program p = new Program();
            Socket myClientSocket = (Socket)clientSocket;
            byte[] mmbytes = SocketHelper.ReceiveVarData(myClientSocket);
            ModelMember member = null;
            try {
                member = (ModelMember)db.BytetoClass(mmbytes, "VCDS");
                string ipaddress = IPAddress.Parse(((IPEndPoint)myClientSocket.RemoteEndPoint).Address.ToString()).ToString();

                switch (member.strCommand) {
                    case "login":
                        EchoHelper.Echo("接收客户端（" + ipaddress + "）登录名：" + member.netname + "密码：" + member.netpass, "接收信息", EchoHelper.EchoType.普通信息);

                        //用户cookies服务器端验证。
                        if (p.ValidateUser(ref member)) {
                            member.strCommand = "login";
                            member.bLoginSuccess = true;
                        } else {
                            member.strCommand = "exit";
                            member.bLoginSuccess = false;
                        }

                        ClientItem tmp = null;
                        if ((tmp = p.CheckUserExist(member)) != null && member.bLoginSuccess && member.ipaddress != tmp.clientMember.ipaddress) {
                            //此时用户名和密码同时相同,开始踢客户端.
                            tmp.clientMember.strCommand = "exit";
                            tmp.clientMember.strMessage = "您的账户在另一地点登录：" + ipaddress + "，您被迫下线！建议您修改密码！";
                            byte[] senddata = db.ClasstoByte(tmp.clientMember, "VCDS");
                            if (!tmp.clientSocket.Connected)
                                tmp.clientSocket.Connect(tmp.clientSocket.RemoteEndPoint);
                            member = tmp.clientMember.CopyTo();
                            //删除前一客户端
                            clientList.Remove(tmp);
                            EchoHelper.Echo(member.netname + "（" + member.ipaddress + "），被踢下线了！", "用户验证", EchoHelper.EchoType.错误信息);
                            SocketHelper.SendVarData(tmp.clientSocket, senddata);
                            tmp.clientSocket.Shutdown(SocketShutdown.Both);
                            tmp.clientSocket.Close();
                        }

                        //记录当前客户端.
                        member.ipaddress = ipaddress;
                        ClientItem cur = new ClientItem() {
                            clientMember = member, clientSocket = myClientSocket
                        };

                        byte[] curdata = db.ClasstoByte(member, "VCDS");
                        SocketHelper.SendVarData(myClientSocket, curdata);
                        if (member.bLoginSuccess)
                            clientList.Add(cur);
                        break;
                    case "closeform":
                        member.ipaddress = ipaddress;
                        if ((tmp = p.GetUser(member)) != null) {
                            clientList.Remove(tmp);
                            EchoHelper.Echo(member.netname + "（" + member.ipaddress + "），下线了.", "用户验证", EchoHelper.EchoType.任务信息);
                            //member.strCommand = "quit";
                            //byte[] quitdatas = db.ClasstoByte(member, "VCDS");
                            //SocketHelper.SendVarData(tmp.clientSocket, quitdatas);
                        }
                        break;
                    default:
                        break;
                }

            } catch (Exception ex) {
                EchoHelper.Echo("quit" + ex.Message, "exception", EchoHelper.EchoType.异常信息);
            }
        }

        private bool ValidateUser(ref ModelMember member) {
            member.IS_X_PostKing = false;

            //验证是否具有发帖权限
            string testpostUrl = "http://www.renzhe.org/forum.php?mod=post&action=newthread&fid=36";

            string html = new xkHttp().httpGET(testpostUrl, ref member.cookies);
            if (html.Contains("发表帖子 - 忍者X2站群 -  忍者软件")) {
                EchoHelper.Echo("恭喜您，权限核对成功，您已被授权使用忍者X2站群！", "用户验证", EchoHelper.EchoType.任务信息);
                member.strMessage = "恭喜您，权限核对成功，您已被授权使用忍者X2站群！";
                member.IS_X_PostKing = true;
            } else if (html.Contains("抱歉，您需要设置自己的头像后才能进行本操作")) {
                EchoHelper.Echo("请完善您的（基本资料、头像），即在论坛上发个帖子激活一下。授权论坛：www.renzhe.org！", "用户验证", EchoHelper.EchoType.任务信息);
                member.strMessage = "请完善您的（基本资料、头像），即在论坛上发个帖子激活一下。授权论坛：www.renzhe.org！";
            } else if (html.Contains("请先绑定手机号码")) {
                EchoHelper.Echo("请先绑定手机号码，授权论坛：www.renzhe.org！", "用户验证", EchoHelper.EchoType.任务信息);
                member.strMessage = "请先绑定手机号码，授权论坛：www.renzhe.org！";
            } else if (html.Contains("<s>商业授权用户</s>")) {
                EchoHelper.Echo("您的账户已过期，请到论坛充值续费！", "用户验证", EchoHelper.EchoType.任务信息);
                member.strMessage = "您的账户已过期，请到论坛充值续费！";
            } else if (html.Contains("超时")) {
                EchoHelper.Echo("链接服务超时！", "用户验证", EchoHelper.EchoType.任务信息);
                member.strMessage = "链接服务超时！";
            } else if (html.Contains("没有权限在该版块发帖")) {
                EchoHelper.Echo("用户登录验证失败，请重新登录！", "用户验证", EchoHelper.EchoType.任务信息);
                member.strMessage = "用户登录验证失败，请重新登录！";
            } else if (html.Contains("无法解析此远程名称")) {
                EchoHelper.Echo("域名解析出现问题，请检查您的网络设置！", "用户验证", EchoHelper.EchoType.任务信息);
                member.strMessage = "域名解析出现问题，请检查您的网络设置！";
            } else {
                EchoHelper.Echo("验证失败，原因未知！", "用户验证", EchoHelper.EchoType.任务信息);
                member.strMessage = "验证失败，原因未知！";
                FilesHelper.Write_File(Application.StartupPath + "\\log\\" + DateTime.Now.Ticks.ToString() + ".txt", html);
            }

            if (member.group.Contains("商业授权用户")) {
                member.IS_X_WordPressBuild = true;
            } else {
                member.IS_X_WordPressBuild = false;
            }
            return member.IS_X_PostKing;
        }

    }
}
