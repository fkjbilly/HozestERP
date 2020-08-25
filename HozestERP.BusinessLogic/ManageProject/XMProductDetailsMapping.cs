using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{ 

    public partial class XMProductDetailsMapping : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// 产品管理 主表Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the DetailId
        /// </summary>
        public Nullable<int> DetailId { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string ManufacturersCode { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the Shipper
        /// </summary>
        public Nullable<int> Shipper { get; set; }

        /// <summary>
        /// Gets or sets the Costprice
        /// </summary>
        public Nullable<decimal> Costprice { get; set; }



        #endregion

    }
}
