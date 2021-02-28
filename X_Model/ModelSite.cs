using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace X_Model {
    /// <summary>
    /// 站点信息
    /// </summary>
    [Serializable]
    public class ModelSite : ICloneable {


        #region 模块的基本参数，作者，帮助等。
        public string SiteName = string.Empty;

        public string ModelAuthor = string.Empty;
        public string ModelEmail = string.Empty;
        public string ModelQQ = string.Empty;
        public string ModelPassWord = string.Empty;
        public string ModelUrl = string.Empty;
        public string SiteModelDescription = string.Empty;
        public bool IsPub = false;

        #endregion

        #region 网站基本信息

        /// <summary>
        /// 站点ID
        /// </summary>
        public int SiteID = 1;

        private int lastUsersId = 1;
        public int LastUsersId {
            get {
                int lid;
                ArrayList al = new ArrayList();
                for (int i = 0; i < modelUsers.Count; i++) {
                    al.Add(modelUsers[i].Id);
                }
                lid = getNextID(al);
                return lid;
            }
            set {
                lastUsersId = value;
            }
        }

        /// <summary>
        /// 模拟发布信息,这里考虑到多账户,随机选其中之一发布.所以用泛型来保持.
        /// </summary>
        public List<ModelUsers> modelUsers = new List<ModelUsers>();
        /// <summary>
        /// 站点域名
        /// </summary>
        public string SiteDomain = "http://";

        public DateTime DomainExpire = DateTime.Now.AddDays(-1);

        public int DomainleftDays {
            get {
                int d = (DomainExpire - DateTime.Now).Days;
                if (d < -1) {
                    d = -1;
                }
                return d;
            }
        }
        /// <summary>
        /// 是否是英文站点
        /// </summary>
        public bool IsEN = false;

        /// <summary>
        /// 是否开启互联网团队链轮
        /// </summary>
        public bool IsInternetLink = false;

        public double LinkRate = 0.2;

        public Linktype SiteLinkType = Linktype.正文随机插入;
        /// <summary>
        /// 百度的收录量
        /// </summary>
        public int BaiduNum = 0;

        /// <summary>
        /// 站点主要优化的关键词集合，用,分隔。
        /// </summary>
        public string SiteMainKeys = string.Empty;

        public string SitePM = string.Empty;
        /// <summary>
        /// 登录web模拟辅助
        /// </summary>
        public string WebLogin = string.Empty;

        /// <summary>
        /// 发布web模拟辅助
        /// </summary>
        public string WebPut = string.Empty;

        /// <summary>
        /// 发布方案
        /// </summary>
        public PostMode SitePostMode = PostMode.模拟发布;

        /// <summary>
        /// 是否Utf-8，如果否的话，那么自动判断是编码类型
        /// </summary>
        public bool SiteIsUtf8 = false;

        /// <summary>
        /// 后台地址
        /// </summary>
        public string SiteBackUrl = "http://www.xxxx.com/admin/";
        /// <summary>
        /// 所属组别
        /// </summary>
        public int GroupID = 1;

        /// <summary>
        /// 模块名称
        /// </summary>
        public string SiteModuleName = string.Empty;

        #endregion

        #region 分类参数

        public string tmp01 = string.Empty;
        public string tmp02 = string.Empty;

        public string tmp01Regex = string.Empty;
        public string tmp02Regex = string.Empty;

        /// <summary>
        /// 是否启用自动分类
        /// </summary>
        public bool CategoriesIsEnablad = false;

        private string categoriesUrl = string.Empty;
        /// <summary>
        /// 获取分类的地址
        /// </summary>
        public string CategoriesUrl {
            get {
                if (categoriesUrl == null) {
                    categoriesUrl = string.Empty;
                }
                return categoriesUrl;
            }
            set {
                categoriesUrl = value;
            }
        }
        private string categoriesRegex = string.Empty;
        //public bool CateSocket = false;
        /// <summary>
        /// 正则表达式
        /// </summary>
        public string CategoriesRegex {
            get {
                if (categoriesRegex == null) {
                    categoriesRegex = string.Empty;
                }
                return categoriesRegex;
            }
            set {
                categoriesRegex = value;
            }
        }
        #endregion

        #region 登陆函数

        /// <summary>
        /// 是否启用验证码?,恩,都是LOGIN的,放一起 Ok
        /// </summary>
        public bool LoginNeedVerify = false;

        String loginParameters = string.Empty;
        String loginReferer = string.Empty;
        String loginSucceedText = string.Empty;
        String loginFailText = string.Empty;
        String loginMVerifyUrl = string.Empty;
        String loginLoginUrl = string.Empty;
        String loginVerifyUrl = string.Empty;
        LoginType loginType = LoginType.自动登陆模式;

        private bool loginIsUtf8 = false;
        /// <summary>
        /// 是否启用Utf-8编码
        /// </summary>
        public bool LoginIsUtf8 {
            set {
                if (value == this.postIsUtf8) {
                    this.SiteIsUtf8 = value;
                }
                this.loginIsUtf8 = value;

            }
            get {
                if (this.loginIsUtf8 == this.postIsUtf8) {
                    return this.SiteIsUtf8;
                } else {
                    return loginIsUtf8;
                }
            }
        }
        /// <summary>
        /// 验证码（适用于自动登录）
        /// </summary>
        public string Verify = string.Empty;

        /// <summary>
        /// 是否启动Socket方式登录
        /// </summary>
        //public bool LoginSocket = false;
        /// <summary>
        /// 登陆方式
        /// </summary>
        public LoginType LoginType {
            get {
                return loginType;
            }
            set {
                loginType = value;
            }
        }
        /// <summary>
        /// 登陆参数（适用于自动登录）
        /// </summary>
        public String LoginParameters {
            get {
                return loginParameters;
            }
            set {
                loginParameters = value;
            }
        }
        /// <summary>
        /// 来路URl
        /// </summary>
        public String LoginReferer {
            get {
                return loginReferer;
            }
            set {
                loginReferer = value;
            }
        }
        /// <summary>
        /// 成功字段
        /// </summary>
        public String LoginSucceedText {
            get {
                return loginSucceedText;
            }
            set {
                loginSucceedText = value;
            }
        }
        /// <summary>
        /// 失败字段
        /// </summary>
        public String LoginFailText {
            get {
                return loginFailText;
            }
            set {
                loginFailText = value;
            }
        }
        /// <summary>
        /// 马甲验证地址（适用于马甲登陆）
        /// </summary>
        public String LoginMVerifyUrl {
            get {
                return loginMVerifyUrl;
            }
            set {
                loginMVerifyUrl = value;
            }
        }
        /// <summary>
        /// 登陆地址（适用于自动登录）
        /// </summary>
        public String LoginLoginUrl {
            get {
                return loginLoginUrl;
            }
            set {
                loginLoginUrl = value;
            }
        }
        /// <summary>
        /// 验证码地址（适用于自动登录）
        /// </summary>
        public String LoginVerifyUrl {
            get {
                return loginVerifyUrl;
            }
            set {
                loginVerifyUrl = value;
            }
        }

        public string LoginCookies = string.Empty;
        #endregion

        #region 发布参数
        private bool postIsUtf8 = false;

        /// <summary>
        /// 是否启用Utf-8编码
        /// </summary>
        public bool PostIsUtf8 {
            set {
                if (value == this.LoginIsUtf8) {
                    this.SiteIsUtf8 = value;
                }
                this.postIsUtf8 = value;

            }
            get {
                if (this.postIsUtf8 == this.loginIsUtf8) {
                    return this.SiteIsUtf8;
                } else {
                    return postIsUtf8;
                }
            }
        }
        String postParameters = string.Empty;
        String thispostID = string.Empty;
        String postReferer = string.Empty;
        String postUrl = string.Empty;
        String postSucceedText = string.Empty;
        String postFailText = string.Empty;
        String postID = string.Empty;

        /// <summary>
        /// 每批等待时间，显示的时候设置的是秒
        /// </summary>
        public int perWait = 0;

        public bool IsMutilPost = false;

        public bool IsPostOnGzip = false;
        /// <summary>
        /// 成功提交后,用户浏览器访问的,可以看到的成功URL.
        /// </summary>
        public String PostSuccessPage = string.Empty;

        /// <summary>
        /// 成功后，访问页面，一行一个，可以用于生成HTML的处理。
        /// </summary>
        public string PostSuccessVisitList = string.Empty;
        /// <summary>
        /// 发布参数
        /// </summary>
        public String PostParameters {
            get {
                return postParameters;
            }
            set {
                postParameters = value;
            }
        }
        /// <summary>
        /// 来路URl
        /// </summary>
        public String PostReferer {
            get {
                return postReferer;
            }
            set {
                postReferer = value;
            }
        }
        /// <summary>
        /// 发布URl
        /// </summary>
        public String PostUrl {
            get {
                return postUrl;
            }
            set {
                postUrl = value;
            }
        }
        /// <summary>
        /// 成功字段
        /// </summary>
        public String PostSucceedText {
            get {
                return postSucceedText;
            }
            set {
                postSucceedText = value;
            }
        }
        /// <summary>
        /// 失败字段
        /// </summary>
        public String PostFailText {
            get {
                return postFailText;
            }
            set {
                postFailText = value;
            }
        }
        /// <summary>
        /// 所有分类ID
        /// </summary>
        public String PostID {
            get {
                if (postID == null) {
                    postID = string.Empty;
                }
                return postID;
            }
            set {
                postID = value;
            }
        }
        /// <summary>
        /// 随机ID
        /// </summary>
        /// <returns></returns>
        //public void GetPostID() {
        //    string[] arr = PostID.Split(',');
        //    Random r = new Random();
        //    CurrentPostID = arr[r.Next(1, arr.Length - 1)];
        //}
        /// <summary>
        /// 当前Post的ID
        /// </summary>
        //public String CurrentPostID {
        //    get {
        //        if (thispostID == null) {
        //            thispostID = string.Empty;
        //        }
        //        return thispostID;
        //    }
        //    set {
        //        thispostID = value;
        //    }
        //}

        /// <summary>
        /// 是否启动Socket方式提交
        /// </summary>
        //public bool PostSocket = false;

        #endregion

        public static int getNextID(ArrayList al) {
            int max = 0;
            try {
                for (int i = 0; i < al.Count; i++) {
                    int current = int.Parse(al[i].ToString());
                    if (current > max) {
                        max = current;
                    }
                }
                max += 1;
            } catch {
            }
            return max;
        }


        public object Clone() {
            //创建内存流 
            MemoryStream ms = new MemoryStream();
            //以二进制格式进行序列化 
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, this);
            //反序列化当前实例到一个object 
            ms.Seek(0, 0);
            object obj = bf.Deserialize(ms);
            //关闭内存流 
            ms.Close();
            return obj;
        }
    }
    /// <summary>
    /// 发布方案
    /// </summary>
    [Serializable]
    public enum PostMode {
        接口发布,
        模拟发布,
        随机马甲发布,
    }
    /// <summary>
    /// 发布方案
    /// </summary>
    [Serializable]
    public enum Linktype {
        头部声明,
        正文随机插入,
        尾部追加,
    }

    /// <summary>
    /// 登陆方案
    /// </summary>
    [Serializable]
    public enum LoginType {
        自动登陆模式,
        马甲登陆模式,
    }


}
