
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-04-09 10:25:24
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
    public partial class XMDeliveryDetailsService : IXMDeliveryDetailsService
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
        public XMDeliveryDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMDeliveryDetailsService成员
        /// <summary>
        /// Insert into XMDeliveryDetails
        /// </summary>
        /// <param name="xmdeliverydetails">XMDeliveryDetails</param>
        public void InsertXMDeliveryDetails(XMDeliveryDetails xmdeliverydetails)
        {
            if (xmdeliverydetails == null)
                return;

            if (!this._context.IsAttached(xmdeliverydetails))

                this._context.XMDeliveryDetails.AddObject(xmdeliverydetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMDeliveryDetails
        /// </summary>
        /// <param name="xmdeliverydetails">XMDeliveryDetails</param>
        public void UpdateXMDeliveryDetails(XMDeliveryDetails xmdeliverydetails)
        {
            if (xmdeliverydetails == null)
                return;

            if (this._context.IsAttached(xmdeliverydetails))
                this._context.XMDeliveryDetails.Attach(xmdeliverydetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMDeliveryDetails list
        /// </summary>
        public List<XMDeliveryDetails> GetXMDeliveryDetailsList()
        {
            var query = from p in this._context.XMDeliveryDetails
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMDeliveryDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDeliveryDetails Page List</returns>
        public PagedList<XMDeliveryDetails> SearchXMDeliveryDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMDeliveryDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMDeliveryDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMDeliveryDetails by Id
        /// </summary>
        /// <param name="id">XMDeliveryDetails Id</param>
        /// <returns>XMDeliveryDetails</returns>   
        public XMDeliveryDetails GetXMDeliveryDetailsById(int id)
        {
            var query = from p in this._context.XMDeliveryDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMDeliveryDetails by Id
        /// </summary>
        /// <param name="Id">XMDeliveryDetails Id</param>
        public void DeleteXMDeliveryDetails(int id)
        {
            var xmdeliverydetails = this.GetXMDeliveryDetailsById(id);
            if (xmdeliverydetails == null)
                return;

            if (!this._context.IsAttached(xmdeliverydetails))
                this._context.XMDeliveryDetails.Attach(xmdeliverydetails);

            this._context.DeleteObject(xmdeliverydetails);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMDeliveryDetails by Id
        /// </summary>
        /// <param name="Ids">XMDeliveryDetails Id</param>
        public void BatchDeleteXMDeliveryDetails(List<int> ids)
        {
            var query = from q in _context.XMDeliveryDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmdeliverydetailss = query.ToList();
            foreach (var item in xmdeliverydetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMDeliveryDetails.Attach(item);

                _context.XMDeliveryDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion

        /// <summary>
        /// 根据主表Id查询 
        /// </summary>
        /// <param name="DeliveryId">主表Id</param>
        /// <returns></returns>
        public List<XMDeliveryDetails> GetXMDeliveryDetailsByDeliveryId(int DeliveryId)
        {
            var query = from q in _context.XMDeliveryDetails
                        where q.DeliveryId == DeliveryId
                        && q.IsEnabled == false
                        select q;
            return query.ToList();
        }



        /// <summary>
        /// 根据明细Id查询
        /// </summary>
        /// <param name="Ids">明细Id集合</param>
        /// <returns></returns>
        public List<XMDeliveryDetails> GetXMDeliveryDetailsById(List<int> Ids)
        {
            var query = from q in _context.XMDeliveryDetails
                        where Ids.Contains(q.Id)
                        && q.IsEnabled == false
                        select q;
            return query.ToList();
        }


        /// <summary>
        /// 根据订单号、是否发货、未打印 查询 
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="IsDelivery">是否发货：0：未发货，1 :已发货</param>
        /// <param name="PrintQuantity">打印次数 ：0：未打印</param>
        /// <returns></returns>
        public List<XMDeliveryDetails> GetXMDeliveryDetailsSearchByOrderCodeList(string OrderCode, int IsDelivery, int PrintQuantity)
        {
            var query = from d in _context.XMDeliveryDetails
                        join q in _context.XMDeliveries
                        on d.DeliveryId equals q.Id
                        where d.OrderNo.Contains(OrderCode)
                        && (IsDelivery == -1 || q.IsDelivery.Value.Equals(IsDelivery == 0 ? false : true))
                        && q.PrintQuantity.Value == 0
                        select d;
            return query.ToList();
        }


        public List<XMDeliveryDetailsMapping> GetXMDeliveryDetailsMappingSearch(string OrderCode, string PartNo)
        {
            var query = from p in _context.XMDeliveryDetails
                        join q in _context.XMDeliveries
                        on p.DeliveryId equals q.Id
                        where p.OrderNo.Contains(OrderCode)
                        && p.PlatformMerchantCode.Contains(PartNo)
                        && p.IsEnabled == false
                        && q.IsEnabled == false
                        select new XMDeliveryDetailsMapping
                        {
                            Id = q.Id,
                            DeliveryTypeId = q.DeliveryTypeId,
                            DeliveryNumber = q.DeliveryNumber,
                            LogisticsNumber = q.LogisticsNumber,
                            LogisticsId = q.LogisticsId,
                            Price = q.Price,
                            IsDelivery = q.IsDelivery,
                            XMDeliveryDetailsId = p.Id,
                            OrderNo = p.OrderNo,
                            DetailsTypeId = p.DetailsTypeId,
                            ProductlId = p.ProductlId,
                            PlatformMerchantCode = p.PlatformMerchantCode,
                            PrdouctName = p.PrdouctName,
                            Specifications = p.Specifications,
                            ProductNum = p.ProductNum
                        };

            return new List<XMDeliveryDetailsMapping>(query);
        }

        /// <summary>
        /// 根据 发货单主表Id查询详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<XMDeliveryDetailsMapping> GetXMDeliveryDetailsMappingSearchList(int Id)
        {


            var query = from p in _context.XMDeliveryDetails
                        join q in _context.XMDeliveries
                        on p.DeliveryId equals q.Id
                        where q.Id == Id
                        && p.IsEnabled == false
                        && q.IsEnabled == false
                        select new XMDeliveryDetailsMapping
                        {
                            Id = q.Id,
                            DeliveryTypeId = q.DeliveryTypeId,
                            DeliveryNumber = q.DeliveryNumber,
                            LogisticsNumber = q.LogisticsNumber,
                            LogisticsId = q.LogisticsId,
                            Price = q.Price,
                            IsDelivery = q.IsDelivery,
                            XMDeliveryDetailsId = p.Id,
                            OrderNo = p.OrderNo,
                            DetailsTypeId = p.DetailsTypeId,
                            ProductlId = p.ProductlId,
                            PlatformMerchantCode = p.PlatformMerchantCode,
                            PrdouctName = p.PrdouctName,
                            Specifications = p.Specifications,
                            ProductNum = p.ProductNum,
                            WarehouseID=p.WarehouseID
                        };

            return new List<XMDeliveryDetailsMapping>(query);
        }

        /// <summary>
        /// 根据发货单ID和商品编码查询对应的发货单详细信息
        /// </summary>
        /// <param name="DeliveryNumberList">发货单号</param>
        /// <param name="PlatformMerchantCode">商品编码</param>
        /// <returns></returns>
        public IEnumerable<dynamic> GetXMDeliveryDetailsList(List<string> DeliveryNumberList)
        {
          
            var deliveryQuery = from p in _context.XMDeliveries
                        where DeliveryNumberList.Contains(p.DeliveryNumber)
                        select p;//找出所有选中的账单对应的发货单信息
            var orderCode = deliveryQuery.Select(m => m.OrderCode).ToList();

            var deliveryId = deliveryQuery.Select(m => m.Id).ToArray().Select(m=>(int?)m).ToList();

            var deliveryDetailsQuery = from p in _context.XMDeliveryDetails
                                       where deliveryId.Contains(p.DeliveryId)
                                       select p;

             var orderQuery = from p in _context.XMOrderInfoProductDetails
                        join q in _context.XMOrderInfoes
                        on p.OrderInfoID equals q.ID
                        where orderCode.Contains(q.OrderCode)
                        select new{
                            p.FactoryPrice,
                            q.OrderCode
                        };

             var deliveryDetailsArray = deliveryDetailsQuery.ToArray();
             var deliveryArray = deliveryQuery.ToArray();
             var orderArray = orderQuery.ToArray();

             var array = deliveryDetailsArray.Join(deliveryArray, m => m.DeliveryId, m => m.Id, (m, m1) => new
             {
                 m.PlatformMerchantCode,
                 m.ProductNum,
                 m1.VerificationStatus,
                 m1.DeliveryNumber,
                 m1.IsDelivery,
                 m1.OrderCode
             }).GroupJoin(orderArray, m => m.OrderCode, m => m.OrderCode, (m, m1) => new {
                 m.DeliveryNumber,
                 m.PlatformMerchantCode,
                 m.ProductNum,
                 m.IsDelivery,
                 m.VerificationStatus,
                 m1.FirstOrDefault().FactoryPrice
             });
            return array;
        }
    }
}
