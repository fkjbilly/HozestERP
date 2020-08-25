using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Osp.Sdk;


namespace HozestERP.BusinessLogic.PlatOrderGrab
{
    public class Vipapis : IVipapis
    {
        /// <summary>
        /// 根据订单修改时间获取订单信息
        /// </summary>
        public void GetVipOrderByModifyDate() 
        {
            try
            {
                vipapis.delivery.DvdDeliveryServiceHelper.DvdDeliveryServiceClient client = new vipapis.delivery.DvdDeliveryServiceHelper.DvdDeliveryServiceClient();
                Osp.Sdk.Context.InvocationContext invocationContext = Osp.Sdk.Context.Factory.GetInstance();
                invocationContext.SetAppKey("861eb2e5");
                invocationContext.SetAppSecret("984CC95DF0CBDFDBB1019A74D90C0C48");
                invocationContext.SetAppURL("");
                invocationContext.SetAccessToken("your accessToken if you need");
                invocationContext.SetLanguage("the language code if you need");
                //System.Console.WriteLine(client.getOrderList(null, null, null, null, null, null, undefined, undefined));
            }
            catch (Osp.Sdk.Exception.OspException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
