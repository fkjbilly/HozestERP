
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
    public partial interface ISys_CustomerStarService
    {
        #region ISys_CustomerStarService成员
        /// <summary>
        /// Insert into Sys_CustomerStar
        /// </summary>
        /// <param name="sys_customerstar">Sys_CustomerStar</param>
    	void InsertSys_CustomerStar(Sys_CustomerStar sys_customerstar);
    	
        /// <summary>
        /// Update into Sys_CustomerStar
        /// </summary>
        /// <param name="sys_customerstar">Sys_CustomerStar</param>
        void UpdateSys_CustomerStar(Sys_CustomerStar sys_customerstar);	
    	
        /// <summary>
        /// get to Sys_CustomerStar list
        /// </summary>
        List<Sys_CustomerStar> GetSys_CustomerStarList();
    	       
    	/// <summary>
    	/// get to Sys_CustomerStar Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Sys_CustomerStar Page List</returns>
    	PagedList<Sys_CustomerStar> SearchSys_CustomerStar(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Sys_CustomerStar by ID
        /// </summary>
        /// <param name="id">Sys_CustomerStar ID</param>
        /// <returns>Sys_CustomerStar</returns>   
        Sys_CustomerStar GetSys_CustomerStarByID(int id);
    
    	/// <summary>
        /// delete Sys_CustomerStar by ID
        /// </summary>
        /// <param name="ID">Sys_CustomerStar ID</param>
        void DeleteSys_CustomerStar(int id);
    	
    	/// <summary>
        /// Batch delete Sys_CustomerStar by ID
        /// </summary>
        /// <param name="IDs">Sys_CustomerStar ID</param>
        void BatchDeleteSys_CustomerStar(List<int> ids);

        #endregion
    }
}
