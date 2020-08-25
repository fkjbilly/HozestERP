
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-07-07 10:13:35
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMAdvertisingFeeService : IXMAdvertisingFeeService
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
        public XMAdvertisingFeeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMAdvertisingFeeService成员
        /// <summary>
        /// Insert into XMAdvertisingFee
        /// </summary>
        /// <param name="xmadvertisingfee">XMAdvertisingFee</param>
        public void InsertXMAdvertisingFee(XMAdvertisingFee xmadvertisingfee)
        {
            if (xmadvertisingfee == null)
                return;

            if (!this._context.IsAttached(xmadvertisingfee))

                this._context.XMAdvertisingFees.AddObject(xmadvertisingfee);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMAdvertisingFee
        /// </summary>
        /// <param name="xmadvertisingfee">XMAdvertisingFee</param>
        public void UpdateXMAdvertisingFee(XMAdvertisingFee xmadvertisingfee)
        {
            if (xmadvertisingfee == null)
                return;

            if (this._context.IsAttached(xmadvertisingfee))
                this._context.XMAdvertisingFees.Attach(xmadvertisingfee);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMAdvertisingFee list
        /// </summary>
        public List<XMAdvertisingFee> GetXMAdvertisingFeeList()
        {
            var query = from p in this._context.XMAdvertisingFees
                        orderby p.CreatorTime descending
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMAdvertisingFee Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAdvertisingFee Page List</returns>
        public PagedList<XMAdvertisingFee> SearchXMAdvertisingFee(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAdvertisingFees
                        orderby p.Id
                        select p;
            return new PagedList<XMAdvertisingFee>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// 根据条件查询广告费用
        /// </summary>
        /// <param name="NickId">店铺列表</param>
        /// <param name="min">开始时间</param>
        /// <param name="max">结束时间</param>
        /// <returns></returns>
        public List<XMAdvertisingFee> GetXMXMAdvertisingFeeByDetails(List<int> NickId, DateTime? min, DateTime? max)
        {
            var query = from f in this._context.XMAdvertisingFees
                        join n in this._context.XMNicks
                        on f.NickId equals n.nick_id
                        where f.Feedate >= min && f.Feedate < max
                        && NickId.Contains(f.NickId.Value)
                        orderby f.Feedate descending
                        select f;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nickId"></param>
        /// <returns></returns>
        public List<XMAdvertisingFee> GetXMXMAdvertisingFeeByParm(int nickId)
        {
            var query = from f in this._context.XMAdvertisingFees
                        where f.NickId == nickId
                        select f;
            return query.ToList();
        }

        /// <summary>
        /// 根据某店铺条件查询广告费用
        /// </summary>
        /// <param name="NickId">店铺</param>
        /// <param name="min">时间</param>
        /// <returns></returns>
        public List<XMAdvertisingFee> GetXMByIdmin(int NickId, DateTime? min)
        {

            var query = from f in this._context.XMAdvertisingFees
                        join n in this._context.XMNicks
                        on f.NickId equals n.nick_id
                        where f.Feedate == min
                        && (f.NickId == NickId || NickId == 0)
                        orderby f.Feedate descending
                        select f;
            return query.ToList();
        }

        /// <summary>
        /// get a XMAdvertisingFee by Id
        /// </summary>
        /// <param name="id">XMAdvertisingFee Id</param>
        /// <returns>XMAdvertisingFee</returns>   
        public XMAdvertisingFee GetXMAdvertisingFeeById(int id)
        {
            var query = from p in this._context.XMAdvertisingFees
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMAdvertisingFee by Id
        /// </summary>
        /// <param name="Id">XMAdvertisingFee Id</param>
        public void DeleteXMAdvertisingFee(int id)
        {
            var xmadvertisingfee = this.GetXMAdvertisingFeeById(id);
            if (xmadvertisingfee == null)
                return;

            if (!this._context.IsAttached(xmadvertisingfee))
                this._context.XMAdvertisingFees.Attach(xmadvertisingfee);

            this._context.DeleteObject(xmadvertisingfee);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMAdvertisingFee by Id
        /// </summary>
        /// <param name="Ids">XMAdvertisingFee Id</param>
        public void BatchDeleteXMAdvertisingFee(List<int> ids)
        {
            var query = from q in _context.XMAdvertisingFees
                        where ids.Contains(q.Id)
                        select q;
            var xmadvertisingfees = query.ToList();
            foreach (var item in xmadvertisingfees)
            {
                if (!_context.IsAttached(item))
                    _context.XMAdvertisingFees.Attach(item);

                _context.XMAdvertisingFees.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
