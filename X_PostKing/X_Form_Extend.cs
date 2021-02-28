using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using X_Service.Web;
using System.Web;
using X_Service.Util;
using X_Service.Files;
using System.Collections;
using ComponentFactory.Krypton.Toolkit;
using System.Net;

namespace X_PostKing {
    public partial class X_Form_Extend : X_Form_BaseTool {
        public X_Form_Extend() {
            InitializeComponent();
        }
        protected X_Waiting wait = new X_Waiting();

        private void TS_保存_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtKey.Text) || string.IsNullOrEmpty(txtInUrl.Text)) {
                EchoHelper.ShowBalloon("警告：", "大侠，关键词，关键URL特征，不能为空。都需要填写内容！", txtKey);
                return;
            }
            wait.ShowMsg("搜索进行中，大侠莫要着急。");
            btnSearch.Enabled = false;
            Thread th = SearchThread("SearchTH");
            if (th == null) {
                th = new Thread(new ThreadStart(SearchTH));
                th.IsBackground = true;
            }
            th.Start();
        }
        private void SearchTH() {

            for (int i = 0; i < 5; i++) {
                CookieCollection cookies = new CookieCollection();
                string html = new xkHttp().httpGET("http://www.google.com.hk/search?q=" + HttpUtility.HtmlEncode(txtKey.Text) + "+inurl:" + txtInUrl.Text + "&hl=zh-CN&safe=strict&biw=1366&bih=627&prmd=ivns&ei=PBcsTZX4J8iecb2B8ZkI&start=" + i + "0&sa=N", ref cookies, "");
                string pattern = @"(((\w|-)+[.]){1,}(com|cn|mobi|tel|asia|net|org|name|me|info|org|gov|cc|hk|biz|tv))";
                MatchCollection mc = Regex.Matches(html, pattern);
                foreach (Match match in mc) {
                    if (!match.ToString().Contains("google") && !txtContent.Text.Contains(match.ToString()) && !match.ToString().Contains("265") && !match.ToString().Contains("k.com")) {
                        txtContent.AppendText(match.ToString() + Environment.NewLine);
                    }
                }
                Thread.Sleep(5000);
            }
            btnSearch.Enabled = true;
            wait.CloseMsg();
            KryptonMessageBox.Show("完毕");
        }

        private void btnOutput_Click(object sender, EventArgs e) {
            saveFile.Filter = "导出网站列表(*.txt)|*.txt";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                FilesHelper.Write_File(saveFile.FileName, txtContent.Text);
            }
        }

        private void BtnWa_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtInlink.Text)) {
                EchoHelper.ShowBalloon("警告：", "请填写您要查询的网址URL，不能为空！", txtInlink);
                return;
            }
            wait.ShowMsg("搜索进行中，大侠莫要着急。");

            BtnWa.Enabled = false;
            Thread th = SearchThread("BtnWa");
            if (th == null) {
                th = new Thread(new ThreadStart(inlinkTH));
                th.Name = "BtnWa";
                th.IsBackground = true;
            }
            th.Start();
        }

        private void inlinkTH() {
            string url = "http://inlink.linkhelper.cn/?url=" + txtInlink.Text;
            CookieCollection cookies = new CookieCollection();
            string html = new xkHttp().httpGET(url, ref cookies);
            ArrayList al = RegexHelper.getMatchs(html, @"rowspan=1>[0-9]+?\.(.*)", 1);
            for (int i = 0; i < al.Count; i++) {
                txtInContent.AppendText(Environment.NewLine + al[i].ToString().Trim());
            }
            BtnWa.Enabled = true;
            wait.CloseMsg();
        }

    }
}
