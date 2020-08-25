
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
    public partial class TableUpdateLogService: ITableUpdateLogService
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
    	public TableUpdateLogService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ITableUpdateLogService成员
        /// <summary>
        /// Insert into TableUpdateLog
        /// </summary>
        /// <param name="tableupdatelog">TableUpdateLog</param>
    	public void InsertTableUpdateLog(TableUpdateLog tableupdatelog)
    	{	
            if (tableupdatelog == null)
                return;
    
            if (!this._context.IsAttached(tableupdatelog))
    			
                this._context.TableUpdateLogs.AddObject(tableupdatelog);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into TableUpdateLog
        /// </summary>
        /// <param name="tableupdatelog">TableUpdateLog</param>
        public void UpdateTableUpdateLog(TableUpdateLog tableupdatelog)
        {
            if (tableupdatelog == null)
                return;
    
            if (this._context.IsAttached(tableupdatelog))
                this._context.TableUpdateLogs.Attach(tableupdatelog);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to TableUpdateLog list
        /// </summary>
        public List<TableUpdateLog> GetTableUpdateLogList()
        {		
            var query = from p in this._context.TableUpdateLogs
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to TableUpdateLog Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>TableUpdateLog Page List</returns>
        public PagedList<TableUpdateLog> SearchTableUpdateLog(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.TableUpdateLogs
                        orderby p.LogID
                        select p;
            return new PagedList<TableUpdateLog>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a TableUpdateLog by LogID
        /// </summary>
        /// <param name="logid">TableUpdateLog LogID</param>
        /// <returns>TableUpdateLog</returns>   
        public TableUpdateLog GetTableUpdateLogByLogID(int logid)
        {
            var query = from p in this._context.TableUpdateLogs
                        where p.LogID.Equals(logid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete TableUpdateLog by LogID
        /// </summary>
        /// <param name="LogID">TableUpdateLog LogID</param>
        public void DeleteTableUpdateLog(int logid)
        {
            var tableupdatelog = this.GetTableUpdateLogByLogID(logid);
            if (tableupdatelog == null)
                return;
    
            if (!this._context.IsAttached(tableupdatelog))
                this._context.TableUpdateLogs.Attach(tableupdatelog);
    
            this._context.DeleteObject(tableupdatelog);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete TableUpdateLog by LogID
        /// </summary>
        /// <param name="LogIDs">TableUpdateLog LogID</param>
        public void BatchDeleteTableUpdateLog(List<int> logids)
        {
    	   var query = from q in _context.TableUpdateLogs
                    where logids.Contains(q.LogID)
                    select q;
            var tableupdatelogs = query.ToList();
            foreach (var item in tableupdatelogs)
            {
                if (!_context.IsAttached(item))
                    _context.TableUpdateLogs.Attach(item);  
    
                _context.TableUpdateLogs.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
