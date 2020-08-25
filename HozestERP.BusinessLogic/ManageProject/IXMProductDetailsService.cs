
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-30 10:10:15
** 修改人:
** 修改日期:
** 描 述: 接口类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMProductDetailsService
    {
        #region IXMProductDetailsService成员
        /// <summary>
        /// Insert into XMProductDetails
        /// </summary>
        /// <param name="xmproductdetails">XMProductDetails</param>
        void InsertXMProductDetails(XMProductDetails xmproductdetails);

        /// <summary>
        /// Update into XMProductDetails
        /// </summary>
        /// <param name="xmproductdetails">XMProductDetails</param>
        void UpdateXMProductDetails(XMProductDetails xmproductdetails);

        /// <summary>
        /// get to XMProductDetails list
        /// </summary>
        List<XMProductDetails> GetXMProductDetailsList();

        /// <summary>
        /// 根据产品主表Id查询明细
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        List<XMProductDetails> GetXMProductDetailsListByProductId(int ProductId);

        /// <summary>
        /// 根据产品主表Id查询明细
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        List<XMProductDetails> GetXMProductDetailsListByProductIds(List<int> ProductIds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="platFormID"></param>
        /// <returns></returns>
        XMProductDetails GetXMProductDetailsByProductIdAndPlatFormId(int productId, int platFormID);

        XMProductDetails GetXMProductDetailsByProductIdAndPlatformMerchantCode(int productId, string PlatformMerchantCode);

        /// <summary>
        /// 根据商品名称 查询商品名称、商品编码、尺寸、出厂价
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        List<XMProductDetailsMapping> GetXMProductDetailsByProductName(string ProductName);

        /// <summary>
        /// 根据商品编码查询
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        List<XMProductDetailsMapping> GetXMProductDetailsByProductNameList(string ProductName);

        /// <summary>
        /// get to XMProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProductDetails Page List</returns>
        PagedList<XMProductDetails> SearchXMProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMProductDetails by Id
        /// </summary>
        /// <param name="id">XMProductDetails Id</param>
        /// <returns>XMProductDetails</returns>   
        XMProductDetails GetXMProductDetailsById(int id);

        /// <summary>
        /// get a XMProductDetails by PlatformMerchantCode
        /// </summary>
        /// <param name="id">XMProductDetails PlatformMerchantCode</param>
        /// <returns>XMProductDetails</returns>   
        List<XMProductDetails> GetXMProductDetailsByPlatformMerchantCode(string PlatformMerchantCode, int PlatformTypeId, string Color);
       
        /// <summary>
        /// get a XMProductDetails by PlatformMerchantCode
        /// </summary>
        /// <param name="id">XMProductDetails PlatformMerchantCode</param>
        /// <returns>XMProductDetails</returns>   
        List<XMProductDetails> GetXMProductDetailsByPlatformMerchantCode(string PlatformMerchantCode, int PlatformTypeId = -1);

        List<XMProductNew> GetXMProductListByManufacturersCode(string ManufacturersCode, int PlatformTypeId);

        List<XMProduct> GetXMProductListByTManufacturersCode(string ManufacturersCode);

        /// <summary>
        /// delete XMProductDetails by Id
        /// </summary>
        /// <param name="Id">XMProductDetails Id</param>
        void DeleteXMProductDetails(int id);

        /// <summary>
        /// Batch delete XMProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMProductDetails Id</param>
        void BatchDeleteXMProductDetails(List<int> ids);

        #endregion
    }
}
