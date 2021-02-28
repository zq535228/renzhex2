using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using X_Model;
using X_Service.Util;
using X_PostKing.Job;
using System.Collections;
using System.Collections.Generic;
using X_Service.Files;
using System.IO;
using X_Service.Db;
using X_Service.Web;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Tags;
using X_Service.Fetch;
using ComponentFactory.Krypton.Toolkit;

namespace X_PostKing {
    public partial class X_Form_AddSite : X_Form_BaseTool {

        #region 构造函数
        X_Waiting wait = new X_Waiting();

        public ModelSite site = new ModelSite();
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isedit">是否为编辑站点</param>
        /// <param name="st">参数</param>
        /// <param name="GroupName">群组名称</param>
        public X_Form_AddSite(bool isedit, ModelSite st, string GroupName) {
            InitializeComponent();
            //更改标题
            if (!isedit) {
                this.Text = "添加一个新站点";
            } else {
                this.Text = "编辑站点资料";
            }
            //赋值
            site = st;
            this.Group_Name.Text = GroupName;
            Form.CheckForIllegalCrossThreadCalls = false;
            LoadListUsers();
        }

        #endregion

        #region 事件

        private void X_Form_AddSite_Load(object sender, EventArgs e) {
            TabC_AddSite.SelectedIndex = 0;
            TabC_AddSite_SelectedIndexChanged(sender, e);
            Loaded();
            new Thread(new ThreadStart(doit)).Start();
        }

        private void doit() {
            new WebServiceHelper().doit();
        }

        private void 添加账户ToolStripMenuItem_Click(object sender, EventArgs e) {
            ModelUsers user = new ModelUsers();
            if (site.LoginType == LoginType.马甲登陆模式) {
                user.LoginMethod = LoginMethod.Cookie登陆;
            }
            user.Id = site.LastUsersId;
            X_Form_AddSiteUser siteuser = new X_Form_AddSiteUser(user, site.LoginMVerifyUrl.Replace("[后台地址]", site.SiteBackUrl));
            if (siteuser.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                this.site.modelUsers.Add(siteuser.user);
            }
            LoadListUsers();//重新加载...
        }

        private void TS_保存_Click(object sender, EventArgs e) {
            save();
            if (site.SiteName.Trim() != string.Empty) {
                this.DialogResult = DialogResult.OK;
                SaveAll();
            } else {
                EchoHelper.ShowBalloon("站点名称", "您必须输入站点名称才能保存哦！", Site_Name);
            }

        }

        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void Btn_Edit_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("大虾，非专业人士，导入发布模块即可！\n当前登录模式 [" + site.LoginType.ToString() + "] 您确定编辑？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            save();

            X_Form_AddSitePostEdit post = new X_Form_AddSitePostEdit(site);
            if (post.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                site = post.site;
            }

            Loaded();
            EchoHelper.Echo("编辑模块结束,又回到了该站点基本设置", "编辑模块", EchoHelper.EchoType.任务信息);

        }

        private void Btn_TestLogin_Click(object sender, EventArgs e) {
            save();
            X_Form_Users user = new X_Form_Users(site);
            if (user.ShowDialog() == DialogResult.OK) {
                EchoHelper.Show("此过程小慢，勿动，请稍后。。。", EchoHelper.MessageType.提示);

                Thread th = new Thread(new ParameterizedThreadStart(Test_Login));
                th.IsBackground = true;
                th.Start(user.SelectIds);
            }

        }

        private void TabC_AddSite_SelectedIndexChanged(object sender, EventArgs e) {
            toolStrip导入模块.Visible = false;
            toolStrip导出模块.Visible = false;
            switch (TabC_AddSite.SelectedIndex) {
                case 0: {
                        TabC_AddSite.Size = new Size(TabC_AddSite.Size.Width, groupBox1.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + TabC_AddSite.Size.Height + 30 + 22);
                        break;
                    }
                case 1: {
                        toolStrip导入模块.Visible = true;
                        toolStrip导出模块.Visible = true;
                        TabC_AddSite.Size = new Size(TabC_AddSite.Size.Width, groupBox5.Size.Height + groupbox6.Size.Height + groupBox2.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + TabC_AddSite.Size.Height + 30 + 22);
                        break;
                    }
                case 2: {
                        TabC_AddSite.Size = new Size(TabC_AddSite.Size.Width, groupBox3.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + TabC_AddSite.Size.Height + 30 + 22);
                        LoadListUsers();
                        break;
                    }
            }
        }




        private void 导入_Click(object sender, EventArgs e) {
            try {
                Open_File.Filter = "忍者X2模拟发布引擎模板(*.rzmb)|*.rzmb";
                Open_File.FileName = "*.rzmb";
                if (this.Open_File.ShowDialog() == DialogResult.OK) {
                    string SafeFileName = Open_File.FileName.Substring(Open_File.FileName.LastIndexOf(@"\") + 1);//获取选中的文件名 
                    File.Copy(this.Open_File.FileName, Application.StartupPath + "\\Module\\" + SafeFileName, true);
                    cbModuleBind();
                    EchoHelper.Echo("导入模板成功！请从下拉列表中选择发布模块...", "导入模板", EchoHelper.EchoType.任务信息);
                    EchoHelper.Show("导入模板成功！请从下拉列表中选择发布模块...", EchoHelper.MessageType.提示);
                }
            } catch (Exception ex) {
                EchoHelper.Echo("导入模块失败：" + ex.Message, "导入模块", EchoHelper.EchoType.异常信息);
            }
        }

        private void 导出_Click(object sender, EventArgs e) {
            Save_File.Filter = "忍者X2模拟发布引擎模板(*.rzmb)|*.rzmb";
            Save_File.FileName = site.SiteModuleName.Contains("0o0o请选择发布模块0o0o") ? "" : site.SiteModuleName;
            if (Save_File.ShowDialog() == DialogResult.OK) {
                DbTools db = new DbTools();

                string SafeFileName = Save_File.FileName.Substring(Save_File.FileName.LastIndexOf(@"\") + 1);//获取选中的文件名 
                db.Save(Application.StartupPath + "\\Module\\" + SafeFileName, "WCNM", site);
                db.Save(Save_File.FileName, "WCNM", site);
                cbModuleBind();
                cbModule.Text = site.SiteModuleName = SafeFileName;
                EchoHelper.Echo("导出模板成功！文件保存位置" + Save_File.FileName, "导出模板", EchoHelper.EchoType.任务信息);
                EchoHelper.Show("导出模板成功！", EchoHelper.MessageType.提示);
                save();
            }
        }

        private void Cms_账户管理_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            if (ListUsers.SelectedItems.Count == 0) {
                编辑当前账户ToolStripMenuItem.Enabled = false;
                测试登陆.Enabled = false;
                删除当前账户ToolStripMenuItem.Enabled = false;
                TS_内置浏览器登录.Enabled = false;
            } else if (ListUsers.SelectedItems.Count == 1) {
                编辑当前账户ToolStripMenuItem.Enabled = true;
                测试登陆.Enabled = true;
                删除当前账户ToolStripMenuItem.Enabled = true;
                TS_内置浏览器登录.Enabled = true;
            } else {
                编辑当前账户ToolStripMenuItem.Enabled = false;
                测试登陆.Enabled = true;
                删除当前账户ToolStripMenuItem.Enabled = false;
                TS_内置浏览器登录.Enabled = false;
            }
            if (site.LoginType == LoginType.马甲登陆模式) {
                TS_内置浏览器注册.Enabled = false;
                TS_内置浏览器登录.Enabled = false;
            }
        }

        private void 编辑当前账户ToolStripMenuItem_Click(object sender, EventArgs e) {
            int id = int.Parse(ListUsers.SelectedItems[0].Text);
            ModelUsers user = new ModelUsers();
            user = site.modelUsers[FindIndexByUserid(id)];
            X_Form_AddSiteUser siteuser = new X_Form_AddSiteUser(user, site.LoginMVerifyUrl.Replace("[后台地址]", site.SiteBackUrl));
            if (siteuser.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                this.site.modelUsers[FindIndexByUserid(id)] = (siteuser.user);
            }
            LoadListUsers();//重新加载...
        }

        private void 删除当前账户ToolStripMenuItem_Click(object sender, EventArgs e) {
            int id = int.Parse(ListUsers.SelectedItems[0].Text);
            if (KryptonMessageBox.Show(string.Format("您确定要删除账户[{0}]吗？删除后您将不能使用该账户发布信息！", ListUsers.SelectedItems[0].SubItems[1].Text), "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                RemoveUserByid(id);
                LoadListUsers();//重新加载...
            }

        }

        private void ListUsers_DoubleClick(object sender, EventArgs e) {
            if (ListUsers.SelectedItems.Count == 1) {
                int id = int.Parse(ListUsers.SelectedItems[0].Text);
                ModelUsers user = new ModelUsers();
                user = site.modelUsers[FindIndexByUserid(id)];
                X_Form_AddSiteUser siteuser = new X_Form_AddSiteUser(user, site.LoginMVerifyUrl.Replace("[后台地址]", site.SiteBackUrl));
                if (siteuser.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    this.site.modelUsers[FindIndexByUserid(id)] = (siteuser.user);
                }
                LoadListUsers();//重新加载...
            }
        }

        private void TS_内置浏览器登录_Click(object sender, EventArgs e) {
            ModelUsers user = new ModelUsers();
            int id = int.Parse(ListUsers.SelectedItems[0].Text);
            user = SelectUserByid(id);

            //X_Form_Browser brw = new X_Form_Browser();
            //brw.url = site.SiteDomain;
            //brw.Show();
        }

        private void TS_手动注册账户_Click(object sender, EventArgs e) {
            //ModelUsers user = new ModelUsers();
            //user.Id = site.LastUsersId;
            //X_Form_Browser brw = new X_Form_Browser();
            //brw.url = site.SiteDomain;
            //if(brw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
            //    site.modelUsers.Add(user);
            //    LoadListUsers();
            //}

        }

        private void 导入账户ToolStripMenuItem_Click(object sender, EventArgs e) {
            object obj = null;
            Open_File.Filter = "忍者X2用户库(*.rzu)|*.rzu";
            Open_File.FileName = "*.rzu";
            if (this.Open_File.ShowDialog() == DialogResult.OK) {
                DbTools db = new DbTools();
                obj = db.Read(this.Open_File.FileName, "WCNM");
                //成功导入的用户数
                int succNum = 0;
                if (obj != null) {
                    IList<ModelUsers> users = (IList<ModelUsers>)obj;
                    for (int i = 0; i < users.Count; i++) {
                        bool has = false;
                        foreach (ModelUsers item in site.modelUsers) {
                            if (item.Uname == users[i].Uname) {
                                has = true;
                            }
                        }
                        if (!has) {
                            users[i].Id = site.LastUsersId;
                            site.modelUsers.Add(users[i]);
                            succNum++;
                        }
                    }
                    LoadListUsers();
                    EchoHelper.Echo("导入用户库成功" + succNum + "个用户。", "导入用户库", EchoHelper.EchoType.任务信息);
                    EchoHelper.Show("导入用户库成功" + succNum + "个用户。", EchoHelper.MessageType.提示);
                } else {
                    EchoHelper.Echo("导入用户库失败！", "导入用户库", EchoHelper.EchoType.任务信息);
                    EchoHelper.Show("导入用户库失败！", EchoHelper.MessageType.提示);
                }
            }

        }

        private void 导出账户ToolStripMenuItem_Click(object sender, EventArgs e) {
            Save_File.Filter = "忍者X2用户库(*.rzu)|*.rzu";
            if (Save_File.ShowDialog() == DialogResult.OK) {
                DbTools db = new DbTools();
                db.Save(Save_File.FileName, "WCNM", site.modelUsers);
                EchoHelper.Echo("导出用户库成功！文件保存位置" + Save_File.FileName, "导出用户库", EchoHelper.EchoType.任务信息);
                EchoHelper.Show("导出用户库成功！", EchoHelper.MessageType.提示);
            }

        }

        private void 测试登陆_Click(object sender, EventArgs e) {
            try {
                for (int i = 0; i < ListUsers.SelectedItems.Count; i++) {
                    int id = int.Parse(ListUsers.SelectedItems[i].Text);
                    Thread th = new Thread(new ParameterizedThreadStart(Test_Login));
                    th.IsBackground = true;
                    th.Start(id);
                }
            } catch {
            }
        }

        private void Btn_测试发布_Click(object sender, EventArgs e) {
            int UserId = 0;
            X_Form_Users user = new X_Form_Users(site);
            if (user.ShowDialog() == DialogResult.OK) {
                UserId = GetLogin_ID(user.SelectIds);
                if (site.CategoriesIsEnablad) {
                    X_Form_Cate cate = new X_Form_Cate(site, UserId);
                    if (cate.ShowDialog() == DialogResult.OK) {
                        EchoHelper.Show("此过程小慢，勿动，请稍后。。。", EchoHelper.MessageType.提示);
                        site = cate.SiteInfo;
                    } else {
                        return;
                    }
                    cate.Dispose();
                    cate.Close();
                }
                Thread th = new Thread(new ParameterizedThreadStart(Test_Post));
                th.IsBackground = true;
                th.Start(UserId);
            }
            user.Close();
        }
        /// <summary>
        /// 保存账户配置到,账户列表的控件里.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("确认账户信息配置正确?", "注意", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) {
                TS_保存_Click(sender, e);
            }
        }

        #endregion

        #region 方法
        #region 保存加载当前的信息
        /// <summary>
        /// 保存当前的信息
        /// </summary>
        private void save() {
            site.SiteName = Site_Name.Text;
            site.SiteDomain = Site_Domain.Text;
            site.SiteBackUrl = txtBackUrl.Text;
            site.SiteMainKeys = txtMainKeys.Text;
            site.LoginType = btn自动登录.Checked ? LoginType.自动登陆模式 : LoginType.马甲登陆模式;
            site.SiteIsUtf8 = ckIsUtf8.Checked;
            site.SiteModuleName = cbModule.Text.Contains("0o0o请选择发布模块0o0o") ? "" : cbModule.Text;
            site.IsInternetLink = btnISInterLink.Checked;
            site.IsEN = btnISEN.Checked;
            try {
                site.LinkRate = Convert.ToDouble(tbarLinkRate.Value) * 0.01 / 2;
            } catch {
                site.LinkRate = 0.3 / 2;
            }

            site.SiteLinkType = btnLinkType2.Checked ? Linktype.正文随机插入 : Linktype.正文随机插入;
            site.SiteLinkType = btnLinkType1.Checked ? Linktype.头部声明 : Linktype.正文随机插入;
            site.SiteLinkType = btnLinkType3.Checked ? Linktype.尾部追加 : Linktype.正文随机插入;

        }
        /// <summary>
        /// 加载
        /// </summary>
        private void Loaded() {
            Site_Name.Text = site.SiteName;
            Site_Domain.Text = site.SiteDomain;
            txtBackUrl.Text = site.SiteBackUrl;
            Lable_MoShi.Text = site.LoginType.ToString();
            txtMainKeys.Text = site.SiteMainKeys;
            ckIsUtf8.Checked = site.SiteIsUtf8;
            if (site.LoginIsUtf8 != site.PostIsUtf8) {
                ckIsUtf8.Enabled = false;
            }

            if (site.LoginType == LoginType.自动登陆模式) {
                btn自动登录.Checked = true;
            } else {
                btnCookies登录.Checked = true;
            }
            cbModuleBind();
            cbModule.Text = site.SiteModuleName;
            linkLabelModelHelper.Enabled = !string.IsNullOrEmpty(site.ModelUrl);

            btnISInterLink.Checked = site.IsInternetLink;
            if (!btnISInterLink.Checked) {
                btnISInterLink.Text = "链轮已关闭";
                btnLinkType1.Enabled = btnLinkType2.Enabled = btnLinkType3.Enabled = tbarLinkRate.Enabled = false;
            } else {
                btnISInterLink.Text = "链轮已开启";
                btnLinkType1.Enabled = btnLinkType2.Enabled = btnLinkType3.Enabled = tbarLinkRate.Enabled = true;

                btnLinkType2.Checked = site.SiteLinkType == Linktype.正文随机插入;
                btnLinkType1.Checked = site.SiteLinkType == Linktype.头部声明;
                btnLinkType3.Checked = site.SiteLinkType == Linktype.尾部追加;

                try {
                    tbarLinkRate.Value = (int)(site.LinkRate * 200);
                } catch (Exception ex) {
                    EchoHelper.EchoException(ex);
                }
            }

            btnISEN.Checked = site.IsEN;
            btnISCN.Checked = !btnISEN.Checked;
        }

        #endregion

        #region 导入加载模块
        /// <summary>
        /// 导入加载模块
        /// </summary>
        /// <param name="_si"></param>
        private void Loaded(ModelSite _si) {
            //开始之前对这个site，进行初始化，放弃模块本身的一些信息，最后赋值到我们的site中。
            _si.SiteName = Site_Name.Text;
            _si.SiteID = this.site.SiteID;
            _si.GroupID = this.site.GroupID;
            _si.modelUsers = this.site.modelUsers;
            _si.SiteModuleName = this.site.SiteModuleName;
            _si.SiteBackUrl = txtBackUrl.Text;
            _si.SiteDomain = Site_Domain.Text;
            _si.SiteMainKeys = txtMainKeys.Text;
            this.site = _si;
        }
        #endregion

        #region 根据id查找对应用户，返回User
        /// <summary>
        /// 根据id查找对应用户，返回User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private ModelUsers SelectUserByid(int id) {
            ModelUsers user = new ModelUsers();
            for (int i = 0; i < site.modelUsers.Count; i++) {
                if (site.modelUsers[i].Id == id) {
                    user = site.modelUsers[i];
                }
            }
            return user;
        }
        #endregion

        #region 根据Id号码查找序列
        /// <summary>
        /// 根据Id号码查找序列
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int FindIndexByUserid(int id) {
            for (int i = 0; i < site.modelUsers.Count; i++) {
                if (site.modelUsers[i].Id == id) {
                    return i;
                }
            }
            return 0;
        }
        #endregion

        #region 根据ID删除用户
        /// <summary>
        /// 根据ID删除用户
        /// </summary>
        /// <param name="id"></param>
        private void RemoveUserByid(int id) {
            for (int i = 0; i < site.modelUsers.Count; i++) {
                if (site.modelUsers[i].Id == id) {
                    site.modelUsers.RemoveAt(i);
                }
            }
        }
        #endregion

        #region 加载用户名列表
        /// <summary>
        /// 加载用户名列表
        /// </summary>
        private void LoadListUsers() {
            ListUsers.Items.Clear();
            foreach (ModelUsers user in site.modelUsers) {
                if (site.LoginType == LoginType.马甲登陆模式) {
                    if (user.LoginMethod == LoginMethod.Cookie登陆) {
                        ListViewItem item = new ListViewItem(user.Id.ToString());
                        switch (user.LoginState) {
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
                        //item.s
                        ListUsers.Items.Add(item);
                    }
                } else if (site.LoginType == LoginType.自动登陆模式) {
                    if (user.LoginMethod == LoginMethod.用户名登陆) {
                        ListViewItem item = new ListViewItem(user.Id.ToString());
                        switch (user.LoginState) {
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
            groupBox3.Text = string.Format("账户信息列表：模式：{1}(当前共有{0}个账户)", ListUsers.Items.Count, site.LoginType);
        }
        #endregion

        #region 随机获取id
        /// <summary>
        /// 随即获取id
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int GetLogin_ID(string str) {
            string[] arr = str.Split(',');
            Random r = new Random();
            return int.Parse(arr[r.Next(0, arr.Length - 1)]);
        }
        #endregion

        #region 测试登陆
        /// <summary>
        /// 测试登陆
        /// </summary>
        /// <param name="userID">测试用户的ID</param>
        private void Test_Login(object id) {
            try {
                int userID = Convert.ToInt32(id);
                JobCoreTest test = new JobCoreTest(site, FindModelUserByID(site, userID));
                test.Login();
                LoadListUsers();
            } catch {
            }
        }
        #endregion

        #region 测试发布
        /// <summary>
        /// 测试发布
        /// </summary>
        /// <param name="id">测试用户的ID</param>
        private void Test_Post(object id) {
            int userID = (int)id;
            JobCoreTest test = new JobCoreTest(site, FindModelUserByID(site, userID));
            string html = test.Post();
        }
        #endregion


        /// <summary>
        /// 绑定列表
        /// </summary>
        private void cbModuleBind() {
            string path = Application.StartupPath + "\\Module\\";
            IList<FileInfo> files = FilesHelper.ReadDirectoryList(path, ".rzmb");
            cbModule.DataSource = files;
            cbModule.DisplayMember = "Name";
            cbModule.ValueMember = "FullName";
        }

        private void cbModule_SelectionChangeCommitted(object sender, EventArgs e) {
            wait.ShowMsg("正在导入忍者发布模块...");
            string path = cbModule.SelectedItem.ToString();
            DbTools db = new DbTools();
            object obj = db.Read(path, "WCNM");
            if (obj != null) {
                ModelSite si = (ModelSite)obj;
                Loaded(si);
                site.SiteModuleName = cbModule.Text;
                Loaded();
                Thread.Sleep(200);
                wait.ShowMsg("恭喜您，导入忍者发布模块成功！");
                Thread.Sleep(200);
                EchoHelper.Echo("导入发布模块成功！", "导入模板", EchoHelper.EchoType.任务信息);
            } else {
                Loaded(new ModelSite());
                site.SiteModuleName = cbModule.Text;
                Loaded();
                EchoHelper.Echo("导入发布模块失败！", "导入模板", EchoHelper.EchoType.任务信息);
                EchoHelper.Show("导入发布模块失败！", EchoHelper.MessageType.提示);
            }
            wait.CloseMsg();
        }
        #endregion

        private void btn_模式切换_MouseClick(object sender, MouseEventArgs e) {
            save();
            Loaded();
        }

        private void Site_Name_TextChanged(object sender, EventArgs e) {
            Site_Name.Text = StringHelper.NoChar(Site_Name.Text);
        }

        private void GositeUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            X_Form_MainFormBrowser bw = new X_Form_Main().getBrowser();
            bw.Show();
            bw.GotoPage(Site_Domain.Text);
            //ProcessHelper.openUrl(Site_Domain.Text);
        }

        private void Site_Domain_Leave(object sender, EventArgs e) {
        }

        private void ckInterLink_CheckedChanged(object sender, EventArgs e) {
            Site_Domain_Leave(sender, e);
            if (btnISInterLink.Checked == true) {
                tbarLinkRate.Enabled = true;
                wait.ShowMsg("请稍等，验证站点中...");
                if (string.IsNullOrEmpty(site.PostSuccessPage)) {
                    TabC_AddSite.SelectedIndex = 1;
                    EchoHelper.ShowBalloon("不允许加入链轮", "您的模块中，无法获取成功url，请更新模块!", cbModule);
                    btnISInterLink.Checked = false;
                }
            } else {
                tbarLinkRate.Enabled = false;
            }
            wait.CloseMsg();
        }

        private void btnBackUrl_Click(object sender, EventArgs e) {
            txtBackUrl.Text = string.Empty;
        }

        private void btnInterLink_Click(object sender, EventArgs e) {
            save();
            if (btnISInterLink.Checked && !string.IsNullOrEmpty(site.PostSuccessPage) && SeoHelper.isWWW(site.SiteBackUrl)) {
                btnISInterLink.Text = "链轮已开启";
                btnISInterLink.Checked = true;
                tbarLinkRate.Value = 50;
                btnLinkType1.Enabled = btnLinkType2.Enabled = btnLinkType3.Enabled = tbarLinkRate.Enabled = true;
            } else if (btnISInterLink.Checked) {
#if !DEBUG
                TabC_AddSite.SelectedIndex = 1;
                if (!SeoHelper.isWWW(site.SiteBackUrl)) {
                    EchoHelper.ShowBalloon("非主域名禁止加入", "为了维护链轮库的质量，共同提高排名，非主域名暂时不可加入！", txtBackUrl);
                } else {
                    EchoHelper.ShowBalloon("站点不支持链轮", "您的模块中，无法获取成功url，请重新编写发布模块！", cbModule);
                }
                btnISInterLink.Checked = false;
                btnISInterLink.Text = "链轮已关闭";
                tbarLinkRate.Value = 0;
                btnLinkType1.Enabled = btnLinkType2.Enabled = btnLinkType3.Enabled = tbarLinkRate.Enabled = false;
#endif
            }


        }

        private void btnGetMainkeys_Click(object sender, EventArgs e) {
            if (Site_Domain.Text != "http://") {
                btnGetMainkeys.Enabled = false;
                wait.ShowMsg("关键词自动加载中。。。请稍后。。。");
                txtMainKeys.Text = FetchContent.GetKeywords(Site_Domain.Text);
                wait.CloseMsg();
                btnGetMainkeys.Enabled = true;
            } else {
                EchoHelper.ShowBalloon("域名提示", "请输入正确的域名。", Site_Domain);
            }

        }

        private void lbPostModuleDown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            int tmpx = this.Location.X;
            this.Location = new System.Drawing.Point(tmpx - tmpx / 2, this.Location.Y);
            Point p = new Point(tmpx - tmpx / 2 + this.Width, this.Location.Y);
            this.Enabled = false;

            X_Form_ModuleShop shop = new X_Form_ModuleShop(p);
            DialogResult dr = shop.ShowDialog();

            if (dr == DialogResult.Cancel || dr == DialogResult.OK) {
                this.Location = new System.Drawing.Point(tmpx, this.Location.Y);
                this.Enabled = true;
                cbModuleBind();
                cbModule.Text = site.SiteModuleName;
            }

        }




        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ProcessHelper.openUrl(site.ModelUrl);
        }

        private void ckIsUtf8_MouseClick(object sender, MouseEventArgs e) {
            save();
        }


    }

}
