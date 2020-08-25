using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JdSdk.Response;

namespace JdSdk.Request
{ 
    /// <summary>
    /// 根据条件检索订单信息 Request
    /// </summary>
    public class JindingLogisticsCompanyRequest : JdRequestBase<JindingLogisticsCompanyResponse>
    {
        

        public override String ApiName
        {
            get { return "360buy.delivery.logistics.get"; }
        }

        protected override void PrepareParam(IDictionary<String, Object> paramters)
        {

           

        }

        public override void Validate()
        {
           
        }

    }
}
