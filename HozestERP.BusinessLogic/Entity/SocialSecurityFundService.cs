
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
    public partial class SocialSecurityFundService: ISocialSecurityFundService
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
    	public SocialSecurityFundService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ISocialSecurityFundService成员
        /// <summary>
        /// Insert into SocialSecurityFund
        /// </summary>
        /// <param name="socialsecurityfund">SocialSecurityFund</param>
    	public void InsertSocialSecurityFund(SocialSecurityFund socialsecurityfund)
    	{	
            if (socialsecurityfund == null)
                return;
    
            if (!this._context.IsAttached(socialsecurityfund))
    			
                this._context.SocialSecurityFunds.AddObject(socialsecurityfund);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into SocialSecurityFund
        /// </summary>
        /// <param name="socialsecurityfund">SocialSecurityFund</param>
        public void UpdateSocialSecurityFund(SocialSecurityFund socialsecurityfund)
        {
            if (socialsecurityfund == null)
                return;
    
            if (this._context.IsAttached(socialsecurityfund))
                this._context.SocialSecurityFunds.Attach(socialsecurityfund);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to SocialSecurityFund list
        /// </summary>
        public List<SocialSecurityFund> GetSocialSecurityFundList()
        {		
            var query = from p in this._context.SocialSecurityFunds
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to SocialSecurityFund Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>SocialSecurityFund Page List</returns>
        public PagedList<SocialSecurityFund> SearchSocialSecurityFund(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.SocialSecurityFunds
                        orderby p.ID
                        select p;
            return new PagedList<SocialSecurityFund>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a SocialSecurityFund by ID
        /// </summary>
        /// <param name="id">SocialSecurityFund ID</param>
        /// <returns>SocialSecurityFund</returns>   
        public SocialSecurityFund GetSocialSecurityFundByID(int id)
        {
            var query = from p in this._context.SocialSecurityFunds
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete SocialSecurityFund by ID
        /// </summary>
        /// <param name="ID">SocialSecurityFund ID</param>
        public void DeleteSocialSecurityFund(int id)
        {
            var socialsecurityfund = this.GetSocialSecurityFundByID(id);
            if (socialsecurityfund == null)
                return;
    
            if (!this._context.IsAttached(socialsecurityfund))
                this._context.SocialSecurityFunds.Attach(socialsecurityfund);
    
            this._context.DeleteObject(socialsecurityfund);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete SocialSecurityFund by ID
        /// </summary>
        /// <param name="IDs">SocialSecurityFund ID</param>
        public void BatchDeleteSocialSecurityFund(List<int> ids)
        {
    	   var query = from q in _context.SocialSecurityFunds
                    where ids.Contains(q.ID)
                    select q;
            var socialsecurityfunds = query.ToList();
            foreach (var item in socialsecurityfunds)
            {
                if (!_context.IsAttached(item))
                    _context.SocialSecurityFunds.Attach(item);  
    
                _context.SocialSecurityFunds.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
