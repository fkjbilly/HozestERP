using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Web.Modules;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{

    public partial class AdvanceApplicationDetailManage : BaseAdministrationPage, IEditPage
    {
        /// <summary>
        /// 按钮 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnEdit", "ManageFinance.AdvanceApplicationDetail.Edit");
                buttons.Add("imgBtnDelete", "ManageFinance.AdvanceApplicationDetail.Delete");
                buttons.Add("imgBtnUpdate", "ManageFinance.AdvanceApplicationDetail.Save");
                buttons.Add("imgBtnCancel", "ManageFinance.AdvanceApplicationDetail.Cancel");
                buttons.Add("btnSave", "ManageFinance.AdvanceApplicationDetailManage.Save"); //保存 
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate(); 
            }
        }


         /// <summary>
        /// 数据
        /// </summary>
        public void loadDate()
        {
            if (this.AdvanceId > 0)
            {

                //暂支申请主表信息
                AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(this.AdvanceId);

                if (advanceApplication != null)
                {

                    if (advanceApplication.ScalpingId != null)
                    {
                        this.ScalpingId = advanceApplication.ScalpingId.Value;//刷单Id
                    }
                    if (advanceApplication.TheAdvanceMoney != null) {

                        this.TheAdvanceMoney = advanceApplication.TheAdvanceMoney.Value;//暂支金额
                    
                    }

                    this.IntAdvanceState = advanceApplication.AdvanceState != null ? advanceApplication.AdvanceState.Value : 0;

                    if (advanceApplication.TheAdvanceType.Value == 343)
                    {
                        this.TD2.Visible = true;
                    }
                    else
                    {
                        this.TD2.Visible = false;
                    } 
                    //部门审核通过不可修改
                    if (advanceApplication.ManagerIsAudit.Value == true)
                    {  
                        this.VisibleNo();
                        this.lblTheAdvanceTypeId.Text = advanceApplication.TheAdvanceTypeName != null ? advanceApplication.TheAdvanceTypeName.CodeName : "";

                        // this.lblScalpingNo.Text = advanceApplication.ScalpingNo != null ? advanceApplication.ScalpingNo.ScalpingCode : "";

                        this.lbtnOrderNo.Text = advanceApplication.ScalpingNo != null ? advanceApplication.ScalpingNo.ScalpingCode : "";

                        this.lblPlatformType.Text = advanceApplication.PlatformTypeName != null ? advanceApplication.PlatformTypeName.CodeName : "";
                        this.lblNickName.Text = advanceApplication.NickName != null ? advanceApplication.NickName.nick : "";
                        this.lblApplicationDepartment.Text = advanceApplication.DepartmentName != null ? advanceApplication.DepartmentName.DepName : "";
                        this.lblApplicationPayee.Text = advanceApplication.ApplicationPayee != null ? advanceApplication.ApplicationPayee : "";
                        this.lblTheAdvanceSubject.Text = advanceApplication.TheAdvanceSubject != null ? advanceApplication.TheAdvanceSubject : "";
                        this.lblTheAdvanceMoney.Text = advanceApplication.TheAdvanceMoney != null ? advanceApplication.TheAdvanceMoney.Value.ToString() : "";

                        this.lblForecastReturnTime.Text = advanceApplication.ForecastReturnTime != null ? advanceApplication.ForecastReturnTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                        this.lblSubject.Text = advanceApplication.Subject != null ? advanceApplication.Subject : "";
                        this.lblManagerPeople.Text = advanceApplication.ManagerPeopleName != null ? advanceApplication.ManagerPeopleName.FullName : "";
                        if (advanceApplication.ManagerIsAudit != null)
                        {
                            this.ckbManagerIsAudit.Checked = advanceApplication.ManagerIsAudit.Value;
                        }
                        this.lblManagerTime.Text = advanceApplication.ManagerTime != null ? advanceApplication.ManagerTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                        this.lblFinancePeople.Text = advanceApplication.FinancePeopleName != null ? advanceApplication.FinancePeopleName.FullName : "";
                        if (advanceApplication.FinanceIsAudit != null)
                        {
                            this.ckbFinanceIsAudit.Checked = advanceApplication.FinanceIsAudit.Value;
                        }
                        this.lblFinanceAuditTime.Text = advanceApplication.FinanceAuditTime != null ? advanceApplication.FinanceAuditTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                        if (Convert.ToInt32(AdvanceStateEnum.TheAdvanceNoneDealWith) == advanceApplication.AdvanceState.Value)
                        {
                            lblAdvanceState.Text = "未处理";
                        }
                        else if (Convert.ToInt32(AdvanceStateEnum.TheAdvanceUse) == advanceApplication.AdvanceState.Value)
                        {
                            lblAdvanceState.Text = "暂支使用中";
                        }
                        else if (Convert.ToInt32(AdvanceStateEnum.TheAdvanceEnd) == advanceApplication.AdvanceState.Value)
                        {
                            lblAdvanceState.Text = "暂支结束";
                        }
                        this.lblApplicants.Text = advanceApplication.ApplicantsName != null ? advanceApplication.ApplicantsName.FullName : "";
                        this.lblPaymentTine.Text = advanceApplication.PaymentTime != null ? advanceApplication.PaymentTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                        this.lblFinanceOkPeople.Text = advanceApplication.FinanceOkPeopleName != null ? advanceApplication.FinanceOkPeopleName.FullName : "";
                        if (advanceApplication.FinanceOkIsAudit != null)
                        {
                            this.ckbFinanceOkIsAudit.Checked = advanceApplication.FinanceOkIsAudit.Value;
                        }
                        this.lblFinanceOkTime.Text = advanceApplication.FinanceOkTime != null ? advanceApplication.FinanceOkTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";

                        this.lblDirectorPeople.Text = advanceApplication.DirectorPeopleName != null ? advanceApplication.DirectorPeopleName.FullName : "";
                        if (advanceApplication.DirectorIsAudit != null)
                        {
                            this.chbDirectorIsAudit.Checked = advanceApplication.DirectorIsAudit.Value;
                        }
                        this.lblDirectorTime.Text = advanceApplication.DirectorTime != null ? advanceApplication.DirectorTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";


                        this.lblFinanceAdvanceEndPeople.Text = advanceApplication.FinanceAdvanceEndPeopleName != null ? advanceApplication.FinanceAdvanceEndPeopleName.FullName : "";
                        if (advanceApplication.FinanceAdvanceEndIsAudit != null)
                        {
                            this.ckbFinanceAdvanceEndIsAudit.Checked = advanceApplication.FinanceAdvanceEndIsAudit.Value;
                        }
                        this.lblFinanceAdvanceEndTime.Text = advanceApplication.FinanceAdvanceEndTime != null ? advanceApplication.FinanceAdvanceEndTime.Value.ToString("yyyy-MM-dd hh:ss:mm") : "";

                        //刷单单号 订单回款明细

                        this.lbtnOrderNo.OnClientClick = "return ShowWindowDetail('订单回款明细','" + CommonHelper.GetStoreLocation()
                                                    + "ManageProject/XMScalpingPaymentDetails.aspx?ScalpingId=" + advanceApplication.ScalpingId
                                                    + "', 1000, 480, this,'');";
                    }
                    else
                    { 
                        this.VisibleYes();
                        this.hfScalpingId.Value = advanceApplication.ScalpingId != null ? advanceApplication.ScalpingId.Value.ToString() : "";
                        this.hfPlatformTypeId.Value = advanceApplication.PlatformTypeId != null ? advanceApplication.PlatformTypeId.Value.ToString() : "";
                        this.hfNickId.Value = advanceApplication.NickId != null ? advanceApplication.NickId.Value.ToString() : "";
                        this.ddTheAdvanceType.SelectedValue = advanceApplication.TheAdvanceType != null ? advanceApplication.TheAdvanceType.Value.ToString() : "";
                        this.txtScalpingCode.Value = advanceApplication.ScalpingNo != null ? advanceApplication.ScalpingNo.ScalpingCode : "";
                        this.txtPlatformType.Text = advanceApplication.PlatformTypeName != null ? advanceApplication.PlatformTypeName.CodeName : "";
                        this.txtNickName.Text = advanceApplication.NickName != null ? advanceApplication.NickName.nick : "";
                        this.ddApplicationDepartment.SelectedValue = advanceApplication.ApplicationDepartment != null ? advanceApplication.ApplicationDepartment.Value.ToString() : "";
                        this.txtApplicationPayee.Text = advanceApplication.ApplicationPayee != null ? advanceApplication.ApplicationPayee : "";
                        this.txtTheAdvanceSubject.Text = advanceApplication.TheAdvanceSubject != null ? advanceApplication.TheAdvanceSubject : "";
                        this.txtTheAdvanceMoney.Text = advanceApplication.TheAdvanceMoney != null ? advanceApplication.TheAdvanceMoney.Value.ToString() : "";
                        //this.lblForecastReturnTime.Text = advanceApplication.ForecastReturnTime != null ? advanceApplication.ForecastReturnTime.Value.ToString("yyyy-MM-dd") : "";
                        this.txtSubject.Text = advanceApplication.Subject != null ? advanceApplication.Subject : "";
                        //申请人
                        this.txtApplicants.SelectSingleCustomer = base.CustomerInfoService.GetCustomerInfoByID(advanceApplication.Applicants.Value);
                        if (this.txtApplicants.SelectSingleCustomer != null)
                            this.txtApplicants.Value = this.txtApplicants.SelectSingleCustomer.FullName;

                    } 
                }
                BindGrid();
            }
        }
        /// <summary>
        /// 从表
        /// </summary> 
        public void BindGrid()
        {  
            //暂支申请明细信息
            List<AdvanceApplicationDetail> advanceApplicationDetail = base.AdvanceApplicationDetailService.GetAdvanceApplicationDetailListByAdvanceId(this.AdvanceId);


            #region 剩余暂支款
            decimal sum = 0;
            if (advanceApplicationDetail.Count > 0) {

                var advanceApplicationDetailNew = advanceApplicationDetail.Where(p => p.AdvanceTypeId == 345).ToList();
                if (advanceApplicationDetailNew.Count > 0)
                {
                    sum = advanceApplicationDetailNew.Select(p => p.TheAdvanceMoney == null ? 0 : p.TheAdvanceMoney.Value).Sum();
                    
                } 
            }
            if (this.lblTheAdvanceMoney.Text != "")
            {
                decimal TheAdvanceMoney = Convert.ToDecimal(this.lblTheAdvanceMoney.Text.Trim());
                decimal YK = TheAdvanceMoney - sum;
                this.lblSUMTheAdvanceMoney.Text = YK.ToString("0.##");
            }
            else {
                this.lblSUMTheAdvanceMoney.Text = "0";
            }

            #endregion

            if (this.IntAdvanceState == (int)AdvanceStateEnum.TheAdvanceUse)
            {
                #region 刷单订单总金额、总佣金

                decimal SalePriceSum = 0;
                decimal FeeSum = 0;
                decimal DeductionSum = 0; 
                decimal SalePrice = 0;

                if (this.ScalpingId > 0)
                {
                    var scalpingList = base.XMScalpingService.GetXMScalpingByScalpingId(this.ScalpingId);

                    var scalpingListNew = scalpingList.Where(p => p.IsAbnormal == false).ToList();

                    //订单总销售额
                    SalePriceSum = scalpingListNew.Select(p => p.SalePrice == null ? 0 : p.SalePrice.Value).Sum();
                    //订单总佣金
                    FeeSum = scalpingListNew.Select(p => p.Fee == null ? 0 : p.Fee.Value).Sum();
                    //订单扣点
                    DeductionSum = scalpingListNew.Select(p => p.Deduction == null ? 0 : p.Deduction.Value).Sum();
                }

                #endregion

                #region 在操作记录上新增 订单回款、佣金、订单扣点

                //订单回款=订单销售额-订单扣点 
                SalePrice = SalePriceSum - DeductionSum;

                if (SalePrice > 0 && FeeSum > 0)
                {
                    //346:还款类型 , 378：订单回款 ,SalePriceSum:订单回款金额 
                    advanceApplicationDetail.Add(new AdvanceApplicationDetail()
                    {
                        AdvanceId = this.AdvanceId,
                        AdvanceTypeId = 346,
                        PayTypeId = 378,
                        TheAdvanceMoney = SalePrice,
                        RecipientsId = -1

                    });
                    //346:还款类型 , 379：订单佣金 ,FeeSum:订单总佣金 
                    advanceApplicationDetail.Add(new AdvanceApplicationDetail()
                    {
                        AdvanceId = this.AdvanceId,
                        AdvanceTypeId = 346,
                        PayTypeId = 379,
                        TheAdvanceMoney = FeeSum,
                        RecipientsId = -1
                    });

                }
                else if (SalePrice > 0 && FeeSum == 0)
                {

                    //346:还款类型 , 378：订单回款 ,SalePriceSum:订单回款金额 
                    advanceApplicationDetail.Add(new AdvanceApplicationDetail()
                    {
                        AdvanceId = this.AdvanceId,
                        AdvanceTypeId = 346,
                        PayTypeId = 378,
                        TheAdvanceMoney = SalePrice,
                        RecipientsId = -1

                    });
                }
                else if (SalePrice == 0 && FeeSum > 0)
                {
                    //346:还款类型 , 379：订单佣金 ,FeeSum:订单总佣金 
                    advanceApplicationDetail.Add(new AdvanceApplicationDetail()
                    {
                        AdvanceId = this.AdvanceId,
                        AdvanceTypeId = 346,
                        PayTypeId = 379,
                        TheAdvanceMoney = FeeSum,
                        RecipientsId = -1
                    });

                }

                if (DeductionSum > 0) {

                    //346:还款类型 , 379：订单扣点 ,DeductionSum:订单扣点
                    advanceApplicationDetail.Add(new AdvanceApplicationDetail()
                    {
                        AdvanceId = this.AdvanceId,
                        AdvanceTypeId = 346,
                        PayTypeId = 380,
                        TheAdvanceMoney = DeductionSum,
                        RecipientsId = -1
                    });
                }

                #endregion
            }
            //部门审核通过 暂支申请明细不可新增
                //if (this.BoolManagerIsAudit == true)
                if(this.IntAdvanceState==(int)AdvanceStateEnum.TheAdvanceEnd)
                {
                    this.RowEditIndex = advanceApplicationDetail.Count();

                }  
                if (this.RowEditIndex == -1)
                {
                    this.gvAdvanceApplicationDetail.EditIndex = advanceApplicationDetail.Count();
                    advanceApplicationDetail.Add(new AdvanceApplicationDetail()); //新增编辑行
                }
                else
                {
                    this.gvAdvanceApplicationDetail.EditIndex = this.RowEditIndex;
                }

              
                this.gvAdvanceApplicationDetail.DataSource = advanceApplicationDetail;
                this.gvAdvanceApplicationDetail.DataBind(); 
        }

          
        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitleTabPanelVisible = false;

            //暂支类型
            this.ddTheAdvanceType.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(184, false);
            ddTheAdvanceType.DataSource = codeList;
            ddTheAdvanceType.DataTextField = "CodeName";
            ddTheAdvanceType.DataValueField = "CodeID";
            ddTheAdvanceType.DataBind();   

            //部门

            CommonMethod.DropDownListDepartment(this.ddApplicationDepartment, false);//申请部门
        }

        public void SetTrigger()
        { 
        }

        #endregion

        /// <summary>
        /// 不可编辑
        /// </summary>
        public void VisibleNo()
        {
            this.ddTheAdvanceType.Visible = false;  
            this.DIVScalpingNo.Visible = false; 
            this.ddApplicationDepartment.Visible = false;
            this.txtApplicationPayee.Visible = false;
            this.txtTheAdvanceSubject.Visible = false;
            this.txtTheAdvanceMoney.Visible = false;
           // this.txtForecastReturnTime.Visible = false;
            this.txtSubject.Visible = false;
            this.txtApplicants.Visible = false;
            this.txtNickName.Visible = false;
            this.txtPlatformType.Visible = false;


            this.lblTheAdvanceTypeId.Visible = true;
            this.DIVLableScalpingNo.Visible = true;
            this.lblApplicationDepartment.Visible = true;
            this.lblApplicationPayee.Visible = true;
            this.lblTheAdvanceSubject.Visible = true;
            this.lblTheAdvanceMoney.Visible = true;
            this.lblSUMTheAdvanceMoney.Visible = true;
            //this.lblForecastReturnTime.Visible = true;
            this.lblSubject.Visible = true;
            this.lblApplicants.Visible = true;
            this.lblNickName.Visible = true;
            this.lblPlatformType.Visible = true;

           // this.tdScalpingCode.Style.Add("width", "200px");

            this.btnSave.Visible = false;
             
        }

        /// <summary>
        /// 可编辑
        /// </summary>
        public void VisibleYes()
        { 
            this.ddTheAdvanceType.Visible = true;
            this.DIVScalpingNo.Visible = true;
            this.ddApplicationDepartment.Visible = true;
            this.txtApplicationPayee.Visible = true;
            this.txtTheAdvanceSubject.Visible = true;
            this.txtTheAdvanceMoney.Visible = true;
            //this.txtForecastReturnTime.Visible = true;
            this.txtSubject.Visible = true;
            this.txtApplicants.Visible = true;
            this.txtNickName.Visible = true;
            this.txtPlatformType.Visible = true;

            this.lblTheAdvanceTypeId.Visible = false;
            this.DIVLableScalpingNo.Visible = false;
            this.lblApplicationDepartment.Visible = false;
            this.lblApplicationPayee.Visible = false;
            this.lblTheAdvanceSubject.Visible = false;
            this.lblTheAdvanceMoney.Visible = false;
            this.lblSUMTheAdvanceMoney.Visible = false;
            //this.lblForecastReturnTime.Visible = false;
            this.lblSubject.Visible = false;
            this.lblApplicants.Visible = false;
            this.lblNickName.Visible = false;
            this.lblPlatformType.Visible = false;
           // this.tdScalpingCode.Style.Add("width", "260px");

            this.btnSave.Visible = true;
        }

        public int RowEditIndex
        {
            get
            {
                int editIndex = -1;
                try
                {
                    int.TryParse(ViewState["RowEditIndex"].ToString(), out editIndex);
                }
                catch
                {
                }
                return editIndex;
            }
            set
            {
                ViewState["RowEditIndex"] = value;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        decimal SYTheAdvanceMoney = 0;
        protected void gvAdvanceApplicationDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var item = (AdvanceApplicationDetail)e.Row.DataItem; 
                //领/还款人
                Label lblRecipientsFunName = e.Row.FindControl("lblRecipientsFunName") as Label;

                #region 部门审核通过 不允许修改
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;

                //数据源数据
                if (item.Id != null && item.Id != 0 && item.Id > 0)
                { 
                    if (imgBtnEdit != null && imgBtnDelete != null)
                    {
                        //if (this.BoolManagerIsAudit == true)
                        if (this.IntAdvanceState == (int)AdvanceStateEnum.TheAdvanceEnd)
                        {
                            imgBtnEdit.Visible = false;
                            imgBtnDelete.Visible = false;
                        }
                        else
                        {
                            imgBtnEdit.Visible = true;
                            imgBtnDelete.Visible = true;
                        }
                    }
                    #endregion  
                    if (lblRecipientsFunName != null)
                    {
                        if (item.RecipientsId == -1)
                        {
                            lblRecipientsFunName.Text = "系统统计";
                        }
                        else
                        {
                            lblRecipientsFunName.Text = item.RecipientsFunName != null ? item.RecipientsFunName.FullName : "";
                        }
                    }
                }
                else //系统统计数据
                {

                    if (imgBtnEdit != null && imgBtnDelete != null)
                    {

                        imgBtnEdit.Visible = false;
                        imgBtnDelete.Visible = false;
                    }
                    if (lblRecipientsFunName != null)
                    {
                        if (item.RecipientsId == -1)
                        {
                            lblRecipientsFunName.Text = "系统统计";
                        }
                    }
                }
                #region 金额
                Label lblTheAdvanceMoneyD = e.Row.FindControl("lblTheAdvanceMoneyD") as Label;

                if (lblTheAdvanceMoneyD != null)
                {

                    if (item.AdvanceTypeId == 345)
                    {

                        lblTheAdvanceMoneyD.Text = item.TheAdvanceMoney.Value.ToString();
                    }
                    else if (item.AdvanceTypeId == 346)
                    {
                        lblTheAdvanceMoneyD.Text = "-" + item.TheAdvanceMoney.Value.ToString();
                        lblTheAdvanceMoneyD.Style.Add("color", "red");
                        SYTheAdvanceMoney += item.TheAdvanceMoney.Value;
                    }
                }
                #endregion
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                var lblSYTheAdvanceMoney = e.Row.FindControl("lblSYTheAdvanceMoney") as Label;
                //总暂支金额
                decimal lblTheAdvanceMoney = 0;
                if (this.lblTheAdvanceMoney.Text != "")
                {
                    lblTheAdvanceMoney = Convert.ToDecimal(this.lblTheAdvanceMoney.Text.Trim());
                }
                //未领款金额
                decimal lblSUMTheAdvanceMoney = Convert.ToDecimal(this.lblSUMTheAdvanceMoney.Text.Trim());
                //剩余还款金额=总暂支金额-已经还款金额 -未领款金额
                decimal SY = lblTheAdvanceMoney - SYTheAdvanceMoney - lblSUMTheAdvanceMoney;

                lblSYTheAdvanceMoney.Text = SY.ToString("0.##");
            }
        }

        protected void gvAdvanceApplicationDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {  

            this.RowEditIndex = e.NewEditIndex;
            BindGrid(); 

            int Id = 0;
            int.TryParse(this.gvAdvanceApplicationDetail.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
            var row = this.gvAdvanceApplicationDetail.Rows[e.NewEditIndex];
            var advanceApplicationDetail = base.AdvanceApplicationDetailService.GetAdvanceApplicationDetailById(Id);

            if (advanceApplicationDetail != null)
            {
                //暂支类型
                CodeControl ccAdvanceTypeId = (CodeControl)row.FindControl("ccAdvanceTypeId");
                ccAdvanceTypeId.SelectedValue = advanceApplicationDetail.AdvanceTypeId.Value;

                //领/还款类型
                CodeControl ccPayTypeId = (CodeControl)row.FindControl("ccPayTypeId");
                ccPayTypeId.SelectedValue = advanceApplicationDetail.PayTypeId.Value;

                //领/还款人
                SelectSingleCustomerControl txtRecipientsId = (SelectSingleCustomerControl)row.FindControl("txtRecipientsId");
                txtRecipientsId.SelectSingleCustomer = base.CustomerInfoService.GetCustomerInfoByID(advanceApplicationDetail.RecipientsId.Value);
                if (txtRecipientsId.SelectSingleCustomer != null)
                    txtRecipientsId.Value = txtRecipientsId.SelectSingleCustomer.FullName;
            }


        }

        protected void gvAdvanceApplicationDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            BindGrid();
        }

        protected void gvAdvanceApplicationDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row = this.gvAdvanceApplicationDetail.Rows[e.RowIndex];
            decimal d = 0;
            var ccAdvanceTypeId = row.FindControl("ccAdvanceTypeId") as CodeControl;
            var ccPayTypeId = row.FindControl("ccPayTypeId") as CodeControl;
            SimpleTextBox txtTheAdvanceMoney = row.FindControl("txtTheAdvanceMoney") as SimpleTextBox;
            if (txtTheAdvanceMoney.Text.Trim() != "")
            {
                if (!decimal.TryParse(txtTheAdvanceMoney.Text.Trim(), out d))
                {
                    base.ShowMessage("您输入的暂支金额不正确!");
                    return;
                }
            }

            var txtRecipientsId = row.FindControl("txtRecipientsId") as SelectSingleCustomerControl; 
            var RecipientsId= txtRecipientsId.SelectSingleCustomer.CustomerID;

            int QID = Convert.ToInt32(gvAdvanceApplicationDetail.DataKeys[e.RowIndex].Value.ToString());
            AdvanceApplicationDetail advanceApplicationDetail = new AdvanceApplicationDetail();
            if (QID == 0) //新增
            {
                advanceApplicationDetail.AdvanceId = this.AdvanceId;
                advanceApplicationDetail.AdvanceTypeId = ccAdvanceTypeId.SelectedValue;
                advanceApplicationDetail.PayTypeId = ccPayTypeId.SelectedValue;
                advanceApplicationDetail.TheAdvanceMoney = Convert.ToDecimal(txtTheAdvanceMoney.Text);
                advanceApplicationDetail.RecipientsId = RecipientsId;
                advanceApplicationDetail.IsEnable = false;
                advanceApplicationDetail.CreatorID = HozestERPContext.Current.User.CustomerID;
                advanceApplicationDetail.CreateTime = DateTime.Now;
                advanceApplicationDetail.UpdatorID = HozestERPContext.Current.User.CustomerID;
                advanceApplicationDetail.UpdateTime = DateTime.Now;

                base.AdvanceApplicationDetailService.InsertAdvanceApplicationDetail(advanceApplicationDetail);
            }
            else //修改
            {

                advanceApplicationDetail.AdvanceTypeId = ccAdvanceTypeId.SelectedValue;
                advanceApplicationDetail.PayTypeId = ccPayTypeId.SelectedValue;
                advanceApplicationDetail.TheAdvanceMoney = Convert.ToDecimal(txtTheAdvanceMoney.Text);
                advanceApplicationDetail.RecipientsId = RecipientsId;
                advanceApplicationDetail.UpdatorID = HozestERPContext.Current.User.CustomerID;
                advanceApplicationDetail.UpdateTime = DateTime.Now;
                base.AdvanceApplicationDetailService.UpdateAdvanceApplicationDetail(advanceApplicationDetail);
                 
            } 
            //重新绑定
            this.RowEditIndex = -1;
            loadDate(); 
        }

        protected void gvAdvanceApplicationDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int QID = Convert.ToInt32(gvAdvanceApplicationDetail.DataKeys[e.RowIndex].Value.ToString());

            var AdvanceApplicationDetail= base.AdvanceApplicationDetailService.GetAdvanceApplicationDetailById(QID);
            if (AdvanceApplicationDetail!=null)
            {
                AdvanceApplicationDetail.IsEnable = true;
                AdvanceApplicationDetail.UpdatorID = HozestERPContext.Current.User.CustomerID;
                AdvanceApplicationDetail.UpdateTime = DateTime.Now;
                base.AdvanceApplicationDetailService.UpdateAdvanceApplicationDetail(AdvanceApplicationDetail); 
            }
             
            //重新绑定
            this.RowEditIndex = -1;
            BindGrid();
        }
         
        /// <summary>
        /// 保存暂支申请信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                { 
                    if (this.AdvanceId > 0)
                    { 
                        string ddTheAdvanceType = this.ddTheAdvanceType.SelectedValue.Trim(); 

                        //查询暂支单预计归还日期
                        var setting = base.SettingManager.GetSettingByName("AdvanceApplication.ForecastReturnTime");

                        if (setting != null)
                        {
                            //刷单暂支
                            if (ddTheAdvanceType == "343")
                            {
                                #region 根据店铺Id查询 所对应的项目,并查询出该项目所对应的所有店铺

                                int ProjectId = 0;
                                var NickId = Convert.ToInt32(this.hfNickId.Value);
                                var XMNick = base.XMNickService.GetXMNickByID(NickId);
                                if (XMNick != null)
                                {
                                    if (XMNick.ProjectId != null)
                                    {
                                        ProjectId = XMNick.ProjectId.Value;
                                    }
                                }

                                XMProject xMProject = new XMProject();

                                List<int> ProjectIdList = new List<int>();//项目Id

                                List<int> NickIdList = new List<int>();//项目下所有的 店铺Id
                                if (ProjectId > 0)
                                {
                                    ProjectIdList.Add(ProjectId);
                                    //所有店铺
                                    var XMNickProjectIdList = base.XMNickService.GetXMNickListByProjectId(ProjectIdList);
                                    //所有店铺Id
                                    NickIdList = XMNickProjectIdList.Select(p => p.nick_id).ToList();

                                    xMProject = base.XMProjectService.GetXMProjectById(ProjectId);
                                }
                                #endregion

                                List<AdvanceApplication> AdvanceApplicationList = new List<AdvanceApplication>();
                                if (NickIdList.Count > 0)
                                {
                                    var AdvanceApplicationListByNickId = base.AdvanceApplicationService.GetAdvanceApplicationListByNickId(NickIdList);

                                    if (AdvanceApplicationListByNickId.Count > 0)
                                    {

                                        AdvanceApplicationList = AdvanceApplicationListByNickId.Where(p => p.ForecastReturnTime < DateTime.Now.AddDays(1) && p.AdvanceState == (int)AdvanceStateEnum.TheAdvanceUse).ToList();
                                    }
                                }

                                if (AdvanceApplicationList.Count > 0)
                                {
                                    string ProjectName = "";

                                    if (xMProject != null)
                                    {

                                        ProjectName = xMProject.ProjectName;
                                    }
                                    base.ShowMessage(ProjectName + "项目有其它店铺未在归还日期内还款,请先还款!");
                                    return;

                                }
                                else
                                { 
                                    #region 修改
                                    string ddApplicationDepartment = this.ddApplicationDepartment.SelectedValue.Trim();
                                    string txtApplicationPayee = this.txtApplicationPayee.Text;
                                    string txtTheAdvanceSubject = this.txtTheAdvanceSubject.Text;
                                    string txtTheAdvanceMoney = this.txtTheAdvanceMoney.Text;
                                    //string lblForecastReturnTime = this.lblForecastReturnTime.Text.Trim();
                                    string txtSubject = this.txtSubject.Text;
                                    int txtApplicants = this.txtApplicants.SelectSingleCustomer.CustomerID;// this.txtApplicants.Text;   

                                    //判断刷单单号否有效
                                    this.lblMag.Visible = false;
                                    int scalpingId = 0;
                                    int.TryParse(this.hfScalpingId.Value, out scalpingId);
                                    if (ddTheAdvanceType == "343")
                                    {
                                        var scalping = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(scalpingId);
                                        if (scalping == null)
                                        {
                                            this.lblMag.Visible = true;
                                            this.lblMag.Text = "刷单单号有误";
                                            this.hfScalpingId.Value = "";
                                            this.txtScalpingCode.Value = "";
                                            this.hfNickId.Value = "";
                                            this.txtNickName.Text = "";
                                            this.hfPlatformTypeId.Value = "";
                                            this.txtPlatformType.Text = "";
                                            ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "advanceApplicationDetailManage", "autoCompleteBindScalpingCodeManag()", true);
                                            return;
                                        }
                                    }

                                    //暂支申请主表信息
                                    AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(this.AdvanceId);

                                    if (advanceApplication != null)
                                    {
                                        //判断是否重复
                                        var AdvanceApplicationListByScalpingId = base.AdvanceApplicationService.GetAdvanceApplicationByScalpingId(scalpingId);
                                        if (AdvanceApplicationListByScalpingId.Count > 0)
                                        {
                                            if (AdvanceApplicationListByScalpingId[0].ScalpingId != advanceApplication.ScalpingId)
                                            {
                                                this.lblMag.Visible = true;
                                                this.lblMag.Text = "刷单单号已存在";
                                                this.hfScalpingId.Value = "";
                                                this.txtScalpingCode.Value = "";
                                                this.hfNickId.Value = "";
                                                this.txtNickName.Text = "";
                                                this.hfPlatformTypeId.Value = "";
                                                this.txtPlatformType.Text = "";
                                                ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "advanceApplicationDetailManage", "autoCompleteBindScalpingCodeManag()", true);
                                                return;
                                            }
                                        }
                                        if (ddTheAdvanceType == "343")
                                        {
                                            advanceApplication.PlatformTypeId = Convert.ToInt32(this.hfPlatformTypeId.Value);
                                            advanceApplication.NickId = Convert.ToInt32(this.hfNickId.Value);
                                            advanceApplication.ScalpingId = Convert.ToInt32(scalpingId);
                                        } 
                                        advanceApplication.TheAdvanceType = Convert.ToInt32(ddTheAdvanceType);
                                        advanceApplication.ApplicationDepartment = Convert.ToInt32(ddApplicationDepartment);
                                        advanceApplication.ApplicationPayee = txtApplicationPayee;
                                        advanceApplication.TheAdvanceSubject = txtTheAdvanceSubject;
                                        advanceApplication.TheAdvanceMoney = Convert.ToDecimal(txtTheAdvanceMoney);
                                        //if (lblForecastReturnTime != "")
                                        //{
                                        //    advanceApplication.ForecastReturnTime = Convert.ToDateTime(lblForecastReturnTime);
                                        //}
                                        advanceApplication.Subject = txtSubject;
                                        advanceApplication.Applicants = txtApplicants;
                                        advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                        advanceApplication.UpdateTime = DateTime.Now;

                                        base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
                                        base.ShowMessage("保存成功");
                                        loadDate();
                                        ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "advanceApplicationDetailManage", "autoCompleteBindScalpingCodeManag()", true);
                                    }

                                    #endregion
                                }
                            }
                            else
                            {
                                #region 修改
                                string ddApplicationDepartment = this.ddApplicationDepartment.SelectedValue.Trim();
                                string txtApplicationPayee = this.txtApplicationPayee.Text;
                                string txtTheAdvanceSubject = this.txtTheAdvanceSubject.Text;
                                string txtTheAdvanceMoney = this.txtTheAdvanceMoney.Text;
                                //string lblForecastReturnTime = this.lblForecastReturnTime.Text.Trim();
                                string txtSubject = this.txtSubject.Text;
                                int txtApplicants = this.txtApplicants.SelectSingleCustomer.CustomerID;// this.txtApplicants.Text;   

                                //暂支申请主表信息
                                AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(this.AdvanceId);

                                if (advanceApplication != null)
                                {
                                    advanceApplication.PlatformTypeId = null;
                                    advanceApplication.NickId = null;
                                    advanceApplication.ScalpingId = null;
                                    advanceApplication.TheAdvanceType = Convert.ToInt32(ddTheAdvanceType);
                                    advanceApplication.ApplicationDepartment = Convert.ToInt32(ddApplicationDepartment);
                                    advanceApplication.ApplicationPayee = txtApplicationPayee;
                                    advanceApplication.TheAdvanceSubject = txtTheAdvanceSubject;
                                    advanceApplication.TheAdvanceMoney = Convert.ToDecimal(txtTheAdvanceMoney);
                                    //if (lblForecastReturnTime != "")
                                    //{
                                    //    advanceApplication.ForecastReturnTime = Convert.ToDateTime(lblForecastReturnTime);
                                    //}
                                    advanceApplication.Subject = txtSubject;
                                    advanceApplication.Applicants = txtApplicants;
                                    advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    advanceApplication.UpdateTime = DateTime.Now;
                                    base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
                                    base.ShowMessage("保存成功");
                                    loadDate();
                                    ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "advanceApplicationDetailManage", "autoCompleteBindScalpingCodeManag()", true);
                                } 
                                #endregion
                            }
                        }
                        else
                        {

                            base.ShowMessage("请联系管理员设置暂支预计归还天数!");
                            return;
                        } 
                         
                        
                    }
                }
                catch (Exception err)
                {
                    this.ProcessException(err);
                }
            }
        }

        protected void ddTheAdvanceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddTheAdvanceType = (DropDownList)sender;
            string projectid = ddTheAdvanceType.SelectedValue.Trim();//暂支类型id

            if (projectid == "343")
            {
                this.TD2.Visible = true;
            }
            else
            {
                this.TD2.Visible = false;
            }


            ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "advanceApplicationDetailManage", "autoCompleteBindScalpingCodeManag()", true);

        }

        //public string SYTheAdvanceMoney()
        //{
        //    decimal HKsum = 0;
        //    //主表信息
        //    //AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(this.AdvanceId);
        //    //明细
        //    List<AdvanceApplicationDetail> advanceApplicationDetail = base.AdvanceApplicationDetailService.GetAdvanceApplicationDetailListByAdvanceId(this.AdvanceId);

        //    decimal TheAdvanceMoney = Convert.ToDecimal(this.lblTheAdvanceMoney.Text.Trim());

        //    if (advanceApplicationDetail.Count > 0)
        //    {
        //        var advanceApplicationDetailNew = advanceApplicationDetail.Where(p => p.AdvanceTypeId == 346).ToList();
        //        if (advanceApplicationDetailNew.Count > 0)
        //        {
        //            HKsum = advanceApplicationDetailNew.Select(p => p.TheAdvanceMoney.Value).Sum();
        //        }
        //    }
        //    //剩余还款金额=总暂支金额-已经还款金额 
        //    decimal SY = TheAdvanceMoney - HKsum;

        //    return "-" + SY.ToString("0.##");
        //}
         
        private int IntAdvanceState = 0;

        private bool BoolManagerIsAudit = false;

        //刷单id 
        private int ScalpingId = 0;
        //暂支金额
        private decimal TheAdvanceMoney = 0;

        /// <summary>
        /// 暂支申请Id
        /// </summary>
        public int AdvanceId
        {
            get
            {
                return Convert.ToInt32(Request.Params["AdvanceId"]);
            }
        } 


    }
}