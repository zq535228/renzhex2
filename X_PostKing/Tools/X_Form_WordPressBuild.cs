using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using X_Service.Util;
using X_Service.Files;
using System.Threading;
using X_Service.Db;
using X_Service.Web;
using X_Service.Login;

namespace X_PostKing.Tools {

    public partial class X_Form_WordPressBuild : X_Form_BaseTool {

        public X_Form_WordPressBuild() {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        string txtWpPath;
        string txtOutPath;

        private void X_Form_WordPressBuild_Load(object sender, EventArgs e) {
            txtWpPath = Application.StartupPath;
            txtOutPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            try {
                txtPID.Text = ini.re("快速建站信息", "淘宝PID");
                txt数据库连接.Text = ini.re("快速建站信息", "数据库连接");
                txt数据库名.Text = ini.re("快速建站信息", "数据库名");
                txt用户名.Text = ini.re("快速建站信息", "用户名");
                txt密码.Text = ini.re("快速建站信息", "密码");
            } catch (Exception ex) {
                EchoHelper.Echo("Setup信息读取出错啦.", ex.Message, EchoHelper.EchoType.异常信息);
            }

            if (!Login_Base.member.group.Contains("商业授权用户")) {
                tabControlWP淘宝客.Enabled = false;
                EchoHelper.Show("您的权限不足！", EchoHelper.MessageType.错误);
                this.TopMost = true;
            }
        }


        private void textBox10_TextChanged(object sender, EventArgs e) {

        }


        private void button生成_Click(object sender, EventArgs e) {

            if (string.IsNullOrEmpty(txt网站名称.Text)) {
                EchoHelper.Show("网站名称必填！", EchoHelper.MessageType.错误);
                return;
            }
            if (string.IsNullOrEmpty(txt淘宝客地址.Text)) {
                EchoHelper.Show("淘宝客关键词必填！", EchoHelper.MessageType.错误);
                return;
            }

            if (string.IsNullOrEmpty(txt网站名称.Text)) {
                EchoHelper.Show("网站名称必填！", EchoHelper.MessageType.错误);
                return;
            }
            if (string.IsNullOrEmpty(txtPID.Text)) {
                EchoHelper.Show("淘宝PID无法生成，请填写淘宝账户！", EchoHelper.MessageType.错误);
                return;
            }

            if (string.IsNullOrEmpty(txtOutPath)) {
                EchoHelper.Show("输出路径未选择！", EchoHelper.MessageType.错误);
                return;
            }
            ini.up("快速建站信息", "数据库连接", txt数据库连接.Text);
            ini.up("快速建站信息", "数据库名", txt数据库名.Text);
            ini.up("快速建站信息", "用户名", txt用户名.Text);
            ini.up("快速建站信息", "密码", txt密码.Text);
            ini.up("快速建站信息", "淘宝PID", txtPID.Text);

            new Thread(new ThreadStart(ThStart)).Start();
            button生成.Enabled = false;
        }

        protected void ThStart() {

            if (Directory.Exists(txtOutPath)) {
                EchoHelper.Echo("发现目标文件，准备清理中。。。" + txtOutPath, "输出路径", EchoHelper.EchoType.普通信息);
                if (MessageBox.Show("发现目标文件是否清理?", "确认", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) {
                    FilesHelper.DeleteInDir(txtOutPath);
                } else {
                    return;
                }
                EchoHelper.Echo("目标文件存在，清理成功。" + txtOutPath, "输出路径", EchoHelper.EchoType.普通信息);
            }

            ModelWordPress wordpress = new ModelWordPress();
            wordpress.密码 = txt密码.Text;
            wordpress.数据库连接 = txt数据库连接.Text;
            wordpress.数据库名 = txt数据库名.Text;
            wordpress.淘宝客地址 = txt淘宝客地址.Text;
            wordpress.淘宝客关键词 = txt淘宝客关键词.Text;
            wordpress.网站SEO标题 = txt网站SEO标题.Text;
            wordpress.网站地址 = txt网站地址.Text;
            wordpress.网站关键词 = txt网站关键词.Text;
            wordpress.网站简介 = txt网站简介.Text;
            wordpress.网站描述 = txt网站描述.Text;
            wordpress.网站名称 = txt网站名称.Text;
            wordpress.用户名 = txt用户名.Text;
            wordpress.模版路径 = txtWpPath;
            wordpress.输出路径 = txtOutPath;
            wordpress.淘宝PID = txtPID.Text;

            EchoHelper.Echo("保存配置信息！" + txtWpPath, "保存配置", EchoHelper.EchoType.普通信息);
            Save(txtWpPath + "\\Temp\\" + txt网站名称.Text + ".tk", wordpress);
            EchoHelper.Echo("整理文件中，请稍等！" + txtOutPath, "输出路径", EchoHelper.EchoType.任务信息);

            try {
                ZipHelper.UnZip(txtWpPath + "\\X_Wordpress.dll", txtOutPath);
                EchoHelper.Echo("保存配置文件！" + txtWpPath + "\\" + txt网站名称.Text + ".tk", "输出路径", EchoHelper.EchoType.普通信息);
            } catch {
                EchoHelper.Echo("解压程序出错，请检查设置或下载最新版本重试！", "解压失败", EchoHelper.EchoType.错误信息);
                return;
            }

            string sqlStr = txtOutPath + @"\sql.sql";
            string taobaoApiStr = txtOutPath + @"\wp-content\themes\xiaohan\myop.php";
            string connStr = txtOutPath + @"\wp-config.php";
            string taobaopid = txtOutPath + @"\tapi\banner940.php";
            string power = txtOutPath + @"\wp-content\themes\xiaohan\footer.php";
            string index = txtOutPath + @"\wp-content\themes\xiaohan\index.php";

            replaceStr(sqlStr);
            replaceStr(taobaoApiStr);
            replaceStr(connStr);
            replaceStr(taobaopid);
            replaceStr(power);
            replaceStr(index);
            kryptonTextBox1.Text = kryptonTextBox1.Text.Replace("[淘宝客关键词]", txt淘宝客关键词.Text);
            button生成.Enabled = true;
            EchoHelper.Echo("淘宝客模版生成成功！", "模块生成", EchoHelper.EchoType.普通信息);
            MessageBox.Show("淘宝客模版生成成功。");
        }

        private void Save(string tmp_path, object obj) {
            DbTools db = new DbTools();
            EchoHelper.Echo("正在保存信息...", "系统", EchoHelper.EchoType.任务信息);
            db.Save(tmp_path, "VCDS", obj);
            EchoHelper.Echo("数据信息保存完成！", "系统", EchoHelper.EchoType.任务信息);
        }

        static public string TrueLength(string str) {
            int lenTotal = 0;
            int n = str.Length;
            string strWord = "";
            int asc;
            for (int i = 0; i < n; i++) {
                strWord = str.Substring(i, 1);
                asc = Convert.ToChar(strWord);
                if (asc < 0 || asc > 127)
                    lenTotal = lenTotal + 3;
                else
                    lenTotal = lenTotal + 1;
            }
            return lenTotal.ToString();
        }
        //替换
        private void replaceStr(string path) {
            string fileStr = FilesHelper.ReadFile(path, null);
            fileStr = fileStr.Replace("[网站名称]", txt网站名称.Text);
            fileStr = fileStr.Replace("[网站地址]", txt网站地址.Text);
            fileStr = fileStr.Replace("[网站地址banner.gif]", TrueLength(txt网站地址.Text + "wp-content/uploads/2011/04/banner.gif"));
            fileStr = fileStr.Replace("[网站地址Google]", TrueLength(txt网站地址.Text + "link: - Google Blog Search"));
            fileStr = fileStr.Replace("[网站地址blogsearch]", TrueLength("http://blogsearch.google.com/blogsearch_feeds?scoring=d&ie=utf-8&num=10&output=rss&partner=wordpress&q=link:" + txt网站地址.Text));
            fileStr = fileStr.Replace("[网站地址num]", TrueLength(txt网站地址.Text));

            fileStr = fileStr.Replace("[网站简介]", txt网站简介.Text);
            fileStr = fileStr.Replace("[网站简介num]", TrueLength(txt网站简介.Text));

            fileStr = fileStr.Replace("[网站SEO标题]", txt网站SEO标题.Text);
            fileStr = fileStr.Replace("[网站SEO标题num]", TrueLength(txt网站SEO标题.Text));

            fileStr = fileStr.Replace("[网站关键词]", txt网站关键词.Text);
            fileStr = fileStr.Replace("[网站关键词num]", TrueLength(txt网站关键词.Text));

            fileStr = fileStr.Replace("[网站描述]", txt网站描述.Text);
            fileStr = fileStr.Replace("[网站描述num]", TrueLength(txt网站描述.Text));


            fileStr = fileStr.Replace("[淘宝客关键词]", txt淘宝客关键词.Text);
            fileStr = fileStr.Replace("[淘宝客地址]", txt淘宝客地址.Text);
            fileStr = fileStr.Replace("[淘宝PID]", txtPID.Text);

            fileStr = fileStr.Replace("[数据库连接]", txt数据库连接.Text);
            fileStr = fileStr.Replace("[数据库名]", txt数据库名.Text);
            fileStr = fileStr.Replace("[用户名]", txt用户名.Text);
            fileStr = fileStr.Replace("[密码]", txt密码.Text);

            string tmp_p = "本程序由<a href='http://www.renzhe.org'>忍者站群</a>生成";
            tmp_p += ",本程序由<a href='http://www.renzhe.org'>忍者软件</a>生成";
            tmp_p += ",本程序由<a href='http://www.renzhe.org'>忍者X2</a>生成";
            tmp_p += ",本程序由<a href='http://www.renzhe.org'>站群系统</a>生成";
            tmp_p += ",本程序由<a href='http://www.renzhe.org'>站群软件</a>生成";
            tmp_p += ",本程序由<a href='http://www.renzhe.org'>免费站群</a>生成";
            string tmp_i = StringHelper.getRandStr(tmp_p);
            fileStr = fileStr.Replace("[版权链接]", tmp_i);

            if (isQiangj.Checked) {
                fileStr = fileStr.Replace("[强奸推广]", "4000");
            } else {
                fileStr = fileStr.Replace("[强奸推广]", "60000");
            }

            FilesHelper.DeleteFile(path);
            EchoHelper.Echo("删除文件成功！" + path, "替换变量", EchoHelper.EchoType.任务信息);

            FilesHelper.Write_File(path, fileStr);
            EchoHelper.Echo("重新写入文件！" + path, "替换变量", EchoHelper.EchoType.任务信息);

        }

        public static void Copy(string dir1, string dir2) {
            //如果要被复制的文件夹不存在，程序返回。
            if (!Directory.Exists(dir1))
                return;
            //如果目标文件夹不存在，则创建它。
            if (!Directory.Exists(dir2))
                Directory.CreateDirectory(dir2);
            //给文件夹添加分隔符“\”               
            if (!dir1.EndsWith("\\"))
                dir1 += "\\";
            if (!dir2.EndsWith("\\"))
                dir2 += "\\";
            //复制文件。递归出口为当前目录下无文件。
            string[] files = Directory.GetFiles(dir1);
            if (files.Length != 0) {
                foreach (string f in files)

                    if (!File.Exists(dir2 + Path.GetFileName(f)) && CanOpen(f) && !f.EndsWith(".tk")) {
                        File.Copy(f, dir2 + Path.GetFileName(f));
                    }

            }
            //复制子目录。递归出口为当前目录下无子目录。
            DirectoryInfo di = new DirectoryInfo(dir1);
            DirectoryInfo[] subdirsInfo = di.GetDirectories();
            if (subdirsInfo.Length != 0) {
                foreach (DirectoryInfo sdi in subdirsInfo) {
                    Copy(sdi.FullName, dir2 + sdi);
                }
            }

        }

        /// <summary>
        /// 文件是否可读。是否可操作。
        /// </summary>
        /// <param name="path">文件路径。</param>
        /// <returns>能否操作。true、false。</returns>
        public static bool CanOpen(string path) {
            bool canOpen = true;
            try {
                FileStream fs = new FileStream(path, FileMode.Open);
                if (fs != null)
                    fs.Close();
                fs.Dispose();
            } catch {
                canOpen = false;
            }
            return canOpen;
        }


        private void button5_Click(object sender, EventArgs e) {
            openFileDialog打开tk文件.Filter = "丽丽淘宝客(*.tk)|*.tk";
            openFileDialog打开tk文件.FileName = "*.tk";

            if (openFileDialog打开tk文件.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                DbTools db = new DbTools();
                object ob = db.Read(openFileDialog打开tk文件.FileName, "VCDS");
                if (ob == null) {
                    EchoHelper.Echo("模块加载失败！", "模块加载", EchoHelper.EchoType.错误信息);
                    return;
                }
                ModelWordPress wordpress = new ModelWordPress();
                try {
                    wordpress = (ModelWordPress)ob;
                } catch { }

                txt密码.Text = wordpress.密码;
                txt数据库连接.Text = wordpress.数据库连接;
                txt数据库名.Text = wordpress.数据库名;
                txt淘宝客关键词.Text = wordpress.淘宝客关键词;
                txt淘宝客地址.Text = wordpress.淘宝客地址;
                txt网站SEO标题.Text = wordpress.网站SEO标题;
                txt网站地址.Text = wordpress.网站地址;
                txt网站关键词.Text = wordpress.网站关键词;
                txt网站简介.Text = wordpress.网站简介;
                txt网站描述.Text = wordpress.网站描述;
                txt网站名称.Text = wordpress.网站名称;
                txt用户名.Text = wordpress.用户名;
                txtWpPath = wordpress.模版路径;
                txtOutPath = wordpress.输出路径;
                EchoHelper.Echo("读取模块信息成功！", "", EchoHelper.EchoType.普通信息);

            }
        }

        private void txt网站SEO标题_TextChanged(object sender, EventArgs e) {
            txt网站关键词.Text = txt网站SEO标题.Text.Replace(" - 100%正品√√√", "").Replace("_", ",");
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Console.WriteLine("mysql -u " + txt用户名.Text + " -p " + txt密码.Text + "");
        }

        private void txt数据库连接_TextChanged(object sender, EventArgs e) {

        }

        private void linkLabel13_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {

        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            //checkDomainValid();
        }

        private void txt网站地址_Leave(object sender, EventArgs e) {
            if (!txt网站地址.Text.EndsWith("/")) {
                EchoHelper.Show("网址格式不符，请确保结尾的/没有忘记", EchoHelper.MessageType.警告);
                txt网站地址.Focus();
            }
        }

        private void txt网站名称_TextChanged(object sender, EventArgs e) {
            //ckValidate.Checked = true;
            linkLabel14.Text = txt网站地址.Text + "wp-admin/";
            txtOutPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + txt网站名称.Text;
        }

        private void linkLabel13_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e) {


        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ProcessHelper.openUrl("http://www.renzhe.org/pub_tapi/banner940.php?kw=" + StringHelper.urlencode(txt淘宝客关键词.Text) + "&srate=800&erate=4000&dazhe=0.20");
        }

        private void btnClearInfo_Click(object sender, EventArgs e) {
            ModelWordPress wordpress = new ModelWordPress();
            //txt密码.Text = wordpress.密码;
            //txt数据库连接.Text = wordpress.数据库连接;
            //txt数据库名.Text = wordpress.数据库名;
            txt淘宝客关键词.Text = wordpress.淘宝客关键词;
            txt淘宝客地址.Text = wordpress.淘宝客地址;
            txt网站SEO标题.Text = wordpress.网站SEO标题;
            txt网站地址.Text = wordpress.网站地址;
            txt网站关键词.Text = wordpress.网站关键词;
            txt网站简介.Text = wordpress.网站简介;
            txt网站描述.Text = wordpress.网站描述;
            txt网站名称.Text = wordpress.网站名称;
            txt用户名.Text = wordpress.用户名;
            txtWpPath = wordpress.模版路径;
            txtOutPath = wordpress.输出路径;
        }

    }
}
