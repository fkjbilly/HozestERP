using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;

namespace HozestERP.Web.ManageCustomer
{
    public partial class CustomerSalaryDetail : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string BasePay = this.txtBasePay.Text.Trim();
            string MeritPay = this.txtMeritPay.Text.Trim();
            string PerformanceRoyalty = this.txtPerformanceRoyalty.Text.Trim();
            string Reward = this.txtReward.Text.Trim();
            string Subsidies = this.txtSubsidies.Text.Trim();
            string BasePayDebit = this.txtBasePayDebit.Text.Trim();
            string AbsenceDutyDebit = this.txtAbsenceDutyDebit.Text.Trim();
            string PerformanceCoefficient = this.txtPerformanceCoefficient.Text.Trim();
            string RealPerformance = this.txtRealPerformance.Text.Trim();
            string Replenishment = this.txtReplenishment.Text.Trim();
            string Debit = this.txtDebit.Text.Trim();
            string ShouldSalary = this.txtShouldSalary.Text.Trim();
            string Pension = this.txtPension.Text.Trim();
            string MedicalCare = this.txtMedicalCare.Text.Trim();
            string Unemployment = this.txtUnemployment.Text.Trim();
            string AccumulationFund = this.txtAccumulationFund.Text.Trim();
            string SocialSecurityTotal = this.txtSocialSecurityTotal.Text.Trim();
            string CommunicationFee = this.txtCommunicationFee.Text.Trim();
            string IndividualIncomeTax = this.txtIndividualIncomeTax.Text.Trim();
            string FinanceCharge = this.txtFinanceCharge.Text.Trim();
            string RealSalary = this.txtRealSalary.Text.Trim();  

            var one = base.CustomerSalaryService.GetCustomerSalaryByID(Id);
            one.BasePay = decimal.Parse(BasePay == "" ? "0" : BasePay);
            one.MeritPay = decimal.Parse(MeritPay == "" ? "0" : MeritPay);
            one.PerformanceRoyalty = decimal.Parse(PerformanceRoyalty == "" ? "0" : PerformanceRoyalty);
            one.Reward = decimal.Parse(Reward == "" ? "0" : Reward);
            one.Subsidies = decimal.Parse(Subsidies == "" ? "0" : Subsidies);
            one.BasePayDebit = decimal.Parse(BasePayDebit == "" ? "0" : BasePayDebit);
            one.AbsenceDutyDebit = decimal.Parse(AbsenceDutyDebit == "" ? "0" : AbsenceDutyDebit);
            one.PerformanceCoefficient = decimal.Parse(PerformanceCoefficient == "" ? "0" : PerformanceCoefficient);
            one.RealPerformance = decimal.Parse(RealPerformance == "" ? "0" : RealPerformance);
            one.Replenishment = decimal.Parse(Replenishment == "" ? "0" : Replenishment);
            one.Debit = decimal.Parse(Debit == "" ? "0" : Debit);
            one.ShouldSalary = decimal.Parse(ShouldSalary == "" ? "0" : ShouldSalary);
            one.Pension = decimal.Parse(Pension == "" ? "0" : Pension);
            one.MedicalCare = decimal.Parse(MedicalCare == "" ? "0" : MedicalCare);
            one.Unemployment = decimal.Parse(Unemployment == "" ? "0" : Unemployment);
            one.AccumulationFund = decimal.Parse(AccumulationFund == "" ? "0" : AccumulationFund);
            one.SocialSecurityTotal = decimal.Parse(SocialSecurityTotal == "" ? "0" : SocialSecurityTotal);
            one.CommunicationFee = decimal.Parse(CommunicationFee == "" ? "0" : CommunicationFee);
            one.IndividualIncomeTax = decimal.Parse(IndividualIncomeTax == "" ? "0" : IndividualIncomeTax);
            one.FinanceCharge = decimal.Parse(FinanceCharge == "" ? "0" : FinanceCharge);
            one.RealSalary = decimal.Parse(RealSalary == "" ? "0" : RealSalary);
            one.Updater = HozestERPContext.Current.User.CustomerID;
            one.UpdateDate = DateTime.Now;
            base.CustomerSalaryService.UpdateCustomerSalary(one);

            base.ShowMessage("保存成功！");
        }

        public void loadDate()
        {
            this.Face_Init();
            if (Type == 0)
            {
                this.btnSave.Visible = false;
            }
            var Info = base.CustomerSalaryService.GetCustomerSalaryByID(Id);
            var CustomerInfo = base.CustomerInfoService.GetCustomerInfoByID((int)Info.CustomerInfoID);
            this.txtDepartment.Text = CustomerInfo.DepartmentName;
            this.txtName.Text = CustomerInfo.FullName;
            this.txtIDNumber.Text = CustomerInfo.IDNumber;
            this.txtGender.Text = CustomerInfo.Gender == null ? "" : CustomerInfo.Gender.CodeName;

            this.txtBasePay.Text = Info.BasePay.ToString();
            this.txtMeritPay.Text = Info.MeritPay.ToString();
            this.txtPerformanceRoyalty.Text = Info.PerformanceRoyalty.ToString();
            this.txtReward.Text = Info.Reward.ToString();
            this.txtSubsidies.Text = Info.Subsidies.ToString();
            this.txtBasePayDebit.Text = Info.BasePayDebit.ToString();
            this.txtAbsenceDutyDebit.Text = Info.AbsenceDutyDebit.ToString();
            this.txtPerformanceCoefficient.Text = Info.PerformanceCoefficient.ToString();
            this.txtRealPerformance.Text = Info.RealPerformance.ToString();
            this.txtReplenishment.Text = Info.Replenishment.ToString();
            this.txtDebit.Text = Info.Debit.ToString();
            this.txtShouldSalary.Text = Info.ShouldSalary.ToString();
            this.txtPension.Text = Info.Pension.ToString();
            this.txtMedicalCare.Text = Info.MedicalCare.ToString();
            this.txtUnemployment.Text = Info.Unemployment.ToString();
            this.txtAccumulationFund.Text = Info.AccumulationFund.ToString();
            this.txtSocialSecurityTotal.Text = Info.SocialSecurityTotal.ToString();
            this.txtCommunicationFee.Text = Info.CommunicationFee.ToString();
            this.txtIndividualIncomeTax.Text = Info.IndividualIncomeTax.ToString();
            this.txtFinanceCharge.Text = Info.FinanceCharge.ToString();
            this.txtRealSalary.Text = Info.RealSalary.ToString();
        }

        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("ID");
            }
        }

        public int Type
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }

        public string Year
        {
            get
            {
                return CommonHelper.QueryString("Year");
            }
        }

        public string Month
        {
            get
            {
                return CommonHelper.QueryString("Month");
            }
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }
    }
}