using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Audit;
using HozestERP.BusinessLogic.SEO;
using HozestERP.Common.Utils;

namespace HozestERP.Web
{
    public partial class BaseAdministrationPage : BasePage
    {
        #region Methods

        protected override void OnPreInit(EventArgs e)
        {
            //admin user validation
            if (this.AdministratorSecurityValidationEnabled &&
                !ValidateAdministratorSecurity())
            {
                string url = SEOHelper.GetAdminAreaLoginPageUrl();
                Response.Redirect(url);
            }

            //page security validation
            if (!ValidatePageSecurity())
            {
                string url = SEOHelper.GetAdminAreaAccessDeniedUrl();
                Response.Redirect(url);
            }

            if (this.IPAddressValidationEnabled && !ValidateIP())
            {
                Response.Redirect(SEOHelper.GetAdminAreaAccessDeniedUrl());
            }
            base.OnPreInit(e);
        }

        /// <summary>
        /// Validates page security for current user
        /// </summary>
        /// <returns>true if action is allow; otherwise false</returns>
        protected virtual bool ValidatePageSecurity()
        {
            return true;
        }

        /// <summary>
        /// Validates admin security
        /// </summary>
        /// <returns>true if admin access is allow; otherwise false</returns>
        protected virtual bool ValidateAdministratorSecurity()
        {
            if (HozestERPContext.Current == null ||
                HozestERPContext.Current.User == null ||
                HozestERPContext.Current.User.IsGuest)
                return false;

            return HozestERPContext.Current.User.IsAdmin;
        }

        protected virtual bool ValidateIP()
        {
            string ipList = this.SettingManager.GetSettingValue("Security.AdminAreaAllowedIP").Trim();
            if (String.IsNullOrEmpty(ipList))
            {
                return true;
            }
            foreach (string s in ipList.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (s.Trim().Equals(HozestERPContext.Current.UserHostAddress))
                {
                    return true;
                }
            }
            return false;
        }

        protected override void OnLoad(EventArgs e)
        {
            CommonHelper.EnsureSsl();
            base.OnLoad(e);
        }

        protected void ProcessException(Exception exc)
        {
            ProcessException(exc, true);
        }

        protected void ProcessException(Exception exc, bool showError)
        {
            this.LogService.InsertLog(LogTypeEnum.AdministrationArea, exc.Message, exc);
            if (showError)
            {
                if (this.SettingManager.GetSettingValueBoolean("Display.AdminArea.ShowFullErrors"))
                {
                    ShowError(exc.Message, exc.ToString());
                }
                else
                {
                    ShowError(exc.Message, string.Empty);
                }
            }
        }

        protected void ShowMessage(string message)
        {
            MasterPage masterPage = this.Master;
            if (masterPage == null)
                return;

            BaseAdministrationMasterPage baseAdministrationMasterPage = masterPage as BaseAdministrationMasterPage;
            if (baseAdministrationMasterPage != null)
                baseAdministrationMasterPage.ShowMessage(message);
        }

        protected void ShowError(string message)
        {
            ShowError(message, string.Empty);
        }

        protected void ShowError(string message, string completeMessage)
        {
            MasterPage masterPage = this.Master;
            if (masterPage == null)
                return;

            BaseAdministrationMasterPage baseAdministrationMasterPage = masterPage as BaseAdministrationMasterPage;
            if (baseAdministrationMasterPage != null)
                baseAdministrationMasterPage.ShowError(message, completeMessage);
        }

        protected override void RaisePostBackEvent(IPostBackEventHandler sourceControl, string eventArgument)
        {
            if ((sourceControl is Button) || (sourceControl is ImageButton))
            {
                bool haveRight = false;
                string FUNC_KeyWord = string.Empty;
                if (sourceControl is Button)
                {
                    FUNC_KeyWord = (sourceControl as Button).ID;
                }
                else if ((sourceControl is ImageButton))
                {
                    FUNC_KeyWord = (sourceControl as ImageButton).ID;
                }
                //当前按钮权限不存在情况，不作按钮权限限制
                if (!this.ButtonSecuritys.Keys.Contains(FUNC_KeyWord))
                {
                    base.RaisePostBackEvent(sourceControl, eventArgument);
                    return;
                }
                haveRight = base.ACLService.IsActionAllowed(this.ButtonSecuritys[FUNC_KeyWord]);
                if (haveRight)
                {
                    base.RaisePostBackEvent(sourceControl, eventArgument);
                }
                else
                {
                    //无权限的处理
                    //或提示或跳转等等
                    //System.Web.HttpContext.Current.Response.End();
                    this.ShowMessage("你没有该按钮的操作权限，请与管理联系。");
                }
            }
            else
            {
                base.RaisePostBackEvent(sourceControl, eventArgument);
            }
        }
        #endregion

        #region Properties

        protected virtual bool AdministratorSecurityValidationEnabled
        {
            get
            {
                return true;
            }
        }

        protected virtual bool IPAddressValidationEnabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 页面ID
        /// </summary>
        protected virtual int WebModuleID
        {
            get
            {
                return CommonHelper.QueryStringInt("WebModuleID");
            }
        }

        protected virtual Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                return new Dictionary<string, string>();
            }
        }
        #endregion
    }
}