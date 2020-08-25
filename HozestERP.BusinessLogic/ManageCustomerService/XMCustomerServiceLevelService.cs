
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-05-27 09:22:35
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

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMCustomerServiceLevelService: IXMCustomerServiceLevelService
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
    	public XMCustomerServiceLevelService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMCustomerServiceLevelService成员
        /// <summary>
        /// Insert into XMCustomerServiceLevel
        /// </summary>
        /// <param name="xmcustomerservicelevel">XMCustomerServiceLevel</param>
    	public void InsertXMCustomerServiceLevel(XMCustomerServiceLevel xmcustomerservicelevel)
    	{	
            if (xmcustomerservicelevel == null)
                return;
    
            if (!this._context.IsAttached(xmcustomerservicelevel))
    			
                this._context.XMCustomerServiceLevels.AddObject(xmcustomerservicelevel);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMCustomerServiceLevel
        /// </summary>
        /// <param name="xmcustomerservicelevel">XMCustomerServiceLevel</param>
        public void UpdateXMCustomerServiceLevel(XMCustomerServiceLevel xmcustomerservicelevel)
        {
            if (xmcustomerservicelevel == null)
                return;
    
            if (this._context.IsAttached(xmcustomerservicelevel))
                this._context.XMCustomerServiceLevels.Attach(xmcustomerservicelevel);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMCustomerServiceLevel list
        /// </summary>
        public List<XMCustomerServiceLevel> GetXMCustomerServiceLevelList(string rank_name)
        {
            var query = from p in this._context.XMCustomerServiceLevels
                    where p.IsEnabled == false
                    orderby p.RankNumber
                    select p;
            if (!string.IsNullOrEmpty(rank_name))
            {
                query = from p in query
                            where p.RankName == rank_name
                            orderby p.RankNumber
                            select p;
            }
            return query.ToList();
        }

        public List<Enterprises.Department> GetXMCoustomerServiceGroupList(string DepCode)
        {
            string[] DepList = DepCode.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var query = from p in this._context.Departments
                        where DepList.Contains(p.DepCode)
                        && !p.Deleted
                        select p;
            return query.ToList();
        }
    	
        /// <summary>
        /// get to XMCustomerServiceLevel Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMCustomerServiceLevel Page List</returns>
        public PagedList<XMCustomerServiceLevel> SearchXMCustomerServiceLevel(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMCustomerServiceLevels
                        orderby p.Id
                        select p;
            return new PagedList<XMCustomerServiceLevel>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMCustomerServiceLevel by Id
        /// </summary>
        /// <param name="id">XMCustomerServiceLevel Id</param>
        /// <returns>XMCustomerServiceLevel</returns>   
        public XMCustomerServiceLevel GetXMCustomerServiceLevelById(int id)
        {
            var query = from p in this._context.XMCustomerServiceLevels
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMCustomerServiceLevel by Id
        /// </summary>
        /// <param name="Id">XMCustomerServiceLevel Id</param>
        public void DeleteXMCustomerServiceLevel(int id)
        {
            var xmcustomerservicelevel = this.GetXMCustomerServiceLevelById(id);
            if (xmcustomerservicelevel == null)
                return;
    
            if (!this._context.IsAttached(xmcustomerservicelevel))
                this._context.XMCustomerServiceLevels.Attach(xmcustomerservicelevel);
    
            this._context.DeleteObject(xmcustomerservicelevel);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMCustomerServiceLevel by Id
        /// </summary>
        /// <param name="Ids">XMCustomerServiceLevel Id</param>
        public void BatchDeleteXMCustomerServiceLevel(List<int> ids)
        {
    	   var query = from q in _context.XMCustomerServiceLevels
                    where ids.Contains(q.Id)
                    select q;
            var xmcustomerservicelevels = query.ToList();
            foreach (var item in xmcustomerservicelevels)
            {
                if (!_context.IsAttached(item))
                    _context.XMCustomerServiceLevels.Attach(item);  
    
                _context.XMCustomerServiceLevels.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
