
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
    public partial class XMSaleDeliveryBarCodeDetailService: IXMSaleDeliveryBarCodeDetailService
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
    	public XMSaleDeliveryBarCodeDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMSaleDeliveryBarCodeDetailService成员
        /// <summary>
        /// Insert into XMSaleDeliveryBarCodeDetail
        /// </summary>
        /// <param name="xmsaledeliverybarcodedetail">XMSaleDeliveryBarCodeDetail</param>
    	public void InsertXMSaleDeliveryBarCodeDetail(XMSaleDeliveryBarCodeDetail xmsaledeliverybarcodedetail)
    	{	
            if (xmsaledeliverybarcodedetail == null)
                return;
    
            if (!this._context.IsAttached(xmsaledeliverybarcodedetail))
    			
                this._context.XMSaleDeliveryBarCodeDetails.AddObject(xmsaledeliverybarcodedetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMSaleDeliveryBarCodeDetail
        /// </summary>
        /// <param name="xmsaledeliverybarcodedetail">XMSaleDeliveryBarCodeDetail</param>
        public void UpdateXMSaleDeliveryBarCodeDetail(XMSaleDeliveryBarCodeDetail xmsaledeliverybarcodedetail)
        {
            if (xmsaledeliverybarcodedetail == null)
                return;
    
            if (this._context.IsAttached(xmsaledeliverybarcodedetail))
                this._context.XMSaleDeliveryBarCodeDetails.Attach(xmsaledeliverybarcodedetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMSaleDeliveryBarCodeDetail list
        /// </summary>
        public List<XMSaleDeliveryBarCodeDetail> GetXMSaleDeliveryBarCodeDetailList()
        {		
            var query = from p in this._context.XMSaleDeliveryBarCodeDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMSaleDeliveryBarCodeDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleDeliveryBarCodeDetail Page List</returns>
        public PagedList<XMSaleDeliveryBarCodeDetail> SearchXMSaleDeliveryBarCodeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMSaleDeliveryBarCodeDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMSaleDeliveryBarCodeDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMSaleDeliveryBarCodeDetail by Id
        /// </summary>
        /// <param name="id">XMSaleDeliveryBarCodeDetail Id</param>
        /// <returns>XMSaleDeliveryBarCodeDetail</returns>   
        public XMSaleDeliveryBarCodeDetail GetXMSaleDeliveryBarCodeDetailById(int id)
        {
            var query = from p in this._context.XMSaleDeliveryBarCodeDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMSaleDeliveryBarCodeDetail by Id
        /// </summary>
        /// <param name="Id">XMSaleDeliveryBarCodeDetail Id</param>
        public void DeleteXMSaleDeliveryBarCodeDetail(int id)
        {
            var xmsaledeliverybarcodedetail = this.GetXMSaleDeliveryBarCodeDetailById(id);
            if (xmsaledeliverybarcodedetail == null)
                return;
    
            if (!this._context.IsAttached(xmsaledeliverybarcodedetail))
                this._context.XMSaleDeliveryBarCodeDetails.Attach(xmsaledeliverybarcodedetail);
    
            this._context.DeleteObject(xmsaledeliverybarcodedetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMSaleDeliveryBarCodeDetail by Id
        /// </summary>
        /// <param name="Ids">XMSaleDeliveryBarCodeDetail Id</param>
        public void BatchDeleteXMSaleDeliveryBarCodeDetail(List<int> ids)
        {
    	   var query = from q in _context.XMSaleDeliveryBarCodeDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmsaledeliverybarcodedetails = query.ToList();
            foreach (var item in xmsaledeliverybarcodedetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMSaleDeliveryBarCodeDetails.Attach(item);  
    
                _context.XMSaleDeliveryBarCodeDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
