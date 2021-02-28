using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace AutoRunServer {
    public partial class Run : Form {
        public Run() {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnAutoRun_Click(object sender, EventArgs e) {
            Thread th = new Thread(new ThreadStart(th_login));
            th.IsBackground = true;
            th.Start();
            btnAutoRun.Enabled = false;
        }

        private void th_login() {
            while (true) {
                Thread.Sleep(5000);
                //检查进程是否已经启动，已经启动则退出程序。 
                if (System.Diagnostics.Process.GetProcessesByName("ConsoleServer").Length == 0) {
                    string exe_path = Application.StartupPath;
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "ConsoleServer.exe";
                    process.StartInfo.WorkingDirectory = exe_path;
                    process.StartInfo.CreateNoWindow = true;
                    try {
                        process.Start();
                    } catch (Exception ex) {
                        btnAutoRun.Text = "启动出错！" + ex.Message;
                        btnAutoRun.Enabled = true;
                    }
                }

            }

        }

        private void Run_FormClosing(object sender, FormClosingEventArgs e) {

        }

        private void buttonKill_Click(object sender, EventArgs e) {
            Process[] ps = System.Diagnostics.Process.GetProcessesByName("ConsoleServer");
            for (int i = 0; i < ps.Length; i++) {
                //ps[i].Dispose();
                //ps[i].Close();
                ps[i].Kill();
            }
        }

        protected virtual void notiICON_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                if (!Visible) {
                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                    this.TopMost = true;
                    this.TopMost = false;
                }
            }
        }

        protected void Run_SizeChanged(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Visible = false;
                notiICON.Visible = true;
                this.notiICON.ShowBalloonTip(3000, "我在这里", "忍者站群服务端", ToolTipIcon.Info);
            } else {
                notiICON.Visible = false;
            }
        }

    }
}
