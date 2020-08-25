using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ModuleManagement;

namespace HozestERP.Web.ManageSystem
{
    public partial class ModuleDetails : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindModule();
                this.ModuleID = CommonHelper.QueryStringInt("ModuleID"); 
                var module = base.ModuleService.getModuleByModuleID(this.ModuleID);
                if (module != null)
                {
                    this.Master.SetTitle("系统管理->“" + module.ModuleName + "”详细信息");
                    //if (module.ParentModule != null)
                    //{
                    //    this.txtParentModuleCode.Text = module.ParentModule.ModuleCode;
                    //    this.txtParentModuleName.Text = module.ParentModule.ModuleName;
                    //}
                    //this.ParentModuleID = module.ParentID.GetValueOrDefault();
                    this.txtModuleCode.Text = module.ModuleCode;
                    this.txtModuleName.Text = module.ModuleName;
                    this.txtHref.Text = module.href;
                    this.chkExpand.Checked = module.Expand;
                    this.chkPublished.Checked = module.Published;
                    this.chkisTarget.Checked = module.isTarget;
                    this.txtDisplayOrder.Value = module.DisplayOrder;
                    this.txticonCls.Text = module.iconCls;
                    this.txtAppIconCls.Text = module.AppIconCls;
                    this.grdvMessage.DataSource = module.SCustomerActions;
                    this.grdvMessage.DataBind();
                    this.btnAddClick.Enabled = true;
                    this.ddlParentModule.SelectedValue = module.ParentID.GetValueOrDefault().ToString();
                    this.btnAddClick.OnClientClick = "return ShowDetail('CustomerAction.aspx?ModuleID=" + this.ModuleID + "');";
                    //this.btnRefesh.Click += btnAddClick_Click;
                }
                else
                {
                    this.Clear();
                }
            }
        }

        private void BindModule()
        {
            this.ddlParentModule.Items.Clear();
            this.ddlParentModule.Items.Add(new ListItem("", "0"));
            this.BindTree(0);

        }

        private void BindTree(int moduleID)
        {
            var moduleList = base.ModuleService.GetModuleListByModuleID(moduleID);

            foreach (var item in moduleList)
            {

                this.ddlParentModule.Items.Add(new ListItem(GetModuleFullName(item), item.ModuleID.ToString()));

                this.BindTree(item.ModuleID);
            }
        }

        protected string GetModuleFullName(Module module)
        {
            string result = string.Empty;

            while (module != null)
            {
                if (String.IsNullOrEmpty(result))
                {
                    result = module.ModuleName;
                }
                else
                {
                    result = "----" + result;
                }
                module = module.ParentModule;
            }
            return result;
        }

        public void Clear()
        {
            //this.txtParentModuleCode.Text = string.Empty;
            //this.txtParentModuleName.Text = string.Empty;
            this.hidParentModuleID.Value = string.Empty;
            this.txtModuleCode.Text = string.Empty;
            this.txtModuleName.Text = string.Empty;
            this.txtHref.Text = string.Empty;
            this.txtDisplayOrder.Value = 1;
            //this.ParentModuleID = 0;
            this.ModuleID = 0;
            this.btnAddClick.Enabled = false;
            this.txticonCls.Text = "filesw";
            this.txtAppIconCls.Text = "default.png";
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("系统管理->功能模块详细信息");
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnSave.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnDelete.UniqueID, this.Page);
        }
        #endregion


        public int ModuleID
        {
            get
            {
                int moduleID = 0;
                int.TryParse(this.hidModuleID.Value, out moduleID);
                return moduleID;
            }
            set
            {
                this.hidModuleID.Value = value.ToString();
            }
        }

        //public int ParentModuleID
        //{
        //    get
        //    {
        //        int parentModuleID = 0;
        //        int.TryParse(this.hidParentModuleID.Value, out parentModuleID);
        //        return parentModuleID;
        //    }
        //    set
        //    {
        //        this.hidParentModuleID.Value = value.ToString();
        //    }
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //string paretModuleCode = this.txtModuleCode.Text;
            //string paramModuleName = this.txtModuleName.Text;
            int parentModuleID = this.ModuleID;
            this.Clear();
            //this.txtParentModuleCode.Text = paretModuleCode;
            //this.txtParentModuleName.Text = paramModuleName;
            this.ddlParentModule.SelectedValue = parentModuleID.ToString();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int parentmoduleid = 0;
                int.TryParse(this.ddlParentModule.SelectedValue, out parentmoduleid);
                if (this.ModuleID.Equals(0))
                {
                    var moudle = base.ModuleService.InsertModule(parentmoduleid, this.txtModuleName.Text, this.txtModuleCode.Text,
                        this.chkisTarget.Checked, this.txtHref.Text, this.chkExpand.Checked, this.txtDisplayOrder.Value, this.chkPublished.Checked, this.txticonCls.Text.Trim(),this.txtAppIconCls.Text.Trim());
                    this.Master.JsWrite("Refesh('" + moudle.ModuleID.ToString() + "');", "");
                    base.ShowMessage("添加成功!");
                }
                else
                {
                    base.ModuleService.UpdateModule(this.ModuleID, parentmoduleid, this.txtModuleName.Text, this.txtModuleCode.Text, this.chkisTarget.Checked, this.txtHref.Text
                        , this.chkExpand.Checked, this.txtDisplayOrder.Value, this.chkPublished.Checked, this.txticonCls.Text.Trim(), this.txtAppIconCls.Text.Trim());
                    this.Master.JsWrite("Refesh('" + this.ModuleID + "');", "");
                    base.ShowMessage("修改成功!");
                }

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            base.ModuleService.DeleteModule(this.ModuleID);
            this.Master.JsWrite("BtnDelete();", "");
        }

        private void BindGrid()
        {
            var customerActionList = base.ACLService.GetAllCustomerActions(this.ModuleID);
            this.grdvMessage.DataSource = customerActionList;
            this.grdvMessage.DataBind();
        }

        protected void grdvMessage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("detail"))
            {
                BindGrid();
            }
            else if (e.CommandName.Equals("btnDelete"))
            {
                int customerActionID = 0;
                int.TryParse(e.CommandArgument.ToString(), out customerActionID);
                base.ACLService.DeleteCustomerAction(customerActionID);
                this.BindGrid();
            }
        }

        protected void grdvMessage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgbtnDetail = (e.Row.FindControl("imgbtnDetail") as ImageButton);
                imgbtnDetail.Attributes.Add("onclick", "return ShowDetail('CustomerAction.aspx?CustomerActionID=" + imgbtnDetail.CommandArgument.ToString() + "&ModuleID=" + this.ModuleID + "');"); 
            }
        }

        protected void btnAddClick_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}