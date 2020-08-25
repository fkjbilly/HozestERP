
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMSaleInfoProductDetailsService : IXMSaleInfoProductDetailsService
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
        public XMSaleInfoProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMSaleInfoProductDetailsService成员
        /// <summary>
        /// Insert into XMSaleInfoProductDetails
        /// </summary>
        /// <param name="xmsaleinfoproductdetails">XMSaleInfoProductDetails</param>
        public void InsertXMSaleInfoProductDetails(XMSaleInfoProductDetails xmsaleinfoproductdetails)
        {
            if (xmsaleinfoproductdetails == null)
                return;

            if (!this._context.IsAttached(xmsaleinfoproductdetails))

                this._context.XMSaleInfoProductDetails.AddObject(xmsaleinfoproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMSaleInfoProductDetails
        /// </summary>
        /// <param name="xmsaleinfoproductdetails">XMSaleInfoProductDetails</param>
        public void UpdateXMSaleInfoProductDetails(XMSaleInfoProductDetails xmsaleinfoproductdetails)
        {
            if (xmsaleinfoproductdetails == null)
                return;

            if (this._context.IsAttached(xmsaleinfoproductdetails))
                this._context.XMSaleInfoProductDetails.Attach(xmsaleinfoproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMSaleInfoProductDetails list
        /// </summary>
        public List<XMSaleInfoProductDetails> GetXMSaleInfoProductDetailsList()
        {
            var query = from p in this._context.XMSaleInfoProductDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMSaleInfoProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleInfoProductDetails Page List</returns>
        public PagedList<XMSaleInfoProductDetails> SearchXMSaleInfoProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMSaleInfoProductDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMSaleInfoProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleId"></param>
        /// <returns></returns>
        public List<XMSaleInfoProductDetails> GetSaleInfoProductDetailsBySaleId(int saleId)
        {
            var query = from p in this._context.XMSaleInfoProductDetails
                        where p.IsEnable == false && p.SaleInfoId == saleId
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get a XMSaleInfoProductDetails by Id
        /// </summary>
        /// <param name="id">XMSaleInfoProductDetails Id</param>
        /// <returns>XMSaleInfoProductDetails</returns>   
        public XMSaleInfoProductDetails GetXMSaleInfoProductDetailsById(int id)
        {
            var query = from p in this._context.XMSaleInfoProductDetails
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMSaleInfoProductDetails by Id
        /// </summary>
        /// <param name="Id">XMSaleInfoProductDetails Id</param>
        public void DeleteXMSaleInfoProductDetails(int id)
        {
            var xmsaleinfoproductdetails = this.GetXMSaleInfoProductDetailsById(id);
            if (xmsaleinfoproductdetails == null)
                return;

            if (!this._context.IsAttached(xmsaleinfoproductdetails))
                this._context.XMSaleInfoProductDetails.Attach(xmsaleinfoproductdetails);

            this._context.DeleteObject(xmsaleinfoproductdetails);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMSaleInfoProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMSaleInfoProductDetails Id</param>
        public void BatchDeleteXMSaleInfoProductDetails(List<int> ids)
        {
            var query = from q in _context.XMSaleInfoProductDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmsaleinfoproductdetailss = query.ToList();
            foreach (var item in xmsaleinfoproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMSaleInfoProductDetails.Attach(item);

                _context.XMSaleInfoProductDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
