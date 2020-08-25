#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:37.77572 +08:00
*/
#endregion

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using JdSdk.Domain;

namespace JdSdk.Response
{
    /// <summary>
    /// 咨询指定日期的平均等待时长 Response
    /// </summary>
    public class JingdongImPopConsultAvgwaittimeGetResponse : JdResponse
    {

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_im_pop_consult_avgwaittime_get_responce")]
        [JsonProperty("jingdong_im_pop_consult_avgwaittime_get_responce")]
        public AT AT { get; set; } 
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class AT
    { 
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code { get; set; }


        /// <summary>
        /// 平均等待时间（秒）
        /// </summary>
        /// <example></example>
        [XmlElement("avgTime")]
        [JsonProperty("avgTime")]
        public String AvgTime
        {
            get;
            set;
        }
    }
}
