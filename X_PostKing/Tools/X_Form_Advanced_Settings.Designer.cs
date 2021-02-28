namespace X_PostKing.Tools {
    partial class X_Form_Advanced_Settings {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtperWait = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnPerWaitSet = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAllSentence = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtperNum = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.btnPerNum = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnPlan = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnIsTitleWYC = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSiteLink = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.X_Form_Setup;
            this.pictureBox1.Size = new System.Drawing.Size(640, 50);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 237);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(632, 211);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "站点高级优化";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSiteLink);
            this.groupBox1.Controls.Add(this.txtperWait);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Controls.Add(this.btnPerWaitSet);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "优化项";
            // 
            // txtperWait
            // 
            this.txtperWait.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtperWait.Location = new System.Drawing.Point(135, 19);
            this.txtperWait.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.txtperWait.Name = "txtperWait";
            this.txtperWait.ReadOnly = true;
            this.txtperWait.Size = new System.Drawing.Size(86, 22);
            this.txtperWait.TabIndex = 44;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 20);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(123, 20);
            this.kryptonLabel1.TabIndex = 43;
            this.kryptonLabel1.Values.Text = "站点发布间隔时间：";
            // 
            // btnPerWaitSet
            // 
            this.btnPerWaitSet.Location = new System.Drawing.Point(242, 18);
            this.btnPerWaitSet.Name = "btnPerWaitSet";
            this.btnPerWaitSet.Size = new System.Drawing.Size(90, 25);
            this.btnPerWaitSet.TabIndex = 42;
            this.btnPerWaitSet.Values.Text = "全部站点应用";
            this.btnPerWaitSet.Click += new System.EventHandler(this.btnPerWaitSet_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(632, 211);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "任务高级优化";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAllSentence);
            this.groupBox2.Controls.Add(this.txtperNum);
            this.groupBox2.Controls.Add(this.btnPerNum);
            this.groupBox2.Controls.Add(this.btnPlan);
            this.groupBox2.Controls.Add(this.btnIsTitleWYC);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 206);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "优化项";
            // 
            // btnAllSentence
            // 
            this.btnAllSentence.Location = new System.Drawing.Point(6, 113);
            this.btnAllSentence.Name = "btnAllSentence";
            this.btnAllSentence.Size = new System.Drawing.Size(203, 25);
            this.btnAllSentence.TabIndex = 52;
            this.btnAllSentence.Values.Text = "全部任务→开启断言伪原创";
            this.btnAllSentence.Click += new System.EventHandler(this.btnAllSentence_Click);
            // 
            // txtperNum
            // 
            this.txtperNum.Location = new System.Drawing.Point(215, 83);
            this.txtperNum.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtperNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtperNum.Name = "txtperNum";
            this.txtperNum.ReadOnly = true;
            this.txtperNum.Size = new System.Drawing.Size(90, 22);
            this.txtperNum.TabIndex = 51;
            this.txtperNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnPerNum
            // 
            this.btnPerNum.Location = new System.Drawing.Point(6, 82);
            this.btnPerNum.Name = "btnPerNum";
            this.btnPerNum.Size = new System.Drawing.Size(203, 25);
            this.btnPerNum.TabIndex = 50;
            this.btnPerNum.Values.Text = "全部任务→发布数量设置";
            this.btnPerNum.Click += new System.EventHandler(this.btnPerNum_Click);
            // 
            // btnPlan
            // 
            this.btnPlan.Location = new System.Drawing.Point(6, 51);
            this.btnPlan.Name = "btnPlan";
            this.btnPlan.Size = new System.Drawing.Size(203, 25);
            this.btnPlan.TabIndex = 49;
            this.btnPlan.Values.Text = "全部任务→自动随机日触发计划";
            this.btnPlan.Click += new System.EventHandler(this.btnPlan_Click);
            // 
            // btnIsTitleWYC
            // 
            this.btnIsTitleWYC.Location = new System.Drawing.Point(6, 20);
            this.btnIsTitleWYC.Name = "btnIsTitleWYC";
            this.btnIsTitleWYC.Size = new System.Drawing.Size(203, 25);
            this.btnIsTitleWYC.TabIndex = 48;
            this.btnIsTitleWYC.Values.Text = "全部任务→开启标题伪原创";
            this.btnIsTitleWYC.Click += new System.EventHandler(this.btnIsTitleWYC_Click);
            // 
            // btnSiteLink
            // 
            this.btnSiteLink.Location = new System.Drawing.Point(6, 47);
            this.btnSiteLink.Name = "btnSiteLink";
            this.btnSiteLink.Size = new System.Drawing.Size(215, 25);
            this.btnSiteLink.TabIndex = 45;
            this.btnSiteLink.Values.Text = "全部站点→开启链轮15%入库";
            this.btnSiteLink.Click += new System.EventHandler(this.btnSiteLink_Click);
            // 
            // X_Form_Advanced_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 320);
            this.Controls.Add(this.tabControl1);
            this.Name = "X_Form_Advanced_Settings";
            this.Text = "忍者全局优化设定";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtperWait;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPerWaitSet;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnIsTitleWYC;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPlan;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPerNum;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtperNum;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAllSentence;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSiteLink;
    }
}