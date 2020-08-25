#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:38.59277 +08:00
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
    /// 查询客服登录日志 Response
    /// </summary>
    public class JingdongImPopPasslogGetResponse : JdResponse
    {
        
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_im_pop_passlog_get_responce")]
        [JsonProperty("jingdong_im_pop_passlog_get_responce")]
        public PL PL { get; set; } 
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PL
    { 
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code { get; set; }


        /// <summary>
        /// 登录日志类
        /// </summary>
        [XmlElement("PassLog")]
        [JsonProperty("PassLog")]
        public List<PassLog> PassLog
        {
            get;
            set;
        }
    }
}

       