
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
    public partial class XMScalpingApplicationService: IXMScalpingApplicationService
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
    	public XMScalpingApplicationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMScalpingApplicationService成员
        /// <summary>
        /// Insert into XMScalpingApplication
        /// </summary>
        /// <param name="xmscalpingapplication">XMScalpingApplication</param>
    	public void InsertXMScalpingApplication(XMScalpingApplication xmscalpingapplication)
    	{	
            if (xmscalpingapplication == null)
                return;
    
            if (!this._context.IsAttached(xmscalpingapplication))
    			
                this._context.XMScalpingApplications.AddObject(xmscalpingapplication);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMScalpingApplication
        /// </summary>
        /// <param name="xmscalpingapplication">XMScalpingApplication</param>
        public void UpdateXMScalpingApplication(XMScalpingApplication xmscalpingapplication)
        {
            if (xmscalpingapplication == null)
                return;
    
            if (this._context.IsAttached(xmscalpingapplication))
                this._context.XMScalpingApplications.Attach(xmscalpingapplication);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMScalpingApplication list
        /// </summary>
        public List<XMScalpingApplication> GetXMScalpingApplicationList()
        {		
            var query = from p in this._context.XMScalpingApplications
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMScalpingApplication Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMScalpingApplication Page List</returns>
        public PagedList<XMScalpingApplication> SearchXMScalpingApplication(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMScalpingApplications
                        orderby p.ScalpingId
                        select p;
            return new PagedList<XMScalpingApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="scalpingid">XMScalpingApplication ScalpingId</param>
        /// <returns>XMScalpingApplication</returns>   
        public XMScalpingApplication GetXMScalpingApplicationByScalpingId(int scalpingid)
        {
            var query = from p in this._context.XMScalpingApplications
                        where p.ScalpingId.Equals(scalpingid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="ScalpingId">XMScalpingApplication ScalpingId</param>
        public void DeleteXMScalpingApplication(int scalpingid)
        {
            var xmscalpingapplication = this.GetXMScalpingApplicationByScalpingId(scalpingid);
            if (xmscalpingapplication == null)
                return;
    
            if (!this._context.IsAttached(xmscalpingapplication))
                this._context.XMScalpingApplications.Attach(xmscalpingapplication);
    
            this._context.DeleteObject(xmscalpingapplication);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="ScalpingIds">XMScalpingApplication ScalpingId</param>
        public void BatchDeleteXMScalpingApplication(List<int> scalpingids)
        {
    	   var query = from q in _context.XMScalpingApplications
                    where scalpingids.Contains(q.ScalpingId)
                    select q;
            var xmscalpingapplications = query.ToList();
            foreach (var item in xmscalpingapplications)
            {
                if (!_context.IsAttached(item))
                    _context.XMScalpingApplications.Attach(item);  
    
                _context.XMScalpingApplications.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
