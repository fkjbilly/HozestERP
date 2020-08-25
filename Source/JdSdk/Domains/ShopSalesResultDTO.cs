using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{ 
    /// <summary>
    /// ShopSalesResultDTO 属性
    /// </summary>
    [Serializable]
    public class ShopSalesResultDTO : JdObject
    {
        /// <summary>
        /// 返回结果状态码 
        /// </summary>
        /// <example></example>
        [XmlElement("code")]
        [JsonProperty("code")]
        public Int64 Code
        {
            get;
            set;
        }


        /// <summary>
        /// 返回结果描述  
        /// </summary>
        /// <example></example>
        [XmlElement("message")]
        [JsonProperty("message")]
        public String Message
        {
            get;
            set;
        }
        /// <summary>
        /// 纪录对象   
        /// </summary>
        /// <example></example>
        [XmlElement("obj")]
        [JsonProperty("obj")]
        public DwsJosShopSalesResponse Obj 
        {
            get;
            set;
        }
        /// <summary>
        /// 纪录总数   
        /// </summary>
        /// <example></example>
        [XmlElement("totalSize")]
        [JsonProperty("totalSize")]
        public Int64 TotalSize
        {
            get;
            set;
        }

         
    }
}