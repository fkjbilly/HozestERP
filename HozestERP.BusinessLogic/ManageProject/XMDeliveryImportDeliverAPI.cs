using System;
using System.Collections.Generic;
using Top.Api;
using Newtonsoft.Json;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ErrorLog;
using Yhd.Api;
using Osp.Sdk.Context;
using Osp.Sdk.Exception;
using vipapis.address;
using vipapis.delivery;

namespace HozestERP.BusinessLogic.ManageProject
{
    extern alias suning;
    public class XMDeliveryImportDeliverAPI
    {
        public string GetTMAPIDelivery(string OrderId, string LogisticsCode, string Waybill, XMOrderInfoApp xMorderInfoApp)
        {
            try
            {
                string AppKey = xMorderInfoApp.AppKey;
                string AppSecret = xMorderInfoApp.AppSecret;
                string CallbackUrl = xMorderInfoApp.CallbackUrl;//"http://www.hozest.com";
                string AccessToken = xMorderInfoApp.AccessToken;

                ITopClient client = new DefaultTopClient("http://gw.api.taobao.com/router/rest", AppKey, AppSecret);
                Top.Api.Request.LogisticsOfflineSendRequest req = new Top.Api.Request.LogisticsOfflineSendRequest();
                req.Tid = long.Parse(OrderId);
                req.OutSid = Waybill;
                req.CompanyCode = LogisticsCode;
                Top.Api.Response.LogisticsOfflineSendResponse rsp = client.Execute(req, AccessToken);
                //Top.Api.Response.LogisticsOfflineSendResponse m = JsonConvert.DeserializeObject<Top.Api.Response.LogisticsOfflineSendResponse>(rsp.Body);

                if (rsp.Shipping != null)
                {
                    if (rsp.Shipping.IsSuccess)
                    {
                        return rsp.Shipping.Modified;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<IRecordErrorLogs>().WriteErrorLog("负责人:" + HozestERPContext.Current.User.CustomerID.ToString() + ";   方法名:GetTMAPIDelivery;  异常提示：" + ex.Message.ToString() + ";   InnerException:" + ex.InnerException);
            }
            return null;
        }

        public string GetSuNingAPIDelivery(string OrderId, string LogisticsCode, string Waybill, XMOrderInfoApp xMorderInfoApp)
        {
            try
            {
                string AppKey = xMorderInfoApp.AppKey;
                string AppSecret = xMorderInfoApp.AppSecret;
                string CallbackUrl = xMorderInfoApp.CallbackUrl;//"http://www.hozest.com";
                string AccessToken = xMorderInfoApp.AccessToken;

                suning::suning_api_sdk.BizRequest.CustomTransactionRequest.OrderdeliveryAddRequest request = new suning::suning_api_sdk.BizRequest.CustomTransactionRequest.OrderdeliveryAddRequest();
                request.orderCode = OrderId;
                request.expressNo = Waybill;
                request.expressCompanyCode = LogisticsCode;

                suning::suning_api_sdk.ISuningClient client = new suning::suning_api_sdk.DefaultSuningClient("http://open.suning.com/api/http/sopRequest", AppKey, AppSecret);
                suning::suning_api_sdk.BizResponse.CustomTransactionResponse.OrderdeliveryAddResponse rsp = client.Execute(request);
                //suning::suning_api_sdk.BizResponse.CustomTransactionResponse.OrderdeliveryAddResponse m = JsonConvert.DeserializeObject<suning::suning_api_sdk.BizResponse.CustomTransactionResponse.OrderdeliveryAddResponse>(rsp.ToJson());

                if (rsp.sendDetail != null)
                {
                    if (string.IsNullOrEmpty(rsp.respError.error_code))
                    {
                        return "";
                    }
                    else
                    {
                        return null ;
                    }
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<IRecordErrorLogs>().WriteErrorLog("负责人:" + HozestERPContext.Current.User.CustomerID.ToString() + ";   方法名:GetSuNingAPIDelivery;  异常提示：" + ex.Message.ToString() + ";   InnerException:" + ex.InnerException);
            }
            return null;
        }

        public string GetYHDAPIDelivery(string OrderId, string LogisticsCode, string Waybill, XMOrderInfoApp xMorderInfoApp)
        {
            try
            {
                string AppKey = xMorderInfoApp.AppKey;
                string AppSecret = xMorderInfoApp.AppSecret;
                string CallbackUrl = xMorderInfoApp.CallbackUrl;//"http://www.hozest.com";
                string AccessToken = xMorderInfoApp.AccessToken;

                YhdClient client = new YhdClient("http://openapi.yhd.com/app/api/rest/router", AppKey, AppSecret);
                Yhd.Api.Request.LogisticsOrderShipmentsUpdateRequest req = new Yhd.Api.Request.LogisticsOrderShipmentsUpdateRequest();
                req.OrderCode = OrderId;
                req.ExpressNbr = Waybill;
                req.DeliverySupplierId = long.Parse(LogisticsCode);
                Yhd.Api.Response.LogisticsOrderShipmentsUpdateResponse rsp = client.Execute(req, AccessToken);

                if (rsp != null)
                {
                    if (rsp.UpdateCount > 0)
                    {
                        return "";
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<IRecordErrorLogs>().WriteErrorLog("负责人:" + HozestERPContext.Current.User.CustomerID.ToString() + ";   方法名:GetYHDAPIDelivery;  异常提示：" + ex.Message.ToString() + ";   InnerException:" + ex.InnerException);
            }
            return null;
        }

        public string GetVPHAPIDelivery(string OrderId, string LogisticsCode, string Waybill, XMOrderInfoApp xMorderInfoApp, string LogisticsName)
        {
            try
            {
                string AppKey = xMorderInfoApp.AppKey;
                string AppSecret = xMorderInfoApp.AppSecret;
                string CallbackUrl = xMorderInfoApp.CallbackUrl;//"http://www.hozest.com";
                string AccessToken = xMorderInfoApp.AccessToken;
                string posturl = xMorderInfoApp.ServerUrl;

                DvdDeliveryServiceHelper.DvdDeliveryServiceClient client = new DvdDeliveryServiceHelper.DvdDeliveryServiceClient();
                InvocationContext invocationContext = Factory.GetInstance();
                invocationContext.SetAppKey(AppKey);
                invocationContext.SetAppSecret(AppSecret);
                invocationContext.SetAppURL(posturl);

                List<PackageProduct> packageProduct_list = new List<PackageProduct>();
                PackageProduct packageProduct = new PackageProduct();
                packageProduct.SetBarcode("");
                packageProduct.SetAmount(1);
                packageProduct_list.Add(packageProduct);

                List<Package> package_list = new List<Package>();
                Package package = new Package();
                package.SetTransport_no(Waybill);
                package.SetPackage_product_list(packageProduct_list);
                package_list.Add(package);

                List<Ship> ship_list = new List<Ship>();
                Ship ship = new Ship();
                ship.SetOrder_id(OrderId);
                ship.SetCarrier_code(LogisticsCode);
                ship.SetCarrier_name(LogisticsName);
                ship.SetPackage_type("1");
                ship.SetPackages(package_list);
                ship_list.Add(ship);

                ShipResult rsp = client.ship(6480, ship_list);

                if (rsp != null)
                {
                    if (rsp.GetSuccess_num() > 0 && rsp.GetFail_num() == 0)
                    {
                        return rsp.GetSuccess_num().ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<IRecordErrorLogs>().WriteErrorLog("负责人:" + HozestERPContext.Current.User.CustomerID.ToString() + ";   方法名:GetVPHAPIDelivery;  异常提示：" + ex.Message.ToString() + ";   InnerException:" + ex.InnerException);
            }
            return null;
        }
    }
}
