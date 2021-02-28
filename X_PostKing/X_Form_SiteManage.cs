using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Service.Util;
using X_Service.Db;
using X_Model;
using WeifenLuo.WinFormsUI.Docking;
using X_Service.Login;
using X_Service.Files;
using X_PostKing.Job;
using ComponentFactory.Krypton.Toolkit;

namespace X_PostKing {

    public partial class X_Form_SiteManage : DockContent {

        public X_Form_SiteManage() {
            InitializeComponent();
        }


        private void X_Form_SiteManage_Load(object sender, EventArgs e) {
            loadAllData();
        }


        public void loadAllData() {
            treeViewSite.Nodes.Clear();
            TreeNode TNode_All = new TreeNode("全部站点");
            TNode_All.Tag = -1;
            TNode_All.ForeColor = Color.Green;
            TNode_All.ImageIndex = 4;
            TNode_All.SelectedImageIndex = 4;

            IList<ModelGroup> glist = ModelMain.AllData.GroupList.FindAll((ModelGroup g) => {
                return g.GroupFID == 0;
            });

            for (int i = 0; i < glist.Count; i++) {
                TreeNode TNode = new TreeNode(glist[i].GroupName);
                TNode.ForeColor = Color.DarkBlue;
                TNode.Name = glist[i].GroupName;
                TNode.ImageIndex = 0;
                TNode.Tag = glist[i].GroupID;
                if (TNode.Name == "默认群组") {
                    TNode.Expand();
                    TNode.Nodes.Add(TNode_All);
                }
                treeViewSite.Nodes.Add(TNode);
                addSite(TNode.Tag.ToString(), TNode);
            }

            //再递归遍历结点
            for (int i = 0; i <= treeViewSite.Nodes.Count - 1; i++) {
                ForTreeNodeFormList(treeViewSite.Nodes[i], ModelMain.AllData.GroupList);
            }
        }


        #region setSelectedNode( int tagid ) 利用无限递归的方式，去选中树节点中的某个节点

        /// <summary>
        /// 设置选中的节点，可以指定是否为站点。
        /// </summary>
        /// <param name="tagid"></param>
        /// <param name="isSite"></param>
        private void setSelectedNode(int tagid, bool isSite) {
            foreach (TreeNode TNode in treeViewSite.Nodes) {
                if (TNode.Tag.ToString() == tagid.ToString()) {
                    if (isSite && TNode.ForeColor == Color.Green) {
                        treeViewSite.SelectedNode = TNode;
                        treeViewSite.SelectedNode.Expand();
                    } else if (!isSite && TNode.ForeColor != Color.Green) {
                        treeViewSite.SelectedNode = TNode;
                        treeViewSite.SelectedNode.Expand();
                    }
                }
                setSelectedNode2(tagid, TNode, isSite);
            }
        }

        private void setSelectedNode2(int tagid, TreeNode node, bool isSite) {
            foreach (TreeNode TNode in node.Nodes) {
                if (TNode.Tag.ToString() == tagid.ToString()) {
                    if (isSite && TNode.ForeColor == Color.Green) {
                        treeViewSite.SelectedNode = TNode;
                        treeViewSite.SelectedNode.Expand();
                    } else if (!isSite && TNode.ForeColor != Color.Green) {
                        treeViewSite.SelectedNode = TNode;
                        treeViewSite.SelectedNode.Expand();
                    }
                }
                setSelectedNode2(tagid, TNode, isSite);
            }
        }

        #endregion

        private void ForTreeNodeFormList(TreeNode TempNode, List<ModelGroup> groupList) {
            string TTag = null;
            TTag = TempNode.Tag.ToString();

            List<ModelGroup> groups = groupList.FindAll((ModelGroup g) => {
                return g.GroupFID.ToString() == TTag && TTag != "0";
            });

            for (int I = 0; I <= groups.Count - 1; I++) {
                TreeNode TNode = new TreeNode(groups[I].GroupName);
                TNode.Tag = groups[I].GroupID;
                TNode.ForeColor = Color.DarkBlue;
                TNode.ImageIndex = 0;
                TempNode.Nodes.Add(TNode);
                addSite(TNode.Tag.ToString(), TNode);
            }

            if (groups.Count > 0) {
                foreach (TreeNode aNode in TempNode.Nodes) {
                    ForTreeNodeFormList(aNode, groupList);
                }
            }
        }

        /// <summary>
        /// 为每一个node添加站点节点。
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="TempNode"></param>
        private void addSite(string groupID, TreeNode TempNode) {
            List<ModelSite> sites = ModelMain.AllData.SiteList.FindAll((ModelSite s) => {
                return s.GroupID.ToString() == groupID;
            });
            for (int i = 0; i < sites.Count; i++) {
                TreeNode TNode2 = new TreeNode(sites[i].SiteName);
                TNode2.Tag = sites[i].SiteID;
                TNode2.ForeColor = Color.Green;
                if ((sites[i].DomainExpire - DateTime.Now).Days < 30) {
                    TNode2.BackColor = System.Drawing.Color.LavenderBlush;
                }
                TNode2.ImageIndex = 1;
                TNode2.SelectedImageIndex = 3;
                TempNode.Nodes.Add(TNode2);
            }
        }

        private void treeViewSite_ItemDrag(object sender, ItemDragEventArgs e) {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private Point Position = new Point(0, 0);

        private void treeViewSite_DragDrop(object sender, DragEventArgs e) {
            TreeNode myNode = null;
            if (e.Data.GetDataPresent(typeof(TreeNode))) {
                myNode = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
            } else {
                KryptonMessageBox.Show("error");
            }
            Position.X = e.X;
            Position.Y = e.Y;
            Position = treeViewSite.PointToClient(Position);
            TreeNode DropNode = this.treeViewSite.GetNodeAt(Position);
            // 1.目标节点不是空。2.目标节点不是被拖拽接点的字节点。3.目标节点不是被拖拽节点本身
            if (DropNode != null && DropNode.Parent != myNode && DropNode != myNode && DropNode.ForeColor != Color.Green) {
                TreeNode DragNode = myNode;
                // 将被拖拽节点从原来位置删除。
                myNode.Remove();
                // 在目标节点下增加被拖拽节点
                DropNode.Nodes.Add(DragNode);

                if (myNode.ForeColor == Color.DarkBlue) {
                    setGroupFID(DragNode.Tag, DropNode.Tag);
                } else {
                    setSiteGroup(DragNode.Tag, DropNode.Tag);
                }
            }
            // 如果目标节点不存在，即拖拽的位置不存在节点，那么就将被拖拽节点放在根节点之下
            if (DropNode == null && myNode.ForeColor == Color.DarkBlue) {
                TreeNode DragNode = myNode;
                myNode.Remove();
                treeViewSite.Nodes.Add(DragNode);
                setGroupFID(DragNode.Tag, "0");
            }
        }

        private void setSiteGroup(object o1, object o2) {
            ModelSite site = ModelMain.AllData.SiteList.Find((ModelSite s) => {
                return s.SiteID.ToString() == o1.ToString();
            });
            if (site != null) {
                site.GroupID = Convert.ToInt32(o2);
            }

        }

        private void setGroupFID(object o1, object o2) {
            ModelGroup group = ModelMain.AllData.GroupList.Find((ModelGroup s) => {
                return s.GroupID.ToString() == o1.ToString();
            });
            if (group != null) {
                group.GroupFID = Convert.ToInt32(o2);
            }
        }

        private void treeViewSite_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }


        private void MenuSiteVisibelSet() {
            MenuPosts.Visible = true;
            添加发布器ToolStripMenuItem.Visible = true;
            新建一个任务ToolStripMenuItem.Visible = true;
            修改站点ToolStripMenuItem.Visible = true;
            删除站点ToolStripMenuItem.Visible = true;
            toolStripSeparator2.Visible = true;
            添加群组ToolStripMenuItem.Visible = true;
            编辑群组ToolStripMenuItem.Visible = true;
            编辑群组ToolStripMenuItem.Enabled = true;
            删除群组ToolStripMenuItem.Visible = true;
            删除群组ToolStripMenuItem.Enabled = true;
            toolStripSeparator1.Visible = true;

        }

        /// <summary>
        /// 打开菜单初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSite_Opening(object sender, CancelEventArgs e) {
            MenuSiteVisibelSet();//重置所有菜单项目为可见。
            TreeNode myNode = treeViewSite.SelectedNode;
            if (myNode.Text != "全部站点") {
                try {
                    if (myNode.ForeColor == Color.DarkBlue) {//鼠标在分组上
                        新建一个任务ToolStripMenuItem.Visible = false;
                        修改站点ToolStripMenuItem.Visible = false;
                        删除站点ToolStripMenuItem.Visible = false;
                        toolStripSeparator2.Visible = false;
                    }
                    if (Color.Green == myNode.ForeColor) {//鼠标在站点上
                        添加发布器ToolStripMenuItem.Visible = false;
                        添加群组ToolStripMenuItem.Visible = false;
                        编辑群组ToolStripMenuItem.Visible = false;
                        删除群组ToolStripMenuItem.Visible = false;
                        toolStripSeparator1.Visible = false;
                    }
                    if (myNode.Text == "默认群组") {
                        编辑群组ToolStripMenuItem.Enabled = false;
                        删除群组ToolStripMenuItem.Enabled = false;
                    }
                } catch {
                    EchoHelper.Echo("群组选择节点出了点问题", "重新选择", EchoHelper.EchoType.异常信息);
                }

            } else {
                //如果点击的是  全部站点 那么
                新建一个任务ToolStripMenuItem.Visible = false;
                修改站点ToolStripMenuItem.Visible = false;
                删除站点ToolStripMenuItem.Visible = false;
                toolStripSeparator2.Visible = false;
                添加发布器ToolStripMenuItem.Visible = false;
                添加群组ToolStripMenuItem.Visible = false;
                编辑群组ToolStripMenuItem.Visible = false;
                删除群组ToolStripMenuItem.Visible = false;
                toolStripSeparator1.Visible = false;
                删除群组ToolStripMenuItem.Enabled = false;
                MenuPosts.Visible = false;
            }
        }

        public delegate void SiteSelectChangeHandler(int siteID, bool isGroup);
        public event SiteSelectChangeHandler SiteSelect;

        private void treeViewSite_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                if (treeViewSite.SelectedNode.ForeColor == Color.Green) {
                    SiteSelect(Convert.ToInt32(treeViewSite.SelectedNode.Tag), false);
                } else {
                    SiteSelect(Convert.ToInt32(treeViewSite.SelectedNode.Tag), true);
                }
#if DEBUG
                //KryptonMessageBox.Show(treeViewSite.SelectedNode.Tag.ToString());
#endif
            } catch {
            }
        }

        private void treeViewSite_DoubleClick(object sender, EventArgs e) {
            try {
                if (treeViewSite.SelectedNode.ForeColor == Color.Green && treeViewSite.SelectedNode.Text != "全部站点") {
                    int siteIndexID = ModelMain.FindSiteIndexIDByID(Convert.ToInt32(treeViewSite.SelectedNode.Tag));
                    ModelSite site = ModelMain.AllData.SiteList[siteIndexID];
                    X_Form_AddSite Edit = new X_Form_AddSite(true, site, ModelMain.AllData.GroupList[ModelMain.FindGroupIndexByID(site.GroupID)].GroupName);
                    if (Edit.ShowDialog() != DialogResult.Cancel) {
                        ModelMain.AllData.SiteList[siteIndexID] = Edit.site;
                        SiteSelect(Convert.ToInt32(treeViewSite.SelectedNode.Tag), false);
                        loadAllData();
                        setSelectedNode(site.SiteID, true);
                    }
                }

            } catch (Exception ex) {
                EchoHelper.Echo(ex.Message, "出错了", EchoHelper.EchoType.异常信息);
            }
        }

        private void 增加组别ToolStripMenuItem_Click(object sender, EventArgs e) {
            X_Form_AddGroup add = new X_Form_AddGroup(false);
            if (add.ShowDialog() == DialogResult.OK) {
                ModelGroup group = new ModelGroup();
                group.GroupID = ModelMain.AllData.LastGroupId;
                group.GroupName = add.Group_Name;

                int count = ModelMain.AllData.GroupList.FindAll((ModelGroup g) => {
                    return g.GroupName == add.Group_Name;
                }).Count;
                if (count == 0) {
                    ModelMain.AllData.GroupList.Add(group);
                    loadAllData();
                    setSelectedNode(group.GroupID, false);
                } else {
                    EchoHelper.Echo("请改用其他组别名称，此名称已经存在！", "增添组别", EchoHelper.EchoType.错误信息);
                    EchoHelper.Show("请改用其他组别名称，此名称已经存在！", EchoHelper.MessageType.错误);
                }
            }
        }

        private void 修改组别ToolStripMenuItem_Click(object sender, EventArgs e) {
            int GroupID = Convert.ToInt32(treeViewSite.SelectedNode.Tag);
            X_Form_AddGroup edit = new X_Form_AddGroup(true, ModelMain.AllData.GroupList[ModelMain.FindGroupIndexByID(GroupID)].GroupName);
            if (edit.ShowDialog() == DialogResult.OK) {
                ModelMain.AllData.GroupList[ModelMain.FindGroupIndexByID(GroupID)].GroupName = edit.Group_Name;
                loadAllData();
                setSelectedNode(GroupID, false);
            }
        }

        private void 删除组别ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show(string.Format("删除改组别后，组别内的站点将归为【默认组别】哦。。。\r\n\r\n您确认要删除：{0} 吗？", treeViewSite.SelectedNode.Text), "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {

                int GroupID = Convert.ToInt32(treeViewSite.SelectedNode.Tag);
                int count = ModelMain.AllData.SiteList.FindAll((ModelSite s) => {
                    return s.GroupID == GroupID;
                }).Count;
                if (count > 0) {
                    EchoHelper.Echo(string.Format("该组别中还有{0}个站点，请先清理一下他们。", count), "任务", EchoHelper.EchoType.错误信息);
                    EchoHelper.Show(string.Format("请先清空该组别下的{0}个站点，需要清理后再删除这个组别。", count), EchoHelper.MessageType.警告);
                    return;
                }
                removeGroupByID(GroupID);
                loadAllData();

            }
        }

        private void removeGroupByID(int gid) {
            for (int i = 0; i < ModelMain.AllData.GroupList.Count; i++) {
                if (ModelMain.AllData.GroupList[i].GroupID == gid) {
                    ModelMain.AllData.GroupList.RemoveAt(i);
                }
            }

        }

        private void 新建站点ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ModelMain.AllData.SiteList.Count > Login_Base.member.sitenum - 1) {
                EchoHelper.Echo("无法添加新站点，已经超过了最大允许的数量，请升级版本。" + Login_Base.member.sitenum, "新建任务", EchoHelper.EchoType.错误信息);
                EchoHelper.Show("无法添加新站点，已经超过了最大允许的数量，请升级版本。", EchoHelper.MessageType.警告);
                ProcessHelper.openUrl("http://www.renzhe.org/home.php?mod=spacecp&ac=credit&op=exchange");
                return;
            }

            int groupID = 0;
            try {
                groupID = Convert.ToInt32(treeViewSite.SelectedNode.Tag);
            } catch {
                EchoHelper.Echo("大侠，请选择一个分类，否则无法继续！", null, EchoHelper.EchoType.普通信息);
                return;
            }
            ModelSite site = new ModelSite();
            site.SiteID = ModelMain.AllData.LastSiteId;
            site.GroupID = groupID;
            X_Form_AddSite addsite = new X_Form_AddSite(false, site, ModelMain.AllData.GroupList[ModelMain.FindGroupIndexByID(groupID)].GroupName);
            if (addsite.ShowDialog() == DialogResult.OK) {
                int count = ModelMain.AllData.SiteList.FindAll((ModelSite s) => {
                    return s.SiteName == site.SiteName;
                }).Count;
                if (count == 0) {
                    site = addsite.site;
                    ModelMain.AllData.SiteList.Add(site);
                    loadAllData();
                    setSelectedNode(site.SiteID, true);
                } else {
                    EchoHelper.Echo("请改用其他站点名称，此名称已经存在！", "增添站点", EchoHelper.EchoType.错误信息);
                    EchoHelper.Show("请改用其他站点名称，此名称已经存在！", EchoHelper.MessageType.错误);
                }
            }
        }

        private void 删除站点ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show(string.Format("您确定要删除{0}这个站点吗？", ""), "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                int siteID = 0;
                try {
                    siteID = Convert.ToInt32(treeViewSite.SelectedNode.Tag);
                } catch {
                    return;
                }
                removeSiteByID(siteID);
            }
        }

        private void 修改站点ToolStripMenuItem_Click(object sender, EventArgs e) {
            treeViewSite_DoubleClick(sender, e);
        }

        private void removeSiteByID(int siteID) {
            int GroupId = 0;
            for (int i = 0; i < ModelMain.AllData.SiteList.Count; i++) {
                if (ModelMain.AllData.SiteList[i].SiteID == siteID) {
                    List<int> RemoveID = new List<int> {
                    };
                    for (int ii = 0; ii < ModelMain.AllData.TasksList.Count; ii++) {
                        if (ModelMain.AllData.TasksList[ii].SiteID == siteID) {
                            RemoveID.Add(ModelMain.AllData.TasksList[ii].TaskID);
                        }
                    }
                    if (RemoveID.Count > 0) {
                        EchoHelper.Echo(string.Format("该站点中还有{0}个任务，请先清理一下他们。", RemoveID.Count), "任务", EchoHelper.EchoType.错误信息);
                        EchoHelper.Show(string.Format("请先清空该站点下的{0}个任务", RemoveID.Count), EchoHelper.MessageType.警告);
                        loadAllData();
                        setSelectedNode(siteID, true);
                        break;
                    } else {
                        GroupId = ModelMain.AllData.SiteList[i].GroupID;
                        EchoHelper.Echo(string.Format("站点：“{0}”删除成功....", ModelMain.AllData.SiteList[i].SiteName), "系统", EchoHelper.EchoType.任务信息);
                        FilesHelper.DeleteInDir(Application.StartupPath + @"\Task\" + ModelMain.AllData.SiteList[i].SiteName);
                        ModelMain.AllData.SiteList.RemoveAt(i);
                        loadAllData();
                        setSelectedNode(GroupId, false);
                    }
                }
            }
        }

        public delegate void TaskStartChangeHandler();
        public event TaskStartChangeHandler taskStart;

        private void 新建一个任务ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ModelMain.AllData.TasksList.Count > Login_Base.member.sitenum * 10 - 1) {
                EchoHelper.Echo("无法添加新任务，已经超过了最大允许的数量，请升级版本。" + Login_Base.member.sitenum * 5, "新建任务", EchoHelper.EchoType.错误信息);
                EchoHelper.Show("无法添加新任务，已经超过了最大允许的数量，请升级版本。", EchoHelper.MessageType.警告);
                ProcessHelper.openUrl("http://www.renzhe.org/home.php?mod=spacecp&ac=credit&op=exchange");
                return;
            }
            try {
                ModelTasks tasks = new ModelTasks();
                tasks.TaskID = ModelMain.AllData.LastTasksId;
                tasks.SiteID = Convert.ToInt32(treeViewSite.SelectedNode.Tag);
                X_Form_AddTask addTask = new X_Form_AddTask(false, tasks);

                if (addTask.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    ModelMain.AllData.TasksList.Add(tasks);
                    SiteSelect(tasks.SiteID, false);
                    loadAllData();
                    setSelectedNode(tasks.SiteID, true);
                }
            } catch (Exception ex) {
                EchoHelper.Echo(ex.Message, "错误", EchoHelper.EchoType.异常信息);
            }
        }
        private void 开始任务ToolStripMenuItem_Click(object sender, EventArgs e) {
            taskStart();
        }



    }
}
