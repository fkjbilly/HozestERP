
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
    public partial class KFChatLog: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public long Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the Customer
        /// </summary>
        public string Customer { get; set; }
    
    	/// <summary>
        /// Gets or sets the Waiter
        /// </summary>
        public string Waiter { get; set; }
    
    	/// <summary>
        /// Gets or sets the Content
        /// </summary>
        public string Content { get; set; }
    
    	/// <summary>
        /// Gets or sets the SId
        /// </summary>
        public string SId { get; set; }
    
    	/// <summary>
        /// Gets or sets the SkuId
        /// </summary>
        public Nullable<long> SkuId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Time
        /// </summary>
        public Nullable<System.DateTime> Time { get; set; }
    
    	/// <summary>
        /// Gets or sets the Channel
        /// </summary>
        public Nullable<int> Channel { get; set; }
    
    	/// <summary>
        /// Gets or sets the WaiterSend
        /// </summary>
        public Nullable<bool> WaiterSend { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsDelete
        /// </summary>
        public Nullable<bool> IsDelete { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
