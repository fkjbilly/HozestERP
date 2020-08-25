
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-14 10:05:20
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

namespace HozestERP.BusinessLogic.ManageProductionOrder
{
    public partial class XMProductionOrderDetailsService : IXMProductionOrderDetailsService
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
        public XMProductionOrderDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMProductionOrderDetailsService成员
        /// <summary>
        /// Insert into XMProductionOrderDetails
        /// </summary>
        /// <param name="xmproductionorderdetails">XMProductionOrderDetails</param>
        public void InsertXMProductionOrderDetails(XMProductionOrderDetails xmproductionorderdetails)
        {
            if (xmproductionorderdetails == null)
                return;

            if (!this._context.IsAttached(xmproductionorderdetails))

                this._context.XMProductionOrderDetails.AddObject(xmproductionorderdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMProductionOrderDetails
        /// </summary>
        /// <param name="xmproductionorderdetails">XMProductionOrderDetails</param>
        public void UpdateXMProductionOrderDetails(XMProductionOrderDetails xmproductionorderdetails)
        {
            if (xmproductionorderdetails == null)
                return;

            if (this._context.IsAttached(xmproductionorderdetails))
                this._context.XMProductionOrderDetails.Attach(xmproductionorderdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMProductionOrderDetails list
        /// </summary>
        public List<XMProductionOrderDetails> GetXMProductionOrderDetailsList()
        {
            var query = from p in this._context.XMProductionOrderDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productionOrderID"></param>
        /// <returns></returns>
        public List<XMProductionOrderDetails> GetXMProductionOrderDetailsListByProductionOrderID(int productionOrderID)
        {
            var query = from p in this._context.XMProductionOrderDetails
                        where p.IsEnable == false
                        && p.ProductionOrderID == productionOrderID
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMProductionOrderDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProductionOrderDetails Page List</returns>
        public PagedList<XMProductionOrderDetails> SearchXMProductionOrderDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMProductionOrderDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMProductionOrderDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMProductionOrderDetails by Id
        /// </summary>
        /// <param name="id">XMProductionOrderDetails Id</param>
        /// <returns>XMProductionOrderDetails</returns>   
        public XMProductionOrderDetails GetXMProductionOrderDetailsById(int id)
        {
            var query = from p in this._context.XMProductionOrderDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMProductionOrderDetails by Id
        /// </summary>
        /// <param name="Id">XMProductionOrderDetails Id</param>
        public void DeleteXMProductionOrderDetails(int id)
        {
            var xmproductionorderdetails = this.GetXMProductionOrderDetailsById(id);
            if (xmproductionorderdetails == null)
                return;

            if (!this._context.IsAttached(xmproductionorderdetails))
                this._context.XMProductionOrderDetails.Attach(xmproductionorderdetails);

            this._context.DeleteObject(xmproductionorderdetails);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMProductionOrderDetails by Id
        /// </summary>
        /// <param name="Ids">XMProductionOrderDetails Id</param>
        public void BatchDeleteXMProductionOrderDetails(List<int> ids)
        {
            var query = from q in _context.XMProductionOrderDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmproductionorderdetailss = query.ToList();
            foreach (var item in xmproductionorderdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMProductionOrderDetails.Attach(item);

                _context.XMProductionOrderDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
