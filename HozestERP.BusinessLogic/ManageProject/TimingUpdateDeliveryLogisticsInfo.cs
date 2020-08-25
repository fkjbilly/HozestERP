using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Tasks;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class TimingUpdateDeliveryLogisticsInfo : ITask
    {
        public void Execute(XmlNode node)
        {
            XLMInterface xLMInterface = new BusinessLogic.ManageProject.XLMInterface();
            xLMInterface.UpdateDeliveryLogisticsInfo();
        }
    }
}
