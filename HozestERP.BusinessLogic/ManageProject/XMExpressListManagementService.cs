
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-10-27 11:05:13
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
    public partial class XMExpressListManagementService : IXMExpressListManagementService
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
        public XMExpressListManagementService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMExpressListManagementService成员
        /// <summary>
        /// Insert into XMExpressListManagement
        /// </summary>
        /// <param name="xmexpresslistmanagement">XMExpressListManagement</param>
        public void InsertXMExpressListManagement(XMExpressListManagement xmexpresslistmanagement)
        {
            if (xmexpresslistmanagement == null)
                return;

            if (!this._context.IsAttached(xmexpresslistmanagement))

                this._context.XMExpressListManagements.AddObject(xmexpresslistmanagement);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMExpressListManagement
        /// </summary>
        /// <param name="xmexpresslistmanagement">XMExpressListManagement</param>
        public void UpdateXMExpressListManagement(XMExpressListManagement xmexpresslistmanagement)
        {
            if (xmexpresslistmanagement == null)
                return;

            if (this._context.IsAttached(xmexpresslistmanagement))
                this._context.XMExpressListManagements.Attach(xmexpresslistmanagement);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMExpressListManagement list
        /// </summary>
        public List<XMExpressListManagement> GetXMExpressListManagementList()
        {
            var query = from p in this._context.XMExpressListManagements
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="expressID"></param>
        /// <param name="provinceID"></param>
        /// <returns></returns>
        public List<XMExpressListManagement> GetXMExpressListManagementByParm(string number, int year, int month, string expressID, string provinceID)
        {
            int?[] expressIdlist = Array.ConvertAll<string, int?>(expressID.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMExpressListManagements
                        where p.IsEnable == false
                        && (number == "" || p.Number.Contains(number))
                        && p.Year == year
                        && p.Month == month
                         && expressIdlist.Contains(p.ExpressID)
                        && (provinceID == "-1" || p.ProvinceID == provinceID)
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="expressID"></param>
        /// <returns></returns>
        public List<XMNewExpressListManage> GetXMExpressListManagementByParm(int year, int month, string expressIDs)
        {
            int?[] expressIdlist = Array.ConvertAll<string, int?>(expressIDs.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMExpressListManagements
                        join d in this._context.XMCompanyCustoms
                         on System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)p.ExpressID).Trim() equals d.LogisticsId
                        where p.IsEnable == false
                           && p.Year == year
                             && p.Month == month
                           && expressIdlist.Contains(p.ExpressID)
                        select new XMNewExpressListManage
                        {
                            Year = year,
                            Month = month,
                            Number = p.Number,
                            ExpressID = p.ExpressID,
                            Cost = p.Cost,
                            ExpressName = d.LogisticsName
                        };
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public XMExpressListManagement GetXMExpressListManagementByParm(int expressID, string number, int year, int month)
        {
            var query = from p in this._context.XMExpressListManagements
                        where p.IsEnable == false
                        && p.Number.Equals(number)
                        && p.Year == year
                        && p.Month == month
                        && p.ExpressID == expressID
                        select p;
            return query.SingleOrDefault();
        }


        /// <summary>
        /// get to XMExpressListManagement Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMExpressListManagement Page List</returns>
        public PagedList<XMExpressListManagement> SearchXMExpressListManagement(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMExpressListManagements
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMExpressListManagement>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMExpressListManagement by Id
        /// </summary>
        /// <param name="id">XMExpressListManagement Id</param>
        /// <returns>XMExpressListManagement</returns>   
        public XMExpressListManagement GetXMExpressListManagementById(int id)
        {
            var query = from p in this._context.XMExpressListManagements
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMExpressListManagement by Id
        /// </summary>
        /// <param name="Id">XMExpressListManagement Id</param>
        public void DeleteXMExpressListManagement(int id)
        {
            var xmexpresslistmanagement = this.GetXMExpressListManagementById(id);
            if (xmexpresslistmanagement == null)
                return;

            if (!this._context.IsAttached(xmexpresslistmanagement))
                this._context.XMExpressListManagements.Attach(xmexpresslistmanagement);

            this._context.DeleteObject(xmexpresslistmanagement);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMExpressListManagement by Id
        /// </summary>
        /// <param name="Ids">XMExpressListManagement Id</param>
        public void BatchDeleteXMExpressListManagement(List<int> ids)
        {
            var query = from q in _context.XMExpressListManagements
                        where ids.Contains(q.Id) && q.IsEnable == false
                        select q;
            var xmexpresslistmanagements = query.ToList();
            foreach (var item in xmexpresslistmanagements)
            {
                if (!_context.IsAttached(item))
                    _context.XMExpressListManagements.Attach(item);

                _context.XMExpressListManagements.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
