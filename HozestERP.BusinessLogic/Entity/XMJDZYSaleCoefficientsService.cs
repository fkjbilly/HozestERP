
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
    public partial class XMJDZYSaleCoefficientsService: IXMJDZYSaleCoefficientsService
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
    	public XMJDZYSaleCoefficientsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMJDZYSaleCoefficientsService成员
        /// <summary>
        /// Insert into XMJDZYSaleCoefficients
        /// </summary>
        /// <param name="xmjdzysalecoefficients">XMJDZYSaleCoefficients</param>
    	public void InsertXMJDZYSaleCoefficients(XMJDZYSaleCoefficients xmjdzysalecoefficients)
    	{	
            if (xmjdzysalecoefficients == null)
                return;
    
            if (!this._context.IsAttached(xmjdzysalecoefficients))
    			
                this._context.XMJDZYSaleCoefficients.AddObject(xmjdzysalecoefficients);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMJDZYSaleCoefficients
        /// </summary>
        /// <param name="xmjdzysalecoefficients">XMJDZYSaleCoefficients</param>
        public void UpdateXMJDZYSaleCoefficients(XMJDZYSaleCoefficients xmjdzysalecoefficients)
        {
            if (xmjdzysalecoefficients == null)
                return;
    
            if (this._context.IsAttached(xmjdzysalecoefficients))
                this._context.XMJDZYSaleCoefficients.Attach(xmjdzysalecoefficients);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMJDZYSaleCoefficients list
        /// </summary>
        public List<XMJDZYSaleCoefficients> GetXMJDZYSaleCoefficientsList()
        {		
            var query = from p in this._context.XMJDZYSaleCoefficients
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMJDZYSaleCoefficients Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMJDZYSaleCoefficients Page List</returns>
        public PagedList<XMJDZYSaleCoefficients> SearchXMJDZYSaleCoefficients(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMJDZYSaleCoefficients
                        orderby p.Id
                        select p;
            return new PagedList<XMJDZYSaleCoefficients>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMJDZYSaleCoefficients by Id
        /// </summary>
        /// <param name="id">XMJDZYSaleCoefficients Id</param>
        /// <returns>XMJDZYSaleCoefficients</returns>   
        public XMJDZYSaleCoefficients GetXMJDZYSaleCoefficientsById(int id)
        {
            var query = from p in this._context.XMJDZYSaleCoefficients
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMJDZYSaleCoefficients by Id
        /// </summary>
        /// <param name="Id">XMJDZYSaleCoefficients Id</param>
        public void DeleteXMJDZYSaleCoefficients(int id)
        {
            var xmjdzysalecoefficients = this.GetXMJDZYSaleCoefficientsById(id);
            if (xmjdzysalecoefficients == null)
                return;
    
            if (!this._context.IsAttached(xmjdzysalecoefficients))
                this._context.XMJDZYSaleCoefficients.Attach(xmjdzysalecoefficients);
    
            this._context.DeleteObject(xmjdzysalecoefficients);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMJDZYSaleCoefficients by Id
        /// </summary>
        /// <param name="Ids">XMJDZYSaleCoefficients Id</param>
        public void BatchDeleteXMJDZYSaleCoefficients(List<int> ids)
        {
    	   var query = from q in _context.XMJDZYSaleCoefficients
                    where ids.Contains(q.Id)
                    select q;
            var xmjdzysalecoefficientss = query.ToList();
            foreach (var item in xmjdzysalecoefficientss)
            {
                if (!_context.IsAttached(item))
                    _context.XMJDZYSaleCoefficients.Attach(item);  
    
                _context.XMJDZYSaleCoefficients.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
