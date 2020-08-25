
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-02-22 09:17:49
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

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial interface IXMFinancialCapitalFlowService
    {
        #region IXMFinancialCapitalFlowService成员
        /// <summary>
        /// Insert into XMFinancialCapitalFlow
        /// </summary>
        /// <param name="xmfinancialcapitalflow">XMFinancialCapitalFlow</param>
        void InsertXMFinancialCapitalFlow(XMFinancialCapitalFlow xmfinancialcapitalflow);

        /// <summary>
        /// Update into XMFinancialCapitalFlow
        /// </summary>
        /// <param name="xmfinancialcapitalflow">XMFinancialCapitalFlow</param>
        void UpdateXMFinancialCapitalFlow(XMFinancialCapitalFlow xmfinancialcapitalflow);

        /// <summary>
        /// get to XMFinancialCapitalFlow list
        /// </summary>
        List<XMFinancialCapitalFlow> GetXMFinancialCapitalFlowList();
        List<XMFinancialCapitalFlow> GetXMFinancialCapitalFlowListByDate(string Begin, string End);

        /// <summary>
        /// 根据主键ID集合获取相应数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<XMFinancialCapitalFlow> GetXMFinancialCapitalFlowListByIDs(string ids);

        List<XMFinancialCapitalFlow> GetXMFinancialCapitalFlowIsNotAuditListByDateTime(string datetime);
        List<XMFinancialCapitalFlow> GetListByData(string Begin, string End,int companyID, int DepartmentID, int ProjectID, int FinancialType, int Audit, string Abstract, int PaymentCollectionType, int ReceivablesType,int BudgetType, string AssociatedPerson);
        List<XMFinancialCapitalFlow> GetListByData(string Begin, string End, int DepartmentID, int ProjectID, int FinancialType, int Audit, string Abstract, int PaymentCollectionType);
        List<XMFinancialCapitalFlow> GetListByDataBudgetType(DateTime Begin, DateTime End, int ProjectID);
        List<XMFinancialCapitalFlow> GetListByBudgetType(DateTime Begin, DateTime End, int DepartmentType, int BudgetType);
        List<XMFinancialCapitalFlow> GetListByDataToTable(string Begin, string End, int DepartmentID, int ProjectID, int BudgetType);

        /// <summary>
        /// 获取广告成本
        /// </summary>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <param name="DepartmentID"></param>
        /// <param name="ProjectID"></param>
        /// <param name="BudgetType"></param>
        /// <returns></returns>
        decimal getAdvertisingCost(string Begin, string End, int DepartmentID, int ProjectID, int BudgetType);
        List<XMFinancialCapitalFlow> GetListByDataToTableB2BCByReceivablesType(string Begin, string End, int DepartmentID, int ReceivablesType);
        List<XMFinancialCapitalFlow> GetListByDataToTableB2BCByBudgetType(string Begin, string End, int DepartmentID, List<int?> BudgetType);
        List<XMFinancialCapitalFlow> GetListByYearMonth(int ProjectID,int companyID, DateTime begin, DateTime end, bool IsBalance);
        List<XMFinancialCapitalFlow> GetListByFinancialFieldList(string Begin, string End, int DepartmentID, int ProjectID, List<int?> FinancialFieldList);

        //月初定时更新资金流水中未审核的记录
        void TimingFinancialCapitalFlowAutoAduit();
        /// <summary>
        /// get to XMFinancialCapitalFlow Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMFinancialCapitalFlow Page List</returns>
        PagedList<XMFinancialCapitalFlow> SearchXMFinancialCapitalFlow(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="id">XMFinancialCapitalFlow ID</param>
        /// <returns>XMFinancialCapitalFlow</returns>   
        XMFinancialCapitalFlow GetXMFinancialCapitalFlowByID(int id);

        /// <summary>
        /// delete XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="ID">XMFinancialCapitalFlow ID</param>
        void DeleteXMFinancialCapitalFlow(int id);

        /// <summary>
        /// Batch delete XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="IDs">XMFinancialCapitalFlow ID</param>
        void BatchDeleteXMFinancialCapitalFlow(List<int> ids);

        string getDepartmentName(int departmentID);

        #endregion
    }
}
