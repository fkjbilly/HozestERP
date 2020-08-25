
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
    public partial interface ICodeTypeService
    {
        #region ICodeTypeService成员
        /// <summary>
        /// Insert into CodeType
        /// </summary>
        /// <param name="codetype">CodeType</param>
    	void InsertCodeType(CodeType codetype);
    	
        /// <summary>
        /// Update into CodeType
        /// </summary>
        /// <param name="codetype">CodeType</param>
        void UpdateCodeType(CodeType codetype);	
    	
        /// <summary>
        /// get to CodeType list
        /// </summary>
        List<CodeType> GetCodeTypeList();
    	       
    	/// <summary>
    	/// get to CodeType Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CodeType Page List</returns>
    	PagedList<CodeType> SearchCodeType(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CodeType by CodeTypeID
        /// </summary>
        /// <param name="codetypeid">CodeType CodeTypeID</param>
        /// <returns>CodeType</returns>   
        CodeType GetCodeTypeByCodeTypeID(int codetypeid);
    
    	/// <summary>
        /// delete CodeType by CodeTypeID
        /// </summary>
        /// <param name="CodeTypeID">CodeType CodeTypeID</param>
        void DeleteCodeType(int codetypeid);
    	
    	/// <summary>
        /// Batch delete CodeType by CodeTypeID
        /// </summary>
        /// <param name="CodeTypeIDs">CodeType CodeTypeID</param>
        void BatchDeleteCodeType(List<int> codetypeids);

        #endregion
    }
}
