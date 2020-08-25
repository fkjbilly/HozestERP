
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
    public partial class XMAdjustedInfoService: IXMAdjustedInfoService
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
    	public XMAdjustedInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMAdjustedInfoService成员
        /// <summary>
        /// Insert into XMAdjustedInfo
        /// </summary>
        /// <param name="xmadjustedinfo">XMAdjustedInfo</param>
    	public void InsertXMAdjustedInfo(XMAdjustedInfo xmadjustedinfo)
    	{	
            if (xmadjustedinfo == null)
                return;
    
            if (!this._context.IsAttached(xmadjustedinfo))
    			
                this._context.XMAdjustedInfoes.AddObject(xmadjustedinfo);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMAdjustedInfo
        /// </summary>
        /// <param name="xmadjustedinfo">XMAdjustedInfo</param>
        public void UpdateXMAdjustedInfo(XMAdjustedInfo xmadjustedinfo)
        {
            if (xmadjustedinfo == null)
                return;
    
            if (this._context.IsAttached(xmadjustedinfo))
                this._context.XMAdjustedInfoes.Attach(xmadjustedinfo);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMAdjustedInfo list
        /// </summary>
        public List<XMAdjustedInfo> GetXMAdjustedInfoList()
        {		
            var query = from p in this._context.XMAdjustedInfoes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMAdjustedInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAdjustedInfo Page List</returns>
        public PagedList<XMAdjustedInfo> SearchXMAdjustedInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAdjustedInfoes
                        orderby p.Id
                        select p;
            return new PagedList<XMAdjustedInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMAdjustedInfo by Id
        /// </summary>
        /// <param name="id">XMAdjustedInfo Id</param>
        /// <returns>XMAdjustedInfo</returns>   
        public XMAdjustedInfo GetXMAdjustedInfoById(int id)
        {
            var query = from p in this._context.XMAdjustedInfoes
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMAdjustedInfo by Id
        /// </summary>
        /// <param name="Id">XMAdjustedInfo Id</param>
        public void DeleteXMAdjustedInfo(int id)
        {
            var xmadjustedinfo = this.GetXMAdjustedInfoById(id);
            if (xmadjustedinfo == null)
                return;
    
            if (!this._context.IsAttached(xmadjustedinfo))
                this._context.XMAdjustedInfoes.Attach(xmadjustedinfo);
    
            this._context.DeleteObject(xmadjustedinfo);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMAdjustedInfo by Id
        /// </summary>
        /// <param name="Ids">XMAdjustedInfo Id</param>
        public void BatchDeleteXMAdjustedInfo(List<int> ids)
        {
    	   var query = from q in _context.XMAdjustedInfoes
                    where ids.Contains(q.Id)
                    select q;
            var xmadjustedinfos = query.ToList();
            foreach (var item in xmadjustedinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMAdjustedInfoes.Attach(item);  
    
                _context.XMAdjustedInfoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
