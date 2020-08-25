using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManageFinance
{ 
    public partial class CWProjectTree : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTree();
        }

        public void BindTree()
        { 
            var project = base.CWProjectService.GetCWProjectListByParentID(0);
            trCWProject.Nodes.Clear();
            TreeNode rootNode = new TreeNode();
            rootNode.Text = "项目菜单";
            rootNode.NavigateUrl = "CWProjectDetails.aspx?Id=0";
            rootNode.Target = "ModuleContentPage";
            rootNode.SelectAction = TreeNodeSelectAction.Select;
            rootNode.Expand();
            TreeNode treeNode;
            foreach (var item in project)
            {
                treeNode = new TreeNode();
                treeNode.Text = item.ProjectExplanation;
                treeNode.NavigateUrl = "CWProjectDetails.aspx?Id=" + item.Id;
                treeNode.Target = "ModuleContentPage";
                treeNode.SelectAction = TreeNodeSelectAction.Select;
                this.BindTree(treeNode, item.Id);
                rootNode.ChildNodes.Add(treeNode);
            }
            trCWProject.Nodes.Add(rootNode);
        }

        private void BindTree(TreeNode oldNode, int Id)
        {
            TreeNode newNode;
            var moduleList = base.CWProjectService.GetCWProjectListByParentID(Id);
            foreach (var item in moduleList)
            {
                newNode = new TreeNode();
                newNode.Text = item.ProjectExplanation;
                newNode.NavigateUrl = "CWProjectDetails.aspx?Id=" + item.Id;
                newNode.Target = "ModuleContentPage";
                newNode.SelectAction = TreeNodeSelectAction.Select;
                this.BindTree(newNode, item.Id);
                oldNode.ChildNodes.Add(newNode);
            }
        }
    }
}