using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Service.Util;
using System.Threading;

namespace X_PostKing.Tools {
    public partial class X_Form_Domain : X_Form_BaseTool {
        public X_Form_Domain() {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        //开始批量检测域名是否可以注册
        private void btnStart_Click(object sender, EventArgs e) {
            btnStart.Enabled = false;
            Thread th = new Thread(new ThreadStart(TH));
            th.IsBackground = true;
            th.Start();
        }

        private void TH() {
            try {
                string[] str1 = txtBefore.Text.Split('\n');
                int numleft = str1.Length;
                for (int i = 0; i < str1.Length; i++) {
                    int checkout = SeoHelper.checkDomain(str1[i]);
                    if (checkout > 0) {
                        txtAfter.Text = str1[i] + Environment.NewLine + txtAfter.Text;
                    }
                    numleft--;
                    txtBefore.Text = txtBefore.Text.Replace(txtBefore.Lines[0], "").Trim();
                    btnStart.Text = "查询(" + numleft + ")";
                }
            } catch { } finally {
                btnStart.Enabled = true;
                txtEnableDomain.Text = txtAfter.Text;
            }
        }

        private void linkFindDomain_LinkClicked(object sender, EventArgs e) {
            ProcessHelper.openUrl("http://www.kingnic.com/");
        }

        //在可注册的域名中，查询出已经备案的玉米。
        private void btnBeiAN_Click(object sender, EventArgs e) {
            btnBeiAN.Enabled = false;
            Thread th = new Thread(new ThreadStart(TH2));
            th.IsBackground = true;
            th.Start();
        }

        private void TH2() {
            try {
                string[] str1 = txtEnableDomain.Text.Split('\n');
                int numleft = str1.Length;
                for (int i = 0; i < str1.Length; i++) {
                    int checkout = SeoHelper.getDomainISBeiAN(str1[i]);
                    if (checkout > 0) {
                        txtBenANDomain.Text = str1[i] + Environment.NewLine + txtBenANDomain.Text;
                    }
                    numleft--;
                    txtEnableDomain.Text = txtEnableDomain.Text.Replace(txtEnableDomain.Lines[0], "").Trim();
                    btnBeiAN.Text = "查询(" + numleft + ")";
                }
            } catch { } finally {
                btnBeiAN.Enabled = true;
            }
        }

        private void linkBmi_LinkClicked(object sender, EventArgs e) {
            ProcessHelper.openUrl("http://jinmi8.com/icps___0____1.html");
        }

    }
}
