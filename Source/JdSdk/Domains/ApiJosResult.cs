using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JdSdk.Domain
{   
    /// <summary>
    /// ApiJosResult结构
    /// </summary>
    [Serializable]
    public class ApiJosResult : JdObject
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("result_code")]
        [JsonProperty("result_code")]
        public String ResultCode
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("result_describe")]
        [JsonProperty("result_describe")]
        public String ResultDescribe
        {
            get;
            set;
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        [XmlElement("success")]
        [JsonProperty("success")]
        public String Success
        {
            get;
            set;
        }
    }
}
