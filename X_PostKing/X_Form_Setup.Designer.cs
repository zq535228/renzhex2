namespace X_PostKing {
    partial class X_Form_Setup {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_Setup));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.x_Lable2 = new X_Service.Util.X_Lable();
            this.txtEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUpass = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUname = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtToEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.x_Lable1 = new X_Service.Util.X_Lable();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ck日志窗口 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.ck异常信息 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.ck任务信息 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.ck普通信息 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.ck错误信息 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.ToolS = new System.Windows.Forms.ToolStrip();
            this.TS_保存 = new System.Windows.Forms.ToolStripButton();
            this.TS_关闭 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ToolS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 280);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(552, 254);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规设定";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.x_Lable2);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txtUpass);
            this.groupBox2.Controls.Add(this.txtUname);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 109);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "浏览器辅助";
            // 
            // x_Lable2
            // 
            this.x_Lable2.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable2.Location = new System.Drawing.Point(329, 46);
            this.x_Lable2.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable2.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable2.Name = "x_Lable2";
            this.x_Lable2.ShowControl = this.label1;
            this.x_Lable2.ShowText = "在站点->用户管理标签中，会有辅助浏览器，帮助您填写表单，用于辅助账户注册。这里填写的是默认值。";
            this.x_Lable2.ShowTitle = "浏览器辅助";
            this.x_Lable2.Size = new System.Drawing.Size(22, 17);
            this.x_Lable2.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(107, 71);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(216, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // txtUpass
            // 
            this.txtUpass.Location = new System.Drawing.Point(107, 44);
            this.txtUpass.Name = "txtUpass";
            this.txtUpass.Size = new System.Drawing.Size(216, 20);
            this.txtUpass.TabIndex = 7;
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(107, 20);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(216, 20);
            this.txtUname.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "默认邮箱：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "默认用户名：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtToEmail);
            this.groupBox3.Controls.Add(this.x_Lable1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(546, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "软件设定";
            // 
            // txtToEmail
            // 
            this.txtToEmail.Location = new System.Drawing.Point(107, 17);
            this.txtToEmail.Name = "txtToEmail";
            this.txtToEmail.Size = new System.Drawing.Size(251, 20);
            this.txtToEmail.TabIndex = 7;
            // 
            // x_Lable1
            // 
            this.x_Lable1.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable1.Location = new System.Drawing.Point(364, 19);
            this.x_Lable1.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.Name = "x_Lable1";
            this.x_Lable1.ShowControl = this.txtToEmail;
            this.x_Lable1.ShowText = "当出现特殊情况，会以邮件的形式通知您。这个主要配合高端用户的服务器挂机功能。\r\n例如：\r\n系统发生错误，需要您修复。\r\n发布的文章不足，需要您添加文章等。";
            this.x_Lable1.ShowTitle = "邮件通知";
            this.x_Lable1.Size = new System.Drawing.Size(22, 17);
            this.x_Lable1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "邮件通知：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ck日志窗口);
            this.groupBox1.Controls.Add(this.ck异常信息);
            this.groupBox1.Controls.Add(this.ck任务信息);
            this.groupBox1.Controls.Add(this.ck普通信息);
            this.groupBox1.Controls.Add(this.ck错误信息);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志设定";
            // 
            // ck日志窗口
            // 
            this.ck日志窗口.Location = new System.Drawing.Point(450, 20);
            this.ck日志窗口.Name = "ck日志窗口";
            this.ck日志窗口.Size = new System.Drawing.Size(90, 25);
            this.ck日志窗口.TabIndex = 9;
            this.ck日志窗口.Values.Text = "日志窗口";
            // 
            // ck异常信息
            // 
            this.ck异常信息.Location = new System.Drawing.Point(339, 20);
            this.ck异常信息.Name = "ck异常信息";
            this.ck异常信息.Size = new System.Drawing.Size(90, 25);
            this.ck异常信息.TabIndex = 8;
            this.ck异常信息.Values.Text = "异常信息";
            // 
            // ck任务信息
            // 
            this.ck任务信息.Location = new System.Drawing.Point(228, 20);
            this.ck任务信息.Name = "ck任务信息";
            this.ck任务信息.Size = new System.Drawing.Size(90, 25);
            this.ck任务信息.TabIndex = 7;
            this.ck任务信息.Values.Text = "任务信息";
            // 
            // ck普通信息
            // 
            this.ck普通信息.Location = new System.Drawing.Point(117, 20);
            this.ck普通信息.Name = "ck普通信息";
            this.ck普通信息.Size = new System.Drawing.Size(90, 25);
            this.ck普通信息.TabIndex = 6;
            this.ck普通信息.Values.Text = "普通信息";
            // 
            // ck错误信息
            // 
            this.ck错误信息.Location = new System.Drawing.Point(6, 20);
            this.ck错误信息.Name = "ck错误信息";
            this.ck错误信息.Size = new System.Drawing.Size(90, 25);
            this.ck错误信息.TabIndex = 6;
            this.ck错误信息.Values.Text = "错误信息";
            // 
            // ToolS
            // 
            this.ToolS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ToolS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_保存,
            this.TS_关闭});
            this.ToolS.Location = new System.Drawing.Point(0, 50);
            this.ToolS.Name = "ToolS";
            this.ToolS.Padding = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.ToolS.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.ToolS.Size = new System.Drawing.Size(560, 39);
            this.ToolS.TabIndex = 7;
            this.ToolS.Text = "ToolS";
            // 
            // TS_保存
            // 
            this.TS_保存.Image = ((System.Drawing.Image)(resources.GetObject("TS_保存.Image")));
            this.TS_保存.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_保存.Name = "TS_保存";
            this.TS_保存.Size = new System.Drawing.Size(91, 36);
            this.TS_保存.Text = "保存信息";
            this.TS_保存.Click += new System.EventHandler(this.TS_保存_Click);
            // 
            // TS_关闭
            // 
            this.TS_关闭.Image = ((System.Drawing.Image)(resources.GetObject("TS_关闭.Image")));
            this.TS_关闭.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_关闭.Name = "TS_关闭";
            this.TS_关闭.Size = new System.Drawing.Size(91, 36);
            this.TS_关闭.Text = "放弃操作";
            this.TS_关闭.Click += new System.EventHandler(this.TS_关闭_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(560, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // X_Form_Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 375);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ToolS);
            this.Controls.Add(this.pictureBox1);
            this.Name = "X_Form_Setup";
            this.Text = "软件设定";
            this.Load += new System.EventHandler(this.X_Form_Setup_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ToolS.ResumeLayout(false);
            this.ToolS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ToolStrip ToolS;
        public System.Windows.Forms.ToolStripButton TS_保存;
        public System.Windows.Forms.ToolStripButton TS_关闭;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private X_Service.Util.X_Lable x_Lable1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton ck错误信息;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton ck普通信息;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton ck日志窗口;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton ck异常信息;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton ck任务信息;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUpass;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUname;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtToEmail;
        private X_Service.Util.X_Lable x_Lable2;
    }
}