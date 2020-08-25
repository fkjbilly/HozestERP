using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using HozestERP.BusinessLogic.Enterprises;

namespace HozestERP.Web.ManageSystem
{
    public partial class Enterprises : BaseAdministrationPage, ISearchPage
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
            this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnDelete.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitle("参数设置 > 集团公司");
            this.Master.SetTitleVisible = false;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            this.Master.BindData<Enterprise>(this.grdEnterprise, base.EnterpriseService.GetEnterprise(this.txtConent.Text, paramPageIndex, paramPageSize));
        }

        public void BindGrid()
        {
            this.BindGrid(1, this.Master.PageSize);
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var enterpriseIDs = this.Master.GetSelectedIds(this.grdEnterprise);

            if (enterpriseIDs.Count <= 0)
            {
                base.ShowMessage("未选中任何项");
                return;
            }
            base.EnterpriseService.DeleteEnterprise(enterpriseIDs);
            this.BindGrid(Master.PageIndex, Master.PageSize);

            base.ShowMessage("删除成功");
        }

        protected void grdNotice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgbtnDetail = (e.Row.FindControl("imgbtnDetail") as ImageButton);
                imgbtnDetail.OnClientClick = "return ShowDetail('EnterprisesDetails.aspx?EntId=" + imgbtnDetail.CommandArgument.ToString() + "');";
            }
        }

        protected void grdNotice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }
    }
}