using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.PlatOrderGrab
{
    public partial interface IVipapis
    {  
        /// <summary>
        /// 根据订单修改时间获取订单信息
        /// </summary>
        void GetVipOrderByModifyDate();
    }
}
