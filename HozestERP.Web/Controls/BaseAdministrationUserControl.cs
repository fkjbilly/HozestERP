using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using HozestERP.BusinessLogic.Audit;

namespace HozestERP.Web
{
    public partial class BaseAdministrationUserControl : BaseUserControl
    {

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
            if (this.Page == null)
                return;

            MasterPage masterPage = this.Page.Master;
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
            if (this.Page == null)
                return;

            MasterPage masterPage = this.Page.Master;
            if (masterPage == null)
                return;

            BaseAdministrationMasterPage baseAdministrationMasterPage = masterPage as BaseAdministrationMasterPage;
            if (baseAdministrationMasterPage != null)
                baseAdministrationMasterPage.ShowError(message, completeMessage);
        }

    }
}