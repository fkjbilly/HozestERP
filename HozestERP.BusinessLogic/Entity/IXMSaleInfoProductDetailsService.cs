
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
    public partial interface IXMSaleInfoProductDetailsService
    {
        #region IXMSaleInfoProductDetailsService成员
        /// <summary>
        /// Insert into XMSaleInfoProductDetails
        /// </summary>
        /// <param name="xmsaleinfoproductdetails">XMSaleInfoProductDetails</param>
    	void InsertXMSaleInfoProductDetails(XMSaleInfoProductDetails xmsaleinfoproductdetails);
    	
        /// <summary>
        /// Update into XMSaleInfoProductDetails
        /// </summary>
        /// <param name="xmsaleinfoproductdetails">XMSaleInfoProductDetails</param>
        void UpdateXMSaleInfoProductDetails(XMSaleInfoProductDetails xmsaleinfoproductdetails);	
    	
        /// <summary>
        /// get to XMSaleInfoProductDetails list
        /// </summary>
        List<XMSaleInfoProductDetails> GetXMSaleInfoProductDetailsList();
    	       
    	/// <summary>
    	/// get to XMSaleInfoProductDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMSaleInfoProductDetails Page List</returns>
    	PagedList<XMSaleInfoProductDetails> SearchXMSaleInfoProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMSaleInfoProductDetails by Id
        /// </summary>
        /// <param name="id">XMSaleInfoProductDetails Id</param>
        /// <returns>XMSaleInfoProductDetails</returns>   
        XMSaleInfoProductDetails GetXMSaleInfoProductDetailsById(int id);
    
    	/// <summary>
        /// delete XMSaleInfoProductDetails by Id
        /// </summary>
        /// <param name="Id">XMSaleInfoProductDetails Id</param>
        void DeleteXMSaleInfoProductDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMSaleInfoProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMSaleInfoProductDetails Id</param>
        void BatchDeleteXMSaleInfoProductDetails(List<int> ids);

        #endregion
    }
}
