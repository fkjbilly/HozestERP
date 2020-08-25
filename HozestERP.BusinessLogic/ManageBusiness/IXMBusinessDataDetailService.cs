
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-12-08 13:14:11
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

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial interface IXMBusinessDataDetailService
    {
        #region IXMBusinessDataDetailService成员
        /// <summary>
        /// Insert into XMBusinessDataDetail
        /// </summary>
        /// <param name="xmbusinessdatadetail">XMBusinessDataDetail</param>
    	void InsertXMBusinessDataDetail(XMBusinessDataDetail xmbusinessdatadetail);
    	
        /// <summary>
        /// Update into XMBusinessDataDetail
        /// </summary>
        /// <param name="xmbusinessdatadetail">XMBusinessDataDetail</param>
        void UpdateXMBusinessDataDetail(XMBusinessDataDetail xmbusinessdatadetail);	
    	
        /// <summary>
        /// get to XMBusinessDataDetail list
        /// </summary>
        List<XMBusinessDataDetail> GetXMBusinessDataDetailList();
    	List<XMBusinessDataDetail> GetXMBusinessDataDetailListByBusinessDataID(int BusinessDataID);
        List<XMBusinessDataDetail> GetXMBusinessDataDetailListByBusinessDataIDReceivables(int BusinessDataID);
        List<XMBusinessDataAll> GetXMBusinessDataDetailListByDepID(int DepID, DateTime Begin, DateTime End);
        bool GetSpendingAuthority(int CustomerRoleID);

    	/// <summary>
    	/// get to XMBusinessDataDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMBusinessDataDetail Page List</returns>
    	PagedList<XMBusinessDataDetail> SearchXMBusinessDataDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMBusinessDataDetail by ID
        /// </summary>
        /// <param name="id">XMBusinessDataDetail ID</param>
        /// <returns>XMBusinessDataDetail</returns>   
        XMBusinessDataDetail GetXMBusinessDataDetailByID(int id);
    
    	/// <summary>
        /// delete XMBusinessDataDetail by ID
        /// </summary>
        /// <param name="ID">XMBusinessDataDetail ID</param>
        void DeleteXMBusinessDataDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMBusinessDataDetail by ID
        /// </summary>
        /// <param name="IDs">XMBusinessDataDetail ID</param>
        void BatchDeleteXMBusinessDataDetail(List<int> ids);

        #endregion
    }
}
