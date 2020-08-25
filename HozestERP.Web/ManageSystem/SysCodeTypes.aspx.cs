using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net;

namespace HozestERP.Web.ManageSystem
{
    public partial class SysCodeTypes : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.CustomerNodeLoad();
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            Page.Theme = "";
        }

        public void CustomerNodeLoad()
        {
            Ext.Net.TreeNode nodes = new Ext.Net.TreeNode();

            var moduleCodeTypes = base.CodeTypeService.GetCodeTypeAll();
            var modules = moduleCodeTypes.Select(p => p.ModuleID).Distinct().ToList();
            foreach (var item in modules)
            {
                var module = base.ModuleService.getModuleByModuleID(item);
                string strFullName = "公用代码";
                if (module != null)
                {
                    strFullName = module.ModuleName;
                }
                else
                {
                    continue;
                }
                Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                treeNode.Text = strFullName;
                treeNode.NodeID = "Module" + item.ToString();
                treeNode.SingleClickExpand = true;
                treeNode.IconCls = "folder";
                treeNode.Leaf = false;

                var codeTypes = moduleCodeTypes.Where(p => p.ModuleID.Equals(item)).OrderBy(p => p.DisplayOrder).ToList();
                foreach (var code in codeTypes)
                {
                    Ext.Net.TreeNode treeNode1 = new Ext.Net.TreeNode();
                    treeNode1.Text = code.CodeTypeName;
                    treeNode1.NodeID = code.CodeTypeID.ToString();
                    treeNode1.Listeners.Click.Fn = "SelectNode";
                    treeNode1.IconCls = "folder";
                    treeNode1.Leaf = true;
                    treeNode.Nodes.Add(treeNode1);
                }

                nodes.Nodes.Add(treeNode);
            }

            this.customerTree.Root.Add(nodes);
        }
    }
}