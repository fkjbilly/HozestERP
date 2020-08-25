using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageProductionOrder;
using HozestERP.Common;
using HozestERP.Common.Utils;
using System.Transactions;

namespace HozestERP.Web.ManageProductionOrder
{
    public partial class XMProductionOrderDetailEdit : BaseAdministrationPage, ISearchPage
    {
        public string ManufacturersCodeRecord = "";
        public List<HozestERP.BusinessLogic.ManageProject.XMDelivery> DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
        public List<XMXLMInventory> XLMInventoryList = new List<XMXLMInventory>();
        public List<int> InventoryList = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var pingtai = base.XMProductionOrderService.GetXMProductionOrderById(this.XMProductionOrderID);
                this.pingtai2.Value = pingtai.PlatformTypeId.ToString();
                this.BindGrid(1, Master.PageSize);
            }
        }

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            //仓库绑定
            this.ddlWarehouseID.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(227, false);
            this.ddlWarehouseID.DataSource = codeList;
            this.ddlWarehouseID.DataTextField = "CodeName";
            this.ddlWarehouseID.DataValueField = "CodeID";
            this.ddlWarehouseID.DataBind();
            this.ddlWarehouseID.Items.Insert(0, new ListItem("---所有---", "-1"));

            this.Master.SetTitleVisible = false;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var productionOrderDetails = base.XMProductionOrderDetailsService.GetXMProductionOrderDetailsListByProductionOrderID(this.XMProductionOrderID);
            var pageList = new PagedList<XMProductionOrderDetails>(productionOrderDetails, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            ////新增编码行
            this.grdvClients.EditIndex = pageList.Count();
            pageList.Add(new XMProductionOrderDetails());
            this.Master.BindData(this.grdvClients, pageList);

        }

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                #region 修改
                if (e.CommandName.Equals("OrderProductUpdate"))
                {
                    //生产单详情
                    var productionOrderDetail = base.XMProductionOrderDetailsService.GetXMProductionOrderDetailsById(Convert.ToInt32(e.CommandArgument));
                    //编辑行
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    HtmlInputText lblManufacturers = (HtmlInputText)gvr.FindControl("lblManufacturers");//商品编码
                    HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("txtProductCode");//厂家编码
                    HtmlInputControl lblProductName = (HtmlInputControl)gvr.FindControl("lblProductName");
                    HtmlInputControl lblSpecifications = (HtmlInputControl)gvr.FindControl("lblSpecifications");
                    HtmlInputText txtProductNum = (HtmlInputText)gvr.FindControl("txtProductNum");
                    TextBox lblProductWeight = gvr.FindControl("lblProductWeight") as TextBox;
                    TextBox lblProductVolume = gvr.FindControl("lblProductVolume") as TextBox;
                    TextBox txtProductionNumber = gvr.FindControl("txtProductionNumber") as TextBox;
                    HtmlInputControl txtCompletionTime = gvr.FindControl("txtCompletionTime") as HtmlInputControl;
                    CheckBox chkStatus = gvr.FindControl("chkStatus") as CheckBox;
                    CheckBox chkIsSingleRow = gvr.FindControl("chkIsSingleRow") as CheckBox;

                    if (productionOrderDetail != null)
                    {
                        if (lblManufacturers != null)
                        {
                            productionOrderDetail.PlatformMerchantCode = lblManufacturers.Value;
                        }
                        if (txtProductCode != null)
                        {
                            productionOrderDetail.ManufacturersCode = txtProductCode.Value;
                        }
                        if (lblProductName != null)
                        {
                            productionOrderDetail.ProductName = lblProductName.Value;
                        }
                        if (lblSpecifications != null)
                        {
                            productionOrderDetail.Specifications = lblSpecifications.Value;
                        }
                        int productNum = 1;
                        if (txtProductNum != null && int.TryParse(txtProductNum.Value, out productNum))
                        {
                            productionOrderDetail.ProductNum = int.Parse(txtProductNum.Value);
                        }
                        if (lblProductWeight != null)
                        {
                            productionOrderDetail.ProductWeight = lblProductWeight.Text.Trim();
                        }
                        if (lblProductVolume != null)
                        {
                            productionOrderDetail.ProductVolume = lblProductVolume.Text.Trim();
                        }
                        if (txtProductionNumber != null)
                        {
                            productionOrderDetail.ProductionNumber = txtProductionNumber.Text.Trim();
                        }
                        DateTime EstimateStorageDate = new DateTime();
                        if (txtCompletionTime != null && DateTime.TryParse(txtCompletionTime.Value, out EstimateStorageDate))
                        {
                            productionOrderDetail.EstimateStorageDate = Convert.ToDateTime(txtCompletionTime.Value);
                        }
                        if (chkStatus != null)
                        {
                            productionOrderDetail.Status = chkStatus.Checked;
                        }
                        if (chkIsSingleRow != null)
                        {
                            productionOrderDetail.IsSingleRow = chkIsSingleRow.Checked;
                        }

                        productionOrderDetail.UpdateDate = DateTime.Now;
                        productionOrderDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMProductionOrderDetailsService.UpdateXMProductionOrderDetails(productionOrderDetail);
                        CheckStatus();
                        checkSingleRowStatus();
                    }
                    else
                    {
                        XMProductionOrderDetails details = new XMProductionOrderDetails();
                        details.ProductionOrderID = this.XMProductionOrderID;
                        if (lblManufacturers != null)
                        {
                            details.PlatformMerchantCode = lblManufacturers.Value;
                        }
                        if (txtProductCode != null)
                        {
                            details.ManufacturersCode = txtProductCode.Value;
                        }
                        if (lblProductName != null)
                        {
                            details.ProductName = lblProductName.Value;
                        }
                        if (lblSpecifications != null)
                        {
                            details.Specifications = lblSpecifications.Value;
                        }
                        int productNum = 1;
                        if (txtProductNum != null && int.TryParse(txtProductNum.Value, out productNum))
                        {
                            details.ProductNum = int.Parse(txtProductNum.Value);
                        }
                        if (lblProductWeight != null)
                        {
                            details.ProductWeight = lblProductWeight.Text.Trim();
                        }
                        if (lblProductVolume != null)
                        {
                            details.ProductVolume = lblProductVolume.Text.Trim();
                        }
                        if (txtProductionNumber != null)
                        {
                            details.ProductionNumber = txtProductionNumber.Text.Trim();
                        }
                        DateTime EstimateStorageDate = new DateTime();
                        if (txtCompletionTime != null && DateTime.TryParse(txtCompletionTime.Value, out EstimateStorageDate))
                        {
                            details.EstimateStorageDate = Convert.ToDateTime(txtCompletionTime.Value);
                        }
                        if (chkStatus != null)
                        {
                            details.Status = chkStatus.Checked;
                        }
                        if (chkIsSingleRow != null)
                        {
                            details.IsSingleRow = chkIsSingleRow.Checked;
                        }
                        details.IsEnable = false;
                        details.CreateDate = DateTime.Now;
                        details.CreateID = HozestERPContext.Current.User.CustomerID;
                        base.XMProductionOrderDetailsService.InsertXMProductionOrderDetails(details);
                        CheckStatus();
                        checkSingleRowStatus();
                    }
                    base.ShowMessage("添加成功！");
                    this.BindGrid(1, Master.PageSize);
                }
                #endregion
                ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMProductionOrderDetailEdit", "autoCompleteBind()", true);
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }
        }

        /// <summary>
        /// 更新主表排单状态 （已排单1  未排单0  部分排单2）
        /// </summary>
        private void checkSingleRowStatus()
        {
            bool isExsit = false;
            int singleRowStatus = 1;
            var productionOrderDetail = base.XMProductionOrderDetailsService.GetXMProductionOrderDetailsListByProductionOrderID(this.XMProductionOrderID);
            if (productionOrderDetail != null && productionOrderDetail.Count > 0)
            {
                foreach (XMProductionOrderDetails p in productionOrderDetail)
                {
                    if (!p.IsSingleRow.Value || p.IsSingleRow == null)
                    {
                        isExsit = true;
                    }
                }
            }
            if (!isExsit)
            {
                singleRowStatus = 1;  //已排单
            }
            else
            {
                singleRowStatus = 2;    //部分排单
            }
            //更新主表状态
            var productionOrder = base.XMProductionOrderService.GetXMProductionOrderById(this.XMProductionOrderID);
            if (productionOrder != null)
            {
                productionOrder.SingleRowStatus = singleRowStatus;
                productionOrder.UpdateDate = DateTime.Now;
                productionOrder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMProductionOrderService.UpdateXMProductionOrder(productionOrder);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckStatus()
        {
            bool isExsit = false;
            int status = 1000;
            var productionOrderDetail = base.XMProductionOrderDetailsService.GetXMProductionOrderDetailsListByProductionOrderID(this.XMProductionOrderID);
            if (productionOrderDetail != null && productionOrderDetail.Count > 0)
            {
                foreach (XMProductionOrderDetails p in productionOrderDetail)
                {
                    if (!p.Status.Value || p.Status == null)
                    {
                        isExsit = true;
                    }
                }
            }
            if (!isExsit)
            {
                status = 1004;  //全部入库
            }
            else
            {
                status = 1002;    //部分入库
            }
            //更新主表状态
            var productionOrder = base.XMProductionOrderService.GetXMProductionOrderById(this.XMProductionOrderID);
            if (productionOrder != null)
            {
                productionOrder.Status = status;
                productionOrder.UpdateDate = DateTime.Now;
                productionOrder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMProductionOrderService.UpdateXMProductionOrder(productionOrder);
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            if (int.TryParse(this.grdvClients.DataKeys[e.RowIndex].Value.ToString(), out Id))
            {
                var productionOrderDetail = base.XMProductionOrderDetailsService.GetXMProductionOrderDetailsById(Id);
                if (productionOrderDetail != null)
                {
                    if (productionOrderDetail.IsSingleRow == null || productionOrderDetail.IsSingleRow.Value)    //已排单无法删除
                    {
                        base.ShowMessage("已排单无法删除，操作失败！");
                    }
                    else if (!productionOrderDetail.IsSingleRow.Value)
                    {
                        productionOrderDetail.IsEnable = true;
                        productionOrderDetail.UpdateDate = DateTime.Now;
                        productionOrderDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMProductionOrderDetailsService.UpdateXMProductionOrderDetails(productionOrderDetail);
                        base.ShowMessage("操作成功！");
                    }
                    this.BindGrid(1, Master.PageSize);
                }
            }
        }

        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ProductionOrderDetail = e.Row.DataItem as XMProductionOrderDetails;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetDelivery_Click(object sender, EventArgs e)
        {
            int WarehouseID = int.Parse(this.ddlWarehouseID.SelectedValue.Trim());
            //曲美发货不设仓库
            //if (WarehouseID == -1)
            //{
            //    base.ShowMessage("你没有选择发货仓库！");
            //    return;
            //}

            List<int> list = this.Master.GetSelectedIds(this.grdvClients);
            list.Remove(0);
            if (list.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                string msg = "";
                int XMOrderInfoID = 1;
                var productionOrder = base.XMProductionOrderService.GetXMProductionOrderById(this.XMProductionOrderID);
                if (productionOrder != null)
                {
                    var orderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(productionOrder.OrderCode);
                    if (orderInfo != null)
                    {
                        XMOrderInfoID = orderInfo.ID;
                    }
                }
                var Info = base.XMOrderInfoService.GetXMOrderInfoByID(XMOrderInfoID);
                if (Info != null)
                {
                    int OrderInfoProductCount = 0;//有效的订单产品条数
                    int DeliveryProductCount = 0;//能排单的订单产品条数

                    DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
                    XLMInventoryList = new List<XMXLMInventory>();
                    InventoryList = new List<int>();

                    List<XMOrderInfoProductDetails> OrderInfoProductUnSpare = new List<XMOrderInfoProductDetails>();//无备用地址产品
                    List<XMOrderInfoProductDetails> OrderInfoProductSpare = new List<XMOrderInfoProductDetails>();//有备用地址产品
                    List<XMOrderInfoProductDetails> LatexPillowUnSpare = new List<XMOrderInfoProductDetails>();//乳胶枕，U型枕，无备用地址产品
                    List<XMOrderInfoProductDetails> LatexPillowSpare = new List<XMOrderInfoProductDetails>();//乳胶枕，U型枕，有备用地址产品
                    if (OrderInfoProductUnSpare.Count > 0)
                    {
                        msg = ToPlanBill(OrderInfoProductUnSpare, Info, WarehouseID, 1, msg);//无备用地址产品
                    }
                    if (LatexPillowUnSpare.Count > 0)
                    {
                        msg = ToPlanBill(LatexPillowUnSpare, Info, WarehouseID, 3, msg);//乳胶枕，U型枕，无备用地址产品
                    }
                    if (OrderInfoProductSpare.Count > 0)
                    {
                        msg = ToPlanBill(OrderInfoProductSpare, Info, WarehouseID, 2, msg);//有备用地址产品
                    }
                    if (LatexPillowSpare.Count > 0)
                    {
                        msg = ToPlanBill(LatexPillowSpare, Info, WarehouseID, 4, msg);//乳胶枕，U型枕，有备用地址产品
                    }

                    foreach (var item in DeliveryList)
                    {
                        if (item.XM_Delivery_Details != null && item.XM_Delivery_Details.Count > 0)
                        {
                            DeliveryProductCount += item.XM_Delivery_Details.Count;
                        }
                    }

                    if (OrderInfoProductCount > 0 && OrderInfoProductCount == DeliveryProductCount)
                    {
                        foreach (var item in DeliveryList)
                        {
                            base.XMDeliveryService.InsertXMDelivery(item);
                        }
                        //生产单产品排单状态变为true
                        foreach (int OrderInfoProductID in list)
                        {
                            //生产单信息
                            var info = base.XMProductionOrderDetailsService.GetXMProductionOrderDetailsById(OrderInfoProductID);
                            if (info != null)
                            {
                                info.IsSingleRow = true;
                                base.XMProductionOrderDetailsService.UpdateXMProductionOrderDetails(info);
                            }
                        }
                        //操作记录
                        //XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                        //record.PropertyName = "手动排单";
                        //record.OldValue = "IsSingleRow - false";
                        //record.NewValue = "IsSingleRow - true";
                        //record.OrderInfoId = Info.ID;
                        //record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        //record.UpdateTime = DateTime.Now;
                        //base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                    }

                    if (msg != "")
                    {
                        base.ShowMessage(msg);
                        return;
                    }
                    else
                    {
                        BindGrid(this.Master.PageIndex, this.Master.PageSize);
                        base.ShowMessage("排单成功！");
                    }
                }
            }
        }


        public string ToPlanBill(List<XMOrderInfoProductDetails> list, XMOrderInfo Info, int WarehouseID, int type, string msg)
        {
            if (type == 1 || type == 3)
            {
                bool ProductExist = false;
                if (GetPlanBillResult(list, Info, null, WarehouseID, type))//排单成功
                {
                    ProductExist = true;
                }

                if (!ProductExist)
                {
                    msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                }
            }
            else if (type == 2 || type == 4)
            {
                List<int?> Ids = new List<int?>();
                var IDs = list.Select(x => x.ID).ToList();
                var SpareAddressList = base.XMSpareAddressService.GetXMSpareAddressListByIDs(IDs, 709);
                foreach (var info in list)
                {
                    if (Ids.Contains(info.ID))
                    {
                        continue;
                    }
                    var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 709);
                    if (spareAddress != null)
                    {
                        //不同产品，相同地址
                        var SpareAddress = SpareAddressList.Where(x => x.FullName == spareAddress.FullName && x.Mobile == spareAddress.Mobile && x.DeliveryAddress == spareAddress.DeliveryAddress).ToList();
                        var OrderInfoProductIds = SpareAddress.Select(x => x.OtherID).ToList();
                        var List = list.Where(x => OrderInfoProductIds.Contains(x.ID)).ToList();
                        Ids.AddRange(OrderInfoProductIds);

                        bool ProductExist = false;
                        if (GetPlanBillResult(List, Info, spareAddress, WarehouseID, type))//排单成功
                        {
                            ProductExist = true;
                        }

                        if (!ProductExist)
                        {
                            msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                        }
                    }
                }
            }
            return msg;
        }

        public bool GetPlanBillResult(List<XMOrderInfoProductDetails> list, XMOrderInfo Info, XMSpareAddress SpareAddress, int WarehouseID, int type)
        {
            ManufacturersCodeRecord = "";
            bool complete = true;
            HozestERP.BusinessLogic.ManageProject.XMDelivery delivery = ToInsertDelivery(Info, SpareAddress, type);
            delivery.XM_Delivery_Details = new List<XMDeliveryDetails>();

            foreach (var info in list)
            {
                if (type == 1 || type == 2)
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(WarehouseID, info.TManufacturersCode, "");
                    if (exist.Count > 0 && exist[0].Inventory >= info.ProductNum)
                    {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.TManufacturersCode);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        if (delivery.OrderRemarks == Info.CustomerServiceRemark && !string.IsNullOrEmpty(info.SpareRemarks))
                        {
                            delivery.OrderRemarks = info.SpareRemarks;
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, WarehouseID));
                        //减喜临门当日库存
                        InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                        XLMInventoryList.Add(exist[0]);
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.TManufacturersCode + "，";
                    }
                }

                if (type == 3 || type == 4)//乳胶枕，U型枕，无备用地址
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(693, info.TManufacturersCode, "");//南方仓库
                    if (exist.Count > 0 && exist[0].Inventory >= info.ProductNum)
                    {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.TManufacturersCode);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        if (delivery.OrderRemarks == Info.CustomerServiceRemark && !string.IsNullOrEmpty(info.SpareRemarks))
                        {
                            delivery.OrderRemarks = info.SpareRemarks;
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, 693));
                        //减喜临门当日库存
                        InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                        XLMInventoryList.Add(exist[0]);
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.TManufacturersCode + "，";
                    }
                }
            }

            if (complete == true && delivery.XM_Delivery_Details != null && delivery.XM_Delivery_Details.Count > 0)
            {
                DeliveryList.Add(delivery);
            }

            return complete;
        }

        public HozestERP.BusinessLogic.ManageProject.XMDelivery ToInsertDelivery(XMOrderInfo Info, XMSpareAddress SpareAddress, int type)
        {
            HozestERP.BusinessLogic.ManageProject.XMDelivery info = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
            info.DeliveryTypeId = 480;//正常
            info.DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//发货单号;
            info.OrderCode = Info.OrderCode;
            if (type == 1 || type == 3)
            {
                info.FullName = Info.FullName;
                info.Mobile = Info.Mobile;
                info.Tel = Info.Tel;
                info.Province = Info.Province;
                info.City = Info.City;
                info.County = Info.County;
                info.DeliveryAddress = Info.DeliveryAddress;
            }
            else if (type == 2 || type == 4)
            {
                info.FullName = SpareAddress.FullName;
                info.Mobile = SpareAddress.Mobile;
                info.Tel = SpareAddress.Tel;
                info.Province = SpareAddress.Province;
                info.City = SpareAddress.City;
                info.County = SpareAddress.County;
                info.DeliveryAddress = SpareAddress.DeliveryAddress;
            }

            info.OrderRemarks = Info.CustomerServiceRemark;
            info.Shipper = 0;
            info.Price = 0;
            info.PrintBatch = 0;
            info.PrintQuantity = 0;
            info.IsDelivery = false;
            info.IsEnabled = false;
            info.CreateDate = DateTime.Now;
            info.CreateId = HozestERPContext.Current.User.CustomerID;
            info.UpdateDate = DateTime.Now;
            info.UpdateId = HozestERPContext.Current.User.CustomerID;
            //base.XMDeliveryService.InsertXMDelivery(info);
            return info;
        }

        protected void btnIsDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);
                if (customerInfoIDs.Count <= 0)
                {
                    base.ShowMessage("你没有选择任何记录");
                    return;
                }
                else
                {
                    int statuls = 0;
                    int count = 0;
                    int all = GetAllProdutionDetailCount(this.XMProductionOrderID);
                    foreach (int ID in customerInfoIDs)
                    {
                        var productionOrderDetail = base.XMProductionOrderDetailsService.GetXMProductionOrderDetailsById(ID);
                        if (productionOrderDetail != null)
                        {
                            count++;
                            productionOrderDetail.Status = true;
                            productionOrderDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                            productionOrderDetail.UpdateDate = DateTime.Now;
                            base.XMProductionOrderDetailsService.UpdateXMProductionOrderDetails(productionOrderDetail);
                        }
                    }
                    if (count < all)
                    {
                        statuls = 1002;
                    }
                    else
                    {
                        statuls = 1004;
                    }
                    if (count > 0)
                    {
                        var productionOrder = base.XMProductionOrderService.GetXMProductionOrderById(this.XMProductionOrderID);
                        if (productionOrder != null)
                        {
                            productionOrder.Status = statuls;
                            productionOrder.UpdateDate = DateTime.Now;
                            productionOrder.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMProductionOrderService.UpdateXMProductionOrder(productionOrder);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.ShowMessage("错误信息：" + ex.Message);
            }
        }
        /// <summary>
        /// 获取指定生产单包含产品详情明细数量
        /// </summary>
        /// <returns></returns>
        private int GetAllProdutionDetailCount(int proudctionOrderID)
        {
            int total = 0;
            var detail = base.XMProductionOrderDetailsService.GetXMProductionOrderDetailsListByProductionOrderID(proudctionOrderID);
            if (detail != null && detail.Count > 0)
            {
                total = detail.Count;
            }
            return total;
        }


        /// <summary>
        /// 订单id
        /// </summary>
        public int XMProductionOrderID
        {
            get
            {
                return CommonHelper.QueryStringInt("ID");
            }
        }

        public XMDeliveryDetails GetDeliveryDetails(XMOrderInfoProductDetails ProductDetails, string OrderCode, int WarehouseID)
        {
            string PrdouctName = "";
            string Specifications = "";

            XMDeliveryDetails detail = new XMDeliveryDetails();
            //detail.DeliveryId = DeliveryIDType;
            detail.DetailsTypeId = (int)StatusEnum.NormalOrder;//正常订单
            detail.OrderNo = OrderCode;
            var ProductDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(ProductDetails.PlatformMerchantCode, (int)ProductDetails.XM_OrderInfo.PlatformTypeId);
            if (ProductDetail != null && ProductDetail.Count > 0)
            {
                detail.ProductlId = ProductDetail[0].ProductId;
                var product = base.XMProductService.GetXMProductById((int)detail.ProductlId);
                if (product != null)
                {
                    PrdouctName = product.ProductName;
                    Specifications = product.Specifications;
                }
            }
            detail.PlatformMerchantCode = ProductDetails.PlatformMerchantCode;
            detail.PrdouctName = PrdouctName;
            detail.Specifications = Specifications;
            detail.ProductNum = (int)ProductDetails.ProductNum;
            detail.WarehouseID = WarehouseID;
            detail.IsEnabled = false;
            detail.CreateDate = DateTime.Now;
            detail.CreateID = HozestERPContext.Current.User.CustomerID;
            detail.UpdateDate = DateTime.Now;
            detail.UpdateID = HozestERPContext.Current.User.CustomerID;
            //IoC.Resolve<IXMDeliveryDetailsService>().InsertXMDeliveryDetails(detail);
            return detail;
        }

    }
}