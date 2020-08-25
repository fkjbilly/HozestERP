using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class TimingDeliveryLogistics : ITask
    {
        public void Execute(XmlNode node)
        {
            IoC.Resolve<IXMDeliveryService>().DeliveryLogisticsCheck();
        }
    }
}
