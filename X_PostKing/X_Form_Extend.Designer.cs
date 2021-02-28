namespace X_PostKing {
    partial class X_Form_Extend {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_Extend));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TS_保存 = new System.Windows.Forms.ToolStripButton();
            this.TS_取消 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.x_Lable2 = new X_Service.Util.X_Lable();
            this.txtInUrl = new System.Windows.Forms.TextBox();
            this.x_Lable1 = new X_Service.Util.X_Lable();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnOutput = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.x_Lable3 = new X_Service.Util.X_Lable();
            this.txtInlink = new System.Windows.Forms.TextBox();
            this.BtnWa = new System.Windows.Forms.Button();
            this.txtInContent = new System.Windows.Forms.RichTextBox();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.extend;
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
            this.toolStrip1.Size = new System.Drawing.Size(604, 39);
            this.toolStrip1.TabIndex = 7;
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
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(604, 266);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(596, 240);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "外链搜索";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.x_Lable2);
            this.groupBox1.Controls.Add(this.x_Lable1);
            this.groupBox1.Controls.Add(this.btnOutput);
            this.groupBox1.Controls.Add(this.txtInUrl);
            this.groupBox1.Controls.Add(this.txtContent);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 232);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入以下信息，软件帮你搜索外链资源";
            // 
            // x_Lable2
            // 
            this.x_Lable2.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable2.Location = new System.Drawing.Point(469, 51);
            this.x_Lable2.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable2.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable2.Name = "x_Lable2";
            this.x_Lable2.ShowControl = this.txtInUrl;
            this.x_Lable2.ShowText = "某些特定的论坛，例如Discuz的注册页面URL，OBLOG的登录页面。填写URL不包括域名。";
            this.x_Lable2.ShowTitle = "网站URL特征字符串";
            this.x_Lable2.Size = new System.Drawing.Size(22, 17);
            this.x_Lable2.TabIndex = 6;
            // 
            // txtInUrl
            // 
            this.txtInUrl.Location = new System.Drawing.Point(6, 47);
            this.txtInUrl.Name = "txtInUrl";
            this.txtInUrl.Size = new System.Drawing.Size(457, 21);
            this.txtInUrl.TabIndex = 2;
            // 
            // x_Lable1
            // 
            this.x_Lable1.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable1.Location = new System.Drawing.Point(469, 24);
            this.x_Lable1.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.Name = "x_Lable1";
            this.x_Lable1.ShowControl = this.txtKey;
            this.x_Lable1.ShowText = "您可以输入大类别的关键词，这样搜索出来的网站，比较多。例如：美容论坛，二手笔记本论坛等。";
            this.x_Lable1.ShowTitle = "关键词的解释：";
            this.x_Lable1.Size = new System.Drawing.Size(22, 17);
            this.x_Lable1.TabIndex = 5;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(6, 20);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(457, 21);
            this.txtKey.TabIndex = 0;
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(497, 45);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 4;
            this.btnOutput.Text = "导出";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(6, 74);
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(578, 152);
            this.txtContent.TabIndex = 3;
            this.txtContent.Text = "";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(497, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(596, 240);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "查外链";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.x_Lable3);
            this.groupBox2.Controls.Add(this.BtnWa);
            this.groupBox2.Controls.Add(this.txtInContent);
            this.groupBox2.Controls.Add(this.txtInlink);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 232);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通过别人的网站，获取外链资源。他的资源，我也有。";
            // 
            // x_Lable3
            // 
            this.x_Lable3.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable3.Location = new System.Drawing.Point(469, 23);
            this.x_Lable3.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable3.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable3.Name = "x_Lable3";
            this.x_Lable3.ShowControl = this.txtInlink;
            this.x_Lable3.ShowText = "网址可以选www，查询结果有可能会不同。";
            this.x_Lable3.ShowTitle = "请输入网址";
            this.x_Lable3.Size = new System.Drawing.Size(22, 17);
            this.x_Lable3.TabIndex = 3;
            // 
            // txtInlink
            // 
            this.txtInlink.Location = new System.Drawing.Point(6, 20);
            this.txtInlink.Name = "txtInlink";
            this.txtInlink.Size = new System.Drawing.Size(457, 21);
            this.txtInlink.TabIndex = 0;
            // 
            // BtnWa
            // 
            this.BtnWa.Location = new System.Drawing.Point(497, 18);
            this.BtnWa.Name = "BtnWa";
            this.BtnWa.Size = new System.Drawing.Size(75, 23);
            this.BtnWa.TabIndex = 2;
            this.BtnWa.Text = "挖掘";
            this.BtnWa.UseVisualStyleBackColor = true;
            this.BtnWa.Click += new System.EventHandler(this.BtnWa_Click);
            // 
            // txtInContent
            // 
            this.txtInContent.Location = new System.Drawing.Point(6, 48);
            this.txtInContent.Name = "txtInContent";
            this.txtInContent.Size = new System.Drawing.Size(578, 178);
            this.txtInContent.TabIndex = 1;
            this.txtInContent.Text = "";
            // 
            // X_Form_Extend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 391);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "X_Form_Extend";
            this.Text = "资源扩展";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TS_保存;
        private System.Windows.Forms.ToolStripButton TS_取消;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtInUrl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtInContent;
        private System.Windows.Forms.TextBox txtInlink;
        private System.Windows.Forms.Button BtnWa;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private X_Service.Util.X_Lable x_Lable1;
        private X_Service.Util.X_Lable x_Lable2;
        private X_Service.Util.X_Lable x_Lable3;
    }
}