
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-06-07 14:27:52
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

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class ProvinceWarehouse: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the WarehouseID
        /// </summary>
        public Nullable<int> WarehouseID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProvinceName
        /// </summary>
        public string ProvinceName { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnabled
        /// </summary>
        public Nullable<bool> IsEnabled { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdatorID
        /// </summary>
        public Nullable<int> UpdatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateTime { get; set; }

        #endregion
        #region Custom Properties

        public string WarehouseName
        {
            get
            {
                string result = "";
                if (this.WarehouseID != null && this.WarehouseID > 0)
                {
                    var item = IoC.Resolve<IProvinceWarehouseService>().GetWarehouseName(this.WarehouseID.Value);
                    if (item != null)
                    {
                        result = item.CodeName;
                    }
                }
                return result;
            }
        }
    	
        #endregion
    }
}
