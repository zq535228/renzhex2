namespace X_PostKing {
    partial class X_Form_BatchAddTask {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_BatchAddTask));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TS_保存 = new System.Windows.Forms.ToolStripButton();
            this.TS_取消 = new System.Windows.Forms.ToolStripButton();
            this.tabControlSelect = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckBoxSites = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.ckNoTaskSiteList = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.ckAllSite = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTaskPath = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.x_Lable2 = new X_Service.Util.X_Lable();
            this.x_Lable1 = new X_Service.Util.X_Lable();
            this.btnAutoLoad = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtTaskList = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnKeys = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonCheckSet站点挑选 = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.folderBrowser = new X_Service.Ctrl.FolderBrowserDialogEx();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabControlSelect.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet站点挑选)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.X_Form_Task;
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
            this.toolStrip1.Size = new System.Drawing.Size(604, 39);
            this.toolStrip1.TabIndex = 7;
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
            // tabControlSelect
            // 
            this.tabControlSelect.Controls.Add(this.tabPage1);
            this.tabControlSelect.Controls.Add(this.tabPage2);
            this.tabControlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlSelect.Location = new System.Drawing.Point(0, 89);
            this.tabControlSelect.Name = "tabControlSelect";
            this.tabControlSelect.SelectedIndex = 0;
            this.tabControlSelect.Size = new System.Drawing.Size(604, 274);
            this.tabControlSelect.TabIndex = 8;
            this.tabControlSelect.SelectedIndexChanged += new System.EventHandler(this.tabControlSelect_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(596, 248);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "选择站点";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckBoxSites);
            this.groupBox1.Controls.Add(this.ckNoTaskSiteList);
            this.groupBox1.Controls.Add(this.ckAllSite);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请勾选要批量添加任务的站点们";
            // 
            // ckBoxSites
            // 
            this.ckBoxSites.Location = new System.Drawing.Point(6, 51);
            this.ckBoxSites.Name = "ckBoxSites";
            this.ckBoxSites.ScrollAlwaysVisible = true;
            this.ckBoxSites.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ckBoxSites.Size = new System.Drawing.Size(578, 168);
            this.ckBoxSites.TabIndex = 7;
            // 
            // ckNoTaskSiteList
            // 
            this.ckNoTaskSiteList.Checked = true;
            this.ckNoTaskSiteList.Location = new System.Drawing.Point(6, 20);
            this.ckNoTaskSiteList.Name = "ckNoTaskSiteList";
            this.ckNoTaskSiteList.Size = new System.Drawing.Size(90, 25);
            this.ckNoTaskSiteList.TabIndex = 6;
            this.ckNoTaskSiteList.Values.Text = "无任务站点";
            this.ckNoTaskSiteList.Click += new System.EventHandler(this.ckNoTaskSiteList_Click);
            // 
            // ckAllSite
            // 
            this.ckAllSite.Location = new System.Drawing.Point(102, 20);
            this.ckAllSite.Name = "ckAllSite";
            this.ckAllSite.Size = new System.Drawing.Size(90, 25);
            this.ckAllSite.TabIndex = 5;
            this.ckAllSite.Values.Text = "全部站点";
            this.ckAllSite.Click += new System.EventHandler(this.ckAllSite_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(596, 248);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "任务列表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTaskPath);
            this.groupBox2.Controls.Add(this.kryptonLabel1);
            this.groupBox2.Controls.Add(this.x_Lable2);
            this.groupBox2.Controls.Add(this.x_Lable1);
            this.groupBox2.Controls.Add(this.btnAutoLoad);
            this.groupBox2.Controls.Add(this.txtTaskList);
            this.groupBox2.Controls.Add(this.btnKeys);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 239);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加任务列表";
            // 
            // txtTaskPath
            // 
            this.txtTaskPath.AlwaysActive = false;
            this.txtTaskPath.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.txtTaskPath.Location = new System.Drawing.Point(341, 22);
            this.txtTaskPath.Name = "txtTaskPath";
            this.txtTaskPath.Size = new System.Drawing.Size(215, 20);
            this.txtTaskPath.TabIndex = 6;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(247, 22);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(98, 20);
            this.kryptonLabel1.TabIndex = 8;
            this.kryptonLabel1.Values.Text = "批量任务路径：";
            // 
            // x_Lable2
            // 
            this.x_Lable2.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable2.Location = new System.Drawing.Point(562, 24);
            this.x_Lable2.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable2.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable2.Name = "x_Lable2";
            this.x_Lable2.ShowControl = this.txtTaskPath;
            this.x_Lable2.ShowText = "统一的任务路径，如果为空，则创建各自的任务文件夹。";
            this.x_Lable2.ShowTitle = "任务路径";
            this.x_Lable2.Size = new System.Drawing.Size(22, 17);
            this.x_Lable2.TabIndex = 7;
            // 
            // x_Lable1
            // 
            this.x_Lable1.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable1.Location = new System.Drawing.Point(200, 24);
            this.x_Lable1.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable1.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.Name = "x_Lable1";
            this.x_Lable1.ShowControl = this.btnAutoLoad;
            this.x_Lable1.ShowText = "任务一行一个，格式如下：任务名 | 关键词1,关键词2 | 指派用户ID | 栏目1,栏目2  | 所属站点ID。\r\n任务批量添加后，一般需要再编辑下！";
            this.x_Lable1.ShowTitle = "任务格式";
            this.x_Lable1.Size = new System.Drawing.Size(22, 17);
            this.x_Lable1.TabIndex = 5;
            // 
            // btnAutoLoad
            // 
            this.btnAutoLoad.Location = new System.Drawing.Point(7, 20);
            this.btnAutoLoad.Name = "btnAutoLoad";
            this.btnAutoLoad.Size = new System.Drawing.Size(90, 25);
            this.btnAutoLoad.TabIndex = 4;
            this.btnAutoLoad.Values.Text = "自动加载";
            this.btnAutoLoad.Click += new System.EventHandler(this.btnAutoLoad_Click);
            // 
            // txtTaskList
            // 
            this.txtTaskList.Location = new System.Drawing.Point(7, 51);
            this.txtTaskList.Multiline = true;
            this.txtTaskList.Name = "txtTaskList";
            this.txtTaskList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTaskList.Size = new System.Drawing.Size(577, 182);
            this.txtTaskList.TabIndex = 1;
            // 
            // btnKeys
            // 
            this.btnKeys.Location = new System.Drawing.Point(103, 20);
            this.btnKeys.Name = "btnKeys";
            this.btnKeys.Size = new System.Drawing.Size(90, 25);
            this.btnKeys.TabIndex = 0;
            this.btnKeys.Values.Text = "关键词工具";
            this.btnKeys.Click += new System.EventHandler(this.btnKeys_Click);
            // 
            // kryptonCheckSet站点挑选
            // 
            this.kryptonCheckSet站点挑选.AllowUncheck = true;
            this.kryptonCheckSet站点挑选.CheckButtons.Add(this.ckAllSite);
            this.kryptonCheckSet站点挑选.CheckButtons.Add(this.ckNoTaskSiteList);
            this.kryptonCheckSet站点挑选.CheckedButton = this.ckNoTaskSiteList;
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowRight;
            this.buttonSpecAny1.UniqueName = "DB4B6C283F85469FF19DFEEC28D41884";
            this.buttonSpecAny1.Click += new System.EventHandler(this.buttonSpecAny1_Click);
            // 
            // folderBrowser
            // 
            this.folderBrowser.Description = "";
            this.folderBrowser.RootFolder = System.Environment.SpecialFolder.Desktop;
            this.folderBrowser.RootFolderPath = "";
            this.folderBrowser.SelectedPath = "";
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // X_Form_BatchAddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 387);
            this.Controls.Add(this.tabControlSelect);
            this.Controls.Add(this.toolStrip1);
            this.Name = "X_Form_BatchAddTask";
            this.Text = "批量任务";
            this.Load += new System.EventHandler(this.X_Form_BatchAddTask_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.tabControlSelect, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControlSelect.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet站点挑选)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TS_保存;
        private System.Windows.Forms.ToolStripButton TS_取消;
        private System.Windows.Forms.TabControl tabControlSelect;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton ckNoTaskSiteList;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton ckAllSite;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet kryptonCheckSet站点挑选;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox ckBoxSites;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnKeys;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTaskList;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAutoLoad;
        private X_Service.Util.X_Lable x_Lable1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTaskPath;
        private X_Service.Util.X_Lable x_Lable2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private X_Service.Ctrl.FolderBrowserDialogEx folderBrowser;
    }
}