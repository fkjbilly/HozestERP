using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domains
{
    
    /// <summary>
    /// PageAllTask 属性
    /// </summary>
    [Serializable]
    public class PageAllTask : JdObject
    {
        /// <summary>
        /// 总条数
        /// </summary>
        [XmlElement("totalCount")]
        [JsonProperty("totalCount")]
        public Int64 TotalCount 
        {
            get;
            set;
        }

        /// <summary>
        /// 服务单信息 
        /// </summary>
        [XmlElement("result")]
        [JsonProperty("result")]
        public List<AfsServiceMessage> result 
        {
            get;
            set;
        }
    }
}
