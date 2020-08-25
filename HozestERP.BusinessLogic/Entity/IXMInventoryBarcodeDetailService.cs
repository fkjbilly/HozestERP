
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
    public partial interface IXMInventoryBarcodeDetailService
    {
        #region IXMInventoryBarcodeDetailService成员
        /// <summary>
        /// Insert into XMInventoryBarcodeDetail
        /// </summary>
        /// <param name="xminventorybarcodedetail">XMInventoryBarcodeDetail</param>
    	void InsertXMInventoryBarcodeDetail(XMInventoryBarcodeDetail xminventorybarcodedetail);
    	
        /// <summary>
        /// Update into XMInventoryBarcodeDetail
        /// </summary>
        /// <param name="xminventorybarcodedetail">XMInventoryBarcodeDetail</param>
        void UpdateXMInventoryBarcodeDetail(XMInventoryBarcodeDetail xminventorybarcodedetail);	
    	
        /// <summary>
        /// get to XMInventoryBarcodeDetail list
        /// </summary>
        List<XMInventoryBarcodeDetail> GetXMInventoryBarcodeDetailList();
    	       
    	/// <summary>
    	/// get to XMInventoryBarcodeDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMInventoryBarcodeDetail Page List</returns>
    	PagedList<XMInventoryBarcodeDetail> SearchXMInventoryBarcodeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMInventoryBarcodeDetail by Id
        /// </summary>
        /// <param name="id">XMInventoryBarcodeDetail Id</param>
        /// <returns>XMInventoryBarcodeDetail</returns>   
        XMInventoryBarcodeDetail GetXMInventoryBarcodeDetailById(int id);
    
    	/// <summary>
        /// delete XMInventoryBarcodeDetail by Id
        /// </summary>
        /// <param name="Id">XMInventoryBarcodeDetail Id</param>
        void DeleteXMInventoryBarcodeDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMInventoryBarcodeDetail by Id
        /// </summary>
        /// <param name="Ids">XMInventoryBarcodeDetail Id</param>
        void BatchDeleteXMInventoryBarcodeDetail(List<int> ids);

        #endregion
    }
}
