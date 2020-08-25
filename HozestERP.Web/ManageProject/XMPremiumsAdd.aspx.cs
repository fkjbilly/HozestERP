using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMPremiumsAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["RecordOrderCode"] = null;
                Session["PremiumsDetailList"] = null;
                LoadDate();
                BindGrid();
                ddApplicationTypeId_SelectedIndexChanged(sender, e);
                ddlProject_SelectedIndexChanged(sender, e);

                //单个排单
                this.btnSingleRow2.OnClientClick = "return CkeckShowWindowDetail(SavePremiunsInfoIDs(),'选择出库仓库','" + CommonHelper.GetStoreLocation() +
            "ManageProject/XMPremiumsSaleDelivery.aspx?Type=1" + "&&PremiumsId=" + this.Id + "&&TabPanelPremiumsType=" + TabPanelPremiumsType + "',300,170, this, function(){document.getElementById('" + null + "').click();});";
            }
        }

        private void LoadDate()
        {
            if (Id != 0)
            {
                this.ddlApplicationTypeId.Enabled = false;
                this.chkNoOrderPremiums.Enabled = false;

                var XMPremiums = base.XMPremiumsService.GetXMPremiumsById(Id);
                if (XMPremiums != null)
                {
                    Session["RecordOrderCode"] = XMPremiums.OrderCode;

                    this.txtScalpingCode.Value = XMPremiums.OrderCode;//订单号
                    this.wangwang.Value = XMPremiums.WantId;//旺旺号
                    this.wangwangdd.Value = XMPremiums.WantId;//旺旺号
                    this.ddlApplicationTypeId.SelectedValue = XMPremiums.PremiumsTypeId.Value.ToString();//申请类型
                    this.txtNote.Text = XMPremiums.Note;
                    if (XMPremiums.OrderCode.IndexOf("NoOrder") != -1)
                    {
                        this.chkNoOrderPremiums.Checked = false;
                        this.chkNoOrderPremiums.Enabled = false;
                        this.txtScalpingCode.Disabled = true;
                        this.ddlProject.SelectedValue = XMPremiums.NoOrderProjectId.ToString();
                        this.ddlNick.SelectedValue = XMPremiums.NoOrderNickId == null ? "-1" : XMPremiums.NoOrderNickId.ToString();
                    }
                    else
                    {
                        this.lblNickName.Visible = false;
                        this.lblProjectName.Visible = false;
                        this.ddlNick.Visible = false;
                        this.ddlProject.Visible = false;
                    }

                    if (XMPremiums.PaymentPerson != null)
                    {
                        this.ddlPaymentPerson.SelectedValue = XMPremiums.PaymentPerson.ToString();
                    }
                    if (XMPremiums.PremiumsTypeId != Convert.ToInt32(StatusEnum.ChildPayment))
                    {
                        this.ddlPaymentPerson.Enabled = false;
                    }
                    if (XMPremiums.PremiumsStatus == Convert.ToInt32(StatusEnum.PremiumsIssued))
                    {
                        this.lblCashBackStatus.Checked = true;
                    }
                    if (XMPremiums.ManagerStatus == Convert.ToInt32(StatusEnum.AlreadyCheck))
                    {
                        this.lblManagerStatus.Checked = true;
                        this.btnSave.Visible = false;
                        if (XMPremiums.PremiumsStatus == Convert.ToInt32(StatusEnum.PremiumsNoHair))           //已审核未排单
                        {
                            this.btnSingleRow2.Visible = true;
                        }
                        else if (XMPremiums.PremiumsStatus == Convert.ToInt32(StatusEnum.PremiumsIssued))
                        {
                            this.btnSingleRow2.Visible = false;
                        }
                    }
                    else if (XMPremiums.ManagerStatus == Convert.ToInt32(StatusEnum.NotCheck))
                    {
                        this.btnSingleRow2.Visible = false;
                    }
                    if (XMPremiums.IsEvaluation == true)//是否评价
                    {
                        this.ispj.Checked = true;
                    }
                    if (XMPremiums.IsSingleRow == true)//是否排单
                    {
                        this.issh.Checked = true;
                    }
                }

                var ClaimInfo = base.XMClaimInfoService.GetXMClaimInfoByPremiumsId(Id);
                if (ClaimInfo != null)
                {
                    var ClaimInfoDetail = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(ClaimInfo.Id);
                    if (ClaimInfoDetail != null && ClaimInfoDetail.Count > 0)
                    {
                        this.txtClaimReason.Text = ClaimInfoDetail[0].Reason;
                    }
                }
            }
            else
            {
                this.ddlPaymentPerson.Enabled = false;
                this.chkNoOrderPremiums.Enabled = true;
                this.lblNickName.Visible = false;
                this.lblProjectName.Visible = false;
                this.ddlNick.Visible = false;
                this.ddlProject.Visible = false;
                btnSingleRow2.Visible = false;
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.ddlPaymentPerson.Items.Clear();
            var PaymentPersonList = base.CodeService.GetCodeListInfoByCodeTypeID(222);
            this.ddlPaymentPerson.DataSource = PaymentPersonList;
            this.ddlPaymentPerson.DataTextField = "CodeName";
            this.ddlPaymentPerson.DataValueField = "CodeID";
            this.ddlPaymentPerson.DataBind();
            this.ddlPaymentPerson.Items.Insert(0, new ListItem("", "-1"));

            //项目名称绑定
            this.ddlProject.Items.Clear();
            var projectList = base.XMProjectService.GetXMProjectList();
            this.ddlProject.DataSource = projectList;
            this.ddlProject.DataTextField = "ProjectName";
            this.ddlProject.DataValueField = "Id";
            this.ddlProject.DataBind();
            this.ddlProject.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        public void SetTrigger()
        {
        }

        #endregion

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                List<XMPremiumsDetails> list = new List<XMPremiumsDetails>();
                if (Session["PremiumsDetailList"] != null)
                {
                    list = (List<XMPremiumsDetails>)Session["PremiumsDetailList"];
                }

                #region 删除
                if (e.CommandName.Equals("ToDelete"))
                {
                    if (Id != 0)
                    {
                        var xMOrderInfo = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(Convert.ToInt32(e.CommandArgument));
                        if (xMOrderInfo != null)//删除
                        {
                            xMOrderInfo.IsEnable = true;
                            xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            xMOrderInfo.UpdateDate = DateTime.Now;
                            base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(xMOrderInfo);
                            this.BindGrid();
                            base.ShowMessage("操作成功！");
                        }
                    }
                    else
                    {
                        list.RemoveAt(Convert.ToInt32(e.CommandArgument));
                        for (int i = 1; i <= list.Count; i++)
                        {
                            list[i].Id = i;
                        }
                        Session["PremiumsDetailList"] = list;
                    }
                    this.BindGrid();
                }

                #endregion

                //修改
                if (e.CommandName.Equals("ToAdd"))
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    //编辑行
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("txtProductCode");
                    HtmlInputText lblProductName = (HtmlInputText)gvr.FindControl("lblProductName");
                    TextBox txtProductNum = (TextBox)gvr.FindControl("txtProductNum");
                    TextBox lblFactoryPrice = (TextBox)gvr.FindControl("lblFactoryPrice");
                    DropDownList ddlShipper = (DropDownList)gvr.FindControl("ddlShipper");
                    HiddenField hidProductId = (HiddenField)gvr.FindControl("hidProductId");

                    if (txtProductCode.Value == "")
                    {
                        base.ShowMessage("商品编码不能为空！");
                        return;
                    }

                    XMPremiumsDetails one = new XMPremiumsDetails();
                    if (!string.IsNullOrEmpty(hidProductId.Value))
                    {
                        one.ProductDetaislId = int.Parse(hidProductId.Value);
                    }
                    one.PlatformMerchantCode = txtProductCode.Value;
                    one.PrdouctName = lblProductName.Value;
                    one.ProductNum = int.Parse(txtProductNum.Text.Trim());
                    one.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                    one.Shipper = int.Parse(ddlShipper.SelectedValue.Trim());
                    one.IsEnable = false;
                    one.CreateID = HozestERPContext.Current.User.CustomerID;
                    one.CreateDate = DateTime.Now;
                    one.UpdateID = HozestERPContext.Current.User.CustomerID;
                    one.UpdateDate = DateTime.Now;
                    one.IsSingleRow = false;

                    if (Id != 0)
                    {
                        if (ID == 0)
                        {
                            one.PremiumsId = Id;
                            base.XMPremiumsDetailsService.InsertXMPremiumsDetails(one);
                        }
                        else
                        {
                            //订单详细信息
                            var detail = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(ID);
                            if (detail != null)
                            {
                                detail.ProductDetaislId = one.ProductDetaislId;
                                detail.PlatformMerchantCode = one.PlatformMerchantCode;
                                detail.PrdouctName = one.PrdouctName;
                                detail.ProductNum = one.ProductNum;
                                detail.FactoryPrice = one.FactoryPrice;
                                detail.Shipper = one.Shipper;
                                detail.UpdateID = one.UpdateID;
                                detail.UpdateDate = one.UpdateDate;
                                base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(one);
                            }
                        }
                    }
                    else
                    {
                        if (ID == 0)
                        {
                            one.Id = list.Count + 1;
                            list.Add(one);
                        }
                        else
                        {
                            one.Id = ID;
                            list[ID - 1] = one;
                        }
                        Session["PremiumsDetailList"] = list;
                    }
                    //base.ShowMessage("添加成功！");
                    this.BindGrid();
                }
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }
        }

        public string GetSpecifications(string PlatformMerchantCode)
        {
            string Specifications = string.Empty;
            if (!string.IsNullOrEmpty(PlatformMerchantCode))
            {
                //var product = base.XMProductService.getXMProductListByManufacturersCode(PlatformMerchantCode);
                var ProductDetail = base.XMProductService.GetXMProductListByPlatformMerchantCode(PlatformMerchantCode, -1);
                if (ProductDetail != null && ProductDetail.Count > 0)
                {
                    var Product = base.XMProductService.GetXMProductById((int)ProductDetail[0].ProductId);
                    if (Product != null)
                    {
                        Specifications = Product.Specifications;
                    }
                }
            }
            return Specifications;
        }

        protected void ddApplicationTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlApplicationTypeId.SelectedValue == Convert.ToInt32(StatusEnum.ChildPayment).ToString())
            {
                this.lblResponsiblePerson.Visible = true;
                this.txtResponsiblePerson.Visible = true;
                this.lblClaimReason.Visible = true;
                this.txtClaimReason.Visible = true;
                ddlPaymentPerson.Enabled = true;

                var CustomerInfo = base.CustomerInfoService.GetCustomerInfoByID(HozestERPContext.Current.User.CustomerID);
                if (CustomerInfo != null)
                {
                    this.txtResponsiblePerson.Text = CustomerInfo.FullName;
                }
            }
            else
            {
                this.lblResponsiblePerson.Visible = false;
                this.txtResponsiblePerson.Visible = false;
                this.lblClaimReason.Visible = false;
                this.txtClaimReason.Visible = false;
                ddlPaymentPerson.Enabled = false;
                ddlPaymentPerson.SelectedValue = "-1";
            }

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "autoCompleteBindScalpingCode", "autoCompleteBindScalpingCode()", true);//ajax
        }

        public void BindGrid()
        {
            List<XMPremiumsDetails> list = new List<XMPremiumsDetails>();
            if (Id != 0)
            {
                list = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(Id);
            }
            else
            {
                if (Session["PremiumsDetailList"] != null)
                {
                    list = ((List<XMPremiumsDetails>)Session["PremiumsDetailList"]).ToList();
                }
            }

            //新增编码行
            this.grdvClients.EditIndex = list.Count();
            list.Add(new XMPremiumsDetails());
            this.grdvClients.DataSource = list;
            this.grdvClients.DataBind();
        }

        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var premiumsDetails = e.Row.DataItem as XMPremiumsDetails;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlShipper = (DropDownList)e.Row.FindControl("ddlShipper");
                //找到DropDownList 控件，然后进行绑定或者追加内容
                var ShipperList = base.CodeService.GetCodeListInfoByCodeTypeID(226);
                ddlShipper.DataSource = ShipperList;
                ddlShipper.DataTextField = "CodeName";
                ddlShipper.DataValueField = "CodeID";
                ddlShipper.DataBind();
                ddlShipper.SelectedValue = premiumsDetails.Shipper == null ? "" : premiumsDetails.Shipper.ToString();//发货方

                if (premiumsDetails.ProductDetaislId != null)
                {
                    var product = base.XMProductService.GetXMProductById(premiumsDetails.ProductDetaislId.Value);
                    if (product != null)
                    {
                        //尺寸
                        //TextBox txtSpecifications = e.Row.FindControl("txtSpecifications") as TextBox;
                        HtmlInputText lblSpecifications = (HtmlInputText)e.Row.FindControl("lblSpecifications");
                        //Label lblSpecifications = e.Row.FindControl("lblSpecifications") as Label;
                        if (lblSpecifications != null)
                        {
                            lblSpecifications.Value = product.Specifications;
                        }
                    }

                    #region 保存按钮
                    var XMPremiums = base.XMPremiumsService.GetXMPremiumsById(Id);
                    ImageButton imgBtnUpdate = e.Row.FindControl("imgBtnUpdate") as ImageButton;
                    ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                    if (XMPremiums != null)
                    {
                        if (XMPremiums.ManagerStatus == Convert.ToInt32(StatusEnum.AlreadyCheck))
                        {
                            imgBtnUpdate.Visible = false;
                            imgBtnDelete.Visible = false;
                        }
                    }
                    #endregion
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string OrderCode = this.txtScalpingCode.Value.Trim();//订单号
            string wangwang = this.wangwangdd.Value.Trim();//旺旺号
            string ApplicationTypeId = this.ddlApplicationTypeId.SelectedValue;//申请类型
            string PaymentPerson = this.ddlPaymentPerson.SelectedValue;//赔付方
            bool chk = this.chkNoOrderPremiums.Checked;//是否为无订单赠品，false:是无订单赠品
            string note = txtNote.Text.Trim();//备注
            int NickId = int.Parse(this.ddlNick.SelectedValue);

            ToSave(OrderCode, wangwang, ApplicationTypeId, PaymentPerson, chk, Id, note, NickId);
        }

        public void ToSave(string OrderCode, string wangwang, string ApplicationTypeId, string PaymentPerson, bool chk, int ID, string note, int NickId)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    string msg = "";
                    if (chk)
                    {
                        if (string.IsNullOrEmpty(OrderCode))
                        {
                            msg = "订单号不能为空！";
                            base.ShowMessage(msg);
                            return;
                        }
                        else
                        {
                            var OrderInfo = XMOrderInfoService.GetXMOrderByOrderCode(OrderCode);
                            if (OrderInfo == null)
                            {
                                msg = "该订单号的订单不存在！";
                                base.ShowMessage(msg);
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (NickId == -1)
                        {
                            msg = "无订单号赠品，赔付单必须选择店铺！";
                            base.ShowMessage(msg);
                            return;
                        }
                    }

                    if (ApplicationTypeId == Convert.ToInt32(StatusEnum.ChildPayment).ToString() && PaymentPerson == "-1")
                    {
                        msg = "请先选择赔付方！";
                        base.ShowMessage(msg);
                        return;
                    }

                    //财务未审核
                    bool FinanceIsAudit = false;
                    //项目未审核
                    int ManagerStatus = 3;
                    //项目id
                    int projectID = 0;
                    //平台id
                    int platformTypeId = 0;

                    if (ID == 0)
                    {
                        List<XMPremiumsDetails> list = new List<XMPremiumsDetails>();
                        if (Session["PremiumsDetailList"] != null)
                        {
                            list = (List<XMPremiumsDetails>)Session["PremiumsDetailList"];
                        }

                        decimal priceAmount = (decimal)list.Sum(a => a.FactoryPrice*a.ProductNum);

                        XMPremiums XMPremium = new XMPremiums();
                        if (chk)
                        {
                            XMPremium.OrderCode = OrderCode;//订单号
                            XMPremium.WantId = wangwang;//旺旺号
                            var OrderInfo = XMOrderInfoService.GetXMOrderByOrderCode(OrderCode);
                            projectID = OrderInfo.ProjectId;
                            platformTypeId = (int)OrderInfo.PlatformTypeId;
                        }
                        else
                        {
                            XMPremium.OrderCode = "NoOrder" + DateTime.Now.ToString("yyMMddHHmmssfff"); ;
                            XMPremium.WantId = "";
                            XMPremium.NoOrderNickId = NickId;
                            var xmNick = XMNickService.GetXMNickByID(NickId);
                            projectID = (int)xmNick.ProjectId;
                            platformTypeId = (int)xmNick.PlatformTypeId;
                        }

                        var XMDeductionSetUp = XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(projectID, 476, platformTypeId);
                        if(XMDeductionSetUp!=null)
                        {
                            //根据项目限额，平台限额，自动设置审核进度
                            if (priceAmount <= XMDeductionSetUp.Deduction)
                            {
                                FinanceIsAudit = true;
                                //项目审核
                                ManagerStatus = 4;
                            }
                            else if (priceAmount > XMDeductionSetUp.Deduction && priceAmount <= XMDeductionSetUp.Finance)
                            {
                                FinanceIsAudit = true;
                            }
                        }
                        else
                        {
                            //通用
                            var XMDeductionSetUpUsually= XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(projectID, 476, 508);
                            if(XMDeductionSetUpUsually!=null)
                            {
                                //根据项目限额，平台限额，自动设置审核进度
                                if (priceAmount <= XMDeductionSetUpUsually.Deduction)
                                {
                                    FinanceIsAudit = true;
                                    //项目审核
                                    ManagerStatus = 4;
                                }
                                else if (priceAmount > XMDeductionSetUpUsually.Deduction && priceAmount <= XMDeductionSetUpUsually.Finance)
                                {
                                    FinanceIsAudit = true;
                                }
                            }
                        }

                        if (ApplicationTypeId == Convert.ToInt32(StatusEnum.ChildPayment).ToString() && PaymentPerson != "-1")
                        {
                            XMPremium.PaymentPerson = int.Parse(PaymentPerson);//赔付方
                        }
                        else
                        {
                            XMPremium.PaymentPerson = null;
                        }

                        XMPremium.PremiumsTypeId = int.Parse(ApplicationTypeId);//申请类型
                        XMPremium.ManagerStatus = ManagerStatus;
                        XMPremium.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsNoHair);
                        XMPremium.FinanceIsAudit = FinanceIsAudit;
                        XMPremium.IsEnable = false;
                        XMPremium.IsEvaluation = false;
                        XMPremium.IsSingleRow = false;
                        XMPremium.CreatorID = HozestERPContext.Current.User.CustomerID;
                        XMPremium.CreateTime = DateTime.Now;
                        XMPremium.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        XMPremium.UpdateTime = DateTime.Now;
                        XMPremium.Note = note;
                        base.XMPremiumsService.InsertXMPremiums(XMPremium);


                        //更新ActivityExplanation
                        string p = "";
                        foreach (XMPremiumsDetails one in list)
                        {
                            one.PremiumsId = XMPremium.Id;
                            one.IsSingleRow = false;
                            base.XMPremiumsDetailsService.InsertXMPremiumsDetails(one);

                            if (one.Specifications != "")
                            {
                                p += one.PrdouctName + "(" + one.Specifications + ")" + "*" + one.ProductNum + "+";
                            }
                            else
                            {
                                p += one.PrdouctName + "*" + one.ProductNum + "+";
                            }
                        }
                        if (p.Length > 0)
                        {
                            p = p.Substring(0, p.Length - 1);
                        }

                        XMPremium.ActivityExplanation = p;
                        base.XMPremiumsService.UpdateXMPremiums(XMPremium);

                        if (XMPremium.PremiumsTypeId == Convert.ToInt32(StatusEnum.ChildPayment))//赔付
                        {
                            if (!AddClaimInfo(XMPremium, NickId))
                            {
                                msg = "理赔管理中已有该理赔，不能新增修改；若要操作，请先删除！";
                                base.ShowMessage(msg);
                                return;
                            }
                        }

                        if (ApplicationTypeId != Convert.ToInt32(StatusEnum.ChildPayment).ToString())
                        {
                            this.wangwang.Value = wangwang;
                            this.btnSave.Visible = false;
                            this.txtScalpingCode.Value = XMPremium.OrderCode;
                            BindGrid();
                        }

                        msg = "保存成功！";
                        base.ShowMessage(msg);
                        scope.Complete();
                    }
                    else
                    {
                        string p = "";
                        var premiumdetails = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(ID);
                        foreach (var a in premiumdetails)
                        {
                            if (a.Specifications != "")
                            {
                                p += a.PrdouctName + "(" + a.Specifications + ")" + "*" + a.ProductNum + "+";
                            }
                            else
                            {
                                p += a.PrdouctName + "*" + a.ProductNum + "+";
                            }
                        }
                        if (p.Length > 0)
                        {
                            p = p.Substring(0, p.Length - 1);
                        }

                        decimal priceAmount = (decimal)premiumdetails.Sum(a => a.FactoryPrice);

                        var OrderInfo = XMOrderInfoService.GetXMOrderByOrderCode(OrderCode);
                        int paramPlatformTypeId = -1;
                        int paramProjectId = -1;
                        if (OrderInfo != null) 
                        {
                            paramPlatformTypeId = (int)OrderInfo.PlatformTypeId;
                            paramProjectId = OrderInfo.ProjectId;
                        }
                        var XMDeductionSetUp = XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(paramProjectId, 476, paramPlatformTypeId);

                        //根据项目限额，平台限额，自动设置审核进度
                        if(XMDeductionSetUp!=null)
                        {
                            if (priceAmount <= XMDeductionSetUp.Deduction)
                            {
                                FinanceIsAudit = true;
                                //项目审核
                                ManagerStatus = 4;
                            }
                            else if (priceAmount > XMDeductionSetUp.Deduction && priceAmount <= XMDeductionSetUp.Finance)
                            {
                                FinanceIsAudit = true;
                            }
                        }
                        else
                        {
                            //通用
                            var XMDeductionSetUpUsually = XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(projectID, 476, 508);
                            if (XMDeductionSetUpUsually != null)
                            {
                                //根据项目限额，平台限额，自动设置审核进度
                                if (priceAmount <= XMDeductionSetUpUsually.Deduction)
                                {
                                    FinanceIsAudit = true;
                                    //项目审核
                                    ManagerStatus = 4;
                                }
                                else if (priceAmount > XMDeductionSetUpUsually.Deduction && priceAmount <= XMDeductionSetUpUsually.Finance)
                                {
                                    FinanceIsAudit = true;
                                }
                            }
                        }


                        var XMPremium = base.XMPremiumsService.GetXMPremiumsById(ID);
                        XMPremium.OrderCode = OrderCode;//订单号
                        XMPremium.WantId = wangwang;//旺旺号
                        XMPremium.ActivityExplanation = p;

                        if (ApplicationTypeId == Convert.ToInt32(StatusEnum.ChildPayment).ToString() && PaymentPerson != "-1")
                        {
                            XMPremium.PaymentPerson = int.Parse(PaymentPerson);//赔付方
                        }
                        else
                        {
                            XMPremium.PaymentPerson = null;
                        }

                        if (!chk)
                        {
                            XMPremium.NoOrderNickId = NickId;
                        }

                        XMPremium.PremiumsTypeId = int.Parse(ApplicationTypeId);//申请类型
                        XMPremium.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        XMPremium.UpdateTime = DateTime.Now;
                        XMPremium.Note = note;
                        XMPremium.ManagerStatus = ManagerStatus;
                        XMPremium.FinanceIsAudit = FinanceIsAudit;
                        base.XMPremiumsService.UpdateXMPremiums(XMPremium);

                        if (XMPremium.PremiumsTypeId == Convert.ToInt32(StatusEnum.ChildPayment))
                        {
                            if (!AddClaimInfo(XMPremium, NickId))
                            {
                                msg = "理赔管理中已有该理赔，不能新增修改；若要操作，请先删除！";
                                base.ShowMessage(msg);
                                return;
                            }
                        }

                        if (ApplicationTypeId != Convert.ToInt32(StatusEnum.ChildPayment).ToString())
                        {
                            this.wangwang.Value = wangwang;
                        }

                        base.ShowMessage("修改成功！");
                        scope.Complete();
                    }
                }
                catch (Exception err)
                {
                    this.ProcessException(err);
                }
            }
        }

        public bool AddClaimInfo(XMPremiums Info, int NickId)
        {
            var ClaimInfo = base.XMClaimInfoService.GetXMClaimInfoByPremiumsId(Info.Id);
            if (ClaimInfo != null)
            {
                var ClaimInfoDetail = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(ClaimInfo.Id);
                if (ClaimInfoDetail != null && ClaimInfoDetail.Count > 0)
                {
                    var ConfirmCount = ClaimInfoDetail.Where(x => x.IsConfirm == true).ToList();
                    if (ConfirmCount != null && ConfirmCount.Count > 0)
                    {
                        return false;
                    }
                    else
                    {
                        ClaimInfo.IsEnable = true;
                        ClaimInfo.UpdateDate = DateTime.Now;
                        ClaimInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMClaimInfoService.UpdateXMClaimInfo(ClaimInfo);

                        foreach (var a in ClaimInfoDetail)
                        {
                            a.IsEnable = true;
                            a.UpdateDate = DateTime.Now;
                            a.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMClaimInfoDetailService.UpdateXMClaimInfoDetail(a);
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            HozestERP.BusinessLogic.ManageProject.XMClaimInfo ONE = new HozestERP.BusinessLogic.ManageProject.XMClaimInfo();
            HozestERP.BusinessLogic.ManageProject.XMClaimInfoDetail one = new HozestERP.BusinessLogic.ManageProject.XMClaimInfoDetail();

            ONE.OrderCode = Info.OrderCode;
            ONE.PremiumsId = Info.Id;
            ONE.NickId = NickId;

            var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(Info.OrderCode);
            if (OrderInfo != null)
            {
                ONE.FullName = OrderInfo.FullName;
                ONE.Tel = OrderInfo.Mobile;
                ONE.NickId = (int)OrderInfo.NickID;
            }
            else
            {
                ONE.FullName = "";
                //ONE.NickId = -1;
            }

            ONE.IsReturn = false;
            ONE.ReturnRef = "";
            ONE.ClaimRef = AutoClaimRef();
            ONE.IsEnable = false;
            ONE.CreateDate = ONE.UpdateDate = DateTime.Now;
            ONE.CreateID = ONE.UpdateID = HozestERPContext.Current.User.CustomerID;
            base.XMClaimInfoService.InsertXMClaimInfo(ONE);

            one.ClaimInfoID = ONE.Id;
            one.ClaimTypeID = (int)Info.PaymentPerson;

            var PremiumsDetailList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(Info.Id);
            if (PremiumsDetailList != null && PremiumsDetailList.Count > 0)
            {
                one.ClaimAcount = PremiumsDetailList.Sum(x => x.ProductNum * x.FactoryPrice);
            }

            //确认——除厂家，物流理赔外，默认确认
            if (Info.PaymentPerson != 596 && Info.PaymentPerson != 597)
            {
                one.IsConfirm = true;
                //one.ConfirmDate = DateTime.Now;
                //one.ConfirmPerson = HozestERPContext.Current.User.CustomerID;
            }
            else
            {
                one.IsConfirm = false;
            }

            one.ResponsiblePerson = this.txtResponsiblePerson.Text.Trim();
            one.Reason = this.txtClaimReason.Text.Trim();
            one.IsEnable = false;
            one.CreateDate = one.UpdateDate = DateTime.Now;
            one.CreateID = one.UpdateID = HozestERPContext.Current.User.CustomerID;
            base.XMClaimInfoDetailService.InsertXMClaimInfoDetail(one);

            return true;
        }

        private string AutoClaimRef()
        {
            string ClaimRef = "";
            int number = 1;
            var claimInfo = base.XMClaimInfoService.GetXMClaimInfoList();
            if (claimInfo != null && claimInfo.Count > 0)
            {
                number = claimInfo[0].Id + 1;
            }
            ClaimRef = "CA" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return ClaimRef;
        }

        protected void chkNoOrderPremiums_Changed(object sender, EventArgs e)
        {
            bool chk = this.chkNoOrderPremiums.Checked;
            if (!chk)
            {
                this.txtScalpingCode.Value = "";
                this.wangwang.Value = "";
                this.txtScalpingCode.Disabled = true;
                //this.ddlPaymentPerson.Enabled = false;
                //this.chkNoOrderPremiums.Enabled = true;
                this.lblNickName.Visible = true;
                this.lblProjectName.Visible = true;
                this.ddlNick.Visible = true;
                this.ddlProject.Visible = true;
            }
            else
            {
                this.txtScalpingCode.Disabled = false;
                //this.ddlPaymentPerson.Enabled = true;
                //this.chkNoOrderPremiums.Enabled = false;
                this.lblNickName.Visible = false;
                this.lblProjectName.Visible = false;
                this.ddlNick.Visible = false;
                this.ddlProject.Visible = false;
            }

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "autoCompleteBindScalpingCode", "autoCompleteBindScalpingCode()", true);//ajax
        }

        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddlProject.SelectedValue));
            this.ddlNick.Items.Clear();
            this.ddlNick.DataSource = nickList;
            this.ddlNick.DataTextField = "nick";
            this.ddlNick.DataValueField = "nick_id";
            this.ddlNick.DataBind();
            this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "autoCompleteBindScalpingCode", "autoCompleteBindScalpingCode()", true);//ajax
        }

        /// <summary>
        /// 赠品Id
        /// </summary>
        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        /// <summary>
        /// 赠品TabPane 类型
        /// </summary>
        public string TabPanelPremiumsType
        {
            get
            {
                return CommonHelper.QueryString("TabPanelPremiumsType");
            }
        }
    }
}