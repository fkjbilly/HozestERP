using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace JdSdk.Domain
{
    [Serializable]
    public class VenderRemarkQueryResult : JdObject
    {
        /// <summary>
        /// 结果总数,所有订单数
        /// </summary>
        [XmlElement("api_jos_result")]
        [JsonProperty("api_jos_result")]
        public ApiJosResult ApiJosResult
        {
            get;
            set;
        }

        /// <summary>
        /// 订单数据
        /// </summary>
        [XmlElement("vender_remark")]
        [JsonProperty("vender_remark")]
        public VenderRemark VenderRemark
        {
            get;
            set;
        }
    }
}
