using System;
using System.ComponentModel;
using System.Windows.Forms;
using X_Model;
using System.Threading;
using X_Service.Util;
using ComponentFactory.Krypton.Toolkit;

namespace X_PostKing.Tools {
    public partial class X_Form_SiteInfo : X_Form_BaseTool {
        Thread[] ths;
        private X_ListView lvwColumnSorter;

        public X_Form_SiteInfo() {
            InitializeComponent();
            lvwColumnSorter = new X_ListView();
            this.listViewKeys.ListViewItemSorter = lvwColumnSorter;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void X_Form_SiteInfo_Load(object sender, EventArgs e) {
            bindListViewKeys();
        }

        private void bindListViewKeys() {
            listViewKeys.Items.Clear();
            int all = ModelMain.AllData.SiteList.Count;
            for (int i = 0; i < all; i++) {
                ModelSite site = ModelMain.AllData.SiteList[i];
                ListViewItem item = new ListViewItem(site.SiteID.ToString());
                item.SubItems.Add(site.SiteName);
                item.SubItems.Add(site.SiteDomain);
                string num = site.BaiduNum > 99 ? "99+" : site.BaiduNum.ToString();
                item.SubItems.Add(num);
                item.SubItems.Add(site.SiteMainKeys);
                item.SubItems.Add(site.SitePM);
                item.SubItems.Add(site.DomainleftDays.ToString());
                if ((site.DomainExpire - DateTime.Now).Days < 30) {
                    item.BackColor = System.Drawing.Color.LightPink;
                }
                listViewKeys.Items.Add(item);
            }
            listViewHeight(listViewKeys, 18);

        }

        private void btnStop_Click(object sender, EventArgs e) {
            try {
                int all = ModelMain.AllData.SiteList.Count;
                for (int i = 0; i < all; i++) {
                    ths[i].Abort();
                }

            } catch {
            }
        }

        private void menuPM_Opening(object sender, CancelEventArgs e) {
            查询排名ToolStripMenuItem.Enabled = false;
            if (listViewKeys.SelectedItems.Count == 0 || string.IsNullOrEmpty(listViewKeys.SelectedItems[0].SubItems[3].Text)) {
            } else {
                查询排名ToolStripMenuItem.Enabled = true;
            }
        }

        private void 查询排名ToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                for (int i = 0; i < listViewKeys.SelectedItems.Count; i++) {
                    //
                    int index = listViewKeys.SelectedItems[i].Index;
                    Thread th1 = new Thread(new ParameterizedThreadStart(StartThPM));
                    th1.IsBackground = true;
                    th1.Start(index);
                    Thread th2 = new Thread(new ParameterizedThreadStart(StartTHDomainExpire));
                    th2.IsBackground = true;
                    th2.Start(index);
                    Thread th3 = new Thread(new ParameterizedThreadStart(StartTHBaiduCollection));
                    th3.IsBackground = true;
                    th3.Start(index);
                }

            } catch (Exception ex) {
                EchoHelper.Echo("出现异常：" + ex.Message, "查询排名", EchoHelper.EchoType.异常信息);
            }

        }

        private void 关键词设置ToolStripMenuItem_Click(object sender, EventArgs e) {
            editsite();
        }

        private void 访问网站ToolStripMenuItem_Click(object sender, EventArgs e) {
            string url = listViewKeys.SelectedItems[0].SubItems[2].Text;
            ProcessHelper.openUrl(url);
        }

        private void listViewKeys_ColumnClick(object sender, ColumnClickEventArgs e) {
            // 检查点击的列是不是现在的排序列.
            if (e.Column == lvwColumnSorter.SortColumn) {
                // 重新设置此列的排序方法.
                if (lvwColumnSorter.Order == SortOrder.Ascending) {
                    lvwColumnSorter.Order = SortOrder.Descending;
                } else {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            } else {
                // 设置排序列，默认为正向排序
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // 用新的排序方法对ListView排序
            this.listViewKeys.Sort();

        }

        private void listViewKeys_MouseDoubleClick(object sender, MouseEventArgs e) {
            editsite();
        }

        private void editsite() {
            try {
                int siteID = int.Parse(listViewKeys.SelectedItems[0].Text);
                siteID = FindSiteIndexIDByID(siteID);
                ModelSite site = ModelMain.AllData.SiteList[siteID];
                X_Form_AddSite Edit = new X_Form_AddSite(true, site, ModelMain.AllData.GroupList[FindGroupIndexByID(ModelMain.AllData.SiteList[siteID].GroupID)].GroupName);
                if (Edit.ShowDialog() != DialogResult.Cancel) {
                    ModelMain.AllData.SiteList[siteID] = Edit.site;
                }
                Edit.Close();
                site = null;
            } catch {
            }

        }

        private void btnReset_Click(object sender, EventArgs e) {
            bindListViewKeys();
        }

        private void SEO详情ToolStripMenuItem_Click(object sender, EventArgs e) {
            ProcessHelper.openUrl("http://seo.chinaz.com/?q=" + listViewKeys.SelectedItems[0].SubItems[2].Text);

        }

        //关键词批量查询排名
        private void btnKeysPMStart_Click(object sender, EventArgs e) {
            int all = ModelMain.AllData.SiteList.Count;
            ths = new Thread[all];
            for (int i = 0; i < all; i++) {
                ths[i] = new Thread(new ParameterizedThreadStart(StartThPM));
                ths[i].IsBackground = true;
                ths[i].Start(i);
            }
            if (KryptonMessageBox.Show("您是否关闭该此窗口，几分钟后，再来查看结果...", "后台查询", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) {
                this.Close();
            }
            this.ControlBox = true;
        }

        //百度排名查询
        private void btnBaiduCollection_Click(object sender, EventArgs e) {
            int all = ModelMain.AllData.SiteList.Count;
            ths = new Thread[all];
            for (int i = 0; i < all; i++) {
                ths[i] = new Thread(new ParameterizedThreadStart(StartTHBaiduCollection));
                ths[i].IsBackground = true;
                ths[i].Start(i);
            }
            if (KryptonMessageBox.Show("您是否关闭该此窗口，几分钟后，再来查看结果...", "后台查询", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) {
                this.Close();
            }
            this.ControlBox = true;
        }

        private void btnDomainExpire_Click(object sender, EventArgs e) {
            int all = ModelMain.AllData.SiteList.Count;
            ths = new Thread[all];
            for (int i = 0; i < all; i++) {
                ths[i] = new Thread(new ParameterizedThreadStart(StartTHDomainExpire));
                ths[i].IsBackground = true;
                ths[i].Start(i);
            }
            if (KryptonMessageBox.Show("您是否关闭该此窗口，几分钟后，再来查看结果...", "后台查询", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) {
                this.Close();
            }
            this.ControlBox = true;

        }

        //百度的收录查询线程
        private void StartTHBaiduCollection(object index) {
            try {
                int index_id = Convert.ToInt32(index);
                ModelSite site = FindSiteByID(Convert.ToInt32(listViewKeys.Items[index_id].Text));
                string url = site.SiteDomain.Replace("http://", "").Replace("/", "");
                listViewKeys.Items[index_id].SubItems[3].Text = "¤";
                site.BaiduNum = SeoHelper.getBaiduNum(SeoHelper.EnumSearchEngine.Baidu, url);
                EchoHelper.Echo("网站【" + site.SiteDomain + "】的百度收录为：" + site.BaiduNum, site.SiteName, EchoHelper.EchoType.任务信息);

                try {
                    listViewKeys.Items[index_id].SubItems[3].Text = site.BaiduNum.ToString();
                } catch {
                }

            } catch (Exception ex) {
                EchoHelper.Echo("系统异常：" + ex.Message, "网站查询", EchoHelper.EchoType.异常信息);
            }
        }

        private void StartThPM(object index) {
            try {
                int index_id = Convert.ToInt32(index);
                ModelSite site = FindSiteByID(Convert.ToInt32(listViewKeys.Items[index_id].Text));

                string keyword = site.SiteMainKeys;
                string siteName = site.SiteName;
                string url = site.SiteDomain.Replace("http://", "").Replace("/", "");


                if (!string.IsNullOrEmpty(keyword) & !string.IsNullOrEmpty(url)) {
                    EchoHelper.Echo("当前准备查询的关键词：" + keyword + "开始查询，根据您的网速不同，请耐心等待...", siteName, EchoHelper.EchoType.任务信息);
                    listViewKeys.Items[index_id].SubItems[5].Text = "¤";
                    string pm = "";
                    if (keyword.Contains(",")) {
                        string[] kws = keyword.Split(',');
                        for (int j = 0; j < kws.Length; j++) {
                            string pms = SeoHelper.engineKeyWordinfo(SeoHelper.EnumSearchEngine.Baidu, url, kws[j].ToString());
                            EchoHelper.Echo("关键词【" + kws[j].ToString() + "】的排名是：" + pms, siteName, EchoHelper.EchoType.任务信息);
                            pm += pms + ",";
                        }
                    } else {
                        pm = SeoHelper.engineKeyWordinfo(SeoHelper.EnumSearchEngine.Baidu, url, keyword);
                        EchoHelper.Echo("关键词【" + keyword + "】的排名是：" + pm, siteName, EchoHelper.EchoType.任务信息);

                    }
                    site.SitePM = pm.TrimEnd(',');

                    try {
                        listViewKeys.Items[index_id].SubItems[5].Text = site.SitePM;
                    } catch {
                    }
                }
            } catch (Exception ex) {
                EchoHelper.Echo("系统异常：" + ex.Message, "网站查询", EchoHelper.EchoType.异常信息);
            }

        }

        //开始域名查询
        private void StartTHDomainExpire(object index) {
            try {
                int index_id = Convert.ToInt32(index);
                ModelSite site = FindSiteByID(Convert.ToInt32(listViewKeys.Items[index_id].Text));

                string keyword = site.SiteMainKeys;
                string siteName = site.SiteName;
                string url = new Uri(site.SiteDomain).Host;

                if ((site.DomainExpire - DateTime.Now).Days < 30) {
                    listViewKeys.Items[index_id].SubItems[6].Text = "¤";
                    site.DomainExpire = SeoHelper.getDomainExpired(url);
                    EchoHelper.Echo("当前站点：" + site.SiteDomain + "，域名剩余" + (site.DomainExpire - DateTime.Now).Days + "天", siteName, EchoHelper.EchoType.任务信息);
                }

                try {
                    listViewKeys.Items[index_id].SubItems[6].Text = (site.DomainExpire - DateTime.Now).Days.ToString();
                } catch {
                }

            } catch (Exception ex) {
                EchoHelper.Echo("系统异常：" + ex.Message, "网站查询", EchoHelper.EchoType.异常信息);
            }

        }

    }
}
