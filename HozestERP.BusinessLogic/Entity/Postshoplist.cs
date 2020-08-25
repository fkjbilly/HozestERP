
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
    public partial class Postshoplist: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the NickCustomerID
        /// </summary>
        public int NickCustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Post
        /// </summary>
        public string Post { get; set; }
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
