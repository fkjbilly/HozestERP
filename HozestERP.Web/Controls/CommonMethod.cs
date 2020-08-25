
using System;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web
{

    /// <summary>
    /// 通用方法类
    /// </summary>
    public class CommonMethod
    {
        #region 部门树形下接框
        /// <summary>
        /// 部门树形下拉框填充
        /// </summary>
        /// <param name="ddlDepartment">DropDownList</param>
        public static void DropDownListDepartment(DropDownList ddlDepartment, bool isEmpety)
        {
            ddlDepartment.Items.Clear();
            if (isEmpety)
            {
                ddlDepartment.Items.Add(new ListItem("--所有--", "-1"));
            }
            
            var enterprises = IoC.Resolve<IEnterpriseService>().GetAllEnterprises();
            foreach (var enterprise in enterprises)
            {
                var departments = IoC.Resolve<IEnterpriseService>().GetDepartmentByParentID(enterprise.EntId, 0);
                BindDepartment(enterprise.EntId, ddlDepartment, string.Empty, departments);
            }
        }


        private static void BindDepartment(int entID, DropDownList ddlDepartment, string parentString, List<Department> departments)
        {
            string newParentString = parentString;
            for (int i = 0; i < departments.Count; i++)
            {
                var department = departments[i];
                bool isLast = false;
                if ((i + 1) == departments.Count)
                {
                    isLast = true;
                }
                var childDepartments = IoC.Resolve<IEnterpriseService>().GetDepartmentByParentID(entID, department.DepartmentID);
                bool hasChild = childDepartments.Count > 0 ? true : false;
                newParentString = GetPreFix(isLast, hasChild, parentString);
                ListItem item = new ListItem(newParentString + department.DepName, department.DepartmentID.ToString());
                ddlDepartment.Items.Add(item);
                if (hasChild)
                {
                    BindDepartment(entID, ddlDepartment, newParentString, childDepartments);
                }
            }
        }

        /// <summary>
        /// 部门树形下拉框填充
        /// </summary>
        /// <param name="ddlDepartment">DropDownList</param>
        public static void DropDownListDepartmentByLabel(DropDownList ddlDepartment, bool isEmpety)
        {
            ddlDepartment.Items.Clear();
            if (isEmpety)
            {
                ddlDepartment.Items.Add(new ListItem("--所有--", "-1"));
            }

            var enterprises = IoC.Resolve<IEnterpriseService>().GetAllEnterprises();
            foreach (var enterprise in enterprises)
            {
                var departments = IoC.Resolve<IEnterpriseService>().GetDepartmentByParentID(enterprise.EntId, 0);
                BindDepartmentByLabel(enterprise.EntId, ddlDepartment, string.Empty, departments);
            }
        }

        private static void BindDepartmentByLabel(int entID, DropDownList ddlDepartment, string parentString, List<Department> departments)
        {
            string newParentString = parentString;
            for (int i = 0; i < departments.Count; i++)
            {
                var department = departments[i];
                bool isLast = false;
                if ((i + 1) == departments.Count)
                {
                    isLast = true;
                }
                var childDepartments = IoC.Resolve<IEnterpriseService>().GetDepartmentByParentID(entID, department.DepartmentID);
                bool hasChild = childDepartments.Count > 0 ? true : false;
                newParentString = GetPreFix(isLast, hasChild, parentString);
                ListItem item = new ListItem(newParentString + department.DepName, department.Label.ToString());
                ddlDepartment.Items.Add(item);
                if (hasChild)
                {
                    BindDepartmentByLabel(entID, ddlDepartment, newParentString, childDepartments);
                }
            }
        }
        #endregion

        #region 角色下拉框

        /// <summary>
        /// 角色下拉框
        /// </summary>
        /// <param name="ddlDepartment">DropDownList</param>
        public static void DropDownListRole(DropDownList ddlRole, bool isEmpety)
        {
            ddlRole.Items.Clear();
            if (isEmpety)
            {
                ddlRole.Items.Add(new ListItem("", "0"));
            }
            var roles = IoC.Resolve<ICustomerService>().GetCustomerRoleByParentCustomerRoleID(0);
            BindRole(ddlRole, string.Empty, roles);
        }

        public static void DropDownListRole(DropDownList ddlRole, bool isEmpty, string name)
        {
            ddlRole.Items.Clear();
            if (isEmpty)
            {
                ddlRole.Items.Add(new ListItem("", "0"));
            }
            var roles = IoC.Resolve<ICustomerService>().GetCustomerRoleByCondition(0,name);
            BindRole(ddlRole, string.Empty, roles);
        }

        private static void BindRole(DropDownList ddlRole, string parentString, List<CustomerRole> roles)
        {
            string newParentString = parentString;
            for (int i = 0; i < roles.Count; i++)
            {
                var role = roles[i];
                bool isLast = false;
                if ((i + 1) == roles.Count)
                {
                    isLast = true;
                }
                var childDepartments = IoC.Resolve<ICustomerService>().GetCustomerRoleByParentCustomerRoleID(role.CustomerRoleID);
                bool hasChild = childDepartments.Count > 0 ? true : false;
                newParentString = GetPreFix(isLast, hasChild, parentString);
                ListItem item = new ListItem(newParentString + role.Name, role.CustomerRoleID.ToString());
                ddlRole.Items.Add(item);
                if (hasChild)
                {
                    BindRole(ddlRole, newParentString, childDepartments);
                }
            }
        }
        #endregion

        #region 店铺类目
        public static void DropDownListClientType(DropDownList ddlClentType, bool isEmpety)
        {
          
        }

      
        #endregion

        /// <summary>
        /// 用于树的前缀
        /// </summary>
        /// <param name="IsLast">是否是同级节点中的最后一个</param>
        /// <param name="HasChild">本节点是否拥有子节点</param>
        /// <param name="ParentString">父节点前缀符号</param>
        /// <returns>本节点的前缀</returns>
        private static string GetPreFix(bool isLast, bool hasChild, string parentString)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(parentString))
            {
                parentString = parentString.Remove(parentString.Length - 1).Replace("├", "│").Replace("└", "　");
                result += parentString;
            }
            if (isLast)
            {
                result += "└";
            }
            else
            {
                result += "├";
            }
            if (hasChild)
            {
                result += "┬";
            }
            else
            {
                result += "─";
            }
            return result;
        }
    }
}
