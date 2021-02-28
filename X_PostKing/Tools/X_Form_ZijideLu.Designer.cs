namespace X_PostKing.Tools {
    partial class X_Form_ZijideLu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDownPath = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtFtpPWD = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.x_Lable5 = new X_Service.Util.X_Lable();
            this.x_Lable4 = new X_Service.Util.X_Lable();
            this.x_Lable2 = new X_Service.Util.X_Lable();
            this.x_Lable1 = new X_Service.Util.X_Lable();
            this.txtDomainString = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnQuickAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox_login = new System.Windows.Forms.GroupBox();
            this.txtIP = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtPwd2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtPwd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUname = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.x_Lable9 = new X_Service.Util.X_Lable();
            this.x_Lable8 = new X_Service.Util.X_Lable();
            this.x_Lable7 = new X_Service.Util.X_Lable();
            this.x_Lable6 = new X_Service.Util.X_Lable();
            this.x_Lable3 = new X_Service.Util.X_Lable();
            this.btnLogin = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDownPath)).BeginInit();
            this.groupBox_login.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.X_Form_zijidelu;
            this.pictureBox1.Size = new System.Drawing.Size(980, 50);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 388);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox_login);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(972, 362);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "批量建站+批量安装CMS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDownPath);
            this.groupBox2.Controls.Add(this.txtFtpPWD);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.x_Lable5);
            this.groupBox2.Controls.Add(this.x_Lable4);
            this.groupBox2.Controls.Add(this.x_Lable2);
            this.groupBox2.Controls.Add(this.x_Lable1);
            this.groupBox2.Controls.Add(this.txtDomainString);
            this.groupBox2.Controls.Add(this.btnQuickAdd);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(3, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(966, 297);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "批量上站，请输入一行一个：根域名|关键词，最多10行。";
            // 
            // txtDownPath
            // 
            this.txtDownPath.DropDownWidth = 146;
            this.txtDownPath.Items.AddRange(new object[] {
            "http://www.meicuo.net/wp332.zip",
            "http://emlog.renzhe.org/emlog.zip",
            "http://dede.renzhe.org/dede.zip"});
            this.txtDownPath.Location = new System.Drawing.Point(268, 270);
            this.txtDownPath.Name = "txtDownPath";
            this.txtDownPath.Size = new System.Drawing.Size(389, 21);
            this.txtDownPath.TabIndex = 5;
            // 
            // txtFtpPWD
            // 
            this.txtFtpPWD.AlwaysActive = false;
            this.txtFtpPWD.Location = new System.Drawing.Point(78, 270);
            this.txtFtpPWD.Name = "txtFtpPWD";
            this.txtFtpPWD.PasswordChar = '*';
            this.txtFtpPWD.Size = new System.Drawing.Size(87, 20);
            this.txtFtpPWD.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "安装包：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "统一密码：";
            // 
            // x_Lable5
            // 
            this.x_Lable5.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable5.Location = new System.Drawing.Point(663, 272);
            this.x_Lable5.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable5.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable5.Name = "x_Lable5";
            this.x_Lable5.ShowControl = null;
            this.x_Lable5.ShowText = "";
            this.x_Lable5.ShowTitle = "";
            this.x_Lable5.Size = new System.Drawing.Size(22, 17);
            this.x_Lable5.TabIndex = 4;
            // 
            // x_Lable4
            // 
            this.x_Lable4.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable4.Location = new System.Drawing.Point(938, 272);
            this.x_Lable4.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable4.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable4.Name = "x_Lable4";
            this.x_Lable4.ShowControl = null;
            this.x_Lable4.ShowText = "";
            this.x_Lable4.ShowTitle = "";
            this.x_Lable4.Size = new System.Drawing.Size(22, 17);
            this.x_Lable4.TabIndex = 4;
            // 
            // x_Lable2
            // 
            this.x_Lable2.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable2.Location = new System.Drawing.Point(171, 272);
            this.x_Lable2.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable2.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable2.Name = "x_Lable2";
            this.x_Lable2.ShowControl = null;
            this.x_Lable2.ShowText = "";
            this.x_Lable2.ShowTitle = "";
            this.x_Lable2.Size = new System.Drawing.Size(22, 17);
            this.x_Lable2.TabIndex = 4;
            // 
            // x_Lable1
            // 
            this.x_Lable1.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable1.Location = new System.Drawing.Point(938, 20);
            this.x_Lable1.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable1.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.Name = "x_Lable1";
            this.x_Lable1.ShowControl = null;
            this.x_Lable1.ShowText = "";
            this.x_Lable1.ShowTitle = "";
            this.x_Lable1.Size = new System.Drawing.Size(22, 17);
            this.x_Lable1.TabIndex = 4;
            // 
            // txtDomainString
            // 
            this.txtDomainString.AlwaysActive = false;
            this.txtDomainString.Location = new System.Drawing.Point(6, 20);
            this.txtDomainString.Multiline = true;
            this.txtDomainString.Name = "txtDomainString";
            this.txtDomainString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDomainString.Size = new System.Drawing.Size(926, 242);
            this.txtDomainString.TabIndex = 0;
            // 
            // btnQuickAdd
            // 
            this.btnQuickAdd.Location = new System.Drawing.Point(823, 268);
            this.btnQuickAdd.Name = "btnQuickAdd";
            this.btnQuickAdd.Size = new System.Drawing.Size(109, 25);
            this.btnQuickAdd.TabIndex = 2;
            this.btnQuickAdd.Values.Text = "一键批量上站";
            this.btnQuickAdd.Click += new System.EventHandler(this.btnQuickAdd_Click);
            // 
            // groupBox_login
            // 
            this.groupBox_login.Controls.Add(this.txtIP);
            this.groupBox_login.Controls.Add(this.txtPwd2);
            this.groupBox_login.Controls.Add(this.txtPwd);
            this.groupBox_login.Controls.Add(this.txtUname);
            this.groupBox_login.Controls.Add(this.label4);
            this.groupBox_login.Controls.Add(this.label6);
            this.groupBox_login.Controls.Add(this.label5);
            this.groupBox_login.Controls.Add(this.label3);
            this.groupBox_login.Controls.Add(this.x_Lable9);
            this.groupBox_login.Controls.Add(this.x_Lable8);
            this.groupBox_login.Controls.Add(this.x_Lable7);
            this.groupBox_login.Controls.Add(this.x_Lable6);
            this.groupBox_login.Controls.Add(this.x_Lable3);
            this.groupBox_login.Controls.Add(this.btnLogin);
            this.groupBox_login.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_login.Location = new System.Drawing.Point(3, 3);
            this.groupBox_login.Name = "groupBox_login";
            this.groupBox_login.Size = new System.Drawing.Size(966, 56);
            this.groupBox_login.TabIndex = 0;
            this.groupBox_login.TabStop = false;
            this.groupBox_login.Text = "登录服务器";
            // 
            // txtIP
            // 
            this.txtIP.AlwaysActive = false;
            this.txtIP.Location = new System.Drawing.Point(72, 22);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(150, 20);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "请填写服务器IP";
            // 
            // txtPwd2
            // 
            this.txtPwd2.AlwaysActive = false;
            this.txtPwd2.Location = new System.Drawing.Point(679, 22);
            this.txtPwd2.Name = "txtPwd2";
            this.txtPwd2.PasswordChar = '*';
            this.txtPwd2.Size = new System.Drawing.Size(79, 20);
            this.txtPwd2.TabIndex = 3;
            // 
            // txtPwd
            // 
            this.txtPwd.AlwaysActive = false;
            this.txtPwd.Location = new System.Drawing.Point(488, 22);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(79, 20);
            this.txtPwd.TabIndex = 2;
            // 
            // txtUname
            // 
            this.txtUname.AlwaysActive = false;
            this.txtUname.Location = new System.Drawing.Point(310, 22);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(79, 20);
            this.txtUname.TabIndex = 1;
            this.txtUname.Text = "zijidelu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "服务器IP：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(616, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "保护密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "登录密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "用户名：";
            // 
            // x_Lable9
            // 
            this.x_Lable9.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable9.Location = new System.Drawing.Point(764, 24);
            this.x_Lable9.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable9.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable9.Name = "x_Lable9";
            this.x_Lable9.ShowControl = null;
            this.x_Lable9.ShowText = "";
            this.x_Lable9.ShowTitle = "";
            this.x_Lable9.Size = new System.Drawing.Size(22, 17);
            this.x_Lable9.TabIndex = 4;
            // 
            // x_Lable8
            // 
            this.x_Lable8.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable8.Location = new System.Drawing.Point(573, 24);
            this.x_Lable8.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable8.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable8.Name = "x_Lable8";
            this.x_Lable8.ShowControl = null;
            this.x_Lable8.ShowText = "";
            this.x_Lable8.ShowTitle = "";
            this.x_Lable8.Size = new System.Drawing.Size(22, 17);
            this.x_Lable8.TabIndex = 4;
            // 
            // x_Lable7
            // 
            this.x_Lable7.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable7.Location = new System.Drawing.Point(395, 24);
            this.x_Lable7.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable7.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable7.Name = "x_Lable7";
            this.x_Lable7.ShowControl = null;
            this.x_Lable7.ShowText = "";
            this.x_Lable7.ShowTitle = "";
            this.x_Lable7.Size = new System.Drawing.Size(22, 17);
            this.x_Lable7.TabIndex = 4;
            // 
            // x_Lable6
            // 
            this.x_Lable6.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable6.Location = new System.Drawing.Point(228, 24);
            this.x_Lable6.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable6.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable6.Name = "x_Lable6";
            this.x_Lable6.ShowControl = null;
            this.x_Lable6.ShowText = "";
            this.x_Lable6.ShowTitle = "";
            this.x_Lable6.Size = new System.Drawing.Size(22, 17);
            this.x_Lable6.TabIndex = 4;
            // 
            // x_Lable3
            // 
            this.x_Lable3.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable3.Location = new System.Drawing.Point(938, 24);
            this.x_Lable3.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable3.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable3.Name = "x_Lable3";
            this.x_Lable3.ShowControl = null;
            this.x_Lable3.ShowText = "";
            this.x_Lable3.ShowTitle = "";
            this.x_Lable3.Size = new System.Drawing.Size(22, 17);
            this.x_Lable3.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(823, 20);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(109, 25);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Values.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // X_Form_ZijideLu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 463);
            this.Controls.Add(this.tabControl1);
            this.Name = "X_Form_ZijideLu";
            this.Text = "自己的路 批量建站小助手";
            this.Load += new System.EventHandler(this.X_Form_ZijideLu_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDownPath)).EndInit();
            this.groupBox_login.ResumeLayout(false);
            this.groupBox_login.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox_login;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLogin;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtIP;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPwd2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPwd;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUname;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDomainString;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnQuickAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtFtpPWD;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtDownPath;
        private X_Service.Util.X_Lable x_Lable1;
        private X_Service.Util.X_Lable x_Lable4;
        private X_Service.Util.X_Lable x_Lable2;
        private X_Service.Util.X_Lable x_Lable3;
        private X_Service.Util.X_Lable x_Lable5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private X_Service.Util.X_Lable x_Lable9;
        private X_Service.Util.X_Lable x_Lable8;
        private X_Service.Util.X_Lable x_Lable7;
        private X_Service.Util.X_Lable x_Lable6;
    }
}