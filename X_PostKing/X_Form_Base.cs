using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Model;
using X_Service.Login;
using X_Service.Util;
using X_Service.Db;
using System.Threading;
using X_Service.Web;
using WeifenLuo.WinFormsUI.Docking;

namespace X_PostKing {
    public partial class X_Form_Base : Login_Base {

        #region 构造方法，这里还没其他方法

        public X_Form_Base() {
            InitializeComponent();
        }

        

        #endregion

        #region 查找的一些方法，大多数是通过ID。


        //根据任务ID,查找任务
        public ModelTasks FindTaskByID(int id) {
            ModelTasks task = new ModelTasks();
            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                if (ModelMain.AllData.TasksList[i].TaskID == id) {
                    task = ModelMain.AllData.TasksList[i];
                }
            }
            return task;
        }
        //根据站点ID,获取站点信息
        public ModelSite FindSiteByID(int siteID) {
            ModelSite site = new ModelSite();
            for (int i = 0; i < ModelMain.AllData.SiteList.Count; i++) {
                if (ModelMain.AllData.SiteList[i].SiteID == siteID) {
                    site = ModelMain.AllData.SiteList[i];
                }
            }
            return site;
        }
        //根据任务ID,获取任务索引
        public int FindTaskIndexByID(int taskID) {
            int re = -1;
            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                if (ModelMain.AllData.TasksList[i].TaskID == taskID) {
                    re = i;
                }
            }
            return re;
        }
        //根据站点Id查找站点
        public int FindSiteIndexIDByID(int id) {
            for (int i = 0; i < ModelMain.AllData.SiteList.Count; i++) {
                if (ModelMain.AllData.SiteList[i].SiteID == id) {
                    return i;
                }
            }
            return -1;
        }
        //根据群组Id查找群组
        public int FindGroupIndexByID(int id) {
            for (int i = 0; i < ModelMain.AllData.GroupList.Count; i++) {
                if (ModelMain.AllData.GroupList[i].GroupID == +id) {
                    return i;
                }
            }
            return 0;

        }

        public ModelUsers FindModelUserByID(ModelSite site, int id) {
            for (int i = 0; i < site.modelUsers.Count; i++) {
                if (site.modelUsers[i].Id == id) {
                    return site.modelUsers[i];
                }
            }
            return null;
        }

        #endregion

        #region 保存全部信息，包括同步链轮库等。
        protected void SaveAll() {
            new X_Form_TaskManage().UnInvoke_Task();
            DbTools db = new DbTools();
            string tmp_path = Application.StartupPath + "\\Config\\MainConfig.VDB";
            if (ModelMain.AllData.SiteList.Count > 0) {
                db.Save(tmp_path, "VCDS", ModelMain.AllData);
            }
            GC.Collect();
        }

        #endregion


        

    }
}
