
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
    public partial class XMNickService: IXMNickService
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
    	public XMNickService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMNickService成员
        /// <summary>
        /// Insert into XMNick
        /// </summary>
        /// <param name="xmnick">XMNick</param>
    	public void InsertXMNick(XMNick xmnick)
    	{	
            if (xmnick == null)
                return;
    
            if (!this._context.IsAttached(xmnick))
    			
                this._context.XMNicks.AddObject(xmnick);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMNick
        /// </summary>
        /// <param name="xmnick">XMNick</param>
        public void UpdateXMNick(XMNick xmnick)
        {
            if (xmnick == null)
                return;
    
            if (this._context.IsAttached(xmnick))
                this._context.XMNicks.Attach(xmnick);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMNick list
        /// </summary>
        public List<XMNick> GetXMNickList()
        {		
            var query = from p in this._context.XMNicks
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMNick Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMNick Page List</returns>
        public PagedList<XMNick> SearchXMNick(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMNicks
                        orderby p.nick_id
                        select p;
            return new PagedList<XMNick>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMNick by nick_id
        /// </summary>
        /// <param name="nick_id">XMNick nick_id</param>
        /// <returns>XMNick</returns>   
        public XMNick GetXMNickBynick_id(int nick_id)
        {
            var query = from p in this._context.XMNicks
                        where p.nick_id.Equals(nick_id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMNick by nick_id
        /// </summary>
        /// <param name="nick_id">XMNick nick_id</param>
        public void DeleteXMNick(int nick_id)
        {
            var xmnick = this.GetXMNickBynick_id(nick_id);
            if (xmnick == null)
                return;
    
            if (!this._context.IsAttached(xmnick))
                this._context.XMNicks.Attach(xmnick);
    
            this._context.DeleteObject(xmnick);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMNick by nick_id
        /// </summary>
        /// <param name="nick_ids">XMNick nick_id</param>
        public void BatchDeleteXMNick(List<int> nick_ids)
        {
    	   var query = from q in _context.XMNicks
                    where nick_ids.Contains(q.nick_id)
                    select q;
            var xmnicks = query.ToList();
            foreach (var item in xmnicks)
            {
                if (!_context.IsAttached(item))
                    _context.XMNicks.Attach(item);  
    
                _context.XMNicks.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
