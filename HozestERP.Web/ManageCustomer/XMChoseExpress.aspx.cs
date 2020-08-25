using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;
using Newtonsoft.Json.Linq;
using HozestERP.Web.SmsServiceReference;
using Top.Api;

namespace HozestERP.Web.ManageCustomer
{
    public partial class XMChoseExpress : BaseAdministrationPage, IEditPage
    {
        public List<int> IDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IDs = new List<int>();
                GetIDs();
                Session["DirectThermalPrint-Express"] = null;
                Session["DirectThermalPrint-Delivery"] = null;

                if (IDs.Count != 0)
                {
                    this.ddlExpressList.Items.Clear();
                    this.ddlExpressList.Items.Insert(0, new ListItem("顺丰速运", "505"));
                    this.ddlExpressList.Items.Insert(0, new ListItem("中国邮政", "1"));
                    this.ddlExpressList.Items.Insert(0, new ListItem("申通快递", "470"));
                    this.ddlExpressList.Items.Insert(0, new ListItem("中通快递", "500"));
                    this.ddlExpressList.Items.Insert(0, new ListItem("--- 请选择 ---", "-1"));
                }
                else
                {
                    base.ShowMessage("你没有选择任何记录！");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetIDs();
            string ExpressId = this.ddlExpressList.SelectedValue;

            if (IDs == null || IDs.Count == 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }

            if (ExpressId == "-1" || ExpressId == "")
            {
                base.ShowMessage("请先选择快递公司！");
                return;
            }

            if (type == 0)
            {
                ExpressDirectThermalPrint(IDs, ExpressId);
            }
            else if (type == 1)
            {
                DeliveryDirectThermalPrint(IDs, ExpressId);
            }
        }

        /// <summary>
        /// 快递管理热敏打印
        /// </summary>
        public void ExpressDirectThermalPrint(List<int> IDs, string ExpressId)
        {
            string emsCustomerCode = "";
            string printer = "";
            string cp_code = "";
            this.documentIDs.Value = "";
            StringBuilder t = new StringBuilder();
            List<XMExpressManagement> list = new List<XMExpressManagement>();
            List<int> UserIds = GetRoleMappingIds(HozestERPContext.Current.User.CustomerID);//该用户所拥有角色所包含的用户，及可操作的用户

            if (ExpressId == "1")//中国邮政
            {
                cp_code = "POSTB";
                printer = "Xprinter XP-DT108A LABEL";
                emsCustomerCode = "客户代码..90000009451762";
            }
            else if (ExpressId == "470")//申通快递
            {
                cp_code = "STO";
                //#region 根据登陆人判断使用哪个申通打印机
                ////var userName = HozestERPContext.Current.User.Username;//获取登陆人的登陆账号
                //var user = base.CustomerInfoService.GetCustomerInfoByID(HozestERPContext.Current.User.CustomerID);//获取登陆人的信息
                //if(user.SDepartment.DepName.Equals("眠集子公司"))
                    printer = "QR-586 LABEL";
                //else
                //    printer = "Gprinter  GP-1124D";
                //#endregion

            }
            else if (ExpressId == "505")//顺丰速运
            {
                cp_code = "SF";
                printer = "HPRT HLP106S";
            } 
            else if (ExpressId == "500")//中通快递
            {
                cp_code = "ZTO";
                printer = "KM-106 Printer";
            }

            var InfoList = base.XMExpressManagementService.GetXMExpressManagementByID(IDs);
            //foreach (int ID in IDs)
            foreach(var Info in InfoList)
            {
                //var Info = base.XMExpressManagementService.GetXMExpressManagementByID(ID);
                if (Info != null)
                {
                    if (Info.PrintCount > 0 && Info.ExpressID.ToString() != ExpressId)
                    {
                        base.ShowMessage("收件人：" + Info.ReceivingName + "，的快递单已用" + Info.ExpressName + "打印,请先取消该寄件单号！");
                        return;
                    }
                    if (Info.Price != null)
                    {
                        base.ShowMessage("收件人：" + Info.ReceivingName + "，的快递单已填写价格，不能打印！");
                        return;
                    }
                    if (!UserIds.Contains((int)Info.SenderID))
                    {
                        base.ShowMessage("收件人：" + Info.ReceivingName + "，的快递单,您没有权限打印！");
                        return;
                    }
                    list.Add(Info);
                }
            }

            string Template = base.XMOrderInfoAPIService.GetisvTemplates("1", cp_code);//获取商家的模板自定义区
            if (Template == "")
            {
                base.ShowMessage("获取申通电子面单模板失败！");
                return;
            }

            t.Append("{\"cmd\": \"print\",\"requetid\": \"" + DateTime.Now.ToString("yyMMddHHmmddfff") + "\",\"verson\": \"1.0\",");
            t.Append("\"task\": {\"taskID\": \"\",\"preview\": false,\"printer\": \"" + printer + "\",\"documents\":[");//preview：是否预览
            var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppByID(10);//天猫城市爱情旗舰店
            ITopClient client = new DefaultTopClient(XMOrderInfoAppList.ServerUrl, XMOrderInfoAppList.AppKey, XMOrderInfoAppList.AppSecret);
            //list.as
            foreach (XMExpressManagement Info in list)
            {
                string str = base.XMOrderInfoAPIService.GetCaiNiaoWaybilInfo(Info, cp_code, XMOrderInfoAppList, client);
                if (str == "")
                {
                    base.ShowMessage("收件人：" + Info.ReceivingName + "，的快递单获取物流服务商电子面单号失败！");
                    return;
                }
                else
                {
                    string waybill_code = str;
                    int a = str.IndexOf("<waybill_code>");
                    waybill_code = waybill_code.Substring(a, str.Length - a - 1);
                    int b = waybill_code.IndexOf("</waybill_code>");
                    waybill_code = waybill_code.Substring(0, b).Replace("<waybill_code>", "").Replace("</waybill_code>", "");

                    string print_data = str;
                    int c = str.IndexOf("<print_data>");
                    print_data = print_data.Substring(c, str.Length - c - 1);
                    int d = print_data.IndexOf("</print_data>");
                    print_data = print_data.Substring(0, d).Replace("<print_data>", "").Replace("</print_data>", "");

                    Info.ExpressID = int.Parse(ExpressId);
                    Info.CourierNumber = waybill_code;
                    Info.PrintCount = Info.PrintCount + 1;//打印次数
                    Info.PrintDate = DateTime.Now;//打印时间
                    Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDate = DateTime.Now;

                    t = GetJsonStr(t, print_data, Template, Info, emsCustomerCode);
                }
            }
            t.Append("]}}");

            Session["DirectThermalPrint-Express"] = list;
            JObject JsonStr = JObject.Parse(t.ToString());
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ExpressDirectThermalPrint", "<script>doSetPrinterConfig(" + JsonStr + ");</script>");
        }

        /// <summary>
        /// 发货单赠品热敏打印
        /// </summary>
        public void DeliveryDirectThermalPrint(List<int> IDs, string ExpressId)
        {
            string paramSign = "";//项目名称
            string paramWantId = "";//网名
            string paramMobile = "";//接收手机
            string paramLogisticsName = "";//快递名称
            string paramLogisticsNumber = "";//物流单号
            string paramContent = "";//包裹内容
            int paramMDeliveryDype = 0;
            string printer = "";
            string cp_code = "";
            string emsCustomerCode = "";
            this.documentIDs.Value = "";
            StringBuilder t = new StringBuilder();
            List<HozestERP.BusinessLogic.ManageProject.XMDelivery> list = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();

            if (ExpressId == "1")//中国邮政
            {
                cp_code = "POSTB";
                printer = "Xprinter XP-DT108A LABEL";
                emsCustomerCode = "客户代码..90000009451762";
            }
            else if (ExpressId == "470")//申通快递
            {
                cp_code = "STO";
                printer = "QR-586 LABEL";
            }
            else if (ExpressId == "505")//顺丰速运
            {
                cp_code = "SF";
                printer = "HPRT HLP106S";
            }
            else if (ExpressId == "500")//中通快递
            {
                cp_code = "ZTO";
                printer = "KM-106 Printer";
            }
            var deliverylist = base.XMDeliveryService.GetXMDeliveryByListIds(IDs);
            foreach(var delivery in deliverylist)
            //foreach (int ID in IDs)
            {
                //var delivery = base.XMDeliveryService.GetXMDeliveryById(ID);
                if (delivery != null)
                {
                    if (delivery.PrintQuantity > 0 && delivery.LogisticsId.ToString() != ExpressId)
                    {
                        base.ShowMessage("发货单号：" + delivery.DeliveryNumber + "，的快递单已用其他快递公司打印,请先取消该物流单号！");
                        return;
                    }
                    if (string.IsNullOrEmpty(delivery.Mobile) || string.IsNullOrEmpty(delivery.DeliveryAddress))
                    {
                        base.ShowMessage("发货单号：" + delivery.DeliveryNumber + "，的发货单的手机号或地址为空！");
                        return;
                    }
                    list.Add(delivery);
                }
            }

            string Template = base.XMOrderInfoAPIService.GetisvTemplates("1", cp_code);//获取商家的模板自定义区
            if (Template == "" || Template.IndexOf("http:") == -1)
            {
                base.ShowMessage("获取申通电子面单模板失败！");
                return;
            }

            t.Append("{\"cmd\": \"print\",\"requetid\": \"" + DateTime.Now.ToString("yyMMddHHmmddfff") + "\",\"verson\": \"1.0\",");
            t.Append("\"task\": {\"taskID\": \"\",\"preview\": false,\"printer\": \"" + printer + "\",\"documents\":[");//preview：是否预览

            //打印批次
            int PrintBatch = 1;
            //取发货单表中 打印批次倒序最后条
            var xMDeliveryListByPrintBatch = base.XMDeliveryService.GetFirstXMDelivery();
            if (xMDeliveryListByPrintBatch != null)
            {
                if (xMDeliveryListByPrintBatch.PrintBatch != null)
                {
                    PrintBatch = xMDeliveryListByPrintBatch.PrintBatch.Value + 1;
                }
            }
            var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppByID(10);//天猫城市爱情旗舰店
            ITopClient client = new DefaultTopClient(XMOrderInfoAppList.ServerUrl, XMOrderInfoAppList.AppKey, XMOrderInfoAppList.AppSecret);
            #region 先判断库存
            var isInventList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
            foreach (HozestERP.BusinessLogic.ManageProject.XMDelivery Info in list)
            {
                bool isInventLess = false;
                string errMessage = "";
                    //根据发货单ID  查询进销存系统销售出库单记录  更新出库状态  更新库存信息
                    List<SaleDeliveryProduct> List = new List<SaleDeliveryProduct>();
                    var saleDeliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryListByParm(Info.Id);
                    if (saleDeliveryInfo != null && saleDeliveryInfo.Count > 0)
                    {
                        foreach (var info in saleDeliveryInfo)
                        {
                            var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(info.Id);
                            if (saleDelivery != null)
                            {
                                var saleDeliveryDetail = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(saleDelivery.Id);
                                if (saleDeliveryDetail != null && saleDeliveryDetail.Count > 0)
                                {
                                    foreach (XMSaleDeliveryProductDetails parm in saleDeliveryDetail)
                                    {
                                        SaleDeliveryProduct list2 = new SaleDeliveryProduct();
                                        list2.pcode = parm.PlatformMerchantCode;
                                        list2.saleDeliveryCount = parm.SaleCount.Value;
                                        list2.wareHoueseID = saleDelivery.WareHouseId;
                                        List.Add(list2);
                                    }
                                }
                            }
                        }
                    }
                    if (List != null && List.Count > 0)
                    {
                        var List2 = from l in List
                                    group l by new { l.pcode, l.wareHoueseID } into g
                                    select new
                                    {
                                        pcode = g.Key.pcode,
                                        wareHoueseID = g.Key.wareHoueseID,
                                        saleDeliveryCount = g.Sum(a => a.saleDeliveryCount)
                                    };

                        if (List2 != null && List2.Count() > 0)
                        {
                            foreach (var parm in List2)
                            {
                                var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(parm.pcode, parm.wareHoueseID);
                                if (inventInfo == null)
                                {
                                    isInventLess = true;      //库存不足
                                    errMessage = errMessage + parm.pcode + ";";
                                    break;
                                }
                                else
                                {
                                    if (inventInfo.StockNumber == null)
                                    {
                                        isInventLess = true;      //库存不足
                                        errMessage = errMessage + parm.pcode + ";";
                                        break;
                                    }
                                    else
                                    {
                                        if (inventInfo.StockNumber == 0 || inventInfo.StockNumber < 0 || (inventInfo.StockNumber > 0 && inventInfo.StockNumber < parm.saleDeliveryCount))
                                        {
                                            isInventLess = true;      //库存不足
                                            errMessage = errMessage + parm.pcode + ";";
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (isInventLess)                //库存不足
                    {
                        base.ShowMessage("出库单号为：" + errMessage + "库存不足，无法出库！");
                        //return;
                    }
                    else                          //库存充足  减掉库存
                    {
                        isInventList.Add(Info);//库存充足的获取运单号
                        if (saleDeliveryInfo != null && saleDeliveryInfo.Count > 0)
                        {
                            paramContent = "";//重置包裹内容
                            foreach (var info in saleDeliveryInfo)
                            {
                                if (info.BillStatus == 0)
                                {
                                    info.BillStatus = 1000;
                                    info.UpdateDate = DateTime.Now;
                                    info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    base.XMSaleDeliveryService.UpdateXMSaleDelivery(info);
                                    //更新产品库存表（减掉出库数量）
                                    var deliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(info.Id);
                                    if (deliveryProductDetails != null && deliveryProductDetails.Count > 0)
                                    {
                                        foreach (XMSaleDeliveryProductDetails parm in deliveryProductDetails)
                                        {
                                            string code = parm.PlatformMerchantCode;              //商品编码
                                            int wfID = info.WareHouseId;                              //出库仓库ID
                                            var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, wfID);
                                            if (InventoryInfo != null)                             //商品编码为code的产品在库存表中已经存在 更新库存数量
                                            {
                                                InventoryInfo.StockNumber = InventoryInfo.StockNumber - parm.SaleCount;             //库存减掉出库量
                                                InventoryInfo.CanOrderCount = InventoryInfo.StockNumber;
                                                InventoryInfo.UpdateDate = DateTime.Now;
                                                InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
                                                paramContent += parm.ProductName + "+";
                                            }
                                            //更新库存总账主表数据   从表添加一条记录
                                            UpdateInventoryLederInfo(info.WareHouseId, parm);
                                        }
                                    }
                                }
                                if ((info.ProjectId == 5 || info.ProjectId == 22) && paramMDeliveryDype == 481)//曲美、伊丽丝项目
                                {
                                    if (paramContent.Length > 0)
                                    {
                                        paramContent = paramContent.Substring(0, paramContent.Length - 1);
                                    }
                                    bool SendReturn = this.UseSensSms(paramSign, paramWantId, paramMobile, paramLogisticsName, paramLogisticsNumber, paramContent);
                                    if (!SendReturn)
                                    {
                                        throw new Exception("短信发送失败,物流单号：" + paramLogisticsNumber + "，请联系管理员");
                                    }
                                }
                            }
                        }
                }
            }
            #endregion
            foreach (HozestERP.BusinessLogic.ManageProject.XMDelivery Info in isInventList)
            {
                string str = base.XMOrderInfoAPIService.GetCaiNiaoWaybilInfo(Info, cp_code, XMOrderInfoAppList, client);
                if (str == "")
                {
                    base.ShowMessage("发货单号：" + Info.DeliveryNumber + "，的发货单获取物流服务商电子面单号失败！");
                    return;
                }
                else
                {
                    string OrderCode = Info.OrderCode;
                    string PremiumsInfo = "";
                    string IsInvoiced = "无";
                    string waybill_code = str;
                    string remark = Info.OrderRemarks;
                    int a = str.IndexOf("<waybill_code>");
                    waybill_code = waybill_code.Substring(a, str.Length - a - 1);
                    int b = waybill_code.IndexOf("</waybill_code>");
                    waybill_code = waybill_code.Substring(0, b).Replace("<waybill_code>", "").Replace("</waybill_code>", "");
                    string print_data = str;
                    int c = str.IndexOf("<print_data>");
                    print_data = print_data.Substring(c, str.Length - c - 1);
                    int d = print_data.IndexOf("</print_data>");
                    print_data = print_data.Substring(0, d).Replace("<print_data>", "").Replace("</print_data>", "");
                    var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);


                    //物流单号，物流公司
                    Info.LogisticsId = int.Parse(ExpressId);
                    Info.LogisticsNumber = waybill_code;
                    //Info.IsDelivery = true;
                    Info.PrintQuantity = Info.PrintQuantity == null ? 1 : Info.PrintQuantity + 1;//打印次数
                    Info.PrintBatch = PrintBatch;
                    Info.PrintDateTime = DateTime.Now;//打印时间
                    Info.UpdateId = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDate = DateTime.Now;

                    if (OrderInfo != null && OrderInfo.IsInvoiced != null && OrderInfo.IsInvoiced == true)
                    {
                        IsInvoiced = "有";
                    }

                    var XMDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(Info.Id);
                    if (XMDeliveryDetailsList != null && XMDeliveryDetailsList.Count > 0)
                    {
                        foreach (var item in XMDeliveryDetailsList)
                        {
                            if (PremiumsInfo == "")
                            {
                                PremiumsInfo = item.PrdouctName + "(" + item.Specifications + ")" + " * " + item.ProductNum;
                            }
                            else
                            {
                                PremiumsInfo += "，" + item.PrdouctName + "(" + item.Specifications + ")" + " * " + item.ProductNum;
                            }
                        }
                    }
                    t = GetJsonStr(t, print_data, Template, PremiumsInfo, OrderCode, remark, IsInvoiced, emsCustomerCode, Info);
                    //发送短信参数
                    paramLogisticsName = Info.ExpressName;
                    paramLogisticsNumber = Info.LogisticsNumber;
                    paramSign = Info.NickName;
                    paramWantId = Info.WantID;
                    paramMobile = Info.Mobile;
                    paramMDeliveryDype = int.Parse(Info.DeliveryTypeId.ToString());
                }
            }
            t.Append("]}}");
            var count = base.XMDeliveryService.UpdateXMDelivery(isInventList);
            if (count > 0)
            {
                Session["DirectThermalPrint-Delivery"] = list;
                JObject JsonStr = JObject.Parse(t.ToString());
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "DeliveryDirectThermalPrint", "<script>doSetPrinterConfig(" + JsonStr + ");</script>");
            }
        }
      
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="paraSign"></param>
        /// <param name="paramWantId"></param>
        /// <param name="paramMobile"></param>
        /// <param name="paramLogisticsName"></param>
        /// <param name="paramLogisticsNumber"></param>
        /// <param name="paramContent"></param>
        /// <returns></returns>
        public bool UseSensSms(string paraSign, string paramWantId, string paramMobile, string paramLogisticsName, string paramLogisticsNumber, string paramContent)
        {
            bool SensSuss = false;
            HozestERP.Web.SmsServiceReference.SmsServicesClient UseSmsServicesClient = new SmsServicesClient();
            HozestERP.Web.SmsServiceReference.smsResult UsesmsResult = UseSmsServicesClient.sendSms("bjanyx3_v2", "666666", paramWantId + "亲，您的包裹：" + paramContent + "已由" + paramLogisticsName + "发出，快递单号：" + paramLogisticsNumber, paraSign, paramMobile, "");
            int paranReturn = UsesmsResult.result;
            if (paranReturn == 0)
            {
                SensSuss = true;
            }
            return SensSuss;

        }

        private void UpdateInventoryLederInfo(int wareHousesId, XMSaleDeliveryProductDetails info)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, info.PlatformMerchantCode);
            if (inventoryLeder != null)//更新数据
            {
                //更新出库数量
                inventoryLeder.OutCount = (inventoryLeder.OutCount == null ? 0 : inventoryLeder.OutCount) + info.SaleCount;
                inventoryLeder.OutPrice = 0;
                inventoryLeder.OutMoney = 0;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.WarehouseId = wareHousesId;
                inventoryLederInfo.ProductId = info.ProductId;
                inventoryLederInfo.PlatformMerchantCode = info.PlatformMerchantCode;
                inventoryLederInfo.OutCount = info.SaleCount;
                inventoryLederInfo.OutPrice = 0;
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.InCount = 0;
                inventoryLederInfo.InPrice = info.ProductPrice;
                inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                inventoryLederInfo.AfloatCount = 0;
                inventoryLederInfo.AfloatPrice = info.ProductPrice;
                inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(出库)
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, info.PlatformMerchantCode);
            decimal price = 0;
            decimal money = 0;
            XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
            details.WarehouseId = wareHousesId;
            details.ProductId = info.ProductId;
            details.PlatformMerchantCode = info.PlatformMerchantCode;
            details.OutCount = info.SaleCount;
            details.OutPrice = 0;
            details.OutMoney = info.SaleCount * info.ProductPrice;
            details.InCount = 0;
            details.InPrice = price;
            details.InMoney = money;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                details.BalanceCount = BalanceCount - details.OutCount;
            }
            else
            {
                details.BalanceCount = 0;
            }
            details.BalancePrice = info.ProductPrice;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            var saleDeliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryById(info.SaleDeliveryId);
            if (saleDeliveryInfo != null)
            {
                details.RefNumber = saleDeliveryInfo.Ref;
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1002; //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
        }

        public StringBuilder GetJsonStr(StringBuilder t, string print_data, string Template, XMExpressManagement Info, string emsCustomerCode)
        {
            string no = DateTime.Now.ToString("yyMMddHHmmddfff") + Info.CourierNumber;
            if (t.ToString().IndexOf("documentID") != -1)
            {
                t.Append(",");//多个电子面单
                this.documentIDs.Value += "," + no;
            }
            else
            {
                this.documentIDs.Value = no;
            }

            t.Append("{\"documentID\": \"" + no + "\",\"contents\": ["
                + print_data);
            t.Append(",{\"templateURL\": \"" + Template + "\",  \"data\": { \"premiumsInfo\": \"内  件：" + Info.Goods + "\"");
            t.Append(",\"orderCode\": \"" + "" + "\"");
            t.Append(",\"emsCustomerCode\": \"" + emsCustomerCode + "\"");
            t.Append(",\"isInvoiced\": \"" + "" + "\"");
            t.Append("}}]}");

            return t;
        }

        public StringBuilder GetJsonStr(StringBuilder t, string print_data, string Template, string PremiumsInfo, string OrderCode,string remark, string IsInvoiced, string emsCustomerCode, HozestERP.BusinessLogic.ManageProject.XMDelivery Info)
        {
            string no = DateTime.Now.ToString("yyMMddHHmmddfff") + Info.DeliveryNumber;
            if (t.ToString().IndexOf("documentID") != -1)
            {
                t.Append(",");//多个电子面单
                this.documentIDs.Value += "," + no;
            }
            else
            {
                this.documentIDs.Value = no;
            }

            t.Append("{\"documentID\": \"" + no + "\",\"contents\": ["
                + print_data);
            t.Append(",{\"templateURL\": \"" + Template + "\",  \"data\": { \"premiumsInfo\": \"内  件：" + PremiumsInfo + "\"");
            t.Append(",\"orderCode\": \"订单号：" + OrderCode + "\"");
            t.Append(",\"remark\": \"备注：" + remark + "\"");
            t.Append(",\"emsCustomerCode\": \"" + emsCustomerCode + "\"");
            t.Append(",\"isInvoiced\": \"发  票：" + IsInvoiced + "\"");
            t.Append("}}]}");

            return t;
        }

        public void GetIDs()
        {
            if (type == 0 && Session["XMChoseExpress-XMExpressManageList"] != null)
            {
                IDs = (List<int>)Session["XMChoseExpress-XMExpressManageList"];
            }
            else if (type == 1 && Session["XMChoseExpress-XMDelivery"] != null)
            {
                IDs = (List<int>)Session["XMChoseExpress-XMDelivery"];
            }
        }

        public int type
        {
            get
            {
                return CommonHelper.QueryStringInt("type");
            }
        }

        /// <summary>
        /// 该角色下的包含用户
        /// </summary>
        /// <returns></returns>
        public List<int> GetRoleMappingIds(int UserId)
        {
            List<int> Ids = new List<int>();
            Ids.Add(UserId);
            var Roles = base.CustomerService.GetCustomerRolesByCustomerId(UserId);
            if (Roles != null && Roles.Count > 0)
            {
                foreach (var role in Roles)
                {
                    var ids = base.CustomerService.GetCustomerInfosByRoleID(role.CustomerRoleID);
                    if (ids != null && ids.Count > 0)
                    {
                        Ids.AddRange(ids.Select(x => x.CustomerID).ToList());
                    }
                }
            }
            return Ids.Distinct().ToList();
        }

        #region

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        #endregion
    }
}