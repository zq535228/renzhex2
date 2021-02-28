using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using X_Service.Login;

namespace X_Model {
    /// <summary>
    /// 这个类,主要用于记录用户信息
    /// </summary>
    [Serializable]
    public class ModelUsers {
        #region 构造
        private int id = 1;
        private String uname = string.Empty;
        private String upass = string.Empty;
        private String lastUrl = string.Empty;
        private String cookie = string.Empty;
        private LoginMethod loginMethod = LoginMethod.用户名登陆;
        private String loginUserAgent = string.Empty;
        private DateTime loginTime = DateTime.Now;
        private LoginState loginState = LoginState.未登录;
        #endregion

        /// <summary>
        /// 编号
        /// </summary>
        public int Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }
        /// <summary>
        /// 最后发布成功的链接
        /// </summary>
        public string LastUrl {
            get {
                return lastUrl;
            }
            set {
                lastUrl = value;
            }
        }

        private string other;

        public string Other {
            get {
                return other;
            }
            set {
                other = value;
            }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Upass {
            get {
                return upass;
            }
            set {
                upass = value;
            }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Uname {
            get {
                return uname;
            }
            set {
                uname = value;
            }
        }
        /// <summary>
        /// Cookie
        /// </summary>
        public string Cookie {
            get {
                if(cookie == null) {
                    cookie = string.Empty;
                }
                return cookie;
            }
            set {
                cookie = value;
            }
        }


        public CookieCollection cookies;

        /// <summary>
        /// 登陆方式
        /// </summary>
        public LoginMethod LoginMethod {
            get {
                return loginMethod;
            }
            set {
                loginMethod = value;
            }
        }
        /// <summary>
        /// User-Agent
        /// </summary>
        public String LoginUserAgent {
            get {
                if(loginUserAgent == null) {
                    loginUserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                }
                return loginUserAgent;
            }
            set {
                loginUserAgent = value;
            }
        }
        /// <summary>
        /// 最后活动时间
        /// </summary>
        public DateTime LoginTime {
            get {
                return loginTime;
            }
            set {
                loginTime = value;
            }
        }
        /// <summary>
        /// 登陆状态
        /// </summary>
        public LoginState LoginState {
            get {
                return loginState;
            }
            set {
                loginState = value;
            }
        }
        /// <summary>
        /// 计算时间差
        /// </summary>
        /// <returns></returns>
        public string GetTimeSub() {
            if(LoginState == LoginState.登陆失败) {
                return "登陆失败";
            }
            if(LoginState == LoginState.未登录) {
                return "从未";
            }
            DateTime Now = DateTime.Now;
            TimeSpan ts = Now - LoginTime;
            if(ts.Days.ToString() == "0" & ts.Minutes.ToString() == "0" & ts.Seconds < 5) {
                return "刚刚";
            }
            if(ts.Days.ToString() == "0" & ts.Minutes.ToString() == "0") {
                return ts.Seconds.ToString() + "秒前";
            } else if(ts.Days.ToString() == "0") {
                return ts.Minutes.ToString() + "分钟前";
            } else {
                LoginState = LoginState.未知;
                return ts.Days.ToString() + "天前";
            }
        }
    }
    /// <summary>
    /// 登陆方式
    /// </summary>
    [Serializable]
    public enum LoginMethod {
        用户名登陆,
        Cookie登陆,
    }

    [Serializable]
    public enum LoginState {
        未登录,
        未知,
        已登录,
        登陆失败,
    }
}
