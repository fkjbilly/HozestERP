using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Reflection;

using HozestERP.Web.Modules;
using HozestERP.Common.Utils;
using HozestERP.Common;

namespace HozestERP.Web.MasterPages
{
    public partial class CommonEditNoUpdatePanel : BaseAdministrationMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool SettrEditHeadVisible
        {
            set
            {
                this.trEditHead.Visible = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // 加自定义控件事件

            ((IEditPage)this.Page).Face_Init();
            ((IEditPage)this.Page).SetTrigger();

            Page.Header.Controls.Add(new LiteralControl(@"<script type=""text/javascript"" src=""" + CommonHelper.GetStoreLocation() + @"Script/CommonManager.js"" ></script>"));
            Page.Header.Controls.Add(new LiteralControl(@"<script type=""text/javascript"" src=""" + CommonHelper.GetStoreLocation() + @"Script/CommonEdit.js"" ></script>"));
            Page.Header.Controls.Add(new LiteralControl(@"<script type=""text/javascript"" src=""" + CommonHelper.GetStoreLocation() + @"Script/AjaxError.js"" ></script>"));
            this.imgExpand.Attributes.Add("onclick", "Expand('" + this.tdContentPlaceHolder1.ClientID + "','" + this.tdContentPlaceHolder01.ClientID + "',this);return false;");

        }

        public void SetTitle(string paramTitle)
        {
            this.lblTitle.Text = paramTitle;
            this.Page.Title = paramTitle;
        }


        public void SetEditHeadVisble(bool Visible)
        {
            this.trEditHead.Visible = Visible;
        }

        public override void ShowError(string message, string completeMessage)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + message + "');", true);
        }

        public override void ShowMessage(string message)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + message + "');", true);
        }
    }
}