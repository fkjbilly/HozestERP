
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:27:57
** 修改人:
** 修改日期:
** 描 述: 接口类
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
    public partial interface ITableUpdateLogService
    {
        #region ITableUpdateLogService成员
        /// <summary>
        /// Insert into TableUpdateLog
        /// </summary>
        /// <param name="tableupdatelog">TableUpdateLog</param>
    	void InsertTableUpdateLog(TableUpdateLog tableupdatelog);
    	
        /// <summary>
        /// Update into TableUpdateLog
        /// </summary>
        /// <param name="tableupdatelog">TableUpdateLog</param>
        void UpdateTableUpdateLog(TableUpdateLog tableupdatelog);	
    	
        /// <summary>
        /// get to TableUpdateLog list
        /// </summary>
        List<TableUpdateLog> GetTableUpdateLogList();
    	       
    	/// <summary>
    	/// get to TableUpdateLog Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>TableUpdateLog Page List</returns>
    	PagedList<TableUpdateLog> SearchTableUpdateLog(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a TableUpdateLog by LogID
        /// </summary>
        /// <param name="logid">TableUpdateLog LogID</param>
        /// <returns>TableUpdateLog</returns>   
        TableUpdateLog GetTableUpdateLogByLogID(int logid);
    
    	/// <summary>
        /// delete TableUpdateLog by LogID
        /// </summary>
        /// <param name="LogID">TableUpdateLog LogID</param>
        void DeleteTableUpdateLog(int logid);
    	
    	/// <summary>
        /// Batch delete TableUpdateLog by LogID
        /// </summary>
        /// <param name="LogIDs">TableUpdateLog LogID</param>
        void BatchDeleteTableUpdateLog(List<int> logids);

        #endregion
    }
}
