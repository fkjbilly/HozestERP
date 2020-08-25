#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:35.34958 +08:00
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
    /// 获取服务单信息 Response
    /// </summary>
    public class JingdongAfsserviceServiceinfoGetResponse : JdResponse
    {

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_afsservice_serviceinfo_get_responce")]
        [JsonProperty("jingdong_afsservice_serviceinfo_get_responce")]
        public PRIAS PRIAS { get; set; }


    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PRIAS 
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
        public PublicResultObjectAfsService PublicResultObject   
        {
            get;
            set;
        }
        
    }
}



