namespace X_PostKing.Tools {
    partial class X_Form_SiteInfo {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( ) {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDomainExpire = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnBaiduCollection = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnStart = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnReset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.x_Lable1 = new X_Service.Util.X_Lable();
            this.listViewKeys = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuPM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查询排名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关键词设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.访问网站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SEO详情ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuPM.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.extend;
            this.pictureBox1.Size = new System.Drawing.Size(916, 50);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(916, 485);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(908, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "排名查询";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDomainExpire);
            this.groupBox1.Controls.Add(this.btnBaiduCollection);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.x_Lable1);
            this.groupBox1.Controls.Add(this.listViewKeys);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(902, 453);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网站关键字、收录、域名到期排名查询，点击开始即可查询。粉色背景代表即将过期的域名。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "提示：可以按住Ctrl+鼠标左键多选，右键菜单同时查询！";
            // 
            // btnDomainExpire
            // 
            this.btnDomainExpire.Location = new System.Drawing.Point(240, 18);
            this.btnDomainExpire.Name = "btnDomainExpire";
            this.btnDomainExpire.Size = new System.Drawing.Size(105, 25);
            this.btnDomainExpire.TabIndex = 6;
            this.btnDomainExpire.Values.Text = "域名到期查询";
            this.btnDomainExpire.Click += new System.EventHandler(this.btnDomainExpire_Click);
            // 
            // btnBaiduCollection
            // 
            this.btnBaiduCollection.Location = new System.Drawing.Point(123, 18);
            this.btnBaiduCollection.Name = "btnBaiduCollection";
            this.btnBaiduCollection.Size = new System.Drawing.Size(105, 25);
            this.btnBaiduCollection.TabIndex = 6;
            this.btnBaiduCollection.Values.Text = "收录查询";
            this.btnBaiduCollection.Click += new System.EventHandler(this.btnBaiduCollection_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(105, 25);
            this.btnStart.TabIndex = 6;
            this.btnStart.Values.Text = "关键字排名查询";
            this.btnStart.Click += new System.EventHandler(this.btnKeysPMStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(778, 18);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 25);
            this.btnReset.TabIndex = 5;
            this.btnReset.Values.Text = "刷新";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // x_Lable1
            // 
            this.x_Lable1.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable1.Location = new System.Drawing.Point(874, 22);
            this.x_Lable1.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.Name = "x_Lable1";
            this.x_Lable1.ShowControl = this.listViewKeys;
            this.x_Lable1.ShowText = "查询关键词方法，可以用按钮【关键字排名查询】或者右键单独进行查询。输入要查询的关键词，多个关键词请用英文逗号‘,’分隔。若有多个关键词，后面的排名也会相应的出现分" +
                "隔的排名数字。\r\n网址格式：http://www.xxxx.com/\r\n排名结构：-1代表百度在100名之内，没有发现该网站。\r\n重载列表：当您更新了站点信息，" +
                "但是没有显示出来，重载后就会显示出最新的。";
            this.x_Lable1.ShowTitle = "关键词查询";
            this.x_Lable1.Size = new System.Drawing.Size(22, 17);
            this.x_Lable1.TabIndex = 3;
            // 
            // listViewKeys
            // 
            this.listViewKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader14,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewKeys.ContextMenuStrip = this.menuPM;
            this.listViewKeys.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewKeys.FullRowSelect = true;
            this.listViewKeys.GridLines = true;
            this.listViewKeys.Location = new System.Drawing.Point(3, 49);
            this.listViewKeys.Name = "listViewKeys";
            this.listViewKeys.Size = new System.Drawing.Size(896, 401);
            this.listViewKeys.TabIndex = 0;
            this.listViewKeys.UseCompatibleStateImageBehavior = false;
            this.listViewKeys.View = System.Windows.Forms.View.Details;
            this.listViewKeys.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewKeys_ColumnClick);
            this.listViewKeys.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewKeys_MouseDoubleClick);
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "编号";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "网站名称";
            this.columnHeader1.Width = 113;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "网站网址";
            this.columnHeader2.Width = 197;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "收录";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "关键词";
            this.columnHeader3.Width = 248;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "排名";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "余日";
            this.columnHeader5.Width = 65;
            // 
            // menuPM
            // 
            this.menuPM.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuPM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询排名ToolStripMenuItem,
            this.关键词设置ToolStripMenuItem,
            this.访问网站ToolStripMenuItem,
            this.SEO详情ToolStripMenuItem});
            this.menuPM.Name = "menuPM";
            this.menuPM.Size = new System.Drawing.Size(153, 114);
            this.menuPM.Opening += new System.ComponentModel.CancelEventHandler(this.menuPM_Opening);
            // 
            // 查询排名ToolStripMenuItem
            // 
            this.查询排名ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.pm;
            this.查询排名ToolStripMenuItem.Name = "查询排名ToolStripMenuItem";
            this.查询排名ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查询排名ToolStripMenuItem.Text = "查询信息";
            this.查询排名ToolStripMenuItem.Click += new System.EventHandler(this.查询排名ToolStripMenuItem_Click);
            // 
            // 关键词设置ToolStripMenuItem
            // 
            this.关键词设置ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.eidt;
            this.关键词设置ToolStripMenuItem.Name = "关键词设置ToolStripMenuItem";
            this.关键词设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关键词设置ToolStripMenuItem.Text = "关键词设置";
            this.关键词设置ToolStripMenuItem.Click += new System.EventHandler(this.关键词设置ToolStripMenuItem_Click);
            // 
            // 访问网站ToolStripMenuItem
            // 
            this.访问网站ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.visit;
            this.访问网站ToolStripMenuItem.Name = "访问网站ToolStripMenuItem";
            this.访问网站ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.访问网站ToolStripMenuItem.Text = "访问网站";
            this.访问网站ToolStripMenuItem.Click += new System.EventHandler(this.访问网站ToolStripMenuItem_Click);
            // 
            // SEO详情ToolStripMenuItem
            // 
            this.SEO详情ToolStripMenuItem.Image = global::X_PostKing.Properties.Resources.chinaz1;
            this.SEO详情ToolStripMenuItem.Name = "SEO详情ToolStripMenuItem";
            this.SEO详情ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SEO详情ToolStripMenuItem.Text = "SEO详情";
            this.SEO详情ToolStripMenuItem.Click += new System.EventHandler(this.SEO详情ToolStripMenuItem_Click);
            // 
            // X_Form_SiteInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 560);
            this.Controls.Add(this.tabControl1);
            this.Name = "X_Form_SiteInfo";
            this.Text = "网站报表";
            this.Load += new System.EventHandler(this.X_Form_SiteInfo_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuPM.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewKeys;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ContextMenuStrip menuPM;
        private System.Windows.Forms.ToolStripMenuItem 查询排名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关键词设置ToolStripMenuItem;
        private X_Service.Util.X_Lable x_Lable1;
        private System.Windows.Forms.ToolStripMenuItem 访问网站ToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ToolStripMenuItem SEO详情ToolStripMenuItem;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReset;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStart;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBaiduCollection;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDomainExpire;
        private System.Windows.Forms.Label label1;
    }
}