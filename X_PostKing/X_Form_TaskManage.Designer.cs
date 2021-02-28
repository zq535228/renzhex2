namespace X_PostKing {
    partial class X_Form_TaskManage {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_TaskManage));
            this.ListViewTasks = new System.Windows.Forms.ListView();
            this.Numbers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EebSiteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.批次 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsRandUp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StateName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CMS_任务列表 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开始任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动浏览器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑任务ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除任务ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.文章管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看文章ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入文章ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer相关域 = new System.Windows.Forms.Timer(this.components);
            this.timer刷新任务状态 = new System.Windows.Forms.Timer(this.components);
            this.CMS_任务列表.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListViewTasks
            // 
            this.ListViewTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Numbers,
            this.TaskName,
            this.EebSiteName,
            this.批次,
            this.IsRandUp,
            this.StateName});
            this.ListViewTasks.ContextMenuStrip = this.CMS_任务列表;
            this.ListViewTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewTasks.FullRowSelect = true;
            this.ListViewTasks.GridLines = true;
            this.ListViewTasks.Location = new System.Drawing.Point(0, 0);
            this.ListViewTasks.Name = "ListViewTasks";
            this.ListViewTasks.Size = new System.Drawing.Size(948, 439);
            this.ListViewTasks.TabIndex = 10;
            this.ListViewTasks.UseCompatibleStateImageBehavior = false;
            this.ListViewTasks.View = System.Windows.Forms.View.Details;
            this.ListViewTasks.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.List_Pack_ColumnClick);
            this.ListViewTasks.DoubleClick += new System.EventHandler(this.ListViewTasks_DoubleClick);
            // 
            // Numbers
            // 
            this.Numbers.Text = "任务ID";
            this.Numbers.Width = 52;
            // 
            // TaskName
            // 
            this.TaskName.Text = "任务名称";
            this.TaskName.Width = 188;
            // 
            // EebSiteName
            // 
            this.EebSiteName.Text = "站点名称";
            this.EebSiteName.Width = 177;
            // 
            // 批次
            // 
            this.批次.Text = "批次/数量";
            this.批次.Width = 81;
            // 
            // IsRandUp
            // 
            this.IsRandUp.Text = "任务种类";
            this.IsRandUp.Width = 84;
            // 
            // StateName
            // 
            this.StateName.Text = "当前状态";
            this.StateName.Width = 172;
            // 
            // CMS_任务列表
            // 
            this.CMS_任务列表.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CMS_任务列表.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始任务ToolStripMenuItem,
            this.启动浏览器ToolStripMenuItem,
            this.停止任务ToolStripMenuItem,
            this.编辑任务ToolStripMenuItem1,
            this.删除任务ToolStripMenuItem1,
            this.文章管理ToolStripMenuItem});
            this.CMS_任务列表.Name = "CMS_任务列表";
            this.CMS_任务列表.Size = new System.Drawing.Size(135, 136);
            this.CMS_任务列表.Opening += new System.ComponentModel.CancelEventHandler(this.CMS_任务列表_Opening);
            // 
            // 开始任务ToolStripMenuItem
            // 
            this.开始任务ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.run;
            this.开始任务ToolStripMenuItem.Name = "开始任务ToolStripMenuItem";
            this.开始任务ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.开始任务ToolStripMenuItem.Text = "启动任务";
            this.开始任务ToolStripMenuItem.Click += new System.EventHandler(this.开始任务ToolStripMenuItem_Click);
            // 
            // 启动浏览器ToolStripMenuItem
            // 
            this.启动浏览器ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("启动浏览器ToolStripMenuItem.Image")));
            this.启动浏览器ToolStripMenuItem.Name = "启动浏览器ToolStripMenuItem";
            this.启动浏览器ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.启动浏览器ToolStripMenuItem.Text = "启动浏览器";
            this.启动浏览器ToolStripMenuItem.Click += new System.EventHandler(this.启动浏览器ToolStripMenuItem_Click);
            // 
            // 停止任务ToolStripMenuItem
            // 
            this.停止任务ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.s_stop;
            this.停止任务ToolStripMenuItem.Name = "停止任务ToolStripMenuItem";
            this.停止任务ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.停止任务ToolStripMenuItem.Text = "停止任务";
            this.停止任务ToolStripMenuItem.Click += new System.EventHandler(this.停止任务ToolStripMenuItem_Click);
            // 
            // 编辑任务ToolStripMenuItem1
            // 
            this.编辑任务ToolStripMenuItem1.Image = global::X_PostKing.Properties.Resources.eidt;
            this.编辑任务ToolStripMenuItem1.Name = "编辑任务ToolStripMenuItem1";
            this.编辑任务ToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.编辑任务ToolStripMenuItem1.Text = "编辑任务";
            this.编辑任务ToolStripMenuItem1.Click += new System.EventHandler(this.编辑任务ToolStripMenuItem_Click);
            // 
            // 删除任务ToolStripMenuItem1
            // 
            this.删除任务ToolStripMenuItem1.Image = global::X_PostKing.Properties.Resources.delete;
            this.删除任务ToolStripMenuItem1.Name = "删除任务ToolStripMenuItem1";
            this.删除任务ToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.删除任务ToolStripMenuItem1.Text = "删除任务";
            this.删除任务ToolStripMenuItem1.Click += new System.EventHandler(this.删除任务ToolStripMenuItem_Click);
            // 
            // 文章管理ToolStripMenuItem
            // 
            this.文章管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看文章ToolStripMenuItem,
            this.导入文章ToolStripMenuItem});
            this.文章管理ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.document_save_as;
            this.文章管理ToolStripMenuItem.Name = "文章管理ToolStripMenuItem";
            this.文章管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.文章管理ToolStripMenuItem.Text = "文章管理";
            // 
            // 查看文章ToolStripMenuItem
            // 
            this.查看文章ToolStripMenuItem.Name = "查看文章ToolStripMenuItem";
            this.查看文章ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.查看文章ToolStripMenuItem.Text = "查看文章";
            this.查看文章ToolStripMenuItem.Click += new System.EventHandler(this.查看文章ToolStripMenuItem_Click);
            // 
            // 导入文章ToolStripMenuItem
            // 
            this.导入文章ToolStripMenuItem.Name = "导入文章ToolStripMenuItem";
            this.导入文章ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.导入文章ToolStripMenuItem.Text = "导入文章";
            this.导入文章ToolStripMenuItem.Click += new System.EventHandler(this.导入文章ToolStripMenuItem_Click);
            // 
            // timer相关域
            // 
            this.timer相关域.Enabled = true;
            this.timer相关域.Interval = 3600000;
            this.timer相关域.Tick += new System.EventHandler(this.timer相关域_Tick);
            // 
            // timer刷新任务状态
            // 
            this.timer刷新任务状态.Enabled = true;
            this.timer刷新任务状态.Interval = 20000;
            this.timer刷新任务状态.Tick += new System.EventHandler(this.timer刷新任务状态_Tick);
            // 
            // X_Form_TaskManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 439);
            this.CloseButton = false;
            this.Controls.Add(this.ListViewTasks);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "X_Form_TaskManage";
            this.TabText = "任务管理中心";
            this.Text = "X_Form_TaskManage";
            this.Load += new System.EventHandler(this.X_Form_TaskManage_Load);
            this.CMS_任务列表.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListViewTasks;
        private System.Windows.Forms.ColumnHeader Numbers;
        private System.Windows.Forms.ColumnHeader TaskName;
        private System.Windows.Forms.ColumnHeader EebSiteName;
        private System.Windows.Forms.ColumnHeader 批次;
        private System.Windows.Forms.ColumnHeader IsRandUp;
        private System.Windows.Forms.ColumnHeader StateName;
        private System.Windows.Forms.ContextMenuStrip CMS_任务列表;
        private System.Windows.Forms.ToolStripMenuItem 开始任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑任务ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除任务ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 文章管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看文章ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入文章ToolStripMenuItem;
        private System.Windows.Forms.Timer timer相关域;
        private System.Windows.Forms.Timer timer刷新任务状态;
        private System.Windows.Forms.ToolStripMenuItem 启动浏览器ToolStripMenuItem;
    }
}