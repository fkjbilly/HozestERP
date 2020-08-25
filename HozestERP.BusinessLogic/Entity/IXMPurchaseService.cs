
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
    public partial interface IXMPurchaseService
    {
        #region IXMPurchaseService成员
        /// <summary>
        /// Insert into XMPurchase
        /// </summary>
        /// <param name="xmpurchase">XMPurchase</param>
    	void InsertXMPurchase(XMPurchase xmpurchase);
    	
        /// <summary>
        /// Update into XMPurchase
        /// </summary>
        /// <param name="xmpurchase">XMPurchase</param>
        void UpdateXMPurchase(XMPurchase xmpurchase);	
    	
        /// <summary>
        /// get to XMPurchase list
        /// </summary>
        List<XMPurchase> GetXMPurchaseList();
    	       
    	/// <summary>
    	/// get to XMPurchase Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMPurchase Page List</returns>
    	PagedList<XMPurchase> SearchXMPurchase(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMPurchase by Id
        /// </summary>
        /// <param name="id">XMPurchase Id</param>
        /// <returns>XMPurchase</returns>   
        XMPurchase GetXMPurchaseById(int id);
    
    	/// <summary>
        /// delete XMPurchase by Id
        /// </summary>
        /// <param name="Id">XMPurchase Id</param>
        void DeleteXMPurchase(int id);
    	
    	/// <summary>
        /// Batch delete XMPurchase by Id
        /// </summary>
        /// <param name="Ids">XMPurchase Id</param>
        void BatchDeleteXMPurchase(List<int> ids);

        #endregion
    }
}
