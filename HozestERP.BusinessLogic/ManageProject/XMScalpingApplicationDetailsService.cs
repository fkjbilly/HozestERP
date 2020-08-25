
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-31 15:51:21
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
    public partial class XMScalpingApplicationDetailsService: IXMScalpingApplicationDetailsService
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
    	public XMScalpingApplicationDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMScalpingApplicationDetailsService成员
        /// <summary>
        /// Insert into XMScalpingApplicationDetails
        /// </summary>
        /// <param name="xmscalpingapplicationdetails">XMScalpingApplicationDetails</param>
    	public void InsertXMScalpingApplicationDetails(XMScalpingApplicationDetails xmscalpingapplicationdetails)
    	{	
            if (xmscalpingapplicationdetails == null)
                return;
    
            if (!this._context.IsAttached(xmscalpingapplicationdetails))
    			
                this._context.XMScalpingApplicationDetails.AddObject(xmscalpingapplicationdetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMScalpingApplicationDetails
        /// </summary>
        /// <param name="xmscalpingapplicationdetails">XMScalpingApplicationDetails</param>
        public void UpdateXMScalpingApplicationDetails(XMScalpingApplicationDetails xmscalpingapplicationdetails)
        {
            if (xmscalpingapplicationdetails == null)
                return;
    
            if (this._context.IsAttached(xmscalpingapplicationdetails))
                this._context.XMScalpingApplicationDetails.Attach(xmscalpingapplicationdetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMScalpingApplicationDetails list
        /// </summary>
        public List<XMScalpingApplicationDetails> GetXMScalpingApplicationDetailsList()
        {		
            var query = from p in this._context.XMScalpingApplicationDetails
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// 根据刷单主表Id查询明细信息
        /// </summary>
        public List<XMScalpingApplicationDetails> GetXMScalpingApplicationDetailsByScalpingIdList(int ScalpingId)
        {
            var query = from p in this._context.XMScalpingApplicationDetails
                        where p.ScalpingId==ScalpingId
                        && p.IsEnable.Value==false
                        select p;
            return query.ToList();
        }
    	
        /// <summary>
        /// get to XMScalpingApplicationDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMScalpingApplicationDetails Page List</returns>
        public PagedList<XMScalpingApplicationDetails> SearchXMScalpingApplicationDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMScalpingApplicationDetails
                        orderby p.ScalpingDetailsId
                        select p;
            return new PagedList<XMScalpingApplicationDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMScalpingApplicationDetails by ScalpingDetailsId
        /// </summary>
        /// <param name="scalpingdetailsid">XMScalpingApplicationDetails ScalpingDetailsId</param>
        /// <returns>XMScalpingApplicationDetails</returns>   
        public XMScalpingApplicationDetails GetXMScalpingApplicationDetailsByScalpingDetailsId(int scalpingdetailsid)
        {
            var query = from p in this._context.XMScalpingApplicationDetails
                        where p.ScalpingDetailsId.Equals(scalpingdetailsid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMScalpingApplicationDetails by ScalpingDetailsId
        /// </summary>
        /// <param name="ScalpingDetailsId">XMScalpingApplicationDetails ScalpingDetailsId</param>
        public void DeleteXMScalpingApplicationDetails(int scalpingdetailsid)
        {
            var xmscalpingapplicationdetails = this.GetXMScalpingApplicationDetailsByScalpingDetailsId(scalpingdetailsid);
            if (xmscalpingapplicationdetails == null)
                return;
    
            if (!this._context.IsAttached(xmscalpingapplicationdetails))
                this._context.XMScalpingApplicationDetails.Attach(xmscalpingapplicationdetails);
    
            this._context.DeleteObject(xmscalpingapplicationdetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMScalpingApplicationDetails by ScalpingDetailsId
        /// </summary>
        /// <param name="ScalpingDetailsIds">XMScalpingApplicationDetails ScalpingDetailsId</param>
        public void BatchDeleteXMScalpingApplicationDetails(List<int> scalpingdetailsids)
        {
    	   var query = from q in _context.XMScalpingApplicationDetails
                    where scalpingdetailsids.Contains(q.ScalpingDetailsId)
                    select q;
            var xmscalpingapplicationdetailss = query.ToList();
            foreach (var item in xmscalpingapplicationdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMScalpingApplicationDetails.Attach(item);  
    
                _context.XMScalpingApplicationDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
