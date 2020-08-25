using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Tasks;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class TimingGetXMOrderInfo : ITask
    {
        public void Execute(XmlNode node)
        {
            //同步订单
            IoC.Resolve<IXMOrderInfoAPIService>().TimingGetOrderInfo();
        }
    }
}
