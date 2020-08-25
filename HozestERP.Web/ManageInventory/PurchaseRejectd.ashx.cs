using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.Common.Utils;
using System.Web.Script.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageInventory
{
    /// <summary>
    /// PurchaseRejectd 的摘要说明
    /// </summary>
    public class PurchaseRejectd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string prID = CommonHelper.QueryString("PrId");
            int billStatus = 0;
            var purcahseRejectDetail = IoC.Resolve<XMPurchaseRejectedProductDetailsService>().GetXMPurchaseRejectedProductDetailsById(int.Parse(prID));
            if (purcahseRejectDetail != null)
            {
                if (purcahseRejectDetail.BillStatus == null || purcahseRejectDetail.BillStatus == 0)
                {
                    billStatus = 1000;
                    purcahseRejectDetail.BillStatus = 1000;     //将采购退货单状态更新为已退回
                }
                else
                {
                    purcahseRejectDetail.BillStatus = 0;
                }
                purcahseRejectDetail.UpdateDate = DateTime.Now;
                purcahseRejectDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                IoC.Resolve<XMPurchaseRejectedProductDetailsService>().UpdateXMPurchaseRejectedProductDetails(purcahseRejectDetail);
                context.Response.ContentType = "text/plain";
                context.Response.Write("{ \"BillStatus\": " + billStatus + "}");
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