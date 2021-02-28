using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Service.Util;

namespace X_PostKing {
    public partial class X_Form_Setup : X_Form_Base {

        public X_Form_Setup ( ) {
            InitializeComponent();
        }

        private void TS_保存_Click ( object sender , EventArgs e ) {
            SaveLogSetup();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #region 日志设定的读取与保存,应用了INIHelper,保存在/Config/Setup.ini文件中.
        private void SaveLogSetup ( ) {
            //保存日志信息
            string path = Application.StartupPath + "\\Config\\Setup.ini";
            INIHelper ini = new INIHelper(path);

            ini.up("日志设定" , "错误信息" , ck错误信息.Checked.ToString());
            ini.up("日志设定" , "普通信息" , ck普通信息.Checked.ToString());
            ini.up("日志设定" , "任务信息" , ck任务信息.Checked.ToString());
            ini.up("日志设定" , "异常信息" , ck异常信息.Checked.ToString());
            ini.up("日志设定" , "日志窗口" , ck日志窗口.Checked.ToString());

            ini.up("默认注册信息" , "Uname" , txtUname.Text);
            ini.up("默认注册信息" , "Upass" , txtUpass.Text);
            ini.up("默认注册信息" , "Email" , txtEmail.Text);
            ini.up("默认注册信息" , "ToEmail" , txtToEmail.Text);


        }

        private void LoadLogSetup ( ) {
            try {
                string path = Application.StartupPath + "\\Config\\Setup.ini";
                INIHelper ini = new INIHelper(path);
                
                ck错误信息.Checked = Convert.ToBoolean(ini.re("日志设定" , "错误信息"));
                ck普通信息.Checked = Convert.ToBoolean(ini.re("日志设定" , "普通信息"));
                ck任务信息.Checked = Convert.ToBoolean(ini.re("日志设定" , "任务信息"));
                ck异常信息.Checked = Convert.ToBoolean(ini.re("日志设定" , "异常信息"));
                ck日志窗口.Checked = Convert.ToBoolean(ini.re("日志设定" , "日志窗口"));

                txtUname.Text = ini.re("默认注册信息" , "Uname");
                txtUpass.Text = ini.re("默认注册信息" , "Upass");
                txtEmail.Text = ini.re("默认注册信息" , "Email");
                txtToEmail.Text = ini.re("默认注册信息" , "ToEmail");

            } catch ( Exception ex ) {
                EchoHelper.Echo("Setup信息读取出错啦." , ex.Message , EchoHelper.EchoType.异常信息);
            }

        }


        #endregion

        private void X_Form_Setup_Load ( object sender , EventArgs e ) {
            LoadLogSetup();//加载日志设定
            tabControl1_SelectedIndexChanged(sender , e);
        }

        private void TS_关闭_Click ( object sender , EventArgs e ) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void tabControl1_SelectedIndexChanged ( object sender , EventArgs e ) {
            switch ( tabControl1.SelectedIndex ) {
                case 0: {
                        tabControl1.Size = new Size(tabControl1.Size.Width , groupBox1.Size.Height + groupBox3.Size.Height + groupBox2.Size.Height + 37);
                        this.Size = new Size(this.Size.Width , pictureBox1.Size.Height + ToolS.Size.Height + tabControl1.Size.Height + 30 + 22);
                        break;
                    }
            }

        }

    }
}
