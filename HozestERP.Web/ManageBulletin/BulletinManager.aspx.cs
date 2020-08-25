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
    public partial class BulletinManager : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.btnAdd.OnClientClick = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageBulletin/BulletinDetail.aspx','BulletinDetail','公告通知新增');";
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
            this.Master.SetTrigger(this.btnReleased.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnEnd.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitle("公共事务 > 公告管理");
            this.Master.SetTitleVisible = false;
            CommonHelper.FillDropDownStatusDescription(this.ddlBulletinStatus, typeof(BulletinStatusEnum), true
             , BulletinStatusEnum.Found.ToString()
             , BulletinStatusEnum.Released.ToString()
             , BulletinStatusEnum.End.ToString()
             );
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            this.Master.BindData<Bulletin>(this.grdBulletin, base.BulletinService.GetBulletinByCustomerID(HozestERPContext.Current.User.CustomerID, this.txtBulletinTitle.Text, int.Parse(this.ddlBulletinStatus.SelectedValue), this.ddlBulletinType.SelectedValue, this.txtStartDateTime.SelectedDate
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> BulletinIDs = new List<int>();

            for (int i = 0; i < this.grdBulletin.Rows.Count; i++)
            {
                CheckBox myChk = (CheckBox)this.grdBulletin.Rows[i].FindControl("chkSelected");
                if (myChk != null)
                {
                    if (myChk.Checked)
                    {
                        int itemID = 0;
                        int.TryParse(this.grdBulletin.DataKeys[i].Value.ToString(), out itemID);
                        BulletinIDs.Add(itemID);
                    }
                }
            }

            if (BulletinIDs.Count <= 0)
            {
                base.ShowMessage("未选中任何项");
                return;
            }
            base.BulletinService.DeleteBulletin(BulletinIDs);
            base.ShowMessage("删除成功.");
            this.BindGrid();

        }

        protected void grdBulletin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var bulletin = e.Row.DataItem as Bulletin;

                ImageButton imgbtnDetail = (e.Row.FindControl("imgbtnDetail") as ImageButton);
                if (bulletin.BulletinStatuss == BulletinStatusEnum.End)
                {
                    CheckBox myCheckBox = (e.Row.FindControl("chkSelected") as CheckBox);
                    myCheckBox.Visible = false;
                    e.Row.Cells[3].Style.Add("color", "red");
                }
                if (bulletin.BulletinStatuss == BulletinStatusEnum.Found)
                {
                    imgbtnDetail.OnClientClick = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageBulletin/BulletinDetail.aspx?BulletinID=" + imgbtnDetail.CommandArgument.ToString() + "','BulletinDetail" + imgbtnDetail.CommandArgument.ToString() + "','公告通知维护');";
                }
                else
                {
                    imgbtnDetail.OnClientClick = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManagePortlet/BulletinsDetail.aspx?BulletinID=" + imgbtnDetail.CommandArgument.ToString() + "', 'BulletinsDetail" + imgbtnDetail.CommandArgument.ToString() + "','" + bulletin.BulletinTitle + "');";
                }
            }
        }

        protected void grdBulletin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                this.BindGrid();
            }
        }

        protected void btnReleased_Click(object sender, EventArgs e)
        {
            List<int> BulletinIDs = new List<int>();

            for (int i = 0; i < this.grdBulletin.Rows.Count; i++)
            {
                CheckBox myChk = (CheckBox)this.grdBulletin.Rows[i].FindControl("chkSelected");
                if (myChk != null)
                {
                    if (myChk.Checked)
                    {
                        int itemID = 0;
                        int.TryParse(this.grdBulletin.DataKeys[i].Value.ToString(), out itemID);

                        var b = base.BulletinService.GetBulletinByBulletinID(itemID);
                        BulletinIDs.Add(itemID);
                    }
                }
            }

            if (BulletinIDs.Count <= 0)
            {
                base.ShowMessage("未选中任何项");
                return;
            }
            base.BulletinService.bulletinReleased(BulletinIDs);
            this.BindGrid();
            base.ShowMessage("公告发布成功");
        }

        protected void btnEnd_Click(object sender, EventArgs e)
        {
            List<int> BulletinIDs = new List<int>();

            for (int i = 0; i < this.grdBulletin.Rows.Count; i++)
            {
                CheckBox myChk = (CheckBox)this.grdBulletin.Rows[i].FindControl("chkSelected");
                if (myChk != null)
                {
                    if (myChk.Checked)
                    {
                        int itemID = 0;
                        int.TryParse(this.grdBulletin.DataKeys[i].Value.ToString(), out itemID);
                        BulletinIDs.Add(itemID);
                    }
                }
            }

            if (BulletinIDs.Count <= 0)
            {
                base.ShowMessage("未选中任何项");
                return;
            }
            base.BulletinService.bulletinEnd(BulletinIDs);
            this.BindGrid();

            base.ShowMessage("终止成功");

        }
    }
}