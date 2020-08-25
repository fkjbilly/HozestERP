using System;
using System.Linq;
using HozestERP.Common;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageInventory
{
    public partial class ProductBarCodeList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initControl();
                BindGrid(1, Master.PageSize);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void initControl()
        {
            switch (this.Status)
            {
                case "Storage":
                    var storageDetails = base.XMStorageProductDetailsService.GetXMStorageProductDetailsById(this.PID);
                    if (storageDetails != null)
                    {
                        ltPlatFormCode.Text = storageDetails.PlatformMerchantCode;
                        ltProductName.Text = storageDetails.ProductName;
                    }
                    break;
                case "Delivery":
                    var deliveryDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(this.PID);
                    if (deliveryDetails != null)
                    {
                        ltPlatFormCode.Text = deliveryDetails.PlatformMerchantCode;
                        ltProductName.Text = deliveryDetails.ProductName;
                    }
                    break;
                case "SaleReturn":
                    var saleReturnDetails = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsById(this.PID);
                    if (saleReturnDetails != null)
                    {
                        if (saleReturnDetails.ProductId != null)
                        {
                            var products = base.XMProductService.GetXMProductById(saleReturnDetails.ProductId.Value);
                            if (products != null)
                            {
                                ltPlatFormCode.Text = products.ManufacturersCode;
                            }
                        }
                        ltProductName.Text = saleReturnDetails.ProductName;
                    }
                    break;
                case "Allocate":
                    var alloceateDetails = base.XMAllocateProductDetailsService.GetXMAllocateProductDetailsById(this.PID);
                    if (alloceateDetails != null)
                    {
                        ltPlatFormCode.Text = alloceateDetails.PlatformMerchantCode;
                        ltProductName.Text = alloceateDetails.ProductName;
                    }
                    break;
                case "Inventory":
                    var inventoryDetails = base.XMInventoryInfoService.GetXMInventoryInfoById(this.PID);
                    if (inventoryDetails != null)
                    {
                        ltPlatFormCode.Text = inventoryDetails.PlatformMerchantCode;
                        ltProductName.Text = inventoryDetails.ProductName;
                    }
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string BarCode = txtPlatFormCode.Text.Trim();
            switch (this.Status)
            {
                case "Storage":                             //入库产品条形码列表绑定
                    var storageBarCodeList = base.XMStorageProductBarCodeDetailService.GetXMStorageProductBarCodeDetailListByParm(BarCode, PID);
                    var storageBarCodePageList = new PagedList<XMStorageProductBarCodeDetail>(storageBarCodeList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                    if (this.RowEditIndex == -1)
                    {
                        this.grdvBarCodeList.EditIndex = storageBarCodePageList.Count();
                        storageBarCodePageList.Add(new XMStorageProductBarCodeDetail());
                    }
                    else
                    {
                        this.grdvBarCodeList.EditIndex = this.RowEditIndex;
                    }
                    this.Master.BindData(this.grdvBarCodeList, storageBarCodePageList, paramPageSize + 1);
                    break;
                case "Delivery":                           //出库产品条形码列表绑定
                    var saleDeliveryBarCodeList = base.XMSaleDeliveryBarCodeDetailService.GetXMSaleDeliveryBarCodeDetailListByParm(BarCode, PID);
                    var saleDeliveryBarCodePageList = new PagedList<XMSaleDeliveryBarCodeDetail>(saleDeliveryBarCodeList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                    if (this.RowEditIndex == -1)
                    {
                        this.grdvBarCodeList.EditIndex = saleDeliveryBarCodePageList.Count();
                        saleDeliveryBarCodePageList.Add(new XMSaleDeliveryBarCodeDetail());
                    }
                    else
                    {
                        this.grdvBarCodeList.EditIndex = this.RowEditIndex;
                    }
                    this.Master.BindData(this.grdvBarCodeList, saleDeliveryBarCodePageList, paramPageSize + 1);
                    break;
                case "SaleReturn":                           //退货产品条形码列表绑定
                    var saleReturnBarCodeList = base.XMSaleReturnBarCodeDetailService.GetXMSaleReturnBarCodeDetailListByParm(BarCode, PID);
                    var saleReturnBarCodePageList = new PagedList<XMSaleReturnBarCodeDetail>(saleReturnBarCodeList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                    if (this.RowEditIndex == -1)
                    {
                        this.grdvBarCodeList.EditIndex = saleReturnBarCodePageList.Count();
                        saleReturnBarCodePageList.Add(new XMSaleReturnBarCodeDetail());
                    }
                    else
                    {
                        this.grdvBarCodeList.EditIndex = this.RowEditIndex;
                    }
                    this.Master.BindData(this.grdvBarCodeList, saleReturnBarCodePageList, paramPageSize + 1);
                    break;
                case "Allocate":                                                      //调拨产品条形码列表绑定
                    var allocateBarCodeList = base.XMAllocateProductBarCodeDetailService.GetXMAllocateProductBarCodeDetailListByParm(BarCode, PID);
                    var allocateBarCodePageList = new PagedList<XMAllocateProductBarCodeDetail>(allocateBarCodeList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                    if (this.RowEditIndex == -1)
                    {
                        this.grdvBarCodeList.EditIndex = allocateBarCodePageList.Count();
                        allocateBarCodePageList.Add(new XMAllocateProductBarCodeDetail());
                    }
                    else
                    {
                        this.grdvBarCodeList.EditIndex = this.RowEditIndex;
                    }
                    this.Master.BindData(this.grdvBarCodeList, allocateBarCodePageList, paramPageSize + 1);
                    break;
                case "Inventory":                                          //仓库库存产品条形码列表绑定
                    var inventoryBarCodeList = base.XMInventoryBarcodeDetailService.GetXMInventoryBarcodeDetailListByParm(BarCode, this.PID);
                    var inventoryBarCodePageList = new PagedList<XMInventoryBarcodeDetail>(inventoryBarCodeList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                    this.Master.BindData(this.grdvBarCodeList, inventoryBarCodePageList);
                    break;
            }
        }

        protected void grdvBarCodeList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            TextBox txtBarCode = grdvBarCodeList.Rows[e.NewEditIndex].Cells[0].FindControl("txtBarCodes") as TextBox;
            if (txtBarCode != null)
            {
                txtBarCode.Text = "";
                txtBarCode.Focus();
            }
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void grdvBarCodeList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void grdvBarCodeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    switch (this.Status)
                    {
                        case "Storage":
                            var storageBarcodes = base.XMStorageProductBarCodeDetailService.GetXMStorageProductBarCodeDetailById(int.Parse(id));
                            if (storageBarcodes != null)
                            {
                                storageBarcodes.IsEnable = true;
                                storageBarcodes.UpdateDate = DateTime.Now;
                                storageBarcodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMStorageProductBarCodeDetailService.UpdateXMStorageProductBarCodeDetail(storageBarcodes);
                            }
                            break;
                        case "Delivery":
                            var deliveryBarcodes = base.XMSaleDeliveryBarCodeDetailService.GetXMSaleDeliveryBarCodeDetailById(int.Parse(id));
                            if (deliveryBarcodes != null)
                            {
                                deliveryBarcodes.IsEnable = true;
                                deliveryBarcodes.UpdateDate = DateTime.Now;
                                deliveryBarcodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMSaleDeliveryBarCodeDetailService.UpdateXMSaleDeliveryBarCodeDetail(deliveryBarcodes);
                            }
                            break;
                        case "SaleReturn":
                            var saleReturnBarcodes = base.XMSaleReturnBarCodeDetailService.GetXMSaleReturnBarCodeDetailById(int.Parse(id));
                            if (saleReturnBarcodes != null)
                            {
                                saleReturnBarcodes.IsEnable = true;
                                saleReturnBarcodes.UpdateDate = DateTime.Now;
                                saleReturnBarcodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMSaleReturnBarCodeDetailService.UpdateXMSaleReturnBarCodeDetail(saleReturnBarcodes);
                            }
                            break;
                        case "Allocate":
                            var allocateBarcodes = base.XMAllocateProductBarCodeDetailService.GetXMAllocateProductBarCodeDetailById(int.Parse(id));
                            if (allocateBarcodes != null)
                            {
                                allocateBarcodes.IsEnable = true;
                                allocateBarcodes.UpdateDate = DateTime.Now;
                                allocateBarcodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMAllocateProductBarCodeDetailService.UpdateXMAllocateProductBarCodeDetail(allocateBarcodes);
                            }
                            break;
                    }
                    base.ShowMessage("操作成功！");
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                }
            }
            #endregion
        }

        protected void grdvBarCodeList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = 0;
            int.TryParse(this.grdvBarCodeList.DataKeys[e.RowIndex].Value.ToString(), out id);
            if (id != 0)                   //编辑
            {
                var row = this.grdvBarCodeList.Rows[e.RowIndex];
                TextBox txtBarCode = row.FindControl("txtBarCodes") as TextBox;
                switch (this.Status)
                {
                    case "Storage":
                        var storageBarcodes = base.XMStorageProductBarCodeDetailService.GetXMStorageProductBarCodeDetailById(id);
                        if (storageBarcodes != null)
                        {
                            if (txtBarCode != null)
                            {
                                storageBarcodes.BarCode = txtBarCode.Text.Trim();
                                storageBarcodes.UpdateDate = DateTime.Now;
                                storageBarcodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMStorageProductBarCodeDetailService.UpdateXMStorageProductBarCodeDetail(storageBarcodes);
                            }
                        }
                        break;
                    case "Delivery":
                        var deliveryBarcodes = base.XMSaleDeliveryBarCodeDetailService.GetXMSaleDeliveryBarCodeDetailById(id);
                        if (deliveryBarcodes != null)
                        {
                            if (txtBarCode != null)
                            {
                                deliveryBarcodes.BarCode = txtBarCode.Text.Trim();
                                deliveryBarcodes.UpdateDate = DateTime.Now;
                                deliveryBarcodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMSaleDeliveryBarCodeDetailService.UpdateXMSaleDeliveryBarCodeDetail(deliveryBarcodes);
                            }
                        }
                        break;
                    case "SaleReturn":
                        var saleReturnBarcodes = base.XMSaleReturnBarCodeDetailService.GetXMSaleReturnBarCodeDetailById(id);
                        if (saleReturnBarcodes != null)
                        {
                            if (txtBarCode != null)
                            {
                                saleReturnBarcodes.BarCode = txtBarCode.Text.Trim();
                                saleReturnBarcodes.UpdateDate = DateTime.Now;
                                saleReturnBarcodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMSaleReturnBarCodeDetailService.UpdateXMSaleReturnBarCodeDetail(saleReturnBarcodes);
                            }
                        }
                        break;
                    case "Allocate":
                        var allocateBarcodes = base.XMAllocateProductBarCodeDetailService.GetXMAllocateProductBarCodeDetailById(id);
                        if (allocateBarcodes != null)
                        {
                            if (txtBarCode != null)
                            {
                                allocateBarcodes.BarCode = txtBarCode.Text.Trim();
                                allocateBarcodes.UpdateDate = DateTime.Now;
                                allocateBarcodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMAllocateProductBarCodeDetailService.UpdateXMAllocateProductBarCodeDetail(allocateBarcodes);
                            }
                        }
                        break;
                }
                this.RowEditIndex = -1;
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            }
            else            //新增
            {
                var row = this.grdvBarCodeList.Rows[e.RowIndex];
                TextBox txtBarCode = row.FindControl("txtBarCodes") as TextBox;
                switch (this.Status)
                {
                    case "Storage":
                        var storageBarCodes = base.XMStorageProductBarCodeDetailService.GetXMStorageProductBarCodeDetailListBySpdID(this.PID);
                        var storageProductDetails = base.XMStorageProductDetailsService.GetXMStorageProductDetailsById(this.PID);
                        if (storageProductDetails != null)
                        {
                            int storageCount = storageProductDetails.ProductsCount;
                            if (storageBarCodes.Count < storageCount)             //入库商品条形码数量小于入库数量  可以新增
                            {
                                XMStorageProductBarCodeDetail sDetails = new XMStorageProductBarCodeDetail();
                                sDetails.SpdId = this.PID;
                                sDetails.ProductId = storageProductDetails.ProductId;
                                sDetails.PlatformMerchantCode = storageProductDetails.PlatformMerchantCode;
                                sDetails.BarCode = txtBarCode.Text.Trim();
                                sDetails.CreateDate = sDetails.UpdateDate = DateTime.Now;
                                sDetails.CreateID = sDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                sDetails.IsEnable = false;
                                base.XMStorageProductBarCodeDetailService.InsertXMStorageProductBarCodeDetail(sDetails);
                            }
                            else
                            {
                                ShowMessage("入库商品条形码数量大于入库数量，无法添加条形码！");
                                return;
                            }
                        }
                        break;
                    case "Delivery":
                        var deliveryBarcodes = base.XMSaleDeliveryBarCodeDetailService.GetXMSaleDeliveryBarCodeDetailListBySpdID(this.PID);
                        var deliveryPorductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(this.PID);
                        if (deliveryPorductDetails != null)
                        {
                            int deliveryCount = deliveryPorductDetails.SaleCount.Value;    //销售出库数量
                            if (deliveryBarcodes.Count < deliveryCount)                 //出库商品条形码数量小于出库数量  可以新增
                            {
                                XMSaleDeliveryBarCodeDetail dDetail = new XMSaleDeliveryBarCodeDetail();
                                dDetail.SpdId = this.PID;
                                dDetail.ProductId = deliveryPorductDetails.ProductId;
                                dDetail.PlatformMerchantCode = deliveryPorductDetails.PlatformMerchantCode;
                                dDetail.BarCode = txtBarCode.Text.Trim();
                                dDetail.CreateDate = dDetail.UpdateDate = DateTime.Now;
                                dDetail.CreateID = dDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                dDetail.IsEnable = false;
                                base.XMSaleDeliveryBarCodeDetailService.InsertXMSaleDeliveryBarCodeDetail(dDetail);
                            }
                            else
                            {
                                ShowMessage("出库商品条形码数量大于出库数量，无法添加条形码！");
                                return;
                            }
                        }
                        break;
                    case "SaleReturn":
                        var saleReturnBarcodes = base.XMSaleReturnBarCodeDetailService.GetXMSaleReturnBarCodeDetailListBySrdID(this.PID);
                        var saleReturnPorductDetails = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsById(this.PID);
                        if (saleReturnPorductDetails != null)
                        {
                            int saleReturnCount = saleReturnPorductDetails.RejectionProdcutsCount.Value;
                            if (saleReturnBarcodes.Count < saleReturnCount)
                            {
                                XMSaleReturnBarCodeDetail rDetails = new XMSaleReturnBarCodeDetail();
                                rDetails.SpdId = this.PID;
                                rDetails.ProductId = saleReturnPorductDetails.ProductId;
                                rDetails.BarCode = txtBarCode.Text.Trim();
                                rDetails.CreateDate = rDetails.UpdateDate = DateTime.Now;
                                rDetails.CreateID = rDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                rDetails.IsEnable = false;
                                base.XMSaleReturnBarCodeDetailService.InsertXMSaleReturnBarCodeDetail(rDetails);
                            }
                            else
                            {
                                ShowMessage("退货商品条形码数量大于退货数量，无法添加条形码！");
                                return;
                            }
                        }
                        break;
                    //case "Allocate":
                    //    break;
                }
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            }
        }


        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvBarCodeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                HiddenField spdID = e.Row.FindControl("hiddPID") as HiddenField;
                TextBox txtBarCodes = e.Row.FindControl("txtBarCodes") as TextBox;
                if (txtBarCodes != null)
                {
                    txtBarCodes.Focus();
                    txtBarCodes.Attributes.Add("onkeydown", "if(event.keyCode==13){document.all." + btnSaveBarCodes.UniqueID + ".click();return false}");
                }
                switch (this.Status)
                {
                    case "Storage":
                        if (spdID != null && spdID.Value != "")
                        {
                            int id = int.Parse(spdID.Value);
                            var storageDetail = base.XMStorageProductDetailsService.GetXMStorageProductDetailsById(id);
                            if (storageDetail != null)
                            {
                                var storage = base.XMStorageService.GetXMStorageById(storageDetail.StorageId);
                                if (storage != null)
                                {
                                    if (storage.BillStatus == 1000)    //已入库 条形码列表只能查看 无法删除和修改
                                    {
                                        imgBtnEdit.Visible = false;
                                        imgBtnDelete.Visible = false;
                                    }
                                }
                            }
                        }
                        break;
                    case "Delivery":
                        if (spdID != null && spdID.Value != "")
                        {
                            int id = int.Parse(spdID.Value);
                            var saleDeliveryDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(id);
                            if (saleDeliveryDetails != null)
                            {
                                var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(saleDeliveryDetails.SaleDeliveryId);
                                if (saleDelivery != null)
                                {
                                    if (saleDelivery.BillStatus == 1000)      //已出库  条形码列表只能查看 无法删除和修改
                                    {
                                        imgBtnEdit.Visible = false;
                                        imgBtnDelete.Visible = false;
                                    }
                                }
                            }
                        }
                        break;
                    case "SaleReturn":
                        if (spdID != null && spdID.Value != "")
                        {
                            int id = int.Parse(spdID.Value);
                            var saleReturnDetails = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsById(id);
                            if (saleReturnDetails != null)
                            {
                                var saleReturn = base.XMSaleReturnService.GetXMSaleReturnById(saleReturnDetails.SaleReturnId);
                                if (saleReturn != null)
                                {
                                    if (saleReturn.BillStatus == 1000)    //已退货入库产品 条形码列表只能查看 无法修改和删除
                                    {
                                        imgBtnEdit.Visible = false;
                                        imgBtnDelete.Visible = false;
                                    }
                                }
                            }
                        }
                        break;
                    case "Inventory":
                        imgBtnEdit.Visible = false;
                        imgBtnDelete.Visible = false;
                        btnSaveBarCodes.Visible = false;
                        break;
                }
            }
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void btnSaveBarCodes_Click(object sender, EventArgs e)
        {
            TextBox txtBarCode = grdvBarCodeList.Rows[grdvBarCodeList.Rows.Count - 1].FindControl("txtBarCodes") as TextBox;
            if (txtBarCode != null)
            {
                switch (this.Status)
                {
                    case "Storage":
                        if (txtBarCode.Text.Trim() != "")
                        {
                            var info = base.XMStorageProductBarCodeDetailService.GetXMStorageProductBarCodeDetailByParm(this.PID, txtBarCode.Text.Trim());
                            if (info != null)
                            {
                                ShowMessage("条形码已经存在，无法添加条形码！");
                                return;
                            }
                        }
                        else
                        {
                            ShowMessage("请录入条形码！");
                            return;
                        }
                        var storageBarCodes = base.XMStorageProductBarCodeDetailService.GetXMStorageProductBarCodeDetailListBySpdID(this.PID);
                        var storageProductDetails = base.XMStorageProductDetailsService.GetXMStorageProductDetailsById(this.PID);
                        if (storageProductDetails != null)
                        {
                            int storageCount = storageProductDetails.ProductsCount;
                            if (storageBarCodes.Count < storageCount)             //入库商品条形码数量小于入库数量  可以新增
                            {
                                XMStorageProductBarCodeDetail sDetails = new XMStorageProductBarCodeDetail();
                                sDetails.SpdId = this.PID;
                                sDetails.ProductId = storageProductDetails.ProductId;
                                sDetails.PlatformMerchantCode = storageProductDetails.PlatformMerchantCode;
                                sDetails.BarCode = txtBarCode.Text.Trim();
                                sDetails.CreateDate = sDetails.UpdateDate = DateTime.Now;
                                sDetails.CreateID = sDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                sDetails.IsEnable = false;
                                base.XMStorageProductBarCodeDetailService.InsertXMStorageProductBarCodeDetail(sDetails);
                            }
                            else
                            {
                                ShowMessage("入库商品条形码数量大于入库数量，无法添加条形码！");
                                return;
                            }
                        }
                        break;
                    case "Delivery":
                        if (txtBarCode.Text.Trim() != "")
                        {
                            var info = base.XMSaleDeliveryBarCodeDetailService.GetXMSaleDeliveryBarCodeDetailByParm(this.PID, txtBarCode.Text.Trim());
                            if (info != null)
                            {
                                ShowMessage("条形码已经存在，无法添加条形码！");
                                return;
                            }
                        }
                        else
                        {
                            ShowMessage("请录入条形码！");
                            return;
                        }
                        var deliveryBarcodes = base.XMSaleDeliveryBarCodeDetailService.GetXMSaleDeliveryBarCodeDetailListBySpdID(this.PID);
                        var deliveryPorductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(this.PID);
                        if (deliveryPorductDetails != null)
                        {
                            int deliveryCount = deliveryPorductDetails.SaleCount.Value;    //销售出库数量
                            if (deliveryBarcodes.Count < deliveryCount)                 //出库商品条形码数量小于出库数量  可以新增
                            {
                                XMSaleDeliveryBarCodeDetail dDetail = new XMSaleDeliveryBarCodeDetail();
                                dDetail.SpdId = this.PID;
                                dDetail.ProductId = deliveryPorductDetails.ProductId;
                                dDetail.PlatformMerchantCode = deliveryPorductDetails.PlatformMerchantCode;
                                dDetail.BarCode = txtBarCode.Text.Trim();
                                dDetail.CreateDate = dDetail.UpdateDate = DateTime.Now;
                                dDetail.CreateID = dDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                dDetail.IsEnable = false;
                                base.XMSaleDeliveryBarCodeDetailService.InsertXMSaleDeliveryBarCodeDetail(dDetail);
                            }
                            else
                            {
                                ShowMessage("出库商品条形码数量大于出库数量，无法添加条形码！");
                                return;
                            }
                        }
                        break;
                    case "SaleReturn":
                        if (txtBarCode.Text.Trim() != "")
                        {
                            var info = base.XMSaleReturnBarCodeDetailService.GetXMSaleReturnBarCodeDetailByParm(this.PID, txtBarCode.Text.Trim());
                            if (info != null)
                            {
                                ShowMessage("条形码已经存在，无法添加条形码！");
                                return;
                            }
                        }
                        else
                        {
                            ShowMessage("请录入条形码！");
                            return;
                        }
                        var saleReturnBarcodes = base.XMSaleReturnBarCodeDetailService.GetXMSaleReturnBarCodeDetailListBySrdID(this.PID);
                        var saleReturnPorductDetails = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsById(this.PID);
                        if (saleReturnPorductDetails != null)
                        {
                            int saleReturnCount = saleReturnPorductDetails.RejectionProdcutsCount.Value;
                            if (saleReturnBarcodes.Count < saleReturnCount)
                            {
                                XMSaleReturnBarCodeDetail rDetails = new XMSaleReturnBarCodeDetail();
                                rDetails.SpdId = this.PID;
                                rDetails.ProductId = saleReturnPorductDetails.ProductId;
                                rDetails.BarCode = txtBarCode.Text.Trim();
                                rDetails.CreateDate = rDetails.UpdateDate = DateTime.Now;
                                rDetails.CreateID = rDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                rDetails.IsEnable = false;
                                base.XMSaleReturnBarCodeDetailService.InsertXMSaleReturnBarCodeDetail(rDetails);
                            }
                            else
                            {
                                ShowMessage("退货商品条形码数量大于退货数量，无法添加条形码！");
                                return;
                            }
                        }
                        break;
                }

            }
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }


        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        #endregion

        public int RowEditIndex
        {
            get
            {
                int editIndex = -1;
                try
                {
                    int.TryParse(ViewState["RowEditIndex"].ToString(), out editIndex);
                }
                catch
                {
                }
                return editIndex;
            }
            set
            {
                ViewState["RowEditIndex"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PID
        {
            get
            {
                return CommonHelper.QueryStringInt("ID");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            get { return CommonHelper.QueryString("Status"); }
        }

    }
}