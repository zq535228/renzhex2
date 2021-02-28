namespace X_PostKing
{
    partial class X_Form_Cate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.List = new System.Windows.Forms.ListView();
            this.分类ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.分类名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Btn_Get = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_Save = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.List);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 154);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "分类列表";
            // 
            // List
            // 
            this.List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.分类ID,
            this.分类名称});
            this.List.Dock = System.Windows.Forms.DockStyle.Top;
            this.List.FullRowSelect = true;
            this.List.GridLines = true;
            this.List.Location = new System.Drawing.Point(3, 17);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(462, 128);
            this.List.TabIndex = 0;
            this.List.UseCompatibleStateImageBehavior = false;
            this.List.View = System.Windows.Forms.View.Details;
            // 
            // 分类ID
            // 
            this.分类ID.Text = "分类ID";
            this.分类ID.Width = 125;
            // 
            // 分类名称
            // 
            this.分类名称.Text = "分类名称";
            this.分类名称.Width = 280;
            // 
            // Btn_Get
            // 
            this.Btn_Get.Location = new System.Drawing.Point(282, 163);
            this.Btn_Get.Name = "Btn_Get";
            this.Btn_Get.Size = new System.Drawing.Size(90, 25);
            this.Btn_Get.TabIndex = 20;
            this.Btn_Get.Values.Text = "重新获取";
            this.Btn_Get.Click += new System.EventHandler(this.Btn_Get_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(378, 163);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(90, 25);
            this.Btn_Save.TabIndex = 21;
            this.Btn_Save.Values.Text = "保存退出";
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // X_Form_Cate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 192);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Btn_Get);
            this.Controls.Add(this.groupBox2);
            this.Name = "X_Form_Cate";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "获取分类信息";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.X_Form_Categories_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView List;
        private System.Windows.Forms.ColumnHeader 分类ID;
        private System.Windows.Forms.ColumnHeader 分类名称;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Get;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Save;
    }
}