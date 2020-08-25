using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using JdSdk.Domain;

namespace JdSdk.Response
{ 
   
    /// <summary>
    /// 根据条件检索订单信息 Response
    /// </summary>
    public class JindingLogisticsCompanyResponse : JdResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("delivery_logistics_get_response")]
        [JsonProperty("delivery_logistics_get_response")]
        public LogisticsCompanyResponse LC { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LogisticsCompanyResponse
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
        [XmlElement("logistics_companies")]
        [JsonProperty("logistics_companies")]
        public LogisticsCompany LogisticsCompany
        {
            get;
            set;
        }
    }
}
