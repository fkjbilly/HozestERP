using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManageApplication
{
    public partial class ApplicationSaleDelivery : BaseAdministrationPage, IEditPage
    {
        private static List<int> Ids = new List<int>();
        public void Face_Init()
        {
            var wareHoueseList = base.XMWareHousesService.GetXMWareHousesList();
            this.ddlWareHourses.Items.Clear();
            this.ddlWareHourses.DataSource = wareHoueseList;
            this.ddlWareHourses.DataTextField = "Name";
            this.ddlWareHourses.DataValueField = "Id";
            this.ddlWareHourses.DataBind();
            this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        public void SetTrigger()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ids.Clear();
                if (Session["SaveReturnIDs"] != null)
                {
                    string[] IDs = (string[])Session["SaveReturnIDs"];
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
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<XMApplication> XMApplicationList = new List<XMApplication>();
            List<int> AddIDs = new List<int>();
            string WareHourses = this.ddlWareHourses.SelectedValue;
            bool AddToDelivery = this.chkAddToDelivery.Checked;

            if (Ids.Count() <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
            }

            if (WareHourses == "-1" || WareHourses == "")
            {
                base.ShowMessage("请先选择出库仓库！");
                return;
            }

            if (AddToDelivery)
            {
                string msg = "";
                XMApplicationList = XMApplicationService.GetXMApplicationListByIds(Ids);
                foreach(var item in XMApplicationList)
                {
                    if (!item.OrderCode.StartsWith("NoOrder"))
                    {
                        var DeliveryList = base.XMDeliveryService.GetXMDeliveryListByOrderCode(item.OrderCode, 708);
                        if (DeliveryList != null && DeliveryList.Count > 0)
                        {
                            AddIDs.Add(item.ID);
                        }
                        else
                        {
                            msg += "订单号：" + item.OrderCode + "的换货，未生成正式发货单，不能追加！<br/>";
                        }
                    }

                }

                if (msg != "")
                {
                    base.ShowMessage(msg);
                    return;
                }
            }

            SingleRow(Ids, WareHourses, AddIDs);//排单

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

        private void SingleRow(List<int> Ids, string WareHoursesID, List<int> AddIDs)
        {
            //查询所有选中的退换货信息
            var XMApplicationList = XMApplicationService.GetXMApplicationListByIds(Ids);

            var NoPassList = XMApplicationList.Where(a =>a.IsSend==false||a.SupervisorStatus==false||a.IsSingleRow==true).ToList();
            if (NoPassList.Count > 0)
            {
                base.ShowMessage("请选择已送出，已审核，未排单的数据！");
                return;
            }

            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                bool isSucess = true;
                string errMessage = "";
                foreach (var item in Ids)
                {
                    bool isEnough = true;
                    XMApplication XMApplicationEntity = XMApplicationList.Where(a => a.ID == item).SingleOrDefault();
                    if(XMApplicationEntity != null)
                    {
                        int xmDeliveryID = 1;
                        //var xmorderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(XMApplicationEntity.OrderCode);//订单号查询订单
                        if(XMApplicationEntity.IsSingleRow!=null&&(bool)XMApplicationEntity.IsSingleRow)
                        {
                            base.ShowMessage("订单" + XMApplicationEntity.OrderCode + "已排单！");
                            return;
                        }
                        //查询换货明细
                        List<XMApplicationExchange> list = XMApplicationExchangeService.GetXMApplicationExchangeListByApplicationIDType(XMApplicationEntity.ID,1);
                        if(list.Count<=0)
                        {
                            base.ShowMessage("订单"+ XMApplicationEntity .OrderCode+ "无换货明细数据！");
                            return;
                        }
                        
                        foreach(var entity in list)
                        {
                            int totalInventCount = 0;    //总库存数量
                            int canInventCount = 0;   //可用库存

                            string ManufacturersCode = "";
                            if (!string.IsNullOrEmpty(entity.PlatformMerchantCode))
                            {
                                var productDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(entity.PlatformMerchantCode, (int)XMApplicationEntity.PlatformTypeId);
                                if (productDetail.Count > 0)
                                {
                                    ManufacturersCode = productDetail[0].ManufacturersCode;
                                }
                            }
                            if (string.IsNullOrEmpty(ManufacturersCode))
                            {
                                isSucess = false;
                                break;
                            }
                            //获取该产品对应仓库的实际库存数量
                            var inventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(ManufacturersCode, int.Parse(WareHoursesID));
                            if (inventoryInfo != null)
                            {
                                totalInventCount = inventoryInfo.StockNumber.Value;
                            }
                            if (totalInventCount != 0)          //存在库存
                            {
                                //canInventCount = totalInventCount - outCount;
                                canInventCount = int.Parse(inventoryInfo.CanOrderCount.ToString());
                                if (canInventCount < entity.ProductNum)             //剩余库存不足
                                {
                                    errMessage = errMessage + "商品编码为：" + entity.PlatformMerchantCode + " ";
                                    isEnough = false;
                                }
                            }
                            else
                            {
                                errMessage = errMessage + "商品编码为：" + entity.PlatformMerchantCode + " ";
                                isEnough = false;
                            }
                        }

                        if (isSucess == false)
                        {
                            base.ShowMessage("订单号为" + XMApplicationEntity.OrderCode + "的退换货商品格式不正确，排单失败!");
                            break;
                        }

                        if (isEnough == false)               //库存不足   弹出提示
                        {
                            base.ShowMessage(errMessage + "的产品库存不足，请及时补货！");
                            return;
                        }


                        //根据订单号 、是否发货：否0、未打印:0  查询发货单 
                        var xmDeliveryList = base.XMDeliveryService.GetXMDeliveryListByInfo(XMApplicationEntity.OrderCode, 687,708);

                        XMDelivery xd = new XMDelivery();
                        //未返回明细数据 新增发货单主表信息
                        if (AddIDs.Contains(item))
                        {
                            var DeliveryList = base.XMDeliveryService.GetXMDeliveryListByOrderCode(XMApplicationEntity.OrderCode, 708);
                            if (DeliveryList != null && DeliveryList.Count > 0)
                            {
                                xd = DeliveryList[0];
                                xmDeliveryID = xd.Id;
                            }
                        }
                        else if (xmDeliveryList.Count == 0)//根据订单号、未发货查询 未返回数据 则新增发货单
                        {
                            //新增
                            xd.DeliveryTypeId = 708;
                            xd.DeliveryNumber = "ZP" + DateTime.Now.ToString("yyyyMMddHHmmssfff");//赠品发货单号（自动生成）
                            xd.OrderCode = XMApplicationEntity.OrderCode;
                            xd.Price = 0;//运费
                            xd.Shipper = 687;//发货方
                                             //判断无订单
                            if (XMApplicationEntity.OrderCode.StartsWith("NoOrder"))
                            {
                                //备用地址
                                var SpareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(XMApplicationEntity.ID, 710);
                                if (SpareAddress == null)
                                {
                                    base.ShowMessage("无订单赠品必须填写备用地址！");
                                    return;
                                }
                                else
                                {
                                    xd.FullName = SpareAddress.FullName;
                                    xd.Mobile = SpareAddress.Mobile;
                                    xd.Tel = SpareAddress.Tel;
                                    xd.Province = SpareAddress.Province;
                                    xd.City = SpareAddress.City;
                                    xd.County = SpareAddress.County;
                                    xd.DeliveryAddress = SpareAddress.DeliveryAddress;
                                }
                            }
                            else
                            {
                                var OrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(XMApplicationEntity.OrderCode);
                                if (OrderInfo != null)
                                {
                                    xd.FullName = OrderInfo.FullName;
                                    xd.Mobile = OrderInfo.Mobile;
                                    xd.Tel = OrderInfo.Tel;
                                    xd.Province = OrderInfo.Province;
                                    xd.City = OrderInfo.City;
                                    xd.County = OrderInfo.County;
                                    xd.DeliveryAddress = OrderInfo.DeliveryAddress;
                                }
                                else
                                {
                                    base.ShowMessage("订单号" + XMApplicationEntity.OrderCode + "不存在！");
                                    return;
                                }
                            }

                            xd.IsDelivery = false;//是否发货
                            xd.IsEnabled = false;
                            xd.CreateId = HozestERPContext.Current.User.CustomerID;
                            xd.CreateDate = DateTime.Now;
                            xd.UpdateId = HozestERPContext.Current.User.CustomerID;
                            xd.UpdateDate = DateTime.Now;
                            xd.PrintQuantity = 0;//打印次数
                            xd.PrintBatch = 0;//打印批次
                            base.XMDeliveryService.InsertXMDelivery(xd);
                            xmDeliveryID = xd.Id;
                        }
                        else
                        {
                            //返回明细数据 ，根据明细主表Id查询主表信息 
                            xd = xmDeliveryList[0];
                            xmDeliveryID = xd.Id;
                        }

                        if(xd!=null)
                        {
                            foreach (var entity in list)
                            {
                                var productDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(entity.PlatformMerchantCode, (int)XMApplicationEntity.PlatformTypeId);
                                if(productDetail.Count<=0)
                                {
                                    base.ShowMessage("商品信息查询失败,请联系管理员！");
                                    return;
                                }

                                XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
                                deliverDetails.OrderNo = XMApplicationEntity.OrderCode;
                                deliverDetails.DetailsTypeId = 10;
                                deliverDetails.DeliveryId = xd.Id;
                                deliverDetails.ProductlId = productDetail[0].Id;
                                deliverDetails.SourceID = entity.ID;
                                deliverDetails.PlatformMerchantCode = entity.PlatformMerchantCode;
                                deliverDetails.PrdouctName = entity.ProductName;
                                deliverDetails.Specifications = entity.Specifications;
                                deliverDetails.ProductNum = entity.ProductNum;
                                deliverDetails.IsEnabled = false;
                                deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                deliverDetails.CreateDate = DateTime.Now;
                                deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                deliverDetails.UpdateDate = DateTime.Now;
                                deliverDetails.WarehouseID = int.Parse(WareHoursesID);
                                base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);
                            }
                        }

                        //发票先忽略

                        foreach (var entity in list)
                        {
                            var productDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(entity.PlatformMerchantCode, (int)XMApplicationEntity.PlatformTypeId);
                            if (productDetail.Count <= 0)
                            {
                                base.ShowMessage("商品信息查询失败,请联系管理员！");
                                return;
                            }

                            var inventory = base.XMInventoryInfoService.GetXMInventoryInfoByParm(productDetail[0].ManufacturersCode, int.Parse(WareHoursesID));//其他项目判断库存管理里面的可订购数量
                                                                                                                                                               //扣减可订购数量
                            if (inventory != null)
                            {
                                inventory.CanOrderCount -= entity.ProductNum;
                                base.XMInventoryInfoService.UpdateXMInventoryInfo(inventory);
                            }
                        }

                        ////生成销售出库单
                        //var saleDelviery = base.XMSaleDeliveryService.GetXMSaleDeliveryByParm(XMApplicationEntity.ID, xmDeliveryID);
                        ////数据不存在 生成销售出库单
                        //if (saleDelviery == null)
                        //{
                        //    //插入销售出库单主表数据
                        //    XMSaleDelivery saleDeliveryInfo = new XMSaleDelivery();
                        //    saleDeliveryInfo.Ref = AutoSaleDeliveryNumber();
                        //    saleDeliveryInfo.SaleInfoId = 0;
                        //    if (!string.IsNullOrEmpty(XMApplicationEntity.OrderCode))
                        //    {
                        //        var orderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(XMApplicationEntity.OrderCode);
                        //        if (orderInfo != null)
                        //        {
                        //            saleDeliveryInfo.OrderInfoID = orderInfo.ID;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        saleDeliveryInfo.OrderInfoID = 0;
                        //    }
                        //    saleDeliveryInfo.WareHouseId = int.Parse(WareHoursesID);
                        //    saleDeliveryInfo.BillStatus = 0;
                        //    saleDeliveryInfo.SaleMoney = 0;      //换货金额为0
                        //    saleDeliveryInfo.ReceivingType = 701;
                        //    saleDeliveryInfo.BizUserId = HozestERPContext.Current.User.CustomerID;
                        //    saleDeliveryInfo.BizDt = DateTime.Now;
                        //    saleDeliveryInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                        //    saleDeliveryInfo.CreateDate = DateTime.Now;
                        //    saleDeliveryInfo.UpdateDate = DateTime.Now;
                        //    saleDeliveryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        //    saleDeliveryInfo.IsEnable = false;
                        //    saleDeliveryInfo.IsAudit = true;
                        //    saleDeliveryInfo.DeliveryID = xmDeliveryID;
                        //    base.XMSaleDeliveryService.InsertXMSaleDelivery(saleDeliveryInfo);

                        //    //插入销售出库单明细数据
                        //    foreach (var entity in list)
                        //    {
                        //        var productDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(entity.PlatformMerchantCode, (int)XMApplicationEntity.PlatformTypeId);
                        //        if (productDetail.Count <= 0)
                        //        {
                        //            base.ShowMessage("商品信息查询失败,请联系管理员！");
                        //            return;
                        //        }

                        //        XMSaleDeliveryProductDetails saleDeliveryDetail = new XMSaleDeliveryProductDetails();
                        //        saleDeliveryDetail.SaleDeliveryId = saleDeliveryInfo.Id;
                        //        saleDeliveryDetail.ProductId = productDetail[0].Id;
                        //        saleDeliveryDetail.PlatformMerchantCode = productDetail[0].ManufacturersCode;
                        //        saleDeliveryDetail.SaleCount = entity.ProductNum;
                        //        saleDeliveryDetail.ProductMoney = 0;
                        //        saleDeliveryDetail.ProductPrice = 0;   //退换货单价为0;
                        //        saleDeliveryDetail.CreateDate = saleDeliveryDetail.UpdateDate = DateTime.Now;
                        //        saleDeliveryDetail.CreateID = saleDeliveryDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                        //        saleDeliveryDetail.IsEnable = false;
                        //        base.XMSaleDeliveryProductDetailsService.InsertXMSaleDeliveryProductDetails(saleDeliveryDetail);

                        //        var inventory = base.XMInventoryInfoService.GetXMInventoryInfoByParm(productDetail[0].ManufacturersCode, int.Parse(WareHoursesID));//其他项目判断库存管理里面的可订购数量
                        //                                                                                                                          //扣减可订购数量
                        //        if (inventory != null)
                        //        {
                        //            inventory.CanOrderCount -= entity.ProductNum;
                        //            base.XMInventoryInfoService.UpdateXMInventoryInfo(inventory);
                        //        }
                        //    }
                        //}

                        XMApplicationEntity.IsSingleRow = true;
                        XMApplicationEntity.UpdateDate= DateTime.Now;
                        XMApplicationEntity.UpdateID= HozestERPContext.Current.User.CustomerID;
                        XMApplicationService.UpdateXMApplication(XMApplicationEntity);
                    }
                }

                scope.Complete();
            }
            base.ShowMessage("操作成功！");
        }
    }
}