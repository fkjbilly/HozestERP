
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
    public partial class AreaCodeService: IAreaCodeService
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
    	public AreaCodeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IAreaCodeService成员
        /// <summary>
        /// Insert into AreaCode
        /// </summary>
        /// <param name="areacode">AreaCode</param>
    	public void InsertAreaCode(AreaCode areacode)
    	{	
            if (areacode == null)
                return;
    
            if (!this._context.IsAttached(areacode))
    			
                this._context.AreaCodes.AddObject(areacode);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into AreaCode
        /// </summary>
        /// <param name="areacode">AreaCode</param>
        public void UpdateAreaCode(AreaCode areacode)
        {
            if (areacode == null)
                return;
    
            if (this._context.IsAttached(areacode))
                this._context.AreaCodes.Attach(areacode);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to AreaCode list
        /// </summary>
        public List<AreaCode> GetAreaCodeList()
        {		
            var query = from p in this._context.AreaCodes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to AreaCode Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>AreaCode Page List</returns>
        public PagedList<AreaCode> SearchAreaCode(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.AreaCodes
                        orderby p.xmlid
                        select p;
            return new PagedList<AreaCode>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a AreaCode by xmlid
        /// </summary>
        /// <param name="xmlid">AreaCode xmlid</param>
        /// <returns>AreaCode</returns>   
        public AreaCode GetAreaCodeByxmlid(int xmlid)
        {
            var query = from p in this._context.AreaCodes
                        where p.xmlid.Equals(xmlid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete AreaCode by xmlid
        /// </summary>
        /// <param name="xmlid">AreaCode xmlid</param>
        public void DeleteAreaCode(int xmlid)
        {
            var areacode = this.GetAreaCodeByxmlid(xmlid);
            if (areacode == null)
                return;
    
            if (!this._context.IsAttached(areacode))
                this._context.AreaCodes.Attach(areacode);
    
            this._context.DeleteObject(areacode);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete AreaCode by xmlid
        /// </summary>
        /// <param name="xmlids">AreaCode xmlid</param>
        public void BatchDeleteAreaCode(List<int> xmlids)
        {
    	   var query = from q in _context.AreaCodes
                    where xmlids.Contains(q.xmlid)
                    select q;
            var areacodes = query.ToList();
            foreach (var item in areacodes)
            {
                if (!_context.IsAttached(item))
                    _context.AreaCodes.Attach(item);  
    
                _context.AreaCodes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
