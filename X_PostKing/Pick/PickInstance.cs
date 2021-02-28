using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;
using X_Model;
using X_Service.Db;
using X_Service.Fetch;
using X_Service.Files;
using X_Service.Util;
using X_Service.Web;
using System.Net;

namespace X_PostKing.Pick {
    public class PickInstance : PickBase {

        public PickInstance(ModelPick pick, ModelTasks task) {
            base.task = task;
            base.pick = pick;
        }


        #region 采集页面的方法，这个功能应该单独做一个类，等待重构。
        /// <summary>
        /// 采集，先获取list内容，再去找内页内容。最后保存到task.SavePath
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="task"></param>
        public void Pick() {
            EchoHelper.Echo("采集【" + pick.PickName + "】开始了！这个过程较长，请耐心等待。。。", task.TaskName, EchoHelper.EchoType.任务信息);
            FilesHelper.CreateDirectory(Application.StartupPath + task.SavePath);
            try {
                string ckeyword = ArrayHelper.getFirst(task.PickKeyword.Split(','));
                pick.IndexUrls = getIndexUrls(ckeyword);
                pick.ListUrl = getListUrls();
                pickFromUrl();
                EchoHelper.Echo("恭喜大侠，采集【" + task.TaskName + "】任务完毕！！！", task.TaskName, EchoHelper.EchoType.普通信息);
            } catch (Exception ex) {
                EchoHelper.Echo("采集出错！" + ex.Message, task.TaskName, EchoHelper.EchoType.错误信息);
            }

        }

        /// <summary>
        /// 获取入口的集合，如果含有关键词，那么进行替换，如果还有[0-9]等变量，那么也进行处理。
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>返回入口的集合</returns>
        private ArrayList getIndexUrls(string keyword) {
            string keyIndexUrl = pick.IndexUrlStr;

            if (pick.IndexUrlStr.Contains("[关键词")) {

                if (string.IsNullOrEmpty(task.PickKeyword)) {
                    EchoHelper.Echo("主关键词不要为空，因为你设定了采集INDEX页面的【关键词】", task.TaskName, EchoHelper.EchoType.错误信息);
                } else {
                    string keywordGBK = HttpUtility.UrlEncode(keyword, Encoding.Default).ToUpper();
                    string keywordUTF8 = HttpUtility.UrlEncode(keyword, Encoding.UTF8).ToUpper();
                    keyIndexUrl = pick.IndexUrlStr.Replace("[关键词GBK]", keywordGBK).Replace("[关键词UTF8]", keywordUTF8);
                }
            }
            //替换[0-9]，的格式。返回首页URL数组。
            getIndexUrlList(keyIndexUrl, ref pick.IndexUrls);
            return pick.IndexUrls;
        }

        /// <summary>
        /// 获取内容页的集合。
        /// </summary>
        /// <returns>内容页的集合</returns>
        private ArrayList getListUrls() {
            EchoHelper.EchoPickStart("内容聚合开始，请耐心等候...");
            pick.ListUrl.Clear();
            CookieCollection cookies = new CookieCollection();

            int existNum = 0;//跳过不采集的网页内容页面数。

            for (int i = 0; i < pick.IndexUrls.Count; i++) {

                if (task.TaskState == TaskState.等待终止)
                    break;
                string html = new xkHttp().httpGET(pick.IndexUrls[i].ToString(), ref cookies);
                ArrayList al = getListArray(html, pick);//获取到的内页集合，未判断是否采集过。

                getZhizhuUrlList(ref al);

                for (int j = 0; j < al.Count; j++) {
                    if (!pick.ListUrl.Contains(al[j])) {
                        pick.ListUrl.Add(al[j]);
                    } else {
                        existNum++;
                    }
                }

            }
            EchoHelper.Echo("待采集内容页面累计：" + pick.ListUrl.Count + "条，过滤掉的页面共" + existNum + "条。", "内容聚合", EchoHelper.EchoType.任务信息);
            EchoHelper.EchoPickEnd("恭喜你，内容页面集合收集完毕。");
            return pick.ListUrl;
        }



        /// <summary>
        /// 内容页的集合，采集过的都集合起来。
        /// </summary>
        private ArrayList getListArray(string html, ModelPick pick) {
            ArrayList al = new ArrayList();
            NodeFilter filter = new TagNameFilter("a");

            EchoHelper.Echo("开始分析节点，如果网页内容很多，那么将比较耗时，请耐心等候...", "节点分析", EchoHelper.EchoType.任务信息);
            NodeList htmlNodes = new Parser(new Lexer(html)).Parse(filter);

            for (int i = 0; i < htmlNodes.Count; i++) {
                ATag t = (ATag)htmlNodes.ElementAt(i);
                string urlpart = t.GetAttribute("href");

                if (urlpart != null) {
                    urlpart = new xkHttp().getDealUrl(pick.IndexUrlStr, urlpart);

                    bool isadd = true;
                    string[] urlhas = pick.Urlhas.Split('|');
                    if (urlhas.Length > 0 && !string.IsNullOrEmpty(urlhas[0])) {
                        for (int j = 0; j < urlhas.Length; j++) {
                            if (string.IsNullOrEmpty(urlhas[j]) || !urlpart.Contains(urlhas[j])) {
                                isadd = false;
                            }
                        }
                    }

                    string[] urlnothas = pick.UrlnotHas.Split('|');
                    if (urlnothas.Length > 0 && !string.IsNullOrEmpty(urlnothas[0])) {
                        for (int j = 0; j < urlnothas.Length; j++) {
                            if (string.IsNullOrEmpty(urlnothas[j]) || urlpart.Contains(urlnothas[j])) {
                                isadd = false;
                            }
                        }
                    }
                    if (isadd && !al.Contains(urlpart) && !IsPicked(urlpart.GetHashCode())) {
                        al.Add(urlpart);
                    } else if (IsPicked(urlpart.GetHashCode())) {
                        EchoHelper.Echo("检测到此URL已经采集，跳过这条数据！", "节点分析", EchoHelper.EchoType.普通信息);
                    }

                    if (al.Count > task.PickPageNums * 30) {//如果采集量到了，那么就break退出吧。
                        break;
                    }
                }

            }
            EchoHelper.Echo("共分析到" + htmlNodes.Count + "个节点，符合抓取要求的节点共" + al.Count + "个", "节点分析", EchoHelper.EchoType.普通信息);
            return al;
        }

        private void getZhizhuUrlList(ref ArrayList al) {
            ArrayList re = new ArrayList();
            CookieCollection cookies = new CookieCollection();
            if (pick.isZhizhu) {
                for (int i = 0; i < al.Count; i++) {
                    string html = new xkHttp().httpGET(al[i].ToString(), ref cookies);
                    NodeFilter filter = new TagNameFilter("a");
                    EchoHelper.Echo("开始分析节点，如果网页内容很多，那么将比较耗时，请耐心等候...", "节点分析", EchoHelper.EchoType.任务信息);
                    NodeList htmlNodes = new Parser(new Lexer(html)).Parse(filter);

                    for (int q = 0; q < htmlNodes.Count; q++) {
                        ATag t = (ATag)htmlNodes.ElementAt(q);
                        string urlpart = t.GetAttribute("href");

                        if (urlpart != null) {
                            urlpart = new xkHttp().getDealUrl(al[i].ToString(), urlpart);

                            bool isadd = true;
                            string[] urlhas = pick.Urlhas.Split('|');
                            if (urlhas.Length > 0 && !string.IsNullOrEmpty(urlhas[0])) {
                                for (int j = 0; j < urlhas.Length; j++) {
                                    if (string.IsNullOrEmpty(urlhas[j]) || !urlpart.Contains(urlhas[j])) {
                                        isadd = false;
                                    }
                                }
                            }

                            string[] urlnothas = pick.UrlnotHas.Split('|');
                            if (urlnothas.Length > 0 && !string.IsNullOrEmpty(urlnothas[0])) {
                                for (int j = 0; j < urlnothas.Length; j++) {
                                    if (string.IsNullOrEmpty(urlnothas[j]) || urlpart.Contains(urlnothas[j])) {
                                        isadd = false;
                                    }
                                }
                            }

                            if (isadd && !al.Contains(urlpart) && !IsPicked(urlpart.GetHashCode())) {
                                re.Add(urlpart);
                            }
                        }
                    }

                    if (re.Count > task.PickPageNums * 20) {//如果采集量到了，那么就break退出吧。
                        break;
                    }

                    EchoHelper.Echo("共分析到" + htmlNodes.Count + "个节点，本次抓取符合要求的节点共" + re.Count + "个", "节点分析", EchoHelper.EchoType.普通信息);
                }
            }

            for (int i = 0; i < al.Count; i++) {
                if (!re.Contains(al[i]) && !IsPicked(al[i].GetHashCode())) {
                    re.Add(al[i]);
                }
            }
            al = re;
        }

        /// <summary>
        /// 采集页面内容。自动判断 正则模式or智能模式。
        /// </summary>
        /// <param name="pick"></param>
        public void pickFromUrl() {
            string url = "";
            for (int i = 0; i < pick.ListUrl.Count; i++) {
                if (task.TaskState == TaskState.等待终止 || task.TaskState == TaskState.已终止)
                    break;

                url = pick.ListUrl[i].ToString();
                putPicked(url);//将此URL加入到已采集队列。

                string tmp_title = "";
                string tmp_content = "";

                if (pick.isAutoModelGet) {//智能获取模式
                    FetchContent.GetContentFromUrl(url, ref tmp_title, ref tmp_content);
                } else {//正则模式
                    FetchContent.GetContentFromUrl(url, ref tmp_title, ref tmp_content, pick.TitleRegex, pick.ContentRegexs);
                }

                //过滤与整理
                FetchContent.Filter(ref tmp_title, ref tmp_content, pick.StrReplace, pick.Noimg, pick.No2br);

                FetchContent.ImageSrc(ref tmp_content, url);

                saveArticalToFile(tmp_title, tmp_content);
                Thread.Sleep(pick.IntervalTime);//在采集页面的时候，暂停几秒钟。
            }

        }

        #endregion


    }
}
