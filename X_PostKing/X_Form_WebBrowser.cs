using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using WebKit;
using WebKit.DOM;
using WeifenLuo.WinFormsUI.Docking;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Nodes;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;
using X_Model;
using X_PostKing.Job;
using X_Service.Files;
using X_Service.Util;

namespace X_PostKing {

    public partial class X_Form_WebBrowser : DockContent {

        public ModelTasks task;
        private ModelSite site;
        private string Url = "";

        public X_Form_WebBrowser(ModelTasks task, WebKitBrowser browser, string url) {
            InitializeComponent();

            if (!string.IsNullOrEmpty(url)) {
                Url = url;
            }

            if (!string.IsNullOrEmpty(this.Url) && !this.Url.Contains("://")) {
                this.Url = "http://" + this.Url;
            }

            if (task != null) {
                this.task = task;
                this.site = ModelMain.FindSiteByID(task.SiteID);
            }

            if (string.IsNullOrEmpty(this.Url) && this.site != null) {
                this.Url = this.site.SiteBackUrl;
            }


            this.Controls.Add(browser);
            this.browser = browser;
            this.browser.Dock = DockStyle.Fill;
            this.browser.PreviewKeyDown += new PreviewKeyDownEventHandler(BrowserPreviewKeyDown);

        }

        private void X_Form_WebBrowser_Load(object sender, EventArgs e) {
            if (this.task == null || this.site == null) {
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                groupBox1.Visible = false;
                groupBox3.Visible = false;
            } else {
                groupBox1.Enabled = true;
                groupBox3.Enabled = true;
                groupBox1.Visible = true;
                groupBox3.Visible = true;
            }
            countArticle();

            AddEvents(this.browser);
            if (!string.IsNullOrEmpty(this.Url)) {
                OpenUrl(this.Url);
            }

        }

        private void countArticle() {
            try {
                int artcount = FilesHelper.ReadDirectory(Application.StartupPath + this.task.SavePath).Count;
                groupTools.ValuesSecondary.Heading = "本任务共有" + artcount + "篇文章";
                EchoHelper.Echo("重新计算本任务中的剩余文章量，为：" + artcount, "剩余文章", EchoHelper.EchoType.任务信息);

            } catch (Exception) {
                groupTools.ValuesSecondary.Heading = "欢迎使用快捷工具箱";
            }
        }

        private void OpenUrl(string url) {
            browser.Navigate(url);
        }

        #region 辅助填单系统。
        /// <summary>
        /// 加载填写表单
        /// </summary>
        /// <param name="regexs"></param>
        /// <param name="isContentPut">是否需要获取文件的内容</param>
        private void LoadAutoInput(string regexs, bool isContentPut) {
            if (browser.Url != null && browser.Url.ToString().Contains("www.renzhe.org")) {
                EchoHelper.Echo("禁止对官方网站进行灌水操作！", "填写表单", EchoHelper.EchoType.错误信息);
                return;
            }
            JobWebBrowser JobBrowser = new Job.JobWebBrowser(site, task);
            string newRegexs = "";
            string newRegex = "";
            newRegexs = JobBrowser._replace(regexs);
            if (isContentPut) {
                newRegexs = JobBrowser._replacePutContent(newRegexs, Encoding.UTF8);
            }

            string[] reg01 = newRegexs.Split('\n');
            ArrayList al = new ArrayList();

            for (int i = 0; i < reg01.Length; i++) {
                if (!string.IsNullOrEmpty(reg01[i]) && !reg01[i].Contains("→") && al.Count > 0) {
                    al[al.Count - 1] += reg01[i].Trim();
                } else if (!string.IsNullOrEmpty(reg01[i])) {
                    al.Add(reg01[i].Trim());
                }
            }

            for (int i = 0; i < al.Count; i++) {
                string tmp = al[i].ToString().Trim();
                if (tmp.Contains("→")) {
                    string r1 = tmp.Split('→')[0].ToString();
                    string r2 = tmp.Split('→')[1].ToString();
                    //如果是打开网址
                    if (r2.Contains("[打开网址]") && this.browser.Url != null && this.browser.Url.ToString() != r1) {
                        OpenUrl(r1);
                        return;
                    }

                    r2 = r2.Trim();
                    //r1用regex，来获取select，等范围。
                    if (r1.Contains(".*?")) {
                        r1 = RegexHelper.getMatch(browser.DocumentText, r1, 0, true);
                    }
                    newRegex += r1 + "→" + r2 + Environment.NewLine;
                }

            }


            string re = "";
            string[] regs2 = newRegex.Split('\n');
            for (int i = 0; i < regs2.Length; i++) {
                string tmp = regs2[i].Trim();
                if (tmp.Contains("→")) {
                    string r1 = tmp.Split('→')[0].ToString();
                    string r2 = tmp.Split('→')[1].ToString();
                    setAttribute(r1, r2);
                    re += r2 + "|";
                }
            }

            re = re.TrimEnd('|');
            if (isContentPut && !string.IsNullOrEmpty(re)) {
                EchoHelper.Echo("正文【" + re + "】等信息填写成功！", "表单填写", EchoHelper.EchoType.任务信息);
            } else if (!string.IsNullOrEmpty(re)) {
                EchoHelper.Echo("登录【" + re + "】等信息填写成功！", "表单填写", EchoHelper.EchoType.任务信息);
            }
            countArticle();
        }

        /// <summary>
        /// 设置网页控件的value值。
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private void setAttribute(string tag, string value) {
            //如果是<INPUT标签。
            if (tag.ToUpper().Contains("INPUT")) {
                loadInputTagJS(this.browser, tag, value);
            }

            //如果是<TEXTAREA标签
            if (tag.ToUpper().Contains("TEXTAREA")) {
                loadTextAreaJS(this.browser, tag, value);
            }

            //如果是 <SELECT
            if (tag.ToUpper().Contains("SELECT")) {
                loadSelectTagJS(this.browser, tag, value);
            }

            if (value.Contains("【隐藏】") || value.Contains("[隐藏]")) {
                loadHiddenJS(this.browser, tag);
            }

        }

        private void loadInputTagJS(WebKit.WebKitBrowser b, string tag, string value) {
            Winista.Text.HtmlParser.Util.NodeList htmlNodes = new Parser(new Lexer(tag)).Parse(new TagNameFilter("input"));
            if (htmlNodes.Count > 1) {

                int j = 0;
                for (int i = 0; i < htmlNodes.Count; i++) {
                    InputTag option = (InputTag)htmlNodes.ElementAt(i);
                    if (option.GetAttribute("value") == value) {
                        j = i;
                    }
                }

                //若包含多个input，那么就是radio，或者是checkbox
                for (int i = 0; i < htmlNodes.Count; i++) {
                    InputTag option = (InputTag)htmlNodes.ElementAt(i);
                    if (!string.IsNullOrEmpty(option.GetAttribute("id")) && option.GetAttribute("value") == value) {
                        try {
                            b.StringByEvaluatingJavaScriptFromString("document.getElementById('" + option.GetAttribute("id") + "').checked = true;");
                            b.StringByEvaluatingJavaScriptFromString("document.getElementById('" + option.GetAttribute("id") + "').focus();");
                        } catch {
                        }
                    }
                    if (!string.IsNullOrEmpty(option.GetAttribute("name")) && option.GetAttribute("value") == value) {
                        try {
                            b.StringByEvaluatingJavaScriptFromString("document.getElementsByName('" + option.GetAttribute("name") + "')[" + j + "].checked = true;");
                            b.StringByEvaluatingJavaScriptFromString("document.getElementsByName('" + option.GetAttribute("name") + "')[" + j + "].focus();");

                        } catch {
                        }
                    }
                }


            } else {//不包含多个，那就是input
                for (int i = 0; i < htmlNodes.Count; i++) {
                    InputTag option = (InputTag)htmlNodes.ElementAt(i);
                    if (string.IsNullOrEmpty(option.GetAttribute("id"))) {
                        try {
                            b.StringByEvaluatingJavaScriptFromString("document.getElementById('" + option.GetAttribute("id") + "').value = '" + value + "';");
                            b.StringByEvaluatingJavaScriptFromString("document.getElementById('" + option.GetAttribute("id") + "').focus();");
                        } catch {
                        }
                    }

                    if (!string.IsNullOrEmpty(option.GetAttribute("name"))) {
                        try {
                            b.StringByEvaluatingJavaScriptFromString("document.getElementsByName('" + option.GetAttribute("name") + "')[0].value = '" + value + "';");
                            b.StringByEvaluatingJavaScriptFromString("document.getElementsByName('" + option.GetAttribute("name") + "')[0].focus();");

                        } catch {
                        }
                    }
                }
            }
        }

        private void loadTextAreaJS(WebKit.WebKitBrowser b, string tag, string value) {
            Winista.Text.HtmlParser.Util.NodeList htmlNodes = new Parser(new Lexer(tag)).Parse(new TagNameFilter("TEXTAREA"));
            for (int i = 0; i < htmlNodes.Count; i++) {
                TextareaTag option = (TextareaTag)htmlNodes.ElementAt(i);
                WebKit.DOM.NodeList itemname = b.Document.GetElementsByTagName("TEXTAREA");
                foreach (Element itemid in itemname) {
                    if (option.GetAttribute("name") == itemid.GetAttribute("name") || option.GetAttribute("ID") == itemid.GetAttribute("id")) {
                        itemid.InnerText = value;
                        itemid.Focus();
                        itemid.SetAttribute("style", "width:577px; height:200px;visibility:visible;display:inline;");
                    }

                }
            }

        }

        private void loadSelectTagJS(WebKit.WebKitBrowser b, string tag, string value) {
            int j = 0;
            Winista.Text.HtmlParser.Util.NodeList htmlNodesSelect = new Parser(new Lexer(tag)).Parse(new TagNameFilter("SELECT"));
            Winista.Text.HtmlParser.Util.NodeList htmlNodesOptions = new Parser(new Lexer(tag)).Parse(new TagNameFilter("option"));

            for (int i = 0; i < htmlNodesOptions.Count; i++) {
                OptionTag option = (OptionTag)htmlNodesOptions.ElementAt(i);

                if (option.GetAttribute("value") == value) {
                    j = i;
                }
            }

            for (int i = 0; i < htmlNodesSelect.Count; i++) {
                SelectTag option = (SelectTag)htmlNodesSelect.ElementAt(i);
                if (!string.IsNullOrEmpty(option.GetAttribute("id"))) {
                    try {
                        b.StringByEvaluatingJavaScriptFromString("document.getElementById('" + option.GetAttribute("id") + "').options[" + j + "].selected = true;");
                        b.StringByEvaluatingJavaScriptFromString("document.getElementById('" + option.GetAttribute("id") + "').options[" + j + "].focus();");
                    } catch {
                    }
                } else if (!string.IsNullOrEmpty(option.GetAttribute("name"))) {
                    try {
                        b.StringByEvaluatingJavaScriptFromString("document.getElementsByName('" + option.GetAttribute("name") + "')[0].options[" + j + "].selected = true;");
                        b.StringByEvaluatingJavaScriptFromString("document.getElementsByName('" + option.GetAttribute("name") + "')[0].options[" + j + "].focus();");
                    } catch {
                    }
                }
            }


        }

        private void loadHiddenJS(WebKit.WebKitBrowser b, string tag) {
            Parser parser = new Parser(new Lexer(tag));
            INodeIterator i = parser.Elements();
            while (i.HasMoreNodes()) {
                TagNode n = (TagNode)i.NextNode();
                string id = n.GetAttribute("id");
                if (!string.IsNullOrEmpty(tag)) {
                    try {
                        b.StringByEvaluatingJavaScriptFromString("document.getElementById('" + id + "').style.visibility = 'hidden';");
                    } catch {
                    }
                }
            }
        }


        #endregion

        #region 鼠标拖动工具箱
        private void btnCollapsed(object sender, EventArgs e) {
            groupTools.Collapsed = !groupTools.Collapsed;
        }


        private void btnModuleSet_LinkClicked(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("大虾，非专业人士，站点管理界面，导入发布模块即可！\n当前登录模式 [" + this.site.LoginType.ToString() + "] 您确定编辑？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            X_Form_AddSitePostEdit post = new X_Form_AddSitePostEdit(this.site);
            if (post.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                //site = post.site;
                int tmp_index = ModelMain.FindSiteIndexIDByID(this.site.SiteID);
                ModelMain.AllData.SiteList[tmp_index] = post.site;
            }
        }

        private void btnlogin_LinkClicked(object sender, EventArgs e) {
            LoadAutoInput(this.site.WebLogin, false);
        }

        private void btnPut_LinkClicked(object sender, EventArgs e) {
            LoadAutoInput(this.site.WebPut, true);
        }

        private void LinkTask_LinkClicked(object sender, EventArgs e) {
            try {
                X_Form_AddTask task = new X_Form_AddTask(true, this.task);
                if (task.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    int index = ModelMain.FindTaskIndexByID(this.task.TaskID);
                    ModelMain.AllData.TasksList[index] = task.task;
                    ModelMain.AllData.TasksList[index].State_Change += new ModelTasks.Task_State_Changeed(new X_Form_TaskManage().Task_State_Changeed);
                }
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }

        }

        private void LinkSite_LinkClicked(object sender, EventArgs e) {
            try {
                int siteIndexID = ModelMain.FindSiteIndexIDByID(this.site.SiteID);
                X_Form_AddSite Edit = new X_Form_AddSite(true, this.site, ModelMain.AllData.GroupList[ModelMain.FindGroupIndexByID(this.site.GroupID)].GroupName);
                if (Edit.ShowDialog() != DialogResult.Cancel) {
                    ModelMain.AllData.SiteList[siteIndexID] = Edit.site;
                }
            } catch (Exception ex) {
                EchoHelper.Echo(ex.Message, "出错了", EchoHelper.EchoType.异常信息);
            }

        }

        private void btnClose_LinkClicked(object sender, EventArgs e) {
            this.Close();
        }

        private void btnArticleImport_LinkClicked(object sender, EventArgs e) {
            if (!this.task.IsRandUp) {
                try {
                    FolderBrowserDialog f = new FolderBrowserDialog();
                    if (f.ShowDialog(this) == DialogResult.OK) {
                        string path = f.SelectedPath;
                        IList<FileInfo> files = FilesHelper.ReadDirectoryList(path, ".txt|.html");
                        int i = 0;
                        foreach (FileInfo file in files) {
                            string tmp_result = FilesHelper.Read_File(file);
                            string savePath = Application.StartupPath + this.task.SavePath + file.Name.ToLower().Replace("html", "txt");
                            if (!File.Exists(savePath) && !string.IsNullOrEmpty(tmp_result)) {
                                tmp_result = tmp_result.Replace("&", "");//导入的时候，过滤掉&，防止在发布的时候被截断。
                                FilesHelper.Write_File(savePath, tmp_result);
                                i++;
                            }
                        }
                        EchoHelper.Echo("成功导入：" + i + "篇文章。", "导入文章", EchoHelper.EchoType.任务信息);
                        EchoHelper.Show("成功导入：" + i + "篇文章。", EchoHelper.MessageType.提示);
                    }
                } catch (Exception ex) {
                    EchoHelper.Echo("导入文章失败：" + ex.Message, "导入文章", EchoHelper.EchoType.异常信息);
                }

            } else {
                //如果是随机顶贴任务，那么就自然分隔一个文件中的一行为一个顶贴内容。
                OpenFileDialog Open_File = new OpenFileDialog();
                if (Open_File.ShowDialog() == DialogResult.OK) {
                    FileInfo file = new FileInfo(Open_File.FileName);
                    string tmp_result = FilesHelper.Read_File(file);

                    string[] strs = tmp_result.Split('\n');
                    for (int i = 0; i < strs.Length; i++) {
                        string tmp_name = StringHelper.SubStringNoDDD(strs[i].ToString().Trim(), 0, 30);

                        if (!string.IsNullOrEmpty(strs[i].ToString()) && !string.IsNullOrEmpty(tmp_name)) {
                            FilesHelper.Write_File(Application.StartupPath + this.task.SavePath + tmp_name + ".txt", strs[i].ToString().Trim());

                        }

                    }
                    int count = FilesHelper.ReadDirectoryList(Application.StartupPath + this.task.SavePath, ".txt").Count;
                    EchoHelper.Show("分隔整理成功了，此任务现有" + count + "篇顶贴内容！", EchoHelper.MessageType.提示);
                }
            }
        }

        private void btnRefresh_LinkClicked(object sender, EventArgs e) {
            browser.Reload();
        }

        Point mouseDownPoint = Point.Empty;
        Rectangle rect = Rectangle.Empty;
        bool isDrag = false;



        private void kryptonHeaderGroup1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                mouseDownPoint = e.Location;
                //记录控件的大小
                rect = groupTools.Bounds;
            }
        }

        private void kryptonHeaderGroup1_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                isDrag = true;
                //重新设置rect的位置，跟随鼠标移动
                rect.Location = getPointToForm(new Point(e.Location.X - mouseDownPoint.X, e.Location.Y - mouseDownPoint.Y));
                this.Refresh();

            }
        }

        private void kryptonHeaderGroup1_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (isDrag) {
                    isDrag = false;
                    //移动control到放开鼠标的地方
                    groupTools.Location = rect.Location;
                    this.Refresh();
                }
                reset();

            }
        }

        private void reset() {
            mouseDownPoint = Point.Empty;
            rect = Rectangle.Empty;
            isDrag = false;
        }

        private Point getPointToForm(Point p) {
            return this.PointToClient(groupTools.PointToScreen(p));
        }

        #endregion

        void AddEvents(WebKitBrowser browser) {
            browser.Navigating += new WebKitBrowserNavigatingEventHandler(browser_Navigating);
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
            browser.CanGoBackChanged += new CanGoBackChanged(browser_CanGoBackChanged);
            browser.GeolocationPositionRequest += new GeolocationRequest(browser_GeolocationPositionRequest);
            browser.CanGoForwardChanged += new CanGoForwardChanged(browser_CanGoForwardChanged);
            browser.CloseWindowRequest += new EventHandler(browser_CloseWindowRequest);
            browser.DangerousSiteDetected += new EventHandler(browser_DangerousSiteDetected);
            browser.DocumentTitleChanged += new EventHandler(browser_DocumentTitleChanged);
            browser.FaviconAvailable += new FaviconAvailable(browser_FaviconAvaiable);
            browser.HeadersAvailable += new HeadersAvailableEventHandler(browser_HeadersAvailable);
            browser.FormSubmit += new WillSubmitForm(browser_FormSubmit);
            browser.NewWindowCreated += new NewWindowCreatedEventHandler(browser_NewWindowCreated);
            browser.PopupCreated += new NewWindowCreatedEventHandler(browser_PopupCreated);
            browser.ProgressChanged += new WebKit.ProgressChangedEventHandler(browser_ProgressChanged);
            browser.ShowJavaScriptAlertPanel += new ShowJavaScriptAlertPanelEventHandler(browser_ShowJavaScriptAlertPanel);
            browser.ShowJavaScriptConfirmPanel += new ShowJavaScriptConfirmPanelEventHandler(browser_ShowJavaScriptConfirmPanel);
            browser.ShowJavaScriptPromptBeforeUnload += new ShowJavaScriptPromptBeforeUnloadEventHandler(browser_ShowJavaScriptPromptBeforeUnload);
            browser.ShowJavaScriptPromptPanel += new ShowJavaScriptPromptPanelEventHandler(browser_ShowJavaScriptPromptPanel);
            browser.StatusTextChanged += new StatusTextChanged(browser_StatusTextChanged);
            browser.CustomContextMenuManager.ShowContextMenu += new ShowContextMenu(CustomContextMenuManager_ShowContextMenu);

            browser.ResourceIntercepter.ResourceSizeAvailableEvent += new ResourceSizeAvailable(ResourceIntercepter_ResourceProgressChangedEvent);
            browser.ResourceIntercepter.ResourceFinishedLoadingEvent += new ResourceFinishedLoadingHandler(ResourceIntercepter_ResourceFinishedLoadingEvent);
            browser.ResourceIntercepter.ResourceStartedLoadingEvent += new ResourceStartedLoadingHandler(ResourceIntercepter_ResourceStartedLoadingEvent);
            browser.ResourceIntercepter.ResourcesSendRequest += new ResourceSendRequestEventHandler(ResourceIntercepter_ResourcesSendRequest);
            browser.ResourceIntercepter.ResourceFailedLoading += new ResourceFailedHandler(ResourceIntercepter_ResourceFailedLoading);

        }


        private void browser_DocumentTitleChanged(object sender, EventArgs e) {

            this.TabText = browser.DocumentTitle;
            this.ToolTipText = browser.DocumentTitle;

            X_PostKing.X_Form_MainFormBrowser formT = (X_Form_MainFormBrowser)this.DockPanel.Parent;  //强制转换成MainForm
            try {
                formT.txtUrl.Text = browser.Url.ToString();
            } catch {
            }
        }

        private void browser_NewWindowCreated(object sender, NewWindowCreatedEventArgs e) {
            X_Form_WebBrowser wb = new X_Form_WebBrowser(task, e.WebKitBrowser, null);
            wb.browser = e.WebKitBrowser;
            wb.Show(this.DockPanel);
        }

        void browser_Navigating(object sender, WebKitBrowserNavigatingEventArgs e) {
            X_PostKing.X_Form_MainFormBrowser formT = (X_Form_MainFormBrowser)this.DockPanel.Parent;  //强制转换成MainForm
            formT.toolStatus.Text = "Loading...";
        }


        private void browser_DownloadBegin(object sender, FileDownloadBeginEventArgs e) {
        }

        private void browser_LocationChanged(object sender, EventArgs e) {

        }

        private void browser_Error(object sender, WebKitBrowserErrorEventArgs e) {
            if (!string.IsNullOrEmpty(e.Description)) {
                EchoHelper.Echo(e.Description, "浏览器", EchoHelper.EchoType.错误信息);
            }
        }

        private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e) {
            X_PostKing.X_Form_MainFormBrowser formT = (X_Form_MainFormBrowser)this.DockPanel.Parent;  //强制转换成MainForm
            formT.toolStatus.Text = "Downloading...";
        }
        private void browser_NewWindowRequest(object sender, NewWindowRequestEventArgs e) {
        }


        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            this.Cursor = Cursors.Default;
            X_PostKing.X_Form_MainFormBrowser formT = (X_Form_MainFormBrowser)this.DockPanel.Parent;  //强制转换成MainForm
            formT.toolStatus.Text = "完成";
        }

        private void browser_CanGoBackChanged(object sender, CanGoBackChangedEventArgs e) {
            // if (sender.Equals(browser))
            //button1.Enabled = e.CanGoBack;

        }

        private void browser_CanGoForwardChanged(object sender, CanGoForwardChangedEventArgs e) {
            //if (sender.Equals(browser))
            //button2.Enabled = e.CanGoForward;
        }

        void browser_GeolocationPositionRequest(object sender, GeolocationRequestEventArgs e) {
            e.Allow = true;
        }

        private void browser_CloseWindowRequest(object sender, EventArgs e) {
            //tabControl1.Controls.Remove((sender as WebKitBrowser).Parent);

        }

        private void browser_DangerousSiteDetected(object sender, EventArgs e) {
            EchoHelper.Echo("The site " + (sender as WebKitBrowser).Url.ToString() + " is considered dangerous and it is recommended that you leave.", "发现危险站点", EchoHelper.EchoType.错误信息);
        }

        private void browser_FaviconAvaiable(object sender, WebKit.FaviconAvailableEventArgs e) {
            //             if (e.Favicon != null) {
            //                 fav.Visible = true;
            //                 fav.Image = e.Favicon.ToBitmap();
            //             } else
            //                 fav.Visible = false;
        }

        void browser_HeadersAvailable(object sender, HeadersAvailableEventArgs e) {
            // here you can interfere with headers

            // uncomment the following to see how a message box will show
            // all headers with their fields and values

            //string tomes = "";
            //foreach (Header h in e.Headers)
            //{
            //    tomes = tomes + h.Field + ":" + h.Value + "\r\n";
            //}
            //MessageBox.Show(tomes);
        }

        private void browser_FormSubmit(object sender, WebKit.FormDelegateFormEventArgs e) {
            //e.Listener.continueSubmit();  from 1.5 Beta 2 this is automatically called
        }

        private void browser_PopupCreated(object sender, NewWindowCreatedEventArgs e) {
            EchoHelper.Echo("一个弹出窗口被阻止！" + e.WebKitBrowser.Url, "浏览器", EchoHelper.EchoType.任务信息);
            //MessageBox.Show("A popup has been blocked");
            //if (blockPopupsToolStripMenuItem.Checked)
            //else {
            //                 Form f = new Form();
            //                 f.Show();
            //                 WebKitBrowser wb = e.WebKitBrowser;
            //                 wb.AllowDownloads = true;
            //                 wb.Visible = true;
            //                 wb.Name = "browser";
            //                 wb.Dock = DockStyle.Fill;
            //                 wb.DocumentTitleChanged += new EventHandler(wb_DocumentTitleChanged);
            //                 wb.FaviconAvailable += new FaviconAvailable(wb_FaviconAvaiable);
            //                 f.Controls.Add(wb);
            // }
        }

        private void browser_ProgressChanged(object sender, WebKit.ProgressChangesEventArgs e) {
            X_PostKing.X_Form_MainFormBrowser formT = (X_Form_MainFormBrowser)this.DockPanel.Parent;  //强制转换成MainForm
            formT.PBar.Value = e.Percent;
        }


        private void browser_ShowJavaScriptAlertPanel(object sender, WebKit.ShowJavaScriptAlertPanelEventArgs e) {
            MessageBox.Show(e.Message);
        }

        private void browser_ShowJavaScriptConfirmPanel(object sender, WebKit.ShowJavaScriptConfirmPanelEventArgs e) {
            bool val = (MessageBox.Show(e.Message, "OpenWebKitSharp Example", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK);
            e.ReturnValue = val;
        }

        private void browser_ShowJavaScriptPromptPanel(object sender, WebKit.ShowJavaScriptPromptPanelEventArgs e) {
            // e.ReturnValue = Microsoft.VisualBasic.Interaction.InputBox(e.Message, "", e.DefaultValue);
        }

        private void browser_ShowJavaScriptPromptBeforeUnload(object sender, ShowJavaScriptPromptBeforeUnloadEventArgs e) {
            if (MessageBox.Show(e.Message, "OpenWebKitSharp Example", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes) {
                e.ReturnValue = true;
            } else {
                e.ReturnValue = false;
            }
        }

        private void browser_StatusTextChanged(object sender, WebKit.WebKitBrowserStatusChangedEventArgs e) {
            if (sender.Equals(browser)) {
                X_PostKing.X_Form_MainFormBrowser formT = (X_Form_MainFormBrowser)this.DockPanel.Parent;  //强制转换成MainForm
                formT.toolStatus.Text = e.StatusText;
            }
        }

        void CustomContextMenuManager_ShowContextMenu(object sender, ShowContextMenuEventArgs e) {
            ContextMenu tst = new ContextMenu();
            //             MenuItem mn = new MenuItem("Test1");
            //             tst.MenuItems.Add(mn);
            //             MenuItem mn2 = new MenuItem("Test2");
            //             tst.MenuItems.Add(mn2);
            //             MenuItem mn3 = new MenuItem("-");
            //             tst.MenuItems.Add(mn3);
            MenuItem mn4 = new MenuItem("忍者软件");
            mn4.Enabled = false;
            tst.MenuItems.Add(mn4);
            tst.Show(browser, e.Location);
        }

        void ResourceIntercepter_ResourceFailedLoading(object sender, WebKitResourceErrorEventArgs e) {
            //richTextBox1.Text = richTextBox1.Text + e.Resource.Url + " with the type " + e.Resource.MimeType + " failed to load because of this error: " + e.ErrorDescription + "\r\n";
        }

        void ResourceIntercepter_ResourcesSendRequest(object sender, WebKitResourceRequestEventArgs e) {
            if (e.ResourceUrl.ToLower().Contains("tinymce")) {
                //e.SendRequest = false;
            }
            if (e.ResourceUrl.ToLower().Contains("ckeditor.js")) {
                e.SendRequest = false;
            }
            if (e.ResourceUrl.ToLower().Contains("bbcode.js")) {
                e.SendRequest = false;
            }
            if (e.ResourceUrl.ToLower().Contains("editor.js?")) {
                e.SendRequest = false;
            }


        }

        void ResourceIntercepter_ResourceStartedLoadingEvent(object sender, WebKitResourcesEventArgs e) {
            //richTextBox1.Text = richTextBox1.Text + e.Resource.Url + " with the type " + e.Resource.MimeType + " has started loading." + "\r\n";
        }

        void ResourceIntercepter_ResourceFinishedLoadingEvent(object sender, WebKitResourcesEventArgs e) {
            //richTextBox1.Text = richTextBox1.Text + e.Resource.Url + " has finished loading." + "\r\n";
        }

        void ResourceIntercepter_ResourceProgressChangedEvent(object sender, WebKitLoadingResourceEventArgs e) {
            //             X_PostKing.X_Form_MainFormBrowser formT = (X_Form_MainFormBrowser)this.DockPanel.Parent;  //强制转换成MainForm
            //             formT.toolStatus.Text = e.StatusText;

            //             if (e.Received > -1)
            //                 richTextBox1.Text = richTextBox1.Text + e.Received + " bytes have been received" + "\r\n";
            //             else
            //                 richTextBox1.Text = richTextBox1.Text + " the number of the bytes that have been received is not available" + "\r\n";
        }


    }
}
