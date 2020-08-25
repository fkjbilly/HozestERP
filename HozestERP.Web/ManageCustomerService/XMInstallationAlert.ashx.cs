using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using HozestERP.Common.Utils;
using System.Web.Script.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageCustomerService
{
    /// <summary>
    /// XMInstallationAlert 的摘要说明
    /// </summary>
    public class XMInstallationAlert : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (HozestERPContext.Current.User != null)
                {
                    string str = CommonHelper.QueryString("p");
                    JavaScriptSerializer javaS = new JavaScriptSerializer();
                    StringBuilder josn = new StringBuilder();
                    var list = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoListByOrderCodeForXMInstallationList(str).Take(10);
                    javaS.Serialize(list, josn);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(josn.ToString());
                }
            }
            catch
            {
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