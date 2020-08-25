using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    /// <summary>
    /// Summary description for XMScalpingApplicationReturnedHandler
    /// </summary>
    public class XMScalpingApplicationReturnedHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
              string action = CommonHelper.QueryString("action");
              switch (action)
              {
                  #region ProductName
                  case "ProductName":
                      try
                      {
                          string ProductName = CommonHelper.QueryString("q");
                          JavaScriptSerializer javaS = new JavaScriptSerializer();
                          StringBuilder josn = new StringBuilder();
                          List<XMProduct> lsXMProduct = new List<XMProduct>();
                          var lsProduct = IoC.Resolve<IXMProductService>().getXMProductListByProductName(ProductName).Take(10);
                          javaS.Serialize(lsProduct, josn);
                          context.Response.ContentType = "text/plain";
                          context.Response.Write(josn.ToString());
                      }
                      catch
                      {
                      }
                      break;
                  #endregion

                  #region OrderCode
                  case "OrderCode":
                      try
                      {
                          string OrderCode = CommonHelper.QueryString("q");
                          JavaScriptSerializer javaS = new JavaScriptSerializer();
                          StringBuilder josn = new StringBuilder();
                         // List<XMOrderInfoMapping> lsXMOrderInfo = new List<XMOrderInfoMapping>();
                          var lsOrder = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCodeList(OrderCode).Take(10);
                          javaS.Serialize(lsOrder, josn);
                          context.Response.ContentType = "text/plain";
                          context.Response.Write(josn.ToString());
                      }
                      catch
                      {

                      }
                      break;
                  #endregion

                  #region PremiumsDetails
                  case "PremiumsDetails":
                      try
                      {
                          string ProductName = CommonHelper.QueryString("q");
                          JavaScriptSerializer javaS = new JavaScriptSerializer();
                          StringBuilder josn = new StringBuilder();
                          List<XMProduct> lsXMProduct = new List<XMProduct>();
                          var lsProductDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(ProductName).Take(20);
                          javaS.Serialize(lsProductDetails, josn);
                          context.Response.ContentType = "text/plain";
                          context.Response.Write(josn.ToString());
                      }
                      catch
                      {
                      }
                      break;
                  #endregion

                  #region QuestionOrderCode 问题反馈
                  case "QuestionOrderCode":
                      try
                      {
                          string OrderCode = CommonHelper.QueryString("q");
                          JavaScriptSerializer javaS = new JavaScriptSerializer();
                          StringBuilder josn = new StringBuilder();
                          // List<XMOrderInfoMapping> lsXMOrderInfo = new List<XMOrderInfoMapping>();
                          //线上订单
                          var OnlineOrder = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCodeList(OrderCode).Take(10);
                          //线下订单
                          var OfflineOrder = IoC.Resolve<IXMSaleInfoService>().GetXMSaleInfoListByRef(OrderCode).Take(10);
                          List<XMOrderInfoMapping> OrderList = new List<XMOrderInfoMapping>();
                          foreach (var Info in OnlineOrder)
                          {
                              Info.OfflinePlatformName = Info.PlatformName;
                              Info.OfflineNickName = Info.NickName;
                          }
                          foreach (var Info in OfflineOrder)
                          {
                              XMOrderInfoMapping one = new XMOrderInfoMapping();
                              one.OrderCode = Info.Ref;
                              one.WantID = Info.CustomerName;
                              one.OfflinePlatformName = "线下";
                              one.OfflineNickName = Info.ProjectName;
                              one.NickID = one.PlatformTypeId = 0;
                              OrderList.Add(one);
                          }
                          OrderList.AddRange(OnlineOrder);

                          javaS.Serialize(OrderList.OrderBy(x => x.OrderCode).Take(10), josn);
                          context.Response.ContentType = "text/plain";
                          context.Response.Write(josn.ToString());
                      }
                      catch
                      {

                      }
                      break;
                  #endregion

                  #region QuestionOrderCode2 产品详情
                  case "QuestionOrderCode2":
                      try
                      {
                          string OrderCode = CommonHelper.QueryString("q");
                          JavaScriptSerializer javaS = new JavaScriptSerializer();
                          StringBuilder josn = new StringBuilder();
                          // List<XMOrderInfoMapping> lsXMOrderInfo = new List<XMOrderInfoMapping>();
                          var lsOrder = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByOrderCode(OrderCode).Take(10);
                          javaS.Serialize(lsOrder, josn);
                          context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                      }
                      catch
                      {

                      }
                      break;
                  #endregion
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