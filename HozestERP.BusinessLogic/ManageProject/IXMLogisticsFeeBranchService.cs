
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
    public partial interface IXMLogisticsFeeBranchService
    {
        #region IXMLogisticsFeeBranchService成员
        /// <summary>
        /// Insert into XMLogisticsFeeBranch
        /// </summary>
        /// <param name="xmlogisticsfeebranch">XMLogisticsFeeBranch</param>
    	void InsertXMLogisticsFeeBranch(XMLogisticsFeeBranch xmlogisticsfeebranch);
    	
        /// <summary>
        /// Update into XMLogisticsFeeBranch
        /// </summary>
        /// <param name="xmlogisticsfeebranch">XMLogisticsFeeBranch</param>
        void UpdateXMLogisticsFeeBranch(XMLogisticsFeeBranch xmlogisticsfeebranch);	
    	
        /// <summary>
        /// get to XMLogisticsFeeBranch list
        /// </summary>
        IQueryable<XMLogisticsFeeBranchNew> GetXMLogisticsFeeBranchList();
    	       
    	/// <summary>
    	/// get to XMLogisticsFeeBranch Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMLogisticsFeeBranch Page List</returns>
    	PagedList<XMLogisticsFeeBranch> SearchXMLogisticsFeeBranch(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMLogisticsFeeBranch by ID
        /// </summary>
        /// <param name="id">XMLogisticsFeeBranch ID</param>
        /// <returns>XMLogisticsFeeBranch</returns>   
        XMLogisticsFeeBranch GetXMLogisticsFeeBranchByID(int id);
    
    	/// <summary>
        /// delete XMLogisticsFeeBranch by ID
        /// </summary>
        /// <param name="ID">XMLogisticsFeeBranch ID</param>
        void DeleteXMLogisticsFeeBranch(int id,bool flag);
    	
    	/// <summary>
        /// Batch delete XMLogisticsFeeBranch by ID
        /// </summary>
        /// <param name="IDs">XMLogisticsFeeBranch ID</param>
        void BatchDeleteXMLogisticsFeeBranch(List<int> ids);

        XMLogisticsFeeBranch getSingle(Expression<Func<XMLogisticsFeeBranch, bool>> predicate);

        void SaveChanges();

        #endregion

    }
}
