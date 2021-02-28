using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using X_Model;
using X_PostKing.Tools;
using X_Service.Login;
using X_Service.Util;
using X_Service.Files;

namespace X_PostKing {
    public partial class X_Form_BatchAddTask : X_Form_BaseTool {

        public X_Form_BatchAddTask() {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void X_Form_BatchAddTask_Load(object sender, EventArgs e) {
            loadPartSites();

        }

        private void loadSites() {
            ckBoxSites.Items.Clear();
            IList<ModelSite> sites = ModelMain.AllData.SiteList;
            foreach (ModelSite item in sites) {
                ListItem tmp_item = new ListItem(item.SiteName, item.SiteID.ToString());
                ckBoxSites.Items.Add(tmp_item);
            }
        }

        private void loadPartSites() {
            ckBoxSites.Items.Clear();
            IList<ModelSite> sites = ModelMain.AllData.SiteList;
            foreach (ModelSite item in sites) {
                int i = ModelMain.AllData.TasksList.FindAll(delegate(ModelTasks t) {
                    return t.SiteID == item.SiteID;
                }).Count;
                ListItem tmp_item = new ListItem(item.SiteName, item.SiteID.ToString());
                if (i == 0) {
                    ckBoxSites.Items.Add(tmp_item);
                }
            }
        }


        private void TS_保存_Click(object sender, EventArgs e) {
            if (txtTaskPath.Text.Length > 0 && (!txtTaskPath.Text.EndsWith("\\") || !txtTaskPath.Text.StartsWith("\\"))) {
                EchoHelper.Show("任务路径格式出错！", EchoHelper.MessageType.错误);
                return;
            }
            if (string.IsNullOrEmpty(txtTaskList.Text)) {
                //EchoHelper.Show("您的任务详情还没有配置，可以点击自动加载！", EchoHelper.MessageType.错误);
                EchoHelper.ShowBalloon("任务详情", "您的任务详情还没有配置，可以点击自动加载！", btnAutoLoad);
                return;
            }

            if (save()) {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            } else {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        protected bool save() {


            for (int i = 0; i < txtTaskList.Text.Trim().Split('\n').Length; i++) {
                if (ModelMain.AllData.TasksList.Count > Login_Base.member.sitenum * 10 - 1) {
                    EchoHelper.Echo("无法添加新任务，已经超过了最大允许的数量，请升级版本。" + Login_Base.member.sitenum * 5, "新建任务", EchoHelper.EchoType.错误信息);
                    EchoHelper.Show("无法添加新任务，已经超过了最大允许的数量，请升级版本。", EchoHelper.MessageType.警告);
                    ProcessHelper.openUrl("http://www.renzhe.org/home.php?mod=spacecp&ac=credit&op=exchange");
                    return false;
                }

                string tmpstr = txtTaskList.Text.Split('\n')[i].Trim();
                ModelTasks task = new ModelTasks();
                task.TaskID = ModelMain.AllData.LastTasksId;
                task.SiteID = Convert.ToInt32(tmpstr.Split('|')[4].Trim());
                task.TaskName = tmpstr.Split('|')[0].Trim();
                task.PickKeyword = tmpstr.Split('|')[1].Trim();
                task.userIDs = tmpstr.Split('|')[2].Trim();
                task.PostCateIDs = tmpstr.Split('|')[3].Trim();
                if (txtTaskPath.Text.Length > 0) {
                    task.SavePath = txtTaskPath.Text;
                } else {
                    task.SavePath = @"\Task\" + task.TaskName + @"\";
                }
                ModelMain.AllData.TasksList.Add(task);
                EchoHelper.Echo("添加任务[" + task.TaskName + "]成功！", "批量任务", EchoHelper.EchoType.任务信息);

            }
            EchoHelper.Show("添加完毕，不确保每个任务都可以正确运行！\n您需要认真编写每一个任务的详细设置，以便更利于百度搜录！", EchoHelper.MessageType.提示);
            return true;
        }

        private void tabControlSelect_SelectedIndexChanged(object sender, EventArgs e) {
            switch (tabControlSelect.SelectedIndex) {
                case 0: {
                        tabControlSelect.Size = new Size(tabControlSelect.Size.Width, groupBox1.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControlSelect.Size.Height + 30 + 22);
                        break;
                    }
                case 1: {
                        if (ckBoxSites.SelectedItems.Count == 0) {
                            tabControlSelect.SelectedIndex = 0;
                            EchoHelper.Show("请先选择添加任务的网站！", EchoHelper.MessageType.提示);
                            //EchoHelper.ShowBalloon("选择站点", "请先选择添加任务的网站！", ckBoxSites);
                            return;
                        }
                        tabControlSelect.Size = new Size(tabControlSelect.Size.Width, groupBox2.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControlSelect.Size.Height + 30 + 22);
                        break;
                    }

            }

        }

        private void ckAllSite_CheckedChanged(object sender, EventArgs e) {
            if (ckAllSite.Checked == true) {
                loadSites();
            }
        }

        private void ckNoTaskSiteList_Click(object sender, EventArgs e) {
            if (ckNoTaskSiteList.Checked == true) {
                loadPartSites();
            }
        }

        X_Waiting wait = new X_Waiting();

        private void btnAutoLoad_Click(object sender, EventArgs e) {
            txtTaskList.Text = "";
            wait.ShowMsg("自动装载任务中...");
            new Thread(new ThreadStart(Th_load)).Start();
        }

        private void Th_load() {
            foreach (var item in ckBoxSites.SelectedItems) {
                try {
                    ModelSite site = ModelMain.AllData.SiteList.Find(delegate(ModelSite s) {
                        return s.SiteName == item.ToString();
                    });
                    ModelSite tmp_site = (ModelSite)site.Clone();
                    string taskname = tmp_site.SiteName + "_任务" + StringHelper.getRandNum(2);
                    string keys = !string.IsNullOrEmpty(tmp_site.SiteMainKeys) ? tmp_site.SiteMainKeys : tmp_site.SiteName + "关键词1,关键词2,关键词3";
                    string uid = site.modelUsers[0].Id.ToString();
                    if (!tmp_site.CategoriesIsEnablad) {
                        tmp_site.PostID = "";
                    }
                    txtTaskList.Text += Environment.NewLine + taskname + "   |   " + keys + "   |  " + uid + "   |  " + site.PostID + "   |  " + site.SiteID;
                } catch (Exception ex) {

                    EchoHelper.Echo("请确认该站点，可以正常运行。" + ex.Message, "批量任务", EchoHelper.EchoType.错误信息);
                }
            }
            txtTaskList.Text = txtTaskList.Text.Trim();
            wait.CloseMsg();
        }

        private void btnKeys_Click(object sender, EventArgs e) {
            X_Form_GJC gjc = new X_Form_GJC();
            gjc.ShowDialog();
        }

        private void buttonSpecAny1_Click(object sender, EventArgs e) {
            folderBrowser.RootFolderPath = Application.StartupPath + @"\Task\";
            folderBrowser.Description = "请选择 该任务 保存的路径：";
            folderBrowser.SelectedPath = Application.StartupPath + @"\Task\";
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtTaskPath.Text = folderBrowser.SelectedPath.Replace(Application.StartupPath, "") + "\\";
            }
        }

    }
}
