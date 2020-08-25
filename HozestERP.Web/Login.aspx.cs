using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;

namespace HozestERP.Web
{
    public partial class Login : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CommonHelper.SetResponseNoCache(Response);
        }



        public void OnLoggingIn(object sender, LoginCancelEventArgs e)
        {

        }

        protected void OnLoggedIn(object sender, EventArgs e)
        {
            //string str = string.Empty;
            //str = Page.Request.QueryString["ReturnUrl"];
            //if (string.IsNullOrEmpty(str))
            //    str = "~/default.aspx";

            //this.LoginForm.DestinationPageUrl = str;
        }

        protected void OnLoginError(object sender, EventArgs e)
        {
        }

        protected override bool AdministratorSecurityValidationEnabled
        {
            get
            {
                return false;
            }
        }

        protected override bool IPAddressValidationEnabled
        {
            get
            {
                return false;
            }
        }
    }
}