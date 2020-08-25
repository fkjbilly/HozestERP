using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{

     /// <summary>
    /// PublicResultObjectRefundInfo 属性
    /// </summary>
    [Serializable]
    public class PublicResultObjectRefundInfo : JdObject
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("resultCode")]
        [JsonProperty("resultCode")]
        public Int64 ResultCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("resultErrorMsg")]
        [JsonProperty("resultErrorMsg")]
        public String ResultErrorMsg { get; set; }



        /// <summary>
        /// 退款详单明细 
        /// </summary>
        /// <example></example>
        [XmlElement("afsRefundInfoOut")]
        [JsonProperty("afsRefundInfoOut")]
        public AfsRefundInfoOut afsRefundInfoOuts
        {
            get;
            set;
        }
    }
}
