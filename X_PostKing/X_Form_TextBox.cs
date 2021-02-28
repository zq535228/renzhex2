using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace X_PostKing {
    public partial class X_Form_TextBox : X_Form_Base {
        public X_Form_TextBox() {
            InitializeComponent();
        }

        private void textBoxValue_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
