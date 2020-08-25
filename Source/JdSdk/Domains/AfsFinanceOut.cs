using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{ 
    /// <summary>
    /// AfsFinanceOut 属性
    /// </summary>
    [Serializable]
    public class AfsFinanceOut : JdObject
    {   
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("idFinance")]
        [JsonProperty("idFinance")]
        public String IdFinance 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("opTime")]
        [JsonProperty("opTime")]
        public DateTime OpTime 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("margReason")]
        [JsonProperty("margReason")]
        public String MargReason 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("codeAccount")]
        [JsonProperty("codeAccount")]
        public String CodeAccount 
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
        [XmlElement("carriage")]
        [JsonProperty("carriage")]
        public String Carriage 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("memberPhone")]
        [JsonProperty("memberPhone")]
        public String MemberPhone 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("refundment")]
        [JsonProperty("refundment")]
        public String Refundment 
        {
            get;
            set;
        } 
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("type")]
        [JsonProperty("type")]
        public String Type 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("opPin")]
        [JsonProperty("opPin")]
        public String OpPin 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("bilv")]
        [JsonProperty("bilv")]
        public String Bilv 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("price")]
        [JsonProperty("price")]
        public String Price 
        {
            get;
            set;
        }

        /// <summary>
        ///    
        /// </summary>
        [XmlElement("wareName")]
        [JsonProperty("wareName")]
        public String WareName 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("serviceId")]
        [JsonProperty("serviceId")]
        public String ServiceId 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("userId")]
        [JsonProperty("userId")]
        public String UserId 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("opName")]
        [JsonProperty("opName")]
        public String OpName 
        {
            get;
            set;
        }

        /// <summary>
        ///    
        /// </summary>
        [XmlElement("account")]
        [JsonProperty("account")]
        public String Account 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("userName")]
        [JsonProperty("userName")]
        public String UserName 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("bank")]
        [JsonProperty("bank")]
        public String Bank 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("rebate")]
        [JsonProperty("rebate")]
        public String Rebate 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("notes")]
        [JsonProperty("notes")]
        public String Notes 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("wareId")]
        [JsonProperty("wareId")]
        public String WareId 
        {
            get;
            set;
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("orderId")]
        [JsonProperty("orderId")]
        public String OrderId 
        {
            get;
            set;
        }
    }
}
