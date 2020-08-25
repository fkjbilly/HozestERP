using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Enterprises;

namespace HozestERP.Web.ManageSystem
{
    public partial class DepartmentDetail : BaseAdministrationPage, IEditPage
    {
        private int DepartmentID
        {
            get
            {
                int departmentID = 0;
                try
                {
                    int.TryParse(ViewState["DepartmentID"].ToString(), out departmentID);
                }
                catch
                {
                }
                return departmentID;
            }
            set
            {
                ViewState["DepartmentID"] = value;
            }
        }

        public int EnterpriseID
        {
            get
            {
                int enterpriseID = 0;
                try
                {
                    int.TryParse(ViewState["EnterpriseID"].ToString(), out enterpriseID);
                }
                catch
                {
                }
                return enterpriseID;
            }
            set
            {
                ViewState["EnterpriseID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTree();

                this.BintDllDepartment();

            }
            this.SetButtonStyle();
        }

        public void SetButtonStyle()
        {
            if (this.EnterpriseID == 0)
            {
                this.btnAdd.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnDelete.Enabled = false;
            }
            else if (this.DepartmentID == 0)
            {
                this.btnAdd.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnDelete.Enabled = false;
            }
            else
            {
                this.btnAdd.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnDelete.Enabled = true;
            }
        }

        private void BintDllDepartment()
        {
            this.ddlDepartment.Items.Clear();
            BintDllDepartment(0);
        }

        private void BintDllDepartment(int departmentid)
        {
            var enterprises = base.EnterpriseService.GetAllEnterprises();
            foreach (var enterprise in enterprises)
            {
                ListItem item = new ListItem(enterprise.EntName, "ent" + enterprise.EntId);
                this.ddlDepartment.Items.Add(item);
                var moduleList = base.EnterpriseService.GetDepartmentByParentID(enterprise.EntId, departmentid);
                this.BindDepartment(enterprise.EntId, string.Empty, moduleList);
                
            }
        }

        public void BindDepartment(int entID, string parentString, List<Department> departments)
        {
            string newParentString = parentString;
            for (int i = 0; i < departments.Count; i++)
            {
                var department = departments[i];
                if (department.DepartmentID == this.DepartmentID)
                    continue;
                bool isLast = false;
                if ((i + 1) == departments.Count)
                {
                    isLast = true;
                }
                var childDepartments = base.EnterpriseService.GetDepartmentByParentID(entID, department.DepartmentID);
                bool hasChild = childDepartments.Count > 0 ? true : false;
                newParentString = GetPreFix(isLast, hasChild, parentString);
                ListItem item = new ListItem(newParentString + department.DepName, department.DepartmentID.ToString());
                this.ddlDepartment.Items.Add(item);
                if (hasChild)
                {
                    BindDepartment(entID, newParentString, childDepartments);
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

        public void BindTree()
        {
            trDepartment.Nodes.Clear();
            var enterprises = base.EnterpriseService.GetAllEnterprises();
            foreach (var enterprise in enterprises)
            {
                var departments = base.EnterpriseService.GetDepartmentByParentID(enterprise.EntId, 0);
                TreeNode rootNode = new TreeNode();
                rootNode.Text = enterprise.EntName;
                rootNode.ImageUrl = "~/images/CPC_CompGroup.gif";
                rootNode.Target = "ModuleContentPage";
                rootNode.Value = enterprise.EntId.ToString();
                rootNode.SelectAction = TreeNodeSelectAction.Select;
                rootNode.ExpandAll();
                TreeNode treeNode;
                foreach (var item in departments)
                {
                    treeNode = new TreeNode();
                    treeNode.Text = item.DepCode + "_" + item.DepName;
                    treeNode.Value = item.DepartmentID.ToString();
                    treeNode.Target = "ModuleContentPage";
                    if (!item.Published)
                    {
                        treeNode.ImageUrl = "~/images/unchecked.gif";
                    }
                    else
                    {
                        treeNode.ImageUrl = "~/images/checked.gif";
                    }
                    treeNode.SelectAction = TreeNodeSelectAction.Select;
                    this.BindTree(enterprise.EntId, treeNode, item.DepartmentID);
                    rootNode.ChildNodes.Add(treeNode);
                }
                trDepartment.Nodes.Add(rootNode);  
            }
            trDepartment.ExpandAll();
        }

        private void BindTree(int entID, TreeNode oldNode, int departmentID)
        {
            TreeNode newNode;
            var moduleList = base.EnterpriseService.GetDepartmentByParentID(entID, departmentID);
            foreach (var item in moduleList)
            {
                newNode = new TreeNode();
                newNode.Text = item.DepCode + "_" + item.DepName;
                newNode.Target = "ModuleContentPage";
                if (!item.Published)
                {
                    newNode.ImageUrl = "~/images/unchecked.gif";
                }
                else
                {
                    newNode.ImageUrl = "~/images/checked.gif";
                }
                newNode.Value = item.DepartmentID.ToString();
                newNode.SelectAction = TreeNodeSelectAction.Select;
                this.BindTree(entID, newNode, item.DepartmentID);
                oldNode.ChildNodes.Add(newNode);
            }
        }

        protected void trDepartment_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.trDepartment.SelectedNode.Depth == 0)
            {
                var enterprise = base.EnterpriseService.GetEnterpriseByID(int.Parse(this.trDepartment.SelectedNode.Value));

                this.ddlDepartment.SelectedValue = "ent" + enterprise.EntId.ToString();
                this.DepartmentID = 0;
                this.EnterpriseID = enterprise.EntId;
                this.Clear();
                return;                
            }
            var department = base.EnterpriseService.GetDepartmentById(int.Parse(this.trDepartment.SelectedNode.Value));
            this.DepartmentID = int.Parse(this.trDepartment.SelectedNode.Value);
            if (department != null)
            {
                this.EnterpriseID = department.EnterpriseID;
                if (department.ParentDepartment != null)
                {
                    this.ddlDepartment.SelectedValue = department.ParentID.GetValueOrDefault().ToString();
                }
                else
                {
                    this.ddlDepartment.SelectedValue =  "ent"+this.EnterpriseID.ToString();
                }
                this.EnterpriseID = department.EnterpriseID;
                this.txtCode.Text = department.DepCode;
                this.txtName.Text = department.DepName;
                CommonHelper.SelectListItem(this.ddlDepType, department.DepType.GetValueOrDefault());
                this.chkPublished.Checked = department.Published;
                this.txtDisplayOrder.Value = department.DisplayOrder;
                this.txtRemark.Text = department.Remark;
                this.txtTel.Text = department.Tel;
                this.txtAddress.Text = department.Address;
                if (department.DepManager != null)
                {
                    this.SelectCustomer.SelectSingleCustomer = department.DepManager;
                    this.SelectCustomer.Value = department.DepManager.FullName;
                }
            }
            else
            {
                this.Clear();
            }
            this.SetButtonStyle();
        }

        private void Clear()
        {
            this.txtCode.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.chkPublished.Checked = true;
            this.txtDisplayOrder.Value = 1;
            this.txtRemark.Text = string.Empty;
            this.txtTel.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.SelectCustomer.Value = string.Empty;
            this.DepartmentID = 0;
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("系统管理->组织架构详细信息");
            this.ddlDepType.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(1, false);
            this.ddlDepType.DataSource = codeList;
            this.ddlDepType.DataTextField = "CodeName";
            this.ddlDepType.DataValueField = "CodeID";
            this.ddlDepType.DataBind();
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnSave.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnDelete.UniqueID, this.Page);
        }

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.EnterpriseID == 0)
            {
                base.ShowError("请选择节点");
                return;
            }
            this.Clear();
            this.DepartmentID = 0;
            BintDllDepartment();
            string ss = this.trDepartment.SelectedNode.Value;
            this.ddlDepartment.SelectedValue = this.trDepartment.SelectedNode.Value;
        }

        private void UpdateSonDepartment(int enterpriseID, int parentID)
        {
            var departments = base.EnterpriseService.GetDepartmentByParentID(enterpriseID, parentID);
            foreach (var item in departments)
            {
                item.EnterpriseID = enterpriseID;
                item.Label = item.DepartmentID.ToString().PadLeft(4, '0');
                if (item.ParentDepartment != null)
                {
                    item.Label = item.ParentDepartment.Label + item.Label;
                }

                base.EnterpriseService.UpdateDepartment(item);

                UpdateSonDepartment(enterpriseID, item.DepartmentID);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int depType = 0;
                int.TryParse(this.ddlDepType.SelectedValue, out depType);
                var department = base.EnterpriseService.GetDepartmentById(this.DepartmentID);
                int parentID = 0;
                int enterpriseID = 0;
                if (this.ddlDepartment.SelectedValue.Contains("ent"))
                {
                    parentID = 0;
                    int.TryParse(this.ddlDepartment.SelectedValue.Replace("ent", ""), out enterpriseID);
                }
                else
                {
                    int.TryParse(this.ddlDepartment.SelectedValue, out parentID);
                    var newDepartment = base.EnterpriseService.GetDepartmentById(parentID);
                    enterpriseID = newDepartment.EnterpriseID;
                }
                

                if (department != null)
                {
                    department.DepCode = this.txtCode.Text.Trim();
                    department.DepName = this.txtName.Text.Trim();
                    department.DepType = depType;
                    department.ParentID = parentID;
                    department.Published = this.chkPublished.Checked;
                    department.DisplayOrder = this.txtDisplayOrder.Value;
                    department.Tel = this.txtTel.Text.Trim();
                    department.EnterpriseID = enterpriseID;
                    department.Remark = this.txtRemark.Text;
                    department.Address = this.txtAddress.Text.Trim();
                    department.DepManagerID = this.SelectCustomer.SelectSingleCustomer.CustomerID;
                    department.EditUserId = HozestERPContext.Current.User.CustomerID;
                    department.EditTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    base.EnterpriseService.UpdateDepartment(department);

                    //更新当前节点的label
                    department.Label = department.DepartmentID.ToString().PadLeft(4, '0');
                    if (department.ParentDepartment != null)
                    {
                        department.Label = department.ParentDepartment.Label + department.Label;
                    }
                    base.EnterpriseService.UpdateDepartment(department);
                    //更新子节点的label
                    this.UpdateSonDepartment(enterpriseID, department.DepartmentID);
                    
                }
                else
                {
                    department = new HozestERP.BusinessLogic.Enterprises.Department();
                    department.ParentID = parentID;
                    department.DepCode = this.txtCode.Text.Trim();
                    department.DepName = this.txtName.Text.Trim();
                    department.DepType = depType;
                    department.Published = this.chkPublished.Checked;
                    department.DisplayOrder = this.txtDisplayOrder.Value;
                    department.Tel = this.txtTel.Text.Trim();
                    department.Remark = this.txtRemark.Text;
                    department.EnterpriseID = enterpriseID;
                    department.Address = this.txtAddress.Text.Trim();
                    department.Deleted = false;
                    department.DepManagerID = this.SelectCustomer.SelectSingleCustomer.CustomerID;
                    department.AddUserId = HozestERPContext.Current.User.CustomerID;
                    department.AddTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    department.EditUserId = HozestERPContext.Current.User.CustomerID;
                    department.EditTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    department.Label = string.Empty;
                    base.EnterpriseService.InsertDepartment(department);

                    department.Label = department.DepartmentID.ToString().PadLeft(4, '0');
                    if (department.ParentDepartment != null)
                    {
                        department.Label = department.ParentDepartment.Label + department.Label;
                    }
                    base.EnterpriseService.UpdateDepartment(department);
                }
                this.EnterpriseID = enterpriseID;                
                base.ShowMessage("保存成功.");
                this.Clear();
                this.BindTree();
                this.BintDllDepartment();
                this.SetButtonStyle();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            base.EnterpriseService.MarkDepartmentAsDeleted(this.DepartmentID);
            base.ShowMessage("保存成功.");
            this.Clear();
            this.BindTree();
            this.BintDllDepartment();
        }

       

        
    }
}