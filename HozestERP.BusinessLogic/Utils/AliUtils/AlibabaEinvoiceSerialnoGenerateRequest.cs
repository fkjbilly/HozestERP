using System;
using System.Collections.Generic;

namespace HozestERP.BusinessLogic.Utils.AliUtils
{
    /// <summary>
    /// TOP API: alibaba.einvoice.serialno.generate
    /// </summary>
    public class AlibabaEinvoiceSerialnoGenerateRequest : BaseTopRequest<AlibabaEinvoiceSerialnoGenerateResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.einvoice.serialno.generate";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
