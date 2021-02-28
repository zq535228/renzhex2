using System;
using System.Collections.Generic;
using System.Text;
using X_Model;
using System.Data;
using X_Service.Util;
using X_Service.Db;
using X_Service.Web;
using System.Net;

namespace X_PostKing.Job {

    /// <summary>
    /// 链轮的操作类
    /// </summary>
    public class JobLianlun {

        public void SendLink(ModelLinkCycle mlink) {
            CookieCollection cookies = new CookieCollection();
            //本地程序，二级域名程序，自动剔除。
            if (mlink.url.Contains("127.0.0.1") || mlink.url.Contains("localhost") || !mlink.isWWW) {
                return;
            }
            EchoHelper.Echo("上传链接到服务器团队链接库，请稍后...", "上传链轮", EchoHelper.EchoType.任务信息);
            string purl = "http://renzhe.sinaapp.com/index.php/Url/insert";
            string pdata = "url=" + mlink.url + "&title=" + mlink.title + "&keyword=" + mlink.keyword + "&ip=" + mlink.ip;
            string html = new xkHttp().httpPost(purl, pdata, ref cookies, "", Encoding.UTF8);
            if (html.Contains("添加数据成功")) {
                EchoHelper.Echo("上传链接到服务器成功：" + mlink.url, "上传链轮", EchoHelper.EchoType.任务信息);
            } else {
                EchoHelper.Echo("上传链接到服务器失败：" + mlink.url, "上传链轮", EchoHelper.EchoType.任务信息);
            }
        }

        public ModelLinkCycle GetRandLink(string ip) {
            CookieCollection cookies = new CookieCollection();
            ModelLinkCycle newlink = new ModelLinkCycle();
            try {
                EchoHelper.Echo("正在从服务器团队链接库中随机获取一条链接，请稍后...", "链轮获取", EchoHelper.EchoType.普通信息);
                string gurl = "http://renzhe.sinaapp.com/index.php?m=Url&a=findone&nip=" + ip;
                string html = new xkHttp().httpGET(gurl, ref cookies);
                html = html.Split('\r')[0];
                if (!html.Contains("||||")) {
                    newlink.id = Convert.ToInt32(html.Split('|')[0]);
                    newlink.url = html.Split('|')[1];
                    newlink.title = html.Split('|')[2];
                    newlink.keyword = html.Split('|')[3];
                    newlink.ip = html.Split('|')[4];
                    EchoHelper.Echo("获取链接成功：" + newlink.url, "链轮获取", EchoHelper.EchoType.任务信息);
                    EchoHelper.Echo("系统将要标注此链接已被链：" + newlink.url, "链轮标注", EchoHelper.EchoType.普通信息);
                    gurl = "http://renzhe.sinaapp.com/index.php?m=Url&a=setover&id=" + newlink.id;
                    new xkHttp().httpGET(gurl, ref cookies);
                    EchoHelper.Echo("链接已经被标注成功：" + newlink.url, "链轮标注", EchoHelper.EchoType.任务信息);
                } else {
                    EchoHelper.Echo("未找到合适的链接。" + newlink.url, "链轮获取", EchoHelper.EchoType.普通信息);
                }
            } catch {
            }

            return newlink;
        }


    }
}
