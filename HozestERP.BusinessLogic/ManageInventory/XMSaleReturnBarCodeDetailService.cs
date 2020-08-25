
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
    public partial class XMSaleReturnBarCodeDetailService : IXMSaleReturnBarCodeDetailService
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
        public XMSaleReturnBarCodeDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMSaleReturnBarCodeDetailService成员
        /// <summary>
        /// Insert into XMSaleReturnBarCodeDetail
        /// </summary>
        /// <param name="xmsalereturnbarcodedetail">XMSaleReturnBarCodeDetail</param>
        public void InsertXMSaleReturnBarCodeDetail(XMSaleReturnBarCodeDetail xmsalereturnbarcodedetail)
        {
            if (xmsalereturnbarcodedetail == null)
                return;

            if (!this._context.IsAttached(xmsalereturnbarcodedetail))

                this._context.XMSaleReturnBarCodeDetails.AddObject(xmsalereturnbarcodedetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMSaleReturnBarCodeDetail
        /// </summary>
        /// <param name="xmsalereturnbarcodedetail">XMSaleReturnBarCodeDetail</param>
        public void UpdateXMSaleReturnBarCodeDetail(XMSaleReturnBarCodeDetail xmsalereturnbarcodedetail)
        {
            if (xmsalereturnbarcodedetail == null)
                return;

            if (this._context.IsAttached(xmsalereturnbarcodedetail))
                this._context.XMSaleReturnBarCodeDetails.Attach(xmsalereturnbarcodedetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMSaleReturnBarCodeDetail list
        /// </summary>
        public List<XMSaleReturnBarCodeDetail> GetXMSaleReturnBarCodeDetailList()
        {
            var query = from p in this._context.XMSaleReturnBarCodeDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srdID"></param>
        /// <returns></returns>
        public List<XMSaleReturnBarCodeDetail> GetXMSaleReturnBarCodeDetailListBySrdID(int srdID)
        {
            var query = from p in this._context.XMSaleReturnBarCodeDetails
                        where p.IsEnable == false && p.SpdId == srdID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="spdID"></param>
        /// <returns></returns>
        public List<XMSaleReturnBarCodeDetail> GetXMSaleReturnBarCodeDetailListByParm(string barCode, int spdID)
        {
            var query = from p in this._context.XMSaleReturnBarCodeDetails
                        where p.IsEnable == false
                        && (barCode == "" || p.BarCode.Contains(barCode))
                        && p.SpdId == spdID
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMSaleReturnBarCodeDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleReturnBarCodeDetail Page List</returns>
        public PagedList<XMSaleReturnBarCodeDetail> SearchXMSaleReturnBarCodeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMSaleReturnBarCodeDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMSaleReturnBarCodeDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMSaleReturnBarCodeDetail by Id
        /// </summary>
        /// <param name="id">XMSaleReturnBarCodeDetail Id</param>
        /// <returns>XMSaleReturnBarCodeDetail</returns>   
        public XMSaleReturnBarCodeDetail GetXMSaleReturnBarCodeDetailById(int id)
        {
            var query = from p in this._context.XMSaleReturnBarCodeDetails
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srdID"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public XMSaleReturnBarCodeDetail GetXMSaleReturnBarCodeDetailByParm(int srdID, string barCode)
        {
            var query = from p in this._context.XMSaleReturnBarCodeDetails
                        where p.IsEnable == false && p.SpdId == srdID && p.BarCode == barCode
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMSaleReturnBarCodeDetail by Id
        /// </summary>
        /// <param name="Id">XMSaleReturnBarCodeDetail Id</param>
        public void DeleteXMSaleReturnBarCodeDetail(int id)
        {
            var xmsalereturnbarcodedetail = this.GetXMSaleReturnBarCodeDetailById(id);
            if (xmsalereturnbarcodedetail == null)
                return;

            if (!this._context.IsAttached(xmsalereturnbarcodedetail))
                this._context.XMSaleReturnBarCodeDetails.Attach(xmsalereturnbarcodedetail);

            this._context.DeleteObject(xmsalereturnbarcodedetail);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMSaleReturnBarCodeDetail by Id
        /// </summary>
        /// <param name="Ids">XMSaleReturnBarCodeDetail Id</param>
        public void BatchDeleteXMSaleReturnBarCodeDetail(List<int> ids)
        {
            var query = from q in _context.XMSaleReturnBarCodeDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmsalereturnbarcodedetails = query.ToList();
            foreach (var item in xmsalereturnbarcodedetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMSaleReturnBarCodeDetails.Attach(item);

                _context.XMSaleReturnBarCodeDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
