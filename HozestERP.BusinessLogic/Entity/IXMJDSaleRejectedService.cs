
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
    public partial interface IXMJDSaleRejectedService
    {
        #region IXMJDSaleRejectedService成员
        /// <summary>
        /// Insert into XMJDSaleRejected
        /// </summary>
        /// <param name="xmjdsalerejected">XMJDSaleRejected</param>
    	void InsertXMJDSaleRejected(XMJDSaleRejected xmjdsalerejected);
    	
        /// <summary>
        /// Update into XMJDSaleRejected
        /// </summary>
        /// <param name="xmjdsalerejected">XMJDSaleRejected</param>
        void UpdateXMJDSaleRejected(XMJDSaleRejected xmjdsalerejected);	
    	
        /// <summary>
        /// get to XMJDSaleRejected list
        /// </summary>
        List<XMJDSaleRejected> GetXMJDSaleRejectedList();
    	       
    	/// <summary>
    	/// get to XMJDSaleRejected Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMJDSaleRejected Page List</returns>
    	PagedList<XMJDSaleRejected> SearchXMJDSaleRejected(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMJDSaleRejected by Id
        /// </summary>
        /// <param name="id">XMJDSaleRejected Id</param>
        /// <returns>XMJDSaleRejected</returns>   
        XMJDSaleRejected GetXMJDSaleRejectedById(int id);
    
    	/// <summary>
        /// delete XMJDSaleRejected by Id
        /// </summary>
        /// <param name="Id">XMJDSaleRejected Id</param>
        void DeleteXMJDSaleRejected(int id);
    	
    	/// <summary>
        /// Batch delete XMJDSaleRejected by Id
        /// </summary>
        /// <param name="Ids">XMJDSaleRejected Id</param>
        void BatchDeleteXMJDSaleRejected(List<int> ids);

        #endregion
    }
}
