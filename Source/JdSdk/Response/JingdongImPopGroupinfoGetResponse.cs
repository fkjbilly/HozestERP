#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:38.38976 +08:00
*/
#endregion

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using JdSdk.Domain;
using JdSdk.Domains;

namespace JdSdk.Response
{
    /// <summary>
    /// 查询客服组信息 Response
    /// </summary>
    public class JingdongImPopGroupinfoGetResponse : JdResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_im_pop_groupinfo_get_responce")]
        [JsonProperty("jingdong_im_pop_groupinfo_get_responce")]
        public PG PG { get; set; }
    }
     
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PG
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code{ get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [XmlElement("popgroup")]
        [JsonProperty("popgroup")]
        public PopGroup PopGroup { get; set; }
    }
      

    
}
