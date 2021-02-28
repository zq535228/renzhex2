namespace X_PostKing {
    partial class X_Form_AddSitePostEdit03Put {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_AddSitePostEdit03Put));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.TS_保存 = new System.Windows.Forms.ToolStripButton();
            this.TS_取消 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Rich_Fail = new System.Windows.Forms.RichTextBox();
            this.Rich_Succeed = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel16 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.Text_Referer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Text_PostParameters = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.Text_PostUrl = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Btn_TestPost = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_提取发布参数 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Check_Utf = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.Check_IsMutilPost = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.Check_IsPostOnGzip = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.txtperWait = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel15 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel14 = new System.Windows.Forms.LinkLabel();
            this.linkLabel13 = new System.Windows.Forms.LinkLabel();
            this.linkLabel12 = new System.Windows.Forms.LinkLabel();
            this.linkLabel11 = new System.Windows.Forms.LinkLabel();
            this.linkLabel10 = new System.Windows.Forms.LinkLabel();
            this.linkLabel9 = new System.Windows.Forms.LinkLabel();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Rich_Html = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
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
            this.pictureBox1.Size = new System.Drawing.Size(729, 50);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 50);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(729, 39);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(67, 36);
            this.toolStripButton2.Text = "保存";
            this.toolStripButton2.Click += new System.EventHandler(this.TS_保存_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(67, 36);
            this.toolStripButton3.Text = "取消";
            this.toolStripButton3.Click += new System.EventHandler(this.TS_取消_Click);
            // 
            // TS_保存
            // 
            this.TS_保存.Image = ((System.Drawing.Image)(resources.GetObject("TS_保存.Image")));
            this.TS_保存.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_保存.Name = "TS_保存";
            this.TS_保存.Size = new System.Drawing.Size(65, 36);
            this.TS_保存.Text = "保存";
            this.TS_保存.Click += new System.EventHandler(this.TS_保存_Click);
            // 
            // TS_取消
            // 
            this.TS_取消.Image = ((System.Drawing.Image)(resources.GetObject("TS_取消.Image")));
            this.TS_取消.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_取消.Name = "TS_取消";
            this.TS_取消.Size = new System.Drawing.Size(65, 36);
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
            this.tabControl1.Size = new System.Drawing.Size(729, 390);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(721, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发布参数设定";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Rich_Fail);
            this.groupBox2.Controls.Add(this.Rich_Succeed);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(715, 113);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "识别参数(左边是成功标记，右边是失败标记)";
            // 
            // Rich_Fail
            // 
            this.Rich_Fail.Location = new System.Drawing.Point(367, 17);
            this.Rich_Fail.Name = "Rich_Fail";
            this.Rich_Fail.Size = new System.Drawing.Size(342, 84);
            this.Rich_Fail.TabIndex = 0;
            this.Rich_Fail.Text = "";
            // 
            // Rich_Succeed
            // 
            this.Rich_Succeed.Location = new System.Drawing.Point(8, 17);
            this.Rich_Succeed.Name = "Rich_Succeed";
            this.Rich_Succeed.Size = new System.Drawing.Size(353, 84);
            this.Rich_Succeed.TabIndex = 0;
            this.Rich_Succeed.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.linkLabel16);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Text_Referer);
            this.groupBox1.Controls.Add(this.Text_PostParameters);
            this.groupBox1.Controls.Add(this.Text_PostUrl);
            this.groupBox1.Controls.Add(this.Btn_TestPost);
            this.groupBox1.Controls.Add(this.Btn_提取发布参数);
            this.groupBox1.Controls.Add(this.Check_Utf);
            this.groupBox1.Controls.Add(this.Check_IsMutilPost);
            this.groupBox1.Controls.Add(this.Check_IsPostOnGzip);
            this.groupBox1.Controls.Add(this.txtperWait);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.linkLabel15);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.linkLabel14);
            this.groupBox1.Controls.Add(this.linkLabel13);
            this.groupBox1.Controls.Add(this.linkLabel12);
            this.groupBox1.Controls.Add(this.linkLabel11);
            this.groupBox1.Controls.Add(this.linkLabel10);
            this.groupBox1.Controls.Add(this.linkLabel9);
            this.groupBox1.Controls.Add(this.linkLabel8);
            this.groupBox1.Controls.Add(this.linkLabel7);
            this.groupBox1.Controls.Add(this.linkLabel6);
            this.groupBox1.Controls.Add(this.linkLabel4);
            this.groupBox1.Controls.Add(this.linkLabel3);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息设定";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(591, 191);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(41, 12);
            this.linkLabel2.TabIndex = 51;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Tag = "[摘要]";
            this.linkLabel2.Text = "[摘要]";
            // 
            // linkLabel16
            // 
            this.linkLabel16.AutoSize = true;
            this.linkLabel16.Location = new System.Drawing.Point(532, 191);
            this.linkLabel16.Name = "linkLabel16";
            this.linkLabel16.Size = new System.Drawing.Size(53, 12);
            this.linkLabel16.TabIndex = 50;
            this.linkLabel16.TabStop = true;
            this.linkLabel16.Tag = "[随机数]";
            this.linkLabel16.Text = "[随机数]";
            this.linkLabel16.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "毫秒";
            // 
            // Text_Referer
            // 
            this.Text_Referer.Location = new System.Drawing.Point(109, 125);
            this.Text_Referer.Name = "Text_Referer";
            this.Text_Referer.Size = new System.Drawing.Size(458, 20);
            this.Text_Referer.TabIndex = 48;
            // 
            // Text_PostParameters
            // 
            this.Text_PostParameters.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.Text_PostParameters.Location = new System.Drawing.Point(109, 50);
            this.Text_PostParameters.Multiline = true;
            this.Text_PostParameters.Name = "Text_PostParameters";
            this.Text_PostParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Text_PostParameters.Size = new System.Drawing.Size(458, 69);
            this.Text_PostParameters.TabIndex = 47;
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowRight;
            this.buttonSpecAny1.UniqueName = "F469DFE33C7A4DA196A8C84A093E94E9";
            this.buttonSpecAny1.Click += new System.EventHandler(this.buttonSpecAny1_Click);
            // 
            // Text_PostUrl
            // 
            this.Text_PostUrl.Location = new System.Drawing.Point(109, 20);
            this.Text_PostUrl.Name = "Text_PostUrl";
            this.Text_PostUrl.Size = new System.Drawing.Size(458, 20);
            this.Text_PostUrl.TabIndex = 46;
            // 
            // Btn_TestPost
            // 
            this.Btn_TestPost.Location = new System.Drawing.Point(587, 51);
            this.Btn_TestPost.Name = "Btn_TestPost";
            this.Btn_TestPost.TabIndex = 45;
            this.Btn_TestPost.Values.Text = "测试发布";
            this.Btn_TestPost.Click += new System.EventHandler(this.Btn_TestPost_Click);
            // 
            // Btn_提取发布参数
            // 
            this.Btn_提取发布参数.Location = new System.Drawing.Point(587, 20);
            this.Btn_提取发布参数.Name = "Btn_提取发布参数";
            this.Btn_提取发布参数.TabIndex = 44;
            this.Btn_提取发布参数.Values.Text = "提取参数";
            this.Btn_提取发布参数.Click += new System.EventHandler(this.Btn_提取发布参数_Click);
            // 
            // Check_Utf
            // 
            this.Check_Utf.Location = new System.Drawing.Point(477, 153);
            this.Check_Utf.Name = "Check_Utf";
            this.Check_Utf.TabIndex = 43;
            this.Check_Utf.Values.Text = "开启UTF8编码";
            // 
            // Check_IsMutilPost
            // 
            this.Check_IsMutilPost.Location = new System.Drawing.Point(381, 153);
            this.Check_IsMutilPost.Name = "Check_IsMutilPost";
            this.Check_IsMutilPost.TabIndex = 42;
            this.Check_IsMutilPost.Values.Text = "开启Mutil发布";
            // 
            // Check_IsPostOnGzip
            // 
            this.Check_IsPostOnGzip.Location = new System.Drawing.Point(283, 153);
            this.Check_IsPostOnGzip.Name = "Check_IsPostOnGzip";
            this.Check_IsPostOnGzip.TabIndex = 41;
            this.Check_IsPostOnGzip.Values.Text = "压缩数据";
            // 
            // txtperWait
            // 
            this.txtperWait.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtperWait.Location = new System.Drawing.Point(109, 153);
            this.txtperWait.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.txtperWait.Name = "txtperWait";
            this.txtperWait.ReadOnly = true;
            this.txtperWait.Size = new System.Drawing.Size(86, 22);
            this.txtperWait.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "发布间隔：";
            // 
            // linkLabel15
            // 
            this.linkLabel15.AutoSize = true;
            this.linkLabel15.Location = new System.Drawing.Point(491, 191);
            this.linkLabel15.Name = "linkLabel15";
            this.linkLabel15.Size = new System.Drawing.Size(35, 12);
            this.linkLabel15.TabIndex = 38;
            this.linkLabel15.TabStop = true;
            this.linkLabel15.Tag = "(.*?)";
            this.linkLabel15.Text = "(.*?)";
            this.linkLabel15.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 37;
            this.label5.Text = "可用变量：";
            // 
            // linkLabel14
            // 
            this.linkLabel14.AutoSize = true;
            this.linkLabel14.Location = new System.Drawing.Point(278, 191);
            this.linkLabel14.Name = "linkLabel14";
            this.linkLabel14.Size = new System.Drawing.Size(65, 12);
            this.linkLabel14.TabIndex = 36;
            this.linkLabel14.TabStop = true;
            this.linkLabel14.Tag = "{这里输入正则代码}";
            this.linkLabel14.Text = "<中文内容>";
            this.linkLabel14.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel13
            // 
            this.linkLabel13.AutoSize = true;
            this.linkLabel13.Location = new System.Drawing.Point(420, 191);
            this.linkLabel13.Name = "linkLabel13";
            this.linkLabel13.Size = new System.Drawing.Size(65, 12);
            this.linkLabel13.TabIndex = 32;
            this.linkLabel13.TabStop = true;
            this.linkLabel13.Tag = "{这里输入正则代码}";
            this.linkLabel13.Text = "{正则代码}";
            this.linkLabel13.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel12
            // 
            this.linkLabel12.AutoSize = true;
            this.linkLabel12.Location = new System.Drawing.Point(426, 214);
            this.linkLabel12.Name = "linkLabel12";
            this.linkLabel12.Size = new System.Drawing.Size(239, 12);
            this.linkLabel12.TabIndex = 27;
            this.linkLabel12.TabStop = true;
            this.linkLabel12.Tag = "[年]-[月]-[日] [时]:[分]:[秒]";
            this.linkLabel12.Text = "发布时间：[年]-[月]-[日] [时]:[分]:[秒]";
            this.linkLabel12.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel11
            // 
            this.linkLabel11.AutoSize = true;
            this.linkLabel11.Location = new System.Drawing.Point(379, 214);
            this.linkLabel11.Name = "linkLabel11";
            this.linkLabel11.Size = new System.Drawing.Size(41, 12);
            this.linkLabel11.TabIndex = 26;
            this.linkLabel11.TabStop = true;
            this.linkLabel11.Tag = "[作者]";
            this.linkLabel11.Text = "[作者]";
            this.linkLabel11.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel10
            // 
            this.linkLabel10.AutoSize = true;
            this.linkLabel10.Location = new System.Drawing.Point(349, 191);
            this.linkLabel10.Name = "linkLabel10";
            this.linkLabel10.Size = new System.Drawing.Size(65, 12);
            this.linkLabel10.TabIndex = 31;
            this.linkLabel10.TabStop = true;
            this.linkLabel10.Tag = "[分类编号]";
            this.linkLabel10.Text = "[分类编号]";
            this.linkLabel10.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel9
            // 
            this.linkLabel9.AutoSize = true;
            this.linkLabel9.Location = new System.Drawing.Point(332, 214);
            this.linkLabel9.Name = "linkLabel9";
            this.linkLabel9.Size = new System.Drawing.Size(41, 12);
            this.linkLabel9.TabIndex = 30;
            this.linkLabel9.TabStop = true;
            this.linkLabel9.Tag = "[来源]";
            this.linkLabel9.Text = "[来源]";
            this.linkLabel9.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel8
            // 
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.Location = new System.Drawing.Point(261, 214);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(65, 12);
            this.linkLabel8.TabIndex = 29;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Tag = "[后台地址]";
            this.linkLabel8.Text = "[后台地址]";
            this.linkLabel8.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Location = new System.Drawing.Point(178, 214);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(77, 12);
            this.linkLabel7.TabIndex = 28;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Tag = "[随机关键字]";
            this.linkLabel7.Text = "[随机关键字]";
            this.linkLabel7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Location = new System.Drawing.Point(107, 214);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(65, 12);
            this.linkLabel6.TabIndex = 21;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Tag = "[主关键字]";
            this.linkLabel6.Text = "[主关键字]";
            this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(201, 191);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(71, 12);
            this.linkLabel4.TabIndex = 25;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Tag = "[正文(UBB)]";
            this.linkLabel4.Text = "[正文(UBB)]";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(154, 191);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(41, 12);
            this.linkLabel3.TabIndex = 24;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Tag = "[正文]";
            this.linkLabel3.Text = "[正文]";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(107, 191);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(41, 12);
            this.linkLabel1.TabIndex = 22;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "[标题]";
            this.linkLabel1.Text = "[标题]";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "发布来路：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "发布参数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "发布地址：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Rich_Html);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(721, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "返回HTML";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Rich_Html
            // 
            this.Rich_Html.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rich_Html.Location = new System.Drawing.Point(3, 3);
            this.Rich_Html.Name = "Rich_Html";
            this.Rich_Html.Size = new System.Drawing.Size(715, 358);
            this.Rich_Html.TabIndex = 3;
            this.Rich_Html.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.webBrowser1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(721, 364);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "WEB预览";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(721, 364);
            this.webBrowser1.TabIndex = 1;
            // 
            // X_Form_AddSitePostEdit03Put
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 482);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "X_Form_AddSitePostEdit03Put";
            this.Text = "站点设定";
            this.Load += new System.EventHandler(this.X_Form_AddSitePostEdit03Put_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox Rich_Fail;
        private System.Windows.Forms.RichTextBox Rich_Succeed;
        private System.Windows.Forms.LinkLabel linkLabel13;
        private System.Windows.Forms.LinkLabel linkLabel12;
        private System.Windows.Forms.LinkLabel linkLabel11;
        private System.Windows.Forms.LinkLabel linkLabel10;
        private System.Windows.Forms.LinkLabel linkLabel9;
        private System.Windows.Forms.LinkLabel linkLabel8;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.LinkLabel linkLabel15;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtperWait;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton Check_Utf;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton Check_IsMutilPost;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton Check_IsPostOnGzip;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_提取发布参数;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_TestPost;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Text_PostUrl;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Text_PostParameters;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Text_Referer;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox Rich_Html;
        private System.Windows.Forms.Label label6;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private System.Windows.Forms.LinkLabel linkLabel16;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}