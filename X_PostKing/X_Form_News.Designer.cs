namespace X_PostKing {
    partial class X_Form_News {
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("忍者官方微博，加载中...");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_News));
            this.weblist = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // weblist
            // 
            this.weblist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weblist.GridLines = true;
            this.weblist.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.weblist.Location = new System.Drawing.Point(0, 0);
            this.weblist.MultiSelect = false;
            this.weblist.Name = "weblist";
            this.weblist.Size = new System.Drawing.Size(604, 282);
            this.weblist.TabIndex = 1;
            this.weblist.TileSize = new System.Drawing.Size(380, 20);
            this.weblist.UseCompatibleStateImageBehavior = false;
            this.weblist.View = System.Windows.Forms.View.Tile;
            this.weblist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.weblist_MouseDoubleClick);
            // 
            // X_Form_News
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 282);
            this.Controls.Add(this.weblist);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "X_Form_News";
            this.TabText = "忍者X2 微博广播 赶快收听吧~~双击在浏览器中打开~~";
            this.Text = "X_Form_News";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView weblist;
    }
}