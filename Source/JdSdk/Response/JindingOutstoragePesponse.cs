using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using JdSdk.Domains;

namespace JdSdk.Response
{ 

    /// <summary>
    /// 订单SOP出库 Response
    /// </summary>
    public class JindingOutstoragePesponse : JdResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("order_sop_outstorage_response")]
        [JsonProperty("order_sop_outstorage_response")]
        public JindingOutstoragePesponseOP OP { get; set; }
    }
     
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class JindingOutstoragePesponseOP
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
        /// sop出库时间
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

        ///// <summary>
        /////  
        ///// </summary>
        //[XmlElement("logistics_companies")]
        //[JsonProperty("logistics_companies")]
        //public JindingOutstorage LogisticsCompany
        //{
        //    get;
        //    set;
        //}

    }
}
