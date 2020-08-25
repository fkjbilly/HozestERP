
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2017-08-01 17:21:49
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

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class XMTypeTest: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the type
        /// </summary>
        public string type { get; set; }

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
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_ZMDemand list
        /// </summary>
        public virtual ICollection<XMZMDemand> XM_ZMDemand { get; set; }

        /// <summary>
        /// Gets or sets the XM_ZMReservation list
        /// </summary>
        public virtual ICollection<XMZMReservation> XM_ZMReservation { get; set; }
    	
        #endregion
    }
}
