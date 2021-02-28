using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using X_Service.Util;
using X_Service.Web;

namespace X_Model {

    /// <summary>
    /// 主程序数据
    /// </summary>
    [Serializable]
    public class ModelMain {

        #region 构造方法，初始化
        /// <summary>
        /// 本软件所有的需要保存的信息,都放在这里,静态化,全局使用.
        /// </summary>
        public static ModelMain AllData = new ModelMain();

        /// <summary>
        /// 构造函数
        /// </summary>
        public ModelMain() {
            ModelGroup group = new ModelGroup();
            group.GroupID = 1;
            group.GroupName = "默认群组";
            LastGroupId++;
            GroupList.Add(group);
        }
        #endregion

        #region 所有的集合。群组，站点，任务。

        /// <summary>
        /// 群组列表
        /// </summary>
        public List<ModelGroup> GroupList = new List<ModelGroup>();
        private int lastGroupId = 1;

        public int LastGroupId {
            get {
                int lid;
                ArrayList al = new ArrayList();
                for (int i = 0; i < GroupList.Count; i++) {
                    al.Add(GroupList[i].GroupID);
                }
                lid = ArrayHelper.getNextID(al);
                return lid;
            }
            set {
                lastGroupId = value;
            }
        }
        /// <summary>
        /// 站点列表
        /// </summary>
        public List<ModelSite> SiteList = new List<ModelSite>();

        private int lastSiteId;

        public int LastSiteId {
            get {
                int lid;
                ArrayList al = new ArrayList();
                for (int i = 0; i < SiteList.Count; i++) {
                    al.Add(SiteList[i].SiteID);
                }
                lid = ArrayHelper.getNextID(al);
                return lid;
            }
            set {
                lastSiteId = value;
            }
        }

        /// <summary>
        /// 任务列表
        /// </summary>
        public List<ModelTasks> TasksList = new List<ModelTasks>();
        private int lastTasksId;

        public int LastTasksId {
            get {
                int lid;
                ArrayList al = new ArrayList();
                for (int i = 0; i < TasksList.Count; i++) {
                    al.Add(TasksList[i].TaskID);
                }
                lid = ArrayHelper.getNextID(al);
                return lid;
            }
            set {
                lastTasksId = value;
            }
        }



        public List<ModelLinkCycle> LinkCycle = new List<ModelLinkCycle>();

        private int linkcycleID;
        public int LinkcycleID {
            get {
                int lid = 1;
                try {
                    ArrayList al = new ArrayList();
                    for (int i = 0; i < LinkCycle.Count; i++) {
                        al.Add(LinkCycle[i].id);
                    }
                    lid = ArrayHelper.getNextID(al);
                } catch {
                }
                return lid;
            }
            set {
                linkcycleID = value;
            }
        }
        #endregion

        #region 查找的一些方法，大多数是通过ID。


        //根据任务ID,查找任务
        public static ModelTasks FindTaskByID(int taskID) {
            ModelTasks task = new ModelTasks();
            return ModelMain.AllData.TasksList.Find(delegate(ModelTasks t) {
                return t.TaskID == taskID;
            });

            //for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
            //    if (ModelMain.AllData.TasksList[i].TaskID == id) {
            //        task = ModelMain.AllData.TasksList[i];
            //    }
            //}
            //return task;
        }

        //根据任务ID,查找任务
        public static ModelUsers FindUserByID(List<ModelUsers> users, int userID) {
            ModelUsers user = new ModelUsers();
            return users.Find(delegate(ModelUsers t) {
                return user.Id == userID;
            });

            //for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
            //    if (ModelMain.AllData.TasksList[i].TaskID == id) {
            //        task = ModelMain.AllData.TasksList[i];
            //    }
            //}
            //return task;
        }

        //根据站点ID,获取站点信息
        public static ModelSite FindSiteByID(int siteID) {
            ModelSite site = new ModelSite();
            return ModelMain.AllData.SiteList.Find(delegate(ModelSite s) {
                return s.SiteID == siteID;
            });

            //for (int i = 0; i < ModelMain.AllData.SiteList.Count; i++) {
            //    if (ModelMain.AllData.SiteList[i].SiteID == siteID) {
            //        site = ModelMain.AllData.SiteList[i];
            //    }
            //}
            //return site;
        }

        public static ModelUsers FindModelUserByID(ModelSite site, int id) {
            ModelSite user = new ModelSite();
            return site.modelUsers.Find(delegate(ModelUsers u) {
                return u.Id == id;
            });

            //for (int i = 0; i < user.modelUsers.Count; i++) {
            //    if (user.modelUsers[i].Id == id) {
            //        return user.modelUsers[i];
            //    }
            //}
            //return null;
        }

        //根据任务ID,获取任务索引
        public static int FindTaskIndexByID(int taskID) {
            int re = -1;

            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                if (ModelMain.AllData.TasksList[i].TaskID == taskID) {
                    re = i;
                }
            }
            return re;
        }
        //根据站点Id查找站点
        public static int FindSiteIndexIDByID(int id) {
            for (int i = 0; i < ModelMain.AllData.SiteList.Count; i++) {
                if (ModelMain.AllData.SiteList[i].SiteID == id) {
                    return i;
                }
            }
            return -1;
        }
        //根据群组Id查找群组
        public static int FindGroupIndexByID(int id) {
            for (int i = 0; i < ModelMain.AllData.GroupList.Count; i++) {
                if (ModelMain.AllData.GroupList[i].GroupID == +id) {
                    return i;
                }
            }
            return 0;

        }



        #endregion



    }
}
