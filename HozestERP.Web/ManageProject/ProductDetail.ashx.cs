using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.Common.Utils;
using System.Web.Script.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using System.Web.SessionState;

namespace HozestERP.Web.ManageProject
{
    /// <summary>
    /// ProductDetail 的摘要说明
    /// </summary>
    public class ProductDetail : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "GetProductList":
                    try
                    {
                        int PlatformTypeId = 0;
                        List<XMProductNew> List = new List<XMProductNew>();
                        //string platFormID = CommonHelper.QueryString("p");
                        string productName = CommonHelper.QueryString("q");
                        string OrderCode = "";

                        if (context.Session["RecordOrderCode"] != null)
                        {
                            OrderCode = context.Session["RecordOrderCode"].ToString();
                        }

                        var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(OrderCode);
                        if (OrderInfo != null)
                        {
                            PlatformTypeId = (int)OrderInfo.PlatformTypeId;
                        }

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        var products = IoC.Resolve<IXMProductService>().getXMProductListByProductName(productName).Where(p => p.IsPremiums == true).Take(20);
                        foreach (XMProduct p in products)
                        {
                            string PlatformMerchantCode = "";
                            decimal costPrice = 0;
                            var detail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(p.Id);
                            if (detail != null && detail.Count > 0)
                            {
                                XMProductNew ProductNew = new XMProductNew();
                                List<XMProductDetails> list = null;
                                //ProductNew.ManufacturersCode = p.ManufacturersCode;

                                if (PlatformTypeId != 0)
                                {
                                    list = detail.Where(x => x.PlatformTypeId == PlatformTypeId).ToList();
                                    if (list.Count > 0)
                                    {
                                        PlatformMerchantCode = list[0].PlatformMerchantCode;
                                        costPrice = list[0].Costprice == null ? 0 : (decimal)list[0].Costprice;
                                    }
                                }

                                if (PlatformMerchantCode == "")
                                {
                                    list = detail.Where(x => x.PlatformTypeId == 508).ToList();
                                    if (list.Count > 0)//其他平台
                                    {
                                        PlatformMerchantCode = list[0].PlatformMerchantCode;
                                        costPrice= list[0].Costprice == null ? 0 : (decimal)list[0].Costprice;
                                    }
                                }
                                //else
                                //{
                                //    if (detail.Where(x => x.PlatformTypeId == PlatformTypeId).ToList().Count > 0)
                                //    {
                                //        PlatformMerchantCode = (detail.Where(x => x.PlatformTypeId == PlatformTypeId).ToList())[0].PlatformMerchantCode;
                                //    }
                                //}

                                if (string.IsNullOrEmpty(PlatformMerchantCode))
                                {
                                    continue;
                                }

                                ProductNew.PlatformMerchantCode = PlatformMerchantCode;
                                ProductNew.ProductName = p.ProductName;
                                ProductNew.Specifications = p.Specifications;
                                ProductNew.ProductId = p.Id;
                                ProductNew.Shipper = p.Shipper;
                                ProductNew.Costprice = costPrice;
                                List.Add(ProductNew);
                            }
                        }

                        javaS.Serialize(List, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                case "RecordOrderCode":
                    try
                    {
                        string OrderCode = CommonHelper.QueryString("q");
                        context.Session["RecordOrderCode"] = OrderCode;

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