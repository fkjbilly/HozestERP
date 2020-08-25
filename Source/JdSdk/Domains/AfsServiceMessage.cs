using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{ 
   
    /// <summary>
    /// AfsServiceMessage 属性
    /// </summary>
    [Serializable]
    public class AfsServiceMessage : JdObject
    {
        /// <summary>
        /// 服务单号 
        /// </summary>
        [XmlElement("afsServiceId")]
        [JsonProperty("afsServiceId")]
        public Int64 AfsServiceId  
        {
            get;
            set;
        }

        /// <summary>
        /// 服务单信息 ?
        /// </summary>
        [XmlElement("afsApplyId")]
        [JsonProperty("afsApplyId")]
        public Int64 AfsApplyId  
        {
            get;
            set;
        }

        /// <summary>
        ///  分类id?
        /// </summary>
        [XmlElement("afsCategoryId")]
        [JsonProperty("afsCategoryId")]
        public Int64 AfsCategoryId
        {
            get;
            set;
        } 
        /// <summary>
        ///  订单号
        /// </summary>
        [XmlElement("orderId")]
        [JsonProperty("orderId")]
        public Int64 OrderId
        {
            get;
            set;
        }
       /// <summary>
        ///  商品编号?
        /// </summary>
        [XmlElement("wareId")]
        [JsonProperty("wareId")]
        public Int64 WareId
        {
            get;
            set;
        }
         /// <summary>
        ///  商品名称?
        /// </summary>
        [XmlElement("wareName")]
        [JsonProperty("wareName")]
        public String   WareName
        {
            get;
            set;
        }
        /// <summary>
        ///  客户姓名
        /// </summary>
        [XmlElement("customerName")]
        [JsonProperty("customerName")]
        public String   CustomerName
        {
            get;
            set;
        }
         /// <summary>
        ///  联系电话
        /// </summary>
        [XmlElement("customerMobilePhone")]
        [JsonProperty("customerMobilePhone")]
        public String   CustomerMobilePhone
        {
            get;
            set;
        }
        /// <summary>
        ///  审核人
        /// </summary>
        [XmlElement("approveName")]
        [JsonProperty("approveName")]
        public String   ApproveName
        {
            get;
            set;
        }
         /// <summary>
        ///  申请时间
        /// </summary>
        [XmlElement("afsApplyTime")]
        [JsonProperty("afsApplyTime")]
        public String   afsApplyTime
        {
            get;
            set;
        }

        /// <summary>
        ///  审核时间 
        /// </summary>
        [XmlElement("approvedDate")]
        [JsonProperty("approvedDate")]
        public String   ApprovedDate
        {
            get;
            set;
        }  
         
    }
}