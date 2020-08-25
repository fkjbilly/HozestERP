
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
    public partial interface IXMQuestionService
    {
        #region IXMQuestionService成员
        /// <summary>
        /// Insert into XMQuestion
        /// </summary>
        /// <param name="xmquestion">XMQuestion</param>
    	void InsertXMQuestion(XMQuestion xmquestion);
    	
        /// <summary>
        /// Update into XMQuestion
        /// </summary>
        /// <param name="xmquestion">XMQuestion</param>
        void UpdateXMQuestion(XMQuestion xmquestion);	
    	
        /// <summary>
        /// get to XMQuestion list
        /// </summary>
        List<XMQuestion> GetXMQuestionList();
    	       
    	/// <summary>
    	/// get to XMQuestion Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMQuestion Page List</returns>
    	PagedList<XMQuestion> SearchXMQuestion(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMQuestion by ID
        /// </summary>
        /// <param name="id">XMQuestion ID</param>
        /// <returns>XMQuestion</returns>   
        XMQuestion GetXMQuestionByID(int id);
    
    	/// <summary>
        /// delete XMQuestion by ID
        /// </summary>
        /// <param name="ID">XMQuestion ID</param>
        void DeleteXMQuestion(int id);
    	
    	/// <summary>
        /// Batch delete XMQuestion by ID
        /// </summary>
        /// <param name="IDs">XMQuestion ID</param>
        void BatchDeleteXMQuestion(List<int> ids);

        #endregion
    }
}
