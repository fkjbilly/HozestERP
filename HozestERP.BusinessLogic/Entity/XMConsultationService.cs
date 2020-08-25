
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
    public partial class XMConsultationService: IXMConsultationService
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
    	public XMConsultationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMConsultationService成员
        /// <summary>
        /// Insert into XMConsultation
        /// </summary>
        /// <param name="xmconsultation">XMConsultation</param>
    	public void InsertXMConsultation(XMConsultation xmconsultation)
    	{	
            if (xmconsultation == null)
                return;
    
            if (!this._context.IsAttached(xmconsultation))
    			
                this._context.XMConsultations.AddObject(xmconsultation);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMConsultation
        /// </summary>
        /// <param name="xmconsultation">XMConsultation</param>
        public void UpdateXMConsultation(XMConsultation xmconsultation)
        {
            if (xmconsultation == null)
                return;
    
            if (this._context.IsAttached(xmconsultation))
                this._context.XMConsultations.Attach(xmconsultation);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMConsultation list
        /// </summary>
        public List<XMConsultation> GetXMConsultationList()
        {		
            var query = from p in this._context.XMConsultations
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMConsultation Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMConsultation Page List</returns>
        public PagedList<XMConsultation> SearchXMConsultation(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMConsultations
                        orderby p.Id
                        select p;
            return new PagedList<XMConsultation>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMConsultation by Id
        /// </summary>
        /// <param name="id">XMConsultation Id</param>
        /// <returns>XMConsultation</returns>   
        public XMConsultation GetXMConsultationById(int id)
        {
            var query = from p in this._context.XMConsultations
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMConsultation by Id
        /// </summary>
        /// <param name="Id">XMConsultation Id</param>
        public void DeleteXMConsultation(int id)
        {
            var xmconsultation = this.GetXMConsultationById(id);
            if (xmconsultation == null)
                return;
    
            if (!this._context.IsAttached(xmconsultation))
                this._context.XMConsultations.Attach(xmconsultation);
    
            this._context.DeleteObject(xmconsultation);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMConsultation by Id
        /// </summary>
        /// <param name="Ids">XMConsultation Id</param>
        public void BatchDeleteXMConsultation(List<int> ids)
        {
    	   var query = from q in _context.XMConsultations
                    where ids.Contains(q.Id)
                    select q;
            var xmconsultations = query.ToList();
            foreach (var item in xmconsultations)
            {
                if (!_context.IsAttached(item))
                    _context.XMConsultations.Attach(item);  
    
                _context.XMConsultations.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
