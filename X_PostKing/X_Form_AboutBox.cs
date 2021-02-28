using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using X_Service.Util;
using X_Service.Login;
using System.Xml;
using X_Model;
using X_Service.Db;

namespace X_PostKing {
    partial class X_Form_AboutBox : X_Form_Base {
        public X_Form_AboutBox() {
            InitializeComponent();
        }

        private void X_Form_AboutBox_Load(object sender, EventArgs e) {
            this.Text += "  当前版本：" + getVer();

            string group = Login_Base.member.group;
            lb授权.Text = string.Format("本软件授权给【{0}】，授权组别:【{2}】，拥有金币：【{1}】", Login_Base.member.netname, Login_Base.member.userMoney.ToString(), group);

            ///dododo();

        }

        public string getVer() {
            string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
            XmlNodeList oldNodeList = new XmlFiles(localXmlFile).GetNodeList("AutoUpdater/Files");
            string ver = oldNodeList.Item(0).Attributes["Ver"].Value.Trim();
            return ver;
        }

    }
}
