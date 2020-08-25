
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
    public partial interface IXMInvoiceInfoService
    {
        #region IXMInvoiceInfoService成员
        /// <summary>
        /// Insert into XMInvoiceInfo
        /// </summary>
        /// <param name="xminvoiceinfo">XMInvoiceInfo</param>
    	void InsertXMInvoiceInfo(XMInvoiceInfo xminvoiceinfo);
    	
        /// <summary>
        /// Update into XMInvoiceInfo
        /// </summary>
        /// <param name="xminvoiceinfo">XMInvoiceInfo</param>
        void UpdateXMInvoiceInfo(XMInvoiceInfo xminvoiceinfo);	
    	
        /// <summary>
        /// get to XMInvoiceInfo list
        /// </summary>
        List<XMInvoiceInfo> GetXMInvoiceInfoList();
    	       
    	/// <summary>
    	/// get to XMInvoiceInfo Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMInvoiceInfo Page List</returns>
    	PagedList<XMInvoiceInfo> SearchXMInvoiceInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMInvoiceInfo by ID
        /// </summary>
        /// <param name="id">XMInvoiceInfo ID</param>
        /// <returns>XMInvoiceInfo</returns>   
        XMInvoiceInfo GetXMInvoiceInfoByID(int id);
    
    	/// <summary>
        /// delete XMInvoiceInfo by ID
        /// </summary>
        /// <param name="ID">XMInvoiceInfo ID</param>
        void DeleteXMInvoiceInfo(int id);
    	
    	/// <summary>
        /// Batch delete XMInvoiceInfo by ID
        /// </summary>
        /// <param name="IDs">XMInvoiceInfo ID</param>
        void BatchDeleteXMInvoiceInfo(List<int> ids);

        #endregion
    }
}
