
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
    public partial interface IXMSaleDeliveryBarCodeDetailService
    {
        #region IXMSaleDeliveryBarCodeDetailService成员
        /// <summary>
        /// Insert into XMSaleDeliveryBarCodeDetail
        /// </summary>
        /// <param name="xmsaledeliverybarcodedetail">XMSaleDeliveryBarCodeDetail</param>
    	void InsertXMSaleDeliveryBarCodeDetail(XMSaleDeliveryBarCodeDetail xmsaledeliverybarcodedetail);
    	
        /// <summary>
        /// Update into XMSaleDeliveryBarCodeDetail
        /// </summary>
        /// <param name="xmsaledeliverybarcodedetail">XMSaleDeliveryBarCodeDetail</param>
        void UpdateXMSaleDeliveryBarCodeDetail(XMSaleDeliveryBarCodeDetail xmsaledeliverybarcodedetail);	
    	
        /// <summary>
        /// get to XMSaleDeliveryBarCodeDetail list
        /// </summary>
        List<XMSaleDeliveryBarCodeDetail> GetXMSaleDeliveryBarCodeDetailList();
    	       
    	/// <summary>
    	/// get to XMSaleDeliveryBarCodeDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMSaleDeliveryBarCodeDetail Page List</returns>
    	PagedList<XMSaleDeliveryBarCodeDetail> SearchXMSaleDeliveryBarCodeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMSaleDeliveryBarCodeDetail by Id
        /// </summary>
        /// <param name="id">XMSaleDeliveryBarCodeDetail Id</param>
        /// <returns>XMSaleDeliveryBarCodeDetail</returns>   
        XMSaleDeliveryBarCodeDetail GetXMSaleDeliveryBarCodeDetailById(int id);
    
    	/// <summary>
        /// delete XMSaleDeliveryBarCodeDetail by Id
        /// </summary>
        /// <param name="Id">XMSaleDeliveryBarCodeDetail Id</param>
        void DeleteXMSaleDeliveryBarCodeDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMSaleDeliveryBarCodeDetail by Id
        /// </summary>
        /// <param name="Ids">XMSaleDeliveryBarCodeDetail Id</param>
        void BatchDeleteXMSaleDeliveryBarCodeDetail(List<int> ids);

        #endregion
    }
}
