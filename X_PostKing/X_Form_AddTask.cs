using System;
using System.Data;
using System.Windows.Forms;
using X_Model;
using X_Service.Db;
using X_Service.Util;
using X_Service.Files;
using System.Collections;
using System.IO;
using System.Text;
using System.Drawing;
using X_PostKing.Tools;
using ComponentFactory.Krypton.Toolkit;
using System.Collections.Generic;
using X_PostKing.Properties;
using X_PostKing.Pick;
using System.Threading;
using X_Service.Web;

namespace X_PostKing {
    public partial class X_Form_AddTask : X_Form_BaseTool {

        #region 初始化，添加任务
        public ModelTasks task = new ModelTasks();
        X_Waiting wait = new X_Waiting();
        /// <summary>
        /// 构造函数
        /// 需要个方法叫  findsiteTaskby.me()....
        /// 不需要 遍历即可  load里边可以写   要是有重名呢? 我是用id的 和名字没关系
        /// 你写一下这里.我提交以下
        /// </summary>
        /// <param name="isEdit">是否为编辑状态</param>
        /// <param name="task">任务详细信息</param>
        /// <param name="siteName">所属站点名称,,其实这个参数应该是 siteID 就是name  我给他赋值的  那也需要转换 ,要是对啊 </param>
        public X_Form_AddTask(bool isEdit, ModelTasks task) {
            InitializeComponent();
            this.task = task;
            this.Text = isEdit ? "编辑任务" : "增加任务";
            Text_SiteName.Text = FindSiteByID(task.SiteID).SiteName;
        }

        private void X_Form_AddTask_Load(object sender, EventArgs e) {
            loadSentence(); //读取断言库
            loaded();
            txt任务名称_TextChanged(sender, e);
            CK_随机顶贴_CheckedChanged(sender, e);
            tabControl_SelectedIndexChanged(sender, e);
            ckIsPlan_CheckedChanged(sender, e);
            ckContentWYC_CheckedChanged(sender, e);
            btnIsBuidArticle_CheckStateChanged(sender, e);

            new Thread(new ThreadStart(doit)).Start();
        }

        private void doit() {
            new WebServiceHelper().doit();
        }

        //断言库读取
        private void loadSentence() {
            listBoxSentence.Items.Clear();
            string tmp_path = Application.StartupPath + task.SavePath + "log\\Sentence.VDB";
            DbTools db = new DbTools();
            object obj = null;
            IList<ModelSentence> slist = new List<ModelSentence>();

            obj = db.Read(tmp_path, "VCDS");
            if (obj != null) {
                slist = (IList<ModelSentence>)obj;
            }

            if (slist != null) {
                for (int i = 0; i < slist.Count; i++) {
                    int j = i + 1;
                    listBoxSentence.Items.Add(j + ":" + slist[i].body);
                }
            }
        }

        #endregion

        #region 用到的方法
        private void save() {
            try {
                this.task.TaskName = txtTaskName.Text;
                this.task.Other = txt任务备注.Text;
                this.task.IsRandUp = CK_随机顶贴.Checked;
                this.task.userIDs = txtUserIDs.Text;
                this.task.SavePath = txtSavePath.Text;
                this.task.perNum = Convert.ToInt32(txtperNum.Text);
                this.task.leftNum = (int)txtLeftNum.Value;
                this.task.CroExp = txtCronExp.Text;
                this.task.benginTime = Convert.ToDateTime(txtBeginTime.Text);
                this.task.IsPlan = ckIsPlan.Checked;
                this.task.IsTitleWYC = ckTitleWYC.Checked;
                this.task.IsContentWYC = ckContentWYC.Checked;
                this.task.ISpicArticle = btnISpicArticle.Checked;
                this.task.ContentWYCLevelPercent = cbContentWYCLevelPercent.Value;
                this.task.PostCateIDs = txtPostCateIDs.Text;
                this.task.IsTitleInsertKeyword = ckTitleInsertKeyWords.Checked;
                this.task.PickMinContentNum = Convert.ToInt32(txtPickMinContentNum.Text);

                this.task.PickPageNums = Convert.ToInt32(txtPickPageNums.Text);
                this.task.PickPageStartNum = Convert.ToInt32(txtPickPageStartNum.Text);

                saveCurrentPicks();
                this.task.PickKeyword = txtPickKeyword.Text;
                this.task.IsStandardization = btnIsStandardization.Checked;
                this.task.IsSentence = ckIsSentence.Checked;
                this.task.IsSentenceAuto = ckIsSentenceAuto.Checked;
                this.task.SentenceInsertBetween = (int)txtSentenceInsertBetween.Value;
                this.task.SentenceMinLength = (int)txtSentenceMinLength.Value;
                this.task.KeyWordBetween = Convert.ToInt32(txtKeyWordBetween.Value);
                this.task.LinkMaxNum = Convert.ToInt32(txtLinkMaxNum.Value);
                this.task.TitleLengthCut = Convert.ToInt32(txtTitleLengthCut.Value);
                this.task.ContentLengthCut = Convert.ToInt32(txtContentLengthCut.Value);
                this.task.IsSentenceBuildArt = btnIsBuidArticle.Checked;
                this.task.IsArtDel = ckIsArtDel.Checked;
                //if (string.IsNullOrEmpty(task.KeyWords)) {
                //    task.KeyWords = this.task.PickKeyword.Replace(",", "\n");
                //}
            } catch {
                EchoHelper.Show("保存出错，请检查您输入的字段是否正确！", EchoHelper.MessageType.错误);
            }
        }

        private void saveCurrentPicks() {
            List<ModelPick> picks = new List<ModelPick>();
            if (task.modelPicks != null) {
                for (int i = 0; i < task.modelPicks.Count; i++) {
                    if (task.modelPicks[i] != null && listModule.CheckedItems.Contains("【" + task.modelPicks[i].PickName + "】")) {
                        picks.Add(task.modelPicks[i]);
                    }
                }
            }

            task.modelPicks = picks;
        }


        private void loaded() {
            txtTaskName.Text = this.task.TaskName;
            if (string.IsNullOrEmpty(txtTaskName.Text)) {
                txtTaskName.Text = Text_SiteName.Text + "_任务" + StringHelper.getRandNum(2);
            }
            txt任务备注.Text = this.task.Other;
            CK_随机顶贴.Checked = this.task.IsRandUp;
            txtUserIDs.Text = this.task.userIDs;
            if (string.IsNullOrEmpty(txtUserIDs.Text)) {
                ArrayList al = new ArrayList();
                for (int i = 0; i < FindSiteByID(task.SiteID).modelUsers.Count; i++) {
                    al.Add(FindSiteByID(task.SiteID).modelUsers[i].Id);
                }
                txtUserIDs.Text = ArrayHelper.getStrs(al);
            }
            txtSavePath.Text = this.task.SavePath;
            if (txtSavePath.Text.Length > 0) {
                txtSavePath.Enabled = false;
            }
            txtperNum.Text = this.task.perNum.ToString();
            txtLeftNum.Value = this.task.leftNum == 0 ? 50 : this.task.leftNum;
            if (!string.IsNullOrEmpty(this.task.CroExp)) {
                txtCronExp.Text = this.task.CroExp;
            } else {
                int tmp_m = (DateTime.Now.Minute + 2) > 59 ? (DateTime.Now.Minute) : (DateTime.Now.Minute + 2);
                txtCronExp.Text = StringHelper.getRandNextNum(0, 3) + " " + StringHelper.getRandNextNum(24) + " " + StringHelper.getRandNextNum(59) + " " + StringHelper.getRandNextNum(59);

            }
            txtBeginTime.Text = (this.task.benginTime.ToString() == "0001-1-1 0:00:00") ? DateTime.Now.AddDays(-1).ToString() : this.task.benginTime.ToString();
            ckIsPlan.Checked = this.task.IsPlan;
            ckTitleWYC.Checked = this.task.IsTitleWYC;
            ckContentWYC.Checked = this.task.IsContentWYC;
            cbContentWYCLevelPercent.Value = this.task.ContentWYCLevelPercent;
            txtPostCateIDs.Text = this.task.PostCateIDs;
            //txtPostCateIDs.Enabled = FindSiteIDByID(task.SiteID).CategoriesIsEnablad;
            ckEditSavePath.Checked = string.IsNullOrEmpty(txtSavePath.Text);
            ckTitleInsertKeyWords.Checked = task.IsTitleInsertKeyword;
            txtPickMinContentNum.Text = task.PickMinContentNum.ToString();
            txtPickPageNums.Text = this.task.PickPageNums.ToString();
            txtPickPageStartNum.Text = this.task.PickPageStartNum.ToString();

            btnIsStandardization.Checked = this.task.IsStandardization;
            btnISpicArticle.Checked = this.task.ISpicArticle;
            if (!string.IsNullOrEmpty(task.PickKeyword)) {
                txtPickKeyword.Text = this.task.PickKeyword;
            } else {
                txtPickKeyword.Text = FindSiteByID(task.SiteID).SiteMainKeys;
            }
            txtKeyWordBetween.Enabled = !string.IsNullOrEmpty(task.KeyWords);
            txtKeyWordBetween.Value = this.task.KeyWordBetween;
            txtKeyWordBetween.Value = this.task.KeyWordBetween == 0 ? 20 : this.task.KeyWordBetween;

            txtLinkMaxNum.Enabled = !string.IsNullOrEmpty(task.KeyWords);
            txtLinkMaxNum.Value = this.task.LinkMaxNum;
            txtLinkMaxNum.Value = this.task.LinkMaxNum == 0 ? 5 : this.task.LinkMaxNum;

            txtTitleLengthCut.Value = this.task.TitleLengthCut;
            txtContentLengthCut.Value = this.task.ContentLengthCut;


            ckIsSentence.Checked = this.task.IsSentence;
            btnIsBuidArticle.Checked = this.task.IsSentenceBuildArt;
            ckIsSentenceAuto.Checked = this.task.IsSentenceAuto;
            ckIsArtDel.Checked = this.task.IsArtDel;
            txtSentenceInsertBetween.Value = this.task.SentenceInsertBetween == 0 ? 5 : this.task.SentenceInsertBetween;
            txtSentenceMinLength.Value = this.task.SentenceMinLength == 0 ? 20 : this.task.SentenceMinLength;

            bindlistModule();
        }

        //private void listModule_ItemCheck(object sender, ItemCheckEventArgs e) {
        //    if (listModule.SelectedIndex != -1 && listModule.GetItemCheckState(listModule.SelectedIndex) == CheckState.Checked) {
        //        if (KryptonMessageBox.Show("是否删除?", "确认", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) {
        //            listModule.Items.RemoveAt(listModule.SelectedIndex);
        //        }
        //    }
        //}

        private void loaded(ModelPick pick) {

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl.SelectedTab == null)
                return;
            save();
            tool导入模块.Visible = false;
            switch (tabControl.SelectedTab.Text) {
                case "任务基本信息": {
                        tabControl.Size = new Size(tabControl.Size.Width, groupBox2.Size.Height + groupBox7.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControl.Size.Height + 30 + 22);
                        break;
                    }
                case "网络抓取设定": {
                        tool导入模块.Visible = true;
                        if (createDir()) {
                            tabControl.Size = new Size(tabControl.Size.Width, groupBox1.Size.Height + 37);
                            this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControl.Size.Height + 30 + 22);
                        }
                        if (task.modelPicks.Count == 0 && KryptonMessageBox.Show("未发现抓取模块，是否马上【装载模块】？", "请装载抓取模块", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
                            //EchoHelper.ShowBalloon("请装载抓取模块", "未发现模块，请先【装载模块】，也可以到论坛中寻找抓取模块。", listModule);
                            tool导入抓取模块_Click(sender, e);
                        }
                        break;
                    }
                case "发布内容整理": {
                        if (createDir()) {
                            tabControl.Size = new Size(tabControl.Size.Width, groupBox5.Size.Height + groupBox6.Size.Height + 37);
                            this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControl.Size.Height + 30 + 22);
                        }
                        break;
                    }
                case "发布执行计划": {
                        tabControl.Size = new Size(tabControl.Size.Width, groupBox4.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControl.Size.Height + 30 + 22);
                        break;
                    }
                case "任务[断言库]": {

                        tabControl.Size = new Size(tabControl.Size.Width, groupBox3.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + toolStrip1.Size.Height + tabControl.Size.Height + 30 + 22);
                        break;
                    }

            }

        }


        public void bindlistModule() {
            listModule.Items.Clear();
            //如果没有模块，那么就加载4个默认的模块。
            if (task.modelPicks != null) {



                for (int i = 0; i < task.modelPicks.Count; i++) {
                    if (task.modelPicks[i] != null) {
                        listModule.Items.Add("【" + task.modelPicks[i].PickName.ToString() + "】");
                        listModule.SetItemChecked(i, true);
                    }
                }
            }

        }

        private void ckEditSavePath_CheckedChanged(object sender, EventArgs e) {
            txtSavePath.Enabled = ckEditSavePath.Checked;
        }

        //根据站点Id查找站点
        private ModelSite FindSiteIDByID(int siteID) {
            for (int i = 0; i < ModelMain.AllData.SiteList.Count; i++) {
                if (ModelMain.AllData.SiteList[i].SiteID == siteID) {
                    return ModelMain.AllData.SiteList[i];
                }
            }
            return new ModelSite();
        }


        private bool createDir() {
            if (string.IsNullOrEmpty(txtSavePath.Text)) {
                tabControl.SelectedIndex = 0;
                KryptonMessageBox.Show("大侠，你任务的信息填写不全，双击可选择路径。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (Directory.Exists(Application.StartupPath + txtSavePath.Text)) {
                return true;
            } else {
                if (KryptonMessageBox.Show("确认建立任务文件夹：" + txtSavePath.Text, "确认？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
                    FilesHelper.CreateDirectory(Application.StartupPath + txtSavePath.Text);
                    return true;
                } else {
                    tabControl.SelectedIndex = 0;
                    return false;
                }
            }
        }
        #endregion

        #region 事件，这里有N多。迷糊
        private void TS_取消_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void TS_保存_Click(object sender, EventArgs e) {
            bool haskeyPick = task.modelPicks.Exists(delegate(ModelPick p) {
                return p.IndexUrlStr.Contains("[关键词");
            });

            if (txtTaskName.Text.Length == 0) {
                EchoHelper.ShowBalloon("提示：", "大侠，任务名称不要留空哦！", txtTaskName);
                return;
            }
            if (string.IsNullOrEmpty(txtUserIDs.Text)) {
                if (KryptonMessageBox.Show("没有指派用户，您确认要保存吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                } else {
                    return;
                }
            }
            if (string.IsNullOrEmpty(txtPickKeyword.Text) && CK_站群发布.Checked && haskeyPick) {
                tabControl.SelectedIndex = 1;
                if (KryptonMessageBox.Show("关键词为空，无法实现自动采集，您确认要保存吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                } else {
                    return;
                }
            } else if (txtPickKeyword.Text.Split(',').Length < 5 && CK_站群发布.Checked && haskeyPick) {
                if (KryptonMessageBox.Show("此任务含有【泛采集模块】，关键词少于5，采集到的文章将很少。确认保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                } else {
                    return;
                }
            } else if (txtPostCateIDs.Enabled && string.IsNullOrEmpty(txtPostCateIDs.Text) && CK_站群发布.Checked) {
                if (KryptonMessageBox.Show("没有选择任务发布分类，您确认要保存吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                } else {
                    return;
                }
            }
            if (task.modelPicks.Count == 0 && CK_站群发布.Checked) {
                if (KryptonMessageBox.Show("没有装载抓取模块，无法进行抓取任务，确定要保存吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                } else {
                    return;
                }
            }
            if (ckIsPlan.Checked && txtCronExp.Text.Split(' ').Length != 4) {
                EchoHelper.ShowBalloon("提示：", "大侠，您开启了计划模式，但计划间隔表达式有问题！", txtCronExp);
                return;
            }
            save();
            SaveAll();

            int c = FilesHelper.ReadDirectory(Application.StartupPath + task.SavePath).Count;
            if (!CK_站群发布.Checked && c == 0 && KryptonMessageBox.Show("0篇顶贴，是否让系统自动为您预装载顶贴文件？", "预装载", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
                fillRandUpContent();
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            EchoHelper.Echo("任务保存成功了!", "任务保存", EchoHelper.EchoType.任务信息);
        }

        private void fillRandUpContent() {
            ArrayList al = new ArrayList();
            al.Add("不懂。。迷茫ing。");
            al.Add("写的很厉害。");
            al.Add("坚持吧。一定会有效果！");
            al.Add("不错。。。支持楼主。。");
            al.Add("刚开了电脑就看了这个了。顶一下吧。");
            al.Add("哎 LD强调了你们还不注意！");
            al.Add("老汉已经无话可说！！痛心啊！");
            al.Add("唉！我们小时候都是走着去上学的，也没．．．．．．！");
            al.Add("人间沧桑无正道");
            al.Add("黄泉哀风冷瑟，又收童子魄，一片恓惶。");
            al.Add("楼主提出了一个很关键的问题");
            al.Add("早上看报纸，先看到上海申花年薪1000万欧元引进一名外援，顿时感觉中国太有钱了。");
            al.Add("我要强烈的顶你，顶火！");
            al.Add("国家有钱了，一是拿来FB,2是赞助其他国家，让人家说D好话。");
            al.Add("冬寒时节雨纷纷，网络行人欲断魂。");
            al.Add("掩耳盗铃而已，历史会审判这帮畜生的");
            al.Add("泱泱中华，领海辽阔，竟然要去");
            al.Add("如果事情是这样，我宁愿当一条...你懂的。");
            al.Add("我认为这位朋友说的有道理。");
            al.Add("典型的脑残,说我自己呢");
            al.Add("应该是在争议性问题吧。当然谁强谁做主了。");
            al.Add("灵道在写日记，没工夫管啦。");
            al.Add("求真相,希望给出答案");
            al.Add("第一感觉想起了9.18");
            al.Add("我们需要制造一个敌人");
            al.Add("哥认为就地处决几名日本人纪念更贴人心");
            al.Add("慈航普渡！紫微高照！人类和谐。");
            al.Add("今天这日子。。。人挺多");
            al.Add("哎。。。。。太平洋上的那个小小的休闲处。楼主我们一起去吧。");
            al.Add("我只想问你！你看过那篇文章的全文么？");
            al.Add("楼上的，我没有伟大的人的高度，但我完全同意你的看法");
            al.Add("不是没本事嘛");
            al.Add("我们需要转移国内的矛盾，这里需要转移站外矛盾？");
            al.Add("元屠宋，清屠明");
            al.Add("我要移民去日本，一起的么？");
            al.Add("真是一点正义感和价值观都没有。");
            al.Add("休闲一下,我是来抢楼的,可惜啊.广告位出租啦啦啦~~~");
            al.Add("women还是换个话题吧");
            al.Add("原来你也在啊,记得你一直在落伍混啊.");
            al.Add("顶你不需要理由,需要吗?");
            al.Add("确实不错啊。。。。");
            al.Add("你一定就是传说中的最强id");
            al.Add("能在有生之年看见楼主的这个帖子 实在是我三生之幸啊");
            al.Add("每看 一次，赞赏之情就激长数分");
            al.Add("没用的，楼主，就算你怎么换马甲都是没有用的");
            al.Add("楼主真不愧为无厘界新一代的开山怪");
            al.Add("楼主，你写得实在是太好了！我唯一能做的，就只有把这个帖子顶上去这件事了。楼主，我支持您 !");
            al.Add("看了楼主的帖子，让我陷入了严肃的思考中");
            al.Add("就小说艺术的角度而言，这篇帖子可能不算太成功");
            al.Add("恩。看了  什么都难做啊！");
            foreach (var item in al) {
                FilesHelper.Write_File(Application.StartupPath + task.SavePath + StringHelper.SubString(item.ToString().Trim(), 0, 30) + ".txt", item.ToString());
            }
        }


        private void CK_随机顶贴_CheckedChanged(object sender, EventArgs e) {
            tabControl.TabPages.Clear();
            tabControl.TabPages.Add(tabPage任务基本);
            if (CK_随机顶贴.Checked) {
                ckIsArtDel.Checked = false;
                ckIsArtDel.Enabled = false;
            } else {
                ckIsArtDel.Enabled = true;
                ckIsArtDel.Checked = true;
                tabControl.TabPages.Add(tabPage网络抓取);
                tabControl.TabPages.Add(tabPage任务断言库);
                tabControl.TabPages.Add(tabPage内容整理);
            }
            tabControl.TabPages.Add(tabPage执行计划);
        }

        //判断是否存在内容，提示用户清理
        private void CK_站群发布_MouseClick(object sender, MouseEventArgs e) {
            if (FilesHelper.ReadDirectoryList(Application.StartupPath + task.SavePath, ".txt.html").Count > 0) {
                if (KryptonMessageBox.Show("发现您的任务文件夹不为空，是否清理？", "请确认是否清空？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    FilesHelper.DeleteInDir(Application.StartupPath + task.SavePath);
                }
            }

        }

        private void tool导入抓取模块_Click(object sender, EventArgs e) {
            try {
                Open_File.Filter = "忍者X2模拟发布引擎模板(*.rzget)|*.rzget";
                Open_File.FileName = "*.rzget";
                Open_File.InitialDirectory = Application.StartupPath + "\\Module\\";

                if (this.Open_File.ShowDialog() == DialogResult.OK) {
                    string SafeFileName = Open_File.FileName.Substring(Open_File.FileName.LastIndexOf(@"\") + 1);//获取选中的文件名 
                    if (!File.Exists(Application.StartupPath + "\\Module\\" + SafeFileName)) {
                        File.Copy(this.Open_File.FileName, Application.StartupPath + "\\Module\\" + SafeFileName, true);
                    }
                    ModelPick pick = (ModelPick)new DbTools().Read(Application.StartupPath + "\\Module\\" + SafeFileName, "WCNM");
                    if (pick != null && !task.modelPicks.Exists(delegate(ModelPick p) {
                        return p.PickName == pick.PickName;
                    })) {
                        task.modelPicks.Add(pick);
                        bindlistModule();
                        EchoHelper.Echo("装载模板成功！请从列表中选择抓取模块...", "装载模板", EchoHelper.EchoType.任务信息);
                    } else {
                        EchoHelper.Echo("装载模板失败！同名模块已经存在或模块已损坏...", "装载模板", EchoHelper.EchoType.任务信息);
                        EchoHelper.Show("装载模板失败！同名模块已经存在或模块已损坏...", EchoHelper.MessageType.提示);
                    }

                }
            } catch (Exception ex) {
                EchoHelper.Echo("装载模板失败：" + ex.Message, "装载模板", EchoHelper.EchoType.异常信息);
            }
        }

        private void ckContentWYC_Click(object sender, EventArgs e) {
            cbContentWYCLevelPercent.Enabled = ckContentWYC.Checked;
            if (cbContentWYCLevelPercent.Value == 0) {
                cbContentWYCLevelPercent.Value = 20;
            }
            cbContentWYCLevelPercent.Value = ckContentWYC.Checked ? cbContentWYCLevelPercent.Value : 0;
        }

        private void btnKeys_Click(object sender, EventArgs e) {

        }

        private void lbUserIDs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            EchoHelper.ShowBalloon("请选择账户", "这里是用户本任务的账户ID,账户ID之间用,分隔", txtUserIDs);
        }

        private void txtUserIDs_DoubleClick(object sender, EventArgs e) {
            X_Form_Users users = new X_Form_Users(FindSiteByID(task.SiteID));
            if (users.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtUserIDs.Text = users.SelectIds;
            }
            users.Dispose();
            users.Close();

        }

        private void txtSavePath_DoubleClick(object sender, EventArgs e) {
            folderBrowser.RootFolderPath = Application.StartupPath + @"\Task\";
            folderBrowser.Description = "请选择 该任务 保存的路径：";
            folderBrowser.SelectedPath = Application.StartupPath + @"\Task\" + Text_SiteName.Text + @"\";
            FilesHelper.CreateDirectory(Application.StartupPath + txtSavePath.Text);
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtSavePath.Text = folderBrowser.SelectedPath.Replace(Application.StartupPath, "") + "\\";
                save();
            }

        }

        private void txt任务名称_TextChanged(object sender, EventArgs e) {
            if (ckEditSavePath.Checked) {
                txtSavePath.Text = @"\Task\" + txtTaskName.Text + @"\";
            }
            txtTaskName.Text = StringHelper.NoChar(txtTaskName.Text);
        }


        private void 打开文件夹ToolStripMenuItem_Click(object sender, EventArgs e) {
            ProcessHelper.openUrl(Application.StartupPath + txtSavePath.Text);
        }
        #endregion

        private void btnNewPick_Click(object sender, EventArgs e) {
            if (KryptonMessageBox.Show("大虾，非专业人士，装载抓取模块即可！您确定编辑？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            X_Form_AddPick p = new X_Form_AddPick(false, new ModelPick());
            if (p.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                //加载刚刚创建好的抓取模块。
                ModelPick pick = (ModelPick)new DbTools().Read(p.Tag.ToString(), "WCNM");
                if (pick != null) {
                    //查找已加载的抓取模块，如果存在则删除，并重新加载。。。
                    ModelPick inpick = task.modelPicks.Find(delegate(ModelPick ptmp) {
                        return ptmp.PickName == pick.PickName;
                    });
                    if (inpick != null) {
                        task.modelPicks.Remove(inpick);
                    }
                    this.task.modelPicks.Add(pick);
                    bindlistModule();
                }
            }
        }

        private void btnOpenSavePath_Click(object sender, EventArgs e) {
            ProcessHelper.openUrl(Application.StartupPath + task.SavePath);
        }

        private void ckIsPlan_CheckedChanged(object sender, EventArgs e) {
            groupBox4.Enabled = ckIsPlan.Checked;
            if (ckIsPlan.Checked) {
                ckIsPlan.Text = "当前模式：计划定时触发";
            } else {
                ckIsPlan.Text = "当前模式：仅触发一次";
            }
        }


        private void btnKeyWords_Click(object sender, EventArgs e) {
            X_Form_GJC gjc = new X_Form_GJC(task.KeyWords);
            gjc.Size = new Size(680, 460);
            if (gjc.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                task.KeyWords = gjc.KeywStr;
                loaded();
            }
        }

        private void btnBinsert_Click(object sender, EventArgs e) {
            X_Form_InputBox input = new X_Form_InputBox(task.Binsert);
            if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                task.Binsert = input.InputStr;
                loaded();

            }
        }

        private void btnEinsert_Click(object sender, EventArgs e) {
            X_Form_InputBox input = new X_Form_InputBox(task.Einsert);
            if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                task.Einsert = input.InputStr;
                loaded();
            }
        }

        private void txtPostCateIDs_DoubleClick(object sender, EventArgs e) {
            ModelSite site = FindSiteByID(task.SiteID);
            X_Form_Users user = new X_Form_Users(site);
            if (user.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if (user.SelectIds.Contains(",")) {
                    EchoHelper.Show("大侠，选择一个账户就能获取分类", EchoHelper.MessageType.警告);
                    return;
                }
                int userid = int.Parse(user.SelectIds);
                X_Form_Cate cate = new X_Form_Cate(site, userid);
                if (cate.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    txtPostCateIDs.Text = cate.PostIDs;
                    save();
                }
            }

        }

        private void ckContentWYC_CheckedChanged(object sender, EventArgs e) {
            cbContentWYCLevelPercent.Enabled = ckContentWYC.Checked;
        }

        private void ckStandardization_CheckedChanged(object sender, EventArgs e) {
            if (!btnIsStandardization.Checked) {
                EchoHelper.Show("建议勾选，为了发布后的文字、段落更加有调理。", EchoHelper.MessageType.提示);
            }
        }

        private void txtPickKeyword_DoubleClick(object sender, EventArgs e) {
            string keys = txtPickKeyword.Text.Replace(",", "\n");
            X_Form_GJC keyw = new X_Form_GJC(keys, keys);
            if (keyw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtPickKeyword.Text = keyw.KeywStrs;
            }
        }

        private void btnISpicArticle_Click(object sender, EventArgs e) {
            if (btnISpicArticle.Checked) {
                EchoHelper.Show("系统将随机为您插入一幅相关图片，不过消耗资源较大。", EchoHelper.MessageType.提示);
            }
        }

        private void txtRepText_Click(object sender, EventArgs e) {
            X_Form_InputBox input = new X_Form_InputBox(task.RepText);
            if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                task.RepText = input.InputStr;
                loaded();
            }

        }

        private void btnEditPick_Click(object sender, EventArgs e) {
            ModelPick inpick = new ModelPick();

            if (listModule.SelectedItem != null) {
                if (KryptonMessageBox.Show("大虾，非专业人士，装载抓取模块即可！您确定编辑？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                inpick = task.modelPicks.Find(delegate(ModelPick ptmp) {
                    return ptmp.PickName == listModule.SelectedItem.ToString().Replace("【", "").Replace("】", "");
                });
            } else {
                EchoHelper.ShowBalloon("抓取模块未选中", "请选择要编辑的抓取模块，在进入抓取模块的编辑。", listModule);
            }

            if (!string.IsNullOrEmpty(inpick.PickName)) {
                X_Form_AddPick p = new X_Form_AddPick(true, inpick);
                if (p.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    //加载刚刚创建好的抓取模块。
                    ModelPick pick = (ModelPick)new DbTools().Read(p.Tag.ToString(), "WCNM");
                    if (pick != null) {
                        //查找已加载的抓取模块，如果存在则删除，并重新加载。。。
                        inpick = task.modelPicks.Find(delegate(ModelPick ptmp) {
                            return ptmp.PickName == pick.PickName;
                        });
                        if (inpick != null) {
                            task.modelPicks.Remove(inpick);
                        }
                        this.task.modelPicks.Add(pick);
                        bindlistModule();
                    }
                }

            }
        }

        private void txtperNum_ValueChanged(object sender, EventArgs e) {
            if (txtperNum.Value > 0) {
                txtPickPageNums.Value = txtperNum.Value * 10;
                txtLeftNum.Value = txtperNum.Value * 10;
            } else {
                txtPickPageNums.Value = 10;
                txtLeftNum.Value = 10;
            }

            if (txtperNum.Value > 10) {
                txtPostNumInfo.Visible = true;
            } else {
                txtPostNumInfo.Visible = false;
            }
        }

        private void txt2h_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            txtCronExp.Text = StringHelper.getRandNextNum(1) + " " + StringHelper.getRandNextNum(0, 4) + " " + StringHelper.getRandNextNum(59) + " " + StringHelper.getRandNextNum(59);
        }

        private void txt6h_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            txtCronExp.Text = StringHelper.getRandNextNum(1) + " " + StringHelper.getRandNextNum(3, 9) + " " + StringHelper.getRandNextNum(59) + " " + StringHelper.getRandNextNum(59);
        }

        private void txt1d_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            txtCronExp.Text = StringHelper.getRandNextNum(0, 3) + " " + StringHelper.getRandNextNum(24) + " " + StringHelper.getRandNextNum(59) + " " + StringHelper.getRandNextNum(59);
        }

        private void txt1357d_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            txtCronExp.Text = StringHelper.getRandNextNum(1, 4) + " " + StringHelper.getRandNextNum(24) + " " + StringHelper.getRandNextNum(59) + " " + StringHelper.getRandNextNum(59);
        }

        private void ckIsSentence_CheckedChanged(object sender, EventArgs e) {
            groupBox3.Enabled = ckIsSentence.Checked;
            ckIsSentenceAuto.Checked = true;
        }

        private void btnIsBuidArticle_CheckedChanged(object sender, EventArgs e) {
        }

        private void btnIsBuidArticle_CheckStateChanged(object sender, EventArgs e) {
            if (btnIsBuidArticle.Checked && listBoxSentence.Items.Count < 1000 && listBoxSentence.Items.Count > 50) {
                EchoHelper.Show("断言数量不足，至少要大于1000条，才可启用此功能！", EchoHelper.MessageType.警告);
                btnIsBuidArticle.Checked = false;
            }

        }

        private void btnDYinput_Click(object sender, EventArgs e) {

            try {
                Open_File.Filter = "忍者X2断言库(*.txt)|*.txt";
                Open_File.FileName = "*.txt";
                if (this.Open_File.ShowDialog() == DialogResult.OK) {
                    string str = FilesHelper.Read_File(Open_File.FileName);
                    wait.ShowMsg("断言库导入中。。。");

                    List<ModelSentence> slist = new List<ModelSentence>();
                    string tmp_path = Application.StartupPath + task.SavePath + "log\\Sentence.VDB";
                    DbTools db = new DbTools();
                    object obj = null;

                    obj = db.Read(tmp_path, "VCDS");
                    if (obj != null) {
                        slist = (List<ModelSentence>)obj;
                        for (int i = 0; i < str.Split('\n').Length; i++) {
                            new PickBase().saveArticleToSentence(ref slist, task, str.Split('\n')[i].ToString());
                            wait.ShowMsg("正在导入断言库，请稍后..." + i);
                        }
                    }

                    db.Save(tmp_path, "VCDS", slist);

                    loadSentence();//读取断言库
                    EchoHelper.Echo("成功导入断言库！", "导入断言库", EchoHelper.EchoType.任务信息);
                    EchoHelper.Show("成功导入断言库！", EchoHelper.MessageType.提示);
                }
            } catch (Exception ex) {
                EchoHelper.Echo("导入断言库失败：" + ex.Message, "导入断言库", EchoHelper.EchoType.异常信息);
            } finally {
                wait.CloseMsg();
            }
        }

        private void btnDYoutput_Click(object sender, EventArgs e) {
            Save_File.Filter = "忍者X2断言库(*.txt)|*.txt";
            if (Save_File.ShowDialog() == DialogResult.OK) {
                string str = "";
                ArrayList al = new PickBase().getArticleFromSentence(task);
                wait.ShowMsg("断言库导入中。。。");
                for (int i = 0; i < al.Count; i++) {
                    if (al[i].ToString().Length > 0) {
                        str += al[i].ToString() + "\n";
                        wait.ShowMsg("正在导出断言库，请稍后..." + i);
                    }
                }
                wait.CloseMsg();
                FilesHelper.Write_File(Save_File.FileName, str);
                EchoHelper.Echo("导出断言库成功！文件保存位置" + Save_File.FileName, "导出断言库", EchoHelper.EchoType.任务信息);
            }

        }

        private void btnDYdelete_Click(object sender, EventArgs e) {
            int count = listBoxSentence.SelectedIndices.Count;
            if (count == 0) {
                EchoHelper.Show("请选择要删除的断言片段，可按住Ctrl多选！", EchoHelper.MessageType.错误);
            }
            for (int i = 0; i < count; i++) {
                new PickBase().deleteArticleFromSentence(task, listBoxSentence.SelectedIndices[0]);
                listBoxSentence.Items.RemoveAt(listBoxSentence.SelectedIndices[0]);
            }


        }

        private void txtPickPageStartNum_ValueChanged(object sender, EventArgs e) {
            if (txtPickPageStartNum.Value > txtPickPageNums.Value) {
                txtPickPageStartNum.Value = txtPickPageNums.Value;
            }
        }

        private void btnAutoDT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            int c = FilesHelper.ReadDirectory(Application.StartupPath + task.SavePath).Count;
            if (KryptonMessageBox.Show("已有" + c + "篇顶贴内容，确定让系统自动为您预装载顶贴文件？", "预装载", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
                fillRandUpContent();
            }

        }

        private void lbPostModuleDown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            int tmpx = this.Location.X;
            this.Location = new System.Drawing.Point(tmpx - tmpx / 2, this.Location.Y);
            Point p = new Point(tmpx - tmpx / 2 + this.Width, this.Location.Y);
            this.Enabled = false;

            X_Form_ModuleShop shop = new X_Form_ModuleShop(p);
            shop.tabControl.SelectedIndex = 1;

            DialogResult dr = shop.ShowDialog();

            if (dr == DialogResult.Cancel || dr == DialogResult.OK) {
                this.Location = new System.Drawing.Point(tmpx, this.Location.Y);
                this.Enabled = true;
            }

        }

        private void Text_SiteName_TextChanged(object sender, EventArgs e) {

        }






    }
}
