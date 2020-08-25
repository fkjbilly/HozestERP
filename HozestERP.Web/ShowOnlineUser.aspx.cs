using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.Common;

namespace HozestERP.Web
{
    public partial class ShowOnlineUser : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.Page.Theme = "";
        }

        [DirectMethod(Namespace = "CompanyX")]
        public string OnLineUserNodeLoad(string nodeID, string netID)
        {
            Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();
            if (nodeID.Equals("0") && netID.Equals("0"))
            {
                var enterprises = base.EnterpriseService.GetAllEnterprises();
                foreach (var item in enterprises)
                {
                    if (item.Published)
                    {
                        AsyncTreeNode asyncNode = new AsyncTreeNode();
                        asyncNode.Text = item.EntName;
                        asyncNode.NodeID = "Enterprise_" + item.EntId.ToString();
                        asyncNode.IconCls = "root";
                        asyncNode.Expanded = true;
                        asyncNode.SingleClickExpand = true;
                        asyncNode.CustomAttributes.Add(new ConfigItem("NetID", item.EntId.ToString()));
                        nodes.Add(asyncNode);
                    }
                }
            }
            else if (nodeID.IndexOf("Department_") >= 0 || nodeID.IndexOf("Enterprise_") >= 0)
            {
                int departmentID = 0;
                if (nodeID.IndexOf("Department_") >= 0)
                {
                    int.TryParse(nodeID.Replace("Department_", ""), out departmentID);
                }
                int enterpriseID = 0;
                int.TryParse(netID, out enterpriseID);
                var departments = base.EnterpriseService.GetDepartmentByParentID(enterpriseID, departmentID);

                var allUsers = this.OnlineUserService.GetRegisteredUsersOnline();

                foreach (var item in departments)
                {
                    AsyncTreeNode asyncNode = new AsyncTreeNode();
                    asyncNode.Text = item.DepName;
                    asyncNode.NodeID = "Department_" +  item.DepartmentID.ToString();
                    asyncNode.Expanded = true;
                    asyncNode.SingleClickExpand = true;
                    asyncNode.CustomAttributes.Add(new ConfigItem("NetID", netID));
                    nodes.Add(asyncNode);
                }
                if (departmentID != 0)
                {
                    var users = allUsers.Where(p => p.AssociatedCustomer.SCustomerInfo.DepartmentID.Equals(departmentID));
                    foreach (var user in users)
                    {
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                        treeNode.Text = user.AssociatedCustomer.SCustomerInfo.FullName;
                        treeNode.NodeID = user.AssociatedCustomer.CustomerGUID.ToString();
                        treeNode.Listeners.Click.Handler = "window.parent.newTab('PersonInfo" + user.AssociatedCustomer.CustomerGUID.ToString() + "', '" + HozestERP.Common.Utils.CommonHelper.GetStoreLocation() + "ManageSystem/UserAbout.aspx?CustomerID="
                            + user.AssociatedCustomer.CustomerID.ToString() + "', '" + user.AssociatedCustomer.Username + " 基本信息')";
                        try
                        {
                            if (user.AssociatedCustomer.SCustomerInfo.Gender.CodeName.Equals("男"))
                            {
                                treeNode.IconCls = "U01";
                            }
                            else
                            {
                                treeNode.IconCls = "U11";
                            }
                        }
                        catch
                        {
                            treeNode.IconCls = "U01";
                        }
                        treeNode.Leaf = true;
                        nodes.Add(treeNode);
                    }
                }
            }

            return nodes.ToJson();
        }


        [DirectMethod(Namespace = "CompanyX")]
        public string AllUserNodeLoad(string nodeID, string netID)
        {
            Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();
            if (nodeID.Equals("0") && netID.Equals("0"))
            {
                var enterprises = base.EnterpriseService.GetAllEnterprises();
                foreach (var item in enterprises)
                {
                    if (item.Published)
                    {
                        AsyncTreeNode asyncNode = new AsyncTreeNode();
                        asyncNode.Text = item.EntName;
                        asyncNode.NodeID = "Enterprise_" + item.EntId.ToString();
                        asyncNode.IconCls = "root";
                        asyncNode.Expanded = true;
                        asyncNode.SingleClickExpand = true;
                        asyncNode.CustomAttributes.Add(new ConfigItem("NetID", item.EntId.ToString()));
                        nodes.Add(asyncNode);
                    }
                }
            }
            else if (nodeID.IndexOf("Department_") >= 0 || nodeID.IndexOf("Enterprise_") >= 0)
            {
                int departmentID = 0;
                if (nodeID.IndexOf("Department_") >= 0)
                {
                    int.TryParse(nodeID.Replace("Department_", ""), out departmentID);
                }
                int enterpriseID = 0;
                int.TryParse(netID, out enterpriseID);
                var departments = base.EnterpriseService.GetDepartmentByParentID(enterpriseID, departmentID);

                var onlineUsers = this.OnlineUserService.GetRegisteredUsersOnline();

                foreach (var item in departments)
                {
                    AsyncTreeNode asyncNode = new AsyncTreeNode();
                    asyncNode.Text = item.DepName;
                    asyncNode.NodeID = "Department_" + item.DepartmentID.ToString();
                    asyncNode.SingleClickExpand = true;
                    asyncNode.CustomAttributes.Add(new ConfigItem("NetID", netID));
                    nodes.Add(asyncNode);
                }

                if (departmentID != 0)
                {
                    #region 添加部门人员
                    var allUsers = base.CustomerInfoService.GetCustomerList("", "", departmentID, new List<int>());
                    foreach (var customerInfo in allUsers)
                    {
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                        treeNode.Text = customerInfo.FullName;
                        treeNode.NodeID = customerInfo.CustomerID.ToString();
                        treeNode.Listeners.Click.Handler = "window.parent.newTab('PersonInfo" + customerInfo.CustomerID.ToString() + "', '" + HozestERP.Common.Utils.CommonHelper.GetStoreLocation() + "ManageSystem/UserAbout.aspx?CustomerID="
                            + customerInfo.CustomerID.ToString() + "', '" + customerInfo.FullName + " 基本信息')";

                        var customer = onlineUsers.Where(p => p.AssociatedCustomer.SCustomerInfo.CustomerID.Equals(customerInfo.CustomerID)).ToList();
                        if (customer.Count > 0)
                        {
                            try
                            {
                                if (customerInfo.Gender.CodeName.Equals("男"))
                                {
                                    treeNode.IconCls = "U01";
                                }
                                else
                                {
                                    treeNode.IconCls = "U11";
                                }
                            }
                            catch
                            {
                                treeNode.IconCls = "U01";
                            }
                        }
                        else
                        {
                            try
                            {
                                if (customerInfo.Gender.CodeName.Equals("男"))
                                {
                                    treeNode.IconCls = "U00";
                                }
                                else
                                {
                                    treeNode.IconCls = "U10";
                                }
                            }
                            catch
                            {
                                treeNode.IconCls = "U00";
                            }
                        }
                        treeNode.Leaf = true;
                        nodes.Add(treeNode);
                    }
                    #endregion
                }
            }

            return nodes.ToJson();
        }
    }
}