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
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderInfoSaleDelivery : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SaveOrderInfoIDs"] != null)
                {
                    List<int> Ids = new List<int>();
                    string msg = "";
                    string[] DeliveryStatue = { "WAIT_SELLER_SEND_GOODS", "DS_WAIT_SELLER_DELIVERY", "WAIT_SELLER_DELIVERY", "WAIT_SELLER_STOCK_OUT",
                                  "STATUS_10", "ORDER_TRUNED_TO_DO", "以接受", "10","WAIT_BUYER_CONFIRM_GOODS","WAIT_GOODS_RECEIVE_CONFIRM","STATUS_22","ORDER_OUT_OF_WH","已发货","20","DS_WAIT_BUYER_RECEIVE" ,
                                  "TRADE_FINISHED", "FINISHED_L","STATUS_25", "ORDER_FINISH" , "新","30","DS_DEAL_END_NORMAL" };
                    string[] IDs = (string[])Session["SaveOrderInfoIDs"];
                    if (IDs.Count() > 0)
                    {
                        foreach (var ID in IDs)
                        {
                            Ids.Add(int.Parse(ID));
                        }
                    }
                    else
                    {
                        base.ShowMessage("你没有选择任何记录！");
                        return;
                    }

                    var list = base.XMOrderInfoService.GetXMOrderInfoListByIds(Ids);
                    if (list != null && list.Count > 0)
                    {
                        var ProjectCount = list.Select(x => x.ProjectId).Distinct().ToList();
                        if (ProjectCount.Count > 1)
                        {
                            base.ShowMessage("所选订单必须属于同一个项目！");
                            return;
                        }

                        foreach (var info in list)
                        {
                            if (info.IsAudit != null && (bool)info.IsAudit)
                            {
                                msg += "订单号：" + info.OrderCode + "，已审核，不能生成出库单！<br/>";
                                continue;
                            }
                            if (!(bool)info.FinancialAudit)
                            {
                                msg += "订单号：" + info.OrderCode + "，财务审核还未通过，不能生成出库单！<br/>";
                                continue;
                            }
                            if (!DeliveryStatue.Contains(info.OrderStatus))
                            {
                                msg += "订单号：" + info.OrderCode + "，不是待发货状态或已发货状态或已完成状态，不能生成出库单！<br/>";
                                continue;
                            }
                        }

                        if (msg != "")
                        {
                            base.ShowMessage(msg);
                            return;
                        }
                        else
                        {
                            var project = base.XMNickService.GetProjectNameByID((int)list[0].NickID);
                            if (project != null)
                            {
                                var WareList = base.XMWareHousesService.GetXMWarehouseListByProjectId(project.Id);
                                this.ddlWareHourses.Items.Clear();
                                this.ddlWareHourses.DataSource = WareList;
                                this.ddlWareHourses.DataTextField = "Name";
                                this.ddlWareHourses.DataValueField = "Id";
                                this.ddlWareHourses.DataBind();
                                this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
                            }
                        }
                    }
                }
                else
                {
                    base.ShowMessage("你没有选择任何记录！");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "";
            bool isExist = false;
            string errMessage = "";
            List<int> Ids = new List<int>();
            string WareHourses = this.ddlWareHourses.SelectedValue;
            if (Session["SaveOrderInfoIDs"] != null)
            {
                string[] IDs = (string[])Session["SaveOrderInfoIDs"];
                if (IDs.Count() > 0)
                {
                    foreach (var ID in IDs)
                    {
                        Ids.Add(int.Parse(ID));
                    }
                }
            }

            if (WareHourses == "-1" || WareHourses == "")
            {
                base.ShowMessage("请先选择出库仓库！");
                return;
            }

            var list = base.XMOrderInfoService.GetXMOrderInfoListByIds(Ids);
            if (list != null && list.Count > 0)
            {
                foreach (var info in list)
                {
                    var saleDeliverys = base.XMSaleDeliveryService.GetXMSaleDeliveryListByOrderInfoID(info.ID);
                    if (saleDeliverys != null && saleDeliverys.Count > 0)
                    {
                        isExist = true;
                        errMessage = errMessage + " " + info.OrderCode;
                        break;
                    }
                }
            }
            //订单对应的出库单已经存在，无法再次生成出库单
            if (isExist)
            {
                base.ShowMessage("订单号为：" + errMessage + "的订单出库单已经存在，操作失败！");
                return;
            }


            if (list != null && list.Count > 0)
            {
                foreach (var info in list)
                {
                    bool OldValue = info.IsAudit == null ? false : (bool)info.IsAudit;
                    if (info.IsAudit != null && (bool)info.IsAudit)
                    {
                        msg += "订单号：" + info.OrderCode + "，已审核，不能生成出库单！<br/>";
                        continue;
                    }

                    decimal Total = 0;
                    XMSaleDelivery Item = new XMSaleDelivery();
                    Item.XM_SaleDeliveryProductDetails = new List<XMSaleDeliveryProductDetails>();
                    foreach (var detail in info.XM_OrderInfoProductDetails)
                    {
                        XMSaleDeliveryProductDetails details = new XMSaleDeliveryProductDetails();
                        var productDetail = base.XMProductService.GetXMProductListByPlatformMerchantCode(detail.PlatformMerchantCode, (int)info.PlatformTypeId);
                        details.SaleCount = detail.ProductNum;
                        if (productDetail != null && productDetail.Count > 0)
                        {
                            var product = base.XMProductService.GetXMProductById(productDetail[0].ProductId.Value);
                            if (product != null)
                            {
                                details.PlatformMerchantCode = product.ManufacturersCode;
                                details.ProductId = product.Id;
                            }
                            details.ProductPrice = productDetail[0].Saleprice;
                            details.ProductMoney = details.ProductPrice * details.SaleCount;
                        }
                        Total += details.ProductMoney == null ? 0 : (decimal)details.ProductMoney;
                        details.IsEnable = false;
                        details.UpdateDate = details.CreateDate = DateTime.Now;
                        details.UpdateID = details.CreateID = HozestERPContext.Current.User.CustomerID;
                        Item.XM_SaleDeliveryProductDetails.Add(details);
                    }

                    Item.Ref = AutoSaleDeliveryNumber();
                    Item.SaleInfoId = 0;
                    Item.OrderInfoID = info.ID;
                    Item.WareHouseId = int.Parse(WareHourses);
                    Item.BillStatus = 0;
                    Item.SaleMoney = Total;
                    Item.ReceivingType = 701;//支付宝
                    Item.Remarks = info.CustomerServiceRemark;
                    Item.BizUserId = HozestERPContext.Current.User.CustomerID;
                    Item.BizDt = DateTime.Now;
                    Item.IsEnable = false;
                    Item.IsAudit = false;
                    Item.UpdateDate = Item.CreateDate = DateTime.Now;
                    Item.UpdateID = Item.CreateID = HozestERPContext.Current.User.CustomerID;
                    base.XMSaleDeliveryService.InsertXMSaleDelivery(Item);

                    base.ShowMessage("保存成功！");

                    #region 修改审核状态

                    foreach (XMOrderInfoProductDetails xmpd in info.XM_OrderInfoProductDetails)
                    {
                        xmpd.IsAudit = true;
                        xmpd.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xmpd.UpdateDate = DateTime.Now;
                    }
                    info.IsAudit = true;
                    info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    info.UpdateDate = DateTime.Now;
                    base.XMOrderInfoService.UpdateXMOrderInfo(info);//修改审核状态

                    //操作记录
                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                    record.PropertyName = "生成出库单-自动审核";
                    record.OldValue = System.Convert.ToString(OldValue);
                    record.NewValue = System.Convert.ToString(true);
                    record.OrderInfoId = info.ID;
                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    record.UpdateTime = DateTime.Now;
                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);

                    #endregion
                }

                if (msg != "")
                {
                    base.ShowMessage(msg);
                    return;
                }
            }
        }

        private string AutoSaleDeliveryNumber()
        {
            string SaleDeliveryCode = "";       //自动生成销售出货单号
            int number = 1;
            var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryList();
            if (saleDelivery != null && saleDelivery.Count > 0)
            {
                number = saleDelivery[0].Id + 1;
            }
            SaleDeliveryCode = "SD" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return SaleDeliveryCode;
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