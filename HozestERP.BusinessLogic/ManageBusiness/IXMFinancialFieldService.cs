
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-02-29 09:08:36
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

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial interface IXMFinancialFieldService
    {
        #region IXMFinancialFieldService成员
        /// <summary>
        /// Insert into XMFinancialField
        /// </summary>
        /// <param name="xmfinancialfield">XMFinancialField</param>
        void InsertXMFinancialField(XMFinancialField xmfinancialfield);

        /// <summary>
        /// Update into XMFinancialField
        /// </summary>
        /// <param name="xmfinancialfield">XMFinancialField</param>
        void UpdateXMFinancialField(XMFinancialField xmfinancialfield);

        /// <summary>
        /// get to XMFinancialField list
        /// </summary>
        List<XMFinancialField> GetXMFinancialFieldList();
        /// <summary>
        /// 删除字段
        /// </summary>
        /// <param name="id"></param>
        void MarkFieldAsDeleted(int id);

        /// <summary>
        /// get to XMFinancialField Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMFinancialField Page List</returns>
        PagedList<XMFinancialField> SearchXMFinancialField(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        //根据父节点ID查询列表
        List<XMFinancialField> GetXMFinancialFieldByParentID(int parentID);
        /// <summary>
        /// 获取综管部预算字段集合
        /// </summary>
        /// <returns></returns>
        List<XMFinancialField> GetXMManagerFinancialFileldList();
        /// <summary>
        /// 根据父节点ID 查询综管部子节点
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<XMFinancialField> GetXMMangerFinancialFieldListByParentID(int parentId);

        List<XMFinancialField> GetBudgetSettingListByData(string Name);

        XMFinancialField GetBudgetSettingByID(int id);

        /// <summary>
        /// get a XMFinancialField by Id
        /// </summary>
        /// <param name="id">XMFinancialField Id</param>
        /// <returns>XMFinancialField</returns>   
        XMFinancialField GetXMFinancialFieldById(int id);

        /// <summary>
        /// delete XMFinancialField by Id
        /// </summary>
        /// <param name="Id">XMFinancialField Id</param>
        void DeleteXMFinancialField(int id);

        /// <summary>
        /// Batch delete XMFinancialField by Id
        /// </summary>
        /// <param name="Ids">XMFinancialField Id</param>
        void BatchDeleteXMFinancialField(List<int> ids);

        #endregion
    }
}
