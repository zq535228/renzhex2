using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Model;

namespace X_PostKing {
    public partial class X_Form_AddSitePostEdit04Visit : X_Form_BaseTool {

        public ModelSite site = null;

        public X_Form_AddSitePostEdit04Visit( ModelSite si ) {
            InitializeComponent();
            site = si;
            Loaded();
        }

        private void btnCancel_Click( object sender , EventArgs e ) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click( object sender , EventArgs e ) {
            Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void X_Form_AddSitePostEdit04Visit_Load( object sender , EventArgs e ) {

        }

        private void Loaded() {
            txtPost_SuccessPage.Text = site.PostSuccessPage;
            txtPost_SuccessVisitList.Text = site.PostSuccessVisitList;
        }

        private void Save() {
            site.PostSuccessPage = txtPost_SuccessPage.Text;
            site.PostSuccessVisitList = txtPost_SuccessVisitList.Text;

        }

        private void linkLabel_LinkClicked( object sender , LinkLabelLinkClickedEventArgs e ) {
            try {
                LinkLabel link = (LinkLabel)sender;
                Clipboard.Clear();
                string Text = link.Tag.ToString();
                Clipboard.SetText(Text);
                txtPost_SuccessPage.Paste();
                Clipboard.Clear();
            } catch {

            }
        }



    }
}
