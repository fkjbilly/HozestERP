
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2018-04-02 15:26:25
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMLogisticsCostService: IXMLogisticsCostService
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
    	public XMLogisticsCostService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion

    	
        #region IXMLogisticsCostService成员
        /// <summary>
        /// Insert into XMLogisticsCost
        /// </summary>
        /// <param name="xmlogisticscost">XMLogisticsCost</param>
    	public void InsertXMLogisticsCost(XMLogisticsCost xmlogisticscost)
    	{	
            if (xmlogisticscost == null)
                return;
    
            if (!this._context.IsAttached(xmlogisticscost))
    			
                this._context.XMLogisticsCosts.AddObject(xmlogisticscost);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMLogisticsCost
        /// </summary>
        /// <param name="xmlogisticscost">XMLogisticsCost</param>
        public void UpdateXMLogisticsCost(XMLogisticsCost xmlogisticscost)
        {
            if (xmlogisticscost == null)
                return;
    
            if (this._context.IsAttached(xmlogisticscost))
                this._context.XMLogisticsCosts.Attach(xmlogisticscost);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMLogisticsCost list
        /// </summary>
        public List<XMLogisticsCost> GetXMLogisticsCostList()
        {		
            var query = from p in this._context.XMLogisticsCosts
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMLogisticsCost Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMLogisticsCost Page List</returns>
        public PagedList<XMLogisticsCost> SearchXMLogisticsCost(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMLogisticsCosts
                        orderby p.ID
                        select p;
            return new PagedList<XMLogisticsCost>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMLogisticsCost by ID
        /// </summary>
        /// <param name="id">XMLogisticsCost ID</param>
        /// <returns>XMLogisticsCost</returns>   
        public XMLogisticsCost GetXMLogisticsCostByID(int id)
        {
            var query = from p in this._context.XMLogisticsCosts
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public XMLogisticsCost GetXMLogisticsCostByLogisticsNumber(string logisticsNumber)
        {
            var query = from p in this._context.XMLogisticsCosts
                        where p.LogisticsNumber== logisticsNumber
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMLogisticsCost by ID
        /// </summary>
        /// <param name="ID">XMLogisticsCost ID</param>
        public void DeleteXMLogisticsCost(int id)
        {
            var xmlogisticscost = this.GetXMLogisticsCostByID(id);
            if (xmlogisticscost == null)
                return;
    
            if (!this._context.IsAttached(xmlogisticscost))
                this._context.XMLogisticsCosts.Attach(xmlogisticscost);
    
            this._context.DeleteObject(xmlogisticscost);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMLogisticsCost by ID
        /// </summary>
        /// <param name="IDs">XMLogisticsCost ID</param>
        public void BatchDeleteXMLogisticsCost(List<int> ids)
        {
    	   var query = from q in _context.XMLogisticsCosts
                    where ids.Contains(q.ID)
                    select q;
            var xmlogisticscosts = query.ToList();
            foreach (var item in xmlogisticscosts)
            {
                if (!_context.IsAttached(item))
                    _context.XMLogisticsCosts.Attach(item);  
    
                _context.XMLogisticsCosts.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion

    }
}
