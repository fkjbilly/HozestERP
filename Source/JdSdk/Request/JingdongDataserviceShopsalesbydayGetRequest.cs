#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:36.15763 +08:00
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
    ///  Request
    /// </summary>
    public class JingdongDataserviceShopsalesbydayGetRequest : JdRequestBase<JingdongDataserviceShopsalesbydayGetResponse>
    {
         
        /// <summary>
        /// 商品查询日期(年月日).格式(yyyy-MM-dd)  
        /// </summary>
        /// <example></example>
        [XmlElement("timeId")]
        [JsonProperty("timeId")]
        public String TimeId 
        {
            get;
            set;
        }
        public override String ApiName
        {
            get{ return "jingdong.dataservice.shopsalesbyday.get"; }
        }

        protected override void PrepareParam(IDictionary<String, Object> paramters)
        {
            paramters.Add("timeId", this.TimeId);
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("timeId", this.TimeId);
        }

    }
}
