
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-08-24 09:15:46
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
    public partial class XMInvoiceInfoService : IXMInvoiceInfoService
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
        public XMInvoiceInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMInvoiceInfoService成员
        /// <summary>
        /// Insert into XMInvoiceInfo
        /// </summary>
        /// <param name="xminvoiceinfo">XMInvoiceInfo</param>
        public void InsertXMInvoiceInfo(XMInvoiceInfo xminvoiceinfo)
        {
            if (xminvoiceinfo == null)
                return;

            if (!this._context.IsAttached(xminvoiceinfo))

                this._context.XMInvoiceInfoes.AddObject(xminvoiceinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMInvoiceInfo
        /// </summary>
        /// <param name="xminvoiceinfo">XMInvoiceInfo</param>
        public void UpdateXMInvoiceInfo(XMInvoiceInfo xminvoiceinfo)
        {
            if (xminvoiceinfo == null)
                return;

            if (this._context.IsAttached(xminvoiceinfo))
                this._context.XMInvoiceInfoes.Attach(xminvoiceinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMInvoiceInfo list
        /// </summary>
        public List<XMInvoiceInfo> GetXMInvoiceInfoList()
        {
            var query = from p in this._context.XMInvoiceInfoes
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMInvoiceInfo> GetXMInvoiceInfoListByOrderCode(string OrderCode)
        {
            var query = from p in this._context.XMInvoiceInfoes
                        where p.IsEnable == false
                        && p.OrderCode == OrderCode
                        select p;
            return query.ToList();
        }

        public List<XMInvoiceInfo> GetXMInvoiceInfoListByIds(List<int> Ids)
        {
            var query = from p in this._context.XMInvoiceInfoes
                        where p.IsEnable == false
                        && Ids.Contains(p.ID)
                        select p;
            return query.ToList();
        }

        public List<XMInvoiceInfo> GetXMInvoiceInfoListByParm(string begin, string end, int bingling, int InvoiceStatus, int InvoiceType, string OrderCode, string InvoiceHeader, int SingleRow, int ProjectId, int NickId)
        {
            DateTime CrateBeginTime = DateTime.Now;
            DateTime CreateEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                CrateBeginTime = DateTime.Parse(begin);
                CreateEndTime = DateTime.Parse(end);
            }

            bool singleRow = false;
            if (SingleRow == 1)
            {
                singleRow = true;
            }
            bool isBilling = false;
            if (bingling == 1)
            {
                isBilling = true;
            }
            if (bingling == -1 || bingling == 1)
            {
                var query = from p in this._context.XMInvoiceInfoes
                            join o in this._context.XMOrderInfoes
                            on p.OrderCode equals o.OrderCode
                            join n in this._context.XMNicks
                            on o.NickID equals n.nick_id

                            //join o in this._context.XMOrderInfoes
                            //on p.OrderCode equals o.OrderCode into O
                            //from o in O.DefaultIfEmpty()
                            //join n in this._context.XMNicks
                            //on o.NickID equals n.nick_id into N
                            //from n in N.DefaultIfEmpty()

                            where p.IsEnable == false
                                //&& (o == null || o.IsEnable == false)
                                //&& (n == null || n.isEnable == true)
                            && o.IsEnable == false
                            && n.isEnable == true
                            && (ProjectId == -1 || n.ProjectId == ProjectId)
                            && (NickId == -1 || NickId == 99 || o.NickID == NickId)
                            && (InvoiceStatus == -1 || p.InvoiceStatus == InvoiceStatus)
                            && (InvoiceType == -1 || p.InvoiceType == InvoiceType)
                            && (SingleRow == -1 || p.IsSingleRow == singleRow)
                            && (bingling == -1 || p.IsBilling == isBilling)
                            && (OrderCode == "" || p.OrderCode == OrderCode)
                            && ((begin == "" && end == "") || (p.CreateDate >= CrateBeginTime && p.CreateDate < CreateEndTime))
                            && p.InvoiceHeader.Contains(InvoiceHeader)
                            orderby p.CreateDate descending
                            select p;
                return query.ToList();
            }
            else
            {
                var query = from p in this._context.XMInvoiceInfoes
                            join o in this._context.XMOrderInfoes
                            on p.OrderCode equals o.OrderCode
                            join n in this._context.XMNicks
                            on o.NickID equals n.nick_id

                            //join o in this._context.XMOrderInfoes
                            //on p.OrderCode equals o.OrderCode into O
                            //from o in O.DefaultIfEmpty()
                            //join n in this._context.XMNicks
                            //on o.NickID equals n.nick_id into N
                            //from n in N.DefaultIfEmpty()

                            where p.IsEnable == false
                                //&& (o == null || o.IsEnable == false)
                                //&& (n == null || n.isEnable == true)
                            && o.IsEnable == false
                            && n.isEnable == true
                            && (ProjectId == -1 || n.ProjectId == ProjectId)
                            && (NickId == -1 || NickId == 99 || o.NickID == NickId)
                            && (InvoiceStatus == -1 || p.InvoiceStatus == InvoiceStatus)
                            && (InvoiceType == -1 || p.InvoiceType == InvoiceType)
                            && (SingleRow == -1 || p.IsSingleRow == singleRow)
                            && (p.IsBilling == isBilling || p.IsBilling == null)
                            && (OrderCode == "" || p.OrderCode == OrderCode)
                            && ((begin == "" && end == "") || (p.CreateDate >= CrateBeginTime && p.CreateDate < CreateEndTime))
                            && p.InvoiceHeader.Contains(InvoiceHeader)
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
        /// <param name="bingling"></param>
        /// <param name="InvoiceStatus"></param>
        /// <param name="InvoiceType"></param>
        /// <param name="OrderCode"></param>
        /// <param name="InvoiceHeader"></param>
        /// <param name="SingleRow"></param>
        /// <param name="ProjectId"></param>
        /// <param name="NickId"></param>
        /// <param name="OrderStatus"></param>
        /// <returns></returns>
        public List<XMInvoiceInfo> GetXMInvoiceInfoListByParm(string begin, string end, int bingling, int InvoiceStatus, int InvoiceType, string OrderCode, string InvoiceHeader, int SingleRow, int ProjectId, int NickId, List<string> OrderStatus)
        {
            DateTime CrateBeginTime = DateTime.Now;
            DateTime CreateEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                CrateBeginTime = DateTime.Parse(begin);
                CreateEndTime = DateTime.Parse(end);
            }

            bool singleRow = false;
            if (SingleRow == 1)
            {
                singleRow = true;
            }
            bool isBilling = false;
            if (bingling == 1)
            {
                isBilling = true;
            }
            if (bingling == -1 || bingling == 1)
            {
                var query = from p in this._context.XMInvoiceInfoes
                            join o in this._context.XMOrderInfoes
                            on p.OrderCode equals o.OrderCode
                            join n in this._context.XMNicks
                            on o.NickID equals n.nick_id

                            //join o in this._context.XMOrderInfoes
                            //on p.OrderCode equals o.OrderCode into O
                            //from o in O.DefaultIfEmpty()
                            //join n in this._context.XMNicks
                            //on o.NickID equals n.nick_id into N
                            //from n in N.DefaultIfEmpty()

                            where p.IsEnable == false
                                //&& (o == null || o.IsEnable == false)
                                //&& (n == null || n.isEnable == true)
                            && o.IsEnable == false
                            && n.isEnable == true
                            && (ProjectId == -1 || n.ProjectId == ProjectId)
                            && (NickId == -1 || NickId == 99 || o.NickID == NickId)
                            && (InvoiceStatus == -1 || p.InvoiceStatus == InvoiceStatus)
                            && (InvoiceType == -1 || p.InvoiceType == InvoiceType)
                            && (SingleRow == -1 || p.IsSingleRow == singleRow)
                            && (bingling == -1 || p.IsBilling == isBilling)
                            && (OrderCode == "" || p.OrderCode == OrderCode)
                            && OrderStatus.Contains(o.OrderStatus)
                            && ((begin == "" && end == "") || (p.CreateDate >= CrateBeginTime && p.CreateDate < CreateEndTime))
                            && p.InvoiceHeader.Contains(InvoiceHeader)
                            orderby p.CreateDate descending
                            select p;
                return query.ToList();
            }
            else
            {
                var query = from p in this._context.XMInvoiceInfoes
                            join o in this._context.XMOrderInfoes
                            on p.OrderCode equals o.OrderCode
                            join n in this._context.XMNicks
                            on o.NickID equals n.nick_id

                            //join o in this._context.XMOrderInfoes
                            //on p.OrderCode equals o.OrderCode into O
                            //from o in O.DefaultIfEmpty()
                            //join n in this._context.XMNicks
                            //on o.NickID equals n.nick_id into N
                            //from n in N.DefaultIfEmpty()

                            where p.IsEnable == false
                                //&& (o == null || o.IsEnable == false)
                                //&& (n == null || n.isEnable == true)
                            && o.IsEnable == false
                            && n.isEnable == true
                            && (ProjectId == -1 || n.ProjectId == ProjectId)
                            && (NickId == -1 || NickId == 99 || o.NickID == NickId)
                            && (InvoiceStatus == -1 || p.InvoiceStatus == InvoiceStatus)
                            && (InvoiceType == -1 || p.InvoiceType == InvoiceType)
                            && (SingleRow == -1 || p.IsSingleRow == singleRow)
                            && (p.IsBilling == isBilling || p.IsBilling == null)
                            && (OrderCode == "" || p.OrderCode == OrderCode)
                            && OrderStatus.Contains(o.OrderStatus)
                            && ((begin == "" && end == "") || (p.CreateDate >= CrateBeginTime && p.CreateDate < CreateEndTime))
                            && p.InvoiceHeader.Contains(InvoiceHeader)
                            orderby p.CreateDate descending
                            select p;
                return query.ToList();
            }
        }

        /// <summary>
        /// get to XMInvoiceInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInvoiceInfo Page List</returns>
        public PagedList<XMInvoiceInfo> SearchXMInvoiceInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInvoiceInfoes
                        orderby p.ID
                        select p;
            return new PagedList<XMInvoiceInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMInvoiceInfo by ID
        /// </summary>
        /// <param name="id">XMInvoiceInfo ID</param>
        /// <returns>XMInvoiceInfo</returns>   
        public XMInvoiceInfo GetXMInvoiceInfoByID(int id)
        {
            var query = from p in this._context.XMInvoiceInfoes
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public List<XMInvoiceInfo> GetXMInvoiceInfoListByInvoiceNo(string InvoiceNo)
        {
            var query = from p in this._context.XMInvoiceInfoes
                        where p.IsEnable == false
                        && p.InvoiceNo == InvoiceNo
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// delete XMInvoiceInfo by ID
        /// </summary>
        /// <param name="ID">XMInvoiceInfo ID</param>
        public void DeleteXMInvoiceInfo(int id)
        {
            var xminvoiceinfo = this.GetXMInvoiceInfoByID(id);
            if (xminvoiceinfo == null)
                return;

            if (!this._context.IsAttached(xminvoiceinfo))
                this._context.XMInvoiceInfoes.Attach(xminvoiceinfo);

            this._context.DeleteObject(xminvoiceinfo);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMInvoiceInfo by ID
        /// </summary>
        /// <param name="IDs">XMInvoiceInfo ID</param>
        public void BatchDeleteXMInvoiceInfo(List<int> ids)
        {
            var query = from q in _context.XMInvoiceInfoes
                        where ids.Contains(q.ID)
                        select q;
            var xminvoiceinfos = query.ToList();
            foreach (var item in xminvoiceinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMInvoiceInfoes.Attach(item);

                _context.XMInvoiceInfoes.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
