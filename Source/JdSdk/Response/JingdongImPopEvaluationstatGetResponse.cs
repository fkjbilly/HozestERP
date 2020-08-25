#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:38.18075 +08:00
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
    /// 客服日评价统计 Response
    /// </summary>
    public class JingdongImPopEvaluationstatGetResponse : JdResponse
    {

         /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_im_pop_evaluationstat_get_responce")]
        [JsonProperty("jingdong_im_pop_evaluationstat_get_responce")]
        public WDES WDES { get; set; } 
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class WDES
    { 
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code { get; set; }


        /// <summary>
        /// 客服日评价统计数据
        /// </summary>
        /// <example></example>
        [XmlElement("WaiterDailyEvaStat")]
        [JsonProperty("WaiterDailyEvaStat")]
        public List<WaiterDailyEvaStat> WaiterDailyEvaStat
        {
            get;
            set;
        }
    }
}
 