using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using X_Service.Util;
using X_Service.HttpWatch;

namespace X_PostKing {
    public partial class X_Form_HttpWatch : X_Form_Base {
        #region 构造函数
        private HttpWatchTool http;
        private X_ListView lvwColumnSorter;
        Thread HW = null;
        string Title = string.Empty;
        List<Run_WebData> WebData = new List<Run_WebData> {
        };

        public Run_WebData ThisWebData = new Run_WebData();

        public X_Form_HttpWatch(string url, string title = "提取马甲信息") {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            lvwColumnSorter = new X_ListView();
            this.List_Pack.ListViewItemSorter = lvwColumnSorter;
            Text_Url.Text = url;
            this.Text = title;
            Title = title;
        }
        #endregion

        #region 取屏幕信息
        /// <summary>
        /// 取屏幕的高
        /// </summary>
        private int clientHeight = Screen.PrimaryScreen.Bounds.Height;
        /// <summary>
        /// 取屏幕的宽
        /// </summary>
        private int clientWidth = Screen.PrimaryScreen.Bounds.Width;
        #endregion

        #region 添加列表项
        private void AddList(Run_WebData Data, string Leixing) {
            int Counts = WebData.Count;
            WebData.Add(Data);
            ListViewItem item = new ListViewItem(Data.Url);
            item.Tag = Counts.ToString();
            if (Leixing == "KeyCount++") {
                item.ForeColor = Color.Green;
            } else if (Leixing == "Post++") {
                item.ForeColor = Color.Black;
            }
            item.SubItems.Add(Data.Method);
            item.SubItems.Add(Data.Cookie);
            item.SubItems.Add(Data.Parameters);
            item.SubItems.Add(Data.Head);
            this.List_Pack.Items.Add(item);
        }
        #endregion

        #region 改变窗体标题
        public void ChangeTitle(int Count, int KeyCount) {
            if (Count != 0) {
                this.Text = string.Format("{2}：共侦测到数据：{0}条 ，其中有效数据：{1}条", Count, KeyCount, Title);
            } else {
                this.Text = string.Format("{0}（侦测中）", Title);
            }
        }
        #endregion

        #region 启动HW
        private void StartHW() {
            try {
                http = new HttpWatchTool(Text_Url.Text);
                http.Page += new HttpWatchTool.PageChangeHandler(http_Page);
                http.Open(1);
            } catch {
                EchoHelper.Show("启动HW组件失败！点击确定后进入官方网站查找帮助。可能的原因：\n\n1、检查是否安装HttpWatch7.0；\n\n2、请使用IE浏览器（IE7 IE8 IE9），并设置为默认浏览器。", EchoHelper.MessageType.提示);
                EchoHelper.Echo(string.Format("启动HW组件失败！点击确定后进入官方网站查找帮助。"), "任务信息提取", EchoHelper.EchoType.任务信息);
                ProcessHelper.openUrl("http://www.renzhe.org/forum.php?mod=viewthread&tid=35");
                Btn_Start.PerformClick();
                this.Size = new Size(this.Size.Width, 492);
                this.CenterToScreen();
                this.TopMost = false;
                return;
            }
        }
        #endregion

        #region 事件
        private void Btn_Start_Click(object sender, EventArgs e) {
            if (Btn_Start.Text == "开始侦测") {
                if (Text_Url.Text.Trim() == string.Empty) {
                    EchoHelper.Show("请输入要侦测的地址！", EchoHelper.MessageType.警告);
                    return;
                }
                List_Pack.Items.Clear();
                WebData.Clear();
                this.Size = new Size(this.Size.Width, 247);
                this.Location = new System.Drawing.Point(clientWidth - this.Size.Width - 10, clientHeight - this.Size.Height - 50);
                this.TopMost = true;
                HW = new Thread(new ThreadStart(StartHW));
                HW.IsBackground = true;
                HW.Start();
                ChangeTitle(0, 0);
                EchoHelper.Echo(string.Format("开始进行信息侦测，打开了{0}", Text_Url.Text), "任务信息提取", EchoHelper.EchoType.任务信息);
                Btn_Start.Text = "停止侦测";
            } else if (Btn_Start.Text == "停止侦测") {
                if (null != http) {
                    http.Close();
                    http = null;
                }
                HW.Abort();
                EchoHelper.Echo(string.Format("停止侦测，关闭浏览器！"), "任务信息提取", EchoHelper.EchoType.任务信息);
                this.Size = new Size(this.Size.Width, 492);
                this.CenterToScreen();
                this.TopMost = false;
                this.Text = string.Format(Title);
                Btn_Start.Text = "开始侦测";
            }
        }
        private void Btn_Finish_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
        private void List_Pack_Click(object sender, EventArgs e) {
            if (List_Pack.SelectedItems.Count != 0) {
                Rich_Detail.Clear();
                int unm = int.Parse(List_Pack.SelectedItems[0].Tag.ToString());
                ThisWebData = WebData[unm];
                Rich_Detail.AppendText("地址：" + List_Pack.SelectedItems[0].SubItems[0].Text + Environment.NewLine);
                Rich_Detail.AppendText("模式：" + List_Pack.SelectedItems[0].SubItems[1].Text + Environment.NewLine);
                Rich_Detail.AppendText("参数：" + Environment.NewLine + List_Pack.SelectedItems[0].SubItems[3].Text + Environment.NewLine);
                Rich_Detail.AppendText("头部数据：" + Environment.NewLine + List_Pack.SelectedItems[0].SubItems[4].Text + Environment.NewLine);
            }
        }
        private void List_Pack_ColumnClick(object sender, ColumnClickEventArgs e) {
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
            this.List_Pack.Sort();
        }

        private void http_Page(String Leixing, Run_WebData Data, int Count, int KeyCount) {
            if (Leixing == "Count++") {
                ChangeTitle(Count, KeyCount);
            } else if (Leixing == "KeyCount++") {
                ChangeTitle(Count, KeyCount);
                EchoHelper.Echo(string.Format("提取到一条数据！"), "任务信息提取", EchoHelper.EchoType.任务信息);
                AddList(Data, Leixing);
            } else if (Leixing == "Post++") {
                ChangeTitle(Count, KeyCount);
                EchoHelper.Echo(string.Format("提取到一条数据！"), "任务信息提取", EchoHelper.EchoType.任务信息);
                AddList(Data, Leixing);
            } else if (Leixing == "CloseBrowser") {
                Btn_Start.PerformClick();
            }
        }
        #endregion
    }
}
