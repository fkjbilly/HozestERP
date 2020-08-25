
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
    public partial interface IXMDeliveryDetailsService
    {
        #region IXMDeliveryDetailsService成员
        /// <summary>
        /// Insert into XMDeliveryDetails
        /// </summary>
        /// <param name="xmdeliverydetails">XMDeliveryDetails</param>
    	void InsertXMDeliveryDetails(XMDeliveryDetails xmdeliverydetails);
    	
        /// <summary>
        /// Update into XMDeliveryDetails
        /// </summary>
        /// <param name="xmdeliverydetails">XMDeliveryDetails</param>
        void UpdateXMDeliveryDetails(XMDeliveryDetails xmdeliverydetails);	
    	
        /// <summary>
        /// get to XMDeliveryDetails list
        /// </summary>
        List<XMDeliveryDetails> GetXMDeliveryDetailsList();
    	       
    	/// <summary>
    	/// get to XMDeliveryDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMDeliveryDetails Page List</returns>
    	PagedList<XMDeliveryDetails> SearchXMDeliveryDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMDeliveryDetails by Id
        /// </summary>
        /// <param name="id">XMDeliveryDetails Id</param>
        /// <returns>XMDeliveryDetails</returns>   
        XMDeliveryDetails GetXMDeliveryDetailsById(int id);
    
    	/// <summary>
        /// delete XMDeliveryDetails by Id
        /// </summary>
        /// <param name="Id">XMDeliveryDetails Id</param>
        void DeleteXMDeliveryDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMDeliveryDetails by Id
        /// </summary>
        /// <param name="Ids">XMDeliveryDetails Id</param>
        void BatchDeleteXMDeliveryDetails(List<int> ids);

        #endregion
    }
}
