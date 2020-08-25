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
    public partial class SocialSecurityFundAdd : BaseAdministrationPage, IEditPage
    {
        public string Year;
        public string Month;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var one = base.SocialSecurityFundService.GetSocialSecurityFundByID(Id);
            Year = one.Year.ToString();
            Month = one.Month.ToString();

            string RankManagement = this.txtRankManagement.Text.Trim();
            string Post = this.txtPost.Text.Trim();
            string HouseholdRegister = this.txtHouseholdRegister.Text.Trim();
            string InsuranceType = this.txtInsuranceType.Text.Trim();

            string PensionBase = this.txtPensionBase.Text.Trim();
            string PensionCompany = this.txtPensionCompany.Text.Trim();
            string PensionPerson = this.txtPensionPerson.Text.Trim();
            string MedicalCareBase = this.txtMedicalCareBase.Text.Trim();
            string MedicalCareCompany = this.txtMedicalCareCompany.Text.Trim();
            string MedicalCarePerson = this.txtMedicalCarePerson.Text.Trim();
            string UnemploymentBase = this.txtUnemploymentBase.Text.Trim();
            string UnemploymentCompany = this.txtUnemploymentCompany.Text.Trim();
            string UnemploymentPerson = this.txtUnemploymentPerson.Text.Trim();
            string InjuryJobBase = this.txtInjuryJobBase.Text.Trim();
            string InjuryJobCompany = this.txtInjuryJobCompany.Text.Trim();
            string BirthBase = this.txtBirthBase.Text.Trim();
            string BirthCompany = this.txtBirthCompany.Text.Trim();
            string AccumulationFundBase = this.txtAccumulationFundBase.Text.Trim();
            string AccumulationCompany = this.txtAccumulationCompany.Text.Trim();
            string AccumulationFundPerson = this.txtAccumulationFundPerson.Text.Trim();
            string CompanyTotal = this.txtCompanyTotal.Text.Trim();
            string PersonTotal = this.txtPersonTotal.Text.Trim();
            string Total = this.txtTotal.Text.Trim();

            decimal a = 0;
            if (!decimal.TryParse(PensionBase, out a) || !decimal.TryParse(PensionCompany, out a) || !decimal.TryParse(PensionPerson, out a)
                || !decimal.TryParse(MedicalCareBase, out a) || !decimal.TryParse(MedicalCareCompany, out a) || !decimal.TryParse(MedicalCarePerson, out a)
                || !decimal.TryParse(UnemploymentBase, out a) || !decimal.TryParse(UnemploymentCompany, out a) || !decimal.TryParse(UnemploymentPerson, out a)
                || !decimal.TryParse(InjuryJobBase, out a) || !decimal.TryParse(InjuryJobCompany, out a)
                || !decimal.TryParse(BirthBase, out a) || !decimal.TryParse(BirthCompany, out a)
                || !decimal.TryParse(AccumulationFundBase, out a) || !decimal.TryParse(AccumulationCompany, out a) || !decimal.TryParse(AccumulationFundPerson, out a)
                || !decimal.TryParse(CompanyTotal, out a) || !decimal.TryParse(PersonTotal, out a) || !decimal.TryParse(Total, out a))
            {
                base.ShowMessage("输入的数值类型错误！");
                return;
            }

            one.RankManagement = RankManagement;
            one.Post = Post;
            one.HouseholdRegister = HouseholdRegister;
            one.InsuranceType = InsuranceType;
            one.PensionBase = decimal.Parse(PensionBase);
            one.PensionCompany = decimal.Parse(PensionCompany);
            one.PensionPerson = decimal.Parse(PensionPerson);
            one.MedicalCareBase = decimal.Parse(MedicalCareBase);
            one.MedicalCareCompany = decimal.Parse(MedicalCareCompany);
            one.MedicalCarePerson = decimal.Parse(MedicalCarePerson);
            one.UnemploymentBase = decimal.Parse(UnemploymentBase);
            one.UnemploymentCompany = decimal.Parse(UnemploymentCompany);
            one.UnemploymentPerson = decimal.Parse(UnemploymentPerson);
            one.InjuryJobBase = decimal.Parse(InjuryJobBase);
            one.InjuryJobCompany = decimal.Parse(InjuryJobCompany);
            one.BirthBase = decimal.Parse(BirthBase);
            one.BirthCompany = decimal.Parse(BirthCompany);
            one.AccumulationFundBase = decimal.Parse(AccumulationFundBase);
            one.AccumulationCompany = decimal.Parse(AccumulationCompany);
            one.AccumulationFundPerson = decimal.Parse(AccumulationFundPerson);
            one.CompanyTotal = decimal.Parse(CompanyTotal);
            one.PersonTotal = decimal.Parse(PersonTotal);
            one.Total = decimal.Parse(Total);
            one.Updater = HozestERPContext.Current.User.CustomerID;
            one.UpdateDate = DateTime.Now;
            base.SocialSecurityFundService.UpdateSocialSecurityFund(one);

            base.ShowMessage("保存成功！");
        }

        public void loadDate()
        {
            this.Face_Init();

            if (Type == 0)
            {
                this.btnSave.Visible = false;
            }
            var Info = base.SocialSecurityFundService.GetSocialSecurityFundByID(Id);
            var CustomerInfo = base.CustomerInfoService.GetCustomerInfoByID((int)Info.CustomerInfoID);
            Year = Info.Year.ToString();
            Month = Info.Month.ToString();

            this.txtDepartment.Text = CustomerInfo.DepartmentName;
            this.txtName.Text = CustomerInfo.FullName;
            this.txtRankManagement.Text = Info.RankManagement;
            this.txtPost.Text = Info.Post;
            this.txtHouseholdRegister.Text = Info.HouseholdRegister;
            this.txtInsuranceType.Text = Info.InsuranceType;
            this.txtPensionBase.Text = Info.PensionBase.ToString();
            this.txtPensionCompany.Text = Info.PensionCompany.ToString();
            this.txtPensionPerson.Text = Info.PensionPerson.ToString();
            this.txtMedicalCareBase.Text = Info.MedicalCareBase.ToString();
            this.txtMedicalCareCompany.Text = Info.MedicalCareCompany.ToString();
            this.txtMedicalCarePerson.Text = Info.MedicalCarePerson.ToString();
            this.txtUnemploymentBase.Text = Info.UnemploymentBase.ToString();
            this.txtUnemploymentCompany.Text = Info.UnemploymentCompany.ToString();
            this.txtUnemploymentPerson.Text = Info.UnemploymentPerson.ToString();
            this.txtInjuryJobBase.Text = Info.InjuryJobBase.ToString();
            this.txtInjuryJobCompany.Text = Info.InjuryJobCompany.ToString();
            this.txtBirthBase.Text = Info.BirthBase.ToString();
            this.txtBirthCompany.Text = Info.BirthCompany.ToString();
            this.txtAccumulationFundBase.Text = Info.AccumulationFundBase.ToString();
            this.txtAccumulationCompany.Text = Info.AccumulationCompany.ToString();
            this.txtAccumulationFundPerson.Text = Info.AccumulationFundPerson.ToString();
            this.txtCompanyTotal.Text = Info.CompanyTotal.ToString();
            this.txtPersonTotal.Text = Info.PersonTotal.ToString();
            this.txtTotal.Text = Info.Total.ToString();
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

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }
    }
}