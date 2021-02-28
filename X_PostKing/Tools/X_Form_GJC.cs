using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Web;
using X_Service.Web;
using System.Text.RegularExpressions;
using X_Service.Util;
using ComponentFactory.Krypton.Toolkit;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using System.Net;

namespace X_PostKing.Tools {
    public partial class X_Form_GJC : X_Form_Base {

        #region 初始化关键词工具，字段初始化方法。
        public string KeywStr = "";
        /// <summary>
        /// 关键词用英文，分隔的文本
        /// </summary>
        public string KeywStrs = "";

        X_Waiting wait = new X_Waiting();
        Thread th;//线程

        public X_Form_GJC() {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; //去掉线程安全
        }

        public X_Form_GJC(string mainkey) {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; //去掉线程安全
            this.txtResult.Text = mainkey;
            this.KeywStr = mainkey;
            if (mainkey.Contains("\n")) {
                txtKeyword.Text = mainkey.Split('\n')[0].ToString().Trim();
            } else {
                txtKeyword.Text = mainkey.ToString().Trim();
            }
        }

        public X_Form_GJC(string mainkey, string contentkey) {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; //去掉线程安全
            this.txtResult.Text = mainkey;
            this.KeywStr = mainkey;

            if (mainkey.Contains("\n")) {
                txtKeyword.Text = mainkey.Split('\n')[0].ToString().Trim();
            } else {
                txtKeyword.Text = mainkey.ToString().Trim();
            }
            txtResult.Text = contentkey;
        }

        /// <summary>
        /// 重写关闭方法 增加弹出确定关闭对话框.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
            if (this.KeywStr != txtResult.Text) {
                if (KryptonMessageBox.Show("发现内容更改了，不保存and直接退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                } else {
                    e.Cancel = true;
                }
                base.OnClosing(e);
            }

        }

        private void X_Form_GJC_Load(object sender, EventArgs e) {

        }
        #endregion

        #region 百度的关键词挖掘+二次挖掘
        //百度首次挖掘的线程
        public void GoSearch() {
            txtResult.AppendText(txtKeyword.Text + Environment.NewLine);
            ArrayList al = KeySearch(txtKeyword.Text);
            if (al.Count == 0) {
                EchoHelper.Show("本次未获取到关键词，请再试一下！", EchoHelper.MessageType.提示);
            }
            for (int i = 0; i < al.Count; i++) {
                if (!txtResult.Text.Contains(al[i].ToString())) {
                    txtResult.AppendText(al[i].ToString() + Environment.NewLine);
                }
            }
            wait.CloseMsg();
        }


        private void SearchAg_TH() {
            string[] tmp_keys = txtResult.Text.Split('\n');
            if (tmp_keys.Length < 2) {//最少要2个关键词
                KryptonMessageBox.Show("列表中无关键词,请先首次挖掘!");
                return;
            }
            wait.ShowMsg("关键词查询中，可能要等几分钟。。");
            for (int i = 0; i < tmp_keys.Length; i++) {
                ArrayList al = KeySearch(tmp_keys[i].ToString().Trim());
                for (int j = 0; j < al.Count; j++) {
                    if (!txtResult.Text.Contains(al[j].ToString())) {
                        txtResult.AppendText(al[j].ToString() + Environment.NewLine);
                    }
                }
                Thread.Sleep(500);
            }
            wait.CloseMsg();
        }

        private ArrayList KeySearch(string keyw) {
            ArrayList Keyws = new ArrayList();
            CookieCollection cookies = new CookieCollection();
            string purl = "http://renzhe.sinaapp.com/index.php/Kws/index/bq/" + HttpUtility.UrlEncode(StringHelper.FormatHtml(keyw), Encoding.UTF8);
            string html = new xkHttp().httpGET(purl, ref cookies).ToLower();
            ArrayList Keyws2 = RegexHelper.getMatchs(html, "&quot;(.*?)&quot;", 1);
            foreach (var item in Keyws2) {
                if (!item.ToString().Contains("get") && !string.IsNullOrEmpty(item.ToString().Trim())) {
                    Keyws.Add(item);
                }
            }
            return Keyws;
        }


        //private ArrayList KeySearch(string keyw) {
        //    keyw = StringHelper.FormatHtml(keyw);
        //    ArrayList Keyws = new ArrayList();
        //    string url = "http://www.baidu.com/s?wd=" + HttpUtility.UrlEncode(keyw);

        //    xkCookies.Clear();
        //    string html = new xkHttp().httpGET(url, xkCookies.GetCookie(), url).Replace("\n", "`");//变成一行,有利于正则
        //    Thread.Sleep(100);
        //    string pattern = "相关搜索</th><th>(.*?)</th></tr></table>";
        //    Match mc = Regex.Match(html, pattern);
        //    html = mc.Groups[1].Value;//第一次过滤缩小范围

        //    pattern = "<a href=\".*?\">(.*?)</a>";
        //    MatchCollection mcs = Regex.Matches(html, pattern, RegexOptions.IgnoreCase);

        //    foreach (Match m in mcs) {
        //        string tmpkey = m.Groups[1].Value;
        //        if (!Keyws.Contains(tmpkey) && tmpkey.Contains(keyw)) {
        //            Keyws.Add(tmpkey);
        //        }
        //    }
        //    return Keyws;
        //}

        #endregion


        #region 按键产生的事件
        private void btnSubmit_Click(object sender, EventArgs e) {
            if (txtKeyword.Text.Trim() == "")
                KryptonMessageBox.Show("请输入关键词");
            wait.ShowMsg("关键词查询中，可能要等几分钟。。");
            txtResult.Clear();
            th = new Thread(new ThreadStart(GoSearch));
            th.Start();//线程开始,查询开始

        }

        private void btnWa_Click(object sender, EventArgs e) {
            th = new Thread(new ThreadStart(SearchAg_TH));
            th.Start();//线程开始,查询开始
        }


        private void btnOut_Click(object sender, EventArgs e) {

        }




        private void btnSave_Click(object sender, EventArgs e) {
            this.KeywStr = txtResult.Text;
            string[] strs = txtResult.Text.Split('\n');
            foreach (var str in strs) {
                this.KeywStrs += str + ",";
            }
            this.KeywStrs = this.KeywStrs.TrimEnd(',');
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string Text = link.Tag.ToString();
                txtResult.Cut();
                Clipboard.SetText(Text.Replace("[关键词]", Clipboard.GetText()));
                txtResult.Paste();
                Clipboard.Clear();
            } catch {

            }
        }

        #endregion
    }
}
