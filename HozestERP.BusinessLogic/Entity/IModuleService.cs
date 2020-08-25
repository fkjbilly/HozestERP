
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:27:57
** 修改人:
** 修改日期:
** 描 述: 接口类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Entity
{
    public partial interface IModuleService
    {
        #region IModuleService成员
        /// <summary>
        /// Insert into Module
        /// </summary>
        /// <param name="module">Module</param>
    	void InsertModule(Module module);
    	
        /// <summary>
        /// Update into Module
        /// </summary>
        /// <param name="module">Module</param>
        void UpdateModule(Module module);	
    	
        /// <summary>
        /// get to Module list
        /// </summary>
        List<Module> GetModuleList();
    	       
    	/// <summary>
    	/// get to Module Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Module Page List</returns>
    	PagedList<Module> SearchModule(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Module by ModuleID
        /// </summary>
        /// <param name="moduleid">Module ModuleID</param>
        /// <returns>Module</returns>   
        Module GetModuleByModuleID(int moduleid);
    
    	/// <summary>
        /// delete Module by ModuleID
        /// </summary>
        /// <param name="ModuleID">Module ModuleID</param>
        void DeleteModule(int moduleid);
    	
    	/// <summary>
        /// Batch delete Module by ModuleID
        /// </summary>
        /// <param name="ModuleIDs">Module ModuleID</param>
        void BatchDeleteModule(List<int> moduleids);

        #endregion
    }
}
