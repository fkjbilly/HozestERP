using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using System.Transactions;
using System.Linq;

namespace HozestERP.Web.ManageInventory
{
    //已入库采购退货单
    public partial class StoragedRejectedList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                BindGrid(1, Master.PageSize);
            }
        }

        /// <summary>
        /// 返回状态
        /// </summary>
        /// <param name="billStatus"></param>
        /// <returns></returns>
        public string getStatus(string billStatus)
        {
            string statusname = "";
            switch (billStatus)
            {
                case "0":
                    statusname = "待出库";
                    break;
                case "1000":
                    statusname = "已出库";
                    break;
            }
            return statusname;
        }

        public string getRejectWareHouses(int RejectedID)
        {
            string wareHouses = "";



            var rejectedInfo = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(RejectedID);
            if (rejectedInfo != null)
            {
                var PurchaseRejectedProductDetails = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(rejectedInfo.Id);
                foreach (XMPurchaseRejectedProductDetails PurchaseRejectedProductDetailsinfo in PurchaseRejectedProductDetails)
                {
                    if (PurchaseRejectedProductDetailsinfo.InventoryInfoID != null)
                    {
                        var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(int.Parse(PurchaseRejectedProductDetailsinfo.InventoryInfoID.ToString()));
                        if (InventoryInfo != null)
                        {
                            wareHouses += InventoryInfo.WfName + " ";
                        }
                    }
                    else
                    {
                        var storageInfo = base.XMStorageService.GetXMStorageById(rejectedInfo.MId);
                        if (storageInfo != null)
                        {
                            wareHouses = storageInfo.WareHouseName;
                        }
                    }
                }
            }
            return wareHouses;
        }

        /// <summary>
        /// 根据当前用户的角色获取包含用户customerId 并拼接成字符串形式 用逗号隔开
        /// </summary>
        /// <returns></returns>
        private string GetInCludeCustomerByRole()
        {
            string cids = HozestERPContext.Current.User.CustomerID.ToString() + ",";
            List<CustomerInfo> list = new List<CustomerInfo>();
            int customerId = HozestERPContext.Current.User.CustomerID;
            var customerroleList = IoC.Resolve<ICustomerService>().GetCustomerRolesByCustomerId(customerId);//用户权限表
            if (customerroleList != null && customerroleList.Count > 0)
            {
                foreach (var s in customerroleList)      //遍历该用户所有角色
                {
                    list = CustomerService.GetCustomerRoleStaffPrivilegesByCustomerId(s.CustomerRoleID);
                    if (list.Count > 0)
                    {
                        foreach (CustomerInfo Info in list)       //遍历所有包含人员
                        {
                            cids = cids + Info.CustomerID + ",";
                        }
                    }
                }
            }
            if (cids != "" && cids.Length > 0)
            {
                cids = cids.Substring(0, cids.Length - 1);
            }
            return cids;
        }


        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //获取用户角色
            string customerids = GetInCludeCustomerByRole();  //customerIds
            string rejectedCode = txtRejectedCode.Text.Trim();    //退货单号自动生成 
            string productName = txtProductName.Text.Trim();    //产品名称
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            int supplierId = ddlSupplierList.SelectedValue == "" ? -1 : Convert.ToInt16(ddlSupplierList.SelectedValue);                   //供应商ID
            int status = Convert.ToInt16(ddlVerify.SelectedValue);         // 是否审核
            DateTime date = DateTime.Now;
            if (Begin != "" || End != "")
            {
                if (Begin == "" || End == "" || !DateTime.TryParse(Begin, out date) || !DateTime.TryParse(End, out date))
                {
                    base.ShowMessage("日期格式不正确！");
                    return;
                }
            }
            if (End != "")
            {
                End = DateTime.Parse(End).AddDays(1).ToString("yyyy-MM-dd");
            }
            //已入库退货单列表
            var list = base.XMPurchaseRejectedService.GetXMPurchaseRejectedListByParm(rejectedCode,productName, Begin, End, supplierId, status, customerids, true);
            var pageList = new PagedList<XMPurchaseRejected>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvRejected, pageList);
        }

        public string CustomerName(string customerID)
        {
            string name = "";
            var customer = base.CustomerInfoService.GetCustomerInfoByID(Convert.ToInt16(customerID));
            if (customer != null)
            {
                name = customer.FullName;
            }
            return name;
        }

        private void loadData()
        {
            //绑定供应商列表
            var suppliers = base.XMSuppliersService.GetXMSuppliersList();
            if (suppliers != null && suppliers.Count > 0)
            {
                ddlSupplierList.DataSource = suppliers;
                ddlSupplierList.DataTextField = "SupplierName";
                ddlSupplierList.DataValueField = "Id";
                ddlSupplierList.DataBind();
                this.ddlSupplierList.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddlSupplierList.Items[0].Selected = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvRejected_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMPurchaseRejected;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑已入库采购退货单','" + CommonHelper.GetStoreLocation() +
        "ManageInventory/StoragedRejectedAdd.aspx?Type=1"
          + "&&RejectedID=" + info.Id + "&&StorageID=" + info.MId
        + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('查看已入库采购退货单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/StoragedRejectedAdd.aspx?Type=2"
       + "&&RejectedID=" + info.Id + "&&StorageID=" + info.MId
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }

                var rejected = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(info.Id);
                if (rejected != null)
                {
                    int isAudit = rejected.IsAudit.Value ? 1 : 0;
                    switch (isAudit)
                    {
                        case 0:
                            if (imgProductDetails != null)
                            {
                                imgProductDetails.Visible = false;
                            }
                            break;
                        case 1:
                            if (imgBtnEdit != null)
                            {
                                imgBtnEdit.Visible = false;
                            }
                            if (imgBtnDelete != null)
                            {
                                imgBtnDelete.Visible = false;
                            }
                            if (imgProductDetails != null)
                            {
                                imgProductDetails.Visible = true;
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvRejected_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    //删除退货单主表信息和退货单产品明细表
                    var rejectedInfo = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(int.Parse(id));
                    if (rejectedInfo != null)
                    {
                        //珊瑚主表
                        rejectedInfo.IsEnable = true;
                        rejectedInfo.UpdateDate = DateTime.Now;
                        rejectedInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMPurchaseRejectedService.UpdateXMPurchaseRejected(rejectedInfo);
                        var details = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(rejectedInfo.Id);
                        if (details != null && details.Count > 0)
                        {
                            foreach (XMPurchaseRejectedProductDetails parm in details)
                            {
                                parm.IsEnable = true;
                                parm.UpdateDate = DateTime.Now;
                                parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMPurchaseRejectedProductDetailsService.UpdateXMPurchaseRejectedProductDetails(parm);
                            }
                        }
                        base.ShowMessage("操作成功！");
                    }
                    else
                    {
                        base.ShowMessage("未查到该数据！");
                    }
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                }
            }
            #endregion
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

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAudit_Click(object sender, EventArgs e)
        {
            List<int> RejectedIDs = this.Master.GetSelectedIds(this.grdvRejected);
            if (RejectedIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in RejectedIDs)
                {
                    var rejected = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(Convert.ToInt32(ID));
                    if (rejected != null)
                    {
                        rejected.IsAudit = true;
                        rejected.UpdateDate = DateTime.Now;
                        rejected.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        base.XMPurchaseRejectedService.UpdateXMPurchaseRejected(rejected);
                    }
                }

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功.");
            }
        }

        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAuditFalse_Click(object sender, EventArgs e)
        {
            List<int> rejectedIDs = this.Master.GetSelectedIds(this.grdvRejected);
            if (rejectedIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in rejectedIDs)
                {
                    var rejecteds = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(Convert.ToInt32(ID));
                    if (rejecteds != null)
                    {
                        rejecteds.IsAudit = false;
                        rejecteds.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        rejecteds.UpdateDate = DateTime.Now;
                        base.XMPurchaseRejectedService.UpdateXMPurchaseRejected(rejecteds);
                    }
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool getIsAudit(int id)
        {
            bool isAudit = false;
            var Info = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(id);
            if (Info != null && Info.IsAudit != null)
            {
                isAudit = (bool)Info.IsAudit;
            }
            return isAudit;
        }

        /// <summary>
        /// 退货提交出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRejectedDelivery_Click(object sender, EventArgs e)
        {
            bool isAudit = false;
            bool isInventLess = false;
            string errMessage = "";
            List<int> rejectedIDs = this.Master.GetSelectedIds(this.grdvRejected);
            if (rejectedIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                List<SaleDeliveryProduct> List = new List<SaleDeliveryProduct>();
                foreach (int ID in rejectedIDs)
                {
                    int warehousesID = 1;
                    var storageRejected = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(ID);
                    if (storageRejected != null)
                    {
                        var storages = base.XMStorageService.GetXMStorageById(storageRejected.MId);
                        if (storages != null)
                        {
                            warehousesID = storages.WareHouseId;
                        }
                        var rejectedProductDetails = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(storageRejected.Id);
                        if (rejectedProductDetails != null && rejectedProductDetails.Count > 0)
                        {
                            foreach (XMPurchaseRejectedProductDetails Info in rejectedProductDetails)
                            {
                                SaleDeliveryProduct list = new SaleDeliveryProduct();
                                list.pcode = Info.PlatformMerchantCode;
                                list.saleDeliveryCount = Info.RejectionCount;
                                list.wareHoueseID = warehousesID;
                                list.InventoryInfoID = int.Parse(Info.InventoryInfoID.ToString());
                                List.Add(list);
                            }
                        }

                        bool RejectedIsAudit = storageRejected.IsAudit == null ? false : storageRejected.IsAudit.Value;
                        if (!RejectedIsAudit)
                        {
                            isAudit = true;
                            errMessage = errMessage + storageRejected.Ref + ";";
                            break;
                        }
                    }
                }

                if (List != null && List.Count > 0)
                {
                    var List2 = from l in List
                                group l by new { l.pcode, l.wareHoueseID,l.InventoryInfoID } into g
                                select new
                                {
                                    pcode = g.Key.pcode,
                                    wareHoueseID = g.Key.wareHoueseID,
                                    saleDeliveryCount = g.Sum(a => a.saleDeliveryCount),
                                    InventoryInfoID=g.Key.InventoryInfoID
                                };

                    if (List2 != null && List2.Count() > 0)
                    {
                        foreach (var parm in List2)
                        {
                            var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(parm.InventoryInfoID);
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

            }
            if (isAudit)
            {
                base.ShowMessage("已入库退货单号为：" + errMessage + "未通过审核，无法出库！");
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                return;
            }
            if (isInventLess)
            {
                base.ShowMessage("已入库退货单号为：" + errMessage + "库存不足，无法出库！");
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                return;
            }
            if (rejectedIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                //提交出库
                foreach (int ID in rejectedIDs)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        int warehousesID = 1;
                        var rejectedInfo = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(ID);
                        if (rejectedInfo != null && rejectedInfo.BillStatus == 0)
                        {
                            rejectedInfo.BillStatus = 1000;   //状态更新为已出库
                            rejectedInfo.UpdateDate = DateTime.Now;
                            rejectedInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMPurchaseRejectedService.UpdateXMPurchaseRejected(rejectedInfo);
                            //更新产品库存表（减掉出库数量）
                            var storageInfo = base.XMStorageService.GetXMStorageById(rejectedInfo.MId);
                            if (storageInfo != null)
                            {
                                warehousesID = storageInfo.WareHouseId;       //入库仓库ID
                            }
                            var rejectedProductDetails = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(rejectedInfo.Id);
                            if (rejectedProductDetails != null && rejectedProductDetails.Count > 0)
                            {
                                foreach (XMPurchaseRejectedProductDetails parm in rejectedProductDetails)
                                {
                                    string code = parm.PlatformMerchantCode;              //商品编码
                                    var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(int.Parse(parm.InventoryInfoID.ToString()));
                                    if (InventoryInfo != null)                             //商品编码为code的产品在库存表中已经存在 更新库存数量
                                    {
                                        InventoryInfo.StockNumber = InventoryInfo.StockNumber - parm.RejectionCount;             //库存减掉出库量
                                        InventoryInfo.CanOrderCount = InventoryInfo.StockNumber;
                                        InventoryInfo.UpdateDate = DateTime.Now;
                                        InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
                                    }
                                    //更新库存总账主表数据   从表添加一条记录
                                    UpdateInventoryLederInfo(warehousesID, parm);
                                }
                            }
                        }
                        scope.Complete();
                    }
                }
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("提交出库成功！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHousesId"></param>
        /// <param name="info"></param>
        private void UpdateInventoryLederInfo(int wareHousesId, XMPurchaseRejectedProductDetails info)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, info.PlatformMerchantCode);
            if (inventoryLeder != null)     //更新数据
            {
                //更新出库数量
                inventoryLeder.OutCount = (inventoryLeder.OutCount == null ? 0 : inventoryLeder.OutCount) + info.RejectionCount;
                inventoryLeder.OutPrice = CalculateProductPrice(wareHousesId, info, 1002);
                inventoryLeder.OutMoney = inventoryLeder.OutPrice * inventoryLeder.OutCount;
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
                inventoryLederInfo.OutCount = info.RejectionCount;
                inventoryLederInfo.OutPrice = info.RejectionProductPrice;
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.InCount = 0;
                inventoryLederInfo.InPrice = info.RejectionProductPrice;
                inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                inventoryLederInfo.AfloatCount = 0;
                inventoryLederInfo.AfloatPrice = info.RejectionProductPrice;
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
            details.OutCount = info.RejectionCount;
            details.OutPrice = info.RejectionProductPrice;
            details.OutMoney = info.RejectionCount * info.RejectionProductPrice;
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
            details.BalancePrice = info.RejectionProductPrice;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            var purchaseRejectedInfo = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(info.PrId);
            if (purchaseRejectedInfo != null)
            {
                details.RefNumber = purchaseRejectedInfo.Ref;
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1003;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库  1003 采购入库退货 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
        }

        //根据状态平均算出销售单价  (状态出库  入库   在途)
        private decimal CalculateProductPrice(int wareHousesId, XMPurchaseRejectedProductDetails info, int satatus)
        {
            int count = 0;
            decimal money = 0;
            //int refType = 1002;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            decimal price = 0;
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, info.PlatformMerchantCode, satatus);
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                foreach (XMInventoryLedgerDetail Info in inventoryLederDetail)
                {
                    count = count + Info.OutCount.Value;
                    money = money + Info.OutPrice.Value * Info.OutCount.Value;
                }
            }
            count = count + info.RejectionCount;
            money = money + info.RejectionProductPrice * info.RejectionCount;
            price = money / count;
            return price;
        }




        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        #endregion
    }
}