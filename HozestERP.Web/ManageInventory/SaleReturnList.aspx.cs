using System;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using System.Collections.Generic;
using System.Transactions;

namespace HozestERP.Web.ManageInventory
{
    public partial class SaleReturnList : BaseAdministrationPage, ISearchPage
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
        /// 根据用户customerID  获取用户 包含店铺列表
        /// </summary>
        /// <returns></returns>
        private string GetCustomerMappingNickIDs()
        {
            string nickids = "";
            int cutomerId = HozestERPContext.Current.User.CustomerID;
            var nicklist = base.XMNickCustomerMappingService.GetProjectXMNickCustomerMappingListByCustomerID(cutomerId);
            if (nicklist != null && nicklist.Count > 0)         //存在店铺列表
            {
                foreach (XMNickCustomerMapping map in nicklist)
                {
                    nickids = nickids + map.NickId + ",";
                }
            }
            if (nickids != "" && nickids.Length > 0)
            {
                nickids = nickids.Substring(0, nickids.Length - 1);
            }
            return nickids;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetXMSaleReturnListByProjectID()
        {
            string projectIds = "";
            int cutomerId = HozestERPContext.Current.User.CustomerID;
            var nicklist = base.XMNickCustomerMappingService.GetProjectXMNickCustomerMappingListByCustomerID(cutomerId);
            if (nicklist != null && nicklist.Count > 0)         //存在店铺列表
            {
                foreach (XMNickCustomerMapping map in nicklist)
                {
                    var nick = base.XMNickService.GetXMNickByID(map.NickId.Value);
                    if (nick != null)
                    {
                        projectIds = projectIds + nick.ProjectId + ",";
                    }
                }
            }
            if (projectIds != "" && projectIds.Length > 0)
            {
                projectIds = projectIds.Substring(0, projectIds.Length - 1);
            }
            return projectIds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string nickids = GetCustomerMappingNickIDs();
            if (nickids == "")
            {
                base.ShowMessage("您无权限查看销售退货单");
                return;
            }
            int projectId = Convert.ToInt16(ddXMProject.SelectedValue);
            int status = int.Parse(ddlStatus.SelectedValue);    //状态
            string saleReturnCode = txtPurChaseCode.Text.Trim();    //退货单号自动生成 
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            int wareHousesId = ddlWareHourses.SelectedValue == "" ? -1 : Convert.ToInt16(ddlWareHourses.SelectedValue);

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

            string paramwareHourseIDs = "";
            string paramwareHourseIDSelect = this.ddlWareHourses.SelectedValue;
            if (paramwareHourseIDSelect == "-1")
            {
                for (int i = 0; i < this.ddlWareHourses.Items.Count; i++)
                {
                    if (this.ddlWareHourses.Items[i].Value != "-1")
                        paramwareHourseIDs = paramwareHourseIDs + this.ddlWareHourses.Items[i].Value + ",";
                }
                paramwareHourseIDs = paramwareHourseIDs.Substring(0, paramwareHourseIDs.Length - 1) + ",-1";
            }
            else
            {
                paramwareHourseIDs = paramwareHourseIDSelect;
            }


            var list = base.XMSaleReturnService.GetXMSaleReturnListByParm(saleReturnCode, Begin, End, paramwareHourseIDs, status, projectId);

            var pageList = new PagedList<XMSaleReturn>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvSaleReturn, pageList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
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
            if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
            {
                List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                if (XMProjectList.Count > 0)
                {
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                }
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddXMProject.Items[0].Selected = true;
            }
            else
            {
                this.BindddXMProject();//项目
            }
            this.ddXMProject_SelectedIndexChanged(null, null);//店铺
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                //.Where(c => c.ProjectTypeId == 362)

                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));

                //绑定仓库
                string paramprojectIDs = "";
                string paramprojectIDSelect = this.ddXMProject.SelectedValue;
                if (paramprojectIDSelect == "-1" || paramprojectIDSelect == "99")
                {
                    for (int i = 0; i < this.ddXMProject.Items.Count; i++)
                    {
                        if (this.ddXMProject.Items[i].Value != "-1")
                            paramprojectIDs = paramprojectIDs + this.ddXMProject.Items[i].Value + ",";
                    }
                    paramprojectIDs = paramprojectIDs.Substring(0, paramprojectIDs.Length - 1) + ",-1";
                }
                else
                {
                    paramprojectIDs = paramprojectIDSelect;
                }
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(paramprojectIDs);
                this.ddlWareHourses.Items.Clear();
                this.ddlWareHourses.DataSource = wareHouses;
                this.ddlWareHourses.DataTextField = "Name";
                this.ddlWareHourses.DataValueField = "Id";
                this.ddlWareHourses.DataBind();
                this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    this.ddXMProject.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                }
                if (projectList.Count() > 0)
                {
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                    this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "99"));
                }
                string paramprojectIDs = "";
                string paramprojectIDSelect = this.ddXMProject.SelectedValue;
                if (paramprojectIDSelect == "-1" || paramprojectIDSelect == "99")
                {
                    for (int i = 0; i < this.ddXMProject.Items.Count; i++)
                    {
                        if (this.ddXMProject.Items[i].Value != "-1")
                            paramprojectIDs = paramprojectIDs + this.ddXMProject.Items[i].Value + ",";
                    }
                    paramprojectIDs = paramprojectIDs.Substring(0, paramprojectIDs.Length - 1) + ",-1";
                }
                else
                {
                    paramprojectIDs = paramprojectIDSelect;
                }
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(paramprojectIDs);
                this.ddlWareHourses.Items.Clear();
                this.ddlWareHourses.DataSource = wareHouses;
                this.ddlWareHourses.DataTextField = "Name";
                this.ddlWareHourses.DataValueField = "Id";
                this.ddlWareHourses.DataBind();
                this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                string paramprojectIDs = "";
                string paramprojectIDSelect = this.ddXMProject.SelectedValue;
                if (paramprojectIDSelect == "-1" || paramprojectIDSelect == "99")
                {
                    for (int i = 0; i < this.ddXMProject.Items.Count; i++)
                    {
                        if (this.ddXMProject.Items[i].Value != "-1")
                            paramprojectIDs = paramprojectIDs + this.ddXMProject.Items[i].Value + ",";
                    }
                    paramprojectIDs = paramprojectIDs.Substring(0, paramprojectIDs.Length - 1) + ",-1";
                }
                else
                {
                    paramprojectIDs = paramprojectIDSelect;
                }
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(paramprojectIDs);
                this.ddlWareHourses.Items.Clear();
                this.ddlWareHourses.DataSource = wareHouses;
                this.ddlWareHourses.DataTextField = "Name";
                this.ddlWareHourses.DataValueField = "Id";
                this.ddlWareHourses.DataBind();
                this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
        }

        protected void grdvSaleReturn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMSaleReturn;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;

                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑退货入库单','" + CommonHelper.GetStoreLocation() +
        "ManageInventory/SaleReturnAdd.aspx?Type=1"
          + "&&SaleReturnID=" + info.Id
        + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('查看退货入库单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/SaleReturnAdd.aspx?Type=2"
       + "&&SaleReturnID=" + info.Id
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }

                var returnInfo = base.XMSaleReturnService.GetXMSaleReturnById(info.Id);
                if (returnInfo != null)
                {
                    switch (returnInfo.BillStatus)
                    {
                        case 0:                          //状态为待入库  可进行编辑和删除
                            if (imgBtnEdit != null)
                            {
                                imgBtnEdit.Visible = true;
                            }
                            if (imgBtnDelete != null)
                            {
                                imgBtnDelete.Visible = true;
                            }
                            if (imgProductDetails != null)
                            {
                                imgProductDetails.Visible = false;
                            }
                            break;
                        case 1000:                  //状态为已入库  无法编辑和删除只能产看
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

        protected void grdvSaleReturn_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    //删除退货单主表和产品明细表
                    var returnInfo = base.XMSaleReturnService.GetXMSaleReturnById(int.Parse(id));
                    if (returnInfo != null)
                    {
                        //删除主表
                        returnInfo.IsEnable = true;
                        returnInfo.UpdateDate = DateTime.Now;
                        returnInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMSaleReturnService.UpdateXMSaleReturn(returnInfo);
                        //删除相关联的产品明细表
                        var details = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsListBySaleReturnID(returnInfo.Id);
                        if (details != null && details.Count > 0)
                        {
                            foreach (XMSaleReturnProductDetails Info in details)
                            {
                                Info.IsEnable = true;
                                Info.UpdateDate = DateTime.Now;
                                Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMSaleReturnProductDetailsService.UpdateXMSaleReturnProductDetails(Info);
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
        /// 提交入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStorge_Click(object sender, EventArgs e)
        {
            List<int> saleReturnIDs = this.Master.GetSelectedIds(this.grdvSaleReturn);
            if (saleReturnIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                //提交入库 
                foreach (int ID in saleReturnIDs)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        var saleReturn = base.XMSaleReturnService.GetXMSaleReturnById(ID);
                        if (saleReturn != null && saleReturn.BillStatus == 0)
                        {
                            //更新状态
                            saleReturn.BillStatus = 1000;     //状态更新为已入库
                            saleReturn.UpdateDate = DateTime.Now;
                            saleReturn.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMSaleReturnService.UpdateXMSaleReturn(saleReturn);
                            //更新产品库存表
                            var details = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsListBySaleReturnID(saleReturn.Id);
                            if (details != null && details.Count > 0)
                            {
                                foreach (XMSaleReturnProductDetails Info in details)
                                {
                                    string platformCode = "";
                                    if (Info.DeliveryProductsDetailID != null)
                                    {
                                        var saleDelivery = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(Info.DeliveryProductsDetailID.Value);
                                        if (saleDelivery != null)
                                        {
                                            platformCode = saleDelivery.PlatformMerchantCode;
                                        }
                                    }
                                    int wfID = saleReturn.WarehouseId.Value;
                                    var inventeryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(platformCode, wfID);
                                    if (inventeryInfo != null)                //更新库存
                                    {
                                        inventeryInfo.StockNumber += Info.RejectionProdcutsCount;
                                        inventeryInfo.CanOrderCount = inventeryInfo.StockNumber;
                                        inventeryInfo.UpdateDate = DateTime.Now;
                                        inventeryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMInventoryInfoService.UpdateXMInventoryInfo(inventeryInfo);
                                        //更新入库产品条形码
                                        UpdateProductBarCodeList(inventeryInfo.Id, Info.Id);
                                    }
                                    else
                                    {
                                        //产品不存在  新增
                                        XMInventoryInfo parm = new XMInventoryInfo();
                                        parm.PrductId = Info.ProductId.Value;
                                        parm.PlatformMerchantCode = platformCode;
                                        parm.WfId = saleReturn.WarehouseId.Value;
                                        parm.StockNumber = Info.RejectionProdcutsCount;
                                        parm.CanOrderCount = parm.StockNumber;
                                        parm.WarningValue = 0;                            //警戒值  可自行设定
                                        parm.CreateDate = parm.UpdateDate = DateTime.Now;
                                        parm.CreateID = parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        parm.IsEnable = false;
                                        base.XMInventoryInfoService.InsertXMInventoryInfo(parm);
                                        //更新入库产品条形码
                                        UpdateProductBarCodeList(parm.Id, Info.Id);
                                    }
                                    //更新库存总账主表数据   从表添加一条记录
                                    UpdateInventoryLederInfo(wfID, Info, platformCode);

                                }
                            }
                        }
                        scope.Complete();
                    }
                }
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("提交入库成功！");
            }
        }


        /// <summary>
        /// 提交入库   向库存添加该产品的条形码
        /// </summary>
        /// <param name="inventoryID"></param>
        /// <param name="storageDetailID"></param>
        private void UpdateProductBarCodeList(int inventoryID, int saleReturnProductDetailID)
        {
            //根据产品详情ID 获取入库产品的条形码列表
            var barCodes = base.XMSaleReturnBarCodeDetailService.GetXMSaleReturnBarCodeDetailListBySrdID(saleReturnProductDetailID);
            if (barCodes != null && barCodes.Count > 0)
            {
                //遍历所有条形码
                foreach (XMSaleReturnBarCodeDetail Info in barCodes)
                {
                    //查询该仓库产品条形码是否已经存在
                    var inventoryBarCodes = base.XMInventoryBarcodeDetailService.GetXMInventoryBarcodeDetailListByInventoryIDAndBarCode(inventoryID, Info.BarCode);
                    if (inventoryBarCodes == null)              //该产品条形码不存在  新增
                    {
                        XMInventoryBarcodeDetail inventoryBarCode = new XMInventoryBarcodeDetail();
                        inventoryBarCode.SpdId = inventoryID;
                        inventoryBarCode.PrductId = Info.ProductId;
                        inventoryBarCode.PlatformMerchantCode = Info.PlatformMerchantCode;
                        inventoryBarCode.BarCode = Info.BarCode;
                        inventoryBarCode.CreateDate = inventoryBarCode.UpdateDate = DateTime.Now;
                        inventoryBarCode.UpdateID = inventoryBarCode.CreateID = HozestERPContext.Current.User.CustomerID;
                        inventoryBarCode.IsEnable = false;
                        base.XMInventoryBarcodeDetailService.InsertXMInventoryBarcodeDetail(inventoryBarCode);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHousesId"></param>
        /// <param name="info"></param>
        private void UpdateInventoryLederInfo(int wareHousesId, XMSaleReturnProductDetails info, string platformMerchantCode)
        {
            XMInventoryLedger inventoryLeder = null;
            if (platformMerchantCode != "")
            {
                inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, platformMerchantCode);
                if (inventoryLeder != null)     //更新数据
                {
                    //更新入库数量（加上）
                    inventoryLeder.InCount = (inventoryLeder.InCount == null ? 0 : inventoryLeder.InCount) + info.RejectionProdcutsCount;
                    inventoryLeder.InMoney = info.RejectionProductsPrice * inventoryLeder.InCount;
                    inventoryLeder.UpdateDate = DateTime.Now;
                    inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
                }
                else
                {
                    XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                    inventoryLederInfo.WarehouseId = wareHousesId;
                    inventoryLederInfo.ProductId = info.ProductId;
                    inventoryLederInfo.PlatformMerchantCode = platformMerchantCode;
                    inventoryLederInfo.AfloatCount = 0;
                    inventoryLederInfo.AfloatPrice = info.ProductPrice;
                    inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                    inventoryLederInfo.InCount = info.ProductCount;
                    inventoryLederInfo.InPrice = info.ProductPrice;
                    inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                    inventoryLederInfo.OutCount = 0;
                    inventoryLederInfo.OutPrice = info.ProductPrice;
                    inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                    inventoryLederInfo.CreateDate = DateTime.Now;
                    inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                    base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
                }
                //新增库存总账明细(入库)
                var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, platformMerchantCode);
                decimal price = 0;
                decimal money = 0;
                XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
                details.WarehouseId = wareHousesId;
                details.ProductId = info.ProductId;
                details.PlatformMerchantCode = platformMerchantCode;
                details.InCount = info.RejectionProdcutsCount;                  //入库数量
                details.InPrice = info.RejectionProductsPrice;                      //入库单价
                details.InMoney = info.RejectionsaleMoney;                      //金额
                details.OutCount = 0;
                details.OutPrice = price;
                details.OutMoney = money;
                if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
                {
                    //默认最后一条（余量）
                    int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                    details.BalanceCount = BalanceCount + details.InCount;
                }
                else
                {
                    details.BalanceCount = details.InCount;
                }
                details.BalancePrice = info.RejectionProductsPrice;
                details.BalanceMoney = details.BalancePrice * details.BalanceCount;
                var saleReturns = base.XMSaleReturnService.GetXMSaleReturnById(info.SaleReturnId);
                if (saleReturns != null)
                {
                    details.RefNumber = saleReturns.Ref;
                }
                details.BizDate = DateTime.Now;
                details.BizUserId = HozestERPContext.Current.User.CustomerID;
                int refType = 1004;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
                details.RefType = refType;
                base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
            }
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