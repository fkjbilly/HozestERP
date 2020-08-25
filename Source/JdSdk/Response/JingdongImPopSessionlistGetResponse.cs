#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:38.99679 +08:00
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
    /// 获取会话列表 Response
    /// </summary>
    public class JingdongImPopSessionlistGetResponse : JdResponse
    {

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_im_pop_sessionlist_get_responce")]
        [JsonProperty("jingdong_im_pop_sessionlist_get_responce")]
        public CS CS { get; set; } 
        

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CS
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code { get; set; } 

        /// <summary>
        /// 会话
        /// </summary>
        /// <example></example>
        [XmlElement("ChatSession")]
        [JsonProperty("ChatSession")]
        public ChatSession ChatSession
        {
            get;
            set;
        }
    }
}
