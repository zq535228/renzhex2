using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Util;
using X_Service.Login;
using X_Service.Util;
using X_Service.Web;
using X_Service.Files;
using System.Drawing;

namespace X_PostKing {
    public partial class X_Form_News : DockContent {

        private Thread th;

        public X_Form_News() {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            //#if !DEBUG
            EchoHelper.Echo("加载微文，建议收听Qin哦...", "官方微博", EchoHelper.EchoType.任务信息);
            th = new Thread(new ThreadStart(loadWebBrowser));
            th.IsBackground = true;
            th.Start();
            //#endif

        }

        /// <summary>
        /// 这里可以显示一些官方网站的最新帖子等内容。
        /// </summary>
        private void loadWebBrowser() {

            CookieCollection cookies = new CookieCollection();
            string htmlget = new xkHttp().httpGET("http://t.qq.com/zq535228/mine", ref cookies);

            NodeFilter filter = new HasAttributeFilter("class", "msgCnt");
            NodeList htmlNodes = new Parser(new Lexer(htmlget)).Parse(filter);

            weblist.Items.Clear();

            for (int i = 0; i < htmlNodes.Count; i++) {
                string itemad = string.Format("<a  target=\"_blank\" href='http://t.qq.com/zq535228/mine'>{0}</a>", htmlNodes[i].ToPlainTextString());
                //html += 
                weblist.Items.Add(new ListViewItem(htmlNodes[i].ToPlainTextString()));
                if (i > 20) {
                    break;
                }
            }

            if (Login_Base.member.sitenum < 10 && StringHelper.getRandNextNum(3) == 0) {
                //X_Form_Invite x = new X_Form_Invite();
                //x.ShowDialog();
            }

            string bak_path = Application.StartupPath + "\\Temp\\" + DateTime.Now.ToLongDateString() + "\\";
            if (FilesHelper.ReadDirectory(bak_path).Count == 0) {
                new X_Form_Main().Zip(bak_path + "bak_config.zip", Application.StartupPath + @"\Config\");
                EchoHelper.Echo("备份数据配置文件成功！" + "\\Temp\\" + DateTime.Now.ToLongDateString() + "\\bak_config.zip", "系统", EchoHelper.EchoType.任务信息);

            }
        }

        private void weblist_MouseDoubleClick(object sender, MouseEventArgs e) {
            ProcessHelper.openUrl("http://t.qq.com/zq535228?preview");
        }



    }
}
