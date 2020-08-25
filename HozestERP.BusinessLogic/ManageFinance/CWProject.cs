
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-06-02 15:24:28
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
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class CWProject: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the ParentID
        /// </summary>
        public Nullable<int> ParentID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProjectExplanation
        /// </summary>
        public string ProjectExplanation { get; set; }
    
    	/// <summary>
        /// Gets or sets the TableTypeId
        /// </summary>
        public Nullable<int> TableTypeId { get; set; }

        /// <summary>
        /// Gets or sets the DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
         
        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDateTime
        /// </summary>
        public Nullable<System.DateTime> CreateDateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateDateTime { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// 获取父节点菜单
        /// </summary>
        public CWProject ParentProjects
        {
            get
            {
                return IoC.Resolve<ICWProjectService>().GetCWProjectById(this.ParentID.GetValueOrDefault());
            }
        }

        ///// <summary>
        ///// 获取子节点菜单列表
        ///// </summary>
        //public List<CWProject> childProjects
        //{
        //    get
        //    {
        //        return IoC.Resolve<ICWProjectService>().GetCWProjectByModuleID(this.Id);
        //    }
        //}
    	
        #endregion
    }
}
