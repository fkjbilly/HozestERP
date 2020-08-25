
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
    public partial interface ISys_AlertTimeSetService
    {
        #region ISys_AlertTimeSetService成员
        /// <summary>
        /// Insert into Sys_AlertTimeSet
        /// </summary>
        /// <param name="sys_alerttimeset">Sys_AlertTimeSet</param>
    	void InsertSys_AlertTimeSet(Sys_AlertTimeSet sys_alerttimeset);
    	
        /// <summary>
        /// Update into Sys_AlertTimeSet
        /// </summary>
        /// <param name="sys_alerttimeset">Sys_AlertTimeSet</param>
        void UpdateSys_AlertTimeSet(Sys_AlertTimeSet sys_alerttimeset);	
    	
        /// <summary>
        /// get to Sys_AlertTimeSet list
        /// </summary>
        List<Sys_AlertTimeSet> GetSys_AlertTimeSetList();
    	       
    	/// <summary>
    	/// get to Sys_AlertTimeSet Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Sys_AlertTimeSet Page List</returns>
    	PagedList<Sys_AlertTimeSet> SearchSys_AlertTimeSet(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Sys_AlertTimeSet by ID
        /// </summary>
        /// <param name="id">Sys_AlertTimeSet ID</param>
        /// <returns>Sys_AlertTimeSet</returns>   
        Sys_AlertTimeSet GetSys_AlertTimeSetByID(int id);
    
    	/// <summary>
        /// delete Sys_AlertTimeSet by ID
        /// </summary>
        /// <param name="ID">Sys_AlertTimeSet ID</param>
        void DeleteSys_AlertTimeSet(int id);
    	
    	/// <summary>
        /// Batch delete Sys_AlertTimeSet by ID
        /// </summary>
        /// <param name="IDs">Sys_AlertTimeSet ID</param>
        void BatchDeleteSys_AlertTimeSet(List<int> ids);

        #endregion
    }
}
