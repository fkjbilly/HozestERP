using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageBulletin;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageOA
{
    public partial class Bulletins : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }

        #region ISearchPage 成员

        /// <summary>
        /// 添加事件
        /// </summary>
        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitle("我的公告");
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            this.Master.BindData<Bulletin>(this.grdBulletin, base.BulletinService.GetBulletins(this.txtBulletinTitle.Text, -1, this.ddlBulletinType.SelectedValue, this.txtStartDateTime.SelectedDate
                , this.txtEndDateTime.SelectedDate, paramPageIndex, paramPageSize));
        }

        public void BindGrid()
        {
            this.BindGrid(1, this.Master.PageSize);
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void grdBulletin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgbtnDetail = (e.Row.FindControl("imgbtnDetail") as ImageButton);
                imgbtnDetail.OnClientClick = "return ShowDetail('" + CommonHelper.GetStoreLocation() + "BulletinsDetail.aspx?BulletinID=" + imgbtnDetail.CommandArgument.ToString() + "');";
            }
        }
    }
}