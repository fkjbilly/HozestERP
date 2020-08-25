
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
    public partial interface IXMClaimInfoProductDetailsService
    {
        #region IXMClaimInfoProductDetailsService成员
        /// <summary>
        /// Insert into XMClaimInfoProductDetails
        /// </summary>
        /// <param name="xmclaiminfoproductdetails">XMClaimInfoProductDetails</param>
    	void InsertXMClaimInfoProductDetails(XMClaimInfoProductDetails xmclaiminfoproductdetails);
    	
        /// <summary>
        /// Update into XMClaimInfoProductDetails
        /// </summary>
        /// <param name="xmclaiminfoproductdetails">XMClaimInfoProductDetails</param>
        void UpdateXMClaimInfoProductDetails(XMClaimInfoProductDetails xmclaiminfoproductdetails);	
    	
        /// <summary>
        /// get to XMClaimInfoProductDetails list
        /// </summary>
        List<XMClaimInfoProductDetails> GetXMClaimInfoProductDetailsList();
    	       
    	/// <summary>
    	/// get to XMClaimInfoProductDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMClaimInfoProductDetails Page List</returns>
    	PagedList<XMClaimInfoProductDetails> SearchXMClaimInfoProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMClaimInfoProductDetails by ID
        /// </summary>
        /// <param name="id">XMClaimInfoProductDetails ID</param>
        /// <returns>XMClaimInfoProductDetails</returns>   
        XMClaimInfoProductDetails GetXMClaimInfoProductDetailsByID(int id);
    
    	/// <summary>
        /// delete XMClaimInfoProductDetails by ID
        /// </summary>
        /// <param name="ID">XMClaimInfoProductDetails ID</param>
        void DeleteXMClaimInfoProductDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMClaimInfoProductDetails by ID
        /// </summary>
        /// <param name="IDs">XMClaimInfoProductDetails ID</param>
        void BatchDeleteXMClaimInfoProductDetails(List<int> ids);

        #endregion
    }
}
