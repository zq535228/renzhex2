using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using X_Model;
using X_PostKing.Job;
using X_Service.Util;

namespace X_PostKing {
    public partial class X_Form_Cate : X_Form_Base {

        protected X_Waiting wait = new X_Waiting();

        public ModelSite SiteInfo = new ModelSite();
        public int userID = 0;

        public X_Form_Cate(ModelSite si) {
            InitializeComponent();
            SiteInfo = si;
        }

        public X_Form_Cate(ModelSite si, int userID) {
            InitializeComponent();
            this.SiteInfo = si;
            this.userID = userID;
        }


        private void X_Form_Categories_Load(object sender, EventArgs e) {
            wait.ShowMsg("小慢，请稍等一下！");
            Loaded();
            wait.CloseMsg();

        }

        private void Loaded() {
            try {
                Btn_Get.Enabled = false;
                Btn_Save.Enabled = false;
                List.Items.Clear();
                JobCoreTest test = new JobCoreTest(SiteInfo, FindModelUserByID(SiteInfo, userID));
                if (FindModelUserByID(SiteInfo, userID).LoginState!= LoginState.已登录) {
                    test.Login();
                }
                string html = test.GetCategoryHtml();
                Regex r = new Regex(SiteInfo.CategoriesRegex, RegexOptions.Multiline);
                MatchCollection m = r.Matches(html);
                foreach (Match math in m) {
                    ListViewItem item = new ListViewItem(math.Groups["typeid"].Value);
                    item.SubItems.Add(math.Groups["typename"].Value);
                    List.Items.Add(item);
                }
                Btn_Get.Enabled = true;
                Btn_Save.Enabled = true;
            } catch {
                Btn_Get.Enabled = true;
                Btn_Save.Enabled = true;
            }

        }

        private void Btn_Get_Click(object sender, EventArgs e) {
            Loaded();
        }

        /// <summary>
        /// 分类string集合 1,2，5,6,7的形式
        /// </summary>
        public string PostIDs = string.Empty;

        private void Btn_Save_Click(object sender, EventArgs e) {
            SiteInfo.PostID = String.Empty;
            if (List.SelectedItems.Count != 0) {
                for (int i = 0;i < List.SelectedItems.Count;i++) {
                    PostIDs += List.SelectedItems[i].Text + ",";
                }
                if (!string.IsNullOrEmpty(PostIDs)) {
                    PostIDs = PostIDs.Substring(0, PostIDs.Length - 1);
                }
                SiteInfo.PostID = PostIDs;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            } else {
                for (int i = 0; i < List.Items.Count; i++) {
                    PostIDs += List.Items[i].Text + ",";
                }
                if (!string.IsNullOrEmpty(PostIDs)) {
                    PostIDs = PostIDs.Substring(0, PostIDs.Length - 1);
                }
                SiteInfo.PostID = PostIDs;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
