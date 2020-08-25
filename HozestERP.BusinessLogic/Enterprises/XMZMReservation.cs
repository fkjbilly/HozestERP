
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2017-08-03 14:08:13
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
using HozestERP.BusinessLogic.ManageCustomerService;

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class XMZMReservation: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the TypeID
        /// </summary>
        public Nullable<int> TypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the DemandID
        /// </summary>
        public Nullable<int> DemandID { get; set; }
    
    	/// <summary>
        /// Gets or sets the InstallationID
        /// </summary>
        public Nullable<int> InstallationID { get; set; }
    
    	/// <summary>
        /// Gets or sets the position
        /// </summary>
        public string Remarks { get; set; }
    
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
        /// Gets or sets the XM_InstallationList
        /// </summary>
        public virtual XMInstallationList XM_InstallationList { get; set; }
    
    	/// <summary>
        /// Gets or sets the XM_TypeTest
        /// </summary>
        public virtual XMTypeTest XM_TypeTest { get; set; }
    
    	/// <summary>
        /// Gets or sets the XM_ZMDemand
        /// </summary>
        public virtual XMZMDemand XM_ZMDemand { get; set; }

        #endregion
    }
}
