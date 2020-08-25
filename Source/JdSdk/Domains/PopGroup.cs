using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using JdSdk.Domain;

namespace JdSdk.Domains
{

    [Serializable]
    public class PopGroup : JdObject
    {
        /// <summary>
        /// 店铺名字
        /// </summary>
        /// <example></example>
        [XmlElement("shopName")]
        [JsonProperty("shopName")]
        public String ShopName
        {
            get;
            set;
        }

        /// <summary>
        /// 店铺主页
        /// </summary>
        /// <example></example>
        [XmlElement("shopUrl")]
        [JsonProperty("shopUrl")]
        public String ShopUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 客服数量
        /// </summary>
        /// <example></example>
        [XmlElement("waiterCount")]
        [JsonProperty("waiterCount")]
        public Int64 WaiterCount
        {
            get;
            set;
        }

        /// <summary>
        /// 客服列表
        /// </summary>
        /// <example></example>
        [XmlElement("waiterList")]
        [JsonProperty("waiterList")]
        public Waiter[] WaiterList
        {
            get;
            set;
        }
    }
}
