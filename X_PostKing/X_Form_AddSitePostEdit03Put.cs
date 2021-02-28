using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Model;
using System.Threading;
using X_PostKing.Job;
using X_Service.Util;

namespace X_PostKing {
    public partial class X_Form_AddSitePostEdit03Put : X_Form_BaseTool {
        public ModelSite site = null;

        public X_Form_AddSitePostEdit03Put(ModelSite si) {
            InitializeComponent();
            site = si;
        }

        private void Btn_TestPost_Click(object sender, EventArgs e) {
            Save();
            int UserId = 0;
            X_Form_Users user = new X_Form_Users(site);
            if (user.ShowDialog() == DialogResult.OK) {
                UserId = GetLogin_ID(user.SelectIds);
                if (site.CategoriesIsEnablad) {
                    X_Form_Cate cate = new X_Form_Cate(site, UserId);
                    if (cate.ShowDialog() == DialogResult.OK) {
                        EchoHelper.Show("此过程小慢，别动，请稍后。。。", EchoHelper.MessageType.提示);
                        site = cate.SiteInfo;
                    } else {
                        return;
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

        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void TS_保存_Click(object sender, EventArgs e) {
            Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Btn_提取发布参数_Click(object sender, EventArgs e) {
            this.Hide();
            X_Form_HttpWatch majia = new X_Form_HttpWatch(Text_PostUrl.Text.Replace("[后台地址]", site.SiteBackUrl), "提取发布参数");
            if (majia.ShowDialog() == DialogResult.OK) {
                Text_Referer.Text = majia.ThisWebData.Referer.Trim();
                Text_PostUrl.Text = majia.ThisWebData.Url.Trim();
                Text_PostParameters.Text = majia.ThisWebData.Parameters.Trim();
                Save();
                Loaded();
            }
            majia.Dispose();
            majia.Close();

            this.Show();
        }
        private void Loaded() {
            Text_PostParameters.Text = site.PostParameters;
            Text_PostUrl.Text = site.PostUrl;
            if (string.IsNullOrEmpty(Text_PostUrl.Text)) {
                Text_PostUrl.Text = site.LoginLoginUrl;
            }
            Text_Referer.Text = site.PostReferer;
            Rich_Fail.Text = site.PostFailText;
            Rich_Succeed.Text = site.PostSucceedText;
            Check_Utf.Checked = site.PostIsUtf8;
            txtperWait.Value = site.perWait;
            Check_IsPostOnGzip.Checked = site.IsPostOnGzip;
            Check_IsMutilPost.Checked = site.IsMutilPost;
        }
        private void Save() {
            site.PostParameters = Text_PostParameters.Text;
            site.PostUrl = Text_PostUrl.Text;
            site.PostReferer = Text_Referer.Text;
            site.PostFailText = Rich_Fail.Text;
            site.PostSucceedText = Rich_Succeed.Text;
            site.PostIsUtf8 = Check_Utf.Checked;
            site.perWait = (int)txtperWait.Value;
            site.IsMutilPost = Check_IsMutilPost.Checked;
            site.IsPostOnGzip = Check_IsPostOnGzip.Checked;
        }
        public int GetLogin_ID(string str) {
            string[] arr = str.Split(',');
            Random r = new Random();
            return int.Parse(arr[r.Next(0, arr.Length - 1)]);
        }
        /// <summary>
        /// 测试发布
        /// </summary>
        /// <param name="userID">测试用户的ID</param>
        private void Test_Post(object userID) {
            try {
                int id = (int)userID;
                JobCoreTest test = new JobCoreTest(site, FindModelUserByID(site, id));
                string html = test.Post();
                Rich_Html.Text = html;
                webBrowser1.DocumentText = html;
            } catch {

            }
        }
        private void X_Form_AddSitePostEdit03Put_Load(object sender, EventArgs e) {
            Loaded();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string Text = link.Tag.ToString();
                Clipboard.SetText(Text);
                Text_PostParameters.Paste();
                Clipboard.Clear();
            } catch {

            }
        }

        private void buttonSpecAny1_Click(object sender, EventArgs e) {
            X_Form_InputBox inputbox = new X_Form_InputBox(Text_PostParameters.Text);
            if (inputbox.ShowDialog() == DialogResult.OK) {
                Text_PostParameters.Text = inputbox.InputStr;
            }

        }
    }
}
