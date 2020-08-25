using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{
    /// <summary>
    /// DwsJosShopSalesResponse 属性
    /// </summary>
    [Serializable]
    public class DwsJosShopSalesResponse : JdObject
    {
        /// <summary>
        /// 上架商品数量 
        /// </summary>
        /// <example></example>
        [XmlElement("onlProNum")]
        [JsonProperty("onlProNum")]
        public Int64 OnlProNum
        {
            get;
            set;
        }


        /// <summary>
        /// 店铺浏览量   
        /// </summary>
        /// <example></example>
        [XmlElement("pv")]
        [JsonProperty("pv")]
        public Int64 PV
        {
            get;
            set;
        }
        /// <summary>
        ///店铺访问次数 （保留字段，暂时不返回该字段）    
        /// </summary>
        /// <example></example>
        [XmlElement("visit")]
        [JsonProperty("visit ")]
        public Int64 Visit 
        {
            get;
            set;
        }
        /// <summary>
        ///访客数 
        /// </summary>
        /// <example></example>
        [XmlElement("uv")]
        [JsonProperty("uv")]
        public Int64  UV
        {
            get;
            set;
        }
        /// <summary>
        /// 订单量     
        /// </summary>
        /// <example></example>
        [XmlElement("ordQtty")]
        [JsonProperty("ordQtty")]
        public Int64  OrdQtty 
        {
            get;
            set;
        }
        /// <summary>
        ///下单商品件数 
        /// </summary>
        /// <example></example>
        [XmlElement("ordProNum")]
        [JsonProperty("ordProNum")]
        public Int64 OrdProNum 
        {
            get;
            set;
        }
        /// <summary>
        ///下单金额  
        /// </summary>
        /// <example></example>
        [XmlElement("ordAmount")]
        [JsonProperty("ordAmount")]
        public Int64 OrdAmount 
        {
            get;
            set;
        }
        /// <summary>
        /// 下单客户数 
        /// </summary>
        /// <example></example>
        [XmlElement("ordCustNum")]
        [JsonProperty("ordCustNum")]
        public Int64 OrdCustNum 
        {
            get;
            set;
        }
        /// <summary>
        /// 平均订单金额    
        /// </summary>
        /// <example></example>
        [XmlElement("avgOrdPrice")]
        [JsonProperty("avgOrdPrice ")]
        public Int64 AvgOrdPrice 
        {
            get;
            set;
        }
        /// <summary>
        /// 客单价 
        /// </summary>
        /// <example></example>
        [XmlElement("avgCustPrice")]
        [JsonProperty("avgCustPrice")]
        public Int64 AvgCustPrice 
        {
            get;
            set;
        }
        /// <summary>
        ///客单量     
        /// </summary>
        /// <example></example>
        [XmlElement("avgCustOrdNum")]
        [JsonProperty("avgCustOrdNum")]
        public Int64 AvgCustOrdNum 
        {
            get;
            set;
        }
        /// <summary>
        ///客户转化率     
        /// </summary>
        /// <example></example>
        [XmlElement("custRate")]
        [JsonProperty("custRate")]
        public Int64 CustRate 
        {
            get;
            set;
        }
        /// <summary>
        /// 下单转化率    
        /// </summary>
        /// <example></example>
        [XmlElement("ordRate")]
        [JsonProperty("ordRate")]
        public Int64 OrdRate 
        {
            get;
            set;
        }
    }
}
