
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:28:32
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

namespace HozestERP.BusinessLogic.Entity
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
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to AdvanceApplication Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>AdvanceApplication Page List</returns>
        public PagedList<AdvanceApplication> SearchAdvanceApplication(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.AdvanceApplications
                        orderby p.Id
                        select p;
            return new PagedList<AdvanceApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
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
                        select p;
            return query.SingleOrDefault();
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
