using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{



    /// <summary>
    /// AfsServiceOut 属性
    /// </summary>
    [Serializable]
    public class AfsServiceOut : JdObject
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
        /// 分类id 
        /// </summary>
        [XmlElement("afsCategoryId")]
        [JsonProperty("afsCategoryId")]
        public Int64  AfsCategoryId
        {
            get;
            set;
        }
        /// <summary>
        ///  	申请单号
        /// </summary>
        [XmlElement("afsApplyId")]
        [JsonProperty("afsApplyId")]
        public Int64  AfsApplyId
        {
            get;
            set;
        }
        /// <summary>
        /// 订单号 
        /// </summary>
        [XmlElement("orderId")]
        [JsonProperty("orderId")]
        public Int64  OrderId
        {
            get;
            set;
        }

        /// <summary>
        ///  订单备注
        /// </summary>
        [XmlElement("orderRemark")]
        [JsonProperty("orderRemark")]
        public String  OrderRemark
        {
            get;
            set;
        }
        /// <summary>
        /// 商品编码
        /// </summary>
        [XmlElement("wareId")]
        [JsonProperty("wareId")]
        public Int64  WareId
        {
            get;
            set;
        }
        /// <summary>
        ///  商品名称 
        /// </summary>
        [XmlElement("wareName")]
        [JsonProperty("wareName")]
        public String  WareName
        {
            get;
            set;
        }
        /// <summary>
        /// 取件省
        /// </summary>
        [XmlElement("pickwareProvince")]
        [JsonProperty("pickwareProvince")]
        public Int64  PickwareProvince
        {
            get;
            set;
        }
        /// <summary>
        /// 取件市 
        /// </summary>
        [XmlElement("pickwareCity")]
        [JsonProperty("pickwareCity")]
        public Int64  PickwareCity
        {
            get;
            set;
        }
        /// <summary>
        /// 取件县
        /// </summary>
        [XmlElement("pickwareCounty")]
        [JsonProperty("pickwareCounty")]
        public Int64  PickwareCounty
        {
            get;
            set;
        }
        /// <summary>
        /// 取件村
        /// </summary>
        [XmlElement("pickwareVillage")]
        [JsonProperty("pickwareVillage")]
        public Int64  PickwareVillage
        {
            get;
            set;
        }
        /// <summary>
        /// 取件地址 
        /// </summary>
        [XmlElement("pickwareAddress")]
        [JsonProperty("pickwareAddress")]
        public String  PickwareAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 返件省
        /// </summary>
        [XmlElement("returnwareProvince")]
        [JsonProperty("returnwareProvince")]
        public Int64  ReturnwareProvince
        {
            get;
            set;
        }
        /// <summary>
        /// 返件市
        /// </summary>
        [XmlElement("returnwareCity ")]
        [JsonProperty("returnwareCity ")]
        public Int64  ReturnwareCity 
        {
            get;
            set;
        }
        /// <summary>
        /// 返件县
        /// </summary>
        [XmlElement("returnwareCounty")]
        [JsonProperty("returnwareCounty")]
        public Int64  ReturnwareCounty
        {
            get;
            set;
        }
        /// <summary>
        /// 返件村
        /// </summary>
        [XmlElement("returnwareVillage")]
        [JsonProperty("returnwareVillage")]
        public Int64  ReturnwareVillage
        {
            get;
            set;
        }
        /// <summary>
        /// 返件地址
        /// </summary>
        [XmlElement("returnwareAddress")]
        [JsonProperty("returnwareAddress")]
        public String  ReturnwareAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 客户期望:10(退货)20(换货)30(维修) 
        /// </summary>
        [XmlElement("customerExpect")]
        [JsonProperty("customerExpect")]
        public Int64  CustomerExpect 
        {
            get;
            set;
        }
        /// <summary>
        /// 问题描述 
        /// </summary>
        [XmlElement("questionDesc")]
        [JsonProperty("questionDesc")]
        public String  QuestionDesc
        {
            get;
            set;
        }
        /// <summary>
        /// 客户姓名 
        /// </summary>
        [XmlElement("customerName")]
        [JsonProperty("customerName")]
        public String  CustomerName 
        {
            get;
            set;
        }
        /// <summary>
        /// 联系电话 
        /// </summary>
        [XmlElement("customerMobilePhone")]
        [JsonProperty("customerMobilePhone")]
        public String  CustomerMobilePhone
        {
            get;
            set;
        }
        /// <summary>
        /// 客户邮箱
        /// </summary>
        [XmlElement("customerEmail")]
        [JsonProperty("customerEmail")]
        public String  CustomerEmail
        {
            get;
            set;
        }
        /// <summary>
        /// 审核人 
        /// </summary>
        [XmlElement("approveName")]
        [JsonProperty("approveName")]
        public String  ApproveName 
        {
            get;
            set;
        }

         /// <summary>
        /// 申请时间
        /// </summary>
        [XmlElement("afsApplyTime")]
        [JsonProperty("afsApplyTime")]
        public String AfsApplyTime
        {
            get;
            set;
        }

         /// <summary>
        /// 审核时间 
        /// </summary>
        [XmlElement("approvedDate")]
        [JsonProperty("approvedDate")]
        public String  ApprovedDate //Nullable<DateTime>
        {
            get;
            set;
        }
         /// <summary>
        /// 处理时间 
        /// </summary>
        [XmlElement("processedDate")]
        [JsonProperty("processedDate")]
        public String ProcessedDate
        {
            get;
            set;
        }
         /// <summary>
        /// 收货时间 
        /// </summary>
        [XmlElement("receiveDate")]
        [JsonProperty("receiveDate")]
        public String ReceiveDate
        {
            get;
            set;
        } 
         
        /// <summary>
        /// 创建人 
        /// </summary>
        [XmlElement("createName")]
        [JsonProperty("createName")]
        public String  CreateName 
        {
            get;
            set;
        }
         /// <summary>
        /// 创建时间 
        /// </summary>
        [XmlElement("createDate")]
        [JsonProperty("createDate")]
        public String CreateDate
        {
            get;
            set;
        }
    }
}