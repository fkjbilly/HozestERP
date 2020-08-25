
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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMSaleReturnProductDetails : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the SaleReturnId
        /// </summary>
        public int SaleReturnId { get; set; }

        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public Nullable<int> ProductId { get; set; }

        /// <summary>
        /// Gets or sets the ProductCount
        /// </summary>
        public Nullable<int> ProductCount { get; set; }

        /// <summary>
        /// Gets or sets the ProductMoney
        /// </summary>
        public Nullable<decimal> ProductMoney { get; set; }

        /// <summary>
        /// Gets or sets the ProductPrice
        /// </summary>
        public Nullable<decimal> ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryProductsDetailID
        /// </summary>
        public Nullable<int> DeliveryProductsDetailID { get; set; }

        /// <summary>
        /// Gets or sets the RejectionProductsPrice
        /// </summary>
        public Nullable<decimal> RejectionProductsPrice { get; set; }

        /// <summary>
        /// Gets or sets the RejectionsaleMoney
        /// </summary>
        public Nullable<decimal> RejectionsaleMoney { get; set; }

        /// <summary>
        /// Gets or sets the RejectionProdcutsCount
        /// </summary>
        public Nullable<int> RejectionProdcutsCount { get; set; }

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

        //产品名称
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

        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandType
        {
            get
            {
                string result = "";
                var products = IoC.Resolve<IXMProductService>().GetXMProductById(ProductId.Value);
                if (products != null)
                {
                    result = products.BrandTypeId.ToString();
                }
                return result;
            }
        }

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_SaleReturn
        /// </summary>
        public virtual XMSaleReturn XM_SaleReturn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<XMSaleReturnBarCodeDetail> XM_SaleReturnBarCodeDetail { get; set; }

        #endregion
    }
}
