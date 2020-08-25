
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
    public partial interface IXMCustomerRankService
    {
        #region IXMCustomerRankService成员
        /// <summary>
        /// Insert into XMCustomerRank
        /// </summary>
        /// <param name="xmcustomerrank">XMCustomerRank</param>
    	void InsertXMCustomerRank(XMCustomerRank xmcustomerrank);
    	
        /// <summary>
        /// Update into XMCustomerRank
        /// </summary>
        /// <param name="xmcustomerrank">XMCustomerRank</param>
        void UpdateXMCustomerRank(XMCustomerRank xmcustomerrank);	
    	
        /// <summary>
        /// get to XMCustomerRank list
        /// </summary>
        List<XMCustomerRank> GetXMCustomerRankList();
    	       
    	/// <summary>
    	/// get to XMCustomerRank Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMCustomerRank Page List</returns>
    	PagedList<XMCustomerRank> SearchXMCustomerRank(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMCustomerRank by CustomerID
        /// </summary>
        /// <param name="customerid">XMCustomerRank CustomerID</param>
        /// <returns>XMCustomerRank</returns>   
        XMCustomerRank GetXMCustomerRankByCustomerID(int customerid);
    
    	/// <summary>
        /// delete XMCustomerRank by CustomerID
        /// </summary>
        /// <param name="CustomerID">XMCustomerRank CustomerID</param>
        void DeleteXMCustomerRank(int customerid);
    	
    	/// <summary>
        /// Batch delete XMCustomerRank by CustomerID
        /// </summary>
        /// <param name="CustomerIDs">XMCustomerRank CustomerID</param>
        void BatchDeleteXMCustomerRank(List<int> customerids);

        #endregion
    }
}
