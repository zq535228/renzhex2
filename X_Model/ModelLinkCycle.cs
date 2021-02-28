using System;
using System.Collections.Generic;
using System.Text;
using X_Service.Util;

namespace X_Model {

    /// <summary>
    /// 链轮实体类
    /// </summary>
    [Serializable]
    public class ModelLinkCycle {
        public int id = 0;
        public string title = string.Empty;
        public string keyword = string.Empty;
        public string url = string.Empty;
        public string ip = string.Empty;

        private int _datetime;
        public int datetime {
            get {
                if (0 == _datetime) {
                    return TimeHelper.ConvertDateTimeInt(DateTime.Now);
                } else {
                    return _datetime;
                }
            }
            set {
                _datetime = value;
            }
        }
        /// <summary>
        /// 链接生命值，每次被链接一次，这个值就会-1，如果变为零，那么就会被删除。
        /// </summary>
        public int life = 2;

        /// <summary>
        /// 是否团队链接
        /// </summary>
        public bool isInternal = false;

        public string author = string.Empty;

        public string byurl = string.Empty;

        private int _bydatetime;
        public int bydatetime {
            get {
                if (0 == _bydatetime) {
                    return TimeHelper.ConvertDateTimeInt(DateTime.Now);
                } else {
                    return _bydatetime;
                }
            }
            set {
                _datetime = value;
            }
        }

        public string getKeyLink {
            get {
                if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(keyword)) {
                    string re = "<a href='{0}' target='_blank'>{1}</a>";
                    return string.Format(re, this.url, this.keyword);
                } else {
                    return "";
                }
            }
        }

        public string getTitleLink {
            get {
                if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(title)) {
                    string re = "<a href='{0}' target='_blank'>{1}</a>";
                    return string.Format(re, this.url, this.title);
                } else {
                    return "";
                }
            }
        }

        /// <summary>
        /// 是否为主域名
        /// </summary>
        /// <returns></returns>
        public bool isWWW {
            get {
                return SeoHelper.isWWW(this.url);
            }
        }


    }
}
