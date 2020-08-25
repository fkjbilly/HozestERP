
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2017-07-27 15:27:33
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMLogisticsFeeBranch: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// 项目ID
        /// </summary>
        public Nullable<int> ProjectID { get; set; }
    
    	/// <summary>
        /// 物流公司ID
        /// </summary>
        public Nullable<int> LogisticsID { get; set; }
    
    	/// <summary>
        /// 商品品类
        /// </summary>
        public Nullable<int> ProductCategoryID { get; set; }
    
    	/// <summary>
        /// 费用
        /// </summary>
        public Nullable<decimal> Fee { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        #endregion

        #region Custom Properties
    		
    	
        #endregion

    }
}
