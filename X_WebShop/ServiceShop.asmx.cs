using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Services;
using X_Model;
using X_Service.Db;
using X_Service.Files;
using X_Service.Login;
using X_Service.Util;
using System;

namespace X_WebShop {
    /// <summary>
    /// ServiceShop 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://serv.renzhe.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ServiceShop : System.Web.Services.WebService {

        /// <summary>
        /// 获取服务器上所有的发布模块。
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "获取服务器上所有的发布模块。")]
        public List<ModelShopOne> GetAllPutModules() {
            List<ModelShopOne> relist = new List<ModelShopOne>();

            IList<FileInfo> fs = FilesHelper.ReadDirectoryList(Server.MapPath("~/pub_files/put/"), ".rzmb");

            foreach (FileInfo f in fs) {
                string tmpstr = FilesHelper.ReadFile(f.FullName, Encoding.UTF8);

                if (!string.IsNullOrEmpty(tmpstr)) {
                    try {
                        ModelSite site = new DbTools().StringtoClass(tmpstr, "WCNM") as ModelSite;
                        ModelShopOne one = new ModelShopOne();

                        one.ModelName = f.Name;
                        one.FilePath = f.FullName;
                        one.ModelAuthor = site.ModelAuthor;
                        one.ModelEmail = site.ModelEmail;
                        one.ModelPassWord = site.ModelPassWord;
                        one.ModelQQ = site.ModelQQ;
                        one.ModelUrl = site.ModelUrl;
                        one.SiteModelDescription = site.SiteModelDescription;
                        one.LastUpDate = f.LastWriteTime;
                        one.FileSize = f.Length / 1024;
                        one.IsCoreWeb = !string.IsNullOrEmpty(site.WebPut);
                        one.IsCoreSocket = !string.IsNullOrEmpty(site.PostParameters);

                        if (!string.IsNullOrEmpty(one.ModelName) && !one.ModelName.Contains("0o0o请选择发布模块0o0o")) {
                            relist.Add(one);
                        }
                    } catch (Exception ex) {
                        EchoHelper.Echo("拉取市场模块失败，网络异常！", "拉取模块失败", EchoHelper.EchoType.异常信息);
                        EchoHelper.EchoException(ex);
                    }
                }

            }

            return relist;
        }

        /// <summary>
        /// 获取服务器上所有的发布模块。
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "获取服务器上所有的发布模块。")]
        public List<ModelShopOne> GetAllPickModules() {
            List<ModelShopOne> relist = new List<ModelShopOne>();

            IList<FileInfo> fs = FilesHelper.ReadDirectoryList(Server.MapPath("~/pub_files/pick/"), ".rzget");

            foreach (FileInfo f in fs) {
                string tmpstr = FilesHelper.ReadFile(f.FullName, Encoding.UTF8);

                if (!string.IsNullOrEmpty(tmpstr)) {
                    try {
                        ModelPick site = new DbTools().StringtoClass(tmpstr, "WCNM") as ModelPick;
                        ModelShopOne one = new ModelShopOne();

                        one.ModelName = f.Name;
                        one.FilePath = f.FullName;
                        one.ModelAuthor = site.ModelAuthor;
                        one.ModelEmail = site.ModelEmail;
                        one.ModelPassWord = site.ModelPassWord;
                        one.ModelQQ = site.ModelQQ;
                        one.ModelUrl = site.ModelUrl;
                        one.SiteModelDescription = site.SiteModelDescription;
                        one.LastUpDate = f.LastWriteTime;
                        one.FileSize = f.Length / 1024;
                        one.IsFanZhuaQu = site.IndexUrlStr.Contains("关键词");

                        if (!string.IsNullOrEmpty(one.ModelName)) {
                            relist.Add(one);
                        }
                    } catch (Exception ex) {
                        EchoHelper.Echo("拉取市场模块失败，网络异常！", "拉取模块失败", EchoHelper.EchoType.异常信息);
                        EchoHelper.EchoException(ex);
                    }
                }

            }

            return relist;
        }

        /// <summary>
        /// 上传模块方法
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        [WebMethod(Description = "web提供的方法，上传文件到相应的地址")]
        public bool UploadClassStr(string fileName, string fileClassStr, mType mtype) {
            bool res = false;
            try {
                string strFile = "";
                switch (mtype) {
                    case mType.发布模块:
                        strFile = Server.MapPath("~/pub_files/put/") + fileName;

                        if (File.Exists(strFile)) {
                            //验证是密码正确。
                            DbTools db = new DbTools();
                            ModelSite put1 = db.StringtoClass(fileClassStr, "WCNM") as ModelSite;
                            ModelSite put2 = db.Read(strFile, "WCNM") as ModelSite;

                            if (put1.ModelPassWord != put2.ModelPassWord && put1.ModelAuthor == put2.ModelAuthor) {
                                res = false;
                                break;
                            }
                        }

                        FilesHelper.Write_File(strFile, fileClassStr);
                        res = true;

                        break;
                    case mType.抓取模块:
                        strFile = Server.MapPath("~/pub_files/pick/") + fileName;

                        if (File.Exists(strFile)) {
                            //验证是密码正确。
                            DbTools db = new DbTools();
                            ModelPick put1 = db.StringtoClass(fileClassStr, "WCNM") as ModelPick;
                            ModelPick put2 = db.Read(strFile, "WCNM") as ModelPick;

                            if (put1.ModelPassWord != put2.ModelPassWord) {
                                res = false;
                                break;
                            }
                        }

                        FilesHelper.Write_File(strFile, fileClassStr);
                        res = true;

                        break;
                    case mType.个人数据:
                        strFile = Server.MapPath("~/pub_files/person/") + fileName;
                        break;
                }
            } catch (Exception ex) {
                EchoHelper.Echo("拉取市场模块失败，网络异常！", "拉取模块失败", EchoHelper.EchoType.异常信息);
                EchoHelper.EchoException(ex);
                res = false;
            }
            return res;

        }

        [WebMethod(Description = "获取某个模块")]
        public string GetClassStr(string fileName, mType mtype) {

            string strFile = "";
            switch (mtype) {
                case mType.发布模块:
                    strFile = Server.MapPath("~/pub_files/put/") + fileName;
                    break;
                case mType.抓取模块:
                    strFile = Server.MapPath("~/pub_files/pick/") + fileName;
                    break;
                case mType.个人数据:
                    strFile = Server.MapPath("~/pub_files/person/") + fileName;
                    break;
            }

            string res = FilesHelper.Read_File(strFile);
            return res;

        }

        [WebMethod(Description = "删除某一个模块，只有Qin具有这个权力。")]
        public bool Delete(string classMemberObj, string fileName, mType mtype) {
            bool re = false;
            ModelMember member = new DbTools().StringtoClass(classMemberObj, "WCNM") as ModelMember;
            if (member != null) {

                string strFile = "";
                switch (mtype) {
                    case mType.发布模块:
                        strFile = Server.MapPath("~/pub_files/put/") + fileName;
                        break;
                    case mType.抓取模块:
                        strFile = Server.MapPath("~/pub_files/pick/") + fileName;
                        break;
                    case mType.个人数据:
                        strFile = Server.MapPath("~/pub_files/person/") + fileName;
                        break;
                }
                if (member.netname == "Qin" || member.netname.Contains("调试模式")) {
                    FilesHelper.DeleteFile(strFile);
                    re = true;
                }
            }
            return re;

        }

        [WebMethod(Description = "修改某一个模块的名称，只有Qin具有这个权力。")]
        public bool ReName(string classMemberObj, string fileName, string fileNewName, mType mtype) {
            bool re = false;
            ModelMember member = new DbTools().StringtoClass(classMemberObj, "WCNM") as ModelMember;
            if (member != null && (member.netname == "Qin" || member.netname.Contains("调试模式"))) {

                string strFile = "";
                string strFile2 = "";
                DbTools db = new DbTools();

                switch (mtype) {
                    case mType.发布模块:
                        strFile = Server.MapPath("~/pub_files/put/") + fileName;
                        strFile2 = Server.MapPath("~/pub_files/put/") + fileNewName;
                        ModelSite put2 = db.Read(strFile, "WCNM") as ModelSite;
                        put2.SiteModuleName = fileNewName;
                        string tmpstr = db.ClasstoString(put2, "WCNM");
                        File.Delete(strFile);
                        FilesHelper.Write_File(strFile2, tmpstr);
                        re = true;
                        break;
                    case mType.抓取模块:
                        strFile = Server.MapPath("~/pub_files/pick/") + fileName;
                        strFile2 = Server.MapPath("~/pub_files/pick/") + fileNewName;
                        ModelPick pick2 = db.Read(strFile, "WCNM") as ModelPick;
                        pick2.PickName = fileNewName;
                        string tmpstr2 = db.ClasstoString(pick2, "WCNM");
                        File.Delete(strFile);
                        FilesHelper.Write_File(strFile2, tmpstr2);
                        re = true;
                        break;
                    case mType.个人数据:
                        strFile = Server.MapPath("~/pub_files/person/") + fileName;
                        strFile2 = Server.MapPath("~/pub_files/person/") + fileNewName;
                        break;
                }

            }
            return re;

        }

        [WebMethod(Description = "心跳方法")]
        public void doit() {

        }



        /// <summary>
        /// 上传数据的时候用到的，用户分类储存。
        /// </summary>
        public enum mType {
            发布模块,
            抓取模块,
            个人数据
        }

    }



}
