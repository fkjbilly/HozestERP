using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Common;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageFinance
{  
    public partial class PrintAdvanceApplication : BaseAdministrationPage, IEditPage
    {
         
        #region IEditPage 成员

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        #endregion
        //protected override Dictionary<string, string> ButtonSecuritys
        //{
        //    get
        //    {
        //        Dictionary<string, string> buttons = new Dictionary<string, string>();
        //        buttons.Add("btnPrinView", "ManageFinance.PrintAdvanceApplication.PrinView");//打印预览
        //        buttons.Add("btnPrint", "ManageFinance.PrintAdvanceApplication.Print");//打印  

        //        return buttons;
        //    }
        //}

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            Page.Theme = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.InitData();
            }
        } 
        /// <summary>
        /// 加载数据
        /// </summary>
        public void InitData()
        {
            //暂支申请主表信息
            AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(this.AdvanceId); 
            if (advanceApplication != null)
            {
                //var AdvanceApplicationDetailList = base.AdvanceApplicationDetailService.GetAdvanceApplicationDetailListByAdvanceId(advanceApplication.Id); 
                //var AdvanceTypeIdList = AdvanceApplicationDetailList.Where(a => a.AdvanceTypeId == 345).ToList();//查询暂支类型数据

                this.lblApplicationDepartment.Text = advanceApplication.DepartmentName != null ? advanceApplication.DepartmentName.DepName : "";
                this.lblNickName.Text = advanceApplication.NickName != null ? advanceApplication.NickName.nick : "";
                this.txtFinanceOkTime.Text = advanceApplication.FinanceOkTime != null ? advanceApplication.FinanceOkTime.Value.ToLongDateString().ToString() : "";
                this.txtApplicationPayee.Text = advanceApplication.ApplicationPayee != null ? advanceApplication.ApplicationPayee : "";
                this.txtTheAdvanceSubject.Text = advanceApplication.TheAdvanceSubject != null ? advanceApplication.TheAdvanceSubject : "";

                string TheAdvanceMoney=advanceApplication.TheAdvanceMoney!=null ? advanceApplication.TheAdvanceMoney.Value.ToString():"";

                this.txtTheAdvanceMoneyCapital.Text ="人  民  币: "+ new DigitToChnText().Convert(TheAdvanceMoney.ToString(), true);//大写 
                this.txtTheAdvanceMoneyLowerCase.Text = advanceApplication.TheAdvanceMoney!=null ? " ￥ "+advanceApplication.TheAdvanceMoney.Value.ToString("0.##"):"";
                this.txtForecastReturnTime.Text = advanceApplication.ForecastReturnTime != null ? advanceApplication.ForecastReturnTime.Value.ToLongDateString().ToString() : "";
                this.txtSubject.Text = advanceApplication.Subject != null ? advanceApplication.Subject : "";
                this.txtManagerPeople.Text = advanceApplication.ManagerPeopleName!=null ? advanceApplication.ManagerPeopleName.FullName:"";
                this.txtApplicants.Text = advanceApplication.ApplicantsName != null ? advanceApplication.ApplicantsName.FullName : "";
                //if (AdvanceTypeIdList.Count > 0)
                //{
                //    this.txtRecipientsId.Text = AdvanceTypeIdList[0].RecipientsFunName != null ? AdvanceTypeIdList[0].RecipientsFunName.FullName : "";
                //}
            }
        }
         
        /// <summary>
        /// 财务确认(财务确认通过)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void hidBtnFinanceOk_Click(object sender, EventArgs e)
        { 
            try
            {
                AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(this.AdvanceId);

                if (advanceApplication!=null) 
                {
                    if (advanceApplication.FinanceOkIsAudit == false && advanceApplication.AdvanceState != (int)AdvanceStateEnum.TheAdvanceUse)
                    { 
                        advanceApplication.FinanceOkPeople = HozestERPContext.Current.User.CustomerID;
                        advanceApplication.FinanceOkIsAudit = true;
                        advanceApplication.AdvanceState = (int)AdvanceStateEnum.TheAdvanceUse;
                        advanceApplication.FinanceOkTime = DateTime.Now;
                        advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        advanceApplication.UpdateTime = DateTime.Now;
                        base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
                    }
                } 
                ScriptManager.RegisterStartupScript(this.btnPrint, this.Page.GetType(), "PrintAdvanceApplication", "alert('操作成功.');PopClose();", true); 
            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        } 
        public int AdvanceId
        {
            get
            {
                return CommonHelper.QueryStringInt("AdvanceId");
            }
        }

    }
}