using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using System.Linq;

namespace HozestERP.Web.ManageInventory
{
    public partial class SaleList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.btnSaleAdd.OnClientClick = "return ShowWindowDetail('新建销售订单','" + CommonHelper.GetStoreLocation() +
"ManageInventory/SaleAdd.aspx?Type=0"
+ "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                BindGrid(1, Master.PageSize);
            }
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
            string saleCode = txtPurChaseCode.Text.Trim();    //销售单号自动生成 
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            string customerName = txtName.Text.Trim();
            int status = Convert.ToInt16(ddlVerify.SelectedValue);         // 是否审核
            int projectId = ddXMProject.SelectedValue == "" ? -1 : int.Parse(ddXMProject.SelectedValue);

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

            var list = base.XMSaleInfoService.GetXMSaleInfoListByParm(saleCode, Begin, End, status, customerName, customerids, projectId);
            var pageList = new PagedList<XMSaleInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvSaleInfo, pageList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvSaleInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMSaleInfo;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                ImageButton imgSaleDelivery = e.Row.FindControl("imgSaleDelivery") as ImageButton;
                Label lblDeliveryStatus = e.Row.FindControl("lblDeliveryStatus") as Label;        //出库状态
                Label lblDeliveryProgress = e.Row.FindControl("lblSaleDeliveryProgress") as Label;        //出库进度

                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑销售订单','" + CommonHelper.GetStoreLocation() +
        "ManageInventory/SaleAdd.aspx?Type=1"
          + "&&id=" + info.Id
        + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('查看销售订单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/SaleAdd.aspx?Type=2"
       + "&&id=" + info.Id
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgSaleDelivery != null)
                {
                    imgSaleDelivery.OnClientClick = "return ShowWindowDetail('生成销售出库单','" + CommonHelper.GetStoreLocation() +
   "ManageInventory/SaleDeliveryAdd.aspx?Type=0"
     + "&&SaleInfoID=" + info.Id
   + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }

                var saleInfo = base.XMSaleInfoService.GetXMSaleInfoById(info.Id);
                if (saleInfo != null)
                {
                    int FinancialStatus = saleInfo.FinancialStatus.Value ? 1 : 0;
                    switch (FinancialStatus)
                    {
                        case 0:
                            if (imgProductDetails != null)
                            {
                                imgProductDetails.Visible = false;
                            }
                            if (imgSaleDelivery != null)
                            {
                                imgSaleDelivery.Visible = false;
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
                            if (saleInfo.BillStatus == 2)    //已全部出库
                            {
                                imgSaleDelivery.Visible = false;
                            }
                            break;
                    }
                }

                // //判断更新销售单状态
                int saleInfoId = info.Id;
                if (info.BillStatus != null)
                {
                    UpdateDeliveryStatus(saleInfoId, info.BillStatus.Value);
                }

                lblDeliveryProgress.Text = GetSaleDeliveryProgress(saleInfoId);
            }
        }


        private string GetSaleDeliveryProgress(int infoID)
        {
            int saleCount = 0;
            int devliveryCount = 0;
            var saleInfo = base.XMSaleInfoService.GetXMSaleInfoById(infoID);
            if (saleInfo != null)
            {
                var saleInfoProductDetail = base.XMSaleInfoProductDetailsService.GetSaleInfoProductDetailsBySaleId(saleInfo.Id);
                if (saleInfoProductDetail != null && saleInfoProductDetail.Count > 0)
                {
                    foreach (XMSaleInfoProductDetails saleDetails in saleInfoProductDetail)
                    {
                        saleCount = saleCount + saleDetails.SaleCount.Value;
                    }
                }
            }
            var saleDelviery = base.XMSaleDeliveryService.GetXMSaleDeliveryListBySaleInfoID(infoID);
            if (saleDelviery != null && saleDelviery.Count > 0)
            {
                foreach (XMSaleDelivery Info in saleDelviery)
                {
                    var saleDelvieryPorduct = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(Info.Id);
                    if (saleDelvieryPorduct != null && saleDelvieryPorduct.Count > 0)
                    {
                        foreach (XMSaleDeliveryProductDetails details in saleDelvieryPorduct)
                        {
                            devliveryCount = devliveryCount + details.SaleCount.Value;
                        }
                    }
                }
            }
            return devliveryCount.ToString() + "/" + saleCount.ToString();
        }

        private void UpdateDeliveryStatus(int infoID, int saleStatus)
        {
            int status = 0;
            int saleCount = 0;
            int deliveryCount = 0;
            var saleInfo = base.XMSaleInfoService.GetXMSaleInfoById(infoID);
            if (saleInfo != null)
            {
                var saleInfoProductDetail = base.XMSaleInfoProductDetailsService.GetSaleInfoProductDetailsBySaleId(saleInfo.Id);
                if (saleInfoProductDetail != null && saleInfoProductDetail.Count > 0)
                {
                    foreach (XMSaleInfoProductDetails saleDetails in saleInfoProductDetail)
                    {
                        saleCount = saleCount + saleDetails.SaleCount.Value;
                        //更具销售单ID 查询所有出库单
                        var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryListByDeliveryStatus(saleInfo.Id);
                        if (saleDelivery != null && saleDelivery.Count > 0)
                        {
                            foreach (XMSaleDelivery delivery in saleDelivery)
                            {
                                var saledeliveryPorductDetail = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(delivery.Id);
                                if (saledeliveryPorductDetail != null && saledeliveryPorductDetail.Count > 0)
                                {
                                    foreach (XMSaleDeliveryProductDetails parm in saledeliveryPorductDetail)
                                    {
                                        if (parm.PlatformMerchantCode == saleDetails.PlatformMerchantCode && parm.ProductPrice == saleDetails.ProductPrice)
                                        {
                                            deliveryCount = deliveryCount + parm.SaleCount.Value;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (deliveryCount == 0)          //没有产品出库
                {
                    status = 0;    //状态为待出库
                }
                if (deliveryCount > 0 && deliveryCount < saleCount)    //出库数量小于销售数量
                {
                    status = 1;  //状态为部分出库
                }
                if (deliveryCount == saleCount)     //
                {
                    status = 2;  //状态为全部出库
                }
                if (saleStatus != status)
                {
                    saleInfo.BillStatus = status;
                    base.XMSaleInfoService.UpdateXMSaleInfo(saleInfo);
                }
            }
        }
        /// <summary>
        /// 获取出库状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string getDeliveryStauts(string status)
        {
            string name = "";
            switch (status)
            {
                case "0":
                    name = "待出库";
                    break;
                case "1":
                    name = "部分出库";
                    break;
                case "2":
                    name = "全部出库";
                    break;
            }
            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvSaleInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string errMessage = "出库单号为";
            bool isAudit = false;
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    //删除销售单主表信息和销售单产品明细表
                    var saleInfo = base.XMSaleInfoService.GetXMSaleInfoById(int.Parse(id));
                    if (saleInfo != null)
                    {
                        var saleDeliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryListBySaleInfoID(saleInfo.Id);
                        if (saleDeliveryInfo.Count == 0)              //无出库单生成   直接删除
                        {
                            //删除主表
                            saleInfo.IsEnable = true;
                            saleInfo.UpdateDate = DateTime.Now;
                            saleInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMSaleInfoService.UpdateXMSaleInfo(saleInfo);
                            var details = base.XMSaleInfoProductDetailsService.GetSaleInfoProductDetailsBySaleId(saleInfo.Id);
                            if (details != null && details.Count > 0)
                            {
                                foreach (XMSaleInfoProductDetails parm in details)
                                {
                                    parm.IsEnable = true;
                                    parm.UpdateDate = DateTime.Now;
                                    parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    base.XMSaleInfoProductDetailsService.UpdateXMSaleInfoProductDetails(parm);
                                }
                            }
                            base.ShowMessage("操作成功！");
                        }
                        else
                        {
                            foreach (XMSaleDelivery Info in saleDeliveryInfo)
                            {
                                if (Info.IsAudit.Value)
                                {
                                    isAudit = true;
                                    errMessage += Info.Ref + "；";
                                }
                            }
                            if (isAudit)
                            {
                                base.ShowMessage(errMessage + "的出库单已审核通过，无法删除销售单！");
                            }
                            else
                            {
                                //删除销售订单主表
                                saleInfo.IsEnable = true;
                                saleInfo.UpdateDate = DateTime.Now;
                                saleInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMSaleInfoService.UpdateXMSaleInfo(saleInfo);
                                var details = base.XMSaleInfoProductDetailsService.GetSaleInfoProductDetailsBySaleId(saleInfo.Id);
                                if (details != null && details.Count > 0)
                                {
                                    foreach (XMSaleInfoProductDetails parm in details)
                                    {
                                        parm.IsEnable = true;
                                        parm.UpdateDate = DateTime.Now;
                                        parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMSaleInfoProductDetailsService.UpdateXMSaleInfoProductDetails(parm);
                                    }
                                }

                                //删除销售订单对应出库单主表
                                foreach (XMSaleDelivery Info in saleDeliveryInfo)
                                {
                                    Info.IsEnable = true;
                                    Info.UpdateDate = DateTime.Now;
                                    Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    base.XMSaleDeliveryService.UpdateXMSaleDelivery(Info);
                                }
                                base.ShowMessage("操作成功！");
                            }
                        }
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
        /// <param name="id"></param>
        /// <returns></returns>
        public bool getIsAudit(int id)
        {
            bool isAudit = false;
            var Info = base.XMSaleInfoService.GetXMSaleInfoById(id);
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

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAudit_Click(object sender, EventArgs e)
        {
            List<int> SaleInfoIDs = this.Master.GetSelectedIds(this.grdvSaleInfo);
            if (SaleInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in SaleInfoIDs)
                {
                    var saleInfo = base.XMSaleInfoService.GetXMSaleInfoById(Convert.ToInt32(ID));
                    if (saleInfo != null)
                    {
                        saleInfo.FinancialStatus = true;
                        saleInfo.UpdateDate = DateTime.Now;
                        saleInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMSaleInfoService.UpdateXMSaleInfo(saleInfo);
                    }
                }

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功!");
            }
        }

        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAuditFalse_Click(object sender, EventArgs e)
        {
            List<int> SaleInfoIDs = this.Master.GetSelectedIds(this.grdvSaleInfo);
            if (SaleInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in SaleInfoIDs)
                {
                    var saleInfo = base.XMSaleInfoService.GetXMSaleInfoById(Convert.ToInt32(ID));
                    if (saleInfo != null)
                    {
                        saleInfo.FinancialStatus = false;
                        saleInfo.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        saleInfo.UpdateDate = DateTime.Now;
                        base.XMSaleInfoService.UpdateXMSaleInfo(saleInfo);
                    }
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功！");
            }
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
                }
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
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
        }

        #endregion

    }
}