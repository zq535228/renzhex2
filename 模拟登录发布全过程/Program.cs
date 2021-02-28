using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 模拟登录发布全过程 {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 腾讯微博());
        }
    }
}
