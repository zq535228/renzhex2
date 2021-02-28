using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using X_Model;
using X_PostKing.Job;
using X_Service.Db;
using X_Service.Files;
using X_Service.org.renzhe.serv;
using X_Service.Util;


namespace X_PostKing {
    public partial class X_Form_AddSitePostEdit : X_Form_BaseTool {

        #region 构造函数&初始化
        public ModelSite site = null;
        private X_Waiting wait = new X_Waiting();

        public X_Form_AddSitePostEdit(ModelSite web) {
            InitializeComponent();
            site = web;
        }

        #endregion

        #region 事件
        private void Btn_编辑状态_Click(object sender, EventArgs e) {
            X_Form_AddSitePostEdit01Login loginParam = new X_Form_AddSitePostEdit01Login(site);
            this.Hide();
            if (loginParam.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                site = loginParam.site;
            }
            loginParam.Close();
            Loaded();
            this.Show();
        }

        private void Btn_EditCategories_Click(object sender, EventArgs e) {
            X_Form_AddSitePostEdit02Cate cate = new X_Form_AddSitePostEdit02Cate(site);
            this.Hide();
            if (cate.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                site = cate.site;
            }
            cate.Close();
            Loaded();
            this.Show();
        }

        private void Btn_Edit_Click(object sender, EventArgs e) {
            X_Form_AddSitePostEdit03Put put = new X_Form_AddSitePostEdit03Put(site);
            this.Hide();
            if (put.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                site = put.site;
            }
            put.Close();
            Loaded();
            this.Show();
        }

        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void TS_保存_Click(object sender, EventArgs e) {
            DbTools db = new DbTools();
            string strFile = "";

            if (ckIsPub.Enabled == true) {//代表已经成功的验证，是具有编写权限。
                if (string.IsNullOrEmpty(txtSiteModuleName.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "模块名称是必须的！", txtSiteModuleName);
                    return;
                }
                save();
                strFile = Application.StartupPath + "\\Module\\" + site.SiteModuleName;
                db.Save(strFile, "WCNM", site);
            }


            if (site.IsPub && ckIsPub.Enabled == true) {
                if (string.IsNullOrEmpty(txtModelAuthor.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "为了分享，填上您的大名吧！", txtModelAuthor);
                    return;
                }
                if (string.IsNullOrEmpty(txtModelEmail.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "为了分享，填上您的Email吧！", txtModelEmail);
                    return;
                }
                if (string.IsNullOrEmpty(txtModelQQ.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "为了分享，填上您的QQ吧！", txtModelQQ);
                    return;
                }

                if (string.IsNullOrEmpty(txtModelPassWord.Text) && ckIsPub.Enabled == true) {
                    EchoHelper.ShowBalloon("信息不全", "为了您的劳动成果不被侵犯，加密吧！", txtModelPassWord);
                    return;
                }

                if (string.IsNullOrEmpty(txtModelUrl.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "为了分享，填上这个模块的教程链接吧！", txtModelUrl);
                    return;
                }
                if (string.IsNullOrEmpty(txtModelDescription.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "为了分享，填上这个模块的说明吧！", txtModelDescription);
                    return;
                }

                //分享到模块市场中。
                wait.ShowMsg("分享" + site.SiteModuleName + "到忍者模块市场中...");
                string fileClassStr = FilesHelper.Read_File(strFile);
                try {
                    ServiceShop serv = new ServiceShop();
                    serv.Timeout = 10000;
                    serv.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:5.0) Gecko/20100101 Firefox/5.0";
                    serv.UnsafeAuthenticatedConnectionSharing = true;
                    serv.AllowAutoRedirect = false;

                    bool isok = serv.UploadClassStr(site.SiteModuleName, fileClassStr, mType.发布模块);
                    Thread.Sleep(500);
                    if (isok) {
                        EchoHelper.Echo("分享模块成功！忍者对您的贡献表示感谢！", "模块市场", EchoHelper.EchoType.普通信息);
                    } else {
                        EchoHelper.Show("分享失败！原因可能是：\n1、已存在模块与您的密码不符\n2、网络问题！", EchoHelper.MessageType.错误);
                        return;
                    }
                } catch (Exception ex) {
                    EchoHelper.Show("上传失败,请重试！", EchoHelper.MessageType.警告);
                    EchoHelper.EchoException(ex);
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                } finally {
                    wait.CloseMsg();
                }
            }

            SaveAll();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        #endregion

        private void save() {
            //发布模块信息保存
            site.SiteModuleName = txtSiteModuleName.Text.Contains(".rzmb") ? txtSiteModuleName.Text : txtSiteModuleName.Text + ".rzmb";
            site.ModelUrl = txtModelUrl.Text;
            site.ModelQQ = txtModelQQ.Text;
            site.ModelPassWord = txtModelPassWord.Text;
            site.ModelEmail = txtModelEmail.Text;
            site.ModelAuthor = txtModelAuthor.Text.Contains("调试") ? "Qin" : txtModelAuthor.Text;
            site.SiteModelDescription = txtModelDescription.Text;
            site.IsPub = ckIsPub.Checked;
            //web内核参数保存。
            site.WebLogin = txtWebLogin.Text;
            site.WebPut = txtWebPut.Text;

        }
        private void Loaded() {
            if (site.modelUsers.Count == 0) {
                Btn_EditCategories.Enabled = false;
                Btn_EditPost.Enabled = false;
                Btn_EditVisit.Enabled = false;
                btn_测试发布.Enabled = false;
                Btn_测试分类.Enabled = false;
            } else {
                Btn_EditCategories.Enabled = true;
                Btn_EditPost.Enabled = true;
                Btn_EditVisit.Enabled = true;
                btn_测试发布.Enabled = true;
                Btn_测试分类.Enabled = true;
            }
            La_FangAn.Text = site.LoginType.ToString();
            if (site.CategoriesIsEnablad) {
                label5.Text = "启动自动获取分类功能";
            } else {
                label5.Text = "手动填写分类信息";
            }

            txtModelUrl.Text = site.ModelUrl;
            txtModelQQ.Text = site.ModelQQ;
            txtSiteModuleName.Text = site.SiteModuleName.Contains("0o0o请选择发布模块0o0o") ? "" : site.SiteModuleName;
            txtModelEmail.Text = string.IsNullOrEmpty(site.ModelEmail) ? member.email : site.ModelEmail;
            txtModelAuthor.Text = string.IsNullOrEmpty(site.ModelAuthor) ? member.netname : site.ModelAuthor;
            txtModelDescription.Text = site.SiteModelDescription;
            ckIsPub.Checked = site.IsPub;

            txtWebLogin.Text = site.WebLogin;
            txtWebPut.Text = site.WebPut;

        }


        private void X_Form_AddSitePostEdit_Load(object sender, EventArgs e) {
            Loaded();
            tabControl_SelectedIndexChanged(sender, e);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e) {
            setModelInfo();
            switch (tabControl.SelectedIndex) {
                case 0: {
                        tabControl.Size = new Size(tabControl.Size.Width, groupBox6.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip2.Size.Height + tabControl.Size.Height + 30 + 22);
                        break;
                    }
                case 1: {
                        if (!string.IsNullOrEmpty(site.ModelPassWord) && txtModelPassWord.Text != site.ModelPassWord) {
                            tabControl.SelectedIndex = 0;
                            EchoHelper.Show("忍者发布模块版权所有，请输入密码，方可进入编辑模式！", EchoHelper.MessageType.警告);
                            txtModelPassWord.Focus();
                            break;
                        }
                        tabControl.Size = new Size(tabControl.Size.Width, groupBox1.Size.Height + groupBox2.Size.Height + groupBox3.Size.Height + groupBox7.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip2.Size.Height + tabControl.Size.Height + 30 + 22);
                        break;
                    }
                case 2: {
                        if (!string.IsNullOrEmpty(site.ModelPassWord) && txtModelPassWord.Text != site.ModelPassWord) {
                            tabControl.SelectedIndex = 0;
                            EchoHelper.Show("忍者发布模块版权所有，请输入密码，方可进入编辑模式！", EchoHelper.MessageType.警告);
                            txtModelPassWord.Focus();
                            break;
                        }
                        tabControl.Size = new Size(tabControl.Size.Width, groupBox5.Size.Height + groupBox4.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip2.Size.Height + tabControl.Size.Height + 30 + 22);
                        break;
                    }
            }
        }

        //设置发布模块的版权信息
        private void setModelInfo() {
            if (string.IsNullOrEmpty(site.ModelPassWord) || txtModelPassWord.Text == site.ModelPassWord) {
                txtModelAuthor.Enabled = true;
                txtModelDescription.Enabled = true;
                txtModelEmail.Enabled = true;
                txtModelQQ.Enabled = true;
                txtModelUrl.Enabled = true;
                ckIsPub.Enabled = true;
            } else {
                txtModelAuthor.Enabled = false;
                txtModelDescription.Enabled = false;
                txtModelEmail.Enabled = false;
                txtModelQQ.Enabled = false;
                txtModelUrl.Enabled = false;
                ckIsPub.Enabled = false;
            }

            txtSiteModuleName.Enabled = site.SiteModuleName.Contains("0o0o请选择发布模块0o0o") || string.IsNullOrEmpty(txtSiteModuleName.Text);
        }


        private void btnEditVisit_Click(object sender, EventArgs e) {
            X_Form_AddSitePostEdit04Visit visit = new X_Form_AddSitePostEdit04Visit(site);
            this.Hide();
            if (visit.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                site = visit.site;
            }
            visit.Close();
            Loaded();
            this.Show();
        }

        private void Btn_测试分类_Click(object sender, EventArgs e) {
            int UserId = 0;
            X_Form_Users user = new X_Form_Users(site);
            if (user.ShowDialog() == DialogResult.OK) {
                UserId = StringHelper.getRandNum(user.SelectIds);
                if (site.CategoriesIsEnablad) {
                    X_Form_Cate cate = new X_Form_Cate(site, UserId);
                    if (cate.ShowDialog() == DialogResult.OK) {
                    }
                    cate.Dispose();
                    cate.Close();
                }
            }
            user.Close();

        }

        private void btn_测试发布_Click(object sender, EventArgs e) {
            int UserId = 0;
            X_Form_Users user = new X_Form_Users(site);
            if (user.ShowDialog() == DialogResult.OK) {
                UserId = StringHelper.getRandNum(user.SelectIds);
                if (site.CategoriesIsEnablad) {
                    X_Form_Cate cate = new X_Form_Cate(site, UserId);
                    if (cate.ShowDialog() == DialogResult.OK) {
                        EchoHelper.Show("此过程小慢，勿动，请稍后。。。", EchoHelper.MessageType.提示);
                        site = cate.SiteInfo;
                    }
                    cate.Dispose();
                    cate.Close();
                }
                Thread th = new Thread(new ParameterizedThreadStart(Test_Post));
                th.IsBackground = true;
                th.Start(UserId);
            }
            user.Close();

        }
        /// <summary>
        /// 测试发布
        /// </summary>
        /// <param name="id">测试用户的ID</param>
        private void Test_Post(object id) {
            int userID = (int)id;
            JobCoreTest test = new JobCoreTest(site, FindModelUserByID(site, userID));
            string html = test.Post();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string text = "";

                if (link.Tag.ToString().Contains(".*?") || link.Tag.ToString().Contains("后台地址") || link.Tag.ToString().Contains("网站域名")) {
                    text = link.Tag.ToString();
                } else {
                    text = "→" + link.Tag.ToString();
                }
                Clipboard.SetText(text);
                txtWebLogin.Paste();
                Clipboard.Clear();
            } catch {

            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string text = "";

                if (link.Tag.ToString().Contains(".*?") || link.Tag.ToString().Contains("后台地址") || link.Tag.ToString().Contains("网站域名")) {
                    text = link.Tag.ToString();
                } else {
                    text = "→" + link.Tag.ToString();
                }

                Clipboard.SetText(text);
                txtWebPut.Paste();
                Clipboard.Clear();
            } catch {

            }

        }

        private void linkGOTO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ProcessHelper.openUrl(txtModelUrl.Text);
        }

        private void buttonSpecAny1_Click(object sender, EventArgs e) {
            X_Form_InputBox inputbox = new X_Form_InputBox(txtWebLogin.Text);
            inputbox.Width = 1000;
            if (inputbox.ShowDialog() == DialogResult.OK) {
                txtWebLogin.Text = inputbox.InputStr;
            }

        }

        private void buttonSpecAny2_Click(object sender, EventArgs e) {
            X_Form_InputBox inputbox = new X_Form_InputBox(txtWebPut.Text);
            inputbox.Width = 1000;
            if (inputbox.ShowDialog() == DialogResult.OK) {
                txtWebPut.Text = inputbox.InputStr;
            }

        }

        private void txtModelPassWord_TextChanged(object sender, EventArgs e) {
            setModelInfo();
        }

        private void ckIsPub_CheckedChanged(object sender, EventArgs e) {
            if (ckIsPub.Checked == true && member.userMoney < 2000) {
                ckIsPub.Checked = false;
                EchoHelper.Show("您的积分太少啦，没有贡献模块的权限！", EchoHelper.MessageType.警告);
            }
        }


    }
}
