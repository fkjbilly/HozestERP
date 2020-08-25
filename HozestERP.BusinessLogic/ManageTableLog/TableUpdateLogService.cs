using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageTableLog
{
    public class TableUpdateLogService : ITableUpdateLogService
    {
       #region Fields
       private readonly HozestERPObjectContext _context;
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
            this._cacheManager = new HozestERPStaticCache();
        }
        #endregion


        #region ITableUpdateLogService 成员

        /// <summary>
        /// 根据条件查询出数据修改记录
        /// </summary>
        /// <param name="requestID">记录的主键值</param>
        /// <param name="tableName">记录的表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="updator">修改人</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public PagedList<TableUpdateLog> GetTableLogsByConditions(int requestID, string tableName, string fieldName, DateTime? updateTime, string updator, int pageIndex, int pageSize)
        {
            var query = from log in this._context.TableUpdateLogs
                        join user in this._context.Customers 
                            on log.OperatorID equals user.CustomerID 
                        where log.RequestID.Equals(requestID)
                         && log.TableName.Equals(tableName)
                         && (fieldName == "" || log.FieldName.Equals(fieldName))
                         && (updateTime == null || log.UpdateTime>updateTime)
                         && (updator == "" || user.Username.Equals(updator))
                        orderby log.UpdateTime descending
                        select log;
            return new PagedList<TableUpdateLog>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="record"></param>
        public void InsertTableUpdateLog(TableUpdateLog record)
        {
            if (record == null)
                throw new ArgumentNullException("TableUpdateLog");
            _context.TableUpdateLogs.AddObject(record);
            _context.SaveChanges();
        }
        #endregion
    }
}