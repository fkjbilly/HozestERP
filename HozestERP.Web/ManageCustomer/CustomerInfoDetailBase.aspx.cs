using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Profile;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web.ManageCustomer
{
    public partial class CustomerInfoDetailBase : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Face_Init();
                if (this.CustomerID > 0)
                {
                    var customerinfo = base.CustomerInfoService.GetCustomerInfoByID(this.CustomerID);
                    
                    this.ddlDepartment.SelectedValue = customerinfo.DepartmentID.ToString();
                    this.txtJobNumber.Text = customerinfo.JobNumber;
                    this.txtFullName.Text = customerinfo.FullName;
                    this.ddlGender.SelectedValue = customerinfo.GenderID;
                    this.dllNationality.SelectedValue = customerinfo.NationalityID;
                    this.dllAnimal.SelectedValue = customerinfo.AnimalID;
                    this.txtRegisteredResidence.Text = customerinfo.RegisteredResidence;
                    this.txtBirthday.SelectedDate = customerinfo.Birthday;
                    this.dllMarriage.SelectedValue = customerinfo.MarriageID.GetValueOrDefault();
                    this.dllBloodType.SelectedValue = customerinfo.BloodTypeID;
                    this.dllPoliticalStatus.SelectedValue = customerinfo.PoliticalStatusID.GetValueOrDefault();
                    this.txtDisplayOrder.Value = customerinfo.DisplayOrder;
                    this.txtStature.Value = customerinfo.Stature;
                    this.btnIDNumber.Text = customerinfo.IDNumber;
                    CommonHelper.SelectListItem(this.ddlCustomerStatus, customerinfo.CustomerStatusID);
                  
                    if (customerinfo.Childbearing)
                    {
                        this.dllChildbearing.SelectedValue = "是";
                    }
                    else
                    {
                        this.dllChildbearing.SelectedValue = "否";
                    }
                    if (customerinfo.SCustomer != null)
                    {
                        this.chkActive.Checked = customerinfo.SCustomer.Active;
                    }
                }
                else
                {
                    this.Clear();
                }
            }
        }

        private void Clear()
        {
            ddlDepartment.SelectedValue = "0";
            this.txtJobNumber.Text = string.Empty;
            this.txtFullName.Text = string.Empty;
            this.ddlGender.SelectedValue = 0;
            this.dllNationality.SelectedValue = 0;
            this.dllAnimal.SelectedValue = 0;
            this.txtRegisteredResidence.Text = string.Empty;
            this.txtBirthday.SelectedDate = DateTime.Now;
            this.dllMarriage.SelectedValue = 0;
            this.dllBloodType.SelectedValue = 0;
            this.dllPoliticalStatus.SelectedValue = 0;
            this.txtStature.Value = 0;
            this.dllChildbearing.SelectedValue = "否";
        }

        public void Face_Init()
        {
            CommonMethod.DropDownListDepartment(this.ddlDepartment, false);

            CommonHelper.FillDropDownWithEnumDescription(this.ddlCustomerStatus, typeof(CustomerStatusEnum));
            this.ddlCustomerStatus.Enabled = this.SettingManager.GetSettingValueBoolean("CustomerInfo.CustomerStatus.IsEdit", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string IDNUmber = this.btnIDNumber.Text;
                int customerStatusID = 0;
                int.TryParse(this.ddlCustomerStatus.SelectedValue, out customerStatusID);

                if (this.CustomerID > 0)
                {
                    var info = base.CustomerInfoService.GetCustomerInfoByIDNumber(IDNUmber);
                    if (info != null && info.CustomerID != this.CustomerID)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "KeyIDNumber", "<script>alert('该身份证号已存在！');;</script>");
                        return;
                    }
                    var customerinfo = base.CustomerInfoService.GetCustomerInfoByID(this.CustomerID);
                    customerinfo.DepartmentID = int.Parse(ddlDepartment.SelectedValue);
                    customerinfo.JobNumber = this.txtJobNumber.Text.Trim();
                    customerinfo.Published = true;
                    customerinfo.FullName = this.txtFullName.Text.Trim();
                    customerinfo.GenderID = this.ddlGender.SelectedValue;
                    customerinfo.NationalityID = this.dllNationality.SelectedValue;
                    customerinfo.AnimalID = this.dllAnimal.SelectedValue;
                    customerinfo.RegisteredResidence = this.txtRegisteredResidence.Text.Trim();
                    customerinfo.IDNumber = IDNUmber;
                    if (this.txtBirthday.SelectedDate != null)
                    { 
                        customerinfo.Birthday = this.txtBirthday.SelectedDate.GetValueOrDefault(); 
                    }
                    else 
                    {
                        customerinfo.Birthday = DateTime.Now;
                    }
                    customerinfo.MarriageID = this.dllMarriage.SelectedValue;
                    customerinfo.BloodTypeID = this.dllBloodType.SelectedValue;
                    customerinfo.PoliticalStatusID = this.dllPoliticalStatus.SelectedValue;
                    customerinfo.DisplayOrder = this.txtDisplayOrder.Value;
                    customerinfo.Stature = this.txtStature.Value;
                    customerinfo.CustomerStatusID = customerStatusID;
                    if (this.dllChildbearing.SelectedValue == "是")
                    {
                        customerinfo.Childbearing = true;
                    }
                    else
                    {
                        customerinfo.Childbearing = false;
                    }

                    var customer = customerinfo.SCustomer;
                    customer.Active = this.chkActive.Checked;
                    base.CustomerService.UpdateCustomer(customer);
                    base.CustomerInfoService.UpdateCustomerInfo(customerinfo);
               
                }
                else
                {
                    bool childbearing = false;
                    if (this.dllChildbearing.SelectedValue == "是")
                    {
                        childbearing = true;
                    }
                    var returnCustomer = base.CustomerInfoService.InsertCustomerInfo(new CustomerInfo()
                    {
                        CustomerID = this.CustomerID,
                        DepartmentID = int.Parse(ddlDepartment.SelectedValue),
                        JobNumber = this.txtJobNumber.Text.Trim(),
                        Published = true,
                        FullName = this.txtFullName.Text.Trim(),
                        GenderID = this.ddlGender.SelectedValue,
                        NationalityID = this.dllNationality.SelectedValue,
                        AnimalID = this.dllAnimal.SelectedValue,
                        RegisteredResidence = this.txtRegisteredResidence.Text.Trim(),
                        Birthday = this.txtBirthday.SelectedDate.GetValueOrDefault(),
                        MarriageID = this.dllMarriage.SelectedValue,
                        BloodTypeID = this.dllBloodType.SelectedValue,
                        PoliticalStatusID = this.dllPoliticalStatus.SelectedValue,
                        DisplayOrder = this.txtDisplayOrder.Value,
                        Stature = this.txtStature.Value,
                        CustomerStatusID = customerStatusID,
                        Deleted = false,
                        Created = DateTime.Now,
                        CreatorID = HozestERPContext.Current.User.CustomerID,
                        Childbearing = childbearing,
                        IDNumber = IDNUmber
                    });
                }
                StringBuilder editButtonJs = new StringBuilder();
                editButtonJs.AppendLine(" alert('保存成功！'); location.replace(location.href);");
                Page.ClientScript.RegisterStartupScript(GetType(), "key", editButtonJs.ToString(), true);
            }
        }

        public int CustomerID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerID");
            }
        }

    }
}