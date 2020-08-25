
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
    public partial interface IXMSaleDeliveryService
    {
        #region IXMSaleDeliveryService成员
        /// <summary>
        /// Insert into XMSaleDelivery
        /// </summary>
        /// <param name="xmsaledelivery">XMSaleDelivery</param>
    	void InsertXMSaleDelivery(XMSaleDelivery xmsaledelivery);
    	
        /// <summary>
        /// Update into XMSaleDelivery
        /// </summary>
        /// <param name="xmsaledelivery">XMSaleDelivery</param>
        void UpdateXMSaleDelivery(XMSaleDelivery xmsaledelivery);	
    	
        /// <summary>
        /// get to XMSaleDelivery list
        /// </summary>
        List<XMSaleDelivery> GetXMSaleDeliveryList();
    	       
    	/// <summary>
    	/// get to XMSaleDelivery Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMSaleDelivery Page List</returns>
    	PagedList<XMSaleDelivery> SearchXMSaleDelivery(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMSaleDelivery by Id
        /// </summary>
        /// <param name="id">XMSaleDelivery Id</param>
        /// <returns>XMSaleDelivery</returns>   
        XMSaleDelivery GetXMSaleDeliveryById(int id);
    
    	/// <summary>
        /// delete XMSaleDelivery by Id
        /// </summary>
        /// <param name="Id">XMSaleDelivery Id</param>
        void DeleteXMSaleDelivery(int id);
    	
    	/// <summary>
        /// Batch delete XMSaleDelivery by Id
        /// </summary>
        /// <param name="Ids">XMSaleDelivery Id</param>
        void BatchDeleteXMSaleDelivery(List<int> ids);

        #endregion
    }
}
