
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMCombinationService
    {
        #region IXMCombinationService成员
        /// <summary>
        /// Insert into XMCombination
        /// </summary>
        /// <param name="xmcombination">XMCombination</param>
        void InsertXMCombination(XMCombination xmcombination);

        /// <summary>
        /// Update into XMCombination
        /// </summary>
        /// <param name="xmcombination">XMCombination</param>
        void UpdateXMCombination(XMCombination xmcombination);

        /// <summary>
        /// get to XMCombination list
        /// </summary>
        List<XMCombination> GetXMCombinationList(int NIckID, string ProductName, string ManufacturersCode, string PlatformMerchantCode);

        List<XMCombination> GetXMCombinationByManufacturersCode(string ManufacturersCode);

        XMCombination GetXMProductProductId(int ProductId, string PlatformTypeId, int? OrderID);
        /// <summary>
        /// get to XMCombination Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMCombination Page List</returns>
        PagedList<XMCombination> SearchXMCombination(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMCombination by ID
        /// </summary>
        /// <param name="id">XMCombination ID</param>
        /// <returns>XMCombination</returns>   
        XMCombination GetXMCombinationByID(int id);

        /// <summary>
        /// delete XMCombination by ID
        /// </summary>
        /// <param name="ID">XMCombination ID</param>
        void DeleteXMCombination(int id);

        /// <summary>
        /// Batch delete XMCombination by ID
        /// </summary>
        /// <param name="IDs">XMCombination ID</param>
        void BatchDeleteXMCombination(List<int> ids);

        #endregion
    }
}
