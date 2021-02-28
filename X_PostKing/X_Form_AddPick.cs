using System;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;
using X_Model;
using X_Service.Db;
using X_Service.Fetch;
using X_Service.Files;
using X_Service.org.renzhe.serv;
using X_Service.Util;
using X_Service.Web;

namespace X_PostKing {
    public partial class X_Form_AddPick : X_Form_BaseTool {

        X_Waiting wait = new X_Waiting();
        ModelPick mpick;
        CookieCollection cookies = new CookieCollection();

        public X_Form_AddPick(bool isEdit, ModelPick mpick) {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;

            this.mpick = mpick;
            this.Text = isEdit ? "编辑抓取模块" : "新建抓取模块";

        }

        private void X_Form_AddPick_Load(object sender, EventArgs e) {
            loaded(mpick);
            TabC_AddSite_SelectedIndexChanged(sender, e);
#if DEBUG
            //txtUrlContent.Text = "http://www.kao120.com/med/html/kouqiang/zhiyidagang/201202/27018.html";
            //txtTitleRegex.Text = "<title>(.*?)</title>";
            //txtContentRegexs.Text = "e; } </style>(.*?)<div class=\"tag\">";
#endif
        }

        private void TabC_AddSite_SelectedIndexChanged(object sender, EventArgs e) {
            setModelInfo();
            switch (TabC_AddPick.SelectedIndex) {
                case 0: {
                        TabC_AddPick.Size = new Size(TabC_AddPick.Size.Width, groupBox3.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + TabC_AddPick.Size.Height + 30 + 22);
                        break;
                    }
                case 1: {
                        if (!string.IsNullOrEmpty(mpick.ModelPassWord) && txtModelPassWord.Text != mpick.ModelPassWord) {
                            TabC_AddPick.SelectedIndex = 0;
                            EchoHelper.Show("忍者发布模块版权所有，请输入密码，方可进入编辑模式！", EchoHelper.MessageType.警告);
                            txtModelPassWord.Focus();
                            break;
                        }

                        TabC_AddPick.Size = new Size(TabC_AddPick.Size.Width, groupBox1.Size.Height + groupBox2.Size.Height + groupBox4.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + TabC_AddPick.Size.Height + 30 + 22);
                        break;
                    }
                case 2: {
                        if (!string.IsNullOrEmpty(mpick.ModelPassWord) && txtModelPassWord.Text != mpick.ModelPassWord) {
                            TabC_AddPick.SelectedIndex = 0;
                            EchoHelper.Show("忍者发布模块版权所有，请输入密码，方可进入编辑模式！", EchoHelper.MessageType.警告);
                            txtModelPassWord.Focus();
                            break;
                        }

                        TabC_AddPick.Size = new Size(TabC_AddPick.Size.Width, groupBoxZhengzheModel.Size.Height + groupBox6.Size.Height + groupBox9.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + TabC_AddPick.Size.Height + 30 + 22);
                        break;
                    }
                case 3: {
                        if (!string.IsNullOrEmpty(mpick.ModelPassWord) && txtModelPassWord.Text != mpick.ModelPassWord) {
                            TabC_AddPick.SelectedIndex = 0;
                            EchoHelper.Show("忍者发布模块版权所有，请输入密码，方可进入编辑模式！", EchoHelper.MessageType.警告);
                            txtModelPassWord.Focus();
                            break;
                        }

                        TabC_AddPick.Size = new Size(TabC_AddPick.Size.Width, groupBox5.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + TabC_AddPick.Size.Height + 30 + 22);
                        break;
                    }
            }
        }

        private void TS_保存_Click(object sender, EventArgs e) {
            DbTools db = new DbTools();
            string strFile = "";

            if (ckIsPub.Enabled == true) {//代表已经成功的验证，是具有编写权限。
                if (string.IsNullOrEmpty(txtPickName.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "模块名称是必须的！", txtPickName);
                    return;
                }
                save();
                strFile = Application.StartupPath + "\\Module\\" + mpick.PickName;
                db.Save(strFile, "WCNM", mpick);
            }


            if (mpick.IsPub && ckIsPub.Enabled) {
                if (string.IsNullOrEmpty(txtModelAuthor.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "为了分享，填上您的大名吧！", txtModelAuthor);
                    return;
                }
                if (string.IsNullOrEmpty(txtModelEmail.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "为了分享，填上您的Email吧！", txtModelEmail);
                    return;
                }
                if (string.IsNullOrEmpty(txtModelQQ.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "为了分享，填上您的QQ吧！", txtModelQQ);
                    return;
                }

                if (string.IsNullOrEmpty(txtModelPassWord.Text) && ckIsPub.Enabled == true) {
                    EchoHelper.ShowBalloon("信息不全", "为了您的劳动成果不被侵犯，加密吧！", txtModelPassWord);
                    return;
                }

                if (string.IsNullOrEmpty(txtModelUrl.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "为了分享，填上这个模块的教程链接吧！", txtModelUrl);
                    return;
                }
                if (string.IsNullOrEmpty(txtModelDescription.Text)) {
                    EchoHelper.ShowBalloon("信息不全", "为了分享，填上这个模块的说明吧！", txtModelDescription);
                    return;
                }

                //分享到模块市场中。
                wait.ShowMsg("分享" + mpick.PickName + "到忍者模块市场中...");
                string fileClassStr = FilesHelper.Read_File(strFile);
                try {
                    ServiceShop serv = new ServiceShop();
                    serv.Timeout = 10000;
                    serv.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:5.0) Gecko/20100101 Firefox/5.0";
                    serv.UnsafeAuthenticatedConnectionSharing = true;
                    serv.AllowAutoRedirect = false;

                    bool isok = serv.UploadClassStr(mpick.PickName, fileClassStr, mType.抓取模块);
                    Thread.Sleep(500);
                    if (isok) {
                        EchoHelper.Echo("分享模块成功！忍者对您的贡献表示感谢！", "模块市场", EchoHelper.EchoType.普通信息);
                        wait.CloseMsg();
                    } else {
                        EchoHelper.Show("分享失败！原因可能是：\n1、已存在模块与您的密码不符\n2、网络问题！", EchoHelper.MessageType.错误);
                        wait.CloseMsg();
                        return;
                    }

                } catch (Exception ex) {
                    EchoHelper.Show("上传失败,请重试！", EchoHelper.MessageType.警告);
                    EchoHelper.EchoException(ex);
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
            this.Tag = strFile;
            SaveAll();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void loaded(ModelPick pick) {
            this.mpick = pick;
            txtPickName.Text = mpick.PickName;
            txtModelEmail.Text = string.IsNullOrEmpty(mpick.ModelEmail) ? member.email : mpick.ModelEmail;
            txtModelAuthor.Text = string.IsNullOrEmpty(mpick.ModelAuthor) ? member.netname : mpick.ModelAuthor;
            txtModelDescription.Text = mpick.SiteModelDescription;
            txtModelUrl.Text = this.mpick.ModelUrl;
            txtModelQQ.Text = this.mpick.ModelQQ;
            ckIsPub.Checked = mpick.IsPub;

            txtTitleRegex.Text = mpick.TitleRegex;
            txtContentRegexs.Text = mpick.ContentRegexs;
            txtIndexUrlStr.Text = mpick.IndexUrlStr;
            ckZhizhu.Checked = mpick.isZhizhu;
            txtUrlhas.Text = mpick.Urlhas;
            txtUrlnotHas.Text = mpick.UrlnotHas;
            txtlinCookies.Text = mpick.linCookies;
            ckisAutoModelGet.Checked = mpick.isAutoModelGet;
            groupBoxZhengzheModel.Enabled = !mpick.isAutoModelGet;
            txtTitleRegex.Text = mpick.TitleRegex;
            txtContentRegexs.Text = mpick.ContentRegexs;
            txtIntervalTime.Value = Convert.ToDecimal(mpick.IntervalTime);
            ckNO2br.Checked = mpick.No2br;
            ckNOimg.Checked = mpick.Noimg;
            ckSameTileFile.Checked = mpick.SameTileFile;
            txtStrReplace.Text = mpick.StrReplace;
        }

        private void save() {
            mpick.PickName = txtPickName.Text.Contains(".rzget") ? txtPickName.Text : txtPickName.Text + ".rzget";
            mpick.ModelAuthor = txtModelAuthor.Text;
            mpick.ModelEmail = txtModelEmail.Text;
            mpick.ModelPassWord = txtModelPassWord.Text;
            mpick.ModelQQ = txtModelQQ.Text;
            mpick.ModelUrl = txtModelUrl.Text;
            mpick.SiteModelDescription = txtModelDescription.Text;
            mpick.IsPub = ckIsPub.Checked;

            mpick.TitleRegex = txtTitleRegex.Text;
            mpick.ContentRegexs = txtContentRegexs.Text;
            mpick.PickInfo = txtModelDescription.Text;
            mpick.IndexUrlStr = txtIndexUrlStr.Text;
            mpick.isZhizhu = ckZhizhu.Checked;
            mpick.Urlhas = txtUrlhas.Text;
            mpick.UrlnotHas = txtUrlnotHas.Text;
            mpick.linCookies = txtlinCookies.Text;
            mpick.isAutoModelGet = ckisAutoModelGet.Checked;
            mpick.TitleRegex = txtTitleRegex.Text;
            mpick.ContentRegexs = txtContentRegexs.Text;
            mpick.IntervalTime = Convert.ToInt32(txtIntervalTime.Value);
            mpick.No2br = ckNO2br.Checked;
            mpick.Noimg = ckNOimg.Checked;
            mpick.StrReplace = txtStrReplace.Text;
            mpick.SameTileFile = ckSameTileFile.Checked;
        }

        private void btnNext1_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtIndexUrlStr.Text.Trim())) {
                EchoHelper.ShowBalloon("不能为空", "入口页面的URL不能为空！", txtUrlContent);
                return;
            }
            listUrls.Items.Clear();
            btnNext1.Enabled = false;
            wait.ShowMsg("获取页面HTML，内容页分析中。。。");
            Thread t = new Thread(new ThreadStart(th));
            t.IsBackground = true;
            t.Start();
        }

        private void th() {
            try {
                string keywordGBK = HttpUtility.UrlEncode("忍者", Encoding.Default).ToUpper();
                string keywordUTF8 = HttpUtility.UrlEncode("忍者", Encoding.UTF8).ToUpper();
                string gurl = txtIndexUrlStr.Text.Replace("[关键词GBK]", keywordGBK).Replace("[关键词UTF8]", keywordUTF8).Replace("[连续分页]", "2");
                string html = new xkHttp().httpGET(gurl, ref cookies, "http://" + new Uri(gurl).Host);
                txtHTML.Text = html;

                NodeFilter filter = new TagNameFilter("a");
                NodeList htmlNodes = new Parser(new Lexer(html)).Parse(filter);

                for (int i = 0; i < htmlNodes.Count; i++) {
                    ATag t = (ATag)htmlNodes.ElementAt(i);
                    string urlpart = t.GetAttribute("href");

                    if (!string.IsNullOrEmpty(urlpart) && urlpart.Trim().Length > 10) {
                        urlpart = new xkHttp().getDealUrl(gurl, urlpart);
                        bool isadd = true;
                        string[] urlhas = txtUrlhas.Text.Split('|');
                        if (urlhas.Length > 0 && !string.IsNullOrEmpty(urlhas[0])) {
                            for (int j = 0; j < urlhas.Length; j++) {
                                if (string.IsNullOrEmpty(urlhas[j]) || !urlpart.Contains(urlhas[j])) {
                                    isadd = false;
                                }
                            }
                        }

                        string[] urlnothas = txtUrlnotHas.Text.Split('|');
                        if (urlnothas.Length > 0 && !string.IsNullOrEmpty(urlnothas[0])) {
                            for (int j = 0; j < urlnothas.Length; j++) {
                                if (string.IsNullOrEmpty(urlnothas[j]) || urlpart.Contains(urlnothas[j])) {
                                    isadd = false;
                                }
                            }
                        }

                        if (isadd && !string.IsNullOrEmpty(urlpart) && !listUrls.Items.Contains(urlpart)) {
                            listUrls.Items.Add(urlpart);
                        }
                    }

                }
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            } finally {
                wait.CloseMsg();
                btnNext1.Enabled = true;
            }

        }

        private void linkGJC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string Text = link.Tag.ToString();
                Clipboard.SetText(Text);
                txtIndexUrlStr.Paste();
                Clipboard.Clear();
            } catch {

            }
        }

        private void ckisAutoModelGet_CheckedChanged(object sender, EventArgs e) {
            if (ckisAutoModelGet.Checked) {
                groupBoxZhengzheModel.Enabled = false;
                ckisAutoModelGet.Text = "当前模式： 智能抓取，简单无需编写任何规则，系统智能抓取[标题][正文]，性能较差并耗时！";
            } else {
                groupBoxZhengzheModel.Enabled = true;
                ckisAutoModelGet.Text = "当前模式： 正则抓取，要懂得编写正则代码，获取快速准确";
            }
        }

        private void btnGetContent_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtUrlContent.Text.Trim())) {
                EchoHelper.ShowBalloon("不能为空", "内容页面的URL不能为空！", txtUrlContent);
                return;
            }

            if (string.IsNullOrEmpty(txtContentRegexs.Text.Trim()) && !ckisAutoModelGet.Checked) {
                EchoHelper.ShowBalloon("不能为空", "内容正则匹配不能为空！", txtContentRegexs);
                return;
            }

            Thread th = new Thread(new ThreadStart(thget));
            txtHTML.Text = "";
            wait.ShowMsg("正在抓取HTML代码，并获取标题正文。。。");
            btnGetContent.Enabled = false;
            th.IsBackground = true;
            th.Start();
        }

        private void thget() {
            try {
                string url = txtUrlContent.Text;
                string html = new xkHttp().httpGET(url, ref cookies);
                txtHTML.Text = html;

                string tmp_title = "";
                string tmp_content = "";

                if (ckisAutoModelGet.Checked) {//智能获取模式
                    FetchContent.GetContentFromUrl(url, ref tmp_title, ref tmp_content);
                } else {//正则模式
                    FetchContent.GetContentFromUrl(url, ref tmp_title, ref tmp_content, txtTitleRegex.Text, txtContentRegexs.Text);
                }
                //过滤与整理
                FetchContent.Filter(ref tmp_title, ref tmp_content, txtStrReplace.Text, ckNOimg.Checked, ckNO2br.Checked);
                FetchContent.ImageSrc(ref tmp_content, url);

                txtHTML.Text = "[标题]：" + Environment.NewLine + tmp_title + Environment.NewLine + "[正文]：" + Environment.NewLine + tmp_content + Environment.NewLine + Environment.NewLine + "======处理前的HTML代码=====" + Environment.NewLine + txtHTML.Text;
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            } finally {
                wait.CloseMsg();
                btnGetContent.Enabled = true;
                EchoHelper.Show("抓取内容完成！", EchoHelper.MessageType.提示);
            }
        }


        private void linktitlereg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string Text = link.Tag.ToString();
                Clipboard.SetText(Text);
                txtTitleRegex.Paste();
                Clipboard.Clear();
            } catch {

            }
        }

        private void linkstrreg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string Text = link.Tag.ToString() + Environment.NewLine;
                Clipboard.SetText(Text);
                txtStrReplace.Paste();
                Clipboard.Clear();
            } catch {

            }
        }

        private void linkconreg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string Text = link.Tag.ToString();
                Clipboard.SetText(Text);
                txtContentRegexs.Paste();
                Clipboard.Clear();
            } catch {

            }
        }

        private void tool导出模块_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtPickName.Text)) {
                TabC_AddPick.SelectedIndex = 0;
                EchoHelper.ShowBalloon("抓取模块名字必填", "抓取模块的名称都不输入，让我情何以堪！", txtPickName);
                return;
            }
            Save_File.Filter = "忍者X2抓取抓取模块(*.rzget)|*.rzget";
            Save_File.FileName = txtPickName.Text;
            if (Save_File.ShowDialog() == DialogResult.OK) {
                DbTools db = new DbTools();
                save();
                db.Save(Save_File.FileName, "WCNM", mpick);
                EchoHelper.Echo("导出抓取模块成功！文件保存位置" + Save_File.FileName, "导出抓取模块", EchoHelper.EchoType.任务信息);
                EchoHelper.Show("导出抓取模块成功！", EchoHelper.MessageType.提示);
            }
        }

        private void tool导入模块_Click(object sender, EventArgs e) {
            try {
                Open_File.Filter = "忍者X2抓取抓取模板(*.rzget)|*.rzget";
                Open_File.FileName = "*.rzget";
                if (this.Open_File.ShowDialog() == DialogResult.OK) {
                    //string SafeFileName = Open_File.FileName.Substring(Open_File.FileName.LastIndexOf(@"\") + 1);//获取选中的文件名 
                    //File.Copy(this.Open_File.FileName, Application.StartupPath + "\\Module\\" + SafeFileName, true);
                    //db.Save(Save_File.FileName, "WCNM", mpick);
                    DbTools db = new DbTools();
                    ModelPick p = (ModelPick)db.Read(Open_File.FileName, "WCNM");
                    if (p != null) {
                        loaded(p);
                    }

                    EchoHelper.Echo("导入抓取模块成功！请从列表中选择发布模块...", "导入抓取模块", EchoHelper.EchoType.任务信息);
                    //EchoHelper.Show("导入抓取模块成功！请从列表中选择发布模块...", EchoHelper.MessageType.提示);
                }
            } catch (Exception ex) {
                EchoHelper.Echo("导入抓取模块失败：" + ex.Message, "导入抓取模块", EchoHelper.EchoType.异常信息);
            }
        }

        private void ckZhizhu_CheckedChanged(object sender, EventArgs e) {
            if (ckZhizhu.Checked && string.IsNullOrEmpty(txtUrlhas.Text)) {
                EchoHelper.ShowBalloon("请输入包含条件", "不输入包含条件，我会对所有连接进行尝试获取，你想累死【忍者蜘蛛】呀？", txtUrlhas);
                ckZhizhu.Checked = false;
            }

        }

        private void ckZhizhu_Click(object sender, EventArgs e) {
            if (ckZhizhu.Checked) {
                EchoHelper.Show("蜘蛛可以智能爬行抓取更多数据，相反相关度可能不高！", EchoHelper.MessageType.提示);
            }
        }

        private void listUrls_Click(object sender, EventArgs e) {
            //try {
            //    txtIndexUrlStr.Text = listUrls.SelectedItem.ToString();
            //    listUrls.Items.Clear();
            //    btnNext1.Enabled = false;
            //    wait.ShowMsg("获取页面HTML，内容页分析中。。。");
            //    Thread t = new Thread(new ThreadStart(th));
            //    t.IsBackground = true;
            //    t.Start();
            //} catch {
            //    EchoHelper.Show("入口URL改变为当前URL，发生异常，请核查！", EchoHelper.MessageType.警告);
            //}
        }

        private void listUrls_DoubleClick(object sender, EventArgs e) {
            try {
                txtUrlContent.Text = listUrls.SelectedItem.ToString();
                TabC_AddPick.SelectedIndex = 2;
            } catch {
                EchoHelper.Show("还没有找到疑似的内容页面URL，请先获取内容页面。", EchoHelper.MessageType.警告);
            }

        }

        private void X_Form_AddPick_FormClosing(object sender, FormClosingEventArgs e) {
            //             if (KryptonMessageBox.Show("确认您的信息，是否真的退出？", "抓取模块提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) {
            //                 e.Cancel = true;
            //             } else {
            //                 e.Cancel = false;
            //             }
        }

        private void linkLabelFilterA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                string Text = @"[a-zA-z]+://[^\s]*→" + Environment.NewLine + @"http://→" + Environment.NewLine + @"www\.[a-zA-z0-9]+\.(com|net|org|cn)→" + Environment.NewLine;
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                Clipboard.SetText(Text);
                txtStrReplace.Paste();
                Clipboard.Clear();
            } catch {

            }

        }

        private void txtPickName_LinkClicked(object sender, EventArgs e) {
            try {
                KryptonLinkLabel link = (KryptonLinkLabel)sender;
                Clipboard.Clear();
                string Text = link.Tag.ToString();
                Clipboard.SetText(Text);
                txtPickName.Paste();
                Clipboard.Clear();
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
        }

        private void txtModelPassWord_TextChanged(object sender, EventArgs e) {
            setModelInfo();
        }
        private void setModelInfo() {
            if (string.IsNullOrEmpty(mpick.ModelPassWord) || txtModelPassWord.Text == mpick.ModelPassWord) {
                txtModelAuthor.Enabled = true;
                txtModelDescription.Enabled = true;
                txtModelEmail.Enabled = true;
                txtModelQQ.Enabled = true;
                txtModelUrl.Enabled = true;
                ckIsPub.Enabled = true;
            } else {
                txtModelAuthor.Enabled = false;
                txtModelDescription.Enabled = false;
                txtModelEmail.Enabled = false;
                txtModelQQ.Enabled = false;
                txtModelUrl.Enabled = false;
                ckIsPub.Enabled = false;
            }
            txtPickName.Enabled = string.IsNullOrEmpty(txtPickName.Text);
        }



    }
}
