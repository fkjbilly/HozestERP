using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageCustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{
    public class InstallationCount
    {
        public int? projectID { get; set; }

        public int? nickID { get; set; }

        public int installationCount { get; set; }

        public int installationFinishCount { get; set; }

        public decimal? installationMoney { get; set; }

        public float finishRate { get; set; }

        public int? workID { get; set; }

        public string NickName
        {
            get
            {
                string result = "";
                if (this.nickID != null && this.nickID > 0)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(int.Parse(this.nickID.ToString()));
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }

        }

        public string ProjectName
        {
            get
            {
                string result = "";
                if (this.projectID != null && this.projectID > 0)
                {
                    var project = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(this.projectID.ToString()));
                    if (project != null)
                    {
                        result = project.ProjectName;
                    }
                }
                return result;
            }
        }

        public string Worker
        {
            get
            {
                string result = "";
                if (workID != null)
                {
                    var data = IoC.Resolve<IXMWorkerInfoService>().GetXMWorkerInfoByID(int.Parse(workID.ToString()));
                    if(data!=null)
                    {
                        result = data.FullName;
                    }
                }

                return result;
            }
        }
    }
}
