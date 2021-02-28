using System;
using System.Collections.Generic;
using System.Text;
using X_Model;

namespace X_PostKing.Pick {
    public class PickManage {

        public static PickInstance GetInstance(ModelPick pick, ModelTasks task) {
            //IPick repick;

            //switch (typestr.ToLower()) {
            //    case "pickac":
            //        repick = new PickAC();
            //        break;
            //    case "pickbaiduzhidao":
            //        repick = new PickBaiduZhidao(task);
            //        break;
            //    case "pickblog":
            //        repick = new PickBlog(task);
            //        break;
            //    case "pickea":
            //        repick = new PickEA();
            //        break;
            //    case "pickga":
            //        repick = new PickGA(task);
            //        break;
            //    case "picknews":
            //        repick = new PickNews(task);
            //        break;
            //    case "pickqqzone":
            //        repick = new PickQQzone(task);
            //        break;

            //    default:
            //        repick = null;
            //        break;
            //}
            //new PickGA(task);
            return new PickInstance(pick, task); ;
        }
    }
}
