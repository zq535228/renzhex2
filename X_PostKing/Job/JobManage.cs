using System;
using System.Collections;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using X_Model;
using X_Quartz;
using X_Quartz.Impl;
using X_Service.Files;
using X_Service.Util;

namespace X_PostKing.Job {
    public static class JobManage {

        #region 初始化任务
        private static IScheduler scheduler;
        private static readonly object lockObj = new object();
        private static readonly object lockObj1 = new object();
        private static ISchedulerFactory sf;

        public static ISchedulerFactory GetSchedulerFactory() {
            if (sf == null) {
                lock (lockObj1) {
                    if (sf == null) {
                        sf = new StdSchedulerFactory();
                    }
                }
            }
            return sf;
        }
        public static IScheduler GetScheduler() {
            if (scheduler == null) {
                lock (lockObj) {
                    //获取默认调度器
                    scheduler = GetSchedulerFactory().GetScheduler();
                }
            }
            return scheduler;
        }



        #endregion

        #region 任务的相关方法。
        public static void JobRun(ModelSite site, ModelTasks task) {
            lock (lockObj) {
                if (scheduler == null) {
                    scheduler = GetScheduler();
                }
                ScheduleAdd(site, task);
                scheduler.Start();
                EchoHelper.Echo("任务：" + task.TaskID + "、" + task.TaskName + "→加入队列！任务队列总数：" + scheduler.JobGroupNames.Length + "个！", task.TaskName, EchoHelper.EchoType.普通信息);
            }
        }

        /// <summary>
        /// 加入计划。如果已存在，则不去会加入。
        /// </summary>
        /// <param name="site"></param>
        /// <param name="task"></param>
        private static void ScheduleAdd(ModelSite site, ModelTasks task) {
            try {
                JobDetail job = new JobDetail("任务_" + task.TaskID, task.TaskName, typeof(JobCoreRun));
                job.JobDataMap.Put("site", site);
                job.JobDataMap.Put("task", task);
                #region 创建Trigger
                Trigger trigger;//创建的任务类型。若果是简单任务，则启用简单触发器，否则为详尽的任务计划触发。
                if (task.IsPlan) {
                    if (string.IsNullOrEmpty(task.CroExp)) {
                        EchoHelper.Echo("该任务没有设置任务脚本，无法执行。", task.TaskName, EchoHelper.EchoType.错误信息);
                        return;
                    }
                    DateTime dt = (task.benginTime < DateTime.Now) ? DateTime.Now : task.benginTime;
                    trigger = new CronTrigger("trigger" + task.TaskID, "trigger_group" + task.TaskID, job.Name, job.Group, TimeHelper.DateTimeToUTC(dt), task.endTime, task.CroExp);
                } else {
                    trigger = new SimpleTrigger("trigger" + task.TaskID, "trigger_group" + task.TaskID, 1, TimeSpan.FromSeconds(60 * 60 * 5));
                }

                #endregion
                scheduler.ScheduleJob(job, trigger);
            } catch (Exception ex) {
                if (ex.Message.Contains("Unable to store Job with name")) {
                    EchoHelper.Echo("任务：" + task.TaskID + "、" + task.TaskName + "→启动失败！原因：已经在队列中！", "启动任务", EchoHelper.EchoType.错误信息);
                } else {
                    EchoHelper.EchoException(ex);
                }
            }
        }

        /// <summary>
        /// 终止任务。
        /// </summary>
        public static void ScheduleRemove(ModelTasks task) {
            try {
                EchoHelper.Echo("任务：" + task.TaskID + "、" + task.TaskName + "→终止请求已提交，请等待！任务队列总数：" + scheduler.JobGroupNames.Length + "个！", task.TaskName, EchoHelper.EchoType.普通信息);
                scheduler.PauseJob("任务_" + task.TaskID, task.TaskName);
                scheduler.DeleteJob("任务_" + task.TaskID, task.TaskName);
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
        }


        public static void TaskStatusRefresh(ModelTasks task) {
            if (scheduler != null) {
                string[] nowExecuts = scheduler.JobGroupNames;
                string tmp = ArrayHelper.getStrs(nowExecuts);

                if (tmp.Contains(task.TaskName)) {
                    if (task.TaskState == TaskState.等待终止) {
                        ScheduleRemove(task);
                    }
                } else {
                    if (task.TaskState != TaskState.已终止 && task.TaskState != TaskState.未启动) {
                        task.TaskState = TaskState.已终止;
                        EchoHelper.Echo("任务：" + task.TaskID + "、" + task.TaskName + "→任务已终止。任务队列还剩：" + nowExecuts.Length + "个！", task.TaskName, EchoHelper.EchoType.普通信息);
                    }
                }
                if (nowExecuts.Length == 0) {
                    //EchoHelper.Echo("恭喜您，本次所选任务全部执行完毕，任务队列已清空，等待您的再次调遣！", task.TaskName, EchoHelper.EchoType.普通信息);
                }
            }

        }


        /// <summary>
        /// 清理任务计划。
        /// </summary>
        /// <param name="scheduler"></param>
        public static void CleanUp() {
            string[] groups = scheduler.TriggerGroupNames;
            for (int i = 0; i < groups.Length; i++) {
                string[] names = scheduler.GetTriggerNames(groups[i]);
                for (int j = 0; j < names.Length; j++) {
                    scheduler.UnscheduleJob(names[j], groups[i]);
                }
            }

            groups = scheduler.JobGroupNames;
            for (int i = 0; i < groups.Length; i++) {
                string[] names = scheduler.GetJobNames(groups[i]);
                for (int j = 0; j < names.Length; j++) {
                    scheduler.DeleteJob(names[j], groups[i]);
                }
            }
        }


        #endregion
    }
}
