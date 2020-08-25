using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Tasks;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class TimingGetOrderInfoIsUpdate : ITask
    {
        public void Execute(XmlNode node)
        {
            //判断是否1小时内同步过
            IoC.Resolve<IXMOrderInfoAPIService>().TimingGetOrderInfoIsUpdate();
        }
    }
}
