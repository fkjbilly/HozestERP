
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-05 11:22:57
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMOrderInfoOperatingRecordService : IXMOrderInfoOperatingRecordService
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
        public XMOrderInfoOperatingRecordService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMOrderInfoOperatingRecordService成员
        /// <summary>
        /// Insert into XMOrderInfoOperatingRecord
        /// </summary>
        /// <param name="xmorderinfooperatingrecord">XMOrderInfoOperatingRecord</param>
        public void InsertXMOrderInfoOperatingRecord(XMOrderInfoOperatingRecord xmorderinfooperatingrecord)
        {
            if (xmorderinfooperatingrecord == null)
                return;

            if (!this._context.IsAttached(xmorderinfooperatingrecord))

                this._context.XMOrderInfoOperatingRecords.AddObject(xmorderinfooperatingrecord);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMOrderInfoOperatingRecord
        /// </summary>
        /// <param name="xmorderinfooperatingrecord">XMOrderInfoOperatingRecord</param>
        public void UpdateXMOrderInfoOperatingRecord(XMOrderInfoOperatingRecord xmorderinfooperatingrecord)
        {
            if (xmorderinfooperatingrecord == null)
                return;

            if (this._context.IsAttached(xmorderinfooperatingrecord))
                this._context.XMOrderInfoOperatingRecords.Attach(xmorderinfooperatingrecord);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMOrderInfoOperatingRecord list
        /// </summary>
        public List<XMOrderInfoOperatingRecord> GetXMOrderInfoOperatingRecordList()
        {
            var query = from p in this._context.XMOrderInfoOperatingRecords
                        select p;
            return query.ToList();
        }

        public List<XMOrderInfoOperatingRecord> GetXMOrderInfoOperatingRecordListByParm(int OrderInfoId, string PropertyName, string OldValue, string NewValue)
        {
            var query = from p in this._context.XMOrderInfoOperatingRecords
                        where p.OrderInfoId == OrderInfoId
                        && p.PropertyName == PropertyName
                        && p.OldValue == OldValue
                        && p.NewValue == NewValue
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMOrderInfoOperatingRecord Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOrderInfoOperatingRecord Page List</returns>
        public PagedList<XMOrderInfoOperatingRecord> SearchXMOrderInfoOperatingRecord(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMOrderInfoOperatingRecords
                        orderby p.Id
                        select p;
            return new PagedList<XMOrderInfoOperatingRecord>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMOrderInfoOperatingRecord by Id
        /// </summary>
        /// <param name="id">XMOrderInfoOperatingRecord Id</param>
        /// <returns>XMOrderInfoOperatingRecord</returns>   
        public XMOrderInfoOperatingRecord GetXMOrderInfoOperatingRecordById(int id)
        {
            var query = from p in this._context.XMOrderInfoOperatingRecords
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMOrderInfoOperatingRecord by Id
        /// </summary>
        /// <param name="Id">XMOrderInfoOperatingRecord Id</param>
        public void DeleteXMOrderInfoOperatingRecord(int id)
        {
            var xmorderinfooperatingrecord = this.GetXMOrderInfoOperatingRecordById(id);
            if (xmorderinfooperatingrecord == null)
                return;

            if (!this._context.IsAttached(xmorderinfooperatingrecord))
                this._context.XMOrderInfoOperatingRecords.Attach(xmorderinfooperatingrecord);

            this._context.DeleteObject(xmorderinfooperatingrecord);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMOrderInfoOperatingRecord by Id
        /// </summary>
        /// <param name="Ids">XMOrderInfoOperatingRecord Id</param>
        public void BatchDeleteXMOrderInfoOperatingRecord(List<int> ids)
        {
            var query = from q in _context.XMOrderInfoOperatingRecords
                        where ids.Contains(q.Id)
                        select q;
            var xmorderinfooperatingrecords = query.ToList();
            foreach (var item in xmorderinfooperatingrecords)
            {
                if (!_context.IsAttached(item))
                    _context.XMOrderInfoOperatingRecords.Attach(item);

                _context.XMOrderInfoOperatingRecords.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// get to XMOrderInfoOperatingRecord Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOrderInfoOperatingRecord Page List</returns>
        public PagedList<XMOrderInfoOperatingRecord> SearchXMOrderInfoOperatingRecord(int OrderInfoId, string PropertyName, int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMOrderInfoOperatingRecords
                        where p.OrderInfoId == OrderInfoId
                        && p.PropertyName.Contains(PropertyName)
                        orderby p.UpdateTime descending
                        select p;
            return new PagedList<XMOrderInfoOperatingRecord>(query.ToList(), pageIndex, pageSize, sortExpression, sortDirection);
        }

        #endregion
    }
}
