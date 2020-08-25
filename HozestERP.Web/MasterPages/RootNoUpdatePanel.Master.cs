using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Collections;
using System.Data;

using HozestERP.Common.Utils;
using HozestERP.Common;
using HozestERP.Web.Modules;

namespace HozestERP.Web.MasterPages
{
    public partial class RootNoUpdatePanel : BaseAdministrationMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// 
        /// </summary>
        public bool SetSearchPanelVisible
        {
            set
            {
                if (value)
                {
                    this.SearchTab.Style.Add("display", "");
                }
                else
                {
                    this.SearchTab.Style.Add("display", "none");
                }
            }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public void SetTitle(string paramTitle)
        {
            this.lblTitle.Text = paramTitle;
            this.Page.Title = paramTitle;
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            ((ISearchPage)this.Page).Face_Init();

            SetJsPageLoad();

            Page.Header.Controls.Add(new LiteralControl(@"<script type=""text/javascript"" src=""" + CommonHelper.GetStoreLocation() + @"Script/CommonManager.js"" ></script>"));
            Page.Header.Controls.Add(new LiteralControl(@"<script type=""text/javascript"" src=""" + CommonHelper.GetStoreLocation() + @"Script/AjaxError.js"" ></script>"));
            //Page.Header.Controls.Add(new LiteralControl(@"<script type=""text/javascript"" src=""" + CommonHelper.GetStoreLocation() + @"Script/popup.js"" ></script>"));
           
        }


        #region public void JsWrite(string paramAction, string parmaName)
        /// <summary>
        ///  写入JS脚本
        /// </summary>
        /// <param name="paramAction">内容</param>
        /// <param name="parmaName"></param>
        public void JsWrite(string paramAction, string parmaName)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), parmaName, paramAction, true);
     
        }
        #endregion

        #region public void SetJsPageLoad()
        /// <summary>
        /// 设置JS加载，如果页面没传宽度就取当前的，如果传 了就按传过来的
        /// </summary>
        public void SetJsPageLoad()
        {
            string width = "";
            string height = "";
            if (Request["width"] != null && Request["width"].ToString().Length > 0)
            {
                width = Request["width"].ToString();
            }
            if (Request["height"] != null && Request["height"].ToString().Length > 0)
            {
                height = Request["height"].ToString();
            }

            JsWrite("PageLoad('" + width + "','" + height + "');", "InitPage");
        }
        #endregion

        protected void ScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            this.ScriptManager1.AsyncPostBackErrorMessage = "系统在执行中遇到错误,原因如下：" + e.Exception.Message;
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