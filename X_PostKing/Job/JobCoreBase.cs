using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;
using X_Model;
using X_PostKing.Pick;
using X_Service.Files;
using X_Service.Login;
using X_Service.Util;
using X_Service.Web;
using Ibms.Utility.Task;

namespace X_PostKing.Job {
    /// <summary>
    /// 基础类型
    /// </summary>
    public abstract class JobCoreBase : TaskBase {

        public string ShortTitle {
            get {
                if (Title.Length > 20) {
                    _shortTitle = Title.Substring(0, 20);
                    return _shortTitle;
                } else {
                    return Title;
                }

            }
        }

        #region 构造方法&初始化方法，一些字段。


        private ModelUsers _user = null;
        private ModelSite _site = null;
        private ModelTasks _tasks = null;

        public ModelTasks Task {
            get {
                return _tasks;
            }
            set {
                _tasks = value;
            }
        }

        public ModelSite Site {
            get {
                return _site;
            }
            set {
                _site = value;
            }
        }
        public ModelUsers User {
            get {
                return _user;
            }
            set {
                _user = value;
            }
        }
        #endregion

        #region 发布参数用到的参数

        public string Title = string.Empty;
        public string ContentText = string.Empty;

        public string TaskName {
            get {
                return Task.TaskName;
            }
        }

        private string _shortTitle = string.Empty;

        #endregion

        #region 一些等待重写的方法。包括登录、获取分类html、Post提交等。
        /// <summary>
        /// 待重写的登陆方法
        /// </summary>
        /// <returns></returns>
        public abstract string Login();


        public string GetCategoryHtml() {
            if (Site == null) {
                return "不允许空类型-----忍者";
            } else if (!Site.CategoriesIsEnablad) {
                return "没有启用分类-----忍者";
            } else {

                string tmp_CategoriesUrl = Site.CategoriesUrl;

                if (tmp_CategoriesUrl.Contains("[")) {
                    tmp_CategoriesUrl = tmp_CategoriesUrl.Replace("[网站域名]", Site.SiteDomain);
                    tmp_CategoriesUrl = tmp_CategoriesUrl.Replace("[后台地址]", Site.SiteBackUrl);
                    tmp_CategoriesUrl = tmp_CategoriesUrl.Replace("[验证码]", Site.Verify);
                    tmp_CategoriesUrl = tmp_CategoriesUrl.Replace("[随机数]", StringHelper.getRandNum(3).ToString());
                    tmp_CategoriesUrl = tmp_CategoriesUrl.Replace("[主关键字]", ArrayHelper.getRandOneFromStrs(Site.SiteMainKeys.Split(',')));
                    tmp_CategoriesUrl = tmp_CategoriesUrl.Replace("[来源]", Login_Base.member.netname);
                    tmp_CategoriesUrl = tmp_CategoriesUrl.Replace("[临时值01]", Site.tmp01);
                    tmp_CategoriesUrl = tmp_CategoriesUrl.Replace("[临时值02]", Site.tmp02);
                }

                string html = new xkHttp().httpGET(tmp_CategoriesUrl, ref User.cookies);
                return html;
            }
        }

        /// <summary>
        /// 支持url|{(.*?)}的方式,获取url页面中的{(.*?)}正则匹配；没有url，则在GetCategoryHtml()中匹配
        /// </summary>
        /// <param name="regexStr"></param>
        /// <returns></returns>
        public string GetTempValue(string regexStr) {
            string str = "";
            if (!string.IsNullOrEmpty(regexStr)) {
                if (regexStr.Contains("|")) {
                    string tmp01 = regexStr.Split('|')[0];
                    string tmp02 = regexStr.Split('|')[1];
                    str = RegexHelper.getHtmlRegexText(new xkHttp().httpGET(tmp01, ref User.cookies), tmp02);
                } else {
                    str = RegexHelper.getHtmlRegexText(GetCategoryHtml(), regexStr);
                }
            }
            return str;
        }


        public abstract string Post();

        #endregion.

        #region 用来访问发布后成功页面，并且可以进行下一步生成。
        public void VisitAndBuildHTML(string html) {
            string charset = Site.SiteIsUtf8 ? "utf-8" : "gb2312";


            if (!string.IsNullOrEmpty(Site.PostSuccessVisitList)) {
                string[] strs = Site.PostSuccessVisitList.Split('\n');
                for (int i = 0; i < strs.Length; i++) {
                    string url = _replaceRegexText(html, strs[i].Trim());
                    url = _replace(url);
                    try {
                        EchoHelper.Echo("系统尝试生成：" + url, "", EchoHelper.EchoType.普通信息);
                        if (url.Contains("[POST]")) {
                            url = url.Replace("[POST]", "");
                            html = new xkHttp().httpPost(url, "", ref User.cookies);
                        } else {
                            html = new xkHttp().httpGET(url, ref User.cookies);
                        }

                    } catch (Exception ex) {
                        EchoHelper.EchoException(ex);
                        //EchoHelper.Echo("尝试访问失败" + url, Task.TaskName, EchoHelper.EchoType.错误信息);
                    }
                }
            }

        }

        #endregion

        #region 获取Cookie
        /// <summary>
        /// 获取COOKIE
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        protected string GetCookie(string head) {
            StringBuilder sbCookies = new StringBuilder();
            string[] arr = head.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in arr) {
                if (str.StartsWith("Set-Cookie: ")) {
                    int intStart = str.IndexOf(";");
                    string strCookie = str.Substring(12, intStart - 11);
                    sbCookies.Append(strCookie);
                }
            }
            return sbCookies.ToString();
        }

        #endregion

        #region 是否包含失败标记
        /// <summary>
        /// 是否包含失败标记
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        protected string VerifyFail(string html, string FailText) {
            FailText += "\n(404) =无法找到路径，请核对网站后台路径。";
            FailText += "\nThe operation has timed out=网络超时，尝试连接20秒无反应。";
            FailText += "\n操作超时=网络超时，尝试连接20秒无反应。";
            FailText += "\n(500) =服务器内部错误，资源超载，暂时无法访问。";
            FailText += "\n无法解析=DNS解析错误。";
            FailText += "\n(403) =远程服务器错误: 已被禁止，请查看是否具有权限。";
            FailText += "\n无法连接到远程服务器。";
            FailText += "\n验证码=请检查是否出现了验证码？";
            FailText += "\n密码错误=登录名或密码错误？";
            FailText += "\n密码不正确";
            FailText += "\n无效用户名";
            FailText += "\n登录失败";

            string[] Fail = FailText.Split(new char[] { '\n' });
            for (int i = 0; i < Fail.Length; i++) {
                if (Fail[i].Trim() != string.Empty) {
                    int index = Fail[i].IndexOf("=");
                    string text = Fail[i];
                    string str = Fail[i];
                    if (index != -1) {
                        text = Fail[i].Substring(0, index);
                        str = Fail[i].Substring(index + 1);
                    } else {

                    }
                    if (html.Contains(text)) {

                        return str;
                    }
                }
            }
            return "NotFind";
        }
        /// <summary>
        /// 是否包含成功标记
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        protected bool VerifySucceed(string html, string SucceedTest) {
            string[] Succeed = SucceedTest.Split(new char[] { '\n' });
            for (int i = 0; i < Succeed.Length; i++) {
                if (Succeed[i].Trim() != string.Empty) {
                    if (html.Contains(Succeed[i])) {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region 替换功能，去除汉字，参数替换等。qin重构

        //除了 正文、标题，之外的所有参数替换。
        public virtual string _replace(string data) {
            if (string.IsNullOrEmpty(data)) {
                return "";
            }

            if (User != null && User.Id > -1) {
                data = data.Replace("[用户名]", User.Uname);
                data = data.Replace("[用户名@]", StringHelper.GetMetaString(User.Uname, "", "@", true));
                data = data.Replace("[密码]", User.Upass);
                data = data.Replace("[密码MD5]", StringHelper.CreateMd5(User.Upass, 32));
            }
            data = data.Replace("[网站域名]", Site.SiteDomain);
            data = data.Replace("[后台地址]", Site.SiteBackUrl);
            data = data.Replace("[验证码]", Site.Verify);

            if (data.Contains("[分类编号]")) {
                if (!string.IsNullOrEmpty(Site.PostID)) {
                    data = data.Replace("[分类编号]", Site.PostID);
                } else if (Task != null && !Task.IsRandUp && !string.IsNullOrEmpty(Task.PostCateIDs)) {
                    Site.PostID = StringHelper.getRandStr(Task.PostCateIDs);
                    data = data.Replace("[分类编号]", Site.PostID);
                } else {
                    Site.PostID = ArrayHelper.getRandOneFromArray(_getCateIDs());
                    data = data.Replace("[分类编号]", Site.PostID);
                }
            }

            data = data.Replace("[年]", DateTime.Now.Year.ToString());
            data = data.Replace("[月]", DateTime.Now.Month.ToString());
            data = data.Replace("[日]", DateTime.Now.Day.ToString());
            data = data.Replace("[时]", DateTime.Now.Hour.ToString());
            data = data.Replace("[分]", DateTime.Now.Minute.ToString());
            data = data.Replace("[秒]", DateTime.Now.Second.ToString());
            data = data.Replace("[随机数]", StringHelper.getRandNum(3).ToString());
            data = data.Replace("[主关键字]", ArrayHelper.getRandOneFromStrs(Site.SiteMainKeys.Split(',')));
            data = data.Replace("[来源]", Login_Base.member.netname);
            data = data.Replace("[临时值01]", Site.tmp01);
            data = data.Replace("[临时值02]", Site.tmp02);
            try {//防止没有实例化的异常。
                data = data.Replace("[随机关键字]", ArrayHelper.getRandOneFromStrs(Task.PickKeyword.Split(',')));
                data = data.Replace("[长尾记录单]", ArrayHelper.getRandOneFromStrs(Task.KeyWords.Split('\n')));

            } catch {
            }

            data = _replaceCHText(data);
            return data;
        }

        private ArrayList _getCateIDs() {
            string cateHtml = GetCategoryHtml();
            ArrayList al = RegexHelper.getMatchs(cateHtml, Site.CategoriesRegex, 1);
            return al;
        }


        /// <summary>
        /// 过滤掉汉字尖括号。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected string _replaceCHText(string text) {
            //Regex r = new Regex("<(.*?)>", RegexOptions.Multiline);
            //MatchCollection m = r.Matches(text);
            //foreach (Match math in m) {
            //    text = text.Replace("<" + math.Groups[1].Value + ">", HttpUtility.UrlEncode(math.Groups[1].Value));
            //}
            return text;

        }

        protected string _replaceRegexText(string html, string text) {

            Regex r = new Regex("{(.*?)}", RegexOptions.Multiline);
            MatchCollection m = r.Matches(text);
            int i = 0;
            foreach (Match math in m) {
                Match m1 = Regex.Match(html, math.Groups[1].Value, RegexOptions.Multiline);
                if (m1.Success && m1.Groups.Count > 1 && !string.IsNullOrEmpty(m1.Groups[1].ToString())) {
                    text = text.Replace("{" + math.Groups[1].Value + "}", m1.Groups[1].Value);
                }
                i++;
            }
            return text;

        }

        protected string _replaceRepText(string content) {
            try {
                if (!string.IsNullOrEmpty(this.Task.RepText)) {
                    string[] StrReplace = this.Task.RepText.Split('\n');
                    for (int i = 0; i < StrReplace.Length; i++) {
                        string tmpreg = StrReplace[i].ToString().Trim();
                        if (!tmpreg.Contains("→") && !string.IsNullOrEmpty(tmpreg)) {
                            content = content.Replace(tmpreg, "");
                        } else if (!string.IsNullOrEmpty(tmpreg)) {
                            string tmp01 = tmpreg.Split('→')[0].ToString();
                            string tmp02 = tmpreg.Split('→')[1].ToString();
                            content = RegexHelper.regReplaces(content, tmp01, tmp02);
                        }
                    }
                }
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
            return content;
        }
        /// <summary>
        /// 标题、正文处理 替换文件中的内容，即内容，
        /// </summary>
        /// <param name="data"></param>
        /// <param name="file"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public virtual string _replacePutContent(string data, Encoding encode) {
            try {
                data = _replace(data);

                string tmp_title = string.Empty;
                string tmp_content = string.Empty;

                //返回的是经过nohtml处理的title，content。
                _randFileToTitleAndConent(ref tmp_title, ref tmp_content);

                #region 如果获取到的文件不为空，那么进一步进行处理。


                if (!string.IsNullOrEmpty(tmp_content)) {
                    //过滤用户自定义规则。
                    tmp_content = _replaceRepText(tmp_content);

                    #region 标题进行严格的整理。

                    if (Task.IsTitleInsertKeyword && !Task.IsRandUp) {
                        tmp_title = _titleInsertKeyword(tmp_title, Task.KeyWords);
                    }

                    if ((string.IsNullOrEmpty(tmp_title) || tmp_title.Length < 14 || tmp_title.Contains("301")) && Task.IsTitleWYC) {
                        string[] sts = tmp_content.Split('。', '？', '！', '?', '!');
                        ArrayList al = new ArrayList();
                        for (int i = 0; i < sts.Length; i++) {
                            sts[i] = RegexHelper.regReplaces(sts[i].Trim(), @"<.*?>", "");//HTML。
                            if (sts[i].Trim().Length > 10) {
                                al.Add(sts[i].Trim());
                            }
                        }
                        tmp_title = ArrayHelper.getRandOneFromArray(al);
                    }
                    tmp_title = StringHelper.SubStringNoDDD(tmp_title, 0, Task.TitleLengthCut);

                    tmp_title = _replaceRepText(tmp_title);
                    tmp_title = RegexHelper.regReplaces(tmp_title, "[0-9]+?.", "");
                    tmp_title = RegexHelper.regReplaces(tmp_title, "[0-9]+?、", "");
                    tmp_title = RegexHelper.regReplaces(tmp_title, "\\([0-9]+?\\)", "");
                    tmp_title = RegexHelper.regReplaces(tmp_title, "（[0-9]+?）", "");
                    tmp_title = tmp_title
                        .Replace("[转载]", "")
                        .Replace("[置顶]", "")
                        .Replace("[恶搞]", "")
                        .Replace("[推荐]", "")
                        .Replace("、", "")
                        .Replace("，", "")
                        .Replace(",", "")
                        .Replace("”", "")
                        .Replace("“", "")
                        .Replace("。", "")
                        .Replace("%", "")
                        .Replace("％", "");
                    tmp_title = RegexHelper.regReplaces(tmp_title, @"[　 \f\n\r\t\v]{2,}", " ");//过滤标题中的空白字符。
                    if (Task.IsTitleWYC && !Task.IsRandUp) {
                        tmp_title = StringHelper.contentWYC(tmp_title, Task.ContentWYCLevelPercent);
                    }

                    #endregion

                    if (Task.IsContentWYC && !Task.IsRandUp)
                        tmp_content = StringHelper.contentWYC(tmp_content, Task.ContentWYCLevelPercent);

                    //正文截断，截取所要的字数。
                    tmp_content = StringHelper.SubStringNoDDD(tmp_content, 0, Task.ContentLengthCut);

                    if (!Task.IsRandUp) {
                        ArrayList alimg = new ArrayList();
                        ArrayList ala = new ArrayList();
                        ArrayList albr = new ArrayList();

                        if (Task.IsStandardization && !Task.IsRandUp) {
                            getStandardization_pre(ref tmp_content, ref alimg, ref ala, ref albr);
                        }

                        //先把随机关键词插入到正文中，以免影响到链轮链接。
                        tmp_content = _addRandKey(tmp_content, Task.KeyWords);

                        //替换断言库中的内容。
                        if (Task.IsSentence) {
                            tmp_content = _repRandSentence(tmp_content, Task.KeyWords);
                        }

                        //链轮插入正文的操作
                        if (Site.IsInternetLink && new Random().Next(10) < Convert.ToInt32(Site.LinkRate * 10)) {
                            string ip = SeoHelper.getIp(Site.SiteBackUrl);

                            ModelLinkCycle link1 = new JobLianlun().GetRandLink(ip);
                            ModelLinkCycle link2 = new JobLianlun().GetRandLink(ip);
                            ModelLinkCycle link3 = new JobLianlun().GetRandLink(ip);

                            switch (Site.SiteLinkType) {
                                case Linktype.头部声明:
                                    string tmpstr = link1.getTitleLink + "<br />" + link2.getTitleLink + "<br />" + link3.getTitleLink;
                                    tmpstr = StringHelper.StringTrim(tmpstr, "<br />");
                                    tmp_content = _addBinsert(tmp_content, tmpstr);
                                    break;
                                case Linktype.尾部追加:
                                    tmpstr = link1.getTitleLink + "<br />" + link2.getTitleLink + "<br />" + link3.getTitleLink;
                                    tmpstr = StringHelper.StringTrim(tmpstr, "<br />");
                                    tmp_content = _addEinsert(tmp_content, tmpstr);
                                    break;
                                default:
                                    tmpstr = link1.getKeyLink + "\n" + link2.getKeyLink + "\n" + link3.getKeyLink;
                                    tmpstr = StringHelper.StringTrim(tmpstr, "\n");
                                    tmp_content = _addRandKey(tmp_content, tmpstr);
                                    break;
                            }
                        }
                        tmp_content = _addBinsert(tmp_content, Task.Binsert);
                        tmp_content = _addEinsert(tmp_content, Task.Einsert);

                        if (Task.ISpicArticle && !Task.IsRandUp) {
                            tmp_content = getImageToArticle(tmp_content);
                        }

                        if (Task.IsStandardization && !Task.IsRandUp) {
                            tmp_content = getStandardization(tmp_content, alimg, ala, albr);
                        }
                    }
                    //链轮操作结束
                    if (Site.IsEN) {
                        EchoHelper.Echo("正在翻译该文章...", "任务翻译", EchoHelper.EchoType.任务信息);
                        tmp_title = StringHelper.translate(tmp_title);
                        tmp_content = StringHelper.translate(tmp_content);
                    }

                    this.Title = tmp_title;
                    this.ContentText = tmp_content;
#if DEBUG
                    this.ContentText += "注意：您所使用的是忍者站群的DEBUG版本，此版本用于内测使用，无法用于正式用途。www.renzhe.org";
                    this.Title += "_DEBUG内测版本";
#endif
                    data = data.Replace("[标题]", Title);
                    data = data.Replace("[正文]", ContentText);
                    data = data.Replace("[正文(UBB)]", StringHelper.HtmlToUBB(ContentText));
                    data = data.Replace("[摘要]", StringHelper.SubString(StringHelper.HtmlToUBB(ContentText), 0, 170));
                #endregion
                }
            } catch (Exception ex) {
                Task.TaskState = TaskState.等待终止;
                EchoHelper.EchoException(ex);
                return "";
            }

            return data;
        }

        /// <summary>
        /// 替换断言库中的内容。
        /// </summary>
        /// <param name="tmp_content"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private string _repRandSentence(string tmp_content, string p) {
            ArrayList al = new ArrayList();

            tmp_content = tmp_content.Replace("。", "。¤").Replace("？", "？¤").Replace("！", "！¤").Replace("，", "，¤").Replace("?", "?¤").Replace("!", "!¤");

            string[] sts = tmp_content.Split('¤');
            for (int i = 0; i < sts.Length; i++) {
                al.Add(sts[i]);
            }
            ArrayList tmp = new PickBase().getArticleFromSentence(Task);

            if (tmp.Count > 500) {
                for (int i = 0; i < al.Count; i++) {
                    int index = (i + 1) * Task.SentenceInsertBetween < al.Count - 1 ? (i + 1) * Task.SentenceInsertBetween : -1;
                    if (index != -1 && !al[index].ToString().Contains("∫") && !al[index].ToString().Contains("∮") && !al[index].ToString().Contains("∝")) {//若含有特殊内容，则不替换。
                        al[index] = ArrayHelper.getRandOneFromArray(tmp);
                        tmp.Remove(al[index]);
                    }
                }
            }

            string re = "";
            for (int i = 0; i < al.Count; i++) {
                re += al[i];
            }

            return re;
        }

        private void _randFileToTitleAndConent(ref string title, ref string content) {
            ArrayList al = FilesHelper.ReadDirectory(Application.StartupPath + Task.SavePath);
            if (al.Count < 1) {
                //EchoHelper.Echo("获取文章失败，请查看任务目录" + Task.SavePath + "中是否还存在文件...", Task.TaskName, EchoHelper.EchoType.普通信息);
                return;
            }
            Random rd = new Random();
            int i = rd.Next(al.Count);
            FileInfo file = (FileInfo)al[i];

            title = RegexHelper.regReplaces(file.Name.ToLower(), "\\d\\d\\.txt", "");//标题中过滤掉数字，在保存文件的时候产生的。
            title = RegexHelper.regReplaces(title, "\\d\\d\\.html", "");
            title = RegexHelper.regReplaces(title, "\\d\\d\\.htm", "");
            title = title.Replace(".txt", "").Replace(".html", "").Replace(".htm", "");
            content = FilesHelper.ReadFile(Application.StartupPath + Task.SavePath + file.Name, null);

#if !DEBUG
            if (!Task.IsRandUp && Task.IsArtDel) {
                file.Delete();
            }
#endif
        }

        #endregion

        #region 关键词加入，伪原创，前置，后置内容，等方法
        protected string _addBinsert(string html, string bstr) {
            if (bstr.Replace("\n<br />", "").Trim().Length > 0) {
                return bstr + Environment.NewLine + "<br name='brinster' />" + html;
            } else {
                return html;
            }

        }

        protected string _addEinsert(string html, string estr) {
            if (estr.Replace("\n<br />", "").Trim().Length > 0) {
                return html + Environment.NewLine + "<br name='brinster' />" + estr;
            } else {
                return html;
            }
        }

        /// <summary>
        /// 这里是传入的keys是一行一个的\n的txt类型的。
        /// </summary>
        /// <param name="title"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        protected string _titleInsertKeyword(string title, string keys) {
            int r = new Random().Next(100);
            if (r < 50) {
                string key = ArrayHelper.getRandOneFromStrs(keys.Split('\n'));
                key = StringHelper.FormatHtml(key);
                title = title.Insert(0, key + "_");
            }
            return title;
        }
        /// <summary>
        /// 随机插入关键链接
        /// </summary>
        /// <param name="html">html内容，尽量是村文本，没有进行高级的HTML插入判断</param>
        /// <param name="keys">想要插入的关键词链接集合，用\n分隔</param>
        /// <returns>结果String</returns>
        protected string _addRandKey(string html, string keys) {
            ArrayList al = new ArrayList();
            string re = "";

            html = html.Replace("。", "。¤").Replace("？", "？¤").Replace("！", "！¤").Replace("，", "，¤").Replace("?", "?¤").Replace("!", "!¤");

            string[] sts = html.Split('¤');
            for (int i = 0; i < sts.Length; i++) {
                al.Add(sts[i]);
            }

            if (al.Count > Task.KeyWordBetween && Task.KeyWordBetween != 0) {
                for (int i = 0; i < al.Count / Task.KeyWordBetween; i++) {
                    int j = i + 1;
                    if (j > Task.LinkMaxNum) {
                        break;
                    }
                    int max = j * Task.KeyWordBetween > al.Count ? al.Count : j * Task.KeyWordBetween;
                    int min = i > max ? max : i * Task.KeyWordBetween;
                    int index = new Random().Next(max / 3, max);
                    string key = ArrayHelper.getRandOneFromStrs(keys.Trim().Split('\n'));
                    if (!string.IsNullOrEmpty(key)) {
                        keys = keys.Replace(key + "\n", "").Replace(key, "");
                        al.Insert(index, key);
                    }

                }
            }

            //if (html.Length > 150) {
            //    int count1 = (html.Length / 150);
            //    int count2 = keys.Split('\n').Length;
            //    int count = count2 < count1 ? count2 : count1;
            //    int part = html.Length / count;

            //    for (int i = 0; i < count; i++) {
            //        int j = i + 1;
            //        int index = new Random().Next(i * part, j * part);
            //        string key = ArrayHelper.getRandOneFromStrs(keys.Trim().Split('\n'));
            //        if (!string.IsNullOrEmpty(key))
            //            keys = keys.Replace(key, "");

            //        if (index < html.Length) {
            //            html = html.Insert(index, key);
            //        }
            //    }
            for (int i = 0; i < al.Count; i++) {
                //string biaodian = al[i].ToString().Trim().Length > 10 ? "，" : "";
                if (!string.IsNullOrEmpty(al[i].ToString())) {
                    re += al[i].ToString().Trim();
                }
            }
            //re = StringHelper.StringRightTrim(re, "，");
            //re = StringHelper.StringRightTrim(re, "、");
            //re = re.Trim() + "。";

            return re.Trim();
        }

        #endregion

        #region 获取链接的<a>这样的格式。
        //public string GetLinkCycle(string str1, string str2) {
        //    string re = "";

        //    ModelLinkCycle link = new ModelLinkCycle();

        //    if (!Task.IsRandUp) {
        //        if (Site.IsInternetLink) {
        //            //如果启动了链轮功能，在库里查找不同IP的一条Link实体拿出来。
        //            for (int i = 0; i < ModelMain.AllData.LinkCycle.Count; i++) {
        //                if (Site.SiteIP != ModelMain.AllData.LinkCycle[i].ip && new xkHttpClient().UrlStatus(ModelMain.AllData.LinkCycle[i].url)) {
        //                    link = ModelMain.AllData.LinkCycle[i];
        //                    ModelMain.AllData.LinkCycle.RemoveAt(i);
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    int r = new Random().Next(30);
        //    if (r < 8 && !string.IsNullOrEmpty(link.keyword)) {
        //        re = link.getKeyLink;
        //    } else {
        //        re = link.getTitleLink;
        //    }
        //    if (!string.IsNullOrEmpty(re)) {
        //        re = str1 + re + str2;
        //    }
        //    return re;
        //}
        #endregion

        #region 加入到链轮库中。。。

        protected void AddToLianlun(string url) {
            int tmprand = new Random().Next(10);
            if (Site.IsInternetLink) {
                EchoHelper.Echo("看您是否有机会加入【忍者站群X链轮库】，计算中...", Task.TaskName, EchoHelper.EchoType.任务信息);
                if (tmprand < Convert.ToInt32(Site.LinkRate * 10)) {
                    EchoHelper.Echo("恭喜您，您的链接有机会加入到了【忍者站群X链轮库】中。", Task.TaskName, EchoHelper.EchoType.普通信息);
                    if (!string.IsNullOrEmpty(Title) & new xkHttp().httpStatus(url)) {
                        ModelLinkCycle mlink = new ModelLinkCycle();
                        mlink.id = ModelMain.AllData.LinkcycleID;
                        mlink.isInternal = Site.IsInternetLink;
                        mlink.author = Login_Base.member.netname;
                        mlink.title = Title;
                        mlink.keyword = StringHelper.getRandStr(Site.SiteMainKeys);
                        mlink.url = url;
                        mlink.ip = SeoHelper.getIp(url);
                        mlink.life = 2;
                        mlink.datetime = TimeHelper.ConvertDateTimeInt(DateTime.Now);
                        new JobLianlun().SendLink(mlink);
                    } else {
                        EchoHelper.Echo("加入链轮库的条件不符合，真遗憾，跳过：" + url, "链轮库", EchoHelper.EchoType.错误信息);
                    }
                } else {
                    EchoHelper.Echo("很遗憾，此次随机未能加入【忍者站群X链轮库】！", "", EchoHelper.EchoType.普通信息);
                }
            }

        }
        #endregion

        #region 拉取成功连接。
        protected string getSuccessUrl(string html) {
            string url = Site.SiteDomain;
            if (Site.PostSuccessPage.Contains("|")) {
                string gurl = _replace(Site.PostSuccessPage.Split('|')[0]);
                html = new xkHttp().httpGET(gurl, ref User.cookies);
                url = _replaceRegexText(html, Site.PostSuccessPage.Split('|')[1]);
                url = new xkHttp().getDealUrl(_replace(url));
            } else {
                url = _replaceRegexText(html, Site.PostSuccessPage);
                url = new xkHttp().getDealUrl(_replace(url));
            }

            if (url != Site.SiteDomain && !string.IsNullOrEmpty(url)) {
                try {
                    EchoHelper.Echo("尝试访问成功页面：" + url, "", EchoHelper.EchoType.普通信息);
                    if (new xkHttp().httpStatus(url)) {
                        User.LastUrl = url;
                        EchoHelper.Echo("恭喜您，此成功页面URL可正常访问！", "", EchoHelper.EchoType.普通信息);
                    }
                } catch {
                    EchoHelper.Echo("请手动查看页面是否正常：" + url, "", EchoHelper.EchoType.普通信息);
                }
            }

            return url;
        }

        protected void AddPuts(string url, string taskname, string reason) {
            ModelAllPut put = new ModelAllPut();
            put.reason = reason;
            put.taskName = taskname;
            put.url = url;
            new X_Form_AllPutView().Add(put);
            EchoHelper.Echo("成功入库历史发布结果！", taskname, EchoHelper.EchoType.任务信息);
        }

        #endregion

        /// <summary>
        /// 设置该任务的临时应用的账户
        /// </summary>
        public void setUser() {
            if (!string.IsNullOrEmpty(Task.userIDs)) {
                string[] userlist = Task.userIDs.Split(',');
                int userid = Convert.ToInt32(ArrayHelper.getRandOneFromStrs(userlist));
                this.User = Site.modelUsers.Find(delegate(ModelUsers user) {
                    return user.Id == userid;
                });
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 正文整理，预处理。
        /// </summary>
        /// <param name="content"></param>
        /// <param name="alimg"></param>
        /// <param name="ala"></param>
        /// <param name="albr"></param>
        protected void getStandardization_pre(ref string content, ref ArrayList alimg, ref  ArrayList ala, ref ArrayList albr) {
            NodeList htmlNodesImgs = new Parser(new Lexer(content)).Parse(new TagNameFilter("img"));
            NodeList htmlNodesAs = new Parser(new Lexer(content)).Parse(new TagNameFilter("a"));
            NodeList htmlNodesBR = new Parser(new Lexer(content)).Parse(new AttributeRegexFilter("name", "brinster"));

            for (int j = 0; j < htmlNodesImgs.Count; j++) {
                ImageTag img = (ImageTag)htmlNodesImgs.ElementAt(j);
                alimg.Add(img);
                content = content.Replace(img.ToHtml(), "∫" + j);
            }

            for (int j = 0; j < htmlNodesAs.Count; j++) {
                ATag A = (ATag)htmlNodesAs.ElementAt(j);
                ala.Add(A);
                content = content.Replace(A.ToHtml(), "∮" + j);
            }

            for (int j = 0; j < htmlNodesBR.Count; j++) {
                ITag BR = (ITag)htmlNodesBR.ElementAt(j);
                albr.Add(BR);
                content = content.Replace(BR.ToHtml(), "∝" + j);
            }

            //去掉HTML
            content = RegexHelper.regReplaces(content, "<.*?>", "");
            //去掉http链接等
            content = RegexHelper.regReplace(content, @"[a-zA-z]+://[^\s]*", "");                   //网址过滤1
            content = RegexHelper.regReplace(content, @"http://", "");                              //网址过滤1
            content = RegexHelper.regReplaces(content, @"www\.[a-zA-z0-9]+\.(com|net|org|cn)", ""); //网址过滤2
        }
        /// <summary>
        /// 正文整理，字数，标签，行高等等
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        protected string getStandardization(string content, ArrayList alimg, ArrayList ala, ArrayList albr) {
            string re = string.Empty;
            content = content.Replace("。", "。¤").Replace("？", "？¤").Replace("！", "！¤").Replace("，", "，¤").Replace("?", "?¤").Replace("!", "!¤");
            string[] sts = content.Split('¤');
            ArrayList al = new ArrayList();
            ArrayList al2 = new ArrayList();

            for (int i = 0; i < sts.Length; i++) {
                al.Add(sts[i]);
            }
            al2.Add("");

            int f = al.Count;
            int partLength = Convert.ToInt32(StringHelper.getRandStr("50,150,250,350"));

            if (f > 0) {
                int totle = al.Count;
                for (int i = 0; i < totle; i++) {
                    if (al2[al2.Count - 1].ToString().Trim().Length > partLength) {
                        al2[al2.Count - 1] += al[0].ToString().Trim();
                        al2.Add("");
                        partLength = Convert.ToInt32(StringHelper.getRandStr("50,150,250,350"));
                    } else if (al[0].ToString().Trim().Length > 0) {
                        al2[al2.Count - 1] += al[0].ToString().Trim();
                    }
                    al.RemoveAt(0);
                }
            } else {
                re = content;
            }
            for (int i = 0; i < al2.Count; i++) {
                if (al2[i].ToString().Trim().Length > 0) {
                    al2[i] = StringHelper.StringRightTrim(al2[i].ToString(), "，");
                    al2[i] = StringHelper.StringRightTrim(al2[i].ToString(), "、");
                    al2[i] = StringHelper.StringRightTrim(al2[i].ToString(), "。");
                    al2[i] = StringHelper.StringRightTrim(al2[i].ToString(), "？");
                    al2[i] = StringHelper.StringRightTrim(al2[i].ToString(), "！");
                    al2[i] = StringHelper.StringRightTrim(al2[i].ToString(), "!");
                    al2[i] = StringHelper.StringRightTrim(al2[i].ToString(), "?");

                    re += "<p style=\"text-indent:2em; padding:0px; margin:0px;line-height:240%;\">" + al2[i].ToString() + "。</p>\n\n";
                }
            }


            for (int j = 0; j < alimg.Count; j++) {
                ImageTag img = (ImageTag)alimg[j];
                re = re.Replace("∫" + j, "<br />" + img.ToHtml().Replace("\n", "").Replace("\r", "") + "<br />");
            }

            for (int j = 0; j < ala.Count; j++) {
                ATag A = (ATag)ala[j];
                re = re.Replace("∮" + j, A.ToHtml().Replace("\n", "").Replace("\r", ""));
            }

            for (int j = 0; j < albr.Count; j++) {
                ITag br = (ITag)albr[j];
                re = re.Replace("∝" + j, br.ToHtml());
            }

            //re = re.Replace("<br />", "。<br />")
            //        .Replace(">，", ">")
            //        .Replace(">、", ">")
            //        .Replace(">。", ">")
            //        .Replace("、。", "。")
            //        .Replace("，。", "。")
            //        .Replace("，。", "。")
            //        .Replace("。<", "<")
            //        ;

            return re;
        }

        protected string getImageToArticle(string str) {
            try {
                EchoHelper.Echo("随机挑选一张图片插入正文中...", Task.TaskName, EchoHelper.EchoType.任务信息);
                string keyValueLast = StringHelper.getRandStr(Task.PickKeyword.Replace('\n', ','));
                string imagehtml = new xkHttp().getImage(keyValueLast);
                str = str.Insert(0, imagehtml);
                EchoHelper.Echo("挑图完成：" + RegexHelper.getMatch(imagehtml, "src=\"(.*?)\"", 1), Task.TaskName, EchoHelper.EchoType.任务信息);
                return str;
            } catch (Exception ex) {
                EchoHelper.Echo("抱歉，获取随机图片失败：" + ex.Message, TaskName, EchoHelper.EchoType.异常信息);
                return "";
            }
        }




    }
}
