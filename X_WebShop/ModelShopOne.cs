using System;
using System.Collections.Generic;
using System.Text;

namespace X_WebShop {

    /// <summary>
    /// 模块Model
    /// </summary>
    [Serializable]
    public class ModelShopOne {

        public string ModelName = string.Empty;
        public string ModelAuthor = string.Empty;
        public string ModelEmail = string.Empty;
        public string ModelQQ = string.Empty;
        public string ModelPassWord = string.Empty;
        public string ModelUrl = string.Empty;
        public string SiteModelDescription = string.Empty;
        public string FilePath = string.Empty;
        public bool IsPub = false;
        public DateTime LastUpDate = new DateTime();
        public long FileSize = 0;
        //发布模块
        public bool IsCoreSocket = false;
        public bool IsCoreWeb = false;
        //抓取模块
        public bool IsFanZhuaQu = false;

    }
}
