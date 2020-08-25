#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-01-31 10:56:47:035 +08:00
*/
#endregion

using System.Xml.Serialization;
using JdSdk.Domain;
using Newtonsoft.Json;
using System;

namespace JdSdk.Response
{
    /// <summary>
    /// 根据条件检索订单信息 Response
    /// </summary>
    public class OrderSearchResponse : JdResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("order_search_response")]
        [JsonProperty("order_search_response")]
        public OrderSearchResponseChild Child { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class OrderSearchResponseChild
    {
        /// <summary>
        /// 订单数据
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// 订单数据
        /// </summary>
        [XmlElement("order_search")]
        [JsonProperty("order_search")]
        public OrderSearch OrderSearch
        {
            get;
            set;
        }
    }
}
