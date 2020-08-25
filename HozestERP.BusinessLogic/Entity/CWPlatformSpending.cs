
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
    public partial class CWPlatformSpending: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProfitProjectId
        /// </summary>
        public Nullable<int> ProfitProjectId { get; set; }
    
    	/// <summary>
        /// Gets or sets the YearStr
        /// </summary>
        public string YearStr { get; set; }
    
    	/// <summary>
        /// Gets or sets the MonthStr
        /// </summary>
        public string MonthStr { get; set; }
    
    	/// <summary>
        /// Gets or sets the CountMoney
        /// </summary>
        public Nullable<decimal> CountMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDateTime
        /// </summary>
        public Nullable<System.DateTime> CreateDateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateDateTime { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
