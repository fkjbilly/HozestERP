
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
    public partial class Bulletin: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the BulletinID
        /// </summary>
        public int BulletinID { get; set; }
    
    	/// <summary>
        /// Gets or sets the BulletinCode
        /// </summary>
        public string BulletinCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the BulletinTitle
        /// </summary>
        public string BulletinTitle { get; set; }
    
    	/// <summary>
        /// Gets or sets the BulletinTypeID
        /// </summary>
        public int BulletinTypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the PriorTypeID
        /// </summary>
        public int PriorTypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the EffectiveDate
        /// </summary>
        public System.DateTime EffectiveDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the InvalidDate
        /// </summary>
        public System.DateTime InvalidDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReleasedDate
        /// </summary>
        public Nullable<System.DateTime> ReleasedDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the BulletinStatus
        /// </summary>
        public int BulletinStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the Approval
        /// </summary>
        public string Approval { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }
    
    	/// <summary>
        /// Gets or sets the Deleted
        /// </summary>
        public bool Deleted { get; set; }
    
    	/// <summary>
        /// Gets or sets the Published
        /// </summary>
        public bool Published { get; set; }
    
    	/// <summary>
        /// Gets or sets the DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
    
    	/// <summary>
        /// Gets or sets the Created
        /// </summary>
        public System.DateTime Created { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public int CreatorID { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SCustomerInfo list
        /// </summary>
        public virtual ICollection<CustomerInfo> SCustomerInfo { get; set; }

        #endregion
    }
}
