
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
    public partial class LogService: ILogService
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
    	public LogService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ILogService成员
        /// <summary>
        /// Insert into Log
        /// </summary>
        /// <param name="log">Log</param>
    	public void InsertLog(Log log)
    	{	
            if (log == null)
                return;
    
            if (!this._context.IsAttached(log))
    			
                this._context.Logs.AddObject(log);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Log
        /// </summary>
        /// <param name="log">Log</param>
        public void UpdateLog(Log log)
        {
            if (log == null)
                return;
    
            if (this._context.IsAttached(log))
                this._context.Logs.Attach(log);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Log list
        /// </summary>
        public List<Log> GetLogList()
        {		
            var query = from p in this._context.Logs
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Log Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Log Page List</returns>
        public PagedList<Log> SearchLog(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Logs
                        orderby p.LogID
                        select p;
            return new PagedList<Log>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Log by LogID
        /// </summary>
        /// <param name="logid">Log LogID</param>
        /// <returns>Log</returns>   
        public Log GetLogByLogID(int logid)
        {
            var query = from p in this._context.Logs
                        where p.LogID.Equals(logid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Log by LogID
        /// </summary>
        /// <param name="LogID">Log LogID</param>
        public void DeleteLog(int logid)
        {
            var log = this.GetLogByLogID(logid);
            if (log == null)
                return;
    
            if (!this._context.IsAttached(log))
                this._context.Logs.Attach(log);
    
            this._context.DeleteObject(log);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Log by LogID
        /// </summary>
        /// <param name="LogIDs">Log LogID</param>
        public void BatchDeleteLog(List<int> logids)
        {
    	   var query = from q in _context.Logs
                    where logids.Contains(q.LogID)
                    select q;
            var logs = query.ToList();
            foreach (var item in logs)
            {
                if (!_context.IsAttached(item))
                    _context.Logs.Attach(item);  
    
                _context.Logs.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
