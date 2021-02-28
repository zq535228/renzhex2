using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Service.Util;

namespace X_PostKing {
    public partial class X_Form_AddGroup : X_Form_BaseTool {
        #region 构造函数
        public String Group_Name = string.Empty;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isedit">是否为编辑状态</param>
        /// <param name="Name">名称</param>
        public X_Form_AddGroup ( bool isedit , string Name = "新增群组" ) {
            InitializeComponent();
            textBox1.Text = Name;
            if ( isedit ) {
                this.Text = "增加新组别";
            } else {
                this.Text = "修改组别名称";
            }
        }
        #endregion

        #region 事件
        private void TS_保存_Click ( object sender , EventArgs e ) {
            if ( textBox1.Text.Trim().Length > 2 ) {
                Group_Name = textBox1.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            } else {
                EchoHelper.ShowBalloon("-_-!" , "大侠，组别最少要2个字符以上哦！" , textBox1);
            }
        }

        private void TS_取消_Click ( object sender , EventArgs e ) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        #endregion
    }
}
