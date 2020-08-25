
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
    public partial interface IXMStorageProductDetailsService
    {
        #region IXMStorageProductDetailsService成员
        /// <summary>
        /// Insert into XMStorageProductDetails
        /// </summary>
        /// <param name="xmstorageproductdetails">XMStorageProductDetails</param>
    	void InsertXMStorageProductDetails(XMStorageProductDetails xmstorageproductdetails);
    	
        /// <summary>
        /// Update into XMStorageProductDetails
        /// </summary>
        /// <param name="xmstorageproductdetails">XMStorageProductDetails</param>
        void UpdateXMStorageProductDetails(XMStorageProductDetails xmstorageproductdetails);	
    	
        /// <summary>
        /// get to XMStorageProductDetails list
        /// </summary>
        List<XMStorageProductDetails> GetXMStorageProductDetailsList();
    	       
    	/// <summary>
    	/// get to XMStorageProductDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMStorageProductDetails Page List</returns>
    	PagedList<XMStorageProductDetails> SearchXMStorageProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMStorageProductDetails by Id
        /// </summary>
        /// <param name="id">XMStorageProductDetails Id</param>
        /// <returns>XMStorageProductDetails</returns>   
        XMStorageProductDetails GetXMStorageProductDetailsById(int id);
    
    	/// <summary>
        /// delete XMStorageProductDetails by Id
        /// </summary>
        /// <param name="Id">XMStorageProductDetails Id</param>
        void DeleteXMStorageProductDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMStorageProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMStorageProductDetails Id</param>
        void BatchDeleteXMStorageProductDetails(List<int> ids);

        #endregion
    }
}
