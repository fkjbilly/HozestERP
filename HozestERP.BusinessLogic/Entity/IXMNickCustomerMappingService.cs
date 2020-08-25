
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
    public partial interface IXMNickCustomerMappingService
    {
        #region IXMNickCustomerMappingService成员
        /// <summary>
        /// Insert into XMNickCustomerMapping
        /// </summary>
        /// <param name="xmnickcustomermapping">XMNickCustomerMapping</param>
    	void InsertXMNickCustomerMapping(XMNickCustomerMapping xmnickcustomermapping);
    	
        /// <summary>
        /// Update into XMNickCustomerMapping
        /// </summary>
        /// <param name="xmnickcustomermapping">XMNickCustomerMapping</param>
        void UpdateXMNickCustomerMapping(XMNickCustomerMapping xmnickcustomermapping);	
    	
        /// <summary>
        /// get to XMNickCustomerMapping list
        /// </summary>
        List<XMNickCustomerMapping> GetXMNickCustomerMappingList();
    	       
    	/// <summary>
    	/// get to XMNickCustomerMapping Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMNickCustomerMapping Page List</returns>
    	PagedList<XMNickCustomerMapping> SearchXMNickCustomerMapping(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="nickcustomerid">XMNickCustomerMapping NickCustomerID</param>
        /// <returns>XMNickCustomerMapping</returns>   
        XMNickCustomerMapping GetXMNickCustomerMappingByNickCustomerID(int nickcustomerid);
    
    	/// <summary>
        /// delete XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerID">XMNickCustomerMapping NickCustomerID</param>
        void DeleteXMNickCustomerMapping(int nickcustomerid);
    	
    	/// <summary>
        /// Batch delete XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerIDs">XMNickCustomerMapping NickCustomerID</param>
        void BatchDeleteXMNickCustomerMapping(List<int> nickcustomerids);

        #endregion
    }
}
