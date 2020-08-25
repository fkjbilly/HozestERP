
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
    public partial interface IXMOrderInfoService
    {
        #region IXMOrderInfoService成员
        /// <summary>
        /// Insert into XMOrderInfo
        /// </summary>
        /// <param name="xmorderinfo">XMOrderInfo</param>
    	void InsertXMOrderInfo(XMOrderInfo xmorderinfo);
    	
        /// <summary>
        /// Update into XMOrderInfo
        /// </summary>
        /// <param name="xmorderinfo">XMOrderInfo</param>
        void UpdateXMOrderInfo(XMOrderInfo xmorderinfo);	
    	
        /// <summary>
        /// get to XMOrderInfo list
        /// </summary>
        List<XMOrderInfo> GetXMOrderInfoList();
    	       
    	/// <summary>
    	/// get to XMOrderInfo Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMOrderInfo Page List</returns>
    	PagedList<XMOrderInfo> SearchXMOrderInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMOrderInfo by ID
        /// </summary>
        /// <param name="id">XMOrderInfo ID</param>
        /// <returns>XMOrderInfo</returns>   
        XMOrderInfo GetXMOrderInfoByID(int id);
    
    	/// <summary>
        /// delete XMOrderInfo by ID
        /// </summary>
        /// <param name="ID">XMOrderInfo ID</param>
        void DeleteXMOrderInfo(int id);
    	
    	/// <summary>
        /// Batch delete XMOrderInfo by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfo ID</param>
        void BatchDeleteXMOrderInfo(List<int> ids);

        #endregion
    }
}
