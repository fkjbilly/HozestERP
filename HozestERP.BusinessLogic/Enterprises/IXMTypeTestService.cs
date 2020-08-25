
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-08-01 17:21:53
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

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial interface IXMTypeTestService
    {
        #region IXMTypeTestService成员
        /// <summary>
        /// Insert into XMTypeTest
        /// </summary>
        /// <param name="xmtypetest">XMTypeTest</param>
    	void InsertXMTypeTest(XMTypeTest xmtypetest);
    	
        /// <summary>
        /// Update into XMTypeTest
        /// </summary>
        /// <param name="xmtypetest">XMTypeTest</param>
        void UpdateXMTypeTest(XMTypeTest xmtypetest);	
    	
        /// <summary>
        /// get to XMTypeTest list
        /// </summary>
        List<XMTypeTest> GetXMTypeTestList();
        //List<XMTypeTest> GetXMTypeTestListByParam(string type);
    	       
    	/// <summary>
    	/// get to XMTypeTest Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMTypeTest Page List</returns>
    	PagedList<XMTypeTest> SearchXMTypeTest(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMTypeTest by ID
        /// </summary>
        /// <param name="id">XMTypeTest ID</param>
        /// <returns>XMTypeTest</returns>   
        XMTypeTest GetXMTypeTestByID(int id);
    
    	/// <summary>
        /// delete XMTypeTest by ID
        /// </summary>
        /// <param name="ID">XMTypeTest ID</param>
        void DeleteXMTypeTest(int id);
    	
    	/// <summary>
        /// Batch delete XMTypeTest by ID
        /// </summary>
        /// <param name="IDs">XMTypeTest ID</param>
        void BatchDeleteXMTypeTest(List<int> ids);

        #endregion
    }
}
