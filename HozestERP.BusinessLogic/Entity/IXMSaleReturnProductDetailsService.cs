
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
    public partial interface IXMSaleReturnProductDetailsService
    {
        #region IXMSaleReturnProductDetailsService成员
        /// <summary>
        /// Insert into XMSaleReturnProductDetails
        /// </summary>
        /// <param name="xmsalereturnproductdetails">XMSaleReturnProductDetails</param>
    	void InsertXMSaleReturnProductDetails(XMSaleReturnProductDetails xmsalereturnproductdetails);
    	
        /// <summary>
        /// Update into XMSaleReturnProductDetails
        /// </summary>
        /// <param name="xmsalereturnproductdetails">XMSaleReturnProductDetails</param>
        void UpdateXMSaleReturnProductDetails(XMSaleReturnProductDetails xmsalereturnproductdetails);	
    	
        /// <summary>
        /// get to XMSaleReturnProductDetails list
        /// </summary>
        List<XMSaleReturnProductDetails> GetXMSaleReturnProductDetailsList();
    	       
    	/// <summary>
    	/// get to XMSaleReturnProductDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMSaleReturnProductDetails Page List</returns>
    	PagedList<XMSaleReturnProductDetails> SearchXMSaleReturnProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMSaleReturnProductDetails by Id
        /// </summary>
        /// <param name="id">XMSaleReturnProductDetails Id</param>
        /// <returns>XMSaleReturnProductDetails</returns>   
        XMSaleReturnProductDetails GetXMSaleReturnProductDetailsById(int id);
    
    	/// <summary>
        /// delete XMSaleReturnProductDetails by Id
        /// </summary>
        /// <param name="Id">XMSaleReturnProductDetails Id</param>
        void DeleteXMSaleReturnProductDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMSaleReturnProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMSaleReturnProductDetails Id</param>
        void BatchDeleteXMSaleReturnProductDetails(List<int> ids);

        #endregion
    }
}
