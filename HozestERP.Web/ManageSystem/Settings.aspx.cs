using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.Caching;

namespace HozestERP.Web.ManageSystem
{
    public partial class Settings : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitle("参数设置 > 系统参数");
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            this.Master.BindData<Setting>(this.grdNotice, base.SettingManager.GetAllSettings(this.txtName.Text.Trim(), paramPageIndex, paramPageSize));
        }

        public void BindGrid()
        {
            this.BindGrid(1, this.Master.PageSize);
        }

        #endregion



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }


        protected void grdNotice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgbtnDetail = (e.Row.FindControl("imgbtnDetail") as ImageButton);
                imgbtnDetail.OnClientClick = "return ShowDetail('SettingsDetails.aspx?SettingID=" + imgbtnDetail.CommandArgument.ToString() + "');";
                e.Row.Cells[1].Style.Add("word-break", "break-all");
            }
        }

        protected void grdNotice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void btnClearCache_Click(object sender, EventArgs e)
        {
            new HozestERPStaticCache().Clear();
        }
    }
}