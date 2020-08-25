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
    public partial class TwoCommonEdit : BaseAdministrationMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            //this.imgExpand.Attributes.Add("onclick", "Expand('" + this.tdContentPlaceHolder1.ClientID + "','" + this.tdContentPlaceHolder01.ClientID + "',this);return false;");

            string path = CommonHelper.GetStoreLocation() + "App_Themes/" + base.Page.Theme;
            this.JsBaseWrite("imgCloseExpandSrc='" + path + "/Image/btn2down.gif';", "InitUp");
            this.JsBaseWrite("imgOpenExpandSrc='" + path + "/Image/btn2up.gif';", "InitDown");
        }

        #region public void JsWrite(string paramAction, string parmaName)
        /// <summary>
        ///  写入JS脚本
        /// </summary>
        /// <param name="paramAction">内容</param>
        /// <param name="parmaName"></param>
        public void JsWrite(string paramAction, string parmaName)
        {
            if (ScriptManager.GetCurrent(this.Page).IsInAsyncPostBack)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.Page.GetType(), parmaName, paramAction, true);
            }
            else
            {
                this.JsBaseWrite(paramAction, parmaName);
            }
        }
        #endregion

        #region public void JsBaseWrite(string paramAction, string parmaName)
        /// <summary>
        ///  写入JS脚本
        /// </summary>
        /// <param name="paramAction">内容</param>
        /// <param name="parmaName"></param>
        public void JsBaseWrite(string paramAction, string parmaName)
        {
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string strCheckInput = paramAction;
            if (!cs.IsStartupScriptRegistered(cstype, parmaName))
            {
                cs.RegisterStartupScript(cstype, parmaName, strCheckInput, true);
            }
        }
        #endregion


        public void SetTrigger(string triggerId, Page currentPage)
        {
            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = triggerId;
            this.UpdatePanel1.Triggers.Add(trigger);
            if (ScriptManager.GetCurrent(currentPage).IsInAsyncPostBack) { triggerInitMethod.Invoke(trigger, null); }
        }


        private static MethodInfo triggerInitMethod = typeof(UpdatePanelTrigger).GetMethod("Initialize", BindingFlags.NonPublic | BindingFlags.Instance);

        public void SetTitle(string paramTitle)
        {
            this.lblTitle.Text = paramTitle;
            this.Page.Title = paramTitle;
        }

        public void SetLeftTitle(string paramTitle)
        {
            this.lblLeftTitle.Text = paramTitle;
        }


        public void SetEditHeadVisble(bool Visible)
        {
            this.trEditHead.Visible = Visible;
        }

        public override void ShowError(string message, string completeMessage)
        {
            this.JsWrite("alert('" + message  + "');", "EmptyData");
        }

        public override void ShowMessage(string message)
        {
            this.JsWrite("alert('" + message + "');", "EmptyData");
        }
    }
}