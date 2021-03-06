
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-09-24 15:14:39
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMClaimFormDetailService
    {
        #region IXMClaimFormDetailService成员
        /// <summary>
        /// Insert into XMClaimFormDetail
        /// </summary>
        /// <param name="xmclaimformdetail">XMClaimFormDetail</param>
    	void InsertXMClaimFormDetail(XMClaimFormDetail xmclaimformdetail);
    	
        /// <summary>
        /// Update into XMClaimFormDetail
        /// </summary>
        /// <param name="xmclaimformdetail">XMClaimFormDetail</param>
        void UpdateXMClaimFormDetail(XMClaimFormDetail xmclaimformdetail);	
    	
        /// <summary>
        /// get to XMClaimFormDetail list
        /// </summary>
        List<XMClaimFormDetail> GetXMClaimFormDetailList();
        List<XMClaimFormDetail> GetXMClaimFormDetailListByClaimFormID(int ClaimFormID);

    	/// <summary>
    	/// get to XMClaimFormDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMClaimFormDetail Page List</returns>
    	PagedList<XMClaimFormDetail> SearchXMClaimFormDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMClaimFormDetail by ID
        /// </summary>
        /// <param name="id">XMClaimFormDetail ID</param>
        /// <returns>XMClaimFormDetail</returns>   
        XMClaimFormDetail GetXMClaimFormDetailByID(int id);
    
    	/// <summary>
        /// delete XMClaimFormDetail by ID
        /// </summary>
        /// <param name="ID">XMClaimFormDetail ID</param>
        void DeleteXMClaimFormDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMClaimFormDetail by ID
        /// </summary>
        /// <param name="IDs">XMClaimFormDetail ID</param>
        void BatchDeleteXMClaimFormDetail(List<int> ids);

        #endregion
    }
}
