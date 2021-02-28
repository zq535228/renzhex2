namespace X_PostKing.Tools {
    partial class X_Form_Domain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkFindDomain = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.btnStart = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtAfter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtBefore = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBenANDomain = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnBeiAN = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtEnableDomain = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.linkBmi = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
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
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.X_Form_Domain;
            this.pictureBox1.Size = new System.Drawing.Size(736, 50);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(736, 353);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(728, 327);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "域名检测";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkBmi);
            this.groupBox1.Controls.Add(this.linkFindDomain);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.txtAfter);
            this.groupBox1.Controls.Add(this.txtBefore);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 321);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过期域名是否可注册";
            // 
            // linkFindDomain
            // 
            this.linkFindDomain.Location = new System.Drawing.Point(352, 154);
            this.linkFindDomain.Name = "linkFindDomain";
            this.linkFindDomain.Orientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Left;
            this.linkFindDomain.Size = new System.Drawing.Size(20, 60);
            this.linkFindDomain.TabIndex = 3;
            this.linkFindDomain.Values.Text = "过期域名";
            this.linkFindDomain.LinkClicked += new System.EventHandler(this.linkFindDomain_LinkClicked);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(343, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Orientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Left;
            this.btnStart.Size = new System.Drawing.Size(36, 128);
            this.btnStart.TabIndex = 2;
            this.btnStart.Values.Text = "批量检测";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtAfter
            // 
            this.txtAfter.Location = new System.Drawing.Point(385, 20);
            this.txtAfter.Multiline = true;
            this.txtAfter.Name = "txtAfter";
            this.txtAfter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAfter.Size = new System.Drawing.Size(331, 295);
            this.txtAfter.TabIndex = 1;
            // 
            // txtBefore
            // 
            this.txtBefore.Location = new System.Drawing.Point(6, 20);
            this.txtBefore.Multiline = true;
            this.txtBefore.Name = "txtBefore";
            this.txtBefore.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBefore.Size = new System.Drawing.Size(331, 295);
            this.txtBefore.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 327);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "备案检测";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBenANDomain);
            this.groupBox2.Controls.Add(this.btnBeiAN);
            this.groupBox2.Controls.Add(this.txtEnableDomain);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(722, 322);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "过滤已备案域名";
            // 
            // txtBenANDomain
            // 
            this.txtBenANDomain.Location = new System.Drawing.Point(385, 20);
            this.txtBenANDomain.Multiline = true;
            this.txtBenANDomain.Name = "txtBenANDomain";
            this.txtBenANDomain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBenANDomain.Size = new System.Drawing.Size(331, 295);
            this.txtBenANDomain.TabIndex = 4;
            // 
            // btnBeiAN
            // 
            this.btnBeiAN.Location = new System.Drawing.Point(343, 20);
            this.btnBeiAN.Name = "btnBeiAN";
            this.btnBeiAN.Orientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Left;
            this.btnBeiAN.Size = new System.Drawing.Size(36, 128);
            this.btnBeiAN.TabIndex = 3;
            this.btnBeiAN.Values.Text = "批量探测是否备案";
            this.btnBeiAN.Click += new System.EventHandler(this.btnBeiAN_Click);
            // 
            // txtEnableDomain
            // 
            this.txtEnableDomain.Location = new System.Drawing.Point(6, 20);
            this.txtEnableDomain.Multiline = true;
            this.txtEnableDomain.Name = "txtEnableDomain";
            this.txtEnableDomain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEnableDomain.Size = new System.Drawing.Size(331, 295);
            this.txtEnableDomain.TabIndex = 2;
            // 
            // linkBmi
            // 
            this.linkBmi.Location = new System.Drawing.Point(352, 221);
            this.linkBmi.Name = "linkBmi";
            this.linkBmi.Orientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Left;
            this.linkBmi.Size = new System.Drawing.Size(20, 48);
            this.linkBmi.TabIndex = 4;
            this.linkBmi.Values.Text = "备案米";
            this.linkBmi.LinkClicked += new System.EventHandler(this.linkBmi_LinkClicked);
            // 
            // X_Form_Domain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 425);
            this.Controls.Add(this.tabControl1);
            this.Name = "X_Form_Domain";
            this.Text = "过期域名注册";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
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

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAfter;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBefore;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStart;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel linkFindDomain;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEnableDomain;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBenANDomain;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBeiAN;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel linkBmi;

    }
}