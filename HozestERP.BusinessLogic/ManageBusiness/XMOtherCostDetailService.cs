
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
    public partial class XMOtherCostDetailService : IXMOtherCostDetailService
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
        public XMOtherCostDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMOtherCostDetailService成员
        /// <summary>
        /// Insert into XMOtherCostDetail
        /// </summary>
        /// <param name="xmothercostdetail">XMOtherCostDetail</param>
        public void InsertXMOtherCostDetail(XMOtherCostDetail xmothercostdetail)
        {
            if (xmothercostdetail == null)
                return;

            if (!this._context.IsAttached(xmothercostdetail))

                this._context.XMOtherCostDetails.AddObject(xmothercostdetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMOtherCostDetail
        /// </summary>
        /// <param name="xmothercostdetail">XMOtherCostDetail</param>
        public void UpdateXMOtherCostDetail(XMOtherCostDetail xmothercostdetail)
        {
            if (xmothercostdetail == null)
                return;

            if (this._context.IsAttached(xmothercostdetail))
                this._context.XMOtherCostDetails.Attach(xmothercostdetail);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMOtherCostDetail list
        /// </summary>
        public List<XMOtherCostDetail> GetXMOtherCostDetailList()
        {
            var query = from p in this._context.XMOtherCostDetails
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectID"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public XMOtherCostDetail GetXMOtherCostDataByParm(int id, int departmentID, int year)
        {
            var query = from p in this._context.XMOtherCostDetails
                        where p.DepartmentID == departmentID 
                        && p.FinancialFieldID == id 
                        && p.Year == year 
                        && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        public List<XMOtherCostDetail> GetXMOtherCostDataAudit(int id, int departmentID, int year)
        {
            var query = from p in this._context.XMOtherCostDetails
                        where (departmentID == -1 || p.DepartmentID == departmentID)
                        && p.FinancialFieldID == id
                        && p.Year == year
                        && p.IsEnable == false
                        && p.IsAudit == true
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<XMOtherCostDetail> GetXMOtherCostDataByParm(int departmentID, int year)
        {
            var query = from p in this._context.XMOtherCostDetails
                        where p.DepartmentID == departmentID && p.Year == year && p.IsEnable == false
                        && p.IsEnable==false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<XMOtherCostDetail> GetXMOtherCostDataByParm2(int departmentID, int year)
        {
            var query = from p in this._context.XMOtherCostDetails
                        join q in this._context.XMFinancialFields on p.FinancialFieldID equals q.Id
                        where q.ParentID == 0 && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMOtherCostDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOtherCostDetail Page List</returns>
        public PagedList<XMOtherCostDetail> SearchXMOtherCostDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMOtherCostDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMOtherCostDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMOtherCostDetail by Id
        /// </summary>
        /// <param name="id">XMOtherCostDetail Id</param>
        /// <returns>XMOtherCostDetail</returns>   
        public XMOtherCostDetail GetXMOtherCostDetailById(int id)
        {
            var query = from p in this._context.XMOtherCostDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMOtherCostDetail by Id
        /// </summary>
        /// <param name="Id">XMOtherCostDetail Id</param>
        public void DeleteXMOtherCostDetail(int id)
        {
            var xmothercostdetail = this.GetXMOtherCostDetailById(id);
            if (xmothercostdetail == null)
                return;

            if (!this._context.IsAttached(xmothercostdetail))
                this._context.XMOtherCostDetails.Attach(xmothercostdetail);

            this._context.DeleteObject(xmothercostdetail);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMOtherCostDetail by Id
        /// </summary>
        /// <param name="Ids">XMOtherCostDetail Id</param>
        public void BatchDeleteXMOtherCostDetail(List<int> ids)
        {
            var query = from q in _context.XMOtherCostDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmothercostdetails = query.ToList();
            foreach (var item in xmothercostdetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMOtherCostDetails.Attach(item);

                _context.XMOtherCostDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
