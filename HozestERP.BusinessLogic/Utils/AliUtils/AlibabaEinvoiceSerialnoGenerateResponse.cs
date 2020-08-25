using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace HozestERP.BusinessLogic.Utils.AliUtils
{
    /// <summary>
    /// AlibabaEinvoiceSerialnoGenerateResponse.
    /// </summary>
    public class AlibabaEinvoiceSerialnoGenerateResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("serial_no")]
        public string SerialNo { get; set; }

    }
}
