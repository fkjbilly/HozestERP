using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using System.Web;
using System.IO;
using System.Transactions;

namespace HozestERP.Web.ManageInventory
{
    //未入库采购退货单
    public partial class RejectedList : BaseAdministrationPage, ISearchPage
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
        /// 根据当前用户的角色获取包含用户customerId 并拼接成字符串形式 用逗号隔开
        /// </summary>
        /// <returns></returns>
        private string GetInCludeCustomerByRole()
        {
            string cids = HozestERPContext.Current.User.CustomerID.ToString() + "," + "7,";
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
            //未入库退货单列表
            var list = base.XMPurchaseRejectedService.GetXMPurchaseRejectedListByParm(rejectedCode, productName, Begin, End, supplierId, status, customerids, false);
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
                Literal lblBillStatus = e.Row.FindControl("lblBillStatus") as Literal;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑采购退货单','" + CommonHelper.GetStoreLocation() +
        "ManageInventory/RejectedAdd.aspx?Type=1"
          + "&&RejectedID=" + info.Id + "&&PurchaseID=" + info.MId
        + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('查看采购退货单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/RejectedAdd.aspx?Type=2"
       + "&&RejectedID=" + info.Id + "&&PurchaseID=" + info.MId
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
                    bool isReturn = true;    //
                    var rejectedProductDetail = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(rejected.Id);
                    if (rejectedProductDetail != null && rejectedProductDetail.Count > 0)
                    {
                        foreach (XMPurchaseRejectedProductDetails Info in rejectedProductDetail)
                        {
                            if (Info.BillStatus == null || Info.BillStatus == 0)
                            {
                                isReturn = false;
                                break;
                            }
                        }
                    }
                    if (lblBillStatus != null)
                    {
                        lblBillStatus.Text = !isReturn ? "待退回" : "已退回";
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
                base.ShowMessage("操作成功成功.");
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
        /// 退回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsReturn_Click(object sender, EventArgs e)
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
                        //rejecteds.BillStatus = 1000;      //修改状态为已退回
                        //rejecteds.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        //rejecteds.UpdateDate = DateTime.Now;
                        //base.XMPurchaseRejectedService.UpdateXMPurchaseRejected(rejecteds);
                        var rejectedDetail = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(rejecteds.Id);
                        if (rejectedDetail != null && rejectedDetail.Count > 0)
                        {
                            foreach (XMPurchaseRejectedProductDetails Info in rejectedDetail)
                            {
                                Info.BillStatus = 1000;
                                Info.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                                Info.UpdateDate = DateTime.Now;
                                base.XMPurchaseRejectedProductDetailsService.UpdateXMPurchaseRejectedProductDetails(Info);
                            }
                        }
                    }
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功！");
            }
        }


        /// <summary>
        /// 退回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConcelIsReturn_Click(object sender, EventArgs e)
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
                        //rejecteds.BillStatus = 0;      //修改状态为退回
                        //rejecteds.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        //rejecteds.UpdateDate = DateTime.Now;
                        //base.XMPurchaseRejectedService.UpdateXMPurchaseRejected(rejecteds);
                        var rejectedDetail = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(rejecteds.Id);
                        if (rejectedDetail != null && rejectedDetail.Count > 0)
                        {
                            foreach (XMPurchaseRejectedProductDetails Info in rejectedDetail)
                            {
                                Info.BillStatus = 1000;
                                Info.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                                Info.UpdateDate = DateTime.Now;
                                base.XMPurchaseRejectedProductDetailsService.UpdateXMPurchaseRejectedProductDetails(Info);
                            }
                        }
                    }
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功！");
            }
        }


        /// <summary>
        /// 导出退货单数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImportData_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
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
                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\PurchaseRejectedExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    //读取数据
                    List<HozestERP.BusinessLogic.ManageInventory.PurchaseRejectedDetail> Info = new List<HozestERP.BusinessLogic.ManageInventory.PurchaseRejectedDetail>();
                    var list = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsListByParm(rejectedCode, productName, Begin, End, supplierId, status, customerids, false);
                    List<int> rejectedIDs = this.Master.GetSelectedIds(this.grdvRejected);
                    if (rejectedIDs.Count <= 0)
                    {
                        Info = list;
                    }
                    else
                    {
                        if (list != null && list.Count > 0)
                        {
                            foreach (HozestERP.BusinessLogic.ManageInventory.PurchaseRejectedDetail one in list)
                            {
                                if (rejectedIDs.IndexOf(one.PrId) != -1)
                                {
                                    Info.Add(one);
                                }
                            }
                        }
                    }
                    base.ExportManager.ExportPurchaseRejectedDetail(filePath, Info);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
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