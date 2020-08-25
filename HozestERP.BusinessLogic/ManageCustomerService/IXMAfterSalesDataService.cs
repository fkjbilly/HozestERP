
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-07-01 15:43:26
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
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial interface IXMAfterSalesDataService
    {
        #region IXMAfterSalesDataService成员
        /// <summary>
        /// Insert into XMAfterSalesData
        /// </summary>
        /// <param name="xmaftersalesdata">XMAfterSalesData</param>
    	void InsertXMAfterSalesData(XMAfterSalesData xmaftersalesdata);
    	
        /// <summary>
        /// Update into XMAfterSalesData
        /// </summary>
        /// <param name="xmaftersalesdata">XMAfterSalesData</param>
        void UpdateXMAfterSalesData(XMAfterSalesData xmaftersalesdata);	
    	
        /// <summary>
        /// get to XMAfterSalesData list
        /// </summary>
        List<XMAfterSalesData> GetXMAfterSalesDataList();
        //List<QuestionDetailed_Result> GetXMAfterSalesDataByDemandReturn(DateTime begin, DateTime end, int CustomerID, string ReturnID);
        List<QuestionDetailed_Result> GetXMAfterSalesDataByPersonalWorkload(DateTime begin, DateTime end, int CustomerID);

        XMAfterSalesData GetXMAfterSalesDataInfoByMonth(string date, int CustomerID);
        List<XMAfterSalesData> GetXMAfterSalesDataListByMonth(string date);

    	/// <summary>
    	/// get to XMAfterSalesData Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMAfterSalesData Page List</returns>
    	PagedList<XMAfterSalesData> SearchXMAfterSalesData(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMAfterSalesData by ID
        /// </summary>
        /// <param name="id">XMAfterSalesData ID</param>
        /// <returns>XMAfterSalesData</returns>   
        XMAfterSalesData GetXMAfterSalesDataByID(int id);
    
    	/// <summary>
        /// delete XMAfterSalesData by ID
        /// </summary>
        /// <param name="ID">XMAfterSalesData ID</param>
        void DeleteXMAfterSalesData(int id);
    	
    	/// <summary>
        /// Batch delete XMAfterSalesData by ID
        /// </summary>
        /// <param name="IDs">XMAfterSalesData ID</param>
        void BatchDeleteXMAfterSalesData(List<int> ids);

        #endregion
    }
}
