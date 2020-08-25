using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{ 
    /// <summary>
    /// AfsSignatureOut 属性
    /// </summary>
    [Serializable]
    public class AfsSignatureOut : JdObject
    {
        /// <summary>
        ///  操作人  
        /// </summary>
        [XmlElement("opName")]
        [JsonProperty("opName")]
        public String OpName 
        {
            get;
            set;
        }
        /// <summary>
        ///  备注   
        /// </summary>
        [XmlElement("remark")]
        [JsonProperty("remark")]
        public String Remark
        {
            get;
            set;
        }
        /// <summary>
        ///  操作时间   
        /// </summary>
        [XmlElement("opTime")]
        [JsonProperty("opTime")]
        public DateTime OpTime
        {
            get;
            set;
        }

    }
}
