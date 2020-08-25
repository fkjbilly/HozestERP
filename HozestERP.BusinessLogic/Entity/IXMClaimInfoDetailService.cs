
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
    public partial interface IXMClaimInfoDetailService
    {
        #region IXMClaimInfoDetailService成员
        /// <summary>
        /// Insert into XMClaimInfoDetail
        /// </summary>
        /// <param name="xmclaiminfodetail">XMClaimInfoDetail</param>
    	void InsertXMClaimInfoDetail(XMClaimInfoDetail xmclaiminfodetail);
    	
        /// <summary>
        /// Update into XMClaimInfoDetail
        /// </summary>
        /// <param name="xmclaiminfodetail">XMClaimInfoDetail</param>
        void UpdateXMClaimInfoDetail(XMClaimInfoDetail xmclaiminfodetail);	
    	
        /// <summary>
        /// get to XMClaimInfoDetail list
        /// </summary>
        List<XMClaimInfoDetail> GetXMClaimInfoDetailList();
    	       
    	/// <summary>
    	/// get to XMClaimInfoDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMClaimInfoDetail Page List</returns>
    	PagedList<XMClaimInfoDetail> SearchXMClaimInfoDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMClaimInfoDetail by Id
        /// </summary>
        /// <param name="id">XMClaimInfoDetail Id</param>
        /// <returns>XMClaimInfoDetail</returns>   
        XMClaimInfoDetail GetXMClaimInfoDetailById(int id);
    
    	/// <summary>
        /// delete XMClaimInfoDetail by Id
        /// </summary>
        /// <param name="Id">XMClaimInfoDetail Id</param>
        void DeleteXMClaimInfoDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMClaimInfoDetail by Id
        /// </summary>
        /// <param name="Ids">XMClaimInfoDetail Id</param>
        void BatchDeleteXMClaimInfoDetail(List<int> ids);

        #endregion
    }
}
