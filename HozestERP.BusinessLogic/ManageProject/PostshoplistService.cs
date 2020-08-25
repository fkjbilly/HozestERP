
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-06-19 09:09:59
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
    public partial class PostshoplistService: IPostshoplistService
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
    	public PostshoplistService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IPostshoplistService成员
        /// <summary>
        /// Insert into Postshoplist
        /// </summary>
        /// <param name="postshoplist">Postshoplist</param>
    	public void InsertPostshoplist(Postshoplist postshoplist)
    	{	
            if (postshoplist == null)
                return;
    
            if (!this._context.IsAttached(postshoplist))
    			
                this._context.Postshoplists.AddObject(postshoplist);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Postshoplist
        /// </summary>
        /// <param name="postshoplist">Postshoplist</param>
        public void UpdatePostshoplist(Postshoplist postshoplist)
        {
            if (postshoplist == null)
                return;
    
            if (this._context.IsAttached(postshoplist))
                this._context.Postshoplists.Attach(postshoplist);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Postshoplist list
        /// </summary>
        public List<Postshoplist> GetPostshoplistList()
        {		
            var query = from p in this._context.Postshoplists
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 查询某个id的店铺管理人员
        /// </summary>
        public List<Postshoplist> XMPostListById(int id)
        {
            //IQueryable<XMPost>
            var query = from p in this._context.Postshoplists
                        where p.IsEnable == false && p.NickId == id
                        select p;

            return new List<Postshoplist>(query).ToList();
        }
    	
        /// <summary>
        /// get to Postshoplist Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Postshoplist Page List</returns>
        public PagedList<Postshoplist> SearchPostshoplist(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Postshoplists
                        orderby p.NickCustomerID
                        select p;
            return new PagedList<Postshoplist>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Postshoplist by NickCustomerID
        /// </summary>
        /// <param name="nickcustomerid">Postshoplist NickCustomerID</param>
        /// <returns>Postshoplist</returns>   
        public Postshoplist GetPostshoplistByNickCustomerID(int nickcustomerid)
        {
            var query = from p in this._context.Postshoplists
                        where p.NickCustomerID.Equals(nickcustomerid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Postshoplist by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerID">Postshoplist NickCustomerID</param>
        public void DeletePostshoplist(int nickcustomerid)
        {
            var postshoplist = this.GetPostshoplistByNickCustomerID(nickcustomerid);
            if (postshoplist == null)
                return;
    
            if (!this._context.IsAttached(postshoplist))
                this._context.Postshoplists.Attach(postshoplist);
    
            this._context.DeleteObject(postshoplist);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Postshoplist by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerIDs">Postshoplist NickCustomerID</param>
        public void BatchDeletePostshoplist(List<int> nickcustomerids)
        {
    	   var query = from q in _context.Postshoplists
                    where nickcustomerids.Contains(q.NickCustomerID)
                    select q;
            var postshoplists = query.ToList();
            foreach (var item in postshoplists)
            {
                if (!_context.IsAttached(item))
                    _context.Postshoplists.Attach(item);  
    
                _context.Postshoplists.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
