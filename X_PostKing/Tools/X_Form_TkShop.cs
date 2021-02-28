using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Service.Util;
using System.IO;
using X_Service.Files;
using System.Threading;
using X_Service.Login;

namespace X_PostKing.Tools {
    public partial class X_Form_TkShop : X_Form_BaseTool {
        string txtTapiPath;
        string txtOutPath;

        public X_Form_TkShop() {
            InitializeComponent();
            txtTapiPath = Application.StartupPath;
            txtOutPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\tapi";
            if (!Login_Base.member.group.Contains("商业授权用户") ) {
                this.tabControlTKShop.Enabled = false;
                EchoHelper.Show("您的权限不足！", EchoHelper.MessageType.错误);
                this.TopMost = true;
            }
        }

        private void btnOutput_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(txtSClick.Text) && !string.IsNullOrEmpty(txtSClick.Text)) {
                new Thread(new ThreadStart(ThStart)).Start();
                btnOutput.Enabled = false;
            } else {
                EchoHelper.Show("广告基本信息不完整，请核查。", EchoHelper.MessageType.错误);
            }
        }


        protected void ThStart() {

            if (Directory.Exists(txtOutPath)) {
                EchoHelper.Echo("发现目标文件，准备清理中。。。" + txtOutPath, "输出路径", EchoHelper.EchoType.普通信息);
                if (MessageBox.Show("发现目标文件是否清理?", "确认", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) {
                    FilesHelper.DeleteInDir(txtOutPath);
                } else {
                    return;
                }
                EchoHelper.Echo("目标文件存在，清理成功。" + txtOutPath, "输出路径", EchoHelper.EchoType.普通信息);
            }

            EchoHelper.Echo("整理文件中，请稍等！" + txtOutPath, "输出路径", EchoHelper.EchoType.任务信息);

            try {
                ZipHelper.UnZip(txtTapiPath + "\\X_TkShop.dll", txtOutPath);
            } catch {
                EchoHelper.Echo("解压程序出错，请检查设置或下载最新版本重试！", "解压失败", EchoHelper.EchoType.错误信息);
                return;
            }

            string get_html = txtOutPath + @"\get.html";
            replaceStr(get_html);
            txtOverInsertHTML.Text = txtOverInsertHTML.Text.Replace("[延时载入]", txtDelayNum.Value.ToString());
            btnOutput.Enabled = true;
            
            EchoHelper.Echo("淘宝客模版生成成功！", "模块生成", EchoHelper.EchoType.普通信息);
            MessageBox.Show("淘宝客模版生成成功。插入下面的代码吧！");
        }

        private void replaceStr(string path) {
            string fileStr = FilesHelper.ReadFile(path, null);
            fileStr = fileStr.Replace("[佣金链接]", txtSClick.Text);
            fileStr = fileStr.Replace("[店铺地址]", txtShopUrl.Text);

            FilesHelper.DeleteFile(path);
            EchoHelper.Echo("删除文件成功！" + path, "替换变量", EchoHelper.EchoType.任务信息);

            FilesHelper.Write_File(path, fileStr);
            EchoHelper.Echo("重新写入文件！" + path, "替换变量", EchoHelper.EchoType.任务信息);

        }

    }
}
