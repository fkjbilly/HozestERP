using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageSystem
{
    public partial class AlertSettings : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
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
            this.Master.SetTitle("参数设置 > 消息时间设置");
            this.Master.SetTitleVisible = false;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var alertTimeSet = base.SettingManager.GetAlertTimeSetList(HozestERPContext.Current.User.CustomerID, this.txtRmdname.Text.Trim(), paramPageIndex, paramPageSize);
            this.Master.BindData(grdAlertTimeSet, alertTimeSet); 
        }

        //public void BindGrid()
        //{
        //    this.BindGrid(1, this.Master.PageSize);
        //}

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
            var AlertSettingsIDs = this.Master.GetSelectedIds(this.grdAlertTimeSet);

            if (AlertSettingsIDs.Count <= 0)
            {
                base.ShowMessage("未选中任何项");
                return;
            }
            base.SettingManager.DeleteAlertSettings(AlertSettingsIDs);
            this.BindGrid(Master.PageIndex, Master.PageSize);

            base.ShowMessage("删除成功");
        }

        protected void grdAlertTimeSet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }


        protected void grdAlertTimeSet_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int alertTimeSetID = 0;
            int.TryParse(this.grdAlertTimeSet.DataKeys[e.RowIndex].Value.ToString(), out alertTimeSetID);

            var row = this.grdAlertTimeSet.Rows[e.RowIndex];
                DropDownList ddlCycletime = (row.FindControl("ddlCycletime") as DropDownList);
                
            var alertTimeSet = base.SettingManager.GetAlertTimeSetByID(alertTimeSetID);
            if (alertTimeSet != null)
            {
                alertTimeSet.Cycletime = int.Parse(ddlCycletime.SelectedValue);
                base.SettingManager.UpdateAlertTimeSet(alertTimeSet);
            }
            grdAlertTimeSet.EditIndex = -1;
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }


        protected void grdAlertTimeSet_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAlertTimeSet.EditIndex = e.NewEditIndex;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void grdAlertTimeSet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdAlertTimeSet.EditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }
    }
}