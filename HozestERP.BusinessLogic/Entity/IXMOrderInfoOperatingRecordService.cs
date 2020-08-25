
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
    public partial interface IXMOrderInfoOperatingRecordService
    {
        #region IXMOrderInfoOperatingRecordService成员
        /// <summary>
        /// Insert into XMOrderInfoOperatingRecord
        /// </summary>
        /// <param name="xmorderinfooperatingrecord">XMOrderInfoOperatingRecord</param>
    	void InsertXMOrderInfoOperatingRecord(XMOrderInfoOperatingRecord xmorderinfooperatingrecord);
    	
        /// <summary>
        /// Update into XMOrderInfoOperatingRecord
        /// </summary>
        /// <param name="xmorderinfooperatingrecord">XMOrderInfoOperatingRecord</param>
        void UpdateXMOrderInfoOperatingRecord(XMOrderInfoOperatingRecord xmorderinfooperatingrecord);	
    	
        /// <summary>
        /// get to XMOrderInfoOperatingRecord list
        /// </summary>
        List<XMOrderInfoOperatingRecord> GetXMOrderInfoOperatingRecordList();
    	       
    	/// <summary>
    	/// get to XMOrderInfoOperatingRecord Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMOrderInfoOperatingRecord Page List</returns>
    	PagedList<XMOrderInfoOperatingRecord> SearchXMOrderInfoOperatingRecord(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMOrderInfoOperatingRecord by Id
        /// </summary>
        /// <param name="id">XMOrderInfoOperatingRecord Id</param>
        /// <returns>XMOrderInfoOperatingRecord</returns>   
        XMOrderInfoOperatingRecord GetXMOrderInfoOperatingRecordById(int id);
    
    	/// <summary>
        /// delete XMOrderInfoOperatingRecord by Id
        /// </summary>
        /// <param name="Id">XMOrderInfoOperatingRecord Id</param>
        void DeleteXMOrderInfoOperatingRecord(int id);
    	
    	/// <summary>
        /// Batch delete XMOrderInfoOperatingRecord by Id
        /// </summary>
        /// <param name="Ids">XMOrderInfoOperatingRecord Id</param>
        void BatchDeleteXMOrderInfoOperatingRecord(List<int> ids);

        #endregion
    }
}
