namespace AutoRunServer {
    partial class Run {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Run));
            this.btnAutoRun = new System.Windows.Forms.Button();
            this.notiICON = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonKill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAutoRun
            // 
            this.btnAutoRun.Location = new System.Drawing.Point(12, 12);
            this.btnAutoRun.Name = "btnAutoRun";
            this.btnAutoRun.Size = new System.Drawing.Size(296, 23);
            this.btnAutoRun.TabIndex = 0;
            this.btnAutoRun.Text = "搞起";
            this.btnAutoRun.UseVisualStyleBackColor = true;
            this.btnAutoRun.Click += new System.EventHandler(this.btnAutoRun_Click);
            // 
            // notiICON
            // 
            this.notiICON.Icon = ((System.Drawing.Icon)(resources.GetObject("notiICON.Icon")));
            this.notiICON.Text = "忍者站群服务端";
            this.notiICON.Visible = true;
            this.notiICON.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notiICON_MouseClick);
            // 
            // buttonKill
            // 
            this.buttonKill.Location = new System.Drawing.Point(12, 41);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(296, 23);
            this.buttonKill.TabIndex = 1;
            this.buttonKill.Text = "退出";
            this.buttonKill.UseVisualStyleBackColor = true;
            this.buttonKill.Click += new System.EventHandler(this.buttonKill_Click);
            // 
            // Run
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 77);
            this.Controls.Add(this.buttonKill);
            this.Controls.Add(this.btnAutoRun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Run";
            this.Text = "忍者X2服务器自动挂起程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Run_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Run_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAutoRun;
        private System.Windows.Forms.NotifyIcon notiICON;
        private System.Windows.Forms.Button buttonKill;
    }
}

