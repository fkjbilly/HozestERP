
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-01-09 11:02:47
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
using HozestERP.BusinessLogic.ManageApplication;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMOrderInfoProductDetails : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the OrderInfoID
        /// </summary>
        public Nullable<int> OrderInfoID { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string TManufacturersCode { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the SpareRemarks
        /// </summary>
        public string SpareRemarks { get; set; }

        /// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> ProductNum { get; set; }

        /// <summary>
        /// 出厂价
        /// </summary>
        public Nullable<decimal> FactoryPrice { get; set; }

        /// <summary>
        /// 特供价
        /// </summary>
        public Nullable<decimal> TCostprice { get; set; }

        /// <summary>
        /// 销售价
        /// </summary>
        public Nullable<decimal> SalesPrice { get; set; }

        /// <summary>
        /// 是否抵库
        /// </summary>
        public Nullable<bool> ISArrivedLibrary { get; set; }

        /// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets the CutoffShipDay
        /// </summary>
        public Nullable<System.DateTime> CutoffShipDay { get; set; }

        /// <summary>
        /// 是否审核
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }

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
        /// 是否加急
        /// </summary>
        public Nullable<bool> IsExpedited { get; set; }

        public string Status { get; set; }

        /// <summary>
        /// 否已排过单
        /// </summary>
        public Nullable<bool> IsSingleRow { get; set; }

        #endregion
        #region Custom Properties


        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_OrderInfo
        /// </summary>
        public virtual XMOrderInfo XM_OrderInfo { get; set; }


        /// <summary>
        ///  平台ID
        /// </summary>
        public string PlatFormTypeId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.OrderInfoID.ToString()))
                {
                    var orderInfo = IoC.Resolve<XMOrderInfoService>().GetXMOrderInfoByID((int)this.OrderInfoID);
                    if (orderInfo != null)
                        return orderInfo.PlatformTypeId.ToString();
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 厂家编码
        /// </summary>
        public string Manufacturers
        {
            get
            {
                string result = "";
                if (this.PlatformMerchantCode != "")
                {

                    var nick = IoC.Resolve<IXMProductService>().GetXMProductProductId(this.ID, this.PlatformMerchantCode, this.OrderInfoID);
                    if (nick != null)
                    {
                        result = nick.ManufacturersCode;
                    }
                    else
                    {
                        var Nick = IoC.Resolve<IXMCombinationService>().GetXMProductProductId(this.ID, this.PlatformMerchantCode, this.OrderInfoID);
                        if (Nick != null)
                        {
                            result = Nick.ManufacturersCode;
                        }
                    }
                    return result;
                }
                else
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductVolume
        {
            get
            {
                string result = "";
                if (this.PlatformMerchantCode != "")
                {
                    var nick = IoC.Resolve<IXMProductService>().GetXMProductProductId(this.ID, this.PlatformMerchantCode, this.OrderInfoID);
                    if (nick != null)
                    {
                        result = nick.ProductVolume;
                    }
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string ProductWeight
        {
            get
            {
                string result = "";
                if (this.PlatformMerchantCode != "")
                {
                    var nick = IoC.Resolve<IXMProductService>().GetXMProductProductId(this.ID, this.PlatformMerchantCode, this.OrderInfoID);
                    if (nick != null)
                    {
                        result = nick.ProductWeight;
                    }
                    else
                    {
                        var Nick = IoC.Resolve<IXMCombinationService>().GetXMProductProductId(this.ID, this.PlatformMerchantCode, this.OrderInfoID);
                        if (Nick != null)
                        {
                            result = Nick.ProductWeight;
                        }
                    }
                    return result;
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
                string result = "";
                if (this.PlatformMerchantCode != "" && this.PlatFormTypeId != null && this.PlatFormTypeId.ToString() != "")
                {

                    var Manufacturersproduce = IoC.Resolve<IXMProductService>().getXMProductByPlatform(int.Parse(this.PlatFormTypeId.ToString()), this.PlatformMerchantCode);
                    if (Manufacturersproduce != null)
                    {
                        result = Manufacturersproduce.ManufacturersCode;
                    }
                    return result;
                }
                else
                {

                    return null;
                }
            }
        }

        ///// <summary>
        ///// 退货的数量
        ///// </summary>
        //public int count
        //{
        //    get
        //    {
        //        int result = 0;
        //        if (this.ID != 0)
        //        {

        //            var nick = IoC.Resolve<IXMApplicationExchangeService>().GetXMApplicationExchangeByIsOrID(this.ID,2);
        //            if (nick != null)
        //            {
        //                result = int.Parse(nick.ProductNum.ToString());
        //            }
        //            return result;
        //        }
        //        else
        //        {

        //            return 0;
        //        }
        //    }
        //}

        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class SimpleInfoProductDetail
    {
        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> ProductNum { get; set; }
    }
}
