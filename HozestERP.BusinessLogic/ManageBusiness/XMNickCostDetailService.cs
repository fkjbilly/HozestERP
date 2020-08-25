
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-02-29 09:08:41
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

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class XMNickCostDetailService : IXMNickCostDetailService
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
        public XMNickCostDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMNickCostDetailService成员
        /// <summary>
        /// Insert into XMNickCostDetail
        /// </summary>
        /// <param name="xmnickcostdetail">XMNickCostDetail</param>
        public void InsertXMNickCostDetail(XMNickCostDetail xmnickcostdetail)
        {
            if (xmnickcostdetail == null)
                return;

            if (!this._context.IsAttached(xmnickcostdetail))

                this._context.XMNickCostDetails.AddObject(xmnickcostdetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMNickCostDetail
        /// </summary>
        /// <param name="xmnickcostdetail">XMNickCostDetail</param>
        public void UpdateXMNickCostDetail(XMNickCostDetail xmnickcostdetail)
        {
            if (xmnickcostdetail == null)
                return;

            if (this._context.IsAttached(xmnickcostdetail))
                this._context.XMNickCostDetails.Attach(xmnickcostdetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMNickCostDetail list
        /// </summary>
        public List<XMNickCostDetail> GetXMNickCostDetailList()
        {
            var query = from p in this._context.XMNickCostDetails
                        select p;
            return query.ToList();
        }

        public List<XMNickCostDetail> GetXMNickCostDataByParm2(int projectID, int year)
        {
            var query = from p in this._context.XMNickCostDetails
                        where p.NickId == projectID && p.Year == year && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMNickCostDetail> GetXMNickCostDataByParm3(int projectID, int year)
        {
            var query = from p in this._context.XMNickCostDetails
                        join q in this._context.XMFinancialFields
                        on p.FinancialFieldID equals q.Id
                        where q.ParentID == 0 && p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="year"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<XMNickCostDetail> GetXMNickDataByParm4(int projectID, int year, int parentID)
        {
            var query = from p in this._context.XMNickCostDetails
                        join q in this._context.XMFinancialFields
                        on p.FinancialFieldID equals q.Id
                        where q.ParentID == parentID && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMNickCostDetail> GetXMNickCostByData(int ProjectId, int year, int FinancialFieldId)
        {
            var query = from p in this._context.XMNickCostDetails
                        where p.IsEnable == false
                        && p.Year == year
                        && (ProjectId == -1 || p.NickId == ProjectId)
                        && p.FinancialFieldID == FinancialFieldId
                        && p.IsAudit==true
                        select p;

            if (query.ToList().Count() == 0)
            {
                query = from p in this._context.XMNickCostDetails
                        join q in this._context.XMFinancialFields
                        on p.FinancialFieldID equals q.Id
                        where q.ParentID == FinancialFieldId
                        && p.IsEnable == false
                        && q.Deleted == false
                        && p.Year == year
                        && (ProjectId == -1 || p.NickId == ProjectId)
                        && p.IsAudit == true
                        select p;
            }
            return query.ToList();
        }

        /// <summary>
        /// get to XMNickCostDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMNickCostDetail Page List</returns>
        public PagedList<XMNickCostDetail> SearchXMNickCostDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMNickCostDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMNickCostDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMNickCostDetail by Id
        /// </summary>
        /// <param name="id">XMNickCostDetail Id</param>
        /// <returns>XMNickCostDetail</returns>   
        public XMNickCostDetail GetXMNickCostDetailById(int id)
        {
            var query = from p in this._context.XMNickCostDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectID"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public XMNickCostDetail GetXMNickCostDataByParm(int id, int projectID, int year)
        {
            var query = from p in this._context.XMNickCostDetails
                        where p.NickId == projectID && p.FinancialFieldID == id && p.Year == year && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// delete XMNickCostDetail by Id
        /// </summary>
        /// <param name="Id">XMNickCostDetail Id</param>
        public void DeleteXMNickCostDetail(int id)
        {
            var xmnickcostdetail = this.GetXMNickCostDetailById(id);
            if (xmnickcostdetail == null)
                return;

            if (!this._context.IsAttached(xmnickcostdetail))
                this._context.XMNickCostDetails.Attach(xmnickcostdetail);

            this._context.DeleteObject(xmnickcostdetail);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMNickCostDetail by Id
        /// </summary>
        /// <param name="Ids">XMNickCostDetail Id</param>
        public void BatchDeleteXMNickCostDetail(List<int> ids)
        {
            var query = from q in _context.XMNickCostDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmnickcostdetails = query.ToList();
            foreach (var item in xmnickcostdetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMNickCostDetails.Attach(item);

                _context.XMNickCostDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
