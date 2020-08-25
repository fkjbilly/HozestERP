using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageSystem
{
    public partial class CustomerRoles : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            Page.Theme = "";
        }

        [DirectMethod(Namespace = "CompanyX")]
        public string NodeLoad(string nodeID)
        {
            Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();
            if (!string.IsNullOrEmpty(nodeID))
            {
                int parentRoleID = 0;
                int.TryParse(nodeID, out parentRoleID);
                var customerRoles = base.CustomerService.GetCustomerRoleByParentCustomerRoleID(parentRoleID);

                foreach (var item in customerRoles)
                {
                    AsyncTreeNode asyncNode = new AsyncTreeNode();
                    if (item.Active)
                        asyncNode.Text = item.Name;
                    else
                        asyncNode.Text = "<font color='red'>" + item.Name + "</font>";
                    asyncNode.NodeID = item.CustomerRoleID.ToString();
                    asyncNode.Listeners.Click.Fn = "SelectNode";
                    asyncNode.Expanded = true;
                    nodes.Add(asyncNode);
                }
            }

            return nodes.ToJson();
        }


        [DirectMethod(Namespace = "CompanyX")]
        public string RefreshCustomerRoleTreeLoad()
        {
            Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();

            AsyncTreeNode rootNode = new AsyncTreeNode();
            rootNode.Text = "角色";
            rootNode.NodeID = "0";
            rootNode.SingleClickExpand = true;
            rootNode.Expanded = true;
            nodes.Add(rootNode);

            return nodes.ToJson();
        }


    }
}