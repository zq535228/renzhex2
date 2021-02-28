namespace X_PostKing {
    partial class X_Form_VCode {
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pbVcode = new System.Windows.Forms.PictureBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            ( (System.ComponentModel.ISupportInitialize)( this.pbVcode ) ).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12 , 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88 , 21);
            this.textBox1.TabIndex = 4;
            // 
            // pbVcode
            // 
            this.pbVcode.Location = new System.Drawing.Point(12 , 12);
            this.pbVcode.Name = "pbVcode";
            this.pbVcode.Size = new System.Drawing.Size(200 , 80);
            this.pbVcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVcode.TabIndex = 3;
            this.pbVcode.TabStop = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(127 , 109);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(85 , 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "确认提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // X_FormVCode
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F , 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225 , 146);
            this.ControlBox = false;
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pbVcode);
            this.Name = "X_FormVCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请输入验证码";
            this.Load += new System.EventHandler(this.X_FormVCode_Load);
            ( (System.ComponentModel.ISupportInitialize)( this.pbVcode ) ).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pbVcode;
        private System.Windows.Forms.Button btnSubmit;
    }
}