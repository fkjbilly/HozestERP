using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Ext.Net;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Enterprises;

namespace HozestERP.Web.ManageSystem
{
    public partial class CustomerRoleDepartmentMapping : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                BindData();
                DropDownListDepartment(ddlList, true);

            }
        }


        private void BindData()
        {
            var CustomerRoles = base.CustomerService.GetDepartmentByCustomerRoleId(this.CustomerRoleID);
            var store = this.GridPanel1.GetStore();
            store.DataSource = CustomerRoles;
            store.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strddl = this.ddlList.SelectedItem.Value;
            if (string.IsNullOrEmpty(strddl))
            {
                X.MessageBox.Show(new MessageBoxConfig()
                {
                    Title = "提示信息",
                    Message = "请选择部门!",
                    Icon = MessageBox.Icon.INFO,
                    Buttons = MessageBox.Button.OK,
                });
            }
            else
            {
                if (strddl == "-1")
                {
                    var enterprises = base.EnterpriseService.GetAllEnterprises();
                    foreach (var enterprise in enterprises)
                    {
                        var departments = base.EnterpriseService.GetDepartmentByParentID(enterprise.EntId, 0);
                        foreach (var department in departments)
                        {
                            base.CustomerService.AddDepartmentToRole(department.DepartmentID, this.CustomerRoleID);
                        }
                    }
                }
                else
                {
                    base.CustomerService.AddDepartmentToRole(int.Parse(strddl), this.CustomerRoleID);
                }
                X.MessageBox.Show(new MessageBoxConfig()
                {
                    Title = "提示信息",
                    Message = "部门添加成功!",
                    Icon = MessageBox.Icon.INFO,
                    Buttons = MessageBox.Button.OK,
                });

                this.BindData();
            }
        }


        [DirectMethod(Namespace = "CompanyX")]
        public void DeleteDepartment(int departmentID)
        {
            try
            {
                base.CustomerService.RemoveDepartmentFromRole(departmentID, this.CustomerRoleID);
                this.BindData();
                X.MessageBox.Show(new MessageBoxConfig()
                {
                    Title = "提示信息",
                    Message = "部门删除成功!",
                    Icon = MessageBox.Icon.INFO,
                    Buttons = MessageBox.Button.OK,
                });
            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        }


        private int CustomerRoleID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerRoleID");
            }
        }


        /// <summary>
        /// 部门树形下拉框填充
        /// </summary>
        /// <param name="ddlDepartment">DropDownList</param>
        public void DropDownListDepartment(ComboBox ddlDepartment, bool isEmpety)
        {
            ddlDepartment.Items.Clear();
            if (isEmpety)
            {
                ddlDepartment.Items.Add(new Ext.Net.ListItem("--所有--", "-1"));
            }

            var enterprises = base.EnterpriseService.GetAllEnterprises();
            foreach (var enterprise in enterprises)
            {
                var departments = base.EnterpriseService.GetDepartmentByParentID(enterprise.EntId, 0);
                BindDepartment(enterprise.EntId, ddlDepartment, string.Empty, departments);
            }
        }


        private void BindDepartment(int entID, ComboBox ddlDepartment, string parentString, List<Department> departments)
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
                var childDepartments = base.EnterpriseService.GetDepartmentByParentID(entID, department.DepartmentID);
                bool hasChild = childDepartments.Count > 0 ? true : false;
                newParentString = GetPreFix(isLast, hasChild, parentString);
                Ext.Net.ListItem item = new Ext.Net.ListItem(newParentString + department.DepName, department.DepartmentID.ToString());
                ddlDepartment.Items.Add(item);
                if (hasChild)
                {
                    BindDepartment(entID, ddlDepartment, newParentString, childDepartments);
                }
            }
        }
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
