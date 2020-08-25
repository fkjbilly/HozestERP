using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Customers;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageInventory
{
    public partial class PurchaseList : BaseAdministrationPage, ISearchPage
    {
        public XLMInterface xLMInterface = new BusinessLogic.ManageProject.XLMInterface();
        private static int PayID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //初始化审核按钮
                this.btnPurchaseAdd.OnClientClick = "return ShowWindowDetail('新增采购单','" + CommonHelper.GetStoreLocation() +
"ManageInventory/PurchaseAdd.aspx?Type=0"
+ "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                BindGrid(1, Master.PageSize);


                //京东自营采购单导入
                this.btnJDSelfPurchaseSupportExport.OnClientClick = "return ShowWindowDetail('京东自营采购单导入','" + CommonHelper.GetStoreLocation() +
            "ManageInventory/ImportJDSelfPurchaseSupport.aspx',500,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                this.btnImportLogisticsFee.OnClientClick = "return ShowWindowDetail('导入物流费用数据','" + CommonHelper.GetStoreLocation() +
"ManageProject/ImportPurchaseLogisticsFee.aspx',750,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //获取用户角色
            string customerids = GetInCludeCustomerByRole();  //customerIds
            string purChaseCode = txtPurChaseCode.Text.Trim();                  //采购单号
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            int supplierId = ddlSupplierList.SelectedValue == "" ? -1 : Convert.ToInt16(ddlSupplierList.SelectedValue);                   //供应商ID
            int status = Convert.ToInt16(ddlVerify.SelectedValue);         // 采购单状态
            int storageStatus = int.Parse(ddlStorageStatus.SelectedValue);    //入库状态
            string EmitFactory = this.ddlEmitFactory.SelectedValue;
            int BuildOrder = int.Parse(this.ddlBuildOrder.SelectedValue);

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

            var list = base.XMPurchaseService.GetXMPurchaseByParm(purChaseCode, Begin, End, supplierId, status, storageStatus, customerids, EmitFactory, BuildOrder);
            var pageList = new PagedList<XMPurchase>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvPurChase, pageList);
        }

        /// <summary>
        /// 获取入库状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string getStorageStauts(string status)
        {
            string name = "";
            switch (status)
            {
                case "0":
                    name = "待入库";
                    break;
                case "1":
                    name = "部分入库";
                    break;
                case "2":
                    name = "全部入库";
                    break;
            }
            return name;
        }

        /// <summary>
        /// 获取部门审核状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool getIsAudit(int id)
        {
            bool isAudit = false;
            var Info = base.XMPurchaseService.GetXMPurchaseById(id);
            if (Info != null && Info.IsAudit != null)
            {
                isAudit = (bool)Info.IsAudit;
            }
            return isAudit;
        }

        /// <summary>
        /// 获取审核状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool getFinancialStatus(int id)
        {
            bool Status = true;
            //var Info = base.XMPurchaseService.GetXMPurchaseById(id);
            //if (Info != null)
            //{
            //    //var paymentRequest = base.XMPaymentApplyService.GetXMPaymentApplyByPurchaseID(Info.Id);
            //    var paymentRequestList = XMPaymentApplyService.GetXMPaymentApplyListByPurchaseID(Info.Id);
            //    decimal amount = paymentRequestList.Sum(a => a.PayAmounts);
            //    if(amount>=0)
            //    {
            //        foreach(var item in paymentRequestList)
            //        {
            //            bool isIsAudit = item.IsAudit.Value;
            //            bool FinancialStatus = item.FinancialStatus.Value;
            //            Status = isIsAudit && FinancialStatus;
            //        }
            //    }
            //    //if (paymentRequest != null)
            //    //{
            //    //    bool isIsAudit = paymentRequest.IsAudit.Value;
            //    //    bool FinancialStatus = paymentRequest.FinancialStatus.Value;
            //    //    Status = isIsAudit && FinancialStatus;
            //    //}
            //}
            return Status;
        }
        /// <summary>
        /// 获取应付账款中相应审核状态对应的金额
        /// </summary>
        /// <param name="PurchaseID">采购单号</param>
        /// <param name="isAudit">审核状态</param>
        /// <returns></returns>
        public string getAuditProductsMoney(string PurchaseID, bool isAudit)
        {
            var XMPaymentApplys = base.XMPaymentApplyService.GetXMPaymentApplysByPurchaseID(int.Parse(PurchaseID));
            if (isAudit)
            {
                var AuditMoney = XMPaymentApplys.Where(m => m.IsAudit == true).Sum(m => m.PayAmounts);
                return AuditMoney.ToString("0.##");
            }
            else
            {
                var notAuditMoney = XMPaymentApplys.Where(m => m.IsAudit == false).Sum(m => m.PayAmounts);
                return notAuditMoney.ToString("0.##");
            }
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

        protected void grdvPurChase_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMPurchase;
                Label lblDealAddress = e.Row.FindControl("lblDealAddress") as Label;
                Label lblPurchaseStatus = e.Row.FindControl("lblPurchaseStatus") as Label;        //采购订单状态

                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                ImageButton imgRejected = e.Row.FindControl("imgRejected") as ImageButton;               //生成入库单
                ImageButton imgReturned = e.Row.FindControl("imgReturned") as ImageButton;               //生成退货单
                ImageButton imgPay= e.Row.FindControl("imgPay") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑采购订单','" + CommonHelper.GetStoreLocation() +
        "ManageInventory/PurchaseAdd.aspx?Type=1"
          + "&&Id=" + info.Id
        + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('查看采购订单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/PurchaseAdd.aspx?Type=2"
       + "&&Id=" + info.Id
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgRejected != null)
                {
                    imgRejected.OnClientClick = "return ShowWindowDetail('新建采购入库单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/StorageAdd.aspx?Type=0"
       + "&&PurchaseID=" + info.Id
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgReturned != null)
                {
                    imgReturned.OnClientClick = "return ShowWindowDetail('新建退货单','" + CommonHelper.GetStoreLocation() +
   "ManageInventory/RejectedAdd.aspx?Type=0"
     + "&&PurchaseID=" + info.Id
   + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                var purchase = base.XMPurchaseService.GetXMPurchaseById(info.Id);
                if (purchase != null && purchase.IsAudit != null)
                {
                    //var payment = base.XMPaymentApplyService.GetXMPaymentApplyByPurchaseID(purchase.Id);
                    var paymentList = XMPaymentApplyService.GetXMPaymentApplyListByPurchaseID(purchase.Id);//判断是否有付款数据
                    if (paymentList.Count>0)
                    {
                        if (purchase.IsAudit.Value)
                        {
                            if (purchase.BillStatus == 2)              //已全部入库 
                            {
                                imgReturned.Visible = false;
                                imgRejected.Visible = false;
                                imgProductDetails.Visible = true;
                                imgBtnDelete.Visible = false;
                                imgBtnEdit.Visible = false;
                                imgPay.Visible = false;
                            }
                            else
                            {
                                bool Status = true;
                                //decimal amount = paymentList.Sum(a => a.PayAmounts);
                                //if (amount >=0)
                                //{
                                //    foreach (var item in paymentList)
                                //    {
                                //        bool isIsAudit = item.IsAudit.Value;
                                //        bool FinancialStatus = item.FinancialStatus.Value;
                                //        Status = isIsAudit && FinancialStatus;
                                //    }
                                //}
                                if (Status)
                                {
                                    imgReturned.Visible = true;
                                    imgRejected.Visible = true;
                                }
                                else
                                {
                                    imgReturned.Visible = false;
                                    imgRejected.Visible = false;
                                }
                                imgProductDetails.Visible = true;
                                imgBtnDelete.Visible = false;
                                imgBtnEdit.Visible = false;
                            }
                        }
                        else {
                            imgPay.Visible = false;
                            imgBtnEdit.Visible = true;
                            imgBtnDelete.Visible = true;
                            imgRejected.Visible = false;
                            imgReturned.Visible = false;
                            imgProductDetails.Visible = true;
                        }
                    }
                    else
                    {

                        if (purchase.IsAudit.Value)
                        {
                            imgBtnDelete.Visible = false;
                            imgPay.Visible = true;
                            imgRejected.Visible = true;
                        }
                        else
                        {
                            imgPay.Visible = false;
                            imgBtnDelete.Visible = true;
                            imgRejected.Visible = false;
                        }
                        imgReturned.Visible = false;

                        imgProductDetails.Visible = true;
                        //imgProductDetails.Visible = false;
                    }
                }
                string dealAddress = info.DealAddress;
                if (!string.IsNullOrEmpty(dealAddress) && dealAddress.Length > 12)
                {
                    dealAddress = dealAddress.Substring(0, 12) + "....";
                }
                lblDealAddress.Text = dealAddress;
                lblDealAddress.ToolTip = info.DealAddress;
                //判断更新采购单状态
                int purchaseId = info.Id;
                UpdatePurcahaseStatus(purchaseId, info.BillStatus);
            }
        }

        /// <summary>
        /// 获取当前采购订单状态
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        private void UpdatePurcahaseStatus(int purchaseId, int purchaseStatus)
        {
            //采购单
            int status = 0;
            int purchaseCount = 0;   //采购总数
            int storageCount = 0;     //入库总数
            int rejectCount = 0;      //采购退货总数
            var purchaseInfo = base.XMPurchaseService.GetXMPurchaseById(purchaseId);
            if (purchaseInfo != null)
            {
                var purchaseProductDetail = base.XMPurchaseProductDetailsService.GetXMPurchaseProductDetailsByPurchaseID(purchaseInfo.Id);
                if (purchaseProductDetail != null && purchaseProductDetail.Count > 0)
                {
                    foreach (XMPurchaseProductDetails purchaseDetails in purchaseProductDetail)
                    {
                        purchaseCount = purchaseCount + purchaseDetails.ProductCount;
                        //根据采购单查询所有的入库单(状态为1000  已经入库)
                        var storageInfo = base.XMStorageService.GetXMStorageListByPurcahaseIDAndStorageStatus(purchaseInfo.Id, 1000);
                        if (storageInfo != null && storageInfo.Count > 0)
                        {
                            foreach (XMStorage storages in storageInfo)
                            {
                                var storageProductDetail = base.XMStorageProductDetailsService.GetXMStorageProductDetailsByStorageID(storages.Id);
                                if (storageProductDetail != null && storageProductDetail.Count > 0)
                                {
                                    foreach (XMStorageProductDetails detail in storageProductDetail)
                                    {
                                        if (detail.PlatformMerchantCode == purchaseDetails.PlatformMerchantCode)
                                        {
                                            storageCount = storageCount + detail.ProductsCount;
                                        }
                                    }
                                }
                            }
                        }
                        var rejectedInfo = base.XMPurchaseRejectedService.GetXMPurchaseRejectedListByPurchaseID(purchaseInfo.Id);
                        if (rejectedInfo != null && rejectedInfo.Count > 0)
                        {
                            foreach (XMPurchaseRejected rejected in rejectedInfo)
                            {
                                var rejectedDetail = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(rejected.Id);
                                if (rejectedDetail != null && rejectedDetail.Count > 0)
                                {
                                    foreach (XMPurchaseRejectedProductDetails details in rejectedDetail)
                                    {
                                        if (details.PlatformMerchantCode == purchaseDetails.PlatformMerchantCode)
                                        {
                                            rejectCount = rejectCount + details.RejectionCount;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //未有产品入库（状态为待入库）
                if (storageCount == 0)
                {
                    status = 0;    //状态为待入库
                }
                if ((storageCount + rejectCount) > 0 && (storageCount + rejectCount) < purchaseCount)    //入库数量+退货数量 
                {
                    status = 1;  //状态为部分入库
                }
                if ((storageCount + rejectCount) == purchaseCount)
                {
                    status = 2;  //状态为全部入库
                }
                if (purchaseStatus != status)
                {
                    purchaseInfo.BillStatus = status;
                    purchaseInfo.UpdateDate = DateTime.Now;
                    purchaseInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMPurchaseService.UpdateXMPurchase(purchaseInfo);
                }
            }
        }

        protected void grdvPurChase_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    //删除采购主表信息和采购产品明细表
                    var purcahaseInfo = base.XMPurchaseService.GetXMPurchaseById(Convert.ToInt16(id));
                    if (purcahaseInfo != null)
                    {
                        var paymentRequest = base.XMPaymentApplyService.GetXMPaymentApplyByPurchaseID(Convert.ToInt16(id));
                        if (paymentRequest != null)
                        {
                            if (paymentRequest.FinancialStatus.Value || paymentRequest.IsAudit.Value || paymentRequest.FinancialConfirm.Value)
                            {
                                base.ShowMessage("应付账款已经审核通过，无法删除采购单！");
                                return;
                            }
                        }
                        //删除主表
                        purcahaseInfo.IsEnable = true;
                        purcahaseInfo.UpdateDate = DateTime.Now;
                        purcahaseInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMPurchaseService.UpdateXMPurchase(purcahaseInfo);
                        //删除产品明细表
                        var details = base.XMPurchaseProductDetailsService.GetXMPurchaseProductDetailsByPurchaseID(purcahaseInfo.Id);
                        if (details != null && details.Count > 0)
                        {
                            foreach (XMPurchaseProductDetails parm in details)
                            {
                                parm.IsEnable = true;
                                parm.UpdateDate = DateTime.Now;
                                parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMPurchaseProductDetailsService.UpdateXMPurchaseProductDetails(parm);
                            }
                        }

                        //删除财务应付账款记录(如付款账款已经审核将无法删除采购单)
                        if (paymentRequest != null)
                        {
                            paymentRequest.IsEnable = true;
                            paymentRequest.UpdateDate = DateTime.Now;
                            paymentRequest.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMPaymentApplyService.UpdateXMPaymentApply(paymentRequest);
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
            else if(e.CommandName.Equals("Pay"))
            {
                PayID = int.Parse(e.CommandArgument.ToString());
            }
            #endregion
        }

        /// <summary>
        /// 部门审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAudit_Click(object sender, EventArgs e)
        {
            List<int> purchaseIDs = this.Master.GetSelectedIds(this.grdvPurChase);
            if (purchaseIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in purchaseIDs)
                {
                    //更新采购单状态
                    var purchases = base.XMPurchaseService.GetXMPurchaseById(Convert.ToInt32(ID));
                    if (purchases != null && purchases.IsAudit == false)
                    {
                        purchases.IsAudit = true;
                        purchases.UpdateDate = DateTime.Now;
                        purchases.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        base.XMPurchaseService.UpdateXMPurchase(purchases);
                        //新增请款单数据
                        //var payment = base.XMPaymentApplyService.GetXMPaymentApplyByPurchaseID(purchases.Id);
                        //if (payment == null)
                        //{
                        //    InsertPaymentRequstData(purchases);
                        //}
                    }
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功!");
            }
        }

        /// <summary>
        /// 新增请款单数据
        /// </summary>
        /// <param name="id"></param>
        private void InsertPaymentRequstData(XMPurchase purchases)
        {
            XMPaymentApply paymentApply = new XMPaymentApply();
            paymentApply.PurchaseID = purchases.Id;
            paymentApply.PayAmounts = purchases.ProductsMoney.Value;
            paymentApply.PayMode = purchases.PaymentType.Value;
            paymentApply.SupplierID = purchases.SupplierId;
            paymentApply.RequstDate = DateTime.Now;
            paymentApply.UserDate = purchases.PurchaseDate;
            paymentApply.ApplicantID = HozestERPContext.Current.User.CustomerID;
            paymentApply.UpdateDate = DateTime.Now;
            paymentApply.UpdateID = HozestERPContext.Current.User.CustomerID;
            paymentApply.IsAudit = false;
            paymentApply.FinancialStatus = false;
            paymentApply.FinancialConfirm = false;
            paymentApply.IsEnable = false;
            base.XMPaymentApplyService.InsertXMPaymentApply(paymentApply);
        }

        protected void imgPay_Click(object sender, EventArgs e)
        {
            FormPanel1.Reset();
            window1.Show();
        }

        protected void btnSave_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            var purchases = base.XMPurchaseService.GetXMPurchaseById(PayID);

            var XMPaymentApplyList = XMPaymentApplyService.GetXMPaymentApplyListByPurchaseID(PayID);

            decimal amount = XMPaymentApplyList.Sum(a => a.PayAmounts);

            decimal payamount = decimal.Parse(txtAmount.Text);
            if(amount+ payamount> purchases.ProductsMoney)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "金额超出范围！").Show();
            }
            else
            {
                XMPaymentApply paymentApply = new XMPaymentApply();
                paymentApply.PurchaseID = purchases.Id;
                paymentApply.PayAmounts = decimal.Parse(txtAmount.Text);
                paymentApply.PayMode = purchases.PaymentType.Value;
                paymentApply.SupplierID = purchases.SupplierId;
                paymentApply.RequstDate = DateTime.Now;
                paymentApply.UserDate = purchases.PurchaseDate;
                paymentApply.ApplicantID = HozestERPContext.Current.User.CustomerID;
                paymentApply.UpdateDate = DateTime.Now;
                paymentApply.UpdateID = HozestERPContext.Current.User.CustomerID;
                paymentApply.IsAudit = false;
                paymentApply.FinancialStatus = false;
                paymentApply.FinancialConfirm = false;
                paymentApply.IsEnable = false;
                paymentApply.RequestFundsReason = txtReason.Text;
                base.XMPaymentApplyService.InsertXMPaymentApply(paymentApply);

                window1.Hide();
                Ext.Net.ExtNet.Msg.Alert("提示", "操作成功！").Show();
            }
        }

        /// <summary>
        /// 部门反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAuditFalse_Click(object sender, EventArgs e)
        {
            string errMessage = string.Empty;
            bool isAudit = false;
            List<int> purchaseIDs = this.Master.GetSelectedIds(this.grdvPurChase);
            if (purchaseIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in purchaseIDs)
                {
                    var purchases = base.XMPurchaseService.GetXMPurchaseById(Convert.ToInt32(ID));
                    if (purchases != null)
                    {
                        purchases.IsAudit = false;
                        purchases.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        purchases.UpdateDate = DateTime.Now;
                        base.XMPurchaseService.UpdateXMPurchase(purchases);
                    }
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功!");
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

        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {
            //绑定供应商列表
            var suppliers = base.XMSuppliersService.GetXMSuppliersList();
            if (suppliers.Count() > 0)
            {
                ddlSupplierList.Items.Clear();
                ddlSupplierList.DataSource = suppliers;
                ddlSupplierList.DataTextField = "SupplierName";
                ddlSupplierList.DataValueField = "Id";
                ddlSupplierList.DataBind();
                this.ddlSupplierList.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddlSupplierList.Items[0].Selected = true;
            }

            //绑定发出工厂
            var PurchaseList = base.XMPurchaseService.GetXMPurchaseList();
            List<string> EmitFactory = PurchaseList.Select(x => x.EmitFactory).Distinct().ToList();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var value in EmitFactory)
            {
                if (value != null)
                {
                    dic.Add(value, value);
                }
            }

            ddlEmitFactory.Items.Clear();
            ddlEmitFactory.DataSource = dic;
            ddlEmitFactory.DataTextField = "Key";
            ddlEmitFactory.DataValueField = "Value";
            ddlEmitFactory.DataBind();
            this.ddlEmitFactory.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        #endregion

        /// <summary>
        /// 生成喜临门订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuildOrder_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvPurChase);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                var PurchaseList = base.XMPurchaseService.GetXMPurchaseByIDs(IDs);
                foreach (var Info in PurchaseList)
                {
                    if (Info.IsAudit != true && Info.FinancialStatus != true)
                    {
                        base.ShowMessage("采购订单:" + Info.PurchaseNumber + "，必须经过部门审核，财务审核！");
                        return;
                    }
                    if (Info.IsBuildOrder == true)
                    {
                        base.ShowMessage("采购订单:" + Info.PurchaseNumber + "，已生成千胜订单！");
                        return;
                    }
                    if (string.IsNullOrEmpty(Info.DealAddress) || Info.DealAddress.Length < 10)
                    {
                        base.ShowMessage("采购订单:" + Info.PurchaseNumber + "，交货地址未填写或太简略，不能生成千胜订单！");
                        return;
                    }
                    if (string.IsNullOrEmpty(Info.ReceiverMobile))
                    {
                        base.ShowMessage("采购订单:" + Info.PurchaseNumber + "，收件人手机未填写！");
                        return;
                    }
                    if (string.IsNullOrEmpty(Info.Receiver))
                    {
                        base.ShowMessage("采购订单:" + Info.PurchaseNumber + "，收件人姓名未填写！");
                        return;
                    }
                    if (string.IsNullOrEmpty(Info.BuyMember))
                    {
                        base.ShowMessage("采购订单:" + Info.PurchaseNumber + "，买家会员名未填写！");
                        return;
                    }
                }

                string msg = "";
                string method = "qs.order.put";

                foreach (var Info in PurchaseList)
                {
                    StringBuilder body = new StringBuilder();
                    body = GetOrderPutJson(body, Info, ref msg);
                    string WarehouseName = "";
                    WarehouseName = Info.EmitFactory;
                    //if (Info.EmitFactory.IndexOf("棉花仓") != -1)
                    //{
                    //    WarehouseName = "南方仓库";//南方仓库
                    //}
                    //else if (Info.EmitFactory.IndexOf("总部仓") != -1)
                    //{
                    //    WarehouseName = "南方仓库";//南方仓库
                    //}
                    //else if (Info.EmitFactory.IndexOf("EBD香河成品仓库") != -1)
                    //{
                    //    WarehouseName = "北方仓库";//北方仓库
                    //}
                    //else if (Info.EmitFactory.IndexOf("EBD成都成品仓库") != -1)
                    //{
                    //    WarehouseName = "成都仓库";//成都仓库
                    //}
                    //else if (Info.EmitFactory.IndexOf("EBD佛山成品仓库") != -1)
                    //{
                    //    WarehouseName = "TP佛山成品仓库";//TP佛山成品仓库
                    //}
                    foreach (var paramdetail in Info.XM_PurchaseProductDetails.Where(p=>p.IsEnable==false).ToList()) 
                    {
                        var XLMInventory = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(WarehouseName, paramdetail.PlatformMerchantCode);
                        if (XLMInventory.Count == 1)
                        {
                            int inventorycount = int.Parse(XLMInventory[0].Inventory.ToString());
                            int Purchase = paramdetail.ProductCount;
                            if (Purchase > inventorycount) 
                            {
                                base.ShowMessage("厂家编码" + paramdetail.PlatformMerchantCode + "库存不足，提交中断");
                                return;
                            }
                        }
                        else 
                        {
                            base.ShowMessage("厂家编码" + paramdetail.PlatformMerchantCode + "喜临门当日库存没有该商品，提交中断");
                            return;
                        }
                    }
                    if (body == null)
                    {
                        //msg += "发货单号：" + Info.DeliveryNumber + "，转换Json格式错误！";
                        continue;
                    }

                    string url = xLMInterface.GetUrl(method, body.ToString());
                    string josnStr = xLMInterface.GetResponseData(body.ToString(), url);//GetInfo(url);
                    if (josnStr == "error")
                    {
                        msg += "网络连接错误，请稍后再试！";
                        break;
                    }

                    Dictionary<string, object> data = xLMInterface.JsonToDictionary(josnStr);
                    if (data.ContainsKey("flag"))
                    {
                        msg += "采购订单：" + Info.PurchaseNumber + "，" + data["message"] + "！<br/>";
                    }
                    else
                    {
                        if (data["success"].ToString() != "True")
                        {
                            msg += "采购订单：" + Info.PurchaseNumber + "，" + data["message"] + "！<br/>";
                        }
                        else
                        {
                            Info.IsBuildOrder = true;
                            Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.XMPurchaseService.UpdateXMPurchase(Info);
                            foreach (var paramdetail in Info.XM_PurchaseProductDetails)
                            {
                                var XLMInventory = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(WarehouseName, paramdetail.PlatformMerchantCode);
                                if (XLMInventory.Count == 1)
                                {
                                    int inventorycount = int.Parse(XLMInventory[0].Inventory.ToString());//库存数量
                                    int Purchase = paramdetail.ProductCount;//采购数量
                                    XLMInventory[0].Inventory = inventorycount - Purchase;//剩余库存
                                    base.XMXLMInventoryService.UpdateXMXLMInventory(XLMInventory[0]);//修改库存
                                }
                            }
                        }
                    }
                }

                if (msg != "")
                {
                    base.ShowMessage(msg);
                }
                else
                {
                    base.ShowMessage("喜临门订单创建成功！");

                    this.BindGrid(1, Master.PageSize);
                }
            }
        }

        public StringBuilder GetOrderPutJson(StringBuilder body, XMPurchase purchase, ref string msg)
        {
            try
            {
                int a = 0;
                string Zip = "000000";
                string remark = "";
                string shopName = "城市爱情";
                string WantID = purchase.BuyMember == null ? "" : purchase.BuyMember;
                string Province = "";
                string City = "";
                string County = "";
                string Address = "";

                if (!string.IsNullOrEmpty(purchase.DealAddress) && purchase.DealAddress.Length >= 8)
                {
                    string ybs = purchase.DealAddress.Substring(purchase.DealAddress.Length - 8).Replace("(", "").Replace(")", "").Replace("（", "").Replace("）", "");

                    if (ybs.Length == 6 && int.TryParse(ybs, out  a))
                    {
                        Zip = ybs;
                    }
                }

                body.Append("{").Append("\"platOrderHeader\":{").Append("");
                body.Append("\"shopName\":").Append("\"" + shopName + "\",");
                body.Append("\"status\":").Append("\"WAIT_SELLER_SEND_GOODS\",");

                #region 修改卖家备注

                remark = purchase.SellerRemarks == null ? "" : purchase.SellerRemarks;

                if (remark.IndexOf("//赠品") != -1)
                {
                    remark = remark.Substring(0, remark.IndexOf("//赠品"));
                }
                if (remark.IndexOf("//更改尺寸为") > -1)
                {
                    remark = remark.Substring(0, remark.IndexOf("//更改尺寸为"));
                }
                else if (remark.IndexOf("//更改床垫地址") > -1)
                {
                    remark = remark.Substring(0, remark.IndexOf("//更改床垫地址"));
                }

                //var exist = purchase.XM_Delivery_Details.Where(x => x.PrdouctName.Contains("乳胶枕") || x.PrdouctName.Contains("喜米") || x.PrdouctName.Contains("U型枕")).ToList();
                //if (exist != null && exist.Count > 0)
                //{
                //    remark = "圆通速递/能发就发/小城///送货上门";
                //}

                #endregion

                body.Append("\"sellerMemo\":").Append("\"" + remark + "\",");
                body.Append("\"modified\":").Append("\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",");
                body.Append("\"buyerNick\":").Append("\"" + WantID + "\",");
                body.Append("\"created\":").Append("\"" + ((DateTime)purchase.Date_Created).ToString("yyyy-MM-dd HH:mm:ss") + "\",");
                body.Append("\"num\":").Append(purchase.XM_PurchaseProductDetails.Sum(x => x.ProductCount) + ",");
                body.Append("\"tid\":").Append("\"" + purchase.PurchaseNumber + "\",");
                body.Append("\"payment\":").Append((purchase.ProductsMoney == null ? 0 : purchase.ProductsMoney) + ",");
                body.Append("\"payTime\":").Append("\"" + ((DateTime)purchase.PurchaseDate).ToString("yyyy-MM-dd HH:mm:ss") + "\",");
                body.Append("\"totalFee\":").Append((purchase.ProductsMoney == null ? 0 : purchase.ProductsMoney) + ",");
                body.Append("\"postFee\":").Append("0,");
                body.Append("\"receiverName\":").Append("\"" + purchase.Receiver + "\",");

                #region 省市区处理

                Address = purchase.DealAddress.Replace("\r", "").Replace("\n", "");
                if (Address.StartsWith("上海") || Address.StartsWith("北京")
                    || Address.StartsWith("天津") || Address.StartsWith("重庆"))
                {
                    Province = Address.Substring(0, 2);
                    City = Province + "市";
                    Address = Address.Substring(2, Address.Length - 2);
                    if (Address.StartsWith("市"))
                    {
                        Address = Address.Substring(1, Address.Length - 1);
                    }

                    if (Address.Contains("区"))
                    {
                        int CountyIndex = Address.IndexOf("区");
                        County = Address.Substring(0, CountyIndex + 1);
                    }
                    else if (Address.Contains("县"))
                    {
                        int CountyIndex = Address.IndexOf("县");
                        County = Address.Substring(0, CountyIndex + 1);
                    }
                    Address = Address.Substring(County.Length, Address.Length - County.Length);
                }
                else
                {
                    if (Address.Contains("省") || Address.Contains("自治区"))
                    {
                        if (Address.Contains("省"))
                        {
                            int ProvinceIndex = Address.IndexOf("省");
                            Province = Address.Substring(0, ProvinceIndex + 1);
                            Address = Address.Substring(Province.Length, Address.Length - Province.Length);
                        }
                        else if (Address.Contains("自治区"))
                        {
                            int ProvinceIndex = Address.IndexOf("自治区");
                            Province = Address.Substring(0, ProvinceIndex + 3);
                            Address = Address.Substring(Province.Length, Address.Length - Province.Length);
                        }
                    }
                    if (Address.Contains("市"))
                    {
                        int CityIndex = Address.IndexOf("市");
                        City = Address.Substring(0, CityIndex + 1);
                        Address = Address.Substring(City.Length, Address.Length - City.Length);
                    }
                    if (Address.Contains("区") || Address.Contains("县"))
                    {
                        if (Address.Contains("区"))
                        {
                            int CountyIndex = Address.IndexOf("区");
                            County = Address.Substring(0, CountyIndex + 1);
                        }
                        else if (Address.Contains("县"))
                        {
                            int CountyIndex = Address.IndexOf("县");
                            County = Address.Substring(0, CountyIndex + 1);
                        }
                        Address = Address.Substring(County.Length, Address.Length - County.Length);
                    }
                }

                #endregion

                body.Append("\"receiverState\":").Append("\"" + Province + "\",");
                body.Append("\"receiverCity\":").Append("\"" + City + "\",");
                body.Append("\"receiverDistrict\":").Append("\"" + County + "\",");

                #region 详细地址

                if (!Address.Contains(County))
                {
                    Address = County + Address;
                }

                #endregion

                body.Append("\"receiverAddress\":").Append("\"" + Address + "\",");

                body.Append("\"receiverZip\":").Append("\"" + Zip + "\",");
                body.Append("\"receiverMobile\":").Append("\"" + purchase.ReceiverMobile + "\",");
                body.Append("\"receiverPhone\":").Append("\"" + (purchase.Tel == null ? "" : (purchase.Tel == "" ? "0000-00000000" : purchase.Tel)) + "\",");
                body.Append("\"hasPostFee\":").Append("true},");

                //platOrderDetails
                body.Append("\"platOrderDetails\":[");

                var detailList = purchase.XM_PurchaseProductDetails.Where(p => p.IsEnable == false).ToList();
               
                for (int i = 0; i < detailList.Count; i++)
                {
                     
                    decimal Price = 0;
                    string ManufacturersCode = "";
                    body.Append("{");
                    var detail = detailList[i];

                    //var Product = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(detail.PlatformMerchantCode, (int)detail.PlatformTypeId);
                    var Product = base.XMProductDetailsService.GetXMProductDetailsByProductIdAndPlatFormId((int)detail.ProductId, (int)detail.PlatformTypeId);
                    //if (Product != null && Product.Count > 0)
                    //{
                    //    var product = IoC.Resolve<IXMProductService>().GetXMProductById((int)Product[0].ProductId);
                    //    if (product != null)
                    //    {
                    //        Price = Product[0].Saleprice == null ? 0 : (decimal)Product[0].Saleprice;
                    //        ManufacturersCode = Product[0].ManufacturersCode;
                    //    }
                    //}
                    //if (ManufacturersCode == "")
                    //{
                    //    msg += "商品编码：" + detail.PlatformMerchantCode + "，不存在！<br/>";
                    //    return null;
                    //}
                    //Price = detail.ProductPrice;//取采购订单的单价

                    if (Product != null)
                    {
                        Price = decimal.Parse(Product.Saleprice.ToString());//取商品的单价
                    }
                    else //对应平台没有找通用
                    {
                        Product = base.XMProductDetailsService.GetXMProductDetailsByProductIdAndPlatFormId((int)detail.ProductId, 508);
                        Price = decimal.Parse(Product.Saleprice.ToString());//取商品的单价
                    }
                    body.Append("\"totalFee\":").Append(Price * detail.ProductCount + ",");
                    body.Append("\"payment\":").Append(Price * detail.ProductCount + ",");
                    body.Append("\"modified\":").Append("\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",");
                    body.Append("\"num\":").Append(detail.ProductCount + ",");
                    body.Append("\"price\":").Append(Price + ",");
                    body.Append("\"outerSkuId\":").Append("\"" + detail.PlatformMerchantCode + "\",");//数据库字段名声定义不准确，名称含义是商品编码，实际内容是厂家编码
                    body.Append("\"taxRate\":").Append("\"0.06\"}");
                    if (i != detailList.Count - 1)
                    {
                        body.Append(",");
                    }
                }
                body.Append("],");

                //platOrderPayTypes
                body.Append("\"platOrderPayTypes\":[{");
                body.Append("\"amount\":").Append((purchase.ProductsMoney == null ? 0 : purchase.ProductsMoney) + ",");
                body.Append("\"payType\":").Append("\"001\"}]}");

                return body;
            }
            catch
            {
                return null;
            }
        }
    }
}