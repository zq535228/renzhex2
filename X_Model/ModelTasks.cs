using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace X_Model {
    /// <summary>
    /// 任务信息
    /// </summary>
    [Serializable]
    public class ModelTasks {
        #region Event
        public delegate void Task_State_Changeed(ModelTasks task);
        public event Task_State_Changeed State_Change;
        #endregion

        #region 私有变量
        private string taskName;
        private TaskState taskState = TaskState.未启动;

        #endregion        /// <summary>


        /// <summary>
        /// 任务ID
        /// </summary>
        public int TaskID = 1;

        /// <summary>
        /// 站点ID,所属站点
        /// </summary>
        public int SiteID = 1;

        public List<ModelPick> modelPicks = new List<ModelPick>();

        /// <summary>
        /// 任务指派用户集合，用，分隔。
        /// </summary>
        public string userIDs = string.Empty;

        /// <summary>
        /// 任务名
        /// </summary>
        public string TaskName {
            get {
                return taskName;
            }
            set {
                taskName = value;
            }
        }

        /// <summary>
        /// 发布分类集合 用，分隔。
        /// </summary>
        public string PostCateIDs = string.Empty;
        /// <summary>
        /// 任务备注信息
        /// </summary>
        public string Other = string.Empty;

        /// <summary>
        /// 是否随机顶贴
        /// </summary>
        public bool IsRandUp = false;

        /// <summary>
        /// 关键词集合,用\n分隔,一行一个，所谓的长尾记录单
        /// </summary>
        public string KeyWords = string.Empty;

        private int keyWordBetween = 20;

        public int KeyWordBetween {
            get {
                return keyWordBetween == 0 ? 20 : keyWordBetween;
            }
            set {
                keyWordBetween = value;
            }
        }

        public int LinkMaxNum = 5;

        /// <summary>
        /// 保存路径,存放采集的文章
        /// </summary>
        public string SavePath = string.Empty;

        /// <summary>
        /// 任务文章，正文前插入内容
        /// </summary>
        public string Binsert = string.Empty;

        /// <summary>
        /// 任务文章，正文后插入内容
        /// </summary>
        public string Einsert = string.Empty;

        /// <summary>
        /// 替换过滤内容，\r\n分隔，支持正则，一行一个。
        /// </summary>
        public string RepText = string.Empty;

        /// <summary>
        /// 是否标题伪原创，正规化
        /// </summary>
        public bool IsTitleWYC = true;

        private int titleLengthCut = 50;

        public int TitleLengthCut {
            get {
                return titleLengthCut == 0 ? 50 : titleLengthCut;
            }
            set {
                titleLengthCut = value;
            }
        }

        private int contentLengthCut = 5000;
        /// <summary>
        /// 正文截断模式
        /// </summary>
        public int ContentLengthCut {
            get {
                return contentLengthCut == 0 ? 5000 : contentLengthCut;
            }
            set {
                contentLengthCut = value;
            }
        }

        /// <summary>
        /// 是否自动加入关键词，有软件自动出现50%几率插入。
        /// </summary>
        public bool IsTitleInsertKeyword = false;

        /// <summary>
        /// 是否内容伪原创
        /// </summary>
        public bool IsContentWYC = true;

        /// <summary>
        /// 是否开启断言库
        /// </summary>
        public bool IsSentence = true;

        public bool IsSentenceBuildArt = false;
        /// <summary>
        /// 是否自动加入采集库。
        /// </summary>
        public bool IsSentenceAuto = true;

        public bool IsArtDel = true;
        /// <summary>
        /// 入选断言的最少字节数。
        /// </summary>
        public int SentenceMinLength = 20;

        public int SentenceInsertBetween = 3;
        /// <summary>
        /// 是否启动计划任务
        /// </summary>
        public bool IsPlan = false;

        /// <summary>
        /// 是否开启文章正规化处理
        /// </summary>
        public bool IsStandardization = true;

        public bool ISpicArticle = false;
        /// <summary>
        /// 每批数量
        /// </summary>
        public int perNum = 2;

        /// <summary>
        /// 续航数量，低于此值，将触发采集。
        /// </summary>
        public int leftNum = 4;

        public int ContentWYCLevelPercent = 20;
        /// <summary>
        /// 任务状态
        /// </summary>
        public TaskState TaskState {
            get {
                return taskState;
            }
            set {
                if (taskState != value) {
                    taskState = value;
                    if (State_Change != null) {
                        State_Change(this);
                    }
                }

            }
        }
        /// <summary>
        /// 是否加载事件
        /// </summary>
        /// <returns></returns>
        public bool Is_LoadEvent() {
            if (State_Change != null) {
                return true;
            } else {
                return false;
            }
        }

        public void Clear_State() {
            if (Is_LoadEvent()) {
                State_Change = null;
            }
        }

        /// <summary>
        /// 执行任务的表达式。String类型的
        /// </summary>
        public String CroExp = string.Empty;

        /// <summary>
        /// 任务开始时间
        /// </summary>
        public DateTime benginTime;

        /// <summary>
        /// 任务结束时间
        /// </summary>
        public int PickPageNums = 10;
        public int PickPageStartNum = 0;
        public int PickMinContentNum = 150;

        public string PickKeyword = "";
        public bool pickNews = true;
        public bool pickBlog = true;
        public bool pickAsk = true;
        public bool pickQQzone = true;
        public bool pickGA = false;
        public bool pickEA = false;
        public bool pickAC = false;
    }


    public enum TaskState {
        未启动,
        运行中,
        采集中,
        登录中,
        发布中,
        睡眠中,
        等待终止,
        已终止,
    }
}
