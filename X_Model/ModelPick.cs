using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using X_Service.Util;

namespace X_Model {
    [Serializable]
    public class ModelPick  {

        #region 模块的基本参数，作者，帮助等。
        public string PickName = string.Empty;

        public string ModelAuthor = string.Empty;
        public string ModelEmail = string.Empty;
        public string ModelQQ = string.Empty;
        public string ModelPassWord = string.Empty;
        public string ModelUrl = string.Empty;
        public string SiteModelDescription = string.Empty;
        public bool IsPub = false;
        #endregion

        /// <summary>
        /// 模块说明
        /// </summary>
        public string PickInfo = string.Empty;
        /// <summary>
        /// 采集首页
        /// </summary>
        public string IndexUrlStr;

        /// <summary>
        /// 采集首页的集合
        /// </summary>
        public ArrayList IndexUrls = new ArrayList();
        public bool isZhizhu = false;
        public string Urlhas = "";
        public string UrlnotHas = "";
        public string linCookies = "";

        /// <summary>
        /// 带采集的列表页面集合
        /// </summary>
        public ArrayList ListUrl = new ArrayList();

        public bool isAutoModelGet = false;
        /// <summary>
        /// 标题正则。
        /// </summary>
        public string TitleRegex = string.Empty;

        /// <summary>
        /// 内容正则规则，一行一个。
        /// </summary>
        public string ContentRegexs = string.Empty;

        /// <summary>
        /// 替换内容，一行一个，左右分隔=，把左面的替换成右边的。
        /// </summary>
        public string StrReplace = string.Empty;

        /// <summary>
        /// 抓取页面的间隔时间。
        /// </summary>
        public int IntervalTime = 200;

        public bool Noimg = false;
        public bool No2br = true;
        public bool SameTileFile = false;


        /// <summary>
        /// 默认最小字节是500，小于500的不进行抓取
        /// </summary>
        public int MinLength = 500;


        #region 待用的

        /// <summary>
        /// 获取 列表页面 的正则代码
        /// </summary>
        public string ListUrlRegex = string.Empty;
        /// <summary>
        /// 任务对应的关键词，可选，有时候需要，例如百度知道，问答等。
        /// </summary>
        public string KeyWord = string.Empty;
        /// <summary>
        /// 是否为UTF8
        /// </summary>
        public bool IsUtf8 = false;

        /// <summary>
        /// 对应的任务ID，
        /// </summary>
        public int TaskID = 1;

        /// <summary>
        /// 采集的域名 多属情况应该是以 /结尾。
        /// </summary>
        public string PickDomain = string.Empty;
        /// <summary>
        /// 内容分页的正则。
        /// </summary>
        public string ClistRegex = string.Empty;


        #endregion
    }
}
