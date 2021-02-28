using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using ICSharpCode.SharpZipLib.Zip;
using X_Model;
using X_PostKing.Tools;
using X_Service.Db;
using X_Service.Files;
using X_Service.Login;
using X_Service.Reflect;
using X_Service.Util;
using System.Net.Sockets;

namespace X_PostKing {

    //编辑后,列表没有刷新.不需要刷新
    public partial class X_Form_Main : X_Form_Base {

        #region 构造函数
        private X_ListView lvwColumnSorter;
        private X_Waiting wait = new X_Waiting();

        public X_Form_Main() {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            lvwColumnSorter = new X_ListView();
            return;
        }
        #endregion

        #region 全局方法 最小化，任务托盘，关闭提示，自动保存


        /// <summary>
        /// 重写关闭方法 增加弹出确定关闭对话框.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
            SaveAll();
            e.Cancel = true;
            int runNum = ModelMain.AllData.TasksList.FindAll(delegate(ModelTasks task) {
                return task.TaskState != TaskState.已终止 & task.TaskState != TaskState.未启动;
            }).Count;

            if (runNum > 0 && KryptonMessageBox.Show("您还有运行中的任务，有可能造成数据丢失，确认退出？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
                e.Cancel = false;
            } else {
                e.Cancel = true;
            }
            if (KryptonMessageBox.Show("真的要退出【忍者X2站群系统】？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
                e.Cancel = false;
            } else {
                e.Cancel = true;
            }

            Socket clientSocket = null;
            DbTools db = new DbTools();
            if ((clientSocket = SocketHelper.GetSocket()) == null)
                return;

            member.strCommand = "closeform";
            byte[] bufs = db.ClasstoByte(member, "VCDS");
            SocketHelper.SendVarData(clientSocket, bufs);

            base.OnClosing(e);
        }

        //间隔执行某些方法。
        private void TmSaveAll_Tick(object sender, EventArgs e) {
            setLabelBar();
            SaveAll();
        }

        #endregion


        #region 窗体加载时,加载操作...

        public delegate void ReLoadSites();
        public event ReLoadSites LoadSites;

        private void X_Form_Main_Load(object sender, EventArgs e) {
            X_Main_Load(sender, e);

            X_Form_News news = new X_Form_News();
            news.Show(this.dockPanelMain, WeifenLuo.WinFormsUI.Docking.DockState.DockBottom);

            X_Form_SiteManage sites = new X_Form_SiteManage();
            sites.Show(this.dockPanelMain);

            X_Form_TaskManage tasks = new X_Form_TaskManage();
            sites.SiteSelect += new X_Form_SiteManage.SiteSelectChangeHandler(tasks.taskSelectChange);
            sites.taskStart += new X_Form_SiteManage.TaskStartChangeHandler(tasks.taskStart);
            LoadSites += new ReLoadSites(sites.loadAllData);

            X_Form_AllPutView view = new X_Form_AllPutView();
            view.Show(this.dockPanelMain);

            tasks.Show(this.dockPanelMain);
            tasks.DockTo(dockPanelMain.Panes[2], DockStyle.Fill, 0);

            loadFlashHelpForm();
        }


        private void X_Main_Load(object sender, EventArgs e) {
            object obj = null;
            DbTools db = new DbTools();
            EchoHelper.Echo("忍者X2站群引擎正在加载数据信息...", "系统", EchoHelper.EchoType.任务信息);
            obj = db.Read(Application.StartupPath + "\\Config\\MainConfig.VDB", "VCDS");
            if (obj != null) {
                try {
                    ModelMain.AllData = (ModelMain)obj;
                } catch (Exception ex) {
                    EchoHelper.EchoException(ex);
//                     string bugs = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\把此文件发送给Qin.zip";
//                     ZipHelper.Zip(bugs, Application.StartupPath + @"\Config\");
//                     EchoHelper.Echo("数据加载出现了异常，为了分析异常数据，请上交给Qin处理！", "请提交异常数据", EchoHelper.EchoType.异常信息);
//                     EchoHelper.Echo("建议把桌面上的【把此文件发送给Qin.zip】文件，发送给Qin，让他来分析此数据包的问题！", "请提交异常数据", EchoHelper.EchoType.异常信息);
//                     EchoHelper.Echo(ex.Message, "请提交异常数据", EchoHelper.EchoType.异常信息);
                }

                if (ModelMain.AllData.TasksList != null) {
                    for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                        ModelMain.AllData.TasksList[i].TaskState = TaskState.未启动;
                    }
                    EchoHelper.Echo("忍者X2站群引擎全部数据加载完毕，您可以开始正常使用啦！", "系统", EchoHelper.EchoType.任务信息);

                }

                //判断域名是否快要到期，然后给出提示。
                int domainexpired = 0;
                if (ModelMain.AllData.SiteList != null) {
                    for (int i = 0; i < ModelMain.AllData.SiteList.Count; i++) {
                        if (ModelMain.AllData.SiteList[i].DomainleftDays < 30 && ModelMain.AllData.SiteList[i].DomainleftDays > 0) {
                            domainexpired++;
                        }
                    }
                }
                if (domainexpired > 0 && KryptonMessageBox.Show("您有快要到期的域名，是否查看？", "域名到期提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) {
                    new X_Form_SiteInfo().ShowDialog();
                }
            } else {
                EchoHelper.Echo("数据信息未能正确加载，系统自动初始化数据成功。", "系统", EchoHelper.EchoType.普通信息);
            }
            //判断站点数量的权限
            ValidateUserPower();
            setLabelBar();
        }

        private void ValidateUserPower() {
            if (Login_Base.member.sitenum < ModelMain.AllData.SiteList.Count) {
                Login_Base.member.IS_X_PostKing = false;
            }


            if (Login_Base.member.IS_X_PostKing == false) {
                EchoHelper.Echo("您的实际站点数超量，目前您的站点数：" + member.sitenum + "。请升级VIP，或用金币兑换站点数量。", "权限不足", EchoHelper.EchoType.错误信息);
                EchoHelper.Show("您的权限不足：具体原因请查看后台黑窗运行日志！", EchoHelper.MessageType.错误);
                EchoHelper.Show("10秒后，将自动关闭！", EchoHelper.MessageType.错误);
                this.dockPanelMain.Enabled = false;
                new Thread(new ThreadStart(nopowerclose)).Start();
            } else {
                try {
                    this.Text += " 授权用户【" + ini.re("登录账户密码", "INFO") + "】 站点数【" + Login_Base.member.sitenum + "】";
                    this.Text += "  当前版本：" + new X_Form_AboutBox().getVer();
                    if (!Convert.ToBoolean(ini.re("日志设定", "日志窗口"))) {
                        EchoHelper.Hide();
                    }
                } catch (Exception ex) {
                    EchoHelper.Echo("INI信息读取出错啦.", ex.Message, EchoHelper.EchoType.异常信息);
                }
            }
        }

        private void nopowerclose() {
            Thread.Sleep(10000);
            Application.ExitThread();
            Application.Exit();
        }

        
        /// <summary>
        /// 设置状态栏信息。
        /// </summary>
        private void setLabelBar() {
            string zym = "怕苦苦一辈子，不怕苦苦一阵子。, Be a  man (做个男子汉！拿出男人样！), 心有多大 舞台就有多大。我们要怕的，只有害怕本身 (克服恐惧心理), 立即行动，绝不拖延  （养成立即行动的好习惯）,成功就是简单的事情重复做 （做好基本功，耐得住寂寞和等待）,今日事 今日毕, 只为成功想办法，不为失败找借口。, 不能从失败中吸取教训的人，它的成功之路是遥远的。, 目标明确 行动坚决";
            string randstr = StringHelper.getRandStr(zym);
            labelbar.Text = "现在时间是：" + DateTime.Now.ToString();
            labelbar.Text += "  ∷  统计：" + ModelMain.AllData.SiteList.Count + "个站点" + "  " + ModelMain.AllData.TasksList.Count + "个任务";
            labelbar.Text += "  ∷  您是" + Login_Base.member.group + "：" + randstr;
        }


        private void TaskStateClear() {
            foreach (ModelTasks task in ModelMain.AllData.TasksList) {
                task.TaskState = TaskState.未启动;
            }
        }

        private int taskCount(int siteID) {
            int re = 0;
            foreach (ModelTasks item in ModelMain.AllData.TasksList) {
                if (item.SiteID == siteID) {
                    re++;
                }
            }
            return re;
        }
        private int groupCount(int groupID) {
            int re = 0;
            foreach (ModelSite item in ModelMain.AllData.SiteList) {
                if (item.GroupID == groupID) {
                    re++;
                }
            }
            return re;
        }

        #endregion

        #region 菜单内容
        private void 黑窗_Click(object sender, EventArgs e) {
            if (EchoHelper.IsShow) {
                EchoHelper.Hide();//修改为已隐藏
            } else {
                //Console.Clear();//清空控制台信息
                EchoHelper.Show();//显示控制台
                this.Focus();//窗体获取焦点
            }
        }

        private void 关于_Click(object sender, EventArgs e) {
            X_Form_AboutBox frm = new X_Form_AboutBox();
            if (frm.ShowDialog() == DialogResult.OK) {

            }
        }

        private void 软件保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveAll();
        }

        private void 刷新日志ToolStripMenuItem_Click(object sender, EventArgs e) {
            Console.Clear();//清空控制台信息
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void 软件设定ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_Setup setup = new X_Form_Setup();
            setup.ShowDialog();
        }

        private void 运行日志ToolStripMenuItem1_Click(object sender, EventArgs e) {
            ProcessHelper.openUrl(Application.StartupPath + "\\log\\");
        }

        private void 外链资源搜索ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_Extend ext = new X_Form_Extend();
            if (ext.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

            }
            ext.Close();
        }

        private void 网站外链查询ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_Extend ext = new X_Form_Extend();
            if (ext.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

            }
            ext.Close();
        }

        private void 长尾关键词ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_GJC gjc = new X_Form_GJC();
            if (gjc.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

            }
            gjc.Close();

        }

        private void 站点信息ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_SiteInfo info = new X_Form_SiteInfo();
            if (info.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

            }
            info.Close();
        }

        private void 网站报表_Click(object sender, EventArgs e) {
            站点信息ToolStripMenuItem_Click(sender, e);
        }

        private void 网站链轮_Click(object sender, EventArgs e) {
            X_Form_LinkCycle linkCycle = new X_Form_LinkCycle();
            if (linkCycle.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

            }
            linkCycle.Close();
        }

        private void 访问论坛ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_MainFormBrowser bw = new X_Form_Main().getBrowser();
            bw.Show();
            bw.GotoPage("http://www.renzhe.org/");
        }

        private void 正则测试工具ToolStripMenuItem_Click(object sender, EventArgs e) {
            new ReflectionFunction().LoadMdiForm("X_WordPressBuild.exe", "X_WordPressBuild.X_Form_WordPressBuild", null);
        }

        private void 过期域名注册ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_Domain domain = new X_Form_Domain();
            if (domain.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

            }
            domain.Close();
        }

        private void 超级链轮库ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_LinkCycle linkcycle = new X_Form_LinkCycle();
            if (linkcycle.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

            }
            linkcycle.Close();
        }

        private void 主页ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_MainFormBrowser bw = new X_Form_Main().getBrowser();
            bw.Show();
            bw.GotoPage("http://www.renzhe.org/");
        }

        private void btnBuy_Click(object sender, EventArgs e) {
            X_Form_MainFormBrowser bw = new X_Form_Main().getBrowser();
            bw.Show();
            bw.GotoPage("http://www.renzhe.org/forum.php?mod=viewthread&tid=15119");
        }

        #endregion

        private void 启动所有任务_Click(object sender, EventArgs e) {
            wait.ShowMsg("准备启动任务，请稍后...");
            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                wait.ShowMsg("启动任务中..." + (ModelMain.AllData.TasksList.Count - i).ToString());
                ModelTasks task = ModelMain.AllData.TasksList[i];
                ModelSite site = ModelMain.FindSiteByID(task.SiteID);
                if (task.TaskState == TaskState.已终止 || task.TaskState == TaskState.未启动) {
                    task.TaskState = TaskState.运行中;
                    Thread.Sleep(40);
                }
            }
            wait.CloseMsg();
        }

        private void 停止所有任务_Click(object sender, EventArgs e) {
            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                ModelTasks task = ModelMain.AllData.TasksList[i];
                if (task.TaskState != TaskState.未启动 && task.TaskState != TaskState.已终止) {
                    ModelMain.AllData.TasksList[i].TaskState = TaskState.等待终止;
                    Thread.Sleep(40);
                }
            }

        }

        private void 访问官方论坛ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_MainFormBrowser bw = new X_Form_Main().getBrowser();
            bw.Show();
            bw.GotoPage("http://www.renzhe.org/forum.php?mod=forumdisplay&fid=36&filter=typeid&typeid=8");
            //ProcessHelper.openUrl("http://www.renzhe.org/");
        }

        private void 新手教程ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_FlashHelp help = new X_Form_FlashHelp();
            help.ShowDialog();
        }

        //根据站点的数量，来判断用户是新手还是老手，然后弹出新手动画。
        private void loadFlashHelpForm() {
            if (ModelMain.AllData.SiteList.Count < 1) {
                new X_Form_FlashHelp().Show();
            }
        }

        //新添加的2个批量任务。对于商业用户来说挺有用的，我自己也一直希望有这样的功能。
        private void toolStripButton批量建站_Click(object sender, EventArgs e) {
            X_Form_BatchAddSite batch = new X_Form_BatchAddSite();
            if (batch.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                LoadSites();
            }

        }

        private void toolStripButton批量任务_Click(object sender, EventArgs e) {
            X_Form_BatchAddTask batch = new X_Form_BatchAddTask();
            if (batch.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                //LoadSites();
            }
        }

        private void 过期域名检测ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_Domain domain = new X_Form_Domain();
            domain.ShowDialog();
        }

        private void wP一键生成器ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_WordPressBuild wp = new X_Form_WordPressBuild();
            wp.ShowDialog();
        }

        private void 动画教程ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_MainFormBrowser bw = new X_Form_Main().getBrowser();
            bw.Show();
            bw.GotoPage("http://www.renzhe.org/forum.php?mod=forumdisplay&fid=36&filter=typeid&typeid=8");
        }

        private void 模块下载ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_MainFormBrowser bw = new X_Form_Main().getBrowser();
            bw.Show();
            bw.GotoPage("http://www.renzhe.org/forum.php?mod=forumdisplay&fid=36&filter=typeid&typeid=7");
        }

        private void 淘宝店铺引入ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_TkShop tkshop = new X_Form_TkShop();
            tkshop.ShowDialog();
        }

        private void 相关域爬爬ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_WLink wlink = new X_Form_WLink();
            wlink.ShowDialog();
        }

        #region 备份数据

        private void 备份数据ToolStripMenuItem_Click(object sender, EventArgs e) {
            Zip(Application.StartupPath + "\\Temp\\" + DateTime.Now.ToLongDateString() + "\\bak_config.zip", Application.StartupPath + @"\Config\");
            EchoHelper.Echo("备份数据配置文件成功！" + "\\Temp\\" + DateTime.Now.ToLongDateString() + "\\bak_config.zip", "系统", EchoHelper.EchoType.任务信息);
        }

        public void Zip(string filename, string directory) {
            try {
                _createDirtory(filename);
                FastZip fz = new FastZip();
                fz.CreateEmptyDirectories = true;
                fz.CreateZip(filename, directory, true, "");
                fz = null;
            } catch {
            }
        }
        //创建目录
        private void _createDirtory(string path) {
            if (!File.Exists(path)) {
                string[] dirArray = path.Split('\\');
                string temp = string.Empty;
                for (int i = 0; i < dirArray.Length - 1; i++) {
                    temp += dirArray[i].Trim() + "\\";
                    if (!Directory.Exists(temp))
                        Directory.CreateDirectory(temp);
                }
            }
        }

        #endregion

        private void dnsPod批量设置ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_DnsPod dnspod = new X_Form_DnsPod();
            dnspod.ShowDialog();
        }

        private void 抓取模块下载ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_MainFormBrowser bw = new X_Form_Main().getBrowser();
            bw.Show();
            bw.GotoPage("http://www.renzhe.org/forum.php?mod=forumdisplay&fid=36&filter=typeid&typeid=21");
        }

        private void 自己的路批量上站ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_ZijideLu zijidelu = new X_Form_ZijideLu();
            zijidelu.ShowDialog();
        }

        private void 忍者全局优化ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_Advanced_Settings adseting = new X_Form_Advanced_Settings();
            adseting.ShowDialog();
        }

        private void VIP特权ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_Invite x = new X_Form_Invite();
            x.ShowDialog();
        }

        private void 启动浏览器_Click(object sender, EventArgs e) {
            try {
                getBrowser().Show();
            } catch (Exception ex) {
                EchoHelper.Show("浏览器内核，启动失败！请下载最新20M的软件包，并安装微软：vcredist补丁！", EchoHelper.MessageType.错误);
                EchoHelper.EchoException(ex);
            }
        }

        private static X_Form_MainFormBrowser browser = new X_Form_MainFormBrowser();

        public X_Form_MainFormBrowser getBrowser() {
            if (browser == null) {
                browser = new X_Form_MainFormBrowser();
            }
            return browser;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e) {
            关于_Click(sender, e);
        }



    }
}
