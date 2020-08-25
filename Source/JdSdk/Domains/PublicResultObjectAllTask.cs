using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{
     /// <summary>
    /// PublicResultObjectAllTask 属性
    /// </summary>
    [Serializable]
    public class PublicResultObjectAllTask : JdObject
    {
        /// <summary>
        /// 结果编码:100(正常)300(异常)301(传参异常) 
        /// </summary>
        /// <example></example>
        [XmlElement("resultCode")]
        [JsonProperty("resultCode")]
        public Int64 ResultCode
        {
            get;
            set;
        }


        /// <summary>
        /// 服务单信息 
        /// </summary>
        /// <example></example>
        [XmlElement("allAfsService")]
        [JsonProperty("allAfsService")]
        public PageAllTask AllAfsService
        {
            get;
            set;
        }

         
    }
}
