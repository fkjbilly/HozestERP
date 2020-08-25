using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JdSdk.Response;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Request
{
    public class JingdongAfsserviceRefundinfoGetRequest : JdRequestBase<JingdongAfsserviceRefundinfoGetResponse>
    {
        /// <summary>
        /// 服务单号 
        /// </summary>
        /// <example></example>
        [XmlElement("afsServiceId ")]
        [JsonProperty("afsServiceId ")]
        public Int64 AfsServiceId 
        {
            get;
            set;
        }
         
        public override String ApiName
        {
            get{ return "jingdong.afsservice.refundinfo.get"; }
        }

        protected override void PrepareParam(IDictionary<String, Object> paramters)
        {
            paramters.Add("afsServiceId" ,this.AfsServiceId); 
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("afsServiceId", this.AfsServiceId);
        }

    }
}

