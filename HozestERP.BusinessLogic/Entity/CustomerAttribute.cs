
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
    public partial class CustomerAttribute: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the CustomerAttributeId
        /// </summary>
        public int CustomerAttributeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerId
        /// </summary>
        public int CustomerId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Key
        /// </summary>
        public string Key { get; set; }
    
    	/// <summary>
        /// Gets or sets the Value
        /// </summary>
        public string Value { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SCustomer
        /// </summary>
        public virtual Customer SCustomer { get; set; }

        #endregion
    }
}
