
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
    public partial interface IXMProductService
    {
        #region IXMProductService成员
        /// <summary>
        /// Insert into XMProduct
        /// </summary>
        /// <param name="xmproduct">XMProduct</param>
    	void InsertXMProduct(XMProduct xmproduct);
    	
        /// <summary>
        /// Update into XMProduct
        /// </summary>
        /// <param name="xmproduct">XMProduct</param>
        void UpdateXMProduct(XMProduct xmproduct);	
    	
        /// <summary>
        /// get to XMProduct list
        /// </summary>
        List<XMProduct> GetXMProductList();
    	       
    	/// <summary>
    	/// get to XMProduct Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMProduct Page List</returns>
    	PagedList<XMProduct> SearchXMProduct(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMProduct by Id
        /// </summary>
        /// <param name="id">XMProduct Id</param>
        /// <returns>XMProduct</returns>   
        XMProduct GetXMProductById(int id);
    
    	/// <summary>
        /// delete XMProduct by Id
        /// </summary>
        /// <param name="Id">XMProduct Id</param>
        void DeleteXMProduct(int id);
    	
    	/// <summary>
        /// Batch delete XMProduct by Id
        /// </summary>
        /// <param name="Ids">XMProduct Id</param>
        void BatchDeleteXMProduct(List<int> ids);

        #endregion
    }
}
