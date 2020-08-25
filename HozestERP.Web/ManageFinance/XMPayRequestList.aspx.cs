using System;
using System.Collections.Generic;
using HozestERP.Common;
using HozestERP.BusinessLogic;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    public partial class XMPayRequestList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick= "return ShowWindowDetail('付款申请单修改','" + CommonHelper.GetStoreLocation() +
            "ManageFinance/XMPaymentRequest.aspx?"

        + "',900,500, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                BindGrid(1, Master.PageSize);
            }
        }


        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //string purchaseNumber = txtPurchaseNumber.Text.Trim();
            string purchaseRef = txtPurchaseRef.Text.Trim();
            string Requester = txtRequester.Text.Trim();
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
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
            //int isAudit = int.Parse(ddIsAudit.SelectedValue);
            int FinancialStatus = int.Parse(ddlFinancialStatus.SelectedValue);
            int FinanceOkIsAudit = int.Parse(ddFinanceOkIsAudit.SelectedValue);

            //string Year = this.ddlYear.SelectedValue;//年
            var list = base.XMPaymentApplyService.GetXMPaymentApply(purchaseRef,Requester, Begin, End, -1, FinancialStatus, FinanceOkIsAudit);
            var pageList = new PagedList<HozestERP.BusinessLogic.ManageFinance.XMPaymentApply>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            this.Master.BindData(this.gvPayRequest, pageList);
        }


        /// <summary>
        /// 公司审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAudit_Click(object sender, EventArgs e)
        {
            bool isAudit = false;
            string errMessage = "";
            List<int> grdPayRequestIDs = this.Master.GetSelectedIds(this.gvPayRequest);
            if (grdPayRequestIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdPayRequestIDs)
                {
                    var payRequest = base.XMPaymentApplyService.GetXMPaymentApplyById(ID);
                    if (payRequest != null && !payRequest.FinancialStatus.Value)
                    {
                        isAudit = true;
                        errMessage = errMessage + payRequest.PurchaseRef + ";";
                    }
                }
            }
            if (isAudit)
            {
                base.ShowMessage("采购单号为" + errMessage + "财务未审核，无法公司审核！");
                return;
            }

            if (grdPayRequestIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdPayRequestIDs)
                {
                    var payRequest = base.XMPaymentApplyService.GetXMPaymentApplyById(ID);
                    if (payRequest != null)
                    {
                        if (payRequest.FinancialStatus.Value)
                        {
                            payRequest.IsAudit = true;
                            payRequest.IsAuditDate = DateTime.Now;
                            payRequest.IsAuditPerson = HozestERPContext.Current.User.CustomerID;
                            payRequest.UpdateDate = DateTime.Now;
                            payRequest.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMPaymentApplyService.UpdateXMPaymentApply(payRequest);
                        }
                    }
                }
            }
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("操作成功!");
        }

        /// <summary>
        /// 公司反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAuditNO_Click(object sender, EventArgs e)
        {
            bool isAudit = false;
            string errMessage = "";
            List<int> grdPayRequestIDs = this.Master.GetSelectedIds(this.gvPayRequest);
            if (grdPayRequestIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdPayRequestIDs)
                {
                    var payRequest = base.XMPaymentApplyService.GetXMPaymentApplyById(ID);
                    if (payRequest != null && !payRequest.FinancialStatus.Value)
                    {
                        isAudit = true;
                        errMessage = errMessage + payRequest.PurchaseRef + ";";
                    }
                    if (payRequest != null && payRequest.FinancialStatus.Value && payRequest.FinancialConfirm.Value)
                    {
                        isAudit = true;
                    }
                }
            }
            if (isAudit)
            {
                base.ShowMessage("采购单号为" + errMessage + "财务未审核或财务已确认，无法公司反审核！");
                return;
            }
            if (grdPayRequestIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdPayRequestIDs)
                {
                    var payRequest = base.XMPaymentApplyService.GetXMPaymentApplyById(ID);
                    if (payRequest != null)
                    {
                        if (payRequest.FinancialStatus.Value)
                        {
                            payRequest.IsAudit = false;
                            payRequest.IsAuditDate = DateTime.Now;
                            payRequest.IsAuditPerson = HozestERPContext.Current.User.CustomerID;
                            payRequest.UpdateDate = DateTime.Now;
                            payRequest.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMPaymentApplyService.UpdateXMPaymentApply(payRequest);
                        }
                    }
                }
            }
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("操作成功!");
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvPayRequest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as HozestERP.BusinessLogic.ManageFinance.XMPaymentApply;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                ImageButton imgBtnPrint = e.Row.FindControl("imagebtnPrint") as ImageButton;
                HyperLink hlPurchaseInfo = e.Row.FindControl("hlPurchaseInfo") as HyperLink;
                if (hlPurchaseInfo != null)
                {
                    hlPurchaseInfo.Attributes.Add("onclick", "return ShowWindowDetail('查看采购订单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/PurchaseAdd.aspx?Type=2"
       + "&&Id=" + info.PurchaseID
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});"); 
                }
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('付款申请单修改','" + CommonHelper.GetStoreLocation() +
            "ManageFinance/XMPaymentRequest.aspx?PaymentRequestID=" + info.Id

        + "',900,500, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if(imgBtnPrint!=null)
                {
                    imgBtnPrint.OnClientClick= "return ShowWindowDetail('付款申请单打印','" + CommonHelper.GetStoreLocation() +
            "ManageFinance/PrintPaymentApply.aspx?PaymentRequestID=" + info.Id

        + "',900,500, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }

            }
        }


        protected void gvPayRequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    var info = base.XMPaymentApplyService.GetXMPaymentApplyById(int.Parse(id));
                    if (info.IsAudit.Value || info.FinancialStatus.Value)                //公司审核和财务审核其中有一项审核通过 既无法删除
                    {
                        base.ShowMessage("公司审核或财务审核已通过，不能删除！");
                    }
                    else
                    {
                        info.IsEnable = true;
                        info.UpdateDate = DateTime.Now;
                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMPaymentApplyService.UpdateXMPaymentApply(info);
                    }
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                }
            }

            #endregion
        }


        /// <summary>
        /// 财务审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinanceIsAudit_Click(object sender, EventArgs e)
        {
            List<int> grdPayRequestIDs = this.Master.GetSelectedIds(this.gvPayRequest);
            if (grdPayRequestIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdPayRequestIDs)
                {
                    var payRequest = base.XMPaymentApplyService.GetXMPaymentApplyById(ID);
                    if (payRequest != null)
                    {
                        payRequest.IsAudit = true;
                        payRequest.IsAuditDate= DateTime.Now;
                        payRequest.IsAuditPerson= HozestERPContext.Current.User.CustomerID;
                        payRequest.FinancialStatus = true;
                        payRequest.FinancialStatusDate = DateTime.Now;
                        payRequest.FinancialStatusPerson = HozestERPContext.Current.User.CustomerID;
                        payRequest.UpdateDate = DateTime.Now;
                        payRequest.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMPaymentApplyService.UpdateXMPaymentApply(payRequest);
                    }
                }
            }
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("操作成功!");
        }

        /// <summary>
        /// 财务反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinanceIsAuditNO_Click(object sender, EventArgs e)
        {
            bool isAudit = false;
            string errMessage = "";
            List<int> grdPayRequestIDs = this.Master.GetSelectedIds(this.gvPayRequest);
            if (grdPayRequestIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdPayRequestIDs)
                {
                    var payRequest = base.XMPaymentApplyService.GetXMPaymentApplyById(ID);
                    if (payRequest != null && payRequest.IsAudit.Value)
                    {
                        isAudit = true;
                        errMessage = errMessage + payRequest.PurchaseRef + ";";
                    }
                }
            }
            if (isAudit)
            {
                base.ShowMessage("采购单号为：" + errMessage + "的付款申请单公司已审核通过，无法财务反审核！");
                return;
            }

            if (grdPayRequestIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdPayRequestIDs)
                {
                    var payRequest = base.XMPaymentApplyService.GetXMPaymentApplyById(ID);
                    if (payRequest != null)
                    {
                        payRequest.FinancialStatus = false;
                        payRequest.FinancialStatusDate = DateTime.Now;
                        payRequest.FinancialStatusPerson = HozestERPContext.Current.User.CustomerID;
                        payRequest.UpdateID = HozestERPContext.Current.User.CustomerID;
                        payRequest.UpdateDate = DateTime.Now;
                        base.XMPaymentApplyService.UpdateXMPaymentApply(payRequest);
                    }
                }
            }
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("操作成功!");
        }

        /// <summary>
        /// 财务确认(财务已经审核通过  已确认付款)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void hidBtnFinanceOkF_Click(object sender, EventArgs e)
        {
            bool isAduit = false;
            string errMessage = "";
            List<int> grdPayRequestIDs = this.Master.GetSelectedIds(this.gvPayRequest);
            if (grdPayRequestIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdPayRequestIDs)
                {
                    var payRequest = base.XMPaymentApplyService.GetXMPaymentApplyById(ID);
                    if (payRequest != null && !payRequest.IsAudit.Value)
                    {
                        isAduit = true;
                        errMessage = errMessage + payRequest.PurchaseRef + ";";
                    }
                }
            }
            if (isAduit)
            {
                base.ShowMessage("采购单号为：" + errMessage + "的付款申请单未通过公司审核，无法财务确认！");
                return;
            }
            if (grdPayRequestIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in grdPayRequestIDs)
                {
                    var payRequest = base.XMPaymentApplyService.GetXMPaymentApplyById(ID);
                    if (payRequest != null)
                    {
                        if (payRequest.IsAudit.Value)
                        {
                            payRequest.FinancialConfirm = true;
                            payRequest.ConfirmDate = DateTime.Now;
                            payRequest.ConfirmPerson = HozestERPContext.Current.User.CustomerID;
                            payRequest.UpdateDate = DateTime.Now;
                            payRequest.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMPaymentApplyService.UpdateXMPaymentApply(payRequest);
                        }
                    }
                }
            }
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("操作成功!");
        }

        /// <summary>
        /// 查询
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

        public string getDepartment(string requestsID)
        {
            string departmentName = "";
            if (requestsID != null && requestsID != "")
            {
                var customerInfo = base.CustomerInfoService.GetCustomerInfoByID(int.Parse(requestsID));
                if (customerInfo != null)
                {
                    departmentName = customerInfo.DepartmentName;
                }
            }
            return departmentName;
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