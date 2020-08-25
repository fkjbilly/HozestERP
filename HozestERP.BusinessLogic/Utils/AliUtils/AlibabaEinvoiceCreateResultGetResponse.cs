using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace HozestERP.BusinessLogic.Utils.AliUtils
{
    /// <summary>
    /// AlibabaEinvoiceCreateResultGetResponse.
    /// </summary>
    public class AlibabaEinvoiceCreateResultGetResponse : TopResponse
    {
        /// <summary>
        /// 开票返回结果数据列表
        /// </summary>
        [XmlArray("invoice_result_list")]
        [XmlArrayItem("invoice_result")]
        public List<InvoiceResult> InvoiceResultList { get; set; }

    }
}
