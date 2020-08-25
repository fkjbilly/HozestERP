
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
    public partial class XMLogisticsInfoService: IXMLogisticsInfoService
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
    	public XMLogisticsInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMLogisticsInfoService成员
        /// <summary>
        /// Insert into XMLogisticsInfo
        /// </summary>
        /// <param name="xmlogisticsinfo">XMLogisticsInfo</param>
    	public void InsertXMLogisticsInfo(XMLogisticsInfo xmlogisticsinfo)
    	{	
            if (xmlogisticsinfo == null)
                return;
    
            if (!this._context.IsAttached(xmlogisticsinfo))
    			
                this._context.XMLogisticsInfoes.AddObject(xmlogisticsinfo);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMLogisticsInfo
        /// </summary>
        /// <param name="xmlogisticsinfo">XMLogisticsInfo</param>
        public void UpdateXMLogisticsInfo(XMLogisticsInfo xmlogisticsinfo)
        {
            if (xmlogisticsinfo == null)
                return;
    
            if (this._context.IsAttached(xmlogisticsinfo))
                this._context.XMLogisticsInfoes.Attach(xmlogisticsinfo);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMLogisticsInfo list
        /// </summary>
        public List<XMLogisticsInfo> GetXMLogisticsInfoList()
        {		
            var query = from p in this._context.XMLogisticsInfoes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMLogisticsInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMLogisticsInfo Page List</returns>
        public PagedList<XMLogisticsInfo> SearchXMLogisticsInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMLogisticsInfoes
                        orderby p.Id
                        select p;
            return new PagedList<XMLogisticsInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMLogisticsInfo by Id
        /// </summary>
        /// <param name="id">XMLogisticsInfo Id</param>
        /// <returns>XMLogisticsInfo</returns>   
        public XMLogisticsInfo GetXMLogisticsInfoById(int id)
        {
            var query = from p in this._context.XMLogisticsInfoes
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMLogisticsInfo by Id
        /// </summary>
        /// <param name="Id">XMLogisticsInfo Id</param>
        public void DeleteXMLogisticsInfo(int id)
        {
            var xmlogisticsinfo = this.GetXMLogisticsInfoById(id);
            if (xmlogisticsinfo == null)
                return;
    
            if (!this._context.IsAttached(xmlogisticsinfo))
                this._context.XMLogisticsInfoes.Attach(xmlogisticsinfo);
    
            this._context.DeleteObject(xmlogisticsinfo);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMLogisticsInfo by Id
        /// </summary>
        /// <param name="Ids">XMLogisticsInfo Id</param>
        public void BatchDeleteXMLogisticsInfo(List<int> ids)
        {
    	   var query = from q in _context.XMLogisticsInfoes
                    where ids.Contains(q.Id)
                    select q;
            var xmlogisticsinfos = query.ToList();
            foreach (var item in xmlogisticsinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMLogisticsInfoes.Attach(item);  
    
                _context.XMLogisticsInfoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
