using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Service.Util;
using ComponentFactory.Krypton.Toolkit;
using X_Service.Web;
using System.Threading;
using System.Collections;
using System.Net;

namespace X_PostKing.Tools {
    public partial class X_Form_ZijideLu : X_Form_BaseTool {

        string reffer = "";
        string postdata = "";
        string purl = "";

        X_Waiting wait = new X_Waiting();

        public X_Form_ZijideLu() {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            wait.ShowMsg("加载窗体ing...");

#if DEBUG
            txtIP.Text = "67.198.177.138";
            txtUname.Text = "zijidelu";
            txtPwd.Text = "Zqowner3";
            txtPwd2.Text = "Zqowner521";
            txtFtpPWD.Text = "Zqowner3";
            txtDomainString.Text = "";
#endif
        }

        private void X_Form_ZijideLu_Load(object sender, EventArgs e) {
            wait.CloseMsg();
            if (member.IS_X_WordPressBuild != true) {
                EchoHelper.Show("您的站点数超过200个的时候再来使用此功能吧！", EchoHelper.MessageType.警告);
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if (txtPwd.Text == txtPwd2.Text) {
                EchoHelper.ShowBalloon("密码不可相同", "为了您服务器的安全，请保证密码是不同的！", txtPwd2);
                return;
            }
            groupBox_login.Enabled = false;
            new Thread(new ThreadStart(th_login)).Start();
        }
        CookieCollection zijidelu_cookies = new CookieCollection();
        private void th_login() {
            purl = "http://" + txtIP.Text + ":8888/index.php?m=Public&a=login";
            reffer = "http://" + txtIP.Text + ":8888/index.php?m=Public&a=login";
            postdata = "user=【用户名】&password=【密码】&verify=【验证码】&question=0&hash_answer=&submit_type=&__hash__=【hash】";

            EchoHelper.Echo("登录[" + txtIP.Text + ":8888]后台，请稍后...", "", EchoHelper.EchoType.普通信息);
            string html = new xkHttp().httpGET(reffer, ref zijidelu_cookies);
            string __hash__ = RegexHelper.getHtmlRegexText(html, "{name=\"__hash__\" value=\"(.*?)\" />}");
            postdata = postdata.Replace("【hash】", __hash__);
            Image img = new xkHttp().httpPic("http://" + txtIP.Text + ":8888/index.php?m=Public&a=verify", "", ref zijidelu_cookies);
            EchoHelper.Echo("请输入验证码：", "", EchoHelper.EchoType.普通信息);
            X_Form_VCode code = new X_Form_VCode(img);
            if (img == null) {
                groupBox_login.Enabled = true;
                EchoHelper.Show("验证码获取失败！", EchoHelper.MessageType.提示);
                return;
            }
            if (code.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string __vcode__ = code.key;
                string __pwd__ = StringHelper.CreateMd5(StringHelper.CreateMd5(StringHelper.CreateMd5(txtPwd.Text, 32).Substring(2, 28), 32), 32);

                postdata = postdata.Replace("【验证码】", __vcode__);
                postdata = postdata.Replace("【密码】", __pwd__);
                postdata = postdata.Replace("【用户名】", txtUname.Text);

                EchoHelper.Echo("登录[" + txtIP.Text + ":8888]，请稍后...", "", EchoHelper.EchoType.普通信息);
                html = new xkHttp().httpPost(purl, postdata, ref zijidelu_cookies, reffer, Encoding.UTF8);

                if (html.Contains("添加网站")) {
                    //EchoHelper.Show("登录成功！", EchoHelper.MessageType.提示);
                } else {
                    groupBox_login.Enabled = true;
                    EchoHelper.Show("登录失败！", EchoHelper.MessageType.提示);
                    return;
                }
            }
            EchoHelper.Echo("核对是否具有[" + txtIP.Text + "]操作权限，请稍后...", "", EchoHelper.EchoType.普通信息);

            purl = "http://" + txtIP.Text + ":8888/index.php?m=Safes&a=input_safe_password";
            reffer = "http://" + txtIP.Text + ":8888/index.php?m=Safes&a=input_safe_password";
            postdata = "safe_password=【密码2】&__hash__=【hash】";
            __hash__ = RegexHelper.getHtmlRegexText(html, "{name=\"__hash__\" value=\"(.*?)\" />}");
            postdata = postdata.Replace("【hash】", __hash__);
            string __pwd2__ = StringHelper.CreateMd5(StringHelper.CreateMd5(StringHelper.CreateMd5(txtPwd2.Text, 32).Substring(2, 28), 32), 32);
            postdata = postdata.Replace("【密码2】", __pwd2__);
            html = new xkHttp().httpPost(purl, postdata, ref zijidelu_cookies, reffer, Encoding.UTF8);
            if (html.Contains("密码验证成功")) {
                EchoHelper.Show("验证成功，请继续！", EchoHelper.MessageType.提示);
                EchoHelper.Echo("验证成功，请继续！", "", EchoHelper.EchoType.普通信息);
                groupBox2.Enabled = true;
            } else {
                groupBox_login.Enabled = true;
                EchoHelper.Show("操作密码验证失败！", EchoHelper.MessageType.提示);
            }

        }

        private void btnQuickAdd_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtDownPath.Text) && !txtDownPath.Text.Contains(".zip")) {
                EchoHelper.ShowBalloon("格式不符", "压缩包格式：.zip", txtDownPath);
                return;
            }
            btnQuickAdd.Enabled = false;
            txtDownPath.Enabled = false;
            txtFtpPWD.Enabled = false;
            new Thread(new ThreadStart(th_quick)).Start();

        }

        private void th_quick() {
            string[] sts = txtDomainString.Text.Split('\n');
            ArrayList waitSites = new ArrayList();
            for (int i = 0; i < sts.Length; i++) {
                if (sts[i].Split('|').Length > 1 && sts[i].Split('|')[0].ToString().Contains(".")) {
                    waitSites.Add(sts[i]);//未判断异常
                }
            }

            for (int i = 0; i < waitSites.Count; i++) {
                quickAddSite(waitSites[i].ToString().Split('|')[0].ToString());
            }

            //安装CMS程序
            for (int i = 0; i < waitSites.Count; i++) {
                CookieCollection cookies = new CookieCollection();
                string html = new xkHttp().httpGET("http://www." + waitSites[i].ToString().Split('|')[0].ToString(), ref cookies);
                if (html.Contains("emlog")) {
                    emlogInstall(waitSites[i].ToString().Split('|')[0].ToString(), waitSites[i].ToString().Split('|')[1].ToString());

                } else if (html.Contains("500")) {
                    wordpressInstall(waitSites[i].ToString().Split('|')[0].ToString(), waitSites[i].ToString().Split('|')[1].ToString());

                } else if (html.Contains("您的网站已经可以正常访问")) {
                    EchoHelper.Echo("您的网站已经可以正常访问, 但程序无法使用批量安装，请手工安装！", "程序安装", EchoHelper.EchoType.普通信息);

                }
            }

            btnQuickAdd.Enabled = true;
        }

        private void quickAddSite(string domain) {
            purl = "http://" + txtIP.Text + ":8888/index.php?m=Hosts&a=quick_add_vhost&ajax=json&";
            postdata = "domains=" + domain + "&add_www=on&name=" + getDbName(domain) + "&password=" + txtFtpPWD.Text + "&sid=1&install_soft=&software_siteurl=http%3A%2F%2F&config_file=&htaccess=0&uid=1520&__hash__=【hash】";
            reffer = "http://" + txtIP.Text + ":8888/index.php?m=Hosts&a=quick_add_vhost";
            string html = new xkHttp().httpGET(reffer, ref zijidelu_cookies);
            string __hash__ = RegexHelper.getHtmlRegexText(html, "{name=\"__hash__\" value=\"(.*?)\" />}");
            postdata = postdata.Replace("【hash】", __hash__);

            html = new xkHttp().httpPost(purl, postdata, ref zijidelu_cookies, reffer, Encoding.UTF8);

            if (html.Contains(@"\u6dfb\u52a0\u6210\u529f")) {
                EchoHelper.Echo("快速建站【" + domain + "】成功！", "添加站点", EchoHelper.EchoType.普通信息);
            } else {
                EchoHelper.Echo("快速建站【" + domain + "】失败，请尝试手工建站点！", "添加站点", EchoHelper.EchoType.错误信息);
                //return;
            }

            if (html.Contains(@"\u8d8a\u6743\u64cd\u4f5c\")) {
                EchoHelper.Show("请重新登录", EchoHelper.MessageType.错误);
                groupBox_login.Enabled = true;
                groupBox2.Enabled = false;
                return;
            }

            purl = "http://" + txtIP.Text + ":8888/index.php?m=Hosts&a=index";
            html = new xkHttp().httpGET(purl, ref zijidelu_cookies);
            string path = RegexHelper.getHtmlRegexText(html, "{<a href=\"/index.php\\?m=Files&a=index&dir=(.*?)\"><img}");
            if (!path.Contains(domain)) {
                return;
            }
            //删除默认文件
            EchoHelper.Echo("删除lum中的默认文件！", "删除默认文件", EchoHelper.EchoType.普通信息);
            purl = "http://" + txtIP.Text + ":8888/index.php?m=Files&a=file_mut_actions&ajax=json";
            postdata = "select_file%5B2%5D=favicon.ico&select_file%5B3%5D=index.php&select_file%5B4%5D=phpinfo.php&path=" + path + "%2F&action_name=delete&";
            html = new xkHttp().httpPost(purl, postdata, ref zijidelu_cookies, reffer, true, false, 20, true, true);

            //远程下载
            EchoHelper.Echo("远程下载文件开始，此过程较慢，请耐心等待！", "远程下载", EchoHelper.EchoType.普通信息);
            purl = "http://" + txtIP.Text + ":8888/index.php?m=Files&a=download&ajax=json&";
            postdata = "path=" + path + "%2F&file_url=" + txtDownPath.Text;
            html = new xkHttp().httpPost(purl, postdata, ref zijidelu_cookies, reffer, true, false, 200, true, true);
            if (html.Contains(":1,")) {
                EchoHelper.Echo("下载【" + txtDownPath.Text + "】成功！", "远程下载", EchoHelper.EchoType.普通信息);
            } else {
                EchoHelper.Echo("下载【" + txtDownPath.Text + "】失败！", "远程下载", EchoHelper.EchoType.错误信息);
            }

            //解压卡死
            purl = "http://" + txtIP.Text + ":8888/index.php?m=Files&a=cx_file&ajax=json&";
            string zip_name = txtDownPath.Text.Replace(RegexHelper.getMatch(txtDownPath.Text, ".*\\/"), "");
            postdata = "&uid=1520&method=x&source=" + path + "%2F" + zip_name + "&source_name=" + zip_name + "&target=&target2=cur_path&password=";
            html = new xkHttp().httpPost(purl, postdata, ref zijidelu_cookies, reffer, true, false, 100, true, true);
            if (html.Contains(":1,")) {
                EchoHelper.Echo("解压【" + zip_name + "】成功！", "在线解压", EchoHelper.EchoType.普通信息);
            } else {
                EchoHelper.Echo("解压【" + zip_name + "】失败！", "在线解压", EchoHelper.EchoType.错误信息);
            }
        }

        private string getDbName(string p) {
            p = StringHelper.SubStringNoDDD(p.Replace(".", "_").Replace("-", "_"), 0, 15);
            return p;
        }


        //emlog安装过程
        private void emlogInstall(string domain, string desc) {
            CookieCollection cookies = new CookieCollection();
            purl = "http://www." + domain + "/install.php?action=install";
            reffer = "http://www." + domain + "/install.php";
            postdata = "hostname=localhost&dbuser=【数据库】&password=【密码】&dbname=【数据库】&dbprefix=emlog_&admin=admin&adminpw=【密码】&adminpw2=【密码】";

            postdata = postdata.Replace("【数据库】", getDbName(domain));
            postdata = postdata.Replace("【密码】", txtFtpPWD.Text);

            string html = new xkHttp().httpPost(purl, postdata, ref cookies, reffer, Encoding.UTF8);

            //登录后台
            purl = "http://www." + domain + "/admin/index.php?action=login";
            reffer = "http://www." + domain + "/admin/";
            postdata = "user=admin&pw=【密码】".Replace("【密码】", txtFtpPWD.Text);
            html = new xkHttp().httpPost(purl, postdata, ref cookies, reffer, Encoding.UTF8);

            //保存侧边
            purl = "http://www." + domain + "/admin/widgets.php?action=compages";
            reffer = "http://www." + domain + "/admin/widgets.php";
            postdata = "widgets%5B%5D=archive&widgets%5B%5D=newcomm&widgets%5B%5D=link&widgets%5B%5D=search&widgets%5B%5D=sort&wgnum=1";
            html = new xkHttp().httpPost(purl, postdata, ref cookies, reffer, Encoding.UTF8);

            //删除默认的日志
            purl = "http://www." + domain + "/admin/admin_log.php?action=operate_log";
            reffer = "http://www." + domain + "/admin/admin_log.php";
            postdata = "pid=&blog%5B%5D=1&operate=del&sort=";
            html = new xkHttp().httpPost(purl, postdata, ref cookies, reffer, Encoding.UTF8);

            //删除链接
            purl = "http://www." + domain + "/admin/link.php?action=dellink&linkid=1";
            html = new xkHttp().httpGET(purl, ref cookies);

            //系统设置
            purl = "http://www." + domain + "/admin/configure.php?action=mod_config";
            reffer = "http://www." + domain + "/admin/configure.php";

            postdata = "blogname=" + getSiteName(desc) + "&bloginfo=" + getSiteDesc(desc) + "&blogurl=http%3A%2F%2Fwww." + domain + "%2F&site_key=" + getSiteKeys(desc) + "&index_lognum=10&timezone=8&istrackback=y&isthumbnail=y&istwitter=y&index_twnum=10&twnavi=%E7%A2%8E%E8%AF%AD&rss_output_num=10&rss_output_fulltext=y&ischkcomment=y&comment_code=y&isgravatar=y&comment_pnum=20&comment_order=newer&icp=&footer_info=";
            html = new xkHttp().httpPost(purl, postdata, ref cookies, reffer, Encoding.UTF8);

            //添加分类
            ArrayList al = getCategoryKeys(desc);
            for (int i = 0; i < al.Count; i++) {
                purl = "http://www." + domain + "/admin/sort.php?action=add";
                reffer = "http://www." + domain + "/admin/sort.php";
                postdata = "taxis=" + StringHelper.getRandNum(4) + "&sortname=" + al[i] + "&alias=" + StringHelper.getRandStr();
                html = new xkHttp().httpPost(purl, postdata, ref cookies, reffer, Encoding.UTF8);
            }
            ////判断是否成功
            purl = "http://www." + domain;
            html = new xkHttp().httpGET(purl, ref cookies);
            if (html.Contains(getSiteName(desc))) {
                EchoHelper.Show("配置【" + domain + "】完成", EchoHelper.MessageType.提示);
                EchoHelper.Echo("安装【" + domain + "】完成！", "在线安装", EchoHelper.EchoType.普通信息);
            } else {
                EchoHelper.Echo("安装【" + domain + "】失败！", "在线安装", EchoHelper.EchoType.错误信息);
            }
        }

        //wordpress安装过程
        private void wordpressInstall(string domain, string desc) {
            CookieCollection cookies = new CookieCollection();
            EchoHelper.Echo("WordPress › 准备配置文件", domain, EchoHelper.EchoType.普通信息);
            purl = "http://www." + domain + "/wp-admin/setup-config.php?step=2";
            reffer = "http://www." + domain + "/wp-admin/setup-config.php?step=1";
            postdata = "dbname=【数据库】&uname=【数据库】&pwd=【密码】&dbhost=localhost&prefix=wp_&submit=%E6%8F%90%E4%BA%A4";
            postdata = postdata.Replace("【数据库】", getDbName(domain));
            postdata = postdata.Replace("【密码】", txtFtpPWD.Text);
            string html = new xkHttp().httpPost(purl, postdata, ref cookies, reffer, Encoding.UTF8);

            EchoHelper.Echo("WordPress←安装", domain, EchoHelper.EchoType.普通信息);
            purl = "http://www." + domain + "/wp-admin/install.php?step=2";
            reffer = "http://www." + domain + "/wp-admin/install.php";
            postdata = "weblog_title=biaoti&user_name=admin&admin_password=【密码】&admin_password2=【密码】&admin_email=admin@" + domain + "&blog_public=1&Submit=%E5%AE%89%E8%A3%85+WordPress";
            postdata = postdata.Replace("【密码】", txtFtpPWD.Text);
            html = new xkHttp().httpPost(purl, postdata, ref cookies, reffer, Encoding.UTF8);

            EchoHelper.Echo("仪表盘←WordPress", domain, EchoHelper.EchoType.普通信息);
            purl = "http://www." + domain + "/wp-login.php";
            reffer = "http://www." + domain + "/wp-login.php";
            postdata = "log=admin&pwd=【密码】&wp-submit=%E7%99%BB%E5%BD%95&redirect_to=http%3A%2F%2Fwww." + domain + "%2Fwp-admin%2F&testcookie=1";
            postdata = postdata.Replace("【密码】", txtFtpPWD.Text);
            html = new xkHttp().httpPost(purl, postdata, ref cookies, reffer, Encoding.UTF8);


            EchoHelper.Echo("链接←WordPress", domain, EchoHelper.EchoType.普通信息);
            purl = "http://www." + domain + "/wp-admin/link-manager.php";
            reffer = "http://www." + domain + "/wp-admin/";
            html = new xkHttp().httpGET(purl, ref cookies);
            string suiji1 = RegexHelper.getHtmlRegexText(html, "{name=\"_wpnonce\" value=\"(.*?)\" />}");

            purl = "http://www." + domain + "/wp-admin/link-manager.php?s=&_wpnonce=【随机1】&_wp_http_referer=%2Fwp-admin%2Flink-manager.php&action=delete&cat_id=0&linkcheck%5B%5D=1&linkcheck%5B%5D=5&linkcheck%5B%5D=3&linkcheck%5B%5D=4&linkcheck%5B%5D=6&linkcheck%5B%5D=2&linkcheck%5B%5D=7&action2=delete&=%E5%BA%94%E7%94%A8";
            purl = purl.Replace("【随机1】", suiji1);
            reffer = "http://www." + domain + "/wp-admin/link-manager.php";
            html = new xkHttp().httpGET(purl, ref cookies, reffer);

            //页面
            purl = "http://www." + domain + "/wp-admin/edit.php?post_type=page";
            reffer = "http://www." + domain + "/wp-admin/link-manager.php?deleted=7";
            html = new xkHttp().httpGET(purl, ref cookies, reffer);
            string suiji2 = RegexHelper.getHtmlRegexText(html, "{action=trash&amp;_wpnonce=(.*?)'}");

            purl = "http://www." + domain + "/wp-admin/post.php?post=2&action=trash&_wpnonce=【随机2】";
            purl = purl.Replace("【随机2】", suiji2);
            reffer = "http://www." + domain + "/wp-admin/edit.php?post_type=page";
            html = new xkHttp().httpGET(purl, ref cookies, reffer);

            //文章
            purl = "http://www." + domain + "/wp-admin/edit.php";
            reffer = "http://www." + domain + "/wp-admin/edit.php?post_type=page&trashed=1&ids=2";
            html = new xkHttp().httpGET(purl, ref cookies, reffer);
            string suiji3 = RegexHelper.getHtmlRegexText(html, "{action=trash&amp;_wpnonce=(.*?)'}");

            purl = "http://www." + domain + "/wp-admin/post.php?post=1&action=trash&_wpnonce=【随机3】";
            purl = purl.Replace("【随机3】", suiji3);
            reffer = "http://www." + domain + "/wp-admin/edit.php";
            html = new xkHttp().httpGET(purl, ref cookies, reffer);

            //设置
            purl = "http://www." + domain + "/wp-admin/options-general.php";
            reffer = "http://www." + domain + "/wp-admin/edit.php?trashed=1&ids=1";
            html = new xkHttp().httpGET(purl, ref cookies, reffer);
            string suiji4 = RegexHelper.getHtmlRegexText(html, "{name=\"_wpnonce\" value=\"(.*?)\" />}");

            purl = "http://www." + domain + "/wp-admin/options.php";
            reffer = "http://www." + domain + "/wp-admin/options-general.php";
            postdata = "option_page=general&action=update&_wpnonce=【随机4】&_wp_http_referer=%2Fwp-admin%2Foptions-general.php&blogname=" + getSiteName(desc) + "&blogdescription=" + getSiteDesc(desc) + "&siteurl=http%3A%2F%2Fwww." + domain + "&home=http%3A%2F%2Fwww." + domain + "&admin_email=admin@" + domain + "&default_role=subscriber&timezone_string=UTC%2B8&date_format=Y+%E5%B9%B4+n+%E6%9C%88+j+%E6%97%A5&date_format_custom=Y+%E5%B9%B4+n+%E6%9C%88+j+%E6%97%A5&time_format=a+g%3Ai&time_format_custom=a+g%3Ai&start_of_week=1&submit=%E4%BF%9D%E5%AD%98%E6%9B%B4%E6%94%B9";
            postdata = postdata.Replace("【随机4】", suiji4);
            html = new xkHttp().httpPost(purl, postdata, ref cookies, reffer, Encoding.UTF8);

            //分类循环添加

            purl = "http://www." + domain + "/wp-admin/edit-tags.php?taxonomy=category";
            reffer = "http://www." + domain + "/wp-admin/options-general.php?settings-updated=true";
            html = new xkHttp().httpGET(purl, ref cookies, reffer);
            string suiji_tag = RegexHelper.getHtmlRegexText(html, "{name=\"_wpnonce_add-tag\" value=\"(.*?)\" />}");

            ArrayList al = getCategoryKeys(desc);
            for (int i = 0; i < al.Count; i++) {
                purl = "http://www." + domain + "/wp-admin/admin-ajax.php";
                reffer = "http://www." + domain + "/wp-admin/edit-tags.php?taxonomy=category";
                postdata = "action=add-tag&screen=edit-category&taxonomy=category&post_type=post&_wpnonce_add-tag=【随机tag】&_wp_http_referer=%2Fwp-admin%2Fedit-tags.php%3Ftaxonomy%3Dcategory&tag-name=" + al[i] + "&slug=" + StringHelper.getRandStr() + "&parent=-1&description=";
                postdata = postdata.Replace("【随机tag】", suiji_tag);
                html = new xkHttp().httpPost(purl, postdata, ref cookies, reffer, Encoding.UTF8);
            }

        }

        #region 返回站点关键词组合的各种信息

        private string getSiteName(string desc) {
            string re = "";
            ArrayList al = getAllKeys(desc);
            for (int i = 0; i < 3; i++) {
                re += al[i].ToString() + "_";
            }
            return re.TrimEnd('_');
        }

        private string getSiteKeys(string desc) {
            string re = "";
            ArrayList al = getAllKeys(desc);
            for (int i = 0; i < 3; i++) {
                re += al[i].ToString() + ",";
            }
            return re.TrimEnd(',');
        }

        private string getSiteDesc(string desc) {
            string re = "";
            ArrayList al = getAllKeys(desc);
            for (int i = 0; i < al.Count; i++) {
                re += al[i].ToString() + "_";
            }
            re = StringHelper.SubString(re.TrimEnd('_'), 0, 200);
            return re;
        }

        private ArrayList getCategoryKeys(string desc) {
            ArrayList al = getAllKeys(desc);
            for (int i = 0; i < 3; i++) {
                al.Remove(al[0]);
            }
            return al;
        }

        private ArrayList getAllKeys(string desc) {
            ArrayList al = new ArrayList();
            string[] sts = desc.Split(',');

            for (int i = 0; i < sts.Length; i++) {
                al.Add(sts[i]);
            }
            return al;

        }
        #endregion

    }
}
