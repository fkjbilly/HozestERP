
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-07-28 17:30:58
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
    public partial class XMClaimInfoService : IXMClaimInfoService
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
        public XMClaimInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMClaimInfoService成员
        /// <summary>
        /// Insert into XMClaimInfo
        /// </summary>
        /// <param name="xmclaiminfo">XMClaimInfo</param>
        public void InsertXMClaimInfo(XMClaimInfo xmclaiminfo)
        {
            if (xmclaiminfo == null)
                return;

            if (!this._context.IsAttached(xmclaiminfo))

                this._context.XMClaimInfoes.AddObject(xmclaiminfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMClaimInfo
        /// </summary>
        /// <param name="xmclaiminfo">XMClaimInfo</param>
        public void UpdateXMClaimInfo(XMClaimInfo xmclaiminfo)
        {
            if (xmclaiminfo == null)
                return;

            if (this._context.IsAttached(xmclaiminfo))
                this._context.XMClaimInfoes.Attach(xmclaiminfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMClaimInfo list
        /// </summary>
        public List<XMClaimInfo> GetXMClaimInfoList()
        {
            var query = from p in this._context.XMClaimInfoes
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMClaimInfo> GetXMClaimInfoListByDate(string Begin, string End)
        {
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!string.IsNullOrEmpty(Begin))
            {
                begin = DateTime.Parse(Begin);
            }

            if (!string.IsNullOrEmpty(End))
            {
                end = DateTime.Parse(End).AddDays(1);
            }

            var query = from p in this._context.XMClaimInfoes
                        where p.IsEnable == false
                        && (Begin == "" || p.CreateDate >= begin)
                        && (End == "" || p.CreateDate < end)
                        select p;
            return query.Distinct().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="orderCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="isReturn"></param>
        /// <param name="projectId"></param>
        /// <param name="nickids"></param>
        /// <param name="responsiblePerson"></param>
        /// <returns></returns>
        public List<XMClaimInfo> GetXMClaimInfoListByParm(string fullName, string orderCode, string claimCode, string begin, string end, int isReturn, int projectId, string nickids, string responsiblePerson)
        {
            int?[] nickIdlist = Array.ConvertAll<string, int?>(nickids.Split(','), delegate(string s) { return int.Parse(s); });
            bool isReturned = false;
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end).AddDays(1);
            }
            if (isReturn == 1)
            {
                isReturned = true;
            }
            var query = from p in this._context.XMClaimInfoes
                        join r in this._context.XMClaimInfoDetails
                        on p.Id equals r.ClaimInfoID
                        join t in this._context.XMNicks
                        on p.NickId equals t.nick_id into T
                        from t in T.DefaultIfEmpty()
                        where p.IsEnable == false
                        && (fullName == "" || p.FullName.Contains(fullName))
                        && (orderCode == "" || p.OrderCode.Contains(orderCode))
                        && (claimCode == "" || p.ClaimRef.Contains(claimCode))
                        && ((begin == "" && end == "") || (p.CreateDate >= purBeginTime && p.CreateDate < purEndTime))
                        && (isReturn == -1 || p.IsReturn == isReturned)
                        && (projectId == -1 || t.ProjectId == projectId)
                        && (nickids == "-1" || nickIdlist.Contains(p.NickId))
                        && (responsiblePerson == "" || r.ResponsiblePerson.Contains(responsiblePerson))
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="orderCode"></param>
        /// <param name="claimCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="isReturn"></param>
        /// <param name="projectId"></param>
        /// <param name="nickids"></param>
        /// <param name="claimTypeID"></param>
        /// <param name="isConfirm"></param>
        /// <returns></returns>
        public List<XMClaimInfo> GetXMClaimInfoListByParm(string fullName, string orderCode, string claimCode, string begin, string end, int isReturn, int projectId, string nickids, int claimTypeID, int isConfirm)
        {
            int?[] nickIdlist = Array.ConvertAll<string, int?>(nickids.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nickIdlist.Count() > 0 && nickIdlist[0] != -1)
            {
                nick_id = int.Parse(nickIdlist[0].ToString());
            }
            bool isReturned = isReturn == 0 ? false : true;
            bool isComfirmed = isConfirm == 0 ? false : true;
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMClaimInfoes
                        join d in this._context.XMClaimInfoDetails
                         on p.Id equals d.ClaimInfoID
                        join t in this._context.XMNicks
                         on p.NickId equals t.nick_id
                        where p.IsEnable == false
                          && (fullName == "" || p.FullName.Contains(fullName))
                          && (orderCode == "" || p.OrderCode.Contains(orderCode))
                          && (claimCode == "" || p.ClaimRef.Contains(claimCode))
                          && ((begin == "" && end == "") || (p.CreateDate >= purBeginTime && p.CreateDate < purEndTime))
                           && (isReturn == -1 || p.IsReturn == isReturned)
                            && (nick_id == -1 || nickIdlist.Contains(p.NickId))
                            && (projectId == -1 || t.ProjectId == projectId)
                            && d.ClaimTypeID == claimTypeID
                            && (isConfirm == -1 || d.IsConfirm == isComfirmed)
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMClaimInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMClaimInfo Page List</returns>
        public PagedList<XMClaimInfo> SearchXMClaimInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMClaimInfoes
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMClaimInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMClaimInfo by Id
        /// </summary>
        /// <param name="id">XMClaimInfo Id</param>
        /// <returns>XMClaimInfo</returns>   
        public XMClaimInfo GetXMClaimInfoById(int id)
        {
            var query = from p in this._context.XMClaimInfoes
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        public XMClaimInfo GetXMClaimInfoByPremiumsId(int PremiumsId)
        {
            var query = from p in this._context.XMClaimInfoes
                        where p.PremiumsId == PremiumsId
                        && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        public XMClaimInfo GetXMClaimInfoByLogisticsNumber(string logisticsNumber)
        {
            var query = from p in this._context.XMClaimInfoes
                        where p.LogisticsNumber== logisticsNumber
                        && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMClaimInfo by Id
        /// </summary>
        /// <param name="Id">XMClaimInfo Id</param>
        public void DeleteXMClaimInfo(int id)
        {
            var xmclaiminfo = this.GetXMClaimInfoById(id);
            if (xmclaiminfo == null)
                return;

            if (!this._context.IsAttached(xmclaiminfo))
                this._context.XMClaimInfoes.Attach(xmclaiminfo);

            this._context.DeleteObject(xmclaiminfo);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMClaimInfo by Id
        /// </summary>
        /// <param name="Ids">XMClaimInfo Id</param>
        public void BatchDeleteXMClaimInfo(List<int> ids)
        {
            var query = from q in _context.XMClaimInfoes
                        where ids.Contains(q.Id)
                        select q;
            var xmclaiminfos = query.ToList();
            foreach (var item in xmclaiminfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMClaimInfoes.Attach(item);

                _context.XMClaimInfoes.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
