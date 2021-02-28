using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Model;
using X_Service.Util;
using ComponentFactory.Krypton.Toolkit;

namespace X_PostKing.Tools {
    public partial class X_Form_Advanced_Settings : X_Form_BaseTool {
        X_Waiting wait = new X_Waiting();

        public X_Form_Advanced_Settings() {
            InitializeComponent();
        }

        private void btnPerWaitSet_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("真的要对全部站点，设定批次间间隔为" + txtperWait.Value + "秒？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel) {
                return;
            }

            for (int i = 0; i < ModelMain.AllData.SiteList.Count; i++) {
                ModelMain.AllData.SiteList[i].perWait = Convert.ToInt32(txtperWait.Value);
            }
            EchoHelper.Show("设定" + ModelMain.AllData.SiteList.Count + "个站点成功！", EchoHelper.MessageType.提示);
        }

        private void btnIsTitleWYC_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("真的要对全部任务，设定开启标题伪原创正规化处理？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel) {
                return;
            }

            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                ModelMain.AllData.TasksList[i].IsTitleWYC = true;
            }
            EchoHelper.Show("设定" + ModelMain.AllData.TasksList.Count + "个任务成功！", EchoHelper.MessageType.提示);

        }

        private void btnPlan_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("真的要对每个任务，添加计划并设定为随机时间的日触发？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel) {
                return;
            }
            wait.ShowMsg("设定任务中...");
            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                wait.ShowMsg("设定任务中..." + (ModelMain.AllData.TasksList.Count - i).ToString());
                ModelMain.AllData.TasksList[i].IsPlan = true;
                ModelMain.AllData.TasksList[i].benginTime = DateTime.Now.AddDays(-1);
                ModelMain.AllData.TasksList[i].CroExp = StringHelper.getRandNextNum(1) + " " + StringHelper.getRandNextNum(3, 9) + " " + StringHelper.getRandNextNum(59) + " " + StringHelper.getRandNextNum(59);
            }
            wait.CloseMsg();
            EchoHelper.Show("设定" + ModelMain.AllData.TasksList.Count + "个任务成功！", EchoHelper.MessageType.提示);
        }

        private void btnPerNum_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("真的要对每个任务，发布量设定为：" + txtperNum.Value + "？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel) {
                return;
            }
            wait.ShowMsg("设定任务中...");
            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                wait.ShowMsg("设定任务中..." + (ModelMain.AllData.TasksList.Count - i).ToString());
                ModelMain.AllData.TasksList[i].perNum = Convert.ToInt32(txtperNum.Value);
            }
            wait.CloseMsg();
            EchoHelper.Show("设定" + ModelMain.AllData.TasksList.Count + "个任务成功！", EchoHelper.MessageType.提示);
        }

        private void btnAllSentence_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("真的要对每个任务，开启断言？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel) {
                return;
            }
            wait.ShowMsg("设定任务中...");
            for (int i = 0; i < ModelMain.AllData.TasksList.Count; i++) {
                wait.ShowMsg("设定任务中..." + (ModelMain.AllData.TasksList.Count - i).ToString());
                ModelMain.AllData.TasksList[i].IsSentence = true;
                ModelMain.AllData.TasksList[i].IsSentenceAuto = true;
                ModelMain.AllData.TasksList[i].SentenceMinLength = 20;
                ModelMain.AllData.TasksList[i].SentenceInsertBetween = 3;
            }
            wait.CloseMsg();
            EchoHelper.Show("设定" + ModelMain.AllData.TasksList.Count + "个任务成功！", EchoHelper.MessageType.提示);
        }

        private void btnSiteLink_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("真的要对全部站点，开启链轮？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel) {
                return;
            }

            for (int i = 0; i < ModelMain.AllData.SiteList.Count; i++) {
                if (!string.IsNullOrEmpty(ModelMain.AllData.SiteList[i].PostSuccessPage) && SeoHelper.isWWW(ModelMain.AllData.SiteList[i].SiteBackUrl)) {
                    ModelMain.AllData.SiteList[i].LinkRate = 0.3 / 2;
                    ModelMain.AllData.SiteList[i].IsInternetLink = true;
                }

            }
            EchoHelper.Show("设定" + ModelMain.AllData.SiteList.Count + "个站点成功！", EchoHelper.MessageType.提示);

        }
    }
}
