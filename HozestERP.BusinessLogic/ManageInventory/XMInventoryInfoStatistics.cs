
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-09-20 15:57:09
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
using HozestERP.BusinessLogic.Infrastructure;
using System.Runtime.Serialization;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMInventoryInfoStatistics : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the WfID
        /// </summary>
        public Nullable<int> WfID { get; set; }

        /// <summary>
        /// Gets or sets the Year
        /// </summary>
        public Nullable<int> Year { get; set; }

        /// <summary>
        /// Gets or sets the Month
        /// </summary>
        public Nullable<int> Month { get; set; }

        /// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string ManufacturersCode { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the InitialCount
        /// </summary>
        public Nullable<int> InitialCount { get; set; }

        /// <summary>
        /// Gets or sets the InitialMoney
        /// </summary>
        public Nullable<decimal> InitialMoney { get; set; }

        /// <summary>
        /// Gets or sets the StorageCount
        /// </summary>
        public Nullable<int> StorageCount { get; set; }

        /// <summary>
        /// Gets or sets the StorageMoney
        /// </summary>
        public Nullable<decimal> StorageMoney { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryCount
        /// </summary>
        public Nullable<int> DeliveryCount { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryMoney
        /// </summary>
        public Nullable<decimal> DeliveryMoney { get; set; }

        /// <summary>
        /// Gets or sets the InventoryCount
        /// </summary>
        public Nullable<int> InventoryCount { get; set; }

        /// <summary>
        /// Gets or sets the InventoryMoney
        /// </summary>
        public Nullable<decimal> InventoryMoney { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

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

        //仓库名称
        public string WareHouseName
        {
            get
            {
                string wareHouseName = "";
                if (this.WfID != null)
                {
                    var sup = IoC.Resolve<IXMWareHousesService>().GetXMWareHousesById(WfID.Value);
                    if (sup != null)
                    {
                        wareHouseName = sup.Name;
                    }
                }
                return wareHouseName;
            }
        }

        #endregion
    }
}
