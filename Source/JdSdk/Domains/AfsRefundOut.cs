using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{ 
     /// <summary>
    /// AfsRefundOut 属性
    /// </summary>
    [Serializable]
    public class AfsRefundOut : JdObject
    {   
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("suggestAmount")]
        [JsonProperty("suggestAmount")]
        public String SuggestAmount 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("payInfo")]
        [JsonProperty("payInfo")]
        public String PayInfo
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("reason")]
        [JsonProperty("reason")]
        public String Reason
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("afsServiceId")]
        [JsonProperty("afsServiceId")]
        public String AfsServiceId
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("mark")]
        [JsonProperty("mark")]
        public String Mark
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("afsRefundId")]
        [JsonProperty("afsRefundId")]
        public String AfsRefundId
        {
            get;
            set;
        }
    }
}
