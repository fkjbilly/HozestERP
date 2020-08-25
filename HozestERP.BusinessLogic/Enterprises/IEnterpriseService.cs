using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HozestERP.Common;
using System.Collections;

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial interface IEnterpriseService
    {
        /// <summary>
        /// 获得第一条单位信息
        /// </summary>
        /// <returns></returns>
        Enterprise GetFristEnterprises();       
        /// <summary>
        /// Gets all Enterprises
        /// </summary>
        /// <returns>Enterprises</returns>
        List<Enterprise> GetAllEnterprises();

        List<Department> GetDepartmentListByRoleID(int RoleID);
        List<Department> GetDepartmentListByDepType(int DepartmentType);

        /// <summary>
        /// 通过单位ID获得单位信息
        /// </summary>
        /// <param name="EnterpriseId">Enterprise identifier</param>
        /// <returns>Enterprise</returns>
        Enterprise GetEnterpriseById(int EnterpriseId);


        /// <summary>
        /// 更新单位信息
        /// </summary>
        /// <param name="Enterprise">Enterprise</param>
        void UpdateEnterprise(Enterprise Enterprise);


        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// <param name="Enterprise">Enterprise</param>
        void InsertEnterprise(Enterprise Enterprise);


        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// <param name="EnterpriseId">Enterprise identifier</param>
        void MarkEnterpriseAsDeleted(int EnterpriseId);


        #region Department
        /// <summary>
        /// Inserts Department
        /// </summary>
        /// <param name="department"></param>
        void InsertDepartment(Department department);

        /// <summary>
        /// Update The Department
        /// </summary>
        /// <param name="department"></param>
        void UpdateDepartment(Department department);

        /// <summary>
        /// Gets all Department
        /// </summary>
        /// <returns></returns>
        List<Department> GetDepartmentAll();

        /// <summary>
        ///  Gets all Department
        /// </summary>
        /// <param name="enterpriseID">公司ID</param>
        /// <param name="parentID">父节点ID</param>
        /// <returns>List</returns>
        List<Department> GetDepartmentByParentID(int enterpriseID, int parentID);

        /// <summary>
        /// Gets a Department
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Department GetDepartmentById(int departmentId);


        /// <summary>
        /// Gets a Department
        /// </summary>
        /// <param name="DepName">部门名称</param>
        /// <returns></returns>
        Department GetDepartmentByDepName(string DepName);


        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// <param name="EnterpriseId">Department identifier</param>
        void MarkDepartmentAsDeleted(int departmentId);
        #endregion

        #region 集团公司页面添加删除修改

        /// <summary>
        /// 获取集团公司列表
        /// </summary>
        /// <param name="content">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>List</returns>
        PagedList<Enterprise> GetEnterprise(string content, int pageIndex, int pageSize);

        /// <summary>
        /// Deletes a Enterprise item
        /// </summary>
        /// <param name="logId">Log item identifier</param>
        void DeleteEnterprise(List<int> enterpriseIds);

        /// <summary>
        /// 根据ID获取当前集团公司信息
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        Enterprise GetEnterpriseByID(int EnterpriseId);


        #endregion
    }
}
