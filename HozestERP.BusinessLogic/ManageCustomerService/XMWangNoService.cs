
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-05-28 15:13:50
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
    public partial class XMWangNoService: IXMWangNoService
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
    	public XMWangNoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMWangNoService成员
        /// <summary>
        /// Insert into XMWangNo
        /// </summary>
        /// <param name="xmwangno">XMWangNo</param>
    	public void InsertXMWangNo(XMWangNo xmwangno)
    	{	
            if (xmwangno == null)
                return;
    
            if (!this._context.IsAttached(xmwangno))
    			
                this._context.XMWangNoes.AddObject(xmwangno);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMWangNo
        /// </summary>
        /// <param name="xmwangno">XMWangNo</param>
        public void UpdateXMWangNo(XMWangNo xmwangno)
        {
            if (xmwangno == null)
                return;
    
            if (this._context.IsAttached(xmwangno))
                this._context.XMWangNoes.Attach(xmwangno);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMWangNo list
        /// </summary>
        public List<XMWangNo> GetXMWangNoList(int ddlNickId, int ProjectTypeId, string WangNo)
        {		
            var query = from p in this._context.XMWangNoes
                        where (p.NickId == ddlNickId || ddlNickId == -1) && (p.PlatfromTypeId == ProjectTypeId || ProjectTypeId == -1) && p.IsEnabled == false &&(p.WangNo == WangNo || WangNo=="")
                        orderby p.CreateTime descending
                        select p;
            return query.ToList();
        }

        public List<XMPreSalesSalary> GetWangNoPreList(int CustomerID, DateTime beginDate, DateTime endDate, List<string> RefundStatus)
        {
            var RankList = from p in this._context.XMCustomerWangNoes
                           join Rank in this._context.XMWangNoes
                           on p.WangNoID equals Rank.ID
                           where p.IsEnabled == false
                           && Rank.IsEnabled == false
                           && p.CustomerID == CustomerID
                           select new
                           {
                               CustomerID = p.CustomerID,
                               WangNoID = p.WangNoID,
                               WangNo = Rank.WangNo,
                               PlatformTypeId = Rank.PlatfromTypeId
                           };
            var query = from p in this._context.XMOrderInfoes
                        join rankList in RankList
                        on p.BelongsServiceId equals rankList.WangNoID
                        where p.PayDate >= beginDate && p.PayDate < endDate && p.IsScalping!=true
                        && !RefundStatus.Contains(p.OrderStatus)
                        orderby rankList.WangNoID descending
                        select new XMPreSalesSalary 
                        {
                            CustomerID = rankList.CustomerID,
                            PlatformTypeId = rankList.PlatformTypeId,
                            PayPrice = p.PayPrice,
                            WangNo = rankList.WangNo
                        };
            return query.ToList();
        }

        public List<XMPreSalesSalary> GetTotalClickFarmingList(int CustomerID, DateTime beginDate, DateTime endDate, List<string> RefundStatus)
        {
            var RankList = from p in this._context.XMCustomerWangNoes
                           join Rank in this._context.XMWangNoes
                           on p.WangNoID equals Rank.ID
                           where p.IsEnabled == false && Rank.IsEnabled == false
                           select new
                           {
                               CustomerID = p.CustomerID,
                               WangNoID = p.WangNoID,
                               WangNo = Rank.WangNo,
                               PlatformTypeId = Rank.PlatfromTypeId
                           };
            var query = from p in this._context.XMOrderInfoes
                        join rankList in RankList
                        on p.BelongsServiceId equals rankList.WangNoID
                        where p.PayDate >= beginDate && p.PayDate < endDate && rankList.CustomerID == CustomerID && p.IsScalping == true
                        orderby rankList.CustomerID descending
                        select new XMPreSalesSalary
                        {
                            CustomerID = rankList.CustomerID,
                            PlatformTypeId = rankList.PlatformTypeId,
                            PayPrice = p.PayPrice,
                            WangNo = rankList.WangNo
                        };
            return query.ToList();
        }

        public List<XMPreSalesSalary> GetTotalRefundList(int CustomerID, DateTime beginDate, DateTime endDate, List<string> RefundStatus)
        {
            var RankList = from p in this._context.XMCustomerWangNoes
                           join Rank in this._context.XMWangNoes
                           on p.WangNoID equals Rank.ID
                           where p.IsEnabled == false && Rank.IsEnabled == false
                           select new
                           {
                               CustomerID = p.CustomerID,
                               WangNoID = p.WangNoID,
                               WangNo = Rank.WangNo,
                               PlatformTypeId = Rank.PlatfromTypeId
                           };
            var query = from p in this._context.XMOrderInfoes
                        join rankList in RankList
                        on p.BelongsServiceId equals rankList.WangNoID
                        where p.PayDate >= beginDate && p.PayDate < endDate && rankList.CustomerID == CustomerID && p.IsScalping != true
                        && RefundStatus.Contains(p.OrderStatus)
                        orderby rankList.CustomerID descending
                        select new XMPreSalesSalary
                        {
                            CustomerID = rankList.CustomerID,
                            PlatformTypeId = rankList.PlatformTypeId,
                            PayPrice = p.PayPrice,
                            WangNo = rankList.WangNo
                        };
            return query.ToList();
        }

        /// <summary>
        /// get to XMWangNo list
        /// </summary>
        public List<XMWangNo> GetXMCustomerWangNoList(int CustomerID)
        {
            var query = from p in this._context.XMWangNoes
                        join customerWangNoes in this._context.XMCustomerWangNoes
                            on p.ID equals customerWangNoes.WangNoID
                        where p.IsEnabled == false && customerWangNoes.IsEnabled == false && customerWangNoes.CustomerID == CustomerID
                        orderby p.WangNo
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMWangNo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMWangNo Page List</returns>
        public PagedList<XMWangNo> SearchXMWangNo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMWangNoes
                        orderby p.ID
                        select p;
            return new PagedList<XMWangNo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMWangNo by ID
        /// </summary>
        /// <param name="id">XMWangNo ID</param>
        /// <returns>XMWangNo</returns>   
        public XMWangNo GetXMWangNoByID(int id)
        {
            var query = from p in this._context.XMWangNoes
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public XMWangNo GetXMWangNoByName(string name)
        {
            var query = from p in this._context.XMWangNoes
                        where p.WangNo.Equals(name) && p.IsEnabled == false
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMWangNo by ID
        /// </summary>
        /// <param name="ID">XMWangNo ID</param>
        public void DeleteXMWangNo(int id)
        {
            var xmwangno = this.GetXMWangNoByID(id);
            if (xmwangno == null)
                return;
    
            if (!this._context.IsAttached(xmwangno))
                this._context.XMWangNoes.Attach(xmwangno);
    
            this._context.DeleteObject(xmwangno);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMWangNo by ID
        /// </summary>
        /// <param name="IDs">XMWangNo ID</param>
        public void BatchDeleteXMWangNo(List<int> ids)
        {
    	   var query = from q in _context.XMWangNoes
                    where ids.Contains(q.ID)
                    select q;
            var xmwangnos = query.ToList();
            foreach (var item in xmwangnos)
            {
                if (!_context.IsAttached(item))
                    _context.XMWangNoes.Attach(item);  
    
                _context.XMWangNoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
