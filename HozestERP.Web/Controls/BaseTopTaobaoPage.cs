using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Audit.UsersOnline;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.Audit;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ModuleManagement;
using HozestERP.BusinessLogic.Security;
using HozestERP.BusinessLogic.Notices;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Media;
using HozestERP.BusinessLogic.ExportImport;
using HozestERP.BusinessLogic.ManageProtal;
using HozestERP.BusinessLogic.ManageFile;
using HozestERP.BusinessLogic.ManageTableLog; 


namespace HozestERP.Web
{
    public partial class BaseTopTaobaoPage : System.Web.UI.Page
    {

        public BaseTopTaobaoPage()
        {

        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            //theme
            if (!String.IsNullOrEmpty(HozestERPContext.Current.TopTaobaoTheme))
            {
                this.Theme = HozestERPContext.Current.TopTaobaoTheme;
            }
            this.Error += new EventHandler(BasePage_Error);
        }

        void BasePage_Error(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Gets a value indicating whether this page is tracked by 'Online Customers' module
        /// </summary>
        public virtual bool TrackedByOnlineCustomersModule
        {
            get
            {
                return true;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            //online user tracking
            if (this.TrackedByOnlineCustomersModule)
            {
                this.OnlineUserService.TrackCurrentUser();
            }

            base.OnPreRender(e);
        }

        #region Services, managers

        public IOnlineUserService OnlineUserService
        {
            get { return IoC.Resolve<IOnlineUserService>(); }
        }

        public ISettingManager SettingManager
        {
            get { return IoC.Resolve<ISettingManager>(); }
        }

        public ILogService LogService
        {
            get { return IoC.Resolve<ILogService>(); }
        }

        public ICustomerService CustomerService
        {
            get { return IoC.Resolve<ICustomerService>(); }
        }

        public ICustomerInfoService CustomerInfoService
        {
            get { return IoC.Resolve<ICustomerInfoService>(); }
        }

        public IModuleService ModuleService
        {
            get { return IoC.Resolve<IModuleService>(); }
        }

        public IACLService ACLService
        {
            get { return IoC.Resolve<IACLService>(); }
        }

        public INoticeService NoticeService
        {
            get { return IoC.Resolve<INoticeService>(); }
        }

        public IEnterpriseService EnterpriseService
        {
            get { return IoC.Resolve<IEnterpriseService>(); }
        }

        public ICodeTypeService CodeTypeService
        {
            get { return IoC.Resolve<ICodeTypeService>(); }
        }

        public ICodeService CodeService
        {
            get { return IoC.Resolve<ICodeService>(); }
        }

        public IAreaCodeService AreaCodeService
        {
            get { return IoC.Resolve<IAreaCodeService>(); }
        }

        public IPictureService PictureService
        {
            get { return IoC.Resolve<IPictureService>(); }
        }

        public IPortalService PortalService
        {
            get { return IoC.Resolve<IPortalService>(); }
        }

    

        public IFileService FileService
        {
            get { return IoC.Resolve<IFileService>(); }
        }

        public ITableUpdateLogService TableUpdateLogService
        {
            get { return IoC.Resolve<ITableUpdateLogService>(); }
        }

     

        public IImportManager ImportManager
        {
            get { return IoC.Resolve<IImportManager>();}
        }

        public IExportManager ExportManager
        {
            get { return IoC.Resolve<IExportManager>(); }
        }

        

     

        #endregion
    }
}
