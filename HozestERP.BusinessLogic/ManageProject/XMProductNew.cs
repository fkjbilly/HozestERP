using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMProductNew
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
        /// <summary>
        /// Gets or sets the BrandTypeId
        /// </summary>
        public Nullable<int> BrandTypeId { get; set; }
        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string ManufacturersCode { get; set; }

        /// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string TManufacturersCode { get; set; }

        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the ManufacturersInventory
        /// </summary>
        public Nullable<int> ManufacturersInventory { get; set; }

        /// <summary>
        /// Gets or sets the WarningQuantity
        /// </summary>
        public Nullable<int> WarningQuantity { get; set; }

        /// <summary>
        /// Gets or sets the ProductColors
        /// </summary>
        public string ProductColors { get; set; }

        /// <summary>
        /// Gets or sets the ProductUnit
        /// </summary>
        public string ProductUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductWeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductVolume { get; set; }
        /// <summary>
        /// Gets or sets the IsPremiums
        /// </summary>
        public Nullable<bool> IsPremiums { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public Nullable<int> ProductId { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the ProductTypeId
        /// </summary>
        public Nullable<int> ProductTypeId { get; set; }

        /// <summary>
        /// Gets or sets the PlatformInventory
        /// </summary>
        public Nullable<int> PlatformInventory { get; set; }

        /// <summary>
        /// Gets or sets the strUrl
        /// </summary>
        public string strUrl { get; set; }

        /// <summary>
        /// Gets or sets the Images
        /// </summary>
        public Nullable<int> Images { get; set; }

        /// <summary>
        /// Gets or sets the Costprice
        /// </summary>
        public Nullable<decimal> Costprice { get; set; }

        /// <summary>
        /// Gets or sets the Saleprice
        /// </summary>
        public Nullable<decimal> Saleprice { get; set; }

        /// <summary>
        /// Gets or sets the TCostprice
        /// </summary>
        public Nullable<decimal> TCostprice { get; set; }

        /// <summary>
        /// Gets or sets the TDateTimeStart
        /// </summary>
        public Nullable<System.DateTime> TDateTimeStart { get; set; }

        /// <summary>
        /// Gets or sets the TDateTimeEnd
        /// </summary>
        public Nullable<System.DateTime> TDateTimeEnd { get; set; }

        /// <summary>
        /// Gets or sets the IsMainPush
        /// </summary>
        public Nullable<bool> IsMainPush { get; set; }

        /// <summary>
        /// Gets or sets the count
        /// </summary>
        public Nullable<int> count { get; set; }

        /// <summary>
        /// Gets or sets the Shipper
        /// </summary>
        public Nullable<int> Shipper { get; set; }
    }
}
