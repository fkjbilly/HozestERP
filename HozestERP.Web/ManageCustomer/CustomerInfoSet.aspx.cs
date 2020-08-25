using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;


namespace HozestERP.Web.ManageCustomer
{
    public partial class CustomerInfoSet : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!txtOldPwd.Visible)
                    txtOldPwd.Visible = true;
                else
                    txtOldPwd.Visible = false;
            }
        }


        protected void btnPwdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (txtOldPwd.Visible && string.IsNullOrEmpty(txtNewPwd.Text))
                    {
                        CommonHelper.MessageShow(this.Page, "原始密码不能为空");
                        return;
                    }
                    string oldPassword = txtOldPwd.Text;
                    string password = txtNewPwd.Text;
                    string confirmPassword = txtConfirmPassword.Text;
                    StringBuilder editButtonJs = new StringBuilder();
                    if (password != confirmPassword)
                    {
                        base.ShowError("输入的密码不匹配.");
                    }
                    else
                    {
                        var customer = base.CustomerService.GetCustomerById(this.CustomerID);
                        if (!txtOldPwd.Visible)
                        {
                            this.CustomerService.ModifyPassword(customer.Email, password);
                        }
                        else
                        {
                            this.CustomerService.ModifyPassword(customer.Email, oldPassword, password);
                        }
                        CommonHelper.MessageShow(this.Page, "密码已更改");
                    }
                    txtOldPwd.Text = string.Empty;
                    txtNewPwd.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                }
            }
            catch (Exception exc)
            {
                base.ShowError(Server.HtmlEncode(exc.Message));
            }
        }


        private int CustomerID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerID");
            }
        }
    }
}