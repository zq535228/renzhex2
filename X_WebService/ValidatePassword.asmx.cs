using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using X_Service.Web;
using X_Service.Login;
using X_Service.Util;
using System.Text;
using X_Service.Db;
using System.Data;

namespace X_WebService {
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://webservice.renzhe.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ValidatePassword : System.Web.Services.WebService {

        //声明Soap头实例
        public MySoapHeader myHeader = new MySoapHeader();

        /// <summary>
        /// hahahah
        /// </summary>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string HelloWord() {
            //可以通过存储在数据库中的用户与密码来验证
            ModelMember mem = new ModelMember();
            if(mem.IS_X_PostKing) {
                return "IS_X_PostKing！";
            }
            if(mem.IS_X_WordPressBuild) {
                return "IS_X_WordPressBuild";
            } else {
                return "对不起，您没有权限调用此服务！";
            }
        }

        //md5（md5（password）+salt）的方式直接获取密码
        protected ModelMember getUser(string username, string password) {
            ModelMember mem = new ModelMember();

            DataTable dt = DbMysql.GetDataTable("select salt from bbs_ucenter_members where username='" + username + "' ");
            string salt = dt.Rows[0].ToString();
            string md5pwd = StringHelper.CreateMd5(StringHelper.CreateMd5(password, 32) + salt, 32);
            DataTable gourp = DbMysql.GetDataTable("select uid, groupid,groupexpiry,credits from bbs_common_member where username='" + username + "' and password='" + password + "' ");

            try {
                mem.netname = username;
                mem.netpass = password;

                string uid = gourp.Rows[0][0].ToString();

                if(gourp.Rows[0][1].ToString() == "20") {
                    mem.group = "商业授权用户";
                    mem.expire = gourp.Rows[0][2].ToString();
                    mem.sitenum = 9999;
                    mem.userMoney = 9999;
                } else {
                    // select * from bbs_common_member_count
                    mem.group = "普通用户";
                    //mem.expire = gourp.Rows[0][1].ToString();
                    mem.sitenum = 9999;
                    mem.userMoney = 9999;
                }



            } catch(Exception) {

                throw;
            }

            return new ModelMember();
        }






        protected string EchoHelperEcho(string message) {

            return message;

        }
    }
}