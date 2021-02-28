namespace X_PostKing {
    partial class X_Form_BaseTool {
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sStrip = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0 , 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(604 , 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // sStrip
            // 
            this.sStrip.Location = new System.Drawing.Point(0 , 369);
            this.sStrip.Name = "sStrip";
            this.sStrip.Size = new System.Drawing.Size(604 , 22);
            this.sStrip.TabIndex = 2;
            this.sStrip.Text = "一般的工具，不会使用，鼠标悬浮在控制上，会给出提示哦！";
            // 
            // X_Form_BaseTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F , 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604 , 391);
            this.Controls.Add(this.sStrip);
            this.Controls.Add(this.pictureBox1);
            this.MinimizeBox = false;
            this.Name = "X_Form_BaseTool";
            this.Text = "X_Form_Tool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.StatusStrip sStrip;
    }
}