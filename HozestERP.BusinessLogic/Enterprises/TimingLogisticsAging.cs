using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Tasks;

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class TimingLogisticsAging : ITask
    {
        public void Execute(XmlNode node)
        {
            IoC.Resolve<ILogisticsAgingService>().TimingGetLogisticsAging();
        }
    }
}
