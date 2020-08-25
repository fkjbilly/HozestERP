
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-06-05 10:06:13
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
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class CWStaffSpendingService : ICWStaffSpendingService
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
        public CWStaffSpendingService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region ICWStaffSpendingService成员
        /// <summary>
        /// Insert into CWStaffSpending
        /// </summary>
        /// <param name="cwstaffspending">CWStaffSpending</param>
        public void InsertCWStaffSpending(CWStaffSpending cwstaffspending)
        {
            if (cwstaffspending == null)
                return;

            if (!this._context.IsAttached(cwstaffspending))

                this._context.CWStaffSpendings.AddObject(cwstaffspending);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into CWStaffSpending
        /// </summary>
        /// <param name="cwstaffspending">CWStaffSpending</param>
        public void UpdateCWStaffSpending(CWStaffSpending cwstaffspending)
        {
            if (cwstaffspending == null)
                return;

            if (this._context.IsAttached(cwstaffspending))
                this._context.CWStaffSpendings.Attach(cwstaffspending);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to CWStaffSpending list
        /// </summary>
        public List<CWStaffSpending> GetCWStaffSpendingList()
        {
            var query = from p in this._context.CWStaffSpendings
                        select p;
            return query.ToList();
        }

        public XMFinancialField GetFinancialFieldName(int FinancialFieldId)
        {
            var query = from f in this._context.XMFinancialFields
                        where f.Deleted == false
                        && f.Id == FinancialFieldId
                        select f;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据条件查询 人员开支费用
        /// </summary>
        /// <param name="ProfitProjectId">利润项目Id</param>
        /// <param name="NickProjectId">店铺项目Id</param>
        /// <param name="YearStr">年份</param>
        /// <param name="MonthStr">月份</param>
        /// <returns></returns>
        public List<CWStaffSpending> GetCWStaffSpendingList(int ProjectId, int NickId, string YearStr, string MonthStr)
        {
            //月份集合
            List<string> MonthStrList = new List<string>();

            if (MonthStr != "")
            {
                if (MonthStr.IndexOf(",") > -1)
                {
                    string[] OrderCodestr = MonthStr.Split(',');
                    MonthStrList = new List<string>(OrderCodestr);
                }
                else if (MonthStr.IndexOf("，") > -1)
                {
                    string[] OrderCodestr = MonthStr.Split('，');
                    MonthStrList = new List<string>(OrderCodestr);
                }
                else
                {
                    MonthStrList.Add(MonthStr);
                }
            }

            var query = from p in this._context.CWStaffSpendings
                        where (ProjectId == -1 || p.ProjectId == ProjectId)
                        && (NickId == -1 || p.NickId == NickId)
                        && p.YearStr.Equals(YearStr)
                        && MonthStrList.Contains(p.MonthStr)
                        && p.IsEnable == false
                        orderby p.FinancialFieldId
                        select p;
            return query.ToList();
        }

        public CWStaffSpending GetCWStaffSpendingInfo(string ProjectId, int NickId, string Year, string Month, int FinancialFieldId, int DepartmentType)
        {
            int projectId = int.Parse(ProjectId);
            var query = from p in this._context.CWStaffSpendings
                        where (projectId == -1 || p.ProjectId == projectId)
                        && (NickId == -1 || p.NickId == NickId)
                        && (DepartmentType == -1 || p.DepartmentTypeId == DepartmentType)
                        && p.YearStr.Equals(Year)
                        && p.MonthStr.Equals(Month)
                        && p.IsEnable == false
                        && p.FinancialFieldId == FinancialFieldId
                        orderby p.FinancialFieldId
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// get to CWStaffSpending Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CWStaffSpending Page List</returns>
        public PagedList<CWStaffSpending> SearchCWStaffSpending(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CWStaffSpendings
                        orderby p.Id
                        select p;
            return new PagedList<CWStaffSpending>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a CWStaffSpending by Id
        /// </summary>
        /// <param name="id">CWStaffSpending Id</param>
        /// <returns>CWStaffSpending</returns>   
        public CWStaffSpending GetCWStaffSpendingById(int id)
        {
            var query = from p in this._context.CWStaffSpendings
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public List<CWStaffSpending> GetCWStaffSpendingListbyData(List<int?> FinancialFieldList, string YearStr, string MonthStr, int ProjectId, int DepartmentType, int NickId)
        {
            var query = from p in this._context.CWStaffSpendings
                        where p.IsEnable == false
                        && FinancialFieldList.Contains(p.FinancialFieldId)
                        && p.YearStr == YearStr
                        && p.MonthStr == MonthStr
                        && (ProjectId == -1 || p.ProjectId == ProjectId)
                        && (NickId == -1 || p.NickId == NickId)
                        && (DepartmentType == -1 || p.DepartmentTypeId == DepartmentType)
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// delete CWStaffSpending by Id
        /// </summary>
        /// <param name="Id">CWStaffSpending Id</param>
        public void DeleteCWStaffSpending(int id)
        {
            var cwstaffspending = this.GetCWStaffSpendingById(id);
            if (cwstaffspending == null)
                return;

            if (!this._context.IsAttached(cwstaffspending))
                this._context.CWStaffSpendings.Attach(cwstaffspending);

            this._context.DeleteObject(cwstaffspending);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete CWStaffSpending by Id
        /// </summary>
        /// <param name="Ids">CWStaffSpending Id</param>
        public void BatchDeleteCWStaffSpending(List<int> ids)
        {
            var query = from q in _context.CWStaffSpendings
                        where ids.Contains(q.Id)
                        select q;
            var cwstaffspendings = query.ToList();
            foreach (var item in cwstaffspendings)
            {
                if (!_context.IsAttached(item))
                    _context.CWStaffSpendings.Attach(item);

                _context.CWStaffSpendings.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
