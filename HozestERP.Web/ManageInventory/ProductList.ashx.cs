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
    /// ProductList 的摘要说明
    /// </summary>
    public class ProductList : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "PdInfo":
                    List<XMProductNew> List2 = new List<XMProductNew>();
                    string pName = System.Web.HttpUtility.UrlDecode(CommonHelper.QueryString("q"));
                    var product = IoC.Resolve<IXMProductService>().getXMProductListByProductName(pName).Take(50);
                    JavaScriptSerializer javaS3 = new JavaScriptSerializer();
                    StringBuilder josn3 = new StringBuilder();
                    if (product != null && product.Count() > 0)
                    {
                        foreach (XMProduct Info in product)
                        {
                            decimal costPrice = 0;
                            XMProductNew productNew = new XMProductNew();
                            productNew.ProductId = Info.Id;
                            productNew.ProductName = Info.ProductName;
                            productNew.ManufacturersCode = Info.ManufacturersCode;
                            productNew.Specifications = Info.Specifications;
                            productNew.ProductUnit = Info.ProductUnit;
                            var details = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(Info.Id);
                            if (details != null && details.Count > 0)
                            {
                                productNew.Costprice = details[0].Costprice;
                            }
                            List2.Add(productNew);
                        }
                    }
                    javaS3.Serialize(List2, josn3);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(josn3.ToString());
                    break;


                case "SaleAdd":
                    int salePid = int.Parse(CommonHelper.QueryString("pid"));
                    List<XMProductNew> PList = new List<XMProductNew>();
                    string saleProductName = System.Web.HttpUtility.UrlDecode(CommonHelper.QueryString("q"));
                    JavaScriptSerializer SaleJavaS = new JavaScriptSerializer();
                    StringBuilder saleJosn = new StringBuilder();
                    var saleProducts = IoC.Resolve<IXMProductService>().getXMProductListByProductName(saleProductName).Take(50);
                    if (saleProducts != null && saleProducts.Count() > 0)
                    {
                        foreach (XMProduct Info in saleProducts)
                        {
                            XMProductNew productNew = new XMProductNew();
                            productNew.ProductId = Info.Id;
                            productNew.ProductName = Info.ProductName;
                            productNew.ManufacturersCode = Info.ManufacturersCode;
                            productNew.Specifications = Info.Specifications;
                            productNew.ProductUnit = Info.ProductUnit;
                            decimal cost = 0;
                            var productDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(Info.Id).Where(p => p.PlatformTypeId == salePid).ToList();
                            if (productDetails != null && productDetails.Count > 0)
                            {
                                productNew.Saleprice = productDetails[0].Saleprice;
                            }
                            else
                            {
                                productNew.Saleprice = cost;
                            }
                            PList.Add(productNew);
                        }
                    }
                    SaleJavaS.Serialize(PList, saleJosn);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(saleJosn.ToString());
                    break;
                case "ProductName":
                    int pid = int.Parse(CommonHelper.QueryString("pid"));
                    List<XMProductNew> List = new List<XMProductNew>();
                    string productName = System.Web.HttpUtility.UrlDecode(CommonHelper.QueryString("q"));
                    JavaScriptSerializer javaS = new JavaScriptSerializer();
                    StringBuilder josn = new StringBuilder();
                    var products = IoC.Resolve<IXMProductService>().getXMProductListByProductName(productName).Take(50);
                    if (products != null && products.Count() > 0)
                    {
                        foreach (XMProduct Info in products)
                        {
                            XMProductNew productNew = new XMProductNew();
                            productNew.ProductId = Info.Id;
                            productNew.ProductName = Info.ProductName;
                            productNew.ManufacturersCode = Info.ManufacturersCode;
                            productNew.Specifications = Info.Specifications;
                            productNew.ProductUnit = Info.ProductUnit;
                            decimal cost = 0;
                            var productDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(Info.Id).Where(p => p.PlatformTypeId == pid).ToList();
                            if (productDetails != null && productDetails.Count > 0)
                            {
                                productNew.Costprice = productDetails[0].Costprice;
                            }
                            else
                            {
                                productNew.Costprice = cost;
                            }
                            List.Add(productNew);
                        }
                    }
                    javaS.Serialize(List, josn);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(josn.ToString());
                    break;
                case "ProductId":
                    decimal costprice = 0;
                    string pro = CommonHelper.QueryString("productId");
                    int productId = int.Parse(pro);
                    int platformId = int.Parse(CommonHelper.QueryString("pId"));
                    JavaScriptSerializer javaS2 = new JavaScriptSerializer();
                    StringBuilder josn2 = new StringBuilder();
                    XMProductNew productNew2 = new XMProductNew();
                    var productDetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(productId).Where(p => p.PlatformTypeId == platformId).ToList();
                    if (productDetail != null && productDetail.Count > 0)
                    {
                        productNew2.Costprice = productDetail[0].Costprice;
                    }
                    else
                    {
                        productNew2.Costprice = costprice;
                    }
                    javaS2.Serialize(productNew2, josn2);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(josn2.ToString());
                    break;

                case "ProductId2":                                           //如所选项为0 重新选个不为0的
                    decimal costprice2 = 0;
                    string pro2 = CommonHelper.QueryString("productId");
                    int productId2 = int.Parse(pro2);
                    JavaScriptSerializer javaS21 = new JavaScriptSerializer();
                    StringBuilder josn21 = new StringBuilder();
                    XMProductNew productNew21 = new XMProductNew();
                    var productDetail21 = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(productId2);
                    if (productDetail21 != null && productDetail21.Count > 0)
                    {
                        foreach (var parm in productDetail21)
                        {
                            if (parm.Costprice > 0)
                            {
                                costprice2 = parm.Costprice.Value;
                                break;
                            }
                        }
                    }
                    productNew21.Costprice = costprice2;
                    javaS21.Serialize(productNew21, josn21);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(josn21.ToString());
                    break;

                case "SaleProductId":
                    decimal saleprice = 0;
                    string pro6 = CommonHelper.QueryString("productId");
                    int productId6 = int.Parse(pro6);
                    int platformId6 = int.Parse(CommonHelper.QueryString("pId"));
                    JavaScriptSerializer javaS6 = new JavaScriptSerializer();
                    StringBuilder josn6 = new StringBuilder();
                    XMProductNew productNew6 = new XMProductNew();
                    var productDetail6 = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(productId6).Where(p => p.PlatformTypeId == platformId6).ToList();
                    if (productDetail6 != null && productDetail6.Count > 0)
                    {
                        productNew6.Saleprice = productDetail6[0].Saleprice;
                    }
                    else
                    {
                        productNew6.Saleprice = saleprice;
                    }
                    javaS6.Serialize(productNew6, josn6);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(josn6.ToString());
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