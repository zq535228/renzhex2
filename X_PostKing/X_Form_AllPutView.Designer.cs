namespace X_PostKing {
    partial class X_Form_AllPutView {
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
            this.components = new System.ComponentModel.Container();
            this.ListViewAllPut = new System.Windows.Forms.ListView();
            this.Numbers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EebSiteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsRandUp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ListViewAllPut
            // 
            this.ListViewAllPut.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Numbers,
            this.EebSiteName,
            this.TaskName,
            this.IsRandUp});
            this.ListViewAllPut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewAllPut.FullRowSelect = true;
            this.ListViewAllPut.GridLines = true;
            this.ListViewAllPut.Location = new System.Drawing.Point(0, 0);
            this.ListViewAllPut.Name = "ListViewAllPut";
            this.ListViewAllPut.Size = new System.Drawing.Size(948, 439);
            this.ListViewAllPut.TabIndex = 11;
            this.ListViewAllPut.UseCompatibleStateImageBehavior = false;
            this.ListViewAllPut.View = System.Windows.Forms.View.Details;
            this.ListViewAllPut.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.List_Pack_ColumnClick);
            this.ListViewAllPut.DoubleClick += new System.EventHandler(this.ListViewAllPut_DoubleClick);
            // 
            // Numbers
            // 
            this.Numbers.Text = "发布时间";
            this.Numbers.Width = 130;
            // 
            // EebSiteName
            // 
            this.EebSiteName.Text = "站点的URL";
            this.EebSiteName.Width = 250;
            // 
            // TaskName
            // 
            this.TaskName.Text = "任务名称";
            this.TaskName.Width = 150;
            // 
            // IsRandUp
            // 
            this.IsRandUp.Text = "失败原因";
            this.IsRandUp.Width = 200;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 20000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // X_Form_AllPutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 439);
            this.CloseButton = false;
            this.Controls.Add(this.ListViewAllPut);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "X_Form_AllPutView";
            this.TabText = "发布结果浏览";
            this.Text = "X_Form_AllPutView";
            this.Load += new System.EventHandler(this.X_Form_AllPutView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListViewAllPut;
        private System.Windows.Forms.ColumnHeader Numbers;
        private System.Windows.Forms.ColumnHeader TaskName;
        private System.Windows.Forms.ColumnHeader EebSiteName;
        private System.Windows.Forms.ColumnHeader IsRandUp;
        private System.Windows.Forms.Timer timerRefresh;
    }
}