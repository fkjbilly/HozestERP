
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
    public partial interface ISys_StarSetService
    {
        #region ISys_StarSetService成员
        /// <summary>
        /// Insert into Sys_StarSet
        /// </summary>
        /// <param name="sys_starset">Sys_StarSet</param>
    	void InsertSys_StarSet(Sys_StarSet sys_starset);
    	
        /// <summary>
        /// Update into Sys_StarSet
        /// </summary>
        /// <param name="sys_starset">Sys_StarSet</param>
        void UpdateSys_StarSet(Sys_StarSet sys_starset);	
    	
        /// <summary>
        /// get to Sys_StarSet list
        /// </summary>
        List<Sys_StarSet> GetSys_StarSetList();
    	       
    	/// <summary>
    	/// get to Sys_StarSet Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Sys_StarSet Page List</returns>
    	PagedList<Sys_StarSet> SearchSys_StarSet(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Sys_StarSet by ID
        /// </summary>
        /// <param name="id">Sys_StarSet ID</param>
        /// <returns>Sys_StarSet</returns>   
        Sys_StarSet GetSys_StarSetByID(int id);
    
    	/// <summary>
        /// delete Sys_StarSet by ID
        /// </summary>
        /// <param name="ID">Sys_StarSet ID</param>
        void DeleteSys_StarSet(int id);
    	
    	/// <summary>
        /// Batch delete Sys_StarSet by ID
        /// </summary>
        /// <param name="IDs">Sys_StarSet ID</param>
        void BatchDeleteSys_StarSet(List<int> ids);

        #endregion
    }
}
