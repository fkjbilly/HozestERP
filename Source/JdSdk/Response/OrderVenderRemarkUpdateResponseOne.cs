using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Response
{ 
    /// <summary>
    /// 商家订单备注修改。 Response
    /// </summary>
    public class OrderVenderRemarkUpdateResponseOne : JdResponse
    {             
        /// <summary>
        /// 
        /// </summary> 
        [XmlElement("order_vender_remark_update")]
        [JsonProperty("order_vender_remark_update")]
        public OrderVenderRemarkUpdateResponseOUP OUP { get; set; }
    }
     
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class OrderVenderRemarkUpdateResponseOUP
    { 
       
        /// <summary>
        /// 订单id
        /// </summary>
        [XmlElement("order_id")]
        [JsonProperty("order_id")]
        public String OrderId
        {
            get;
            set;
        }

        /// <summary>
        /// 商家ID
        /// </summary>
        [XmlElement("vender_id")]
        [JsonProperty("vender_id")]
        public String VenderId
        {
            get;
            set;
        }


        /// <summary>
        /// 修改时间
        /// </summary>
        [XmlElement("modified")]
        [JsonProperty("modified")]
        public String Modified
        {
            get;
            set;
        }

        /// <summary>
        /// 0为正常，其它值参见错误代码一览表
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code
        {
            get;
            set;
        }
         

    }
}
