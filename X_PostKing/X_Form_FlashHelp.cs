using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Service.Files;

namespace X_PostKing {
    public partial class X_Form_FlashHelp : X_Form_BaseTool {
        public X_Form_FlashHelp() {
            InitializeComponent();
            this.webBrowserHelper.Url = new Uri("http://www.renzhe.org/pub_video/help.html");
        }
    }
}
