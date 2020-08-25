using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.ManageCustomerService;

using HozestERP.Common;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public partial interface ICustomerInfoService
    {
        /// <summary>
        /// 获取返回用户信息
        /// </summary>
        /// <param name="jobNumber">工号</param>
        /// <param name="fullName">姓名</param>
        /// <param name="departmentID">归属部门</param>
        /// <returns>customerInfos</returns>
        List<CustomerInfo> GetCustomerList(string jobNumber, string fullName, int departmentID, List<int> CustomerStatus);

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
        PagedList<CustomerInfo> GetCustomerList(string jobNumber, string fullName, int departmentID, List<int> CustomerStatus, int pageIndex, int pageSize);

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
        PagedList<CustomerInfo> GetCustomerList(string jobNumber, string fullName, int departmentID, int enterpriseID, List<int> CustomerStatus, int pageIndex, int pageSize);

        /// <summary>
        /// 返回用户组别和姓名
        /// </summary>
        List<XMCustomerServiceWangNo> GetCustomerServiceInfoList(int GroupID, string Name, string DepCode, string Rank);
        /// <summary>
        /// 根据ID返回用户组别和姓名
        /// </summary>
        XMCustomerServiceWangNo GetCustomerServiceInfoListByID(int GroupID, string Name, string DepCode, string Rank, int CustomerID);
        /// <summary>
        /// 根据条件返回信息
        /// </summary>
        List<XMPreSalesSalary> GetCustomerInfoPreList(int GroupID, string Name, string DepCode, string Rank);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="CustomerID"></param>
        /// <param name="DepCode"></param>
        /// <returns></returns>
        List<XMCustomerSaleAcountAnalysis> GetCustomerSaleAcount(int GroupID, int CustomerID, string DepCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="CustomerID"></param>
        /// <param name="DepCode"></param>
        /// <returns></returns>
        List<XMCustomerServiceWangNo> GetCustomerServiceInfoList(int GroupID, int CustomerID, string DepCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="Name"></param>
        /// <param name="DepCode"></param>
        /// <param name="Rank"></param>
        /// <returns></returns>
        List<XMJingMoTongJiInfo> GetJingMoTongJi(int GroupID, string Name, string DepCode, string Rank);
        List<XMPreSalesSalary> GetSortPreList(List<XMPreSalesSalary> List,int GroupID);
        List<XMPreSalesSalary> GetSortPreNameList(List<XMPreSalesSalary> List, string Name, int RankID);

        List<CustomerInfo> GetCustomerInfoListByDepId(int DepId);

        List<CustomerInfo> GetCustomerInfoListInSearch(int DepartmentID, string FullName, int Gender, bool Deleted);

        /// <summary>
        /// 根据ID获取当前人事基本信息
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        CustomerInfo GetCustomerInfoByID(int customerID);

        CustomerInfo GetCustomerInfoByIDNum(string IDNUmber);

        /// <summary>
        /// 添加人事基本信息
        /// </summary>
        /// <param name="customerinfo"></param>
        /// <returns></returns>
        CustomerInfo InsertCustomerInfo(CustomerInfo customerinfo);

        CustomerInfo GetCustomerInfoByIDNumber(string IDNumber);

        /// <summary>
        /// 更新人事基本信息
        /// </summary>
        /// <param name="customerinfo">CustomerInfo</param>
        void UpdateCustomerInfo(CustomerInfo customerinfo);



        /// <summary>
        /// delete 人事基本信息 by Id
        /// </summary>
        /// <param name="Id"> Id</param>
        void DeleteCustomerInfo(int id);


        /// <summary>
        /// Batch delete CustomerInfoes by CustomerID
        /// </summary>
        /// <param name="Ids">CustomerInfoes CustomerID</param>
        void BatchDeleteCustomerInfo(List<int> ids);


        /// <summary>
        /// 修改删除标志位
        /// </summary>
        /// <param name="customerGUID">CustomerInfo identifier</param>
        void MarkCustomerInfoAsDeleted(List<int> customerIDs);

        /// <summary>
        /// 修改反删除标志位
        /// </summary>
        /// <param name="customerGUID">CustomerInfo identifier</param>
        void MarkCustomerInfoAsOppositeDeleted(List<int> customerIDs);

        /// <summary>
        /// 获取返回用户信息
        /// </summary>
        /// <param name="fullName">姓名</param>
        /// <param name="departmentLabel">归属部门</param>
        /// <param name="IsHaveChildDepartment">包含子组织</param>
        /// <param name="published">生效</param>
        /// <param name="genderID">性别</param>
        /// <param name="deleted">已删除</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>customerInfos</returns>
        PagedList<CustomerInfo> GetCustomerInfo( string fullName, string departmentLabel, bool IsHaveChildDepartment, bool published
            , int genderID, bool deleted, int pageIndex, int pageSize);


        #region  AM、AE星级,可操作客户数表的操作

        /// <summary>
        /// 根据customerID获取Sys_CustomerStar表
        /// </summary>
        /// <param name="customerID">customerID</param>
        /// <returns></returns>
        Sys_CustomerStar GetCustomerStarByCustomerID(int customerID);


        /// <summary>
        /// 根据customerStarID获取Sys_CustomerStar表
        /// </summary>
        /// <param name="customerStarID">customerStarID</param>
        /// <returns></returns>
        Sys_CustomerStar GetCustomerStarByID(int customerStarID);


        /// <summary>
        /// 更新Sys_CustomerStar表信息
        /// </summary>
        /// <param name="customerStar">customerStar</param>
        void UpdateCustomerStar(Sys_CustomerStar customerStar);


        /// <summary>
        /// 添加Sys_CustomerStar表信息
        /// </summary>
        /// <param name="customerStar">customerStar</param>
        void InsertCustomerStar(Sys_CustomerStar customerStar);


        /// <summary>
        /// 删除Sys_CustomerStar表信息
        /// </summary>
        /// <param name="customerStarID">customerStarID</param>
        void DeleteCustomerStar(int customerStarID);


        /// <summary>
        /// 获取返回用户信息列表
        /// </summary>   
        /// <param name="fullName">姓名</param>
        /// <param name="departmentID">部门ID</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>customerInfos</returns>
        PagedList<CustomerInfo> GetCustomerInfoList(string fullName, int departmentID, int pageIndex, int pageSize);

        #endregion
    }
}
