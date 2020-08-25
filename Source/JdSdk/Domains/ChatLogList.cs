using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{ 
    /// <summary>
    /// ChatLog 属性
    /// </summary>
    [Serializable]
    public class ChatLogList : JdObject
    { 
        /// <summary>
        /// 咨询的顾客
        /// </summary>
        [XmlElement("customer")]
        [JsonProperty("customer")]
        public String Customer
        {
            get;
            set;
        }

        /// <summary>
        /// 客服账号
        /// </summary>
        [XmlElement("waiter")]
        [JsonProperty("waiter")]
        public String Waiter
        {
            get;
            set;
        }

        /// <summary>
        /// 聊天内容。
        /// </summary>
        [XmlElement("content")]
        [JsonProperty("content")]
        public String Content
        {
            get;
            set;
        }

        /// <summary>
        /// 会话ID。
        /// </summary>
        [XmlElement("sid")]
        [JsonProperty("sid")]
        public String Sid
        {
            get;
            set;
        }

        /// <summary>
        /// 商品id
        /// </summary>
        [XmlElement("skuId")]
        [JsonProperty("skuId")]
        public Int64 SkuId
        {
            get;
            set;
        }

        /// <summary>
        /// 消息发送时间
        /// </summary>
        [XmlElement("time")]
        [JsonProperty("time")]
        public Int64 Time
        {
            get;
            set;
        }

        /// <summary>
        /// 消息通道。
        /// </summary>
        [XmlElement("channel")]
        [JsonProperty("channel")]
        public Int64 Channel
        {
            get;
            set;
        }

        /// <summary>
        /// 是否是客服发送的
        /// </summary>
        [XmlElement("waiterSend")]
        [JsonProperty("waiterSend")]
        public Nullable<Boolean> WaiterSend
        {
            get;
            set;
        }
    }
}
