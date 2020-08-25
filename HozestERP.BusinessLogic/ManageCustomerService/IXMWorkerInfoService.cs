
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2018-01-23 13:30:30
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
using System.Linq.Expressions;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial interface IXMWorkerInfoService
    {
        #region IXMWorkerInfoService成员
        /// <summary>
        /// Insert into XMWorkerInfo
        /// </summary>
        /// <param name="xmworkerinfo">XMWorkerInfo</param>
    	void InsertXMWorkerInfo(XMWorkerInfo xmworkerinfo);
    	
        /// <summary>
        /// Update into XMWorkerInfo
        /// </summary>
        /// <param name="xmworkerinfo">XMWorkerInfo</param>
        void UpdateXMWorkerInfo(XMWorkerInfo xmworkerinfo);	
    	
        /// <summary>
        /// get to XMWorkerInfo list
        /// </summary>
        List<XMWorkerInfo> GetXMWorkerInfoList(string Name,string Province,string City,string Region);
    	       
    	/// <summary>
    	/// get to XMWorkerInfo Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMWorkerInfo Page List</returns>
    	PagedList<XMWorkerInfo> SearchXMWorkerInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMWorkerInfo by ID
        /// </summary>
        /// <param name="id">XMWorkerInfo ID</param>
        /// <returns>XMWorkerInfo</returns>   
        XMWorkerInfo GetXMWorkerInfoByID(int id);
    
    	/// <summary>
        /// delete XMWorkerInfo by ID
        /// </summary>
        /// <param name="ID">XMWorkerInfo ID</param>
        void DeleteXMWorkerInfo(int id);
    	
    	/// <summary>
        /// Batch delete XMWorkerInfo by ID
        /// </summary>
        /// <param name="IDs">XMWorkerInfo ID</param>
        void BatchDeleteXMWorkerInfo(List<int> ids);

        XMWorkerInfo getSingle(Expression<Func<XMWorkerInfo, bool>> predicate);

        IQueryable<XMWorkerInfo> getList(Expression<Func<XMWorkerInfo, bool>> predicate);

        #endregion

    }
}
