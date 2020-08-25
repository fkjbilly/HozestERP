
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
    public partial class XMSaleDeliveryService : IXMSaleDeliveryService
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
        public XMSaleDeliveryService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMSaleDeliveryService成员
        /// <summary>
        /// Insert into XMSaleDelivery
        /// </summary>
        /// <param name="xmsaledelivery">XMSaleDelivery</param>
        public void InsertXMSaleDelivery(XMSaleDelivery xmsaledelivery)
        {
            if (xmsaledelivery == null)
                return;

            if (!this._context.IsAttached(xmsaledelivery))

                this._context.XMSaleDeliveries.AddObject(xmsaledelivery);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMSaleDelivery
        /// </summary>
        /// <param name="xmsaledelivery">XMSaleDelivery</param>
        public void UpdateXMSaleDelivery(XMSaleDelivery xmsaledelivery)
        {
            if (xmsaledelivery == null)
                return;

            if (this._context.IsAttached(xmsaledelivery))
                this._context.XMSaleDeliveries.Attach(xmsaledelivery);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMSaleDelivery list
        /// </summary>
        public List<XMSaleDelivery> GetXMSaleDeliveryList()
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.IsEnable == false
                        orderby p.Id descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHoueseID"></param>
        /// <returns></returns>
        public List<XMSaleDelivery> GetXMSaleDeliveryListByPremiums(int wareHoueseID)
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.IsEnable == false
                        && p.PremiumsID != null
                        && p.BillStatus == 0
                        && p.WareHouseId == wareHoueseID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderCode"></param>
        /// <returns></returns>
        public List<XMSaleDelivery> GetXMSaleDeliveryListByOrderInfoID(int orderInfoID)
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.IsEnable == false && p.OrderInfoID == orderInfoID
                        select p;
            return query.ToList();
        }

        public List<XMSaleDelivery> GetXMSaleDeliveryListOtherProject(DateTime begin, DateTime end, List<int> WareHousesList)
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.IsEnable == false
                        && p.IsAudit == true
                        && p.BillStatus != 0
                        && WareHousesList.Contains(p.WareHouseId)
                        && p.BizDt >= begin
                        && p.BizDt < end
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleInfoID"></param>
        /// <returns></returns>
        public List<XMSaleDelivery> GetXMSaleDeliveryListBySaleInfoID(int saleInfoID)
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.IsEnable == false && p.SaleInfoId == saleInfoID
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleInfoID"></param>
        /// <returns></returns>
        public List<XMSaleDelivery> GetXMSaleDeliveryListByDeliveryStatus(int saleInfoID)
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.IsEnable == false && p.SaleInfoId == saleInfoID && p.BillStatus == 1000
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据仓库ID查询出库单列表
        /// </summary>
        /// <param name="wareHourseID"></param>
        /// <returns></returns>
        public List<XMSaleDelivery> GetXMSaleDeliveryListByWareHoursesID(int wareHourseID)
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.IsEnable == false
                        && p.WareHouseId == wareHourseID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deliveryCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="wareHourseId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<XMSaleDelivery> GetXMSaleDeliveryListByParm(string deliveryCode, string begin, string end, string wareHourseId, int status, int projectId, string nickids, string saleCode, int bizUserId)
        {
            int?[] wareHourseIdlist = Array.ConvertAll<string, int?>(wareHourseId.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }
            if (saleCode != "")
            {
                //出库单中通过线下销售订单生成的
                var query = from p in this._context.XMSaleDeliveries
                            join t in this._context.XMWareHouses
                            on p.WareHouseId equals t.Id
                            join y in this._context.XMSaleInfoes
                            on p.SaleInfoId equals y.Id
                            where p.IsEnable == false
                            && y.Ref.Contains(saleCode)
                            && (deliveryCode == "" || p.Ref.Contains(deliveryCode))
                              && ((begin == "" && end == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                              && wareHourseIdlist.Contains(p.WareHouseId)
                             && (status == -1 || p.BillStatus == status)
                             && (bizUserId == -1 || p.BizUserId == bizUserId)
                             && p.OrderInfoID == 0
                            orderby p.CreateDate descending
                            select p;

                //出库单是通过线上订单生成的
                var query1 = from p in this._context.XMSaleDeliveries
                             join t1 in this._context.XMWareHouses
                               on p.WareHouseId equals t1.Id
                             join y1 in this._context.XMOrderInfoes
                                on p.OrderInfoID equals y1.ID
                             where p.IsEnable == false
                             && y1.IsEnable == false
                              && y1.OrderCode.Contains(saleCode)
                                && (deliveryCode == "" || p.Ref.Contains(deliveryCode))
                                   && ((begin == "" && end == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                                    && wareHourseIdlist.Contains(p.WareHouseId)
                                    && (status == -1 || p.BillStatus == status)
                                   && (bizUserId == -1 || p.BizUserId == bizUserId)
                             orderby p.CreateDate descending
                             select p;

                //合并两个集合
                var hebingQuery = query.Union(query1);
                return hebingQuery.ToList();
            }
            else
            {
                var query = from p in this._context.XMSaleDeliveries
                            join t in this._context.XMWareHouses
                            on p.WareHouseId equals t.Id
                            where p.IsEnable == false
                              && (deliveryCode == "" || p.Ref.Contains(deliveryCode))
                           && ((begin == "" && end == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                                && wareHourseIdlist.Contains(p.WareHouseId)
                          && (status == -1 || p.BillStatus == status)
                          && (bizUserId == -1 || p.BizUserId == bizUserId)
                            orderby p.CreateDate descending
                            select p;
                return query.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="wareHourseId"></param>
        /// <returns></returns>
        public List<XMSaleDelivery> GetXMSaleDeliveryListByParm(string begin, string end, int wareHourseId)
        {
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            //排除双十一三天  （11-10  11-11  11-12）   618 节点 （6-16 6-17 6-18 6-19）
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMSaleDeliveries
                        join t in this._context.XMWareHouses
                 on p.WareHouseId equals t.Id
                        where p.IsEnable == false
                        && p.BillStatus == 1000
                          && ((begin == "" && end == "") || ((p.BizDt >= purBeginTime && p.BizDt <= purEndTime) && !((p.BizDt.Value.Month == 11 && p.BizDt.Value.Day == 10) || (p.BizDt.Value.Month == 11 && p.BizDt.Value.Day == 11) || (p.BizDt.Value.Month == 11 && p.BizDt.Value.Day == 12) || (p.BizDt.Value.Month == 6 && p.BizDt.Value.Day == 16) || (p.BizDt.Value.Month == 6 && p.BizDt.Value.Day == 17) || (p.BizDt.Value.Month == 6 && p.BizDt.Value.Day == 18) || (p.BizDt.Value.Month == 6 && p.BizDt.Value.Day == 19))))
                            && (wareHourseId == -1 || p.WareHouseId == wareHourseId)
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="wareHourseId"></param>
        /// <returns></returns>
        public XMSaleDelivery GetXMSaleDeliveryByParm(string begin, int wareHourseId)
        {
            DateTime purBeginTime = DateTime.Now;
            if (begin != "")
            {
                purBeginTime = DateTime.Parse(begin);
            }
            var query = from p in this._context.XMSaleDeliveries
                        join t in this._context.XMWareHouses
                 on p.WareHouseId equals t.Id
                        where p.IsEnable == false
                           && p.BillStatus == 1000
                           && p.BizDt == purBeginTime
                           && p.WareHouseId == wareHourseId
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="premiumsID"></param>
        /// <param name="deliveryID"></param>
        /// <returns></returns>
        public XMSaleDelivery GetXMSaleDeliveryByParm(int premiumsID, int deliveryID)
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.IsEnable == false
                        && p.PremiumsID == premiumsID
                        && p.DeliveryID == deliveryID
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deliveryID"></param>
        /// <returns></returns>
        public List<XMSaleDelivery> GetXMSaleDeliveryListByParm(int deliveryID)
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.IsEnable == false
                        && p.DeliveryID == deliveryID
                        && p.BillStatus == 0
                        select p;
            return query.ToList();
        }

        public List<XMSaleDelivery> GetXMSaleDeliveryListByDeliveryID(int deliveryID)
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.IsEnable == false
                        && p.DeliveryID == deliveryID
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="deliveryCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="wareHourseId"></param>
        /// <param name="status"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        public List<XMSaleDelivery> GetXMSaleDeliveryListByProjectID(string deliveryCode, string begin, string end, int wareHourseId, int status, string projectids, int projectId, string saleCode, int bizUserId)
        {
            int?[] projectlist = Array.ConvertAll<string, int?>(projectids.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }
            if (saleCode != "")
            {
                var query = from p in this._context.XMSaleDeliveries
                            join t in this._context.XMWareHouses
                            on p.WareHouseId equals t.Id
                            join d in this._context.XMSaleInfoes
                            on p.SaleInfoId equals d.Id
                            where p.IsEnable == false
                              && d.Ref.Contains(saleCode)
                              && (deliveryCode == "" || p.Ref.Contains(deliveryCode))
                              && ((begin == "" && end == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                              && (wareHourseId == -1 || p.WareHouseId == wareHourseId)
                              && (status == -1 || p.BillStatus == status)
                              && ((t.NickId == -1 || t.NickId == 99) && projectlist.Contains(t.ProjectId))
                              && (projectId == -1 || t.ProjectId == projectId)
                              && (bizUserId == -1 || p.BizUserId == bizUserId)
                              && p.OrderInfoID == 0
                            orderby p.CreateDate descending
                            select p;

                //出库单是通过线上订单生成的
                var query1 = from p in this._context.XMSaleDeliveries
                             join t1 in this._context.XMWareHouses
                               on p.WareHouseId equals t1.Id
                             join y1 in this._context.XMOrderInfoes
                                on p.OrderInfoID equals y1.ID
                             where p.IsEnable == false
                             && y1.IsEnable == false
                              && y1.OrderCode.Contains(saleCode)
                                && (deliveryCode == "" || p.Ref.Contains(deliveryCode))
                              && ((begin == "" && end == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                              && (wareHourseId == -1 || p.WareHouseId == wareHourseId)
                              && (status == -1 || p.BillStatus == status)
                              && ((t1.NickId == -1 || t1.NickId == 99) && projectlist.Contains(t1.ProjectId))
                              && (projectId == -1 || t1.ProjectId == projectId)
                              && (bizUserId == -1 || p.BizUserId == bizUserId)
                             orderby p.CreateDate descending
                             select p;

                //合并两个集合
                var hebingQuery = query.Union(query1);
                return hebingQuery.ToList();
            }
            else
            {
                var query = from p in this._context.XMSaleDeliveries
                            join t in this._context.XMWareHouses
                            on p.WareHouseId equals t.Id
                            where p.IsEnable == false
                                 && (deliveryCode == "" || p.Ref.Contains(deliveryCode))
                                                        && ((begin == "" && end == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                                                        && (wareHourseId == -1 || p.WareHouseId == wareHourseId)
                                                        && (status == -1 || p.BillStatus == status)
                                                        && ((t.NickId == -1 || t.NickId == 99) && projectlist.Contains(t.ProjectId))
                                                        && (projectId == -1 || t.ProjectId == projectId)
                                                        && (bizUserId == -1 || p.BizUserId == bizUserId)
                            orderby p.CreateDate descending
                            select p;
                return query.ToList();
            }
        }

        /// <summary>
        /// get to XMSaleDelivery Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleDelivery Page List</returns>
        public PagedList<XMSaleDelivery> SearchXMSaleDelivery(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMSaleDeliveries
                        orderby p.Id
                        select p;
            return new PagedList<XMSaleDelivery>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMSaleDelivery by Id
        /// </summary>
        /// <param name="id">XMSaleDelivery Id</param>
        /// <returns>XMSaleDelivery</returns>   
        public XMSaleDelivery GetXMSaleDeliveryById(int id)
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMSaleDelivery by Id
        /// </summary>
        /// <param name="Id">XMSaleDelivery Id</param>
        public void DeleteXMSaleDelivery(int id)
        {
            var xmsaledelivery = this.GetXMSaleDeliveryById(id);
            if (xmsaledelivery == null)
                return;

            if (!this._context.IsAttached(xmsaledelivery))
                this._context.XMSaleDeliveries.Attach(xmsaledelivery);

            this._context.DeleteObject(xmsaledelivery);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMSaleDelivery by Id
        /// </summary>
        /// <param name="Ids">XMSaleDelivery Id</param>
        public void BatchDeleteXMSaleDelivery(List<int> ids)
        {
            var query = from q in _context.XMSaleDeliveries
                        where ids.Contains(q.Id)
                        select q;
            var xmsaledeliverys = query.ToList();
            foreach (var item in xmsaledeliverys)
            {
                if (!_context.IsAttached(item))
                    _context.XMSaleDeliveries.Attach(item);

                _context.XMSaleDeliveries.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
