
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
    public partial interface ICodeListService
    {
        #region ICodeListService成员
        /// <summary>
        /// Insert into CodeList
        /// </summary>
        /// <param name="codelist">CodeList</param>
    	void InsertCodeList(CodeList codelist);
    	
        /// <summary>
        /// Update into CodeList
        /// </summary>
        /// <param name="codelist">CodeList</param>
        void UpdateCodeList(CodeList codelist);	
    	
        /// <summary>
        /// get to CodeList list
        /// </summary>
        List<CodeList> GetCodeListList();
    	       
    	/// <summary>
    	/// get to CodeList Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CodeList Page List</returns>
    	PagedList<CodeList> SearchCodeList(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CodeList by CodeID
        /// </summary>
        /// <param name="codeid">CodeList CodeID</param>
        /// <returns>CodeList</returns>   
        CodeList GetCodeListByCodeID(int codeid);
    
    	/// <summary>
        /// delete CodeList by CodeID
        /// </summary>
        /// <param name="CodeID">CodeList CodeID</param>
        void DeleteCodeList(int codeid);
    	
    	/// <summary>
        /// Batch delete CodeList by CodeID
        /// </summary>
        /// <param name="CodeIDs">CodeList CodeID</param>
        void BatchDeleteCodeList(List<int> codeids);

        #endregion
    }
}
