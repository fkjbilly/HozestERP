
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
    public partial interface IPortalColumnNumberService
    {
        #region IPortalColumnNumberService成员
        /// <summary>
        /// Insert into PortalColumnNumber
        /// </summary>
        /// <param name="portalcolumnnumber">PortalColumnNumber</param>
    	void InsertPortalColumnNumber(PortalColumnNumber portalcolumnnumber);
    	
        /// <summary>
        /// Update into PortalColumnNumber
        /// </summary>
        /// <param name="portalcolumnnumber">PortalColumnNumber</param>
        void UpdatePortalColumnNumber(PortalColumnNumber portalcolumnnumber);	
    	
        /// <summary>
        /// get to PortalColumnNumber list
        /// </summary>
        List<PortalColumnNumber> GetPortalColumnNumberList();
    	       
    	/// <summary>
    	/// get to PortalColumnNumber Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>PortalColumnNumber Page List</returns>
    	PagedList<PortalColumnNumber> SearchPortalColumnNumber(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a PortalColumnNumber by ID
        /// </summary>
        /// <param name="id">PortalColumnNumber ID</param>
        /// <returns>PortalColumnNumber</returns>   
        PortalColumnNumber GetPortalColumnNumberByID(int id);
    
    	/// <summary>
        /// delete PortalColumnNumber by ID
        /// </summary>
        /// <param name="ID">PortalColumnNumber ID</param>
        void DeletePortalColumnNumber(int id);
    	
    	/// <summary>
        /// Batch delete PortalColumnNumber by ID
        /// </summary>
        /// <param name="IDs">PortalColumnNumber ID</param>
        void BatchDeletePortalColumnNumber(List<int> ids);

        #endregion
    }
}
