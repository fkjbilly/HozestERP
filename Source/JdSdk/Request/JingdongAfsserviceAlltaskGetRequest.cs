#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:34.13751 +08:00
*/
#endregion

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JdSdk.Domain;
using JdSdk.Response;

namespace JdSdk.Request
{
    /// <summary>
    /// 获取服务单列表信息 Request
    /// </summary>
    public class JingdongAfsserviceAlltaskGetRequest : JdRequestBase<JingdongAfsserviceAlltaskGetResponse>
    { 
        /// <summary>
        /// 服务单号 
        /// </summary>
        /// <example></example>
        [XmlElement("afsServiceId")]
        [JsonProperty("afsServiceId")]
        public Nullable<Int64> AfsServiceId 
        {
            get;
            set;
        }

        /// <summary>
        /// 页码请求超过总页数，则返回最后一页的数据，小于1默认为1
        /// </summary>
        /// <example></example>
        [XmlElement("pageNumber")]
        [JsonProperty("pageNumber")]
        public Int64 PageNumber 
        {
            get;
            set;
        }

        /// <summary>
        /// 每页条数(范围1-30) 
        /// </summary>
        /// <example></example>
        [XmlElement("pageSize")]
        [JsonProperty("pageSize")]
        public Int64 PageSize 
        {
            get;
            set;
        }

        /// <summary>
        /// 客户账号 
        /// </summary>
        /// <example></example>
        [XmlElement("customerPin")]
        [JsonProperty("customerPin")]
        public String CustomerPin
        {
            get;
            set;
        }

        /// <summary>
        /// 订单号
        /// </summary>
        /// <example></example>
        [XmlElement("orderId")]
        [JsonProperty("orderId")]
        public Nullable<Int64> OrderId
        {
            get;
            set;
        }

        /// <summary>
        /// 申请时间begin
        /// </summary>
        /// <example></example>
        [XmlElement("afsApplyTimeBegin")]
        [JsonProperty("afsApplyTimeBegin")]
        public Nullable<DateTime> AfsApplyTimeBegin
        {
            get;
            set;
        }

        /// <summary>
        /// 申请时间end
        /// </summary>
        /// <example></example>
        [XmlElement("afsApplyTimeEnd ")]
        [JsonProperty("afsApplyTimeEnd ")]
        public Nullable<DateTime> AfsApplyTimeEnd 
        {
            get;
            set;
        }

        /// <summary>
        /// 审核时间begin
        /// </summary>
        /// <example></example>
        [XmlElement("approvedDateBegin")]
        [JsonProperty("approvedDateBegin")]
        public Nullable<DateTime> ApprovedDateBegin 
        {
            get;
            set;
        }

        /// <summary>
        /// 审核时间end 
        /// </summary>
        /// <example></example>
        [XmlElement("approvedDateEnd")]
        [JsonProperty("approvedDateEnd")]
        public Nullable<DateTime> ApprovedDateEnd 
        {
            get;
            set;
        }

        public override String ApiName
        {
            get { return "jingdong.afsservice.alltask.get"; }
        }

        protected override void PrepareParam(IDictionary<String, Object> paramters)
        {
            paramters.Add("afsServiceId", this.AfsServiceId);
            paramters.Add("pageNumber", this.PageNumber);
            paramters.Add("pageSize", this.PageSize);
            paramters.Add("customerPin", this.CustomerPin);
            paramters.Add("orderId", this.OrderId);
            paramters.Add("afsApplyTimeBegin", this.AfsApplyTimeBegin);
            paramters.Add("afsApplyTimeEnd", this.AfsApplyTimeEnd);
            paramters.Add("approvedDateBegin", this.ApprovedDateBegin);
            paramters.Add("approvedDateEnd", this.ApprovedDateEnd);
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("pageNumber", this.PageNumber);
            RequestValidator.ValidateRequired("pageSize", this.PageSize);
            //RequestValidator.ValidateRequired("afsApplyTimeBegin", this.AfsApplyTimeBegin);
            //RequestValidator.ValidateRequired("afsApplyTimeEnd", this.AfsApplyTimeEnd);
        }
        
    }
}


 

 