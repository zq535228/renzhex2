using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using X_Service.Login;
using X_Service.Web;
using X_Service.Db;
using X_Service.Util;

namespace X_WebShop {
    /// <summary>
    /// UserValidate 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://serv.renzhe.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class UserValidate : System.Web.Services.WebService {

        /// <summary>
        /// 关键的用户字段需要加密处理
        /// </summary>
        /// <param name="member"></param>
        /// <returns>返回经过sKey加密后的密文</returns>
        [WebMethod(Description = "验证用户，返回加密的用户包String。内有IS_X_PostKing的字段代表是否成功登陆；strMessage字段代表失败原因。")]
        public string Validate(ModelMember member) {
            DbTools db = new DbTools();

            bool reSuccess = ValidateUser(ref member);

            //如果服务器端验证成功，那么加入到服务器的在线列表中。在isOnLine方法中返回true
            //同时T掉跟他一样的用户名的在线用户。
            if (reSuccess) {
                RemoveFromOnlineList(member.netname);
                OnlineList.AllData.MmList.Add(member);
            }

            //加密准备返回。

            string restr = db.ClasstoString(member, "VCDS");
            restr = MD5Helper.MD5Encrypt(restr, member.sKey);

            return restr;
        }

        /// <summary>
        /// 客户端通过这个方法，自动检测，如果返回false那么则自动关闭，说明被T下线了。
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [WebMethod(Description = "判断是否在线，2-3分钟就执行一次，然后客户端自动下线。")]
        public bool isOnLine(string netname) {
            int count = OnlineList.AllData.MmList.FindAll(delegate(ModelMember t) {
                return t.netname == netname;
            }).Count;
            return count > 0;
        }

        private bool ValidateUser(ref ModelMember member) {
            member.IS_X_PostKing = false;

            //验证是否具有发帖权限
            string testpostUrl = "http://www.renzhe.org/forum.php?mod=post&action=newthread&fid=36";

            string html = new xkHttp().httpGET(testpostUrl, ref member.cookies);
            if (html.Contains("发表帖子 - 忍者X2站群 -  忍者软件")) {
                member.strMessage = "恭喜您，权限核对成功，您已被授权使用忍者X2站群！";
                member.IS_X_PostKing = true;
            } else if (html.Contains("抱歉，您需要设置自己的头像后才能进行本操作")) {
                member.strMessage = "请完善您的（基本资料、头像），即在论坛上发个帖子激活一下。授权论坛：www.renzhe.org！";
            } else if (html.Contains("请先绑定手机号码")) {
                member.strMessage = "请先绑定手机号码，授权论坛：www.renzhe.org！";
            } else if (html.Contains("<s>商业授权用户</s>")) {
                member.strMessage = "您的账户已过期，请到论坛充值续费！";
            } else if (html.Contains("超时")) {
                member.strMessage = "链接服务超时！";
            } else if (html.Contains("没有权限在该版块发帖")) {
                member.strMessage = "用户登录验证失败，请重新登录！";
            } else if (html.Contains("无法解析此远程名称")) {
                member.strMessage = "域名解析出现问题，请检查您的网络设置！";
            } else {
                member.strMessage = "验证失败，原因未知！";
            }

            if (member.group.Contains("商业授权用户")) {
                member.IS_X_WordPressBuild = true;
            } else {
                member.IS_X_WordPressBuild = false;
            }
            return member.IS_X_PostKing;
        }

        private void SaveAll() {
            DbTools db = new DbTools();
            string tmp_path = Server.MapPath("~/pub_files/") + "OnlineList.VDB";
            if (OnlineList.AllData.MmList.Count > 0) {
                db.Save(tmp_path, "VCDS", OnlineList.AllData);
            }
        }

        private void RemoveFromOnlineList(string netname) {
            ModelMember mm = OnlineList.AllData.MmList.Find(delegate(ModelMember t) {
                return t.netname == netname;
            });

            if (mm != null) {
                OnlineList.AllData.MmList.Remove(mm);
            }
        }

    }
}
