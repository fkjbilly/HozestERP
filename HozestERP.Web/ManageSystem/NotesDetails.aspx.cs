using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Profile;
using HozestERP.BusinessLogic.Notices;

namespace HozestERP.Web.ManageSystem
{
    public partial class NotesDetails : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.ID.HasValue)
                {
                    var notice = base.NoticeService.GetNoticeByID(this.ID.GetValueOrDefault());
                    this.txtTitle.Text = notice.Title;
                    this.txtDateTime.SelectedDate = DateTimeHelper.ConvertToUserTime(notice.DateTime, DateTimeKind.Utc);
                    this.txtPromulgator.Text = notice.Promulgator;
                    this.txtStartTime.SelectedDate = DateTimeHelper.ConvertToUserTime(notice.StartTime, DateTimeKind.Utc);
                    this.txtDescription.Value = notice.Description;
                    this.chkPublished.Checked = notice.Published;
                }
                else
                {
                    this.txtTitle.Text = string.Empty;
                    this.txtDateTime.SelectedDate = DateTime.Now;
                    this.txtPromulgator.Text = string.Empty;
                    this.txtStartTime.SelectedDate = DateTime.Now;
                    this.txtDescription.Value = string.Empty;
                    this.chkPublished.Checked = true;
                }
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("公司动态 > 基本信息维护");
        }

        public void SetTrigger()
        {
           
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (this.ID.HasValue)
                {
                    var notice = base.NoticeService.GetNoticeByID(this.ID.GetValueOrDefault());
                    notice.Title = this.txtTitle.Text.Trim();
                    notice.DateTime = this.txtDateTime.SelectedDate.GetValueOrDefault();
                    notice.Published = this.chkPublished.Checked;
                    notice.StartTime = this.txtStartTime.SelectedDate.GetValueOrDefault();
                    notice.Description = this.txtDescription.Value;
                    base.NoticeService.UpdateNotice(notice);
                }
                else
                {
                    base.NoticeService.InsertNotice(new Notice() {
                        ID = Guid.NewGuid()
                        , Title = this.txtTitle.Text.Trim()
                        , DateTime = this.txtDateTime.SelectedDate.GetValueOrDefault()
                        , Published = this.chkPublished.Checked
                        , StartTime = this.txtStartTime.SelectedDate.GetValueOrDefault()
                        , Promulgator = this.txtPromulgator.Text
                        , Description = this.txtDescription.Value
                    });
                }
                base.ShowMessage("保存成功.");
                Response.Redirect("Notes.aspx");
            }
        }

        public Guid? ID
        {
            get
            {
                return CommonHelper.QueryStringGuid("ID");
            }
        }
    }
}