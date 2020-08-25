
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMStorageService : IXMStorageService
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
        public XMStorageService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMStorageService成员
        /// <summary>
        /// Insert into XMStorage
        /// </summary>
        /// <param name="xmstorage">XMStorage</param>
        public void InsertXMStorage(XMStorage xmstorage)
        {
            if (xmstorage == null)
                return;

            if (!this._context.IsAttached(xmstorage))

                this._context.XMStorages.AddObject(xmstorage);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMStorage
        /// </summary>
        /// <param name="xmstorage">XMStorage</param>
        public void UpdateXMStorage(XMStorage xmstorage)
        {
            if (xmstorage == null)
                return;

            if (this._context.IsAttached(xmstorage))
                this._context.XMStorages.Attach(xmstorage);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMStorage list
        /// </summary>
        public List<XMStorage> GetXMStorageList()
        {
            var query = from p in this._context.XMStorages
                        where p.IsEnable == false
                        orderby p.Id descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMStorage list  by  purchaseID
        /// </summary>
        /// <param name="purchaseID"></param>
        /// <returns></returns>
        public List<XMStorage> GetXMStorageListByPurcahaseID(int purchaseID)
        {
            var query = from p in this._context.XMStorages
                        where p.IsEnable == false
                        && p.PurchaseId == purchaseID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseID"></param>
        /// <param name="storageStatus"></param>
        /// <returns></returns>
        public List<XMStorage> GetXMStorageListByPurcahaseIDAndStorageStatus(int purchaseID, int storageStatus)
        {
            var query = from p in this._context.XMStorages
                        where p.IsEnable == false
                        && p.PurchaseId == purchaseID
                        && p.BillStatus == storageStatus
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMStorage Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMStorage Page List</returns>
        public PagedList<XMStorage> SearchXMStorage(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMStorages
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMStorage>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storageCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="supplierId"></param>
        /// <param name="wareHousesId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<XMStorage> GetXMStorageByParm(string storageCode, string begin, string end, int supplierId, string wareHourseId, int status, int projectId, string nickids)
        {
            int?[] wareHourseIdlist = Array.ConvertAll<string, int?>(wareHourseId.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMStorages
                        join t in this._context.XMWareHouses
                        on p.WareHouseId equals t.Id
                        where p.IsEnable == false
                           && (storageCode == "" || p.Ref.Contains(storageCode))
                           && ((begin == "" && end == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                             //&& (wareHourseId == -1 || p.wareHourseId == wareHourseId)
                             && wareHourseIdlist.Contains(p.WareHouseId)
                            //&& (projectId == -1 || t.ProjectId == projectId)
                             && (status == -1 || p.BillStatus == status)
                             && (supplierId == -1 || p.SupplierId == supplierId)
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// nickid == -1  projectid!=-1
        /// </summary>
        /// <param name="storageCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="supplierId"></param>
        /// <param name="wareHousesId"></param>
        /// <param name="status"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        public List<XMStorage> GetXMStorageByProjectID(string storageCode, string begin, string end, int supplierId, int wareHousesId, int status, string projectids, int projectId)
        {
            int?[] projectlist = Array.ConvertAll<string, int?>(projectids.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMStorages
                        join t in this._context.XMWareHouses
                        on p.WareHouseId equals t.Id
                        where p.IsEnable == false
                              && ((begin == "" && end == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                              && (storageCode == "" || p.Ref.Contains(storageCode))
                              && (supplierId == -1 || p.SupplierId == supplierId)
                              && (wareHousesId == -1 || p.WareHouseId == wareHousesId)
                              && (status == -1 || p.BillStatus == status)
                               && ((t.NickId == -1 || t.NickId == 99) && projectlist.Contains(t.ProjectId))
     && (projectId == -1 || t.ProjectId == projectId)
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public List<XMStorage> GetXMStorageBySupplierId(int supplierID)
        {
            var query = from p in this._context.XMStorages
                        where p.IsEnable == false
                        && p.SupplierId == supplierID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 根据仓库ID 查询相关记录
        /// </summary>
        /// <param name="wareHoursesID"></param>
        /// <returns></returns>
        public List<XMStorage> GetXMStorageByWareHoursesId(int wareHoursesID)
        {
            var query = from p in this._context.XMStorages
                        where p.IsEnable == false
                        && p.WareHouseId == wareHoursesID
                        select p;
            return query.ToList();
        }

        public List<XMStorage> GetXMStorageByRef(string Ref)
        {
            var query = from p in this._context.XMStorages
                        where p.IsEnable == false
                        && p.Ref == Ref
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get a XMStorage by Id
        /// </summary>
        /// <param name="id">XMStorage Id</param>
        /// <returns>XMStorage</returns>   
        public XMStorage GetXMStorageById(int id)
        {
            var query = from p in this._context.XMStorages
                        where p.Id.Equals(id)
                        && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        public ImportStorage GetDetail(string refNo, string manufacturersCode)
        {
            var query = from p in _context.XMStorages
                        join m in _context.XMStorageProductDetails on p.Id equals m.StorageId into temp
                        from pm in temp.DefaultIfEmpty()
                        join n in _context.XMProducts on pm.ProductId equals n.Id into temp1
                        from pn in temp1.DefaultIfEmpty()
                        where p.Ref==refNo && pn.ManufacturersCode==manufacturersCode
                        select new ImportStorage
                        {
                            Id = p.Id,
                            Ref=p.Ref,
                            ProductsCount=pm.ProductsCount,
                            WareHouseId=p.WareHouseId
                        };

            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMStorage by Id
        /// </summary>
        /// <param name="Id">XMStorage Id</param>
        public void DeleteXMStorage(int id)
        {
            var xmstorage = this.GetXMStorageById(id);
            if (xmstorage == null)
                return;

            if (!this._context.IsAttached(xmstorage))
                this._context.XMStorages.Attach(xmstorage);

            this._context.DeleteObject(xmstorage);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMStorage by Id
        /// </summary>
        /// <param name="Ids">XMStorage Id</param>
        public void BatchDeleteXMStorage(List<int> ids)
        {
            var query = from q in _context.XMStorages
                        where ids.Contains(q.Id)
                        select q;
            var xmstorages = query.ToList();
            foreach (var item in xmstorages)
            {
                if (!_context.IsAttached(item))
                    _context.XMStorages.Attach(item);

                _context.XMStorages.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
