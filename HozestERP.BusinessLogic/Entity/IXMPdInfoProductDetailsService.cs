
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
    public partial interface IXMPdInfoProductDetailsService
    {
        #region IXMPdInfoProductDetailsService成员
        /// <summary>
        /// Insert into XMPdInfoProductDetails
        /// </summary>
        /// <param name="xmpdinfoproductdetails">XMPdInfoProductDetails</param>
    	void InsertXMPdInfoProductDetails(XMPdInfoProductDetails xmpdinfoproductdetails);
    	
        /// <summary>
        /// Update into XMPdInfoProductDetails
        /// </summary>
        /// <param name="xmpdinfoproductdetails">XMPdInfoProductDetails</param>
        void UpdateXMPdInfoProductDetails(XMPdInfoProductDetails xmpdinfoproductdetails);	
    	
        /// <summary>
        /// get to XMPdInfoProductDetails list
        /// </summary>
        List<XMPdInfoProductDetails> GetXMPdInfoProductDetailsList();
    	       
    	/// <summary>
    	/// get to XMPdInfoProductDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMPdInfoProductDetails Page List</returns>
    	PagedList<XMPdInfoProductDetails> SearchXMPdInfoProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMPdInfoProductDetails by Id
        /// </summary>
        /// <param name="id">XMPdInfoProductDetails Id</param>
        /// <returns>XMPdInfoProductDetails</returns>   
        XMPdInfoProductDetails GetXMPdInfoProductDetailsById(int id);
    
    	/// <summary>
        /// delete XMPdInfoProductDetails by Id
        /// </summary>
        /// <param name="Id">XMPdInfoProductDetails Id</param>
        void DeleteXMPdInfoProductDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMPdInfoProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMPdInfoProductDetails Id</param>
        void BatchDeleteXMPdInfoProductDetails(List<int> ids);

        #endregion
    }
}
