
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
    public partial interface IXMSaleReturnBarCodeDetailService
    {
        #region IXMSaleReturnBarCodeDetailService成员
        /// <summary>
        /// Insert into XMSaleReturnBarCodeDetail
        /// </summary>
        /// <param name="xmsalereturnbarcodedetail">XMSaleReturnBarCodeDetail</param>
    	void InsertXMSaleReturnBarCodeDetail(XMSaleReturnBarCodeDetail xmsalereturnbarcodedetail);
    	
        /// <summary>
        /// Update into XMSaleReturnBarCodeDetail
        /// </summary>
        /// <param name="xmsalereturnbarcodedetail">XMSaleReturnBarCodeDetail</param>
        void UpdateXMSaleReturnBarCodeDetail(XMSaleReturnBarCodeDetail xmsalereturnbarcodedetail);	
    	
        /// <summary>
        /// get to XMSaleReturnBarCodeDetail list
        /// </summary>
        List<XMSaleReturnBarCodeDetail> GetXMSaleReturnBarCodeDetailList();
    	       
    	/// <summary>
    	/// get to XMSaleReturnBarCodeDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMSaleReturnBarCodeDetail Page List</returns>
    	PagedList<XMSaleReturnBarCodeDetail> SearchXMSaleReturnBarCodeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMSaleReturnBarCodeDetail by Id
        /// </summary>
        /// <param name="id">XMSaleReturnBarCodeDetail Id</param>
        /// <returns>XMSaleReturnBarCodeDetail</returns>   
        XMSaleReturnBarCodeDetail GetXMSaleReturnBarCodeDetailById(int id);
    
    	/// <summary>
        /// delete XMSaleReturnBarCodeDetail by Id
        /// </summary>
        /// <param name="Id">XMSaleReturnBarCodeDetail Id</param>
        void DeleteXMSaleReturnBarCodeDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMSaleReturnBarCodeDetail by Id
        /// </summary>
        /// <param name="Ids">XMSaleReturnBarCodeDetail Id</param>
        void BatchDeleteXMSaleReturnBarCodeDetail(List<int> ids);

        #endregion
    }
}