using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using HozestERP.BusinessLogic;
using System.Text;

namespace HozestERP.Web.ManageSystem
{
    public partial class PsnAccount : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        void bind()
        {
            var themes = from f in Directory.GetDirectories(Server.MapPath("~/App_Themes"))
                         select Path.GetFileName(f);

            ddlThemes.DataSource = themes;
            ddlThemes.DataBind();

            this.ddlThemes.SelectedValue = HozestERPContext.Current.WorkingTheme;

            litDep.Text ="信息部";
            litUserName.Text = HozestERPContext.Current.User.Username;

            var roles = HozestERPContext.Current.User.SCustomerRoles;
            if (roles.Count > 0)
            {
                string rolename = string.Empty;
                foreach (var item in roles)
                {
                    rolename += item.Name + ",";
                }
                litRole.Text = rolename.Substring(0, rolename.Length - 1);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (HozestERPContext.Current != null ||
          HozestERPContext.Current.User != null ||
          !HozestERPContext.Current.User.IsGuest)
            {
                HozestERPContext.Current.User.WorkingTheme = this.ddlThemes.SelectedItem.Value;
            }
            base.ShowMessage("保存成功.");
        }
    }
}