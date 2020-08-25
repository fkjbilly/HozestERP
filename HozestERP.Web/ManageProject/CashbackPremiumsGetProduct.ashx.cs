using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.Common.Utils;
using System.Web.Script.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageProject
{
    public class CashbackPremiumsGetProduct : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string PrdouctName = CommonHelper.QueryString("p");
            JavaScriptSerializer javaS = new JavaScriptSerializer();
            StringBuilder josn = new StringBuilder();
            var products = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductNameList(PrdouctName).Take(10);
            javaS.Serialize(products, josn);
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