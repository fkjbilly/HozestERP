
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
    public partial interface IXMOtherMonthlyTargetService
    {
        #region IXMOtherMonthlyTargetService成员
        /// <summary>
        /// Insert into XMOtherMonthlyTarget
        /// </summary>
        /// <param name="xmothermonthlytarget">XMOtherMonthlyTarget</param>
    	void InsertXMOtherMonthlyTarget(XMOtherMonthlyTarget xmothermonthlytarget);
    	
        /// <summary>
        /// Update into XMOtherMonthlyTarget
        /// </summary>
        /// <param name="xmothermonthlytarget">XMOtherMonthlyTarget</param>
        void UpdateXMOtherMonthlyTarget(XMOtherMonthlyTarget xmothermonthlytarget);	
    	
        /// <summary>
        /// get to XMOtherMonthlyTarget list
        /// </summary>
        List<XMOtherMonthlyTarget> GetXMOtherMonthlyTargetList();
    	List<XMOtherMonthlyTarget> GetXMOtherMonthlyTargetListByAudit(DateTime begin, DateTime end);

    	/// <summary>
    	/// get to XMOtherMonthlyTarget Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMOtherMonthlyTarget Page List</returns>
    	PagedList<XMOtherMonthlyTarget> SearchXMOtherMonthlyTarget(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMOtherMonthlyTarget by ID
        /// </summary>
        /// <param name="id">XMOtherMonthlyTarget ID</param>
        /// <returns>XMOtherMonthlyTarget</returns>   
        XMOtherMonthlyTarget GetXMOtherMonthlyTargetByID(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depid"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        List<XMOtherMonthlyTarget> GetXMOtherMonthlyTargetListByParm(int depid, int year);

    
    	/// <summary>
        /// delete XMOtherMonthlyTarget by ID
        /// </summary>
        /// <param name="ID">XMOtherMonthlyTarget ID</param>
        void DeleteXMOtherMonthlyTarget(int id);
    	
    	/// <summary>
        /// Batch delete XMOtherMonthlyTarget by ID
        /// </summary>
        /// <param name="IDs">XMOtherMonthlyTarget ID</param>
        void BatchDeleteXMOtherMonthlyTarget(List<int> ids);

        #endregion
    }
}
