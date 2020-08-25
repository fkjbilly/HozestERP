
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2018-01-25 11:01:56
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
using System.Linq.Expressions;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMClaimReasonService: IXMClaimReasonService
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
    	public XMClaimReasonService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion

    	
        #region IXMClaimReasonService成员
        /// <summary>
        /// Insert into XMClaimReason
        /// </summary>
        /// <param name="xmclaimreason">XMClaimReason</param>
    	public void InsertXMClaimReason(XMClaimReason xmclaimreason)
    	{	
            if (xmclaimreason == null)
                return;
    
            if (!this._context.IsAttached(xmclaimreason))
    			
                this._context.XMClaimReasons.AddObject(xmclaimreason);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMClaimReason
        /// </summary>
        /// <param name="xmclaimreason">XMClaimReason</param>
        public void UpdateXMClaimReason(XMClaimReason xmclaimreason)
        {
            if (xmclaimreason == null)
                return;
    
            if (this._context.IsAttached(xmclaimreason))
                this._context.XMClaimReasons.Attach(xmclaimreason);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMClaimReason list
        /// </summary>
        public List<XMClaimReason> GetXMClaimReasonList()
        {		
            var query = from p in this._context.XMClaimReasons
                        where p.IsEnable==false
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMClaimReason Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMClaimReason Page List</returns>
        public PagedList<XMClaimReason> SearchXMClaimReason(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMClaimReasons
                        orderby p.ID
                        select p;
            return new PagedList<XMClaimReason>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMClaimReason by ID
        /// </summary>
        /// <param name="id">XMClaimReason ID</param>
        /// <returns>XMClaimReason</returns>   
        public XMClaimReason GetXMClaimReasonByID(int id)
        {
            var query = from p in this._context.XMClaimReasons
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public List<XMClaimReasonNew> GetXMClaimNewReasonList()
        {
            var query = from p in _context.XMClaimReasons
                        join m in _context.XMProjects on p.ProjectID equals m.Id into temp
                        from pm in temp.DefaultIfEmpty()
                        where p.IsEnable == false
                        select new XMClaimReasonNew
                        {
                            ID=p.ID,
                            ProjectID=p.ProjectID,
                            ProjectName=pm.ProjectName,
                            Reason=p.Reason,
                            IsEnable=p.IsEnable,
                            CreateID=p.CreateID,
                            CreateTime=p.CreateTime,
                            UpdateID=p.UpdateID,
                            UpdateTime=p.UpdateTime
                        };

            return query.ToList();
        }

        /// <summary>
        /// delete XMClaimReason by ID
        /// </summary>
        /// <param name="ID">XMClaimReason ID</param>
        public void DeleteXMClaimReason(int id)
        {
            var xmclaimreason = this.GetXMClaimReasonByID(id);
            if (xmclaimreason == null)
                return;
    
            if (!this._context.IsAttached(xmclaimreason))
                this._context.XMClaimReasons.Attach(xmclaimreason);
    
            this._context.DeleteObject(xmclaimreason);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMClaimReason by ID
        /// </summary>
        /// <param name="IDs">XMClaimReason ID</param>
        public void BatchDeleteXMClaimReason(List<int> ids)
        {
    	   var query = from q in _context.XMClaimReasons
                    where ids.Contains(q.ID)
                    select q;
            var xmclaimreasons = query.ToList();
            foreach (var item in xmclaimreasons)
            {
                if (!_context.IsAttached(item))
                    _context.XMClaimReasons.Attach(item);  
    
                _context.XMClaimReasons.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        public XMClaimReason getSingle(Expression<Func<XMClaimReason, bool>> predicate)
        {
            XMClaimReason entity = _context.XMClaimReasons.FirstOrDefault(predicate);
            return entity;
        }

        public IQueryable<XMClaimReason> getList(Expression<Func<XMClaimReason, bool>> predicate)
        {
            IQueryable<XMClaimReason> query = _context.XMClaimReasons.Where(predicate);
            return query;
        }

        #endregion

    }
}
