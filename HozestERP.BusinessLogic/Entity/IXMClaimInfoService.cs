
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
    public partial interface IXMClaimInfoService
    {
        #region IXMClaimInfoService成员
        /// <summary>
        /// Insert into XMClaimInfo
        /// </summary>
        /// <param name="xmclaiminfo">XMClaimInfo</param>
    	void InsertXMClaimInfo(XMClaimInfo xmclaiminfo);
    	
        /// <summary>
        /// Update into XMClaimInfo
        /// </summary>
        /// <param name="xmclaiminfo">XMClaimInfo</param>
        void UpdateXMClaimInfo(XMClaimInfo xmclaiminfo);	
    	
        /// <summary>
        /// get to XMClaimInfo list
        /// </summary>
        List<XMClaimInfo> GetXMClaimInfoList();
    	       
    	/// <summary>
    	/// get to XMClaimInfo Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMClaimInfo Page List</returns>
    	PagedList<XMClaimInfo> SearchXMClaimInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMClaimInfo by Id
        /// </summary>
        /// <param name="id">XMClaimInfo Id</param>
        /// <returns>XMClaimInfo</returns>   
        XMClaimInfo GetXMClaimInfoById(int id);
    
    	/// <summary>
        /// delete XMClaimInfo by Id
        /// </summary>
        /// <param name="Id">XMClaimInfo Id</param>
        void DeleteXMClaimInfo(int id);
    	
    	/// <summary>
        /// Batch delete XMClaimInfo by Id
        /// </summary>
        /// <param name="Ids">XMClaimInfo Id</param>
        void BatchDeleteXMClaimInfo(List<int> ids);

        #endregion
    }
}
