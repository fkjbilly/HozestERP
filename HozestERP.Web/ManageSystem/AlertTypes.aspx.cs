using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Web.Modules;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.Common;

namespace HozestERP.Web.ManageSystem
{
    public partial class AlertTypes : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, this.Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            var AlertSettings = base.SettingManager.GetAllAlertSettings(this.txtRmdnameSearch.Text.Trim(), paramPageIndex, paramPageSize);
            
            if (this.RowEditIndex == -1)
            {
                this.grdAlertTypes.EditIndex = AlertSettings.Count();
                AlertSettings.Add(new BusinessLogic.Configuration.Settings.Sys_AlertSettings());
            }
            else
            {
                this.grdAlertTypes.EditIndex = this.RowEditIndex;
            }
            this.Master.BindData(this.grdAlertTypes, AlertSettings, paramPageSize + 1);
        }

        #endregion


        protected void grdAlertTypes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void grdAlertTypes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int alertTypeID = 0;
            int.TryParse(this.grdAlertTypes.DataKeys[e.RowIndex].Value.ToString(), out alertTypeID);
            base.SettingManager.DeleteAlertSettings(alertTypeID);
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("删除成功.");
        }

        protected void grdAlertTypes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void grdAlertTypes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int alertTypeID = 0;
            int.TryParse(this.grdAlertTypes.DataKeys[e.RowIndex].Value.ToString(), out alertTypeID);

            var row = this.grdAlertTypes.Rows[e.RowIndex];
            TextBox txtRmdname = row.FindControl("txtRmdname") as TextBox;
            TextBox txtRemarks = row.FindControl("txtRemarks") as TextBox;

            var alertTypes = base.SettingManager.GetAlertSettingsByID(alertTypeID);
            if (alertTypes != null)
            {
                alertTypes.Rmdname = txtRmdname.Text.Trim();
                alertTypes.Remarks = txtRemarks.Text.Trim();

                base.SettingManager.UpdateAlertSettings(alertTypes);
            }
            else
            {

                alertTypes = new BusinessLogic.Configuration.Settings.Sys_AlertSettings()
                {
                    
                    Rmdname = txtRmdname.Text.Trim(),
                    Remarks = txtRemarks.Text.Trim()
                };
                base.SettingManager.InsertAlertSettings(alertTypes);
            }
            this.RowEditIndex = -1;
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }


        public int RowEditIndex
        {
            get
            {
                int editIndex = -1;
                try
                {
                    int.TryParse(ViewState["RowEditIndex"].ToString(), out editIndex);
                }
                catch
                {
                }
                return editIndex;
            }
            set
            {
                ViewState["RowEditIndex"] = value;
            }
        }

        
    }
}