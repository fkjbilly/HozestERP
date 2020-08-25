using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{ 

    public partial class XMDeliveryDetails_Result : BaseEntity
    {
        #region Primitive Properties
         
        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the PrdouctName
        /// </summary>
        public string PrdouctName { get; set; }

        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> ProductNum { get; set; }
       
        

        #endregion
        #region Custom Properties


        #endregion
    }
}
