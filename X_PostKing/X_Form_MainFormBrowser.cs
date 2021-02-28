using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Threading;
using X_Service.Util;
using X_Model;
using System.IO;
using WebKit;

namespace X_PostKing {

    public partial class X_Form_MainFormBrowser : X_Form_Base {

        public X_Form_MainFormBrowser() {
            Form.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void X_Form_MainFormBrowser_Load(object sender, EventArgs e) {
        }

        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
        }
        protected override void OnClosing(CancelEventArgs e) {
            e.Cancel = true;
            this.Hide();
            base.OnClosing(e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            this.txtUrl.Text = "http://www.renzhe.org.cn/";
            X_Form_WebBrowser wb = new X_Form_WebBrowser(null, new WebKitBrowser(), this.txtUrl.Text);
            wb.Show(dockPanel);
        }


        public void GotoPage(ModelTasks task) {
            X_Form_WebBrowser wb = new X_Form_WebBrowser(task, new WebKitBrowser(), null);
            wb.task = task;

            string url = "";
            if (task != null) {
                ModelSite site = ModelMain.FindSiteByID(task.SiteID);
                if (string.IsNullOrEmpty(url) && site != null) {
                    url = site.SiteBackUrl;
                }
            }

            if (!string.IsNullOrEmpty(url) && !url.Contains("://")) {
                url = "http://" + url;
            }

            this.txtUrl.Text = url;
            wb.Show(dockPanel);
        }
        public void GotoPage(ModelTasks task, string url) {
            X_Form_WebBrowser wb = new X_Form_WebBrowser(task, new WebKitBrowser(), url);
            wb.task = task;
            this.txtUrl.Text = url;
            wb.Show(dockPanel);
        }
        public void GotoPage(string url) {
            X_Form_WebBrowser wb = new X_Form_WebBrowser(null, new WebKitBrowser(), url);
            this.txtUrl.Text = url;
            wb.Show(dockPanel);
        }

        private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e) {
            try {
                if (dockPanel.ActiveDocument.GetType().ToString().Equals("X_PostKing.X_Form_WebBrowser")) {
                    X_Form_WebBrowser wb = (X_Form_WebBrowser)dockPanel.ActiveDocument;
                    this.txtUrl.Text = wb.browser.Url.ToString();
                    if (this.dockPanel.Contents.Count == 0) {
                        this.txtUrl.Text = string.Empty;
                    }
                }
            } catch {
                this.txtUrl.Text = string.Empty;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            try {
                if (dockPanel.ActiveDocument.GetType().ToString().Equals("X_PostKing.X_Form_WebBrowser")) {
                    X_Form_WebBrowser wb = (X_Form_WebBrowser)dockPanel.ActiveDocument;
                    wb.browser.GoBack();
                }
            } catch {
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e) {
            try {
                if (dockPanel.ActiveDocument.GetType().ToString().Equals("X_PostKing.X_Form_WebBrowser")) {
                    X_Form_WebBrowser wb = (X_Form_WebBrowser)dockPanel.ActiveDocument;
                    wb.browser.Reload();
                }
            } catch {
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e) {
            GotoPage(this.txtUrl.Text.Trim());
        }

        protected override void Login_Base_SizeChanged(object sender, EventArgs e) {

        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                toolStripButton5_Click(sender, e);
            }
        }

        private void 软件保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveAll();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Hide();
        }

        private void X_Form_MainFormBrowser_SizeChanged(object sender, EventArgs e) {
        }

        private void browser_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            this.toolStatus.Text = "Loading...";
        }

        private void browser_DownloadBegin(object sender, FileDownloadBeginEventArgs e) {
        }

        private void browser_LocationChanged(object sender, EventArgs e) {

        }

        private void browser_Error(object sender, WebKitBrowserErrorEventArgs e) {
        }

        private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e) {
            this.toolStatus.Text = "Downloading...";
        }
        private void browser_NewWindowRequest(object sender, NewWindowRequestEventArgs e) {
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            this.Cursor = Cursors.Default;
            this.toolStatus.Text = "完成";
        }

        private void toolStripButtonCMD_Click(object sender, EventArgs e) {
            if (EchoHelper.IsShow) {
                EchoHelper.Hide();//修改为已隐藏
            } else {
                EchoHelper.Show();//显示控制台
                this.Focus();//窗体获取焦点
            }
        }

        private void txtUrl_Enter(object sender, EventArgs e) {
            txtUrl.SelectAll();
        }

    }
}
