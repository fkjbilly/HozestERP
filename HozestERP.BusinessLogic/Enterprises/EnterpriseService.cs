using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.Common.Utils;

using HozestERP.Common;
using System.Collections;


namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class EnterpriseService : IEnterpriseService
    {
        #region Constants
        private const string CATEGORIES_BY_ID_KEY = "CRM.Enterprise.id-{0}";
        private const string CATEGORIES_PATTERN_KEY = "CRM.Enterprise.";
        #endregion

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
        public EnterpriseService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region Methods
        /// <summary>
        /// 获取第一条单位信息
        /// </summary>
        /// <returns></returns>
        public Enterprise GetFristEnterprises()
        {
            string key = string.Format(CATEGORIES_PATTERN_KEY);
            object obj2 = _cacheManager.Get(key);
            if (this.EnterpriseCacheEnabled && (obj2 != null))
            {
                return (Enterprise)obj2;
            }
            
            var query = from p in _context.Enterprises
                        where !p.Deleted                        
                        select p;
            var Enterprise = query.FirstOrDefault();

            if (this.EnterpriseCacheEnabled)
            {
                _cacheManager.Add(key, Enterprise);
            }

            return Enterprise;
        }
        /// <summary>
        /// 获得单位信息
        /// </summary>
        /// <returns></returns>
        public List<Enterprise> GetAllEnterprises()
        {
            var query = from p in _context.Enterprises
                        where !p.Deleted
                        select p;
            var Enterprise = query.ToList();
            return Enterprise;
        }
        /// <summary>
        /// 通过ID获得单位信息
        /// </summary>
        /// <param name="EnterpriseId"></param>
        /// <returns></returns>
        public Enterprise GetEnterpriseById(int EnterpriseId)
        {
            if (EnterpriseId == 0)
                return null;
            var query = from p in _context.Enterprises
                        where p.EntId == EnterpriseId&&!p.Deleted
                        select p;
            var Enterprise = query.SingleOrDefault();
            return Enterprise;

        }
        /// <summary>
        /// 修改单位信息
        /// </summary>
        /// <param name="Enterprise"></param>
        public void UpdateEnterprise(Enterprise Enterprise)
        {
            if (Enterprise == null)
                throw new ArgumentNullException("Enterprise");
            if (!_context.IsAttached(Enterprise))
                _context.Enterprises.Attach(Enterprise);
            _context.SaveChanges();

            if (this.EnterpriseCacheEnabled)
            {
                _cacheManager.RemoveByPattern(CATEGORIES_PATTERN_KEY);
            }

        }
        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// <param name="Enterprise"></param>
        public void InsertEnterprise(Enterprise Enterprise)
        {
            if (Enterprise == null)
                throw new ArgumentNullException("Enterprise");

            _context.Enterprises.AddObject(Enterprise);
            _context.SaveChanges();

            if (this.EnterpriseCacheEnabled)
            {
                _cacheManager.RemoveByPattern(CATEGORIES_PATTERN_KEY);
            }

        }
        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// <param name="EnterpriseId"></param>
        public void MarkEnterpriseAsDeleted(int EnterpriseId)
        {
            var markEnterprise = GetEnterpriseById(EnterpriseId);
            if (markEnterprise != null)
            {
                markEnterprise.Deleted = true;
                UpdateEnterprise(markEnterprise);
            }

            if (this.EnterpriseCacheEnabled)
            {
                _cacheManager.RemoveByPattern(CATEGORIES_PATTERN_KEY);
            }
        }
        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// <param name="EnterpriseId">Department identifier</param>
        public void MarkDepartmentAsDeleted(int departmentId)
        {
            var department = GetDepartmentById(departmentId);
            if (department != null)
            {
                department.Deleted = true;
                UpdateDepartment(department);
            }
        }


        /// <summary>
        /// Gets a Department
        /// </summary>
        /// <param name="DepName">部门名称</param>
        /// <returns></returns>
        public Department GetDepartmentByDepName(string DepName) {

            var query = from p in _context.Departments
                        where p.DepName.Equals(DepName) && !p.Deleted
                        select p;
            var Department = query.SingleOrDefault();
            return Department;
        }


        #region Department
        /// <summary>
        /// 部门信息添加
        /// </summary>
        /// <param name="department"></param>
        public void InsertDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException("department");

            _context.Departments.AddObject(department);
            _context.SaveChanges();
        }

        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="department"></param>
        public void UpdateDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException("department");


            if (!_context.IsAttached(department))
                _context.Departments.Attach(department);

            _context.SaveChanges();
        }

        /// <summary>
        /// 返回部门信息
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartmentAll()
        {
            var query = from p in _context.Departments
                        where p.Deleted == false
                        orderby p.Label, p.DisplayOrder
                        select p;

            return query.ToList();
        }

        /// <summary>
        /// 返回部门信息
        /// </summary>
        /// <param name="enterpriseID">公司ID</param>
        /// <param name="parentID">父节点</param>
        /// <returns>List</returns>
        public List<Department> GetDepartmentByParentID(int enterpriseID, int parentID)
        {
            var query = from p in this._context.Departments 
                        where !p.Deleted && p.EnterpriseID == enterpriseID && p.ParentID == parentID 
                        orderby p.DisplayOrder ascending 
                        select p;
            return query.ToList();
        }
        #endregion
        /// <summary>
        /// 通过ID获得部门信息
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        public Department GetDepartmentById(int departmentId)
        {
            if (departmentId == 0)
                return null;
            var query = from p in _context.Departments
                        where p.DepartmentID == departmentId && !p.Deleted
                        select p;
            var Department = query.SingleOrDefault();
            return Department;

        }

        public List<Department> GetDepartmentListByRoleID(int RoleID)
        {
            var query = from cr in _context.Departments
                        from c in cr.SCustomerRoles
                        where c.CustomerRoleID == RoleID
                            && !cr.Deleted
                        select cr;
            return query.ToList();
        }

        public List<Department> GetDepartmentListByDepType(int DepartmentType)
        {
            var query = from d in _context.Departments
                        where d.Deleted == false
                            && (DepartmentType == -1 || d.DepType == DepartmentType)
                        select d;
            return query.ToList();
        }

        #region 集团公司页面添加修改删除

        /// <summary>
        /// 获取集团公司列表
        /// </summary>
        /// <param name="content">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>PagedList</returns>
        public PagedList<Enterprise> GetEnterprise(string content, int pageIndex, int pageSize)
        {
            var query = from p in this._context.Enterprises
                        where p.EntName.Contains(content) && !p.Deleted
                        orderby p.DisplayOrder ascending
                        select p;
            var notices = new PagedList<Enterprise>(query, pageIndex, pageSize);
            return notices;
        }

        /// <summary>
        /// Deletes a Enterprise item
        /// </summary>
        /// <param name="logId">Log item identifier</param>
        public void DeleteEnterprise(List<int> enterpriseIds)
        {
            foreach (var id in enterpriseIds)
            {
                var enterprise = GetEnterpriseByID(int.Parse(id.ToString()));
                if (enterprise == null)
                    break;

                enterprise.Deleted = true;

                if (!_context.IsAttached(enterprise))
                    _context.Enterprises.Attach(enterprise);

            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 根据ID获取当前集团公司信息
        /// </summary>
        /// <param name="EnterpriseId"></param>
        /// <returns></returns>
        public Enterprise GetEnterpriseByID(int EnterpriseId)
        {
            var query = from p in this._context.Enterprises
                        where p.EntId == EnterpriseId
                        select p;
            var notice = query.SingleOrDefault();
            return notice;
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether categories cache is enabled
        /// </summary>
        public bool EnterpriseCacheEnabled
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Cache.EnterpriseManager.EnterpriseCacheEnabled");
            }
        }

        #endregion

    }
}
