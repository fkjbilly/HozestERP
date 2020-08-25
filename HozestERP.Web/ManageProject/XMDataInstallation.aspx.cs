using HozestERP.BusinessLogic.ManageProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManageProject
{
    public partial class XMDataInstallation : BaseAdministrationPage, ISearchPage
    {
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

        }

        public void Face_Init()
        {

        }

        public void SetTrigger()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                this.BindddXMProject();//项目
                BindNick();
            }
        }

        private void BindGrid()
        {
            var data = XMInstallationListService.getInstallationFinish(-1, -1, "", "", "");
            Store1.DataSource = data;
            Store1.DataBind();
        }

        private void BindddXMProject()
        {
            ddXMProject.Items.Clear();
            var projectList = base.XMProjectService.GetXMProjectList();
            Ext.Net.Store Store = ddXMProject.GetStore();
            projectList.Add(new XMProject()
            {
                ProjectName = "---所有---",
                Id = -1,
            });
            Store.DataSource = projectList.OrderBy(a => a.Id);
            Store.DataBind();
            ddXMProject.SelectedIndex = 0;
            ddXMProject.Value = "-1";
        }

        private void BindNick()
        {
            ddlNick2.Items.Clear();
            var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(ddXMProject.Value));
            Ext.Net.Store Store = ddlNick2.GetStore();
            nickList.Add(new XMNick()
            {
                nick = "---所有---",
                nick_id = -1,
            });
            Store.DataSource = nickList.OrderBy(a => a.nick_id);
            Store.DataBind();
            ddlNick2.SelectedIndex = 0;
            ddlNick2.Value = "-1";
        }

        protected void ddXMProject2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddXMProject.Value.ToString().Trim().Length > 0)
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(ddXMProject.Value));
                ddlNick2.Items.Clear();
                Ext.Net.Store Store = ddlNick2.GetStore();
                nickList.Add(new XMNick()
                {
                    nick = "---所有---",
                    nick_id = -1,
                });
                Store.DataSource = nickList.OrderBy(a => a.nick_id);
                Store.DataBind();
                ddlNick2.SelectedIndex = 0;
                if (!Page.IsPostBack)
                {
                    ddlNick2.Value = "-1";
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int projectID= Convert.ToInt32(this.ddXMProject.Value.ToString().Trim());
            int nickID= Convert.ToInt32(this.ddlNick2.Value.ToString());//店铺
            string worker = txtWork.Text.Trim();
            string start = txtCreateDateBegin.Value.Trim();
            string end = txtCreateDateEnd.Value.Trim();
            var data = XMInstallationListService.getInstallationFinish(projectID, nickID, start, end, worker);
            Store1.DataSource = data;
            Store1.DataBind();
            this.BindddXMProject();//项目
            BindNick();
            ddXMProject.Value = projectID.ToString();
            ddlNick2.Value = nickID.ToString();
        }
    }
}