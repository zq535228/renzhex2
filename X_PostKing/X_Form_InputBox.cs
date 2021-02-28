using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace X_PostKing {
    public partial class X_Form_InputBox : X_Form_BaseTool {

        public string InputStr;
        public X_Form_InputBox ( string str ) {
            InitializeComponent();
            this.InputStr = str;
            this.txtInputStr.Text = str;
        }

        private void TS_保存_Click ( object sender , EventArgs e ) {
            this.InputStr = txtInputStr.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void TS_取消_Click ( object sender , EventArgs e ) {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
