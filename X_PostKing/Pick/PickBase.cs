using System;
using System.Collections.Generic;
using System.Text;
using X_Model;
using System.Collections;
using X_Service.Util;
using X_Service.Web;
using System.Windows.Forms;
using X_Service.Files;
using X_Service.Db;
using System.Text.RegularExpressions;

namespace X_PostKing.Pick {
    public class PickBase {
        protected ModelTasks task;
        protected ModelPick pick;

        public PickBase() {
            pick = new ModelPick();
        }

        /// <summary>
        /// 把url中的[0-12]演变成数组0,1,2,3,4,5返回。
        /// 如果url中没有[0-12]的格式，就把这个url返回去。
        /// </summary>
        /// <param name="oldUrl"></param>
        /// <param name="al"></param>
        protected void getIndexUrlList(string oldUrl, ref ArrayList al) {
            try {
                EchoHelper.Echo("整理网址列表中，如果是多页的话则需要点时间。", task.TaskName, EchoHelper.EchoType.任务信息);
                ArrayList tmp_al = new ArrayList();

                if (oldUrl.Contains("[连续分页]")) {
                    oldUrl = oldUrl.Replace("[连续分页]", "[" + task.PickPageStartNum + "-" + task.PickPageNums + "]");
                    string tmpNum = RegexHelper.getMatch(oldUrl, @"\[.*?\-.*?\]");
                    tmpNum = tmpNum.Replace("[", "").Replace("]", "");
                    int num1 = Convert.ToInt32(tmpNum.Split('-')[0].ToString());
                    int num2 = Convert.ToInt32(tmpNum.Split('-')[1].ToString());
                    oldUrl = RegexHelper.regReplace(oldUrl, @"\[.*?\-.*?\]", "{num}");
                    for (int i = num1; i < num2 + 1; i++) {
                        tmp_al.Add(oldUrl.Replace("{num}", i.ToString()));
                    }
                } else {
                    tmp_al.Add(oldUrl);
                }
                al = tmp_al;
            } catch (Exception ex) {
                EchoHelper.Echo("网址中的[0-12]格式替换失败。" + ex.Message, task.TaskName, EchoHelper.EchoType.异常信息);

            }
        }

        protected ModelPickHash getModelPickHash() {
            DbTools db = new DbTools();
            ModelPickHash hash = new ModelPickHash();
            try {
                object obj = db.Read(Application.StartupPath + task.SavePath + "log\\" + task.TaskName + ".VDB", "VCDS");
                if (obj != null) {
                    hash = (ModelPickHash)obj;
                }
            } catch (Exception ex) {
                EchoHelper.Echo("PichHash加载失败！" + ex.Message, task.TaskName, EchoHelper.EchoType.异常信息);
            }
            return hash;
        }

        protected void saveHash(ModelPickHash hash) {
            DbTools db = new DbTools();
            db.Save(Application.StartupPath + task.SavePath + "log\\" + task.TaskName + ".VDB", "VCDS", hash);
        }

        /// <summary>
        /// 检查这个URL是否已经被采集。
        /// </summary>
        /// <param name="hashcode"></param>
        /// <returns></returns>
        protected bool IsPicked(int hashcode) {
            ModelPickHash hash = getModelPickHash();
            bool re = false;
            try {
                if (hash.HashValue.Contains(hashcode)) {
                    re = true;
                }
            } catch (Exception ex) {
                EchoHelper.EchoException(ex);
            }
            return re;
        }

        protected void putPicked(string content) {
            ModelPickHash hash = getModelPickHash();
            hash.HashValue.Add(content.GetHashCode());
            saveHash(hash);
        }

        protected void saveArticalToFile(string new_title, string new_content) {
            //检查内容字数是否满足要求
            new_title = new_title.Replace("/", "");
            if (string.IsNullOrEmpty(new_title)) {
                new_title = StringHelper.getRandCode(10);
            }

            string tmpPickcontent = StringHelper.SubStringNoDDD(new_content, 0, 500);//将此正文截取前30个字符，用来判断是否存在已经采集的情况。

            if (new_content.Length > task.PickMinContentNum && !IsPicked(tmpPickcontent.GetHashCode())) {
                string tmp_path;

                if (pick.SameTileFile) {
                    tmp_path = Application.StartupPath + task.SavePath + new_title.Trim() + ".txt";
                } else {
                    tmp_path = Application.StartupPath + task.SavePath + new_title.Trim() + StringHelper.getRandNum(2) + ".txt";
                }

                if (task.IsSentenceAuto) {
                    List<ModelSentence> slist = new List<ModelSentence>();
                    string tmp_path2 = Application.StartupPath + task.SavePath + "log\\Sentence.VDB";
                    DbTools db = new DbTools();
                    object obj = null;

                    obj = db.Read(tmp_path2, "VCDS");
                    if (obj != null) {
                        slist = (List<ModelSentence>)obj;
                        for (int i = 0; i < new_content.Split('\n').Length; i++) {
                            new PickBase().saveArticleToSentence(ref slist, task, new_content.Split('\n')[i].ToString());
                        }
                    }

                    db.Save(tmp_path2, "VCDS", slist);
                    //saveArticleToSentence(task, new_content);//保存此文章为断言库内容。
                }

                FilesHelper.Write_File(tmp_path, new_content);

                putPicked(tmpPickcontent);//将此内容加入到已采集队列。

                EchoHelper.Echo("页面内容采集：" + new_title.Trim() + " 成功√√√", "采集", EchoHelper.EchoType.任务信息);
            } else {
                EchoHelper.Echo("内容字数太少[" + new_content.Length + "]，或已存在该文章！" + new_title.Trim() + " 跳过×", "采集", EchoHelper.EchoType.任务信息);
            }
        }


        /// <summary>
        /// 加入到断言库中，分解当前的文章
        /// </summary>
        /// <param name="new_content"></param>
        public void saveArticleToSentence(ref List<ModelSentence> slist, ModelTasks task, string new_content) {
            if (new_content.Length < 1) {
                return;
            }

            int count = 0;
            if (task.IsSentence) {

                new_content = new_content.Replace("。", "，¤").Replace("？", "？¤").Replace("！", "！¤").Replace("，", "，¤").Replace("?", "?¤").Replace("!", "!¤").Replace("\n", "\n¤");
                string[] sts = new_content.Split('¤');
                for (int i = 0; i < sts.Length; i++) {
                    //去掉HTML
                    sts[i] = RegexHelper.regReplaces(sts[i], "<.*?>", "");
                    //去掉http链接等
                    sts[i] = RegexHelper.regReplace(sts[i], @"[a-zA-z]+://[^\s]*", "");                   //网址过滤1
                    sts[i] = RegexHelper.regReplace(sts[i], @"http://", "");                              //网址过滤1
                    sts[i] = RegexHelper.regReplaces(sts[i], @"www\.[a-zA-z0-9]+\.(com|net|org|cn)", ""); //网址过滤2

                    Regex r = new Regex("[\u4e00-\u9fa5]");//UTF8 中中文汉字的范围
                    float xCount = (float)(r.Matches(sts[i]).Count) / (float)sts[i].Length;
                    if (xCount > 0.7 && sts[i].Length > task.SentenceMinLength && sts[i].Length < 300) {

                        int has = slist.FindAll(delegate(ModelSentence tmp) {
                            return tmp.body == sts[i].Trim();
                        }).Count;//查找是否存在这条记录，如果不存在，那么加入到库中。

                        ModelSentence sentence = new ModelSentence();
                        sentence.body = sts[i].Trim();
                        if (has == 0) {
                            slist.Insert(0, sentence);
                            count += 1;
                        } else {
                            EchoHelper.Echo("本条断言已存在：[" + sentence.body + "]，跳过！", "断言库", EchoHelper.EchoType.任务信息);
                        }

                    }
                }
                if (slist.Count > 50000) {//若断言大于5万条，那么就不自动加入断言库了。
                    task.IsSentenceAuto = false;
                }
                if (count != 0) {
                    EchoHelper.Echo("本次成功加入" + count + "条断言片段！目前已存在断言" + slist.Count + "条。", "断言库", EchoHelper.EchoType.任务信息);
                }

            }

        }

        /// <summary>
        /// 删除断言库中的一条。
        /// </summary>
        /// <param name="index"></param>
        public void deleteArticleFromSentence(ModelTasks task, int index) {
            string tmp_path = Application.StartupPath + task.SavePath + "log\\Sentence.VDB";
            DbTools db = new DbTools();
            object obj = null;
            IList<ModelSentence> slist = new List<ModelSentence>();
            obj = db.Read(tmp_path, "VCDS");
            if (obj != null) {
                slist = (IList<ModelSentence>)obj;
            }

            slist.RemoveAt(index);
            db.Save(tmp_path, "VCDS", slist);
        }

        public ArrayList getArticleFromSentence(ModelTasks task) {
            string tmp_path = Application.StartupPath + task.SavePath + "log\\Sentence.VDB";
            DbTools db = new DbTools();
            object obj = null;
            IList<ModelSentence> slist = new List<ModelSentence>();
            obj = db.Read(tmp_path, "VCDS");
            if (obj != null) {
                slist = (IList<ModelSentence>)obj;
            }

            ArrayList al = new ArrayList();
            for (int i = 0; i < slist.Count; i++) {
                al.Add(slist[i].body);
            }

            return al;
        }


    }
}
