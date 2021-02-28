namespace X_PostKing {
    partial class X_Form_AddSitePostEdit02Cate {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_AddSitePostEdit02Cate));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TS_保存 = new System.Windows.Forms.ToolStripButton();
            this.TS_取消 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.x_Lable2 = new X_Service.Util.X_Lable();
            this.txtTmpReg01 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lbTmp02 = new System.Windows.Forms.Label();
            this.lbTmp01 = new System.Windows.Forms.Label();
            this.txtTmpReg02 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.List = new System.Windows.Forms.ListView();
            this.分类ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.分类名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Text_Regex = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.Text_Url = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Radio_Enabled = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.Btn_GetCategories = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.x_Lable1 = new X_Service.Util.X_Lable();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Rich_Html = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Web_Browser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.X_Form_Site;
            this.pictureBox1.Size = new System.Drawing.Size(764, 50);
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
            this.toolStrip1.Size = new System.Drawing.Size(764, 39);
            this.toolStrip1.TabIndex = 10;
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(764, 331);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(756, 305);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "分类&变量设定";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.x_Lable2);
            this.groupBox2.Controls.Add(this.lbTmp02);
            this.groupBox2.Controls.Add(this.lbTmp01);
            this.groupBox2.Controls.Add(this.txtTmpReg02);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTmpReg01);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.List);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(750, 180);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "分类列表";
            // 
            // x_Lable2
            // 
            this.x_Lable2.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable2.Location = new System.Drawing.Point(665, 111);
            this.x_Lable2.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable2.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable2.Name = "x_Lable2";
            this.x_Lable2.ShowControl = this.txtTmpReg01;
            this.x_Lable2.ShowText = "支持URL|{(.*?)}的方式匹配正则，如果没有URL，则代表在分类页面中匹配！";
            this.x_Lable2.ShowTitle = "临时值";
            this.x_Lable2.Size = new System.Drawing.Size(22, 17);
            this.x_Lable2.TabIndex = 20;
            // 
            // txtTmpReg01
            // 
            this.txtTmpReg01.Location = new System.Drawing.Point(109, 109);
            this.txtTmpReg01.Name = "txtTmpReg01";
            this.txtTmpReg01.Size = new System.Drawing.Size(479, 20);
            this.txtTmpReg01.TabIndex = 18;
            // 
            // lbTmp02
            // 
            this.lbTmp02.AutoSize = true;
            this.lbTmp02.Location = new System.Drawing.Point(594, 139);
            this.lbTmp02.Name = "lbTmp02";
            this.lbTmp02.Size = new System.Drawing.Size(65, 12);
            this.lbTmp02.TabIndex = 19;
            this.lbTmp02.Text = "[临时值02]";
            // 
            // lbTmp01
            // 
            this.lbTmp01.AutoSize = true;
            this.lbTmp01.Location = new System.Drawing.Point(594, 113);
            this.lbTmp01.Name = "lbTmp01";
            this.lbTmp01.Size = new System.Drawing.Size(65, 12);
            this.lbTmp01.TabIndex = 19;
            this.lbTmp01.Text = "[临时值01]";
            // 
            // txtTmpReg02
            // 
            this.txtTmpReg02.Location = new System.Drawing.Point(109, 135);
            this.txtTmpReg02.Name = "txtTmpReg02";
            this.txtTmpReg02.Size = new System.Drawing.Size(479, 20);
            this.txtTmpReg02.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "临时值02：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "临时值01：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "分类内容：";
            // 
            // List
            // 
            this.List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.分类ID,
            this.分类名称});
            this.List.FullRowSelect = true;
            this.List.Location = new System.Drawing.Point(109, 16);
            this.List.MultiSelect = false;
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(550, 87);
            this.List.TabIndex = 0;
            this.List.UseCompatibleStateImageBehavior = false;
            this.List.View = System.Windows.Forms.View.Details;
            // 
            // 分类ID
            // 
            this.分类ID.Text = "分类ID";
            this.分类ID.Width = 125;
            // 
            // 分类名称
            // 
            this.分类名称.Text = "分类名称";
            this.分类名称.Width = 400;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Text_Regex);
            this.groupBox1.Controls.Add(this.Text_Url);
            this.groupBox1.Controls.Add(this.Radio_Enabled);
            this.groupBox1.Controls.Add(this.Btn_GetCategories);
            this.groupBox1.Controls.Add(this.x_Lable1);
            this.groupBox1.Controls.Add(this.linkLabel3);
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本参数";
            // 
            // Text_Regex
            // 
            this.Text_Regex.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.Text_Regex.Location = new System.Drawing.Point(109, 72);
            this.Text_Regex.Name = "Text_Regex";
            this.Text_Regex.Size = new System.Drawing.Size(442, 20);
            this.Text_Regex.TabIndex = 14;
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowRight;
            this.buttonSpecAny1.UniqueName = "5CFDE89C8069405C66B03B2ECC217815";
            this.buttonSpecAny1.Click += new System.EventHandler(this.Text_Regex_DoubleClick);
            // 
            // Text_Url
            // 
            this.Text_Url.Location = new System.Drawing.Point(108, 46);
            this.Text_Url.Name = "Text_Url";
            this.Text_Url.Size = new System.Drawing.Size(442, 20);
            this.Text_Url.TabIndex = 13;
            // 
            // Radio_Enabled
            // 
            this.Radio_Enabled.Location = new System.Drawing.Point(109, 15);
            this.Radio_Enabled.Name = "Radio_Enabled";
            this.Radio_Enabled.TabIndex = 12;
            this.Radio_Enabled.Values.Text = "启用分类";
            this.Radio_Enabled.CheckedChanged += new System.EventHandler(this.Radio_Enabled_CheckedChanged);
            // 
            // Btn_GetCategories
            // 
            this.Btn_GetCategories.Location = new System.Drawing.Point(569, 44);
            this.Btn_GetCategories.Name = "Btn_GetCategories";
            this.Btn_GetCategories.TabIndex = 11;
            this.Btn_GetCategories.Values.Text = "测试获取分类";
            this.Btn_GetCategories.Click += new System.EventHandler(this.Btn_GetCategories_Click);
            // 
            // x_Lable1
            // 
            this.x_Lable1.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable1.Location = new System.Drawing.Point(205, 20);
            this.x_Lable1.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable1.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.Name = "x_Lable1";
            this.x_Lable1.ShowControl = null;
            this.x_Lable1.ShowText = "某些场合不需要自动填写分类，例如手动填写分类";
            this.x_Lable1.ShowTitle = "是否启用";
            this.x_Lable1.Size = new System.Drawing.Size(22, 17);
            this.x_Lable1.TabIndex = 10;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(261, 21);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(89, 12);
            this.linkLabel3.TabIndex = 9;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Tag = "(?<typeid>.*?)";
            this.linkLabel3.Text = "(?<typeid>.*?)";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegex_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(367, 21);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(101, 12);
            this.linkLabel2.TabIndex = 8;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Tag = "(?<typename>.*?)";
            this.linkLabel2.Text = "(?<typename>.*?)";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegex_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(485, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 12);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "[后台地址]";
            this.linkLabel1.Text = "[后台地址]";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUrl_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "正则代码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "分类地址：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "是否启用：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Rich_Html);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(756, 305);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "返回HTML";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Rich_Html
            // 
            this.Rich_Html.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rich_Html.Location = new System.Drawing.Point(3, 3);
            this.Rich_Html.Name = "Rich_Html";
            this.Rich_Html.Size = new System.Drawing.Size(750, 299);
            this.Rich_Html.TabIndex = 0;
            this.Rich_Html.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Web_Browser);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(756, 305);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "WEB预览";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Web_Browser
            // 
            this.Web_Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Web_Browser.Location = new System.Drawing.Point(0, 0);
            this.Web_Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Web_Browser.Name = "Web_Browser";
            this.Web_Browser.ScriptErrorsSuppressed = true;
            this.Web_Browser.Size = new System.Drawing.Size(756, 305);
            this.Web_Browser.TabIndex = 1;
            // 
            // X_Form_AddSitePostEdit02Cate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 445);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "X_Form_AddSitePostEdit02Cate";
            this.Text = "站点设定";
            this.Load += new System.EventHandler(this.X_Form_AddSitePostEdit02Cate_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TS_保存;
        private System.Windows.Forms.ToolStripButton TS_取消;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView List;
        private System.Windows.Forms.ColumnHeader 分类ID;
        private System.Windows.Forms.ColumnHeader 分类名称;
        private System.Windows.Forms.WebBrowser Web_Browser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox Rich_Html;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private X_Service.Util.X_Lable x_Lable1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_GetCategories;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton Radio_Enabled;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Text_Url;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Text_Regex;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTmpReg01;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTmpReg02;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbTmp02;
        private System.Windows.Forms.Label lbTmp01;
        private X_Service.Util.X_Lable x_Lable2;
    }
}