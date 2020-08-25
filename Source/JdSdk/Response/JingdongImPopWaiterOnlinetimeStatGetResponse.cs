#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-10-26 10:25:39.40282 +08:00
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
    /// 日累计在线时长 Response
    /// </summary>
    public class JingdongImPopWaiterOnlinetimeStatGetResponse : JdResponse
    { 
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("jingdong_im_pop_waiter_onlinetime_stat_get_responce")]
        [JsonProperty("jingdong_im_pop_waiter_onlinetime_stat_get_responce")]
        public WDSD WDSD { get; set; } 
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class WDSD
    { 
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("code")]
        [JsonProperty("code")]
        public string Code { get; set; }


        /// <summary>
        /// 客服日在线时长统计类
        /// </summary>
        [XmlElement("WaiterDailyStat")]
        [JsonProperty("WaiterDailyStat")]
        public List<WaiterDailyStat> WaiterDailyStatDate
        {
            get;
            set;
        }
    }
}

        