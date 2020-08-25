
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
    public partial class XMConsultationDetailsService: IXMConsultationDetailsService
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
    	public XMConsultationDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMConsultationDetailsService成员
        /// <summary>
        /// Insert into XMConsultationDetails
        /// </summary>
        /// <param name="xmconsultationdetails">XMConsultationDetails</param>
    	public void InsertXMConsultationDetails(XMConsultationDetails xmconsultationdetails)
    	{	
            if (xmconsultationdetails == null)
                return;
    
            if (!this._context.IsAttached(xmconsultationdetails))
    			
                this._context.XMConsultationDetails.AddObject(xmconsultationdetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMConsultationDetails
        /// </summary>
        /// <param name="xmconsultationdetails">XMConsultationDetails</param>
        public void UpdateXMConsultationDetails(XMConsultationDetails xmconsultationdetails)
        {
            if (xmconsultationdetails == null)
                return;
    
            if (this._context.IsAttached(xmconsultationdetails))
                this._context.XMConsultationDetails.Attach(xmconsultationdetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMConsultationDetails list
        /// </summary>
        public List<XMConsultationDetails> GetXMConsultationDetailsList()
        {		
            var query = from p in this._context.XMConsultationDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMConsultationDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMConsultationDetails Page List</returns>
        public PagedList<XMConsultationDetails> SearchXMConsultationDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMConsultationDetails
                        orderby p.id
                        select p;
            return new PagedList<XMConsultationDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMConsultationDetails by id
        /// </summary>
        /// <param name="id">XMConsultationDetails id</param>
        /// <returns>XMConsultationDetails</returns>   
        public XMConsultationDetails GetXMConsultationDetailsByid(int id)
        {
            var query = from p in this._context.XMConsultationDetails
                        where p.id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMConsultationDetails by id
        /// </summary>
        /// <param name="id">XMConsultationDetails id</param>
        public void DeleteXMConsultationDetails(int id)
        {
            var xmconsultationdetails = this.GetXMConsultationDetailsByid(id);
            if (xmconsultationdetails == null)
                return;
    
            if (!this._context.IsAttached(xmconsultationdetails))
                this._context.XMConsultationDetails.Attach(xmconsultationdetails);
    
            this._context.DeleteObject(xmconsultationdetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMConsultationDetails by id
        /// </summary>
        /// <param name="ids">XMConsultationDetails id</param>
        public void BatchDeleteXMConsultationDetails(List<int> ids)
        {
    	   var query = from q in _context.XMConsultationDetails
                    where ids.Contains(q.id)
                    select q;
            var xmconsultationdetailss = query.ToList();
            foreach (var item in xmconsultationdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMConsultationDetails.Attach(item);  
    
                _context.XMConsultationDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
