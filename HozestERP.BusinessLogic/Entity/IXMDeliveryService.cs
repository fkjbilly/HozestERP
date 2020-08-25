
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
    public partial interface IXMDeliveryService
    {
        #region IXMDeliveryService成员
        /// <summary>
        /// Insert into XMDelivery
        /// </summary>
        /// <param name="xmdelivery">XMDelivery</param>
    	void InsertXMDelivery(XMDelivery xmdelivery);
    	
        /// <summary>
        /// Update into XMDelivery
        /// </summary>
        /// <param name="xmdelivery">XMDelivery</param>
        void UpdateXMDelivery(XMDelivery xmdelivery);	
    	
        /// <summary>
        /// get to XMDelivery list
        /// </summary>
        List<XMDelivery> GetXMDeliveryList();
    	       
    	/// <summary>
    	/// get to XMDelivery Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMDelivery Page List</returns>
    	PagedList<XMDelivery> SearchXMDelivery(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMDelivery by Id
        /// </summary>
        /// <param name="id">XMDelivery Id</param>
        /// <returns>XMDelivery</returns>   
        XMDelivery GetXMDeliveryById(int id);
    
    	/// <summary>
        /// delete XMDelivery by Id
        /// </summary>
        /// <param name="Id">XMDelivery Id</param>
        void DeleteXMDelivery(int id);
    	
    	/// <summary>
        /// Batch delete XMDelivery by Id
        /// </summary>
        /// <param name="Ids">XMDelivery Id</param>
        void BatchDeleteXMDelivery(List<int> ids);

        #endregion
    }
}
