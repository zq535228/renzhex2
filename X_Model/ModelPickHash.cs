using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace X_Model {
    [Serializable]
    public class ModelPickHash {
        /// <summary>
        /// 哈希值集合
        /// </summary>
        public ArrayList HashValue = new ArrayList();

        //private ArrayList _hashValue;

        ///// <summary>
        ///// 哈希值集合
        ///// </summary>
        //public ArrayList HashValue {
        //    get {
        //        if ( _hashValue == null ) {
        //            _hashValue = new ArrayList();
        //        }
        //        return _hashValue;
        //    }
        //    set { _hashValue = value; }
        //}
    }
}
