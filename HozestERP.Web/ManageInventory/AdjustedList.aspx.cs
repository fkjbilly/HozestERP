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
    public partial class AdjustedList : BaseAdministrationPage, ISearchPage
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
        private string GetXMAdjustByProjectID()
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
                base.ShowMessage("您无权限查看调整单!");
                return;
            }
            string AdjustedCode = txtPurChaseCode.Text.Trim();    //调整单号自动生成 
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            int projectId = ddXMProject.SelectedValue == "" ? -1 : Convert.ToInt16(ddXMProject.SelectedValue);
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
            string paramwareHourseIDSelect = ddlWareHourses.SelectedValue == "" ? "-1" : ddlWareHourses.SelectedValue;
            if (paramwareHourseIDSelect == "-1")
            {
                for (int i = 0; i < this.ddlWareHourses.Items.Count; i++)
                {
                    if (this.ddlWareHourses.Items[i].Value != "-1")
                        paramwareHourseIDs = paramwareHourseIDs + this.ddlWareHourses.Items[i].Value + ",";
                }
                if (paramwareHourseIDs.Length > 0)
                {
                    paramwareHourseIDs = paramwareHourseIDs.Substring(0, paramwareHourseIDs.Length - 1) + ",-1";
                }
                else
                {
                    paramwareHourseIDs = "-1";
                }
            }
            else
            {
                paramwareHourseIDs = paramwareHourseIDSelect;
            }
            var list = base.XMAdjustedInfoService.GetXMAdjustedInfoByParm(AdjustedCode, Begin, End, paramwareHourseIDs, projectId, nickids);
            list = list.OrderByDescending(p => p.BizDt).ToList();
            var pageList = new PagedList<XMAdjustedInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvAdjusted, pageList);
        }
        /// <summary>
        /// 
        /// </summary>
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
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool getIsAudit(int id)
        {
            bool isAudit = false;
            var Info = base.XMAdjustedInfoService.GetXMAdjustedInfoById(id);
            if (Info != null && Info.FinancialStatus != null)
            {
                isAudit = (bool)Info.FinancialStatus;
            }
            return isAudit;
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

        protected void grdvAdjusted_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMAdjustedInfo;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑调整单','" + CommonHelper.GetStoreLocation() +
        "ManageInventory/AdjustedAdd.aspx?Type=1"
          + "&&AdjustedID=" + info.Id
        + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('查看调整单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/AdjustedAdd.aspx?Type=2"
       + "&&AdjustedID=" + info.Id
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }

                int FinancialStatus = info.FinancialStatus.Value ? 1 : 0;
                switch (FinancialStatus)
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

        protected void grdvAdjusted_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    ////删除调整单主表信息和调整单产品明细表
                    var adjustedInfo = base.XMAdjustedInfoService.GetXMAdjustedInfoById(int.Parse(id));
                    if (adjustedInfo != null)
                    {
                        //删除主表
                        adjustedInfo.IsEnable = true;
                        adjustedInfo.UpdateDate = DateTime.Now;
                        adjustedInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMAdjustedInfoService.UpdateXMAdjustedInfo(adjustedInfo);
                        //删除从表
                        var detail = base.XMAdjustedProductDetailService.GetXMAdjustedProductDetailListByAdjustedID(adjustedInfo.Id);
                        if (detail != null && detail.Count > 0)
                        {
                            foreach (XMAdjustedProductDetail Info in detail)
                            {
                                Info.IsEnable = true;
                                Info.UpdateDate = DateTime.Now;
                                Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMAdjustedProductDetailService.UpdateXMAdjustedProductDetail(Info);
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
        /// 审核(生效) 后  //判断是盘盈入库        盘亏出库 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAudit_Click(object sender, EventArgs e)
        {
            bool isAuditStatus = false;
            List<int> AdjustInfoIDs = this.Master.GetSelectedIds(this.grdvAdjusted);
            if (AdjustInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in AdjustInfoIDs)
                {
                    var adjustInfo = base.XMAdjustedInfoService.GetXMAdjustedInfoById(Convert.ToInt32(ID));
                    if (adjustInfo != null)
                    {
                        if (adjustInfo.FinancialStatus != null && adjustInfo.FinancialStatus.Value)
                        {
                            isAuditStatus = true;
                            break;
                        }
                    }
                }
            }

            if (isAuditStatus)          //已审核过无法再审了
            {
                base.ShowMessage("选中的调整单已经审核过了，审核失败！");
                return;
            }

            if (AdjustInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in AdjustInfoIDs)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        var adjustInfo = base.XMAdjustedInfoService.GetXMAdjustedInfoById(Convert.ToInt32(ID));
                        if (adjustInfo != null && adjustInfo.FinancialStatus != null && !adjustInfo.FinancialStatus.Value)
                        {
                            //财务审核通过，调整单生效 
                            adjustInfo.FinancialStatus = true;
                            adjustInfo.AuditTime = adjustInfo.UpdateDate = DateTime.Now;
                            adjustInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMAdjustedInfoService.UpdateXMAdjustedInfo(adjustInfo);
                            //  更新盘点单状态
                            var pdInfo = base.XMPdInfoService.GetXMPdInfoById(adjustInfo.PdInfoId.Value);
                            if (pdInfo != null)
                            {
                                pdInfo.BillStatus = 1000;     //调整单生效  盘点单状态更新为已盘点
                                pdInfo.UpdateDate = DateTime.Now;
                                pdInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMPdInfoService.UpdateXMPdInfo(pdInfo);
                            }
                            var adjustProductDetail = base.XMAdjustedProductDetailService.GetXMAdjustedProductDetailListByAdjustedID(adjustInfo.Id);
                            if (adjustProductDetail != null && adjustProductDetail.Count > 0)
                            {
                                foreach (XMAdjustedProductDetail Info in adjustProductDetail)
                                {
                                    string code = Info.PlatformMerchantCode;
                                    int wfID = adjustInfo.WarehouseId.Value;
                                    var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, wfID);
                                    if (InventoryInfo != null)                       //商品编码为code的产品在库存表中已经存在 更新库存数量
                                    {
                                        InventoryInfo.StockNumber += Info.ProductCount;
                                        InventoryInfo.CanOrderCount = InventoryInfo.StockNumber;
                                        InventoryInfo.UpdateDate = DateTime.Now;
                                        InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
                                        //判断是盘盈入库        盘亏出库 
                                        if (Info.ProductCount > 0)        //盘盈入库
                                        {
                                            ////  更新库存帐查询信息(入库)
                                            UpdateInventoryLederStorageInfo(adjustInfo.WarehouseId.Value, Info);
                                        }
                                        else                                            //盘亏出库 
                                        {
                                            ////  更新库存帐查询信息(出库)
                                            UpdateInventoryLederDeliveryInfo(adjustInfo.WarehouseId.Value, Info);
                                        }
                                    }
                                }
                            }
                        }
                        scope.Complete();
                    }
                }

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功!");
            }
        }

        /// <summary>
        /// 库存帐查询 库存盘点 盘亏出库
        /// </summary>
        /// <param name="wareHouseId"></param>
        /// <param name="details"></param>
        private void UpdateInventoryLederDeliveryInfo(int wareHouseId, XMAdjustedProductDetail details)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHouseId, details.PlatformMerchantCode);
            if (inventoryLeder != null)     //更新数据
            {
                //更新出库数量（减掉）
                inventoryLeder.OutCount = (inventoryLeder.OutCount == null ? 0 : inventoryLeder.OutCount) + details.ProductCount;
                inventoryLeder.OutPrice = details.ProductPrice;
                inventoryLeder.InMoney = details.ProductPrice * inventoryLeder.InCount;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.WarehouseId = wareHouseId;
                inventoryLederInfo.ProductId = details.ProductId;
                inventoryLederInfo.PlatformMerchantCode = details.PlatformMerchantCode;
                inventoryLederInfo.AfloatCount = 0;
                inventoryLederInfo.AfloatPrice = details.ProductPrice;
                inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                inventoryLederInfo.InCount = 0;
                inventoryLederInfo.InPrice = details.ProductPrice;
                inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                inventoryLederInfo.OutCount = details.ProductCount;
                inventoryLederInfo.OutPrice = details.ProductPrice;
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(出库)
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHouseId, details.PlatformMerchantCode);
            XMInventoryLedgerDetail detail = new XMInventoryLedgerDetail();
            detail.WarehouseId = wareHouseId;
            detail.ProductId = details.ProductId;
            detail.PlatformMerchantCode = details.PlatformMerchantCode;
            detail.InCount = 0;
            detail.InPrice = details.ProductPrice;
            detail.InMoney = detail.InCount * detail.InPrice;
            detail.OutCount = int.Parse(details.ProductCount.ToString().Remove(0, 1));              //出库数量
            detail.OutPrice = details.ProductPrice;            //出库单价
            detail.OutMoney = detail.OutCount * detail.OutPrice;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                detail.BalanceCount = BalanceCount - detail.OutCount;
            }
            else           //
            {
                detail.BalanceCount = 0;
            }
            detail.BalancePrice = details.ProductPrice;
            detail.BalanceMoney = detail.BalancePrice * detail.BalanceCount;
            var adjustInfo = base.XMAdjustedInfoService.GetXMAdjustedInfoById(details.AdId);
            if (adjustInfo != null)
            {
                var pdInfo = base.XMPdInfoService.GetXMPdInfoById(adjustInfo.PdInfoId.Value);
                if (pdInfo != null)
                {
                    detail.RefNumber = pdInfo.Ref;
                }
            }
            detail.BizDate = DateTime.Now;
            detail.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1010;    //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            detail.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(detail);
        }


        /// <summary>
        /// 库存帐查询 库存盘点 盘盈入库
        /// </summary>
        private void UpdateInventoryLederStorageInfo(int wareHouseId, XMAdjustedProductDetail details)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHouseId, details.PlatformMerchantCode);
            if (inventoryLeder != null)     //更新数据
            {
                //更新入库数量（加上）
                inventoryLeder.InCount = (inventoryLeder.InCount == null ? 0 : inventoryLeder.InCount) + details.ProductCount;
                inventoryLeder.InMoney = details.ProductPrice * inventoryLeder.InCount;
                inventoryLeder.InPrice = details.ProductPrice;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else                       //新增数据
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.WarehouseId = wareHouseId;
                inventoryLederInfo.ProductId = details.ProductId;
                inventoryLederInfo.PlatformMerchantCode = details.PlatformMerchantCode;
                inventoryLederInfo.AfloatCount = 0;
                inventoryLederInfo.AfloatPrice = details.ProductPrice;
                inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                inventoryLederInfo.InCount = details.ProductCount;
                inventoryLederInfo.InPrice = details.ProductPrice;
                inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                inventoryLederInfo.OutCount = 0;
                inventoryLederInfo.OutPrice = details.ProductPrice;
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(入库)
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHouseId, details.PlatformMerchantCode);
            decimal price = 0;
            decimal money = 0;
            XMInventoryLedgerDetail detail = new XMInventoryLedgerDetail();
            detail.WarehouseId = wareHouseId;
            detail.ProductId = details.ProductId;
            detail.PlatformMerchantCode = details.PlatformMerchantCode;
            detail.InCount = details.ProductCount;                  //入库数量
            detail.InPrice = details.ProductPrice;                      //入库单价
            detail.InMoney = details.ProductMoney;
            detail.OutCount = 0;
            detail.OutPrice = price;
            detail.OutMoney = money;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                detail.BalanceCount = BalanceCount + detail.InCount;
            }
            else           //
            {
                detail.BalanceCount = detail.InCount;
            }
            detail.BalancePrice = details.ProductPrice;
            detail.BalanceMoney = detail.BalancePrice * detail.BalanceCount;
            var adjustInfo = base.XMAdjustedInfoService.GetXMAdjustedInfoById(details.AdId);
            if (adjustInfo != null)
            {
                var pdInfo = base.XMPdInfoService.GetXMPdInfoById(adjustInfo.PdInfoId.Value);
                if (pdInfo != null)
                {
                    detail.RefNumber = pdInfo.Ref;
                }
            }
            detail.BizDate = DateTime.Now;
            detail.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1008;    //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            detail.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(detail);
        }

        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnIsAuditFalse_Click(object sender, EventArgs e)
        //{
        //    List<int> AdjustInfoIDs = this.Master.GetSelectedIds(this.grdvAdjusted);
        //    if (AdjustInfoIDs.Count <= 0)
        //    {
        //        base.ShowMessage("你没有选择任何记录");
        //        return;
        //    }
        //    else
        //    {
        //        foreach (int ID in AdjustInfoIDs)
        //        {
        //            var adjustInfo = base.XMAdjustedInfoService.GetXMAdjustedInfoById(Convert.ToInt32(ID));
        //            if (adjustInfo != null)
        //            {
        //                adjustInfo.FinancialStatus = false;
        //                adjustInfo.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
        //                adjustInfo.UpdateDate = DateTime.Now;
        //                base.XMAdjustedInfoService.UpdateXMAdjustedInfo(adjustInfo);
        //            }
        //        }
        //        BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //        base.ShowMessage("操作成功！");
        //    }
        //}

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