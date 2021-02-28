namespace X_PostKing {
    partial class X_Form_FlashHelp {
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
            this.webBrowserHelper = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::X_PostKing.Properties.Resources.X_Form_Help;
            this.pictureBox1.Size = new System.Drawing.Size(1048, 50);
            // 
            // webBrowserHelper
            // 
            this.webBrowserHelper.Dock = System.Windows.Forms.DockStyle.Top;
            this.webBrowserHelper.Location = new System.Drawing.Point(0, 50);
            this.webBrowserHelper.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserHelper.Name = "webBrowserHelper";
            this.webBrowserHelper.Size = new System.Drawing.Size(1048, 665);
            this.webBrowserHelper.TabIndex = 3;
            // 
            // X_Form_FlashHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 740);
            this.Controls.Add(this.webBrowserHelper);
            this.Name = "X_Form_FlashHelp";
            this.Text = "忍者站群X2 新手上路";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.webBrowserHelper, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserHelper;

    }
}