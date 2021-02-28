using X_Service.Ctrl;
namespace X_PostKing {
    partial class X_Form_AddTask {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X_Form_AddTask));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TS_保存 = new System.Windows.Forms.ToolStripButton();
            this.TS_取消 = new System.Windows.Forms.ToolStripButton();
            this.tool导入模块 = new System.Windows.Forms.ToolStripButton();
            this.CMS右键 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowser = new X_Service.Ctrl.FolderBrowserDialogEx();
            this.Save_File = new System.Windows.Forms.SaveFileDialog();
            this.Open_File = new System.Windows.Forms.OpenFileDialog();
            this.kryptonCheckSet任务模式 = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.CK_随机顶贴 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.CK_站群发布 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.tabPage执行计划 = new System.Windows.Forms.TabPage();
            this.ckIsPlan = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt1357d = new System.Windows.Forms.LinkLabel();
            this.txt1d = new System.Windows.Forms.LinkLabel();
            this.txt6h = new System.Windows.Forms.LinkLabel();
            this.txt2h = new System.Windows.Forms.LinkLabel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.txtBeginTime = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCronExp = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.x_Lable1 = new X_Service.Util.X_Lable();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage内容整理 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtContentLengthCut = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.x_Lable13 = new X_Service.Util.X_Lable();
            this.txtTitleLengthCut = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.x_Lable11 = new X_Service.Util.X_Lable();
            this.txtRepText = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.x_Lable10 = new X_Service.Util.X_Lable();
            this.ckTitleWYC = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.x_Lable3 = new X_Service.Util.X_Lable();
            this.btnISpicArticle = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnIsStandardization = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.x_Lable18 = new X_Service.Util.X_Lable();
            this.ckContentWYC = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.label16 = new System.Windows.Forms.Label();
            this.ckTitleInsertKeyWords = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.label19 = new System.Windows.Forms.Label();
            this.cbContentWYCLevelPercent = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.x_Lable14 = new X_Service.Util.X_Lable();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtLinkMaxNum = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtKeyWordBetween = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnEinsert = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnBinsert = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnKeyWord = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtPostCateIDs = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny4 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.x_Lable9 = new X_Service.Util.X_Lable();
            this.x_Lable8 = new X_Service.Util.X_Lable();
            this.x_Lable7 = new X_Service.Util.X_Lable();
            this.x_Lable6 = new X_Service.Util.X_Lable();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage网络抓取 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPostModuleDown = new System.Windows.Forms.LinkLabel();
            this.label25 = new System.Windows.Forms.Label();
            this.x_Lable21 = new X_Service.Util.X_Lable();
            this.txtLeftNum = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.btnEditPick = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNewPick = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.listModule = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
            this.x_Lable2 = new X_Service.Util.X_Lable();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtPickPageStartNum = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtPickPageNums = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtPickMinContentNum = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtPickKeyword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny3 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.x_Lable17 = new X_Service.Util.X_Lable();
            this.label9 = new System.Windows.Forms.Label();
            this.x_Lable16 = new X_Service.Util.X_Lable();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.x_Lable12 = new X_Service.Util.X_Lable();
            this.lbMinLength = new System.Windows.Forms.Label();
            this.lbPickKeyWord = new System.Windows.Forms.Label();
            this.tabPage任务基本 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.x_Lable24 = new X_Service.Util.X_Lable();
            this.txtUserIDs = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.x_Lable23 = new X_Service.Util.X_Lable();
            this.ckIsArtDel = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnAutoDT = new System.Windows.Forms.LinkLabel();
            this.txtPostNumInfo = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtperNum = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTaskName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txt任务备注 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtSavePath = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.x_Lable5 = new X_Service.Util.X_Lable();
            this.x_Lable4 = new X_Service.Util.X_Lable();
            this.label1 = new System.Windows.Forms.Label();
            this.ckEditSavePath = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Text_SiteName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage任务断言库 = new System.Windows.Forms.TabPage();
            this.ckIsSentence = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.x_Lable20 = new X_Service.Util.X_Lable();
            this.listBoxSentence = new System.Windows.Forms.ListBox();
            this.ckIsSentenceAuto = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnIsBuidArticle = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.x_Lable19 = new X_Service.Util.X_Lable();
            this.txtSentenceInsertBetween = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.x_Lable15 = new X_Service.Util.X_Lable();
            this.txtSentenceMinLength = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDYdelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDYoutput = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDYinput = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.CMS右键.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet任务模式)).BeginInit();
            this.tabPage执行计划.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage内容整理.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage网络抓取.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage任务基本.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage任务断言库.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Size = new System.Drawing.Size(577, 50);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_保存,
            this.TS_取消,
            this.tool导入模块});
            this.toolStrip1.Location = new System.Drawing.Point(0, 50);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(577, 39);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TS_保存
            // 
            this.TS_保存.Image = ((System.Drawing.Image)(resources.GetObject("TS_保存.Image")));
            this.TS_保存.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_保存.Name = "TS_保存";
            this.TS_保存.Size = new System.Drawing.Size(67, 36);
            this.TS_保存.Text = "保存";
            this.TS_保存.Click += new System.EventHandler(this.TS_保存_Click);
            // 
            // TS_取消
            // 
            this.TS_取消.Image = ((System.Drawing.Image)(resources.GetObject("TS_取消.Image")));
            this.TS_取消.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_取消.Name = "TS_取消";
            this.TS_取消.Size = new System.Drawing.Size(67, 36);
            this.TS_取消.Text = "取消";
            this.TS_取消.Click += new System.EventHandler(this.TS_取消_Click);
            // 
            // tool导入模块
            // 
            this.tool导入模块.Image = ((System.Drawing.Image)(resources.GetObject("tool导入模块.Image")));
            this.tool导入模块.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool导入模块.Name = "tool导入模块";
            this.tool导入模块.Size = new System.Drawing.Size(91, 36);
            this.tool导入模块.Text = "装载模块";
            this.tool导入模块.Click += new System.EventHandler(this.tool导入抓取模块_Click);
            // 
            // CMS右键
            // 
            this.CMS右键.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件夹ToolStripMenuItem});
            this.CMS右键.Name = "CMS右键";
            this.CMS右键.Size = new System.Drawing.Size(137, 26);
            this.CMS右键.Text = "打开文件夹";
            // 
            // 打开文件夹ToolStripMenuItem
            // 
            this.打开文件夹ToolStripMenuItem.Name = "打开文件夹ToolStripMenuItem";
            this.打开文件夹ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开文件夹ToolStripMenuItem.Text = "打开文件夹";
            this.打开文件夹ToolStripMenuItem.Click += new System.EventHandler(this.打开文件夹ToolStripMenuItem_Click);
            // 
            // folderBrowser
            // 
            this.folderBrowser.Description = "";
            this.folderBrowser.RootFolder = System.Environment.SpecialFolder.Desktop;
            this.folderBrowser.RootFolderPath = "";
            this.folderBrowser.SelectedPath = "";
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // Open_File
            // 
            this.Open_File.FileName = "openFileDialog1";
            // 
            // kryptonCheckSet任务模式
            // 
            this.kryptonCheckSet任务模式.CheckButtons.Add(this.CK_随机顶贴);
            this.kryptonCheckSet任务模式.CheckButtons.Add(this.CK_站群发布);
            this.kryptonCheckSet任务模式.CheckedButton = this.CK_站群发布;
            // 
            // CK_随机顶贴
            // 
            this.CK_随机顶贴.Location = new System.Drawing.Point(199, 43);
            this.CK_随机顶贴.Name = "CK_随机顶贴";
            this.CK_随机顶贴.Size = new System.Drawing.Size(90, 25);
            this.CK_随机顶贴.TabIndex = 27;
            this.CK_随机顶贴.Values.Text = "随机顶贴";
            this.CK_随机顶贴.Click += new System.EventHandler(this.CK_随机顶贴_CheckedChanged);
            this.CK_随机顶贴.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CK_站群发布_MouseClick);
            // 
            // CK_站群发布
            // 
            this.CK_站群发布.Checked = true;
            this.CK_站群发布.Location = new System.Drawing.Point(103, 43);
            this.CK_站群发布.Name = "CK_站群发布";
            this.CK_站群发布.Size = new System.Drawing.Size(90, 25);
            this.CK_站群发布.TabIndex = 26;
            this.CK_站群发布.Values.Text = "站群发布";
            this.CK_站群发布.Click += new System.EventHandler(this.CK_随机顶贴_CheckedChanged);
            this.CK_站群发布.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CK_站群发布_MouseClick);
            // 
            // tabPage执行计划
            // 
            this.tabPage执行计划.Controls.Add(this.ckIsPlan);
            this.tabPage执行计划.Controls.Add(this.groupBox4);
            this.tabPage执行计划.Location = new System.Drawing.Point(4, 22);
            this.tabPage执行计划.Name = "tabPage执行计划";
            this.tabPage执行计划.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage执行计划.Size = new System.Drawing.Size(569, 344);
            this.tabPage执行计划.TabIndex = 5;
            this.tabPage执行计划.Text = "发布执行计划";
            this.tabPage执行计划.UseVisualStyleBackColor = true;
            // 
            // ckIsPlan
            // 
            this.ckIsPlan.AutoSize = true;
            this.ckIsPlan.BackColor = System.Drawing.Color.Transparent;
            this.ckIsPlan.Checked = true;
            this.ckIsPlan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsPlan.Location = new System.Drawing.Point(11, 2);
            this.ckIsPlan.Name = "ckIsPlan";
            this.ckIsPlan.Size = new System.Drawing.Size(144, 16);
            this.ckIsPlan.TabIndex = 11;
            this.ckIsPlan.Text = "是否启动发布执行计划";
            this.ckIsPlan.UseVisualStyleBackColor = false;
            this.ckIsPlan.CheckedChanged += new System.EventHandler(this.ckIsPlan_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt1357d);
            this.groupBox4.Controls.Add(this.txt1d);
            this.groupBox4.Controls.Add(this.txt6h);
            this.groupBox4.Controls.Add(this.txt2h);
            this.groupBox4.Controls.Add(this.kryptonWrapLabel1);
            this.groupBox4.Controls.Add(this.txtBeginTime);
            this.groupBox4.Controls.Add(this.txtCronExp);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.x_Lable1);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(563, 209);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // txt1357d
            // 
            this.txt1357d.AutoSize = true;
            this.txt1357d.Location = new System.Drawing.Point(358, 85);
            this.txt1357d.Name = "txt1357d";
            this.txt1357d.Size = new System.Drawing.Size(119, 12);
            this.txt1357d.TabIndex = 16;
            this.txt1357d.TabStop = true;
            this.txt1357d.Text = "[每周1357或246触发]";
            this.txt1357d.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txt1357d_LinkClicked);
            // 
            // txt1d
            // 
            this.txt1d.AutoSize = true;
            this.txt1d.Location = new System.Drawing.Point(277, 85);
            this.txt1d.Name = "txt1d";
            this.txt1d.Size = new System.Drawing.Size(77, 12);
            this.txt1d.TabIndex = 15;
            this.txt1d.TabStop = true;
            this.txt1d.Text = "[每日间触发]";
            this.txt1d.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txt1d_LinkClicked);
            // 
            // txt6h
            // 
            this.txt6h.AutoSize = true;
            this.txt6h.Location = new System.Drawing.Point(178, 85);
            this.txt6h.Name = "txt6h";
            this.txt6h.Size = new System.Drawing.Size(95, 12);
            this.txt6h.TabIndex = 15;
            this.txt6h.TabStop = true;
            this.txt6h.Text = "[每6小时内触发]";
            this.txt6h.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txt6h_LinkClicked);
            // 
            // txt2h
            // 
            this.txt2h.AutoSize = true;
            this.txt2h.Location = new System.Drawing.Point(79, 85);
            this.txt2h.Name = "txt2h";
            this.txt2h.Size = new System.Drawing.Size(95, 12);
            this.txt2h.TabIndex = 14;
            this.txt2h.TabStop = true;
            this.txt2h.Text = "[每2小时内触发]";
            this.txt2h.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txt2h_LinkClicked);
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(83)))), ((int)(((byte)(92)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(27, 109);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(505, 75);
            this.kryptonWrapLabel1.Text = "脚本说明：忍者的任务执行表达式的规则，由4个子表达式组成的字符串，每个子表达式都描述\r\n了一个单独的日程细节。\r\n\r\n键值含义：天 小时 分钟 秒。\r\n例如：我计" +
                "划设置任务的执行间隔是：1天2小时30分钟，那么表达式为：1 2 30 0";
            // 
            // txtBeginTime
            // 
            this.txtBeginTime.Location = new System.Drawing.Point(125, 26);
            this.txtBeginTime.Name = "txtBeginTime";
            this.txtBeginTime.Size = new System.Drawing.Size(282, 20);
            this.txtBeginTime.TabIndex = 12;
            // 
            // txtCronExp
            // 
            this.txtCronExp.Location = new System.Drawing.Point(125, 52);
            this.txtCronExp.Name = "txtCronExp";
            this.txtCronExp.Size = new System.Drawing.Size(282, 20);
            this.txtCronExp.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "任务开始时间：";
            // 
            // x_Lable1
            // 
            this.x_Lable1.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable1.Location = new System.Drawing.Point(413, 54);
            this.x_Lable1.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable1.Name = "x_Lable1";
            this.x_Lable1.ShowControl = this.txtCronExp;
            this.x_Lable1.ShowText = "执行表达式是一种高级任务执行脚本语句。每个键值都有不同的含义哦。";
            this.x_Lable1.ShowTitle = "执行表达式";
            this.x_Lable1.Size = new System.Drawing.Size(22, 17);
            this.x_Lable1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "执行间隔表达式：";
            // 
            // tabPage内容整理
            // 
            this.tabPage内容整理.Controls.Add(this.groupBox6);
            this.tabPage内容整理.Controls.Add(this.groupBox5);
            this.tabPage内容整理.Location = new System.Drawing.Point(4, 22);
            this.tabPage内容整理.Name = "tabPage内容整理";
            this.tabPage内容整理.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage内容整理.Size = new System.Drawing.Size(569, 344);
            this.tabPage内容整理.TabIndex = 2;
            this.tabPage内容整理.Text = "发布内容整理";
            this.tabPage内容整理.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtContentLengthCut);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.x_Lable13);
            this.groupBox6.Controls.Add(this.txtTitleLengthCut);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.x_Lable11);
            this.groupBox6.Controls.Add(this.txtRepText);
            this.groupBox6.Controls.Add(this.x_Lable10);
            this.groupBox6.Controls.Add(this.x_Lable3);
            this.groupBox6.Controls.Add(this.btnISpicArticle);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.btnIsStandardization);
            this.groupBox6.Controls.Add(this.x_Lable18);
            this.groupBox6.Controls.Add(this.ckContentWYC);
            this.groupBox6.Controls.Add(this.ckTitleWYC);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.ckTitleInsertKeyWords);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.cbContentWYCLevelPercent);
            this.groupBox6.Controls.Add(this.x_Lable14);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 123);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(563, 154);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "原创化处理";
            // 
            // txtContentLengthCut
            // 
            this.txtContentLengthCut.AlwaysActive = false;
            this.txtContentLengthCut.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtContentLengthCut.Location = new System.Drawing.Point(431, 116);
            this.txtContentLengthCut.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtContentLengthCut.Name = "txtContentLengthCut";
            this.txtContentLengthCut.Size = new System.Drawing.Size(49, 22);
            this.txtContentLengthCut.TabIndex = 51;
            this.txtContentLengthCut.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(370, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 52;
            this.label12.Text = "正文截断：";
            // 
            // x_Lable13
            // 
            this.x_Lable13.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable13.Location = new System.Drawing.Point(486, 119);
            this.x_Lable13.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable13.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable13.Name = "x_Lable13";
            this.x_Lable13.ShowControl = this.txtContentLengthCut;
            this.x_Lable13.ShowText = "截断：当正文字数超过这个字节，那么就按此字节截取。";
            this.x_Lable13.ShowTitle = "开启【正文截断】";
            this.x_Lable13.Size = new System.Drawing.Size(22, 17);
            this.x_Lable13.TabIndex = 50;
            // 
            // txtTitleLengthCut
            // 
            this.txtTitleLengthCut.AlwaysActive = false;
            this.txtTitleLengthCut.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtTitleLengthCut.Location = new System.Drawing.Point(443, 21);
            this.txtTitleLengthCut.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtTitleLengthCut.Name = "txtTitleLengthCut";
            this.txtTitleLengthCut.Size = new System.Drawing.Size(37, 22);
            this.txtTitleLengthCut.TabIndex = 47;
            this.txtTitleLengthCut.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(406, 26);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 48;
            this.label21.Text = "截断：";
            // 
            // x_Lable11
            // 
            this.x_Lable11.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable11.Location = new System.Drawing.Point(486, 88);
            this.x_Lable11.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable11.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable11.Name = "x_Lable11";
            this.x_Lable11.ShowControl = this.txtRepText;
            this.x_Lable11.ShowText = "填入需要过滤的内容，一条一行，在发布的时候，会自动为您过滤掉，如果填写的是正则表达式，那么就会过滤匹配的内容。\r\n替换格式：正则表达式→替换值；过滤格式：正则表达" +
                "式。";
            this.x_Lable11.ShowTitle = "替换过滤库（支持正则）";
            this.x_Lable11.Size = new System.Drawing.Size(22, 17);
            this.x_Lable11.TabIndex = 45;
            // 
            // txtRepText
            // 
            this.txtRepText.Location = new System.Drawing.Point(294, 84);
            this.txtRepText.Name = "txtRepText";
            this.txtRepText.Size = new System.Drawing.Size(186, 25);
            this.txtRepText.TabIndex = 44;
            this.txtRepText.Values.Text = "替换过滤库（支持正则）";
            this.txtRepText.Click += new System.EventHandler(this.txtRepText_Click);
            // 
            // x_Lable10
            // 
            this.x_Lable10.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable10.Location = new System.Drawing.Point(486, 24);
            this.x_Lable10.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable10.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable10.Name = "x_Lable10";
            this.x_Lable10.ShowControl = this.ckTitleWYC;
            this.x_Lable10.ShowText = "开启标题正规化+伪原创，之后，标题字数过少，系统会重拟标题。\r\n截断：当标题超过这个字节，那么就按此字节截取。";
            this.x_Lable10.ShowTitle = "伪原创程度";
            this.x_Lable10.Size = new System.Drawing.Size(22, 17);
            this.x_Lable10.TabIndex = 43;
            // 
            // ckTitleWYC
            // 
            this.ckTitleWYC.Checked = true;
            this.ckTitleWYC.Location = new System.Drawing.Point(264, 20);
            this.ckTitleWYC.Name = "ckTitleWYC";
            this.ckTitleWYC.Size = new System.Drawing.Size(135, 25);
            this.ckTitleWYC.TabIndex = 23;
            this.ckTitleWYC.Values.Text = "[标题] 正规化+伪原创";
            // 
            // x_Lable3
            // 
            this.x_Lable3.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable3.Location = new System.Drawing.Point(264, 119);
            this.x_Lable3.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable3.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable3.Name = "x_Lable3";
            this.x_Lable3.ShowControl = this.btnISpicArticle;
            this.x_Lable3.ShowText = "在采集的正文中随机插入一张相关性图片，根据您的需要决定是否开启。";
            this.x_Lable3.ShowTitle = "图片正文";
            this.x_Lable3.Size = new System.Drawing.Size(22, 17);
            this.x_Lable3.TabIndex = 42;
            // 
            // btnISpicArticle
            // 
            this.btnISpicArticle.Location = new System.Drawing.Point(125, 115);
            this.btnISpicArticle.Name = "btnISpicArticle";
            this.btnISpicArticle.Size = new System.Drawing.Size(131, 25);
            this.btnISpicArticle.TabIndex = 41;
            this.btnISpicArticle.Values.Text = "发布时 随机插入图片";
            this.btnISpicArticle.Click += new System.EventHandler(this.btnISpicArticle_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(54, 121);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 40;
            this.label17.Text = "图片正文：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(54, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 39;
            this.label14.Text = "正文处理：";
            // 
            // btnIsStandardization
            // 
            this.btnIsStandardization.Checked = true;
            this.btnIsStandardization.Location = new System.Drawing.Point(125, 84);
            this.btnIsStandardization.Name = "btnIsStandardization";
            this.btnIsStandardization.Size = new System.Drawing.Size(131, 25);
            this.btnIsStandardization.TabIndex = 38;
            this.btnIsStandardization.Values.Text = "[正文] 正规化处理";
            this.btnIsStandardization.Click += new System.EventHandler(this.ckStandardization_CheckedChanged);
            // 
            // x_Lable18
            // 
            this.x_Lable18.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable18.Location = new System.Drawing.Point(264, 88);
            this.x_Lable18.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable18.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable18.Name = "x_Lable18";
            this.x_Lable18.ShowControl = this.btnIsStandardization;
            this.x_Lable18.ShowText = "开启此项将剔除HTML标签，并重新排版，经过正规化处理的文字，段落，换行，HTML标记，URL，会变得整齐有序。\r\n也就相当于整理正文的意思。";
            this.x_Lable18.ShowTitle = "正规话处理";
            this.x_Lable18.Size = new System.Drawing.Size(22, 17);
            this.x_Lable18.TabIndex = 37;
            // 
            // ckContentWYC
            // 
            this.ckContentWYC.Checked = true;
            this.ckContentWYC.Location = new System.Drawing.Point(125, 51);
            this.ckContentWYC.Name = "ckContentWYC";
            this.ckContentWYC.Size = new System.Drawing.Size(131, 25);
            this.ckContentWYC.TabIndex = 24;
            this.ckContentWYC.Values.Text = "[正文] 伪原创";
            this.ckContentWYC.Click += new System.EventHandler(this.ckContentWYC_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(30, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 12);
            this.label16.TabIndex = 22;
            this.label16.Text = "标题处理选项：";
            // 
            // ckTitleInsertKeyWords
            // 
            this.ckTitleInsertKeyWords.Location = new System.Drawing.Point(125, 20);
            this.ckTitleInsertKeyWords.Name = "ckTitleInsertKeyWords";
            this.ckTitleInsertKeyWords.Size = new System.Drawing.Size(131, 25);
            this.ckTitleInsertKeyWords.TabIndex = 21;
            this.ckTitleInsertKeyWords.Values.Text = "随机关键词+[标题]";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(30, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 12);
            this.label19.TabIndex = 20;
            this.label19.Text = "正文处理选项：";
            // 
            // cbContentWYCLevelPercent
            // 
            this.cbContentWYCLevelPercent.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.TabDock;
            this.cbContentWYCLevelPercent.DrawBackground = true;
            this.cbContentWYCLevelPercent.LargeChange = 20;
            this.cbContentWYCLevelPercent.Location = new System.Drawing.Point(264, 53);
            this.cbContentWYCLevelPercent.Maximum = 100;
            this.cbContentWYCLevelPercent.Name = "cbContentWYCLevelPercent";
            this.cbContentWYCLevelPercent.Size = new System.Drawing.Size(216, 20);
            this.cbContentWYCLevelPercent.SmallChange = 20;
            this.cbContentWYCLevelPercent.TabIndex = 19;
            this.cbContentWYCLevelPercent.TickFrequency = 20;
            this.cbContentWYCLevelPercent.TrackBarSize = ComponentFactory.Krypton.Toolkit.PaletteTrackBarSize.Small;
            this.cbContentWYCLevelPercent.Value = 20;
            this.cbContentWYCLevelPercent.VolumeControl = true;
            // 
            // x_Lable14
            // 
            this.x_Lable14.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable14.Location = new System.Drawing.Point(486, 55);
            this.x_Lable14.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable14.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable14.Name = "x_Lable14";
            this.x_Lable14.ShowControl = this.ckContentWYC;
            this.x_Lable14.ShowText = "伪原创设置，可以有效的提高搜索引擎的搜录哦。伪原创的程度需要您自己把握。\r\n从0-50%，伪原创的程度越高则效果越好，但会影响可读性。";
            this.x_Lable14.ShowTitle = "伪原创程度";
            this.x_Lable14.Size = new System.Drawing.Size(22, 17);
            this.x_Lable14.TabIndex = 14;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtLinkMaxNum);
            this.groupBox5.Controls.Add(this.txtKeyWordBetween);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.btnEinsert);
            this.groupBox5.Controls.Add(this.btnBinsert);
            this.groupBox5.Controls.Add(this.btnKeyWord);
            this.groupBox5.Controls.Add(this.txtPostCateIDs);
            this.groupBox5.Controls.Add(this.x_Lable9);
            this.groupBox5.Controls.Add(this.x_Lable8);
            this.groupBox5.Controls.Add(this.x_Lable7);
            this.groupBox5.Controls.Add(this.x_Lable6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(563, 120);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "文章内容处理";
            // 
            // txtLinkMaxNum
            // 
            this.txtLinkMaxNum.AlwaysActive = false;
            this.txtLinkMaxNum.Enabled = false;
            this.txtLinkMaxNum.Location = new System.Drawing.Point(443, 53);
            this.txtLinkMaxNum.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtLinkMaxNum.Name = "txtLinkMaxNum";
            this.txtLinkMaxNum.Size = new System.Drawing.Size(37, 22);
            this.txtLinkMaxNum.TabIndex = 47;
            this.txtLinkMaxNum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // txtKeyWordBetween
            // 
            this.txtKeyWordBetween.AlwaysActive = false;
            this.txtKeyWordBetween.Enabled = false;
            this.txtKeyWordBetween.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtKeyWordBetween.Location = new System.Drawing.Point(368, 53);
            this.txtKeyWordBetween.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtKeyWordBetween.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.txtKeyWordBetween.Name = "txtKeyWordBetween";
            this.txtKeyWordBetween.Size = new System.Drawing.Size(37, 22);
            this.txtKeyWordBetween.TabIndex = 47;
            this.txtKeyWordBetween.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(408, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 12);
            this.label26.TabIndex = 48;
            this.label26.Text = "上限：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(309, 58);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 48;
            this.label20.Text = "插入间隔：";
            // 
            // btnEinsert
            // 
            this.btnEinsert.Location = new System.Drawing.Point(294, 84);
            this.btnEinsert.Name = "btnEinsert";
            this.btnEinsert.Size = new System.Drawing.Size(186, 25);
            this.btnEinsert.TabIndex = 3;
            this.btnEinsert.Values.Text = "文章尾部插入内容";
            this.btnEinsert.Click += new System.EventHandler(this.btnEinsert_Click);
            // 
            // btnBinsert
            // 
            this.btnBinsert.Location = new System.Drawing.Point(56, 84);
            this.btnBinsert.Name = "btnBinsert";
            this.btnBinsert.Size = new System.Drawing.Size(186, 25);
            this.btnBinsert.TabIndex = 3;
            this.btnBinsert.Values.Text = "文章头部插入内容";
            this.btnBinsert.Click += new System.EventHandler(this.btnBinsert_Click);
            // 
            // btnKeyWord
            // 
            this.btnKeyWord.Location = new System.Drawing.Point(56, 52);
            this.btnKeyWord.Name = "btnKeyWord";
            this.btnKeyWord.Size = new System.Drawing.Size(247, 25);
            this.btnKeyWord.TabIndex = 13;
            this.btnKeyWord.Values.Text = "标题正文 [长尾记录单] 管理";
            this.btnKeyWord.Click += new System.EventHandler(this.btnKeyWords_Click);
            // 
            // txtPostCateIDs
            // 
            this.txtPostCateIDs.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny4});
            this.txtPostCateIDs.Location = new System.Drawing.Point(125, 26);
            this.txtPostCateIDs.Name = "txtPostCateIDs";
            this.txtPostCateIDs.Size = new System.Drawing.Size(355, 20);
            this.txtPostCateIDs.TabIndex = 12;
            // 
            // buttonSpecAny4
            // 
            this.buttonSpecAny4.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowRight;
            this.buttonSpecAny4.UniqueName = "C7681274ADA54BE4FCA145B6C26E5935";
            this.buttonSpecAny4.Click += new System.EventHandler(this.txtPostCateIDs_DoubleClick);
            // 
            // x_Lable9
            // 
            this.x_Lable9.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable9.Location = new System.Drawing.Point(486, 56);
            this.x_Lable9.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable9.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable9.Name = "x_Lable9";
            this.x_Lable9.ShowControl = this.btnKeyWord;
            this.x_Lable9.ShowText = "长尾记录单：这些关键词或关键词链接，任务将随机插入正文中。有效的起到提高网站内链。\r\n插入间隔，一般设置为20即可，越大则插入的越稀疏。\r\n上限：根据您对SEO认" +
                "识来设定，一篇内容中最大出现的连接数，默认是5个。";
            this.x_Lable9.ShowTitle = "长尾记录单";
            this.x_Lable9.Size = new System.Drawing.Size(22, 17);
            this.x_Lable9.TabIndex = 11;
            // 
            // x_Lable8
            // 
            this.x_Lable8.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable8.Location = new System.Drawing.Point(486, 28);
            this.x_Lable8.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable8.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable8.Name = "x_Lable8";
            this.x_Lable8.ShowControl = this.txtPostCateIDs;
            this.x_Lable8.ShowText = "发送到网站上的分类ID，可以通过>>这个图标来登录网站选择。";
            this.x_Lable8.ShowTitle = "请选择分类";
            this.x_Lable8.Size = new System.Drawing.Size(22, 17);
            this.x_Lable8.TabIndex = 10;
            // 
            // x_Lable7
            // 
            this.x_Lable7.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable7.Location = new System.Drawing.Point(248, 88);
            this.x_Lable7.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable7.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable7.Name = "x_Lable7";
            this.x_Lable7.ShowControl = this.btnBinsert;
            this.x_Lable7.ShowText = "在每篇文章的头部都插入固定的内容，可以是一些链接等。";
            this.x_Lable7.ShowTitle = "文章头部插入内容";
            this.x_Lable7.Size = new System.Drawing.Size(22, 17);
            this.x_Lable7.TabIndex = 9;
            // 
            // x_Lable6
            // 
            this.x_Lable6.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable6.Location = new System.Drawing.Point(486, 88);
            this.x_Lable6.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable6.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable6.Name = "x_Lable6";
            this.x_Lable6.ShowControl = this.btnEinsert;
            this.x_Lable6.ShowText = "例如：每篇文章，都要统一版权信息，可以插入固定的内容。";
            this.x_Lable6.ShowTitle = "文章尾部插入的内容";
            this.x_Lable6.Size = new System.Drawing.Size(22, 17);
            this.x_Lable6.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "分类选择：";
            // 
            // tabPage网络抓取
            // 
            this.tabPage网络抓取.Controls.Add(this.groupBox1);
            this.tabPage网络抓取.Location = new System.Drawing.Point(4, 22);
            this.tabPage网络抓取.Name = "tabPage网络抓取";
            this.tabPage网络抓取.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage网络抓取.Size = new System.Drawing.Size(569, 344);
            this.tabPage网络抓取.TabIndex = 1;
            this.tabPage网络抓取.Text = "网络抓取设定";
            this.tabPage网络抓取.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPostModuleDown);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.x_Lable21);
            this.groupBox1.Controls.Add(this.txtLeftNum);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.btnEditPick);
            this.groupBox1.Controls.Add(this.btnNewPick);
            this.groupBox1.Controls.Add(this.listModule);
            this.groupBox1.Controls.Add(this.x_Lable2);
            this.groupBox1.Controls.Add(this.kryptonButton1);
            this.groupBox1.Controls.Add(this.txtPickPageStartNum);
            this.groupBox1.Controls.Add(this.txtPickPageNums);
            this.groupBox1.Controls.Add(this.txtPickMinContentNum);
            this.groupBox1.Controls.Add(this.txtPickKeyword);
            this.groupBox1.Controls.Add(this.x_Lable17);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.x_Lable16);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.x_Lable12);
            this.groupBox1.Controls.Add(this.lbMinLength);
            this.groupBox1.Controls.Add(this.lbPickKeyWord);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "抓取基本信息";
            // 
            // lbPostModuleDown
            // 
            this.lbPostModuleDown.AutoSize = true;
            this.lbPostModuleDown.Location = new System.Drawing.Point(341, 97);
            this.lbPostModuleDown.Name = "lbPostModuleDown";
            this.lbPostModuleDown.Size = new System.Drawing.Size(53, 12);
            this.lbPostModuleDown.TabIndex = 43;
            this.lbPostModuleDown.TabStop = true;
            this.lbPostModuleDown.Text = "模块市场";
            this.lbPostModuleDown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbPostModuleDown_LinkClicked);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(169, 183);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 12);
            this.label25.TabIndex = 42;
            this.label25.Text = "到";
            // 
            // x_Lable21
            // 
            this.x_Lable21.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable21.Location = new System.Drawing.Point(259, 209);
            this.x_Lable21.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable21.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable21.Name = "x_Lable21";
            this.x_Lable21.ShowControl = this.txtLeftNum;
            this.x_Lable21.ShowText = "当任务中的文章少于这个数量，那么将触发采集。";
            this.x_Lable21.ShowTitle = "续航数量";
            this.x_Lable21.Size = new System.Drawing.Size(22, 17);
            this.x_Lable21.TabIndex = 41;
            // 
            // txtLeftNum
            // 
            this.txtLeftNum.AlwaysActive = false;
            this.txtLeftNum.Location = new System.Drawing.Point(103, 206);
            this.txtLeftNum.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtLeftNum.Name = "txtLeftNum";
            this.txtLeftNum.ReadOnly = true;
            this.txtLeftNum.Size = new System.Drawing.Size(149, 22);
            this.txtLeftNum.TabIndex = 40;
            this.txtLeftNum.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(20, 211);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 12);
            this.label24.TabIndex = 39;
            this.label24.Text = "续航文章量：";
            // 
            // btnEditPick
            // 
            this.btnEditPick.Location = new System.Drawing.Point(222, 91);
            this.btnEditPick.Name = "btnEditPick";
            this.btnEditPick.Size = new System.Drawing.Size(113, 25);
            this.btnEditPick.TabIndex = 37;
            this.btnEditPick.Values.Text = "编辑当前模块";
            this.btnEditPick.Click += new System.EventHandler(this.btnEditPick_Click);
            // 
            // btnNewPick
            // 
            this.btnNewPick.Location = new System.Drawing.Point(103, 91);
            this.btnNewPick.Name = "btnNewPick";
            this.btnNewPick.Size = new System.Drawing.Size(113, 25);
            this.btnNewPick.TabIndex = 36;
            this.btnNewPick.Values.Text = "新建抓取模块";
            this.btnNewPick.Click += new System.EventHandler(this.btnNewPick_Click);
            // 
            // listModule
            // 
            this.listModule.Location = new System.Drawing.Point(103, 20);
            this.listModule.Name = "listModule";
            this.listModule.ScrollAlwaysVisible = true;
            this.listModule.Size = new System.Drawing.Size(416, 65);
            this.listModule.TabIndex = 34;
            // 
            // x_Lable2
            // 
            this.x_Lable2.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable2.Location = new System.Drawing.Point(525, 24);
            this.x_Lable2.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable2.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable2.Name = "x_Lable2";
            this.x_Lable2.ShowControl = this.listModule;
            this.x_Lable2.ShowText = "点击装载模块按钮即可加入抓取模块。\r\n各种抓取模块的文章来源质量略有不同，请根据您的需要来选择或自定义。";
            this.x_Lable2.ShowTitle = "模块选择";
            this.x_Lable2.Size = new System.Drawing.Size(22, 17);
            this.x_Lable2.TabIndex = 33;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(287, 150);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(232, 51);
            this.kryptonButton1.TabIndex = 32;
            this.kryptonButton1.Values.ExtraText = "查看内容\r\n打开文本文件夹";
            this.kryptonButton1.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton1.Values.Image")));
            this.kryptonButton1.Values.Text = "";
            this.kryptonButton1.Click += new System.EventHandler(this.btnOpenSavePath_Click);
            // 
            // txtPickPageStartNum
            // 
            this.txtPickPageStartNum.AlwaysActive = false;
            this.txtPickPageStartNum.Location = new System.Drawing.Point(103, 178);
            this.txtPickPageStartNum.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.txtPickPageStartNum.Name = "txtPickPageStartNum";
            this.txtPickPageStartNum.ReadOnly = true;
            this.txtPickPageStartNum.Size = new System.Drawing.Size(60, 22);
            this.txtPickPageStartNum.TabIndex = 2;
            this.txtPickPageStartNum.ValueChanged += new System.EventHandler(this.txtPickPageStartNum_ValueChanged);
            // 
            // txtPickPageNums
            // 
            this.txtPickPageNums.AlwaysActive = false;
            this.txtPickPageNums.Location = new System.Drawing.Point(192, 178);
            this.txtPickPageNums.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.txtPickPageNums.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPickPageNums.Name = "txtPickPageNums";
            this.txtPickPageNums.ReadOnly = true;
            this.txtPickPageNums.Size = new System.Drawing.Size(60, 22);
            this.txtPickPageNums.TabIndex = 2;
            this.txtPickPageNums.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // txtPickMinContentNum
            // 
            this.txtPickMinContentNum.AlwaysActive = false;
            this.txtPickMinContentNum.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtPickMinContentNum.Location = new System.Drawing.Point(103, 150);
            this.txtPickMinContentNum.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.txtPickMinContentNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPickMinContentNum.Name = "txtPickMinContentNum";
            this.txtPickMinContentNum.ReadOnly = true;
            this.txtPickMinContentNum.Size = new System.Drawing.Size(149, 22);
            this.txtPickMinContentNum.TabIndex = 1;
            this.txtPickMinContentNum.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // txtPickKeyword
            // 
            this.txtPickKeyword.AlwaysActive = false;
            this.txtPickKeyword.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny3});
            this.txtPickKeyword.Location = new System.Drawing.Point(103, 122);
            this.txtPickKeyword.MaxLength = 327670000;
            this.txtPickKeyword.Name = "txtPickKeyword";
            this.txtPickKeyword.Size = new System.Drawing.Size(416, 20);
            this.txtPickKeyword.TabIndex = 1;
            this.txtPickKeyword.DoubleClick += new System.EventHandler(this.txtPickKeyword_DoubleClick);
            // 
            // buttonSpecAny3
            // 
            this.buttonSpecAny3.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowRight;
            this.buttonSpecAny3.UniqueName = "BAF26D9FD4644C0BCF8E294D5F19F8A1";
            this.buttonSpecAny3.Click += new System.EventHandler(this.txtPickKeyword_DoubleClick);
            // 
            // x_Lable17
            // 
            this.x_Lable17.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable17.Location = new System.Drawing.Point(259, 181);
            this.x_Lable17.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable17.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable17.Name = "x_Lable17";
            this.x_Lable17.ShowControl = this.txtPickPageNums;
            this.x_Lable17.ShowText = "一般情况下1页的文章，大约10篇左右，根据您的需求进行设定。\r\n若您勾选3个模块，这里添加2页面，那么大约采集的文章就是3*2*10=60篇左右。\r\n抓取页数替换" +
                "模块中的[连续分页]变量，一般指定的页码是1-10，即采集1-10的分页。";
            this.x_Lable17.ShowTitle = "抓取页数";
            this.x_Lable17.Size = new System.Drawing.Size(22, 17);
            this.x_Lable17.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "抓取页数：";
            // 
            // x_Lable16
            // 
            this.x_Lable16.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable16.Location = new System.Drawing.Point(259, 153);
            this.x_Lable16.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable16.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable16.Name = "x_Lable16";
            this.x_Lable16.ShowControl = this.txtPickMinContentNum;
            this.x_Lable16.ShowText = "抓取文章，需要过滤一些垃圾内容，有的内容只有100-200个字，这样的正文太短了，我们需要跳过它。\r\n那么这里设置一下最小的抓取字数，就会忽略掉字数不够的文章。";
            this.x_Lable16.ShowTitle = "最小抓取字数";
            this.x_Lable16.Size = new System.Drawing.Size(22, 17);
            this.x_Lable16.TabIndex = 24;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(32, 97);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 18;
            this.label18.Text = "模块操作：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "当前抓取模块：";
            // 
            // x_Lable12
            // 
            this.x_Lable12.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable12.Location = new System.Drawing.Point(525, 124);
            this.x_Lable12.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable12.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable12.Name = "x_Lable12";
            this.x_Lable12.ShowControl = this.txtPickKeyword;
            this.x_Lable12.ShowText = "填写这个是非常重要的，一般是用来抓取文章的直接关键词。关键词之间用英文,分割。\r\n例如：百度问答采集模块，搜索关键词：女人，女鞋，计算机，nick，adieu等。" +
                "\r\n多个关键词，会随机挑选某一个去采集抓取文章。";
            this.x_Lable12.ShowTitle = "搜索关键词";
            this.x_Lable12.Size = new System.Drawing.Size(22, 17);
            this.x_Lable12.TabIndex = 17;
            // 
            // lbMinLength
            // 
            this.lbMinLength.AutoSize = true;
            this.lbMinLength.Location = new System.Drawing.Point(32, 154);
            this.lbMinLength.Name = "lbMinLength";
            this.lbMinLength.Size = new System.Drawing.Size(65, 12);
            this.lbMinLength.TabIndex = 15;
            this.lbMinLength.Text = "最小抓取：";
            // 
            // lbPickKeyWord
            // 
            this.lbPickKeyWord.AutoSize = true;
            this.lbPickKeyWord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPickKeyWord.ForeColor = System.Drawing.Color.Black;
            this.lbPickKeyWord.Location = new System.Drawing.Point(20, 125);
            this.lbPickKeyWord.Name = "lbPickKeyWord";
            this.lbPickKeyWord.Size = new System.Drawing.Size(77, 12);
            this.lbPickKeyWord.TabIndex = 11;
            this.lbPickKeyWord.Text = "搜索关键词：";
            // 
            // tabPage任务基本
            // 
            this.tabPage任务基本.Controls.Add(this.groupBox7);
            this.tabPage任务基本.Controls.Add(this.groupBox2);
            this.tabPage任务基本.Location = new System.Drawing.Point(4, 22);
            this.tabPage任务基本.Name = "tabPage任务基本";
            this.tabPage任务基本.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage任务基本.Size = new System.Drawing.Size(569, 344);
            this.tabPage任务基本.TabIndex = 0;
            this.tabPage任务基本.Text = "任务基本信息";
            this.tabPage任务基本.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.x_Lable24);
            this.groupBox7.Controls.Add(this.txtUserIDs);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 188);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(563, 59);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "请选择可以运行这个任务的账户，点击扩展按钮选择。";
            // 
            // x_Lable24
            // 
            this.x_Lable24.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable24.Location = new System.Drawing.Point(509, 22);
            this.x_Lable24.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable24.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable24.Name = "x_Lable24";
            this.x_Lable24.ShowControl = this.txtUserIDs;
            this.x_Lable24.ShowText = "选择本任务将用到的用户，点击>>进行选择。";
            this.x_Lable24.ShowTitle = "账户选择";
            this.x_Lable24.Size = new System.Drawing.Size(22, 17);
            this.x_Lable24.TabIndex = 33;
            // 
            // txtUserIDs
            // 
            this.txtUserIDs.AlwaysActive = false;
            this.txtUserIDs.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.txtUserIDs.Location = new System.Drawing.Point(103, 20);
            this.txtUserIDs.Name = "txtUserIDs";
            this.txtUserIDs.Size = new System.Drawing.Size(400, 20);
            this.txtUserIDs.TabIndex = 2;
            this.txtUserIDs.DoubleClick += new System.EventHandler(this.txtUserIDs_DoubleClick);
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowRight;
            this.buttonSpecAny1.UniqueName = "84E870C87802498A9CB7A1C179BD2544";
            this.buttonSpecAny1.Click += new System.EventHandler(this.txtUserIDs_DoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "账户选择：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.x_Lable23);
            this.groupBox2.Controls.Add(this.ckIsArtDel);
            this.groupBox2.Controls.Add(this.btnAutoDT);
            this.groupBox2.Controls.Add(this.txtPostNumInfo);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.txtperNum);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.CK_随机顶贴);
            this.groupBox2.Controls.Add(this.CK_站群发布);
            this.groupBox2.Controls.Add(this.txtTaskName);
            this.groupBox2.Controls.Add(this.txt任务备注);
            this.groupBox2.Controls.Add(this.txtSavePath);
            this.groupBox2.Controls.Add(this.x_Lable5);
            this.groupBox2.Controls.Add(this.x_Lable4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ckEditSavePath);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Text_SiteName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 185);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本信息";
            // 
            // x_Lable23
            // 
            this.x_Lable23.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable23.Location = new System.Drawing.Point(509, 47);
            this.x_Lable23.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable23.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable23.Name = "x_Lable23";
            this.x_Lable23.ShowControl = this.ckIsArtDel;
            this.x_Lable23.ShowText = "发布时使用的文章，在发布提交过后，将自动删除！\r\n如果不选中，那么发布过的文章将保留，而造成重复发布！";
            this.x_Lable23.ShowTitle = "发布后删除";
            this.x_Lable23.Size = new System.Drawing.Size(22, 17);
            this.x_Lable23.TabIndex = 33;
            // 
            // ckIsArtDel
            // 
            this.ckIsArtDel.Checked = true;
            this.ckIsArtDel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsArtDel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.ckIsArtDel.Location = new System.Drawing.Point(417, 45);
            this.ckIsArtDel.Name = "ckIsArtDel";
            this.ckIsArtDel.Size = new System.Drawing.Size(86, 20);
            this.ckIsArtDel.TabIndex = 2;
            this.ckIsArtDel.Text = "发布后删除";
            this.ckIsArtDel.Values.Text = "发布后删除";
            // 
            // btnAutoDT
            // 
            this.btnAutoDT.AutoSize = true;
            this.btnAutoDT.Location = new System.Drawing.Point(323, 49);
            this.btnAutoDT.Name = "btnAutoDT";
            this.btnAutoDT.Size = new System.Drawing.Size(77, 12);
            this.btnAutoDT.TabIndex = 32;
            this.btnAutoDT.TabStop = true;
            this.btnAutoDT.Text = "填充顶贴内容";
            this.btnAutoDT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAutoDT_LinkClicked);
            // 
            // txtPostNumInfo
            // 
            this.txtPostNumInfo.AutoSize = true;
            this.txtPostNumInfo.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPostNumInfo.ForeColor = System.Drawing.Color.Crimson;
            this.txtPostNumInfo.Location = new System.Drawing.Point(227, 158);
            this.txtPostNumInfo.Name = "txtPostNumInfo";
            this.txtPostNumInfo.Size = new System.Drawing.Size(287, 12);
            this.txtPostNumInfo.TabIndex = 31;
            this.txtPostNumInfo.Text = "大量发布、将受百度惩罚，请按SEO的规则优化站群！";
            this.txtPostNumInfo.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(487, 129);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.btnOpenSavePath_Click);
            // 
            // txtperNum
            // 
            this.txtperNum.Location = new System.Drawing.Point(103, 153);
            this.txtperNum.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtperNum.Name = "txtperNum";
            this.txtperNum.ReadOnly = true;
            this.txtperNum.Size = new System.Drawing.Size(90, 22);
            this.txtperNum.TabIndex = 29;
            this.txtperNum.ValueChanged += new System.EventHandler(this.txtperNum_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "任务模式：";
            // 
            // txtTaskName
            // 
            this.txtTaskName.AlwaysActive = false;
            this.txtTaskName.Location = new System.Drawing.Point(103, 17);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(400, 20);
            this.txtTaskName.TabIndex = 2;
            this.txtTaskName.TextChanged += new System.EventHandler(this.txt任务名称_TextChanged);
            // 
            // txt任务备注
            // 
            this.txt任务备注.AlwaysActive = false;
            this.txt任务备注.Location = new System.Drawing.Point(103, 101);
            this.txt任务备注.Name = "txt任务备注";
            this.txt任务备注.Size = new System.Drawing.Size(400, 20);
            this.txt任务备注.TabIndex = 2;
            // 
            // txtSavePath
            // 
            this.txtSavePath.AlwaysActive = false;
            this.txtSavePath.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny2});
            this.txtSavePath.Location = new System.Drawing.Point(103, 127);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(330, 20);
            this.txtSavePath.TabIndex = 2;
            this.txtSavePath.DoubleClick += new System.EventHandler(this.txtSavePath_DoubleClick);
            // 
            // buttonSpecAny2
            // 
            this.buttonSpecAny2.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowRight;
            this.buttonSpecAny2.UniqueName = "F4B4A658664D494A698519EE1D2D40CC";
            this.buttonSpecAny2.Click += new System.EventHandler(this.txtSavePath_DoubleClick);
            // 
            // x_Lable5
            // 
            this.x_Lable5.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable5.Location = new System.Drawing.Point(295, 47);
            this.x_Lable5.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable5.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable5.Name = "x_Lable5";
            this.x_Lable5.ShowControl = this.CK_站群发布;
            this.x_Lable5.ShowText = "2种任务模式，站群发布+随机顶贴。随机顶贴内置50+顶贴语句，随机出现。";
            this.x_Lable5.ShowTitle = "任务模式";
            this.x_Lable5.Size = new System.Drawing.Size(22, 17);
            this.x_Lable5.TabIndex = 24;
            // 
            // x_Lable4
            // 
            this.x_Lable4.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable4.Location = new System.Drawing.Point(199, 156);
            this.x_Lable4.MaximumSize = new System.Drawing.Size(22, 17);
            this.x_Lable4.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable4.Name = "x_Lable4";
            this.x_Lable4.ShowControl = this.txtperNum;
            this.x_Lable4.ShowText = "该任务被触发后，每次发布的文章数量。";
            this.x_Lable4.ShowTitle = "每批数量";
            this.x_Lable4.Size = new System.Drawing.Size(22, 17);
            this.x_Lable4.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "每次发布：";
            // 
            // ckEditSavePath
            // 
            this.ckEditSavePath.AutoSize = true;
            this.ckEditSavePath.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ckEditSavePath.Checked = true;
            this.ckEditSavePath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEditSavePath.Location = new System.Drawing.Point(439, 129);
            this.ckEditSavePath.Name = "ckEditSavePath";
            this.ckEditSavePath.Size = new System.Drawing.Size(48, 16);
            this.ckEditSavePath.TabIndex = 16;
            this.ckEditSavePath.Text = "编辑";
            this.ckEditSavePath.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ckEditSavePath.UseVisualStyleBackColor = true;
            this.ckEditSavePath.CheckedChanged += new System.EventHandler(this.ckEditSavePath_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "选择路径：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "任务备注：";
            // 
            // Text_SiteName
            // 
            this.Text_SiteName.Location = new System.Drawing.Point(103, 74);
            this.Text_SiteName.Name = "Text_SiteName";
            this.Text_SiteName.ReadOnly = true;
            this.Text_SiteName.Size = new System.Drawing.Size(400, 21);
            this.Text_SiteName.TabIndex = 4;
            this.Text_SiteName.TextChanged += new System.EventHandler(this.Text_SiteName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "所属站点：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "任务名称：";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage任务基本);
            this.tabControl.Controls.Add(this.tabPage网络抓取);
            this.tabControl.Controls.Add(this.tabPage任务断言库);
            this.tabControl.Controls.Add(this.tabPage内容整理);
            this.tabControl.Controls.Add(this.tabPage执行计划);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 89);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(577, 370);
            this.tabControl.TabIndex = 6;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage任务断言库
            // 
            this.tabPage任务断言库.Controls.Add(this.ckIsSentence);
            this.tabPage任务断言库.Controls.Add(this.groupBox3);
            this.tabPage任务断言库.Location = new System.Drawing.Point(4, 22);
            this.tabPage任务断言库.Name = "tabPage任务断言库";
            this.tabPage任务断言库.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage任务断言库.Size = new System.Drawing.Size(569, 344);
            this.tabPage任务断言库.TabIndex = 6;
            this.tabPage任务断言库.Text = "任务[断言库]";
            this.tabPage任务断言库.UseVisualStyleBackColor = true;
            // 
            // ckIsSentence
            // 
            this.ckIsSentence.AutoSize = true;
            this.ckIsSentence.BackColor = System.Drawing.Color.Transparent;
            this.ckIsSentence.Checked = true;
            this.ckIsSentence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsSentence.Location = new System.Drawing.Point(9, 2);
            this.ckIsSentence.Name = "ckIsSentence";
            this.ckIsSentence.Size = new System.Drawing.Size(288, 16);
            this.ckIsSentence.TabIndex = 12;
            this.ckIsSentence.Text = "是否启动断言功能、采集数据将自动入选[断言库]";
            this.ckIsSentence.UseVisualStyleBackColor = false;
            this.ckIsSentence.CheckedChanged += new System.EventHandler(this.ckIsSentence_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.x_Lable20);
            this.groupBox3.Controls.Add(this.ckIsSentenceAuto);
            this.groupBox3.Controls.Add(this.btnIsBuidArticle);
            this.groupBox3.Controls.Add(this.x_Lable19);
            this.groupBox3.Controls.Add(this.x_Lable15);
            this.groupBox3.Controls.Add(this.txtSentenceMinLength);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.txtSentenceInsertBetween);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnDYdelete);
            this.groupBox3.Controls.Add(this.listBoxSentence);
            this.groupBox3.Controls.Add(this.btnDYoutput);
            this.groupBox3.Controls.Add(this.btnDYinput);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(563, 190);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(416, 133);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(149, 12);
            this.label23.TabIndex = 60;
            this.label23.Text = "注意：断言>500条将生效！";
            // 
            // x_Lable20
            // 
            this.x_Lable20.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable20.Location = new System.Drawing.Point(390, 131);
            this.x_Lable20.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable20.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable20.Name = "x_Lable20";
            this.x_Lable20.ShowControl = this.listBoxSentence;
            this.x_Lable20.ShowText = "各种语言的片段、组成的断言列表。";
            this.x_Lable20.ShowTitle = "这里就是断言库";
            this.x_Lable20.Size = new System.Drawing.Size(22, 17);
            this.x_Lable20.TabIndex = 59;
            // 
            // listBoxSentence
            // 
            this.listBoxSentence.FormattingEnabled = true;
            this.listBoxSentence.ItemHeight = 12;
            this.listBoxSentence.Location = new System.Drawing.Point(6, 21);
            this.listBoxSentence.Name = "listBoxSentence";
            this.listBoxSentence.ScrollAlwaysVisible = true;
            this.listBoxSentence.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSentence.Size = new System.Drawing.Size(551, 100);
            this.listBoxSentence.TabIndex = 0;
            // 
            // ckIsSentenceAuto
            // 
            this.ckIsSentenceAuto.Checked = true;
            this.ckIsSentenceAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsSentenceAuto.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.ckIsSentenceAuto.Location = new System.Drawing.Point(135, 159);
            this.ckIsSentenceAuto.Name = "ckIsSentenceAuto";
            this.ckIsSentenceAuto.Size = new System.Drawing.Size(111, 20);
            this.ckIsSentenceAuto.StateCommon.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.ckIsSentenceAuto.TabIndex = 58;
            this.ckIsSentenceAuto.Text = "采集入选断言库";
            this.ckIsSentenceAuto.Values.Text = "采集入选断言库";
            // 
            // btnIsBuidArticle
            // 
            this.btnIsBuidArticle.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.btnIsBuidArticle.Location = new System.Drawing.Point(6, 159);
            this.btnIsBuidArticle.Name = "btnIsBuidArticle";
            this.btnIsBuidArticle.Size = new System.Drawing.Size(123, 20);
            this.btnIsBuidArticle.StateCommon.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.btnIsBuidArticle.TabIndex = 57;
            this.btnIsBuidArticle.Text = "自动生成原创文章";
            this.btnIsBuidArticle.Values.Text = "自动生成原创文章";
            this.btnIsBuidArticle.CheckedChanged += new System.EventHandler(this.btnIsBuidArticle_CheckedChanged);
            this.btnIsBuidArticle.CheckStateChanged += new System.EventHandler(this.btnIsBuidArticle_CheckStateChanged);
            // 
            // x_Lable19
            // 
            this.x_Lable19.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable19.Location = new System.Drawing.Point(482, 161);
            this.x_Lable19.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable19.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable19.Name = "x_Lable19";
            this.x_Lable19.ShowControl = this.txtSentenceInsertBetween;
            this.x_Lable19.ShowText = "此数值越小，伪原创程度越高，阅读性就会下降，反之亦然。";
            this.x_Lable19.ShowTitle = "断言间隔";
            this.x_Lable19.Size = new System.Drawing.Size(22, 17);
            this.x_Lable19.TabIndex = 54;
            // 
            // txtSentenceInsertBetween
            // 
            this.txtSentenceInsertBetween.AlwaysActive = false;
            this.txtSentenceInsertBetween.Location = new System.Drawing.Point(439, 158);
            this.txtSentenceInsertBetween.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtSentenceInsertBetween.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSentenceInsertBetween.Name = "txtSentenceInsertBetween";
            this.txtSentenceInsertBetween.Size = new System.Drawing.Size(37, 22);
            this.txtSentenceInsertBetween.TabIndex = 49;
            this.txtSentenceInsertBetween.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // x_Lable15
            // 
            this.x_Lable15.BackColor = System.Drawing.Color.Transparent;
            this.x_Lable15.Location = new System.Drawing.Point(353, 161);
            this.x_Lable15.MaximumSize = new System.Drawing.Size(16, 16);
            this.x_Lable15.MinimumSize = new System.Drawing.Size(22, 17);
            this.x_Lable15.Name = "x_Lable15";
            this.x_Lable15.ShowControl = this.txtSentenceMinLength;
            this.x_Lable15.ShowText = "开启采集入选断言库，那么大于此字数的语句片段才会入库。";
            this.x_Lable15.ShowTitle = "入选字数";
            this.x_Lable15.Size = new System.Drawing.Size(22, 17);
            this.x_Lable15.TabIndex = 53;
            // 
            // txtSentenceMinLength
            // 
            this.txtSentenceMinLength.AlwaysActive = false;
            this.txtSentenceMinLength.Location = new System.Drawing.Point(310, 158);
            this.txtSentenceMinLength.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtSentenceMinLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSentenceMinLength.Name = "txtSentenceMinLength";
            this.txtSentenceMinLength.Size = new System.Drawing.Size(37, 22);
            this.txtSentenceMinLength.TabIndex = 51;
            this.txtSentenceMinLength.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(252, 163);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 52;
            this.label22.Text = "入选字数：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 50;
            this.label5.Text = "断言间隔：";
            // 
            // btnDYdelete
            // 
            this.btnDYdelete.Location = new System.Drawing.Point(262, 127);
            this.btnDYdelete.Name = "btnDYdelete";
            this.btnDYdelete.Size = new System.Drawing.Size(122, 25);
            this.btnDYdelete.TabIndex = 3;
            this.btnDYdelete.Values.Text = "删除所选断言";
            this.btnDYdelete.Click += new System.EventHandler(this.btnDYdelete_Click);
            // 
            // btnDYoutput
            // 
            this.btnDYoutput.Location = new System.Drawing.Point(134, 127);
            this.btnDYoutput.Name = "btnDYoutput";
            this.btnDYoutput.Size = new System.Drawing.Size(122, 25);
            this.btnDYoutput.TabIndex = 2;
            this.btnDYoutput.Values.Text = "导出断言库";
            this.btnDYoutput.Click += new System.EventHandler(this.btnDYoutput_Click);
            // 
            // btnDYinput
            // 
            this.btnDYinput.Location = new System.Drawing.Point(6, 127);
            this.btnDYinput.Name = "btnDYinput";
            this.btnDYinput.Size = new System.Drawing.Size(122, 25);
            this.btnDYinput.TabIndex = 1;
            this.btnDYinput.Values.Text = "导入断言库";
            this.btnDYinput.Click += new System.EventHandler(this.btnDYinput_Click);
            // 
            // X_Form_AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 484);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "X_Form_AddTask";
            this.Text = "任务管理";
            this.Load += new System.EventHandler(this.X_Form_AddTask_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.tabControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.CMS右键.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet任务模式)).EndInit();
            this.tabPage执行计划.ResumeLayout(false);
            this.tabPage执行计划.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage内容整理.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage网络抓取.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage任务基本.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage任务断言库.ResumeLayout(false);
            this.tabPage任务断言库.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TS_保存;
        private System.Windows.Forms.ToolStripButton TS_取消;
        private FolderBrowserDialogEx folderBrowser;
        private System.Windows.Forms.ContextMenuStrip CMS右键;
        private System.Windows.Forms.ToolStripMenuItem 打开文件夹ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog Save_File;
        private System.Windows.Forms.OpenFileDialog Open_File;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet kryptonCheckSet任务模式;
        private System.Windows.Forms.TabPage tabPage执行计划;
        private System.Windows.Forms.CheckBox ckIsPlan;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private X_Service.Util.X_Lable x_Lable1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage内容整理;
        private System.Windows.Forms.GroupBox groupBox6;
        private X_Service.Util.X_Lable x_Lable14;
        private System.Windows.Forms.GroupBox groupBox5;
        private X_Service.Util.X_Lable x_Lable9;
        private X_Service.Util.X_Lable x_Lable8;
        private X_Service.Util.X_Lable x_Lable7;
        private X_Service.Util.X_Lable x_Lable6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage网络抓取;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtPickPageNums;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtPickMinContentNum;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPickKeyword;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny3;
        private X_Service.Util.X_Lable x_Lable17;
        private System.Windows.Forms.Label label9;
        private X_Service.Util.X_Lable x_Lable16;
        private System.Windows.Forms.Label label8;
        private X_Service.Util.X_Lable x_Lable12;
        private System.Windows.Forms.Label lbPickKeyWord;
        private System.Windows.Forms.Label lbMinLength;
        private System.Windows.Forms.TabPage tabPage任务基本;
        private System.Windows.Forms.GroupBox groupBox7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUserIDs;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtperNum;
        private System.Windows.Forms.Label label15;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton CK_随机顶贴;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton CK_站群发布;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTaskName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt任务备注;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSavePath;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private X_Service.Util.X_Lable x_Lable5;
        private X_Service.Util.X_Lable x_Lable4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckEditSavePath;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Text_SiteName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPostCateIDs;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnKeyWord;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBinsert;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEinsert;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar cbContentWYCLevelPercent;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton ckTitleInsertKeyWords;
        private System.Windows.Forms.Label label16;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton ckTitleWYC;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton ckContentWYC;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCronExp;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBeginTime;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private X_Service.Util.X_Lable x_Lable2;
        private X_Service.Util.X_Lable x_Lable3;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnISpicArticle;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnIsStandardization;
        private X_Service.Util.X_Lable x_Lable18;
        private System.Windows.Forms.PictureBox pictureBox2;
        private X_Service.Util.X_Lable x_Lable10;
        private ComponentFactory.Krypton.Toolkit.KryptonButton txtRepText;
        private X_Service.Util.X_Lable x_Lable11;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox listModule;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNewPick;
        private System.Windows.Forms.ToolStripButton tool导入模块;
        private System.Windows.Forms.Label label18;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEditPick;
        private System.Windows.Forms.Label label19;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtKeyWordBetween;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtTitleLengthCut;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label txtPostNumInfo;
        private System.Windows.Forms.LinkLabel txt6h;
        private System.Windows.Forms.LinkLabel txt2h;
        private System.Windows.Forms.LinkLabel txt1d;
        private System.Windows.Forms.LinkLabel txt1357d;
        private X_Service.Util.X_Lable x_Lable13;
        private System.Windows.Forms.TabPage tabPage任务断言库;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBoxSentence;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDYinput;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDYoutput;
        private System.Windows.Forms.CheckBox ckIsSentence;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDYdelete;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtSentenceInsertBetween;
        private System.Windows.Forms.Label label5;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtSentenceMinLength;
        private System.Windows.Forms.Label label22;
        private X_Service.Util.X_Lable x_Lable15;
        private X_Service.Util.X_Lable x_Lable19;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox btnIsBuidArticle;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox ckIsSentenceAuto;
        private X_Service.Util.X_Lable x_Lable20;
        private System.Windows.Forms.Label label23;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtLeftNum;
        private System.Windows.Forms.Label label24;
        private X_Service.Util.X_Lable x_Lable21;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtContentLengthCut;
        private System.Windows.Forms.Label label12;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtPickPageStartNum;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.LinkLabel btnAutoDT;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox ckIsArtDel;
        private X_Service.Util.X_Lable x_Lable23;
        private X_Service.Util.X_Lable x_Lable24;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtLinkMaxNum;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.LinkLabel lbPostModuleDown;
    }
}