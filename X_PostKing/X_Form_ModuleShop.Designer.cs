namespace X_PostKing {
    partial class X_Form_ModuleShop {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewPut = new System.Windows.Forms.ListView();
            this.发布模块名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.S内核 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.W内核 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.大小 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.最后更新 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.模块作者 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripPut = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除模块PutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewPick = new System.Windows.Forms.ListView();
            this.抓取模块名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.泛抓 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.大小pick = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.最后更新pick = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.作者pick = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripPick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除模块PickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.search = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStripPut.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStripPick.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.webshop;
            this.pictureBox1.Size = new System.Drawing.Size(502, 50);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 50);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(502, 407);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(494, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发布模块";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewPut);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 375);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "根据需要，选择您想获取的发布模块，双击下载。";
            // 
            // listViewPut
            // 
            this.listViewPut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewPut.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.发布模块名称,
            this.S内核,
            this.W内核,
            this.大小,
            this.最后更新,
            this.模块作者});
            this.listViewPut.ContextMenuStrip = this.contextMenuStripPut;
            this.listViewPut.FullRowSelect = true;
            this.listViewPut.GridLines = true;
            this.listViewPut.Location = new System.Drawing.Point(6, 20);
            this.listViewPut.MultiSelect = false;
            this.listViewPut.Name = "listViewPut";
            this.listViewPut.ShowItemToolTips = true;
            this.listViewPut.Size = new System.Drawing.Size(476, 349);
            this.listViewPut.TabIndex = 1;
            this.listViewPut.UseCompatibleStateImageBehavior = false;
            this.listViewPut.View = System.Windows.Forms.View.Details;
            this.listViewPut.DoubleClick += new System.EventHandler(this.listViewPut_DoubleClick);
            // 
            // 发布模块名称
            // 
            this.发布模块名称.Text = "发布模块名称";
            this.发布模块名称.Width = 160;
            // 
            // S内核
            // 
            this.S内核.Text = "S内核";
            this.S内核.Width = 46;
            // 
            // W内核
            // 
            this.W内核.Text = "W内核";
            this.W内核.Width = 48;
            // 
            // 大小
            // 
            this.大小.Text = "大小";
            this.大小.Width = 48;
            // 
            // 最后更新
            // 
            this.最后更新.Text = "最后更新";
            this.最后更新.Width = 75;
            // 
            // 模块作者
            // 
            this.模块作者.Text = "模块作者";
            this.模块作者.Width = 70;
            // 
            // contextMenuStripPut
            // 
            this.contextMenuStripPut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStripPut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.重命名ToolStripMenuItem,
            this.删除模块PutToolStripMenuItem,
            this.toolStripMenuItem2,
            this.帮助说明ToolStripMenuItem});
            this.contextMenuStripPut.Name = "contextMenuStrip";
            this.contextMenuStripPut.Size = new System.Drawing.Size(153, 136);
            this.contextMenuStripPut.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "下载模块";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.put发布模块下载_Click);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名PutToolStripMenuItem_Click);
            // 
            // 删除模块PutToolStripMenuItem
            // 
            this.删除模块PutToolStripMenuItem.Name = "删除模块PutToolStripMenuItem";
            this.删除模块PutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除模块PutToolStripMenuItem.Text = "删除模块";
            this.删除模块PutToolStripMenuItem.Click += new System.EventHandler(this.put删除模块ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "模块详情";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.put模块详情_Click);
            // 
            // 帮助说明ToolStripMenuItem
            // 
            this.帮助说明ToolStripMenuItem.Name = "帮助说明ToolStripMenuItem";
            this.帮助说明ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.帮助说明ToolStripMenuItem.Text = "帮助链接";
            this.帮助说明ToolStripMenuItem.Click += new System.EventHandler(this.put帮助说明ToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(494, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "抓取模块";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewPick);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 375);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "根据需要，选择您想获取的抓取模块，双击下载。";
            // 
            // listViewPick
            // 
            this.listViewPick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewPick.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.抓取模块名称,
            this.泛抓,
            this.大小pick,
            this.最后更新pick,
            this.作者pick});
            this.listViewPick.ContextMenuStrip = this.contextMenuStripPick;
            this.listViewPick.FullRowSelect = true;
            this.listViewPick.GridLines = true;
            listViewItem2.StateImageIndex = 0;
            this.listViewPick.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listViewPick.Location = new System.Drawing.Point(6, 20);
            this.listViewPick.MultiSelect = false;
            this.listViewPick.Name = "listViewPick";
            this.listViewPick.ShowItemToolTips = true;
            this.listViewPick.Size = new System.Drawing.Size(476, 349);
            this.listViewPick.TabIndex = 2;
            this.listViewPick.UseCompatibleStateImageBehavior = false;
            this.listViewPick.View = System.Windows.Forms.View.Details;
            this.listViewPick.DoubleClick += new System.EventHandler(this.listViewPick_DoubleClick);
            // 
            // 抓取模块名称
            // 
            this.抓取模块名称.Text = "抓取模块名称";
            this.抓取模块名称.Width = 206;
            // 
            // 泛抓
            // 
            this.泛抓.Text = "泛抓";
            this.泛抓.Width = 48;
            // 
            // 大小pick
            // 
            this.大小pick.Text = "大小";
            this.大小pick.Width = 48;
            // 
            // 最后更新pick
            // 
            this.最后更新pick.Text = "最后更新";
            this.最后更新pick.Width = 75;
            // 
            // 作者pick
            // 
            this.作者pick.Text = "模块作者";
            this.作者pick.Width = 70;
            // 
            // contextMenuStripPick
            // 
            this.contextMenuStripPick.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStripPick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.重命名ToolStripMenuItem1,
            this.删除模块PickToolStripMenuItem,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.contextMenuStripPick.Name = "contextMenuStrip";
            this.contextMenuStripPick.Size = new System.Drawing.Size(153, 136);
            this.contextMenuStripPick.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripPick_Opening);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "下载模块";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.pick模块下载_Click);
            // 
            // 重命名ToolStripMenuItem1
            // 
            this.重命名ToolStripMenuItem1.Name = "重命名ToolStripMenuItem1";
            this.重命名ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.重命名ToolStripMenuItem1.Text = "重命名";
            this.重命名ToolStripMenuItem1.Click += new System.EventHandler(this.重命名PickToolStripMenuItem1_Click);
            // 
            // 删除模块PickToolStripMenuItem
            // 
            this.删除模块PickToolStripMenuItem.Name = "删除模块PickToolStripMenuItem";
            this.删除模块PickToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除模块PickToolStripMenuItem.Text = "删除模块";
            this.删除模块PickToolStripMenuItem.Click += new System.EventHandler(this.pick模块删除_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem5.Text = "模块详情";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.pick模块详情_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "帮助链接";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.pick帮助说明_Click);
            // 
            // search
            // 
            this.search.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.search.Location = new System.Drawing.Point(254, 24);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(236, 20);
            this.search.TabIndex = 4;
            this.search.Text = "输入“关键词“查找模块";
            this.search.Enter += new System.EventHandler(this.search_Enter);
            this.search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.ToolTipTitle = "点击或者按回车提交";
            this.buttonSpecAny1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.WorkspaceMaximize;
            this.buttonSpecAny1.UniqueName = "959D8C6D9F25432B64ADB6F0D5AA423C";
            this.buttonSpecAny1.Click += new System.EventHandler(this.buttonSearchEnter_Click);
            // 
            // X_Form_ModuleShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 482);
            this.Controls.Add(this.search);
            this.Controls.Add(this.tabControl);
            this.Name = "X_Form_ModuleShop";
            this.Text = "忍者软件模块市场";
            this.Load += new System.EventHandler(this.X_Form_ModuleShop_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.search, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStripPut.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStripPick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox search;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private System.Windows.Forms.ListView listViewPut;
        private System.Windows.Forms.ColumnHeader 发布模块名称;
        private System.Windows.Forms.ColumnHeader 模块作者;
        private System.Windows.Forms.ColumnHeader 最后更新;
        private System.Windows.Forms.ListView listViewPick;
        private System.Windows.Forms.ColumnHeader 抓取模块名称;
        private System.Windows.Forms.ColumnHeader 泛抓;
        private System.Windows.Forms.ColumnHeader 大小pick;
        private System.Windows.Forms.ColumnHeader 作者pick;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ColumnHeader 大小;
        private System.Windows.Forms.ToolStripMenuItem 帮助说明ToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader S内核;
        private System.Windows.Forms.ColumnHeader W内核;
        private System.Windows.Forms.ToolStripMenuItem 删除模块PutToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader 最后更新pick;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 删除模块PickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem1;
    }
}