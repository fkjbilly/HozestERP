using System;
using System.Linq;
using System.IO;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageProject;
using System.Collections.Generic;

namespace HozestERP.Web.ManageCustomer
{
    public partial class CustomerInfoAccount : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnProjectRole.Attributes.Add("onclick", "return ShowWindowDetail('设置人员权限','" + CommonHelper.GetStoreLocation() +
"ManageCustomer/SetRolesOfCustomer.aspx?CustomerID=" + this.CustomerID
+ "',300,500, this,'');");
                bind();
            }
        }

        void bind()
        {
            var themes = from f in Directory.GetDirectories(Server.MapPath("~/App_Themes"))
                         select Path.GetFileName(f);

            ddlThemes.DataSource = themes;
            ddlThemes.DataBind();

            var customer = base.CustomerService.GetCustomerById(this.CustomerID);

            this.ddlThemes.SelectedValue = customer.WorkingTheme;
            try
            {
                litDep.Text = customer.SCustomerInfo.SDepartment.DepName;
            }
            catch
            {
            }
            litUserName.Text = customer.Username;

            var roles = customer.SCustomerRoles;
            if (roles.Count > 0)
            {
                string rolename = string.Empty;
                foreach (var item in roles)
                {
                    rolename += item.Name + ",";
                }
                litRole.Text = rolename.Substring(0, rolename.Length - 1);
            }
            string project = "";
            List<string> List = new List<string>();
            List<int> ProjectIDList = new List<int>();
            var nicks = base.XMNickService.GetMyNickListByCustomerID(this.CustomerID);
            if (nicks != null && nicks.Count > 0)
            {
                foreach (XMNick parm in nicks)
                {
                    if (!List.Contains(parm.ProjectName))
                    {
                        List.Add(parm.ProjectName);
                        ProjectIDList.Add(parm.ProjectId.Value);
                    }
                }
            }
            if (List.Count > 0)
            {
                foreach (string s in List)
                {
                    project = project + s + ",";
                }
            }
            if (project.Length > 0)
            {
                project = project.Substring(0, project.Length - 1);
            }

            litProjectList.Text = project;

            if (ProjectIDList.Count > 0)
            {
                //将用户权限存到session中
                Session["ProjectIDs"] = ProjectIDList;
            }
            else
            {
                Session["ProjectIDs"] = null;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            var customer = base.CustomerService.GetCustomerById(this.CustomerID);
            customer.WorkingTheme = this.ddlThemes.SelectedItem.Value;
            base.ShowMessage("保存成功.");
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