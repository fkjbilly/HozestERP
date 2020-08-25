
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-03-01 09:19:36
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
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Customers
{
    public partial class SocialSecurityFundService : ISocialSecurityFundService
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
        public SocialSecurityFundService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region ISocialSecurityFundService成员
        /// <summary>
        /// Insert into SocialSecurityFund
        /// </summary>
        /// <param name="socialsecurityfund">SocialSecurityFund</param>
        public void InsertSocialSecurityFund(SocialSecurityFund socialsecurityfund)
        {
            if (socialsecurityfund == null)
                return;

            if (!this._context.IsAttached(socialsecurityfund))

                this._context.SocialSecurityFunds.AddObject(socialsecurityfund);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into SocialSecurityFund
        /// </summary>
        /// <param name="socialsecurityfund">SocialSecurityFund</param>
        public void UpdateSocialSecurityFund(SocialSecurityFund socialsecurityfund)
        {
            if (socialsecurityfund == null)
                return;

            if (this._context.IsAttached(socialsecurityfund))
                this._context.SocialSecurityFunds.Attach(socialsecurityfund);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to SocialSecurityFund list
        /// </summary>
        public List<SocialSecurityFund> GetSocialSecurityFundList()
        {
            var query = from p in this._context.SocialSecurityFunds
                        where p.IsEnabled == false
                        select p;
            return query.ToList();
        }

        public List<SocialSecurityFund> GetSocialSecurityFundListByData(int DepartmentID, List<int> DepIdList, string FullName, int Year, int Month)
        {
            var query = from p in this._context.SocialSecurityFunds
                        join c in this._context.CustomerInfoes
                        on p.CustomerInfoID equals c.CustomerID
                        where p.IsEnabled == false
                        && (DepartmentID == -1 || DepIdList.Contains(c.DepartmentID))
                        && c.FullName.Contains(FullName)
                        && (Month == -1 || p.Month == Month)
                        && p.Year == Year
                        select p;
            return query.ToList();
        }

        public SocialSecurityFund GetListByYearMonthCustomerInfoID(int Year, int Month, int CustomerInfoID)
        {
            var query = from p in this._context.SocialSecurityFunds
                        where p.IsEnabled == false
                        && p.Month == Month
                        && p.Year == Year
                        && p.CustomerInfoID == CustomerInfoID
                        select p;
            return query.SingleOrDefault();
        }

        public Department GetDepartmentName(int CustomerInfoID)
        {
            var query = from p in this._context.CustomerInfoes
                        join d in this._context.Departments
                        on p.DepartmentID equals d.DepartmentID
                        where p.Deleted == false
                        && d.Deleted == false
                        && p.CustomerID == CustomerInfoID
                        select d;
            return query.SingleOrDefault();
        }

        public List<CustomerInfo> GetCustomerInfoByIDNumber(string IDNumber)
        {
            var query = from p in this._context.CustomerInfoes
                        join d in this._context.Departments
                        on p.DepartmentID equals d.DepartmentID
                        where d.Deleted == false
                        && p.IDNumber == IDNumber
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to SocialSecurityFund Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>SocialSecurityFund Page List</returns>
        public PagedList<SocialSecurityFund> SearchSocialSecurityFund(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.SocialSecurityFunds
                        orderby p.ID
                        select p;
            return new PagedList<SocialSecurityFund>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a SocialSecurityFund by ID
        /// </summary>
        /// <param name="id">SocialSecurityFund ID</param>
        /// <returns>SocialSecurityFund</returns>   
        public SocialSecurityFund GetSocialSecurityFundByID(int id)
        {
            var query = from p in this._context.SocialSecurityFunds
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete SocialSecurityFund by ID
        /// </summary>
        /// <param name="ID">SocialSecurityFund ID</param>
        public void DeleteSocialSecurityFund(int id)
        {
            var socialsecurityfund = this.GetSocialSecurityFundByID(id);
            if (socialsecurityfund == null)
                return;

            if (!this._context.IsAttached(socialsecurityfund))
                this._context.SocialSecurityFunds.Attach(socialsecurityfund);

            this._context.DeleteObject(socialsecurityfund);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete SocialSecurityFund by ID
        /// </summary>
        /// <param name="IDs">SocialSecurityFund ID</param>
        public void BatchDeleteSocialSecurityFund(List<int> ids)
        {
            var query = from q in _context.SocialSecurityFunds
                        where ids.Contains(q.ID)
                        select q;
            var socialsecurityfunds = query.ToList();
            foreach (var item in socialsecurityfunds)
            {
                if (!_context.IsAttached(item))
                    _context.SocialSecurityFunds.Attach(item);

                _context.SocialSecurityFunds.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
