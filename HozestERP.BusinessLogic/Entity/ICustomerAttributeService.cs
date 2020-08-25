
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
    public partial interface ICustomerAttributeService
    {
        #region ICustomerAttributeService成员
        /// <summary>
        /// Insert into CustomerAttribute
        /// </summary>
        /// <param name="customerattribute">CustomerAttribute</param>
    	void InsertCustomerAttribute(CustomerAttribute customerattribute);
    	
        /// <summary>
        /// Update into CustomerAttribute
        /// </summary>
        /// <param name="customerattribute">CustomerAttribute</param>
        void UpdateCustomerAttribute(CustomerAttribute customerattribute);	
    	
        /// <summary>
        /// get to CustomerAttribute list
        /// </summary>
        List<CustomerAttribute> GetCustomerAttributeList();
    	       
    	/// <summary>
    	/// get to CustomerAttribute Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CustomerAttribute Page List</returns>
    	PagedList<CustomerAttribute> SearchCustomerAttribute(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CustomerAttribute by CustomerAttributeId
        /// </summary>
        /// <param name="customerattributeid">CustomerAttribute CustomerAttributeId</param>
        /// <returns>CustomerAttribute</returns>   
        CustomerAttribute GetCustomerAttributeByCustomerAttributeId(int customerattributeid);
    
    	/// <summary>
        /// delete CustomerAttribute by CustomerAttributeId
        /// </summary>
        /// <param name="CustomerAttributeId">CustomerAttribute CustomerAttributeId</param>
        void DeleteCustomerAttribute(int customerattributeid);
    	
    	/// <summary>
        /// Batch delete CustomerAttribute by CustomerAttributeId
        /// </summary>
        /// <param name="CustomerAttributeIds">CustomerAttribute CustomerAttributeId</param>
        void BatchDeleteCustomerAttribute(List<int> customerattributeids);

        #endregion
    }
}
