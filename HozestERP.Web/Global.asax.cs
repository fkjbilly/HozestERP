using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using HozestERP.BusinessLogic.Configuration;
using HozestERP.BusinessLogic.Tasks;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Utils;
using HozestERP.BusinessLogic.Audit;
using HozestERP.BusinessLogic;

namespace HozestERP.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            HozestERPConfig.Init();

            //initialize IoC
            IoC.InitializeWith(new DependencyResolverFactory());

            //initialize task manager
            TaskManager.Instance.Initialize(HozestERPConfig.ScheduleTasks);
            TaskManager.Instance.Start();

            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HozestERPConfig.Init();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                IoC.Resolve<ILogService>().InsertLog(LogTypeEnum.Unknown, ex.Message, ex);
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

            TaskManager.Instance.Stop();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 24 * 60;
        }
    }
}