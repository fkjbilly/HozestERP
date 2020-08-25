using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.BusinessLogic.Notices;


namespace HozestERP.Web.ManageSystem
{
    public partial class Notes : BaseAdministrationPage, ISearchPage
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
            this.Master.SetTrigger(this.btnDelete.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitle("公司动态");
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            this.Master.BindData<Notice>(this.grdNotice, base.NoticeService.GetNotices(this.txtConent.Text, paramPageIndex, paramPageSize));
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> noticeIDs = this.Master.GetSelectedIds(this.grdNotice);

            if (noticeIDs.Count <= 0)
            {
                base.ShowMessage("未选中任何项");
                return;
            }
            base.NoticeService.DeleteNotice(noticeIDs);
            this.BindGrid();

            base.ShowMessage("删除成功");
        }

        protected void grdNotice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgbtnDetail = (e.Row.FindControl("imgbtnDetail") as ImageButton);
                imgbtnDetail.OnClientClick = "return ShowDetail('NotesDetails.aspx?ID=" + imgbtnDetail.CommandArgument.ToString() + "');";
            }
        }

        protected void grdNotice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                this.BindGrid();
            }
        }
    }
}