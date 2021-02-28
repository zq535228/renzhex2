using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Model;
using X_Service.Util;
using System.Threading;
using X_Service.Db;
using X_Service.Web;
using System.Net;

namespace X_PostKing {
    public partial class X_Form_LinkCycle : X_Form_BaseTool {
        #region 构造方法。
        X_Waiting w = new X_Waiting();

        public X_Form_LinkCycle() {
            InitializeComponent();
        }

        private void X_Form_LinkCycle_Load(object sender, EventArgs e) {
            w.ShowMsg("忍者X2链轮库加载中...请稍后...");
            new Thread(new ThreadStart(bindlvLinkCycle)).Start();
        }

        #endregion

        #region 绑定listView的方法。

        /// <summary>
        /// 绑定网络+自己的链轮库
        /// </summary>
        private void bindlvLinkCycle() {
            try {
                lvLinkCycle.Items.Clear();
                CookieCollection cookies = new CookieCollection();
                string html = new xkHttp().httpGET("http://renzhe.sinaapp.com/index.php?m=Url&a=urlindex", ref cookies);
                string[] s = html.Split('\r')[0].TrimEnd('^').Split('^');

                for (int i = 0; i < s.Length; i++) {
                    ListViewItem item = new ListViewItem(s[i]);
                    lvLinkCycle.Items.Add(item);
                }
                listViewHeight(lvLinkCycle, 18);

            } catch (Exception) {
                EchoHelper.Echo("远程加载链轮失败！", "获取链轮", EchoHelper.EchoType.异常信息);
            } finally {
                w.CloseMsg();
            }
        }

        #endregion

        #region 菜单事件

        private void TS_保存_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion

        #region 链轮库管理

        private void lvLinkCycle_DoubleClick(object sender, EventArgs e) {
            访问URLToolStripMenuItem_Click(sender, e);
        }

        private void 访问URLToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                string url = lvLinkCycle.SelectedItems[0].Text.Split('|')[1];
                ProcessHelper.openUrl(url);
            } catch {
            }

        }
        #endregion

        private void reload_DoubleClick(object sender, EventArgs e) {
            ModelMain.AllData.LinkCycle.Clear();
        }

        private void menuLinkCycle_Opening(object sender, CancelEventArgs e) {
            if (lvLinkCycle.SelectedItems.Count == 0) {
                e.Cancel = true;
            }
        }
    }
}
