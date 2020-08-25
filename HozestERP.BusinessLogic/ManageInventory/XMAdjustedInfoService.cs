
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
    public partial class XMAdjustedInfoService : IXMAdjustedInfoService
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
        public XMAdjustedInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMAdjustedInfoService成员
        /// <summary>
        /// Insert into XMAdjustedInfo
        /// </summary>
        /// <param name="xmadjustedinfo">XMAdjustedInfo</param>
        public void InsertXMAdjustedInfo(XMAdjustedInfo xmadjustedinfo)
        {
            if (xmadjustedinfo == null)
                return;

            if (!this._context.IsAttached(xmadjustedinfo))

                this._context.XMAdjustedInfoes.AddObject(xmadjustedinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMAdjustedInfo
        /// </summary>
        /// <param name="xmadjustedinfo">XMAdjustedInfo</param>
        public void UpdateXMAdjustedInfo(XMAdjustedInfo xmadjustedinfo)
        {
            if (xmadjustedinfo == null)
                return;

            if (this._context.IsAttached(xmadjustedinfo))
                this._context.XMAdjustedInfoes.Attach(xmadjustedinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMAdjustedInfo list
        /// </summary>
        public List<XMAdjustedInfo> GetXMAdjustedInfoList()
        {
            var query = from p in this._context.XMAdjustedInfoes
                        where p.IsEnable == false
                        orderby p.Id descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjustedCode"></param>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <param name="wareHousesId"></param>
        /// <returns></returns>
        public List<XMAdjustedInfo> GetXMAdjustedInfoByParm(string adjustedCode, string begin, string end, string wareHousesId, int projectId, string nickids)
        {
            int?[] wareHousesIdlist = Array.ConvertAll<string, int?>(wareHousesId.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMAdjustedInfoes
                        join t in this._context.XMWareHouses
                        on p.WarehouseId equals t.Id
                        where p.IsEnable == false
                        && (adjustedCode == "" || p.Ref.Contains(adjustedCode))
                         && ((begin == "" && end == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                        && wareHousesIdlist.Contains(p.WarehouseId)
                         && (projectId == -1 || projectId == 99 || t.ProjectId == projectId)
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjustedCode"></param>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <param name="wareHousesId"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        public List<XMAdjustedInfo> GetXMAdjustedInfoByProjectID(string adjustedCode, string Begin, string End, int wareHousesId, string projectids, int projectId)
        {
            int?[] projectlist = Array.ConvertAll<string, int?>(projectids.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (Begin != "" && End != "")
            {
                purBeginTime = DateTime.Parse(Begin);
                purEndTime = DateTime.Parse(End);
            }
            var query = from p in this._context.XMAdjustedInfoes
                        join t in this._context.XMWareHouses
                        on p.WarehouseId equals t.Id
                        where p.IsEnable == false
                         && (adjustedCode == "" || p.Ref.Contains(adjustedCode))
                         && ((Begin == "" && End == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                         && (wareHousesId == -1 || p.WarehouseId == wareHousesId)
                         && ((t.NickId == -1 || t.NickId == 99) && projectlist.Contains(t.ProjectId))
                         && (projectId == -1 || t.ProjectId == projectId)
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMAdjustedInfo List by WareHousesID
        /// </summary>
        /// <param name="wareHousesID"></param>
        /// <returns></returns>
        public List<XMAdjustedInfo> GetXMAdjustedInfoByWareHousesID(int wareHousesID)
        {
            var query = from p in this._context.XMAdjustedInfoes
                        where p.IsEnable == false
                        && p.WarehouseId == wareHousesID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMAdjustedInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAdjustedInfo Page List</returns>
        public PagedList<XMAdjustedInfo> SearchXMAdjustedInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAdjustedInfoes
                        orderby p.Id
                        select p;
            return new PagedList<XMAdjustedInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMAdjustedInfo by Id
        /// </summary>
        /// <param name="id">XMAdjustedInfo Id</param>
        /// <returns>XMAdjustedInfo</returns>   
        public XMAdjustedInfo GetXMAdjustedInfoById(int id)
        {
            var query = from p in this._context.XMAdjustedInfoes
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据单号查询
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public XMAdjustedInfo GetXMAdjustedInfoByRef(string code)
        {
            var query = from p in this._context.XMAdjustedInfoes
                        where p.IsEnable == false
                        && p.Ref == code
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMAdjustedInfo by Id
        /// </summary>
        /// <param name="Id">XMAdjustedInfo Id</param>
        public void DeleteXMAdjustedInfo(int id)
        {
            var xmadjustedinfo = this.GetXMAdjustedInfoById(id);
            if (xmadjustedinfo == null)
                return;

            if (!this._context.IsAttached(xmadjustedinfo))
                this._context.XMAdjustedInfoes.Attach(xmadjustedinfo);

            this._context.DeleteObject(xmadjustedinfo);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMAdjustedInfo by Id
        /// </summary>
        /// <param name="Ids">XMAdjustedInfo Id</param>
        public void BatchDeleteXMAdjustedInfo(List<int> ids)
        {
            var query = from q in _context.XMAdjustedInfoes
                        where ids.Contains(q.Id)
                        select q;
            var xmadjustedinfos = query.ToList();
            foreach (var item in xmadjustedinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMAdjustedInfoes.Attach(item);

                _context.XMAdjustedInfoes.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
