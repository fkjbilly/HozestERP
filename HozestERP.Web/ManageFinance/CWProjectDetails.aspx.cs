using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageFinance;

namespace HozestERP.Web.ManageFinance
{ 
    public partial class CWProjectDetails : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindModule();
                this.Id = CommonHelper.QueryStringInt("Id");
                var project = base.CWProjectService.GetCWProjectById(this.Id);
                if (project != null)
                {
                    this.Master.SetTitle("项目->“" + project.ProjectExplanation + "”详细信息");
                     
                    this.txtProjectExplanation.Text = project.ProjectExplanation; 
                    this.txtDisplayOrder.Value = project.DisplayOrder;
                    this.ddlParentModule.SelectedValue = project.ParentID.GetValueOrDefault().ToString(); 
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

        private void BindTree(int ParentID)
        {
            var ProjectList = base.CWProjectService.GetCWProjectListByParentID(ParentID);

            foreach (var item in ProjectList)
            {

                this.ddlParentModule.Items.Add(new ListItem(GetModuleFullName(item), item.Id.ToString()));

                this.BindTree(item.Id);
            }
        }

        protected string GetModuleFullName(CWProject project)
        {
            string result = string.Empty;

            while (project != null)
            {
                if (String.IsNullOrEmpty(result))
                {
                    result = project.ProjectExplanation;
                }
                else
                {
                    result = "----" + result;
                }
                project = project.ParentProjects;
            }
            return result;
        }

        public void Clear()
        { 
            this.txtProjectExplanation.Text = string.Empty; 
            this.txtDisplayOrder.Value = 1; 
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


        public int Id
        {
            get
            {
                int moduleID = 0;
                int.TryParse(this.hidID.Value, out moduleID);
                return moduleID;
            }
            set
            {
                this.hidID.Value = value.ToString();
            }
        }

        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
            int parentModuleID = this.Id;
            this.Clear(); 
            this.ddlParentModule.SelectedValue = parentModuleID.ToString();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int parentmoduleid = 0;
                int.TryParse(this.ddlParentModule.SelectedValue, out parentmoduleid);
                if (this.Id.Equals(0))
                {
                    var project = base.CWProjectService.InsertCWProject(parentmoduleid, this.txtProjectExplanation.Text, this.ccTableTypeId.SelectedValue, this.txtDisplayOrder.Value);
                    this.Master.JsWrite("Refesh('" + project.Id.ToString() + "');", "");
                    base.ShowMessage("添加成功!");
                }
                else
                {
                    base.CWProjectService.UpdateCWProject(this.Id, parentmoduleid, this.txtProjectExplanation.Text, this.ccTableTypeId.SelectedValue, this.txtDisplayOrder.Value);
                    this.Master.JsWrite("Refesh('" + this.Id + "');", "");
                    base.ShowMessage("修改成功!");
                }

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            base.ModuleService.DeleteModule(this.Id);
            this.Master.JsWrite("BtnDelete();", "");
        }
         
       
    }
}