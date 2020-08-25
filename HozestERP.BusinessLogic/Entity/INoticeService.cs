
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
    public partial interface INoticeService
    {
        #region INoticeService成员
        /// <summary>
        /// Insert into Notice
        /// </summary>
        /// <param name="notice">Notice</param>
    	void InsertNotice(Notice notice);
    	
        /// <summary>
        /// Update into Notice
        /// </summary>
        /// <param name="notice">Notice</param>
        void UpdateNotice(Notice notice);	
    	
        /// <summary>
        /// get to Notice list
        /// </summary>
        List<Notice> GetNoticeList();
    	       
    	/// <summary>
    	/// get to Notice Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Notice Page List</returns>
    	PagedList<Notice> SearchNotice(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Notice by ID
        /// </summary>
        /// <param name="id">Notice ID</param>
        /// <returns>Notice</returns>   
        Notice GetNoticeByID(System.Guid id);
    
    	/// <summary>
        /// delete Notice by ID
        /// </summary>
        /// <param name="ID">Notice ID</param>
        void DeleteNotice(System.Guid id);
    	
    	/// <summary>
        /// Batch delete Notice by ID
        /// </summary>
        /// <param name="IDs">Notice ID</param>
        void BatchDeleteNotice(List<System.Guid> ids);

        #endregion
    }
}
