
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-05-27 09:22:35
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

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial interface IXMCustomerServiceLevelService
    {
        #region IXMCustomerServiceLevelService成员
        /// <summary>
        /// Insert into XMCustomerServiceLevel
        /// </summary>
        /// <param name="xmcustomerservicelevel">XMCustomerServiceLevel</param>
    	void InsertXMCustomerServiceLevel(XMCustomerServiceLevel xmcustomerservicelevel);
    	
        /// <summary>
        /// Update into XMCustomerServiceLevel
        /// </summary>
        /// <param name="xmcustomerservicelevel">XMCustomerServiceLevel</param>
        void UpdateXMCustomerServiceLevel(XMCustomerServiceLevel xmcustomerservicelevel);	
    	
        /// <summary>
        /// get to XMCustomerServiceLevel list
        /// </summary>
        List<XMCustomerServiceLevel> GetXMCustomerServiceLevelList(string rank_name);

        List<Enterprises.Department> GetXMCoustomerServiceGroupList(string DepCode);
    	       
    	/// <summary>
    	/// get to XMCustomerServiceLevel Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMCustomerServiceLevel Page List</returns>
    	PagedList<XMCustomerServiceLevel> SearchXMCustomerServiceLevel(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMCustomerServiceLevel by Id
        /// </summary>
        /// <param name="id">XMCustomerServiceLevel Id</param>
        /// <returns>XMCustomerServiceLevel</returns>   
        XMCustomerServiceLevel GetXMCustomerServiceLevelById(int id);
    
    	/// <summary>
        /// delete XMCustomerServiceLevel by Id
        /// </summary>
        /// <param name="Id">XMCustomerServiceLevel Id</param>
        void DeleteXMCustomerServiceLevel(int id);
    	
    	/// <summary>
        /// Batch delete XMCustomerServiceLevel by Id
        /// </summary>
        /// <param name="Ids">XMCustomerServiceLevel Id</param>
        void BatchDeleteXMCustomerServiceLevel(List<int> ids);

        #endregion
    }
}