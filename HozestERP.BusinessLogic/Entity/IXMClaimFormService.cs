
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
    public partial interface IXMClaimFormService
    {
        #region IXMClaimFormService成员
        /// <summary>
        /// Insert into XMClaimForm
        /// </summary>
        /// <param name="xmclaimform">XMClaimForm</param>
    	void InsertXMClaimForm(XMClaimForm xmclaimform);
    	
        /// <summary>
        /// Update into XMClaimForm
        /// </summary>
        /// <param name="xmclaimform">XMClaimForm</param>
        void UpdateXMClaimForm(XMClaimForm xmclaimform);	
    	
        /// <summary>
        /// get to XMClaimForm list
        /// </summary>
        List<XMClaimForm> GetXMClaimFormList();
    	       
    	/// <summary>
    	/// get to XMClaimForm Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMClaimForm Page List</returns>
    	PagedList<XMClaimForm> SearchXMClaimForm(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMClaimForm by ID
        /// </summary>
        /// <param name="id">XMClaimForm ID</param>
        /// <returns>XMClaimForm</returns>   
        XMClaimForm GetXMClaimFormByID(int id);
    
    	/// <summary>
        /// delete XMClaimForm by ID
        /// </summary>
        /// <param name="ID">XMClaimForm ID</param>
        void DeleteXMClaimForm(int id);
    	
    	/// <summary>
        /// Batch delete XMClaimForm by ID
        /// </summary>
        /// <param name="IDs">XMClaimForm ID</param>
        void BatchDeleteXMClaimForm(List<int> ids);

        #endregion
    }
}
