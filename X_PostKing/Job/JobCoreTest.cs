using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using X_Model;
using X_Service.Files;
using X_Service.Util;
using X_Service.Web;
using System.Drawing;
using System.IO;
using System.Web;
using System.Net;


namespace X_PostKing.Job {
    /// <summary>
    /// 测试项目类
    /// </summary>
    public class JobCoreTest : JobCoreBase {

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public JobCoreTest() {
            ContentText = "恭喜您，您看到这篇文章意味着您的忍者X2引擎发布参数已经成功设置好了!(这是正文)\r\n\r\n赶紧体验一下忍者X2的强大功能吧!\r\n\r\nBY:RenZhe.org";
            Title = "忍者X2系统测试文章";
        }
        public JobCoreTest(Ibms.Utility.Task.ISchedule s) {
        }
        public JobCoreTest(ModelSite site, ModelUsers user) {
            ContentText = "恭喜您，您看到这篇文章意味着您的忍者X2引擎发布参数已经成功设置好了!(这是正文)\r\n\r\n赶紧体验一下忍者X2的强大功能吧!\r\n\r\nBY:RenZhe.org";
            Title = "忍者X2系统测试文章";
            base.Site = site;
            base.User = user;
        }
        #endregion

        #region 登陆
        #region 重写后的登陆方法
        /// <summary>
        /// 重写登陆方法
        /// </summary>
        /// <returns>返回Html代码</returns>
        public override string Login() {
            if (Site == null | User == null) {
                return "不允许空类型-----忍者X2";
            }
            if (Site.LoginType == LoginType.马甲登陆模式) {
                return CookieLogin();
            } else if (Site.LoginType == LoginType.自动登陆模式) {
                return AutoLogin();
            } else {
                return "登陆模式未确定-----忍者X2";
            }
        }
        #endregion

        #region 用户名登陆模式
        /// <summary>
        /// 用户名登陆模式
        /// </summary>
        /// <returns>返回HTML</returns>
        private string AutoLogin() {
            if (string.IsNullOrEmpty(Site.LoginParameters)) {
                EchoHelper.Show("这个模块无Socket内核，试试web内核吧！", EchoHelper.MessageType.提示);
                return "";
            }
            try {
                CookieCollection cookies = new CookieCollection();
                #region 私有临时变量
                string charset = Site.LoginIsUtf8 ? "UTF-8" : "GB2312";
                string tmp_FailText = string.Empty;
                string tmp_Login_Referer = _replace(Site.LoginReferer);
                string tmp_LoginCookies = _replace(Site.LoginCookies);
                xkCookies.UpCookie(ref cookies, tmp_Login_Referer, tmp_LoginCookies);

                string html = new xkHttp().httpGET(tmp_Login_Referer, ref cookies);
                string tmp_LoginParameters = _replaceRegexText(html, Site.LoginParameters);
                string tmp_LoginLoginUrl = _replace(Site.LoginLoginUrl);
                #endregion

                #region 是否使用验证码,如果使用的话,就弹出验证码输入框,并过滤到[验证码]标签,有时间重构一下你的获取验证码的类
                if (Site.LoginNeedVerify) {//要判断是否启用验证码那个不行,,在界面里,,bunengyongzhegefangfa不能用这个方法 ??
                    byte[] checkcodebyte = new byte[1];
                    string tmp_Login_VerifyUrl;
                    if (Site.LoginVerifyUrl.Split('|').Length > 1) {
                        html = new xkHttp().httpGET(_replaceRegexText(html, _replace(Site.LoginVerifyUrl.Split('|')[1])), ref cookies);
                        tmp_Login_VerifyUrl = _replaceRegexText(html, _replace(Site.LoginVerifyUrl.Split('|')[0]));
                    } else {
                        tmp_Login_VerifyUrl = _replaceRegexText(html, _replace(Site.LoginVerifyUrl));
                    }

                    checkcodebyte = new xkHttp().httpBytes(tmp_Login_VerifyUrl, checkcodebyte, ref cookies);
                    X_Form_VCode vcode = new X_Form_VCode(new Bitmap(new MemoryStream(checkcodebyte)));
                    if (vcode.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        Site.Verify = vcode.key;
                    }
                }
                #endregion

                #region 消息提示
                EchoHelper.Echo("正在申请sessionid...", "登陆测试", EchoHelper.EchoType.任务信息);
                EchoHelper.Echo(string.Format("正在提交登陆信息<{0}>", "POST"), "登陆测试", EchoHelper.EchoType.任务信息);
                #endregion

                #region 做登录的提交动作，并返回HTML
                tmp_LoginParameters = tmp_LoginParameters.Replace("→", "=").Replace("\r\n", "&");
                tmp_LoginParameters = _replace(tmp_LoginParameters);
                html = new xkHttp().httpPost(tmp_LoginLoginUrl, tmp_LoginParameters, ref cookies, tmp_Login_Referer, Encoding.GetEncoding(charset));
                #endregion

                if (VerifySucceed(html, Site.LoginSucceedText)) {
                    #region 验证是否成功
                    User.cookies = cookies;
                    User.LoginTime = DateTime.Now;
                    User.LoginState = LoginState.已登录;
                    EchoHelper.Echo("恭喜您，登陆成功！", "登陆测试", EchoHelper.EchoType.任务信息);
                    EchoHelper.Show("恭喜您，登陆成功！", EchoHelper.MessageType.提示);
                    #endregion
                } else if ((tmp_FailText = VerifyFail(html, Site.LoginFailText)) != "NotFind") {
                    #region 验证是否失败
                    EchoHelper.Echo("抱歉，登陆失败！失败原因：" + tmp_FailText, "登陆测试", EchoHelper.EchoType.错误信息);
                    EchoHelper.Show("抱歉，登陆失败！失败原因：" + tmp_FailText, EchoHelper.MessageType.提示);
                    User.LoginState = LoginState.登陆失败;
                    #endregion
                } else {
                    #region 没有找到标志
                    string logpath = Application.StartupPath + @"\Log\未知标识\【" + Site.SiteName + "】登陆失败_" + DateTime.Now.Millisecond + ".html";
                    EchoHelper.Echo("抱歉，提交失败！失败原因：未知。确定您的参数提交正确？\r\n具体详情：" + logpath, "登陆测试", EchoHelper.EchoType.错误信息);
                    EchoHelper.Show("抱歉，提交失败！失败原因：未知。确定您的参数提交正确？\r\n具体详情：" + logpath, EchoHelper.MessageType.提示);
                    User.LoginState = LoginState.登陆失败;
                    FilesHelper.WriteFile(logpath, html, Encoding.GetEncoding(charset));
                    #endregion
                }
                return html;
            } catch (Exception e) {
                EchoHelper.Show(e.Message, EchoHelper.MessageType.警告);
                return e.Message;
            }
        }


        protected string _replaceTestContent(string data, Encoding encode) {
            if (Site.IsEN) {
                Title = StringHelper.translate(Title);
                ContentText = StringHelper.translate(ContentText);
                data = data.Replace("[标题]", Title);
                data = data.Replace("[正文]", ContentText);
            } else {
                data = data.Replace("[标题]", Title);
                data = data.Replace("[正文]", ContentText);
            }
            return data;
        }

        #endregion

        #region 马甲登陆模式
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
                EchoHelper.Echo("正在访问登陆识别页面" + tmp_LoginMVerifyUrl, "登陆测试", EchoHelper.EchoType.任务信息);
                #endregion

                #region 获取HTML
                CookieCollection cookies = new CookieCollection();
                xkCookies.UpCookie(ref cookies, tmp_LoginMVerifyUrl, User.Cookie);
                string html = new xkHttp().httpPost(tmp_LoginMVerifyUrl, "", ref cookies, tmp_LoginReferer, Encoding.GetEncoding(charset));
                #endregion

                if (VerifySucceed(html, Site.LoginSucceedText)) {
                    #region 是否包含成功字段
                    User.LoginTime = DateTime.Now;
                    EchoHelper.Echo("恭喜您，登陆成功！", "登陆测试", EchoHelper.EchoType.任务信息);
                    EchoHelper.Show("恭喜您，登陆成功！", EchoHelper.MessageType.提示);
                    User.LoginState = LoginState.已登录;
                    User.cookies = cookies;
                    #endregion
                } else if ((tmp_FailText = VerifyFail(html, Site.LoginFailText)) != "NotFind") {
                    #region 是否包含失败字段
                    EchoHelper.Echo("抱歉，登陆失败！失败原因：" + tmp_FailText, "登陆测试", EchoHelper.EchoType.错误信息);
                    EchoHelper.Show("抱歉，登陆失败！失败原因：" + tmp_FailText, EchoHelper.MessageType.提示);
                    User.LoginState = LoginState.登陆失败;
                    #endregion
                } else {
                    #region 未找到标志
                    string logpath = Application.StartupPath + @"\Log\未知标识\【" + Site.SiteName + "】测试登录未找到标志_" + DateTime.Now.Millisecond.ToString() + ".html";
                    FilesHelper.WriteFile(logpath, html, Encoding.GetEncoding(charset));
                    EchoHelper.Echo("抱歉，提交失败！失败原因：未知。确定您的参数提交正确？\r\n具体详情：" + logpath, "登陆测试", EchoHelper.EchoType.错误信息);
                    EchoHelper.Show("抱歉，提交失败！失败原因：未知。确定您的参数提交正确？\r\n具体详情：" + logpath, EchoHelper.MessageType.提示);
                    User.LoginState = LoginState.登陆失败;
                    #endregion
                }
                return html;

            } catch (Exception e) {
                EchoHelper.Show(e.Message, EchoHelper.MessageType.警告);
                return e.Message;
            }
        }
        #endregion
        #endregion

        #region 发布
        #region 重写后的发布方法
        /// <summary>
        /// 重写后的发布方法
        /// </summary>
        /// <returns></returns>
        public override string Post() {

            if (Site == null | User == null) {
                return "不允许空类型-----忍者X";
            } else if (User.LoginState != LoginState.已登录) {
                return "当前用户没有登陆成功，无法发布，请先让该用户登陆。-----忍者";
            } else {
                return Test_Post();
            }
        }
        #endregion

        #region 测试发布类
        /// <summary>
        /// 测试发布类
        /// </summary>
        /// <returns></returns>
        private string Test_Post() {
            if (string.IsNullOrEmpty(Site.PostParameters)) {
                EchoHelper.Show("这个模块无Socket内核，试试web内核吧！", EchoHelper.MessageType.提示);
                return "";
            }
            try {
                #region 发布的私有变量
                string html;

                #region 获取临时值01-02
                Site.tmp01 = this.GetTempValue(Site.tmp01Regex);
                Site.tmp02 = this.GetTempValue(Site.tmp02Regex);
                #endregion

                string charset = Site.PostIsUtf8 ? "UTF-8" : "GB2312";
                string tmp_PostReferer = _replace(Site.PostReferer);
                string tmp_PostData = Site.PostParameters;

                string tmp_FailText = string.Empty;
                #endregion

                #region 获取HTML
                html = new xkHttp().httpGET(tmp_PostReferer, ref User.cookies);

                string tmp_PostURl = _replaceRegexText(html, Site.PostUrl);
                tmp_PostURl = _replace(tmp_PostURl);

                tmp_PostData = tmp_PostData.Replace("→", "=").Replace("\r\n", "&");
                tmp_PostData = _replaceRegexText(html, tmp_PostData);
                tmp_PostData = _replace(tmp_PostData);
                tmp_PostData = _replaceTestContent(tmp_PostData, Encoding.GetEncoding(charset));

                if (!Site.IsMutilPost) {
                    tmp_PostData = StringHelper.urlencode(tmp_PostData, charset);
                }

                html = new xkHttp().httpPost(tmp_PostURl, tmp_PostData, ref User.cookies, tmp_PostReferer, charset.ToLower() == "utf-8", Site.IsMutilPost, 15, Site.IsPostOnGzip, true);
                html += tmp_PostData;
                #endregion

                if (VerifySucceed(html, Site.PostSucceedText)) {
                    #region 是否存在成功标记
                    EchoHelper.Echo("恭喜您，发布成功！", "发布测试", EchoHelper.EchoType.任务信息);
                    EchoHelper.Show("恭喜您，发布成功！", EchoHelper.MessageType.提示);
                    VisitAndBuildHTML(html);
                    string url = getSuccessUrl(html);//获取成功连接。待加入链轮库中。
                    #endregion
                } else if ((tmp_FailText = VerifyFail(html, Site.PostFailText)) != "NotFind") {
                    #region 是否存在失败标记
                    EchoHelper.Echo("抱歉，发布失败！失败原因：" + tmp_FailText, "发布测试", EchoHelper.EchoType.错误信息);
                    EchoHelper.Show("抱歉，发布失败！失败原因：" + tmp_FailText, EchoHelper.MessageType.提示);
                    #endregion
                } else {
                    #region 未找到标志
                    string logpath = Application.StartupPath + @"\Log\未知标识\【" + Site.SiteName + "】测试发布未找到标志_" + DateTime.Now.Millisecond.ToString() + ".html";
                    FilesHelper.WriteFile(logpath, html, Encoding.GetEncoding(charset));
                    EchoHelper.Echo("抱歉，提交失败！失败原因：未知。确定您的参数提交正确？\r\n具体详情：" + logpath, "发布测试", EchoHelper.EchoType.错误信息);
                    EchoHelper.Show("抱歉，提交失败！失败原因：未知。确定您的参数提交正确？\r\n具体详情：" + logpath, EchoHelper.MessageType.提示);
                    #endregion
                }
                return html;
            } catch (Exception e) {
                EchoHelper.Show(e.Message, EchoHelper.MessageType.警告);
                return e.Message;
            }
        }
        #endregion
        #endregion

    }
}
