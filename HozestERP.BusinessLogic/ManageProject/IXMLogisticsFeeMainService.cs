
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-07-27 15:27:38
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
    public partial interface IXMLogisticsFeeMainService
    {
        #region IXMLogisticsFeeMainService成员
        /// <summary>
        /// Insert into XMLogisticsFeeMain
        /// </summary>
        /// <param name="xmlogisticsfeemain">XMLogisticsFeeMain</param>
    	void InsertXMLogisticsFeeMain(XMLogisticsFeeMain xmlogisticsfeemain,bool flag);
    	
        /// <summary>
        /// Update into XMLogisticsFeeMain
        /// </summary>
        /// <param name="xmlogisticsfeemain">XMLogisticsFeeMain</param>
        void UpdateXMLogisticsFeeMain(XMLogisticsFeeMain xmlogisticsfeemain);	
    	
        /// <summary>
        /// get to XMLogisticsFeeMain list
        /// </summary>
        IQueryable<XMLogisticsFeeMainNew> GetXMLogisticsFeeMainList();
    	       
    	/// <summary>
    	/// get to XMLogisticsFeeMain Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMLogisticsFeeMain Page List</returns>
    	PagedList<XMLogisticsFeeMain> SearchXMLogisticsFeeMain(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMLogisticsFeeMain by ID
        /// </summary>
        /// <param name="id">XMLogisticsFeeMain ID</param>
        /// <returns>XMLogisticsFeeMain</returns>   
        XMLogisticsFeeMain GetXMLogisticsFeeMainByID(int id);
    
    	/// <summary>
        /// delete XMLogisticsFeeMain by ID
        /// </summary>
        /// <param name="ID">XMLogisticsFeeMain ID</param>
        void DeleteXMLogisticsFeeMain(int id,bool flag);
    	
    	/// <summary>
        /// Batch delete XMLogisticsFeeMain by ID
        /// </summary>
        /// <param name="IDs">XMLogisticsFeeMain ID</param>
        void BatchDeleteXMLogisticsFeeMain(List<int> ids);

        XMLogisticsFeeMain getSingle(Expression<Func<XMLogisticsFeeMain, bool>> predicate);

        void saveChanges();

        #endregion

    }
}
