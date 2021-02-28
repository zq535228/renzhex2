using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Service.Web;
using X_Service.Util;
using System.Collections;
using System.Threading;
using ComponentFactory.Krypton.Toolkit;
using System.Net;

namespace X_PostKing.Tools {
    public partial class X_Form_DnsPod : X_Form_BaseTool {

        CookieCollection cookies = new CookieCollection();

        public X_Form_DnsPod() {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnTaobao_Click(object sender, EventArgs e) {
            ProcessHelper.openUrl("http://s8.taobao.com/search?q=com+%D3%F2%C3%FB&cat=0&pid=mm_25078734_0_0&mode=23&commend=1%2C2");
        }

        private void btnGD_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("到Godaddy.com的官方网站设置域名使用DnsPod的DNS进行解析？", "设置DNS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                ProcessHelper.openUrl("http://www.godaddy.com/");
            }
        }

        private void btnLoginDnsPod_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtPWD.Text) || string.IsNullOrEmpty(txtUserEmail.Text) || !txtUserEmail.Text.Contains("@")) {
                EchoHelper.Show("DNSPOD的邮箱，密码不能为空，或格式不正确！", EchoHelper.MessageType.错误);
                return;
            }
            new Thread(new ThreadStart(th_login)).Start();
        }

        private void th_login() {

            btnLoginDNSPOD.Enabled = false;
            string postdata = "email=" + txtUserEmail.Text + "&password=" + txtPWD.Text + "&remember=1";
            string posturl = "https://www.dnspod.cn/Auth/Login";
            string reffer = "https://www.dnspod.cn/";
            btnLoginDNSPOD.Text = "登录中...";
            string html = new xkHttp().httpPost(posturl, postdata, ref cookies, reffer, Encoding.UTF8);

            if (html.Contains("success")) {
                btnLoginDNSPOD.Text = "已登录";
                btnLogout.Enabled = true;
                groupBox3.Enabled = true;
                EchoHelper.Show("登录成功！", EchoHelper.MessageType.提示);
            } else {
                btnLoginDNSPOD.Enabled = true;
                btnLoginDNSPOD.Text = "登录";
                EchoHelper.Show("登录失败！", EchoHelper.MessageType.错误);
            }
        }

        private void btnListNewDomain_Click(object sender, EventArgs e) {
            new Thread(new ThreadStart(th_ListNewDoamin)).Start();
        }
        private void th_ListNewDoamin() {
            btnListNewDomain.Enabled = false;
            txtADomains.Text = "";
            string postdata = "format=json&lang=cn&error_on_empty=no&use_session=yes&type=recent&offset=0&length=50";
            string posturl = "https://www.dnspod.cn/Api/Domain.List";
            string reffer = "https://www.dnspod.cn/Domain#/recent";

            string html = new xkHttp().httpPost(posturl, postdata, ref cookies, reffer, Encoding.UTF8);
            if (html.Contains("code\":\"1")) {
                groupBox5.Enabled = true;
                ArrayList al = RegexHelper.getMatchs(html, "\"id\":.*?,\"name\":\".*?\",\"grade\"");
                for (int i = 0; i < al.Count; i++) {
                    string str1 = al[i].ToString();
                    string tmp01 = RegexHelper.getMatch(str1, "\"id\":(.*?),\"name\":\"(.*?)\",\"grade\"", 1);
                    string tmp02 = RegexHelper.getMatch(str1, "\"id\":(.*?),\"name\":\"(.*?)\",\"grade\"", 2);
                    txtADomains.Text += "【" + tmp02 + "：" + tmp01 + "】" + Environment.NewLine;
                }
                txtADomains.Text = txtADomains.Text.Trim();
            } else {
                EchoHelper.Show("列表失败！", EchoHelper.MessageType.错误);
            }
            btnListNewDomain.Enabled = true;
        }

        private void X_Form_DnsPod_Load(object sender, EventArgs e) {

#if DEBUG
            txtUserEmail.Text = "20223358@qq.com";
            txtPWD.Text = "Zqowner521";
#endif

        }

        private void btnSetA_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("您确定要添加上述域名的A记录@、www为【" + txtSetIP.Text + "】吗？", "设置A记录", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                new Thread(new ThreadStart(th_SetA)).Start();
            }

        }

        private void th_SetA() {
            btnSetA.Enabled = false;
            string[] sts = txtADomains.Text.Split('\n');
            int succNum = 0;
            for (int i = 0; i < sts.Length; i++) {
                string domain = RegexHelper.getMatch(sts[i].ToString(), "【(.*?)：(.*?)】", 1);
                string strid = RegexHelper.getMatch(sts[i].ToString(), "【(.*?)：(.*?)】", 2);

                string postdata = "selected=false&domain_id=" + strid + "&domain_grade=D_Free&domain=" + domain + "&visible=true&comparing=undefinedundefinedundefined&ttl=600&sub_domain=@&record_type=A&record_line=%E9%BB%98%E8%AE%A4&value=" + txtSetIP.Text + "&mx=-&format=json&lang=cn&error_on_empty=no&use_session=yes";

                string posturl = "https://www.dnspod.cn/Api/Record.Create";
                string reffer = "https://www.dnspod.cn/Domain#/huolili123.com";

                string html = new xkHttp().httpPost(posturl, postdata, ref cookies, reffer, Encoding.UTF8);
                if (html.Contains("code\":\"1")) {
                    succNum++;
                }

                postdata = "selected=false&domain_id=" + strid + "&domain_grade=D_Free&domain=" + domain + "&visible=true&comparing=undefinedundefinedundefined&sub_domain=www&record_type=A&record_line=%E9%BB%98%E8%AE%A4&value=" + txtSetIP.Text + "&mx=-&ttl=600&format=json&lang=cn&error_on_empty=no&use_session=yes";
                html = new xkHttp().httpPost(posturl, postdata, ref cookies, reffer, Encoding.UTF8);
                if (html.Contains("code\":\"1")) {
                    succNum++;
                }
                Thread.Sleep(1500);
            }
            EchoHelper.Show("成功设置" + succNum + "条A记录！", EchoHelper.MessageType.提示);
            btnSetA.Enabled = true;
        }

        private void btnCreateDomain_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtNewDomains.Text)) {
                EchoHelper.Show("添加的域名列表为空！", EchoHelper.MessageType.错误);
                return;
            }
            if (txtNewDomains.Text.Split('\n').Length > 14) {
                EchoHelper.Show("每次最多添加15个域名，以免出错！", EchoHelper.MessageType.错误);
                return;
            }
            if (KryptonMessageBox.Show("一行一个的根域名，您确定要批量添加上述域名到Dnspod中吗？", "批量提交域名", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                new Thread(new ThreadStart(th_CreateDomain)).Start();
            }
        }

        public void th_CreateDomain() {
            btnCreateDomain.Enabled = false;
            string[] sts = txtNewDomains.Text.Split('\n');
            int succNum = 0;
            for (int i = 0; i < sts.Length; i++) {
                string postdata = "format=json&lang=cn&error_on_empty=no&use_session=yes&domain=" + sts[i].ToString().Trim() + "&is_mark=no";
                string posturl = "https://www.dnspod.cn/Api/Domain.Create";
                string reffer = "https://www.dnspod.cn/Domain#/all";

                string html = new xkHttp().httpPost(posturl, postdata, ref cookies, reffer, Encoding.UTF8);
                if (html.Contains("code\":\"1")) {
                    succNum++;
                }
                Thread.Sleep(1500);
            }
            EchoHelper.Show("成功设置" + succNum + "个域名！", EchoHelper.MessageType.提示);
            btnCreateDomain.Enabled = true;
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            groupBox3.Enabled = false;
            btnLoginDNSPOD.Enabled = true;
            btnLogout.Enabled = false;
        }

    }
}
