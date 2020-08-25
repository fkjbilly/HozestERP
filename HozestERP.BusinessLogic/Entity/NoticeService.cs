
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
    public partial class NoticeService: INoticeService
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
    	public NoticeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region INoticeService成员
        /// <summary>
        /// Insert into Notice
        /// </summary>
        /// <param name="notice">Notice</param>
    	public void InsertNotice(Notice notice)
    	{	
            if (notice == null)
                return;
    
            if (!this._context.IsAttached(notice))
    			
                this._context.Notices.AddObject(notice);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Notice
        /// </summary>
        /// <param name="notice">Notice</param>
        public void UpdateNotice(Notice notice)
        {
            if (notice == null)
                return;
    
            if (this._context.IsAttached(notice))
                this._context.Notices.Attach(notice);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Notice list
        /// </summary>
        public List<Notice> GetNoticeList()
        {		
            var query = from p in this._context.Notices
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Notice Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Notice Page List</returns>
        public PagedList<Notice> SearchNotice(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Notices
                        orderby p.ID
                        select p;
            return new PagedList<Notice>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Notice by ID
        /// </summary>
        /// <param name="id">Notice ID</param>
        /// <returns>Notice</returns>   
        public Notice GetNoticeByID(System.Guid id)
        {
            var query = from p in this._context.Notices
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Notice by ID
        /// </summary>
        /// <param name="ID">Notice ID</param>
        public void DeleteNotice(System.Guid id)
        {
            var notice = this.GetNoticeByID(id);
            if (notice == null)
                return;
    
            if (!this._context.IsAttached(notice))
                this._context.Notices.Attach(notice);
    
            this._context.DeleteObject(notice);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Notice by ID
        /// </summary>
        /// <param name="IDs">Notice ID</param>
        public void BatchDeleteNotice(List<System.Guid> ids)
        {
    	   var query = from q in _context.Notices
                    where ids.Contains(q.ID)
                    select q;
            var notices = query.ToList();
            foreach (var item in notices)
            {
                if (!_context.IsAttached(item))
                    _context.Notices.Attach(item);  
    
                _context.Notices.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
