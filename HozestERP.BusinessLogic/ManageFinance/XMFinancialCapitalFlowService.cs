
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-02-22 09:17:51
** 修改人:
** 修改日期:
** 描 述: 接口实现类
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
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class XMFinancialCapitalFlowService : IXMFinancialCapitalFlowService
    {
        #region Fields
        /// <summary>
        /// Object context
        /// </summary>
        private readonly HozestERPObjectContext _context;
        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public XMFinancialCapitalFlowService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMFinancialCapitalFlowService成员
        /// <summary>
        /// Insert into XMFinancialCapitalFlow
        /// </summary>
        /// <param name="xmfinancialcapitalflow">XMFinancialCapitalFlow</param>
        public void InsertXMFinancialCapitalFlow(XMFinancialCapitalFlow xmfinancialcapitalflow)
        {
            if (xmfinancialcapitalflow == null)
                return;

            if (!this._context.IsAttached(xmfinancialcapitalflow))

                this._context.XMFinancialCapitalFlows.AddObject(xmfinancialcapitalflow);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMFinancialCapitalFlow
        /// </summary>
        /// <param name="xmfinancialcapitalflow">XMFinancialCapitalFlow</param>
        public void UpdateXMFinancialCapitalFlow(XMFinancialCapitalFlow xmfinancialcapitalflow)
        {
            if (xmfinancialcapitalflow == null)
                return;

            if (this._context.IsAttached(xmfinancialcapitalflow))
                this._context.XMFinancialCapitalFlows.Attach(xmfinancialcapitalflow);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMFinancialCapitalFlow list
        /// </summary>
        public List<XMFinancialCapitalFlow> GetXMFinancialCapitalFlowList()
        {
            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        select p;
            return query.ToList();
        }

        public List<XMFinancialCapitalFlow> GetXMFinancialCapitalFlowListByDate(string Begin, string End)
        {
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!string.IsNullOrEmpty(Begin))
            {
                begin = DateTime.Parse(Begin);
            }

            if (!string.IsNullOrEmpty(End))
            {
                end = DateTime.Parse(End);
            }

            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && (Begin == "" || p.Date >= begin)
                        && (End == "" || p.Date <= end)
                        select p;
            return query.Distinct().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<XMFinancialCapitalFlow> GetXMFinancialCapitalFlowListByIDs(string ids)
        {
            int?[] idlist = Array.ConvertAll<string, int?>(ids.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && idlist.Contains(p.ID)
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 每月1号定时更新资金流水中未审核的记录，将状态更改为审核状态
        /// </summary>
        public void TimingFinancialCapitalFlowAutoAduit()
        {
            //2005-11-5 13:21:25
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            if (day == 1 && hour == 0)
            {
                //每月1号0点  更新所有之前未审核的  更新已审核状态
                var financials = GetXMFinancialCapitalFlowIsNotAuditListByDateTime(DateTime.Now.ToString());
                if (financials != null && financials.Count > 0)
                {
                    foreach (XMFinancialCapitalFlow Info in financials)
                    {
                        Info.Audit = true;
                        Info.UpdateDate = DateTime.Now;
                        IoC.Resolve<IXMFinancialCapitalFlowService>().UpdateXMFinancialCapitalFlow(Info);
                    }
                }

                //每月1号0点定时执行产品库存统计
                IoC.Resolve<XMInventoryInfoStatisticsService>().AutoStatisticsInventoryInfo();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public List<XMFinancialCapitalFlow> GetXMFinancialCapitalFlowIsNotAuditListByDateTime(string datetime)
        {
            DateTime begin = DateTime.Now;
            if (datetime != "")
            {
                begin = DateTime.Parse(datetime);
            }
            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && p.Date <= begin
                        && p.Audit == false
                        select p;
            return query.ToList();
        }

        public List<XMFinancialCapitalFlow> GetListByData(string Begin, string End, int companyID, int DepartmentID, int ProjectID, int FinancialType, int Audit, string Abstract, int PaymentCollectionType, int ReceivablesType,int BudgetType, string AssociatedPerson)
        {
            bool financialType = false;
            bool audit = false;
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now;
            List<int> departmentList = new List<int>();

            if (FinancialType == 1)
            {
                financialType = true;
            }
            if (Audit == 1)
            {
                audit = true;
            }
            if (Begin != "" && End != "")
            {
                begin = DateTime.Parse(Begin);
                end = DateTime.Parse(End);
            }

            departmentList.Add(DepartmentID);

            //新老B2B事业部
            if (DepartmentID==297)
            {
                departmentList.Add(6);
            }
            //新老B2C服务部
            else if(DepartmentID==63)
            {
                departmentList.Add(197);
            }

            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && ((Begin == "" && End == "") || (p.Date >= begin && p.Date < end))
                        && (DepartmentID == -1 || departmentList.Contains((int)p.DepartmentID))
                        && (ProjectID == -1 || p.BelongingProjectID == ProjectID)
                        && (FinancialType == -1 || p.IsIncome == financialType)
                        && (PaymentCollectionType == -1 || p.PaymentCollectionType == PaymentCollectionType)
                        && (ReceivablesType == -1 || p.ReceivablesType == ReceivablesType)
                        &&(BudgetType==-1||p.BudgetType== BudgetType)
                            //&& (AssociatedPerson == "" || p.AssociatedPerson.Contains(AssociatedPerson))
                        && (AssociatedPerson == "-1" ||
                           ((AssociatedPerson == "" && (p.AssociatedPerson == null || p.AssociatedPerson == ""))
                           || (AssociatedPerson != "" && p.AssociatedPerson.Contains(AssociatedPerson)))
                           )
                        && (Audit == -1 || p.Audit == audit || (p.Audit == null && audit == false))
                        && p.Abstract.Contains(Abstract)
                        orderby p.Date descending
                        select p;

            if(companyID!=-1&& DepartmentID==-1)
            {
                if(companyID!=3)
                {
                    var departmentIDList= (from p in this._context.Departments
                                          where !p.Deleted && p.EnterpriseID == companyID && p.ParentID == 0
                                          select p.DepartmentID).ToList();

                    return query.Where(a => departmentIDList.Contains((int)a.DepartmentID)).ToList();
                }
                else//新旧数据合并
                {
                    var departmentIDList = (from p in this._context.Departments
                                            where !p.Deleted && p.EnterpriseID == companyID && p.ParentID == 0
                                            select p.DepartmentID).ToList();

                    departmentIDList.Add(6);
                    departmentIDList.Add(197);
                    departmentIDList.Add(505);
                    departmentIDList.Add(507);
                    departmentIDList.Add(707);

                    return query.Where(a=> departmentIDList.Contains((int)a.DepartmentID)).ToList();
                }
            }

            return query.ToList();

        }

        public List<XMFinancialCapitalFlow> GetListByData(string Begin, string End, int DepartmentID, int ProjectID, int FinancialType, int Audit, string Abstract, int PaymentCollectionType)
        {
            bool financialType = false;
            bool audit = false;
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now; ;

            if (FinancialType == 1)
            {
                financialType = true;
            }
            if (Audit == 1)
            {
                audit = true;
            }
            if (Begin != "" && End != "")
            {
                begin = DateTime.Parse(Begin);
                end = DateTime.Parse(End);
            }

            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && ((Begin == "" && End == "") || (p.Date >= begin && p.Date < end))
                        && (DepartmentID == -1 || p.DepartmentID == DepartmentID)
                        && (ProjectID == -1 || p.BelongingProjectID == ProjectID)
                        && (FinancialType == -1 || p.IsIncome == financialType)
                        && (PaymentCollectionType == -1 || p.PaymentCollectionType == PaymentCollectionType)
                        && (Audit == -1 || p.Audit == audit || (p.Audit == null && audit == false))
                        && p.Abstract.Contains(Abstract)
                        select p;
            return query.ToList();
        }

        public List<XMFinancialCapitalFlow> GetListByDataToTable(string Begin, string End, int DepartmentID, int ProjectID, int BudgetType)
        {
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now; ;

            if (Begin != "" && End != "")
            {
                begin = DateTime.Parse(Begin);
                end = DateTime.Parse(End);
            }

            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && ((Begin == "" && End == "") || (p.Date >= begin && p.Date < end))
                        && (DepartmentID == -1 || p.DepartmentID == DepartmentID)
                        && (ProjectID == -1 || p.BelongingProjectID == ProjectID)
                        && p.IsIncome == false
                            //&& p.Audit == true
                        && (BudgetType == -1 || p.BudgetType == BudgetType)
                        select p;
            return query.ToList();
        }

        public decimal getAdvertisingCost(string Begin, string End, int DepartmentID, int ProjectID, int BudgetType)
        {
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now; ;

            if (Begin != "" && End != "")
            {
                begin = DateTime.Parse(Begin);
                end = DateTime.Parse(End);
            }

            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && ((Begin == "" && End == "") || (p.Date >= begin && p.Date < end))
                        && (DepartmentID == -1 || p.DepartmentID == DepartmentID)
                        && (ProjectID == -1 || p.BelongingProjectID == ProjectID)
                        && p.IsIncome == false
                        //&& p.Audit == true
                        && (BudgetType == -1 || p.BudgetType == BudgetType)
                        select p;

            decimal? cost = query.Select(a => a.Amount).Sum();

            return cost == null ? 0 : (decimal)cost;
        }

        public List<XMFinancialCapitalFlow> GetListByDataToTableB2BCByReceivablesType(string Begin, string End, int DepartmentID, int ReceivablesType)
        {
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now; ;

            if (Begin != "" && End != "")
            {
                begin = DateTime.Parse(Begin);
                end = DateTime.Parse(End);
            }

            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && ((Begin == "" && End == "") || (p.Date >= begin && p.Date < end))
                        && (DepartmentID == -1 || p.DepartmentID == DepartmentID)
                        && p.IsIncome == true
                        && (ReceivablesType == -1 || p.ReceivablesType == ReceivablesType)
                        && (DepartmentID != 197 || (DepartmentID == 197 && (p.BelongingProjectID == -1 || p.BelongingProjectID == null)))
                        select p;
            return query.ToList();
        }

        public List<XMFinancialCapitalFlow> GetListByDataToTableB2BCByBudgetType(string Begin, string End, int DepartmentID, List<int?> BudgetType)
        {
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now; ;

            if (Begin != "" && End != "")
            {
                begin = DateTime.Parse(Begin);
                end = DateTime.Parse(End);
            }

            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && ((Begin == "" && End == "") || (p.Date >= begin && p.Date < end))
                        && (DepartmentID == -1 || p.DepartmentID == DepartmentID)
                        && p.IsIncome == false
                        && !BudgetType.Contains(p.BudgetType)
                        select p;
            return query.ToList();
        }

        public List<XMFinancialCapitalFlow> GetListByFinancialFieldList(string Begin, string End, int DepartmentID, int ProjectID, List<int?> FinancialFieldList)
        {
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now; ;

            if (Begin != "" && End != "")
            {
                begin = DateTime.Parse(Begin);
                end = DateTime.Parse(End);
            }

            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && ((Begin == "" && End == "") || (p.Date >= begin && p.Date < end))
                        && (DepartmentID == -1 || p.DepartmentID == DepartmentID)
                        && (ProjectID == -1 || p.BelongingProjectID == ProjectID)
                        && p.IsIncome == false
                            //&& p.Audit == true
                        && FinancialFieldList.Contains(p.BudgetType)
                        select p;
            return query.ToList();
        }

        public List<XMFinancialCapitalFlow> GetListByDataBudgetType(DateTime Begin, DateTime End, int ProjectID)
        {
            var query = from p in this._context.XMFinancialCapitalFlows
                        join b in this._context.XMFinancialFields
                        on p.BudgetType equals b.Id
                        where p.IsEnabled == false
                        && b.Deleted == false
                        && b.IsManagementField == true
                        && b.ParentID == 70//管理费用
                        && p.Date >= Begin && p.Date < End
                        && (ProjectID == -1 || p.BelongingProjectID == ProjectID)
                        && p.IsIncome == false
                        && p.Audit == true
                        select p;
            return query.ToList();
        }

        public List<XMFinancialCapitalFlow> GetListByBudgetType(DateTime Begin, DateTime End, int DepartmentType, int BudgetType)
        {
            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && p.Date >= Begin && p.Date < End
                        && p.DepartmentID == DepartmentType
                        && p.BudgetType == BudgetType
                        && p.IsIncome == false
                        //&& p.Audit == true
                        select p;
            return query.ToList();
        }

        public List<XMFinancialCapitalFlow> GetListByYearMonth(int ProjectID, int companyID, DateTime begin, DateTime end, bool IsBalance)
        {
            List<int> departmentList = new List<int>();

            if (companyID!=-1)
            {
                departmentList = (from p in this._context.Departments
                                where !p.Deleted && p.EnterpriseID == companyID && p.ParentID == 0
                                select p.DepartmentID).ToList();
                if(companyID==3)
                {
                    //6, 197, 505, 507, 707  codelist 老部门
                    departmentList.Add(6);
                    departmentList.Add(197);
                    departmentList.Add(505);
                    departmentList.Add(507);
                    departmentList.Add(707);
                }
            }

            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.IsEnabled == false
                        && ((IsBalance == true && p.Date < begin) || (IsBalance == false && p.Date >= begin))
                        && (IsBalance == true || p.Date < end)
                        && (ProjectID == -1 || p.BelongingProjectID == ProjectID)
                        &&(companyID==-1|| departmentList.Contains((int)p.DepartmentID))
                        orderby p.PaymentCollectionType
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMFinancialCapitalFlow Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMFinancialCapitalFlow Page List</returns>
        public PagedList<XMFinancialCapitalFlow> SearchXMFinancialCapitalFlow(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMFinancialCapitalFlows
                        orderby p.ID
                        select p;
            return new PagedList<XMFinancialCapitalFlow>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="id">XMFinancialCapitalFlow ID</param>
        /// <returns>XMFinancialCapitalFlow</returns>   
        public XMFinancialCapitalFlow GetXMFinancialCapitalFlowByID(int id)
        {
            var query = from p in this._context.XMFinancialCapitalFlows
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="ID">XMFinancialCapitalFlow ID</param>
        public void DeleteXMFinancialCapitalFlow(int id)
        {
            var xmfinancialcapitalflow = this.GetXMFinancialCapitalFlowByID(id);
            if (xmfinancialcapitalflow == null)
                return;

            if (!this._context.IsAttached(xmfinancialcapitalflow))
                this._context.XMFinancialCapitalFlows.Attach(xmfinancialcapitalflow);

            this._context.DeleteObject(xmfinancialcapitalflow);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="IDs">XMFinancialCapitalFlow ID</param>
        public void BatchDeleteXMFinancialCapitalFlow(List<int> ids)
        {
            var query = from q in _context.XMFinancialCapitalFlows
                        where ids.Contains(q.ID)
                        select q;
            var xmfinancialcapitalflows = query.ToList();
            foreach (var item in xmfinancialcapitalflows)
            {
                if (!_context.IsAttached(item))
                    _context.XMFinancialCapitalFlows.Attach(item);

                _context.XMFinancialCapitalFlows.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        public string getDepartmentName(int departmentID)
        {
            var query = from c in _context.CodeLists
                        where c.CodeID == departmentID
                        select c;

            var codeList = query.SingleOrDefault();

            if(codeList==null)
            {
                var query1 = from p in _context.Departments
                             where p.DepartmentID == departmentID && !p.Deleted
                             select p;

                var departmentList = query1.SingleOrDefault();
                if(departmentList==null)
                {
                    return "";
                }
                else
                {
                    return departmentList.DepName;
                }
            }
            else
            {
                return codeList.CodeName;
            }
        }

        #endregion
    }
}
