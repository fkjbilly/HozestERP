
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-08-01 14:09:38
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMLogisticsFeeDetailService: IXMLogisticsFeeDetailService
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
    	public XMLogisticsFeeDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion

    	
        #region IXMLogisticsFeeDetailService成员
        /// <summary>
        /// Insert into XMLogisticsFeeDetail
        /// </summary>
        /// <param name="xmlogisticsfeedetail">XMLogisticsFeeDetail</param>
    	public void InsertXMLogisticsFeeDetail(XMLogisticsFeeDetail xmlogisticsfeedetail)
    	{	
            if (xmlogisticsfeedetail == null)
                return;
    
            if (!this._context.IsAttached(xmlogisticsfeedetail))
    			
                this._context.XMLogisticsFeeDetails.AddObject(xmlogisticsfeedetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMLogisticsFeeDetail
        /// </summary>
        /// <param name="xmlogisticsfeedetail">XMLogisticsFeeDetail</param>
        public void UpdateXMLogisticsFeeDetail(XMLogisticsFeeDetail xmlogisticsfeedetail)
        {
            if (xmlogisticsfeedetail == null)
                return;
    
            if (this._context.IsAttached(xmlogisticsfeedetail))
                this._context.XMLogisticsFeeDetails.Attach(xmlogisticsfeedetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMLogisticsFeeDetail list
        /// </summary>
        public IQueryable<XMLogisticsFeeDetail> GetXMLogisticsFeeDetailList(int OrderID)
        {		
            var query = from p in this._context.XMLogisticsFeeDetails
                        where p.OrderID== OrderID
                        select p;
            return query;
        }
    
    	
        /// <summary>
        /// get to XMLogisticsFeeDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMLogisticsFeeDetail Page List</returns>
        public PagedList<XMLogisticsFeeDetail> SearchXMLogisticsFeeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMLogisticsFeeDetails
                        orderby p.ID
                        select p;
            return new PagedList<XMLogisticsFeeDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMLogisticsFeeDetail by ID
        /// </summary>
        /// <param name="id">XMLogisticsFeeDetail ID</param>
        /// <returns>XMLogisticsFeeDetail</returns>   
        public XMLogisticsFeeDetail GetXMLogisticsFeeDetailByID(int id)
        {
            var query = from p in this._context.XMLogisticsFeeDetails
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMLogisticsFeeDetail by ID
        /// </summary>
        /// <param name="ID">XMLogisticsFeeDetail ID</param>
        public void DeleteXMLogisticsFeeDetail(int id)
        {
            var xmlogisticsfeedetail = this.GetXMLogisticsFeeDetailByID(id);
            if (xmlogisticsfeedetail == null)
                return;
    
            if (!this._context.IsAttached(xmlogisticsfeedetail))
                this._context.XMLogisticsFeeDetails.Attach(xmlogisticsfeedetail);
    
            this._context.DeleteObject(xmlogisticsfeedetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMLogisticsFeeDetail by ID
        /// </summary>
        /// <param name="IDs">XMLogisticsFeeDetail ID</param>
        public void BatchDeleteXMLogisticsFeeDetail(List<int> ids)
        {
    	   var query = from q in _context.XMLogisticsFeeDetails
                    where ids.Contains(q.ID)
                    select q;
            var xmlogisticsfeedetails = query.ToList();
            foreach (var item in xmlogisticsfeedetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMLogisticsFeeDetails.Attach(item);  
    
                _context.XMLogisticsFeeDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        public List<XMLogisticsFeeDetail> getList(Expression<Func<XMLogisticsFeeDetail, bool>> predicate)
        {
            List<XMLogisticsFeeDetail> list = _context.XMLogisticsFeeDetails.Where(predicate).ToList();
            return list;
        }

        public void delete(XMLogisticsFeeDetail entity)
        {
            _context.XMLogisticsFeeDetails.DeleteObject(entity);
            _context.SaveChanges();
        }

        public decimal getLogisticsFeeTotal(int orderID)
        {
            decimal fee = 0;
            IQueryable<XMLogisticsFeeDetail> query = _context.XMLogisticsFeeDetails.Where(a => a.OrderID == orderID);
            if(query.Count()>0)
            {
                fee = (decimal)query.Sum(a => a.Fee);
            }
            return fee;
        }
        #endregion

    }
}
