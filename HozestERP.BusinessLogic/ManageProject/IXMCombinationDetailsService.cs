
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-06-11 14:00:22
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMCombinationDetailsService
    {
        #region IXMCombinationDetailsService成员
        /// <summary>
        /// Insert into XMCombinationDetails
        /// </summary>
        /// <param name="xmcombinationdetails">XMCombinationDetails</param>
    	void InsertXMCombinationDetails(XMCombinationDetails xmcombinationdetails);
    	
        /// <summary>
        /// Update into XMCombinationDetails
        /// </summary>
        /// <param name="xmcombinationdetails">XMCombinationDetails</param>
        void UpdateXMCombinationDetails(XMCombinationDetails xmcombinationdetails);

        /// <summary>
        /// Update into XMCombinationDetails
        /// </summary>
        /// <param name="xmcombinationdetails">XMCombinationDetails</param>
        void UpdateXMCombinationDetails(List<XMCombinationDetails> xmcombinationdetails);

        /// <summary>
        /// get to XMCombinationDetails list
        /// </summary>
        List<XMCombinationDetails> GetXMCombinationDetailsList();

        /// <summary>
        /// 根据产品主表Id查询明细
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        List<XMCombinationDetails> GetXMProductDetailsListByProductId(int ProductId);

        XMCombinationDetails GetXMProductDetailsById(int id);

        List<XMCombinationDetails> GetXMProductDetailsByPlatformMerchantCode(string PlatformMerchantCode, int PlatformTypeId);

    	/// <summary>
    	/// get to XMCombinationDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMCombinationDetails Page List</returns>
    	PagedList<XMCombinationDetails> SearchXMCombinationDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        List<XMCombinationDetails> GetXMCombinationDetailsByPlatformMerchantCode(string PlatformMerchantCode, int PlatformTypeId);

        /// <summary>
        /// 根据产品主表Id查询明细
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        List<XMCombinationDetails> GetXMCombinationDetailsListByProductId(int ProductId);

    	/// <summary>
        /// get a XMCombinationDetails by Id
        /// </summary>
        /// <param name="id">XMCombinationDetails Id</param>
        /// <returns>XMCombinationDetails</returns>   
        XMCombinationDetails GetXMCombinationDetailsById(int id);
    
    	/// <summary>
        /// delete XMCombinationDetails by Id
        /// </summary>
        /// <param name="Id">XMCombinationDetails Id</param>
        void DeleteXMCombinationDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMCombinationDetails by Id
        /// </summary>
        /// <param name="Ids">XMCombinationDetails Id</param>
        void BatchDeleteXMCombinationDetails(List<int> ids);

        #endregion
    }
}
