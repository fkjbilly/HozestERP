
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-07 08:51:54
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMOrderInfoPlanRecordService
    {
        #region IXMOrderInfoPlanRecordService成员
        /// <summary>
        /// Insert into XMOrderInfoPlanRecord
        /// </summary>
        /// <param name="xmorderinfoplanrecord">XMOrderInfoPlanRecord</param>
    	void InsertXMOrderInfoPlanRecord(XMOrderInfoPlanRecord xmorderinfoplanrecord);
    	
        /// <summary>
        /// Update into XMOrderInfoPlanRecord
        /// </summary>
        /// <param name="xmorderinfoplanrecord">XMOrderInfoPlanRecord</param>
        void UpdateXMOrderInfoPlanRecord(XMOrderInfoPlanRecord xmorderinfoplanrecord);

        /// <summary>
        /// Get a record by status
        /// </summary>
        /// <param name="id">status</param>
        /// <returns>record</returns>
        IList<XMOrderInfoPlanRecord> GetByStatus(string status);

        /// <summary>
        /// get to XMOrderInfoPlanRecord list
        /// </summary>
        List<XMOrderInfoPlanRecord> GetXMOrderInfoPlanRecordList();
    	       
    	/// <summary>
    	/// get to XMOrderInfoPlanRecord Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMOrderInfoPlanRecord Page List</returns>
    	PagedList<XMOrderInfoPlanRecord> SearchXMOrderInfoPlanRecord(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMOrderInfoPlanRecord by ID
        /// </summary>
        /// <param name="id">XMOrderInfoPlanRecord ID</param>
        /// <returns>XMOrderInfoPlanRecord</returns>   
        XMOrderInfoPlanRecord GetXMOrderInfoPlanRecordByID(int id);
    
    	/// <summary>
        /// delete XMOrderInfoPlanRecord by ID
        /// </summary>
        /// <param name="ID">XMOrderInfoPlanRecord ID</param>
        void DeleteXMOrderInfoPlanRecord(int id);
    	
    	/// <summary>
        /// Batch delete XMOrderInfoPlanRecord by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfoPlanRecord ID</param>
        void BatchDeleteXMOrderInfoPlanRecord(List<int> ids);

        #endregion
    }
}
