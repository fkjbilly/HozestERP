using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JdSdk.Domain;
using JdSdk.Response;

namespace JdSdk.Response
{
    public class OrderVenderRemarkResponse : JdResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_order_venderRemark_queryByOrderId_responce")]
        [JsonProperty("jingdong_order_venderRemark_queryByOrderId_responce")]
        public VR VR { get; set; }
    }

    /// <summary>
    /// 根据条件检索订单信息 Response
    /// </summary>
    [Serializable]
    public class VR
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("venderRemarkQueryResult")]
        [JsonProperty("venderRemarkQueryResult")]
        public VenderRemarkQueryResult VenderRemarkQueryResult { get; set; }
    }
}
