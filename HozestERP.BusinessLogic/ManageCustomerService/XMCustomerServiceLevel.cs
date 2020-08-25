
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-05-27 09:22:34
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

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMCustomerServiceLevel: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the RankName
        /// </summary>
        public string RankName { get; set; }
    
    	/// <summary>
        /// Gets or sets the RankNumber
        /// </summary>
        public Nullable<int> RankNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the BasicSalary
        /// </summary>
        public Nullable<int> BasicSalary { get; set; }
    
    	/// <summary>
        /// Gets or sets the BonusBase
        /// </summary>
        public Nullable<int> BonusBase { get; set; }
    
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
    
    	/// <summary>
        /// Gets or sets the IsEnabled
        /// </summary>
        public Nullable<bool> IsEnabled { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
