using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace X_PostKing {
    public partial class X_Form_CronExp : X_Form_BaseTool {

        public string CronExp = "";
        public DateTime StartDateTime;
        public DateTime? EndDateTime;


        public X_Form_CronExp() {
            InitializeComponent();
        }

        private void TS_保存_Click(object sender, EventArgs e) {
            CronExp = TriggerPanel.GetCronExp();
            StartDateTime = TriggerPanel.GetStartDateTime();
            EndDateTime = TriggerPanel.GetEndDateTime();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
