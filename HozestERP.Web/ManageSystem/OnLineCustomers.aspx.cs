using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

using HozestERP.BusinessLogic.Audit;
using HozestERP.BusinessLogic.Audit.UsersOnline;
using HozestERP.Common;

namespace HozestERP.Web.ManageSystem
{
    public partial class OnLineCustomers : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, this.Master.PageSize);
                this.cbEnabled.Checked = base.OnlineUserService.Enabled;
            }
        }

        //protected string GetCustomerInfo(OnlineUserInfo oui)
        //{
        //    string customerInfo = string.Empty;
        //    if (oui.AssociatedCustomerId.HasValue)
        //    {
        //        var customer = oui.AssociatedCustomer;
        //        if (customer != null)
        //        {
        //            customerInfo = string.Format("{0}", Server.HtmlEncode(customer.Username));
        //        }
        //        else
        //        {
        //            customerInfo = "游客";
        //        }
        //    }
        //    else
        //    {
        //        customerInfo = "游客";
        //    }

        //    return customerInfo;
        //}
        //protected string GetLocationInfo(OnlineUserInfo oui)
        //{
        //    string result = string.Empty;
        //    try
        //    {
        //        string countryName = GeoCountryLookup.LookupCountryName(oui.IPAddress);
        //        result = Server.HtmlEncode(countryName);
        //    }
        //    catch (Exception exc)
        //    {
        //        Debug.WriteLine(exc.ToString());
        //    }
        //    return result;
        //}
        //protected string GetLastPageVisitedInfo(OnlineUserInfo oui)
        //{
        //    string result = string.Empty;
        //    if (!String.IsNullOrEmpty(oui.LastPageVisited))
        //    {
        //        result = string.Format("<a href=\"{0}\" target=\"_blank\">{0}</a>", oui.LastPageVisited);
        //    }
        //    return result;
        //}
        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            this.Master.SetTitle("在线用户列表");
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var registeredUsers = this.OnlineUserService.GetRegisteredUsersOnline();
            if (!base.OnlineUserService.Enabled)
            {
                registeredUsers = new List<OnlineUserInfo>();
            }
            var users = new PagedList<OnlineUserInfo>(registeredUsers, paramPageIndex, paramPageSize);
            this.Master.BindData(this.gvCustomers, users);
        }

        #endregion

        protected void btnSet_Click(object sender, EventArgs e)
        {
            base.OnlineUserService.Enabled = this.cbEnabled.Checked;
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
    }
}