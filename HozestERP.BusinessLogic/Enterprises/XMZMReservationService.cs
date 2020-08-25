
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-08-03 14:08:18
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

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class XMZMReservationService: IXMZMReservationService
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
    	public XMZMReservationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMZMReservationService成员
        /// <summary>
        /// Insert into XMZMReservation
        /// </summary>
        /// <param name="xmzmreservation">XMZMReservation</param>
    	public void InsertXMZMReservation(XMZMReservation xmzmreservation)
    	{	
            if (xmzmreservation == null)
                return;
    
            if (!this._context.IsAttached(xmzmreservation))
    			
                this._context.XMZMReservations.AddObject(xmzmreservation);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMZMReservation
        /// </summary>
        /// <param name="xmzmreservation">XMZMReservation</param>
        public void UpdateXMZMReservation(XMZMReservation xmzmreservation)
        {
            if (xmzmreservation == null)
                return;
    
            if (this._context.IsAttached(xmzmreservation))
                this._context.XMZMReservations.Attach(xmzmreservation);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMZMReservation list
        /// </summary>
        public List<XMZMReservation> GetXMZMReservationList()
        {		
            var query = from p in this._context.XMZMReservations
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PremiumsId"></param>
        /// <returns></returns>
        public XMZMReservation GetXMZMReservationListByInstallationID(int InstallationID, int paramTypeID)
        {

            var query = from p in this._context.XMZMReservations
                        where p.InstallationID == InstallationID
                        && p.TypeID == paramTypeID
                        select p;
            return query.SingleOrDefault();
        }

        public List<XMZMReservation> GetXMZMReservationByRID(int ID)
        {
            var query = from p in this._context.XMZMReservations
                        where p.ID == ID
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMZMReservation Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMZMReservation Page List</returns>
        public PagedList<XMZMReservation> SearchXMZMReservation(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMZMReservations
                        orderby p.ID
                        select p;
            return new PagedList<XMZMReservation>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMZMReservation by ID
        /// </summary>
        /// <param name="id">XMZMReservation ID</param>
        /// <returns>XMZMReservation</returns>   
        public XMZMReservation GetXMZMReservationByID(int id)
        {
            var query = from p in this._context.XMZMReservations
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public XMZMReservation GetXMZMReservationByXMInstallationListID(int id)
        {
            var query = from p in this._context.XMZMReservations
                        where p.InstallationID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMZMReservation by ID
        /// </summary>
        /// <param name="ID">XMZMReservation ID</param>
        public void DeleteXMZMReservation(int id)
        {
            var xmzmreservation = this.GetXMZMReservationByID(id);
            if (xmzmreservation == null)
                return;
    
            if (!this._context.IsAttached(xmzmreservation))
                this._context.XMZMReservations.Attach(xmzmreservation);
    
            this._context.DeleteObject(xmzmreservation);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMZMReservation by ID
        /// </summary>
        /// <param name="IDs">XMZMReservation ID</param>
        public void BatchDeleteXMZMReservation(List<int> ids)
        {
    	   var query = from q in _context.XMZMReservations
                    where ids.Contains(q.ID)
                    select q;
            var xmzmreservations = query.ToList();
            foreach (var item in xmzmreservations)
            {
                if (!_context.IsAttached(item))
                    _context.XMZMReservations.Attach(item);  
    
                _context.XMZMReservations.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
