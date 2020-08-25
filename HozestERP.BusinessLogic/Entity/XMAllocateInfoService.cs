
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
    public partial class XMAllocateInfoService: IXMAllocateInfoService
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
    	public XMAllocateInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMAllocateInfoService成员
        /// <summary>
        /// Insert into XMAllocateInfo
        /// </summary>
        /// <param name="xmallocateinfo">XMAllocateInfo</param>
    	public void InsertXMAllocateInfo(XMAllocateInfo xmallocateinfo)
    	{	
            if (xmallocateinfo == null)
                return;
    
            if (!this._context.IsAttached(xmallocateinfo))
    			
                this._context.XMAllocateInfoes.AddObject(xmallocateinfo);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMAllocateInfo
        /// </summary>
        /// <param name="xmallocateinfo">XMAllocateInfo</param>
        public void UpdateXMAllocateInfo(XMAllocateInfo xmallocateinfo)
        {
            if (xmallocateinfo == null)
                return;
    
            if (this._context.IsAttached(xmallocateinfo))
                this._context.XMAllocateInfoes.Attach(xmallocateinfo);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMAllocateInfo list
        /// </summary>
        public List<XMAllocateInfo> GetXMAllocateInfoList()
        {		
            var query = from p in this._context.XMAllocateInfoes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMAllocateInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAllocateInfo Page List</returns>
        public PagedList<XMAllocateInfo> SearchXMAllocateInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAllocateInfoes
                        orderby p.Id
                        select p;
            return new PagedList<XMAllocateInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMAllocateInfo by Id
        /// </summary>
        /// <param name="id">XMAllocateInfo Id</param>
        /// <returns>XMAllocateInfo</returns>   
        public XMAllocateInfo GetXMAllocateInfoById(int id)
        {
            var query = from p in this._context.XMAllocateInfoes
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMAllocateInfo by Id
        /// </summary>
        /// <param name="Id">XMAllocateInfo Id</param>
        public void DeleteXMAllocateInfo(int id)
        {
            var xmallocateinfo = this.GetXMAllocateInfoById(id);
            if (xmallocateinfo == null)
                return;
    
            if (!this._context.IsAttached(xmallocateinfo))
                this._context.XMAllocateInfoes.Attach(xmallocateinfo);
    
            this._context.DeleteObject(xmallocateinfo);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMAllocateInfo by Id
        /// </summary>
        /// <param name="Ids">XMAllocateInfo Id</param>
        public void BatchDeleteXMAllocateInfo(List<int> ids)
        {
    	   var query = from q in _context.XMAllocateInfoes
                    where ids.Contains(q.Id)
                    select q;
            var xmallocateinfos = query.ToList();
            foreach (var item in xmallocateinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMAllocateInfoes.Attach(item);  
    
                _context.XMAllocateInfoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
