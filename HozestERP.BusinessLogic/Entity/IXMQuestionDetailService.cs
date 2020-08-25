
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
    public partial interface IXMQuestionDetailService
    {
        #region IXMQuestionDetailService成员
        /// <summary>
        /// Insert into XMQuestionDetail
        /// </summary>
        /// <param name="xmquestiondetail">XMQuestionDetail</param>
    	void InsertXMQuestionDetail(XMQuestionDetail xmquestiondetail);
    	
        /// <summary>
        /// Update into XMQuestionDetail
        /// </summary>
        /// <param name="xmquestiondetail">XMQuestionDetail</param>
        void UpdateXMQuestionDetail(XMQuestionDetail xmquestiondetail);	
    	
        /// <summary>
        /// get to XMQuestionDetail list
        /// </summary>
        List<XMQuestionDetail> GetXMQuestionDetailList();
    	       
    	/// <summary>
    	/// get to XMQuestionDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMQuestionDetail Page List</returns>
    	PagedList<XMQuestionDetail> SearchXMQuestionDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMQuestionDetail by ID
        /// </summary>
        /// <param name="id">XMQuestionDetail ID</param>
        /// <returns>XMQuestionDetail</returns>   
        XMQuestionDetail GetXMQuestionDetailByID(int id);
    
    	/// <summary>
        /// delete XMQuestionDetail by ID
        /// </summary>
        /// <param name="ID">XMQuestionDetail ID</param>
        void DeleteXMQuestionDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMQuestionDetail by ID
        /// </summary>
        /// <param name="IDs">XMQuestionDetail ID</param>
        void BatchDeleteXMQuestionDetail(List<int> ids);

        #endregion
    }
}
