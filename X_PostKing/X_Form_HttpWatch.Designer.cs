namespace X_PostKing {
    partial class X_Form_HttpWatch {
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
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Finish = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Group_2 = new System.Windows.Forms.GroupBox();
            this.Rich_Detail = new System.Windows.Forms.RichTextBox();
            this.Radio_IE = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Group_1 = new System.Windows.Forms.GroupBox();
            this.List_Pack = new System.Windows.Forms.ListView();
            this.Url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cookie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PostData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Btn_Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Text_Url = new System.Windows.Forms.TextBox();
            this.Group_2.SuspendLayout();
            this.Group_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(1, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(583, 2);
            this.label5.TabIndex = 25;
            // 
            // Btn_Finish
            // 
            this.Btn_Finish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Finish.Location = new System.Drawing.Point(495, 432);
            this.Btn_Finish.Name = "Btn_Finish";
            this.Btn_Finish.Size = new System.Drawing.Size(75, 23);
            this.Btn_Finish.TabIndex = 24;
            this.Btn_Finish.Text = "完成提取";
            this.Btn_Finish.UseVisualStyleBackColor = true;
            this.Btn_Finish.Click += new System.EventHandler(this.Btn_Finish_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(16, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(413, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "请登录后访问发布页,然后提取该页信息(技巧,在访问的页面后加?renzhe即可)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(16, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(479, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "提取技巧：在请求的参数上加上“?renzhe”这个字符，系统会自动标记为关键数据哦 ^_^!";
            // 
            // Group_2
            // 
            this.Group_2.Controls.Add(this.Rich_Detail);
            this.Group_2.Location = new System.Drawing.Point(12, 219);
            this.Group_2.Name = "Group_2";
            this.Group_2.Size = new System.Drawing.Size(563, 173);
            this.Group_2.TabIndex = 21;
            this.Group_2.TabStop = false;
            this.Group_2.Text = "详细信息";
            // 
            // Rich_Detail
            // 
            this.Rich_Detail.Location = new System.Drawing.Point(6, 20);
            this.Rich_Detail.Name = "Rich_Detail";
            this.Rich_Detail.Size = new System.Drawing.Size(551, 142);
            this.Rich_Detail.TabIndex = 4;
            this.Rich_Detail.Text = "";
            // 
            // Radio_IE
            // 
            this.Radio_IE.AutoSize = true;
            this.Radio_IE.Checked = true;
            this.Radio_IE.Location = new System.Drawing.Point(81, 39);
            this.Radio_IE.Name = "Radio_IE";
            this.Radio_IE.Size = new System.Drawing.Size(497, 16);
            this.Radio_IE.TabIndex = 19;
            this.Radio_IE.TabStop = true;
            this.Radio_IE.Text = "1、成功安装好HttpWatch7.0；2、使用IE浏览器（IE7 IE8 IE9），并设置为默认浏览器。";
            this.Radio_IE.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "提取说明：";
            // 
            // Group_1
            // 
            this.Group_1.Controls.Add(this.List_Pack);
            this.Group_1.Location = new System.Drawing.Point(10, 65);
            this.Group_1.Name = "Group_1";
            this.Group_1.Size = new System.Drawing.Size(565, 148);
            this.Group_1.TabIndex = 17;
            this.Group_1.TabStop = false;
            this.Group_1.Text = "侦探到的信息(绿色的为关键数据)";
            // 
            // List_Pack
            // 
            this.List_Pack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Url,
            this.Mode,
            this.Cookie,
            this.PostData,
            this.Header});
            this.List_Pack.FullRowSelect = true;
            this.List_Pack.GridLines = true;
            this.List_Pack.Location = new System.Drawing.Point(6, 20);
            this.List_Pack.MultiSelect = false;
            this.List_Pack.Name = "List_Pack";
            this.List_Pack.Size = new System.Drawing.Size(554, 122);
            this.List_Pack.TabIndex = 2;
            this.List_Pack.UseCompatibleStateImageBehavior = false;
            this.List_Pack.View = System.Windows.Forms.View.Details;
            this.List_Pack.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.List_Pack_ColumnClick);
            this.List_Pack.Click += new System.EventHandler(this.List_Pack_Click);
            // 
            // Url
            // 
            this.Url.Text = "网址";
            this.Url.Width = 224;
            // 
            // Mode
            // 
            this.Mode.Text = "Mode";
            this.Mode.Width = 57;
            // 
            // Cookie
            // 
            this.Cookie.Text = "Cookie";
            this.Cookie.Width = 69;
            // 
            // PostData
            // 
            this.PostData.Text = "PostData";
            this.PostData.Width = 83;
            // 
            // Header
            // 
            this.Header.Text = "Header";
            // 
            // Btn_Start
            // 
            this.Btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Start.Location = new System.Drawing.Point(428, 10);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(147, 23);
            this.Btn_Start.TabIndex = 16;
            this.Btn_Start.Text = "开始侦测";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "提取地址：";
            // 
            // Text_Url
            // 
            this.Text_Url.Location = new System.Drawing.Point(81, 12);
            this.Text_Url.Name = "Text_Url";
            this.Text_Url.Size = new System.Drawing.Size(336, 21);
            this.Text_Url.TabIndex = 14;
            // 
            // X_Form_HttpWatch
            // 
            this.AcceptButton = this.Btn_Start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 468);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Btn_Finish);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Group_2);
            this.Controls.Add(this.Radio_IE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Group_1);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Text_Url);
            this.Name = "X_Form_HttpWatch";
            this.Text = "数据分析器";
            this.Group_2.ResumeLayout(false);
            this.Group_1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Finish;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox Group_2;
        private System.Windows.Forms.RichTextBox Rich_Detail;
        private System.Windows.Forms.RadioButton Radio_IE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox Group_1;
        private System.Windows.Forms.ListView List_Pack;
        private System.Windows.Forms.ColumnHeader Url;
        private System.Windows.Forms.ColumnHeader Mode;
        private System.Windows.Forms.ColumnHeader Cookie;
        private System.Windows.Forms.ColumnHeader PostData;
        private System.Windows.Forms.ColumnHeader Header;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Text_Url;
    }
}