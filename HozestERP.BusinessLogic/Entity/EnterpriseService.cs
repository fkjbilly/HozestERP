
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
    public partial class EnterpriseService: IEnterpriseService
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
    	public EnterpriseService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IEnterpriseService成员
        /// <summary>
        /// Insert into Enterprise
        /// </summary>
        /// <param name="enterprise">Enterprise</param>
    	public void InsertEnterprise(Enterprise enterprise)
    	{	
            if (enterprise == null)
                return;
    
            if (!this._context.IsAttached(enterprise))
    			
                this._context.Enterprises.AddObject(enterprise);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Enterprise
        /// </summary>
        /// <param name="enterprise">Enterprise</param>
        public void UpdateEnterprise(Enterprise enterprise)
        {
            if (enterprise == null)
                return;
    
            if (this._context.IsAttached(enterprise))
                this._context.Enterprises.Attach(enterprise);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Enterprise list
        /// </summary>
        public List<Enterprise> GetEnterpriseList()
        {		
            var query = from p in this._context.Enterprises
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Enterprise Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Enterprise Page List</returns>
        public PagedList<Enterprise> SearchEnterprise(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Enterprises
                        orderby p.EntId
                        select p;
            return new PagedList<Enterprise>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Enterprise by EntId
        /// </summary>
        /// <param name="entid">Enterprise EntId</param>
        /// <returns>Enterprise</returns>   
        public Enterprise GetEnterpriseByEntId(int entid)
        {
            var query = from p in this._context.Enterprises
                        where p.EntId.Equals(entid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Enterprise by EntId
        /// </summary>
        /// <param name="EntId">Enterprise EntId</param>
        public void DeleteEnterprise(int entid)
        {
            var enterprise = this.GetEnterpriseByEntId(entid);
            if (enterprise == null)
                return;
    
            if (!this._context.IsAttached(enterprise))
                this._context.Enterprises.Attach(enterprise);
    
            this._context.DeleteObject(enterprise);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Enterprise by EntId
        /// </summary>
        /// <param name="EntIds">Enterprise EntId</param>
        public void BatchDeleteEnterprise(List<int> entids)
        {
    	   var query = from q in _context.Enterprises
                    where entids.Contains(q.EntId)
                    select q;
            var enterprises = query.ToList();
            foreach (var item in enterprises)
            {
                if (!_context.IsAttached(item))
                    _context.Enterprises.Attach(item);  
    
                _context.Enterprises.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
