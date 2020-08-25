
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-10-12 10:51:28
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
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public partial class XMExpressManagementService : IXMExpressManagementService
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
        public XMExpressManagementService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMExpressManagementService成员
        /// <summary>
        /// Insert into XMExpressManagement
        /// </summary>
        /// <param name="xmexpressmanagement">XMExpressManagement</param>
        public void InsertXMExpressManagement(XMExpressManagement xmexpressmanagement)
        {
            if (xmexpressmanagement == null)
                return;

            if (!this._context.IsAttached(xmexpressmanagement))

                this._context.XMExpressManagements.AddObject(xmexpressmanagement);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMExpressManagement
        /// </summary>
        /// <param name="xmexpressmanagement">XMExpressManagement</param>
        public void UpdateXMExpressManagement(XMExpressManagement xmexpressmanagement)
        {
            if (xmexpressmanagement == null)
                return;

            if (this._context.IsAttached(xmexpressmanagement))
                this._context.XMExpressManagements.Attach(xmexpressmanagement);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMExpressManagement list
        /// </summary>
        public List<XMExpressManagement> GetXMExpressManagementList()
        {
            var query = from p in this._context.XMExpressManagements
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 更具打印时间查询记录
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<XMExpressManagement> GetXMExpressManagementListByparm(int year, int month, string expressIDs)
        {
            int?[] expressIdlist = Array.ConvertAll<string, int?>(expressIDs.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMExpressManagements
                        where p.IsEnable == false
                           && (p.PrintDate.Value.Year == year && p.PrintDate.Value.Month == month)
                            && expressIdlist.Contains(p.ExpressID)
                           && p.CourierNumber != null
                        select p;
            return query.ToList();
        }

        public List<XMExpressManagement> GetXMExpressManagementListByParam(string CourierNumber, int DepartmentID, List<int?> CustomerInfoIDs, string ReceivingName, int Print)
        {
            var query = from p in this._context.XMExpressManagements
                        where p.IsEnable == false
                        && p.CourierNumber.Contains(CourierNumber)
                        && (DepartmentID == -1 || p.DepartmentID == DepartmentID)
                        && CustomerInfoIDs.Contains(p.SenderID)
                        && p.ReceivingName.Contains(ReceivingName)
                        && (Print == -1 || (Print == 0 && p.PrintCount == 0) || (Print == 1 && p.PrintCount > 0))
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CourierNumber"></param>
        /// <returns></returns>
        public List<XMExpressManagement> GetXMExpressManagementListByCourierNumber(string CourierNumber)
        {
            var query = from p in this._context.XMExpressManagements
                        where p.IsEnable == false
                        && p.CourierNumber == CourierNumber
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMExpressManagement Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMExpressManagement Page List</returns>
        public PagedList<XMExpressManagement> SearchXMExpressManagement(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMExpressManagements
                        orderby p.ID
                        select p;
            return new PagedList<XMExpressManagement>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMExpressManagement by ID
        /// </summary>
        /// <param name="id">XMExpressManagement ID</param>
        /// <returns>XMExpressManagement</returns>   
        public XMExpressManagement GetXMExpressManagementByID(int id)
        {
            var query = from p in this._context.XMExpressManagements
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// get a XMExpressManagement by ID
        /// </summary>
        /// <param name="id">XMExpressManagement ID</param>
        /// <returns>XMExpressManagement</returns>   
        public List<XMExpressManagement> GetXMExpressManagementByID(List<int> ids)
        {
            var query = from p in this._context.XMExpressManagements
                        where ids.Contains(p.ID)
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// delete XMExpressManagement by ID
        /// </summary>
        /// <param name="ID">XMExpressManagement ID</param>
        public void DeleteXMExpressManagement(int id)
        {
            var xmexpressmanagement = this.GetXMExpressManagementByID(id);
            if (xmexpressmanagement == null)
                return;

            if (!this._context.IsAttached(xmexpressmanagement))
                this._context.XMExpressManagements.Attach(xmexpressmanagement);

            this._context.DeleteObject(xmexpressmanagement);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMExpressManagement by ID
        /// </summary>
        /// <param name="IDs">XMExpressManagement ID</param>
        public void BatchDeleteXMExpressManagement(List<int> ids)
        {
            var query = from q in _context.XMExpressManagements
                        where ids.Contains(q.ID)
                        select q;
            var xmexpressmanagements = query.ToList();
            foreach (var item in xmexpressmanagements)
            {
                if (!_context.IsAttached(item))
                    _context.XMExpressManagements.Attach(item);

                _context.XMExpressManagements.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
