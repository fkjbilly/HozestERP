
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
    public partial interface IXMCommunicationRecordService
    {
        #region IXMCommunicationRecordService成员
        /// <summary>
        /// Insert into XMCommunicationRecord
        /// </summary>
        /// <param name="xmcommunicationrecord">XMCommunicationRecord</param>
    	void InsertXMCommunicationRecord(XMCommunicationRecord xmcommunicationrecord);
    	
        /// <summary>
        /// Update into XMCommunicationRecord
        /// </summary>
        /// <param name="xmcommunicationrecord">XMCommunicationRecord</param>
        void UpdateXMCommunicationRecord(XMCommunicationRecord xmcommunicationrecord);	
    	
        /// <summary>
        /// get to XMCommunicationRecord list
        /// </summary>
        List<XMCommunicationRecord> GetXMCommunicationRecordList();
    	       
    	/// <summary>
    	/// get to XMCommunicationRecord Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMCommunicationRecord Page List</returns>
    	PagedList<XMCommunicationRecord> SearchXMCommunicationRecord(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMCommunicationRecord by Id
        /// </summary>
        /// <param name="id">XMCommunicationRecord Id</param>
        /// <returns>XMCommunicationRecord</returns>   
        XMCommunicationRecord GetXMCommunicationRecordById(int id);
    
    	/// <summary>
        /// delete XMCommunicationRecord by Id
        /// </summary>
        /// <param name="Id">XMCommunicationRecord Id</param>
        void DeleteXMCommunicationRecord(int id);
    	
    	/// <summary>
        /// Batch delete XMCommunicationRecord by Id
        /// </summary>
        /// <param name="Ids">XMCommunicationRecord Id</param>
        void BatchDeleteXMCommunicationRecord(List<int> ids);

        #endregion
    }
}
