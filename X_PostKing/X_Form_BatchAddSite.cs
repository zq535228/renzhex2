using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Model;
using System.Collections;
using System.Web.UI.WebControls;
using X_Service.Util;
using X_Service.Login;

namespace X_PostKing {

    public partial class X_Form_BatchAddSite : X_Form_BaseTool {

        private ModelSite _copySite = new ModelSite();

        public X_Form_BatchAddSite() {
            InitializeComponent();
        }

        private void X_Form_BatchAddSite_Load(object sender, EventArgs e) {
            if (member.IS_X_WordPressBuild != true) {
                EchoHelper.Show("您的站点数超过50个的时候再来使用此功能吧！您可以使用批量任务的功能。", EchoHelper.MessageType.警告);
                this.Close();
            }

            tabControlSelect_SelectedIndexChanged(sender, e);
            load();

        }

        private void TS_保存_Click(object sender, EventArgs e) {
            int num = save();
            if (num > 0) {
                EchoHelper.Show(string.Format("成功添加{0}个站点！", num), EchoHelper.MessageType.提示);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            } else {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        //无异常产生则返回true；
        private int save() {
            int addnum = 0;
            try {
                _copySite = FindSiteByID(Convert.ToInt32(((ListItem)ddlSiteList.SelectedItem).Value));
                
                if (!_copySite.SiteBackUrl.Contains("http://www.")) {
                    EchoHelper.Echo("被复制的站点后台格式需要包含：http://www.！", "批量建站", EchoHelper.EchoType.错误信息);
                    return 0;
                }

                if (_copySite.modelUsers.Count<1) {
                    EchoHelper.Echo("被复制的站点无可用的账户，请确保改站点可用正常运行！", "批量建站", EchoHelper.EchoType.错误信息);
                    return 0;
                }

                string[] alist = txtBatchList.Text.Trim().Split('\n');

                for (int i = 0; i < alist.Length; i++) {
                    ModelSite site = new ModelSite();
                    site = (ModelSite)_copySite.Clone();
                    site.SiteID = ModelMain.AllData.LastSiteId;
                    site.SiteName = alist[i].Split('|')[0].Trim().Replace(".", "_");
                    site.SiteBackUrl = site.SiteBackUrl.Split('.')[0] + "." + alist[i].Split('|')[0].Trim() + site.SiteBackUrl.Split('.')[2].Replace("com", "").Replace("net", "").Replace("info", "");
                    site.SiteDomain = "http://www." + alist[i].Split('|')[0].Trim() + "/";
                    site.SiteMainKeys = alist[i].Split('|')[1].Trim().Split(',')[0] + "," + alist[i].Split('|')[1].Trim().Split(',')[1] + "," + alist[i].Split('|')[1].Trim().Split(',')[2];

                    ModelUsers user = site.modelUsers[0];
                    site.PostID = "";

                    if (ModelMain.AllData.SiteList.Count > Login_Base.member.sitenum - 1) {
                        EchoHelper.Echo("无法添加新站点，已经超过了最大允许的数量，请升级版本。" + Login_Base.member.sitenum, "新建任务", EchoHelper.EchoType.错误信息);
                        EchoHelper.Show("无法添加新站点，已经超过了最大允许的数量，请升级版本。", EchoHelper.MessageType.警告);
                        ProcessHelper.openUrl("http://www.renzhe.org/home.php?mod=spacecp&ac=credit&op=exchange");
                        return addnum;
                    }

                    int hasnum = ModelMain.AllData.SiteList.FindAll(delegate(ModelSite s) {
                        return s.SiteDomain == site.SiteDomain;
                    }).Count;
                    if (!string.IsNullOrEmpty(site.SiteName) && !string.IsNullOrEmpty(user.Uname) && !string.IsNullOrEmpty(user.Upass) && hasnum < 1) {
                        ModelMain.AllData.SiteList.Add(site);
                        addnum++;
                        EchoHelper.Echo("添加站点[" + site.SiteName + "]成功：" + site.SiteDomain, "批量站点", EchoHelper.EchoType.任务信息);
                    } else {
                        EchoHelper.Echo("此网站已存在：" + site.SiteDomain + "，跳过。", "批量站点", EchoHelper.EchoType.普通信息);
                    }
                }
                return addnum;
            } catch (Exception ex) {
                EchoHelper.Show("添加异常，请检查您的导入格式是否正确？", EchoHelper.MessageType.警告);
                EchoHelper.Echo("批量添加站点异常：" + ex.Message + "，请检查您的导入格式是否正确？", "批量站点", EchoHelper.EchoType.异常信息);
                return 0;
            }
        }

        private void load() {
            IList<ModelSite> slist = ModelMain.AllData.SiteList;
            foreach (ModelSite item in slist) {
                ddlSiteList.Items.Add(new ListItem(item.SiteName, item.SiteID.ToString()));
            }
        }

        private void tabControlSelect_SelectedIndexChanged(object sender, EventArgs e) {
            switch (tabControlSelect.SelectedIndex) {
                case 0: {
                        tabControlSelect.Size = new Size(tabControlSelect.Size.Width, groupBox1.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControlSelect.Size.Height + 30 + 22);
                        break;
                    }
                case 1: {
                        if (ddlSiteList.SelectedIndex == -1) {
                            EchoHelper.Show("请先选择被复制的网站！", EchoHelper.MessageType.提示);
                            tabControlSelect.SelectedIndex = 0;
                            return;
                        }
                        tabControlSelect.Size = new Size(tabControlSelect.Size.Width, groupBox2.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControlSelect.Size.Height + 30 + 22);
                        break;
                    }

            }
        }

        private void txtBatchList_Enter(object sender, EventArgs e) {
            if (txtBatchList.Text == "renzhe.org|关键词1,关键词2,关键词3,关键词4") {
                txtBatchList.Text = "";
            }
        }

        private void txtBatchList_Leave(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtBatchList.Text)) {
                txtBatchList.Text = "renzhe.org|关键词1,关键词2,关键词3,关键词4";
            }
        }

        private int i = ModelMain.AllData.LastSiteId;
        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e) {
            if (txtBatchList.Text != "renzhe" + i + ".org|关键词1,关键词2,关键词3,关键词4") {
                txtBatchList.Text += Environment.NewLine + "renzhe" + i + ".org|关键词1,关键词2,关键词3,关键词4";
            } else {
                txtBatchList.Text = "renzhe" + i + ".org|关键词1,关键词2,关键词3,关键词4";
            }
            i++;
        }



    }
}
