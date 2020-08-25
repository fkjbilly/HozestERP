
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
    public partial class XMPremiumsService: IXMPremiumsService
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
    	public XMPremiumsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMPremiumsService成员
        /// <summary>
        /// Insert into XMPremiums
        /// </summary>
        /// <param name="xmpremiums">XMPremiums</param>
    	public void InsertXMPremiums(XMPremiums xmpremiums)
    	{	
            if (xmpremiums == null)
                return;
    
            if (!this._context.IsAttached(xmpremiums))
    			
                this._context.XMPremiums.AddObject(xmpremiums);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMPremiums
        /// </summary>
        /// <param name="xmpremiums">XMPremiums</param>
        public void UpdateXMPremiums(XMPremiums xmpremiums)
        {
            if (xmpremiums == null)
                return;
    
            if (this._context.IsAttached(xmpremiums))
                this._context.XMPremiums.Attach(xmpremiums);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMPremiums list
        /// </summary>
        public List<XMPremiums> GetXMPremiumsList()
        {		
            var query = from p in this._context.XMPremiums
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMPremiums Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPremiums Page List</returns>
        public PagedList<XMPremiums> SearchXMPremiums(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPremiums
                        orderby p.Id
                        select p;
            return new PagedList<XMPremiums>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMPremiums by Id
        /// </summary>
        /// <param name="id">XMPremiums Id</param>
        /// <returns>XMPremiums</returns>   
        public XMPremiums GetXMPremiumsById(int id)
        {
            var query = from p in this._context.XMPremiums
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMPremiums by Id
        /// </summary>
        /// <param name="Id">XMPremiums Id</param>
        public void DeleteXMPremiums(int id)
        {
            var xmpremiums = this.GetXMPremiumsById(id);
            if (xmpremiums == null)
                return;
    
            if (!this._context.IsAttached(xmpremiums))
                this._context.XMPremiums.Attach(xmpremiums);
    
            this._context.DeleteObject(xmpremiums);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMPremiums by Id
        /// </summary>
        /// <param name="Ids">XMPremiums Id</param>
        public void BatchDeleteXMPremiums(List<int> ids)
        {
    	   var query = from q in _context.XMPremiums
                    where ids.Contains(q.Id)
                    select q;
            var xmpremiumss = query.ToList();
            foreach (var item in xmpremiumss)
            {
                if (!_context.IsAttached(item))
                    _context.XMPremiums.Attach(item);  
    
                _context.XMPremiums.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
