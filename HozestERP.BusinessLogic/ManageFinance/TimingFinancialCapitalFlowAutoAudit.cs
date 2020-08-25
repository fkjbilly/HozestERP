using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Tasks;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class TimingFinancialCapitalFlowAutoAudit : ITask
    {
        public void Execute(XmlNode node)
        {
            IoC.Resolve<IXMFinancialCapitalFlowService>().TimingFinancialCapitalFlowAutoAduit();
        }
    }
}
