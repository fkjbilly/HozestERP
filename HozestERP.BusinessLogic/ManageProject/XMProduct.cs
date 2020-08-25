
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
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMProduct : BaseEntity
    {
        #region Primitive Properties

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
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 厂家编码
        /// </summary>
        public string ManufacturersCode { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        public string Specifications { get; set; }
        /// <summary>
        /// 系列
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// 厂家库存
        /// </summary>
        public Nullable<int> ManufacturersInventory { get; set; }

        /// <summary>
        /// 预警库存数
        /// </summary>
        public Nullable<int> WarningQuantity { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ProductColors { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string ProductUnit { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public string ProductWeight { get; set; }
        /// <summary>
        /// 积极
        /// </summary>
        public string ProductVolume { get; set; }

        /// <summary>
        /// 是否赠品
        /// </summary>
        public Nullable<bool> IsPremiums { get; set; }

        /// <summary>
        /// Gets or sets the IsMoveCargo
        /// </summary>
        public Nullable<bool> IsMoveCargo { get; set; }

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
        /// Gets or sets the Shipper
        /// </summary>
        public Nullable<int> Shipper { get; set; }

        /// <summary>
        /// Gets or sets the SuppliersID
        /// </summary>
        public Nullable<int> SuppliersID { get; set; }

        #endregion
        #region Custom Properties


        /// <summary>
        /// 店铺名称
        /// </summary>
        public XMNick NickName
        {
            get
            {
                if (this.NickId != null)
                {
                    return IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                }
                else
                {

                    return null;
                }
            }
        }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandTypeCodeName
        {
            get
            {
                string result = "";
                if (this.BrandTypeId != null)
                {
                    var list = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.BrandTypeId.Value);
                    if (list != null)
                    {
                        result = list.CodeName;
                    }
                }
                return result;
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
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_Suppliers
        /// </summary>
        public virtual XMSuppliers XM_Suppliers { get; set; }

        #endregion

    }
}
