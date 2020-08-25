
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
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProtal;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMProductService
    {
        #region IXMProductService成员
        /// <summary>
        /// Insert into XMProduct
        /// </summary>
        /// <param name="xmproduct">XMProduct</param>
        void InsertXMProduct(XMProduct xmproduct);

        /// <summary>
        /// Update into XMProduct
        /// </summary>
        /// <param name="xmproduct">XMProduct</param>
        void UpdateXMProduct(XMProduct xmproduct);

        /// <summary>
        /// get to XMProduct list
        /// </summary>
        List<XMProduct> GetXMProductList();
        List<XMProductAddCount> GetXMProductByIDsCount(List<int> Ids, int CombinationID);
        List<XMProduct> GetXMProductByIDs(List<int> Ids);
        List<XMProduct> GetXMProductListByCondition(string ProductName, string ManufacturersCode);

        /// <summary>
        /// 根据厂家编码或产品编号查询
        /// </summary>
        /// <param name="platformmerchantCode"></param>
        /// <returns></returns>
        List<XMProductNew> GetXMProductListByCode(string manufacturersCode, int? platform);
        List<XMProductNew> GetXMProductListByProductName(string ProductName, int PlatformTypeId);
        IQueryable<ProductChose> GetXMProductListWithDetail();
        List<XMProductDetails> GetXMProductListByPlatformMerchantCode(string PlatformMerchantCode, int PlatformTypeId);

        /// <summary>
        /// 根据厂家编码查询
        /// </summary>
        /// <param name="ManufacturersCode"></param>
        /// <returns></returns>
        List<XMProduct> getXMProductListByManufacturersCode(string ManufacturersCode);
        List<XMProduct> getXMProductListByPlatformMerchantCode(string PlatformMerchantCode);

        List<UnSetMinPriceProduct> getProductByMinPriceUnSet(int BrandTypeId);

        /// <summary>
        /// 根据厂家编码查询产品信息
        /// </summary>
        /// <param name="ManufacturersCode">厂家编码</param>
        /// <returns></returns>
        XMProduct getXMProductByManufacturersCode(string ManufacturersCode);

        /// <summary>
        /// 根据厂家编码查询(Equals)
        /// </summary>
        /// <param name="ManufacturersCode"></param>
        /// <returns></returns>
        List<XMProduct> getXMProductListByEqusManufacturersCode(string ManufacturersCode);


        /// <summary>
        /// 根据产品名称查询
        /// </summary>
        /// <param name="ManufacturersCode"></param>
        /// <returns></returns>
        List<XMProduct> getXMProductListByProductName(string ProductName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductName">品牌</param>
        /// <param name="ProductName">产品名称</param>
        /// <param name="SupplierId">供应商ID</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProduct Page List</returns>
        PagedList<XMProduct> SearchXMProduct(int BrandTypeId, string ProductName, int SupplierId , string FactoryCode, string ProductCode, int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BrandTypeId"></param>
        /// <param name="ProductName"></param>
        /// <param name="FactoryCode"></param>
        /// <param name="ProductCode"></param>
        /// <returns></returns>
        List<XMProduct> GetXMProducts(int BrandTypeId, string ProductName, string FactoryCode, string ProductCode);

        List<HighChart> GetXMProductCombinationList(string ManufacturersCode);

        /// <summary>
        /// 根据子表的productid查询产品主表信息
        /// </summary>
        /// <param name="productid">productid</param>
        /// <returns></returns>
        XMProduct GetXMProductProductId(int ProductId, string PlatformTypeId, int? OrderID);

        /// <summary>
        /// 查询厂家编码
        /// </summary>
        /// <param name="PlatformTypeId">平台ID</param>
        /// <param name="PlatformMerchantCode">商家编码</param>
        /// <returns></returns>
        XMProduct getXMProductByPlatform(int PlatformTypeId, string PlatformMerchantCode);

        /// <summary>
        /// 根据子表的productid查询产品主表信息
        /// </summary>
        /// <param name="productid">productid</param>
        /// <returns></returns>
        XMProduct GetXMProductAppId(int AppId, string PlatformMerchantCode);

        /// <summary>
        /// get a XMProduct by Id
        /// </summary>
        /// <param name="id">XMProduct Id</param>
        /// <returns>XMProduct</returns>   
        XMProduct GetXMProductById(int id);

        /// <summary>
        /// delete XMProduct by Id
        /// </summary>
        /// <param name="Id">XMProduct Id</param>
        void DeleteXMProduct(int id);

        /// <summary>
        /// Batch delete XMProduct by Id
        /// </summary>
        /// <param name="Ids">XMProduct Id</param>
        void BatchDeleteXMProduct(List<int> ids);

        #endregion
    }
}
