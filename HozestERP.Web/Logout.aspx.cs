using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.SEO;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.Web
{
    public partial class Logout : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CommonHelper.SetResponseNoCache(Response);

            this.CustomerService.Logout();

            string url = SEOHelper.GetAdminAreaLoginPageUrl();
            Response.Redirect(url);
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