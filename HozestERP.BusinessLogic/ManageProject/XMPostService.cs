
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-06-17 10:26:28
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
    public partial class XMPostService: IXMPostService
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
    	public XMPostService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMPostService成员
        /// <summary>
        /// Insert into XMPost
        /// </summary>
        /// <param name="xmpost">XMPost</param>
    	public void InsertXMPost(XMPost xmpost)
    	{	
            if (xmpost == null)
                return;
    
            if (!this._context.IsAttached(xmpost))
    			
                this._context.XMPosts.AddObject(xmpost);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMPost
        /// </summary>
        /// <param name="xmpost">XMPost</param>
        public void UpdateXMPost(XMPost xmpost)
        {
            if (xmpost == null)
                return;
    
            if (this._context.IsAttached(xmpost))
                this._context.XMPosts.Attach(xmpost);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMPost list
        /// </summary>
        public List<XMPost> GetXMPostList()
        {		
            var query = from p in this._context.XMPosts
                        where p.IsEnable==false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 查询某个id的店铺管理人员
        /// </summary>
        public List<XMPost> GetXMPostListById(int id)
        {
            //IQueryable<XMPost>
            var query = from p in this._context.XMPosts
                        join s in this._context.XMNickCustomerMappings on p.Id equals s.CustomerTypeID
                        into JoinedPB
                        from s in JoinedPB.DefaultIfEmpty()
                        join b in this._context.CustomerInfoes on s.CustomerID equals b.CustomerID
                        into JoinedPB2
                        from b in JoinedPB2.DefaultIfEmpty()
                        where p.IsEnable == false && s.NickId == id
                        select
            new XMPost
            {
                Post = p.Post,
                FullName = b.FullName,
                Id = s.NickCustomerID
            };

            return new List<XMPost>(query).ToList();
//            string sql = @"select p.Post from XM_Post p 
//                            join XM_Nick_Customer_Mapping N on p.Id=N.CustomerTypeID 
//                            join Sys_CustomerInfo b on N.CustomerID=b.CustomerID 
//                            where p.IsEnable='false' and N.NickId={0} ";
//            var XMPostList = this._context.ExecuteStoreQuery<XMPost>(sql, id).ToList();//, "%" + shopManager + "%"
//            return XMPostList.ToList();
        }
    	
        /// <summary>
        /// get to XMPost Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPost Page List</returns>
        public PagedList<XMPost> SearchXMPost(string post,bool IsEnable,int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPosts
                        where (p.Post.IndexOf(post) != -1 || post=="")
                        && p.IsEnable.Value == IsEnable 
                        orderby p.OrderID,p.Id
                        select p;
            return new PagedList<XMPost>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

    	/// <summary>
        /// get a XMPost by Id
        /// </summary>
        /// <param name="id">XMPost Id</param>
        /// <returns>XMPost</returns>   
        public XMPost GetXMPostById(int id)
        {
            var query = from p in this._context.XMPosts
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMPost by Id
        /// </summary>
        /// <param name="Id">XMPost Id</param>
        public void DeleteXMPost(int id)
        {
            var xmpost = this.GetXMPostById(id);
            if (xmpost == null)
                return;
    
            if (!this._context.IsAttached(xmpost))
                this._context.XMPosts.Attach(xmpost);
    
            this._context.DeleteObject(xmpost);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMPost by Id
        /// </summary>
        /// <param name="Ids">XMPost Id</param>
        public void BatchDeleteXMPost(List<int> ids)
        {
    	   var query = from q in _context.XMPosts
                    where ids.Contains(q.Id)
                    select q;
            var xmposts = query.ToList();
            foreach (var item in xmposts)
            {
                if (!_context.IsAttached(item))
                    _context.XMPosts.Attach(item);  
    
                _context.XMPosts.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
