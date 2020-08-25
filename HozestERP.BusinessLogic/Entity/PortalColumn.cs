
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
    public partial class PortalColumn: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ColumnNumberID
        /// </summary>
        public int ColumnNumberID { get; set; }
    
    	/// <summary>
        /// Gets or sets the PortalID
        /// </summary>
        public int PortalID { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsExpand
        /// </summary>
        public int IsExpand { get; set; }
    
    	/// <summary>
        /// Gets or sets the SortIndex
        /// </summary>
        public int SortIndex { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SPortal
        /// </summary>
        public virtual Portal SPortal { get; set; }
    
    	/// <summary>
        /// Gets or sets the SPortalColumnNumber
        /// </summary>
        public virtual PortalColumnNumber SPortalColumnNumber { get; set; }

        #endregion
    }
}
