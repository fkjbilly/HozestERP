using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    /// <summary>
    /// xMPremiunsInfoList 的摘要说明
    /// </summary>
    public class xMPremiunsInfoList : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "SavePremiunsInfoIDs":
                    try
                    {
                        context.Session["SavePremiunsInfoIDs"] = null;
                        string Ids = CommonHelper.QueryString("Ids");
                        string[] IDs = Ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        context.Session["SavePremiunsInfoIDs"] = IDs;

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize("", josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}