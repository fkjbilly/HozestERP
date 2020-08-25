
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-02-10 09:55:45
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
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMPremiumsDetails: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the PremiumsId
        /// </summary>
        public Nullable<int> PremiumsId { get; set; }

        /// <summary>
        /// Gets or sets the Shipper
        /// </summary>
        public Nullable<int> Shipper { get; set; }

    	/// <summary>
        /// 产品管理 主表Id
        /// </summary>
        public Nullable<int> ProductDetaislId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the PrdouctName
        /// </summary>
        public string PrdouctName { get; set; }
    
    	/// <summary>
        /// Gets or sets the FactoryPrice
        /// </summary>
        public Nullable<decimal> FactoryPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> ProductNum { get; set; }
    
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
        /// 是否排单
        /// </summary>
        public Nullable<bool> IsSingleRow { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// 尺寸
        /// </summary>
        public string Specifications
        {
            get
            {
                if (!string.IsNullOrEmpty(this.PlatformMerchantCode))
                {
                    var ProductDetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(this.PlatformMerchantCode);
                    if (ProductDetail.Count>0)
                    {
                        var Product = IoC.Resolve<IXMProductService>().GetXMProductById((int)ProductDetail[0].ProductId);
                        if (Product != null)
                        {
                            return Product.Specifications;
                        }
                    }
                    return "";
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 发货方
        /// </summary>
        public string ShipperName
        {
            get
            {
                string result = "";
                if (this.Shipper != null)
                {
                    var list = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.Shipper.Value);
                    if (list != null)
                    {
                        result = list.CodeName;
                    }
                }
                return result;
            }
        }
    	
        #endregion
    }
}
