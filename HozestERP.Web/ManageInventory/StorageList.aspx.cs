using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ExportImport;

namespace HozestERP.Web.ManageInventory
{
    public partial class StorageList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                BindGrid(1, Master.PageSize);

                //京东自营导入
                this.btnJDSelfSupportExport.OnClientClick = "return ShowWindowDetail('京东自营导入','" + CommonHelper.GetStoreLocation() +
            "ManageInventory/ImportJDSelfSupport.aspx',500,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            }
        }

        /// <summary>
        /// 根据用户customerID  获取用户 包含店铺列表
        /// </summary>
        /// <returns></returns>
        private string GetCustomerMappingNickIDs()
        {
            string nickids = "-1,";
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
        private string GetXMStorageListByProjectID()
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
                base.ShowMessage("您无权限查看采购入库单！");
                return;
            }
            int projectId = ddXMProject.SelectedValue == "" ? -1 : Convert.ToInt16(ddXMProject.SelectedValue);
            int status = int.Parse(ddlStatus.SelectedValue);    //状态
            string storageCode = txtPurChaseCode.Text.Trim();    //入库单号自动生成 
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            int supplierId = ddlSupplierList.SelectedValue == "" ? -1 : Convert.ToInt16(ddlSupplierList.SelectedValue);                   //供应商ID
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

            var list = base.XMStorageService.GetXMStorageByParm(storageCode, Begin, End, supplierId, paramwareHourseIDs, status, projectId, nickids);

            list = list.OrderByDescending(p => p.BizDt).ToList();
            var pageList = new PagedList<XMStorage>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvStorage, pageList);
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
                List<XMWareHouses> WareList = new List<XMWareHouses>();
                if (projectList != null && projectList.Count > 0)
                {
                    for (int i = 0; i < ddXMProject.Items.Count; i++)
                    {

                        var wareHouesse = base.XMWareHousesService.GetXMWarehouseListByProjectId(int.Parse(ddXMProject.Items[i].Value.ToString()));
                        if (wareHouesse != null && wareHouesse.Count > 0)
                        {
                            foreach (XMWareHouses ware in wareHouesse)
                            {
                                WareList.Add(ware);
                            }
                        }
                    }
                }
                this.ddlWareHourses.Items.Clear();
                this.ddlWareHourses.DataSource = WareList;
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
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));

                //绑定仓库
                List<XMWareHouses> WareList = new List<XMWareHouses>();
                if (projectList != null && projectList.Count() > 0)
                {
                    for (int i = 0; i < ddXMProject.Items.Count; i++)
                    {

                        var wareHouesse = base.XMWareHousesService.GetXMWarehouseListByProjectId(int.Parse(ddXMProject.Items[i].Value.ToString()));
                        if (wareHouesse != null && wareHouesse.Count > 0)
                        {
                            foreach (XMWareHouses ware in wareHouesse)
                            {
                                WareList.Add(ware);
                            }
                        }
                    }
                }
                this.ddlWareHourses.Items.Clear();
                this.ddlWareHourses.DataSource = WareList;
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
                int projectID = Convert.ToInt32(this.ddXMProject.SelectedValue);
                if (Convert.ToInt16(this.ddXMProject.SelectedValue.ToString().Trim()) != -1)
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
                else
                {
                    BindddXMProject();
                }
            }

        }

        protected void grdvStorage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    //删除入库主表信息和入库产品明细表
                    var storageInfo = base.XMStorageService.GetXMStorageById(Convert.ToInt16(id));
                    if (storageInfo != null)
                    {
                        //删除主表
                        storageInfo.IsEnable = true;
                        storageInfo.UpdateDate = DateTime.Now;
                        storageInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMStorageService.UpdateXMStorage(storageInfo);
                        var details = base.XMStorageProductDetailsService.GetXMStorageProductDetailsByStorageID(storageInfo.Id);
                        if (details != null && details.Count > 0)
                        {
                            foreach (XMStorageProductDetails parm in details)
                            {
                                parm.IsEnable = true;
                                parm.UpdateDate = DateTime.Now;
                                parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMStorageProductDetailsService.UpdateXMStorageProductDetails(parm);
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

        protected void grdvStorage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMStorage;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                ImageButton imgStoragedSetRejected = e.Row.FindControl("imgStoragedSetReturn") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑采购入库单','" + CommonHelper.GetStoreLocation() +
        "ManageInventory/StorageAdd.aspx?Type=1"
          + "&&StorageID=" + info.Id + "&&PurchaseID=" + info.PurchaseId
        + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('查看采购入库单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/StorageAdd.aspx?Type=2"
       + "&&StorageID=" + info.Id + "&&PurchaseID=" + info.PurchaseId
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
               
                var storage = base.XMStorageService.GetXMStorageById(info.Id);
                if (storage != null)
                {
                    switch (storage.BillStatus)
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
                            if (imgStoragedSetRejected != null)
                            {
                                imgStoragedSetRejected.Visible = false;
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
                            if (imgStoragedSetRejected != null)
                            {
                                imgStoragedSetRejected.Visible = true;
                            }
                            break;
                    }
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
        /// 入库审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStorageIsAudit_Click(object sender, EventArgs e)
        {
            List<int> grdStorageIDs = this.Master.GetSelectedIds(this.grdvStorage);
            if (grdStorageIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdStorageIDs)
                {
                    var storage = base.XMStorageService.GetXMStorageById(ID);
                    if (storage != null)
                    {
                        storage.IsAudit = true;
                        storage.UpdateDate = DateTime.Now;
                        storage.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMStorageService.UpdateXMStorage(storage);
                    }
                }
            }
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("操作成功!");
        }

        /// <summary>
        /// 入库反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStorageIsAuditFalse_Click(object sender, EventArgs e)
        {
            bool isOk = false;
            string errMessage = "";
            List<int> grdStorageIDs = this.Master.GetSelectedIds(this.grdvStorage);
            if (grdStorageIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdStorageIDs)
                {
                    var storage = base.XMStorageService.GetXMStorageById(ID);
                    if (storage != null && storage.BillStatus == 1000)    //已入库入库单无法反审核
                    {
                        isOk = true;
                        errMessage = errMessage + storage.Ref + ";";
                    }
                }
            }
            if (isOk)
            {
                base.ShowMessage("入库单号为：" + errMessage + "的订单已入库，无法实现反审核！");
                return;
            }
            if (grdStorageIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdStorageIDs)
                {
                    var storage = base.XMStorageService.GetXMStorageById(ID);
                    if (storage != null)
                    {
                        storage.IsAudit = false;
                        storage.UpdateDate = DateTime.Now;
                        storage.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMStorageService.UpdateXMStorage(storage);
                    }
                }
            }
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("操作成功!");
        }

        /// <summary>
        /// 提交入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStorge_Click(object sender, EventArgs e)
        {
            bool isAudit = false;
            string errMessage = "";
            List<int> storageIDs = this.Master.GetSelectedIds(this.grdvStorage);
            if (storageIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in storageIDs)
                {
                    var storages = base.XMStorageService.GetXMStorageById(ID);
                    if (storages != null)
                    {
                        bool storageIsAudit = storages.IsAudit == null ? false : storages.IsAudit.Value;
                        if (!storageIsAudit)
                        {
                            isAudit = true;
                            errMessage = errMessage + storages.Ref + ";";
                        }
                    }
                }
            }
            if (isAudit)
            {
                base.ShowMessage("入库单号为：" + errMessage + "未通过审核，无法入库！");
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                return;
            }

            if (storageIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                //提交入库 
                foreach (int ID in storageIDs)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        var storages = base.XMStorageService.GetXMStorageById(ID);
                        if (storages != null && storages.BillStatus == 0)
                        {
                            //更新状态
                            storages.BillStatus = 1000;      //状态更新为已入库
                            storages.StorageDate = DateTime.Now;
                            base.XMStorageService.UpdateXMStorage(storages);
                            //更新产品库存表
                            var storageProductDetails = base.XMStorageProductDetailsService.GetXMStorageProductDetailsByStorageID(storages.Id);
                            if (storageProductDetails != null && storageProductDetails.Count > 0)
                            {
                                foreach (XMStorageProductDetails Info in storageProductDetails)
                                {
                                    string code = Info.PlatformMerchantCode;
                                    int wfID = storages.WareHouseId;
                                    var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, wfID);
                                    if (InventoryInfo != null)                       //商品编码为code的产品在库存表中已经存在 更新库存数量
                                    {
                                        InventoryInfo.StockNumber += Info.ProductsCount;
                                        InventoryInfo.CanOrderCount = InventoryInfo.StockNumber;
                                        InventoryInfo.UpdateDate = DateTime.Now;
                                        InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
                                        //更新入库产品条形码
                                        UpdateProductBarCodeList(InventoryInfo.Id, Info.Id);
                                        
                                    }
                                    else
                                    {
                                        //产品不存在  新增
                                        XMInventoryInfo parm = new XMInventoryInfo();
                                        parm.PrductId = Info.ProductId.Value;
                                        parm.PlatformMerchantCode = Info.PlatformMerchantCode;
                                        parm.WfId = storages.WareHouseId;
                                        parm.StockNumber = Info.ProductsCount;
                                        parm.CanOrderCount = parm.StockNumber;
                                        parm.WarningValue = 0;
                                        parm.CreateID = HozestERPContext.Current.User.CustomerID;
                                        parm.CreateDate = DateTime.Now;
                                        parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        parm.UpdateDate = DateTime.Now;
                                        parm.IsEnable = false;
                                        base.XMInventoryInfoService.InsertXMInventoryInfo(parm);
                                        //更新入库产品条形码
                                        UpdateProductBarCodeList(parm.Id, Info.Id);
                                    }

                                    //更新库存总账主表数据   从表添加一条记录
                                    UpdateInventoryLederInfo(storages.WareHouseId, Info);
                                }
                                if (storages.PurchaseNumber.IndexOf("jd") > -1)//京东自营自动生成采购退货单
                                {
                                    AutoInsertPurchaseRejectedData(storages.PurchaseNumber, storages.Ref);
                                }
                            }
                        }
                        scope.Complete();
                    }
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("提交入库成功！");
            }
        }

        /// <summary>
        /// 提交入库   向库存添加该产品的条形码
        /// </summary>
        /// <param name="inventoryID"></param>
        /// <param name="storageDetailID"></param>
        private void UpdateProductBarCodeList(int inventoryID, int storageDetailID)
        {
            //根据产品详情ID 获取入库产品的条形码列表
            var barCodes = base.XMStorageProductBarCodeDetailService.GetXMStorageProductBarCodeDetailListBySpdID(storageDetailID);
            if (barCodes != null && barCodes.Count > 0)
            {
                //遍历所有条形码
                foreach (XMStorageProductBarCodeDetail Info in barCodes)
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
        private void UpdateInventoryLederInfo(int wareHousesId, XMStorageProductDetails info)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, info.PlatformMerchantCode);
            if (inventoryLeder != null)     //更新数据
            {
                //更新在途数量(减去)
                inventoryLeder.AfloatCount = inventoryLeder.AfloatCount == 0 ? 0 : inventoryLeder.AfloatCount - info.ProductsCount;
                inventoryLeder.AfloatPrice = info.ProductsPrice;
                inventoryLeder.AfloatMoney = info.ProductsPrice * inventoryLeder.AfloatCount;
                //更新入库数量（加上）
                inventoryLeder.InCount = (inventoryLeder.InCount == null ? 0 : inventoryLeder.InCount) + info.ProductsCount;
                inventoryLeder.InMoney = info.ProductsPrice * inventoryLeder.InCount;
                inventoryLeder.InPrice = info.ProductsPrice;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else                       //新增数据
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.WarehouseId = wareHousesId;
                inventoryLederInfo.ProductId = info.ProductId;
                inventoryLederInfo.PlatformMerchantCode = info.PlatformMerchantCode;
                inventoryLederInfo.AfloatCount = 0;
                inventoryLederInfo.AfloatPrice = info.ProductsPrice;
                inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                inventoryLederInfo.InCount = info.ProductsCount;
                inventoryLederInfo.InPrice = info.ProductsPrice;
                inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                inventoryLederInfo.OutCount = 0;
                inventoryLederInfo.OutPrice = info.ProductsPrice;
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(入库)
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, info.PlatformMerchantCode);
            decimal price = 0;
            decimal money = 0;
            XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
            details.WarehouseId = wareHousesId;
            details.ProductId = info.ProductId;
            details.PlatformMerchantCode = info.PlatformMerchantCode;
            details.InCount = info.ProductsCount;                  //入库数量
            details.InPrice = info.ProductsPrice;                      //入库单价
            details.InMoney = info.ProductsMoney;
            details.OutCount = 0;
            details.OutPrice = price;
            details.OutMoney = money;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                details.BalanceCount = BalanceCount + details.InCount;
            }
            else           //
            {
                details.BalanceCount = details.InCount;
            }
            details.BalancePrice = info.ProductsPrice;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            details.BalanceMoney = details.BalanceCount * details.BalancePrice;
            var storages = base.XMStorageService.GetXMStorageById(info.StorageId);
            if (storages != null)
            {
                details.RefNumber = storages.Ref;        //业务单号
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        #endregion

        /// <summary>
        /// 根据采购单和采购入库单对比自动生成采购退货单     如 采购数量 大于采购入库数量       被拒件（采购数量-采购入库数量 ）
        /// </summary>
        /// <param name="PurchaseNumber">采购单号</param>
        /// <param name="refNumber">入库单号</param>
        public void AutoInsertPurchaseRejectedData(string PurchaseNumber, string refNumber)
        {
            var PurchaseRejecteds = base.XMPurchaseRejectedService.GetXMPurchaseRejectedsByRef(PurchaseNumber);
            var Purchase = base.XMPurchaseService.GetXMPurchaseBypurChaseCode(PurchaseNumber);
            var Purchasede = base.XMPurchaseProductDetailsService.GetXMPurchaseProductDetailsByPurchaseID(Purchase[0].Id);
            var XM_Storage = base.XMStorageService.GetXMStorageByRef(refNumber);
            var XM_Storagede = base.XMStorageProductDetailsService.GetXMStorageProductDetailsByStorageID(XM_Storage[0].Id);
            List<StorageProductDetailInfos> Lists = new List<StorageProductDetailInfos>();
            foreach (XMStorageProductDetails paramXMStorageProductDetails in XM_Storagede)
            {
                StorageProductDetailInfos storageDeatail = new StorageProductDetailInfos();
                var Purchasedeone =Purchasede.Where(p=>p.PlatformMerchantCode.Equals(paramXMStorageProductDetails.PlatformMerchantCode)).ToList();
                storageDeatail.refNumber = refNumber;
                storageDeatail.ManufacturersCode = paramXMStorageProductDetails.PlatformMerchantCode;
                storageDeatail.purcahseCount = Purchasedeone[0].ProductCount;
                storageDeatail.storageCount = paramXMStorageProductDetails.ProductsCount;
                storageDeatail.puchasePrice = paramXMStorageProductDetails.ProductsPrice;
                Lists.Add(storageDeatail);
            }
            if (PurchaseRejecteds == null)
            {
                List<XMPurchaseRejectedProductDetails> PurchaseRejectedList = new List<XMPurchaseRejectedProductDetails>();
                if (Lists != null && Lists.Count > 0)
                {
                    foreach (StorageProductDetailInfos Info in Lists)
                    {
                        int ccCount = Info.purcahseCount - Info.storageCount;
                        if (ccCount > 0)
                        {
                            //生成采购退货单
                            XMPurchaseRejectedProductDetails detaisl = new XMPurchaseRejectedProductDetails();
                            var products = base.XMProductService.getXMProductByManufacturersCode(Info.ManufacturersCode);
                            if (products != null)
                            {
                                detaisl.ProductId = products.Id;
                            }
                            detaisl.PlatformMerchantCode = Info.ManufacturersCode;
                            detaisl.RejectionCount = ccCount;    //残次件数量
                            detaisl.RejectionProductPrice = Info.puchasePrice;
                            detaisl.RejectionMoney = ccCount * Info.puchasePrice;
                            detaisl.CreateDate = detaisl.UpdateDate = DateTime.Now;
                            detaisl.CreateID = detaisl.UpdateID = HozestERPContext.Current.User.CustomerID;
                            detaisl.IsEnable = false;
                            detaisl.BillStatus = 0;    //默认为待退回
                            PurchaseRejectedList.Add(detaisl);
                        }
                    }
                }

                //自动生成采购退货单主表及从表数据
                if (PurchaseRejectedList.Count > 0)
                {
                    //生成采购退货单主表
                    XMPurchaseRejected d = new XMPurchaseRejected();
                    d.Ref = PurchaseNumber;
                    var purchaseInfo2 = base.XMPurchaseService.GetXMPurchaseBypurChaseCode(PurchaseNumber);
                    if (purchaseInfo2 != null && purchaseInfo2.Count > 0)
                    {
                        d.MId = purchaseInfo2[0].Id;
                        d.EmitFactory = purchaseInfo2[0].EmitFactory;   //发出工厂
                    }
                    d.SupplierId = 1;
                    d.BizUserId = HozestERPContext.Current.User.CustomerID;
                    d.BizDt = DateTime.Now;
                    d.BillStatus = 0;       //状态 待退货
                    d.RejectionMoney = PurchaseRejectedList.Sum(p => p.RejectionMoney);
                    d.ReceivingType = 700;
                    d.CreateDate = d.UpdateDate = DateTime.Now;
                    d.CreateID = d.UpdateID = HozestERPContext.Current.User.CustomerID;
                    d.IsEnable = false;
                    d.IsAudit = true;
                    d.IsStoraged = false;

                    base.XMPurchaseRejectedService.InsertXMPurchaseRejected(d);

                    //生成采购退货单明细表
                    foreach (XMPurchaseRejectedProductDetails p in PurchaseRejectedList)
                    {
                        p.PrId = d.Id;
                        base.XMPurchaseRejectedProductDetailsService.InsertXMPurchaseRejectedProductDetails(p);
                    }
                }
            }
        }

        /// <summary>
        /// 导出入库单明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStorageInfoExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\StorageInfoExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    string nickids = GetCustomerMappingNickIDs();
                    int projectId = ddXMProject.SelectedValue == "" ? -1 : Convert.ToInt16(ddXMProject.SelectedValue);
                    int status = int.Parse(ddlStatus.SelectedValue);    //状态
                    string storageCode = txtPurChaseCode.Text.Trim();    //入库单号自动生成 
                    //开始日期
                    string Begin = this.txtBeginDate.Value.Trim();
                    //结束日期
                    string End = this.txtEndDate.Value.Trim();
                    int supplierId = ddlSupplierList.SelectedValue == "" ? -1 : Convert.ToInt16(ddlSupplierList.SelectedValue);                   //供应商ID
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

                    var list = base.XMStorageService.GetXMStorageByParm(storageCode, Begin, End, supplierId, paramwareHourseIDs, status, projectId, nickids);

                    list = list.OrderByDescending(p => p.BizDt).ToList();
                    base.ExportManager.StorageInfoToXls(filePath, list);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }
    }
}