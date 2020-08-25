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
    public partial class XMPremiumsSaleDelivery : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SavePremiunsInfoIDs"] != null)
                {
                    List<int> Ids = new List<int>();
                    string[] IDs = (string[])Session["SavePremiunsInfoIDs"];
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
            List<int> IDs = new List<int>();
            List<int> AddIDs = new List<int>();
            string WareHourses = this.ddlWareHourses.SelectedValue;
            bool AddToDelivery = this.chkAddToDelivery.Checked;
            if (Session["SavePremiunsInfoIDs"] != null)
            {
                string[] SavePremiunsInfoIDs = (string[])Session["SavePremiunsInfoIDs"];
                if (SavePremiunsInfoIDs.Count() > 0)
                {
                    foreach (var ID in SavePremiunsInfoIDs)
                    {
                        IDs.Add(int.Parse(ID));
                    }
                }
                else
                {
                    base.ShowMessage("你没有选择任何记录！");
                    return;
                }
            }
            if (WareHourses == "-1" || WareHourses == "")
            {
                base.ShowMessage("请先选择出库仓库！");
                return;
            }

            if (AddToDelivery)
            {
                string msg = "";
                if (this.Type == 0)
                {
                    var XMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
                    foreach (XMPremiums Info in XMPremiumsList)
                    {
                        if (!Info.OrderCode.StartsWith("NoOrder"))
                        {
                            var DeliveryList = base.XMDeliveryService.GetXMDeliveryListByOrderCode(Info.OrderCode, 480);
                            if (DeliveryList != null && DeliveryList.Count > 0)
                            {
                                AddIDs.Add(Info.Id);
                            }
                            else
                            {
                                msg += "订单号：" + Info.OrderCode + "的赠品，未生成正式发货单，不能追加！<br/>";
                            }
                        }
                    }
                }
                else if (this.Type == 1)
                {
                    var XMPremiumsDetail = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(IDs[0]);
                    if (XMPremiumsDetail != null)
                    {
                        var XMPremiums = base.XMPremiumsService.GetXMPremiumsById((int)XMPremiumsDetail.PremiumsId);
                        if (XMPremiums != null)
                        {
                            if (!XMPremiums.OrderCode.StartsWith("NoOrder"))
                            {
                                var DeliveryList = base.XMDeliveryService.GetXMDeliveryListByOrderCode(XMPremiums.OrderCode, 480);
                                if (DeliveryList != null && DeliveryList.Count > 0)
                                {
                                    AddIDs.Add(DeliveryList[0].Id);
                                }
                                else
                                {
                                    msg += "订单号：" + XMPremiums.OrderCode + "的赠品，未生成正式发货单，不能追加！<br/>";
                                }
                            }
                        }
                    }
                }

                if (msg != "")
                {
                    base.ShowMessage(msg);
                    return;
                }
            }

            SingleRow(IDs, WareHourses, AddIDs);//排单
        }

        private void SingleRow(List<int> IDs, string WareHoursesID, List<int> AddIDs)
        {
            //事务
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                if (IDs.Count <= 0)
                {
                    base.ShowMessage("你没有选择任何记录！");
                    return;
                }
                else
                {
                    //查询所有选中的赠品信息
                    var XMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
                    var DDidNotPassList = XMPremiumsList.Where(a =>
                        a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.NotCheck)||a.FinanceIsAudit==false
                        || a.PremiumsStatus == Convert.ToInt32(StatusEnum.PremiumsIssued)
                        ).ToList();//运营未通过、赠品状态未发

                    if (DDidNotPassList.Count > 0)
                    {
                        base.ShowMessage("请选择运营,财务已审核赠品状态是未发的数据！");
                        return;
                    }

                    #region  批量排单
                    if (this.Type == 0)          //批量排单
                    {
                        bool isSucess = true;
                        foreach (int ID in IDs)
                        {
                            int Id = ID;
                            XMPremiums xMPremiums = base.XMPremiumsService.GetXMPremiumsById(Id);
                            var xmorderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMPremiums.OrderCode);//订单号查询订单
                            if (xMPremiums != null)
                            {
                                List<XMPremiumsDetails> XMPremiumsDetailsList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(xMPremiums.Id);
                                int xmDeliveryID = 1;
                                bool isEnough = true;
                                string errMessage = "";
                                if (XMPremiumsDetailsList.Count == 0)
                                {
                                    base.ShowMessage("赠品明细无数据！");
                                    return;
                                }
                                else
                                {
                                    foreach (var parm in XMPremiumsDetailsList)
                                    {
                                        int outCount = 0;     //已派单产品数量
                                        int totalInventCount = 0;    //总库存数量
                                        int canInventCount = 0;   //可用库存
                                        string ManufacturersCode = "";
                                        if (!string.IsNullOrEmpty(parm.PlatformMerchantCode))
                                        {
                                            int paramPlatformTypeid = -1;
                                            if (xmorderinfo != null)
                                                paramPlatformTypeid = int.Parse(xmorderinfo.PlatformTypeId.ToString());
                                            var productDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(parm.PlatformMerchantCode, paramPlatformTypeid);
                                            if (productDetail != null && productDetail.Count > 0)
                                            {
                                                ManufacturersCode = productDetail[0].ManufacturersCode;
                                            }
                                        }
                                        //查询所有通过赠品自动生产的出库单 状态为未出库的出库单记录
                                        //var saleDeliverys = base.XMSaleDeliveryService.GetXMSaleDeliveryListByPremiums(int.Parse(WareHoursesID));
                                        //if (saleDeliverys != null && saleDeliverys.Count > 0)
                                        //{
                                        //    foreach (var p in saleDeliverys)
                                        //    {
                                        //        var saleDeliveryProductDetail = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(p.Id);
                                        //        if (saleDeliveryProductDetail != null && saleDeliveryProductDetail.Count > 0)
                                        //        {
                                        //            foreach (var detail in saleDeliveryProductDetail)
                                        //            {
                                        //                if (detail.PlatformMerchantCode == ManufacturersCode)
                                        //                {
                                        //                    outCount = outCount + 1;
                                        //                }
                                        //            }
                                        //        }
                                        //    }
                                        //}
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
                                            if (canInventCount < parm.ProductNum)             //剩余库存不足
                                            {
                                                errMessage = errMessage + "商品编码为：" + parm.PlatformMerchantCode + " ";
                                                isEnough = false;
                                            }
                                        }
                                        else
                                        {
                                            errMessage = errMessage + "商品编码为：" + parm.PlatformMerchantCode + " ";
                                            isEnough = false;
                                        }
                                    }

                                    if (isSucess == false)
                                    {
                                        base.ShowMessage("订单号为" + xMPremiums.OrderCode + "的赠品商品格式不正确，排单失败!");
                                        break;
                                    }

                                    if (isEnough == false)               //库存不足   弹出提示
                                    {
                                        base.ShowMessage(errMessage + "的产品库存不足，请及时补货！");
                                        return;
                                    }

                                    //查询发票管理中未排单的 及 未开票的 记录  如存在更新发票排单状态为已排单  
                                    var invoiceInfoList = base.XMInvoiceInfoService.GetXMInvoiceInfoListByOrderCode(xMPremiums.OrderCode).Where(x => x.IsScrap != true && x.IsSingleRow != true && x.InvoiceType != null && (x.IsBilling == null || x.IsBilling == false)).ToList();//发票
                                    if (invoiceInfoList != null && invoiceInfoList.Count > 0)
                                    {
                                        foreach (var item in invoiceInfoList)
                                        {
                                            #region 修改发票排单状态
                                            item.IsSingleRow = true;
                                            item.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            item.UpdateDate = DateTime.Now;
                                            base.XMInvoiceInfoService.UpdateXMInvoiceInfo(item);
                                            #endregion
                                        }
                                    }

                                    List<int> ShipperType = new List<int>();
                                    foreach (XMPremiumsDetails info in XMPremiumsDetailsList)
                                    {
                                        if (info.Shipper != null && ShipperType.IndexOf((int)info.Shipper) == -1)
                                        {
                                            ShipperType.Add((int)info.Shipper);
                                        }
                                    }

                                    foreach (int Shipper in ShipperType)
                                    {
                                        //返回明细数据
                                        //根据订单号 、是否发货：否0、未打印:0  查询发货单 
                                        var xmDeliveryList = base.XMDeliveryService.GetXMDeliveryListByOrderCodeShipper(xMPremiums.OrderCode, Shipper);

                                        //发货单对象
                                        HozestERP.BusinessLogic.ManageProject.XMDelivery xd = new HozestERP.BusinessLogic.ManageProject.XMDelivery();

                                        //未返回明细数据 新增发货单主表信息
                                        if (AddIDs.Contains(ID))
                                        {
                                            var DeliveryList = base.XMDeliveryService.GetXMDeliveryListByOrderCode(xMPremiums.OrderCode, 480);
                                            if (DeliveryList != null && DeliveryList.Count > 0)
                                            {
                                                xd = DeliveryList[0];
                                                xmDeliveryID = xd.Id;
                                            }
                                        }
                                        else if (xmDeliveryList.Count == 0)//根据订单号、未发货查询 未返回数据 则新增发货单
                                        {
                                            //新增
                                            xd.DeliveryTypeId = 481;//非正常
                                            xd.DeliveryNumber = "ZP" + DateTime.Now.ToString("yyyyMMddHHmmssfff");//赠品发货单号（自动生成）
                                            xd.OrderCode = xMPremiums.OrderCode;
                                            xd.Price = 0;//运费
                                            xd.Shipper = Shipper;//发货方
                                            //备用地址
                                            var SpareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(xMPremiums.Id, 711);
                                            if (SpareAddress != null)
                                            {
                                                xd.FullName = SpareAddress.FullName;
                                                xd.Mobile = SpareAddress.Mobile;
                                                xd.Tel = SpareAddress.Tel;
                                                xd.Province = SpareAddress.Province;
                                                xd.City = SpareAddress.City;
                                                xd.County = SpareAddress.County;
                                                xd.DeliveryAddress = SpareAddress.DeliveryAddress;
                                            }
                                            else
                                            {
                                                if (TabPanelPremiumsType == "ManagerNoOrder")//无订单赠品
                                                {
                                                    base.ShowMessage("无订单赠品必须填写备用地址！");
                                                    return;
                                                }

                                                var OrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMPremiums.OrderCode);
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
                                                    base.ShowMessage("此订单号不存在！");
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

                                        if (xd != null)//发货单记录 不未空
                                        {
                                            if (xd.Id != 0)
                                            {
                                                for (int i = 0; i < XMPremiumsDetailsList.Count; i++)
                                                {
                                                    if (XMPremiumsDetailsList[i].Shipper == Shipper)
                                                    {
                                                        string Specifications = "";
                                                        if (XMPremiumsDetailsList[i].ProductDetaislId != null)
                                                        {
                                                            var product = base.XMProductService.GetXMProductById(XMPremiumsDetailsList[i].ProductDetaislId.Value);
                                                            if (product != null)
                                                            {
                                                                //尺寸  
                                                                Specifications = product.Specifications;
                                                            }
                                                        }

                                                        if (Specifications == "")
                                                        {
                                                            var productDetails = base.XMProductService.GetXMProductListByPlatformMerchantCode(XMPremiumsDetailsList[i].PlatformMerchantCode, -1);
                                                            if (productDetails != null && productDetails.Count > 0)
                                                            {
                                                                var product = base.XMProductService.GetXMProductById((int)productDetails[0].ProductId);
                                                                if (product != null)
                                                                {
                                                                    //尺寸  
                                                                    Specifications = product.Specifications;
                                                                }
                                                            }
                                                        }

                                                        XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
                                                        deliverDetails.OrderNo = xMPremiums.OrderCode;
                                                        deliverDetails.DetailsTypeId = xMPremiums.PremiumsTypeId.Value;
                                                        deliverDetails.DeliveryId = xd.Id;
                                                        deliverDetails.ProductlId = XMPremiumsDetailsList[i].ProductDetaislId;
                                                        deliverDetails.SourceID = XMPremiumsDetailsList[i].Id;
                                                        deliverDetails.PlatformMerchantCode = XMPremiumsDetailsList[i].PlatformMerchantCode;
                                                        deliverDetails.PrdouctName = XMPremiumsDetailsList[i].PrdouctName;
                                                        deliverDetails.Specifications = Specifications;
                                                        deliverDetails.ProductNum = XMPremiumsDetailsList[i].ProductNum;
                                                        deliverDetails.IsEnabled = false;
                                                        deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                                        deliverDetails.CreateDate = DateTime.Now;
                                                        deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                        deliverDetails.UpdateDate = DateTime.Now;
                                                        deliverDetails.WarehouseID = int.Parse(WareHoursesID);
                                                        base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);
                                                    }
                                                }

                                                xMPremiums.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsIssued);
                                                xMPremiums.IsSingleRow = true;
                                                xMPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                                xMPremiums.UpdateTime = DateTime.Now;
                                                base.XMPremiumsService.UpdateXMPremiums(xMPremiums);

                                                var InvoiceInfoList = base.XMInvoiceInfoService.GetXMInvoiceInfoListByOrderCode(xd.OrderCode)
                                                    .Where(x => x.IsScrap != true && x.IsSingleRow != true && x.InvoiceType != null&&x.IsBilling==true).ToList();//发票
                                                if (InvoiceInfoList != null && InvoiceInfoList.Count > 0)
                                                {
                                                    foreach (var item in InvoiceInfoList)
                                                    {
                                                        if (item != null)
                                                        {
                                                            List<XMInvoiceInfoDetail> InvoiceDetailsList = base.XMInvoiceInfoDetailService.GetXMInvoiceInfoDetailListByInvoiceInfoID(item.ID);
                                                            if (InvoiceDetailsList.Count > 0)
                                                            {
                                                                //插入发货单明细
                                                                XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
                                                                deliverDetails.OrderNo = xd.OrderCode;
                                                                deliverDetails.DetailsTypeId = (int)StatusEnum.InvoiceInfo;//发票
                                                                deliverDetails.DeliveryId = xd.Id;
                                                                deliverDetails.ProductlId = 0;
                                                                deliverDetails.PlatformMerchantCode = "";
                                                                deliverDetails.PrdouctName = "发票";
                                                                deliverDetails.Specifications = "";
                                                                deliverDetails.ProductNum = 1;
                                                                deliverDetails.InvoiceInfoID = item.ID;
                                                                deliverDetails.SourceID= item.ID;
                                                                deliverDetails.IsEnabled = false;
                                                                deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                                                deliverDetails.CreateDate = DateTime.Now;
                                                                deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                                deliverDetails.UpdateDate = DateTime.Now;
                                                                base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);

                                                                item.IsSingleRow = true;
                                                                item.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                                item.UpdateDate = DateTime.Now;
                                                                base.XMInvoiceInfoService.UpdateXMInvoiceInfo(item);
                                                            }
                                                        }
                                                    }
                                                }


                                                var ClaimInfo = base.XMClaimInfoService.GetXMClaimInfoByPremiumsId(Id);
                                                if (ClaimInfo != null)
                                                {
                                                    var ClaimInfoDetail = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(ClaimInfo.Id);
                                                    if (ClaimInfoDetail != null && ClaimInfoDetail.Count > 0)
                                                    {
                                                        foreach (var a in ClaimInfoDetail)
                                                        {
                                                            a.IsConfirm = true;
                                                            a.UpdateDate = DateTime.Now;
                                                            a.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                            base.XMClaimInfoDetailService.UpdateXMClaimInfoDetail(a);
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                    }
                                    //循环排单
                                    foreach (var p in XMPremiumsDetailsList)
                                    {
                                        p.IsSingleRow = true;
                                        p.UpdateDate = DateTime.Now;
                                        p.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(p);
                                    }
                                }

                                if (XMPremiumsDetailsList != null && XMPremiumsDetailsList.Count > 0)
                                {
                                    foreach (var detail in XMPremiumsDetailsList)
                                    {
                                        int productID = 0;
                                        string ManufacturersCode = "";
                                        if (detail.PlatformMerchantCode != null)
                                        {
                                            var productDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(detail.PlatformMerchantCode);
                                            if (productDetail != null && productDetail.Count > 0)
                                            {
                                                productID = productDetail[0].ProductId.Value;
                                                ManufacturersCode = productDetail[0].ManufacturersCode;
                                            }
                                        }
                                        if (detail.ProductDetaislId != null && detail.ProductDetaislId != -1)
                                        {
                                            var products = base.XMProductService.GetXMProductById(detail.ProductDetaislId.Value);
                                            if (products != null)
                                            {
                                                productID = products.Id;
                                                ManufacturersCode = products.ManufacturersCode;
                                            }
                                            else
                                            {
                                                var productDetails = base.XMProductDetailsService.GetXMProductDetailsById(detail.ProductDetaislId.Value);
                                                if (productDetails != null)
                                                {
                                                    productID = productDetails.ProductId.Value;
                                                    ManufacturersCode = productDetails.ManufacturersCode;
                                                }
                                            }
                                        }
                                        var inventory = base.XMInventoryInfoService.GetXMInventoryInfoByParm(ManufacturersCode, int.Parse(WareHoursesID));//其他项目判断库存管理里面的可订购数量
                                                                                                                                                          //扣减可订购数量
                                        if (inventory != null)
                                        {
                                            inventory.CanOrderCount -= detail.ProductNum;
                                            base.XMInventoryInfoService.UpdateXMInventoryInfo(inventory);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion   批量排单

                    #region   单个排单
                    else if (this.Type == 1)//单个排单
                    {
                        bool c = false;
                        bool isSucess = true;
                        int xmDeliveryID = 1;
                        bool isEnough = true;
                        string errMessage = "";
                        string OrderCode = "";
                        int PremiumsID = 0;
                        List<int> ShipperType = new List<int>();
                        foreach (int Id in IDs)
                        {
                            var premiumsDetailInfo = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(Id);
                            if (premiumsDetailInfo != null)
                            {
                                if (premiumsDetailInfo.IsSingleRow != null && premiumsDetailInfo.IsSingleRow.Value)
                                {
                                    c = true;
                                }
                            }
                        }
                        if (c)
                        {
                            base.ShowMessage("选中产品已排单，操作失败！");
                            return;
                        }
                        foreach (int Id in IDs)
                        {
                            var premiumsDetail = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(Id);
                            if (premiumsDetail == null)
                            {
                                base.ShowMessage("赠品明细无数据！");
                                return;
                            }
                            else
                            {
                                int outCount = 0;     //已派单产品数量
                                int totalInventCount = 0;    //总库存数量
                                int canInventCount = 0;   //可用库存
                                string ManufacturersCode = "";
                                var premiumsInfo = base.XMPremiumsService.GetXMPremiumsById(premiumsDetail.PremiumsId.Value);
                                if (premiumsInfo != null)
                                {
                                    PremiumsID = premiumsInfo.Id;
                                    OrderCode = premiumsInfo.OrderCode;
                                }
                                var productDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(premiumsDetail.PlatformMerchantCode);
                                if (productDetail != null && productDetail.Count > 0)
                                {
                                    ManufacturersCode = productDetail[0].ManufacturersCode;
                                }
                                //查询所有通过赠品自动生产的出库单 状态为未出库的出库单记录
                                var saleDeliverys = base.XMSaleDeliveryService.GetXMSaleDeliveryListByPremiums(int.Parse(WareHoursesID));
                                if (saleDeliverys != null && saleDeliverys.Count > 0)
                                {
                                    foreach (var p in saleDeliverys)
                                    {
                                        var saleDeliveryProductDetail = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(p.Id);
                                        if (saleDeliveryProductDetail != null && saleDeliveryProductDetail.Count > 0)
                                        {
                                            foreach (var detail in saleDeliveryProductDetail)
                                            {
                                                if (detail.PlatformMerchantCode == ManufacturersCode)
                                                {
                                                    outCount = outCount + 1;
                                                }
                                            }
                                        }
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
                                if (totalInventCount != 0)//存在库存
                                {
                                    canInventCount = totalInventCount - outCount;
                                    if (canInventCount < premiumsDetail.ProductNum)//剩余库存不足
                                    {
                                        errMessage = errMessage + "商品编码为：" + premiumsDetail.PlatformMerchantCode + " ";
                                        isEnough = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    errMessage = errMessage + "商品编码为：" + premiumsDetail.PlatformMerchantCode + " ";
                                    isEnough = false;
                                    break;
                                }
                            }

                            if (premiumsDetail.Shipper != null && ShipperType.IndexOf((int)premiumsDetail.Shipper) == -1)
                            {
                                ShipperType.Add((int)premiumsDetail.Shipper);
                            }
                        }
                        if (isSucess == false)
                        {
                            base.ShowMessage("订单号为" + OrderCode + "的赠品商品格式不正确，排单失败!");
                            return;
                        }

                        if (isEnough == false)               //库存不足   弹出提示
                        {
                            base.ShowMessage(errMessage + "的产品库存不足，请及时补货！");
                            return;
                        }

                        //查询发票管理中未排单的 及 未开票的 记录  如存在更新发票排单状态为已排单  
                        var invoiceInfoList = base.XMInvoiceInfoService.GetXMInvoiceInfoListByOrderCode(OrderCode).Where(x => x.IsScrap != true && x.IsSingleRow != true && x.InvoiceType != null && (x.IsBilling == null || x.IsBilling == false)).ToList();//发票
                        if (invoiceInfoList != null && invoiceInfoList.Count > 0)
                        {
                            foreach (var item in invoiceInfoList)
                            {
                                #region 修改发票排单状态
                                item.IsSingleRow = true;
                                item.UpdateID = HozestERPContext.Current.User.CustomerID;
                                item.UpdateDate = DateTime.Now;
                                base.XMInvoiceInfoService.UpdateXMInvoiceInfo(item);
                                #endregion
                            }
                        }

                        foreach (int Shipper in ShipperType)
                        {
                            //返回明细数据
                            //根据订单号 、是否发货：否0、未打印:0  查询发货单 
                            //发货单对象
                            HozestERP.BusinessLogic.ManageProject.XMDelivery xd = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
                            //未返回明细数据 新增发货单主表信息

                            if (this.chkAddToDelivery.Checked)
                            {
                                if (AddIDs.Count > 0)
                                {
                                    var Delivery = base.XMDeliveryService.GetXMDeliveryById(AddIDs[0]);
                                    if (Delivery != null)
                                    {
                                        xd = Delivery;
                                    }
                                }
                            }

                            if (xd.Id == 0)
                            {
                                xd.DeliveryTypeId = 481;//非正常
                                xd.DeliveryNumber = "ZP" + DateTime.Now.ToString("yyyyMMddHHmmssfff");//赠品发货单号（自动生成）
                                xd.OrderCode = OrderCode;
                                xd.Price = 0;//运费
                                xd.Shipper = Shipper;//发货方
                                //备用地址
                                var SpareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(PremiumsID, 711);
                                if (SpareAddress != null)
                                {
                                    xd.FullName = SpareAddress.FullName;
                                    xd.Mobile = SpareAddress.Mobile;
                                    xd.Tel = SpareAddress.Tel;
                                    xd.Province = SpareAddress.Province;
                                    xd.City = SpareAddress.City;
                                    xd.County = SpareAddress.County;
                                    xd.DeliveryAddress = SpareAddress.DeliveryAddress;
                                }
                                else
                                {
                                    if (TabPanelPremiumsType == "ManagerNoOrder")//无订单赠品
                                    {
                                        base.ShowMessage("无订单赠品必须填写备用地址！");
                                        return;
                                    }

                                    var OrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(OrderCode);
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
                                        base.ShowMessage("此订单号不存在！");
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
                            }
                            xmDeliveryID = xd.Id;

                            if (xd != null)//发货单记录 不未空
                            {
                                if (xd.Id != 0)
                                {
                                    foreach (int id in IDs)
                                    {
                                        var detailsInfo = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(id);
                                        if (detailsInfo != null)
                                        {
                                            if (detailsInfo.Shipper == Shipper)
                                            {
                                                string Specifications = "";
                                                if (detailsInfo.ProductDetaislId != null)
                                                {
                                                    var product = base.XMProductService.GetXMProductById(detailsInfo.ProductDetaislId.Value);
                                                    if (product != null)
                                                    {
                                                        //尺寸  
                                                        Specifications = product.Specifications;
                                                    }
                                                }

                                                if (Specifications == "")
                                                {
                                                    var productDetails = base.XMProductService.GetXMProductListByPlatformMerchantCode(detailsInfo.PlatformMerchantCode, -1);
                                                    if (productDetails != null && productDetails.Count > 0)
                                                    {
                                                        var product = base.XMProductService.GetXMProductById((int)productDetails[0].ProductId);
                                                        if (product != null)
                                                        {
                                                            //尺寸  
                                                            Specifications = product.Specifications;
                                                        }
                                                    }
                                                }
                                                XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
                                                deliverDetails.OrderNo = OrderCode;
                                                var premiumsInfo = base.XMPremiumsService.GetXMPremiumsById(detailsInfo.PremiumsId.Value);
                                                if (premiumsInfo != null)
                                                {
                                                    deliverDetails.DetailsTypeId = premiumsInfo.PremiumsTypeId.Value;
                                                }
                                                deliverDetails.DeliveryId = xd.Id;
                                                deliverDetails.ProductlId = detailsInfo.ProductDetaislId;
                                                deliverDetails.PlatformMerchantCode = detailsInfo.PlatformMerchantCode;
                                                deliverDetails.PrdouctName = detailsInfo.PrdouctName;
                                                deliverDetails.Specifications = Specifications;
                                                deliverDetails.ProductNum = detailsInfo.ProductNum;
                                                deliverDetails.SourceID = detailsInfo.Id;
                                                deliverDetails.IsEnabled = false;
                                                deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                                deliverDetails.CreateDate = DateTime.Now;
                                                deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                deliverDetails.UpdateDate = DateTime.Now;
                                                deliverDetails.WarehouseID = int.Parse(WareHoursesID);
                                                base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);

                                            }
                                        }
                                    }

                                    var DeliveryList = base.XMDeliveryService.GetXMDeliveryByOrderCodeAndDeliveryTypeId(xd.OrderCode, 722)
                                        .Where(x => x.IsDelivery == false).ToList();//发票;
                                    if (DeliveryList != null && DeliveryList.Count > 0)
                                    {
                                        foreach (var item in DeliveryList)
                                        {
                                            //插入发货单明细
                                            XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
                                            deliverDetails.OrderNo = xd.OrderCode;
                                            deliverDetails.DetailsTypeId = (int)StatusEnum.InvoiceInfo;//发票
                                            deliverDetails.DeliveryId = xd.Id;
                                            deliverDetails.ProductlId = 0;
                                            deliverDetails.PlatformMerchantCode = "";
                                            deliverDetails.PrdouctName = "发票";
                                            deliverDetails.Specifications = "";
                                            deliverDetails.ProductNum = 1;
                                            if (item.XM_Delivery_Details != null && item.XM_Delivery_Details.Count > 0)
                                            {
                                                int InvoiceInfoID= (int)(item.XM_Delivery_Details.ToList())[0].InvoiceInfoID;
                                                deliverDetails.InvoiceInfoID = InvoiceInfoID;
                                                deliverDetails.SourceID = InvoiceInfoID;
                                            }
                                            deliverDetails.IsEnabled = false;
                                            deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                            deliverDetails.CreateDate = DateTime.Now;
                                            deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            deliverDetails.UpdateDate = DateTime.Now;
                                            deliverDetails.WarehouseID = int.Parse(WareHoursesID);
                                            base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);

                                            item.IsEnabled = true;
                                            item.UpdateId = HozestERPContext.Current.User.CustomerID;
                                            item.UpdateDate = DateTime.Now;
                                            base.XMDeliveryService.UpdateXMDelivery(item);
                                        }
                                    }

                                    var InvoiceInfoList = base.XMInvoiceInfoService.GetXMInvoiceInfoListByOrderCode(xd.OrderCode)
                                        .Where(x => x.IsScrap != true && x.IsSingleRow != true && x.InvoiceType != null).ToList();//发票
                                    if (InvoiceInfoList != null && InvoiceInfoList.Count > 0)
                                    {
                                        foreach (var item in InvoiceInfoList)
                                        {
                                            if (item != null)
                                            {
                                                List<XMInvoiceInfoDetail> InvoiceDetailsList = base.XMInvoiceInfoDetailService.GetXMInvoiceInfoDetailListByInvoiceInfoID(item.ID);
                                                if (InvoiceDetailsList.Count > 0)
                                                {
                                                    //插入发货单明细
                                                    XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
                                                    deliverDetails.OrderNo = xd.OrderCode;
                                                    deliverDetails.DetailsTypeId = (int)StatusEnum.InvoiceInfo;//发票
                                                    deliverDetails.DeliveryId = xd.Id;
                                                    deliverDetails.ProductlId = 0;
                                                    deliverDetails.PlatformMerchantCode = "";
                                                    deliverDetails.PrdouctName = "发票";
                                                    deliverDetails.Specifications = "";
                                                    deliverDetails.ProductNum = 1;
                                                    deliverDetails.InvoiceInfoID = item.ID;
                                                    deliverDetails.SourceID= item.ID;
                                                    deliverDetails.IsEnabled = false;
                                                    deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                                    deliverDetails.CreateDate = DateTime.Now;
                                                    deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    deliverDetails.UpdateDate = DateTime.Now;
                                                    base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);

                                                    item.IsSingleRow = true;
                                                    item.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    item.UpdateDate = DateTime.Now;
                                                    base.XMInvoiceInfoService.UpdateXMInvoiceInfo(item);
                                                }
                                            }
                                        }
                                    }


                                    var ClaimInfo = base.XMClaimInfoService.GetXMClaimInfoByPremiumsId(PremiumsID);
                                    if (ClaimInfo != null)
                                    {
                                        var ClaimInfoDetail = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(ClaimInfo.Id);
                                        if (ClaimInfoDetail != null && ClaimInfoDetail.Count > 0)
                                        {
                                            foreach (var a in ClaimInfoDetail)
                                            {
                                                a.IsConfirm = true;
                                                a.UpdateDate = DateTime.Now;
                                                a.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                base.XMClaimInfoDetailService.UpdateXMClaimInfoDetail(a);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //赠品详情排单
                        foreach (int ID in IDs)
                        {
                            var xMPremiumsDetails = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(ID);
                            if (xMPremiumsDetails != null)
                            {
                                xMPremiumsDetails.IsSingleRow = true;
                                xMPremiumsDetails.UpdateDate = DateTime.Now;
                                xMPremiumsDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(xMPremiumsDetails);
                            }
                        }
                        bool isSingleRow = true;
                        var XMPremiumsDetailsList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(PremiumsID);
                        if (XMPremiumsDetailsList != null && XMPremiumsDetailsList.Count > 0)
                        {
                            foreach (var Info in XMPremiumsDetailsList)
                            {
                                if (Info.IsSingleRow == null || (Info.IsSingleRow != null && !Info.IsSingleRow.Value))
                                {
                                    isSingleRow = false;
                                    break;
                                }
                            }
                        }
                        var xMPremiums = base.XMPremiumsService.GetXMPremiumsById(PremiumsID);
                        if (xMPremiums != null)
                        {
                            //已全部排单
                            if (isSingleRow)
                            {
                                xMPremiums.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsIssued);
                                xMPremiums.IsSingleRow = true;
                                xMPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                xMPremiums.UpdateTime = DateTime.Now;
                                base.XMPremiumsService.UpdateXMPremiums(xMPremiums);
                            }
                        }

                        //生成销售出库单
                        var saleDelviery = base.XMSaleDeliveryService.GetXMSaleDeliveryByParm(xMPremiums.Id, xmDeliveryID);
                        //数据不存在 生成销售出库单
                        if (saleDelviery == null)
                        {
                            //插入销售出库单主表数据
                            XMSaleDelivery saleDeliveryInfo = new XMSaleDelivery();
                            saleDeliveryInfo.Ref = AutoSaleDeliveryNumber();
                            saleDeliveryInfo.SaleInfoId = 0;
                            if (!string.IsNullOrEmpty(xMPremiums.OrderCode))
                            {
                                var orderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMPremiums.OrderCode);
                                if (orderInfo != null)
                                {
                                    saleDeliveryInfo.OrderInfoID = orderInfo.ID;
                                }
                            }
                            else
                            {
                                saleDeliveryInfo.OrderInfoID = 0;
                            }
                            saleDeliveryInfo.WareHouseId = int.Parse(WareHoursesID);
                            saleDeliveryInfo.BillStatus = 0;
                            saleDeliveryInfo.SaleMoney = 0;      //赠品金额为0
                            saleDeliveryInfo.ReceivingType = 701;
                            saleDeliveryInfo.BizUserId = HozestERPContext.Current.User.CustomerID;
                            saleDeliveryInfo.BizDt = DateTime.Now;
                            saleDeliveryInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                            saleDeliveryInfo.CreateDate = DateTime.Now;
                            saleDeliveryInfo.UpdateDate = DateTime.Now;
                            saleDeliveryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            saleDeliveryInfo.IsEnable = false;
                            saleDeliveryInfo.IsAudit = true;
                            saleDeliveryInfo.PremiumsID = xMPremiums.Id;
                            saleDeliveryInfo.DeliveryID = xmDeliveryID;
                            base.XMSaleDeliveryService.InsertXMSaleDelivery(saleDeliveryInfo);

                            //插入销售出库单明细数据
                            foreach (int id in IDs)
                            {
                                var premiumsDetails = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(id);
                                int productID = 0;
                                string ManufacturersCode = "";
                                if (premiumsDetails.PlatformMerchantCode != null)
                                {
                                    var productDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(premiumsDetails.PlatformMerchantCode);
                                    if (productDetail != null && productDetail.Count > 0)
                                    {
                                        productID = productDetail[0].ProductId.Value;
                                        ManufacturersCode = productDetail[0].ManufacturersCode;
                                    }
                                }
                                if (premiumsDetails.ProductDetaislId != null && premiumsDetails.ProductDetaislId != -1)
                                {
                                    var products = base.XMProductService.GetXMProductById(premiumsDetails.ProductDetaislId.Value);
                                    if (products != null)
                                    {
                                        productID = products.Id;
                                        ManufacturersCode = products.ManufacturersCode;
                                    }
                                    else
                                    {
                                        var productDetails = base.XMProductDetailsService.GetXMProductDetailsById(premiumsDetails.ProductDetaislId.Value);
                                        if (productDetails != null)
                                        {
                                            productID = productDetails.ProductId.Value;
                                            ManufacturersCode = productDetails.ManufacturersCode;
                                        }
                                    }
                                }
                                XMSaleDeliveryProductDetails saleDeliveryDetail = new XMSaleDeliveryProductDetails();
                                saleDeliveryDetail.SaleDeliveryId = saleDeliveryInfo.Id;
                                saleDeliveryDetail.ProductId = productID;
                                saleDeliveryDetail.PlatformMerchantCode = ManufacturersCode;
                                saleDeliveryDetail.SaleCount = premiumsDetails.ProductNum;
                                saleDeliveryDetail.ProductMoney = 0;
                                saleDeliveryDetail.ProductPrice = 0;   //赠品单价为0;
                                saleDeliveryDetail.CreateDate = saleDeliveryDetail.UpdateDate = DateTime.Now;
                                saleDeliveryDetail.CreateID = saleDeliveryDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                saleDeliveryDetail.IsEnable = false;
                                base.XMSaleDeliveryProductDetailsService.InsertXMSaleDeliveryProductDetails(saleDeliveryDetail);
                            }
                        }
                    }
                    #endregion

                    base.ShowMessage("保存成功！");
                }
                scope.Complete();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private bool CheckInventroyIsEnough(List<XMPremiumsDetails> XMPremiumsDetailsList)
        {
            bool isEnough = false;
            //foreach ()
            //{

            //}
            return isEnough;
        }

        /// <summary>
        /// 自动生成销售出库单单号
        /// </summary>
        /// <returns></returns>
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



        /// <summary>
        /// 赠品TabPane 类型
        /// </summary>
        public string TabPanelPremiumsType
        {
            get
            {
                return CommonHelper.QueryString("TabPanelPremiumsType");
            }
        }
        /// <summary>
        /// 排单类型  0 批量排单  1  单个排单
        /// </summary>
        public int Type
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }

        public int PremiumsId
        {
            get
            {
                return CommonHelper.QueryStringInt("PremiumsId");
            }
        }
    }
}