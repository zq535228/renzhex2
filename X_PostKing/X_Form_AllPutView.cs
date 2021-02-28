using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using X_Service.Util.SplashScreen;
using X_Service.Util;
using X_Model;
using X_Service.Db;
using System.Collections;

namespace X_PostKing {
    public partial class X_Form_AllPutView : DockContent {

        private X_ListView lvwColumnSorter;
        private List<ModelAllPut> puts = new List<ModelAllPut>();
        string tmp_path = Application.StartupPath + "\\Config\\AllPuts.VDB";
        DbTools db = new DbTools();

        public X_Form_AllPutView() {
            InitializeComponent();

        }

        private void X_Form_AllPutView_Load(object sender, EventArgs e) {
            listViewHeight(ListViewAllPut, 20);
            lvwColumnSorter = new X_ListView();
            this.ListViewAllPut.ListViewItemSorter = lvwColumnSorter;
            loadlistview();
        }



        #region listViewHeight( ListView lv , int height ){} 方法是用来撑大listview空间的行高度的。传入控件本身，还有高度。
        protected void listViewHeight(ListView lv, int height) {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);//分别是宽和高
            lv.SmallImageList = imgList;   //这里设置listView的SmallImageList ,用imgList将其撑大
        }

        #endregion

        public void Add(ModelAllPut put) {
            object obj = db.Read(tmp_path, "VCDS");
            if (obj != null) {
                puts = (List<ModelAllPut>)obj;

            }

            put.idtime = DateTime.Now.ToString();
            puts.Insert(0, put);
            db.Save(tmp_path, "VCDS", puts);
        }

        private void List_Pack_ColumnClick(object sender, ColumnClickEventArgs e) {
            // 检查点击的列是不是现在的排序列.
            if (e.Column == lvwColumnSorter.SortColumn) {
                // 重新设置此列的排序方法.
                if (lvwColumnSorter.Order == SortOrder.Ascending) {
                    lvwColumnSorter.Order = SortOrder.Descending;
                } else {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            } else {
                // 设置排序列，默认为正向排序
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // 用新的排序方法对ListView排序
            this.ListViewAllPut.Sort();
        }

        private void timerRefresh_Tick(object sender, EventArgs e) {
            loadlistview();
        }

        private void loadlistview() {
            this.ListViewAllPut.Items.Clear();
            object obj = db.Read(tmp_path, "VCDS");
            if (obj != null) {
                puts = (List<ModelAllPut>)obj;
                for (int i = 0; i < puts.Count; i++) {
                    ListViewItem lv = new ListViewItem(puts[i].idtime.ToString());
                    lv.SubItems.Add(puts[i].url);
                    lv.SubItems.Add(puts[i].taskName);
                    lv.SubItems.Add(puts[i].reason);
                    ListViewAllPut.Items.Add(lv);
                    if (i > 100) {
                        break;
                    }
                }
            }
        }

        private void ListViewAllPut_DoubleClick(object sender, EventArgs e) {
            string url = ListViewAllPut.SelectedItems[0].SubItems[1].Text;
            ProcessHelper.openUrl(url);
        }


    }
}
