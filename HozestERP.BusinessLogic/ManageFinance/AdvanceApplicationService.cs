
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-23 09:33:49
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
    public partial class AdvanceApplicationService: IAdvanceApplicationService
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
    	public AdvanceApplicationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IAdvanceApplicationService成员
        /// <summary>
        /// Insert into AdvanceApplication
        /// </summary>
        /// <param name="advanceapplication">AdvanceApplication</param>
    	public void InsertAdvanceApplication(AdvanceApplication advanceapplication)
    	{	
            if (advanceapplication == null)
                return;
    
            if (!this._context.IsAttached(advanceapplication))
    			
                this._context.AdvanceApplications.AddObject(advanceapplication);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into AdvanceApplication
        /// </summary>
        /// <param name="advanceapplication">AdvanceApplication</param>
        public void UpdateAdvanceApplication(AdvanceApplication advanceapplication)
        {
            if (advanceapplication == null)
                return;
    
            if (this._context.IsAttached(advanceapplication))
                this._context.AdvanceApplications.Attach(advanceapplication);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to AdvanceApplication list
        /// </summary>
        public List<AdvanceApplication> GetAdvanceApplicationList()
        {		
            var query = from p in this._context.AdvanceApplications
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to AdvanceApplication Page List
        /// </summary>
        /// <param name="PlatformTypeId">平台类型</param>
        /// <param name="NickId">店铺Id</param>
        /// <param name="ManagerIsAudit">部门审核</param>
        /// <param name="FinanceIsAudit">财务审核</param>
        /// <param name="AdvanceState">暂支状态</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>AdvanceApplication Page List</returns>
        public PagedList<AdvanceApplication> SearchAdvanceApplication(int PlatformTypeId, List<int> NickId, int ManagerIsAudit, int FinanceIsAudit, int FinanceOkIsAudit, int AdvanceState, string ScalpingCode, int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            if (ScalpingCode != "")
            {
                if (NickId.Count > 1)
                {
                    var query = from p in this._context.AdvanceApplications
                                join b in this._context.XMScalpingApplications
                                on p.ScalpingId equals b.ScalpingId
                                where (PlatformTypeId == -1 || p.PlatformTypeId == null || p.PlatformTypeId == PlatformTypeId)
                                && NickId.Contains(p.NickId.Value)
                                && (ManagerIsAudit == -1 || p.ManagerIsAudit.Value.Equals(ManagerIsAudit == 0 ? false : true))
                                && (FinanceIsAudit == -1 || p.FinanceIsAudit.Value.Equals(FinanceIsAudit == 0 ? false : true))
                                && (FinanceOkIsAudit == -1 || p.FinanceOkIsAudit.Value.Equals(FinanceOkIsAudit == 0 ? false : true))
                                && (AdvanceState == -1 || p.AdvanceState == AdvanceState)
                                && p.IsEnable == false
                                && b.ScalpingCode.Contains(ScalpingCode)
                                orderby p.Id descending
                                select p;
                    return new PagedList<AdvanceApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
                }
                else
                {

                    int nickId = NickId[0];
                    var query = from p in this._context.AdvanceApplications
                                join b in this._context.XMScalpingApplications
                                on p.ScalpingId equals b.ScalpingId
                                where (PlatformTypeId == -1 || p.PlatformTypeId == null || p.PlatformTypeId == PlatformTypeId)
                                && (nickId == -1 || p.NickId == null || p.NickId == nickId)
                                && (ManagerIsAudit == -1 || p.ManagerIsAudit.Value.Equals(ManagerIsAudit == 0 ? false : true))
                                && (FinanceIsAudit == -1 || p.FinanceIsAudit.Value.Equals(FinanceIsAudit == 0 ? false : true))
                                && (FinanceOkIsAudit == -1 || p.FinanceOkIsAudit.Value.Equals(FinanceOkIsAudit == 0 ? false : true))
                                && (AdvanceState == -1 || p.AdvanceState == AdvanceState)
                                && p.IsEnable == false
                                && b.ScalpingCode.Contains(ScalpingCode)
                                orderby p.Id descending
                                select p;
                    return new PagedList<AdvanceApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
                }
            }
            else {

                if (NickId.Count > 1)
                {
                    var query = from p in this._context.AdvanceApplications 
                                where (PlatformTypeId == -1 || p.PlatformTypeId == null || p.PlatformTypeId == PlatformTypeId)
                                && NickId.Contains(p.NickId.Value)
                                && (ManagerIsAudit == -1 || p.ManagerIsAudit.Value.Equals(ManagerIsAudit == 0 ? false : true))
                                && (FinanceIsAudit == -1 || p.FinanceIsAudit.Value.Equals(FinanceIsAudit == 0 ? false : true))
                                && (FinanceOkIsAudit == -1 || p.FinanceOkIsAudit.Value.Equals(FinanceOkIsAudit == 0 ? false : true))
                                && (AdvanceState == -1 || p.AdvanceState == AdvanceState)
                                && p.IsEnable == false 
                                orderby p.Id descending
                                select p;
                    return new PagedList<AdvanceApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
                }
                else
                {

                    int nickId = NickId[0];
                    var query = from p in this._context.AdvanceApplications 
                                where (PlatformTypeId == -1 || p.PlatformTypeId == null || p.PlatformTypeId == PlatformTypeId)
                                && (nickId == -1 || p.NickId == null || p.NickId == nickId)
                                && (ManagerIsAudit == -1 || p.ManagerIsAudit.Value.Equals(ManagerIsAudit == 0 ? false : true))
                                && (FinanceIsAudit == -1 || p.FinanceIsAudit.Value.Equals(FinanceIsAudit == 0 ? false : true))
                                && (FinanceOkIsAudit == -1 || p.FinanceOkIsAudit.Value.Equals(FinanceOkIsAudit == 0 ? false : true))
                                && (AdvanceState == -1 || p.AdvanceState == AdvanceState)
                                && p.IsEnable == false 
                                orderby p.Id descending
                                select p;
                    return new PagedList<AdvanceApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
                }
            }
        }



        /// <summary>
        /// 根据暂支类型、店铺名称、申请人、暂支状态查询
        /// </summary>
        /// <param name="TheAdvanceType">暂支类型</param>
        /// <param name="NickId">店铺名称</param>
        /// <param name="ApplicantsName">申请人</param>
        /// <param name="AdvanceState">暂支状态</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns></returns>
        public PagedList<AdvanceApplication> SearchAdvanceApplication(int TheAdvanceType, int NickId, string ApplicantsName, int AdvanceState,string ScalpingCode,int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            if (TheAdvanceType == 343)
            {
                var query = from p in this._context.AdvanceApplications
                            join b in this._context.CustomerInfoes
                            on p.Applicants equals b.CustomerID
                            join c in this._context.XMScalpingApplications
                            on p.ScalpingId equals c.ScalpingId
                            where (p.TheAdvanceType == TheAdvanceType || TheAdvanceType == -1)
                            && (NickId == -1 || p.NickId == NickId)
                            && (AdvanceState == -1 || p.AdvanceState == AdvanceState)
                            && p.IsEnable == false
                            && b.FullName.Contains(ApplicantsName)
                            && c.ScalpingCode.Contains(ScalpingCode)
                            orderby p.Id descending
                            select p;
                return new PagedList<AdvanceApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
            }
            else {
                var query = from p in this._context.AdvanceApplications
                            join b in this._context.CustomerInfoes
                            on p.Applicants equals b.CustomerID 
                            where (p.TheAdvanceType == TheAdvanceType || TheAdvanceType == -1)
                            && (NickId == -1 || p.NickId == NickId)
                            && (AdvanceState == -1 || p.AdvanceState == AdvanceState)
                            && p.IsEnable == false
                            && b.FullName.Contains(ApplicantsName) 
                            orderby p.Id descending
                            select p;
                return new PagedList<AdvanceApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
            
            }
        
        }
    
    	/// <summary>
        /// get a AdvanceApplication by Id
        /// </summary>
        /// <param name="id">AdvanceApplication Id</param>
        /// <returns>AdvanceApplication</returns>   
        public AdvanceApplication GetAdvanceApplicationById(int id)
        {
            var query = from p in this._context.AdvanceApplications
                        where p.Id.Equals(id) 
                        && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }
         

        /// <summary>
        /// 根据刷单id 查询
        /// </summary>
        /// <param name="id">AdvanceApplication Id</param>
        /// <returns>AdvanceApplication</returns>   
        public List<AdvanceApplication> GetAdvanceApplicationByScalpingId(int ScalpingId)
        {
            var query = from p in this._context.AdvanceApplications
                        where p.ScalpingId==ScalpingId
                        && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id">AdvanceApplication Id</param>
        /// <returns>AdvanceApplication</returns>   
        public List<AdvanceApplication> GetAdvanceApplicationListById(List<int> Id)
        {
            var query = from p in this._context.AdvanceApplications
                        where !p.IsEnable.Value && Id.Contains(p.Id)
                        select p;
            return query.ToList();
        
        }

        /// <summary>
        /// 根据店铺Id查询
        /// </summary>
        /// <param name="id">AdvanceApplication Id</param>
        /// <returns>AdvanceApplication</returns>   
        public List<AdvanceApplication> GetAdvanceApplicationListByNickId(List<int> NickId) {

            var query = from p in this._context.AdvanceApplications
                        where !p.IsEnable.Value 
                        && NickId.Contains(p.NickId.Value)
                        select p;
            return query.ToList();
        }
    
    	/// <summary>
        /// delete AdvanceApplication by Id
        /// </summary>
        /// <param name="Id">AdvanceApplication Id</param>
        public void DeleteAdvanceApplication(int id)
        {
            var advanceapplication = this.GetAdvanceApplicationById(id);
            if (advanceapplication == null)
                return;
    
            if (!this._context.IsAttached(advanceapplication))
                this._context.AdvanceApplications.Attach(advanceapplication);
    
            this._context.DeleteObject(advanceapplication);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete AdvanceApplication by Id
        /// </summary>
        /// <param name="Ids">AdvanceApplication Id</param>
        public void BatchDeleteAdvanceApplication(List<int> ids)
        {
    	   var query = from q in _context.AdvanceApplications
                    where ids.Contains(q.Id)
                    select q;
            var advanceapplications = query.ToList();
            foreach (var item in advanceapplications)
            {
                if (!_context.IsAttached(item))
                    _context.AdvanceApplications.Attach(item);  
    
                _context.AdvanceApplications.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
