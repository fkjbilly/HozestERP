using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Tasks;
using System.Xml;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class GetChatLogs : ITask
    {
        public void Execute(XmlNode node)
        {
            IoC.Resolve<IKFChatLogService>().doJob();
        }
    }
}
