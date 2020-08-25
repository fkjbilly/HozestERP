
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
    public partial class XMPdInfoService : IXMPdInfoService
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
        public XMPdInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMPdInfoService成员
        /// <summary>
        /// Insert into XMPdInfo
        /// </summary>
        /// <param name="xmpdinfo">XMPdInfo</param>
        public void InsertXMPdInfo(XMPdInfo xmpdinfo)
        {
            if (xmpdinfo == null)
                return;

            if (!this._context.IsAttached(xmpdinfo))

                this._context.XMPdInfoes.AddObject(xmpdinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMPdInfo
        /// </summary>
        /// <param name="xmpdinfo">XMPdInfo</param>
        public void UpdateXMPdInfo(XMPdInfo xmpdinfo)
        {
            if (xmpdinfo == null)
                return;

            if (this._context.IsAttached(xmpdinfo))
                this._context.XMPdInfoes.Attach(xmpdinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMPdInfo list
        /// </summary>
        public List<XMPdInfo> GetXMPdInfoList()
        {
            var query = from p in this._context.XMPdInfoes
                        where p.IsEnable == false
                        orderby p.Id descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMPdInfo list by parm
        /// </summary>
        /// <param name="pdCode">盘点单号</param>
        /// <param name="begin">业务时间 开始</param>
        /// <param name="end">业务时间 结束</param>
        /// <param name="wareHousesId">仓库ID</param>
        /// <param name="status">状态（待盘点 ， 已盘点）</param>
        /// <returns></returns>
        public List<XMPdInfo> GetXMPdInfoListByParm(string pdCode, string begin, string end, string  wareHousesId, int status, int projectId, string nickids)
        {
            int?[] wareHousesIdlist = Array.ConvertAll<string, int?>(wareHousesId.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime pdBeginTime = DateTime.Now;
            DateTime pdEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                pdBeginTime = DateTime.Parse(begin);
                pdEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMPdInfoes
                        join t in this._context.XMWareHouses
                        on p.WarehouseId equals t.Id
                        where p.IsEnable == false
                        && (pdCode == "" || p.Ref.Contains(pdCode))
                        && ((begin == "" && end == "") || (p.BizDt >= pdBeginTime && p.BizDt < pdEndTime))
                        && wareHousesIdlist.Contains(p.WarehouseId)
                        && (status == -1 || p.BillStatus == status)
                        orderby p.BizDt descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pdCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="wareHousesId"></param>
        /// <param name="status"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        public List<XMPdInfo> GetXMPdInfoListByPorjectID(string pdCode, string begin, string end, int wareHousesId, int status, string projectids, int projectId)
        {
            int?[] projectlist = Array.ConvertAll<string, int?>(projectids.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime pdBeginTime = DateTime.Now;
            DateTime pdEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                pdBeginTime = DateTime.Parse(begin);
                pdEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMPdInfoes
                        join t in this._context.XMWareHouses
                        on p.WarehouseId equals t.Id
                        where p.IsEnable == false
                        && (pdCode == "" || p.Ref.Contains(pdCode))
                        && ((begin == "" && end == "") || (p.BizDt >= pdBeginTime && p.BizDt < pdEndTime))
                        && (wareHousesId == -1 || p.WarehouseId == wareHousesId)
                        && (status == -1 || p.BillStatus == status)
                        && ((t.NickId == -1 || t.NickId == 99) && projectlist.Contains(t.ProjectId))
                        && (projectId == -1 || t.ProjectId == projectId)
                        orderby p.BizDt descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMPdInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPdInfo Page List</returns>
        public PagedList<XMPdInfo> SearchXMPdInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPdInfoes
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMPdInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMPdInfo by Id
        /// </summary>
        /// <param name="id">XMPdInfo Id</param>
        /// <returns>XMPdInfo</returns>   
        public XMPdInfo GetXMPdInfoById(int id)
        {
            var query = from p in this._context.XMPdInfoes
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMPdInfo by Id
        /// </summary>
        /// <param name="Id">XMPdInfo Id</param>
        public void DeleteXMPdInfo(int id)
        {
            var xmpdinfo = this.GetXMPdInfoById(id);
            if (xmpdinfo == null)
                return;

            if (!this._context.IsAttached(xmpdinfo))
                this._context.XMPdInfoes.Attach(xmpdinfo);

            this._context.DeleteObject(xmpdinfo);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMPdInfo by Id
        /// </summary>
        /// <param name="Ids">XMPdInfo Id</param>
        public void BatchDeleteXMPdInfo(List<int> ids)
        {
            var query = from q in _context.XMPdInfoes
                        where ids.Contains(q.Id)
                        select q;
            var xmpdinfos = query.ToList();
            foreach (var item in xmpdinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMPdInfoes.Attach(item);

                _context.XMPdInfoes.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
