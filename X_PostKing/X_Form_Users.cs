using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using X_Model;
using System.Threading;
using X_Service.Util;
using X_PostKing.Job;
using ComponentFactory.Krypton.Toolkit;

namespace X_PostKing {
    public partial class X_Form_Users : X_Form_Base {
        #region 构造函数
        public string SelectIds = string.Empty;
        ModelSite SiteInfo = null;
        
        public X_Form_Users ( ModelSite si ) {
            InitializeComponent();
            SiteInfo = si;
            Form.CheckForIllegalCrossThreadCalls = false;
        }
        #endregion

        #region 事件
        private void 添加账户ToolStripMenuItem_Click ( object sender , EventArgs e ) {
            ModelUsers user = new ModelUsers();
            if ( SiteInfo.LoginType == LoginType.马甲登陆模式 ) {
                user.LoginMethod = LoginMethod.Cookie登陆;
            }
            user.Id = SiteInfo.LastUsersId;
            X_Form_AddSiteUser siteuser = new X_Form_AddSiteUser(user , SiteInfo.LoginMVerifyUrl.Replace("[后台地址]" , SiteInfo.SiteBackUrl));
            if ( siteuser.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                this.SiteInfo.modelUsers.Add(siteuser.user);
                SiteInfo.LastUsersId++;
            }
            LoadListUsers();//重新加载...
        }

        private void Cms_账户管理_Opening ( object sender , System.ComponentModel.CancelEventArgs e ) {
            if ( ListUsers.SelectedItems.Count == 0 ) {
                编辑当前账户ToolStripMenuItem.Enabled = false;
                测试登陆.Enabled = false;
                删除当前账户ToolStripMenuItem.Enabled = false;

            } else if ( ListUsers.SelectedItems.Count == 1 ) {
                编辑当前账户ToolStripMenuItem.Enabled = true;
                测试登陆.Enabled = true;
                删除当前账户ToolStripMenuItem.Enabled = true;
            } else {
                编辑当前账户ToolStripMenuItem.Enabled = false;
                测试登陆.Enabled = true;
                删除当前账户ToolStripMenuItem.Enabled = false;
            }
        }

        private void 编辑当前账户ToolStripMenuItem_Click ( object sender , EventArgs e ) {
            int id = int.Parse(ListUsers.SelectedItems[0].Text);
            ModelUsers user = new ModelUsers();
            user = SiteInfo.modelUsers[FindIndexByUserid(id)];
            X_Form_AddSiteUser siteuser = new X_Form_AddSiteUser(user , SiteInfo.LoginMVerifyUrl.Replace("[后台地址]" , SiteInfo.SiteBackUrl));
            if ( siteuser.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                this.SiteInfo.modelUsers[FindIndexByUserid(id)] = ( siteuser.user );
            }
            LoadListUsers();//重新加载...
        }

        private void 删除当前账户ToolStripMenuItem_Click ( object sender , EventArgs e ) {
            int id = int.Parse(ListUsers.SelectedItems[0].Text);
            if ( KryptonMessageBox.Show(string.Format("您确定要删除账户[{0}]吗？删除后您将不能使用该账户发布信息！" , ListUsers.SelectedItems[0].SubItems[1].Text) , "注意" , MessageBoxButtons.YesNo , MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes ) {
                RemoveUserByid(id);
                LoadListUsers();//重新加载...
            }

        }

        private void 测试登陆_Click ( object sender , EventArgs e ) {
            for ( int i = 0; i < ListUsers.SelectedItems.Count; i++ ) {
                int id = int.Parse(ListUsers.SelectedItems[i].Text);
                Thread th = new Thread(new ParameterizedThreadStart(Test_Login));
                th.IsBackground = true;
                th.Start(id);
            }
        }

        private void Btn_LoginAll_Click ( object sender , EventArgs e ) {
            for ( int i = 0; i < ListUsers.Items.Count; i++ ) {
                int id = int.Parse(ListUsers.Items[i].Text);
                Thread th = new Thread(new ParameterizedThreadStart(Test_Login));
                th.IsBackground = true;
                th.Start(id);
            }
        }

        private void Btn_OK_Click ( object sender , EventArgs e ) {
            if ( ListUsers.SelectedItems.Count == 0 ) {
                EchoHelper.Show("请至少选择一个账号！" , EchoHelper.MessageType.提示);
                return;
            }
            SelectIds = string.Empty;
            for ( int i = 0; i < ListUsers.SelectedItems.Count; i++ ) {
                SelectIds += ListUsers.SelectedItems[i].Text + ",";
            }
            SelectIds = SelectIds.Substring(0 , SelectIds.Length - 1);
            this.DialogResult = DialogResult.OK;
        }

        private void X_Form_Users_Load ( object sender , EventArgs e ) {
            LoadListUsers();
        }

        private void ListUsers_DoubleClick ( object sender , EventArgs e ) {
            if ( ListUsers.SelectedItems.Count == 1 ) {
                int id = int.Parse(ListUsers.SelectedItems[0].Text);
                ModelUsers user = new ModelUsers();
                user = SiteInfo.modelUsers[FindIndexByUserid(id)];
                X_Form_AddSiteUser siteuser = new X_Form_AddSiteUser(user , SiteInfo.LoginMVerifyUrl.Replace("[后台地址]" , SiteInfo.SiteBackUrl));
                if ( siteuser.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                    this.SiteInfo.modelUsers[FindIndexByUserid(id)] = ( siteuser.user );
                }
                LoadListUsers();//重新加载..
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 根据Id号码查找序列
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int FindIndexByUserid ( int id ) {
            for ( int i = 0; i < SiteInfo.modelUsers.Count; i++ ) {
                if ( SiteInfo.modelUsers[i].Id == id ) {
                    return i;
                }
            }
            return 0;
        }
        /// <summary>
        /// 根据ID删除用户
        /// </summary>
        /// <param name="id"></param>
        private void RemoveUserByid ( int id ) {
            for ( int i = 0; i < SiteInfo.modelUsers.Count; i++ ) {
                if ( SiteInfo.modelUsers[i].Id == id ) {
                    SiteInfo.modelUsers.RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// 加载用户名列表
        /// </summary>
        private void LoadListUsers ( ) {
            ListUsers.Items.Clear();
            foreach ( ModelUsers user in SiteInfo.modelUsers ) {
                if ( SiteInfo.LoginType == LoginType.马甲登陆模式 ) {
                    if ( user.LoginMethod == LoginMethod.Cookie登陆 ) {
                        ListViewItem item = new ListViewItem(user.Id.ToString());
                        switch ( user.LoginState ) {
                            case LoginState.登陆失败:
                                item.ForeColor = Color.Red;
                                break;
                            case LoginState.未登录:
                                item.ForeColor = Color.Blue;
                                break;
                            case LoginState.未知:
                                item.ForeColor = Color.SaddleBrown;
                                break;
                            case LoginState.已登录:
                                item.ForeColor = Color.Green;
                                break;
                        }
                        item.SubItems.Add(user.Uname);
                        item.SubItems.Add(user.LoginState.ToString());
                        item.SubItems.Add(user.GetTimeSub());
                        item.SubItems.Add(user.LastUrl);
                        ListUsers.Items.Add(item);
                    }
                } else if ( SiteInfo.LoginType == LoginType.自动登陆模式 ) {
                    if ( user.LoginMethod == LoginMethod.用户名登陆 ) {
                        ListViewItem item = new ListViewItem(user.Id.ToString());
                        switch ( user.LoginState ) {
                            case LoginState.登陆失败:
                                item.ForeColor = Color.Red;
                                break;
                            case LoginState.未登录:
                                item.ForeColor = Color.Blue;
                                break;
                            case LoginState.未知:
                                item.ForeColor = Color.SaddleBrown;
                                break;
                            case LoginState.已登录:
                                item.ForeColor = Color.Green;
                                break;
                        }
                        item.SubItems.Add(user.Uname);
                        item.SubItems.Add(user.LoginState.ToString());
                        item.SubItems.Add(user.GetTimeSub());
                        item.SubItems.Add(user.LastUrl);
                        ListUsers.Items.Add(item);
                    }
                }
            }

            if ( ListUsers.Items.Count > 0 ) {
                this.Text = "账户列表（请选择一个或多个账户）";
                groupBox3.Text = string.Format("账户信息列表：模式：{1}(当前共有{0}个账户)" , ListUsers.Items.Count , SiteInfo.LoginType);
                ListUsers.Focus();
                ListUsers.Items[0].Selected = true;
            } else {
                this.Text = "账户列表（当前列表没有账户，请至少添加一个！）";
            }
        }
        /// <summary>
        /// 测试登陆
        /// </summary>
        /// <param name="id"></param>
        private void Test_Login ( object id ) {
            int userID = (int)id;
            JobCoreTest test = new JobCoreTest(SiteInfo , FindModelUserByID(SiteInfo , userID));
            test.Login();
            LoadListUsers();
        }
        #endregion

        private void 注册账户ToolStripMenuItem_Click ( object sender , EventArgs e ) {
            //X_Form_Browser bro = new X_Form_Browser();
            //bro.ShowDialog();//效果
        }

        private void 登录ToolStripMenuItem_Click ( object sender , EventArgs e ) {
            //X_Form_Browser bro = new X_Form_Browser();
            ////bro.siteUrl = "http://dz15/";
            //bro.ShowDialog();//效果
        }

    }
}
