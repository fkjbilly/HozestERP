#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:34.13751 +08:00
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
    /// 获取服务单列表信息 Response
    /// </summary>
    public class JingdongAfsserviceAlltaskGetResponse : JdResponse
    {

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_afsservice_alltask_get_responce")]
        [JsonProperty("jingdong_afsservice_alltask_get_responce")]
        public POAT POAT { get; set; }


    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class POAT 
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code { get; set; }
         
        /// <summary>
        /// 服务单信息 
        /// </summary>
        /// <example></example>
        [XmlElement("publicResultObject")]
        [JsonProperty("publicResultObject")]
        public PublicResultObjectAllTask PublicResultObject   
        {
            get;
            set;
        }
        
    }
}

