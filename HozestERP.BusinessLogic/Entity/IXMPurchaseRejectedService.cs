
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
    public partial interface IXMPurchaseRejectedService
    {
        #region IXMPurchaseRejectedService成员
        /// <summary>
        /// Insert into XMPurchaseRejected
        /// </summary>
        /// <param name="xmpurchaserejected">XMPurchaseRejected</param>
    	void InsertXMPurchaseRejected(XMPurchaseRejected xmpurchaserejected);
    	
        /// <summary>
        /// Update into XMPurchaseRejected
        /// </summary>
        /// <param name="xmpurchaserejected">XMPurchaseRejected</param>
        void UpdateXMPurchaseRejected(XMPurchaseRejected xmpurchaserejected);	
    	
        /// <summary>
        /// get to XMPurchaseRejected list
        /// </summary>
        List<XMPurchaseRejected> GetXMPurchaseRejectedList();
    	       
    	/// <summary>
    	/// get to XMPurchaseRejected Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMPurchaseRejected Page List</returns>
    	PagedList<XMPurchaseRejected> SearchXMPurchaseRejected(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMPurchaseRejected by Id
        /// </summary>
        /// <param name="id">XMPurchaseRejected Id</param>
        /// <returns>XMPurchaseRejected</returns>   
        XMPurchaseRejected GetXMPurchaseRejectedById(int id);
    
    	/// <summary>
        /// delete XMPurchaseRejected by Id
        /// </summary>
        /// <param name="Id">XMPurchaseRejected Id</param>
        void DeleteXMPurchaseRejected(int id);
    	
    	/// <summary>
        /// Batch delete XMPurchaseRejected by Id
        /// </summary>
        /// <param name="Ids">XMPurchaseRejected Id</param>
        void BatchDeleteXMPurchaseRejected(List<int> ids);

        #endregion
    }
}
