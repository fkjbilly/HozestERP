
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-05-09 16:59:13
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial interface IXMAdjustedProductDetailService
    {
        #region IXMAdjustedProductDetailService成员
        /// <summary>
        /// Insert into XMAdjustedProductDetail
        /// </summary>
        /// <param name="xmadjustedproductdetail">XMAdjustedProductDetail</param>
    	void InsertXMAdjustedProductDetail(XMAdjustedProductDetail xmadjustedproductdetail);
    	
        /// <summary>
        /// Update into XMAdjustedProductDetail
        /// </summary>
        /// <param name="xmadjustedproductdetail">XMAdjustedProductDetail</param>
        void UpdateXMAdjustedProductDetail(XMAdjustedProductDetail xmadjustedproductdetail);	
    	
        /// <summary>
        /// get to XMAdjustedProductDetail list
        /// </summary>
        List<XMAdjustedProductDetail> GetXMAdjustedProductDetailList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjustedID"></param>
        /// <returns></returns>
        List<XMAdjustedProductDetail> GetXMAdjustedProductDetailListByAdjustedID(int adjustedID);
    	       
    	/// <summary>
    	/// get to XMAdjustedProductDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMAdjustedProductDetail Page List</returns>
    	PagedList<XMAdjustedProductDetail> SearchXMAdjustedProductDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMAdjustedProductDetail by Id
        /// </summary>
        /// <param name="id">XMAdjustedProductDetail Id</param>
        /// <returns>XMAdjustedProductDetail</returns>   
        XMAdjustedProductDetail GetXMAdjustedProductDetailById(int id);
    
    	/// <summary>
        /// delete XMAdjustedProductDetail by Id
        /// </summary>
        /// <param name="Id">XMAdjustedProductDetail Id</param>
        void DeleteXMAdjustedProductDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMAdjustedProductDetail by Id
        /// </summary>
        /// <param name="Ids">XMAdjustedProductDetail Id</param>
        void BatchDeleteXMAdjustedProductDetail(List<int> ids);

        #endregion
    }
}
