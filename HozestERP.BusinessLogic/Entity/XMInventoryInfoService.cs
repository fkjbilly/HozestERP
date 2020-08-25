
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
    public partial class XMInventoryInfoService: IXMInventoryInfoService
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
    	public XMInventoryInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMInventoryInfoService成员
        /// <summary>
        /// Insert into XMInventoryInfo
        /// </summary>
        /// <param name="xminventoryinfo">XMInventoryInfo</param>
    	public void InsertXMInventoryInfo(XMInventoryInfo xminventoryinfo)
    	{	
            if (xminventoryinfo == null)
                return;
    
            if (!this._context.IsAttached(xminventoryinfo))
    			
                this._context.XMInventoryInfoes.AddObject(xminventoryinfo);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMInventoryInfo
        /// </summary>
        /// <param name="xminventoryinfo">XMInventoryInfo</param>
        public void UpdateXMInventoryInfo(XMInventoryInfo xminventoryinfo)
        {
            if (xminventoryinfo == null)
                return;
    
            if (this._context.IsAttached(xminventoryinfo))
                this._context.XMInventoryInfoes.Attach(xminventoryinfo);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMInventoryInfo list
        /// </summary>
        public List<XMInventoryInfo> GetXMInventoryInfoList()
        {		
            var query = from p in this._context.XMInventoryInfoes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMInventoryInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInventoryInfo Page List</returns>
        public PagedList<XMInventoryInfo> SearchXMInventoryInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInventoryInfoes
                        orderby p.Id
                        select p;
            return new PagedList<XMInventoryInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMInventoryInfo by Id
        /// </summary>
        /// <param name="id">XMInventoryInfo Id</param>
        /// <returns>XMInventoryInfo</returns>   
        public XMInventoryInfo GetXMInventoryInfoById(int id)
        {
            var query = from p in this._context.XMInventoryInfoes
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMInventoryInfo by Id
        /// </summary>
        /// <param name="Id">XMInventoryInfo Id</param>
        public void DeleteXMInventoryInfo(int id)
        {
            var xminventoryinfo = this.GetXMInventoryInfoById(id);
            if (xminventoryinfo == null)
                return;
    
            if (!this._context.IsAttached(xminventoryinfo))
                this._context.XMInventoryInfoes.Attach(xminventoryinfo);
    
            this._context.DeleteObject(xminventoryinfo);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMInventoryInfo by Id
        /// </summary>
        /// <param name="Ids">XMInventoryInfo Id</param>
        public void BatchDeleteXMInventoryInfo(List<int> ids)
        {
    	   var query = from q in _context.XMInventoryInfoes
                    where ids.Contains(q.Id)
                    select q;
            var xminventoryinfos = query.ToList();
            foreach (var item in xminventoryinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMInventoryInfoes.Attach(item);  
    
                _context.XMInventoryInfoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
