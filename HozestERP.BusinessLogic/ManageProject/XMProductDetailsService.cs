
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-30 10:10:16
** 修改人:
** 修改日期:
** 描 述: 接口实现类
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
    public partial class XMProductDetailsService : IXMProductDetailsService
    {
        #region Fields
        /// <summary>
        /// Object context
        /// </summary>
        private readonly HozestERPObjectContext _context;
        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public XMProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMProductDetailsService成员
        /// <summary>
        /// Insert into XMProductDetails
        /// </summary>
        /// <param name="xmproductdetails">XMProductDetails</param>
        public void InsertXMProductDetails(XMProductDetails xmproductdetails)
        {
            if (xmproductdetails == null)
                return;

            if (!this._context.IsAttached(xmproductdetails))

                this._context.XMProductDetails.AddObject(xmproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMProductDetails
        /// </summary>
        /// <param name="xmproductdetails">XMProductDetails</param>
        public void UpdateXMProductDetails(XMProductDetails xmproductdetails)
        {
            if (xmproductdetails == null)
                return;

            if (this._context.IsAttached(xmproductdetails))
                this._context.XMProductDetails.Attach(xmproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMProductDetails list
        /// </summary>
        public List<XMProductDetails> GetXMProductDetailsList()
        {
            var query = from p in this._context.XMProductDetails
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据产品主表Id查询明细
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<XMProductDetails> GetXMProductDetailsListByProductId(int ProductId)
        {
            var query = from p in this._context.XMProductDetails
                        where p.ProductId == ProductId
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据产品主表Id查询明细
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<XMProductDetails> GetXMProductDetailsListByProductIds(List<int> ProductIds)
        {
            var query = from p in this._context.XMProductDetails
                        where ProductIds.Contains(p.ProductId.Value)
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="platFormID"></param>
        /// <returns></returns>
        public XMProductDetails GetXMProductDetailsByProductIdAndPlatFormId(int productId, int platFormID)
        {
            var query = from p in this._context.XMProductDetails
                        where p.ProductId == productId && p.PlatformTypeId == platFormID
                        && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        public XMProductDetails GetXMProductDetailsByProductIdAndPlatformMerchantCode(int productId, string PlatformMerchantCode)
        {
            var query = from p in _context.XMProductDetails
                        where p.ProductId == productId && p.PlatformMerchantCode == PlatformMerchantCode
                        && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 根据商品名称、是赠品 查询商品名称、商品编码、尺寸、出厂价
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public List<XMProductDetailsMapping> GetXMProductDetailsByProductName(string ProductName)
        {
            //var query = from p in this._context.XMProducts
            //            join b in this._context.XMProductDetails
            //            on p.Id equals b.ProductId 
            //            where p.ProductName.Contains(ProductName)
            //            && p.IsEnable.Value == false
            //            && b.IsEnable.Value == false
            //            && p.IsPremiums == true
            //            select new XMProductDetailsMapping
            //            {
            //                Id = p.Id,
            //                ProductName = p.ProductName,
            //                ManufacturersCode = p.ManufacturersCode,
            //                Specifications = p.Specifications,
            //                Costprice = b.Costprice
            //            };
            //return new List<XMProductDetailsMapping>(query);

            //&& b.IsEnable.Value == false

            //左链接
            var query = from p in this._context.XMProducts
                        join b in this._context.XMProductDetails
                        on p.Id equals b.ProductId into JoinedPB
                        from b in JoinedPB.DefaultIfEmpty()
                        where p.ProductName.Equals(ProductName)
                        && p.IsEnable.Value == false
                        && b.IsEnable == false
                        && p.IsPremiums == true
                        select new XMProductDetailsMapping
                        {
                            Id = p.Id,
                            ProductName = p.ProductName,
                            ManufacturersCode = p.ManufacturersCode,
                            Specifications = p.Specifications,
                            Costprice = b.Costprice,
                            PlatformMerchantCode = b.PlatformMerchantCode,
                            DetailId = b.Id
                        };

            return new List<XMProductDetailsMapping>(query.Distinct()).ToList();
        }

        /// <summary>
        /// 根据商品编码查询
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public List<XMProductDetailsMapping> GetXMProductDetailsByProductNameList(string ProductName)
        {
            //左链接
            var query = from p in this._context.XMProducts
                        join b in this._context.XMProductDetails
                        on p.Id equals b.ProductId into JoinedPB
                        from b in JoinedPB.DefaultIfEmpty()
                        where p.ProductName.Contains(ProductName)
                        && p.IsEnable.Value == false
                        //&& p.IsPremiums == true
                        select new XMProductDetailsMapping
                        {
                            Id = p.Id,
                            DetailId = b.Id,
                            ProductName = p.ProductName,
                            ManufacturersCode = p.ManufacturersCode,
                            PlatformMerchantCode = b.PlatformMerchantCode,
                            Specifications = p.Specifications,
                            Shipper = p.Shipper,
                            Costprice = b.Costprice
                        };

            return new List<XMProductDetailsMapping>(query.Distinct()).ToList();
        }

        /// <summary>
        /// get to XMProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProductDetails Page List</returns>
        public PagedList<XMProductDetails> SearchXMProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMProductDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMProductDetails by Id
        /// </summary>
        /// <param name="id">XMProductDetails Id</param>
        /// <returns>XMProductDetails</returns>   
        public XMProductDetails GetXMProductDetailsById(int id)
        {
            var query = from p in this._context.XMProductDetails
                        where p.Id.Equals(id)
                        && p.IsEnable.Value == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// get a XMProductDetails by PlatformMerchantCode
        /// </summary>
        /// <param name="id">XMProductDetails PlatformMerchantCode</param>
        /// <returns>XMProductDetails</returns>   
        public List<XMProductDetails> GetXMProductDetailsByPlatformMerchantCode(string PlatformMerchantCode, int PlatformTypeId, string Color)
        {
            var query = from p in this._context.XMProductDetails
                        where p.PlatformMerchantCode == PlatformMerchantCode
                        && (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        && (Color == "" || p.Color == Color)
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get a XMProductDetails by PlatformMerchantCode
        /// </summary>
        /// <param name="id">XMProductDetails PlatformMerchantCode</param>
        /// <returns>XMProductDetails</returns>   
        public List<XMProductDetails> GetXMProductDetailsByPlatformMerchantCode(string PlatformMerchantCode, int PlatformTypeId = -1)
        {
            var query = from p in this._context.XMProductDetails
                        where p.PlatformMerchantCode == PlatformMerchantCode
                        //&& p.IsEnable.Value == false
                        && (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        orderby p.CreateDate descending
                        select p;
            if (query.ToList().Count == 0) 
            {
                query = from p in this._context.XMProductDetails
                        where p.PlatformMerchantCode == PlatformMerchantCode
                            //&& p.IsEnable.Value == false
                        && (PlatformTypeId == -1 || p.PlatformTypeId == 508)//通用
                        orderby p.CreateDate descending
                        select p;
            }
            return query.ToList();
        }

        public List<XMProductNew> GetXMProductListByManufacturersCode(string ManufacturersCode, int PlatformTypeId)
        {
            List<XMProductNew> list = new List<XMProductNew>();
            var query1 = from p in this._context.XMProducts
                        where p.ManufacturersCode.Contains(ManufacturersCode)
                        //&& p.IsEnable == false
                        select new XMProductNew
                        {
                            Id = -1,
                            ManufacturersCode = p.ManufacturersCode
                        };
            var query2 = from p in this._context.XMCombinations
                         where p.ManufacturersCode.Contains(ManufacturersCode)
                         //&& p.IsEnabled == false
                         select new XMProductNew
                         {
                             Id = -1,
                             ManufacturersCode = p.ManufacturersCode
                         };
            var query3 = from p in this._context.XMProductDetails
                         where p.TemporaryManufacturersCode.Contains(ManufacturersCode)
                         //&& p.IsEnable == false
                         && p.PlatformTypeId == PlatformTypeId
                         select new XMProductNew
                         {
                             Id = p.Id,
                             ManufacturersCode = p.TemporaryManufacturersCode
                         };
            list.AddRange(query1.ToList());
            list.AddRange(query2.ToList());
            list.AddRange(query3.ToList());
            return list;
        }

        public List<XMProduct> GetXMProductListByTManufacturersCode(string ManufacturersCode)
        {
            var query = from p in this._context.XMProducts
                        join q in this._context.XMProductDetails
                        on p.Id equals q.ProductId
                        where (p.ManufacturersCode == ManufacturersCode || q.TemporaryManufacturersCode == ManufacturersCode)
                        && p.IsEnable == false
                        && q.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// delete XMProductDetails by Id
        /// </summary>
        /// <param name="Id">XMProductDetails Id</param>
        public void DeleteXMProductDetails(int id)
        {
            var xmproductdetails = this.GetXMProductDetailsById(id);
            if (xmproductdetails == null)
                return;

            if (!this._context.IsAttached(xmproductdetails))
                this._context.XMProductDetails.Attach(xmproductdetails);

            this._context.DeleteObject(xmproductdetails);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMProductDetails Id</param>
        public void BatchDeleteXMProductDetails(List<int> ids)
        {
            var query = from q in _context.XMProductDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmproductdetailss = query.ToList();
            foreach (var item in xmproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMProductDetails.Attach(item);

                _context.XMProductDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
