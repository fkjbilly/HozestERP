
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-07-14 10:23:29
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
    public partial class XMDailySaleInfoService : IXMDailySaleInfoService
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
        public XMDailySaleInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMDailySaleInfoService成员
        /// <summary>
        /// Insert into XMDailySaleInfo
        /// </summary>
        /// <param name="xmdailysaleinfo">XMDailySaleInfo</param>
        public void InsertXMDailySaleInfo(XMDailySaleInfo xmdailysaleinfo)
        {
            if (xmdailysaleinfo == null)
                return;

            if (!this._context.IsAttached(xmdailysaleinfo))

                this._context.XMDailySaleInfoes.AddObject(xmdailysaleinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMDailySaleInfo
        /// </summary>
        /// <param name="xmdailysaleinfo">XMDailySaleInfo</param>
        public void UpdateXMDailySaleInfo(XMDailySaleInfo xmdailysaleinfo)
        {
            if (xmdailysaleinfo == null)
                return;

            if (this._context.IsAttached(xmdailysaleinfo))
                this._context.XMDailySaleInfoes.Attach(xmdailysaleinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMDailySaleInfo list
        /// </summary>
        public List<XMDailySaleInfo> GetXMDailySaleInfoList()
        {
            var query = from p in this._context.XMDailySaleInfoes
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productName"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<XMDailySaleInfo> GetXMDailySaleInfoListByParm(string productCode, string productName, string begin, string end, int projectID, int nickID)
        {
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMDailySaleInfoes
                        join m in this._context.XMProducts
                        on p.ProductId equals m.Id
                        where p.IsEnable == false
                        && (projectID == -1 || p.ProjectId == projectID)
                        && (nickID == -1 || p.NickId == nickID)
                        && (productCode == "" || p.PlatformMerchantCode.Contains(productCode))
                        && (productName == "" || m.ProductName.Contains(productName))
                         && ((begin == "" && end == "") || (p.CreateDate >= purBeginTime && p.CreateDate < purEndTime))
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMDailySaleInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDailySaleInfo Page List</returns>
        public PagedList<XMDailySaleInfo> SearchXMDailySaleInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMDailySaleInfoes
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMDailySaleInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMDailySaleInfo by Id
        /// </summary>
        /// <param name="id">XMDailySaleInfo Id</param>
        /// <returns>XMDailySaleInfo</returns>   
        public XMDailySaleInfo GetXMDailySaleInfoById(int id)
        {
            var query = from p in this._context.XMDailySaleInfoes
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="activityDate"></param>
        /// <param name="projectID"></param>
        /// <param name="nickID"></param>
        /// <returns></returns>
        public List<XMDailySaleInfo> GetXMDailySaleInfoByParm(string productCode, DateTime activityDate, int projectID, int nickID)
        {
            var query = from p in this._context.XMDailySaleInfoes
                        where p.IsEnable == false
                        && p.PlatformMerchantCode == productCode
                        && p.CreateDate == activityDate
                        && p.ProjectId == projectID
                        && (nickID == -1 || p.NickId == nickID)
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public XMDailySaleInfo GetXMDailySaleInfoByPlatformMerchantCodeAndDate(string productCode, DateTime currentDate)
        {
            var query = from p in this._context.XMDailySaleInfoes
                        where p.IsEnable == false
                        && p.PlatformMerchantCode == productCode
                        && p.CreateDate == currentDate
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMDailySaleInfo by Id
        /// </summary>
        /// <param name="Id">XMDailySaleInfo Id</param>
        public void DeleteXMDailySaleInfo(int id)
        {
            var xmdailysaleinfo = this.GetXMDailySaleInfoById(id);
            if (xmdailysaleinfo == null)
                return;

            if (!this._context.IsAttached(xmdailysaleinfo))
                this._context.XMDailySaleInfoes.Attach(xmdailysaleinfo);

            this._context.DeleteObject(xmdailysaleinfo);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMDailySaleInfo by Id
        /// </summary>
        /// <param name="Ids">XMDailySaleInfo Id</param>
        public void BatchDeleteXMDailySaleInfo(List<int> ids)
        {
            var query = from q in _context.XMDailySaleInfoes
                        where ids.Contains(q.Id)
                        select q;
            var xmdailysaleinfos = query.ToList();
            foreach (var item in xmdailysaleinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMDailySaleInfoes.Attach(item);

                _context.XMDailySaleInfoes.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
