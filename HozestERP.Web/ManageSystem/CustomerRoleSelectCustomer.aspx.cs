using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web.Modules
{
    public partial class CustomerRoleSelectCustomer : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindTree();
                this.BindSelectCustomerGrid();
                this.EnterpriseID = 0;
                this.BindCustomerGrid(1, this.GridNevigator1.PageSize);
            }
        }

        public void BindCustomerGrid(int pageIndex, int pageSize)
        {
            var customerInfos = base.CustomerInfoService.GetCustomerList(this.txtJobNumber.Text.Trim(), this.txtFullName.Text.Trim(), this.DepartmentID, this.EnterpriseID, new List<int>(), pageIndex, pageSize);

            this.GridNevigator1.BindData(grdCustomer, customerInfos);

            if (customerInfos.Count > 0)
                this.GridNevigator1.Visible = true;
            else
                this.GridNevigator1.Visible = false;


        }

        public void GridNevigator1_PageSizeChange(object sender, OnChageEventArg e)
        {
            this.GridNevigator1.PageIndex = 1;
            // 改变页面大小
            this.BindCustomerGrid(1, e.newPageSize);

        }

        public void GridNevigator1_PageChange(object sender, OnChageEventArg e)
        {
            // 改变页码
            this.BindCustomerGrid(e.newPageIndex, e.newPageSize);
        }

        public void BindTree()
        {
            var enterprises = base.EnterpriseService.GetAllEnterprises();
            trDepartment.Nodes.Clear();
            TreeNode root = new TreeNode();
            root.Text = "全部";
            root.Value = "";
            root.ImageUrl = "~/images/CPC_CompGroup.gif";
            root.SelectAction = TreeNodeSelectAction.Select;
            root.ExpandAll();
            foreach (var itemEnt in enterprises)
            {
                var departments = base.EnterpriseService.GetDepartmentByParentID(itemEnt.EntId, 0);
                this.EnterpriseID = itemEnt.EntId;
                TreeNode rootNode = new TreeNode();
                rootNode.Text = itemEnt.EntName;
                rootNode.ImageUrl = "~/images/CPC_CompGroup.gif";
                rootNode.Value = "ent" + itemEnt.EntId;
                rootNode.SelectAction = TreeNodeSelectAction.Select;
                rootNode.ExpandAll();
                TreeNode treeNode;
                foreach (var item in departments)
                {
                    treeNode = new TreeNode();
                    treeNode.Text = item.DepCode + "_" + item.DepName;
                    treeNode.Value = item.DepartmentID.ToString();
                    if (!item.Published)
                    {
                        continue;
                    }
                    treeNode.SelectAction = TreeNodeSelectAction.Select;
                    this.BindTree(treeNode, item.DepartmentID);
                    rootNode.ChildNodes.Add(treeNode);
                }
                root.ChildNodes.Add(rootNode);

            }
            trDepartment.Nodes.Add(root);
        }

        private void BindTree(TreeNode oldNode, int departmentID)
        {
            TreeNode newNode;
            var moduleList = base.EnterpriseService.GetDepartmentByParentID(this.EnterpriseID, departmentID);
            foreach (var item in moduleList)
            {
                newNode = new TreeNode();
                newNode.Text = item.DepCode + "_" + item.DepName;
                newNode.Value = item.DepartmentID.ToString();
                if (!item.Published)
                {
                    continue;
                }
                newNode.SelectAction = TreeNodeSelectAction.Select;
                this.BindTree(newNode, item.DepartmentID);
                oldNode.ChildNodes.Add(newNode);
            }
        }

        protected void trDepartment_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.trDepartment.SelectedNode != null)
            {
                if (this.trDepartment.SelectedNode.Value.IndexOf("ent") >= 0)
                {
                    this.EnterpriseID = int.Parse(this.trDepartment.SelectedNode.Value.Replace("ent", ""));
                    this.DepartmentID = 0;
                }
                else
                {
                    this.EnterpriseID = 0;
                    int departmentID = 0;
                    int.TryParse(this.trDepartment.SelectedNode.Value, out departmentID);
                    this.DepartmentID = departmentID;
                }
                this.BindCustomerGrid(1, this.GridNevigator1.PageSize);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindCustomerGrid(1, this.GridNevigator1.PageSize);
        }

        public void BindSelectCustomerGrid()
        {
            this.grdSelectCustomer.DataSource = this.SelectCustomers;
            this.grdSelectCustomer.DataBind();
        }

        protected void grdCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SelectCustomer"))
            {
                int customerID = 0;
                int.TryParse(e.CommandArgument.ToString(), out customerID);
                var customerInfo = base.CustomerInfoService.GetCustomerInfoByID(customerID);
                if (customerInfo != null)
                {
                    if (this.SelectCustomers.Where(p => p.CustomerID.Equals(customerID)).SingleOrDefault() != null)
                    {
                        return;
                    }
                    this.SelectCustomers.Add(customerInfo);
                    this.BindSelectCustomerGrid();
                }
            }
        }

        protected void grdSelectCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DetailDelete"))
            {
                int customerID = 0;
                int.TryParse(e.CommandArgument.ToString(), out customerID);
                var customerInfo = this.SelectCustomers.Where(p => p.CustomerID.Equals(customerID)).SingleOrDefault();
                if (customerInfo != null)
                {
                    this.SelectCustomers.Remove(customerInfo);
                    this.BindSelectCustomerGrid();
                }
            }
        }

        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdCustomer.Rows.Count; i++)
            {
                int customerID = 0;
                int.TryParse(this.grdCustomer.DataKeys[i].Value.ToString(), out customerID);
                var customerInfo = base.CustomerInfoService.GetCustomerInfoByID(customerID);
                if (customerInfo != null)
                {
                    if (this.SelectCustomers.Where(p => p.CustomerID.Equals(customerID)).SingleOrDefault() != null)
                    {
                        continue;
                    }
                    this.SelectCustomers.Add(customerInfo);
                    this.BindSelectCustomerGrid();
                }
            }
        }
        /// <summary>
        /// 移除全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = this.grdSelectCustomer.Rows.Count - 1; i < this.grdSelectCustomer.Rows.Count; i--)
            {
                if (i >= 0)
                {
                    int customerID = 0;
                    int.TryParse(this.grdSelectCustomer.DataKeys[i].Value.ToString(), out customerID);

                    var customerInfo = this.SelectCustomers.Where(p => p.CustomerID.Equals(customerID)).SingleOrDefault();
                    if (customerInfo != null)
                    {
                        this.SelectCustomers.Remove(customerInfo);

                    }
                }
            }
            this.BindSelectCustomerGrid();
        }

        public int EnterpriseID
        {
            get
            {
                int _enterpriseID = 0;
                try
                {
                    int.TryParse(ViewState["EnterpriseID"].ToString(), out _enterpriseID);
                }
                catch
                {
                    return 0;
                }
                return _enterpriseID;
            }
            set
            {
                ViewState["EnterpriseID"] = value;
            }
        }

        public int DepartmentID
        {
            get
            {
                int _deparetmentID = 0;
                try
                {
                    int.TryParse(ViewState["DepartmentID"].ToString(), out _deparetmentID);
                }
                catch
                {
                    return 0;
                }
                return _deparetmentID;
            }
            set
            {
                ViewState["DepartmentID"] = value;
            }
        }

        public List<CustomerInfo> SelectCustomers
        {
            get
            {
                try
                {
                    return (Session[this.SessionPageID + "SelectCustomer"] as List<CustomerInfo>);
                }
                catch
                {
                }
                return new List<CustomerInfo>();
            }
            set
            {
                Session[this.SessionPageID + "SelectCustomer"] = value;
            }
        }

        public string SessionPageID
        {
            get
            {
                return CommonHelper.QueryString("PageID");
            }
        }
    }
}