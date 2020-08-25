
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-05-25 16:55:27
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
    public partial class XMInventoryLedgerService : IXMInventoryLedgerService
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
        public XMInventoryLedgerService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMInventoryLedgerService成员
        /// <summary>
        /// Insert into XMInventoryLedger
        /// </summary>
        /// <param name="xminventoryledger">XMInventoryLedger</param>
        public void InsertXMInventoryLedger(XMInventoryLedger xminventoryledger)
        {
            if (xminventoryledger == null)
                return;

            if (!this._context.IsAttached(xminventoryledger))

                this._context.XMInventoryLedgers.AddObject(xminventoryledger);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMInventoryLedger
        /// </summary>
        /// <param name="xminventoryledger">XMInventoryLedger</param>
        public void UpdateXMInventoryLedger(XMInventoryLedger xminventoryledger)
        {
            if (xminventoryledger == null)
                return;

            if (this._context.IsAttached(xminventoryledger))
                this._context.XMInventoryLedgers.Attach(xminventoryledger);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMInventoryLedger list
        /// </summary>
        public List<XMInventoryLedger> GetXMInventoryLedgerList()
        {
            var query = from p in this._context.XMInventoryLedgers
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHousesID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <returns></returns>
        public XMInventoryLedger GetXMInventoryLedgerByParm(int wareHousesID, string PlatformMerchantCode)
        {
            var query = from p in this._context.XMInventoryLedgers
                        where p.WarehouseId == wareHousesID && p.PlatformMerchantCode == PlatformMerchantCode
                        orderby p.CreateDate descending
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code">商品编码</param>
        /// <param name="productName"></param>
        /// <param name="nickID"></param>
        /// <param name="wareHouseID"></param>
        /// <returns></returns>
        public List<XMInventoryLedger> GetXMInventoryLedgerListByParm(string code, string productName, string nicks, string wareHouseID)
        {
            int?[] wareHouseIDlist = Array.ConvertAll<string, int?>(wareHouseID.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMInventoryLedgers
                        join m in this._context.XMProducts
                        on p.ProductId equals m.Id
                        join t in this._context.XMWareHouses
                        on p.WarehouseId equals t.Id
                        where (code == "" || p.PlatformMerchantCode.Contains(code))
                        && (productName == "" || m.ProductName.Contains(productName))
                        && wareHouseIDlist.Contains(p.WarehouseId)
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="productName"></param>
        /// <param name="wareHouseID"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        public List<XMInventoryLedger> GetXMInventoryLedgerListByProjectID(string code, string productName, int wareHouseID, string projectids)
        {
            int?[] projectIdlist = Array.ConvertAll<string, int?>(projectids.Split(','), delegate(string s) { return int.Parse(s); });
               var query = from p in this._context.XMInventoryLedgers
                        join m in this._context.XMProducts
                        on p.ProductId equals m.Id
                        join t in this._context.XMWareHouses
                        on p.WarehouseId equals t.Id
                        where (code == "" || p.PlatformMerchantCode.Contains(code))
                        && (productName == "" || m.ProductName.Contains(productName))
                          && ((t.NickId == -1 || t.NickId == 99) && projectIdlist.Contains(t.ProjectId))
                          && (wareHouseID == -1 || p.WarehouseId == wareHouseID)
                           orderby p.CreateDate descending
                           select p;
               return query.ToList();
        }

        /// <summary>
        /// get to XMInventoryLedger Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInventoryLedger Page List</returns>
        public PagedList<XMInventoryLedger> SearchXMInventoryLedger(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInventoryLedgers
                        orderby p.Id
                        select p;
            return new PagedList<XMInventoryLedger>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMInventoryLedger by Id
        /// </summary>
        /// <param name="id">XMInventoryLedger Id</param>
        /// <returns>XMInventoryLedger</returns>   
        public XMInventoryLedger GetXMInventoryLedgerById(int id)
        {
            var query = from p in this._context.XMInventoryLedgers
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMInventoryLedger by Id
        /// </summary>
        /// <param name="Id">XMInventoryLedger Id</param>
        public void DeleteXMInventoryLedger(int id)
        {
            var xminventoryledger = this.GetXMInventoryLedgerById(id);
            if (xminventoryledger == null)
                return;

            if (!this._context.IsAttached(xminventoryledger))
                this._context.XMInventoryLedgers.Attach(xminventoryledger);

            this._context.DeleteObject(xminventoryledger);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMInventoryLedger by Id
        /// </summary>
        /// <param name="Ids">XMInventoryLedger Id</param>
        public void BatchDeleteXMInventoryLedger(List<int> ids)
        {
            var query = from q in _context.XMInventoryLedgers
                        where ids.Contains(q.Id)
                        select q;
            var xminventoryledgers = query.ToList();
            foreach (var item in xminventoryledgers)
            {
                if (!_context.IsAttached(item))
                    _context.XMInventoryLedgers.Attach(item);

                _context.XMInventoryLedgers.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
