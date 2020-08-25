
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
    public partial class XMInventoryBarcodeDetailService : IXMInventoryBarcodeDetailService
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
        public XMInventoryBarcodeDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMInventoryBarcodeDetailService成员
        /// <summary>
        /// Insert into XMInventoryBarcodeDetail
        /// </summary>
        /// <param name="xminventorybarcodedetail">XMInventoryBarcodeDetail</param>
        public void InsertXMInventoryBarcodeDetail(XMInventoryBarcodeDetail xminventorybarcodedetail)
        {
            if (xminventorybarcodedetail == null)
                return;

            if (!this._context.IsAttached(xminventorybarcodedetail))

                this._context.XMInventoryBarcodeDetails.AddObject(xminventorybarcodedetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMInventoryBarcodeDetail
        /// </summary>
        /// <param name="xminventorybarcodedetail">XMInventoryBarcodeDetail</param>
        public void UpdateXMInventoryBarcodeDetail(XMInventoryBarcodeDetail xminventorybarcodedetail)
        {
            if (xminventorybarcodedetail == null)
                return;

            if (this._context.IsAttached(xminventorybarcodedetail))
                this._context.XMInventoryBarcodeDetails.Attach(xminventorybarcodedetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMInventoryBarcodeDetail list
        /// </summary>
        public List<XMInventoryBarcodeDetail> GetXMInventoryBarcodeDetailList()
        {
            var query = from p in this._context.XMInventoryBarcodeDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMInventoryBarcodeDetail list by InventoryID and barCode
        /// </summary>
        /// <param name="inventoryID"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public XMInventoryBarcodeDetail GetXMInventoryBarcodeDetailListByInventoryIDAndBarCode(int inventoryID, string barCode)
        {
            var query = from p in this._context.XMInventoryBarcodeDetails
                        where p.IsEnable == false && p.SpdId == inventoryID && p.BarCode == barCode
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlatformMerchantCode"></param>
        /// <param name="productName"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public List<XMInventoryBarcodeDetail> GetXMInventoryBarcodeDetailListByParm(string barCode, int spdID)
        {
            var query = from p in this._context.XMInventoryBarcodeDetails
                        where p.IsEnable == false
                        && (barCode == "" || p.BarCode.Contains(barCode))
                        && p.SpdId == spdID
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMInventoryBarcodeDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInventoryBarcodeDetail Page List</returns>
        public PagedList<XMInventoryBarcodeDetail> SearchXMInventoryBarcodeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInventoryBarcodeDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMInventoryBarcodeDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMInventoryBarcodeDetail by Id
        /// </summary>
        /// <param name="id">XMInventoryBarcodeDetail Id</param>
        /// <returns>XMInventoryBarcodeDetail</returns>   
        public XMInventoryBarcodeDetail GetXMInventoryBarcodeDetailById(int id)
        {
            var query = from p in this._context.XMInventoryBarcodeDetails
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMInventoryBarcodeDetail by Id
        /// </summary>
        /// <param name="Id">XMInventoryBarcodeDetail Id</param>
        public void DeleteXMInventoryBarcodeDetail(int id)
        {
            var xminventorybarcodedetail = this.GetXMInventoryBarcodeDetailById(id);
            if (xminventorybarcodedetail == null)
                return;

            if (!this._context.IsAttached(xminventorybarcodedetail))
                this._context.XMInventoryBarcodeDetails.Attach(xminventorybarcodedetail);

            this._context.DeleteObject(xminventorybarcodedetail);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMInventoryBarcodeDetail by Id
        /// </summary>
        /// <param name="Ids">XMInventoryBarcodeDetail Id</param>
        public void BatchDeleteXMInventoryBarcodeDetail(List<int> ids)
        {
            var query = from q in _context.XMInventoryBarcodeDetails
                        where ids.Contains(q.Id)
                        select q;
            var xminventorybarcodedetails = query.ToList();
            foreach (var item in xminventorybarcodedetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMInventoryBarcodeDetails.Attach(item);

                _context.XMInventoryBarcodeDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
