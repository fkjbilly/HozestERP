
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
    public partial class XMStorageService: IXMStorageService
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
                        orderby p.Id
                        select p;
            return new PagedList<XMStorage>(query, pageIndex, pageSize, sortExpression, sortDirection);
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
                        select p;
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
