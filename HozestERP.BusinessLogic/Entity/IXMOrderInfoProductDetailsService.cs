
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
    public partial interface IXMOrderInfoProductDetailsService
    {
        #region IXMOrderInfoProductDetailsService成员
        /// <summary>
        /// Insert into XMOrderInfoProductDetails
        /// </summary>
        /// <param name="xmorderinfoproductdetails">XMOrderInfoProductDetails</param>
    	void InsertXMOrderInfoProductDetails(XMOrderInfoProductDetails xmorderinfoproductdetails);
    	
        /// <summary>
        /// Update into XMOrderInfoProductDetails
        /// </summary>
        /// <param name="xmorderinfoproductdetails">XMOrderInfoProductDetails</param>
        void UpdateXMOrderInfoProductDetails(XMOrderInfoProductDetails xmorderinfoproductdetails);	
    	
        /// <summary>
        /// get to XMOrderInfoProductDetails list
        /// </summary>
        List<XMOrderInfoProductDetails> GetXMOrderInfoProductDetailsList();
    	       
    	/// <summary>
    	/// get to XMOrderInfoProductDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMOrderInfoProductDetails Page List</returns>
    	PagedList<XMOrderInfoProductDetails> SearchXMOrderInfoProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="id">XMOrderInfoProductDetails ID</param>
        /// <returns>XMOrderInfoProductDetails</returns>   
        XMOrderInfoProductDetails GetXMOrderInfoProductDetailsByID(int id);
    
    	/// <summary>
        /// delete XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="ID">XMOrderInfoProductDetails ID</param>
        void DeleteXMOrderInfoProductDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfoProductDetails ID</param>
        void BatchDeleteXMOrderInfoProductDetails(List<int> ids);

        #endregion
    }
}
