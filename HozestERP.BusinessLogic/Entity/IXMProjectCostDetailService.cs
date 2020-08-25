
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
    public partial interface IXMProjectCostDetailService
    {
        #region IXMProjectCostDetailService成员
        /// <summary>
        /// Insert into XMProjectCostDetail
        /// </summary>
        /// <param name="xmprojectcostdetail">XMProjectCostDetail</param>
    	void InsertXMProjectCostDetail(XMProjectCostDetail xmprojectcostdetail);
    	
        /// <summary>
        /// Update into XMProjectCostDetail
        /// </summary>
        /// <param name="xmprojectcostdetail">XMProjectCostDetail</param>
        void UpdateXMProjectCostDetail(XMProjectCostDetail xmprojectcostdetail);	
    	
        /// <summary>
        /// get to XMProjectCostDetail list
        /// </summary>
        List<XMProjectCostDetail> GetXMProjectCostDetailList();
    	       
    	/// <summary>
    	/// get to XMProjectCostDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMProjectCostDetail Page List</returns>
    	PagedList<XMProjectCostDetail> SearchXMProjectCostDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMProjectCostDetail by Id
        /// </summary>
        /// <param name="id">XMProjectCostDetail Id</param>
        /// <returns>XMProjectCostDetail</returns>   
        XMProjectCostDetail GetXMProjectCostDetailById(int id);
    
    	/// <summary>
        /// delete XMProjectCostDetail by Id
        /// </summary>
        /// <param name="Id">XMProjectCostDetail Id</param>
        void DeleteXMProjectCostDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMProjectCostDetail by Id
        /// </summary>
        /// <param name="Ids">XMProjectCostDetail Id</param>
        void BatchDeleteXMProjectCostDetail(List<int> ids);

        #endregion
    }
}
