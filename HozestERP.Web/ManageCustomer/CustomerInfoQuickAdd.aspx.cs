using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;

using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Profile;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.Web.ManageCustomer
{
    public partial class CustomerInfoQuickAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CommonMethod.DropDownListDepartment(this.ddlDepartment, false);

                CommonHelper.FillDropDownWithEnumDescription(this.ddlCustomerStatus, typeof(CustomerStatusEnum));
                this.ddlCustomerStatus.Enabled = this.SettingManager.GetSettingValueBoolean("CustomerInfo.CustomerStatus.IsEdit", true);

                CommonMethod.DropDownListRole(this.ddlRole, false);
                //去除超级管理员选项
                for (int i = 0; i < this.ddlRole.Items.Count; i++)
                {
                    if (ddlRole.Items[i].Text == "Aadministrator")
                    {
                        ddlRole.Items.Remove(ddlRole.Items[i]);
                    }
                }
                this.Clear();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ddlDepartment.SelectedValue.Trim().Length == 0 || this.ddlDepartment.SelectedValue.Trim() == "0")
            {
                this.ShowMessage("请选择所属部门！");
                return;
            }
            if (Page.IsValid)
            {
                try
                {
                    MembershipCreateStatus createStatus = MembershipCreateStatus.Success;
                    string IDNUmber = this.btnIDNumber.Text;
                    string email = txtUserName.Text.Trim() + "@Hozest.com";
                    var sysCustomer = base.CustomerService.AddCustomer(email, txtUserName.Text.Trim(), txtPassword.Text.Trim(), true, false, true, out createStatus);

                    int customerStatusID = 0;
                    int.TryParse(this.ddlCustomerStatus.SelectedValue, out customerStatusID);

                    var info = base.CustomerInfoService.GetCustomerInfoByIDNum(IDNUmber);
                    if (info != null)
                    {
                        base.ShowMessage("该身份证号已存在！");
                        return;
                    }

                    var returnCustomer = base.CustomerInfoService.InsertCustomerInfo(new CustomerInfo()
                    {
                        CustomerID = sysCustomer.CustomerID,
                        DepartmentID = int.Parse(ddlDepartment.SelectedValue),
                        JobNumber="0",
                        Published = true,
                        Birthday=DateTime.Now,
                        FullName = this.txtFullName.Text.Trim(),
                        GenderID = this.ddlGender.SelectedValue,
                        CustomerStatusID = customerStatusID,
                        Deleted = false,
                        Created = DateTime.Now,
                        CreatorID = HozestERPContext.Current.User.CustomerID,
                        IDNumber = IDNUmber
                    });
                    
                    base.CustomerService.AddCustomerToRole(sysCustomer.CustomerID, int.Parse(ddlRole.SelectedValue));
                    base.ShowMessage("添加成功.");
                    this.Clear();
                }
                catch (Exception err)
                {
                    base.ProcessException(err);
                }
            }
        }

        private void Clear()
        {
            this.ddlDepartment.SelectedValue = "0";
            this.txtFullName.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.ddlGender.SelectedValue = 0;
            this.txtDueday.SelectedDate = DateTime.Now;
            this.ddlCustomerStatus.SelectedValue = "0";
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("添加用户");
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSave.UniqueID, this.Page);
        }

        #endregion

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (base.CustomerService.GetCustomerByUsername(txtUserName.Text.Trim())!=null)
            {
                args.IsValid = false;
                this.CustomValidator1.ErrorMessage = "当前用户名已经存在.";
            }
            else
            {
                args.IsValid = true;
                this.CustomValidator1.ErrorMessage = string.Empty;
            }
        }
    }
}