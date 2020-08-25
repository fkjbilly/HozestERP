
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2018-12-13 09:24:33
** 修改人:
** 修改日期:
** 描 述: 
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class XMBills: BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the BillID
        /// </summary>
        public int BillID { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> ProductNum { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public Nullable<decimal> Price { get; set; }

        /// <summary>
        /// Gets or sets the SuppliersID
        /// </summary>
        public Nullable<int> SuppliersID { get; set; }

        /// <summary>
        /// Gets or sets the VerificationStatus
        /// </summary>
        public string VerificationStatus { get; set; }

        /// <summary>
        /// Gets or sets the CreatebyName
        /// </summary>
        public string CreatebyName { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the ExMessage
        /// </summary>
        public string ExMessage { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryNumber
        /// </summary>
        public string DeliveryNumber { get; set; }

        #endregion
        #region Custom Properties


        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_Suppliers
        /// </summary>
        public virtual XMSuppliers XM_Suppliers { get; set; }

        #endregion
    }

    public enum status : int
    {
        异常 = 0,
        全部核销 = 1,
        部分核销 = 2,
        未核销 = 3
    }
}
