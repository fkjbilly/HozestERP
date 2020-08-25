
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-05-09 16:59:21
** 修改人:
** 修改日期:
** 描 述: 接口实现类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMSaleReturnProductDetailsService : IXMSaleReturnProductDetailsService
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
        public XMSaleReturnProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMSaleReturnProductDetailsService成员
        /// <summary>
        /// Insert into XMSaleReturnProductDetails
        /// </summary>
        /// <param name="xmsalereturnproductdetails">XMSaleReturnProductDetails</param>
        public void InsertXMSaleReturnProductDetails(XMSaleReturnProductDetails xmsalereturnproductdetails)
        {
            if (xmsalereturnproductdetails == null)
                return;

            if (!this._context.IsAttached(xmsalereturnproductdetails))

                this._context.XMSaleReturnProductDetails.AddObject(xmsalereturnproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMSaleReturnProductDetails
        /// </summary>
        /// <param name="xmsalereturnproductdetails">XMSaleReturnProductDetails</param>
        public void UpdateXMSaleReturnProductDetails(XMSaleReturnProductDetails xmsalereturnproductdetails)
        {
            if (xmsalereturnproductdetails == null)
                return;

            if (this._context.IsAttached(xmsalereturnproductdetails))
                this._context.XMSaleReturnProductDetails.Attach(xmsalereturnproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMSaleReturnProductDetails list
        /// </summary>
        public List<XMSaleReturnProductDetails> GetXMSaleReturnProductDetailsList()
        {
            var query = from p in this._context.XMSaleReturnProductDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleReturnID"></param>
        /// <returns></returns>
        public List<XMSaleReturnProductDetails> GetXMSaleReturnProductDetailsListBySaleReturnID(int saleReturnID)
        {
            var query = from p in this._context.XMSaleReturnProductDetails
                        where p.IsEnable == false && p.SaleReturnId == saleReturnID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<XMSaleReturnProductDetails> GetXMSaleReturnProductDetailsListByDeliveryProductsDetailID(int ID)
        {
            var query = from p in this._context.XMSaleReturnProductDetails
                        join d in this._context.XMSaleReturns
                        on p.SaleReturnId equals d.Id
                        where p.IsEnable == false && p.DeliveryProductsDetailID == ID
                        && d.BillStatus == 1000
                        select p;
            return query.ToList();
        }

        public List<XMSaleReturnProductDetails> GetXMSaleReturnProductDetailsListByDate(DateTime Begin, DateTime End, List<int?> WareHousesList)
        {
            var query = from p in this._context.XMSaleReturns
                        join d in this._context.XMSaleReturnProductDetails
                        on p.Id equals d.SaleReturnId
                        where p.IsEnable == false
                        && d.IsEnable == false
                        && WareHousesList.Contains(p.WarehouseId)
                        && p.BillStatus != 0
                        && p.BizDt >= Begin
                        && p.BizDt < End
                        orderby p.Id descending
                        select d;
            return query.ToList();
        }

        /// <summary>
        /// get to XMSaleReturnProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleReturnProductDetails Page List</returns>
        public PagedList<XMSaleReturnProductDetails> SearchXMSaleReturnProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMSaleReturnProductDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMSaleReturnProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMSaleReturnProductDetails by Id
        /// </summary>
        /// <param name="id">XMSaleReturnProductDetails Id</param>
        /// <returns>XMSaleReturnProductDetails</returns>   
        public XMSaleReturnProductDetails GetXMSaleReturnProductDetailsById(int id)
        {
            var query = from p in this._context.XMSaleReturnProductDetails
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMSaleReturnProductDetails by Id
        /// </summary>
        /// <param name="Id">XMSaleReturnProductDetails Id</param>
        public void DeleteXMSaleReturnProductDetails(int id)
        {
            var xmsalereturnproductdetails = this.GetXMSaleReturnProductDetailsById(id);
            if (xmsalereturnproductdetails == null)
                return;

            if (!this._context.IsAttached(xmsalereturnproductdetails))
                this._context.XMSaleReturnProductDetails.Attach(xmsalereturnproductdetails);

            this._context.DeleteObject(xmsalereturnproductdetails);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMSaleReturnProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMSaleReturnProductDetails Id</param>
        public void BatchDeleteXMSaleReturnProductDetails(List<int> ids)
        {
            var query = from q in _context.XMSaleReturnProductDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmsalereturnproductdetailss = query.ToList();
            foreach (var item in xmsalereturnproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMSaleReturnProductDetails.Attach(item);

                _context.XMSaleReturnProductDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
