/******************************************************************
** Copyright (c) 2008 -2012 
** 创建人:方银朗
** 创建日期:2011-02-11
** 修改人: 方银朗
** 修改日期: 2011-02-11
** 描 述: 方银朗 2011-02-11 增加类的头部注释
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

using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ModuleManagement
{
    public partial class Module: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ModuleID
        /// </summary>
        public int ModuleID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ParentID
        /// </summary>
        public Nullable<int> ParentID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ModuleName
        /// </summary>
        public string ModuleName { get; set; }
    
    	/// <summary>
        /// Gets or sets the ModuleCode
        /// </summary>
        public string ModuleCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the isTarget
        /// </summary>
        public bool isTarget { get; set; }
    
    	/// <summary>
        /// Gets or sets the href
        /// </summary>
        public string href { get; set; }
    
    	/// <summary>
        /// Gets or sets the Expand
        /// </summary>
        public bool Expand { get; set; }
    
    	/// <summary>
        /// Gets or sets the Published
        /// </summary>
        public bool Published { get; set; }
    
    	/// <summary>
        /// Gets or sets the Deleted
        /// </summary>
        public bool Deleted { get; set; }
    
    	/// <summary>
        /// Gets or sets the DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the iconCls
        /// </summary>
        public string iconCls { get; set; }

        /// <summary>
        /// Gets or sets the AppIconCls
        /// </summary>
        public string AppIconCls { get; set; }

        #endregion

        #region Custom Properties
        /// <summary>
        /// 获取父节点菜单
        /// </summary>
        public Module ParentModule
        {
            get
            {
                return IoC.Resolve<IModuleService>().getModuleByModuleID(this.ParentID.GetValueOrDefault());
            }
        }

        /// <summary>
        /// 获取子节点菜单列表
        /// </summary>
        public List<Module> childModules
        {
            get
            {
                return IoC.Resolve<IModuleService>().GetModulesByModuleID(this.ModuleID);
            }
        }
        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the ACL list
        /// </summary>
        public virtual ICollection<CustomerAction> SCustomerActions { get; set; }


        #endregion
    }
}
