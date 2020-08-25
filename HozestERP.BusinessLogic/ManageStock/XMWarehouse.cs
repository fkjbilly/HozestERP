
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-07-10 10:14:52
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

namespace HozestERP.BusinessLogic.ManageStock
{
    public partial class XMWarehouse: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProvinceID
        /// </summary>
        public string ProvinceID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CityID
        /// </summary>
        public string CityID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CountyID
        /// </summary>
        public string CountyID { get; set; }
    
    	/// <summary>
        /// Gets or sets the WarehouseName
        /// </summary>
        public string WarehouseName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Position
        /// </summary>
        public string Position { get; set; }
    
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
        /// 省
        /// </summary>
        public string ProvinceName
        {
            get
            {
                if (this.ProvinceID != null)
                {
                    return IoC.Resolve<XMWarehouseService>().GetProvinceNameByID(this.ProvinceID.Trim());
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 市
        /// </summary>
        public string CityName
        {
            get
            {
                if (this.CityID != null)
                {
                    return IoC.Resolve<XMWarehouseService>().GetCityNameByID(this.CityID.Trim());
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 区
        /// </summary>
        public string CountyName
        {
            get
            {
                if (this.CountyID != null)
                {
                    return IoC.Resolve<XMWarehouseService>().GetCountyNameByID(this.CountyID.Trim());
                }
                else
                {
                    return null;
                }
            }
        }
    	
        #endregion
    }
}
