using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HozestERP.WebApi.Entities
{
    public class OrderStatus
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }
    }
}