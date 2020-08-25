using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.BusinessLogic.Audit;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Profile;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageSystem
{
    public partial class LogDetails : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Log log = this.LogService.GetLogById(this.LogId);
            if (log != null)
            {
                this.lblLogType.Text = Server.HtmlEncode(log.LogType.ToString());
                this.lblSeverity.Text = log.Severity.ToString();
                this.lblMessage.Text = Server.HtmlEncode(log.Message);
                this.lblException.Text = Server.HtmlEncode(log.Exception);
                this.lblIPAddress.Text = Server.HtmlEncode(log.IPAddress);
                Customer customer = log.Customer;
                if (customer != null)
                    this.lblCustomer.Text = Server.HtmlEncode(customer.Email);
                lblPageURL.Text = Server.HtmlEncode(log.PageURL);
                lblReferrerURL.Text = Server.HtmlEncode(log.ReferrerURL);
                this.lblCreatedOn.Text = DateTimeHelper.ConvertToUserTime(log.CreatedOn, DateTimeKind.Utc).ToString();
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("查看活动日志详细信息");
            this.Master.SettrEditHeadVisible = false;
        }

        public void SetTrigger()
        {
        }

        #endregion


        public int LogId
        {
            get
            {
                return CommonHelper.QueryStringInt("LogId");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            this.LogService.DeleteLog(this.LogId);
            Response.Redirect("Logs.aspx");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logs.aspx");
        }
    }
}