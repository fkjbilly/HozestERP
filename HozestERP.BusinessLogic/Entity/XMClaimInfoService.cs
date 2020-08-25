
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
    public partial class XMClaimInfoService: IXMClaimInfoService
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
    	public XMClaimInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMClaimInfoService成员
        /// <summary>
        /// Insert into XMClaimInfo
        /// </summary>
        /// <param name="xmclaiminfo">XMClaimInfo</param>
    	public void InsertXMClaimInfo(XMClaimInfo xmclaiminfo)
    	{	
            if (xmclaiminfo == null)
                return;
    
            if (!this._context.IsAttached(xmclaiminfo))
    			
                this._context.XMClaimInfoes.AddObject(xmclaiminfo);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMClaimInfo
        /// </summary>
        /// <param name="xmclaiminfo">XMClaimInfo</param>
        public void UpdateXMClaimInfo(XMClaimInfo xmclaiminfo)
        {
            if (xmclaiminfo == null)
                return;
    
            if (this._context.IsAttached(xmclaiminfo))
                this._context.XMClaimInfoes.Attach(xmclaiminfo);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMClaimInfo list
        /// </summary>
        public List<XMClaimInfo> GetXMClaimInfoList()
        {		
            var query = from p in this._context.XMClaimInfoes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMClaimInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMClaimInfo Page List</returns>
        public PagedList<XMClaimInfo> SearchXMClaimInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMClaimInfoes
                        orderby p.Id
                        select p;
            return new PagedList<XMClaimInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMClaimInfo by Id
        /// </summary>
        /// <param name="id">XMClaimInfo Id</param>
        /// <returns>XMClaimInfo</returns>   
        public XMClaimInfo GetXMClaimInfoById(int id)
        {
            var query = from p in this._context.XMClaimInfoes
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMClaimInfo by Id
        /// </summary>
        /// <param name="Id">XMClaimInfo Id</param>
        public void DeleteXMClaimInfo(int id)
        {
            var xmclaiminfo = this.GetXMClaimInfoById(id);
            if (xmclaiminfo == null)
                return;
    
            if (!this._context.IsAttached(xmclaiminfo))
                this._context.XMClaimInfoes.Attach(xmclaiminfo);
    
            this._context.DeleteObject(xmclaiminfo);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMClaimInfo by Id
        /// </summary>
        /// <param name="Ids">XMClaimInfo Id</param>
        public void BatchDeleteXMClaimInfo(List<int> ids)
        {
    	   var query = from q in _context.XMClaimInfoes
                    where ids.Contains(q.Id)
                    select q;
            var xmclaiminfos = query.ToList();
            foreach (var item in xmclaiminfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMClaimInfoes.Attach(item);  
    
                _context.XMClaimInfoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
