using System;
using System.Collections.Generic;
using System.Text;

namespace X_Model {
    /// <summary>
    /// 群组信息
    /// </summary>
    [Serializable]
    public class ModelGroup {

        #region 私有字段
        private string _groupName;
        private int _groupID;
        #endregion

        #region 公开属性
        public string GroupName {
            get { return _groupName; }
            set { _groupName = value; }
        }

        public int GroupID {
            get { return _groupID; }
            set { _groupID = value; }
        }

        public int GroupFID = 0;
        #endregion

    }
}
