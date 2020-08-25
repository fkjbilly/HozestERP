
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
    public partial class XMInventoryInfoStatisticsService: IXMInventoryInfoStatisticsService
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
    	public XMInventoryInfoStatisticsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMInventoryInfoStatisticsService成员
        /// <summary>
        /// Insert into XMInventoryInfoStatistics
        /// </summary>
        /// <param name="xminventoryinfostatistics">XMInventoryInfoStatistics</param>
    	public void InsertXMInventoryInfoStatistics(XMInventoryInfoStatistics xminventoryinfostatistics)
    	{	
            if (xminventoryinfostatistics == null)
                return;
    
            if (!this._context.IsAttached(xminventoryinfostatistics))
    			
                this._context.XMInventoryInfoStatistics.AddObject(xminventoryinfostatistics);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMInventoryInfoStatistics
        /// </summary>
        /// <param name="xminventoryinfostatistics">XMInventoryInfoStatistics</param>
        public void UpdateXMInventoryInfoStatistics(XMInventoryInfoStatistics xminventoryinfostatistics)
        {
            if (xminventoryinfostatistics == null)
                return;
    
            if (this._context.IsAttached(xminventoryinfostatistics))
                this._context.XMInventoryInfoStatistics.Attach(xminventoryinfostatistics);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMInventoryInfoStatistics list
        /// </summary>
        public List<XMInventoryInfoStatistics> GetXMInventoryInfoStatisticsList()
        {		
            var query = from p in this._context.XMInventoryInfoStatistics
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMInventoryInfoStatistics Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInventoryInfoStatistics Page List</returns>
        public PagedList<XMInventoryInfoStatistics> SearchXMInventoryInfoStatistics(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInventoryInfoStatistics
                        orderby p.Id
                        select p;
            return new PagedList<XMInventoryInfoStatistics>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMInventoryInfoStatistics by Id
        /// </summary>
        /// <param name="id">XMInventoryInfoStatistics Id</param>
        /// <returns>XMInventoryInfoStatistics</returns>   
        public XMInventoryInfoStatistics GetXMInventoryInfoStatisticsById(int id)
        {
            var query = from p in this._context.XMInventoryInfoStatistics
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMInventoryInfoStatistics by Id
        /// </summary>
        /// <param name="Id">XMInventoryInfoStatistics Id</param>
        public void DeleteXMInventoryInfoStatistics(int id)
        {
            var xminventoryinfostatistics = this.GetXMInventoryInfoStatisticsById(id);
            if (xminventoryinfostatistics == null)
                return;
    
            if (!this._context.IsAttached(xminventoryinfostatistics))
                this._context.XMInventoryInfoStatistics.Attach(xminventoryinfostatistics);
    
            this._context.DeleteObject(xminventoryinfostatistics);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMInventoryInfoStatistics by Id
        /// </summary>
        /// <param name="Ids">XMInventoryInfoStatistics Id</param>
        public void BatchDeleteXMInventoryInfoStatistics(List<int> ids)
        {
    	   var query = from q in _context.XMInventoryInfoStatistics
                    where ids.Contains(q.Id)
                    select q;
            var xminventoryinfostatisticss = query.ToList();
            foreach (var item in xminventoryinfostatisticss)
            {
                if (!_context.IsAttached(item))
                    _context.XMInventoryInfoStatistics.Attach(item);  
    
                _context.XMInventoryInfoStatistics.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
