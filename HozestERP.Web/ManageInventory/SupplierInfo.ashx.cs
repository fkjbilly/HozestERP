using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.Common.Utils;
using System.Web.Script.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageInventory
{
    /// <summary>
    /// SupplierInfo 的摘要说明
    /// </summary>
    public class SupplierInfo : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string supplierId = CommonHelper.QueryString("supId");
            JavaScriptSerializer javaS = new JavaScriptSerializer();
            StringBuilder josn = new StringBuilder();
            var suppliers = IoC.Resolve<IXMSuppliersService>().GetXMSuppliersById(int.Parse(supplierId));
            javaS.Serialize(suppliers, josn);
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