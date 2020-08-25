using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageCustomerService
{
    /// <summary>
    /// xMConsultation 的摘要说明
    /// </summary>
    public class xMConsultation : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string ManufacturersCode = CommonHelper.QueryString("ManufacturersCode");
            var list = IoC.Resolve<IXMProductService>().GetXMProductCombinationList(ManufacturersCode).Take(10);
            
            JavaScriptSerializer javaS = new JavaScriptSerializer();
            StringBuilder josn = new StringBuilder();
            javaS.Serialize(list, josn);
            context.Response.ContentType = "text/plain";
            context.Response.Write(josn.ToString());
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