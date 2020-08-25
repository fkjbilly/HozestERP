
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
    public partial class XMStorageProductBarCodeDetailService : IXMStorageProductBarCodeDetailService
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
        public XMStorageProductBarCodeDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMStorageProductBarCodeDetailService成员
        /// <summary>
        /// Insert into XMStorageProductBarCodeDetail
        /// </summary>
        /// <param name="xmstorageproductbarcodedetail">XMStorageProductBarCodeDetail</param>
        public void InsertXMStorageProductBarCodeDetail(XMStorageProductBarCodeDetail xmstorageproductbarcodedetail)
        {
            if (xmstorageproductbarcodedetail == null)
                return;

            if (!this._context.IsAttached(xmstorageproductbarcodedetail))

                this._context.XMStorageProductBarCodeDetails.AddObject(xmstorageproductbarcodedetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMStorageProductBarCodeDetail
        /// </summary>
        /// <param name="xmstorageproductbarcodedetail">XMStorageProductBarCodeDetail</param>
        public void UpdateXMStorageProductBarCodeDetail(XMStorageProductBarCodeDetail xmstorageproductbarcodedetail)
        {
            if (xmstorageproductbarcodedetail == null)
                return;

            if (this._context.IsAttached(xmstorageproductbarcodedetail))
                this._context.XMStorageProductBarCodeDetails.Attach(xmstorageproductbarcodedetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMStorageProductBarCodeDetail list
        /// </summary>
        public List<XMStorageProductBarCodeDetail> GetXMStorageProductBarCodeDetailList()
        {
            var query = from p in this._context.XMStorageProductBarCodeDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spdID"></param>
        /// <returns></returns>
        public List<XMStorageProductBarCodeDetail> GetXMStorageProductBarCodeDetailListBySpdID(int spdID)
        {
            var query = from p in this._context.XMStorageProductBarCodeDetails
                        where p.IsEnable == false && p.SpdId == spdID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 根据入库产品ID 和 条形码查询产品相关信息
        /// </summary>
        /// <param name="spdID"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public XMStorageProductBarCodeDetail GetXMStorageProductBarCodeDetailByParm(int spdID, string barCode)
        {
            var query = from p in this._context.XMStorageProductBarCodeDetails
                        where p.SpdId == spdID && p.BarCode == barCode
                        && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// get to XMStorageProductBarCodeDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMStorageProductBarCodeDetail Page List</returns>
        public PagedList<XMStorageProductBarCodeDetail> SearchXMStorageProductBarCodeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMStorageProductBarCodeDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMStorageProductBarCodeDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMStorageProductBarCodeDetail by Id
        /// </summary>
        /// <param name="id">XMStorageProductBarCodeDetail Id</param>
        /// <returns>XMStorageProductBarCodeDetail</returns>   
        public XMStorageProductBarCodeDetail GetXMStorageProductBarCodeDetailById(int id)
        {
            var query = from p in this._context.XMStorageProductBarCodeDetails
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spdID"></param>
        /// <returns></returns>
        public List<XMStorageProductBarCodeDetail> GetXMStorageProductBarCodeDetailListByParm(string barCode, int spdID)
        {
            var query = from p in this._context.XMStorageProductBarCodeDetails
                        where p.IsEnable == false
                        && (barCode == "" || p.BarCode.Contains(barCode))
                        && p.SpdId == spdID
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// delete XMStorageProductBarCodeDetail by Id
        /// </summary>
        /// <param name="Id">XMStorageProductBarCodeDetail Id</param>
        public void DeleteXMStorageProductBarCodeDetail(int id)
        {
            var xmstorageproductbarcodedetail = this.GetXMStorageProductBarCodeDetailById(id);
            if (xmstorageproductbarcodedetail == null)
                return;

            if (!this._context.IsAttached(xmstorageproductbarcodedetail))
                this._context.XMStorageProductBarCodeDetails.Attach(xmstorageproductbarcodedetail);

            this._context.DeleteObject(xmstorageproductbarcodedetail);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMStorageProductBarCodeDetail by Id
        /// </summary>
        /// <param name="Ids">XMStorageProductBarCodeDetail Id</param>
        public void BatchDeleteXMStorageProductBarCodeDetail(List<int> ids)
        {
            var query = from q in _context.XMStorageProductBarCodeDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmstorageproductbarcodedetails = query.ToList();
            foreach (var item in xmstorageproductbarcodedetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMStorageProductBarCodeDetails.Attach(item);

                _context.XMStorageProductBarCodeDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
