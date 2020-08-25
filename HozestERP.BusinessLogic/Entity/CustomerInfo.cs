
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
    public partial class CustomerInfo: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public int CustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the DepartmentID
        /// </summary>
        public int DepartmentID { get; set; }
    
    	/// <summary>
        /// Gets or sets the JobNumber
        /// </summary>
        public string JobNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }
    
    	/// <summary>
        /// Gets or sets the GenderID
        /// </summary>
        public int GenderID { get; set; }
    
    	/// <summary>
        /// Gets or sets the NationalityID
        /// </summary>
        public int NationalityID { get; set; }
    
    	/// <summary>
        /// Gets or sets the AnimalID
        /// </summary>
        public int AnimalID { get; set; }
    
    	/// <summary>
        /// Gets or sets the RegisteredResidence
        /// </summary>
        public string RegisteredResidence { get; set; }
    
    	/// <summary>
        /// Gets or sets the Birthday
        /// </summary>
        public Nullable<System.DateTime> Birthday { get; set; }
    
    	/// <summary>
        /// Gets or sets the MarriageID
        /// </summary>
        public Nullable<int> MarriageID { get; set; }
    
    	/// <summary>
        /// Gets or sets the BloodTypeID
        /// </summary>
        public int BloodTypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the PoliticalStatusID
        /// </summary>
        public Nullable<int> PoliticalStatusID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Stature
        /// </summary>
        public int Stature { get; set; }
    
    	/// <summary>
        /// Gets or sets the Childbearing
        /// </summary>
        public bool Childbearing { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerStatusID
        /// </summary>
        public int CustomerStatusID { get; set; }
    
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
        public Nullable<System.DateTime> Created { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the IDNumber
        /// </summary>
        public string IDNumber { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SCustomer
        /// </summary>
        public virtual Customer SCustomer { get; set; }
    
    	/// <summary>
        /// Gets or sets the SDepartment
        /// </summary>
        public virtual Department SDepartment { get; set; }
    
    	/// <summary>
        /// Gets or sets the SBulletins list
        /// </summary>
        public virtual ICollection<Bulletin> SBulletins { get; set; }

        #endregion
    }
}
