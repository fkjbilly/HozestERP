
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-08-01 14:09:31
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
using System.Linq.Expressions;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMLogisticsFeeDetailService
    {
        #region IXMLogisticsFeeDetailService成员
        /// <summary>
        /// Insert into XMLogisticsFeeDetail
        /// </summary>
        /// <param name="xmlogisticsfeedetail">XMLogisticsFeeDetail</param>
    	void InsertXMLogisticsFeeDetail(XMLogisticsFeeDetail xmlogisticsfeedetail);
    	
        /// <summary>
        /// Update into XMLogisticsFeeDetail
        /// </summary>
        /// <param name="xmlogisticsfeedetail">XMLogisticsFeeDetail</param>
        void UpdateXMLogisticsFeeDetail(XMLogisticsFeeDetail xmlogisticsfeedetail);	
    	
        /// <summary>
        /// get to XMLogisticsFeeDetail list
        /// </summary>
        IQueryable<XMLogisticsFeeDetail> GetXMLogisticsFeeDetailList(int OrderID);
    	       
    	/// <summary>
    	/// get to XMLogisticsFeeDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMLogisticsFeeDetail Page List</returns>
    	PagedList<XMLogisticsFeeDetail> SearchXMLogisticsFeeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMLogisticsFeeDetail by ID
        /// </summary>
        /// <param name="id">XMLogisticsFeeDetail ID</param>
        /// <returns>XMLogisticsFeeDetail</returns>   
        XMLogisticsFeeDetail GetXMLogisticsFeeDetailByID(int id);
    
    	/// <summary>
        /// delete XMLogisticsFeeDetail by ID
        /// </summary>
        /// <param name="ID">XMLogisticsFeeDetail ID</param>
        void DeleteXMLogisticsFeeDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMLogisticsFeeDetail by ID
        /// </summary>
        /// <param name="IDs">XMLogisticsFeeDetail ID</param>
        void BatchDeleteXMLogisticsFeeDetail(List<int> ids);

        List<XMLogisticsFeeDetail> getList(Expression<Func<XMLogisticsFeeDetail, bool>> predicate);

        void delete(XMLogisticsFeeDetail entity);

        decimal getLogisticsFeeTotal(int orderID);
        #endregion

    }
}
