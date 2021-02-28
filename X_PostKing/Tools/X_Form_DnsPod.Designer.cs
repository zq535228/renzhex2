namespace X_PostKing.Tools {
    partial class X_Form_DnsPod {
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.x_Lable2 = new X_Service.Util.X_Lable();
            this.txtSetIP = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtADomains = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSetA = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNewDomains = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnCreateDomain = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnListNewDomain = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUserEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtPWD = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.x_Lable1 = new X_Service.Util.X_Lable();
            this.btnLoginDNSPOD = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.x_Lable4 = new X_Service.Util.X_Lable();
            this.btnGD = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.x_Lable3 = new X_Service.Util.X_Lable();
            this.btnTaobao = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.x_Lable5 = new X_Service.Util.X_Lable();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.tools;
            this.pictureBox1.Size = new System.Drawing.Size(644, 50);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 302);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(636, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "域名小助手，批量解析、指向IP。";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.x_Lable5);
            this.groupBox3.Controls.Add(this.x_Lable2);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(3, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(630, 150);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3、集中处理DNSPOD";
            // 
            // x_Lable2
            // 
            this.x_Lable2.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable2.Location = new System.Drawing.Point(580, 40);
            this.x_Lable2.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable2.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable2.Name = "x_Lable2";
            this.x_Lable2.ShowControl = this.txtSetIP;
            this.x_Lable2.ShowText = "在批量设定指向的IP之前，你可以批量添加域名，然后列出最近域名，点击批量添加A记录按钮设定。";
            this.x_Lable2.ShowTitle = "最后一步，批量添加域名及A记录";
            this.x_Lable2.Size = new System.Drawing.Size(22, 17);
            this.x_Lable2.TabIndex = 4;
            // 
            // txtSetIP
            // 
            this.txtSetIP.Location = new System.Drawing.Point(6, 95);
            this.txtSetIP.Name = "txtSetIP";
            this.txtSetIP.Size = new System.Drawing.Size(124, 20);
            this.txtSetIP.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtADomains);
            this.groupBox5.Controls.Add(this.btnSetA);
            this.groupBox5.Controls.Add(this.txtSetIP);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(312, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(262, 124);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "域名批量指向IP";
            // 
            // txtADomains
            // 
            this.txtADomains.Location = new System.Drawing.Point(6, 20);
            this.txtADomains.Multiline = true;
            this.txtADomains.Name = "txtADomains";
            this.txtADomains.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtADomains.Size = new System.Drawing.Size(246, 66);
            this.txtADomains.TabIndex = 0;
            // 
            // btnSetA
            // 
            this.btnSetA.Location = new System.Drawing.Point(136, 93);
            this.btnSetA.Name = "btnSetA";
            this.btnSetA.Size = new System.Drawing.Size(116, 25);
            this.btnSetA.TabIndex = 1;
            this.btnSetA.Values.Text = "3、批量添加A记录";
            this.btnSetA.Click += new System.EventHandler(this.btnSetA_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNewDomains);
            this.groupBox4.Controls.Add(this.btnCreateDomain);
            this.groupBox4.Controls.Add(this.btnListNewDomain);
            this.groupBox4.Location = new System.Drawing.Point(20, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(262, 124);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "域名批量添加到DnsPod中";
            // 
            // txtNewDomains
            // 
            this.txtNewDomains.Location = new System.Drawing.Point(6, 20);
            this.txtNewDomains.Multiline = true;
            this.txtNewDomains.Name = "txtNewDomains";
            this.txtNewDomains.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNewDomains.Size = new System.Drawing.Size(246, 66);
            this.txtNewDomains.TabIndex = 0;
            // 
            // btnCreateDomain
            // 
            this.btnCreateDomain.Location = new System.Drawing.Point(6, 92);
            this.btnCreateDomain.Name = "btnCreateDomain";
            this.btnCreateDomain.Size = new System.Drawing.Size(116, 25);
            this.btnCreateDomain.TabIndex = 1;
            this.btnCreateDomain.Values.Text = "1、批量添加域名↑";
            this.btnCreateDomain.Click += new System.EventHandler(this.btnCreateDomain_Click);
            // 
            // btnListNewDomain
            // 
            this.btnListNewDomain.Location = new System.Drawing.Point(128, 92);
            this.btnListNewDomain.Name = "btnListNewDomain";
            this.btnListNewDomain.Size = new System.Drawing.Size(124, 25);
            this.btnListNewDomain.TabIndex = 1;
            this.btnListNewDomain.Values.Text = "2、列出最近域名→";
            this.btnListNewDomain.Click += new System.EventHandler(this.btnListNewDomain_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUserEmail);
            this.groupBox2.Controls.Add(this.txtPWD);
            this.groupBox2.Controls.Add(this.x_Lable1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnLogout);
            this.groupBox2.Controls.Add(this.btnLoginDNSPOD);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 56);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2、登录DNSPOD";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.Location = new System.Drawing.Point(98, 22);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(112, 20);
            this.txtUserEmail.TabIndex = 0;
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(260, 22);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '*';
            this.txtPWD.Size = new System.Drawing.Size(112, 20);
            this.txtPWD.TabIndex = 0;
            // 
            // x_Lable1
            // 
            this.x_Lable1.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable1.Location = new System.Drawing.Point(580, 24);
            this.x_Lable1.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable1.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.Name = "x_Lable1";
            this.x_Lable1.ShowControl = this.btnLoginDNSPOD;
            this.x_Lable1.ShowText = "登录到DNSPOD，成功后，可以进入下一步操作。";
            this.x_Lable1.ShowTitle = "登录到DNSPOD";
            this.x_Lable1.Size = new System.Drawing.Size(22, 17);
            this.x_Lable1.TabIndex = 4;
            // 
            // btnLoginDNSPOD
            // 
            this.btnLoginDNSPOD.Location = new System.Drawing.Point(392, 20);
            this.btnLoginDNSPOD.Name = "btnLoginDNSPOD";
            this.btnLoginDNSPOD.Size = new System.Drawing.Size(88, 25);
            this.btnLoginDNSPOD.TabIndex = 1;
            this.btnLoginDNSPOD.Values.Text = "登录";
            this.btnLoginDNSPOD.Click += new System.EventHandler(this.btnLoginDnsPod_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "DnsPod邮箱：";
            // 
            // btnLogout
            // 
            this.btnLogout.Enabled = false;
            this.btnLogout.Location = new System.Drawing.Point(486, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(88, 25);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Values.Text = "注销";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.x_Lable4);
            this.groupBox1.Controls.Add(this.x_Lable3);
            this.groupBox1.Controls.Add(this.btnGD);
            this.groupBox1.Controls.Add(this.btnTaobao);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1、域名购买、预处理";
            // 
            // x_Lable4
            // 
            this.x_Lable4.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable4.Location = new System.Drawing.Point(580, 24);
            this.x_Lable4.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable4.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable4.Name = "x_Lable4";
            this.x_Lable4.ShowControl = this.btnGD;
            this.x_Lable4.ShowText = "登录GD，进入域名注册的后台将 DNS 修改为：\r\nf1g1ns1.dnspod.net\r\nf1g1ns2.dnspod.net";
            this.x_Lable4.ShowTitle = "批量修改GD的域名DNS";
            this.x_Lable4.Size = new System.Drawing.Size(22, 17);
            this.x_Lable4.TabIndex = 4;
            // 
            // btnGD
            // 
            this.btnGD.Location = new System.Drawing.Point(316, 20);
            this.btnGD.Name = "btnGD";
            this.btnGD.Size = new System.Drawing.Size(258, 25);
            this.btnGD.TabIndex = 0;
            this.btnGD.Values.Text = "Godaddy接收域名、批量使用DNSPOD解析";
            this.btnGD.Click += new System.EventHandler(this.btnGD_Click);
            // 
            // x_Lable3
            // 
            this.x_Lable3.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable3.Location = new System.Drawing.Point(288, 24);
            this.x_Lable3.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable3.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable3.Name = "x_Lable3";
            this.x_Lable3.ShowControl = this.btnTaobao;
            this.x_Lable3.ShowText = "点击此按钮，可以快速的去淘宝，购买您的域名。记得准备好godaddy的账号，邮箱哦。";
            this.x_Lable3.ShowTitle = "快捷购买域名";
            this.x_Lable3.Size = new System.Drawing.Size(22, 17);
            this.x_Lable3.TabIndex = 4;
            // 
            // btnTaobao
            // 
            this.btnTaobao.Location = new System.Drawing.Point(20, 20);
            this.btnTaobao.Name = "btnTaobao";
            this.btnTaobao.Size = new System.Drawing.Size(262, 25);
            this.btnTaobao.TabIndex = 0;
            this.btnTaobao.Values.Text = "淘宝购买域名com|net|org|info";
            this.btnTaobao.Click += new System.EventHandler(this.btnTaobao_Click);
            // 
            // x_Lable5
            // 
            this.x_Lable5.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable5.Location = new System.Drawing.Point(288, 40);
            this.x_Lable5.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable5.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable5.Name = "x_Lable5";
            this.x_Lable5.ShowControl = this.btnCreateDomain;
            this.x_Lable5.ShowText = "添加域名列表，一行一个，必须都是根域名（无www）。最多15个每次。";
            this.x_Lable5.ShowTitle = "批量添加域名";
            this.x_Lable5.Size = new System.Drawing.Size(22, 17);
            this.x_Lable5.TabIndex = 4;
            // 
            // X_Form_DnsPod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 375);
            this.Controls.Add(this.tabControl1);
            this.Name = "X_Form_DnsPod";
            this.Text = "域名批量解析助手";
            this.Load += new System.EventHandler(this.X_Form_DnsPod_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGD;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTaobao;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCreateDomain;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPWD;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNewDomains;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUserEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private X_Service.Util.X_Lable x_Lable4;
        private X_Service.Util.X_Lable x_Lable3;
        private System.Windows.Forms.GroupBox groupBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLoginDNSPOD;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtADomains;
        private X_Service.Util.X_Lable x_Lable2;
        private X_Service.Util.X_Lable x_Lable1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSetA;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnListNewDomain;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSetIP;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLogout;
        private X_Service.Util.X_Lable x_Lable5;
    }
}