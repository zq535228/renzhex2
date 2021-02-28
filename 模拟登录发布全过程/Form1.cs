using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Service.Web;
using System.Net;
using 模拟登录发布全过程.org.renzhe.serv;
using System.Threading;
using X_Service.Util;

namespace 模拟登录发布全过程 {
    public partial class Form1 : Form {

        private DateTime dts;
        public Form1() {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            dts = DateTime.Now;
            new Thread(new ThreadStart(doti)).Start();
        }
        private void doti() {
            new ServiceShop().doit();
            textBox1.Text = "OKOK";

        }


        string purl = "";
        string reffer = "";
        string html = "";
        string postdata = "";

        private void button1_Click(object sender, EventArgs e) {
            //             string tmp_Login_Referer = _replace(Site.LoginReferer);
            //             string tmp_LoginCookies = _replace(Site.LoginCookies);
            //             xkCookies.UpCookie(ref cookies, tmp_Login_Referer, tmp_LoginCookies);
            CookieCollection cookies = new CookieCollection();
            //


            purl = "http://www.baidu.com/";
            reffer = "http://www.baidu.com/cache/user/html/login-1.2.html";

            //xkCookies.UpCookie(ref cookies, "http://www.baidu.com/", "BAIDUID=0915774773D18CA1A50FB5012E9F9E5A:FG=1");
            html = new xkHttp().httpGET(purl, ref cookies, reffer);

            purl = "https://passport.baidu.com/v2/api/?getapi&class=login&tpl=mn&tangram=true";
            reffer = "http://www.baidu.com/cache/user/html/login-1.2.html";
            html = new xkHttp().httpGET(purl, ref cookies, reffer);

            purl = "https://passport.baidu.com/v2/api/?logincheck&callback=bdPass.api.login._needCodestringCheckCallback&tpl=mn&charset=utf-8&index=0&username=fly5470&time=1347641320386";
            html = new xkHttp().httpGET(purl, ref cookies, reffer);


            purl = "https://passport.baidu.com/v2/api/?login";
            postdata = "ppui_logintime=6141&charset=utf-8&codestring=&token=5331620304e19a69b92d42db468dae6f&isPhone=false&index=0&u=&safeflg=0&staticpage=http%3A%2F%2Fwww.baidu.com%2Fcache%2Fuser%2Fhtml%2Fjump.html&loginType=1&tpl=mn&callback=parent.bdPass.api.login._postCallback&username=fly5470&password=19811108&verifycode=&mem_pass=on";
            html = new xkHttp().httpPost(purl, postdata, ref cookies);

        }

        private void button2_Click(object sender, EventArgs e) {

        }


        ServiceShop serv;
        public ServiceShop getServ() {
            serv = new ServiceShop();
            serv.Timeout = 20000;
            serv.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:5.0) Gecko/20100101 Firefox/5.0";
            serv.UnsafeAuthenticatedConnectionSharing = true;
            serv.AllowAutoRedirect = false;
            serv.Proxy = null;
            return serv;
        }

        Thread thr;
        private void button3_Click(object sender, EventArgs e) {
            thr = new Thread(new ThreadStart(th));
            thr.Start();
        }

        private void th() {
            for (int i = 1; i < 50; i++) {
                serv = new ServiceShop();
                string l = serv.GetAllPutModules().Length.ToString() + Environment.NewLine;
                Thread.Sleep(Convert.ToInt32(StringHelper.getRandNum(3)));
                textBox1.Text = i + ":" + l + textBox1.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            thr.Abort();
        }

        private void button5_Click(object sender, EventArgs e) {

        }




    }
}
