
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
    public partial interface IXMAdvertisingFeeService
    {
        #region IXMAdvertisingFeeService成员
        /// <summary>
        /// Insert into XMAdvertisingFee
        /// </summary>
        /// <param name="xmadvertisingfee">XMAdvertisingFee</param>
    	void InsertXMAdvertisingFee(XMAdvertisingFee xmadvertisingfee);
    	
        /// <summary>
        /// Update into XMAdvertisingFee
        /// </summary>
        /// <param name="xmadvertisingfee">XMAdvertisingFee</param>
        void UpdateXMAdvertisingFee(XMAdvertisingFee xmadvertisingfee);	
    	
        /// <summary>
        /// get to XMAdvertisingFee list
        /// </summary>
        List<XMAdvertisingFee> GetXMAdvertisingFeeList();
    	       
    	/// <summary>
    	/// get to XMAdvertisingFee Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMAdvertisingFee Page List</returns>
    	PagedList<XMAdvertisingFee> SearchXMAdvertisingFee(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMAdvertisingFee by Id
        /// </summary>
        /// <param name="id">XMAdvertisingFee Id</param>
        /// <returns>XMAdvertisingFee</returns>   
        XMAdvertisingFee GetXMAdvertisingFeeById(int id);
    
    	/// <summary>
        /// delete XMAdvertisingFee by Id
        /// </summary>
        /// <param name="Id">XMAdvertisingFee Id</param>
        void DeleteXMAdvertisingFee(int id);
    	
    	/// <summary>
        /// Batch delete XMAdvertisingFee by Id
        /// </summary>
        /// <param name="Ids">XMAdvertisingFee Id</param>
        void BatchDeleteXMAdvertisingFee(List<int> ids);

        #endregion
    }
}
