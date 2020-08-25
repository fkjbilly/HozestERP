using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageTableLog
{
    public interface ITableUpdateLogService
    {
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
        PagedList<TableUpdateLog> GetTableLogsByConditions(int requestID, String tableName, String fieldName, DateTime? updateTime, String updator, int pageIndex, int pageSize);

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="record"></param>
        void InsertTableUpdateLog(TableUpdateLog record);
    }
}
