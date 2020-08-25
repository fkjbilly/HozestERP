using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Profile;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageSystem
{
    public partial class CustomerRoleDetails : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var customerRole = base.CustomerService.GetCustomerRoleById(this.CustomerRoleID);
                if (customerRole != null)
                {
                    this.txtName.Text = customerRole.Name;
                    this.txtDescription.Text = customerRole.Description;
                    this.chkActive.Checked = customerRole.Active;
                    this.ddlParentCustomerRole.SelectedValue = customerRole.ParentCustomerRoleID.ToString();
                }
                else
                {
                    this.txtName.Text = string.Empty;
                    this.txtDescription.Text = string.Empty;
                    this.chkActive.Checked = true;
                }
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("系统管理->角色详细信息");

            CommonMethod.DropDownListRole(this.ddlParentCustomerRole, true);
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSave.UniqueID, this.Page);
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var customerRole = base.CustomerService.GetCustomerRoleById(this.CustomerRoleID);
                if (customerRole != null)
                {
                    customerRole.Name = this.txtName.Text.Trim();
                    customerRole.Description = this.txtDescription.Text.Trim();
                    customerRole.Active = this.chkActive.Checked;
                    customerRole.ParentCustomerRoleID = int.Parse(this.ddlParentCustomerRole.SelectedValue);
                    base.CustomerService.UpdateCustomerRole(customerRole);
                }
                else
                {
                    base.CustomerService.InsertCustomerRole(new HozestERP.BusinessLogic.CustomerManagement.CustomerRole()
                    {
                        Name = this.txtName.Text,
                        Description = this.txtDescription.Text,
                        Code = string.Empty,
                        Deleted = false,
                        Active = this.chkActive.Checked,
                        CreateStaff = HozestERPContext.Current.User.CustomerID,
                        CreateDate = DateTime.Now,
                        ParentCustomerRoleID = int.Parse(this.ddlParentCustomerRole.SelectedValue)
                    });
                }
                this.Master.JsWrite("alert('保存成功.');window.parent.RefreshCustomerRoleTree();window.location='CustomerRoleDetails.aspx';", "");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var customerRole = new HozestERP.BusinessLogic.CustomerManagement.CustomerRole()
                {
                    Name = this.txtName.Text,
                    Description = this.txtDescription.Text,
                    Code = string.Empty,
                    Deleted = false,
                    Active = this.chkActive.Checked,
                    CreateStaff = HozestERPContext.Current.User.CustomerID,
                    CreateDate = DateTime.Now,
                    ParentCustomerRoleID = int.Parse(this.ddlParentCustomerRole.SelectedValue)
                };
                base.CustomerService.InsertCustomerRole(customerRole);
                this.Master.JsWrite("alert('保存成功.');window.parent.RefreshCustomerRoleTree();window.location='CustomerRoleDetails.aspx?CustomerRoleID=" + customerRole.CustomerRoleID + "';", "");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            base.CustomerService.MarkCustomerRoleAsDeleted(this.CustomerRoleID);
            this.Master.JsWrite("alert('删除成功.');window.parent.RefreshCustomerRoleTree();window.location='CustomerRoleDetails.aspx';", "");
        }

        public int CustomerRoleID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerRoleID");
            }
        }

    }
}