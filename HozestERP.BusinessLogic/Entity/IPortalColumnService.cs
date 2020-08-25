
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
    public partial interface IPortalColumnService
    {
        #region IPortalColumnService成员
        /// <summary>
        /// Insert into PortalColumn
        /// </summary>
        /// <param name="portalcolumn">PortalColumn</param>
    	void InsertPortalColumn(PortalColumn portalcolumn);
    	
        /// <summary>
        /// Update into PortalColumn
        /// </summary>
        /// <param name="portalcolumn">PortalColumn</param>
        void UpdatePortalColumn(PortalColumn portalcolumn);	
    	
        /// <summary>
        /// get to PortalColumn list
        /// </summary>
        List<PortalColumn> GetPortalColumnList();
    	       
    	/// <summary>
    	/// get to PortalColumn Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>PortalColumn Page List</returns>
    	PagedList<PortalColumn> SearchPortalColumn(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a PortalColumn by ID
        /// </summary>
        /// <param name="id">PortalColumn ID</param>
        /// <returns>PortalColumn</returns>   
        PortalColumn GetPortalColumnByID(int id);
    
    	/// <summary>
        /// delete PortalColumn by ID
        /// </summary>
        /// <param name="ID">PortalColumn ID</param>
        void DeletePortalColumn(int id);
    	
    	/// <summary>
        /// Batch delete PortalColumn by ID
        /// </summary>
        /// <param name="IDs">PortalColumn ID</param>
        void BatchDeletePortalColumn(List<int> ids);

        #endregion
    }
}
