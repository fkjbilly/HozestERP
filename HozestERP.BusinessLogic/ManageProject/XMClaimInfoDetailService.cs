
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
    public partial class XMClaimInfoDetailService : IXMClaimInfoDetailService
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
        public XMClaimInfoDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMClaimInfoDetailService成员
        /// <summary>
        /// Insert into XMClaimInfoDetail
        /// </summary>
        /// <param name="xmclaiminfodetail">XMClaimInfoDetail</param>
        public void InsertXMClaimInfoDetail(XMClaimInfoDetail xmclaiminfodetail)
        {
            if (xmclaiminfodetail == null)
                return;

            if (!this._context.IsAttached(xmclaiminfodetail))

                this._context.XMClaimInfoDetails.AddObject(xmclaiminfodetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMClaimInfoDetail
        /// </summary>
        /// <param name="xmclaiminfodetail">XMClaimInfoDetail</param>
        public void UpdateXMClaimInfoDetail(XMClaimInfoDetail xmclaiminfodetail)
        {
            if (xmclaiminfodetail == null)
                return;

            if (this._context.IsAttached(xmclaiminfodetail))
                this._context.XMClaimInfoDetails.Attach(xmclaiminfodetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMClaimInfoDetail list
        /// </summary>
        public List<XMClaimInfoDetail> GetXMClaimInfoDetailList()
        {
            var query = from p in this._context.XMClaimInfoDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMClaimInfoDetail> GetXMClaimInfoDetailListByDate(string Begin, string End)
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

            var query = from p in this._context.XMClaimInfoDetails
                        join q in this._context.XMClaimInfoes
                        on p.ClaimInfoID equals q.Id
                        where p.IsEnable == false
                        && (Begin == "" || q.CreateDate >= begin)
                        && (End == "" || q.CreateDate < end)
                        select p;
            return query.Distinct().ToList();
        }

        /// <summary>
        /// get to XMClaimInfoDetail list
        /// </summary>
        /// <param name="ClaimInfoID"></param>
        /// <returns></returns>
        public List<XMClaimInfoDetail> GetXMClaimInfoDetailListByClaimInfoID(int ClaimInfoID)
        {
            var query = from p in this._context.XMClaimInfoDetails
                        where p.IsEnable == false 
                        && p.ClaimInfoID == ClaimInfoID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="realName"></param>
        /// <param name="OrderCode"></param>
        /// <param name="claimRef"></param>
        /// <param name="isReturn"></param>
        /// <param name="isConfirm"></param>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        public List<XMClaimInfoDetail> GetXMClaimInfoDetailListByParm(int CreateID, string ResponsiblePerson, string realName, string OrderCode, string claimRef, int isReturn, int isConfirm, string Begin, string End, int ClaimTypeID, int projectID, string nickids)
        {
            int?[] nickIdlist = Array.ConvertAll<string, int?>(nickids.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nickIdlist.Count() > 0 && nickIdlist[0] != -1)
            {
                nick_id = int.Parse(nickIdlist[0].ToString());
            }
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (Begin != "" && End != "")
            {
                purBeginTime = DateTime.Parse(Begin);
                purEndTime = DateTime.Parse(End);
            }
            bool isReturned = isReturn == 0 ? false : true;
            bool isConfirmed = isConfirm == 0 ? false : true;
            var query = from p in this._context.XMClaimInfoDetails
                        join t in this._context.XMClaimInfoes
                         on p.ClaimInfoID equals t.Id
                        join d in this._context.XMNicks
                         on t.NickId equals d.nick_id into D
                        from d in D.DefaultIfEmpty()
                        where p.IsEnable == false
                        && (realName == "" || t.FullName.Contains(realName))
                        && (OrderCode == "" || t.OrderCode.Contains(OrderCode))
                        && (claimRef == "" || t.ClaimRef.Contains(claimRef))
                        && (isReturn == -1 || t.IsReturn == isReturned)
                        && (isConfirm == -1 || p.IsConfirm == isConfirmed)
                        && ((Begin == "" && End == "") || (t.CreateDate >= purBeginTime && t.CreateDate < purEndTime))
                        && p.ClaimTypeID == ClaimTypeID
                        && (nick_id == -1 || nickIdlist.Contains(t.NickId))
                        && (projectID == -1 || d.ProjectId == projectID)
                        && (CreateID == -1 || t.CreateID == CreateID)
                        && (ResponsiblePerson == "-1" ||
                           ((ResponsiblePerson == "" && (p.ResponsiblePerson == null || p.ResponsiblePerson == ""))
                           || (ResponsiblePerson != "" && p.ResponsiblePerson.Contains(ResponsiblePerson)))
                           )
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMClaimInfoDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMClaimInfoDetail Page List</returns>
        public PagedList<XMClaimInfoDetail> SearchXMClaimInfoDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMClaimInfoDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMClaimInfoDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMClaimInfoDetail by Id
        /// </summary>
        /// <param name="id">XMClaimInfoDetail Id</param>
        /// <returns>XMClaimInfoDetail</returns>   
        public XMClaimInfoDetail GetXMClaimInfoDetailById(int id)
        {
            var query = from p in this._context.XMClaimInfoDetails
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMClaimInfoDetail by Id
        /// </summary>
        /// <param name="Id">XMClaimInfoDetail Id</param>
        public void DeleteXMClaimInfoDetail(int id)
        {
            var xmclaiminfodetail = this.GetXMClaimInfoDetailById(id);
            if (xmclaiminfodetail == null)
                return;

            if (!this._context.IsAttached(xmclaiminfodetail))
                this._context.XMClaimInfoDetails.Attach(xmclaiminfodetail);

            this._context.DeleteObject(xmclaiminfodetail);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMClaimInfoDetail by Id
        /// </summary>
        /// <param name="Ids">XMClaimInfoDetail Id</param>
        public void BatchDeleteXMClaimInfoDetail(List<int> ids)
        {
            var query = from q in _context.XMClaimInfoDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmclaiminfodetails = query.ToList();
            foreach (var item in xmclaiminfodetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMClaimInfoDetails.Attach(item);

                _context.XMClaimInfoDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
