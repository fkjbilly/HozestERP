
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
    public partial class XMOrderInfoPlanRecord: BaseEntity
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
        /// Gets or sets the Status
        /// </summary>
        public string Status { get; set; }
    
    	/// <summary>
        /// Gets or sets the DeliveryTime
        /// </summary>
        public Nullable<System.DateTime> DeliveryTime { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
