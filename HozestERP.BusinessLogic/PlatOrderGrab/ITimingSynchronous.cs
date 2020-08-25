using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Domain;
using JdSdk;
using System.Net;
using JdSdk.Domain;
using JdSdk.Response;
using JdSdk.Domains;

namespace HozestERP.BusinessLogic.PlatOrderGrab
{
    public partial interface ITimingSynchronous
    {
        void TimingGetOrderInfo();//定时同步
    }
}
