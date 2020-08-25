
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
    public partial interface IXMOtherCostDetailService
    {
        #region IXMOtherCostDetailService成员
        /// <summary>
        /// Insert into XMOtherCostDetail
        /// </summary>
        /// <param name="xmothercostdetail">XMOtherCostDetail</param>
    	void InsertXMOtherCostDetail(XMOtherCostDetail xmothercostdetail);
    	
        /// <summary>
        /// Update into XMOtherCostDetail
        /// </summary>
        /// <param name="xmothercostdetail">XMOtherCostDetail</param>
        void UpdateXMOtherCostDetail(XMOtherCostDetail xmothercostdetail);	
    	
        /// <summary>
        /// get to XMOtherCostDetail list
        /// </summary>
        List<XMOtherCostDetail> GetXMOtherCostDetailList();
    	       
    	/// <summary>
    	/// get to XMOtherCostDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMOtherCostDetail Page List</returns>
    	PagedList<XMOtherCostDetail> SearchXMOtherCostDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMOtherCostDetail by Id
        /// </summary>
        /// <param name="id">XMOtherCostDetail Id</param>
        /// <returns>XMOtherCostDetail</returns>   
        XMOtherCostDetail GetXMOtherCostDetailById(int id);
    
    	/// <summary>
        /// delete XMOtherCostDetail by Id
        /// </summary>
        /// <param name="Id">XMOtherCostDetail Id</param>
        void DeleteXMOtherCostDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMOtherCostDetail by Id
        /// </summary>
        /// <param name="Ids">XMOtherCostDetail Id</param>
        void BatchDeleteXMOtherCostDetail(List<int> ids);

        #endregion
    }
}
