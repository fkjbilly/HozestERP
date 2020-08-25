using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ModuleManagement;

namespace HozestERP.Web.ManageSystem
{
    public partial class ModuleTree : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTree();
        }

        public void BindTree()
        {

            var modules = base.ModuleService.GetModuleListByModuleID(0);
            trModules.Nodes.Clear();
            TreeNode rootNode = new TreeNode();
            rootNode.Text = "功能模块菜单";
            rootNode.NavigateUrl = "ModuleDetails.aspx?ModuleID=0";
            rootNode.Target = "ModuleContentPage";
            rootNode.SelectAction = TreeNodeSelectAction.Select;
            rootNode.Expand();
            TreeNode treeNode;
            foreach (var item in modules)
            {
                treeNode = new TreeNode();
                treeNode.Text = item.ModuleName;
                treeNode.NavigateUrl = "ModuleDetails.aspx?ModuleID=" + item.ModuleID;
                treeNode.Target = "ModuleContentPage";
                treeNode.SelectAction = TreeNodeSelectAction.Select;
                this.BindTree(treeNode, item.ModuleID);
                rootNode.ChildNodes.Add(treeNode);
            }
            trModules.Nodes.Add(rootNode);
        }

        private void BindTree(TreeNode oldNode, int moduleID)
        {
            TreeNode newNode;
            var moduleList = base.ModuleService.GetModuleListByModuleID(moduleID);
            foreach (var item in moduleList)
            {
                newNode = new TreeNode();
                newNode.Text = item.ModuleName;
                newNode.NavigateUrl = "ModuleDetails.aspx?ModuleID=" + item.ModuleID;
                newNode.Target = "ModuleContentPage";
                newNode.SelectAction = TreeNodeSelectAction.Select;
                this.BindTree(newNode, item.ModuleID);
                oldNode.ChildNodes.Add(newNode);
            }
        }
    }
}