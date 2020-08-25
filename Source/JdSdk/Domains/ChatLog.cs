#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:50.75146 +08:00
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
    /// ChatLog 属性
    /// </summary>
    [Serializable]
    public class ChatLog : JdObject
    {

        /// <summary>
        /// ChatLogList
        /// </summary>
        [XmlElement("chatLogList")]
        [JsonProperty("chatLogList")]
        public List<ChatLogList> ChatLogList
        {
            get;
            set;
        }

        /// <summary>
        /// 纪录总数
        /// </summary>
        [XmlElement("totalRecord")]
        [JsonProperty("totalRecord")]
        public Int64 TotalRecord
        {
            get;
            set;
        }
         
    }
}
