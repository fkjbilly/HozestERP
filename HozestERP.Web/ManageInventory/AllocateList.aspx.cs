using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using System.Transactions;

namespace HozestERP.Web.ManageInventory
{
    public partial class AllocateList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                this.btnAddAllocateInfo.OnClientClick = "return ShowWindowDetail('新建调拨单','" + CommonHelper.GetStoreLocation() +
"ManageInventory/AllocateAdd.aspx?Type=0"
+ "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
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
        private string GetXMAllocateByProjectID()
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
            int projectId = ddXMProject.SelectedValue == "" ? -1 : Convert.ToInt16(ddXMProject.SelectedValue);
            if (nickids == "")
            {
                base.ShowMessage("您无权限查看调拨单!");
                return;
            }
            int status = int.Parse(ddlStatus.SelectedValue);    //状态
            string dbCode = txtPurChaseCode.Text.Trim();    //调拨单号自动生成
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            int wareHousesIdFrom = ddlWareHoursesFrom.SelectedValue == "" ? -1 : Convert.ToInt16(ddlWareHoursesFrom.SelectedValue);
            int wareHousesIdTo = ddlWareHoursesTo.SelectedValue == "" ? -1 : Convert.ToInt16(ddlWareHoursesTo.SelectedValue);
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
            string paramwareHourseIDsFrom = "";
            string paramwareHourseIDSelectFrom = this.ddlWareHoursesFrom.SelectedValue;
            if (paramwareHourseIDSelectFrom == "-1")
            {
                for (int i = 0; i < this.ddlWareHoursesFrom.Items.Count; i++)
                {
                    if (this.ddlWareHoursesFrom.Items[i].Value != "-1")
                        paramwareHourseIDsFrom = paramwareHourseIDsFrom + this.ddlWareHoursesFrom.Items[i].Value + ",";
                }
                paramwareHourseIDsFrom = paramwareHourseIDsFrom.Substring(0, paramwareHourseIDsFrom.Length - 1) + ",-1";
            }
            else
            {
                paramwareHourseIDsFrom = paramwareHourseIDSelectFrom;
            }

            string paramwareHourseIDsTo = "";
            string paramwareHourseIDSelectTo = this.ddlWareHoursesTo.SelectedValue;
            if (paramwareHourseIDSelectTo == "-1")
            {
                for (int i = 0; i < this.ddlWareHoursesTo.Items.Count; i++)
                {
                    if (this.ddlWareHoursesTo.Items[i].Value != "-1")
                        paramwareHourseIDsTo = paramwareHourseIDsTo + this.ddlWareHoursesTo.Items[i].Value + ",";
                }
                paramwareHourseIDsTo = paramwareHourseIDsTo.Substring(0, paramwareHourseIDsTo.Length - 1) + ",-1";
            }
            else
            {
                paramwareHourseIDsTo = paramwareHourseIDSelectTo;
            }
            var list = base.XMAllocateInfoService.GetXMAllocateInfoListByParm(nickids, status, dbCode, Begin, End, paramwareHourseIDsFrom, paramwareHourseIDsTo, projectId);

            list = list.OrderByDescending(p => p.BizDt).ToList();
            var pageList = new PagedList<XMAllocateInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvAllocate, pageList);
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

        protected void grdvAllocate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMAllocateInfo;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;

                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑调拨单','" + CommonHelper.GetStoreLocation() +
      "ManageInventory/AllocateAdd.aspx?Type=1"
        + "&&AllocateId=" + info.Id
      + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('查看调拨单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/AllocateAdd.aspx?Type=2"
       + "&&AllocateId=" + info.Id
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (info.BillStatus == 1000)          //审核通过只能查看 无法删除编辑
                {
                    if (imgBtnEdit != null)
                    {
                        imgBtnEdit.Visible = false;
                    }
                    if (imgProductDetails != null)
                    {
                        imgProductDetails.Visible = true;
                    }
                    if (imgBtnDelete != null)
                    {
                        imgBtnDelete.Visible = false;
                    }
                }
                else
                {
                    if (imgBtnEdit != null)
                    {
                        imgBtnEdit.Visible = true;
                    }
                    if (imgProductDetails != null)
                    {
                        imgProductDetails.Visible = false;
                    }
                    if (imgBtnDelete != null)
                    {
                        imgBtnDelete.Visible = true;
                    }
                }
            }
        }

        protected void grdvAllocate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    ////删除调拨单主表信息和调拨单产品明细表
                    var dbInfo = base.XMAllocateInfoService.GetXMAllocateInfoById(int.Parse(id));
                    if (dbInfo != null)
                    {
                        //删除主表
                        dbInfo.IsEnable = true;
                        dbInfo.UpdateDate = DateTime.Now;
                        dbInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMAllocateInfoService.UpdateXMAllocateInfo(dbInfo);
                        //删除从表
                        var detail = base.XMAllocateProductDetailsService.GetXMAllocateProductDetailsListByAllcateId(dbInfo.Id);
                        if (detail != null && detail.Count > 0)
                        {
                            foreach (XMAllocateProductDetails Info in detail)
                            {
                                Info.IsEnable = true;
                                Info.UpdateDate = DateTime.Now;
                                Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMAllocateProductDetailsService.UpdateXMAllocateProductDetails(Info);
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

                    this.ddXMProject1.Items.Clear();
                    this.ddXMProject1.Items.Clear();
                    this.ddXMProject1.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                }
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddXMProject.Items[0].Selected = true;
                this.ddXMProject1.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddXMProject1.Items[0].Selected = true;
            }
            else
            {
                this.BindddXMProject();//项目
            }
            this.ddXMProject_SelectedIndexChanged(null, null);//店铺
            this.ddXMProject1_SelectedIndexChanged(null, null);//店铺
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

                this.ddXMProject1.DataSource = projectList;
                this.ddXMProject1.DataTextField = "ProjectName";
                this.ddXMProject1.DataValueField = "Id";
                this.ddXMProject1.DataBind();
                this.ddXMProject1.Items.Insert(0, new ListItem("---所有---", "-1"));


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

                this.ddlWareHoursesFrom.DataSource = this.ddlWareHoursesTo.DataSource = wareHouses;
                this.ddlWareHoursesTo.DataTextField = this.ddlWareHoursesFrom.DataTextField = "Name";
                this.ddlWareHoursesTo.DataValueField = this.ddlWareHoursesFrom.DataValueField = "Id";
                this.ddlWareHoursesTo.DataBind();
                this.ddlWareHoursesFrom.DataBind();
                this.ddlWareHoursesFrom.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddlWareHoursesTo.Items.Insert(0, new ListItem("---所有---", "-1"));
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
                    this.ddXMProject1.DataSource = projectList;
                    this.ddXMProject1.DataTextField = "ProjectName";
                    this.ddXMProject1.DataValueField = "Id";
                    this.ddXMProject1.DataBind();
                    this.ddXMProject1.Items.Insert(0, new ListItem("---所有---", "99"));
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

                this.ddlWareHoursesFrom.DataSource = this.ddlWareHoursesTo.DataSource = wareHouses;
                this.ddlWareHoursesTo.DataTextField = this.ddlWareHoursesFrom.DataTextField = "Name";
                this.ddlWareHoursesTo.DataValueField = this.ddlWareHoursesFrom.DataValueField = "Id";
                this.ddlWareHoursesTo.DataBind();
                this.ddlWareHoursesFrom.DataBind();
                this.ddlWareHoursesFrom.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddlWareHoursesTo.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddXMProject1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject1.SelectedValue.ToString().Trim().Length > 0)
            {
                string paramprojectIDs = "";
                string paramprojectIDSelect = this.ddXMProject1.SelectedValue;
                if (paramprojectIDSelect == "-1" || paramprojectIDSelect == "99")
                {
                    for (int i = 0; i < this.ddXMProject.Items.Count; i++)
                    {
                        if (this.ddXMProject1.Items[i].Value != "-1")
                            paramprojectIDs = paramprojectIDs + this.ddXMProject1.Items[i].Value + ",";
                    }
                    paramprojectIDs = paramprojectIDs.Substring(0, paramprojectIDs.Length - 1) + ",-1";
                }
                else
                {
                    paramprojectIDs = paramprojectIDSelect;
                }
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(paramprojectIDs);
                this.ddlWareHoursesTo.Items.Clear();
                this.ddlWareHoursesTo.DataSource = wareHouses;
                this.ddlWareHoursesTo.DataTextField = "Name";
                this.ddlWareHoursesTo.DataValueField = "Id";
                this.ddlWareHoursesTo.DataBind();
                this.ddlWareHoursesTo.Items.Insert(0, new ListItem("---所有---", "-1"));

            }
            // BindInfo();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                this.ddlWareHoursesFrom.Items.Clear();
                this.ddlWareHoursesFrom.DataSource = wareHouses;
                this.ddlWareHoursesFrom.DataTextField = "Name";
                this.ddlWareHoursesFrom.DataValueField = "Id";
                this.ddlWareHoursesFrom.DataBind();
                this.ddlWareHoursesFrom.Items.Insert(0, new ListItem("---所有---", "-1"));

            }
            // BindInfo();
        }

        /// <summary>
        /// 更新入库记录
        /// </summary>
        /// <param name="wareHousesId"></param>
        /// <param name="info"></param>
        private void UpdateStorageInventoryLederInfo(int wareHousesId, XMAllocateProductDetails info)
        {
            decimal price = 0;
            decimal money = 0;
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, info.PlatformMerchantCode);
            var productDetail = base.XMProductDetailsService.GetXMProductDetailsListByProductId(info.ProductId.Value);
            if (inventoryLeder != null)     //更新数据
            {
                ////更新入库数量（加上）
                inventoryLeder.InCount = (inventoryLeder.InCount == null ? 0 : inventoryLeder.InCount) + info.ProductCount;
                if (productDetail != null && productDetail.Count > 0)
                {
                    inventoryLeder.InPrice = productDetail[0].Costprice;
                }
                inventoryLeder.InMoney = inventoryLeder.InPrice * inventoryLeder.InCount;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.WarehouseId = wareHousesId;
                inventoryLederInfo.ProductId = info.ProductId.Value;
                inventoryLederInfo.PlatformMerchantCode = info.PlatformMerchantCode;
                inventoryLederInfo.AfloatCount = 0;
                if (productDetail != null && productDetail.Count > 0)
                {
                    inventoryLederInfo.AfloatPrice = productDetail[0].Costprice;
                }
                inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                inventoryLederInfo.InCount = info.ProductCount;
                if (productDetail != null && productDetail.Count > 0)
                {
                    inventoryLederInfo.InPrice = productDetail[0].Costprice;
                }
                inventoryLederInfo.InMoney = inventoryLederInfo.InPrice * inventoryLederInfo.InCount;
                inventoryLederInfo.OutCount = 0;
                if (productDetail != null && productDetail.Count > 0)
                {
                    inventoryLederInfo.OutPrice = productDetail[0].Costprice;
                }
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(入库)
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, info.PlatformMerchantCode);

            XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
            details.WarehouseId = wareHousesId;
            details.ProductId = info.ProductId;
            details.PlatformMerchantCode = info.PlatformMerchantCode;
            details.InCount = info.ProductCount;                  //入库数量
            if (productDetail != null && productDetail.Count > 0)
            {
                details.InPrice = productDetail[0].Costprice;          //入库单价
            }
            details.InMoney = details.InPrice * details.InCount;
            details.OutCount = 0;
            details.OutPrice = price;
            details.OutMoney = money;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                details.BalanceCount = BalanceCount + info.ProductCount;
            }
            else           //
            {
                details.BalanceCount = info.ProductCount;
            }
            details.BalancePrice = details.InPrice;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            var dbInfo = base.XMAllocateInfoService.GetXMAllocateInfoById(info.AllocateId);
            if (dbInfo != null)
            {
                details.RefNumber = dbInfo.Ref;        //业务单号
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1012;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库  1011 调拨出库  1012 调拨入库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
        }

        /// <summary>
        /// 更新出库记录
        /// </summary>
        /// <param name="wareHousesId"></param>
        /// <param name="info"></param>
        private void UpdateDeliveryInventoryLederInfo(int wareHousesId, XMAllocateProductDetails info)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, info.PlatformMerchantCode);
            var productDetails = base.XMProductDetailsService.GetXMProductDetailsListByProductId(info.ProductId.Value);
            if (inventoryLeder != null)     //更新数据
            {
                //更新出库数量（加上）
                inventoryLeder.OutCount = (inventoryLeder.OutCount == null ? 0 : inventoryLeder.OutCount) + info.ProductCount;
                if (productDetails != null && productDetails.Count > 0)
                {
                    inventoryLeder.OutPrice = productDetails[0].Costprice;
                }
                inventoryLeder.OutMoney = inventoryLeder.OutPrice * inventoryLeder.OutCount;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.OutCount = info.ProductCount;
                inventoryLederInfo.WarehouseId = wareHousesId;
                inventoryLederInfo.ProductId = info.ProductId.Value;
                inventoryLederInfo.PlatformMerchantCode = info.PlatformMerchantCode;
                if (productDetails != null && productDetails.Count > 0)
                {
                    inventoryLederInfo.OutPrice = productDetails[0].Costprice;
                }
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
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
            details.OutCount = info.ProductCount;                  //出库数量
            if (productDetails != null && productDetails.Count > 0)
            {
                details.OutPrice = productDetails[0].Costprice;              //出库单价
            }
            details.OutMoney = details.OutPrice * info.ProductCount;
            details.InCount = 0;
            details.InPrice = price;
            details.InMoney = money;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                details.BalanceCount = BalanceCount - info.ProductCount;
            }
            else           //
            {
                details.BalanceCount = info.ProductCount;
            }
            details.BalancePrice = price;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            var dbInfo = base.XMAllocateInfoService.GetXMAllocateInfoById(info.AllocateId);
            if (dbInfo != null)
            {
                details.RefNumber = dbInfo.Ref;        //业务单号
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1011;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库  1011 调拨出库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
        }

        /// <summary>
        /// 提交调拨单  更新库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmitAllocate_Click(object sender, EventArgs e)
        {
            string errMessage = "";
            bool isInventLess = false;   //判断库存是否不足
            bool isAllocateFail = false;   // 判断调拨是否失败
            List<int> dbInfoIDs = this.Master.GetSelectedIds(this.grdvAllocate);

            if (dbInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录!");
                return;
            }
            else
            {
                foreach (int ID in dbInfoIDs)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        var dbInfo = base.XMAllocateInfoService.GetXMAllocateInfoById(ID);
                        if (dbInfo != null)
                        {
                            if (dbInfo.BillStatus == 0)            //未调拨
                            {
                                var dbProductDetails = base.XMAllocateProductDetailsService.GetXMAllocateProductDetailsListByAllcateId(dbInfo.Id);
                                if (dbProductDetails != null && dbProductDetails.Count > 0)
                                {
                                    foreach (XMAllocateProductDetails Info in dbProductDetails)
                                    {
                                        var inventInfoFrom = base.XMInventoryInfoService.GetXMInventoryInfoByParm(Info.PlatformMerchantCode, dbInfo.From_WarehouseId);
                                        if (inventInfoFrom == null || (inventInfoFrom != null && inventInfoFrom.StockNumber < Info.ProductCount))              //库存不足
                                        {
                                            errMessage += "厂家编码为" + Info.PlatformMerchantCode + "的商品库存不足，";
                                            isInventLess = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (dbInfo.BillStatus == 1000)       //已调拨
                            {
                                isAllocateFail = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (isInventLess)      //库存不足
            {
                base.ShowMessage(errMessage + "无法调拨！");
                return;
            }
            if (isAllocateFail)
            {
                base.ShowMessage("已经调拨的调拨单操作失败！");
                return;
            }

            if (dbInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录!");
                return;
            }
            else
            {
                foreach (int ID in dbInfoIDs)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        var dbInfo = base.XMAllocateInfoService.GetXMAllocateInfoById(ID);
                        if (dbInfo != null && dbInfo.BillStatus == 0)
                        {
                            dbInfo.BillStatus = 1000;     //更该状态为 已调拨
                            dbInfo.UpdateDate = DateTime.Now;
                            dbInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMAllocateInfoService.UpdateXMAllocateInfo(dbInfo);

                            //更新仓库库存
                            var dbProductDetails = base.XMAllocateProductDetailsService.GetXMAllocateProductDetailsListByAllcateId(dbInfo.Id);
                            if (dbProductDetails != null && dbProductDetails.Count > 0)
                            {
                                foreach (XMAllocateProductDetails Info in dbProductDetails)
                                {

                                    var inventInfoFrom = base.XMInventoryInfoService.GetXMInventoryInfoByParm(Info.PlatformMerchantCode, dbInfo.From_WarehouseId);
                                    if ((inventInfoFrom != null && inventInfoFrom.StockNumber >= Info.ProductCount))              //库存充足减库存
                                    {
                                        //更新出库仓库库存
                                        inventInfoFrom.StockNumber = inventInfoFrom.StockNumber - Info.ProductCount;
                                        inventInfoFrom.CanOrderCount = inventInfoFrom.StockNumber;
                                        inventInfoFrom.UpdateDate = DateTime.Now;
                                        inventInfoFrom.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMInventoryInfoService.UpdateXMInventoryInfo(inventInfoFrom);
                                        //在库存帐查询中添加记录
                                        UpdateDeliveryInventoryLederInfo(dbInfo.From_WarehouseId, Info);
                                        //更新仓库出库产品条形码
                                        UpdateDeliveryBarCodes(inventInfoFrom.Id, Info.Id);

                                        //更新入库仓库库存
                                        var inventInfoTo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(Info.PlatformMerchantCode, dbInfo.To_WarehouseId);
                                        if (inventInfoTo == null)          //新增
                                        {
                                            XMInventoryInfo inventory = new XMInventoryInfo();
                                            var product = base.XMProductService.getXMProductByManufacturersCode(Info.PlatformMerchantCode);
                                            if (product != null)
                                            {
                                                inventory.PrductId = product.Id;
                                            }
                                            inventory.PlatformMerchantCode = Info.PlatformMerchantCode;
                                            inventory.WfId = dbInfo.To_WarehouseId;
                                            inventory.StockNumber = Info.ProductCount;
                                            inventory.CanOrderCount = inventory.StockNumber;
                                            inventory.WarningValue = 0;
                                            inventory.CreateDate = inventory.UpdateDate = DateTime.Now;
                                            inventory.CreateID = inventory.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            inventory.IsEnable = false;
                                            base.XMInventoryInfoService.InsertXMInventoryInfo(inventory);
                                            UpdateStorageBarCodes(inventory.Id, Info.Id);
                                        }
                                        else              //更新库存
                                        {
                                            inventInfoTo.StockNumber = inventInfoTo.StockNumber + Info.ProductCount;
                                            inventInfoTo.CanOrderCount = inventInfoTo.StockNumber;
                                            inventInfoTo.UpdateDate = DateTime.Now;
                                            inventInfoTo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            base.XMInventoryInfoService.UpdateXMInventoryInfo(inventInfoTo);
                                            UpdateStorageBarCodes(inventInfoTo.Id, Info.Id);
                                        }
                                        UpdateStorageInventoryLederInfo(dbInfo.To_WarehouseId, Info);
                                    }
                                }
                            }
                        }
                        scope.Complete();
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
            }
        }


        /// <summary>
        /// 调拨出库产品条形更新(删除)
        /// </summary>
        /// <param name="inventInfoFromID"></param>
        /// <param name="allocateDetailID"></param>
        private void UpdateDeliveryBarCodes(int inventInfoFromID, int allocateDetailID)
        {
            //根据调拨产品详情ID 获取调拨产品的条形码列表
            var barCodes = base.XMAllocateProductBarCodeDetailService.GetXMAllocateProductBarCodeDetailListById(allocateDetailID);
            if (barCodes != null && barCodes.Count > 0)                   //存在条形码
            {
                //遍历所有条形码
                foreach (XMAllocateProductBarCodeDetail Info in barCodes)
                {
                    var inventoryBarCodes = base.XMInventoryBarcodeDetailService.GetXMInventoryBarcodeDetailListByInventoryIDAndBarCode(inventInfoFromID, Info.BarCode);
                    if (inventoryBarCodes != null)              //该商品如存在该条形码   出库后删除该条形码
                    {
                        inventoryBarCodes.IsEnable = true;
                        inventoryBarCodes.UpdateDate = DateTime.Now;
                        inventoryBarCodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMInventoryBarcodeDetailService.UpdateXMInventoryBarcodeDetail(inventoryBarCodes);
                    }
                }
            }
        }
        /// <summary>
        /// 调拨入库产品条形码更新（新增）
        /// </summary>
        /// <param name="inventInfoToID"></param>
        /// <param name="allocateDetailID"></param>
        private void UpdateStorageBarCodes(int inventInfoToID, int allocateDetailID)
        {
            //根据调拨入库产品详情ID 获取入库产品的条形码列表
            var barCodes = base.XMAllocateProductBarCodeDetailService.GetXMAllocateProductBarCodeDetailListById(allocateDetailID);
            if (barCodes != null && barCodes.Count > 0)                   //存在条形码
            {
                //遍历所有条形码
                foreach (XMAllocateProductBarCodeDetail Info in barCodes)
                {
                    var inventoryBarCodes = base.XMInventoryBarcodeDetailService.GetXMInventoryBarcodeDetailListByInventoryIDAndBarCode(inventInfoToID, Info.BarCode);
                    if (inventoryBarCodes == null)              //该产品条形码不存在  新增
                    {
                        XMInventoryBarcodeDetail inventoryBarCode = new XMInventoryBarcodeDetail();
                        inventoryBarCode.SpdId = inventInfoToID;
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