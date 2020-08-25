/******************************************************************
** Copyright (c) 2008 -2012 
** 创建人:方银朗
** 创建日期:2012-03-08
** 修改人: 方银朗
** 修改日期: 2012-03-08
** 描 述: 方银朗 2012-03-08 增加类的头部注释
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.ManageCustomerService;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public partial class CustomerInfoService : ICustomerInfoService
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
        public CustomerInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region CustomerInfo
        /// <summary>
        /// 获取返回用户信息
        /// </summary>
        /// <param name="jobNumber">工号</param>
        /// <param name="fullName">姓名</param>
        /// <param name="departmentID">归属部门</param>
        /// <returns>customerInfos</returns>
        public List<CustomerInfo> GetCustomerList(string jobNumber, string fullName, int departmentID, List<int> CustomerStatus)
        {
            var query = from p in this._context.CustomerInfoes
                        where p.JobNumber.Contains(jobNumber)
                            && p.FullName.Contains(fullName)
                            && p.Published && !p.Deleted
                            && (departmentID.Equals(0) || p.DepartmentID.Equals(departmentID))
                            && (CustomerStatus.Count.Equals(0) || CustomerStatus.Contains(p.CustomerStatusID))
                        select p;
            return query.ToList();
        }

        public CustomerInfo GetCustomerInfoByIDNum(string IDNumber)
        {
            var query = from p in this._context.CustomerInfoes
                        where p.IDNumber == IDNumber
                        && !p.Deleted
                        select p;
            return query.SingleOrDefault();
        }

        public List<CustomerInfo> GetCustomerInfoListByDepId(int DepId)
        {
            var query = from p in this._context.CustomerInfoes
                        where p.DepartmentID == DepId
                        && !p.Deleted
                        select p;
            return query.ToList();
        }

        public List<CustomerInfo> GetCustomerInfoListInSearch(int DepartmentID, string FullName, int Gender, bool Deleted)
        {
            var query = from p in this._context.CustomerInfoes
                        where (Gender == -1 || p.GenderID == Gender)
                        && p.FullName.Contains(FullName)
                        && p.Deleted == Deleted
                        && (DepartmentID == -1 || p.DepartmentID == DepartmentID)
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 分页获取返回用户信息
        /// </summary>
        /// <param name="jobNumber"></param>
        /// <param name="fullName"></param>
        /// <param name="departmentID"></param>
        /// <param name="CustomerStatus"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<CustomerInfo> GetCustomerList(string jobNumber, string fullName, int departmentID, List<int> CustomerStatus, int pageIndex, int pageSize)
        {
            var query = from p in this._context.CustomerInfoes
                        where p.JobNumber.Contains(jobNumber)
                            && p.FullName.Contains(fullName)
                            && p.Published && !p.Deleted
                            && (departmentID.Equals(0) || p.DepartmentID.Equals(departmentID))
                            && (CustomerStatus.Count.Equals(0) || CustomerStatus.Contains(p.CustomerStatusID))
                        orderby p.DisplayOrder
                        select p;
            return new PagedList<CustomerInfo>(query, pageIndex, pageSize);
        }

        public List<XMPreSalesSalary> GetSortPreList(List<XMPreSalesSalary> List, int GroupID)
        {
            var query = from p in List
                        where p.GroupID == GroupID && p.RankName != "组长" && p.RankName != "主管"
                        orderby p.JingMao descending
                        select p;
            return query.ToList();
        }

        public List<XMPreSalesSalary> GetSortPreNameList(List<XMPreSalesSalary> List, string Name, int Rank)
        {
            var query = from p in List
                        where (p.Name == Name || Name == "") && (p.RankID == Rank || Rank == -1)
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 分页获取返回用户信息
        /// </summary>
        /// <param name="jobNumber"></param>
        /// <param name="fullName"></param>
        /// <param name="departmentID"></param>
        /// <param name="enterpriseID"></param>
        /// <param name="CustomerStatus"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<CustomerInfo> GetCustomerList(string jobNumber, string fullName, int departmentID, int enterpriseID, List<int> CustomerStatus, int pageIndex, int pageSize)
        {
            var query = from p in this._context.CustomerInfoes
                        join departments in this._context.Departments
                            on p.DepartmentID equals departments.DepartmentID
                        into departmentsX
                        from department in departmentsX.DefaultIfEmpty()
                        where p.JobNumber.Contains(jobNumber)
                            && p.FullName.Contains(fullName)
                            && p.Published && !p.Deleted
                            && (departmentID.Equals(0) || p.DepartmentID.Equals(departmentID))
                            && (enterpriseID.Equals(0) || department.EnterpriseID.Equals(enterpriseID))
                            && (CustomerStatus.Count.Equals(0) || CustomerStatus.Contains(p.CustomerStatusID))
                        orderby p.DisplayOrder
                        select p;
            return new PagedList<CustomerInfo>(query, pageIndex, pageSize);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="Name"></param>
        /// <param name="DepCode"></param>
        /// <param name="Rank"></param>
        /// <returns></returns>
        public List<XMJingMoTongJiInfo> GetJingMoTongJi(int GroupID, string Name, string DepCode, string Rank)
        {
            var query = from p in GetCustomerServiceInfoList(GroupID, Name, DepCode, Rank)
                        select new XMJingMoTongJiInfo
                        {
                            ID = p.ID,
                            Group = p.Group,
                            GroupID = p.GroupID,
                            Name = p.Name,
                            CustomerID = p.CustomerID
                        };
            return query.ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<XMCustomerSaleAcountAnalysis> GetCustomerSaleAcount(int GroupID, int CustomerID, string DepCode)
        {
            var query = from p in GetCustomerServiceInfoList(GroupID, CustomerID, DepCode)
                        select new XMCustomerSaleAcountAnalysis
                        {
                            ID = p.ID,
                            Group = p.Group,
                            GroupID = p.GroupID,
                            Name = p.Name,
                            CustomerID = p.CustomerID
                        };
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="CustomerID"></param>
        /// <param name="DepCode"></param>
        /// <returns></returns>
        public List<XMCustomerServiceWangNo> GetCustomerServiceInfoList(int GroupID, int CustomerID, string DepCode)
        {
            string[] DepList = DepCode.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var query = from p in this._context.CustomerInfoes
                        join departments in this._context.Departments
                        on p.DepartmentID equals departments.DepartmentID
                        where (GroupID == -1 || departments.DepartmentID == GroupID)
                        && (CustomerID == -1 || p.CustomerID == CustomerID)
                        && (
                              from department in this._context.Departments
                              where DepList.Contains(department.DepCode)
                              select department.DepartmentID
                         ).Contains(p.DepartmentID)
                          && p.Deleted == false
                          && p.Childbearing == false
                        orderby p.DepartmentID
                        select new XMCustomerServiceWangNo
                        {
                            ID = p.CustomerID,
                            Group = departments.DepName,
                            GroupID = p.DepartmentID,
                            Name = p.FullName,
                            CustomerID = p.CustomerID,
                        };
            return query.ToList();
        }

        public List<XMPreSalesSalary> GetCustomerInfoPreList(int GroupID, string Name, string DepCode, string Rank)
        {
            var query = from p in GetCustomerServiceInfoList(GroupID, Name, DepCode, Rank)
                        select new XMPreSalesSalary
                        {
                            ID = p.ID,
                            Group = p.Group,
                            GroupID = p.GroupID,
                            Name = p.Name,
                            RankID = p.RankID,
                            RankName = p.RankName,
                            CustomerID = p.CustomerID,
                            BasicSalary = p.BasicSalary,
                            BonusBase = p.BonusBase
                        };
            return query.ToList();
        }

        /// <summary>
        /// 返回用户组别和姓名
        /// </summary>
        public List<XMCustomerServiceWangNo> GetCustomerServiceInfoList(int GroupID, string Name, string DepCode, string Rank)
        {
            string[] DepList = DepCode.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var RankList = (from rankList in this._context.XMCustomerRanks
                            join rank in this._context.XMCustomerServiceLevels
                                 on rankList.RankID equals rank.Id
                            where rank.IsEnabled == false
                            && rankList.IsEnabled == false
                            select new
                            {
                                CustomerID = rankList.CustomerID,
                                RankID = rank.Id,
                                RankName = rank.RankName,
                                BasicSalary = rank.BasicSalary,
                                BonusBase = rank.BonusBase,
                                PaymentAmount = rankList.PaymentAmount
                            });
            var query = from p in this._context.CustomerInfoes
                        join departments in this._context.Departments
                            on p.DepartmentID equals departments.DepartmentID
                        join RankLists in RankList
                            on p.CustomerID equals RankLists.CustomerID into RankX
                        from rank in RankX.DefaultIfEmpty()

                        where (GroupID == -1 || departments.DepartmentID == GroupID) && (Name == "" || p.FullName == Name) && (Rank == "" || rank.RankName == Rank)
                        && (
                                from department in this._context.Departments
                                where DepList.Contains(department.DepCode)
                                select department.DepartmentID
                           ).Contains(p.DepartmentID)
                        && p.Deleted == false
                        && p.Childbearing == false
                        orderby p.DepartmentID
                        select new XMCustomerServiceWangNo
                        {
                            ID = p.CustomerID,
                            Group = departments.DepName,
                            GroupID = p.DepartmentID,
                            Name = p.FullName,
                            RankID = rank.RankID,
                            RankName = rank.RankName,
                            CustomerID = p.CustomerID,
                            BasicSalary = rank.BasicSalary,
                            BonusBase = rank.BonusBase,
                            PaymentAmount = rank.PaymentAmount
                        };
            return query.ToList();
        }

        /// <summary>
        /// 根据ID返回用户组别和姓名
        /// </summary>
        public XMCustomerServiceWangNo GetCustomerServiceInfoListByID(int GroupID, string Name, string DepCode, string Rank, int CustomerID)
        {
            List<XMCustomerServiceWangNo> CustomerServiceInfoList = GetCustomerServiceInfoList(GroupID, Name, DepCode, Rank);
            var query = from p in CustomerServiceInfoList
                        where p.ID == CustomerID
                        select p;
            var CustomerServiceWangNo = query.SingleOrDefault();
            return CustomerServiceWangNo;
        }

        /// <summary>
        /// 根据ID获取当前人事基本信息
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public CustomerInfo GetCustomerInfoByID(int customerID)
        {
            var query = from p in this._context.CustomerInfoes
                        where p.CustomerID == customerID
                        select p;
            var customerinfo = query.SingleOrDefault();
            return customerinfo;
        }

        public CustomerInfo GetCustomerInfoByIDNumber(string IDNUmber)
        {
            var query = from p in this._context.CustomerInfoes
                        where p.IDNumber == IDNUmber
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 添加人事基本信息
        /// </summary>
        /// <param name="customerinfo"></param>
        /// <returns>CustomerInfo</returns>
        public CustomerInfo InsertCustomerInfo(CustomerInfo customerinfo)
        {
            if (customerinfo == null)
                throw new ArgumentNullException("customerinfo");

            _context.CustomerInfoes.AddObject(customerinfo);
            _context.SaveChanges();


            return customerinfo;
        }

        /// <summary>
        /// 更新人事基本信息
        /// </summary>
        /// <param name="customerinfo">CustomerInfo</param>
        public void UpdateCustomerInfo(CustomerInfo customerinfo)
        {
            if (customerinfo == null)
                throw new ArgumentNullException("CustomerInfo");
            if (!_context.IsAttached(customerinfo))
                _context.CustomerInfoes.Attach(customerinfo);
            _context.SaveChanges();

        }


        /// <summary>
        /// delete 人事基本信息 by Id
        /// </summary>
        /// <param name="Id"> Id</param>
        public void DeleteCustomerInfo(int id)
        {
            var customerInfoes = this.GetCustomerInfoByID(id);
            if (customerInfoes == null)
                return;

            // 管理员数据不可删除
            if (id != 7)
            {
                if (!this._context.IsAttached(customerInfoes))
                    this._context.CustomerInfoes.Attach(customerInfoes);
                this._context.DeleteObject(customerInfoes);
                this._context.SaveChanges();
            }
        }

        /// <summary>
        /// Batch delete CustomerInfoes by CustomerID
        /// </summary>
        /// <param name="Ids">CustomerInfoes CustomerID</param>
        public void BatchDeleteCustomerInfo(List<int> ids)
        {
            var query = from q in _context.CustomerInfoes
                        where ids.Contains(q.CustomerID)
                        select q;
            var bzstaffbasicinformations = query.ToList();
            foreach (var item in bzstaffbasicinformations)
            {
                // 管理员数据不可删除
                if (item.CustomerID != 7)
                {
                    if (!_context.IsAttached(item))
                        _context.CustomerInfoes.Attach(item);
                    _context.CustomerInfoes.DeleteObject(item);
                }
            }
            _context.SaveChanges();
        }



        /// <summary>
        /// 修改删除标志位
        /// </summary>
        /// <param name="customerGUID">CustomerInfo identifier</param>
        public void MarkCustomerInfoAsDeleted(List<int> customerIDs)
        {
            string strCustomerIDs = string.Empty;
            foreach (var item in customerIDs)
            {
                if (!string.IsNullOrEmpty(strCustomerIDs))
                {
                    strCustomerIDs += ",";
                }
                strCustomerIDs += "'" + item.ToString() + "'";
            }
            string sql = "update Sys_CustomerInfo set Deleted=1 where customerid in (" + strCustomerIDs + ")";
            this._context.ExecuteStoreCommand(sql);
        }

        /// <summary>
        /// 修改反删除标志位
        /// </summary>
        /// <param name="customerGUID">CustomerInfo identifier</param>
        public void MarkCustomerInfoAsOppositeDeleted(List<int> customerIDs)
        {
            string strCustomerIDs = string.Empty;
            foreach (var item in customerIDs)
            {
                if (!string.IsNullOrEmpty(strCustomerIDs))
                {
                    strCustomerIDs += ",";
                }
                strCustomerIDs += "'" + item.ToString() + "'";
            }
            string sql = "update Sys_CustomerInfo set Deleted=0 where customerid in (" + strCustomerIDs + ")";
            this._context.ExecuteStoreCommand(sql);
        }

        /// <summary>
        /// 获取返回用户信息
        /// </summary>
        /// <param name="jobNumber">工号</param>
        /// <param name="fullName">姓名</param>
        /// <param name="departmentLabel">归属部门</param>
        /// <param name="IsHaveChildDepartment">包含子组织</param>
        /// <param name="published">生效</param>
        /// <param name="genderID">性别</param>
        /// <param name="birthdayStartDate">出生日期</param>
        /// <param name="birthdayEndDate">至</param>
        /// <param name="deleted">已删除</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>customerInfos</returns>
        public PagedList<CustomerInfo> GetCustomerInfo(string fullName, string departmentLabel, bool IsHaveChildDepartment, bool published
            , int genderID, bool deleted, int pageIndex, int pageSize)
        {
            var query = from p in this._context.CustomerInfoes
                        where p.FullName.Contains(fullName)
                        && (departmentLabel.Equals("-1") ||
                            (from a in this._context.Departments
                             where ((!IsHaveChildDepartment && a.Label.Equals(departmentLabel)) || (IsHaveChildDepartment && a.Label.StartsWith(departmentLabel)))
                             select a.DepartmentID).Contains(p.DepartmentID))
                        && p.Published.Equals(published)
                        && (genderID.Equals(-1) || p.GenderID.Equals(genderID))
                        && p.Deleted.Equals(deleted)
                        && this.SecuritySql.Contains(p.CustomerID)
                        orderby p.DisplayOrder
                        select p;
            return new PagedList<CustomerInfo>(query, pageIndex, pageSize);
        }

        #endregion

        #region  AM、AE星级,可操作客户数表的操作

        /// <summary>
        /// 获取返回用户信息列表
        /// </summary>   
        /// <param name="fullName">姓名</param>
        /// <param name="departmentID">部门ID</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>customerInfos</returns>
        public PagedList<CustomerInfo> GetCustomerInfoList(string fullName, int departmentID, int pageIndex, int pageSize)
        {
            var query = from p in this._context.CustomerInfoes
                        where p.FullName.Contains(fullName)
                        && p.DepartmentID == departmentID
                        && this.SecuritySql.Contains(p.CustomerID)
                        orderby p.DisplayOrder
                        select p;
            return new PagedList<CustomerInfo>(query, pageIndex, pageSize);
        }


        /// <summary>
        /// 根据customerID获取Sys_CustomerStar表
        /// </summary>
        /// <param name="customerID">customerID</param>
        /// <returns></returns>
        public Sys_CustomerStar GetCustomerStarByCustomerID(int customerID)
        {
            var query = from p in this._context.Sys_CustomerStar
                        where p.CustomerID.Equals(customerID)
                        orderby p.SetDate descending
                        select p;

            return query.FirstOrDefault();
        }

        /// <summary>
        /// 根据customerStarID获取Sys_CustomerStar表
        /// </summary>
        /// <param name="customerStarID">customerStarID</param>
        /// <returns></returns>
        public Sys_CustomerStar GetCustomerStarByID(int customerStarID)
        {
            var query = from p in this._context.Sys_CustomerStar
                        where p.ID.Equals(customerStarID)
                        select p;
            var customerStar = query.SingleOrDefault();
            return customerStar;
        }

        /// <summary>
        /// 更新Sys_CustomerStar表信息
        /// </summary>
        /// <param name="customerStar">customerStar</param>
        public void UpdateCustomerStar(Sys_CustomerStar customerStar)
        {
            if (customerStar == null)
                throw new ArgumentNullException("Sys_CustomerStar");

            if (!_context.IsAttached(customerStar))
                _context.Sys_CustomerStar.Attach(customerStar);

            _context.SaveChanges();
        }

        /// <summary>
        /// 添加Sys_CustomerStar表信息
        /// </summary>
        /// <param name="customerStar">customerStar</param>
        public void InsertCustomerStar(Sys_CustomerStar customerStar)
        {
            if (customerStar == null)
                throw new ArgumentNullException("Sys_CustomerStar");

            _context.Sys_CustomerStar.AddObject(customerStar);
            _context.SaveChanges();
        }

        /// <summary>
        /// 删除Sys_CustomerStar表信息
        /// </summary>
        /// <param name="customerStarID">customerStarID</param>
        public void DeleteCustomerStar(int customerStarID)
        {
            var customerStar = GetCustomerStarByID(customerStarID);
            if (customerStar == null)
                return;

            if (!_context.IsAttached(customerStar))
                _context.Sys_CustomerStar.Attach(customerStar);
            _context.DeleteObject(customerStar);
            _context.SaveChanges();
        }


        #endregion

        #region Properties
        /// <summary> 
        /// 人员数据权限
        /// </summary>
        private IQueryable<int> SecuritySql
        {
            get
            {
                return this._context.Security(HozestERPContext.Current.User.CustomerID);
            }
        }
        #endregion
    }
}
