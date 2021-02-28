using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using X_Service.Util;

namespace X_PostKing {
    public partial class X_Form_Invite : X_Form_BaseTool {
        public X_Form_Invite() {
            InitializeComponent();
        }

        private void X_Form_Invite_Load(object sender, EventArgs e) {
            loadtext();
            this.TopMost = true;
            tabControl_SelectedIndexChanged(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            ProcessHelper.openUrl("http://t.qq.com/zq535228");
        }

        private void loadtext() {
            ArrayList al = new ArrayList();
            al.Add("忍者软件是干啥用的？忍者软件是“站群管理系统”，如果不知道什么是站群，那么简单点说就是他就是一个网络营销的机器，更直接点说，是一个挂机做网站赚钱的营销软件。例如：每个网站月赚50元，挂999个就5万了，真的一点不夸张。忍者站群，永久免费，推荐您也试试。\r\nhttp://www.renzhe.org/forum.php?mod=viewthread&tid=2&x=" + member.UID);
            al.Add("站群我听说过，具体如何操作不太明白，讲一下？我们所说的做站，都是为了赚钱而做的，不是单纯的为了兴趣；所以为了能赚多些钱，就要多多的做站，不过一个人的精力是有限的，所以就是用软件去管理这些网站，这就是我们所说的站群软件管理系统，要是说到具体的操作，涉及的知识还真挺多的，不是一时半会儿能说明白滴，更不能一口吃个胖子，还是建议您慢慢研究一下。\r\nhttp://www.renzhe.org/member.php?mod=register&x=" + member.UID);
            al.Add("我想免费获取[忍者站群X2]，如何操作？忍者客服：注册一个论坛账户、下载后，使用论坛账户密码登陆软件即可。我们的广告写的不是免费试用，而是免费使用，免费升级，永久授权。\r\nhttp://www.renzhe.org/forum.php&x=" + member.UID);
            al.Add("我看到你们网站的排名都不错嘛？忍者客服：SEO是站群的基础，你看看我们的各个关键词的排名就知道了；这里想提醒您一点，Qin作为站群SEO软件的作者，对搜索引擎优化也是有一些独到的见解滴。\r\nhttp://renzhe.org/");
            al.Add("市面上所有的站群软件都是收费的，你的真的是永久免费授权？忍者客服：是的，非常肯定：是永久免费。我的目标不是卖软件，而是让大家学会网络营销、大家赚钱我在收取一点软件使用的费用，这个相信是最能让大家认可的一种方式。\r\nhttp://renzhe.org/");
            al.Add("忍者站群免费跟商业版本的区别是什么？我获得的站点数，会变吗？忍者客服：除了站点数不同，无任何功能区别，免费版可以通过论坛金币换取站点数，发布文章-1金币，为了保持论坛的活跃度，您的金币可以在论坛轻松获取：发帖、回帖、邮件验证等等都给金币哦；商业版9999站点无金币限制。站点数永久不变（但商业授权到期后，会变为原有站点数）\r\nhttp://www.renzhe.org/member.php?mod=register&x=" + member.UID);
            al.Add("给我一个加入商业用户组的理由吧？忍者客服：我们有一个愿景，就是让15%的付费用户组月薪可以超过3W，也是我的目标；如果你打算真正的投资做站群，那么你一定要加入我们。在这里的每一个商业用户都是有决心和诚意做站群的，我们有浓厚的学习和互助氛围。相信你周围的3个人成功了，那么你也许就是第四个。加油。。。\r\nhttp://www.renzhe.org/member.php?mod=register&x=" + member.UID);
            al.Add("我的一个建站新手，可以给我一些帮助吗，没有网络营销的思路&方向，很迷茫。忍者客服：这个问题问的好，说到网络营销的思路，就是靠多做一些网站来赚取广告费，老鸟一天的收入可以是几百到几千，当然也是要有成本投入的，服务器空间+域名+维护。一般来讲都是挂谷歌广告、淘宝客、广告联盟等形式。也可以多多来我们的论坛讨论跟大家交换一下意见。\r\nhttp://www.renzhe.org/member.php?mod=register&x=" + member.UID);
            al.Add("信誉实力证明？忍者客服：万网服务器；51.la的赞助广告；A5首页广告；Qin的微博；网站的ICP备案；此人气论坛。\r\nhttp://www.renzhe.org/member.php?mod=register&x=" + member.UID);
            al.Add("黑豹站群有全自动外链、侠客V3有万能发布，那么忍者X2站群呢？忍者客服：市面上的所有SEO软件我都已经有接触，并研究过他们的功能、从最早的侠客v1、珊瑚虫、黑豹、黑马博客、虫虫博客。这么多SEO软件，真的太多了；我还是建议草根网友选择适合自己的，而不是看宣传出来的功能。说道功能：我们的忍者X2，支持95%的站点发布（我不会吹嘘万能发布）；我们的忍者X2，支持超级云链轮；我们的忍者X2，是按您计划进行发布的；我们的忍者X2，是具有免费版本的。更多惊喜功能，我并没有一一列出，既然是免费给大家用，那么为什么不亲自来体验一下呢？\r\nhttp://www.renzhe.org/member.php?mod=register&x=" + member.UID);

            InviteTxt.Text = ArrayHelper.getRandOneFromArray(al);
            label2.Text = label2.Text.Replace("【站点数】", member.sitenum.ToString());

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ProcessHelper.openUrl("http://www.renzhe.org/forum.php?mod=viewthread&tid=15119&extra=page%3D1");

        }

        private void InviteTxt_DoubleClick(object sender, EventArgs e) {
            loadtext();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e) {
            switch (tabControl.SelectedTab.Text) {
                case "人人为我、我为人人": {
                        tabControl.Size = new Size(tabControl.Size.Width, groupBox1.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + tabControl.Size.Height + 30 + 22);
                        break;
                    }
                case "加入商业授权用户组": {
                        tabControl.Size = new Size(tabControl.Size.Width, groupBox2.Size.Height + 37);
                        this.Size = new Size(this.Size.Width, pictureBox1.Size.Height + tabControl.Size.Height + 30 + 22);
                        break;
                    }

            }
        }
    }
}
