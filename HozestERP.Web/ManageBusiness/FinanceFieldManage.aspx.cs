using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageBusiness;

namespace HozestERP.Web.ManageBusiness
{
    public partial class FinanceFieldManage : BaseAdministrationPage, IEditPage
    {
        private int Id
        {
            get
            {
                int id = 0;
                try
                {
                    int.TryParse(ViewState["Id"].ToString(), out id);
                }
                catch
                {
                }
                return id;
            }
            set
            {
                ViewState["Id"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTree();
                this.BintDllField();
                this.ddlManagementField.Enabled = false;
            }
        }


        protected void trFinanceField_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.trFinanceField.SelectedNode.Depth == 0)
            {
                this.ddlFields.SelectedValue = "0";
                this.Id = 0;

                this.Clear();
                return;
            }
            var field = base.XMFinancialFieldService.GetXMFinancialFieldById(int.Parse(this.trFinanceField.SelectedNode.Value));
            this.Id = int.Parse(this.trFinanceField.SelectedNode.Value);
            if (field != null)
            {
                //if (field.ParentFinancialField != null)
                //{
                //    this.ddlFields.SelectedValue = field.ParentID.GetValueOrDefault().ToString();
                //}
                //else
                //{
                //    this.ddlFields.SelectedValue = string.Empty;
                //}
                if (field.ParentFinancialField != null)
                {
                    ddlFields.SelectedValue = field.ParentFinancialField.Id.ToString();
                }
                else
                {
                    ddlFields.SelectedValue = "0";
                }
                this.txtFieldCode.Text = field.FieldCode;
                this.txtFieldName.Text = field.FieldName;
                //CommonHelper.SelectListItem(this.ddlDepType, field.DepType.GetValueOrDefault());
                this.txtDisplayOrder.Value = field.DisplayOrder;

                if (field.ParentFinancialField != null && field.ParentFinancialField.Id == 70)//营业费用
                {
                    this.ddlManagementField.Enabled = true;
                    this.ddlManagementField.SelectedValue = field.IsManagementField == null ? "0" : (field.IsManagementField == false ? "0" : "1");
                }
                else
                {
                    this.ddlManagementField.Enabled = false;
                    this.ddlManagementField.SelectedValue = "0";
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
            this.txtFieldCode.Text = string.Empty;
            this.txtFieldName.Text = string.Empty;
            this.txtDisplayOrder.Value = 1;
            this.Id = 0;
        }

        public void SetButtonStyle()
        {
            if (this.Id == 0)
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

        public void BindTree()
        {
            trFinanceField.Nodes.Clear();
            var fields = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(0);
            TreeNode rootNode = new TreeNode();
            rootNode.Text = "项目";
            rootNode.ImageUrl = "~/images/CPC_CompGroup.gif";
            rootNode.Target = "ModuleContentPage";
            rootNode.Value = string.Empty;
            rootNode.SelectAction = TreeNodeSelectAction.Select;
            rootNode.ExpandAll();
            TreeNode treeNode;
            foreach (var item in fields)
            {
                treeNode = new TreeNode();
                treeNode.Text = item.FieldName;
                treeNode.Value = item.Id.ToString();
                treeNode.Target = "ModuleContentPage";
                treeNode.SelectAction = TreeNodeSelectAction.Select;
                this.BindTree(treeNode, item.Id);
                rootNode.ChildNodes.Add(treeNode);
            }
            trFinanceField.Nodes.Add(rootNode);
            trFinanceField.ExpandAll();
        }

        private void BindTree(TreeNode oldNode, int fieldID)
        {
            TreeNode newNode;
            var moduleList = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(fieldID);
            foreach (var item in moduleList)
            {
                newNode = new TreeNode();
                newNode.Text = item.FieldName;
                newNode.Target = "ModuleContentPage";
                newNode.Value = item.Id.ToString();
                newNode.SelectAction = TreeNodeSelectAction.Select;
                this.BindTree(newNode, item.Id);
                oldNode.ChildNodes.Add(newNode);
            }
        }

        private void BintDllField()
        {
            this.ddlFields.Items.Clear();
            BintDllField(0);
        }

        private void BintDllField(int fieldID)
        {
            ListItem item = new ListItem("项目字段", "0");
            this.ddlFields.Items.Add(item);
            var moduleList = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(fieldID);
            this.BindFieldList(string.Empty, moduleList);
        }

        /// <summary>
        /// 递归获取字段
        /// </summary>
        /// <param name="parentString"></param>
        /// <param name="fields"></param>
        public void BindFieldList(string parentString, List<XMFinancialField> fields)
        {
            string newParentString = parentString;
            for (int i = 0; i < fields.Count; i++)
            {
                var field = fields[i];
                if (field.Id == this.Id)
                    continue;
                bool isLast = false;
                if ((i + 1) == fields.Count)
                {
                    isLast = true;
                }
                var childDepartments = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(field.Id);
                bool hasChild = childDepartments.Count > 0 ? true : false;
                newParentString = GetPreFix(isLast, hasChild, parentString);
                ListItem item = new ListItem(newParentString + field.FieldName, field.Id.ToString());
                this.ddlFields.Items.Add(item);
                if (hasChild)
                {
                    BindFieldList(newParentString, childDepartments);
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.Clear();
            this.Id = 0;
            BintDllField();
            if (this.trFinanceField.SelectedNode.Value != null)
            {
                this.ddlFields.SelectedValue = this.trFinanceField.SelectedNode.Value;
                var fields = base.XMFinancialFieldService.GetXMFinancialFieldById(Convert.ToInt16(this.trFinanceField.SelectedNode.Value));
                if (fields != null && fields.Id == 70)//营业费用
                {
                    this.ddlManagementField.Enabled = true;
                    this.ddlManagementField.SelectedValue = "0";
                }
                else
                {
                    this.ddlManagementField.Enabled = false;
                    this.ddlManagementField.SelectedValue = "0";
                }
            }
            else
            {
                this.ddlFields.SelectedValue = "0";
                this.ddlManagementField.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool IsManagementField = false;
                if (this.ddlManagementField.Enabled == true)//营业费用
                {
                    IsManagementField = true;
                }

                var field = base.XMFinancialFieldService.GetXMFinancialFieldById(this.Id);
                int parentID = 0;

                int.TryParse(this.ddlFields.SelectedValue, out parentID);
                var newField = base.XMFinancialFieldService.GetXMFinancialFieldById(parentID);
                if (field != null)
                {
                    field.FieldCode = this.txtFieldCode.Text.Trim();
                    field.FieldName = this.txtFieldName.Text.Trim();
                    field.ParentID = parentID;
                    field.DisplayOrder = this.txtDisplayOrder.Value;
                    field.EditUserId = HozestERPContext.Current.User.CustomerID;
                    field.EditTime = DateTime.Now;
                    field.Deleted = false;
                    field.IsManagementField = IsManagementField;
                    base.XMFinancialFieldService.UpdateXMFinancialField(field);
                }
                else
                {
                    field = new XMFinancialField();
                    field.ParentID = parentID;
                    field.FieldCode = this.txtFieldCode.Text.Trim();
                    field.FieldName = this.txtFieldName.Text.Trim();
                    field.DisplayOrder = this.txtDisplayOrder.Value;
                    field.AddUserId = HozestERPContext.Current.User.CustomerID;
                    field.AddTime = DateTime.Now;
                    field.EditUserId = HozestERPContext.Current.User.CustomerID;
                    field.EditTime = DateTime.Now;
                    field.Deleted = false;
                    field.IsManagementField = IsManagementField;
                    base.XMFinancialFieldService.InsertXMFinancialField(field);
                }
                base.ShowMessage("保存成功.");
                this.Clear();
                this.BindTree();
                this.BintDllField();
                this.SetButtonStyle();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.Id == 0)
            {
                base.ShowMessage("该节点无法删除!");
                return;
            }
            base.XMFinancialFieldService.MarkFieldAsDeleted(this.Id);
            base.ShowMessage("保存成功.");
            this.Clear();
            this.BindTree();
            this.BintDllField();
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            //this.Master.SetTitle("系统管理->组织架构详细信息");
            //this.ddlDepType.Items.Clear();
            //var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(1, false);
            //this.ddlDepType.DataSource = codeList;
            //this.ddlDepType.DataTextField = "CodeName";
            //this.ddlDepType.DataValueField = "CodeID";
            //this.ddlDepType.DataBind();
        }

        public void SetTrigger()
        {
            //this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnSave.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnDelete.UniqueID, this.Page);
        }

        #endregion
    }
}