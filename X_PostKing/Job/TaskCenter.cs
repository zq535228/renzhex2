using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using X_Model;
using X_Service.Util;
using Ibms.Utility.Task;

namespace X_PostKing.Job {

    /// <summary> 
    /// 任务管理中心 
    /// 使用它可以管理一个或则多个同时运行的任务 
    /// </summary> 
    public static class TaskCenter {

        /// <summary>
        /// 开启一个任务。
        /// </summary>
        /// <param name="site"></param>
        /// <param name="task"></param>
        public static void TaskJoinAndStart(ModelSite site, ModelTasks task) {

            ISchedule schedule;
            if (!task.IsPlan) {
                schedule = new ImmediateExecution();
            } else {
                string[] strs = task.CroExp.Split(' ');
                schedule = new CycExecution(new TimeSpan(int.Parse(strs[0]), int.Parse(strs[1]), int.Parse(strs[2]), int.Parse(strs[3])));
            }

            JobCoreRun scheduleTask = new JobCoreRun(schedule);
            scheduleTask.Job += new TimerCallback(scheduleTask.Execute);
            scheduleTask.Site = site;
            scheduleTask.Task = task;
            Ibms.Utility.Task.TaskExp.AddTask(scheduleTask);
            Ibms.Utility.Task.TaskExp.StartTask(scheduleTask);

            EchoHelper.Echo("任务：" + task.TaskID + "、" + task.TaskName + "→加入队列！任务队列总数：" + Ibms.Utility.Task.TaskExp.ScheduleTasks.Count + "个！", task.TaskName, EchoHelper.EchoType.普通信息);

        }

        /// <summary> 
        /// 终止一个任务。 
        /// </summary> 
        /// <param name="task"></param>
        public static void TerminateOneTask(ModelTasks task) {
            JobCoreRun tmp = Ibms.Utility.Task.TaskExp.ScheduleTasks.Find(delegate(JobCoreRun job) { return job.TaskName == task.TaskName; });
            if (tmp != null) {
                Ibms.Utility.Task.TaskExp.TerminateTask(tmp);
                Ibms.Utility.Task.TaskExp.DelTask(tmp);
            }

            EchoHelper.Echo("任务：" + task.TaskID + "、" + task.TaskName + "→终止请求已提交，请等待！任务队列总数：" + Ibms.Utility.Task.TaskExp.ScheduleTasks.Count + "个！", task.TaskName, EchoHelper.EchoType.普通信息);
            task.TaskState = TaskState.等待终止;
        }

        public static void TaskStatusRefresh(ModelTasks task) {
            JobCoreRun j = Ibms.Utility.Task.TaskExp.ScheduleTasks.Find(delegate(JobCoreRun t) { return t.TaskName == task.TaskName; });
            if (j != null && task != null && j.Task.TaskState == TaskState.等待终止 && Ibms.Utility.Task.TaskExp.ScheduleTasks.Contains(j)) {
                TerminateOneTask(task);
            } else if (j == null && task != null && task.TaskState == TaskState.等待终止) {
                task.TaskState = TaskState.已终止;
                EchoHelper.Echo("任务：" + task.TaskID + "、" + task.TaskName + "→任务已终止。任务队列还剩：" + Ibms.Utility.Task.TaskExp.ScheduleTasks.Count + "个！", task.TaskName, EchoHelper.EchoType.普通信息);
            }
        }




    }
}
