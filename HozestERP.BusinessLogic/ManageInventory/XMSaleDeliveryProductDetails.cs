
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-05-09 16:59:04
** 修改人:
** 修改日期:
** 描 述: 
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMSaleDeliveryProductDetails : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the SaleDeliveryId
        /// </summary>
        public int SaleDeliveryId { get; set; }

        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public Nullable<int> ProductId { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the SaleCount
        /// </summary>
        public Nullable<int> SaleCount { get; set; }

        /// <summary>
        /// Gets or sets the ProductMoney
        /// </summary>
        public Nullable<decimal> ProductMoney { get; set; }

        /// <summary>
        /// Gets or sets the ProductPrice
        /// </summary>
        public Nullable<decimal> ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }

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

        #endregion
        #region Custom Properties

        public string ProductName
        {
            get
            {
                string productName = "";
                if (ProductId != null)
                {
                    var products = IoC.Resolve<IXMProductService>().GetXMProductById(ProductId.Value);
                    if (products != null)
                    {
                        productName = products.ProductName;
                    }
                }
                return productName;
            }
        }

        //产品规格
        public string Specifications
        {
            get
            {
                string specifications = "";
                if (ProductId != null)
                {
                    var products = IoC.Resolve<IXMProductService>().GetXMProductById(ProductId.Value);
                    if (products != null)
                    {
                        specifications = products.Specifications;
                    }
                }
                return specifications;
            }
        }

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

        //产品单位
        public string ProductUnit
        {
            get
            {
                string productUnit = "";
                if (ProductId != null)
                {
                    var products = IoC.Resolve<IXMProductService>().GetXMProductById(ProductId.Value);
                    if (products != null)
                    {
                        productUnit = products.ProductUnit;
                    }
                }
                return productUnit;
            }
        }
        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_SaleDelivery
        /// </summary>
        public virtual XMSaleDelivery XM_SaleDelivery { get; set; }
        /// <summary>
        ///  Gets or sets the XM_SaleDeliveryBarCodeDetail
        /// </summary>
        public virtual ICollection<XMSaleDeliveryBarCodeDetail> XM_SaleDeliveryBarCodeDetail { get; set; }

        #endregion
    }
}
