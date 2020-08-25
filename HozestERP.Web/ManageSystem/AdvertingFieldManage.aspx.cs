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
    public partial class AdvertingFieldManage : BaseAdministrationPage, IEditPage
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
                //绑定左边数
                BindTree();
                //绑定下拉框
                this.BintDllField();
            }
        }


        private void Clear()
        {
            this.txtFieldCode.Text = string.Empty;
            this.txtFieldName.Text = string.Empty;
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

        protected void trAdvertingField_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.trAdvertingField.SelectedNode.Depth == 0)
            {
                this.ddlFields.SelectedValue = "0";
                this.Id = 0;

                this.Clear();
                return;
            }
            var field = base.XMAdvertingFieldService.GetXMAdvertingFieldById(int.Parse(this.trAdvertingField.SelectedNode.Value));
            this.Id = int.Parse(this.trAdvertingField.SelectedNode.Value);
            if (field != null)
            {
                this.txtFieldCode.Text = field.FieldCode;
                this.txtFieldName.Text = field.FieldName;
            }
            else
            {
                this.Clear();
            }
            this.SetButtonStyle();
        }


        public void BindTree()
        {
            trAdvertingField.Nodes.Clear();
            var fields = base.XMAdvertingFieldService.GetXMAdvertingFieldList();
            TreeNode rootNode = new TreeNode();
            rootNode.Text = "广告费";
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
                rootNode.ChildNodes.Add(treeNode);
            }
            trAdvertingField.Nodes.Add(rootNode);
            trAdvertingField.ExpandAll();
        }


        private void BintDllField()
        {
            this.ddlFields.Items.Clear();
            BintDllField(0);
        }

        private void BintDllField(int fieldID)
        {
            ListItem item = new ListItem("广告费", "0");
            this.ddlFields.Items.Add(item);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.Clear();
            this.Id = 0;
            BintDllField();
            this.ddlFields.SelectedValue = "0";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var field = base.XMAdvertingFieldService.GetXMAdvertingFieldById(this.Id);
                if (field != null)
                {
                    field.FieldCode = this.txtFieldCode.Text.Trim();
                    field.FieldName = this.txtFieldName.Text.Trim();
                    field.UpdateID = HozestERPContext.Current.User.CustomerID;
                    field.UpdateDate = DateTime.Now;
                    field.IsDelete = false;
                    base.XMAdvertingFieldService.UpdateXMAdvertingField(field);
                }
                else
                {
                    field = new XMAdvertingField();
                    field.FieldCode = this.txtFieldCode.Text.Trim();
                    field.FieldName = this.txtFieldName.Text.Trim();
                    field.CreateID = HozestERPContext.Current.User.CustomerID;
                    field.CreateDate = DateTime.Now;
                    field.UpdateID = HozestERPContext.Current.User.CustomerID;
                    field.UpdateDate = DateTime.Now;
                    field.IsDelete = false;
                    base.XMAdvertingFieldService.InsertXMAdvertingField(field);
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
            //根据字段ID查询相关信息
            var fields = base.XMAdvertingFieldService.GetXMAdvertingFieldById(this.Id);
            if (fields != null)
            {
                base.XMAdvertingFieldService.DeleteXMAdvertingField(this.Id);
                base.ShowMessage("保存成功.");
            }
            else
            {
                base.ShowMessage("未查到该数据！");
            }
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