
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
    public partial class KFChatLogService: IKFChatLogService
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
    	public KFChatLogService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IKFChatLogService成员
        /// <summary>
        /// Insert into KFChatLog
        /// </summary>
        /// <param name="kfchatlog">KFChatLog</param>
    	public void InsertKFChatLog(KFChatLog kfchatlog)
    	{	
            if (kfchatlog == null)
                return;
    
            if (!this._context.IsAttached(kfchatlog))
    			
                this._context.KFChatLogs.AddObject(kfchatlog);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into KFChatLog
        /// </summary>
        /// <param name="kfchatlog">KFChatLog</param>
        public void UpdateKFChatLog(KFChatLog kfchatlog)
        {
            if (kfchatlog == null)
                return;
    
            if (this._context.IsAttached(kfchatlog))
                this._context.KFChatLogs.Attach(kfchatlog);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to KFChatLog list
        /// </summary>
        public List<KFChatLog> GetKFChatLogList()
        {		
            var query = from p in this._context.KFChatLogs
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to KFChatLog Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>KFChatLog Page List</returns>
        public PagedList<KFChatLog> SearchKFChatLog(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.KFChatLogs
                        orderby p.Id
                        select p;
            return new PagedList<KFChatLog>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a KFChatLog by Id
        /// </summary>
        /// <param name="id">KFChatLog Id</param>
        /// <returns>KFChatLog</returns>   
        public KFChatLog GetKFChatLogById(long id)
        {
            var query = from p in this._context.KFChatLogs
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete KFChatLog by Id
        /// </summary>
        /// <param name="Id">KFChatLog Id</param>
        public void DeleteKFChatLog(long id)
        {
            var kfchatlog = this.GetKFChatLogById(id);
            if (kfchatlog == null)
                return;
    
            if (!this._context.IsAttached(kfchatlog))
                this._context.KFChatLogs.Attach(kfchatlog);
    
            this._context.DeleteObject(kfchatlog);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete KFChatLog by Id
        /// </summary>
        /// <param name="Ids">KFChatLog Id</param>
        public void BatchDeleteKFChatLog(List<long> ids)
        {
    	   var query = from q in _context.KFChatLogs
                    where ids.Contains(q.Id)
                    select q;
            var kfchatlogs = query.ToList();
            foreach (var item in kfchatlogs)
            {
                if (!_context.IsAttached(item))
                    _context.KFChatLogs.Attach(item);  
    
                _context.KFChatLogs.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
