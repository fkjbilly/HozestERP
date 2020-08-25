
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-06-17 10:08:36
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
    public partial class XMAllocateProductBarCodeDetailService : IXMAllocateProductBarCodeDetailService
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
        public XMAllocateProductBarCodeDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMAllocateProductBarCodeDetailService成员
        /// <summary>
        /// Insert into XMAllocateProductBarCodeDetail
        /// </summary>
        /// <param name="xmallocateproductbarcodedetail">XMAllocateProductBarCodeDetail</param>
        public void InsertXMAllocateProductBarCodeDetail(XMAllocateProductBarCodeDetail xmallocateproductbarcodedetail)
        {
            if (xmallocateproductbarcodedetail == null)
                return;

            if (!this._context.IsAttached(xmallocateproductbarcodedetail))

                this._context.XMAllocateProductBarCodeDetails.AddObject(xmallocateproductbarcodedetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMAllocateProductBarCodeDetail
        /// </summary>
        /// <param name="xmallocateproductbarcodedetail">XMAllocateProductBarCodeDetail</param>
        public void UpdateXMAllocateProductBarCodeDetail(XMAllocateProductBarCodeDetail xmallocateproductbarcodedetail)
        {
            if (xmallocateproductbarcodedetail == null)
                return;

            if (this._context.IsAttached(xmallocateproductbarcodedetail))
                this._context.XMAllocateProductBarCodeDetails.Attach(xmallocateproductbarcodedetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMAllocateProductBarCodeDetail list
        /// </summary>
        public List<XMAllocateProductBarCodeDetail> GetXMAllocateProductBarCodeDetailList()
        {
            var query = from p in this._context.XMAllocateProductBarCodeDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apdID"></param>
        /// <returns></returns>
        public List<XMAllocateProductBarCodeDetail> GetXMAllocateProductBarCodeDetailListById(int apdID)
        {
            var query = from p in this._context.XMAllocateProductBarCodeDetails
                        where p.IsEnable == false && p.SpdId == apdID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="apdID"></param>
        /// <returns></returns>
        public List<XMAllocateProductBarCodeDetail> GetXMAllocateProductBarCodeDetailListByParm(string barCode, int apdID)
        {
            var query = from p in this._context.XMAllocateProductBarCodeDetails
                        where p.IsEnable == false
                        && (barCode == "" || p.BarCode.Contains(barCode))
                        && p.SpdId == apdID
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMAllocateProductBarCodeDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAllocateProductBarCodeDetail Page List</returns>
        public PagedList<XMAllocateProductBarCodeDetail> SearchXMAllocateProductBarCodeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAllocateProductBarCodeDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMAllocateProductBarCodeDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMAllocateProductBarCodeDetail by Id
        /// </summary>
        /// <param name="id">XMAllocateProductBarCodeDetail Id</param>
        /// <returns>XMAllocateProductBarCodeDetail</returns>   
        public XMAllocateProductBarCodeDetail GetXMAllocateProductBarCodeDetailById(int id)
        {
            var query = from p in this._context.XMAllocateProductBarCodeDetails
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据调拨产品详情ID和产品条形码查询产品
        /// </summary>
        /// <param name="apdID"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public XMAllocateProductBarCodeDetail GetXMAllocateProductBarCodeDetailByParm(int apdID, string barcode)
        {
            var query = from p in this._context.XMAllocateProductBarCodeDetails
                        where p.IsEnable == false && p.SpdId == apdID && p.BarCode == barcode
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMAllocateProductBarCodeDetail by Id
        /// </summary>
        /// <param name="Id">XMAllocateProductBarCodeDetail Id</param>
        public void DeleteXMAllocateProductBarCodeDetail(int id)
        {
            var xmallocateproductbarcodedetail = this.GetXMAllocateProductBarCodeDetailById(id);
            if (xmallocateproductbarcodedetail == null)
                return;

            if (!this._context.IsAttached(xmallocateproductbarcodedetail))
                this._context.XMAllocateProductBarCodeDetails.Attach(xmallocateproductbarcodedetail);

            this._context.DeleteObject(xmallocateproductbarcodedetail);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMAllocateProductBarCodeDetail by Id
        /// </summary>
        /// <param name="Ids">XMAllocateProductBarCodeDetail Id</param>
        public void BatchDeleteXMAllocateProductBarCodeDetail(List<int> ids)
        {
            var query = from q in _context.XMAllocateProductBarCodeDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmallocateproductbarcodedetails = query.ToList();
            foreach (var item in xmallocateproductbarcodedetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMAllocateProductBarCodeDetails.Attach(item);

                _context.XMAllocateProductBarCodeDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
