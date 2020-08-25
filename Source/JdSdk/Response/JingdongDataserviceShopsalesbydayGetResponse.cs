#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:36.15863 +08:00
*/
#endregion

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using JdSdk.Domain;
using JdSdk.Domains;

namespace JdSdk.Response
{
    /// <summary>
    ///  Response
    /// </summary>
    public class JingdongDataserviceShopsalesbydayGetResponse : JdResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_dataservice_shopsalesbyday_get_responce")]
        [JsonProperty("jingdong_dataservice_shopsalesbyday_get_responce")]
        public RDT RDT { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class RDT 
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code { get; set; }


         
            
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("resultDTO")]
        [JsonProperty("resultDTO")]
        public ShopSalesResultDTO ResultDTO { get; set; }

       
    }
}