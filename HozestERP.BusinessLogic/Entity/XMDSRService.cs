
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
    public partial class XMDSRService: IXMDSRService
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
    	public XMDSRService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMDSRService成员
        /// <summary>
        /// Insert into XMDSR
        /// </summary>
        /// <param name="xmdsr">XMDSR</param>
    	public void InsertXMDSR(XMDSR xmdsr)
    	{	
            if (xmdsr == null)
                return;
    
            if (!this._context.IsAttached(xmdsr))
    			
                this._context.XMDSRs.AddObject(xmdsr);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMDSR
        /// </summary>
        /// <param name="xmdsr">XMDSR</param>
        public void UpdateXMDSR(XMDSR xmdsr)
        {
            if (xmdsr == null)
                return;
    
            if (this._context.IsAttached(xmdsr))
                this._context.XMDSRs.Attach(xmdsr);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMDSR list
        /// </summary>
        public List<XMDSR> GetXMDSRList()
        {		
            var query = from p in this._context.XMDSRs
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMDSR Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDSR Page List</returns>
        public PagedList<XMDSR> SearchXMDSR(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMDSRs
                        orderby p.ID
                        select p;
            return new PagedList<XMDSR>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMDSR by ID
        /// </summary>
        /// <param name="id">XMDSR ID</param>
        /// <returns>XMDSR</returns>   
        public XMDSR GetXMDSRByID(int id)
        {
            var query = from p in this._context.XMDSRs
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMDSR by ID
        /// </summary>
        /// <param name="ID">XMDSR ID</param>
        public void DeleteXMDSR(int id)
        {
            var xmdsr = this.GetXMDSRByID(id);
            if (xmdsr == null)
                return;
    
            if (!this._context.IsAttached(xmdsr))
                this._context.XMDSRs.Attach(xmdsr);
    
            this._context.DeleteObject(xmdsr);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMDSR by ID
        /// </summary>
        /// <param name="IDs">XMDSR ID</param>
        public void BatchDeleteXMDSR(List<int> ids)
        {
    	   var query = from q in _context.XMDSRs
                    where ids.Contains(q.ID)
                    select q;
            var xmdsrs = query.ToList();
            foreach (var item in xmdsrs)
            {
                if (!_context.IsAttached(item))
                    _context.XMDSRs.Attach(item);  
    
                _context.XMDSRs.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
