using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JdSdk.Response;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Request
{
    
    /// <summary>
    /// 订单SOP出库 Request
    /// </summary>
    public class JindingOutstorageRequest : JdRequestBase<JindingOutstoragePesponse>
    {
        /// <summary>
        /// 订单id
        /// </summary> 
        [XmlElement("order_id")]
        [JsonProperty("order_id")]
        public string OrderId
        {
            get;
            set;
        }

        /// <summary>
        /// 物流公司ID(只可通过获取商家物流公司接口获得),多个物流公司以|分隔
        /// </summary> 
        [XmlElement("logistics_id")]
        [JsonProperty("logistics_id")]
        public string LogisticsId
        {
            get;
            set;
        }

        /// <summary>
        /// 运单号(当厂家自送时运单号可为空，不同物流公司的运单号用|分隔，如果同一物流公司有多个运单号，则用英文逗号分隔)
        /// </summary>
        /// <example>1200458628372,111232|468778814888,323232323</example>
        [XmlElement("waybill")]
        [JsonProperty("waybill")]
        public String Waybill
        {
            get;
            set;
        }

        /// <summary>
        /// 流水号
        /// </summary>
        /// <example>1</example>
        [XmlElement("trade_no")]
        [JsonProperty("trade_no")]
        public string TradeNo
        {
            get;
            set;
        }
         
        public override String ApiName
        {
             get { return "360buy.order.sop.outstorage"; } 
        }

        protected override void PrepareParam(IDictionary<String, Object> paramters)
        {

            paramters.Add("order_id", this.OrderId);
            paramters.Add("logistics_id", this.LogisticsId);
            paramters.Add("waybill", this.Waybill); 

        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("order_id", this.OrderId);
            RequestValidator.ValidateRequired("logistics_id", this.LogisticsId);
            RequestValidator.ValidateRequired("waybill", this.Waybill);
        }

    }
}
