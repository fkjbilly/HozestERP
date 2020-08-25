
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
    public partial class AdvanceApplicationDetailService: IAdvanceApplicationDetailService
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
    	public AdvanceApplicationDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IAdvanceApplicationDetailService成员
        /// <summary>
        /// Insert into AdvanceApplicationDetail
        /// </summary>
        /// <param name="advanceapplicationdetail">AdvanceApplicationDetail</param>
    	public void InsertAdvanceApplicationDetail(AdvanceApplicationDetail advanceapplicationdetail)
    	{	
            if (advanceapplicationdetail == null)
                return;
    
            if (!this._context.IsAttached(advanceapplicationdetail))
    			
                this._context.AdvanceApplicationDetails.AddObject(advanceapplicationdetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into AdvanceApplicationDetail
        /// </summary>
        /// <param name="advanceapplicationdetail">AdvanceApplicationDetail</param>
        public void UpdateAdvanceApplicationDetail(AdvanceApplicationDetail advanceapplicationdetail)
        {
            if (advanceapplicationdetail == null)
                return;
    
            if (this._context.IsAttached(advanceapplicationdetail))
                this._context.AdvanceApplicationDetails.Attach(advanceapplicationdetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to AdvanceApplicationDetail list
        /// </summary>
        public List<AdvanceApplicationDetail> GetAdvanceApplicationDetailList()
        {		
            var query = from p in this._context.AdvanceApplicationDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to AdvanceApplicationDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>AdvanceApplicationDetail Page List</returns>
        public PagedList<AdvanceApplicationDetail> SearchAdvanceApplicationDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.AdvanceApplicationDetails
                        orderby p.Id
                        select p;
            return new PagedList<AdvanceApplicationDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a AdvanceApplicationDetail by Id
        /// </summary>
        /// <param name="id">AdvanceApplicationDetail Id</param>
        /// <returns>AdvanceApplicationDetail</returns>   
        public AdvanceApplicationDetail GetAdvanceApplicationDetailById(int id)
        {
            var query = from p in this._context.AdvanceApplicationDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete AdvanceApplicationDetail by Id
        /// </summary>
        /// <param name="Id">AdvanceApplicationDetail Id</param>
        public void DeleteAdvanceApplicationDetail(int id)
        {
            var advanceapplicationdetail = this.GetAdvanceApplicationDetailById(id);
            if (advanceapplicationdetail == null)
                return;
    
            if (!this._context.IsAttached(advanceapplicationdetail))
                this._context.AdvanceApplicationDetails.Attach(advanceapplicationdetail);
    
            this._context.DeleteObject(advanceapplicationdetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete AdvanceApplicationDetail by Id
        /// </summary>
        /// <param name="Ids">AdvanceApplicationDetail Id</param>
        public void BatchDeleteAdvanceApplicationDetail(List<int> ids)
        {
    	   var query = from q in _context.AdvanceApplicationDetails
                    where ids.Contains(q.Id)
                    select q;
            var advanceapplicationdetails = query.ToList();
            foreach (var item in advanceapplicationdetails)
            {
                if (!_context.IsAttached(item))
                    _context.AdvanceApplicationDetails.Attach(item);  
    
                _context.AdvanceApplicationDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
