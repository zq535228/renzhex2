using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using X_Model;
using X_Service.Util;
using X_PostKing.Job;
using ComponentFactory.Krypton.Toolkit;

namespace X_PostKing {
    public partial class X_Form_AddSitePostEdit01Login : X_Form_BaseTool {
        #region 构造函数
        public ModelSite site = new ModelSite();
        public X_Form_AddSitePostEdit01Login(ModelSite web) {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            this.site = web;
        }
        #endregion

        #region 事件

        //是否需要验证码
        private void Check_NeedVerify_CheckedChanged(object sender, EventArgs e) {
            Text_VerifyUrl.Enabled = Check_NeedVerify.Checked;

        }

        private void Btn_提取马甲信息_Click(object sender, EventArgs e) {
            this.Hide();
            X_Form_HttpWatch majia = new X_Form_HttpWatch(Text_MVerifyUrl.Text.Replace("[后台地址]", site.SiteBackUrl), "提取马甲参数");
            if (majia.ShowDialog() == DialogResult.OK) {
                Text_MVerifyUrl.Text = majia.ThisWebData.Url;
                Text_Referer.Text = majia.ThisWebData.Referer;
                //SiteInfo
                Save();
                Loaded();
                majia.Dispose();
                majia.Close();
            } else {
                majia.Dispose();
                majia.Close();
            }
            this.Show();
        }

        private void Btn_LoginParameters_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("重新提取登陆参数会原有数据，是否重新提取？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                this.Hide();
                X_Form_HttpWatch majia = new X_Form_HttpWatch(Text_LoginUrl.Text.Replace("[后台地址]", site.SiteBackUrl), "提取登陆参数");
                if (majia.ShowDialog() == DialogResult.OK) {
                    Text_LoginParameters.Text = majia.ThisWebData.Parameters.Trim();
                    Text_LoginUrl.Text = majia.ThisWebData.Url.Trim();
                    Text_Referer.Text = majia.ThisWebData.Referer.Trim();
                    Save();
                    Loaded();
                    majia.Dispose();
                    majia.Close();
                } else {
                    majia.Dispose();
                    majia.Close();
                }
                this.Show();
            }

        }

        private void Btn_TestLogin_Click(object sender, EventArgs e) {
            Save();
            if (site.LoginType == LoginType.自动登陆模式) {
                if (!site.LoginParameters.Contains("[用户名") | !site.LoginParameters.Contains("[密码")) {
                    EchoHelper.ShowBalloon("系统提示", "大侠，您貌似没有替换变量哦！", Text_LoginParameters);
                    EchoHelper.Echo("大侠，您貌似没有替换变量哦！", "系统", EchoHelper.EchoType.任务信息);
                    return;
                }

            }
            X_Form_Users user = new X_Form_Users(site);
            if (user.ShowDialog() == DialogResult.OK) {
                EchoHelper.Show("此过程小慢，别动，请稍后。。。", EchoHelper.MessageType.提示);
                Thread th = new Thread(new ParameterizedThreadStart(Test_Login));
                th.IsBackground = true;
                th.Start(GetLogin_ID(user.SelectIds));
            }
            user.Close();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string Text = link.Tag.ToString();
                Clipboard.SetText(Text);
                Text_LoginParameters.Paste();
                Clipboard.Clear();
            } catch {

            }

        }

        private void TS_保存_Click(object sender, EventArgs e) {
            Save();
            if (site.LoginType == LoginType.自动登陆模式) {
                if (!site.LoginParameters.Contains("[用户名") || !site.LoginParameters.Contains("[密码")) {
                    EchoHelper.ShowBalloon("系统提示", "大侠，您貌似没有替换变量哦！", Text_LoginParameters);
                    EchoHelper.Echo("大侠，您貌似没有替换变量哦！", "系统", EchoHelper.EchoType.任务信息);
                    return;
                }
            } else {
                if (site.LoginMVerifyUrl == string.Empty) {
                    EchoHelper.ShowBalloon("系统提示", "大侠，马甲验证地址要填写哦！", Text_MVerifyUrl);
                    EchoHelper.Echo("大侠，马甲验证地址要填写哦！", "系统", EchoHelper.EchoType.任务信息);
                    return;
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void X_Form_AddSitePostEdit01Login_Load(object sender, EventArgs e) {
            Loaded();

            //根据不同的登陆模式,加载不同的gbox,高度也做了相应的调整.
            int ch = site.LoginType == LoginType.自动登陆模式 ? GBox模拟.Height : GBox马甲.Height;
            int h = groupBox4.Height + groupBox2.Height + ch;
            tabControl1.Size = new Size(tabControl1.Size.Width, h + 37);
            this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControl1.Size.Height + 30 + 22);

        }
        #endregion

        #region 方法

        #region 保存

        #endregion

        #region Loaded

        private void Loaded() {
            if (site.LoginType == LoginType.自动登陆模式) {
                GBox马甲.Visible = false;
            } else {
                GBox模拟.Visible = false;
            }
            Text_LoginParameters.Text = site.LoginParameters;
            Text_MVerifyUrl.Text = site.LoginMVerifyUrl;
            if (string.IsNullOrEmpty(Text_MVerifyUrl.Text)) {
                Text_MVerifyUrl.Text = site.SiteBackUrl;
            }

            Text_LoginUrl.Text = site.LoginLoginUrl;
            if (string.IsNullOrEmpty(Text_LoginUrl.Text)) {
                Text_LoginUrl.Text = site.SiteBackUrl;
            }

            Text_Referer.Text = site.LoginReferer;
            Text_VerifyUrl.Text = site.LoginVerifyUrl;
            Rich_Fail.Text = site.LoginFailText;
            Rich_Succeed.Text = site.LoginSucceedText;
            Check_UTF.Checked = site.LoginIsUtf8;
            Check_NeedVerify.Checked = site.LoginNeedVerify;
            Text_VerifyUrl.Enabled = Check_NeedVerify.Checked;
            txtCookies.Text = site.LoginCookies;
        }

        private void Save() {
            site.LoginParameters = Text_LoginParameters.Text;
            site.LoginMVerifyUrl = Text_MVerifyUrl.Text;
            site.LoginLoginUrl = Text_LoginUrl.Text;
            site.LoginReferer = Text_Referer.Text;
            site.LoginVerifyUrl = Text_VerifyUrl.Text;
            site.LoginFailText = Rich_Fail.Text;
            site.LoginSucceedText = Rich_Succeed.Text;
            site.LoginIsUtf8 = Check_UTF.Checked;
            site.LoginNeedVerify = Check_NeedVerify.Checked;
            site.LoginCookies = txtCookies.Text;
            //site.LoginSocket = CK_socket.Checked;
        }

        #endregion

        public int GetLogin_ID(string str) {
            string[] arr = str.Split(',');
            Random r = new Random();
            return int.Parse(arr[r.Next(0, arr.Length - 1)]);
        }
        /// <summary>
        /// 测试登陆
        /// </summary>
        /// <param name="userID">测试用户的ID</param>
        private void Test_Login(object userID) {
            try {
                int id = (int)userID;
                JobCoreTest test = new JobCoreTest(site, FindModelUserByID(site, id));
                string html = test.Login();
                site = test.Site;
                Rich_Html.Text = html;
                Web_Browser.DocumentText = html;
                this.Enabled = true;
            } catch {
            }
        }


        #endregion

        private void buttonSpecAny1_Click(object sender, EventArgs e) {
            X_Form_InputBox inputbox = new X_Form_InputBox(Text_LoginParameters.Text);
            if (inputbox.ShowDialog() == DialogResult.OK) {
                Text_LoginParameters.Text = inputbox.InputStr;
            }

        }


    }
}
