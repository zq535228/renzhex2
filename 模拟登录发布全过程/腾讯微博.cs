using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Service.Web;
using System.Net;

namespace 模拟登录发布全过程 {
    public partial class 腾讯微博 : Form {
        public 腾讯微博() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string s1 = "http://ptlogin2.qq.com/login?ptlang=2052&u=20223358&p=DA3330D4E5B9456A77C4A4448BE761F9&verifycode=!SSK&low_login_enable=1&low_login_hour=720&css=http://imgcache.qq.com/ptcss/b4/wb/46000101/login1.css&aid=46000101&mibao_css=m_weibo&u1=http%3A%2F%2Ft.qq.com&ptredirect=1&h=1&from_ui=1&dumy=&fp=loginerroralert&action=5-11-20161&g=1&t=1&dummy=";
            CookieCollection cookies = new CookieCollection();

            string html = new xkHttp().httpGET(s1, ref cookies);

            MessageBox.Show(html);
        }
    }
}
