
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-06-08 08:58:31
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial interface IXMAllocateProductDetailsService
    {
        #region IXMAllocateProductDetailsService成员
        /// <summary>
        /// Insert into XMAllocateProductDetails
        /// </summary>
        /// <param name="xmallocateproductdetails">XMAllocateProductDetails</param>
    	void InsertXMAllocateProductDetails(XMAllocateProductDetails xmallocateproductdetails);
    	
        /// <summary>
        /// Update into XMAllocateProductDetails
        /// </summary>
        /// <param name="xmallocateproductdetails">XMAllocateProductDetails</param>
        void UpdateXMAllocateProductDetails(XMAllocateProductDetails xmallocateproductdetails);	
    	
        /// <summary>
        /// get to XMAllocateProductDetails list
        /// </summary>
        List<XMAllocateProductDetails> GetXMAllocateProductDetailsList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="allcateId"></param>
        /// <returns></returns>
        List<XMAllocateProductDetails> GetXMAllocateProductDetailsListByAllcateId(int allcateId);
    	       
    	/// <summary>
    	/// get to XMAllocateProductDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMAllocateProductDetails Page List</returns>
    	PagedList<XMAllocateProductDetails> SearchXMAllocateProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMAllocateProductDetails by Id
        /// </summary>
        /// <param name="id">XMAllocateProductDetails Id</param>
        /// <returns>XMAllocateProductDetails</returns>   
        XMAllocateProductDetails GetXMAllocateProductDetailsById(int id);
    
    	/// <summary>
        /// delete XMAllocateProductDetails by Id
        /// </summary>
        /// <param name="Id">XMAllocateProductDetails Id</param>
        void DeleteXMAllocateProductDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMAllocateProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMAllocateProductDetails Id</param>
        void BatchDeleteXMAllocateProductDetails(List<int> ids);

        #endregion
    }
}
