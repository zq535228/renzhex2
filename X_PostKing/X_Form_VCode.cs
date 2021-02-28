using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace X_PostKing {
    public partial class X_Form_VCode : Form {

        public X_Form_VCode ( Image image ) {
            InitializeComponent();
            this.img = image;
        }

        private void X_FormVCode_Load ( object sender , EventArgs e ) {
            pbVcode.Image = this.img;
        }


        public string key = null;
        public Image img = null;

        private void button1_Click ( object sender , EventArgs e ) {

        }

        private void FrmVcode_FormClosed ( object sender , FormClosedEventArgs e ) {
            key = textBox1.Text;

        }

        private void textBox1_KeyPress ( object sender , KeyPressEventArgs e ) {

        }

        private void btnSubmit_Click ( object sender , EventArgs e ) {
            key = textBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
