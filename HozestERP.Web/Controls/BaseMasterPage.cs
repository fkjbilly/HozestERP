using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Audit.UsersOnline;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.Audit;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ModuleManagement;

namespace HozestERP.Web
{
    public partial class BaseMasterPage : MasterPage
    {

        public BaseMasterPage()
        {

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

        public IModuleService ModuleService
        {
            get { return IoC.Resolve<IModuleService>(); }
        }
        #endregion
    }
}