#region head comment
/*
Code generate by JdSdkTool.
Copyright © starpeng@vip.qq.com
2013-01-31 10:56:42:375 +08:00
*/
#endregion

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Response
{
    /// <summary>
    /// 通过api 增加sku信息 Response
    /// </summary>
    public class WareSkuAddResponse : JdResponse
    {
        /// <summary>
        /// Sku id
        /// </summary>
        [XmlElement("sku_id")]
        [JsonProperty("sku_id")]
        public Int64 SkuId
        {
            get;
            set;
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        [XmlElement("created")]
        [JsonProperty("created")]
        public String Created
        {
            get;
            set;
        }

    }
}
