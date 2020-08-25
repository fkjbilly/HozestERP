
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
    public partial class XMPdInfoService: IXMPdInfoService
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
    	public XMPdInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMPdInfoService成员
        /// <summary>
        /// Insert into XMPdInfo
        /// </summary>
        /// <param name="xmpdinfo">XMPdInfo</param>
    	public void InsertXMPdInfo(XMPdInfo xmpdinfo)
    	{	
            if (xmpdinfo == null)
                return;
    
            if (!this._context.IsAttached(xmpdinfo))
    			
                this._context.XMPdInfoes.AddObject(xmpdinfo);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMPdInfo
        /// </summary>
        /// <param name="xmpdinfo">XMPdInfo</param>
        public void UpdateXMPdInfo(XMPdInfo xmpdinfo)
        {
            if (xmpdinfo == null)
                return;
    
            if (this._context.IsAttached(xmpdinfo))
                this._context.XMPdInfoes.Attach(xmpdinfo);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMPdInfo list
        /// </summary>
        public List<XMPdInfo> GetXMPdInfoList()
        {		
            var query = from p in this._context.XMPdInfoes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMPdInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPdInfo Page List</returns>
        public PagedList<XMPdInfo> SearchXMPdInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPdInfoes
                        orderby p.Id
                        select p;
            return new PagedList<XMPdInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMPdInfo by Id
        /// </summary>
        /// <param name="id">XMPdInfo Id</param>
        /// <returns>XMPdInfo</returns>   
        public XMPdInfo GetXMPdInfoById(int id)
        {
            var query = from p in this._context.XMPdInfoes
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMPdInfo by Id
        /// </summary>
        /// <param name="Id">XMPdInfo Id</param>
        public void DeleteXMPdInfo(int id)
        {
            var xmpdinfo = this.GetXMPdInfoById(id);
            if (xmpdinfo == null)
                return;
    
            if (!this._context.IsAttached(xmpdinfo))
                this._context.XMPdInfoes.Attach(xmpdinfo);
    
            this._context.DeleteObject(xmpdinfo);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMPdInfo by Id
        /// </summary>
        /// <param name="Ids">XMPdInfo Id</param>
        public void BatchDeleteXMPdInfo(List<int> ids)
        {
    	   var query = from q in _context.XMPdInfoes
                    where ids.Contains(q.Id)
                    select q;
            var xmpdinfos = query.ToList();
            foreach (var item in xmpdinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMPdInfoes.Attach(item);  
    
                _context.XMPdInfoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
