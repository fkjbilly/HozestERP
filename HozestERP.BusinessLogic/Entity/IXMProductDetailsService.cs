
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
    public partial interface IXMProductDetailsService
    {
        #region IXMProductDetailsService成员
        /// <summary>
        /// Insert into XMProductDetails
        /// </summary>
        /// <param name="xmproductdetails">XMProductDetails</param>
    	void InsertXMProductDetails(XMProductDetails xmproductdetails);
    	
        /// <summary>
        /// Update into XMProductDetails
        /// </summary>
        /// <param name="xmproductdetails">XMProductDetails</param>
        void UpdateXMProductDetails(XMProductDetails xmproductdetails);	
    	
        /// <summary>
        /// get to XMProductDetails list
        /// </summary>
        List<XMProductDetails> GetXMProductDetailsList();
    	       
    	/// <summary>
    	/// get to XMProductDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMProductDetails Page List</returns>
    	PagedList<XMProductDetails> SearchXMProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMProductDetails by Id
        /// </summary>
        /// <param name="id">XMProductDetails Id</param>
        /// <returns>XMProductDetails</returns>   
        XMProductDetails GetXMProductDetailsById(int id);
    
    	/// <summary>
        /// delete XMProductDetails by Id
        /// </summary>
        /// <param name="Id">XMProductDetails Id</param>
        void DeleteXMProductDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMProductDetails Id</param>
        void BatchDeleteXMProductDetails(List<int> ids);

        #endregion
    }
}
