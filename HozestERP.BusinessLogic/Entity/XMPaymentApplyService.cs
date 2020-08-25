
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
    public partial class XMPaymentApplyService: IXMPaymentApplyService
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
    	public XMPaymentApplyService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMPaymentApplyService成员
        /// <summary>
        /// Insert into XMPaymentApply
        /// </summary>
        /// <param name="xmpaymentapply">XMPaymentApply</param>
    	public void InsertXMPaymentApply(XMPaymentApply xmpaymentapply)
    	{	
            if (xmpaymentapply == null)
                return;
    
            if (!this._context.IsAttached(xmpaymentapply))
    			
                this._context.XMPaymentApplies.AddObject(xmpaymentapply);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMPaymentApply
        /// </summary>
        /// <param name="xmpaymentapply">XMPaymentApply</param>
        public void UpdateXMPaymentApply(XMPaymentApply xmpaymentapply)
        {
            if (xmpaymentapply == null)
                return;
    
            if (this._context.IsAttached(xmpaymentapply))
                this._context.XMPaymentApplies.Attach(xmpaymentapply);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMPaymentApply list
        /// </summary>
        public List<XMPaymentApply> GetXMPaymentApplyList()
        {		
            var query = from p in this._context.XMPaymentApplies
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMPaymentApply Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPaymentApply Page List</returns>
        public PagedList<XMPaymentApply> SearchXMPaymentApply(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPaymentApplies
                        orderby p.Id
                        select p;
            return new PagedList<XMPaymentApply>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMPaymentApply by Id
        /// </summary>
        /// <param name="id">XMPaymentApply Id</param>
        /// <returns>XMPaymentApply</returns>   
        public XMPaymentApply GetXMPaymentApplyById(int id)
        {
            var query = from p in this._context.XMPaymentApplies
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMPaymentApply by Id
        /// </summary>
        /// <param name="Id">XMPaymentApply Id</param>
        public void DeleteXMPaymentApply(int id)
        {
            var xmpaymentapply = this.GetXMPaymentApplyById(id);
            if (xmpaymentapply == null)
                return;
    
            if (!this._context.IsAttached(xmpaymentapply))
                this._context.XMPaymentApplies.Attach(xmpaymentapply);
    
            this._context.DeleteObject(xmpaymentapply);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMPaymentApply by Id
        /// </summary>
        /// <param name="Ids">XMPaymentApply Id</param>
        public void BatchDeleteXMPaymentApply(List<int> ids)
        {
    	   var query = from q in _context.XMPaymentApplies
                    where ids.Contains(q.Id)
                    select q;
            var xmpaymentapplys = query.ToList();
            foreach (var item in xmpaymentapplys)
            {
                if (!_context.IsAttached(item))
                    _context.XMPaymentApplies.Attach(item);  
    
                _context.XMPaymentApplies.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
