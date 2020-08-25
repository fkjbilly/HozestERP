
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
    public partial class XMPdInfoProductDetailsService : IXMPdInfoProductDetailsService
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
        public XMPdInfoProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMPdInfoProductDetailsService成员
        /// <summary>
        /// Insert into XMPdInfoProductDetails
        /// </summary>
        /// <param name="xmpdinfoproductdetails">XMPdInfoProductDetails</param>
        public void InsertXMPdInfoProductDetails(XMPdInfoProductDetails xmpdinfoproductdetails)
        {
            if (xmpdinfoproductdetails == null)
                return;

            if (!this._context.IsAttached(xmpdinfoproductdetails))

                this._context.XMPdInfoProductDetails.AddObject(xmpdinfoproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMPdInfoProductDetails
        /// </summary>
        /// <param name="xmpdinfoproductdetails">XMPdInfoProductDetails</param>
        public void UpdateXMPdInfoProductDetails(XMPdInfoProductDetails xmpdinfoproductdetails)
        {
            if (xmpdinfoproductdetails == null)
                return;

            if (this._context.IsAttached(xmpdinfoproductdetails))
                this._context.XMPdInfoProductDetails.Attach(xmpdinfoproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMPdInfoProductDetails list
        /// </summary>
        public List<XMPdInfoProductDetails> GetXMPdInfoProductDetailsList()
        {
            var query = from p in this._context.XMPdInfoProductDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMPdInfoProductDetails list by pdID
        /// </summary>
        /// <returns></returns>
        public List<XMPdInfoProductDetails> GetXMPdInfoProductDetailsListByPdID(int pdID)
        {
            var query = from p in this._context.XMPdInfoProductDetails
                        where p.IsEnable == false && p.PdId == pdID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMPdInfoProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPdInfoProductDetails Page List</returns>
        public PagedList<XMPdInfoProductDetails> SearchXMPdInfoProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPdInfoProductDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMPdInfoProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMPdInfoProductDetails by Id
        /// </summary>
        /// <param name="id">XMPdInfoProductDetails Id</param>
        /// <returns>XMPdInfoProductDetails</returns>   
        public XMPdInfoProductDetails GetXMPdInfoProductDetailsById(int id)
        {
            var query = from p in this._context.XMPdInfoProductDetails
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMPdInfoProductDetails by Id
        /// </summary>
        /// <param name="Id">XMPdInfoProductDetails Id</param>
        public void DeleteXMPdInfoProductDetails(int id)
        {
            var xmpdinfoproductdetails = this.GetXMPdInfoProductDetailsById(id);
            if (xmpdinfoproductdetails == null)
                return;

            if (!this._context.IsAttached(xmpdinfoproductdetails))
                this._context.XMPdInfoProductDetails.Attach(xmpdinfoproductdetails);

            this._context.DeleteObject(xmpdinfoproductdetails);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMPdInfoProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMPdInfoProductDetails Id</param>
        public void BatchDeleteXMPdInfoProductDetails(List<int> ids)
        {
            var query = from q in _context.XMPdInfoProductDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmpdinfoproductdetailss = query.ToList();
            foreach (var item in xmpdinfoproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMPdInfoProductDetails.Attach(item);

                _context.XMPdInfoProductDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
