
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2018-01-25 11:01:49
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
    public partial interface IXMClaimReasonService
    {
        #region IXMClaimReasonService成员
        /// <summary>
        /// Insert into XMClaimReason
        /// </summary>
        /// <param name="xmclaimreason">XMClaimReason</param>
    	void InsertXMClaimReason(XMClaimReason xmclaimreason);
    	
        /// <summary>
        /// Update into XMClaimReason
        /// </summary>
        /// <param name="xmclaimreason">XMClaimReason</param>
        void UpdateXMClaimReason(XMClaimReason xmclaimreason);	
    	
        /// <summary>
        /// get to XMClaimReason list
        /// </summary>
        List<XMClaimReason> GetXMClaimReasonList();

        List<XMClaimReasonNew> GetXMClaimNewReasonList();

        /// <summary>
        /// get to XMClaimReason Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMClaimReason Page List</returns>
        PagedList<XMClaimReason> SearchXMClaimReason(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMClaimReason by ID
        /// </summary>
        /// <param name="id">XMClaimReason ID</param>
        /// <returns>XMClaimReason</returns>   
        XMClaimReason GetXMClaimReasonByID(int id);
    
    	/// <summary>
        /// delete XMClaimReason by ID
        /// </summary>
        /// <param name="ID">XMClaimReason ID</param>
        void DeleteXMClaimReason(int id);
    	
    	/// <summary>
        /// Batch delete XMClaimReason by ID
        /// </summary>
        /// <param name="IDs">XMClaimReason ID</param>
        void BatchDeleteXMClaimReason(List<int> ids);

        XMClaimReason getSingle(Expression<Func<XMClaimReason, bool>> predicate);

        IQueryable<XMClaimReason> getList(Expression<Func<XMClaimReason, bool>> predicate);

        #endregion

    }
}
