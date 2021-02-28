namespace X_PostKing {
    partial class X_Form_LinkCycle {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_LinkCycle));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TS_保存 = new System.Windows.Forms.ToolStripButton();
            this.TS_取消 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvLinkCycle = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuLinkCycle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.访问URLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuLinkCycle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.X_Form_LinkCycle;
            this.pictureBox1.Size = new System.Drawing.Size(889, 50);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_保存,
            this.TS_取消});
            this.toolStrip1.Location = new System.Drawing.Point(0, 50);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(889, 39);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TS_保存
            // 
            this.TS_保存.Image = ((System.Drawing.Image)(resources.GetObject("TS_保存.Image")));
            this.TS_保存.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_保存.Name = "TS_保存";
            this.TS_保存.Size = new System.Drawing.Size(67, 36);
            this.TS_保存.Text = "保存";
            this.TS_保存.Click += new System.EventHandler(this.TS_保存_Click);
            // 
            // TS_取消
            // 
            this.TS_取消.Image = ((System.Drawing.Image)(resources.GetObject("TS_取消.Image")));
            this.TS_取消.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_取消.Name = "TS_取消";
            this.TS_取消.Size = new System.Drawing.Size(67, 36);
            this.TS_取消.Text = "取消";
            this.TS_取消.Click += new System.EventHandler(this.TS_取消_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(889, 389);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(881, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "链轮库管理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvLinkCycle);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(875, 354);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "链轮具体内容";
            // 
            // lvLinkCycle
            // 
            this.lvLinkCycle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvLinkCycle.ContextMenuStrip = this.menuLinkCycle;
            this.lvLinkCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLinkCycle.FullRowSelect = true;
            this.lvLinkCycle.GridLines = true;
            this.lvLinkCycle.Location = new System.Drawing.Point(3, 17);
            this.lvLinkCycle.Name = "lvLinkCycle";
            this.lvLinkCycle.Size = new System.Drawing.Size(869, 334);
            this.lvLinkCycle.TabIndex = 1;
            this.lvLinkCycle.UseCompatibleStateImageBehavior = false;
            this.lvLinkCycle.View = System.Windows.Forms.View.Details;
            this.lvLinkCycle.DoubleClick += new System.EventHandler(this.lvLinkCycle_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "链接信息ID,URL,TITLE,KEYWORD,OVER";
            this.columnHeader1.Width = 757;
            // 
            // menuLinkCycle
            // 
            this.menuLinkCycle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuLinkCycle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.访问URLToolStripMenuItem});
            this.menuLinkCycle.Name = "menu";
            this.menuLinkCycle.Size = new System.Drawing.Size(153, 48);
            this.menuLinkCycle.Opening += new System.ComponentModel.CancelEventHandler(this.menuLinkCycle_Opening);
            // 
            // 访问URLToolStripMenuItem
            // 
            this.访问URLToolStripMenuItem.Name = "访问URLToolStripMenuItem";
            this.访问URLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.访问URLToolStripMenuItem.Text = "访问URL";
            this.访问URLToolStripMenuItem.Click += new System.EventHandler(this.访问URLToolStripMenuItem_Click);
            // 
            // X_Form_LinkCycle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 503);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "X_Form_LinkCycle";
            this.Text = "超级链轮库";
            this.Load += new System.EventHandler(this.X_Form_LinkCycle_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuLinkCycle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TS_保存;
        private System.Windows.Forms.ToolStripButton TS_取消;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvLinkCycle;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip menuLinkCycle;
        private System.Windows.Forms.ToolStripMenuItem 访问URLToolStripMenuItem;
    }
}