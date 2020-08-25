using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageBulletin;
using HozestERP.BusinessLogic.Profile;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManagePortlet
{
    public partial class BulletinsDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var bulletin = IoC.Resolve<BulletinService>().GetBulletinByBulletinID(this.BulletinID);
            if (bulletin != null)
            {
                this.lblTitle.Text = bulletin.BulletinTitle;
                this.lblPriorType.Text = bulletin.PriorType != null ? bulletin.PriorType.CodeName : "";
                this.lblBulletinType.Text = bulletin.BulletinType != null ? bulletin.BulletinType.CodeName : "";
                this.lblPromulgator.Text = bulletin.CreatorFullName;
                this.lblDescription.Text = bulletin.Remark;
                this.lblDateTime.Text = bulletin.ReleasedDate.ToString("yyyy-MM-dd HH:mm");
                this.downloadfile.ObjectID = this.BulletinID;
                this.downloadfile.TaggantID = Guid.NewGuid();
            }

        }

        private int BulletinID
        {
            get
            {
                return CommonHelper.QueryStringInt("BulletinID");
            }
        }
    }
}