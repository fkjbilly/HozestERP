
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
    public partial interface ICustomerSessionService
    {
        #region ICustomerSessionService成员
        /// <summary>
        /// Insert into CustomerSession
        /// </summary>
        /// <param name="customersession">CustomerSession</param>
    	void InsertCustomerSession(CustomerSession customersession);
    	
        /// <summary>
        /// Update into CustomerSession
        /// </summary>
        /// <param name="customersession">CustomerSession</param>
        void UpdateCustomerSession(CustomerSession customersession);	
    	
        /// <summary>
        /// get to CustomerSession list
        /// </summary>
        List<CustomerSession> GetCustomerSessionList();
    	       
    	/// <summary>
    	/// get to CustomerSession Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CustomerSession Page List</returns>
    	PagedList<CustomerSession> SearchCustomerSession(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CustomerSession by CustomerSessionGUID
        /// </summary>
        /// <param name="customersessionguid">CustomerSession CustomerSessionGUID</param>
        /// <returns>CustomerSession</returns>   
        CustomerSession GetCustomerSessionByCustomerSessionGUID(System.Guid customersessionguid);
    
    	/// <summary>
        /// delete CustomerSession by CustomerSessionGUID
        /// </summary>
        /// <param name="CustomerSessionGUID">CustomerSession CustomerSessionGUID</param>
        void DeleteCustomerSession(System.Guid customersessionguid);
    	
    	/// <summary>
        /// Batch delete CustomerSession by CustomerSessionGUID
        /// </summary>
        /// <param name="CustomerSessionGUIDs">CustomerSession CustomerSessionGUID</param>
        void BatchDeleteCustomerSession(List<System.Guid> customersessionguids);

        #endregion
    }
}
