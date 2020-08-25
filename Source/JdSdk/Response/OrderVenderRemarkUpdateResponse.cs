#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:32.31841 +08:00
*/
#endregion

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using JdSdk.Domain;

namespace JdSdk.Response
{
    /// <summary>
    /// 商家订单备注修改。 Response
    /// </summary>
    public class OrderVenderRemarkUpdateResponse : JdResponse
    {
        /// <summary>
        /// 
        /// </summary> 
        [XmlElement("order_vender_remark_update_response")]
        [JsonProperty("order_vender_remark_update_response")]
        public OrderVenderRemarkUpdateResponseUP UP { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class OrderVenderRemarkUpdateResponseUP
    { 
       
        /// <summary>
        /// 商家id
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
