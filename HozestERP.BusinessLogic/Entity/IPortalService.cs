
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
    public partial interface IPortalService
    {
        #region IPortalService成员
        /// <summary>
        /// Insert into Portal
        /// </summary>
        /// <param name="portal">Portal</param>
    	void InsertPortal(Portal portal);
    	
        /// <summary>
        /// Update into Portal
        /// </summary>
        /// <param name="portal">Portal</param>
        void UpdatePortal(Portal portal);	
    	
        /// <summary>
        /// get to Portal list
        /// </summary>
        List<Portal> GetPortalList();
    	       
    	/// <summary>
    	/// get to Portal Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Portal Page List</returns>
    	PagedList<Portal> SearchPortal(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Portal by ID
        /// </summary>
        /// <param name="id">Portal ID</param>
        /// <returns>Portal</returns>   
        Portal GetPortalByID(int id);
    
    	/// <summary>
        /// delete Portal by ID
        /// </summary>
        /// <param name="ID">Portal ID</param>
        void DeletePortal(int id);
    	
    	/// <summary>
        /// Batch delete Portal by ID
        /// </summary>
        /// <param name="IDs">Portal ID</param>
        void BatchDeletePortal(List<int> ids);

        #endregion
    }
}
