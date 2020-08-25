
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
    public partial interface IXMProductionOrderDetailsService
    {
        #region IXMProductionOrderDetailsService成员
        /// <summary>
        /// Insert into XMProductionOrderDetails
        /// </summary>
        /// <param name="xmproductionorderdetails">XMProductionOrderDetails</param>
    	void InsertXMProductionOrderDetails(XMProductionOrderDetails xmproductionorderdetails);
    	
        /// <summary>
        /// Update into XMProductionOrderDetails
        /// </summary>
        /// <param name="xmproductionorderdetails">XMProductionOrderDetails</param>
        void UpdateXMProductionOrderDetails(XMProductionOrderDetails xmproductionorderdetails);	
    	
        /// <summary>
        /// get to XMProductionOrderDetails list
        /// </summary>
        List<XMProductionOrderDetails> GetXMProductionOrderDetailsList();
    	       
    	/// <summary>
    	/// get to XMProductionOrderDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMProductionOrderDetails Page List</returns>
    	PagedList<XMProductionOrderDetails> SearchXMProductionOrderDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMProductionOrderDetails by Id
        /// </summary>
        /// <param name="id">XMProductionOrderDetails Id</param>
        /// <returns>XMProductionOrderDetails</returns>   
        XMProductionOrderDetails GetXMProductionOrderDetailsById(int id);
    
    	/// <summary>
        /// delete XMProductionOrderDetails by Id
        /// </summary>
        /// <param name="Id">XMProductionOrderDetails Id</param>
        void DeleteXMProductionOrderDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMProductionOrderDetails by Id
        /// </summary>
        /// <param name="Ids">XMProductionOrderDetails Id</param>
        void BatchDeleteXMProductionOrderDetails(List<int> ids);

        #endregion
    }
}
