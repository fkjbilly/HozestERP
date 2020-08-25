
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
    public partial interface IXMApplicationExchangeService
    {
        #region IXMApplicationExchangeService成员
        /// <summary>
        /// Insert into XMApplicationExchange
        /// </summary>
        /// <param name="xmapplicationexchange">XMApplicationExchange</param>
    	void InsertXMApplicationExchange(XMApplicationExchange xmapplicationexchange);
    	
        /// <summary>
        /// Update into XMApplicationExchange
        /// </summary>
        /// <param name="xmapplicationexchange">XMApplicationExchange</param>
        void UpdateXMApplicationExchange(XMApplicationExchange xmapplicationexchange);	
    	
        /// <summary>
        /// get to XMApplicationExchange list
        /// </summary>
        List<XMApplicationExchange> GetXMApplicationExchangeList();
    	       
    	/// <summary>
    	/// get to XMApplicationExchange Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMApplicationExchange Page List</returns>
    	PagedList<XMApplicationExchange> SearchXMApplicationExchange(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMApplicationExchange by ID
        /// </summary>
        /// <param name="id">XMApplicationExchange ID</param>
        /// <returns>XMApplicationExchange</returns>   
        XMApplicationExchange GetXMApplicationExchangeByID(int id);
    
    	/// <summary>
        /// delete XMApplicationExchange by ID
        /// </summary>
        /// <param name="ID">XMApplicationExchange ID</param>
        void DeleteXMApplicationExchange(int id);
    	
    	/// <summary>
        /// Batch delete XMApplicationExchange by ID
        /// </summary>
        /// <param name="IDs">XMApplicationExchange ID</param>
        void BatchDeleteXMApplicationExchange(List<int> ids);

        #endregion
    }
}
