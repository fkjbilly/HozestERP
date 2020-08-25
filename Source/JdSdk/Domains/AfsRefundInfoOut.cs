using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{
    /// <summary>
    /// AfsRefundInfoOut 属性
    /// </summary>
    [Serializable]
    public class AfsRefundInfoOut : JdObject
    {
        /// <summary>
        /// 退款详单明细 
        /// </summary>
        [XmlElement("afsFinanceDetailOuts")]
        [JsonProperty("afsFinanceDetailOuts")]
        public List<AfsFinanceDetailOut> afsFinanceDetailOuts 
        {
            get;
            set;
        }
        /// <summary>
        /// 退款签字信息 
        /// </summary>
        [XmlElement("afsSignatureOut")]
        [JsonProperty("afsSignatureOut")]
        public List<AfsSignatureOut> afsSignatureOut 
        {
            get;
            set;
        }
        /// <summary>
        /// 退款信息 
        /// </summary>
        [XmlElement("afsFinanceOut")]
        [JsonProperty("afsFinanceOut")]
        public AfsFinanceOut afsFinanceOut
        {
            get;
            set;
        }
        /// <summary>
        /// 退款基础信息
        /// </summary>
        [XmlElement("afsRefundOut")]
        [JsonProperty("afsRefundOut")]
        public AfsRefundOut afsRefundOut
        {
            get;
            set;
        }
         
       
        
    }
}
