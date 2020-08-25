
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-08-10 10:40:39
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
    public partial class XMJDSaleRejectedProductDetailService : IXMJDSaleRejectedProductDetailService
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
        public XMJDSaleRejectedProductDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMJDSaleRejectedProductDetailService成员
        /// <summary>
        /// Insert into XMJDSaleRejectedProductDetail
        /// </summary>
        /// <param name="xmjdsalerejectedproductdetail">XMJDSaleRejectedProductDetail</param>
        public void InsertXMJDSaleRejectedProductDetail(XMJDSaleRejectedProductDetail xmjdsalerejectedproductdetail)
        {
            if (xmjdsalerejectedproductdetail == null)
                return;

            if (!this._context.IsAttached(xmjdsalerejectedproductdetail))

                this._context.XMJDSaleRejectedProductDetails.AddObject(xmjdsalerejectedproductdetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMJDSaleRejectedProductDetail
        /// </summary>
        /// <param name="xmjdsalerejectedproductdetail">XMJDSaleRejectedProductDetail</param>
        public void UpdateXMJDSaleRejectedProductDetail(XMJDSaleRejectedProductDetail xmjdsalerejectedproductdetail)
        {
            if (xmjdsalerejectedproductdetail == null)
                return;

            if (this._context.IsAttached(xmjdsalerejectedproductdetail))
                this._context.XMJDSaleRejectedProductDetails.Attach(xmjdsalerejectedproductdetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMJDSaleRejectedProductDetail list
        /// </summary>
        public List<XMJDSaleRejectedProductDetail> GetXMJDSaleRejectedProductDetailList()
        {
            var query = from p in this._context.XMJDSaleRejectedProductDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMJDSaleRejectedProductDetail> GetXMJDSaleRejectedProductDetailListJDSelf(DateTime begin, DateTime end)
        {
            var query = from p in this._context.XMJDSaleRejecteds
                        join d in this._context.XMJDSaleRejectedProductDetails
                        on p.Id equals d.JDRejectedID
                        where p.IsEnable == false
                        && d.IsEnable == false
                        && p.NickId==29//京东喜临门自营
                     
                        && p.BizDt >= begin
                        && p.BizDt < end
                        orderby p.Id descending
                        select d;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jdSaleRejectID"></param>
        /// <returns></returns>
        public List<XMJDSaleRejectedProductDetail> GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(int jdSaleRejectID)
        {
            var query = from p in this._context.XMJDSaleRejectedProductDetails
                        where p.IsEnable == false && p.JDRejectedID == jdSaleRejectID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMJDSaleRejectedProductDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMJDSaleRejectedProductDetail Page List</returns>
        public PagedList<XMJDSaleRejectedProductDetail> SearchXMJDSaleRejectedProductDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMJDSaleRejectedProductDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMJDSaleRejectedProductDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMJDSaleRejectedProductDetail by Id
        /// </summary>
        /// <param name="id">XMJDSaleRejectedProductDetail Id</param>
        /// <returns>XMJDSaleRejectedProductDetail</returns>   
        public XMJDSaleRejectedProductDetail GetXMJDSaleRejectedProductDetailById(int id)
        {
            var query = from p in this._context.XMJDSaleRejectedProductDetails
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMJDSaleRejectedProductDetail by Id
        /// </summary>
        /// <param name="Id">XMJDSaleRejectedProductDetail Id</param>
        public void DeleteXMJDSaleRejectedProductDetail(int id)
        {
            var xmjdsalerejectedproductdetail = this.GetXMJDSaleRejectedProductDetailById(id);
            if (xmjdsalerejectedproductdetail == null)
                return;

            if (!this._context.IsAttached(xmjdsalerejectedproductdetail))
                this._context.XMJDSaleRejectedProductDetails.Attach(xmjdsalerejectedproductdetail);

            this._context.DeleteObject(xmjdsalerejectedproductdetail);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMJDSaleRejectedProductDetail by Id
        /// </summary>
        /// <param name="Ids">XMJDSaleRejectedProductDetail Id</param>
        public void BatchDeleteXMJDSaleRejectedProductDetail(List<int> ids)
        {
            var query = from q in _context.XMJDSaleRejectedProductDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmjdsalerejectedproductdetails = query.ToList();
            foreach (var item in xmjdsalerejectedproductdetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMJDSaleRejectedProductDetails.Attach(item);

                _context.XMJDSaleRejectedProductDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
