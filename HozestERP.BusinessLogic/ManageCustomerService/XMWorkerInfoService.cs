
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2018-01-23 13:30:38
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
using System.Linq.Expressions;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMWorkerInfoService: IXMWorkerInfoService
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
    	public XMWorkerInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion

    	
        #region IXMWorkerInfoService成员
        /// <summary>
        /// Insert into XMWorkerInfo
        /// </summary>
        /// <param name="xmworkerinfo">XMWorkerInfo</param>
    	public void InsertXMWorkerInfo(XMWorkerInfo xmworkerinfo)
    	{	
            if (xmworkerinfo == null)
                return;
    
            if (!this._context.IsAttached(xmworkerinfo))
    			
                this._context.XMWorkerInfoes.AddObject(xmworkerinfo);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMWorkerInfo
        /// </summary>
        /// <param name="xmworkerinfo">XMWorkerInfo</param>
        public void UpdateXMWorkerInfo(XMWorkerInfo xmworkerinfo)
        {
            if (xmworkerinfo == null)
                return;
    
            if (this._context.IsAttached(xmworkerinfo))
                this._context.XMWorkerInfoes.Attach(xmworkerinfo);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMWorkerInfo list
        /// </summary>
        public List<XMWorkerInfo> GetXMWorkerInfoList(string Name, string Province, string City, string Region)
        {		
            var query = from p in this._context.XMWorkerInfoes
                        where p.IsEnable==false
                        &&(Name==""||p.FullName.Contains(Name))
                        &&(Province==""||p.Province.Contains(Province))
                        &&(City==""||p.City.Contains(City))
                        &&(Region==""||p.Regin.Contains(Region))
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMWorkerInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMWorkerInfo Page List</returns>
        public PagedList<XMWorkerInfo> SearchXMWorkerInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMWorkerInfoes
                        orderby p.ID
                        select p;
            return new PagedList<XMWorkerInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMWorkerInfo by ID
        /// </summary>
        /// <param name="id">XMWorkerInfo ID</param>
        /// <returns>XMWorkerInfo</returns>   
        public XMWorkerInfo GetXMWorkerInfoByID(int id)
        {
            var query = from p in this._context.XMWorkerInfoes
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMWorkerInfo by ID
        /// </summary>
        /// <param name="ID">XMWorkerInfo ID</param>
        public void DeleteXMWorkerInfo(int id)
        {
            var xmworkerinfo = this.GetXMWorkerInfoByID(id);
            if (xmworkerinfo == null)
                return;
    
            if (!this._context.IsAttached(xmworkerinfo))
                this._context.XMWorkerInfoes.Attach(xmworkerinfo);
    
            this._context.DeleteObject(xmworkerinfo);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMWorkerInfo by ID
        /// </summary>
        /// <param name="IDs">XMWorkerInfo ID</param>
        public void BatchDeleteXMWorkerInfo(List<int> ids)
        {
    	   var query = from q in _context.XMWorkerInfoes
                    where ids.Contains(q.ID)
                    select q;
            var xmworkerinfos = query.ToList();
            foreach (var item in xmworkerinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMWorkerInfoes.Attach(item);  
    
                _context.XMWorkerInfoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        public XMWorkerInfo getSingle(Expression<Func<XMWorkerInfo, bool>> predicate)
        {
            XMWorkerInfo entity = _context.XMWorkerInfoes.FirstOrDefault(predicate);
            return entity;
        }

        public IQueryable<XMWorkerInfo> getList(Expression<Func<XMWorkerInfo, bool>> predicate)
        {
            IQueryable<XMWorkerInfo> query = _context.XMWorkerInfoes.Where(predicate);
            return query;
        }

        #endregion

    }
}
