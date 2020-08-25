
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-05-25 16:55:15
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
    public partial class XMInventoryLedger : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the WarehouseId
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public Nullable<int> ProductId { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the InCount
        /// </summary>
        public Nullable<int> InCount { get; set; }

        /// <summary>
        /// Gets or sets the InMoney
        /// </summary>
        public Nullable<decimal> InMoney { get; set; }

        /// <summary>
        /// Gets or sets the InPrice
        /// </summary>
        public Nullable<decimal> InPrice { get; set; }

        /// <summary>
        /// Gets or sets the OutCount
        /// </summary>
        public Nullable<decimal> OutCount { get; set; }

        /// <summary>
        /// Gets or sets the OutMoney
        /// </summary>
        public Nullable<decimal> OutMoney { get; set; }

        /// <summary>
        /// Gets or sets the OutPrice
        /// </summary>
        public Nullable<decimal> OutPrice { get; set; }

        /// <summary>
        /// Gets or sets the BalanceCount
        /// </summary>
        public Nullable<int> BalanceCount { get; set; }

        /// <summary>
        /// Gets or sets the BalanceMoney
        /// </summary>
        public Nullable<decimal> BalanceMoney { get; set; }

        /// <summary>
        /// Gets or sets the BalnacePrice
        /// </summary>
        public Nullable<decimal> BalnacePrice { get; set; }

        /// <summary>
        /// Gets or sets the AfloatCount
        /// </summary>
        public Nullable<int> AfloatCount { get; set; }

        /// <summary>
        /// Gets or sets the AfloatMoney
        /// </summary>
        public Nullable<decimal> AfloatMoney { get; set; }

        /// <summary>
        /// Gets or sets the AfloatPrice
        /// </summary>
        public Nullable<decimal> AfloatPrice { get; set; }

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

        #endregion
        #region Custom Properties
        public string WfName
        {
            get
            {
                string wfname = "";
                var wf = IoC.Resolve<XMWareHousesService>().GetXMWareHousesById(WarehouseId);
                if (wf != null)
                {
                    wfname = wf.Name;
                }
                return wfname;
            }
        }
        //获取商品名称
        public string ProductName
        {
            get
            {
                string productName = "";
                if (this.ProductId != null)
                {
                    var product = IoC.Resolve<IXMProductService>().GetXMProductById(this.ProductId.Value);
                    if (product != null)
                    {
                        productName = product.ProductName;
                    }
                }
                return productName;
            }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string Specifications
        {
            get
            {
                string specifications = "";
                if (this.ProductId != null)
                {
                    var product = IoC.Resolve<IXMProductService>().GetXMProductById(this.ProductId.Value);
                    if (product != null)
                    {
                        specifications = product.Specifications;
                    }
                }
                return specifications;
            }
        }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string ProductUnit
        {
            get
            {
                string productUnit = "";
                if (this.ProductId != null)
                {
                    var product = IoC.Resolve<IXMProductService>().GetXMProductById(this.ProductId.Value);
                    if (product != null)
                    {
                        productUnit = product.ProductUnit;
                    }
                }
                return productUnit;
            }
        }



        #endregion
    }
}
