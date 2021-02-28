namespace X_PostKing.Tools {
    partial class X_Form_TkShop {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_TkShop));
            this.tabControlTKShop = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDelayNum = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.x_Lable3 = new X_Service.Util.X_Lable();
            this.x_Lable2 = new X_Service.Util.X_Lable();
            this.txtSClick = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.x_Lable1 = new X_Service.Util.X_Lable();
            this.txtShopUrl = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtOverInsertHTML = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnOutput = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControlTKShop.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.tools;
            this.pictureBox1.Size = new System.Drawing.Size(564, 50);
            // 
            // tabControlTKShop
            // 
            this.tabControlTKShop.Controls.Add(this.tabPage1);
            this.tabControlTKShop.Controls.Add(this.tabPage2);
            this.tabControlTKShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlTKShop.Location = new System.Drawing.Point(0, 50);
            this.tabControlTKShop.Name = "tabControlTKShop";
            this.tabControlTKShop.SelectedIndex = 0;
            this.tabControlTKShop.Size = new System.Drawing.Size(564, 187);
            this.tabControlTKShop.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(556, 161);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDelayNum);
            this.groupBox1.Controls.Add(this.x_Lable3);
            this.groupBox1.Controls.Add(this.x_Lable2);
            this.groupBox1.Controls.Add(this.x_Lable1);
            this.groupBox1.Controls.Add(this.kryptonLabel3);
            this.groupBox1.Controls.Add(this.txtSClick);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Controls.Add(this.txtShopUrl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请输入广告的基本信息";
            // 
            // txtDelayNum
            // 
            this.txtDelayNum.Location = new System.Drawing.Point(86, 73);
            this.txtDelayNum.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtDelayNum.Name = "txtDelayNum";
            this.txtDelayNum.Size = new System.Drawing.Size(67, 22);
            this.txtDelayNum.TabIndex = 18;
            this.txtDelayNum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // x_Lable3
            // 
            this.x_Lable3.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable3.Location = new System.Drawing.Point(159, 77);
            this.x_Lable3.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable3.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable3.Name = "x_Lable3";
            this.x_Lable3.ShowControl = this.txtDelayNum;
            this.x_Lable3.ShowText = "系统将延时几秒钟后，再加载广告。";
            this.x_Lable3.ShowTitle = "延时加载";
            this.x_Lable3.Size = new System.Drawing.Size(22, 17);
            this.x_Lable3.TabIndex = 17;
            // 
            // x_Lable2
            // 
            this.x_Lable2.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable2.Location = new System.Drawing.Point(412, 48);
            this.x_Lable2.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable2.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable2.Name = "x_Lable2";
            this.x_Lable2.ShowControl = this.txtSClick;
            this.x_Lable2.ShowText = "请输入带有您PID的淘宝客链接，点击此链接，将跳转并带有您的PID。";
            this.x_Lable2.ShowTitle = "佣金链接";
            this.x_Lable2.Size = new System.Drawing.Size(22, 17);
            this.x_Lable2.TabIndex = 16;
            // 
            // txtSClick
            // 
            this.txtSClick.Location = new System.Drawing.Point(85, 46);
            this.txtSClick.Name = "txtSClick";
            this.txtSClick.Size = new System.Drawing.Size(321, 20);
            this.txtSClick.TabIndex = 12;
            // 
            // x_Lable1
            // 
            this.x_Lable1.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable1.Location = new System.Drawing.Point(412, 22);
            this.x_Lable1.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable1.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.Name = "x_Lable1";
            this.x_Lable1.ShowControl = this.txtShopUrl;
            this.x_Lable1.ShowText = "请输入您想展示的页面地址，例如：http://shop1122.taobao.com/";
            this.x_Lable1.ShowTitle = "店铺地址";
            this.x_Lable1.Size = new System.Drawing.Size(22, 17);
            this.x_Lable1.TabIndex = 15;
            // 
            // txtShopUrl
            // 
            this.txtShopUrl.Location = new System.Drawing.Point(85, 20);
            this.txtShopUrl.Name = "txtShopUrl";
            this.txtShopUrl.Size = new System.Drawing.Size(321, 20);
            this.txtShopUrl.TabIndex = 9;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(6, 74);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel3.TabIndex = 14;
            this.kryptonLabel3.Values.Text = "延时载入：";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(6, 46);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel2.TabIndex = 11;
            this.kryptonLabel2.Values.Text = "佣金链接：";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 20);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel1.TabIndex = 10;
            this.kryptonLabel1.Values.Text = "店铺地址：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(556, 161);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "完成&生成";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kryptonLabel4);
            this.groupBox2.Controls.Add(this.txtOverInsertHTML);
            this.groupBox2.Controls.Add(this.btnOutput);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 155);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "请点击按钮生成，并插入代码";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(154, 22);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(368, 20);
            this.kryptonLabel4.TabIndex = 4;
            this.kryptonLabel4.Values.Text = "生成的tapi上传至网站根目录。并添加下列代码，以便引入广告。";
            // 
            // txtOverInsertHTML
            // 
            this.txtOverInsertHTML.Location = new System.Drawing.Point(6, 51);
            this.txtOverInsertHTML.Multiline = true;
            this.txtOverInsertHTML.Name = "txtOverInsertHTML";
            this.txtOverInsertHTML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOverInsertHTML.Size = new System.Drawing.Size(538, 98);
            this.txtOverInsertHTML.TabIndex = 3;
            this.txtOverInsertHTML.Text = resources.GetString("txtOverInsertHTML.Text");
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(6, 20);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(142, 25);
            this.btnOutput.TabIndex = 2;
            this.btnOutput.Values.Text = "生成tapi到桌面";
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // X_Form_TkShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 262);
            this.Controls.Add(this.tabControlTKShop);
            this.Name = "X_Form_TkShop";
            this.Text = "淘宝店铺全站引入 一键生成器";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tabControlTKShop, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControlTKShop.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlTKShop;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private X_Service.Util.X_Lable x_Lable3;
        private X_Service.Util.X_Lable x_Lable2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSClick;
        private X_Service.Util.X_Lable x_Lable1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtShopUrl;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtOverInsertHTML;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOutput;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtDelayNum;
    }
}