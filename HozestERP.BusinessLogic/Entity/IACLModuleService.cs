
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
    public partial interface IACLModuleService
    {
        #region IACLModuleService成员
        /// <summary>
        /// Insert into ACLModule
        /// </summary>
        /// <param name="aclmodule">ACLModule</param>
    	void InsertACLModule(ACLModule aclmodule);
    	
        /// <summary>
        /// Update into ACLModule
        /// </summary>
        /// <param name="aclmodule">ACLModule</param>
        void UpdateACLModule(ACLModule aclmodule);	
    	
        /// <summary>
        /// get to ACLModule list
        /// </summary>
        List<ACLModule> GetACLModuleList();
    	       
    	/// <summary>
    	/// get to ACLModule Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>ACLModule Page List</returns>
    	PagedList<ACLModule> SearchACLModule(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a ACLModule by ACLModuleId
        /// </summary>
        /// <param name="aclmoduleid">ACLModule ACLModuleId</param>
        /// <returns>ACLModule</returns>   
        ACLModule GetACLModuleByACLModuleId(int aclmoduleid);
    
    	/// <summary>
        /// delete ACLModule by ACLModuleId
        /// </summary>
        /// <param name="ACLModuleId">ACLModule ACLModuleId</param>
        void DeleteACLModule(int aclmoduleid);
    	
    	/// <summary>
        /// Batch delete ACLModule by ACLModuleId
        /// </summary>
        /// <param name="ACLModuleIds">ACLModule ACLModuleId</param>
        void BatchDeleteACLModule(List<int> aclmoduleids);

        #endregion
    }
}
