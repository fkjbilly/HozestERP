
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-12-22 09:49:06
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

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial interface IXMNickMonthlyTargetService
    {
        #region IXMNickMonthlyTargetService成员
        /// <summary>
        /// Insert into XMNickMonthlyTarget
        /// </summary>
        /// <param name="xmnickmonthlytarget">XMNickMonthlyTarget</param>
    	void InsertXMNickMonthlyTarget(XMNickMonthlyTarget xmnickmonthlytarget);
    	
        /// <summary>
        /// Update into XMNickMonthlyTarget
        /// </summary>
        /// <param name="xmnickmonthlytarget">XMNickMonthlyTarget</param>
        void UpdateXMNickMonthlyTarget(XMNickMonthlyTarget xmnickmonthlytarget);	
    	
        /// <summary>
        /// get to XMNickMonthlyTarget list
        /// </summary>
        List<XMNickMonthlyTarget> GetXMNickMonthlyTargetList();
        List<XMNickMonthlyTarget> GetXMNickMonthlyTargetListByAudit(DateTime begin, DateTime end);

    	/// <summary>
    	/// get to XMNickMonthlyTarget Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMNickMonthlyTarget Page List</returns>
    	PagedList<XMNickMonthlyTarget> SearchXMNickMonthlyTarget(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMNickMonthlyTarget by ID
        /// </summary>
        /// <param name="id">XMNickMonthlyTarget ID</param>
        /// <returns>XMNickMonthlyTarget</returns>   
        XMNickMonthlyTarget GetXMNickMonthlyTargetByID(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        List<XMNickMonthlyTarget> GetXMNickMonthlyTargetListByYear(int year, int nickID);
    	/// <summary>
        /// delete XMNickMonthlyTarget by ID
        /// </summary>
        /// <param name="ID">XMNickMonthlyTarget ID</param>
        void DeleteXMNickMonthlyTarget(int id);
    	
    	/// <summary>
        /// Batch delete XMNickMonthlyTarget by ID
        /// </summary>
        /// <param name="IDs">XMNickMonthlyTarget ID</param>
        void BatchDeleteXMNickMonthlyTarget(List<int> ids);

        #endregion
    }
}
