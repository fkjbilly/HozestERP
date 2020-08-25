using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageFinance
{ 

    public partial class AdvanceApplicationReport : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            //暂支类型
            this.ddTheAdvanceType.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(184, false);
            this.ddTheAdvanceType.DataSource = codeList;
            this.ddTheAdvanceType.DataTextField = "CodeName";
            this.ddTheAdvanceType.DataValueField = "CodeID";
            this.ddTheAdvanceType.DataBind();

            #region 店铺名称绑定

            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddlNickId.Items.Clear();
                var NickList = base.XMNickService.GetXMNickList();
                var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                if (newNickList.Count() > 0)
                {
                    this.ddlNickId.DataSource = newNickList;
                    this.ddlNickId.DataTextField = "nick";
                    this.ddlNickId.DataValueField = "nick_id";
                    this.ddlNickId.DataBind();
                    this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }
            else
            {
                //其他
                //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                if (xMNickList.Count() == 0)
                {
                    this.ddlNickId.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                }
                if (xMNickList.Count > 0)
                {
                    this.ddlNickId.Items.Clear();
                    this.ddlNickId.DataSource = xMNickList;
                    this.ddlNickId.DataTextField = "nick";
                    this.ddlNickId.DataValueField = "nick_id";
                    this.ddlNickId.DataBind();
                    //this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }

            #endregion 

            //暂支状态
            //this.ddAdvanceState.Items.Clear();
            //var codeAdvanceStateList = base.CodeService.GetCodeListInfoByCodeTypeID(183, false);
            //this.ddAdvanceState.DataSource = codeAdvanceStateList;
            //this.ddAdvanceState.DataTextField = "CodeName";
            //this.ddAdvanceState.DataValueField = "CodeID";
            //this.ddAdvanceState.DataBind();
            //this.ddAdvanceState.Items.Insert(0, new ListItem("---所有---", "-1"));
        } 

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
           var ddTheAdvanceType= this.ddTheAdvanceType.SelectedValue;//暂支类型
           var ddlNickId= this.ddlNickId.SelectedValue;//店铺名称
           var txtApplicantsName = this.txtApplicantsName.Text.Trim();//申请人
           var ddAdvanceState = this.ddAdvanceState.SelectedValue;//暂支状态
           var txtScalpingCode = this.txtScalpingCode.Text.Trim();//刷单单号
             
           this.Master.BindData<AdvanceApplication>(this.gvAdvanceApplication
                      , base.AdvanceApplicationService.SearchAdvanceApplication(Convert.ToInt32(ddTheAdvanceType)
                      , Convert.ToInt32(ddlNickId), txtApplicantsName, Convert.ToInt32(ddAdvanceState), txtScalpingCode
                      , paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString()));
        }

        //private void BindGrid()
        //{
        //    this.BindGrid(Master.PageIndex, Master.PageSize);
        //}
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        //隐藏行绑定数据
        protected void gvAdvanceApplication_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                #region 主表
                var advanceApplication = e.Row.DataItem as AdvanceApplication;

                #region 暂支状态处理
                Label lblAdvanceState = e.Row.FindControl("lblAdvanceState") as Label;
                if (Convert.ToInt32(AdvanceStateEnum.TheAdvanceNoneDealWith) == advanceApplication.AdvanceState.Value)
                {

                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        lblAdvanceState.Text = "未处理";
                        e.Row.Cells[11].BackColor = System.Drawing.Color.Yellow;
                    }
                }
                else if (Convert.ToInt32(AdvanceStateEnum.TheAdvanceUse) == advanceApplication.AdvanceState.Value)
                {

                    lblAdvanceState.Text = "暂支使用中";
                    e.Row.Cells[11].BackColor = System.Drawing.Color.Green;

                }
                else if (Convert.ToInt32(AdvanceStateEnum.TheAdvanceEnd) == advanceApplication.AdvanceState.Value)
                {

                    lblAdvanceState.Text = "暂支结束";
                    e.Row.Cells[11].BackColor = System.Drawing.Color.Red;

                }
                #endregion

                //暂支总金额
                decimal TheAdvanceMoney = advanceApplication.TheAdvanceMoney.Value;
                //明细
                List<AdvanceApplicationDetail> advanceApplicationDetail = base.AdvanceApplicationDetailService.GetAdvanceApplicationDetailListByAdvanceId(advanceApplication.Id);

                #region 未领款=暂支总金额-已领款金额
                Label lblWLK = e.Row.FindControl("lblWLK") as Label;
                decimal sum = 0;//已领款金额
                if (advanceApplicationDetail.Count > 0)
                {
                    var advanceApplicationDetailNew = advanceApplicationDetail.Where(p => p.AdvanceTypeId == 345).ToList();
                    if (advanceApplicationDetailNew.Count > 0)
                    {
                        sum = advanceApplicationDetailNew.Select(p => p.TheAdvanceMoney.Value).Sum();
                    }
                }
                //未领款=暂支总金额-已领款金额
                decimal YK = TheAdvanceMoney - sum;
                lblWLK.Text = YK.ToString("0.##");
                #endregion

                #region 未还款

                #region 刷单订单总金额、总佣金

                decimal SalePriceSum = 0;
                decimal FeeSum = 0;
                decimal DeductionSum = 0;
                decimal SalePrice = 0;

                if (advanceApplication.ScalpingId != null && advanceApplication.ScalpingId > 0)
                {
                    var scalpingList = base.XMScalpingService.GetXMScalpingByScalpingId(advanceApplication.ScalpingId.Value);
                     
                    var scalpingListNew = scalpingList.Where(p => p.IsAbnormal == false).ToList();

                    //订单总销售额
                    SalePriceSum = scalpingListNew.Select(p => p.SalePrice == null ? 0 : p.SalePrice.Value).Sum();
                    //订单总佣金
                    FeeSum = scalpingListNew.Select(p => p.Fee == null ? 0 : p.Fee.Value).Sum();
                    //订单扣点
                    DeductionSum = scalpingListNew.Select(p => p.Deduction == null ? 0 : p.Deduction.Value).Sum();
                }

                #endregion
                Label lblWHK = e.Row.FindControl("lblWHK") as Label;
                decimal HKsum = 0;
                if (advanceApplicationDetail.Count > 0)
                {
                    var advanceApplicationDetailNew = advanceApplicationDetail.Where(p => p.AdvanceTypeId == 346).ToList();
                    if (advanceApplicationDetailNew.Count > 0)
                    {
                        HKsum = advanceApplicationDetailNew.Select(p => p.TheAdvanceMoney.Value).Sum();

                    }
                }
                
                decimal SY = 0;

                //订单回款=订单销售额-订单扣点
                SalePrice = SalePriceSum - DeductionSum;
                if (advanceApplication.AdvanceState == (int)AdvanceStateEnum.TheAdvanceNoneDealWith)
                {
                    SY = 0;
                }
                if (advanceApplication.AdvanceState == (int)AdvanceStateEnum.TheAdvanceUse)
                {
                    //剩余还款金额=总暂支金额-已经还款金额-订单回款-订单佣金 -未领款金额-订单扣点
                    SY = TheAdvanceMoney - HKsum - SalePrice - FeeSum - YK - DeductionSum;
                }
                else {
                    //剩余还款金额=总暂支金额-已经还款金额 -未领款金额
                    SY = TheAdvanceMoney - HKsum   - YK;
                }

                lblWHK.Text = "-" + SY.ToString("0.##");
                lblWHK.Style.Add("color", "red");


                #endregion


                #region 归还日期
                Label lblForecastReturnTime = e.Row.FindControl("lblForecastReturnTime") as Label;
                if (advanceApplication.ForecastReturnTime != null)
                {
                    if (advanceApplication.ForecastReturnTime.Value < DateTime.Now.AddDays(1) && SY>0)
                    {
                        //未在归还日期内还款的 日期显示红色
                        lblForecastReturnTime.Text = advanceApplication.ForecastReturnTime.Value.ToString("yyyy-MM-dd");
                        lblForecastReturnTime.Style.Add("color", "red");
                    }
                    else
                    {
                        lblForecastReturnTime.Text = advanceApplication.ForecastReturnTime.Value.ToString("yyyy-MM-dd");
                    }
                }
                else
                {

                    lblForecastReturnTime.Text = "";
                }

                #endregion
                #endregion

                #region 绑定明细数据（暂支记录信息）
                if ((GridView)e.Row.FindControl("gvAdvanceApplicationDetail") != null)
                {

                    if (advanceApplication.AdvanceState == (int)AdvanceStateEnum.TheAdvanceUse)
                    {

                        #region 在操作记录上新增 订单回款、佣金、订单扣点
                         
                        if (SalePrice > 0 && FeeSum > 0)
                        {
                            //346:还款类型 , 378：订单回款 ,SalePrice:订单回款金额 
                            advanceApplicationDetail.Add(new AdvanceApplicationDetail()
                            {
                                AdvanceId = advanceApplication.Id,
                                AdvanceTypeId = 346,
                                PayTypeId = 378,
                                TheAdvanceMoney = SalePrice,
                                RecipientsId = -1

                            });
                            //346:还款类型 , 379：订单佣金 ,FeeSum:订单总佣金 
                            advanceApplicationDetail.Add(new AdvanceApplicationDetail()
                            {
                                AdvanceId = advanceApplication.Id,
                                AdvanceTypeId = 346,
                                PayTypeId = 379,
                                TheAdvanceMoney = FeeSum,
                                RecipientsId = -1
                            });

                        }
                        else if (SalePrice > 0 && FeeSum == 0)
                        {

                            //346:还款类型 , 378：订单回款 ,SalePrice:订单回款金额 
                            advanceApplicationDetail.Add(new AdvanceApplicationDetail()
                            {
                                AdvanceId = advanceApplication.Id,
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
                                AdvanceId = advanceApplication.Id,
                                AdvanceTypeId = 346,
                                PayTypeId = 379,
                                TheAdvanceMoney = FeeSum,
                                RecipientsId = -1
                            });

                        }

                        if (DeductionSum > 0)
                        {

                            //346:还款类型 , 379：订单扣点 ,DeductionSum:订单扣点
                            advanceApplicationDetail.Add(new AdvanceApplicationDetail()
                            {
                                AdvanceId = advanceApplication.Id,
                                AdvanceTypeId = 346,
                                PayTypeId = 380,
                                TheAdvanceMoney = DeductionSum,
                                RecipientsId = -1
                            });
                        }

                        #endregion
                    }
                    GridView gvAdvanceApplicationDetail = (GridView)e.Row.FindControl("gvAdvanceApplicationDetail");
                    gvAdvanceApplicationDetail.DataSource = advanceApplicationDetail;
                    gvAdvanceApplicationDetail.DataBind();
                }
                #endregion

            }

            
        }

        protected void gvAdvanceApplicationDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Attributes.Add("style", "word-break :break-all ; word-wrap:break-word");
                var item = (AdvanceApplicationDetail)e.Row.DataItem;

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

                    }
                }
                #endregion
                 
                #region 领/还款人
                Label lblRecipientsFunName = e.Row.FindControl("lblRecipientsFunName") as Label;
                 
                //数据源数据
                if (item.Id != null && item.Id != 0 && item.Id > 0)
                { 
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
                    if (lblRecipientsFunName != null)
                    {
                        if (item.RecipientsId == -1)
                        {
                            lblRecipientsFunName.Text = "系统统计";
                        }
                    }
                }
#endregion
            }
        }



        protected void ddTheAdvanceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TheAdvanceTypeId = this.ddTheAdvanceType.SelectedValue.Trim();//暂支类型id

            if (TheAdvanceTypeId == "343")
            {
                //店铺
                this.ddlNickId.Items.Clear();
                var NickList = base.XMNickService.GetXMNickList();
                var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                this.ddlNickId.DataSource = newNickList;
                this.ddlNickId.DataTextField = "nick";
                this.ddlNickId.DataValueField = "nick_id";
                this.ddlNickId.DataBind();
                this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddlNickId.Enabled = true;
                this.txtScalpingCode.Enabled = true;
            }
            else
            { 
                this.ddlNickId.Items.Clear(); 
                this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1")); 
                this.ddlNickId.Enabled = false;
                this.txtScalpingCode.Text = "";
                this.txtScalpingCode.Enabled = false;
            }

            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
    }
}