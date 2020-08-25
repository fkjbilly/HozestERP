
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
    public partial interface IXMGiftStorageRecordService
    {
        #region IXMGiftStorageRecordService成员
        /// <summary>
        /// Insert into XMGiftStorageRecord
        /// </summary>
        /// <param name="xmgiftstoragerecord">XMGiftStorageRecord</param>
    	void InsertXMGiftStorageRecord(XMGiftStorageRecord xmgiftstoragerecord);
    	
        /// <summary>
        /// Update into XMGiftStorageRecord
        /// </summary>
        /// <param name="xmgiftstoragerecord">XMGiftStorageRecord</param>
        void UpdateXMGiftStorageRecord(XMGiftStorageRecord xmgiftstoragerecord);	
    	
        /// <summary>
        /// get to XMGiftStorageRecord list
        /// </summary>
        List<XMGiftStorageRecord> GetXMGiftStorageRecordList();
    	       
    	/// <summary>
    	/// get to XMGiftStorageRecord Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMGiftStorageRecord Page List</returns>
    	PagedList<XMGiftStorageRecord> SearchXMGiftStorageRecord(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMGiftStorageRecord by Id
        /// </summary>
        /// <param name="id">XMGiftStorageRecord Id</param>
        /// <returns>XMGiftStorageRecord</returns>   
        XMGiftStorageRecord GetXMGiftStorageRecordById(int id);
    
    	/// <summary>
        /// delete XMGiftStorageRecord by Id
        /// </summary>
        /// <param name="Id">XMGiftStorageRecord Id</param>
        void DeleteXMGiftStorageRecord(int id);
    	
    	/// <summary>
        /// Batch delete XMGiftStorageRecord by Id
        /// </summary>
        /// <param name="Ids">XMGiftStorageRecord Id</param>
        void BatchDeleteXMGiftStorageRecord(List<int> ids);

        #endregion
    }
}
