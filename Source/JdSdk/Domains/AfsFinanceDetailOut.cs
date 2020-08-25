using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{
    /// <summary>
    /// AfsFinanceDetailOut 属性
    /// </summary>
    [Serializable]
    public class AfsFinanceDetailOut : JdObject
    {
        /// <summary>
        ///  编号 
        /// </summary>
        [XmlElement("id")]
        [JsonProperty("id")]
        public Int64 id 
        {
            get;
            set;
        }

        /// <summary>
        ///  订单号 
        /// </summary>
        [XmlElement("orderId")]
        [JsonProperty("orderId")]
        public Int64 OrderId
        {
            get;
            set;
        }
        /// <summary>
        ///  商品编号 
        /// </summary>
        [XmlElement("wareId")]
        [JsonProperty("wareId")]
        public Int64 WareId
        {
            get;
            set;
        }
        /// <summary>
        ///  退款单据编号 
        /// </summary>
        [XmlElement("financeId")]
        [JsonProperty("financeId")]
        public Int64 FinanceId
        {
            get;
            set;
        }
        /// <summary>
        ///  退款金额 
        /// </summary>
        [XmlElement("refundMoney")]
        [JsonProperty("refundMoney")]
        public Int64 RefundMoney
        {
            get;
            set;
        }
        /// <summary>
        ///  支付金额 
        /// </summary>
        [XmlElement("payMoney")]
        [JsonProperty("payMoney")]
        public Int64 PayMoney
        {
            get;
            set;
        }
        /// <summary>
        ///  退款卡号 
        /// </summary>
        [XmlElement("refundNum")]
        [JsonProperty("refundNum")]
        public String RefundNum
        {
            get;
            set;
        }
        /// <summary>
        ///  开户名 
        /// </summary>
        [XmlElement("account")]
        [JsonProperty("account")]
        public String Account
        {
            get;
            set;
        }
        /// <summary>
        ///  支行 
        /// </summary>
        [XmlElement("bank")]
        [JsonProperty("bank")]
        public String Bank
        {
            get;
            set;
        }
        /// <summary>
        ///  创建时间 
        /// </summary>
        [XmlElement("createdDate")]
        [JsonProperty("createdDate")]
        public DateTime CreatedDate
        {
            get;
            set;
        }
         
         
    }
}
