using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Model;
using System.Threading;
using System.Text.RegularExpressions;
using X_Service.Util;
using X_PostKing.Job;
using X_Service.Web;

namespace X_PostKing {
    public partial class X_Form_AddSitePostEdit02Cate : X_Form_BaseTool {

        #region 构造函数
        public ModelSite site = null;
        public X_Form_AddSitePostEdit02Cate(ModelSite st) {
            InitializeComponent();
            site = st;
            Form.CheckForIllegalCrossThreadCalls = false;
        }
        #endregion

        #region 事件
        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void TS_保存_Click(object sender, EventArgs e) {
            if (Radio_Enabled.Checked) {
                if (Text_Regex.Text.Trim() == string.Empty | Text_Regex.Text.Trim() == string.Empty) {
                    EchoHelper.Show("分类地址和正则代码均不能为空，请返回检查！", EchoHelper.MessageType.提示);
                    return;
                }
            }
            Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Btn_GetCategories_Click(object sender, EventArgs e) {
            Save();
            Thread th = new Thread(new ThreadStart(GetCategorise));
            th.IsBackground = true;
            th.Start();
        }

        private void Radio_Enabled_CheckedChanged(object sender, EventArgs e) {
            if (Radio_Enabled.Checked) {
                Text_Regex.Enabled = true;
                Text_Url.Enabled = true;
                List.Enabled = true;
            } else {
                Text_Regex.Enabled = false;
                Text_Url.Enabled = false;
                List.Enabled = false;
            }
        }

        private void X_Form_AddSitePostEdit02Cate_Load(object sender, EventArgs e) {
            Loaded();
        }

        #endregion

        #region 方法
        private void Loaded() {
            Text_Regex.Text = site.CategoriesRegex;
            Text_Url.Text = site.CategoriesUrl;
            txtTmpReg01.Text = site.tmp01Regex;
            txtTmpReg02.Text = site.tmp02Regex;

            if (string.IsNullOrEmpty(Text_Url.Text)) {
                Text_Url.Text = site.LoginLoginUrl;
            }
            if (site.CategoriesIsEnablad) {
                Radio_Enabled.Checked = true;
                Text_Regex.Enabled = true;
                Text_Url.Enabled = true;
                List.Enabled = true;
            } else {
                Text_Regex.Enabled = false;
                Text_Url.Enabled = false;
                List.Enabled = false;
            }
        }

        private void Save() {
            site.CategoriesRegex = Text_Regex.Text;
            site.CategoriesUrl = Text_Url.Text;
            site.CategoriesIsEnablad = Radio_Enabled.Checked;
            site.tmp01Regex = txtTmpReg01.Text;
            site.tmp02Regex = txtTmpReg02.Text;
        }

        private void GetCategorise() {
            try {
                //Save();
                Btn_GetCategories.Enabled = false;
                List.Items.Clear();

                int userid = 0;
                X_Form_Users user = new X_Form_Users(site);
                if (user.ShowDialog() == DialogResult.OK) {
                    try {
                        userid = int.Parse(user.SelectIds);
                    } catch {
                    }
                }
                user.Close();

                JobCoreTest test = new JobCoreTest(site, FindModelUserByID(site, userid));
                string html = test.GetCategoryHtml();
                Web_Browser.DocumentText = html;
                Rich_Html.Text = html;
                Regex r = new Regex(Text_Regex.Text, RegexOptions.Multiline);
                MatchCollection m = r.Matches(html);
                //int i = 0;
                foreach (Match math in m) {
                    ListViewItem item = new ListViewItem(math.Groups["typeid"].Value);
                    item.SubItems.Add(math.Groups["typename"].Value);
                    List.Items.Add(item);
                }

                lbTmp01.Text = lbTmp02.Text = "";
                lbTmp01.Text = test.GetTempValue(txtTmpReg01.Text);
                lbTmp02.Text = test.GetTempValue(txtTmpReg02.Text);

                Btn_GetCategories.Enabled = true;
            } catch {
                Btn_GetCategories.Enabled = true;
            }

        }
        private void linkRegex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string Text = link.Tag.ToString();
                Clipboard.SetText(Text);
                Text_Regex.Paste();
                Clipboard.Clear();
            } catch {

            }
        }

        private void linkUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string Text = link.Tag.ToString();
                Clipboard.SetText(Text);
                Text_Url.Paste();
                Clipboard.Clear();
            } catch {

            }
        }

        #endregion

        private void Text_Regex_DoubleClick(object sender, EventArgs e) {
            X_Form_InputBox inputbox = new X_Form_InputBox(Text_Regex.Text);
            if (inputbox.ShowDialog() == DialogResult.OK) {
                Text_Regex.Text = inputbox.InputStr;
            }
        }
    }
}
