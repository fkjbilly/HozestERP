
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-06-07 14:28:04
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class ProvinceWarehouseService : IProvinceWarehouseService
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
        public ProvinceWarehouseService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IProvinceWarehouseService成员
        /// <summary>
        /// Insert into ProvinceWarehouse
        /// </summary>
        /// <param name="provincewarehouse">ProvinceWarehouse</param>
        public void InsertProvinceWarehouse(ProvinceWarehouse provincewarehouse)
        {
            if (provincewarehouse == null)
                return;

            if (!this._context.IsAttached(provincewarehouse))

                this._context.ProvinceWarehouses.AddObject(provincewarehouse);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into ProvinceWarehouse
        /// </summary>
        /// <param name="provincewarehouse">ProvinceWarehouse</param>
        public void UpdateProvinceWarehouse(ProvinceWarehouse provincewarehouse)
        {
            if (provincewarehouse == null)
                return;

            if (this._context.IsAttached(provincewarehouse))
                this._context.ProvinceWarehouses.Attach(provincewarehouse);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to ProvinceWarehouse list
        /// </summary>
        public List<ProvinceWarehouse> GetProvinceWarehouseList()
        {
            var query = from p in this._context.ProvinceWarehouses
                        where p.IsEnabled == false
                        select p;
            return query.ToList();
        }

        public List<ProvinceWarehouse> GetProvinceWarehouseListByWarehouseID(int WarehouseID)
        {
            var query = from p in this._context.ProvinceWarehouses
                        where p.IsEnabled == false
                        && (WarehouseID == -1 || p.WarehouseID == WarehouseID)
                        select p;
            return query.ToList();
        }

        public List<ProvinceWarehouse> GetProvinceWarehouseListByParam(int WarehouseID, string ProvinceName)
        {
            var query = from p in this._context.ProvinceWarehouses
                        where p.IsEnabled == false
                        && (WarehouseID == -1 || p.WarehouseID == WarehouseID)
                        && p.ProvinceName.Contains(ProvinceName)
                        select p;
            return query.ToList();
        }

        public CodeList GetWarehouseName(int CodeID)
        {
            var query = from p in this._context.CodeLists
                        where p.CodeTypeID == 227
                        && p.CodeID == CodeID
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// get to ProvinceWarehouse Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>ProvinceWarehouse Page List</returns>
        public PagedList<ProvinceWarehouse> SearchProvinceWarehouse(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.ProvinceWarehouses
                        orderby p.ID
                        select p;
            return new PagedList<ProvinceWarehouse>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a ProvinceWarehouse by ID
        /// </summary>
        /// <param name="id">ProvinceWarehouse ID</param>
        /// <returns>ProvinceWarehouse</returns>   
        public ProvinceWarehouse GetProvinceWarehouseByID(int id)
        {
            var query = from p in this._context.ProvinceWarehouses
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete ProvinceWarehouse by ID
        /// </summary>
        /// <param name="ID">ProvinceWarehouse ID</param>
        public void DeleteProvinceWarehouse(int id)
        {
            var provincewarehouse = this.GetProvinceWarehouseByID(id);
            if (provincewarehouse == null)
                return;

            if (!this._context.IsAttached(provincewarehouse))
                this._context.ProvinceWarehouses.Attach(provincewarehouse);

            this._context.DeleteObject(provincewarehouse);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete ProvinceWarehouse by ID
        /// </summary>
        /// <param name="IDs">ProvinceWarehouse ID</param>
        public void BatchDeleteProvinceWarehouse(List<int> ids)
        {
            var query = from q in _context.ProvinceWarehouses
                        where ids.Contains(q.ID)
                        select q;
            var provincewarehouses = query.ToList();
            foreach (var item in provincewarehouses)
            {
                if (!_context.IsAttached(item))
                    _context.ProvinceWarehouses.Attach(item);

                _context.ProvinceWarehouses.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
