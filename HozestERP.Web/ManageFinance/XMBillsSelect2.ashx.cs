using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageFinance
{
    /// <summary>
    /// XMBills 的摘要说明
    /// </summary>
    public class XMBillsSelect2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var list = IoC.Resolve<IXMSuppliersService>().GetXMSuppliersList();
            var selectData = list.Select(m => new
            {
                text = m.SupplierName,
                id = m.Id
            });
          
            var selectDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(selectData);
            context.Response.ContentType = "text/json";
            context.Response.Write(selectDataJson);
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