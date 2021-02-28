namespace X_PostKing {
    partial class X_Form_SiteManage {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing ) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点1");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_SiteManage));
            this.treeViewSite = new System.Windows.Forms.TreeView();
            this.MenuPosts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开始任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建一个任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.添加发布器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改站点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除站点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.添加群组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑群组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除群组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MenuPosts.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewSite
            // 
            this.treeViewSite.AllowDrop = true;
            this.treeViewSite.ContextMenuStrip = this.MenuPosts;
            this.treeViewSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSite.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeViewSite.ImageIndex = 0;
            this.treeViewSite.ImageList = this.imageList1;
            this.treeViewSite.Location = new System.Drawing.Point(0, 0);
            this.treeViewSite.Name = "treeViewSite";
            treeNode1.Name = "节点2";
            treeNode1.Text = "节点2";
            treeNode2.Name = "节点0";
            treeNode2.Text = "节点0";
            treeNode3.Name = "节点1";
            treeNode3.Text = "节点1";
            this.treeViewSite.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.treeViewSite.SelectedImageIndex = 2;
            this.treeViewSite.Size = new System.Drawing.Size(184, 515);
            this.treeViewSite.TabIndex = 0;
            this.treeViewSite.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewSite_ItemDrag);
            this.treeViewSite.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSite_AfterSelect);
            this.treeViewSite.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewSite_DragDrop);
            this.treeViewSite.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewSite_DragEnter);
            this.treeViewSite.DoubleClick += new System.EventHandler(this.treeViewSite_DoubleClick);
            // 
            // MenuPosts
            // 
            this.MenuPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MenuPosts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始任务ToolStripMenuItem,
            this.新建一个任务ToolStripMenuItem,
            this.toolStripSeparator2,
            this.添加发布器ToolStripMenuItem,
            this.修改站点ToolStripMenuItem,
            this.删除站点ToolStripMenuItem,
            this.toolStripSeparator1,
            this.添加群组ToolStripMenuItem,
            this.编辑群组ToolStripMenuItem,
            this.删除群组ToolStripMenuItem});
            this.MenuPosts.Name = "Menu_Tree_Group";
            this.MenuPosts.Size = new System.Drawing.Size(153, 214);
            this.MenuPosts.Opening += new System.ComponentModel.CancelEventHandler(this.MenuSite_Opening);
            // 
            // 开始任务ToolStripMenuItem
            // 
            this.开始任务ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.run;
            this.开始任务ToolStripMenuItem.Name = "开始任务ToolStripMenuItem";
            this.开始任务ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开始任务ToolStripMenuItem.Text = "开始任务";
            this.开始任务ToolStripMenuItem.Click += new System.EventHandler(this.开始任务ToolStripMenuItem_Click);
            // 
            // 新建一个任务ToolStripMenuItem
            // 
            this.新建一个任务ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.add;
            this.新建一个任务ToolStripMenuItem.Name = "新建一个任务ToolStripMenuItem";
            this.新建一个任务ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新建一个任务ToolStripMenuItem.Text = "增加新任务";
            this.新建一个任务ToolStripMenuItem.Click += new System.EventHandler(this.新建一个任务ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // 添加发布器ToolStripMenuItem
            // 
            this.添加发布器ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.addposter;
            this.添加发布器ToolStripMenuItem.Name = "添加发布器ToolStripMenuItem";
            this.添加发布器ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加发布器ToolStripMenuItem.Text = "新建站点";
            this.添加发布器ToolStripMenuItem.Click += new System.EventHandler(this.新建站点ToolStripMenuItem_Click);
            // 
            // 修改站点ToolStripMenuItem
            // 
            this.修改站点ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.eidt;
            this.修改站点ToolStripMenuItem.Name = "修改站点ToolStripMenuItem";
            this.修改站点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改站点ToolStripMenuItem.Text = "修改站点";
            this.修改站点ToolStripMenuItem.Click += new System.EventHandler(this.修改站点ToolStripMenuItem_Click);
            // 
            // 删除站点ToolStripMenuItem
            // 
            this.删除站点ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.delete;
            this.删除站点ToolStripMenuItem.Name = "删除站点ToolStripMenuItem";
            this.删除站点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除站点ToolStripMenuItem.Text = "删除站点";
            this.删除站点ToolStripMenuItem.Click += new System.EventHandler(this.删除站点ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 添加群组ToolStripMenuItem
            // 
            this.添加群组ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.addgroup;
            this.添加群组ToolStripMenuItem.Name = "添加群组ToolStripMenuItem";
            this.添加群组ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加群组ToolStripMenuItem.Text = "添加群组";
            this.添加群组ToolStripMenuItem.Click += new System.EventHandler(this.增加组别ToolStripMenuItem_Click);
            // 
            // 编辑群组ToolStripMenuItem
            // 
            this.编辑群组ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.editgroup;
            this.编辑群组ToolStripMenuItem.Name = "编辑群组ToolStripMenuItem";
            this.编辑群组ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.编辑群组ToolStripMenuItem.Text = "编辑群组";
            this.编辑群组ToolStripMenuItem.Click += new System.EventHandler(this.修改组别ToolStripMenuItem_Click);
            // 
            // 删除群组ToolStripMenuItem
            // 
            this.删除群组ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.delgroup;
            this.删除群组ToolStripMenuItem.Name = "删除群组ToolStripMenuItem";
            this.删除群组ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除群组ToolStripMenuItem.Text = "删除群组";
            this.删除群组ToolStripMenuItem.Click += new System.EventHandler(this.删除组别ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "stock_group.png");
            this.imageList1.Images.SetKeyName(1, "web.gif");
            this.imageList1.Images.SetKeyName(2, "stock_enter_group.png");
            this.imageList1.Images.SetKeyName(3, "pm.png");
            this.imageList1.Images.SetKeyName(4, "all.png");
            // 
            // X_Form_SiteManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 515);
            this.CloseButton = false;
            this.Controls.Add(this.treeViewSite);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "X_Form_SiteManage";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "站点管理";
            this.Text = "站点管理";
            this.Load += new System.EventHandler(this.X_Form_SiteManage_Load);
            this.MenuPosts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewSite;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip MenuPosts;
        private System.Windows.Forms.ToolStripMenuItem 新建一个任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 添加发布器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改站点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除站点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加群组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑群组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除群组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 开始任务ToolStripMenuItem;

    }
}

