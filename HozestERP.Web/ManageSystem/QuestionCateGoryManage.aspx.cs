using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageSystem
{
    public partial class QuestionCateGoryManage : BaseAdministrationPage, IEditPage
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
                //绑定左边树
                BindTree();
                //绑定下拉框
                this.BintDllCategory();
            }
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

        protected void trQuestionCategory_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.trQuestionCategory.SelectedNode.Depth == 0)
            {
                this.ddlQuestionCategory.SelectedValue = "0";
                this.Id = 0;
                this.Clear();
                return;
            }
            var category = base.XMQuestionCategoryService.GetXMQuestionCategoryById(int.Parse(this.trQuestionCategory.SelectedNode.Value));
            this.Id = int.Parse(this.trQuestionCategory.SelectedNode.Value);
            if (category != null)
            {
                if (category.ParentCategory != null)
                {
                    ddlQuestionCategory.SelectedValue = category.ParentCategory.Id.ToString();
                }
                else
                {
                    ddlQuestionCategory.SelectedValue = "0";
                }
                this.txtCategoryCode.Text = category.CategoryCode;
                this.txtCategoryName.Text = category.CategoryName;
                this.txtDisplayOrder.Value = category.DisplayOrder;
            }
            else
            {
                this.Clear();
            }
            this.SetButtonStyle();
        }

        private void Clear()
        {
            this.txtCategoryCode.Text = string.Empty;
            this.txtCategoryName.Text = string.Empty;
            this.txtDisplayOrder.Value = 1;
            this.Id = 0;
        }

        public void BindTree()
        {
            trQuestionCategory.Nodes.Clear();
            var category = base.XMQuestionCategoryService.GetXMQuestionCategoryByParentID(0);
            TreeNode rootNode = new TreeNode();
            rootNode.Text = "问题类型";
            rootNode.ImageUrl = "~/images/CPC_CompGroup.gif";
            rootNode.Target = "ModuleContentPage";
            rootNode.Value = string.Empty;
            rootNode.SelectAction = TreeNodeSelectAction.Select;
            rootNode.ExpandAll();
            TreeNode treeNode;
            foreach (var item in category)
            {
                treeNode = new TreeNode();
                treeNode.Text = item.CategoryName;
                treeNode.Value = item.Id.ToString();
                treeNode.Target = "ModuleContentPage";
                treeNode.SelectAction = TreeNodeSelectAction.Select;
                this.BindTree(treeNode, item.Id);
                rootNode.ChildNodes.Add(treeNode);
            }
           trQuestionCategory.Nodes.Add(rootNode);
           trQuestionCategory.ExpandAll();
        }


        private void BindTree(TreeNode oldNode, int categoryId)
        {
            TreeNode newNode;
            var moduleList = base.XMQuestionCategoryService.GetXMQuestionCategoryByParentID(categoryId);
            foreach (var item in moduleList)
            {
                newNode = new TreeNode();
                newNode.Text = item.CategoryName;
                newNode.Target = "ModuleContentPage";
                newNode.Value = item.Id.ToString();
                newNode.SelectAction = TreeNodeSelectAction.Select;
                this.BindTree(newNode, item.Id);
                oldNode.ChildNodes.Add(newNode);
            }
        }

        private void BintDllCategory()
        {
            this.ddlQuestionCategory.Items.Clear();
            BintDllCategory(0);
        }


        private void BintDllCategory(int categoryId)
        {
            ListItem item = new ListItem("问题类型", "0");
            this.ddlQuestionCategory.Items.Add(item);
            var moduleList = base.XMQuestionCategoryService.GetXMQuestionCategoryByParentID(categoryId);
            this.BindCategoryList(string.Empty, moduleList);
        }

        /// <summary>
        /// 递归获取字段
        /// </summary>
        /// <param name="parentString"></param>
        /// <param name="fields"></param>
        public void BindCategoryList(string parentString, List<XMQuestionCategory> categorys)
        {
            string newParentString = parentString;
            for (int i = 0; i < categorys.Count; i++)
            {
                var category = categorys[i];
                if (category.Id == this.Id)
                    continue;
                bool isLast = false;
                if ((i + 1) == categorys.Count)
                {
                    isLast = true;
                }
                var childCategorys = base.XMQuestionCategoryService.GetXMQuestionCategoryByParentID(category.Id);
                bool hasChild = childCategorys.Count > 0 ? true : false;
                newParentString = GetPreFix(isLast, hasChild, parentString);
                ListItem item = new ListItem(newParentString + category.CategoryName, category.Id.ToString());
                this.ddlQuestionCategory.Items.Add(item);
                if (hasChild)
                {
                    BindCategoryList(newParentString, childCategorys);
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
            BintDllCategory();
            if (this.trQuestionCategory.SelectedNode.Value != null)
            {
                this.ddlQuestionCategory.SelectedValue = this.trQuestionCategory.SelectedNode.Value;
            }
            else
            {
                this.ddlQuestionCategory.SelectedValue = "0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var category = base.XMQuestionCategoryService.GetXMQuestionCategoryById(this.Id);
                int parentID = 0;

                int.TryParse(this.ddlQuestionCategory.SelectedValue, out parentID);
                var newCategory = base.XMQuestionCategoryService.GetXMQuestionCategoryById(parentID);
                if (category != null)
                {
                    category.CategoryCode = this.txtCategoryCode.Text.Trim();
                    category.CategoryName = this.txtCategoryName.Text.Trim();
                    category.ParentId = parentID;
                    category.DisplayOrder = this.txtDisplayOrder.Value;
                    category.UpdateID = HozestERPContext.Current.User.CustomerID;
                    category.UpdateDate = DateTime.Now;
                    category.IsDeleted = false;
                    base.XMQuestionCategoryService.UpdateXMQuestionCategory(category);
                }
                else
                {
                    category = new XMQuestionCategory();
                    category.ParentId = parentID;
                    category.CategoryCode = this.txtCategoryCode.Text.Trim();
                    category.CategoryName = this.txtCategoryName.Text.Trim();
                    category.DisplayOrder = this.txtDisplayOrder.Value;
                    category.CreateID = HozestERPContext.Current.User.CustomerID;
                    category.CreateDate = DateTime.Now;
                    category.UpdateID = HozestERPContext.Current.User.CustomerID;
                    category.UpdateDate = DateTime.Now;
                    category.IsDeleted = false;
                    base.XMQuestionCategoryService.InsertXMQuestionCategory(category);
                }
                base.ShowMessage("保存成功.");
                this.Clear();
                this.BindTree();
                this.BintDllCategory();
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
            base.XMQuestionCategoryService.MarkQuestionCategoryAsDeleted(this.Id);
            base.ShowMessage("保存成功.");
            this.Clear();
            this.BindTree();
            this.BintDllCategory();
        }


        #region IEditPage 成员

        public void Face_Init()
        {

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