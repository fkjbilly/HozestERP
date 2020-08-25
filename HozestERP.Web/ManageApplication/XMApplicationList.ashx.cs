using HozestERP.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace HozestERP.Web.ManageApplication
{
    /// <summary>
    /// XMApplicationList1 的摘要说明
    /// </summary>
    public class XMApplicationList1 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "SaveReturnIDs":
                    try
                    {
                        context.Session["SaveReturnIDs"] = null;
                        string Ids = CommonHelper.QueryString("Ids");
                        string[] IDs = Ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        context.Session["SaveReturnIDs"] = IDs;

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