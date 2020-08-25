
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-06-08 10:42:55
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
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class CWPlatformSpendingService: ICWPlatformSpendingService
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
    	public CWPlatformSpendingService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICWPlatformSpendingService成员
        /// <summary>
        /// Insert into CWPlatformSpending
        /// </summary>
        /// <param name="cwplatformspending">CWPlatformSpending</param>
    	public void InsertCWPlatformSpending(CWPlatformSpending cwplatformspending)
    	{	
            if (cwplatformspending == null)
                return;
    
            if (!this._context.IsAttached(cwplatformspending))
    			
                this._context.CWPlatformSpendings.AddObject(cwplatformspending);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CWPlatformSpending
        /// </summary>
        /// <param name="cwplatformspending">CWPlatformSpending</param>
        public void UpdateCWPlatformSpending(CWPlatformSpending cwplatformspending)
        {
            if (cwplatformspending == null)
                return;
    
            if (this._context.IsAttached(cwplatformspending))
                this._context.CWPlatformSpendings.Attach(cwplatformspending);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CWPlatformSpending list
        /// </summary>
        public List<CWPlatformSpending> GetCWPlatformSpendingList()
        {		
            var query = from p in this._context.CWPlatformSpendings
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 查询平台费用
        /// </summary>
        /// <param name="PlatformTypeId">平台Id(项目表ParentId)</param>
        /// <param name="YearStr">年份</param>
        /// <param name="MonthStr">月份</param>
        /// <returns></returns>
        public List<CWPlatformSpendingMapping> GetCWPlatformSpendingList(List<int> ProjectId, string YearStr, string MonthStr)
        { 
                 //左链接
            var query = from a in this._context.CWProjects
                        join b in this._context.CWPlatformSpendings on a.Id equals b.ProfitProjectId into JoinedAB
                        from b in JoinedAB.DefaultIfEmpty()
                        where (a.IsEnable.Value == false || a.IsEnable == null)
                          && (b.IsEnable.Value == false || b.IsEnable == null)
                         && ProjectId.Contains(a.ParentID.Value)
                         && (b.YearStr.Equals(YearStr) || b.YearStr == null)
                         && (b.MonthStr.Equals(MonthStr) || b.MonthStr == null)
                        select new CWPlatformSpendingMapping
                         {
                             Id = a.Id,
                             PSId = b.Id,
                             ParentID = a.ParentID,
                             ProjectExplanation = a.ProjectExplanation,
                             PlatformTypeId = b.PlatformTypeId,
                             ProfitProjectId = b.ProfitProjectId,
                             YearStr = b.YearStr,
                             MonthStr = b.MonthStr,
                             CountMoney = b.CountMoney == null ? 0 : b.CountMoney.Value,
                             Remark = b.Remark
                         };



            return new List<CWPlatformSpendingMapping>(query.Distinct()).ToList(); 
        }

        /// <summary>
        /// 平台费用
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="YearStr">年份</param>
        /// <param name="MonthStr">月份</param>
        /// <returns></returns>
        public List<CWPlatformSpending> GetCWPlatformSpendingSearchList(int PlatformTypeId, string YearStr, string MonthStr)
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

            var query = from p in this._context.CWPlatformSpendings
                        where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId) 
                        && p.YearStr.Equals(YearStr)
                        && MonthStrList.Contains(p.MonthStr)
                        && p.IsEnable==false
                        select p;
            return query.ToList();

        }

        /// <summary>
        /// 平台费用（根据指定时间）
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="YearStr">年份</param>
        /// <param name="MonthStr">月份</param>
        /// <returns></returns>
        public List<CWPlatformSpending> GetCWPlatformSpendingSearchListSS(int PlatformTypeId, DateTime? min, DateTime? max)
        {
            var query = from p in this._context.CWPlatformSpendings
                        where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        //&& p.YearStr.Equals(YearStr)
                        //&& MonthStrList.Contains(p.MonthStr)
                        && (!min.HasValue || p.CreateDateTime >= min) && (!max.HasValue || p.CreateDateTime <= max) //查询时间范围的数据
                        && p.IsEnable == false
                        select p;
            return query.ToList();

        }


        /// <summary>
        /// get to CWPlatformSpending Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CWPlatformSpending Page List</returns>
        public PagedList<CWPlatformSpending> SearchCWPlatformSpending(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CWPlatformSpendings
                        orderby p.Id
                        select p;
            return new PagedList<CWPlatformSpending>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CWPlatformSpending by Id
        /// </summary>
        /// <param name="id">CWPlatformSpending Id</param>
        /// <returns>CWPlatformSpending</returns>   
        public CWPlatformSpending GetCWPlatformSpendingById(int id)
        {
            var query = from p in this._context.CWPlatformSpendings
                        where p.Id.Equals(id)
                        && p.IsEnable==false
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete CWPlatformSpending by Id
        /// </summary>
        /// <param name="Id">CWPlatformSpending Id</param>
        public void DeleteCWPlatformSpending(int id)
        {
            var cwplatformspending = this.GetCWPlatformSpendingById(id);
            if (cwplatformspending == null)
                return;
    
            if (!this._context.IsAttached(cwplatformspending))
                this._context.CWPlatformSpendings.Attach(cwplatformspending);
    
            this._context.DeleteObject(cwplatformspending);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CWPlatformSpending by Id
        /// </summary>
        /// <param name="Ids">CWPlatformSpending Id</param>
        public void BatchDeleteCWPlatformSpending(List<int> ids)
        {
    	   var query = from q in _context.CWPlatformSpendings
                    where ids.Contains(q.Id)
                    select q;
            var cwplatformspendings = query.ToList();
            foreach (var item in cwplatformspendings)
            {
                if (!_context.IsAttached(item))
                    _context.CWPlatformSpendings.Attach(item);  
    
                _context.CWPlatformSpendings.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
