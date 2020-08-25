using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Profile;
using HozestERP.BusinessLogic.Configuration.Settings;

namespace HozestERP.Web.ManageSystem
{
    public partial class SettingsDetails : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var setting = base.SettingManager.GetSettingById(this.SettingID);
                if (setting != null)
                {
                    this.txtName.Text = setting.Name;
                    this.txtValue.Text = setting.Value;
                    this.txtDescription.Text = setting.Description;
                }
                else
                {
                    this.txtName.Text = string.Empty;
                    this.txtValue.Text = string.Empty;
                    this.txtDescription.Text = string.Empty;
                }
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("系统管理->系统通知详细信息");
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSave.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnDelete.UniqueID, this.Page);
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                base.SettingManager.SetParam(this.txtName.Text.Trim(), this.txtValue.Text.Trim(), this.txtDescription.Text.Trim());
                this.Master.JsWrite("alert('保存成功.');closeWindows();", "");
            }
        }

        public int SettingID
        {
            get
            {
                return CommonHelper.QueryStringInt("SettingID");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            base.SettingManager.DeleteSetting(this.SettingID);
            this.Master.JsWrite("alert('删除成功.');closeWindows();", "");
        }
    }
}