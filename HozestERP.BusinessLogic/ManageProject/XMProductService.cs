
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
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProtal;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMProductService : IXMProductService
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
        public XMProductService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMProductService成员
        /// <summary>
        /// Insert into XMProduct
        /// </summary>
        /// <param name="xmproduct">XMProduct</param>
        public void InsertXMProduct(XMProduct xmproduct)
        {
            if (xmproduct == null)
                return;

            if (!this._context.IsAttached(xmproduct))

                this._context.XMProducts.AddObject(xmproduct);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMProduct
        /// </summary>
        /// <param name="xmproduct">XMProduct</param>
        public void UpdateXMProduct(XMProduct xmproduct)
        {
            if (xmproduct == null)
                return;

            if (this._context.IsAttached(xmproduct))
                this._context.XMProducts.Attach(xmproduct);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMProduct list
        /// </summary>
        public List<XMProduct> GetXMProductList()
        {
            var query = from p in this._context.XMProducts
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMProductAddCount> GetXMProductByIDsCount(List<int> IDs, int CombinationID)
        {
            var query = from info in this._context.XMProducts
                        join count in this._context.XMProductCombinations
                        on info.Id equals count.ProductID into Counts
                        from counts in Counts.DefaultIfEmpty()
                        where info.IsEnable == false
                        && counts.IsEnabled == false
                        && IDs.Contains(info.Id)
                        && counts.CombinationID == CombinationID
                        select new XMProductAddCount
                        {
                            Id = info.Id,
                            BrandTypeId = info.BrandTypeId,
                            ProductName = info.ProductName,
                            ManufacturersCode = info.ManufacturersCode,
                            Specifications = info.Specifications,
                            ManufacturersInventory = info.ManufacturersInventory,
                            WarningQuantity = info.WarningQuantity,
                            ProductColors = info.ProductColors,
                            ProductUnit = info.ProductUnit,
                            ProductWeight = info.ProductWeight,
                            ProductVolume = info.ProductVolume,
                            IsPremiums = info.IsPremiums,
                            Count = counts.Count,
                            IsEnable = info.IsEnable,
                            CreateID = info.CreateID,
                            CreateDate = info.CreateDate,
                            UpdateID = info.UpdateID,
                            UpdateDate = info.UpdateDate
                        };
            return query.ToList();
        }

        public List<XMProduct> GetXMProductByIDs(List<int> IDs)
        {
            var query = from info in this._context.XMProducts
                        where info.IsEnable == false
                        && IDs.Contains(info.Id)
                        select info;
            return query.ToList();
        }

        /// <summary>
        /// get to XMProduct list
        /// </summary>
        public List<XMProduct> GetXMProductListByCondition(string ProductName, string ManufacturersCode)
        {
            var query = from p in this._context.XMProducts
                        where p.IsEnable == false
                        && p.ProductName.Contains(ProductName)
                        && p.ManufacturersCode.Contains(ManufacturersCode)
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据厂家编码或产品编号查询-修改
        /// </summary>
        /// <param name="manufacturersCode"></param>
        /// <returns></returns>
        public List<XMProductNew> GetXMProductListByCode(string manufacturersCode, int? platform)
        {
            var query = from p in this._context.XMProducts
                        join a in this._context.XMProductDetails
                        on p.Id equals a.ProductId
                        where p.IsEnable == false
                        && (manufacturersCode == "" || p.ManufacturersCode.Contains(manufacturersCode))
                        //508 通用
                        && (platform == -1 || a.PlatformTypeId == platform || a.PlatformTypeId==508)
                        && a.IsEnable == false
                        select new XMProductNew
                        {
                            Id=p.Id,
                            PlatformMerchantCode=a.PlatformMerchantCode,
                            BrandTypeId = p.BrandTypeId,
                            ProductName = p.ProductName,
                            Specifications = p.Specifications,
                            ProductWeight = p.ProductWeight,
                            ProductVolume = p.ProductVolume,
                            ManufacturersCode = p.ManufacturersCode,
                            ManufacturersInventory = p.ManufacturersInventory,
                            WarningQuantity = p.WarningQuantity,
                            ProductColors = p.ProductColors,
                            ProductUnit = a.PlatformMerchantCode,
                            Costprice = a.Costprice,
                            Saleprice = a.Saleprice,
                            TCostprice = a.TCostprice,
                            //ProductVolume = a.PlatformMerchantCode,
                            IsPremiums = p.IsPremiums,
                            IsEnable = p.IsEnable
                        };
            List<XMProductNew> list = new List<XMProductNew>();
            if (query.ToList().Count != 0)
            {
                list = query.ToList();
            }
            //else
            //{
            //    var info = from p in this._context.XMCombinations
            //               join a in this._context.XMCombinationDetails
            //               on p.ID equals a.ProductId
            //               where p.IsEnabled == false
            //               && (platformmerchantCode == "" || p.ManufacturersCode.Contains(platformmerchantCode))
            //               && a.PlatformTypeId == platform
            //               && a.IsEnable == false
            //               select new XMProductNew
            //               {
            //                   NickId = p.NickId,
            //                   //BrandTypeId = p.BrandTypeId,
            //                   ProductName = p.ProductName,
            //                   //Specifications = p.Specifications,
            //                   ManufacturersCode = p.ManufacturersCode,
            //                   //ManufacturersInventory = p.ManufacturersInventory,
            //                   //WarningQuantity = p.WarningQuantity,
            //                   //ProductColors = p.ProductColors,
            //                   ProductUnit = a.PlatformMerchantCode,
            //                   Costprice = a.Costprice,
            //                   Saleprice = a.Saleprice,
            //                   TCostprice = a.TCostprice,
            //                   //ProductVolume = a.PlatformMerchantCode,
            //                   //IsPremiums = p.IsPremiums,
            //                   IsEnable = p.IsEnabled
            //               };
            //    list = info.ToList();
            //}
            return list;
        }

        public List<XMProductNew> GetXMProductListByProductName(string ProductName, int PlatformTypeId)
        {
            var query = from p in this._context.XMProducts
                        join a in this._context.XMProductDetails
                        on p.Id equals a.ProductId
                        where p.IsEnable == false
                        && p.ProductName.Contains(ProductName)
                        && (PlatformTypeId == -1 || a.PlatformTypeId == PlatformTypeId || a.PlatformTypeId == 508)//508通用平台
                        && a.IsEnable == false
                        select new XMProductNew
                        {
                            BrandTypeId = p.BrandTypeId,
                            ProductName = p.ProductName,
                            Specifications = p.Specifications,
                            ManufacturersCode = p.ManufacturersCode,
                            ManufacturersInventory = p.ManufacturersInventory,
                            WarningQuantity = p.WarningQuantity,
                            ProductColors = p.ProductColors,
                            PlatformMerchantCode = a.PlatformMerchantCode,
                            Costprice = a.Costprice,
                            Saleprice = a.Saleprice,
                            TCostprice = a.TCostprice,
                            IsPremiums = p.IsPremiums,
                            IsEnable = p.IsEnable
                        };
            List<XMProductNew> list = new List<XMProductNew>();
            if (query.ToList().Count != 0)
            {
                list = query.ToList();
            }
            return list;
        }

        public IQueryable<ProductChose> GetXMProductListWithDetail()
        {
            var query = from p in this._context.XMProducts
                        join a in this._context.XMProductDetails
                        on p.Id equals a.ProductId
                        join m in _context.CodeLists
                        on a.PlatformTypeId equals m.CodeID into temp
                        from pm in temp.DefaultIfEmpty()
                        where p.IsEnable == false
                        && a.IsEnable == false
                        select new ProductChose
                        {
                            ID=a.Id,
                            PlatformMerchantCode=a.PlatformMerchantCode,
                            ManufacturersCode=p.ManufacturersCode,
                            ProductName=p.ProductName,
                            Specifications=p.Specifications,
                            Costprice=a.Costprice,
                            Saleprice=a.Saleprice,
                            PlatformTypeName=pm.CodeName
                        };

            return query;
        }

        public List<XMProductDetails> GetXMProductListByPlatformMerchantCode(string PlatformMerchantCode, int PlatformTypeId)
        {
            var query = from p in this._context.XMProducts
                        join a in this._context.XMProductDetails
                        on p.Id equals a.ProductId
                        where p.IsEnable == false
                        && a.PlatformMerchantCode == PlatformMerchantCode
                        && (PlatformTypeId == -1 || a.PlatformTypeId == PlatformTypeId)
                        && a.IsEnable == false
                        select a;
            return query.ToList();
        }

        /// <summary>
        /// 根据厂家编码查询
        /// </summary>
        /// <param name="ManufacturersCode"></param>
        /// <returns></returns>
        public List<XMProduct> getXMProductListByManufacturersCode(string ManufacturersCode)
        {
            var query = from p in this._context.XMProducts
                        where p.ManufacturersCode.Contains(ManufacturersCode)
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();
        }

        public List<UnSetMinPriceProduct> getProductByMinPriceUnSet(int BrandTypeId)
        {
            var query = from p in this._context.XMProducts
                        join m in this._context.XMProductDetails on p.Id equals m.ProductId into temp
                        from pm in temp.DefaultIfEmpty()
                        join n in _context.CodeLists on p.BrandTypeId equals n.CodeID into temp1
                        from pn in temp1.DefaultIfEmpty()
                        where p.IsEnable == false && (pm.MinPrice == null || pm.MinPrice == 0) && (BrandTypeId==-1||p.BrandTypeId== BrandTypeId) && pn.CodeID !=null && pn.Deleted==false
                        group p by new { p.Id,p.ManufacturersCode,p.ProductName,p.BrandTypeId } into g
                        select new UnSetMinPriceProduct
                        {
                            Id=g.Key.Id,
                            ManufacturersCode=g.Key.ManufacturersCode,
                            ProductName=g.Key.ProductName,
                            BrandTypeId=g.Key.BrandTypeId
                        };

            return query.ToList();
        }

        public List<XMProduct> getXMProductListByPlatformMerchantCode(string PlatformMerchantCode)
        {
            var query = from p in this._context.XMProducts
                        join d in this._context.XMProductDetails
                        on p.Id equals d.ProductId
                        where d.PlatformMerchantCode.Contains(PlatformMerchantCode)
                        && p.IsEnable.Value == false
                        && d.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据厂家编码查询(Equals)
        /// </summary>
        /// <param name="ManufacturersCode"></param>
        /// <returns></returns>
        public List<XMProduct> getXMProductListByEqusManufacturersCode(string ManufacturersCode)
        {
            var query = from p in this._context.XMProducts
                        where p.ManufacturersCode.Equals(ManufacturersCode)
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据产品名称查询
        /// </summary>
        /// <param name="ManufacturersCode"></param>
        /// <returns></returns>
        public List<XMProduct> getXMProductListByProductName(string ProductName)
        {
            var query = from p in this._context.XMProducts
                        where p.ProductName.Contains(ProductName)
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();

        }

        /// <summary>
        /// 根据厂家编码查询产品信息
        /// </summary>
        /// <param name="ManufacturersCode">厂家编码</param>
        /// <returns></returns>
        public XMProduct getXMProductByManufacturersCode(string ManufacturersCode)
        {
            var query = from p in this._context.XMProducts
                        where p.ManufacturersCode == ManufacturersCode
                        && p.IsEnable.Value == false
                        select p;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 查询厂家编码
        /// </summary>
        /// <param name="PlatformTypeId">平台ID</param>
        /// <param name="PlatformMerchantCode">商家编码</param>
        /// <returns></returns>
        public XMProduct getXMProductByPlatform(int PlatformTypeId, string PlatformMerchantCode)
        {
            var query = from p in this._context.XMProducts
                        join pd in this._context.XMProductDetails
                        on p.Id equals pd.ProductId
                        where pd.PlatformMerchantCode == PlatformMerchantCode
                        && pd.PlatformTypeId == PlatformTypeId
                        && p.IsEnable.Value == false
                        && pd.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据子表的productid查询产品主表信息
        /// </summary>
        /// <param name="productid">productid</param>
        /// <returns></returns>
        public XMProduct GetXMProductProductId(int ProductId, string PlatformTypeId, int? OrderID)
        {
            //var PlatformType=from x in this._context.XMOrderInfoes
            var query = from x in this._context.XMProducts
                        join a in this._context.XMProductDetails
                        on x.Id equals a.ProductId
                        join b in this._context.XMOrderInfoProductDetails
                        on a.PlatformMerchantCode equals b.PlatformMerchantCode
                        join d in this._context.XMOrderInfoes
                        on a.PlatformTypeId equals d.PlatformTypeId
                        where b.ID == ProductId && a.PlatformMerchantCode == PlatformTypeId && d.ID == OrderID && a.IsEnable == false
                        select x;
            return query.Distinct().SingleOrDefault();
        }

        /// <summary>
        /// 根据子表的productid查询产品主表信息
        /// </summary>
        /// <param name="productid">productid</param>
        /// <returns></returns>
        public XMProduct GetXMProductAppId(int AppId, string PlatformMerchantCode)
        {
            var query = from x in this._context.XMProducts
                        join a in this._context.XMProductDetails
                        on x.Id equals a.ProductId
                        join b in this._context.XMApplicationExchanges
                        on a.PlatformMerchantCode equals b.PlatformMerchantCode
                        join d in this._context.XMApplications
                        on a.PlatformTypeId equals d.PlatformTypeId
                        where b.ID == AppId
                        && a.PlatformMerchantCode == PlatformMerchantCode
                        && a.PlatformTypeId == d.PlatformTypeId
                        && d.IsEnable == false
                        && x.IsEnable == false
                        && a.IsEnable == false
                        select x;
            return query.Distinct().FirstOrDefault();
        }

        public List<HighChart> GetXMProductCombinationList(string ManufacturersCode)
        {
            var product = from p in this._context.XMProducts
                          where p.IsEnable.Value == false
                          && p.ManufacturersCode.Contains(ManufacturersCode)
                          select new HighChart
                          {
                              Name = p.ProductName,
                              Group = p.ManufacturersCode
                          };
            List<HighChart> list = product.ToList();

            var combination = from p in this._context.XMCombinations
                              where p.IsEnabled == false
                              && p.ManufacturersCode.Contains(ManufacturersCode)
                              select new HighChart
                              {
                                  Name = p.ProductName,
                                  Group = p.ManufacturersCode
                              };
            list.AddRange(combination.ToList());
            list = list.OrderByDescending(x => x.Group).ToList();
            return list;
        }

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
        public PagedList<XMProduct> SearchXMProduct(int BrandTypeId, string ProductName, int SupplierId, string FactoryCode, string ProductCode, int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMProducts
                        join detail in this._context.XMProductDetails
                        on p.Id equals detail.ProductId
                        into details
                        from Detail in details.DefaultIfEmpty()
                        where (BrandTypeId == -1 || p.BrandTypeId.Value == BrandTypeId)
                        && p.ProductName.Contains(ProductName)
                        && p.ManufacturersCode.Contains(FactoryCode)
                        && (ProductCode == "" || Detail.PlatformMerchantCode.Contains(ProductCode))
                        && p.IsEnable.Value == false
                        && (Detail == null || Detail.IsEnable.Value == false)
                        && (SupplierId == -1 ||  p.SuppliersID == SupplierId)
                        orderby p.CreateDate descending
                        select p;

            List<string> list = new List<string>();
            List<XMProduct> productList = new List<XMProduct>();
            foreach (XMProduct info in query)
            {
                if (list.IndexOf(info.Id.ToString()) == -1)
                {
                    list.Add(info.Id.ToString());
                    productList.Add(info);
                }

            }
            return new PagedList<XMProduct>(productList, pageIndex, pageSize, sortExpression, sortDirection);
        }

        public List<XMProduct> GetXMProducts(int BrandTypeId, string ProductName, string FactoryCode, string ProductCode)
        {
            var query = from p in this._context.XMProducts
                        join detail in this._context.XMProductDetails
                        on p.Id equals detail.ProductId
                        into details
                        from Detail in details.DefaultIfEmpty()
                        where (BrandTypeId == -1 || p.BrandTypeId.Value == BrandTypeId)
                        && p.ProductName.Contains(ProductName)
                        && p.ManufacturersCode.Contains(FactoryCode)
                        && (ProductCode == "" || Detail.PlatformMerchantCode.Contains(ProductCode))
                        && p.IsEnable.Value == false
                        && (Detail == null || Detail.IsEnable.Value == false)
                        orderby p.CreateDate descending
                        select p;

            List<string> list = new List<string>();
            List<XMProduct> productList = new List<XMProduct>();
            foreach (XMProduct info in query)
            {
                if (list.IndexOf(info.Id.ToString()) == -1)
                {
                    list.Add(info.Id.ToString());
                    productList.Add(info);
                }

            }

            return productList;
        }

        /// <summary>
        /// get a XMProduct by Id
        /// </summary>
        /// <param name="id">XMProduct Id</param>
        /// <returns>XMProduct</returns>   
        public XMProduct GetXMProductById(int id)
        {
            var query = from p in this._context.XMProducts
                        where p.Id.Equals(id)
                         && p.IsEnable.Value == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMProduct by Id
        /// </summary>
        /// <param name="Id">XMProduct Id</param>
        public void DeleteXMProduct(int id)
        {
            var xmproduct = this.GetXMProductById(id);
            if (xmproduct == null)
                return;

            if (!this._context.IsAttached(xmproduct))
                this._context.XMProducts.Attach(xmproduct);

            this._context.DeleteObject(xmproduct);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMProduct by Id
        /// </summary>
        /// <param name="Ids">XMProduct Id</param>
        public void BatchDeleteXMProduct(List<int> ids)
        {
            var query = from q in _context.XMProducts
                        where ids.Contains(q.Id)
                        select q;
            var xmproducts = query.ToList();
            foreach (var item in xmproducts)
            {
                if (!_context.IsAttached(item))
                    _context.XMProducts.Attach(item);

                _context.XMProducts.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
