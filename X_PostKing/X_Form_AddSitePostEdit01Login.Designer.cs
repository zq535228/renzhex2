namespace X_PostKing {
    partial class X_Form_AddSitePostEdit01Login {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_AddSitePostEdit01Login));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TS_保存 = new System.Windows.Forms.ToolStripButton();
            this.TS_取消 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Rich_Fail = new System.Windows.Forms.RichTextBox();
            this.Rich_Succeed = new System.Windows.Forms.RichTextBox();
            this.GBox模拟 = new System.Windows.Forms.GroupBox();
            this.Text_LoginUrl = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Text_LoginParameters = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.Text_VerifyUrl = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCookies = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Text_Referer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Check_NeedVerify = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.Btn_LoginParameters = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GBox马甲 = new System.Windows.Forms.GroupBox();
            this.Text_MVerifyUrl = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.Check_UTF = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.Btn_TestLogin = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Rich_Html = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Web_Browser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GBox模拟.SuspendLayout();
            this.GBox马甲.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Size = new System.Drawing.Size(729, 50);
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
            this.toolStrip1.Size = new System.Drawing.Size(729, 39);
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 436);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.GBox模拟);
            this.tabPage1.Controls.Add(this.GBox马甲);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(721, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "登录参数设定";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Rich_Fail);
            this.groupBox2.Controls.Add(this.Rich_Succeed);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 279);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(715, 107);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "识别参数(左边是成功标记，右边是失败标记)";
            // 
            // Rich_Fail
            // 
            this.Rich_Fail.Location = new System.Drawing.Point(360, 17);
            this.Rich_Fail.Name = "Rich_Fail";
            this.Rich_Fail.Size = new System.Drawing.Size(342, 84);
            this.Rich_Fail.TabIndex = 0;
            this.Rich_Fail.Text = "";
            // 
            // Rich_Succeed
            // 
            this.Rich_Succeed.Location = new System.Drawing.Point(12, 17);
            this.Rich_Succeed.Name = "Rich_Succeed";
            this.Rich_Succeed.Size = new System.Drawing.Size(342, 84);
            this.Rich_Succeed.TabIndex = 0;
            this.Rich_Succeed.Text = "";
            // 
            // GBox模拟
            // 
            this.GBox模拟.Controls.Add(this.Text_LoginUrl);
            this.GBox模拟.Controls.Add(this.Text_LoginParameters);
            this.GBox模拟.Controls.Add(this.Text_VerifyUrl);
            this.GBox模拟.Controls.Add(this.label6);
            this.GBox模拟.Controls.Add(this.label5);
            this.GBox模拟.Controls.Add(this.txtCookies);
            this.GBox模拟.Controls.Add(this.Text_Referer);
            this.GBox模拟.Controls.Add(this.Check_NeedVerify);
            this.GBox模拟.Controls.Add(this.Btn_LoginParameters);
            this.GBox模拟.Controls.Add(this.label4);
            this.GBox模拟.Controls.Add(this.label3);
            this.GBox模拟.Controls.Add(this.label2);
            this.GBox模拟.Dock = System.Windows.Forms.DockStyle.Top;
            this.GBox模拟.Location = new System.Drawing.Point(3, 102);
            this.GBox模拟.Name = "GBox模拟";
            this.GBox模拟.Size = new System.Drawing.Size(715, 177);
            this.GBox模拟.TabIndex = 13;
            this.GBox模拟.TabStop = false;
            this.GBox模拟.Text = "模拟发布参数设定";
            // 
            // Text_LoginUrl
            // 
            this.Text_LoginUrl.Location = new System.Drawing.Point(127, 15);
            this.Text_LoginUrl.Name = "Text_LoginUrl";
            this.Text_LoginUrl.Size = new System.Drawing.Size(460, 20);
            this.Text_LoginUrl.TabIndex = 37;
            // 
            // Text_LoginParameters
            // 
            this.Text_LoginParameters.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.Text_LoginParameters.Location = new System.Drawing.Point(127, 41);
            this.Text_LoginParameters.Multiline = true;
            this.Text_LoginParameters.Name = "Text_LoginParameters";
            this.Text_LoginParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Text_LoginParameters.Size = new System.Drawing.Size(460, 43);
            this.Text_LoginParameters.TabIndex = 36;
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowRight;
            this.buttonSpecAny1.UniqueName = "BBAD346CA6C844A4F596A26C03757512";
            this.buttonSpecAny1.Click += new System.EventHandler(this.buttonSpecAny1_Click);
            // 
            // Text_VerifyUrl
            // 
            this.Text_VerifyUrl.Location = new System.Drawing.Point(127, 90);
            this.Text_VerifyUrl.Name = "Text_VerifyUrl";
            this.Text_VerifyUrl.Size = new System.Drawing.Size(460, 20);
            this.Text_VerifyUrl.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "Cookies赋值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "来路地址：";
            // 
            // txtCookies
            // 
            this.txtCookies.Location = new System.Drawing.Point(128, 142);
            this.txtCookies.Name = "txtCookies";
            this.txtCookies.Size = new System.Drawing.Size(460, 20);
            this.txtCookies.TabIndex = 33;
            // 
            // Text_Referer
            // 
            this.Text_Referer.Location = new System.Drawing.Point(127, 116);
            this.Text_Referer.Name = "Text_Referer";
            this.Text_Referer.Size = new System.Drawing.Size(460, 20);
            this.Text_Referer.TabIndex = 33;
            // 
            // Check_NeedVerify
            // 
            this.Check_NeedVerify.Location = new System.Drawing.Point(594, 54);
            this.Check_NeedVerify.Name = "Check_NeedVerify";
            this.Check_NeedVerify.TabIndex = 32;
            this.Check_NeedVerify.Values.Text = "需要验证码";
            this.Check_NeedVerify.CheckedChanged += new System.EventHandler(this.Check_NeedVerify_CheckedChanged);
            // 
            // Btn_LoginParameters
            // 
            this.Btn_LoginParameters.Location = new System.Drawing.Point(594, 15);
            this.Btn_LoginParameters.Name = "Btn_LoginParameters";
            this.Btn_LoginParameters.TabIndex = 31;
            this.Btn_LoginParameters.Values.Text = "提取登陆参数";
            this.Btn_LoginParameters.Click += new System.EventHandler(this.Btn_LoginParameters_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "验证码地址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "登陆参数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "登陆地址：";
            // 
            // GBox马甲
            // 
            this.GBox马甲.Controls.Add(this.Text_MVerifyUrl);
            this.GBox马甲.Controls.Add(this.label1);
            this.GBox马甲.Dock = System.Windows.Forms.DockStyle.Top;
            this.GBox马甲.Location = new System.Drawing.Point(3, 48);
            this.GBox马甲.Name = "GBox马甲";
            this.GBox马甲.Size = new System.Drawing.Size(715, 54);
            this.GBox马甲.TabIndex = 12;
            this.GBox马甲.TabStop = false;
            this.GBox马甲.Text = "马甲登录模式";
            // 
            // Text_MVerifyUrl
            // 
            this.Text_MVerifyUrl.Location = new System.Drawing.Point(127, 25);
            this.Text_MVerifyUrl.Name = "Text_MVerifyUrl";
            this.Text_MVerifyUrl.Size = new System.Drawing.Size(460, 20);
            this.Text_MVerifyUrl.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "马甲验证地址：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.linkLabel8);
            this.groupBox4.Controls.Add(this.Check_UTF);
            this.groupBox4.Controls.Add(this.Btn_TestLogin);
            this.groupBox4.Controls.Add(this.linkLabel7);
            this.groupBox4.Controls.Add(this.linkLabel5);
            this.groupBox4.Controls.Add(this.linkLabel4);
            this.groupBox4.Controls.Add(this.linkLabel6);
            this.groupBox4.Controls.Add(this.linkLabel3);
            this.groupBox4.Controls.Add(this.linkLabel2);
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(715, 45);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "辅助工具";
            // 
            // linkLabel8
            // 
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.Location = new System.Drawing.Point(370, 17);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(59, 12);
            this.linkLabel8.TabIndex = 30;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Tag = "[用户名@]";
            this.linkLabel8.Text = "[用户名@]";
            this.linkLabel8.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // Check_UTF
            // 
            this.Check_UTF.Location = new System.Drawing.Point(498, 14);
            this.Check_UTF.Name = "Check_UTF";
            this.Check_UTF.TabIndex = 29;
            this.Check_UTF.Values.Text = "UTF-8编码";
            // 
            // Btn_TestLogin
            // 
            this.Btn_TestLogin.Location = new System.Drawing.Point(594, 14);
            this.Btn_TestLogin.Name = "Btn_TestLogin";
            this.Btn_TestLogin.TabIndex = 28;
            this.Btn_TestLogin.Values.Text = "测试登陆";
            this.Btn_TestLogin.Click += new System.EventHandler(this.Btn_TestLogin_Click);
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Location = new System.Drawing.Point(433, 17);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(41, 12);
            this.linkLabel7.TabIndex = 27;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Tag = "[后台地址]";
            this.linkLabel7.Text = "<汉字>";
            this.linkLabel7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(301, 17);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(65, 12);
            this.linkLabel5.TabIndex = 24;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Tag = "{这里输入正则代码}";
            this.linkLabel5.Text = "{正则代码}";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(244, 17);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(53, 12);
            this.linkLabel4.TabIndex = 25;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Tag = "[验证码]";
            this.linkLabel4.Text = "[验证码]";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Location = new System.Drawing.Point(181, 17);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(59, 12);
            this.linkLabel6.TabIndex = 21;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Tag = "[密码MD5]";
            this.linkLabel6.Text = "[密码MD5]";
            this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(136, 17);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(41, 12);
            this.linkLabel3.TabIndex = 21;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Tag = "[密码]";
            this.linkLabel3.Text = "[密码]";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(79, 17);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(53, 12);
            this.linkLabel2.TabIndex = 22;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Tag = "[用户名]";
            this.linkLabel2.Text = "[用户名]";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(10, 17);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 12);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "[后台地址]";
            this.linkLabel1.Text = "[后台地址]";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Rich_Html);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(721, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "返回HTML";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Rich_Html
            // 
            this.Rich_Html.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rich_Html.Location = new System.Drawing.Point(3, 3);
            this.Rich_Html.Name = "Rich_Html";
            this.Rich_Html.Size = new System.Drawing.Size(715, 354);
            this.Rich_Html.TabIndex = 2;
            this.Rich_Html.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Web_Browser);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(721, 410);
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
            this.Web_Browser.Size = new System.Drawing.Size(721, 360);
            this.Web_Browser.TabIndex = 1;
            // 
            // X_Form_AddSitePostEdit01Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 550);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "X_Form_AddSitePostEdit01Login";
            this.Text = "站点设定";
            this.Load += new System.EventHandler(this.X_Form_AddSitePostEdit01Login_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.GBox模拟.ResumeLayout(false);
            this.GBox模拟.PerformLayout();
            this.GBox马甲.ResumeLayout(false);
            this.GBox马甲.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.RichTextBox Rich_Html;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.WebBrowser Web_Browser;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox GBox马甲;
        private System.Windows.Forms.GroupBox GBox模拟;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox Rich_Fail;
        private System.Windows.Forms.RichTextBox Rich_Succeed;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_TestLogin;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_LoginParameters;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton Check_UTF;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton Check_NeedVerify;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Text_Referer;
        private System.Windows.Forms.Label label5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Text_VerifyUrl;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Text_LoginUrl;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Text_LoginParameters;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Text_MVerifyUrl;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private System.Windows.Forms.LinkLabel linkLabel8;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.Label label6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCookies;






    }
}