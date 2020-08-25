
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-02-10 09:55:48
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
    public partial interface IXMPremiumsDetailsService
    {
        #region IXMPremiumsDetailsService成员
        /// <summary>
        /// Insert into XMPremiumsDetails
        /// </summary>
        /// <param name="xmpremiumsdetails">XMPremiumsDetails</param>
    	void InsertXMPremiumsDetails(XMPremiumsDetails xmpremiumsdetails);


       /// <summary>
        /// Insert into XMPremiumsDetails
       /// </summary>
       /// <param name="ProductDetaislId">商品编码Id</param>
       /// <param name="PlatformMerchantCode">商品编码</param>
       /// <param name="PrdouctName">商品名称</param>
       /// <param name="FactoryPrice">价格</param>
       /// <param name="ProductNum">数量</param>
        int InsertXMPremiumsDetails(int PremiumsId, int ProductDetaislId, string PlatformMerchantCode, string PrdouctName, decimal FactoryPrice, int ProductNum);
    	
        /// <summary>
        /// Update into XMPremiumsDetails
        /// </summary>
        /// <param name="xmpremiumsdetails">XMPremiumsDetails</param>
        void UpdateXMPremiumsDetails(XMPremiumsDetails xmpremiumsdetails);	
    	
        /// <summary>
        /// get to XMPremiumsDetails list
        /// </summary>
        List<XMPremiumsDetails> GetXMPremiumsDetailsList();

        List<XMPremiumsDetails> GetXMPremiumsDetailsListByCustomerID(int CustomerID);

         /// <summary>
         /// 根据赠品申请Id查询赠品明细
         /// </summary>
         /// <param name="PremiumsId">赠品申请Id</param>
         /// <returns></returns>
        List<XMPremiumsDetails> GetXMPremiumsDetailsListByPremiumsId(int PremiumsId);


        /// <summary>
        /// 根据赠品申请Id、明细商品编码 查询赠品明细
        /// </summary>
        /// <param name="PremiumsId">赠品申请Id</param>
        /// <param name="PlatformMerchantCode">商品编码集合</param>
        /// <returns></returns>
        List<XMPremiumsDetails> GetXMPremiumsDetailsListByPremiumsId(int PremiumsId, List<string> PlatformMerchantCode);
        
        /// <summary>
        /// 根据赠品申请Id查询赠品明细（根据商品编码统计数量）
        /// </summary>
        /// <param name="PremiumsId">赠品申请Id</param>
        /// <returns></returns>
        List<XMPremiumsDetailsMapping> GetXMPremiumsDetailsListByPremiumsIdList(List<int> PremiumsIdList);

    	/// <summary>
    	/// get to XMPremiumsDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMPremiumsDetails Page List</returns>
    	PagedList<XMPremiumsDetails> SearchXMPremiumsDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMPremiumsDetails by Id
        /// </summary>
        /// <param name="id">XMPremiumsDetails Id</param>
        /// <returns>XMPremiumsDetails</returns>   
        XMPremiumsDetails GetXMPremiumsDetailsById(int id);
    
    	/// <summary>
        /// delete XMPremiumsDetails by Id
        /// </summary>
        /// <param name="Id">XMPremiumsDetails Id</param>
        void DeleteXMPremiumsDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMPremiumsDetails by Id
        /// </summary>
        /// <param name="Ids">XMPremiumsDetails Id</param>
        void BatchDeleteXMPremiumsDetails(List<int> ids);

        #endregion
    }
}
