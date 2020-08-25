using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.Common.Utils;
using HozestERP.Web.Modules;

namespace HozestERP.Web.ManageProject
{
    public partial class CashbackPremiums : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPremiums();
                BindGrid(false);
                BindGrid(true);
            }
        }

        public XMOrderInfo GetOrderInfo()
        {
            var QuestionDetail = base.XMQuestionDetailService.GetById(Id);
            var Question = base.XMQuestionService.GetById(QuestionDetail.QuestionID);
            if (Question != null)
            {
                var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(Question.OrderNO);
                if (OrderInfo != null)
                {
                    return OrderInfo;
                }
            }
            return null;
        }

        public void LoadPremiums()
        {
            var OrderInfo = GetOrderInfo();
            var Premiums = base.XMPremiumsService.GetXMPremiumsListByQuestionDetailID(Id.ToString());
            if (Premiums != null)
            {
                this.TxtOrderCode.Text = Premiums.OrderCode;
                this.TxtWangNo.Text = Premiums.WantId;
                this.DdApplicationType.SelectedValue = Premiums.PremiumsTypeId.ToString();
                this.DdlPaymentPerson.SelectedValue = Premiums.PaymentPerson.ToString();
                this.LblCashBackStatus.Checked = Premiums.PremiumsStatus == Convert.ToInt32(StatusEnum.PremiumsIssued) ? true : false;
                this.LblManagerStatus.Checked = Premiums.ManagerStatus == Convert.ToInt32(StatusEnum.AlreadyCheck) ? true : false;
                this.Ispj.Checked = Premiums.IsEvaluation == null ? false : (bool)Premiums.IsEvaluation;
                this.Issh.Checked = Premiums.IsSingleRow == null ? false : (bool)Premiums.IsSingleRow;
            }
            else if (OrderInfo != null)
            {
                this.TxtOrderCode.Text = OrderInfo.OrderCode;
                this.TxtWangNo.Text = OrderInfo.WantID;
                this.LblCashBackStatus.Checked = false;
                this.LblManagerStatus.Checked = false;
                this.Ispj.Checked = false;
                this.Issh.Checked = false;
            }
        }

        public void BindGrid(bool IsCashBack, int CashBackIndex = -1, int PremiumsDetailsIndex = -1)
        {
            XMCashBackApplication CashBack = new XMCashBackApplication();
            XMPremiumsDetails PremiumsDetails = new XMPremiumsDetails();
            List<XMPremiumsDetails> PremiumsDetailsList = new List<XMPremiumsDetails>();
            var XMOrderInfo = GetOrderInfo();

            if (IsCashBack)
            {
                //返现
                List<XMCashBackApplication> CashBackList = base.XMCashBackApplicationService.GetXMCashBackApplicationListByQuestionDetailID(Id.ToString());
                if (XMOrderInfo != null)
                {
                    CashBack.OrderCode = XMOrderInfo.OrderCode;
                    CashBack.WantNo = XMOrderInfo.WantID;
                    CashBack.BuyerName = XMOrderInfo.FullName;
                }
                if (CashBackIndex == -1)
                {
                    CashBackList.Add(CashBack);
                    this.gvCashback.EditIndex = CashBackList.Count - 1;
                }
                else
                {
                    this.gvCashback.EditIndex = CashBackIndex;
                }
                this.gvCashback.DataSource = CashBackList;
                this.gvCashback.DataBind();//绑定数据源
            }
            else
            {
                //赠品
                var Premiums = base.XMPremiumsService.GetXMPremiumsListByQuestionDetailID(Id.ToString());
                if (Premiums != null)
                {
                    var premiumsDetailsList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(Premiums.Id);
                    PremiumsDetailsList.AddRange(premiumsDetailsList);
                    if (PremiumsDetailsIndex == -1)
                    {
                        PremiumsDetailsList.Add(PremiumsDetails);
                        this.gvPremiums.EditIndex = PremiumsDetailsList.Count - 1;
                    }
                    else
                    {
                        this.gvPremiums.EditIndex = PremiumsDetailsIndex;
                    }
                }
                else
                {
                    this.gvPremiums.EditIndex = 0;
                }

                this.gvPremiums.DataSource = PremiumsDetailsList;
                this.gvPremiums.DataBind();//绑定数据源
            }
        }

        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        public void Face_Init()
        {
            DdlPaymentPerson.Items.Clear();
            var PaymentPersonList = base.CodeService.GetCodeListInfoByCodeTypeID(222);
            DdlPaymentPerson.DataSource = PaymentPersonList;
            DdlPaymentPerson.DataTextField = "CodeName";
            DdlPaymentPerson.DataValueField = "CodeID";
            DdlPaymentPerson.DataBind();
            DdlPaymentPerson.Items.Insert(0, new ListItem("", "-1"));
        }

        public void SetTrigger()
        {
        }

        protected void gvCashback_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var item = (XMCashBackApplication)e.Row.DataItem;
            if (e.Row.RowState == DataControlRowState.Edit ||
                e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                TextBox txtBuyerName = e.Row.FindControl("txtBuyerName") as TextBox;
                DropDownList ddlApplicationType = e.Row.FindControl("ddlApplicationType") as DropDownList;
                TextBox txtBuyerAlipayNo = e.Row.FindControl("txtBuyerAlipayNo") as TextBox;
                TextBox txtCashBackMoney = e.Row.FindControl("txtCashBackMoney") as TextBox;
                CheckBox ChkCashBackStatus = e.Row.FindControl("ChkCashBackStatus") as CheckBox;
                CheckBox ChkManagerStatus = e.Row.FindControl("ChkManagerStatus") as CheckBox;
                DropDownList ddlPaymentPerson = e.Row.FindControl("ddlPaymentPerson") as DropDownList;

                ddlPaymentPerson.Items.Clear();
                var PaymentPersonList = base.CodeService.GetCodeListInfoByCodeTypeID(222);
                ddlPaymentPerson.DataSource = PaymentPersonList;
                ddlPaymentPerson.DataTextField = "CodeName";
                ddlPaymentPerson.DataValueField = "CodeID";
                ddlPaymentPerson.DataBind();
                ddlPaymentPerson.Items.Insert(0, new ListItem("", "-1"));

                txtBuyerName.Text = item.BuyerName;
                ddlApplicationType.SelectedValue = item.ApplicationTypeId.ToString();
                txtBuyerAlipayNo.Text = item.BuyerAlipayNo;
                txtCashBackMoney.Text = item.CashBackMoney.ToString();
                if (item.Id != 0)
                {
                    ChkCashBackStatus.Checked = item.CashBackStatus == null ? false : (item.CashBackStatus == 0 ? false : true);
                    ChkManagerStatus.Checked = item.ManagerStatus == Convert.ToInt32(StatusEnum.NotCheck) ? false : true;
                }
                ddlPaymentPerson.SelectedValue = item.PaymentPerson.ToString();
            }
        }

        protected void gvCashback_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView a = (GridView)sender;
            var hdId = (HiddenField)(a.Rows[e.NewEditIndex].FindControl("hdId"));//当前行Id
            var XMCashBack = base.XMCashBackApplicationService.GetXMCashBackApplicationById(int.Parse(hdId.Value));
            if (XMCashBack.ManagerStatus == Convert.ToInt32(StatusEnum.AlreadyCheck))
            {
                base.ShowMessage("财务已审核的数据，不可编辑！");
                e.Cancel = true;
                return;
            }
            BindGrid(true, e.NewEditIndex);
        }

        protected void gvCashback_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridView a = (GridView)sender;
                var hdId = (HiddenField)(a.Rows[e.RowIndex].FindControl("hdId"));//当前行Id
                var XMCashBack = base.XMCashBackApplicationService.GetXMCashBackApplicationById(int.Parse(hdId.Value));
                if (XMCashBack.ManagerStatus == Convert.ToInt32(StatusEnum.AlreadyCheck))
                {
                    base.ShowMessage("财务已审核的数据，不可删除！");
                    return;
                }
                XMCashBack.IsEnable = true;
                XMCashBack.UpdatorID = HozestERPContext.Current.User.CustomerID;
                XMCashBack.UpdateTime = DateTime.Now;
                base.XMCashBackApplicationService.UpdateXMCashBackApplication(XMCashBack);
                base.ShowMessage("删除成功！");
                BindGrid(true);
            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        }

        protected void gvCashback_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ToCancel"))
            {
                try
                {
                    BindGrid(true);
                }
                catch (Exception err)
                {
                    base.ProcessException(err);
                }
            }
        }

        protected void gvCashback_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                #region  取控件值
                decimal d = 0;
                GridView a = (GridView)sender;
                TextBox txtBuyerName = a.Rows[e.RowIndex].FindControl("txtBuyerName") as TextBox;
                DropDownList ddlApplicationType = a.Rows[e.RowIndex].FindControl("ddlApplicationType") as DropDownList;
                TextBox txtBuyerAlipayNo = a.Rows[e.RowIndex].FindControl("txtBuyerAlipayNo") as TextBox;
                TextBox txtCashBackMoney = a.Rows[e.RowIndex].FindControl("txtCashBackMoney") as TextBox;
                //CheckBox ChkCashBackStatus = a.Rows[e.RowIndex].FindControl("ChkCashBackStatus") as CheckBox;
                //CheckBox ChkManagerStatus = a.Rows[e.RowIndex].FindControl("ChkManagerStatus") as CheckBox;
                DropDownList ddlPaymentPerson = a.Rows[e.RowIndex].FindControl("ddlPaymentPerson") as DropDownList;
                #endregion

                if (txtBuyerName.Text == "" || txtBuyerAlipayNo.Text == "")
                {
                    base.ShowMessage("数据不能为空！");
                    return;
                }
                if (ddlPaymentPerson.SelectedValue == "-1")
                {
                    base.ShowMessage("请选择赔付方！");
                    return;
                }
                if (!decimal.TryParse(txtCashBackMoney.Text, out d))
                {
                    base.ShowMessage("金额数据类型不正确！");
                    return;
                }

                var XMOrderInfo = GetOrderInfo();
                int ID = int.Parse(a.DataKeys[e.RowIndex].Value.ToString());
                if (ID == 0)
                {
                    XMCashBackApplication XMCashBack = new XMCashBackApplication();
                    XMCashBack.OrderCode = XMOrderInfo.OrderCode;//订单号
                    XMCashBack.WantNo = XMOrderInfo.WantID;//旺旺号
                    XMCashBack.BuyerName = txtBuyerName.Text.Trim();//姓名
                    XMCashBack.ApplicationTypeId = int.Parse(ddlApplicationType.SelectedValue);//申请类型
                    XMCashBack.BuyerAlipayNo = txtBuyerAlipayNo.Text.Trim();//收款账号
                    XMCashBack.CashBackMoney = decimal.Parse(txtCashBackMoney.Text.Trim() == "" ? "0" : txtCashBackMoney.Text.Trim());//金额
                    XMCashBack.PaymentPerson = int.Parse(ddlPaymentPerson.SelectedValue);
                    XMCashBack.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                    XMCashBack.CashBackStatus = Convert.ToInt32(StatusEnum.NotCashBack);
                    XMCashBack.QuestionDetailID = Id.ToString();
                    XMCashBack.IsEnable = false;
                    XMCashBack.CreatorID = HozestERPContext.Current.User.CustomerID;
                    XMCashBack.CreateTime = DateTime.Now;
                    XMCashBack.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    XMCashBack.UpdateTime = DateTime.Now;
                    base.XMCashBackApplicationService.InsertXMCashBackApplication(XMCashBack);
                }
                else
                {
                    XMCashBackApplication XMCashBack = base.XMCashBackApplicationService.GetXMCashBackApplicationById(ID);
                    XMCashBack.BuyerName = txtBuyerName.Text.Trim();//姓名
                    XMCashBack.ApplicationTypeId = int.Parse(ddlApplicationType.SelectedValue);//申请类型
                    XMCashBack.BuyerAlipayNo = txtBuyerAlipayNo.Text.Trim();//收款账号
                    XMCashBack.CashBackMoney = decimal.Parse(txtCashBackMoney.Text.Trim() == "" ? "0" : txtCashBackMoney.Text.Trim());//金额
                    XMCashBack.PaymentPerson = int.Parse(ddlPaymentPerson.SelectedValue);
                    XMCashBack.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    XMCashBack.UpdateTime = DateTime.Now;
                    base.XMCashBackApplicationService.UpdateXMCashBackApplication(XMCashBack);
                }
                base.ShowMessage("保存成功！");
                scope.Complete();
            }
            BindGrid(true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string OrderCode = this.TxtOrderCode.Text.Trim();
            string WangNo = this.TxtWangNo.Text.Trim();
            string ApplicationType = this.DdApplicationType.SelectedValue;
            string PaymentPerson = this.DdlPaymentPerson.SelectedValue;

            if (PaymentPerson == "-1")
            {
                base.ShowMessage("请先选择赔付方！");
                return;
            }
            var Premiums = base.XMPremiumsService.GetXMPremiumsListByQuestionDetailID(Id.ToString());
            if (Premiums != null)
            {
                if (Premiums.ManagerStatus == Convert.ToInt32(StatusEnum.AlreadyCheck))
                {
                    base.ShowMessage("财务已审核的数据，不可编辑！");
                    return;
                }
                Premiums.OrderCode = OrderCode;//订单号
                Premiums.WantId = WangNo;//旺旺号
                Premiums.PremiumsTypeId = int.Parse(ApplicationType);//申请类型
                Premiums.PaymentPerson = int.Parse(PaymentPerson);
                Premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                Premiums.UpdateTime = DateTime.Now;
                base.XMPremiumsService.UpdateXMPremiums(Premiums);
            }
            else
            {
                XMPremiums XMPremium = new XMPremiums();
                XMPremium.QuestionDetailID = Id.ToString();
                XMPremium.OrderCode = OrderCode;//订单号
                XMPremium.WantId = WangNo;//旺旺号
                XMPremium.PaymentPerson = int.Parse(PaymentPerson);
                XMPremium.PremiumsTypeId = int.Parse(ApplicationType);//申请类型
                XMPremium.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                XMPremium.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsNoHair);
                XMPremium.IsEnable = false;
                XMPremium.IsEvaluation = false;
                XMPremium.IsSingleRow = false;
                XMPremium.FinanceIsAudit = false;
                XMPremium.CreatorID = HozestERPContext.Current.User.CustomerID;
                XMPremium.CreateTime = DateTime.Now;
                XMPremium.UpdatorID = HozestERPContext.Current.User.CustomerID;
                XMPremium.UpdateTime = DateTime.Now;
                base.XMPremiumsService.InsertXMPremiums(XMPremium);
            }
            base.ShowMessage("保存成功！");
            BindGrid(false);
        }

        protected void gvPremiums_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var item = (XMPremiumsDetails)e.Row.DataItem;
            if (e.Row.RowState == DataControlRowState.Edit ||
                e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                TextBox txtPrdouctName = e.Row.FindControl("txtPrdouctName") as TextBox;
                TextBox txtPlatformMerchantCode = e.Row.FindControl("txtPlatformMerchantCode") as TextBox;
                TextBox txtSpecifications = e.Row.FindControl("txtSpecifications") as TextBox;
                TextBox txtProductNum = e.Row.FindControl("txtProductNum") as TextBox;
                TextBox txtFactoryPrice = e.Row.FindControl("txtFactoryPrice") as TextBox;
                DropDownList ddlShipper = (DropDownList)e.Row.FindControl("ddlShipper");
                //找到DropDownList 控件，然后进行绑定或者追加内容
                var ShipperList = base.CodeService.GetCodeListInfoByCodeTypeID(226);
                ddlShipper.DataSource = ShipperList;
                ddlShipper.DataTextField = "CodeName";
                ddlShipper.DataValueField = "CodeID";
                ddlShipper.DataBind();

                txtPrdouctName.Text = item.PrdouctName;
                txtPlatformMerchantCode.Text = item.PlatformMerchantCode;
                txtSpecifications.Text = item.Specifications;
                txtProductNum.Text = item.ProductNum.ToString();
                txtFactoryPrice.Text = item.FactoryPrice.ToString();
                ddlShipper.SelectedValue = item.Shipper.ToString();
            }
        }

        protected void gvPremiums_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var Premiums = base.XMPremiumsService.GetXMPremiumsListByQuestionDetailID(Id.ToString());
            if (Premiums != null)
            {
                if (Premiums.ManagerStatus == Convert.ToInt32(StatusEnum.AlreadyCheck))
                {
                    base.ShowMessage("财务已审核的数据，不可编辑！");
                    e.Cancel = true;
                    return;
                }
            }
            BindGrid(false, -1, e.NewEditIndex);
        }

        protected void gvPremiums_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridView a = (GridView)sender;
                var hdIdp = (HiddenField)(a.Rows[e.RowIndex].FindControl("hdIdp"));//当前行Id
                var Premiums = base.XMPremiumsService.GetXMPremiumsListByQuestionDetailID(Id.ToString());
                var PremiumsDetails = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(int.Parse(hdIdp.Value));
                if (Premiums != null)
                {
                    if (Premiums.ManagerStatus == Convert.ToInt32(StatusEnum.AlreadyCheck))
                    {
                        base.ShowMessage("财务已审核的数据，不可删除！");
                        e.Cancel = true;
                        return;
                    }
                }
                PremiumsDetails.IsEnable = true;
                PremiumsDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                PremiumsDetails.UpdateDate = DateTime.Now;
                base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(PremiumsDetails);
                base.ShowMessage("删除成功！");
                BindGrid(false);
            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        }

        protected void gvPremiums_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ToCancel"))
            {
                try
                {
                    BindGrid(false);
                }
                catch (Exception err)
                {
                    base.ProcessException(err);
                }
            }
        }

        protected void gvPremiums_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                #region  取控件值
                int n = 0;
                decimal d = 0;
                GridView a = (GridView)sender;
                TextBox txtPrdouctName = a.Rows[e.RowIndex].FindControl("txtPrdouctName") as TextBox;
                TextBox txtPlatformMerchantCode = a.Rows[e.RowIndex].FindControl("txtPlatformMerchantCode") as TextBox;
                TextBox txtSpecifications = a.Rows[e.RowIndex].FindControl("txtSpecifications") as TextBox;
                TextBox txtProductNum = a.Rows[e.RowIndex].FindControl("txtProductNum") as TextBox;
                TextBox txtFactoryPrice = a.Rows[e.RowIndex].FindControl("txtFactoryPrice") as TextBox;
                DropDownList ddlShipper = a.Rows[e.RowIndex].FindControl("ddlShipper") as DropDownList;
                #endregion

                if (txtPrdouctName.Text == "" || txtPlatformMerchantCode.Text == "" || txtFactoryPrice.Text == "" || txtProductNum.Text == "")
                {
                    base.ShowMessage("数据不能为空！");
                    return;
                }
                if (!int.TryParse(txtProductNum.Text, out n))
                {
                    base.ShowMessage("数量数据类型不正确！");
                    return;
                }
                if (!decimal.TryParse(txtFactoryPrice.Text, out d))
                {
                    base.ShowMessage("出厂价数据类型不正确！");
                    return;
                }

                int ID = int.Parse(a.DataKeys[e.RowIndex].Value.ToString());
                var Premiums = base.XMPremiumsService.GetXMPremiumsListByQuestionDetailID(Id.ToString());
                string DetailId = this.hidDetailId.Value.Trim();
                if (Premiums != null)
                {
                    if (ID == 0)
                    {
                        XMPremiumsDetails orderproduct = new XMPremiumsDetails();
                        orderproduct.ProductDetaislId = int.Parse(DetailId);
                        orderproduct.PremiumsId = Premiums.Id;
                        orderproduct.PlatformMerchantCode = txtPlatformMerchantCode.Text.Trim();
                        orderproduct.PrdouctName = txtPrdouctName.Text.Trim();
                        orderproduct.ProductNum = int.Parse(txtProductNum.Text.Trim());
                        orderproduct.FactoryPrice = decimal.Parse(txtFactoryPrice.Text.Trim());
                        orderproduct.Shipper = int.Parse(ddlShipper.SelectedValue.Trim());
                        orderproduct.IsEnable = false;
                        orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                        orderproduct.CreateDate = DateTime.Now;
                        orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                        orderproduct.UpdateDate = DateTime.Now;
                        base.XMPremiumsDetailsService.InsertXMPremiumsDetails(orderproduct);
                    }
                    else
                    {
                        XMPremiumsDetails orderproduct = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(ID);
                        if (!string.IsNullOrEmpty(DetailId))
                        {
                            orderproduct.ProductDetaislId = int.Parse(DetailId);
                        }
                        orderproduct.PlatformMerchantCode = txtPlatformMerchantCode.Text.Trim();
                        orderproduct.PrdouctName = txtPrdouctName.Text.Trim();
                        orderproduct.ProductNum = int.Parse(txtProductNum.Text.Trim());
                        orderproduct.FactoryPrice = decimal.Parse(txtFactoryPrice.Text.Trim());
                        orderproduct.Shipper = int.Parse(ddlShipper.SelectedValue.Trim());
                        orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                        orderproduct.UpdateDate = DateTime.Now;
                        base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(orderproduct);
                    }
                    base.ShowMessage("保存成功！");
                }
                scope.Complete();
            }
            BindGrid(false);
        }
    }
}