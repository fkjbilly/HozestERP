
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-12-16 08:53:15
** 修改人:
** 修改日期:
** 描 述: 接口实现类
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class XMBusinessDataOtherService: IXMBusinessDataOtherService
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
    	public XMBusinessDataOtherService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMBusinessDataOtherService成员
        /// <summary>
        /// Insert into XMBusinessDataOther
        /// </summary>
        /// <param name="xmbusinessdataother">XMBusinessDataOther</param>
    	public void InsertXMBusinessDataOther(XMBusinessDataOther xmbusinessdataother)
    	{	
            if (xmbusinessdataother == null)
                return;
    
            if (!this._context.IsAttached(xmbusinessdataother))
    			
                this._context.XMBusinessDataOthers.AddObject(xmbusinessdataother);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMBusinessDataOther
        /// </summary>
        /// <param name="xmbusinessdataother">XMBusinessDataOther</param>
        public void UpdateXMBusinessDataOther(XMBusinessDataOther xmbusinessdataother)
        {
            if (xmbusinessdataother == null)
                return;
    
            if (this._context.IsAttached(xmbusinessdataother))
                this._context.XMBusinessDataOthers.Attach(xmbusinessdataother);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMBusinessDataOther list
        /// </summary>
        public List<XMBusinessDataOther> GetXMBusinessDataOtherList()
        {		
            var query = from p in this._context.XMBusinessDataOthers
                        where p.IsEnabled == false
                        select p;
            return query.ToList();
        }

        public List<XMBusinessDataOther> GetXMBusinessDataOtherListByData(string StrObject, int BelongingDep, int AmountType, int FinancialStatus, int BusinessType, int ContractlStatus)
        {
            bool financial = FinancialStatus == 1 ? true : false;
            bool contractl = ContractlStatus == 1 ? true : false;

            IQueryable<XMBusinessDataOther> query;
            query = from p in this._context.XMBusinessDataOthers
                    where p.IsEnabled == false
                    && p.Object.Contains(StrObject)
                    && (BelongingDep == -1 || p.BelongingDepID == BelongingDep)
                    && (AmountType == -1 || p.AmountType == AmountType)
                    && (BusinessType == -1 || p.BusinessType == BusinessType)
                    && (FinancialStatus == -1 || p.FinancialStatus == financial)
                    && (ContractlStatus == -1 || p.ContractlStatus == contractl)
                    select p;
            return query.ToList();
        }
    	
        /// <summary>
        /// get to XMBusinessDataOther Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMBusinessDataOther Page List</returns>
        public PagedList<XMBusinessDataOther> SearchXMBusinessDataOther(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMBusinessDataOthers
                        orderby p.ID
                        select p;
            return new PagedList<XMBusinessDataOther>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        public decimal? GetXMBusinessDataOtherListByMonth(string ProjectID, string DateType, int Month, int BusinessTypeID)
        {
            DateTime begin = DateTime.Parse(DateTime.Now.Year + "/" + Month + "/01");
            DateTime end;
            if (Month == 12)
            {
                end = DateTime.Parse((DateTime.Now.Year + 1) + "/01/01");
            }
            else
            {
                end = DateTime.Parse(DateTime.Now.Year + "/" + (Month + 1) + "/01");
            }
            List<XMBusinessDataOther> list = GetXMBusinessDataOtherListByProjectID(ProjectID, DateType);
            var query = from p in list
                        where (p.SubmitDate >= begin && p.SubmitDate < end)
                        && p.BusinessType == BusinessTypeID
                        select p.Amount;
            return query.ToList().Sum();
        }

        public List<XMBusinessDataOther> GetXMBusinessDataOtherListByProjectID(string ProjectID, string DateType)
        {
            int PayCodeID = 0;
            var CodeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(214);//金额类型
            if (CodeList != null && CodeList.Count > 0)
            {
                foreach (CodeList info in CodeList)
                {
                    if (info.CodeName == "支付")
                    {
                        PayCodeID = info.CodeID;
                        break;
                    }
                }
            }
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now;
            IQueryable<XMBusinessDataOther> query;
            if (DateType == "week")
            {
                begin = begin.AddDays(-6);
            }
            else if (DateType == "month")
            {
                begin = DateTime.Parse(DateTime.Now.Year + "/" + DateTime.Now.Month + "/01");
            }
            else if (DateType == "year")
            {
                begin = DateTime.Parse(DateTime.Now.Year + "/01/01");
            }
            if (ProjectID == "B2B")
            {
                query = from p in this._context.XMBusinessDataOthers
                        where p.BelongingProjectID == -1
                        && p.BelongingDepID == 297
                        && p.IsEnabled == false
                        && p.FinancialStatus == true
                        && p.ContractlStatus == true
                        && (p.SubmitDate >= begin && p.SubmitDate < end)
                        && p.AmountType == PayCodeID
                        orderby p.BusinessType, p.SubmitDate
                        select p;
            }
            else if (ProjectID == "B2C")
            {
                query = from p in this._context.XMBusinessDataOthers
                        where p.BelongingProjectID == -1
                        && p.BelongingDepID == 63
                        && p.IsEnabled == false
                        && p.FinancialStatus == true
                        && p.ContractlStatus == true
                        && (p.SubmitDate >= begin && p.SubmitDate < end)
                        && p.AmountType == PayCodeID
                        orderby p.BusinessType, p.SubmitDate
                        select p;
            }
            else
            {
                int projectId = int.Parse(ProjectID);
                query = from p in this._context.XMBusinessDataOthers
                        where p.BelongingProjectID == projectId
                        && p.IsEnabled == false
                        && p.FinancialStatus == true
                        && p.ContractlStatus == true
                        && (p.SubmitDate >= begin && p.SubmitDate < end)
                        && p.AmountType == PayCodeID
                        orderby p.BusinessType, p.SubmitDate
                        select p;
            }
            return query.ToList();
        }

        public List<XMBusinessDataOther> GetXMBusinessDataOtherResults(string ProjectID, DateTime Begin, DateTime End)
        {
            int PayCodeID = 0;
            var CodeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(214);//金额类型
            if (CodeList != null && CodeList.Count > 0)
            {
                foreach (CodeList info in CodeList)
                {
                    if (info.CodeName == "支付")
                    {
                        PayCodeID = info.CodeID;
                        break;
                    }
                }
            }

            IQueryable<XMBusinessDataOther> query;
            if (ProjectID == "B2B")
            {
                query = from p in this._context.XMBusinessDataOthers
                        where p.BelongingProjectID == -1
                        && p.BelongingDepID == 297
                        && p.IsEnabled == false
                        && p.FinancialStatus == true
                        && p.ContractlStatus == true
                        && (p.SubmitDate >= Begin && p.SubmitDate < End)
                        && p.AmountType == PayCodeID
                        orderby p.BusinessType, p.SubmitDate
                        select p;
            }
            else if (ProjectID == "B2C")
            {
                query = from p in this._context.XMBusinessDataOthers
                        where p.BelongingProjectID == -1
                        && p.BelongingDepID == 63
                        && p.IsEnabled == false
                        && p.FinancialStatus == true
                        && p.ContractlStatus == true
                        && (p.SubmitDate >= Begin && p.SubmitDate < End)
                        && p.AmountType == PayCodeID
                        orderby p.BusinessType, p.SubmitDate
                        select p;
            }
            else
            {
                int projectId = int.Parse(ProjectID);
                query = from p in this._context.XMBusinessDataOthers
                        where p.BelongingProjectID == projectId
                        && p.IsEnabled == false
                        && p.FinancialStatus == true
                        && p.ContractlStatus == true
                        && (p.SubmitDate >= Begin && p.SubmitDate < End)
                        && p.AmountType == PayCodeID
                        orderby p.BusinessType, p.SubmitDate
                        select p;
            }
            return query.ToList();
        }

        public List<XMBusinessDataOther> GetXMBusinessDataOtherListByYear(string ProjectID, string DateType, DateTime begin, DateTime end)
        {
            int PayCodeID = 0;
            var CodeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(214);//金额类型
            if (CodeList != null && CodeList.Count > 0)
            {
                foreach (CodeList info in CodeList)
                {
                    if (info.CodeName == "支付")
                    {
                        PayCodeID = info.CodeID;
                        break;
                    }
                }
            }
            IQueryable<XMBusinessDataOther> query;
            if (ProjectID == "B2B")
            {
                query = from p in this._context.XMBusinessDataOthers
                        where p.BelongingProjectID == -1
                        && p.BelongingDepID == 297
                        && p.IsEnabled == false
                        && p.FinancialStatus == true
                        && p.ContractlStatus == true
                        && (p.SubmitDate >= begin && p.SubmitDate < end)
                        && p.AmountType == PayCodeID
                        orderby p.BusinessType, p.SubmitDate
                        select p;
            }
            else if (ProjectID == "B2C")
            {
                query = from p in this._context.XMBusinessDataOthers
                        where p.BelongingProjectID == -1
                        && p.BelongingDepID == 63
                        && p.IsEnabled == false
                        && p.FinancialStatus == true
                        && p.ContractlStatus == true
                        && (p.SubmitDate >= begin && p.SubmitDate < end)
                        && p.AmountType == PayCodeID
                        orderby p.BusinessType, p.SubmitDate
                        select p;
            }
            else
            {
                int projectId = int.Parse(ProjectID);
                query = from p in this._context.XMBusinessDataOthers
                        where p.BelongingProjectID == projectId
                        && p.IsEnabled == false
                        && p.FinancialStatus == true
                        && p.ContractlStatus == true
                        && (p.SubmitDate >= begin && p.SubmitDate < end)
                        && p.AmountType == PayCodeID
                        orderby p.BusinessType, p.SubmitDate
                        select p;
            }
            return query.ToList();
        }

    	/// <summary>
        /// get a XMBusinessDataOther by ID
        /// </summary>
        /// <param name="id">XMBusinessDataOther ID</param>
        /// <returns>XMBusinessDataOther</returns>   
        public XMBusinessDataOther GetXMBusinessDataOtherByID(int id)
        {
            var query = from p in this._context.XMBusinessDataOthers
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMBusinessDataOther by ID
        /// </summary>
        /// <param name="ID">XMBusinessDataOther ID</param>
        public void DeleteXMBusinessDataOther(int id)
        {
            var xmbusinessdataother = this.GetXMBusinessDataOtherByID(id);
            if (xmbusinessdataother == null)
                return;
    
            if (!this._context.IsAttached(xmbusinessdataother))
                this._context.XMBusinessDataOthers.Attach(xmbusinessdataother);
    
            this._context.DeleteObject(xmbusinessdataother);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMBusinessDataOther by ID
        /// </summary>
        /// <param name="IDs">XMBusinessDataOther ID</param>
        public void BatchDeleteXMBusinessDataOther(List<int> ids)
        {
    	   var query = from q in _context.XMBusinessDataOthers
                    where ids.Contains(q.ID)
                    select q;
            var xmbusinessdataothers = query.ToList();
            foreach (var item in xmbusinessdataothers)
            {
                if (!_context.IsAttached(item))
                    _context.XMBusinessDataOthers.Attach(item);  
    
                _context.XMBusinessDataOthers.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
