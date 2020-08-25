using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{ 
    public partial class XMPremiumsDetailsMapping : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }


        /// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> SumProductNum { get; set; }
        #endregion

    }
}
