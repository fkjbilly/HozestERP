using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;
using vipapis.delivery;

namespace HozestERP.BusinessLogic.ManageProject
{
    public class XMDeliveryImportDeliver
    {
        public string XMDelivery_ImportDeliver(string Shop, XMDelivery One, string LogisticsName)
        {
            string msg = "";
            bool pass = false;
            var XMOrderInfoAppList = IoC.Resolve<IXMOrderInfoAppService>().GetXMOrderInfoAppList();
            var xMOrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoListByOrderEqs(One.OrderCode);

            XMOrderInfoApp xMorderInfoApp = new XMOrderInfoApp();
            if (xMOrderInfo != null && xMOrderInfo.Count > 0)
            {
                for (int i = 0; i < XMOrderInfoAppList.Count; i++)
                {
                    if (XMOrderInfoAppList[i].PlatformTypeId == xMOrderInfo[0].PlatformTypeId && XMOrderInfoAppList[i].NickId == xMOrderInfo[0].NickID)
                    {
                        xMorderInfoApp = XMOrderInfoAppList[i];
                        break;
                    }
                }

                if (xMorderInfoApp != null)
                {
                    if (One.LogisticsNumber != null && One.LogisticsId != null)
                    {
                        //京东
                        if (Shop.IndexOf("京东") != -1)
                        {
                            pass = JingDong(One, xMorderInfoApp, xMOrderInfo[0]);
                            if (!pass)
                            {
                                msg = "订单：" + xMOrderInfo[0].OrderCode.ToString() + "，发货失败！\r";
                            }
                        }
                        //天猫
                        else if (Shop.IndexOf("天猫") != -1)
                        {
                            pass = TM(One, xMorderInfoApp, xMOrderInfo[0]);
                            if (!pass)
                            {
                                msg = "订单：" + xMOrderInfo[0].OrderCode.ToString() + "，发货失败！\r";
                            }
                        }
                        //苏宁易购
                        else if (Shop.IndexOf("苏宁易购") != -1)
                        {
                            pass = SuNing(One, xMorderInfoApp, xMOrderInfo[0]);
                            if (!pass)
                            {
                                msg = "订单：" + xMOrderInfo[0].OrderCode.ToString() + "，发货失败！\r";
                            }
                        }
                        //一号店
                        else if (Shop.IndexOf("一号店") != -1)
                        {
                            pass = YHD(One, xMorderInfoApp, xMOrderInfo[0]);
                            if (!pass)
                            {
                                msg = "订单：" + xMOrderInfo[0].OrderCode.ToString() + "，发货失败！\r";
                            }
                        }
                        //唯品会
                        else if (Shop.IndexOf("唯品会") != -1)
                        {
                            pass = VPH(One, xMorderInfoApp, xMOrderInfo[0], LogisticsName);
                            if (!pass)
                            {
                                msg = "订单：" + xMOrderInfo[0].OrderCode.ToString() + "，发货失败！\r";
                            }
                        }
                        else
                        {
                            DeleteDelivery(One);
                        }

                    }
                    else
                    {
                        msg = "订单：" + xMOrderInfo[0].OrderCode.ToString() + "，物流单号，物流公司不能为空！\r";
                    }
                }
                else
                {
                    msg = "京东appkey、appSecret、sessionKey 不能为空！\r";
                }
            }
            else
            {
                msg = "订单：" + xMOrderInfo[0].OrderCode.ToString() + "，在订单表中不存在！\r";
            }

            return msg;
        }
            

        public bool JingDong(XMDelivery One, XMOrderInfoApp xMorderInfoApp, XMOrderInfo xMOrderInfo)
        {
            bool Succed = false;
            string Waybill = One.LogisticsNumber;
            if (Waybill == "")
            {
                Waybill = null;
            }
            int paramLogisticsId = int.Parse(One.LogisticsId.ToString());
            if (One.LogisticsId == 1)
            {
                paramLogisticsId = 2170;
            }
            if (One.LogisticsId == 500 || One.LogisticsId == 1499) //中通速递
            {
                paramLogisticsId = 1499;
            } if (One.LogisticsId == 3049) //德邦速递
            {
                paramLogisticsId = 3049;
            }
            var outstorage = IoC.Resolve<IXMOrderInfoAPIService>().GetOutstorage(One.OrderCode, paramLogisticsId.ToString(), Waybill, xMorderInfoApp);
            if (outstorage != null)
            {
                if (!outstorage.IsError)
                {
                    UpdateDelivery(One, xMOrderInfo, DateTime.Now.ToString());
                    Succed = true;
                }
                else
                {
                    //DeleteDelivery(One);
                }
            }
            else
            {
                //DeleteDelivery(One);
            }
            return Succed;
        }

        public bool TM(XMDelivery One, XMOrderInfoApp xMorderInfoApp, XMOrderInfo xMOrderInfo)
        {
            bool Succed = false;
            string Waybill = One.LogisticsNumber;
            if (Waybill == "")
            {
                Waybill = null;
            }
            var ModifiedDate = IoC.Resolve<XMDeliveryImportDeliverAPI>().GetTMAPIDelivery(One.OrderCode, One.LogisticsCode, Waybill, xMorderInfoApp);
            if (ModifiedDate != null)
            {
                UpdateDelivery(One, xMOrderInfo, ModifiedDate);
                Succed = true;
            }
            else
            {
                //DeleteDelivery(One);
            }
            return Succed;
        }

        public bool SuNing(XMDelivery One, XMOrderInfoApp xMorderInfoApp, XMOrderInfo xMOrderInfo)
        {
            bool Succed = false;
            string Waybill = One.LogisticsNumber;
            if (Waybill == "")
            {
                Waybill = null;
            }
            var ModifiedDate = IoC.Resolve<XMDeliveryImportDeliverAPI>().GetSuNingAPIDelivery(One.OrderCode, One.LogisticsCode, Waybill, xMorderInfoApp);
            if (ModifiedDate != null)
            {
                UpdateDelivery(One, xMOrderInfo, DateTime.Now.ToString());
                Succed = true;
            }
            else
            {
                //DeleteDelivery(One);
            }
            return Succed;
        }

        public bool YHD(XMDelivery One, XMOrderInfoApp xMorderInfoApp, XMOrderInfo xMOrderInfo)
        {
            bool Succed = false;
            string Waybill = One.LogisticsNumber;
            if (Waybill == "")
            {
                Waybill = null;
            }
            var UpdateCount = IoC.Resolve<XMDeliveryImportDeliverAPI>().GetYHDAPIDelivery(One.OrderCode, One.LogisticsId.ToString(), Waybill, xMorderInfoApp);
            if (UpdateCount != null)
            {
                UpdateDelivery(One, xMOrderInfo, DateTime.Now.ToString());
                Succed = true;
            }
            else
            {
                //DeleteDelivery(One);
            }
            return Succed;
        }

        public bool VPH(XMDelivery One, XMOrderInfoApp xMorderInfoApp, XMOrderInfo xMOrderInfo, string LogisticsName)
        {
            bool Succed = false;
            string Waybill = One.LogisticsNumber;
            if (Waybill == "")
            {
                Waybill = null;
            }
            var Success_num = IoC.Resolve<XMDeliveryImportDeliverAPI>().GetVPHAPIDelivery(One.OrderCode, One.LogisticsId.ToString(), Waybill, xMorderInfoApp, LogisticsName);
            if (Success_num != null)
            {
                UpdateDelivery(One, xMOrderInfo, DateTime.Now.ToString());
                Succed = true;
            }
            else
            {
                //DeleteDelivery(One);
            }
            return Succed;
        }


        public void DeleteDelivery(XMDelivery One)
        {
            One.IsEnabled = true;
            One.UpdateDate = DateTime.Now;
            One.UpdateId = HozestERPContext.Current.User.CustomerID;
            IoC.Resolve<IXMDeliveryService>().UpdateXMDelivery(One);

            var Deatil = IoC.Resolve<IXMDeliveryDetailsService>().GetXMDeliveryDetailsByDeliveryId(One.Id);
            if (Deatil != null && Deatil.Count > 0)
            {
                foreach (XMDeliveryDetails info in Deatil)
                {
                    info.IsEnabled = true;
                    info.UpdateDate = DateTime.Now;
                    info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    IoC.Resolve<IXMDeliveryDetailsService>().UpdateXMDeliveryDetails(info);
                }
            }
        }

        public void UpdateDelivery(XMDelivery One, XMOrderInfo xMOrderInfo, string date)
        {
            xMOrderInfo.DeliveryTime = Convert.ToDateTime(date);//修改出库时间
            xMOrderInfo.OrderStatus = "WAIT_GOODS_RECEIVE_CONFIRM";
            xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
            xMOrderInfo.UpdateDate = DateTime.Now;
            IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xMOrderInfo);

            //修改发货单 是否发货状态
            One.IsDelivery = true;//已发货
            One.UpdateDate = DateTime.Now;
            One.UpdateId = HozestERPContext.Current.User.CustomerID;
            IoC.Resolve<IXMDeliveryService>().UpdateXMDelivery(One);
        }
    }
}
