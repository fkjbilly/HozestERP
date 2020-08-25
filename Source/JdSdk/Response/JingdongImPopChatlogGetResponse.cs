#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:37.57271 +08:00
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
    /// 聊天记录查询 Response
    /// </summary>
    public class JingdongImPopChatlogGetResponse : JdResponse
    {

          /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_im_pop_chatlog_get_responce")]
        [JsonProperty("jingdong_im_pop_chatlog_get_responce")]
        public CL CL { get; set; } 
         

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CL
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 聊天记录
        /// </summary>
        /// <example></example>
        [XmlElement("ChatLog")]
        [JsonProperty("ChatLog")]
        public ChatLog ChatLog
        {
            get;
            set;
        }

    }
}

 