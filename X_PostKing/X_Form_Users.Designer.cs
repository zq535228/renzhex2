namespace X_PostKing
{
    partial class X_Form_Users
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
            this.components = new System.ComponentModel.Container();
            this.Cms_账户管理 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.测试登陆 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.添加账户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑当前账户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除当前账户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ListUsers = new System.Windows.Forms.ListView();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column登陆状态 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column最近活动时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOther = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Btn_Add = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_LoginAll = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_OK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Cms_账户管理.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cms_账户管理
            // 
            this.Cms_账户管理.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测试登陆,
            this.toolStripSeparator2,
            this.添加账户ToolStripMenuItem,
            this.编辑当前账户ToolStripMenuItem,
            this.删除当前账户ToolStripMenuItem});
            this.Cms_账户管理.Name = "Cms_账户管理";
            this.Cms_账户管理.Size = new System.Drawing.Size(149, 98);
            this.Cms_账户管理.Opening += new System.ComponentModel.CancelEventHandler(this.Cms_账户管理_Opening);
            // 
            // 测试登陆
            // 
            this.测试登陆.Name = "测试登陆";
            this.测试登陆.Size = new System.Drawing.Size(148, 22);
            this.测试登陆.Text = "测试登陆";
            this.测试登陆.Click += new System.EventHandler(this.测试登陆_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // 添加账户ToolStripMenuItem
            // 
            this.添加账户ToolStripMenuItem.Name = "添加账户ToolStripMenuItem";
            this.添加账户ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加账户ToolStripMenuItem.Text = "添加已有账户";
            this.添加账户ToolStripMenuItem.Click += new System.EventHandler(this.添加账户ToolStripMenuItem_Click);
            // 
            // 编辑当前账户ToolStripMenuItem
            // 
            this.编辑当前账户ToolStripMenuItem.Name = "编辑当前账户ToolStripMenuItem";
            this.编辑当前账户ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.编辑当前账户ToolStripMenuItem.Text = "编辑当前账户";
            this.编辑当前账户ToolStripMenuItem.Click += new System.EventHandler(this.编辑当前账户ToolStripMenuItem_Click);
            // 
            // 删除当前账户ToolStripMenuItem
            // 
            this.删除当前账户ToolStripMenuItem.Name = "删除当前账户ToolStripMenuItem";
            this.删除当前账户ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除当前账户ToolStripMenuItem.Text = "删除当前账户";
            this.删除当前账户ToolStripMenuItem.Click += new System.EventHandler(this.删除当前账户ToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ListUsers);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(468, 211);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "账户信息列表";
            // 
            // ListUsers
            // 
            this.ListUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnUname,
            this.column登陆状态,
            this.column最近活动时间,
            this.columnOther});
            this.ListUsers.ContextMenuStrip = this.Cms_账户管理;
            this.ListUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListUsers.FullRowSelect = true;
            this.ListUsers.GridLines = true;
            this.ListUsers.Location = new System.Drawing.Point(3, 17);
            this.ListUsers.Name = "ListUsers";
            this.ListUsers.Size = new System.Drawing.Size(462, 187);
            this.ListUsers.TabIndex = 1;
            this.ListUsers.UseCompatibleStateImageBehavior = false;
            this.ListUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnID
            // 
            this.columnID.Text = "编号";
            this.columnID.Width = 49;
            // 
            // columnUname
            // 
            this.columnUname.Text = "用户名";
            this.columnUname.Width = 106;
            // 
            // column登陆状态
            // 
            this.column登陆状态.Text = "登陆状态";
            this.column登陆状态.Width = 98;
            // 
            // column最近活动时间
            // 
            this.column最近活动时间.Text = "最近活动时间";
            this.column最近活动时间.Width = 91;
            // 
            // columnOther
            // 
            this.columnOther.Text = "成功URL";
            this.columnOther.Width = 103;
            // 
            // Btn_Add
            // 
            this.Btn_Add.Location = new System.Drawing.Point(186, 220);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(90, 25);
            this.Btn_Add.TabIndex = 6;
            this.Btn_Add.Values.Text = "添加账户";
            this.Btn_Add.Click += new System.EventHandler(this.添加账户ToolStripMenuItem_Click);
            // 
            // Btn_LoginAll
            // 
            this.Btn_LoginAll.Location = new System.Drawing.Point(282, 220);
            this.Btn_LoginAll.Name = "Btn_LoginAll";
            this.Btn_LoginAll.Size = new System.Drawing.Size(90, 25);
            this.Btn_LoginAll.TabIndex = 7;
            this.Btn_LoginAll.Values.Text = "全部测试登陆";
            this.Btn_LoginAll.Click += new System.EventHandler(this.Btn_LoginAll_Click);
            // 
            // Btn_OK
            // 
            this.Btn_OK.Location = new System.Drawing.Point(378, 220);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(90, 25);
            this.Btn_OK.TabIndex = 8;
            this.Btn_OK.Values.Text = "确定";
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // X_Form_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 248);
            this.Controls.Add(this.Btn_OK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Btn_LoginAll);
            this.Controls.Add(this.Btn_Add);
            this.Name = "X_Form_Users";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "账户列表（请选择一个或多个账户）";
            this.Load += new System.EventHandler(this.X_Form_Users_Load);
            this.Cms_账户管理.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip Cms_账户管理;
        private System.Windows.Forms.ToolStripMenuItem 添加账户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试登陆;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 编辑当前账户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除当前账户ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView ListUsers;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnUname;
        private System.Windows.Forms.ColumnHeader column登陆状态;
        private System.Windows.Forms.ColumnHeader column最近活动时间;
        private System.Windows.Forms.ColumnHeader columnOther;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Add;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_LoginAll;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_OK;
    }
}