
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2017-04-26 15:27:24
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

namespace HozestERP.BusinessLogic.Entity
{
    public partial class LogisticsAging: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Line
        /// </summary>
        public string Line { get; set; }
    
    	/// <summary>
        /// Gets or sets the DepartureProvince
        /// </summary>
        public string DepartureProvince { get; set; }
    
    	/// <summary>
        /// Gets or sets the DepartureCity
        /// </summary>
        public string DepartureCity { get; set; }
    
    	/// <summary>
        /// Gets or sets the DestinationProvince
        /// </summary>
        public string DestinationProvince { get; set; }
    
    	/// <summary>
        /// Gets or sets the DestinationCity
        /// </summary>
        public string DestinationCity { get; set; }
    
    	/// <summary>
        /// Gets or sets the Pathway
        /// </summary>
        public string Pathway { get; set; }
    
    	/// <summary>
        /// Gets or sets the PathwayDate
        /// </summary>
        public Nullable<int> PathwayDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the DestinationDate
        /// </summary>
        public Nullable<int> DestinationDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsSouth
        /// </summary>
        public Nullable<bool> IsSouth { get; set; }
    
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
    		
    	
        #endregion
    }
}
