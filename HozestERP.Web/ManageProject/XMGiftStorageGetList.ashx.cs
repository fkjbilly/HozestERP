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
    /// <summary>
    /// XMOrderInfoProductDetaisRead 的摘要说明
    /// </summary>
    public class XMGiftStorageGetList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string ProductCode = CommonHelper.QueryString("q");
            int NickId = int.Parse(CommonHelper.QueryString("p"));
            JavaScriptSerializer javaS = new JavaScriptSerializer();
            StringBuilder josn = new StringBuilder();
            var products = IoC.Resolve<IXMGiftStorageRecordService>().GetXMProductListByCode(ProductCode).Take(10);
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