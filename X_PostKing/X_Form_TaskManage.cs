using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using WeifenLuo.WinFormsUI.Docking;
using X_Model;
using X_PostKing.Job;
using X_PostKing.Tools;
using X_Service.Files;
using X_Service.Util;
using X_Service.Web;
using System.Net;

namespace X_PostKing {
    public partial class X_Form_TaskManage : DockContent {

        private X_ListView lvwColumnSorter;

        public X_Form_TaskManage() {
            InitializeComponent();
            lvwColumnSorter = new X_ListView();
            this.ListViewTasks.ListViewItemSorter = lvwColumnSorter;

        }

        #region 执行提高相关域的相关方法-TmSendDomains()。30%的几率命中。

        private void timer相关域_Tick(object sender, EventArgs e) {
            try {
                bool b = false;
                string path = Application.StartupPath + "\\Config\\Setup.ini";
                INIHelper ini = new INIHelper(path);
                try {
                    b = Convert.ToBoolean(ini.re("软件默认设定", "开启蜘蛛爬爬"));
                } catch {
                    ini.up("软件默认设定", "开启蜘蛛爬爬", "True");
                }
                if (b) {
                    new Thread(new ThreadStart(TmSendDomains)).Start();
                }
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }

        }

        /// <summary>
        /// 暂时取消了蜘蛛爬爬，自动提交，发现近期很多会员有死机等问题，怀疑是由这里引起的。
        /// </summary>
        private void TmSendDomains() {
            if (new Random().Next(20) < -1) {
                EchoHelper.Echo("准备向3000＋个网址提交您的站点，增加您的相关域。此过程稍慢，请稍后...", "相关域", EchoHelper.EchoType.任务信息);
                int j = 0;
                for (int i = 0; i < ModelMain.AllData.SiteList.Count; i++) {
                    try {
                        string domain = ModelMain.AllData.SiteList[i].SiteDomain;
                        if (domain == "http://" || string.IsNullOrEmpty(domain)) {
                            domain = ModelMain.AllData.SiteList[i].SiteBackUrl;
                        }
                        if (!string.IsNullOrEmpty(domain)) {
                            domain = new Uri(domain).Host.Replace("www.", "");
                            string url = getOUrl().Replace("[域名关键字]", domain);
                            CookieCollection cookies = new CookieCollection();
                            new xkHttp().httpGET(url, ref cookies);
                            EchoHelper.Echo("提交" + domain + "成功！", "相关域", EchoHelper.EchoType.任务信息);
                            j++;
                        }

                    } catch (Exception ex) {
                        EchoHelper.EchoException(ex);
                    }
                }
                EchoHelper.Echo("恭喜您，本次共成功提交" + j + "个站点的相关域，等待排名上升吧。", "相关域", EchoHelper.EchoType.任务信息);
            }
        }

        private string getOUrl() {
            string url = "renzhe.org";
            try {
                url = ArrayHelper.getRandOneFromStrs(new X_Form_WLink().searchUrl.Split('\n')).Trim();
            } catch {
            }

            return url;
        }
        #endregion


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
            this.ListViewTasks.Sort();
        }


        private void X_Form_TaskManage_Load(object sender, EventArgs e) {
            load任务列表(-1, true);
            this.ListViewTasks.Sort();

        }

        private ModelSite FindSiteByID(int siteid) {
            return ModelMain.AllData.SiteList.Find(delegate(ModelSite s) {
                return s.SiteID == siteid;
            });
        }

        private void load任务列表(int inputID, bool isClear) {
            load任务列表(inputID, isClear, false);
        }

        /// <summary>
        /// 加载任务列表
        /// </summary>
        /// <param name="inputID">站点ID，如果是-1则加载所有的任务</param>
        /// <param name="isClear">是否先清空现有数据</param>
        /// <param name="isGroup">是否启用分组加载</param>
        private void load任务列表(int inputID, bool isClear, bool isGroup) {
            if (isClear) {
                ListViewTasks.Items.Clear();
            }
            try {
                foreach (ModelTasks item in ModelMain.AllData.TasksList) {
                    ListViewItem lv = new ListViewItem(item.TaskID.ToString());
                    if (inputID != -1) {
                        bool isaddsite = item.SiteID == inputID & !isGroup;
                        bool isaddgroup = FindSiteByID(item.SiteID).GroupID == inputID & isGroup;

                        if (isaddgroup || isaddsite) {
                            lv.SubItems.Add(item.TaskName);
                            lv.SubItems.Add(ModelMain.FindSiteByID(item.SiteID).SiteName);
                            ListViewTasks.Items.Add(lv);
                            int artcount = FilesHelper.ReadDirectory(Application.StartupPath + item.SavePath).Count;
                            lv.SubItems.Add(item.perNum.ToString() + "/" + artcount.ToString());
                            string tmp_rand = item.IsRandUp ? "随机顶贴" : "站群发布";
                            lv.SubItems.Add(tmp_rand);
                            lv.SubItems.Add(item.TaskState.ToString());
                            if (item.TaskState == TaskState.采集中 || item.TaskState == TaskState.登录中 || item.TaskState == TaskState.发布中) {
                                lv.BackColor = Color.Beige;
                            } else {
                                lv.BackColor = Color.Transparent;
                            }

                        }
                    } else {
                        lv.SubItems.Add(item.TaskName);
                        lv.SubItems.Add(ModelMain.FindSiteByID(item.SiteID).SiteName);
                        int artcount = FilesHelper.ReadDirectory(Application.StartupPath + item.SavePath).Count;
                        lv.SubItems.Add(item.perNum.ToString() + "/" + artcount.ToString());
                        string tmp_rand = item.IsRandUp ? "随机顶贴" : "站群发布";
                        lv.SubItems.Add(tmp_rand);
                        lv.SubItems.Add(item.TaskState.ToString());
                        ListViewTasks.Items.Add(lv);
                        if (item.TaskState == TaskState.采集中 || item.TaskState == TaskState.登录中 || item.TaskState == TaskState.发布中) {
                            lv.BackColor = Color.Beige;
                        } else {
                            lv.BackColor = Color.Transparent;
                        }
                    }
                }
                listViewHeight(ListViewTasks, 20);
                Invoke_Task();
            } catch {
                EchoHelper.Echo("读取任务列表出错！", null, EchoHelper.EchoType.异常信息);
            }

        }

        #region listViewHeight( ListView lv , int height ){} 方法是用来撑大listview空间的行高度的。传入控件本身，还有高度。
        protected void listViewHeight(ListView lv, int height) {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);//分别是宽和高
            lv.SmallImageList = imgList;   //这里设置listView的SmallImageList ,用imgList将其撑大
        }

        #endregion

        public void taskSelectChange(int siteID, bool isgroup) {
            load任务列表(siteID, true, isgroup);
        }

        public void taskStart() {
            if (ListViewTasks.Items.Count > 1 && KryptonMessageBox.Show("您选中了" + ListViewTasks.Items.Count + "个任务，同时启动吗？", "多任务启动", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel) {
                return;
            }

            for (int i = 0; i < ListViewTasks.Items.Count; i++) {
                int taskID = Convert.ToInt32(ListViewTasks.Items[i].Text);
                ModelTasks task = ModelMain.FindTaskByID(taskID);
                if (task.TaskState == TaskState.已终止 || task.TaskState == TaskState.未启动) {
                    task.TaskState = TaskState.运行中;
                    Thread.Sleep(40);
                }

            }

        }

        private void 编辑任务ToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                int id = int.Parse(ListViewTasks.SelectedItems[0].Text);
                ModelTasks mtask = ModelMain.FindTaskByID(id);
                X_Form_AddTask task = new X_Form_AddTask(true, mtask);
                if (task.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    int index = ModelMain.FindTaskIndexByID(id);
                    ModelMain.AllData.TasksList[index] = task.task;
                    ModelMain.AllData.TasksList[index].State_Change += new ModelTasks.Task_State_Changeed(Task_State_Changeed);
                }
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }

        }
        private void 删除任务ToolStripMenuItem_Click(object sender, EventArgs e) {

            if (KryptonMessageBox.Show("您选中了" + ListViewTasks.SelectedItems.Count + "个任务，你要删除吗？", "任务删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel) {
                return;
            }

            for (int i = 0; i < ListViewTasks.SelectedItems.Count; i++) {
                int taskID = Convert.ToInt32(ListViewTasks.SelectedItems[i].Text);
                任务列表删除(taskID);
            }
            load任务列表(-1, true);
        }

        private void 任务列表删除(int taskID) {
            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                if (ModelMain.AllData.TasksList[i].TaskID == taskID) {
                    //ModelMain.AllData.TasksList[i].TaskState = TaskState.等待终止;
                    EchoHelper.Echo(string.Format("任务：“{0}”删除成功....", ModelMain.AllData.TasksList[i].TaskName), "系统", EchoHelper.EchoType.任务信息);

                    if (ModelMain.AllData.TasksList[i].SavePath.Contains(@"\Task\") && KryptonMessageBox.Show("是否删除任务文件夹：" + ModelMain.AllData.TasksList[i].SavePath, "确认删除？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
                        FilesHelper.DeleteInDir(Application.StartupPath + ModelMain.AllData.TasksList[i].SavePath);
                    }
                    ModelMain.AllData.TasksList.RemoveAt(i);
                    return;
                }
            }
        }

        private void 开始任务ToolStripMenuItem_Click(object sender, EventArgs e) {
#if DEBUG
            if (KryptonMessageBox.Show("目前处于调试状态，发布的文章将带有renzhe.org的链接，确认继续？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel) {
                return;
            }
#endif



            if (ListViewTasks.SelectedItems.Count > 1 && KryptonMessageBox.Show("您选中了" + ListViewTasks.SelectedItems.Count + "个任务，同时启动吗？", "多任务启动", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel) {
                return;
            }

            for (int i = 0; i < ListViewTasks.SelectedItems.Count; i++) {
                int taskID = Convert.ToInt32(ListViewTasks.SelectedItems[i].Text);
                ModelTasks task = ModelMain.FindTaskByID(taskID);
                if (task.TaskState == TaskState.已终止 || task.TaskState == TaskState.未启动) {
                    task.TaskState = TaskState.运行中;
                    Thread.Sleep(40);
                }
            }

        }

        private void 停止任务ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ListViewTasks.SelectedItems.Count > 1 && KryptonMessageBox.Show("您选中了" + ListViewTasks.SelectedItems.Count + "个任务，同时停止吗？", "多任务停止", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel) {
                return;
            }

            for (int i = 0; i < ListViewTasks.SelectedItems.Count; i++) {
                int taskID = Convert.ToInt32(ListViewTasks.SelectedItems[i].Text);

                ModelTasks task = ModelMain.AllData.TasksList.Find(delegate(ModelTasks t) {
                    return t.TaskID == taskID;
                });

                if (task.TaskState == TaskState.等待终止) {
                    task.TaskState = TaskState.已终止;
                } else {
                    task.TaskState = TaskState.等待终止;
                }

            }
        }

        private void ListViewTasks_DoubleClick(object sender, EventArgs e) {
            编辑任务ToolStripMenuItem_Click(sender, e);
        }

        public void 导入文章ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ListViewTasks.SelectedItems.Count > 1) {
                EchoHelper.Show("无法导入多个任务导入，请选定一个任务！", EchoHelper.MessageType.警告);
                return;
            }
            int id = int.Parse(ListViewTasks.SelectedItems[0].Text);
            ModelTasks mtask = ModelMain.FindTaskByID(id);

            if (!mtask.IsRandUp) {
                try {
                    FolderBrowserDialog f = new FolderBrowserDialog();
                    if (f.ShowDialog(this) == DialogResult.OK) {
                        string path = f.SelectedPath;
                        IList<FileInfo> files = FilesHelper.ReadDirectoryList(path, ".txt|.html");
                        int i = 0;
                        foreach (FileInfo file in files) {
                            string tmp_result = FilesHelper.Read_File(file);
                            string savePath = Application.StartupPath + mtask.SavePath + file.Name.ToLower().Replace("html", "txt");
                            if (!File.Exists(savePath) && !string.IsNullOrEmpty(tmp_result)) {
                                tmp_result = tmp_result.Replace("&", "-");//导入的时候，过滤掉&，防止在发布的时候被截断。
                                FilesHelper.Write_File(savePath, tmp_result);
                                i++;
                            }
                        }
                        EchoHelper.Echo("成功导入：" + i + "篇文章。", "导入文章", EchoHelper.EchoType.任务信息);
                        EchoHelper.Show("成功导入：" + i + "篇文章。", EchoHelper.MessageType.提示);
                    }
                } catch (Exception ex) {
                    EchoHelper.Echo("导入文章失败：" + ex.Message, "导入文章", EchoHelper.EchoType.异常信息);
                }

            } else {
                //如果是随机顶贴任务，那么就自然分隔一个文件中的一行为一个顶贴内容。
                OpenFileDialog Open_File = new OpenFileDialog();
                if (Open_File.ShowDialog() == DialogResult.OK) {
                    FileInfo file = new FileInfo(Open_File.FileName);
                    string tmp_result = FilesHelper.Read_File(file);

                    string[] strs = tmp_result.Split('\n');
                    for (int i = 0; i < strs.Length; i++) {
                        string tmp_name = StringHelper.SubStringNoDDD(strs[i].ToString().Trim(), 0, 30);

                        if (!string.IsNullOrEmpty(strs[i].ToString()) && !string.IsNullOrEmpty(tmp_name)) {
                            FilesHelper.Write_File(Application.StartupPath + mtask.SavePath + tmp_name + ".txt", strs[i].ToString().Trim());

                        }

                    }
                    int count = FilesHelper.ReadDirectoryList(Application.StartupPath + mtask.SavePath, ".txt").Count;
                    EchoHelper.Show("分隔整理成功了，此任务现有" + count + "篇顶贴内容！", EchoHelper.MessageType.提示);
                }
            }



        }

        private void 查看文章ToolStripMenuItem_Click(object sender, EventArgs e) {
            int id = int.Parse(ListViewTasks.SelectedItems[0].Text);
            ModelTasks mtask = ModelMain.FindTaskByID(id);
            ProcessHelper.openUrl(Application.StartupPath + mtask.SavePath);
        }


        #region  public void Invoke_Task()  用来清除任务的挂载事件，这样就可以保存序列化了。
        private void Invoke_Task() {
            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                if (ModelMain.AllData.TasksList[i].Is_LoadEvent() == false) {
                    ModelMain.AllData.TasksList[i].State_Change += new ModelTasks.Task_State_Changeed(Task_State_Changeed);
                }
            }
        }

        public void UnInvoke_Task() {
            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                if (ModelMain.AllData.TasksList[i].Is_LoadEvent() == true) {
                    ModelMain.AllData.TasksList[i].Clear_State();
                }
            }
        }
        #endregion

        public void Task_State_Changeed(ModelTasks task) {
            try {
                for (int i = 0; i < ListViewTasks.Items.Count; i++) {
                    if (ListViewTasks.Items[i].Text == task.TaskID.ToString()) {
                        ListViewTasks.Items[i].SubItems[5].Text = task.TaskState.ToString();
                        if (task.TaskState == TaskState.采集中 || task.TaskState == TaskState.登录中 || task.TaskState == TaskState.发布中) {
                            ListViewTasks.Items[i].BackColor = Color.Beige;
                        } else {
                            ListViewTasks.Items[i].BackColor = Color.Transparent;
                        }
                    }
                }
                if (task.TaskState == TaskState.等待终止) {
                    TaskCenter.TerminateOneTask(task);
                }
                if (task.TaskState == TaskState.运行中) {
                    TaskCenter.TaskJoinAndStart(FindSiteByID(task.SiteID), task);
                }
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
        }

        private void CMS_任务列表_Opening(object sender, CancelEventArgs e) {
            try {
                开始任务ToolStripMenuItem.Enabled = false;
                停止任务ToolStripMenuItem.Enabled = false;

                string tmp = ListViewTasks.SelectedItems[0].SubItems[5].Text;
                if (tmp != TaskState.已终止.ToString() && tmp != TaskState.未启动.ToString()) {
                    停止任务ToolStripMenuItem.Enabled = true;
                }

                if (tmp == TaskState.已终止.ToString() || tmp == TaskState.未启动.ToString()) {
                    开始任务ToolStripMenuItem.Enabled = true;
                }

                int taskID = Convert.ToInt32(ListViewTasks.SelectedItems[0].Text);
                ModelTasks task = ModelMain.FindTaskByID(taskID);
                ModelSite site = ModelMain.FindSiteByID(task.SiteID);

                if (string.IsNullOrEmpty(site.WebPut) && string.IsNullOrEmpty(site.WebLogin)) {
                    启动浏览器ToolStripMenuItem.Enabled = false;
                    启动浏览器ToolStripMenuItem.Text = "Web内核未配置";
                } else {
                    启动浏览器ToolStripMenuItem.Enabled = true;
                    启动浏览器ToolStripMenuItem.Text = "启动浏览器";
                }

                if (string.IsNullOrEmpty(site.PostParameters) && string.IsNullOrEmpty(site.LoginParameters) && task.modelPicks.Count == 0) {
                    开始任务ToolStripMenuItem.Text = "启动任务（未配置）";
                    开始任务ToolStripMenuItem.Enabled = false;
                } else if (string.IsNullOrEmpty(site.PostParameters) && string.IsNullOrEmpty(site.LoginParameters)) {
                    开始任务ToolStripMenuItem.Text = "启动仅采集";
                } else if (task.modelPicks.Count == 0) {
                    开始任务ToolStripMenuItem.Text = "启动仅发布";
                } else {
                    开始任务ToolStripMenuItem.Text = "启动任务";
                }

            } catch {
                e.Cancel = true;
            }


        }

        private void timer刷新任务状态_Tick(object sender, EventArgs e) {
            for (int i = 0; i < ListViewTasks.Items.Count; i++) {
                int taskID = Convert.ToInt32(ListViewTasks.Items[i].Text);
                ModelTasks task = ModelMain.FindTaskByID(taskID);
                TaskCenter.TaskStatusRefresh(task);
            }
        }

        private void 启动浏览器ToolStripMenuItem_Click(object sender, EventArgs e) {

            if (ListViewTasks.SelectedItems.Count == 1) {
                int taskID = Convert.ToInt32(ListViewTasks.SelectedItems[0].Text);
                ModelTasks task = ModelMain.FindTaskByID(taskID);
                ModelSite site = ModelMain.FindSiteByID(task.SiteID);

                if (site.modelUsers.Count < 1) {
                    if (KryptonMessageBox.Show("站点中不存在用户，无法自动填写【用户名】等变量，您是否继续启用浏览器？\n建议您可以事先：编辑站点添加已有账户！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    } else {
                        return;
                    }
                }

                int artcount = FilesHelper.ReadDirectory(Application.StartupPath + task.SavePath).Count;
                if (artcount < 1) {
                    if (KryptonMessageBox.Show("文章数不足，无法自动填写【正文】等变量，您是否继续启用浏览器？\n建议您可以事先：1、启动采集文章；2、任务右键选择导入文章！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    } else {
                        return;
                    }
                }

                X_Form_MainFormBrowser b = new X_Form_Main().getBrowser();
                b.Show();
                b.GotoPage(task);
            } else {
                if (KryptonMessageBox.Show("共启动" + ListViewTasks.SelectedItems.Count + "个任务，会分别生成浏览器标签，确定要打开？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                } else {
                    return;
                }
                for (int i = 0; i < ListViewTasks.SelectedItems.Count; i++) {
                    int taskID = Convert.ToInt32(ListViewTasks.SelectedItems[i].Text);
                    ModelTasks task = ModelMain.FindTaskByID(taskID);

                    X_Form_MainFormBrowser b = new X_Form_Main().getBrowser();
                    b.Show();
                    b.GotoPage(task);
                }
            }

        }

    }
}
