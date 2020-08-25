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
using System.Web;
using System.IO;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageCustomerService;

namespace HozestERP.Web.ManageInventory
{
    public partial class SaleDeliveryList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //弹出导入产品销量窗口
                this.btnImortDelivery.OnClientClick = "return ShowWindowDetail('导入京东自营出库产品销量','" + CommonHelper.GetStoreLocation() +
            "ManageInventory/ImportSaleProduct.aspx',800,500, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
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
        private string GetXMSaleDeliveryListByProjectID()
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
                base.ShowMessage("您无权限查看销售出库单");
                return;
            }
            string saleCode = txtSaleRef.Text.Trim();       //出库单号
            int bizUserId = ddlBizPerson.SelectedValue == "" ? -1 : int.Parse(ddlBizPerson.SelectedValue);
            int projectId = ddXMProject.SelectedValue == "" ? -1 : int.Parse(ddXMProject.SelectedValue);
            int status = int.Parse(ddlStatus.SelectedValue);    //状态(待出库 已出库)
            string deliveryCode = txtPurChaseCode.Text.Trim();    //出库单号自动生成 
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
            var list = base.XMSaleDeliveryService.GetXMSaleDeliveryListByParm(deliveryCode, Begin, End, paramwareHourseIDs, status, projectId, nickids, saleCode, bizUserId);

            list = list.OrderByDescending(p => p.BizDt).ToList();
            var pageList = new PagedList<XMSaleDelivery>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvSaleDelivery, pageList);
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
            //绑定业务员下拉框
            List<CustomerInfo> List = new List<CustomerInfo>();
            var BizUsers = base.XMSaleDeliveryService.GetXMSaleDeliveryList().GroupBy(p => p.BizUserId).Select(g => new { ID = g.Key }).ToList();
            if (BizUsers != null && BizUsers.Count > 0)
            {
                foreach (var info in BizUsers)
                {
                    var CustomerInfo = base.CustomerInfoService.GetCustomerInfoByID(info.ID.Value);
                    if (CustomerInfo != null)
                    {
                        List.Add(CustomerInfo);
                    }
                }
            }
            ddlBizPerson.DataSource = List;
            ddlBizPerson.DataTextField = "FullName";
            ddlBizPerson.DataValueField = "CustomerID";
            ddlBizPerson.DataBind();
            ddlBizPerson.Items.Insert(0, new ListItem("---所有---", "-1"));

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
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string nickids = GetCustomerMappingNickIDs();
                    if (nickids == "")
                    {
                        base.ShowMessage("您无权限查看销售出库单");
                        return;
                    }
                    string saleCode = txtSaleRef.Text.Trim();       //出库单号
                    int bizUserId = ddlBizPerson.SelectedValue == "" ? -1 : int.Parse(ddlBizPerson.SelectedValue);
                    int projectId = ddXMProject.SelectedValue == "" ? -1 : int.Parse(ddXMProject.SelectedValue);
                    int status = int.Parse(ddlStatus.SelectedValue);    //状态(待出库 已出库)
                    string deliveryCode = txtPurChaseCode.Text.Trim();    //出库单号自动生成 
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
                    var list = base.XMSaleDeliveryService.GetXMSaleDeliveryListByParm(deliveryCode, Begin, End, paramwareHourseIDs, status, projectId, nickids, saleCode, bizUserId);

                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\SaleDeliveryDetailExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    base.ExportManager.ExportSaleDeliveryDetail(filePath, list);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        protected void grdvSaleDelivery_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMSaleDelivery;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                ImageButton imgSaleReturned = e.Row.FindControl("imgSaleReturned") as ImageButton;      //生成销售退货单
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑出库单详情','" + CommonHelper.GetStoreLocation() +
        "ManageInventory/SaleDeliveryAdd.aspx?Type=1"
          + "&&SaleDeliveryID=" + info.Id
        + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('查看出库单详情','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/SaleDeliveryAdd.aspx?Type=2"
       + "&&SaleDeliveryID=" + info.Id
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }

                if (imgSaleReturned != null)
                {
                    imgSaleReturned.OnClientClick = "return ShowWindowDetail('生成销售退货单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/SaleReturnAdd.aspx?Type=0"
       + "&&SaleDeliveryID=" + info.Id
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }

                var delivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(info.Id);
                if (delivery != null)
                {
                    switch (delivery.BillStatus)
                    {
                        case 0:                          //状态为待出库  可进行编辑和删除
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
                            if (imgSaleReturned != null)
                            {
                                imgSaleReturned.Visible = false;
                            }
                            break;
                        case 1000:                  //状态为已出库  无法编辑和删除只能产看
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

        protected void grdvSaleDelivery_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    //删除出库单主表和产品明细表
                    var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(int.Parse(id));
                    if (saleDelivery != null)
                    {
                        //删除主表
                        saleDelivery.IsEnable = true;
                        saleDelivery.UpdateDate = DateTime.Now;
                        saleDelivery.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMSaleDeliveryService.UpdateXMSaleDelivery(saleDelivery);
                        var details = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(saleDelivery.Id);
                        if (details != null && details.Count > 0)
                        {
                            foreach (XMSaleDeliveryProductDetails parm in details)
                            {
                                parm.IsEnable = true;
                                parm.UpdateDate = DateTime.Now;
                                parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMSaleDeliveryProductDetailsService.UpdateXMSaleDeliveryProductDetails(parm);
                            }
                        }

                        //判断是否是线上订单  如是线上订单需更新订单审核状态
                        var orderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(saleDelivery.SaleRef);
                        if (orderInfo != null)         //线上订单
                        {
                            if (saleDelivery.OrderInfoID > 0)
                            {
                                orderInfo.IsAudit = false;
                                orderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                orderInfo.UpdateDate = DateTime.Now;
                                foreach (XMOrderInfoProductDetails xmpd in orderInfo.XM_OrderInfoProductDetails)
                                {
                                    xmpd.IsAudit = false;
                                    xmpd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    xmpd.UpdateDate = DateTime.Now;
                                }
                                base.XMOrderInfoService.UpdateXMOrderInfo(orderInfo);//修改审核状态

                                //操作记录
                                XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                record.PropertyName = "删除出库单-订单自动反审核";
                                record.OldValue = System.Convert.ToString(true);
                                record.NewValue = System.Convert.ToString(false);
                                record.OrderInfoId = orderInfo.ID;
                                record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                record.UpdateTime = DateTime.Now;
                                base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
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
        /// 出库审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeliveryIsAudit_Click(object sender, EventArgs e)
        {
            List<int> grdDeliveryIDs = this.Master.GetSelectedIds(this.grdvSaleDelivery);
            if (grdDeliveryIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdDeliveryIDs)
                {
                    var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(ID);
                    if (saleDelivery != null)
                    {
                        saleDelivery.IsAudit = true;
                        saleDelivery.UpdateDate = DateTime.Now;
                        saleDelivery.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMSaleDeliveryService.UpdateXMSaleDelivery(saleDelivery);
                    }
                }
            }
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("操作成功!");
        }


        /// <summary>
        /// 出库反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeliveryIsAuditFalse_Click(object sender, EventArgs e)
        {
            bool isOk = false;
            string errMessage = "";
            List<int> grdDeliveryIDs = this.Master.GetSelectedIds(this.grdvSaleDelivery);
            if (grdDeliveryIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdDeliveryIDs)
                {
                    var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(ID);
                    if (saleDelivery != null && saleDelivery.BillStatus == 1000)
                    {
                        isOk = true;
                        errMessage = errMessage + saleDelivery.Ref + ";";
                    }
                }
            }
            if (isOk)
            {
                base.ShowMessage("出库单号为：" + errMessage + "的出库单已经出库，无法反审核！");
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                return;
            }
            if (grdDeliveryIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdDeliveryIDs)
                {
                    var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(ID);
                    if (saleDelivery != null)
                    {
                        saleDelivery.IsAudit = false;
                        saleDelivery.UpdateDate = DateTime.Now;
                        saleDelivery.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMSaleDeliveryService.UpdateXMSaleDelivery(saleDelivery);
                    }
                }
            }
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("操作成功!");
        }


        /// <summary>
        /// 提交出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelivery_Click(object sender, EventArgs e)
        {
            bool isAudit = false;
            bool isInventLess = false;
            bool isDelivery = false;
            string errMessage = "";
            List<int> deliveryIDs = this.Master.GetSelectedIds(this.grdvSaleDelivery);
            if (deliveryIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {

                //判断是否已经全部审核
                foreach (int ID in deliveryIDs)
                {
                    var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(ID);
                    if (saleDelivery != null)
                    {
                        bool deliveryIsAudit = saleDelivery.IsAudit == null ? false : saleDelivery.IsAudit.Value;
                        if (!deliveryIsAudit)
                        {
                            isAudit = true;
                            errMessage = errMessage + saleDelivery.Ref + ";";
                        }
                        if (saleDelivery.BillStatus ==1000)    //出库单已出库
                        {
                            isDelivery = true;
                            errMessage = errMessage + saleDelivery.Ref + ";";
                        }
                    }
                }
                if (isAudit)
                {
                    base.ShowMessage("出库单号为：" + errMessage + "未通过审核，无法出库！");
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    return;
                }
                if(isDelivery)
                {
                    base.ShowMessage("出库单号为：" + errMessage + "已出库，出库失败！");
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    return;
                }

                #region     判断商品库存是否充足
                List<SaleDeliveryProduct> List = new List<SaleDeliveryProduct>();
                //统计选中所有商品
                foreach (int ID in deliveryIDs)
                {
                    var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(ID);
                    if (saleDelivery != null)
                    {
                        var saleDeliveryDetail = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(saleDelivery.Id);
                        if (saleDeliveryDetail != null && saleDeliveryDetail.Count > 0)
                        {
                            foreach (XMSaleDeliveryProductDetails parm in saleDeliveryDetail)
                            {
                                SaleDeliveryProduct list = new SaleDeliveryProduct();
                                list.pcode = parm.PlatformMerchantCode;
                                list.saleDeliveryCount = parm.SaleCount.Value;
                                list.wareHoueseID = saleDelivery.WareHouseId;
                                List.Add(list);
                            }
                        }
                    }
                }
                if (List != null && List.Count > 0)
                {
                    var List2 = from l in List
                                group l by new { l.pcode, l.wareHoueseID } into g
                                select new
                                {
                                    pcode = g.Key.pcode,
                                    wareHoueseID = g.Key.wareHoueseID,
                                    saleDeliveryCount = g.Sum(a => a.saleDeliveryCount)
                                };

                    if (List2 != null && List2.Count() > 0)
                    {
                        foreach (var parm in List2)
                        {
                            var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(parm.pcode, parm.wareHoueseID);
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
                #endregion
            }

            if (isInventLess)
            {
                base.ShowMessage("商品编码为：" + errMessage + "库存不足，无法出库！");
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                return;
            }
            if (deliveryIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                //提交出库
                foreach (int ID in deliveryIDs)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        var deliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryById(ID);
                        if (deliveryInfo != null && deliveryInfo.BillStatus == 0)
                        {
                            deliveryInfo.BillStatus = 1000;   //状态更新为已出库
                            deliveryInfo.UpdateDate = DateTime.Now;
                            deliveryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMSaleDeliveryService.UpdateXMSaleDelivery(deliveryInfo);
                            //更新产品库存表（减掉出库数量）
                            var deliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(deliveryInfo.Id);
                            if (deliveryProductDetails != null && deliveryProductDetails.Count > 0)
                            {
                                foreach (XMSaleDeliveryProductDetails parm in deliveryProductDetails)
                                {
                                    string code = parm.PlatformMerchantCode;              //商品编码
                                    int wfID = deliveryInfo.WareHouseId;                              //出库仓库ID
                                    var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, wfID);
                                    if (InventoryInfo != null)                             //商品编码为code的产品在库存表中已经存在 更新库存数量
                                    {
                                        InventoryInfo.StockNumber = InventoryInfo.StockNumber - parm.SaleCount;             //库存减掉出库量
                                        InventoryInfo.CanOrderCount = InventoryInfo.StockNumber;
                                        InventoryInfo.UpdateDate = DateTime.Now;
                                        InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);

                                        //
                                        UpdateSaleDeliveryBarCodes(InventoryInfo.Id, parm.Id);
                                    }
                                    //更新库存总账主表数据   从表添加一条记录
                                    UpdateInventoryLederInfo(deliveryInfo.WareHouseId, parm);
                                    //删除库存商品条形码
                                    //UpdateInventoryBarCodeInfo(InventoryInfo.Id, parm.Id);
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
        /// 删除出库产品条形码
        /// </summary>
        private void UpdateSaleDeliveryBarCodes(int inventoryID, int saleDeliveryProductID)
        {
            //根据产品详情ID 获取入库产品的条形码列表
            var barCodes = base.XMSaleDeliveryBarCodeDetailService.GetXMSaleDeliveryBarCodeDetailListBySpdID(saleDeliveryProductID);
            if (barCodes != null && barCodes.Count > 0)
            {
                //遍历所有条形码
                foreach (XMSaleDeliveryBarCodeDetail Info in barCodes)
                {
                    var inventoryBarCodes = base.XMInventoryBarcodeDetailService.GetXMInventoryBarcodeDetailListByInventoryIDAndBarCode(inventoryID, Info.BarCode);
                    if (inventoryBarCodes != null)    //该产品条形码已经存在  更新状态为删除
                    {
                        inventoryBarCodes.IsEnable = true;    //删除该条形码   出库成功
                        inventoryBarCodes.UpdateDate = DateTime.Now;
                        inventoryBarCodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMInventoryBarcodeDetailService.UpdateXMInventoryBarcodeDetail(inventoryBarCodes);
                    }
                }
            }
        }


        //根据状态平均算出销售单价  (状态出库  入库   在途)
        private decimal CalculateProductPrice(int wareHousesId, XMSaleDeliveryProductDetails info, int satatus)
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
            count = count + info.SaleCount.Value;
            money = money + info.ProductPrice.Value * info.SaleCount.Value;
            price = money / count;
            return price;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHousesId"></param>
        /// <param name="info"></param>
        private void UpdateInventoryLederInfo(int wareHousesId, XMSaleDeliveryProductDetails info)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, info.PlatformMerchantCode);
            if (inventoryLeder != null)     //更新数据
            {
                //更新出库数量
                inventoryLeder.OutCount = (inventoryLeder.OutCount == null ? 0 : inventoryLeder.OutCount) + info.SaleCount;
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
                inventoryLederInfo.OutCount = info.SaleCount;
                inventoryLederInfo.OutPrice = info.ProductPrice;
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.InCount = 0;
                inventoryLederInfo.InPrice = info.ProductPrice;
                inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                inventoryLederInfo.AfloatCount = 0;
                inventoryLederInfo.AfloatPrice = info.ProductPrice;
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
            details.OutCount = info.SaleCount;
            details.OutPrice = info.ProductPrice;
            details.OutMoney = info.SaleCount * info.ProductPrice;
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
            details.BalancePrice = info.ProductPrice;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            var saleDeliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryById(info.SaleDeliveryId);
            if (saleDeliveryInfo != null)
            {
                details.RefNumber = saleDeliveryInfo.Ref;
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1002;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
        }

        public void Face_Init()
        {

        }

        #endregion

    }
}