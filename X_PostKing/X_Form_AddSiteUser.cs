using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Model;
using X_Service.Util;

namespace X_PostKing {
    public partial class X_Form_AddSiteUser : X_Form_BaseTool {
        #region 构造函数
        public ModelUsers user = new ModelUsers();
        public String URL = "";
        public string Cookie = "";

        public X_Form_AddSiteUser(ModelUsers user, string Url = "") {
            InitializeComponent();
            tabControl1.TabPages.Clear();

            if (user.LoginMethod == LoginMethod.用户名登陆) {
                tabControl1.TabPages.Add(tabPage1);
                tabControl1.Size = new Size(tabControl1.Size.Width, groupBox1.Size.Height + 37);
                this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControl1.Size.Height + 30 + 22);
            } else {
                URL = Url;
                tabControl1.TabPages.Add(tabPage2);
                tabControl1.Size = new Size(tabControl1.Size.Width, groupBox2.Size.Height + groupBox3.Size.Height + 37);
                this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControl1.Size.Height + 30 + 22);

            }
            this.user = user;
        }
        #endregion

        #region 事件
        private void X_Form_AddSiteUser_Load(object sender, EventArgs e) {
            Loaded();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e) {
            e.Cancel = true;
        }

        private void TS_保存_Click(object sender, EventArgs e) {
            if (user.LoginMethod == LoginMethod.Cookie登陆) {
                if (txt_username.Text.Trim() == string.Empty) {
                    EchoHelper.ShowBalloon("保存失败", "大侠，虽然是马甲登陆...但那么多马甲您能分得清楚吗？还是写个好记的用户名吧！", txt_username);
                    return;
                } else if (txtCookies.Text.Trim() == string.Empty) {
                    EchoHelper.ShowBalloon("保存失败", "大侠，您貌似没有抓取马甲哦！请抓取后再保存！", Btn_抓取马甲);
                    return;
                }
            } else {
                if (txt用户名.Text.Trim() == string.Empty) {
                    EchoHelper.ShowBalloon("保存失败", "大侠，您没写用户名？......-_-#", txt用户名);
                    return;
                } else if (txt密码.Text.Trim() == string.Empty) {
                    EchoHelper.ShowBalloon("保存失败", "大侠，您没写密码？......-_-#", txt密码);
                    return;
                }

            }
            Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void Btn_抓取马甲_Click(object sender, EventArgs e) {
            this.Hide();
            X_Form_HttpWatch majia = new X_Form_HttpWatch(URL, "提取马甲信息");
            if (majia.ShowDialog() == DialogResult.OK) {
                txtCookies.Text = majia.ThisWebData.Cookie;
                txtAgent.Text = majia.ThisWebData.UserAgent;
                majia.Dispose();
                majia.Close();
            } else {
                majia.Dispose();
                majia.Close();
            }
            this.Show();
        }
        #endregion

        #region 方法
        private void Loaded() {
            if (user.LoginMethod == LoginMethod.用户名登陆) {
                txt用户名.Text = user.Uname;
                txt密码.Text = user.Upass;
                txtLastUrl01.Text = user.LastUrl;
                txt备注信息01.Text = user.Other;
            } else {
                txtCookies.Text = user.Cookie;
                txtAgent.Text = user.LoginUserAgent;
                txt_username.Text = user.Uname;
                txtLastUrl02.Text = user.LastUrl;
                txt备注信息02.Text = user.Other;

            }
        }

        private void Save() {
            if (user.LoginMethod == LoginMethod.用户名登陆) {
                user.Uname = txt用户名.Text;
                user.Upass = txt密码.Text;
                user.LastUrl = txtLastUrl01.Text;
                user.Other = txt备注信息01.Text;

            } else {
                user.LoginUserAgent = txtAgent.Text;
                user.Cookie = txtCookies.Text;
                user.Uname = txt_username.Text;
                user.LastUrl = txtLastUrl02.Text;
                user.Other = txt备注信息02.Text;
            }
        }
        #endregion

        private void linkGo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ProcessHelper.openUrl(txtLastUrl01.Text);
        }

    }
}
