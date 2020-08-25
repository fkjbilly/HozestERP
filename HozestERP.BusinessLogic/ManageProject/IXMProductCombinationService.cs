
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-06-10 16:42:25
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMProductCombinationService
    {
        #region IXMProductCombinationService成员
        /// <summary>
        /// Insert into XMProductCombination
        /// </summary>
        /// <param name="xmproductcombination">XMProductCombination</param>
    	void InsertXMProductCombination(XMProductCombination xmproductcombination);
    	
        /// <summary>
        /// Update into XMProductCombination
        /// </summary>
        /// <param name="xmproductcombination">XMProductCombination</param>
        void UpdateXMProductCombination(XMProductCombination xmproductcombination);	
    	
        /// <summary>
        /// get to XMProductCombination list
        /// </summary>
        List<XMProductCombination> GetXMProductCombinationList();

        List<XMProductCombination> GetXMProductCombinationByCombinationID(int CombinationID);

    	/// <summary>
    	/// get to XMProductCombination Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMProductCombination Page List</returns>
    	PagedList<XMProductCombination> SearchXMProductCombination(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMProductCombination by ID
        /// </summary>
        /// <param name="id">XMProductCombination ID</param>
        /// <returns>XMProductCombination</returns>   
        XMProductCombination GetXMProductCombinationByID(int id);
        XMProductCombination GetXMProductCombinationByIDCom(int CombinationID, int ProductID);
    	/// <summary>
        /// delete XMProductCombination by ID
        /// </summary>
        /// <param name="ID">XMProductCombination ID</param>
        void DeleteXMProductCombination(int id);
    	
    	/// <summary>
        /// Batch delete XMProductCombination by ID
        /// </summary>
        /// <param name="IDs">XMProductCombination ID</param>
        void BatchDeleteXMProductCombination(List<int> ids);

        #endregion
    }
}
