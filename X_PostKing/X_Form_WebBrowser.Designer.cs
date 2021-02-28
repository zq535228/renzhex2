using System.Windows.Forms;

namespace X_PostKing
{
    partial class X_Form_WebBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            System.GC.Collect();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_WebBrowser));
            this.btnModuleSet = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonLinkLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonLinkLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.groupTools = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.buttonSpecHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnArticleImport = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.LinkTask = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.LinkSite = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kryptonLinkLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupTools)).BeginInit();
            this.groupTools.Panel.SuspendLayout();
            this.groupTools.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModuleSet
            // 
            this.btnModuleSet.Location = new System.Drawing.Point(6, 72);
            this.btnModuleSet.Name = "btnModuleSet";
            this.btnModuleSet.Size = new System.Drawing.Size(60, 20);
            this.btnModuleSet.TabIndex = 1;
            this.btnModuleSet.Values.Text = "模块编写";
            this.btnModuleSet.LinkClicked += new System.EventHandler(this.btnModuleSet_LinkClicked);
            // 
            // kryptonLinkLabel2
            // 
            this.kryptonLinkLabel2.Location = new System.Drawing.Point(6, 45);
            this.kryptonLinkLabel2.Name = "kryptonLinkLabel2";
            this.kryptonLinkLabel2.Size = new System.Drawing.Size(102, 20);
            this.kryptonLinkLabel2.TabIndex = 1;
            this.kryptonLinkLabel2.Values.Text = "发布填写(Ctrl+2)";
            this.kryptonLinkLabel2.LinkClicked += new System.EventHandler(this.btnPut_LinkClicked);
            // 
            // kryptonLinkLabel1
            // 
            this.kryptonLinkLabel1.Location = new System.Drawing.Point(6, 19);
            this.kryptonLinkLabel1.Name = "kryptonLinkLabel1";
            this.kryptonLinkLabel1.Size = new System.Drawing.Size(102, 20);
            this.kryptonLinkLabel1.TabIndex = 0;
            this.kryptonLinkLabel1.Values.Text = "登录填写(Ctrl+1)";
            this.kryptonLinkLabel1.LinkClicked += new System.EventHandler(this.btnlogin_LinkClicked);
            // 
            // groupTools
            // 
            this.groupTools.AllowButtonSpecToolTips = true;
            this.groupTools.AutoSize = true;
            this.groupTools.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.buttonSpecHeaderGroup1});
            this.groupTools.Location = new System.Drawing.Point(12, 12);
            this.groupTools.Name = "groupTools";
            // 
            // groupTools.Panel
            // 
            this.groupTools.Panel.Controls.Add(this.groupBox3);
            this.groupTools.Panel.Controls.Add(this.groupBox2);
            this.groupTools.Panel.Controls.Add(this.groupBox1);
            this.groupTools.Panel.Padding = new System.Windows.Forms.Padding(3);
            this.groupTools.Size = new System.Drawing.Size(125, 302);
            this.groupTools.TabIndex = 3;
            this.groupTools.ValuesPrimary.Heading = "辅助工具";
            this.groupTools.ValuesSecondary.Heading = "本任务共有0篇文章";
            this.groupTools.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kryptonHeaderGroup1_MouseDown);
            this.groupTools.MouseMove += new System.Windows.Forms.MouseEventHandler(this.kryptonHeaderGroup1_MouseMove);
            this.groupTools.MouseUp += new System.Windows.Forms.MouseEventHandler(this.kryptonHeaderGroup1_MouseUp);
            // 
            // buttonSpecHeaderGroup1
            // 
            this.buttonSpecHeaderGroup1.ToolTipTitle = "隐藏工具栏Ctrl+~";
            this.buttonSpecHeaderGroup1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Context;
            this.buttonSpecHeaderGroup1.UniqueName = "CA955FFE018245EADEB4115DE40F0799";
            this.buttonSpecHeaderGroup1.Click += new System.EventHandler(this.btnCollapsed);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnArticleImport);
            this.groupBox3.Controls.Add(this.LinkTask);
            this.groupBox3.Controls.Add(this.LinkSite);
            this.groupBox3.Controls.Add(this.btnModuleSet);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(117, 100);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "任务编辑";
            // 
            // btnArticleImport
            // 
            this.btnArticleImport.Location = new System.Drawing.Point(72, 20);
            this.btnArticleImport.Name = "btnArticleImport";
            this.btnArticleImport.Size = new System.Drawing.Size(35, 20);
            this.btnArticleImport.TabIndex = 1;
            this.btnArticleImport.Values.Text = "导入";
            this.btnArticleImport.LinkClicked += new System.EventHandler(this.btnArticleImport_LinkClicked);
            // 
            // LinkTask
            // 
            this.LinkTask.Location = new System.Drawing.Point(6, 20);
            this.LinkTask.Name = "LinkTask";
            this.LinkTask.Size = new System.Drawing.Size(60, 20);
            this.LinkTask.TabIndex = 1;
            this.LinkTask.Values.Text = "任务编辑";
            this.LinkTask.LinkClicked += new System.EventHandler(this.LinkTask_LinkClicked);
            // 
            // LinkSite
            // 
            this.LinkSite.Location = new System.Drawing.Point(6, 46);
            this.LinkSite.Name = "LinkSite";
            this.LinkSite.Size = new System.Drawing.Size(60, 20);
            this.LinkSite.TabIndex = 1;
            this.LinkSite.Values.Text = "站点编辑";
            this.LinkSite.LinkClicked += new System.EventHandler(this.LinkSite_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kryptonLinkLabel3);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 70);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "浏览器操作";
            // 
            // kryptonLinkLabel3
            // 
            this.kryptonLinkLabel3.Location = new System.Drawing.Point(6, 20);
            this.kryptonLinkLabel3.Name = "kryptonLinkLabel3";
            this.kryptonLinkLabel3.Size = new System.Drawing.Size(93, 20);
            this.kryptonLinkLabel3.TabIndex = 1;
            this.kryptonLinkLabel3.Values.Text = "刷新当前页(F5)";
            this.kryptonLinkLabel3.LinkClicked += new System.EventHandler(this.btnRefresh_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(6, 46);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.Values.Text = "关闭当前页(Ctrl+W)";
            this.btnClose.LinkClicked += new System.EventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kryptonLinkLabel2);
            this.groupBox1.Controls.Add(this.kryptonLinkLabel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发布动作";
            // 
            // X_Form_WebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 484);
            this.Controls.Add(this.groupTools);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "X_Form_WebBrowser";
            this.Text = "努力加载ing";
            this.Load += new System.EventHandler(this.X_Form_WebBrowser_Load);
            this.groupTools.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupTools)).EndInit();
            this.groupTools.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel btnModuleSet;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup groupTools;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel LinkSite;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel LinkTask;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel btnArticleImport;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;

        private void BrowserPreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.Control == true && e.KeyCode == Keys.Oemtilde) {
                btnCollapsed(sender, e);
            }

            if (e.Control == true && e.KeyCode == Keys.D1) {
                LoadAutoInput(this.site.WebLogin, false);
            }
            if (e.Control == true && e.KeyCode == Keys.D2) {
                LoadAutoInput(this.site.WebPut, true);
            }
            if (e.Control == true && e.KeyCode == Keys.W) {
                this.Close();
            }
            if (e.KeyCode == Keys.F5) {
                browser.Reload();
            }
        }

        public WebKit.WebKitBrowser browser;

    }
}