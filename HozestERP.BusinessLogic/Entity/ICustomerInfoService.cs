
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
    public partial interface ICustomerInfoService
    {
        #region ICustomerInfoService成员
        /// <summary>
        /// Insert into CustomerInfo
        /// </summary>
        /// <param name="customerinfo">CustomerInfo</param>
    	void InsertCustomerInfo(CustomerInfo customerinfo);
    	
        /// <summary>
        /// Update into CustomerInfo
        /// </summary>
        /// <param name="customerinfo">CustomerInfo</param>
        void UpdateCustomerInfo(CustomerInfo customerinfo);	
    	
        /// <summary>
        /// get to CustomerInfo list
        /// </summary>
        List<CustomerInfo> GetCustomerInfoList();
    	       
    	/// <summary>
    	/// get to CustomerInfo Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CustomerInfo Page List</returns>
    	PagedList<CustomerInfo> SearchCustomerInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CustomerInfo by CustomerID
        /// </summary>
        /// <param name="customerid">CustomerInfo CustomerID</param>
        /// <returns>CustomerInfo</returns>   
        CustomerInfo GetCustomerInfoByCustomerID(int customerid);
    
    	/// <summary>
        /// delete CustomerInfo by CustomerID
        /// </summary>
        /// <param name="CustomerID">CustomerInfo CustomerID</param>
        void DeleteCustomerInfo(int customerid);
    	
    	/// <summary>
        /// Batch delete CustomerInfo by CustomerID
        /// </summary>
        /// <param name="CustomerIDs">CustomerInfo CustomerID</param>
        void BatchDeleteCustomerInfo(List<int> customerids);

        #endregion
    }
}
