
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JdSdk.Domain
{
    /// <summary>
    /// VenderRemark结构
    /// </summary>
    [Serializable]
    public class VenderRemark : JdObject
    {
        /// <summary>
        /// 日期类型字段（创建）
        /// </summary>
        [XmlElement("created")]
        [JsonProperty("created")]
        public String Created
        {
            get;
            set;
        }

        /// <summary>
        /// 发货备注
        /// </summary>
        [XmlElement("remark")]
        [JsonProperty("remark")]
        public String Remark
        {
            get;
            set;
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        [XmlElement("order_id")]
        [JsonProperty("order_id")]
        public String OrderId
        {
            get;
            set;
        }

        /// <summary>
        /// 日期类型字段（修改）
        /// </summary>
        [XmlElement("modified")]
        [JsonProperty("modified")]
        public String Modified
        {
            get;
            set;
        }

        /// <summary>
        /// 备注颜色标识
        /// </summary>
        [XmlElement("flag")]
        [JsonProperty("flag")]
        public String Flag
        {
            get;
            set;
        }
    }
}
