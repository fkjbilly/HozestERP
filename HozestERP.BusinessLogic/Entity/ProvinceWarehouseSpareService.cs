
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:28:32
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

namespace HozestERP.BusinessLogic.Entity
{
    public partial class ProvinceWarehouseSpareService: IProvinceWarehouseSpareService
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
    	public ProvinceWarehouseSpareService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IProvinceWarehouseSpareService成员
        /// <summary>
        /// Insert into ProvinceWarehouseSpare
        /// </summary>
        /// <param name="provincewarehousespare">ProvinceWarehouseSpare</param>
    	public void InsertProvinceWarehouseSpare(ProvinceWarehouseSpare provincewarehousespare)
    	{	
            if (provincewarehousespare == null)
                return;
    
            if (!this._context.IsAttached(provincewarehousespare))
    			
                this._context.ProvinceWarehouseSpares.AddObject(provincewarehousespare);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into ProvinceWarehouseSpare
        /// </summary>
        /// <param name="provincewarehousespare">ProvinceWarehouseSpare</param>
        public void UpdateProvinceWarehouseSpare(ProvinceWarehouseSpare provincewarehousespare)
        {
            if (provincewarehousespare == null)
                return;
    
            if (this._context.IsAttached(provincewarehousespare))
                this._context.ProvinceWarehouseSpares.Attach(provincewarehousespare);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to ProvinceWarehouseSpare list
        /// </summary>
        public List<ProvinceWarehouseSpare> GetProvinceWarehouseSpareList()
        {		
            var query = from p in this._context.ProvinceWarehouseSpares
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to ProvinceWarehouseSpare Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>ProvinceWarehouseSpare Page List</returns>
        public PagedList<ProvinceWarehouseSpare> SearchProvinceWarehouseSpare(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.ProvinceWarehouseSpares
                        orderby p.ID
                        select p;
            return new PagedList<ProvinceWarehouseSpare>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a ProvinceWarehouseSpare by ID
        /// </summary>
        /// <param name="id">ProvinceWarehouseSpare ID</param>
        /// <returns>ProvinceWarehouseSpare</returns>   
        public ProvinceWarehouseSpare GetProvinceWarehouseSpareByID(int id)
        {
            var query = from p in this._context.ProvinceWarehouseSpares
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete ProvinceWarehouseSpare by ID
        /// </summary>
        /// <param name="ID">ProvinceWarehouseSpare ID</param>
        public void DeleteProvinceWarehouseSpare(int id)
        {
            var provincewarehousespare = this.GetProvinceWarehouseSpareByID(id);
            if (provincewarehousespare == null)
                return;
    
            if (!this._context.IsAttached(provincewarehousespare))
                this._context.ProvinceWarehouseSpares.Attach(provincewarehousespare);
    
            this._context.DeleteObject(provincewarehousespare);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete ProvinceWarehouseSpare by ID
        /// </summary>
        /// <param name="IDs">ProvinceWarehouseSpare ID</param>
        public void BatchDeleteProvinceWarehouseSpare(List<int> ids)
        {
    	   var query = from q in _context.ProvinceWarehouseSpares
                    where ids.Contains(q.ID)
                    select q;
            var provincewarehousespares = query.ToList();
            foreach (var item in provincewarehousespares)
            {
                if (!_context.IsAttached(item))
                    _context.ProvinceWarehouseSpares.Attach(item);  
    
                _context.ProvinceWarehouseSpares.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
