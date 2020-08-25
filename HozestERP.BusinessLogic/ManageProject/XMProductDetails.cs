
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2014-12-30 10:10:13
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMProductDetails : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public Nullable<int> ProductId { get; set; }

        /// <summary>
        /// 平台类型
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }

        /// <summary>
        /// Gets or sets the TemporaryManufacturersCode
        /// </summary>
        public string TemporaryManufacturersCode { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        public Nullable<int> ProductTypeId { get; set; }

        /// <summary>
        /// 平台库存
        /// </summary>
        public Nullable<int> PlatformInventory { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string strUrl { get; set; }

        /// <summary>
        /// Gets or sets the Images
        /// </summary>
        public Nullable<int> Images { get; set; }

        /// <summary>
        /// 出厂价
        /// </summary>
        public Nullable<decimal> Costprice { get; set; }

        /// <summary>
        /// 销售价
        /// </summary>
        public Nullable<decimal> Saleprice { get; set; }

        /// <summary>
        /// 最低售价
        /// </summary>
        public Nullable<decimal> MinPrice { get; set; }

        /// <summary>
        /// 未审核最低售价
        /// </summary>
        public Nullable<decimal> UnauditMinPrice { get; set; }

        /// <summary>
        /// 特供价
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
        /// 是否主推
        /// </summary>
        public Nullable<bool> IsMainPush { get; set; }

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

        #endregion
        #region Custom Properties
        /// <summary>
        /// 平台类型
        /// </summary>
        public CodeList PlatformTypeName
        {
            get
            {
                if (this.PlatformTypeId != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PlatformTypeId.Value);
                }
                else
                {

                    return null;
                }
            }
        }

        /// <summary>
        /// 产品类型
        /// </summary>
        public CodeList ProductTypeCodeName
        {
            get
            {
                if (this.ProductTypeId != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.ProductTypeId.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// 厂家编码
        /// </summary>
        public string ManufacturersCode
        {
            get
            {
                string ManufacturersCode = "";
                if (this.ProductId != null)
                {
                    var product = IoC.Resolve<IXMProductService>().GetXMProductById(this.ProductId.Value);
                    if (product != null)
                    {
                        ManufacturersCode = product.ManufacturersCode;
                    }
                }
                return ManufacturersCode;
            }
        }
        #endregion
    }
}
