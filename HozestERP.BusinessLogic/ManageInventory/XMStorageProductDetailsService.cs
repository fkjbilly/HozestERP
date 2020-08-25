
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-05-09 16:59:21
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
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMStorageProductDetailsService : IXMStorageProductDetailsService
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
        public XMStorageProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMStorageProductDetailsService成员
        /// <summary>
        /// Insert into XMStorageProductDetails
        /// </summary>
        /// <param name="xmstorageproductdetails">XMStorageProductDetails</param>
        public void InsertXMStorageProductDetails(XMStorageProductDetails xmstorageproductdetails)
        {
            if (xmstorageproductdetails == null)
                return;

            if (!this._context.IsAttached(xmstorageproductdetails))

                this._context.XMStorageProductDetails.AddObject(xmstorageproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMStorageProductDetails
        /// </summary>
        /// <param name="xmstorageproductdetails">XMStorageProductDetails</param>
        public void UpdateXMStorageProductDetails(XMStorageProductDetails xmstorageproductdetails)
        {
            if (xmstorageproductdetails == null)
                return;

            if (this._context.IsAttached(xmstorageproductdetails))
                this._context.XMStorageProductDetails.Attach(xmstorageproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMStorageProductDetails list
        /// </summary>
        public List<XMStorageProductDetails> GetXMStorageProductDetailsList()
        {
            var query = from p in this._context.XMStorageProductDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="wareHouesesID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <returns></returns>
        public List<XMStorageProductDetails> GetXMStorageProductDetailsListByParm(DateTime startDate, DateTime endDate, int wareHouesesID, string PlatformMerchantCode)
        {
            var query = from p in this._context.XMStorageProductDetails
                        join t in this._context.XMStorages
                         on p.StorageId equals t.Id
                        where p.IsEnable == false
                        && (t.StorageDate >= startDate && t.StorageDate < endDate)
                        && t.WareHouseId == wareHouesesID
                        && p.PlatformMerchantCode == PlatformMerchantCode
                        && t.BillStatus == 1000
                        select p;
            return query.ToList();
        }

        public List<XMStorageProductDetails> GetXMStorageProductDetailsListByWareHousesList(List<int> WareHousesList)
        {
            var query = from p in this._context.XMStorageProductDetails
                        join t in this._context.XMStorages
                        on p.StorageId equals t.Id
                        where p.IsEnable == false
                        && t.IsEnable == false
                        && t.BillStatus == 1000
                        && t.IsAudit == true
                        && WareHousesList.Contains(t.WareHouseId)
                        orderby t.BizDt descending
                        select p;

            var rejected = from p in this._context.XMPurchaseRejectedProductDetails
                           join t in this._context.XMPurchaseRejecteds
                           on p.PrId equals t.Id
                           where p.IsEnable == false
                           && t.IsEnable == false
                           && t.IsAudit == true
                           && t.BillStatus == 1000
                           orderby t.BizDt descending
                           select p;

            List<XMPurchaseRejectedProductDetails> Rejected = rejected.ToList();
            foreach (var Info in query.ToList())
            {
                var Item = Rejected.Where(x => x.XM_PurchaseRejected.MId == Info.XM_Storage.Id && x.PlatformMerchantCode == Info.PlatformMerchantCode);
                if (Item != null && Item.Count() > 0)
                {
                    Info.ProductsCount -= Item.First().RejectionCount;
                }
            }

            return query.ToList();
        }

        /// <summary>
        /// get to XMStorageProductDetails list by parm
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <param name="platformMerchantCode"></param>
        /// <returns></returns>
        public List<XMStorageProductDetails> GetXMStorageProductDetailsListByParm(int purchaseId, string platformMerchantCode)
        {
            var query = from p in this._context.XMStorageProductDetails
                        join t in this._context.XMStorages
                        on p.StorageId equals t.Id
                        where p.IsEnable == false
                        && t.PurchaseId == purchaseId
                        && p.PlatformMerchantCode == platformMerchantCode
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 查询已经入库的采购商品
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="productName"></param>
        /// <param name="supplierId"></param>
        /// <param name="wareHouseId"></param>
        /// <returns></returns>
        public List<PurchaseDetail> GetXMStorageProductDetailsListByParm(string begin, string end, string productName, int supplierId, string wareHouseId, int projectId)
        {
            int?[] wareHouseIDlist = Array.ConvertAll<string, int?>(wareHouseId.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMStorageProductDetails
                        join b in this._context.XMProducts
                        on p.ProductId equals b.Id
                        join m in this._context.XMStorages
                        on p.StorageId equals m.Id
                        join w in this._context.XMPurchases
                        on m.PurchaseId equals w.Id
                        join t in this._context.XMWareHouses
                        on m.WareHouseId equals t.Id
                        where p.IsEnable == false
                        && ((begin == "" && end == "") || (w.PurchaseDate >= purBeginTime && w.PurchaseDate < purEndTime))
                        && (productName == "" || b.ProductName.Contains(productName))
                         && (supplierId == -1 || m.SupplierId == supplierId)
                         && wareHouseIDlist.Contains(t.Id)
                         && m.BillStatus == 1000
                        orderby w.PurchaseDate descending
                        select new PurchaseDetail
                        {
                            Id = p.Id,
                            StorageId = p.StorageId,
                            ProductId = p.ProductId,
                            PurchaseDate = w.PurchaseDate,
                            PurchaseNumber = w.PurchaseNumber,
                            WareHouseName = t.Name,
                            PlatformMerchantCode = p.PlatformMerchantCode,
                            ProductsCount = p.ProductsCount,
                            ProductsMoney = p.ProductsMoney,
                            ProductsPrice = p.ProductsPrice,
                            Ref = m.Ref,
                            CreateID = p.CreateID,
                            CreateDate = p.CreateDate,
                            UpdateDate = p.UpdateDate,
                            UpdateID = p.UpdateID,
                            BillMemo = m.BillMemo,
                            IsEnable = p.IsEnable
                        };
            return query.ToList();
        }


        /// <summary>
        /// get to XMStorageProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMStorageProductDetails Page List</returns>
        public PagedList<XMStorageProductDetails> SearchXMStorageProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMStorageProductDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMStorageProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMStorageProductDetails by Id
        /// </summary>
        /// <param name="id">XMStorageProductDetails Id</param>
        /// <returns>XMStorageProductDetails</returns>   
        public XMStorageProductDetails GetXMStorageProductDetailsById(int id)
        {
            var query = from p in this._context.XMStorageProductDetails
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storageID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public List<XMStorageProductDetails> GetXMStorageProductDetailsByIDOrProductInfo(int storageID, string PlatformMerchantCode, string ProductName)
        {
            var query = from p in this._context.XMStorageProductDetails
                        join t in this._context.XMProducts
                        on p.ProductId equals t.Id
                        where p.StorageId == storageID && p.IsEnable == false
                        && (PlatformMerchantCode == "" || p.PlatformMerchantCode.Contains(PlatformMerchantCode))
                        && (ProductName == "" || t.ProductName.Contains(ProductName))
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storageID"></param>
        /// <returns></returns>
        public List<XMStorageProductDetails> GetXMStorageProductDetailsByStorageID(int storageID)
        {
            var query = from p in this._context.XMStorageProductDetails
                        where p.StorageId == storageID && p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// delete XMStorageProductDetails by Id
        /// </summary>
        /// <param name="Id">XMStorageProductDetails Id</param>
        public void DeleteXMStorageProductDetails(int id)
        {
            var xmstorageproductdetails = this.GetXMStorageProductDetailsById(id);
            if (xmstorageproductdetails == null)
                return;

            if (!this._context.IsAttached(xmstorageproductdetails))
                this._context.XMStorageProductDetails.Attach(xmstorageproductdetails);

            this._context.DeleteObject(xmstorageproductdetails);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMStorageProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMStorageProductDetails Id</param>
        public void BatchDeleteXMStorageProductDetails(List<int> ids)
        {
            var query = from q in _context.XMStorageProductDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmstorageproductdetailss = query.ToList();
            foreach (var item in xmstorageproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMStorageProductDetails.Attach(item);

                _context.XMStorageProductDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
