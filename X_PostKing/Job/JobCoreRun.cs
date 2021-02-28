using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using X_Model;
using X_Service.BBSLog;
using X_Service.Files;
using X_Service.Login;
using X_Service.Mail;
using X_Service.Util;
using X_Service.Web;

namespace X_PostKing.Job {
    /// <summary>
    /// 任务发布&登陆
    /// </summary>
    public class JobCoreRun : JobCoreBase {

        public List<ModelUsers> users = new List<ModelUsers> {
        };

        /// <summary> 
        /// 构造函数 
        /// </summary> 
        /// <param name="schedule">为每个任务制定一个执行计划</param> 
        public JobCoreRun(Ibms.Utility.Task.ISchedule schedule) {
            if (schedule == null) {
                throw (new ArgumentNullException("schedule"));
            }
            m_schedule = schedule;
        }


        public override void Execute(object param) {
            base.Execute(param);
            try {
                JobRunTH();//发现这里会异常退出，div提供的bug反馈。
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
            base.Dispose();
        }

        #region 发布任务开始执行。采集、登录、获取分类、发布的这个过程的入口线程。。

        private void JobRunTH() {

            //针对变更任务执行表达式后的小布丁，日后可以删掉。
            if (Task.CroExp.Split(' ').Length != 4) {
                this.Task.CroExp = StringHelper.getRandNextNum(0, 3) + " " + StringHelper.getRandNextNum(24) + " " + StringHelper.getRandNextNum(59) + " " + StringHelper.getRandNextNum(59);
            }

            if (Task.TaskState == TaskState.等待终止 || Task.TaskState == TaskState.已终止)
                return;
            EchoHelper.Echo("任务：" + Task.TaskID + "、" + Task.TaskName + "→任务被触发！", Task.TaskName, EchoHelper.EchoType.普通信息);

            //采集前，检查是否需要触发采集。
            int count = FilesHelper.ReadDirectory(Application.StartupPath + Task.SavePath).Count;
            if (count < Task.leftNum && !Task.IsRandUp) {
                Task.TaskState = TaskState.采集中;
                Task.PickKeyword = StringHelper.PutFirstToLast(Task.PickKeyword);

                if (Task.modelPicks != null) {
                    for (int i = 0; i < Task.modelPicks.Count; i++) {
                        Pick.PickManage.GetInstance(Task.modelPicks[i], Task).Pick();
                    }
                }

            }
            //采集后，依然为空。则return；
            count = FilesHelper.ReadDirectory(Application.StartupPath + Task.SavePath).Count;
            if (count < 1 && !Task.IsRandUp) {
                EchoHelper.Echo("发布文章的数量不足，请手动添加文章，路径：" + Task.SavePath, Task.TaskName, EchoHelper.EchoType.错误信息);
                EchoHelper.Echo("任务已经停止.....", Task.TaskName, EchoHelper.EchoType.任务信息);
                Mail.sendMail("您的发布文章数量不足-忍者X2", "您的任务[" + Task.TaskName + "],其中的文章不够一个批次的发布啦，请采集或者手动添加文章吧。\n[" + Task.SavePath + "]");
                Task.TaskState = TaskState.等待终止;
                return;
            }
            //循环登录、发布中
            for (int i = 0; i < Task.perNum; i++) {

                if (Task.TaskState == TaskState.等待终止 || Task.TaskState == TaskState.已终止)
                    return;
                setUser();
                Task.TaskState = TaskState.登录中;
                Login();
                if (Task.TaskState == TaskState.等待终止 || Task.TaskState == TaskState.已终止)
                    return;
                Task.TaskState = TaskState.发布中;
                Post();
                if (Task.TaskState != TaskState.等待终止 && Task.TaskState != TaskState.已终止) {
                    EchoHelper.Echo("任务进入" + Site.perWait / 1000 + "秒休眠...", Task.TaskName, EchoHelper.EchoType.任务信息);
                    Thread.Sleep(Site.perWait);
                }
            }

            if (!Task.IsPlan) {
                Task.TaskState = TaskState.等待终止;
            } else {
                Task.TaskState = TaskState.睡眠中;
                EchoHelper.Echo("任务：" + Task.TaskID + "、" + Task.TaskName + "→任务休眠中，等待被触发！", "", EchoHelper.EchoType.普通信息);
            }

        }

        #endregion

        #region 登陆重写登陆方法 派生于基类的Post
        /// <summary>
        /// 重写登陆方法
        /// </summary>
        /// <returns>返回Html代码</returns>
        public override string Login() {
            if (Site == null | User == null) {
                return "不允许空类型-----忍者";
            }
            if (Site.LoginType == LoginType.马甲登陆模式) {
                return CookieLogin();
            } else if (Site.LoginType == LoginType.自动登陆模式) {
                return AutoLogin();
            } else {
                return "登陆模式未确定-----忍者";
            }
        }

        /// <summary>
        /// 用户名登陆模式
        /// </summary>
        /// <returns>返回HTML</returns>
        private string AutoLogin() {
            try {
                CookieCollection cookies = new CookieCollection();

                #region 私有临时变量，准备工作
                string charset = Site.LoginIsUtf8 ? "UTF-8" : "GB2312";
                string tmp_FailText = string.Empty;

                string tmp_Login_Referer = _replace(Site.LoginReferer);
                string tmp_LoginCookies = _replace(Site.LoginCookies);
                xkCookies.UpCookie(ref cookies, tmp_Login_Referer, tmp_LoginCookies);

                string html = new xkHttp().httpGET(tmp_Login_Referer, ref cookies);
                string tmp_LoginParameters = _replaceRegexText(html, Site.LoginParameters);
                string tmp_LoginLoginUrl = _replace(Site.LoginLoginUrl);
                #endregion

                #region 验证码部分
                if (Site.LoginNeedVerify) {
                    string tmp_Login_VerifyUrl;
                    if (Site.LoginVerifyUrl.Split('|').Length > 1) {
                        string url = _replaceRegexText(html, _replace(Site.LoginVerifyUrl.Split('|')[1]));
                        html = new xkHttp().httpGET(url, ref cookies);
                        tmp_Login_VerifyUrl = _replaceRegexText(html, _replace(Site.LoginVerifyUrl.Split('|')[0]));
                    } else {
                        tmp_Login_VerifyUrl = _replaceRegexText(html, _replace(Site.LoginVerifyUrl));
                    }
                    byte[] byteRequest = new byte[1];
                    byteRequest = new xkHttp().httpBytes(tmp_Login_VerifyUrl, byteRequest, ref cookies);
                    X_Form_VCode vcode = new X_Form_VCode(new Bitmap(new MemoryStream(byteRequest)));
                    if (vcode.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        Site.Verify = vcode.key;
                    } else {
                        return "请求失败，没有验证码。";
                    }
                }
                #endregion

                #region 消息提示
                EchoHelper.Echo("正在申请" + User.Uname + "的登录Session信息...", TaskName, EchoHelper.EchoType.任务信息);
                #endregion

                #region 获取HTML
                tmp_LoginParameters = tmp_LoginParameters.Replace("→", "=").Replace("\r\n", "&");
                string postDataStr = _replace(tmp_LoginParameters);
                html = new xkHttp().httpPost(tmp_LoginLoginUrl, postDataStr, ref cookies, tmp_Login_Referer, Encoding.GetEncoding(charset));
                #endregion

                #region 验证是否成功
                if (VerifySucceed(html, Site.LoginSucceedText)) {
                    User.cookies = cookies;
                    User.LoginTime = DateTime.Now;
                    EchoHelper.Echo("恭喜您" + User.Uname + "，登录成功！", TaskName, EchoHelper.EchoType.任务信息);
                    User.LoginState = LoginState.已登录;
                #endregion

                } else if ((tmp_FailText = VerifyFail(html, Site.LoginFailText)) != "NotFind") {
                    #region 验证是否失败
                    EchoHelper.Echo("抱歉" + User.Uname + "，登陆失败！失败原因：" + tmp_FailText, TaskName, EchoHelper.EchoType.错误信息);
                    User.LoginState = LoginState.登陆失败;
                    #endregion
                } else {
                    #region 没有找到标志
                    FilesHelper.WriteFile(Application.StartupPath + @"\Log\未知标识\【" + Site.SiteName + "】登录没有找到标志_" + DateTime.Now.Millisecond.ToString() + ".html", html, Encoding.GetEncoding(charset));
                    EchoHelper.Echo("抱歉，提交失败！失败原因：未知。确定您的参数提交正确？", TaskName, EchoHelper.EchoType.错误信息);
                    User.LoginState = LoginState.登陆失败;
                    Mail.sendMail("【" + Site.SiteName + "】站点出现问题，请核查！", "您的任务[" + Task.TaskName + "],未能发布成功。\n[" + Task.SavePath + "] \n\n具体内容：\n" + html);
                    #endregion
                }
                return html;
            } catch (Exception e) {
                return EchoHelper.EchoException(e);
            }

        }

        /// <summary>
        /// 马甲登陆模式
        /// </summary>
        /// <returns></returns>
        private string CookieLogin() {
            try {
                #region 马甲登陆私有变量
                string charset = Site.LoginIsUtf8 ? "UTF-8" : "GB2312";
                string tmp_LoginMVerifyUrl = _replace(Site.LoginMVerifyUrl);
                string tmp_LoginReferer = _replace(Site.LoginReferer);
                string tmp_FailText = string.Empty;
                #endregion

                #region 消息提示
                EchoHelper.Echo("正在访问登陆识别页面" + tmp_LoginMVerifyUrl, TaskName, EchoHelper.EchoType.任务信息);
                #endregion

                #region 获取HTML
                string html = new xkHttp().httpGET(tmp_LoginMVerifyUrl, ref User.cookies);
                #endregion

                if (VerifySucceed(html, Site.LoginSucceedText)) {
                    User.LoginTime = DateTime.Now;
                    EchoHelper.Echo("恭喜您，登陆成功！", TaskName, EchoHelper.EchoType.任务信息);
                    User.LoginState = LoginState.已登录;
                } else if ((tmp_FailText = VerifyFail(html, Site.LoginFailText)) != "NotFind") {
                    EchoHelper.Echo("抱歉，登陆失败！失败原因：" + tmp_FailText, TaskName, EchoHelper.EchoType.错误信息);
                    User.LoginState = LoginState.登陆失败;
                } else {
                    FilesHelper.WriteFile(Application.StartupPath + @"\Log\未知标识\【" + Site.SiteName + "】登陆失败_" + DateTime.Now.Millisecond + ".html", html, Encoding.GetEncoding(charset));
                    EchoHelper.Echo("抱歉，提交失败！失败原因：未知。确定您的参数提交正确？勾选UTF8试试", TaskName, EchoHelper.EchoType.错误信息);
                    User.LoginState = LoginState.登陆失败;
                }
                return html;

            } catch (Exception e) {
                return EchoHelper.EchoException(e);
            }
        }

        #endregion

        #region 发布 派生于基类的Post
        /// <summary>
        /// 重写后的发布方法
        /// </summary>
        /// <returns></returns>
        public override string Post() {
            string html = "";
            if (Site == null | User == null) {
                EchoHelper.Echo("站点不存在，或者所选用户不存在，请重建任务、排查原因！", Task.TaskName, EchoHelper.EchoType.错误信息);
            } else if (User.LoginState != LoginState.已登录) {
                EchoHelper.Echo("当前用户没有登陆成功，无法发布，请先让该用户登陆。", Task.TaskName, EchoHelper.EchoType.普通信息);
            } else {
                Site.PostID = "";
                html = Task_Post();
            }
            return html;
        }


        /// <summary>
        /// 任务发布类
        /// </summary>
        /// <returns></returns>
        private string Task_Post() {
            try {
                if (Login_Base.member.userMoney < 2) {
                    EchoHelper.Echo("抱歉，发布失败！失败原因：金币不足！", TaskName, EchoHelper.EchoType.错误信息);
                    AddPuts("", TaskName, "抱歉，发布失败！失败原因：金币不足！");
                    Task.TaskState = TaskState.等待终止;
                    return "";
                }

                #region 发布的私有变量
                string html;

                Site.tmp01 = this.GetTempValue(Site.tmp01Regex);
                Site.tmp02 = this.GetTempValue(Site.tmp02Regex);

                string charset = Site.PostIsUtf8 ? "UTF-8" : "GB2312";
                string tmp_PostData = Site.PostParameters;
                string tmp_FailText = string.Empty;



                #endregion

                #region 发布开始前，检查。
                int count = FilesHelper.ReadDirectory(Application.StartupPath + Task.SavePath).Count;
                if (count < 1 && !Task.IsRandUp) {
                    Task.TaskState = TaskState.等待终止;
                    AddPuts("", TaskName, "抱歉，发布文章不足！");
                    return "";
                }
                #endregion

                #region 启动分类，则设置设置site.CurrentPostID。

                //if (Site.CategoriesIsEnablad) {
                //    //如果是顶贴任务就直接去网站上自动获取postID
                //    if (Task.IsRandUp) {
                //        ArrayList al = _getCateIDs();
                //        Site.CurrentPostID = ArrayHelper.getRandOneFromArray(al);
                //    } else {
                //        //发布任务，则去任务本身寻找postID,如果任务中没有设定分类，那就就代表随机，直接去网站寻找。
                //        if (string.IsNullOrEmpty(Task.PostCateIDs)) {
                //            try {
                //                Task.PostCateIDs = ArrayHelper.getStrs(_getCateIDs());
                //            } catch {
                //                EchoHelper.Echo("获取分类信息失败，请检查任务配置！", "系统", EchoHelper.EchoType.错误信息);
                //            }
                //        }
                //      Site.CurrentPostID = ArrayHelper.getRandOneFromStrs(Task.PostCateIDs.Split(','));

                //    }
                //    //如果没有找到，则去站点中获取postID
                //    if (string.IsNullOrEmpty(Site.CurrentPostID)) {
                //        EchoHelper.Echo("发布分类参数获取失败：ThisPostID，请在任务中选择，本次发布结束。", Task.TaskName, EchoHelper.EchoType.错误信息);
                //        AddPuts("", TaskName, "抱歉，分类参数获取失败！");
                //        Task.TaskState = TaskState.等待终止;
                //        return "";
                //    }
                //}

                //Site.tmp01 = this.GetTempValue(Site.tmp01Regex);
                //Site.tmp02 = this.GetTempValue(Site.tmp02Regex);

                #endregion

                #region 进入发布提交动作 获取HTML。

                string tmp_PostReferer = _replace(Site.PostReferer);
                html = new xkHttp().httpGET(tmp_PostReferer, ref User.cookies);

                string tmp_PostURl = _replaceRegexText(html, Site.PostUrl);
                tmp_PostURl = _replace(tmp_PostURl);

                if (tmp_PostURl.Contains("www.renzhe.org")) {
                    EchoHelper.Echo("警告，请不要尝试对[官方网站renzhe.org]进行发布!", Task.TaskName, EchoHelper.EchoType.错误信息);
                    Task.TaskState = TaskState.等待终止;
                    return "";
                }

                tmp_PostData = tmp_PostData.Replace("→", "=").Replace("\r\n", "&");
                tmp_PostData = _replaceRegexText(html, tmp_PostData);
                tmp_PostData = _replace(tmp_PostData);

                tmp_PostData = _replacePutContent(tmp_PostData, Encoding.GetEncoding(charset));

                if (!Site.IsMutilPost) {
                    tmp_PostData = StringHelper.urlencode(tmp_PostData, charset);
                }

                html = new xkHttp().httpPost(tmp_PostURl, tmp_PostData, ref User.cookies, tmp_PostReferer, charset.ToLower() == "utf-8", Site.IsMutilPost, 20, Site.IsPostOnGzip, true);

                #endregion

                #region 是否存在失败标记
                if (VerifySucceed(html, Site.PostSucceedText)) {
                    string url = getSuccessUrl(html);//获取成功连接。待加入链轮库中。
                    User.LastUrl = url;
                    EchoHelper.Echo("恭喜您，发布成功！" + User.LastUrl, TaskName, EchoHelper.EchoType.任务信息);
                    VisitAndBuildHTML(html);//尝试访问并生成。
                    AddToLianlun(url);//加入到链轮库里。
                    LogUP.upToRenzheBBS(Title, url, this.Site.SiteName, this.TaskName, "http://" + new Uri(tmp_PostURl).Host);
                    AddPuts(url, TaskName, "发布成功！");
                } else if ((tmp_FailText = VerifyFail(html, Site.PostFailText)) != "NotFind") {
                    EchoHelper.Echo("抱歉，发布失败！失败原因：" + tmp_FailText, TaskName, EchoHelper.EchoType.错误信息);
                    AddPuts(Site.SiteBackUrl, TaskName, tmp_FailText);
                } else {
                    FilesHelper.WriteFile(Application.StartupPath + @"\Log\未知标识\【" + Site.SiteName + "】发布没有找到标志_" + DateTime.Now.Millisecond.ToString() + ".html", html, Encoding.GetEncoding(charset));
                    EchoHelper.Echo("抱歉，提交失败！失败原因：未知。确定您的参数提交正确？", Task.TaskName, EchoHelper.EchoType.错误信息);
                    AddPuts(Site.SiteBackUrl, TaskName, "抱歉，提交失败！失败原因：未知。");
                    Mail.sendMail("【" + Site.SiteName + "】站点出现问题，请核查！", "您的任务[" + Task.TaskName + "],未能发布成功。\n[" + Task.SavePath + "] \n\n具体内容：\n" + html);
                }

                #endregion

                return html;
            } catch (Exception e) {
                return EchoHelper.EchoException(e);
            }
        }

        #endregion



    }

}


