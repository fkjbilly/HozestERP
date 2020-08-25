#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:50.75646 +08:00
*/
#endregion

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using JdSdk.Domains;

namespace JdSdk.Domain
{
    /// <summary>
    /// ChatSession 属性
    /// </summary>
    [Serializable]
    public class ChatSession : JdObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <example></example>
        [XmlElement("chatSessionList")]
        [JsonProperty("chatSessionList")]
        public List<ChatSessionList> ChatSessionList
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("totalRecord")]
        [JsonProperty("totalRecord")]
        public string totalRecord { get; set; } 
    }
}
