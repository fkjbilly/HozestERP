using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using HozestERP.BusinessLogic;
using System.Text;


namespace HozestERP.Web
{
    public partial class PersonSet : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitleTabPanelVisible = false;
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnPwdSave.UniqueID, this.Page);
        }

        #endregion

        protected void btnPwdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
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
                        base.CustomerService.ModifyPassword(HozestERPContext.Current.User.CustomerID, this.txtNewPwd.Text);
                        base.ShowMessage("密码已更改.");
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
    }
}