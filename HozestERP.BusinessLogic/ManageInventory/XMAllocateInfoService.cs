
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-06-08 08:58:37
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
    public partial class XMAllocateInfoService : IXMAllocateInfoService
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
        public XMAllocateInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMAllocateInfoService成员
        /// <summary>
        /// Insert into XMAllocateInfo
        /// </summary>
        /// <param name="xmallocateinfo">XMAllocateInfo</param>
        public void InsertXMAllocateInfo(XMAllocateInfo xmallocateinfo)
        {
            if (xmallocateinfo == null)
                return;

            if (!this._context.IsAttached(xmallocateinfo))

                this._context.XMAllocateInfoes.AddObject(xmallocateinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMAllocateInfo
        /// </summary>
        /// <param name="xmallocateinfo">XMAllocateInfo</param>
        public void UpdateXMAllocateInfo(XMAllocateInfo xmallocateinfo)
        {
            if (xmallocateinfo == null)
                return;

            if (this._context.IsAttached(xmallocateinfo))
                this._context.XMAllocateInfoes.Attach(xmallocateinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMAllocateInfo list
        /// </summary>
        public List<XMAllocateInfo> GetXMAllocateInfoList()
        {
            var query = from p in this._context.XMAllocateInfoes
                        where p.IsEnable == false
                        orderby p.Id descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dbCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="projectIdFrom"></param>
        /// <param name="projectIdTo"></param>
        /// <param name="wareHousesIdFrom"></param>
        /// <param name="wareHousesIdTo"></param>
        /// <returns></returns>
        public List<XMAllocateInfo> GetXMAllocateInfoListByParm(string nickids, int status, string dbCode, string begin, string end, string wareHousesIdFrom, string wareHousesIdTo, int projectId)
        {
            int?[] wareHousesIdFroms = Array.ConvertAll<string, int?>(wareHousesIdFrom.Split(','), delegate(string s) { return int.Parse(s); });
            int?[] wareHousesIdTos = Array.ConvertAll<string, int?>(wareHousesIdTo.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime dbBeginTime = DateTime.Now;
            DateTime dbEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                dbBeginTime = DateTime.Parse(begin);
                dbEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMAllocateInfoes
                        where p.IsEnable == false
                        && (dbCode == "" || p.Ref.Contains(dbCode))
                        && ((begin == "" && end == "") || (p.BizDt >= dbBeginTime && p.BizDt < dbEndTime))
                        && wareHousesIdFroms.Contains(p.From_WarehouseId)
                        && wareHousesIdTos.Contains(p.To_WarehouseId)
                        && (status == -1 || p.BillStatus == status)
                        orderby p.BizDt descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// nickid ==-1 && projectid!=-1
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dbCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="wareHousesIdFrom"></param>
        /// <param name="wareHousesIdTo"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        public List<XMAllocateInfo> GetXMAllocateInfoListByPorjectID(int status, string dbCode, string begin, string end, int wareHousesIdFrom, int wareHousesIdTo, string projectids, int projectId)
        {
            int?[] projectlist = Array.ConvertAll<string, int?>(projectids.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime dbBeginTime = DateTime.Now;
            DateTime dbEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                dbBeginTime = DateTime.Parse(begin);
                dbEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMAllocateInfoes
                        join t in this._context.XMWareHouses
                        on p.From_WarehouseId equals t.Id
                        where p.IsEnable == false
                        && (dbCode == "" || p.Ref.Contains(dbCode))
                        && ((begin == "" && end == "") || (p.BizDt >= dbBeginTime && p.BizDt < dbEndTime))
                         && (wareHousesIdFrom == -1 || p.From_WarehouseId == wareHousesIdFrom)
                          && (wareHousesIdTo == -1 || p.To_WarehouseId == wareHousesIdTo)
                             && ((t.NickId == -1 || t.NickId == 99) && projectlist.Contains(t.ProjectId))
                               && (projectId == -1 || t.ProjectId == projectId)
                            && (status == -1 || p.BillStatus == status)
                        orderby p.BizDt descending
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMAllocateInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAllocateInfo Page List</returns>
        public PagedList<XMAllocateInfo> SearchXMAllocateInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAllocateInfoes
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMAllocateInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMAllocateInfo by Id
        /// </summary>
        /// <param name="id">XMAllocateInfo Id</param>
        /// <returns>XMAllocateInfo</returns>   
        public XMAllocateInfo GetXMAllocateInfoById(int id)
        {
            var query = from p in this._context.XMAllocateInfoes
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMAllocateInfo by Id
        /// </summary>
        /// <param name="Id">XMAllocateInfo Id</param>
        public void DeleteXMAllocateInfo(int id)
        {
            var xmallocateinfo = this.GetXMAllocateInfoById(id);
            if (xmallocateinfo == null)
                return;

            if (!this._context.IsAttached(xmallocateinfo))
                this._context.XMAllocateInfoes.Attach(xmallocateinfo);

            this._context.DeleteObject(xmallocateinfo);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMAllocateInfo by Id
        /// </summary>
        /// <param name="Ids">XMAllocateInfo Id</param>
        public void BatchDeleteXMAllocateInfo(List<int> ids)
        {
            var query = from q in _context.XMAllocateInfoes
                        where ids.Contains(q.Id)
                        select q;
            var xmallocateinfos = query.ToList();
            foreach (var item in xmallocateinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMAllocateInfoes.Attach(item);

                _context.XMAllocateInfoes.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
