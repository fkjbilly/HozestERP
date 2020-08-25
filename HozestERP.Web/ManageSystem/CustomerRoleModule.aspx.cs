using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Security;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web.ManageSystem
{
    public partial class CustomerRoleModule : BaseAdministrationPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.BindText();
                this.BindCustomerRole();
                this.BindTree();
                this.BindData();
                AlertSettingsBindTree();
            }
        }

        private void BindText()
        {
            if (!IsPostBack)
            {
                var customerRole = base.CustomerService.GetCustomerRoleById(this.CustomerRoleID);
                if (customerRole != null)
                {
                    this.txtName.Text = customerRole.Name;
                    this.txtDescription.Text = customerRole.Description;
                    this.chkActive.Checked = customerRole.Active;
                    this.dropDownField.Value = customerRole.ParentCustomerRoleID.ToString();
                    if (customerRole.ParentCustomerRoleID == 0)
                    {
                        this.dropDownField.Text = "根角色";
                    }
                    else
                    {
                        this.dropDownField.Text = customerRole.ParentCustomerRole.Name.ToString();
                    }
                    this.btnDelete.Enabled = true;
                    // 加载人员权限
                    this.pnlStaffPrivileges.AutoLoad.Url = "CustomerRoleStaffPrivileges.aspx?CustomerRoleID=" + customerRole.CustomerRoleID;

                    // 加载包含人员
                    this.pnlCustomer.AutoLoad.Url = "CustomerRoleCustomerMapping.aspx?CustomerRoleID=" + customerRole.CustomerRoleID;

                    //加载包含部门
                    this.pnlDepartment.AutoLoad.Url = "CustomerRoleDepartmentMapping.aspx?CustomerRoleID=" + customerRole.CustomerRoleID;
                }
                else
                {
                    this.txtName.Text = string.Empty;
                    this.txtDescription.Text = string.Empty;
                    this.chkActive.Checked = true;
                    this.btnDelete.Enabled = false;
                }
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.Page.Theme = "";
        }

        protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.BindData();
        }

        private void BindData()
        {
            var customerActions = base.ACLService.GetAllCustomerActionsByACLModule(this.CustomerRoleID, null);

            Store1.DataSource = customerActions;
            Store1.DataBind();
        }

        private List<ACLModule> CustomerRoleACLModules
        {
            get;
            set;
        }

        private void AlertSettingsBindTree()
        {
            var modules = base.SettingManager.GetAllAlertSettings();
            var roleModules=new List<Sys_AlertSettings>();
            if (this.CustomerRoleID > 0)
                roleModules = base.SettingManager.GetRoleAlertSettings(this.CustomerRoleID);
            AlertSettingsTreePanel.Root.Clear();
            Ext.Net.TreeNode rootNode = new Ext.Net.TreeNode();
            rootNode.Text = "提示类型菜单";
            rootNode.NodeID = "0";
            rootNode.SingleClickExpand = true;
            Ext.Net.TreeNode treeNode;
            foreach (var item in modules)
            {
                treeNode = new Ext.Net.TreeNode();
                treeNode.Text = item.Rmdname;
                treeNode.NodeID = item.ID.ToString();
                treeNode.SingleClickExpand = true;
                if (roleModules.Where(p => p.ID.Equals(item.ID)).ToList().Count > 0)
                {
                    treeNode.Checked = ThreeStateBool.True;
                }
                else
                {
                    treeNode.Checked = ThreeStateBool.False;
                }
                rootNode.Nodes.Add(treeNode);
            }
            AlertSettingsTreePanel.Root.Add(rootNode);
        }

        private void BindTree()
        {
            if (this.CustomerRoleID > 0)
                this.CustomerRoleACLModules = base.ACLService.GetAllACLModule(0, this.CustomerRoleID, true);
            else
                this.CustomerRoleACLModules = new List<ACLModule>();
            var modules = base.ModuleService.GetModuleListByModuleID(0);
            moduleTree.Root.Clear();
            Ext.Net.TreeNode rootNode = new Ext.Net.TreeNode();
            rootNode.Text = "功能模块菜单";
            rootNode.NodeID = "0";
            rootNode.SingleClickExpand = true;
            Ext.Net.TreeNode treeNode;
            foreach (var item in modules)
            {
                if (!item.Published)
                    continue;
                treeNode = new Ext.Net.TreeNode();
                treeNode.Text = item.ModuleName;
                treeNode.NodeID = item.ModuleID.ToString();
                treeNode.SingleClickExpand = true;
                if (this.CustomerRoleACLModules.Where(p => p.ModuleID.Equals(item.ModuleID)).ToList().Count > 0)
                {
                    treeNode.Checked = ThreeStateBool.True;
                }
                else
                {
                    treeNode.Checked = ThreeStateBool.False;
                }
                this.BindTree(treeNode, item.ModuleID);
                rootNode.Nodes.Add(treeNode);
            }
            moduleTree.Root.Add(rootNode);
        }

        private void BindTree(Ext.Net.TreeNode oldNode, int moduleID)
        {
            Ext.Net.TreeNode newNode;
            var moduleList = base.ModuleService.GetModuleListByModuleID(moduleID);
            foreach (var item in moduleList)
            {
                if (!item.Published)
                    continue;
                newNode = new Ext.Net.TreeNode();
                newNode.Text = item.ModuleName;
                newNode.NodeID = item.ModuleID.ToString();
                newNode.SingleClickExpand = true;
                if (this.CustomerRoleACLModules.Where(p => p.ModuleID.Equals(item.ModuleID)).ToList().Count > 0)
                {
                    newNode.Checked = ThreeStateBool.True;
                }
                else
                {
                    newNode.Checked = ThreeStateBool.False;
                }
                this.BindTree(newNode, item.ModuleID);
                oldNode.Nodes.Add(newNode);
            }
        }

        private void BindCustomerRole()
        {
            Ext.Net.TreeNode rootNode = new Ext.Net.TreeNode();
            rootNode.Listeners.Click.Fn = "SelectNode";
            rootNode.Text = "根角色";
            rootNode.NodeID = "0";

            var customerRoles = base.CustomerService.GetCustomerRoleByParentCustomerRoleID(0);

            Ext.Net.TreeNode treeNode;
            foreach (var item in customerRoles)
            {
                treeNode = new Ext.Net.TreeNode();
                treeNode.Text = item.Name;
                treeNode.NodeID = item.CustomerRoleID.ToString();
                treeNode.Listeners.Click.Fn = "SelectNode";
                treeNode.Expanded = true;
                this.BindCustomerRole(treeNode, item.CustomerRoleID);
                rootNode.Nodes.Add(treeNode);
            }

            this.treCustomerRole.Root.Add(rootNode);
        }

        private void BindCustomerRole(Ext.Net.TreeNode oldNode, int parentRoleID)
        {
            var customerRoles = base.CustomerService.GetCustomerRoleByParentCustomerRoleID(parentRoleID);

            Ext.Net.TreeNode treeNode;
            foreach (var item in customerRoles)
            {
                treeNode = new Ext.Net.TreeNode();
                treeNode.Text = item.Name;
                treeNode.NodeID = item.CustomerRoleID.ToString();
                treeNode.Listeners.Click.Fn = "SelectNode";
                treeNode.Expanded = true;
                this.BindCustomerRole(treeNode, item.CustomerRoleID);
                oldNode.Nodes.Add(treeNode);
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var customerRole = new HozestERP.BusinessLogic.CustomerManagement.CustomerRole()
                {
                    Name = this.txtName.Text,
                    Description = this.txtDescription.Text,
                    Code = string.Empty,
                    Deleted = false,
                    Active = this.chkActive.Checked,
                    CreateStaff = HozestERPContext.Current.User.CustomerID,
                    CreateDate = DateTime.Now,
                    ParentCustomerRoleID = int.Parse(this.dropDownField.Value.ToString())
                };
                this.SaveRoleAlertType(customerRole.CustomerRoleID);
                base.CustomerService.InsertCustomerRole(customerRole);
                this.SaveCustomerRoleModule(customerRole.CustomerRoleID);
                X.MessageBox.Show(new MessageBoxConfig()
                {
                    Title = "提示信息",
                    Message = "模块设置成功!",
                    Icon = MessageBox.Icon.INFO,
                    Buttons = MessageBox.Button.OK,
                });
                this._CustomerRoleID = customerRole.CustomerRoleID;
                this.ResourceManager2.AddScript("#{GridPanel1}.save();window.parent.RefreshCustomerRoleTree();window.location='CustomerRoleModule.aspx?CustomerRoleID=" + customerRole.CustomerRoleID + "';");
            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var customerRole = base.CustomerService.GetCustomerRoleById(this.CustomerRoleID);
                if (customerRole != null)
                {
                    customerRole.Name = this.txtName.Text.Trim();
                    customerRole.Description = this.txtDescription.Text.Trim();
                    customerRole.Active = this.chkActive.Checked;
                    customerRole.ParentCustomerRoleID = int.Parse(this.dropDownField.Value.ToString());
                    base.CustomerService.UpdateCustomerRole(customerRole);
                }

                this.SaveCustomerRoleModule(customerRole.CustomerRoleID);
                this.SaveRoleAlertType(customerRole.CustomerRoleID);
                this._CustomerRoleID = this.CustomerRoleID;
                X.MessageBox.Show(new MessageBoxConfig()
                {
                    Title = "提示信息",
                    Message = "模块设置成功!",
                    Icon = MessageBox.Icon.INFO,
                    Buttons = MessageBox.Button.OK,
                });
                this.ResourceManager2.AddScript("#{GridPanel1}.save();window.parent.RefreshCustomerRoleTree();");
            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            base.CustomerService.MarkCustomerRoleAsDeleted(this.CustomerRoleID);
            SaveRoleAlertType(this.CustomerRoleID);
            X.MessageBox.Show(new MessageBoxConfig()
            {
                Title = "提示信息",
                Message = "删除成功!",
                Icon = MessageBox.Icon.INFO,
                Buttons = MessageBox.Button.OK,
            });
            this.ResourceManager2.AddScript("window.parent.RefreshCustomerRoleTree();window.location='CustomerRoleModule.aspx';");
        }

        private void SaveCustomerRoleModule(int customerRoleID)
        {
            try
            {
                var nodes = moduleTree.CheckedNodes;
                if (nodes != null)
                {
                    base.ACLService.DeleteACLModuleByCustomerRoleId(customerRoleID);
                    foreach (var node in nodes)
                    {
                        if (int.Parse(node.NodeID).Equals(0))
                        {
                            continue;
                        }
                        base.ACLService.InsertACLModule(new ACLModule()
                        {
                            CustomerRoleId = customerRoleID
                            ,
                            ModuleID = int.Parse(node.NodeID)
                            ,
                            Allow = true
                        });
                    }
                }
            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        }

        private void SaveRoleAlertType(int customerRoleID)
        {
            try
            {
                string checkedNodeIds = "0";
                var nodes = AlertSettingsTreePanel.CheckedNodes;
                if (nodes != null)
                {
                    var customers = base.CustomerService.GetCustomerInfosByCustomerRoleId(customerRoleID);
                    foreach (var node in nodes)
                    {
                        
                        if (int.Parse(node.NodeID).Equals(0))
                        {
                            continue;
                        }
                        var AlertTimeSets = base.SettingManager.GetAlertTimeSetByRoleID(customerRoleID.ToString(), int.Parse(node.NodeID));
                        if (AlertTimeSets.Count == 0)
                        {
                            foreach (var customer in customers)
                            {
                                base.SettingManager.InsertAlertTimeSet(new Sys_AlertTimeSet()
                                {
                                    CustomerID=customer.CustomerID,
                                    AlertID = int.Parse(node.NodeID),
                                    //默认提示时间为1刻
                                    Cycletime=900000,
                                    Spare1 = customerRoleID.ToString()
                                });
                            }
                        }
                        
                        checkedNodeIds += ","+node.NodeID;
                    }
                    base.SettingManager.DeleteAlertTimeSetByRoleID(customerRoleID.ToString(), checkedNodeIds);
                }
                
            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        }


        protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
        {
            try
            {
                ChangeRecords<SelectCustomerAction> persons = e.DataHandler.ObjectData<SelectCustomerAction>();
                foreach (SelectCustomerAction updated in persons.Updated)
                {
                    var acl = base.ACLService.GetAllAcl(updated.CustomerActionID, this._CustomerRoleID, null).FirstOrDefault();
                    if (acl == null)
                    {
                        base.ACLService.InsertAcl(new ACL()
                        {
                            CustomerActionID = updated.CustomerActionID
                            ,
                            CustomerRoleID = this._CustomerRoleID
                            ,
                            Allow = updated.Allow
                        });
                    }
                    else
                    {
                        acl.Allow = updated.Allow;
                        base.ACLService.UpdateAcl(acl);
                    }
                    try
                    {
                        e.ConfirmationList.ConfirmRecord(updated.CustomerActionID.ToString());
                    }
                    catch
                    {
                    }
                }

                e.Cancel = true;
            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        }

        public int _CustomerRoleID
        {
            get
            {
                try
                {
                    return int.Parse(Session["_CustomerRoleID"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                Session["_CustomerRoleID"] = value.ToString();
            }
        }

        public int CustomerRoleID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerRoleID");
            }
        }

    }
}