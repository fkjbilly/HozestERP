using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JdSdk.Domain;
using JdSdk.Response;

namespace JdSdk.Request
{
    public class OrderVenderRemarkRequest : JdRequestBase<OrderVenderRemarkResponse>
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [XmlElement("order_id")]
        [JsonProperty("order_id")]
        public String OrderId
        {
            get;
            set;
        }

        public override String ApiName
        {
            get { return "jingdong.order.venderRemark.queryByOrderId"; }
        }

        protected override void PrepareParam(IDictionary<String, Object> paramters)
        {
            paramters.Add("order_id", this.OrderId);
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("order_id", this.OrderId);
        }
    }
}
