
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-08-02 16:02:12
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

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class XMZMDemandService: IXMZMDemandService
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
    	public XMZMDemandService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMZMDemandService成员
        /// <summary>
        /// Insert into XMZMDemand
        /// </summary>
        /// <param name="xmzmdemand">XMZMDemand</param>
    	public void InsertXMZMDemand(XMZMDemand xmzmdemand)
    	{	
            if (xmzmdemand == null)
                return;
    
            if (!this._context.IsAttached(xmzmdemand))
    			
                this._context.XMZMDemands.AddObject(xmzmdemand);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMZMDemand
        /// </summary>
        /// <param name="xmzmdemand">XMZMDemand</param>
        public void UpdateXMZMDemand(XMZMDemand xmzmdemand)
        {
            if (xmzmdemand == null)
                return;
    
            if (this._context.IsAttached(xmzmdemand))
                this._context.XMZMDemands.Attach(xmzmdemand);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMZMDemand list
        /// </summary>
        public List<XMZMDemand> GetXMZMDemandList()
        {		
            var query = from p in this._context.XMZMDemands
                        select p;
            return query.ToList();
        }

        public List<XMZMDemand> GetXMZMDemandList(string requirements, int Tid)
        {
            var query = from p in this._context.XMZMDemands
                        where p.requirements.Contains(requirements)
                        && (Tid == -1 || p.Tid == Tid)
                        select p;
            return query.ToList();

        }
    
    	
        /// <summary>
        /// get to XMZMDemand Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMZMDemand Page List</returns>
        public PagedList<XMZMDemand> SearchXMZMDemand(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMZMDemands
                        orderby p.ID
                        select p;
            return new PagedList<XMZMDemand>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMZMDemand by ID
        /// </summary>
        /// <param name="id">XMZMDemand ID</param>
        /// <returns>XMZMDemand</returns>   
        public XMZMDemand GetXMZMDemandByID(int id)
        {
            var query = from p in this._context.XMZMDemands
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public int GetXMZMDemandTidByID(int id)
        {
            var query = from p in this._context.XMZMDemands
                        where p.ID.Equals(id)
                        select p.Tid;
            return (int)query.SingleOrDefault();
        }

        public List<XMZMDemand> GetXMZMDemandListByTid(int Tid)
        {
            var query = from p in this._context.XMZMDemands
                        where p.Tid == Tid
                        select p;
            return query.ToList();
        }

    	/// <summary>
        /// delete XMZMDemand by ID
        /// </summary>
        /// <param name="ID">XMZMDemand ID</param>
        public void DeleteXMZMDemand(int id)
        {
            var xmzmdemand = this.GetXMZMDemandByID(id);
            if (xmzmdemand == null)
                return;
    
            if (!this._context.IsAttached(xmzmdemand))
                this._context.XMZMDemands.Attach(xmzmdemand);
    
            this._context.DeleteObject(xmzmdemand);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMZMDemand by ID
        /// </summary>
        /// <param name="IDs">XMZMDemand ID</param>
        public void BatchDeleteXMZMDemand(List<int> ids)
        {
    	   var query = from q in _context.XMZMDemands
                    where ids.Contains(q.ID)
                    select q;
            var xmzmdemands = query.ToList();
            foreach (var item in xmzmdemands)
            {
                if (!_context.IsAttached(item))
                    _context.XMZMDemands.Attach(item);  
    
                _context.XMZMDemands.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
