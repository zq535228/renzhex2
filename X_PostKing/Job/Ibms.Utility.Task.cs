﻿/******************************************************************************************** 
* (C)2003-2005 C2217 Studio 
*  http://www.cnblogs.com/dyj057/archive/2005/04/11/135383.html
*  保留所有权利 
*   
*  文件名称:                task.cs 
*  文件ID:           
*  编程语言:                C# 
*  文件说明:                实现计划任务的调度机制。可以显示多种任务调度机制(定义时间精确到秒)： 
*                            1.立即执行(一次) 
*                            2.计划执行(一次,可定义任务开始执行的日期) 
*                            3.立即执行(循环执行,多次) 
*                            4.计划执行(循环执行,多次,可定义任务开始执行的日期) 
*                            可以通过实现接口ISchedule 制定自己的执行计划 
*                    
* 当前版本:                    1.0 
* 替换版本:         
*  
* 作者:                        邓杨均 
* EMail:                    dyj057@gmail.com 
* 创建日期:                    2005-4-8 
* 最后修改日期:                2005-4-8 
*  
*历史修改记录: 
 
********************************************************************************************/
using System;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using X_PostKing.Job;

namespace Ibms.Utility.Task {

    #region 任务计划接口和一些标准实现
    /// <summary> 
    /// 计划的接口 
    /// </summary> 
    public interface ISchedule {
        /// <summary> 
        /// 返回最初计划执行时间 
        /// </summary> 
        DateTime ExecutionTime {
            get;
            set;
        }

        /// <summary> 
        /// 初始化执行时间于现在时间的时间刻度差 
        /// </summary> 
        long DueTime {
            get;
        }

        /// <summary> 
        /// 循环的周期 
        /// </summary> 
        long Period {
            get;
        }


    }


    /// <summary> 
    /// 计划立即执行任务 
    /// </summary> 
    public class ImmediateExecution : ISchedule {
        #region ISchedule 成员

        public DateTime ExecutionTime {
            get {
                // TODO:  添加 ImmediatelyShedule.ExecutionTime getter 实现 
                return DateTime.Now;
            }
            set {
                ;
            }
        }

        public long DueTime {
            get {
                return 0;
            }
        }


        public long Period {
            get {
                // TODO:  添加 ImmediatelyShedule.Period getter 实现 
                return Timeout.Infinite;
            }
        }

        #endregion
    }


    /// <summary> 
    /// 计划在某一未来的时间执行一个操作一次，如果这个时间比现在的时间小，就变成了立即执行的方式 
    /// </summary> 
    public class ScheduleExecutionOnce : ISchedule {

        /// <summary> 
        /// 构造函数 
        /// </summary> 
        /// <param name="schedule">计划开始执行的时间</param> 
        public ScheduleExecutionOnce(DateTime schedule) {
            m_schedule = schedule;
        }

        private DateTime m_schedule;

        #region ISchedule 成员

        public DateTime ExecutionTime {
            get {
                // TODO:  添加 ScheduleExecutionOnce.ExecutionTime getter 实现 
                return m_schedule;
            }
            set {
                m_schedule = value;
            }
        }


        /// <summary> 
        /// 得到该计划还有多久才能运行 
        /// </summary> 
        public long DueTime {
            get {
                long ms = (m_schedule.Ticks - DateTime.Now.Ticks) / 10000;

                if (ms < 0) ms = 0;
                return ms;
            }
        }


        public long Period {
            get {
                // TODO:  添加 ScheduleExecutionOnce.Period getter 实现 
                return Timeout.Infinite;
            }
        }


        #endregion
    }


    /// <summary> 
    /// 周期性的执行计划 
    /// </summary> 
    public class CycExecution : ISchedule {
        /// <summary> 
        /// 构造函数，在一个将来时间开始运行 
        /// </summary> 
        /// <param name="shedule">计划执行的时间</param> 
        /// <param name="period">周期时间</param> 
        public CycExecution(DateTime shedule, TimeSpan period) {
            m_schedule = shedule;
            m_period = period;
        }

        /// <summary> 
        /// 构造函数,马上开始运行 
        /// </summary> 
        /// <param name="period">周期时间</param> 
        public CycExecution(TimeSpan period) {
            m_schedule = DateTime.Now;
            m_period = period;
        }

        private DateTime m_schedule;
        private TimeSpan m_period;

        #region ISchedule 成员

        public long DueTime {
            get {
                long ms = (m_schedule.Ticks - DateTime.Now.Ticks) / 10000;

                if (ms < 0) ms = 0;
                return ms;
            }
        }

        public DateTime ExecutionTime {
            get {
                // TODO:  添加 CycExecution.ExecutionTime getter 实现 
                return m_schedule;
            }
            set {
                m_schedule = value;
            }


        }

        public long Period {
            get {
                // TODO:  添加 CycExecution.Period getter 实现 
                return m_period.Ticks / 10000;
            }
        }

        #endregion

    }


    #endregion

    #region 任务实现
    /// <summary> 
    /// 计划任务基类 
    /// 启动的任务会在工作工作线程中完成，调用启动方法后会立即返回。 
    ///  
    /// 用法： 
    /// (1)如果你要创建自己的任务，需要从这个类继承一个新类，然后重载Execute(object param)方法． 
    /// 实现自己的任务,再把任务加入到任务管理中心来启动和停止。 
    /// 比如： 
    /// TaskCenter center = new TaskCenter(); 
    /// Task newTask = new Task( new ImmediateExecution()); 
    /// center.AddTask(newTask); 
    /// center.StartAllTask(); 

    /// (2)直接把自己的任务写入TimerCallBack委托，然后生成一个Task类的实例， 
    /// 设置它的Job和JobParam属性，再Start就可以启动该服务了。此时不能够再使用任务管理中心了。 
    /// 比如： 
    /// Task newTask = new Task( new ImmediateExecution()); 
    ///    newTask.Job+= new TimerCallback(newTask.Execute); 
    ///    newTask.JobParam = "Test immedialte task"; //添加自己的参数 
    ///    newTask.Start(); 
    ///     
    /// </summary> 
    public class TaskBase : IDisposable {



        /// <summary> 
        /// 启动任务 
        /// </summary> 
        public void Start() {
            //启动定时器 
            m_timer = new Timer(m_execTask, m_param, m_schedule.DueTime, m_schedule.Period);
        }


        /// <summary> 
        /// 停止任务 
        /// </summary> 
        public void Stop() {
            //停止定时器 
            m_timer.Change(Timeout.Infinite, Timeout.Infinite);

        }


        /// <summary> 
        /// 任务内容 
        /// </summary> 
        /// <param name="param">任务函数参数</param> 
        public virtual void Execute(object param) {

            //你需要重载该函数,但是需要在你的新函数中调用base.Execute(); 
            m_lastExecuteTime = DateTime.Now;
            //Console.WriteLine(m_lastExecuteTime);

            if (m_schedule.Period == Timeout.Infinite) {
                m_nextExecuteTime = DateTime.MaxValue; //下次运行的时间不存在 
            } else {
                TimeSpan period = new TimeSpan(m_schedule.Period * 10000);
                m_nextExecuteTime = m_lastExecuteTime + period;
            }

        }


        /// <summary> 
        /// 任务下执行时间 
        /// </summary> 
        public DateTime NextExecuteTime {
            get {
                return m_nextExecuteTime;
            }
        }

        DateTime m_nextExecuteTime;
        /// <summary> 
        /// 执行任务的计划 
        /// </summary> 
        public ISchedule Shedule {
            get {
                return m_schedule;
            }
        }

        protected ISchedule m_schedule;

        /// <summary> 
        /// 系统定时器 
        /// </summary> 
        private Timer m_timer;

        /// <summary> 
        /// 任务内容 
        /// </summary> 
        public TimerCallback Job {
            get {
                return m_execTask;
            }
            set {
                m_execTask = value;
            }
        }

        private TimerCallback m_execTask;

        /// <summary> 
        /// 任务参数 
        /// </summary> 
        public object JobParam {
            set {
                m_param = value;
            }
        }
        private object m_param;

        /// <summary> 
        /// 任务名称 
        /// </summary> 
        public string Name {
            get {
                return m_name;
            }
            set {
                m_name = value;
            }
        }
        private string m_name;


        /// <summary> 
        /// 任务描述 
        /// </summary> 
        public string Description {
            get {
                return m_description;
            }
            set {
                m_description = value;
            }
        }
        private string m_description;

        /// <summary> 
        /// 该任务最后一次执行的时间 
        /// </summary> 
        public DateTime LastExecuteTime {
            get {
                return m_lastExecuteTime;
            }
        }
        private DateTime m_lastExecuteTime;



        public void Dispose() {
            GC.Collect();
            GC.SuppressFinalize(this);
        }


    }

    #endregion

    #region 启动任务

    /// <summary> 
    /// 任务管理中心 
    /// 使用它可以管理一个或则多个同时运行的任务 
    /// </summary> 
    public static class TaskExp {


        /// <summary> 
        /// 添加任务 
        /// </summary> 
        /// <param name="newTask">新任务</param> 
        public static void AddTask(JobCoreRun newTask) {
            m_scheduleTasks.Add(newTask);
        }

        /// <summary> 
        /// 删除任务 
        /// </summary> 
        /// <param name="delTask">将要删除的任务，你可能需要停止掉该任务</param> 
        public static void DelTask(JobCoreRun delTask) {
            m_scheduleTasks.Remove(delTask);
        }

        /// <summary> 
        /// 启动所有的任务 
        /// </summary> 
        public static void StartAllTask() {
            foreach (JobCoreRun task in ScheduleTasks) {
                StartTask(task);
            }
        }

        /// <summary> 
        /// 启动一个任务 
        /// </summary> 
        /// <param name="task"></param> 
        public static void StartTask(JobCoreRun task) {
            //标准启动方法 
            if (task.Job == null) {
                task.Job += new TimerCallback(task.Execute);
            }

            task.Start();
        }

        /// <summary> 
        /// 终止所有的任务 
        /// </summary> 
        public static void TerminateAllTask() {
            foreach (JobCoreRun task in ScheduleTasks) {
                TerminateTask(task);
            }
        }

        /// <summary> 
        /// 终止一个任务 
        /// </summary> 
        /// <param name="task"></param> 
        public static void TerminateTask(JobCoreRun task) {
            task.Stop();
        }

        /// <summary> 
        /// 获得所有的 
        /// </summary> 
        public static List<JobCoreRun> ScheduleTasks {
            get {
                return m_scheduleTasks;
            }
        }
        private static List<JobCoreRun> m_scheduleTasks = new List<JobCoreRun>();
    }

    #endregion
}