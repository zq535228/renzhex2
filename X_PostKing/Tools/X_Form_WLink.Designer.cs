namespace X_PostKing.Tools {
    partial class X_Form_WLink {
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
            this.btnGO = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ckAuto = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.x_Lable1 = new X_Service.Util.X_Lable();
            this.listDomains = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(257, 12);
            this.btnGO.Name = "btnGO";
            this.btnGO.Orientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.btnGO.Size = new System.Drawing.Size(31, 121);
            this.btnGO.TabIndex = 1;
            this.btnGO.Values.Text = "手动提高相关域";
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // ckAuto
            // 
            this.ckAuto.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.ckAuto.Location = new System.Drawing.Point(262, 162);
            this.ckAuto.Name = "ckAuto";
            this.ckAuto.Orientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.ckAuto.Size = new System.Drawing.Size(20, 73);
            this.ckAuto.TabIndex = 4;
            this.ckAuto.Text = "自动挂机";
            this.ckAuto.Values.Text = "自动挂机";
            this.ckAuto.Click += new System.EventHandler(this.ckAuto_Click);
            // 
            // x_Lable1
            // 
            this.x_Lable1.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable1.Location = new System.Drawing.Point(264, 139);
            this.x_Lable1.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable1.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.Name = "x_Lable1";
            this.x_Lable1.ShowControl = this.ckAuto;
            this.x_Lable1.ShowText = "自动挂机，并当忍者站群在空闲的时候，就会自动提高您的网站站点的相关域。";
            this.x_Lable1.ShowTitle = "自动挂机提高相关域";
            this.x_Lable1.Size = new System.Drawing.Size(22, 17);
            this.x_Lable1.TabIndex = 5;
            // 
            // listDomains
            // 
            this.listDomains.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listDomains.FullRowSelect = true;
            this.listDomains.GridLines = true;
            this.listDomains.Location = new System.Drawing.Point(12, 12);
            this.listDomains.Name = "listDomains";
            this.listDomains.Size = new System.Drawing.Size(239, 468);
            this.listDomains.TabIndex = 6;
            this.listDomains.UseCompatibleStateImageBehavior = false;
            this.listDomains.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "待优化站点列表（Ctrl+左键多选）";
            this.columnHeader1.Width = 199;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(262, 241);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Orientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.kryptonLabel1.Size = new System.Drawing.Size(20, 245);
            this.kryptonLabel1.TabIndex = 7;
            this.kryptonLabel1.Values.Text = "内置3000+个相关域网址，祝您排名飙升。";
            // 
            // X_Form_WLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 492);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.listDomains);
            this.Controls.Add(this.x_Lable1);
            this.Controls.Add(this.ckAuto);
            this.Controls.Add(this.btnGO);
            this.Name = "X_Form_WLink";
            this.Text = "提高相关域工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGO;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox ckAuto;
        private X_Service.Util.X_Lable x_Lable1;
        private System.Windows.Forms.ListView listDomains;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ColumnHeader columnHeader1;

    }
}