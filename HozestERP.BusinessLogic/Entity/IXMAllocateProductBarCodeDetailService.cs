
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
    public partial interface IXMAllocateProductBarCodeDetailService
    {
        #region IXMAllocateProductBarCodeDetailService成员
        /// <summary>
        /// Insert into XMAllocateProductBarCodeDetail
        /// </summary>
        /// <param name="xmallocateproductbarcodedetail">XMAllocateProductBarCodeDetail</param>
    	void InsertXMAllocateProductBarCodeDetail(XMAllocateProductBarCodeDetail xmallocateproductbarcodedetail);
    	
        /// <summary>
        /// Update into XMAllocateProductBarCodeDetail
        /// </summary>
        /// <param name="xmallocateproductbarcodedetail">XMAllocateProductBarCodeDetail</param>
        void UpdateXMAllocateProductBarCodeDetail(XMAllocateProductBarCodeDetail xmallocateproductbarcodedetail);	
    	
        /// <summary>
        /// get to XMAllocateProductBarCodeDetail list
        /// </summary>
        List<XMAllocateProductBarCodeDetail> GetXMAllocateProductBarCodeDetailList();
    	       
    	/// <summary>
    	/// get to XMAllocateProductBarCodeDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMAllocateProductBarCodeDetail Page List</returns>
    	PagedList<XMAllocateProductBarCodeDetail> SearchXMAllocateProductBarCodeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMAllocateProductBarCodeDetail by Id
        /// </summary>
        /// <param name="id">XMAllocateProductBarCodeDetail Id</param>
        /// <returns>XMAllocateProductBarCodeDetail</returns>   
        XMAllocateProductBarCodeDetail GetXMAllocateProductBarCodeDetailById(int id);
    
    	/// <summary>
        /// delete XMAllocateProductBarCodeDetail by Id
        /// </summary>
        /// <param name="Id">XMAllocateProductBarCodeDetail Id</param>
        void DeleteXMAllocateProductBarCodeDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMAllocateProductBarCodeDetail by Id
        /// </summary>
        /// <param name="Ids">XMAllocateProductBarCodeDetail Id</param>
        void BatchDeleteXMAllocateProductBarCodeDetail(List<int> ids);

        #endregion
    }
}
