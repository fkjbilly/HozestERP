using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageProject
{
    /// <summary>
    /// XMOrderInfoProductDetaisRead 的摘要说明
    /// </summary>
    public class xMInvoiceInfo : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "Supplement":
                    try
                    {
                        string msg = "";
                        string SupplementID = CommonHelper.QueryString("Ids");
                        context.Session["SupplementID"] = SupplementID;
                        var item = IoC.Resolve<IXMInvoiceInfoService>().GetXMInvoiceInfoByID(int.Parse(SupplementID));
                        if (item != null)
                        {
                            if (item.InvoiceType == null)
                            {
                                msg = "发票类型未确定的发票不能补开发票！";
                            }
                            //if (item.IsScrap == true)
                            //{
                            //    msg = "已废弃的发票不能补开发票！";
                            //}
                            //if (item.IsSingleRow == true)
                            //{
                            //    msg = "已排单的发票不能补开发票！";
                            //}
                        }

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(msg, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                case "Resume":
                    try
                    {
                        string msg = "";
                        string OrderCode = "";
                        string ResumeIDs = CommonHelper.QueryString("Ids");
                        string[] arr = ResumeIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var a in arr)
                        {
                            var item = IoC.Resolve<IXMInvoiceInfoService>().GetXMInvoiceInfoByID(int.Parse(a));
                            if (item != null)
                            {
                                if (item.InvoiceType == null)
                                {
                                    msg = "发票类型未确定的发票不能重开发票！";
                                    break;
                                }
                                if (item.IsScrap == true)
                                {
                                    msg = "已废弃的发票不能重开发票！";
                                    break;
                                }
                                if (item.IsSingleRow == true)
                                {
                                    msg = "已排单的发票不能重开发票！";
                                    break;
                                }
                                if (string.IsNullOrEmpty(OrderCode))
                                {
                                    OrderCode = item.OrderCode;
                                }
                                if (OrderCode != item.OrderCode)
                                {
                                    msg = "选择重写的发票包含多个订单，无法操作！";
                                    break;
                                }
                            }
                        }

                        context.Session["ResumeIDs"] = arr;

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(msg, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                case "GetProductInfoList":
                    try
                    {
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        string OrderCode = CommonHelper.QueryString("q");
                        if (OrderCode.Length > 5)
                        {
                            var OrderCodeList = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCodeList(OrderCode).Take(10);
                            foreach (var Item in OrderCodeList)
                            {
                                var Info = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(Item.OrderCode);
                                if (Info != null)
                                {
                                    Item.Count = 0;
                                    Item.ProductName = "";
                                    var one = (Info.XM_OrderInfoProductDetails).ToList()[0];
                                    var productDetail = IoC.Resolve<XMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(one.PlatformMerchantCode);
                                    if (productDetail != null && productDetail.Count > 0)
                                    {
                                        var products = IoC.Resolve<XMProductService>().GetXMProductById(productDetail[0].ProductId.Value);
                                        if (products != null)
                                        {
                                            Item.ProductName = products.BrandTypeCodeName + productDetail[0].ProductTypeCodeName.CodeName;
                                            Item.ProductUnit = products.ProductUnit;
                                        }
                                    }
                                    for (int i = 0; i < Info.XM_OrderInfoProductDetails.Count; i++)
                                    {
                                        var a = (Info.XM_OrderInfoProductDetails).ToList()[i];
                                        Item.Count += a.ProductNum;
                                    }
                                    Item.Amount = Info.PayPrice;
                                    Item.UnitPrice = Item.Amount / decimal.Parse(Item.Count.ToString());
                                }
                            }
                            javaS.Serialize(OrderCodeList, josn);
                        }
                        else
                        {
                            javaS.Serialize("", josn);
                        }

                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                case "SelectProductInfo":
                    try
                    {
                        string IsChsange = "0";
                        List<XMInvoiceInfoDetail> list = new List<XMInvoiceInfoDetail>();
                        if (context.Session["InvoiceInfoDetailList"] != null)
                        {
                            list = ((List<XMInvoiceInfoDetail>)context.Session["InvoiceInfoDetailList"]);
                        }

                        if (list.Count == 0)
                        {
                            IsChsange = "1";
                        }

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(IsChsange, josn);
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