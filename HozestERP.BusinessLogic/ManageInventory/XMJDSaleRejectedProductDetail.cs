
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-08-10 10:40:24
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
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMJDSaleRejectedProductDetail : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the JDRejectedID
        /// </summary>
        public int JDRejectedID { get; set; }

        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public Nullable<int> ProductId { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the RejectionCount
        /// </summary>
        public Nullable<int> RejectionCount { get; set; }

        /// <summary>
        /// Gets or sets the RejectionPrice
        /// </summary>
        public Nullable<decimal> RejectionPrice { get; set; }

        /// <summary>
        /// Gets or sets the RejectionMoney
        /// </summary>
        public Nullable<decimal> RejectionMoney { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }


        /// <summary>
        /// Gets or sets the JDIsConfirm
        /// </summary>
        public Nullable<bool> JDIsConfirm { get; set; }

        /// <summary>
        /// Gets or sets the JDConfirmDate
        /// </summary>
        public Nullable<System.DateTime> JDConfirmDate { get; set; }

        /// <summary>
        /// Gets or sets the JDConfirmer
        /// </summary>
        public Nullable<int> JDConfirmer { get; set; }

        /// <summary>
        /// Gets or sets the XBIsConfirm
        /// </summary>
        public Nullable<bool> XBIsConfirm { get; set; }

        /// <summary>
        /// Gets or sets the XBConfirmDate
        /// </summary>
        public Nullable<System.DateTime> XBConfirmDate { get; set; }

        /// <summary>
        /// Gets or sets the XBConfirmer
        /// </summary>
        public Nullable<int> XBConfirmer { get; set; }

        /// <summary>
        /// Gets or sets the XLMIsConfirm
        /// </summary>
        public Nullable<bool> XLMIsConfirm { get; set; }

        /// <summary>
        /// Gets or sets the XLMConfirmDate
        /// </summary>
        public Nullable<System.DateTime> XLMConfirmDate { get; set; }

        /// <summary>
        /// Gets or sets the XLMConfirmer
        /// </summary>
        public Nullable<int> XLMConfirmer { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandType
        {
            get
            {
                string result = "";
                if (this.PlatformMerchantCode != null)
                {
                    var item = IoC.Resolve<IXMProductService>().getXMProductListByPlatformMerchantCode(this.PlatformMerchantCode);
                    if (item != null && item.Count > 0)
                    {
                        result = item[0].BrandTypeId.ToString();
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }

        public string ProductName
        {
            get
            {
                string productName = "";
                if (this.ProductId != null)
                {
                    var products = IoC.Resolve<XMProductService>().GetXMProductById(this.ProductId.Value);
                    if (products != null)
                    {
                        productName = products.ProductName;
                    }
                }
                return productName;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Specifications
        {
            get
            {
                string Specifications = "";
                if (this.ProductId != null)
                {
                    var products = IoC.Resolve<XMProductService>().GetXMProductById(this.ProductId.Value);
                    if (products != null)
                    {
                        Specifications = products.Specifications;
                    }
                }
                return Specifications;
            }
        }

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_JDSaleRejected
        /// </summary>
        public virtual XMJDSaleRejected XM_JDSaleRejected { get; set; }

        #endregion
    }
}
