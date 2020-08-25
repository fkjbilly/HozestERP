
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-08-04 09:20:45
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
using HozestERP.BusinessLogic.ManageBusiness;

namespace HozestERP.BusinessLogic.ManageApplication
{
    public partial class XMApplicationExchangeService : IXMApplicationExchangeService
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
        public XMApplicationExchangeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMApplicationExchangeService成员
        /// <summary>
        /// Insert into XMApplicationExchange
        /// </summary>
        /// <param name="xmapplicationexchange">XMApplicationExchange</param>
        public void InsertXMApplicationExchange(XMApplicationExchange xmapplicationexchange)
        {
            if (xmapplicationexchange == null)
                return;

            if (!this._context.IsAttached(xmapplicationexchange))

                this._context.XMApplicationExchanges.AddObject(xmapplicationexchange);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMApplicationExchange
        /// </summary>
        /// <param name="xmapplicationexchange">XMApplicationExchange</param>
        public void UpdateXMApplicationExchange(XMApplicationExchange xmapplicationexchange)
        {
            if (xmapplicationexchange == null)
                return;

            if (this._context.IsAttached(xmapplicationexchange))
                this._context.XMApplicationExchanges.Attach(xmapplicationexchange);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMApplicationExchange list
        /// </summary>
        public List<XMApplicationExchange> GetXMApplicationExchangeList()
        {
            var query = from p in this._context.XMApplicationExchanges
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMApplicationExchange Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMApplicationExchange Page List</returns>
        public PagedList<XMApplicationExchange> SearchXMApplicationExchange(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMApplicationExchanges
                        orderby p.ID
                        select p;
            return new PagedList<XMApplicationExchange>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMApplicationExchange by ID
        /// </summary>
        /// <param name="id">XMApplicationExchange ID</param>
        /// <returns>XMApplicationExchange</returns>   
        public XMApplicationExchange GetXMApplicationExchangeByID(int id)
        {
            var query = from p in this._context.XMApplicationExchanges
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public List<ProductSalesData> GetApplicationExchangeSalesArrange(List<XMApplicationExchange> DataList)
        {
            var list = from p in DataList
                       group p by new { p.ApplicaType, p.GoodsStatus, p.ProductName, p.Manufacturers, p.Specifications, p.FactoryPrice, p.ProductNum } into g
                       select new ProductSalesData
                       {
                           ApplicaType = g.Key.ApplicaType,
                           GoodsStatus = g.Key.GoodsStatus,
                           ProductName = g.Key.ProductName,
                           Manufacturers = g.Key.Manufacturers,
                           Specifications = g.Key.Specifications,
                           FactoryPrice = g.Key.FactoryPrice,
                           ProductNum = g.Sum(p => p.ProductNum)
                       };
            return list.ToList();
        }

        public List<XMApplicationExchange> GetApplicationExchangeSales(DateTime Begin, DateTime End, int ApplicaType, bool GoodsNotConfirmSendOut, bool GoodsConfirmSendOut, bool GoodsConfirmReturn, List<int?> NickIdList)
        {
            int[] ApplicaTypeList = { 5, 6, 7 };
            var query = from p in this._context.XMApplications
                        where p.IsEnable == false
                        && p.CreateDate >= Begin
                        && p.CreateDate <= End
                        && NickIdList.Contains(p.NickId)
                        && ((ApplicaType == -1 && ApplicaTypeList.Contains((int)p.ApplicationType)) || (ApplicaType != -1 && p.ApplicationType == ApplicaType))
                        && ((GoodsNotConfirmSendOut == true && (p.GoodsConfirmSendOut == null || p.GoodsConfirmSendOut == false))
                        || (GoodsConfirmSendOut == true && p.GoodsConfirmSendOut == true)
                        || (GoodsConfirmReturn == true && p.GoodsConfirmReturn == true)
                        )
                        select p;

            var Query = from p in this._context.XMApplicationExchanges
                        join q in query
                        on p.ApplicationId equals q.ID
                        where p.IsApplication == 2
                        select p;
            return Query.ToList();
        }

        /// <summary>
        /// delete XMApplicationExchange by ID
        /// </summary>
        /// <param name="ID">XMApplicationExchange ID</param>
        public void DeleteXMApplicationExchange(int id)
        {
            var xmapplicationexchange = this.GetXMApplicationExchangeByID(id);
            if (xmapplicationexchange == null)
                return;

            if (!this._context.IsAttached(xmapplicationexchange))
                this._context.XMApplicationExchanges.Attach(xmapplicationexchange);

            this._context.DeleteObject(xmapplicationexchange);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMApplicationExchange by ID
        /// </summary>
        /// <param name="IDs">XMApplicationExchange ID</param>
        public void BatchDeleteXMApplicationExchange(List<int> ids)
        {
            var query = from q in _context.XMApplicationExchanges
                        where ids.Contains(q.ID)
                        select q;
            var xmapplicationexchanges = query.ToList();
            foreach (var item in xmapplicationexchanges)
            {
                if (!_context.IsAttached(item))
                    _context.XMApplicationExchanges.Attach(item);

                _context.XMApplicationExchanges.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion

        /// <summary>
        /// 根据退换货主表id查询子表内容
        /// </summary>
        public List<XMApplicationExchange> GetXMApplicationExchangeByAppID(int? AppId, int type, int type2, int type3)
        {
            var query = from p in this._context.XMApplicationExchanges
                        where p.ApplicationId == AppId
                        && (p.IsApplication == type || type == 0 || p.IsApplication == type2 || p.IsApplication == type3)
                        select p;

            //筛选呼噜噜订单
            //query = from p in query
            //        join a in this._context.XMApplications
            //        on p.ApplicationId equals a.ID
            //        where (a.PlatformTypeId == 259 && (p.PlatformMerchantCode.StartsWith("CM") || p.PlatformMerchantCode == "" || p.PlatformMerchantCode == null))
            //        || a.PlatformTypeId != 259
            //        select p;

            return new List<XMApplicationExchange>(query.Distinct());
        }

        /// <summary>
        /// 根据退换货主表id查询子表内容
        /// </summary>
        /// <param name="AppId"></param>
        /// <returns></returns>
        public List<XMApplicationExchange> GetXMApplicationExchangeByAppID(int? AppId)
        {
            var query = from p in this._context.XMApplicationExchanges
                        where p.ApplicationId == AppId
                        select p;
            return new List<XMApplicationExchange>(query);
        }

        /// <summary>
        /// 根据订单产品id查询子表内容
        /// </summary>
        public XMApplicationExchange GetXMApplicationExchangeByIsOrID(int? AppId, int scid, int type)
        {
            var query = from p in this._context.XMApplicationExchanges
                        where p.IsOderDetails == AppId
                        && (p.ApplicationId == scid || scid == 0)
                        && p.IsApplication == type
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据订单换过货产品id查询子表内容
        /// </summary>
        public XMApplicationExchange GetXMApplicationExchangeByIsNewOrID(int? AppId, int scid, int type)
        {
            var query = from p in this._context.XMApplicationExchanges
                        where p.IsNewOderDetails == AppId
                        && (p.ApplicationId == scid || scid == 0)
                        && p.IsApplication == type
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据订单产品id查询子表内容列表
        /// </summary>
        public List<XMApplicationExchange> GetXMApplicationExchangeByIsOrIDlist(int? AppId, int scid, int type)
        {
            var query = from p in this._context.XMApplicationExchanges
                        where p.IsOderDetails == AppId
                        && (p.ApplicationId == scid || scid == 0)
                        && p.IsApplication == type
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据订单换过货产品id查询子表内容列表
        /// </summary>
        public List<XMApplicationExchange> GetXMApplicationExchangeByIsNewOrIDlist(int? AppId, int scid, int type)
        {
            var query = from p in this._context.XMApplicationExchanges
                        where p.IsNewOderDetails == AppId
                        && (p.ApplicationId == scid || scid == 0)
                        && p.IsApplication == type
                        select p;
            return query.ToList();
        }

        public List<XMApplicationExchange> GetXMApplicationExchangeListByApplicationIDType(int ApplicationID, int Type)
        {
            var query = from p in this._context.XMApplicationExchanges
                        where p.ApplicationId == ApplicationID
                        && p.IsApplication == Type
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 查询指定id换货成功的产品
        /// </summary>
        public List<XMApplicationExchange> GetXMApplicationExchangeByFinlist(string OrderCode, int type)
        {
            var query = from p in this._context.XMApplicationExchanges
                        join a in this._context.XMApplications
                        on p.ApplicationId equals a.ID
                        where a.OrderCode == OrderCode
                        && a.FinishTime != null
                        && a.FinancialStatus == true
                        && a.SupervisorStatus == true
                        && a.IsSend == true
                        && p.IsApplication == type
                        select p;
            if (type == 5)
            {
                query = from p in this._context.XMApplicationExchanges
                        join a in this._context.XMApplications
                        on p.ApplicationId equals a.ID
                        where a.OrderCode == OrderCode
                        && p.IsApplication == type
                        select p;
            }

            return query.ToList();
        }

        public List<XMApplicationExchange> GetXMApplicationExchangeByOrderCodeAndType(string OrderCode, int type,int scid)
        {
            var query = from p in this._context.XMApplicationExchanges
                        join a in this._context.XMApplications
                        on p.ApplicationId equals a.ID
                        where a.OrderCode == OrderCode && p.IsApplication == type && p.ApplicationId== scid
                        select p;

            return query.ToList();
        }

    }
}
