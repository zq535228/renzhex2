namespace X_PostKing {
    partial class X_Form_AddSiteUser {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_AddSiteUser));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkGo = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLastUrl01 = new System.Windows.Forms.TextBox();
            this.txt备注信息01 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt密码 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt用户名 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt备注信息02 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLastUrl02 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAgent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCookies = new System.Windows.Forms.TextBox();
            this.lable5 = new System.Windows.Forms.Label();
            this.Btn_抓取马甲 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TS_保存 = new System.Windows.Forms.ToolStripButton();
            this.TS_取消 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.X_Form_Site;
            this.pictureBox1.Size = new System.Drawing.Size(700, 50);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 360);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 334);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "用户信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkGo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtLastUrl01);
            this.groupBox1.Controls.Add(this.txt备注信息01);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt密码);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt用户名);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请填写下面的用户信息";
            // 
            // linkGo
            // 
            this.linkGo.AutoSize = true;
            this.linkGo.Location = new System.Drawing.Point(544, 77);
            this.linkGo.Name = "linkGo";
            this.linkGo.Size = new System.Drawing.Size(29, 12);
            this.linkGo.TabIndex = 9;
            this.linkGo.TabStop = true;
            this.linkGo.Text = "访问";
            this.linkGo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGo_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "备注信息：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "成功URL：";
            // 
            // txtLastUrl01
            // 
            this.txtLastUrl01.Location = new System.Drawing.Point(94, 74);
            this.txtLastUrl01.Name = "txtLastUrl01";
            this.txtLastUrl01.Size = new System.Drawing.Size(444, 21);
            this.txtLastUrl01.TabIndex = 6;
            // 
            // txt备注信息01
            // 
            this.txt备注信息01.Location = new System.Drawing.Point(94, 101);
            this.txt备注信息01.Multiline = true;
            this.txt备注信息01.Name = "txt备注信息01";
            this.txt备注信息01.Size = new System.Drawing.Size(365, 56);
            this.txt备注信息01.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码：";
            // 
            // txt密码
            // 
            this.txt密码.Location = new System.Drawing.Point(94, 47);
            this.txt密码.Name = "txt密码";
            this.txt密码.PasswordChar = '*';
            this.txt密码.Size = new System.Drawing.Size(215, 21);
            this.txt密码.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // txt用户名
            // 
            this.txt用户名.Location = new System.Drawing.Point(94, 20);
            this.txt用户名.Name = "txt用户名";
            this.txt用户名.Size = new System.Drawing.Size(215, 21);
            this.txt用户名.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 334);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "抓取马甲";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt备注信息02);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txt_username);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtLastUrl02);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 166);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "第二步：为您的马甲增加标志(以便于区分马甲信息)";
            // 
            // txt备注信息02
            // 
            this.txt备注信息02.Location = new System.Drawing.Point(75, 78);
            this.txt备注信息02.Multiline = true;
            this.txt备注信息02.Name = "txt备注信息02";
            this.txt备注信息02.Size = new System.Drawing.Size(365, 56);
            this.txt备注信息02.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "备注信息：";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(75, 22);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(150, 21);
            this.txt_username.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "成功URL：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "用户名：";
            // 
            // txtLastUrl02
            // 
            this.txtLastUrl02.Location = new System.Drawing.Point(75, 48);
            this.txtLastUrl02.Name = "txtLastUrl02";
            this.txtLastUrl02.Size = new System.Drawing.Size(444, 21);
            this.txtLastUrl02.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtAgent);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtCookies);
            this.groupBox3.Controls.Add(this.lable5);
            this.groupBox3.Controls.Add(this.Btn_抓取马甲);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(686, 144);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "提示：您选择了马甲登陆模式，请按照下列步骤进行添加马甲！";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(156, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(497, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "抓取马甲的操作，是在登录成功后，任意网址后加\"?renzhe\"，出现绿色抓取信息，保存即可。";
            // 
            // txtAgent
            // 
            this.txtAgent.Location = new System.Drawing.Point(75, 105);
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Size = new System.Drawing.Size(561, 21);
            this.txtAgent.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "Agent：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "马甲信息：";
            // 
            // txtCookies
            // 
            this.txtCookies.Location = new System.Drawing.Point(75, 45);
            this.txtCookies.Multiline = true;
            this.txtCookies.Name = "txtCookies";
            this.txtCookies.Size = new System.Drawing.Size(561, 49);
            this.txtCookies.TabIndex = 7;
            // 
            // lable5
            // 
            this.lable5.AutoSize = true;
            this.lable5.Location = new System.Drawing.Point(19, 21);
            this.lable5.Name = "lable5";
            this.lable5.Size = new System.Drawing.Size(53, 12);
            this.lable5.TabIndex = 6;
            this.lable5.Text = "第一步：";
            // 
            // Btn_抓取马甲
            // 
            this.Btn_抓取马甲.Location = new System.Drawing.Point(75, 16);
            this.Btn_抓取马甲.Name = "Btn_抓取马甲";
            this.Btn_抓取马甲.Size = new System.Drawing.Size(75, 23);
            this.Btn_抓取马甲.TabIndex = 4;
            this.Btn_抓取马甲.Text = "抓取马甲";
            this.Btn_抓取马甲.UseVisualStyleBackColor = true;
            this.Btn_抓取马甲.Click += new System.EventHandler(this.Btn_抓取马甲_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 3;
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
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.toolStrip1.Size = new System.Drawing.Size(700, 39);
            this.toolStrip1.TabIndex = 14;
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
            // X_Form_AddSiteUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 487);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "X_Form_AddSiteUser";
            this.Text = "站点设定";
            this.Load += new System.EventHandler(this.X_Form_AddSiteUser_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt备注信息01;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt密码;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt用户名;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TS_保存;
        private System.Windows.Forms.ToolStripButton TS_取消;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lable5;
        private System.Windows.Forms.Button Btn_抓取马甲;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLastUrl02;
        private System.Windows.Forms.TextBox txtCookies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAgent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLastUrl01;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt备注信息02;
        private System.Windows.Forms.LinkLabel linkGo;
        private System.Windows.Forms.Label label11;

    }
}