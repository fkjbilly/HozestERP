using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    /// <summary>
    /// xMOrderUpdateProductDetails 的摘要说明
    /// </summary>
    public class xMOrderUpdateProductDetails : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string ProductName = CommonHelper.QueryString("ProductName").Trim();
            int PlatformTypeId = int.Parse(CommonHelper.QueryString("PlatformTypeId").Trim());
            JavaScriptSerializer javaS = new JavaScriptSerializer();
            StringBuilder josn = new StringBuilder();
            var list = IoC.Resolve<IXMProductService>().GetXMProductListByProductName(ProductName, PlatformTypeId).Take(20);
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