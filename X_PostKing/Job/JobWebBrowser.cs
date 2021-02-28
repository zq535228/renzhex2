using System;
using System.Collections.Generic;
using System.Text;

namespace X_PostKing.Job {
    public class JobWebBrowser : JobCoreBase {

        public JobWebBrowser(X_Model.ModelSite site, X_Model.ModelTasks task) {
            try {
                this.Task = task;
                this.Site = site;
                setUser();
            } catch {
            }
        }

        public override string _replace(string data) {
            data = data.Replace("【", "[").Replace("】", "]");
            return base._replace(data);
        }

        public override string _replacePutContent(string data, Encoding encode) {
            data = data.Replace("【", "[").Replace("】", "]");
            return base._replacePutContent(data, encode);
        }



        public override string Login() {
            throw new NotImplementedException();
        }

        public override string Post() {
            throw new NotImplementedException();
        }
    }
}
