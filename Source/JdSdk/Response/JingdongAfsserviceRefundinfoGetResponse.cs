using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using JdSdk.Domains;

namespace JdSdk.Response
{
    public class JingdongAfsserviceRefundinfoGetResponse : JdResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_afsservice_refundinfo_get_responce")]
        [JsonProperty("jingdong_afsservice_refundinfo_get_responce")]
        public  PRORI PRORI { get; set; }


    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PRORI
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code { get; set; }
         
         /// <summary>
        /// 退款详单明细 
        /// </summary>
        /// <example></example>
        [XmlElement("publicResultObject")]
        [JsonProperty("publicResultObject")]
        public PublicResultObjectRefundInfo PublicResultObject  
        {
            get;
            set;
        }
        
         
    }
}

