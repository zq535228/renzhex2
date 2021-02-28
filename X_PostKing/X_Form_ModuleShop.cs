using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using X_Service.Db;
using X_Service.Files;
using X_Service.Util;
using X_Service.Web;
#if DEBUG
using X_Service.localhost;
#else
using X_Service.org.renzhe.serv;
#endif


namespace X_PostKing {
    public partial class X_Form_ModuleShop : X_Form_BaseTool {

        #region 初始化
        private Point tmpx;
        private X_Waiting wait = new X_Waiting();

        public X_Form_ModuleShop(Point tmpx) {
            InitializeComponent();

            Form.CheckForIllegalCrossThreadCalls = false;

            this.tmpx = tmpx;


        }
        #endregion

        private void X_Form_ModuleShop_Load(object sender, EventArgs e) {
            this.Location = tmpx;

            listViewHeight(this.listViewPut, 20);
            listViewHeight(this.listViewPick, 20);

#if !DEBUG
            删除模块PutToolStripMenuItem.Enabled = member.netname == "Qin";
            删除模块PickToolStripMenuItem.Enabled = member.netname == "Qin";
            重命名ToolStripMenuItem.Enabled = member.netname == "Qin";
            重命名ToolStripMenuItem1.Enabled = member.netname == "Qin";
#endif

            tabControl_SelectedIndexChanged(sender, e);

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e) {
            switch (tabControl.SelectedIndex) {
                case 0:
                    Thread th = new Thread(new ThreadStart(th_load));
                    th.IsBackground = true;
                    th.Start();
                    break;
                case 1:
                    Thread th2 = new Thread(new ThreadStart(th_load2));
                    th2.IsBackground = true;
                    th2.Start();
                    break;
            }
        }

        private void th_load() {
            this.listViewPut.Items.Clear();
            wait.ShowMsg("努力拉取发布模块列表，请稍后...");
            EchoHelper.Echo("努力拉取发布模块列表，请稍后...", "模块市场", EchoHelper.EchoType.任务信息);
            try {
                ModelShopOne[] slist = new WebServiceHelper().GetAllPutModules();
                foreach (ModelShopOne item in slist) {
                    ListViewItem lv = new ListViewItem(item.ModelName);
                    lv.SubItems.Add(item.IsCoreSocket.ToString());
                    lv.SubItems.Add(item.IsCoreWeb.ToString());
                    lv.SubItems.Add(item.FileSize.ToString() + "kb");
                    lv.SubItems.Add(item.LastUpDate.ToShortDateString());
                    lv.SubItems.Add(item.ModelAuthor);
                    lv.ToolTipText = string.Format("模块名称：{0}\n模块说明：{1}\n模块作者：{2} ({3})\n帮助说明：{4}", item.ModelName, item.SiteModelDescription, item.ModelAuthor, item.ModelQQ, item.ModelUrl);
                    this.listViewPut.Items.Add(lv);
                }
                EchoHelper.Echo("请求已完成，共获取" + slist.Length + "个发布模块，共享模块：" + listViewPut.Items.Count + "个！", "模块市场", EchoHelper.EchoType.任务信息);
            } catch (Exception ex) {
                EchoHelper.Echo("拉取市场模块失败，网络异常！", "拉取模块失败", EchoHelper.EchoType.异常信息);
                EchoHelper.EchoException(ex);
            } finally {
                wait.CloseMsg();
            }
        }

        private void th_load2() {
            listViewPick.Items.Clear();
            wait.ShowMsg("努力拉取抓取模块列表，请稍后...");
            EchoHelper.Echo("努力拉取抓取模块列表，请稍后...", "模块市场", EchoHelper.EchoType.任务信息);
            try {

                ModelShopOne[] slist = new WebServiceHelper().GetAllPickModules();
                foreach (ModelShopOne item in slist) {
                    ListViewItem lv = new ListViewItem(item.ModelName);
                    lv.SubItems.Add(item.IsFanZhuaQu.ToString());
                    lv.SubItems.Add(item.FileSize.ToString() + "kb");
                    lv.SubItems.Add(item.LastUpDate.ToShortDateString());
                    lv.SubItems.Add(item.ModelAuthor);
                    lv.ToolTipText = string.Format("模块名称：{0}\n模块说明：{1}\n模块作者：{2} ({3})\n帮助说明：{4}", item.ModelName, item.SiteModelDescription, item.ModelAuthor, item.ModelQQ, item.ModelUrl);
                    this.listViewPick.Items.Add(lv);
                }

                EchoHelper.Echo("请求已完成，共获取" + slist.Length + "个发布模块，共享模块：" + listViewPut.Items.Count + "个！", "模块市场", EchoHelper.EchoType.任务信息);
            } catch (Exception ex) {
                EchoHelper.Echo("拉取市场模块失败，网络异常！", "拉取模块失败", EchoHelper.EchoType.异常信息);
                EchoHelper.EchoException(ex);
            } finally {
                wait.CloseMsg();
            }
        }


        private void contextMenuStrip_Opening(object sender, CancelEventArgs e) {
            if (listViewPut.SelectedItems.Count == 0) {
                e.Cancel = true;
            }
        }

        private void put发布模块下载_Click(object sender, EventArgs e) {
            //下载模块
            string filename = listViewPut.SelectedItems[0].Text;
            try {
                wait.ShowMsg("努力拉取" + filename + "，请稍后...");
                string tmpobj = new WebServiceHelper().GetClassStr(filename, mType.发布模块);
                if (!string.IsNullOrEmpty(tmpobj)) { ///定义并实例化一个内存流，以存放提交上来的字节数组。
                    string strFilePath = Application.StartupPath + "\\Module\\" + filename;
                    bool ishas = File.Exists(strFilePath);
                    if (ishas) {
                        if (KryptonMessageBox.Show("本地已经存在这个模块，是否覆盖？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                            wait.CloseMsg();
                            return;
                        }
                    }
                    FilesHelper.Write_File(strFilePath, tmpobj);
                    EchoHelper.Show(filename + " 模块下载成功！", EchoHelper.MessageType.提示);
                }
                wait.CloseMsg();
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
        }

        private void put模块详情_Click(object sender, EventArgs e) {
            string mstr = listViewPut.SelectedItems[0].ToolTipText;
            EchoHelper.Show(mstr, EchoHelper.MessageType.提示);
        }

        private void listViewPut_DoubleClick(object sender, EventArgs e) {
            put发布模块下载_Click(sender, e);
        }

        private void put帮助说明ToolStripMenuItem_Click(object sender, EventArgs e) {
            string html = listViewPut.SelectedItems[0].ToolTipText;
            string url = RegexHelper.getMatch(html, "帮助说明：(.*)", 1);
            ProcessHelper.openUrl(url);
        }

        private void put删除模块ToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                string clsMemberObj = new DbTools().ClasstoString(member, "WCNM");
                if (new WebServiceHelper().Delete(clsMemberObj, listViewPut.SelectedItems[0].Text.ToString(), mType.发布模块)) {
                    listViewPut.SelectedItems[0].Remove();
                }
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
        }

        private void pick模块删除_Click(object sender, EventArgs e) {
            try {
                string clsMemberObj = new DbTools().ClasstoString(member, "WCNM");
                if (new WebServiceHelper().Delete(clsMemberObj, listViewPick.SelectedItems[0].Text.ToString(), mType.抓取模块)) {
                    listViewPick.SelectedItems[0].Remove();
                }
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
        }

        private void pick模块下载_Click(object sender, EventArgs e) {
            //下载模块
            string filename = listViewPick.SelectedItems[0].Text;
            try {
                wait.ShowMsg("努力拉取" + filename + "，请稍后...");
                string tmpobj = new WebServiceHelper().GetClassStr(filename, mType.抓取模块);
                if (!string.IsNullOrEmpty(tmpobj)) { ///定义并实例化一个内存流，以存放提交上来的字节数组。
                    string strFilePath = Application.StartupPath + "\\Module\\" + filename;
                    bool ishas = File.Exists(strFilePath);
                    if (ishas) {
                        if (KryptonMessageBox.Show("本地已经存在这个模块，是否覆盖？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                            wait.CloseMsg();
                            return;
                        }
                    }
                    FilesHelper.Write_File(strFilePath, tmpobj);
                    EchoHelper.Show(filename + " 模块下载成功！", EchoHelper.MessageType.提示);
                }
                wait.CloseMsg();
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
        }

        private void pick模块详情_Click(object sender, EventArgs e) {
            string mstr = listViewPick.SelectedItems[0].ToolTipText;
            EchoHelper.Show(mstr, EchoHelper.MessageType.提示);
        }

        private void pick帮助说明_Click(object sender, EventArgs e) {
            string html = listViewPick.SelectedItems[0].ToolTipText;
            string url = RegexHelper.getMatch(html, "帮助说明：(.*)", 1);
            ProcessHelper.openUrl(url);

        }

        private void buttonSearchEnter_Click(object sender, EventArgs e) {
            if (tabControl.SelectedIndex == 1) {//抓取
                for (int i = listViewPick.Items.Count - 1; i > -1; i--) {
                    if (!listViewPick.Items[i].Text.ToLower().Contains(search.Text.ToLower())) {
                        listViewPick.Items[i].Remove();
                    }
                }

            } else {//发布
                for (int i = listViewPut.Items.Count - 1; i > -1; i--) {
                    if (!listViewPut.Items[i].Text.ToLower().Contains(search.Text.ToLower())) {
                        listViewPut.Items[i].Remove();
                    }
                }
            }
        }

        private void search_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                buttonSearchEnter_Click(sender, e);
            }
            if (e.KeyData == Keys.Back && search.Text.Length == 1) {
                tabControl_SelectedIndexChanged(sender, e);
            }
        }

        //         private void search_MouseClick(object sender, MouseEventArgs e) {
        //             search.Text = "";
        //         }

        private void search_Enter(object sender, EventArgs e) {
            search.Text = "";
        }

        private void contextMenuStripPick_Opening(object sender, CancelEventArgs e) {
            if (listViewPick.SelectedItems.Count == 0) {
                e.Cancel = true;
            }
        }

        private void listViewPick_DoubleClick(object sender, EventArgs e) {
            pick模块下载_Click(sender, e);
        }

        private void 重命名PutToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                string clsMemberObj = new DbTools().ClasstoString(member, "WCNM");
                X_Form_TextBox fbox = new X_Form_TextBox();
                fbox.textBoxValue.Text = listViewPut.SelectedItems[0].Text.ToString();

                if (fbox.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    if (!fbox.textBoxValue.Text.Contains(".")) {
                        EchoHelper.Show("扩展名必须输入，切不要改变！", EchoHelper.MessageType.错误);
                        return;
                    }
                    if (new WebServiceHelper().ReName(clsMemberObj, listViewPut.SelectedItems[0].Text.ToString(), fbox.textBoxValue.Text, mType.发布模块)) {
                        listViewPut.SelectedItems[0].Text = fbox.textBoxValue.Text;
                    }
                }

            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
        }

        private void 重命名PickToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                string clsMemberObj = new DbTools().ClasstoString(member, "WCNM");
                X_Form_TextBox fbox = new X_Form_TextBox();
                fbox.textBoxValue.Text = listViewPick.SelectedItems[0].Text.ToString();

                if (fbox.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    if (!fbox.textBoxValue.Text.Contains(".")) {
                        EchoHelper.Show("扩展名必须输入，切不要改变！", EchoHelper.MessageType.错误);
                        return;
                    }
                    if (new WebServiceHelper().ReName(clsMemberObj, listViewPick.SelectedItems[0].Text.ToString(), fbox.textBoxValue.Text, mType.抓取模块)) {
                        listViewPick.SelectedItems[0].Text = fbox.textBoxValue.Text;
                    }
                }

            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
        }


    }
}
