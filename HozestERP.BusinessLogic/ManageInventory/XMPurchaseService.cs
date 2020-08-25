
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
    public partial class XMPurchaseService : IXMPurchaseService
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
        public XMPurchaseService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMPurchaseService成员
        /// <summary>
        /// Insert into XMPurchase
        /// </summary>
        /// <param name="xmpurchase">XMPurchase</param>
        public void InsertXMPurchase(XMPurchase xmpurchase)
        {
            if (xmpurchase == null)
                return;

            if (!this._context.IsAttached(xmpurchase))

                this._context.XMPurchases.AddObject(xmpurchase);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMPurchase
        /// </summary>
        /// <param name="xmpurchase">XMPurchase</param>
        public void UpdateXMPurchase(XMPurchase xmpurchase)
        {
            if (xmpurchase == null)
                return;

            if (this._context.IsAttached(xmpurchase))
                this._context.XMPurchases.Attach(xmpurchase);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMPurchase list
        /// </summary>
        public List<XMPurchase> GetXMPurchaseList()
        {
            var query = from p in this._context.XMPurchases
                        where p.IsEnable == false
                        orderby p.Id descending
                        select p;
            return query.ToList();
        }

        public List<XMPurchase> GetXMPurchaseByParm(int PlatformTypeId, string MerchantCode, DateTime begin, DateTime end)
        {
            var query = from p in this._context.XMPurchases
                        join d in this._context.XMPurchaseProductDetails
                        on p.Id equals d.PurchaseId
                        where p.IsEnable == false
                        && d.IsEnable == false
                        && p.PurchaseDate >= begin && p.PurchaseDate < end
                        && d.PlatformMerchantCode == MerchantCode
                        && d.PlatformTypeId == PlatformTypeId
                        orderby p.Date_Created descending
                        select p;
            return query.Distinct().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purChaseCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="supplierId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<XMPurchase> GetXMPurchaseByParm(string purChaseCode, string begin, string end, int supplierId, int status, int storageStatus, string customerids, string EmitFactory, int BuildOrder)
        {
            bool IsBuildOrder = BuildOrder == 1 ? true : false;
            int?[] customerIdlist = Array.ConvertAll<string, int?>(customerids.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (status == -1)
            {
                if (begin != "" && end != "")
                {
                    purBeginTime = DateTime.Parse(begin);
                    purEndTime = DateTime.Parse(end);
                }
                var query = from p in this._context.XMPurchases
                            where p.IsEnable == false
                            && ((begin == "" && end == "") || (p.Date_Created >= purBeginTime && p.Date_Created < purEndTime))
                            && (purChaseCode == "" || p.PurchaseNumber.Contains(purChaseCode))
                            && (supplierId == -1 || p.SupplierId == supplierId)
                            && (storageStatus == -1 || p.BillStatus == storageStatus)
                            && customerIdlist.Contains(p.BizUserId)
                            && (EmitFactory == "-1" || p.EmitFactory == EmitFactory)
                            && (BuildOrder == -1 || (BuildOrder == 1 && p.IsBuildOrder == true) || (BuildOrder == 0 && (p.IsBuildOrder == false || p.IsBuildOrder == null)))
                            orderby p.Date_Created descending
                            select p;
                return query.ToList();
            }
            else
            {
                bool isAudit = status == 0 ? false : true;
                if (begin != "" && end != "")
                {
                    purBeginTime = DateTime.Parse(begin);
                    purEndTime = DateTime.Parse(end);
                }
                var query = from p in this._context.XMPurchases
                            where p.IsEnable == false
                            && ((begin == "" && end == "") || (p.Date_Created >= purBeginTime && p.Date_Created < purEndTime))
                            && (purChaseCode == "" || p.PurchaseNumber.Contains(purChaseCode))
                            && (supplierId == -1 || p.SupplierId == supplierId)
                            && (status == -1 || p.IsAudit == isAudit)
                            && (storageStatus == -1 || p.BillStatus == storageStatus)
                            && customerIdlist.Contains(p.BizUserId)
                            && (EmitFactory == "-1" || p.EmitFactory == EmitFactory)
                            && (BuildOrder == -1 || (BuildOrder == 1 && p.IsBuildOrder == true) || (BuildOrder == 0 && (p.IsBuildOrder == false || p.IsBuildOrder == null)))
                            orderby p.Date_Created descending
                            select p;
                return query.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purChaseCode"></param>
        /// <returns></returns>
        public List<XMPurchase> GetXMPurchaseBypurChaseCode(string purChaseCode)
        {
            var query = from p in this._context.XMPurchases
                        where p.IsEnable == false
                        && p.PurchaseNumber == purChaseCode
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 京东自营采购单根据条件查询
        /// </summary>
        /// <param name="purChaseCode"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public List<XMPurchase> GetXMPurchaseJDZYByParm(string purChaseCode, string address)
        {
            var query = from p in this._context.XMPurchases
                        where p.IsEnable == false
                           && p.PurchaseNumber == purChaseCode
                           && p.DealAddress.Contains(address)
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<XMPurchase> GetXMPurchaseListBySupplierID(int supplierId)
        {
            var query = from p in this._context.XMPurchases
                        where p.IsEnable == false
                        && p.SupplierId == supplierId
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMPurchase Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPurchase Page List</returns>
        public PagedList<XMPurchase> SearchXMPurchase(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPurchases
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMPurchase>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMPurchase by Id
        /// </summary>
        /// <param name="id">XMPurchase Id</param>
        /// <returns>XMPurchase</returns>   
        public XMPurchase GetXMPurchaseById(int id)
        {
            var query = from p in this._context.XMPurchases
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        public List<XMPurchase> GetXMPurchaseByIDs(List<int> IDs)
        {
            var query = from p in this._context.XMPurchases
                        where IDs.Contains(p.Id)
                        && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public ImportPurchase GetDetail(string purchaseNumber, string manufacturersCode)
        {
            var query = from p in _context.XMPurchases
                        join m in _context.XMPurchaseProductDetails on p.Id equals m.PurchaseId into temp
                        from pm in temp.DefaultIfEmpty()
                        join n in _context.XMProducts on pm.ProductId equals n.Id into temp1
                        from pn in temp1.DefaultIfEmpty()
                        where p.PurchaseNumber== purchaseNumber && pn.ManufacturersCode== manufacturersCode
                        select new ImportPurchase
                        {
                            Id=p.Id,
                            PurchaseNumber=p.PurchaseNumber,
                            ProductCount=pm.ProductCount
                        };

            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMPurchase by Id
        /// </summary>
        /// <param name="Id">XMPurchase Id</param>
        public void DeleteXMPurchase(int id)
        {
            var xmpurchase = this.GetXMPurchaseById(id);
            if (xmpurchase == null)
                return;

            if (!this._context.IsAttached(xmpurchase))
                this._context.XMPurchases.Attach(xmpurchase);

            this._context.DeleteObject(xmpurchase);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMPurchase by Id
        /// </summary>
        /// <param name="Ids">XMPurchase Id</param>
        public void BatchDeleteXMPurchase(List<int> ids)
        {
            var query = from q in _context.XMPurchases
                        where ids.Contains(q.Id)
                        select q;
            var xmpurchases = query.ToList();
            foreach (var item in xmpurchases)
            {
                if (!_context.IsAttached(item))
                    _context.XMPurchases.Attach(item);

                _context.XMPurchases.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
