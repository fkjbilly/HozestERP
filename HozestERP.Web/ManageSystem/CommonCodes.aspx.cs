using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageSystem
{
    public partial class CommonCodes : BaseAdministrationPage, IEditPage
    {
        /// <summary>
        /// 获取当前记录CodeID
        /// </summary>
        private int CodeID
        {
            get
            {
                int codeID = 0;
                try
                {
                    int.TryParse(ViewState["CodeID"].ToString(), out codeID);
                }
                catch
                {
                }
                return codeID;
            }
            set
            {
                ViewState["CodeID"] = value;
            }
        }

        /// <summary>
        /// 获取大类CodeTypeID
        /// </summary>
        public int CodeTypeID
        {
            get
            {
                int codetypeID = 0;
                try
                {
                    int.TryParse(ViewState["CodeTypeID"].ToString(), out codetypeID);
                }
                catch
                {
                }
                return codetypeID;
            }
            set
            {
                ViewState["CodeTypeID"] = value;
            }
        }


        public int ModuleID
        {
            get
            {
                return CommonHelper.QueryStringInt("ModuleID");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindCodeType();
            }
        }

        private void BindCodeType()
        {
            var codeTypes = base.CodeTypeService.GetCodeTypeByModuleID(this.ModuleID);
            this.grdCodeType.DataSource = codeTypes;
            this.grdCodeType.DataBind();

        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("系统管理->功能模块详细信息");
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.grdCodeType.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnSave.UniqueID, this.Page);
        }

        #endregion

        protected void grdCodeType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("btnCode"))
            {
                int codeTypeID = 0;
                int.TryParse(e.CommandArgument.ToString(), out codeTypeID);
                var codeLists = base.CodeService.GetCodeListInfoByCodeTypeID(codeTypeID);
                this.CodeTypeID = codeTypeID;
                this.grdCode.DataSource = codeLists;
                this.grdCode.DataBind();
            }
        }

        private void Clear()
        {
            this.txtCodeNo.Text = string.Empty;
            this.txtCodeName.Text = string.Empty;
            this.txtDisplayOrder.Value = 1;
            this.chkDeleted.Checked = false;
            this.CodeID = -1;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.CodeTypeID == 0)
            {
                base.ShowError("请选择基本信息节点");
                return;
            }

            this.Clear();
            this.txtCodeName.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var codelist = base.CodeService.GetCodeListInfoByCodeID(this.CodeID);

                if (codelist != null)
                {
                    codelist.CodeName = this.txtCodeName.Text.Trim();
                    codelist.CodeNO = this.txtCodeNo.Text.Trim();
                    codelist.CodeTypeID = this.CodeTypeID;
                    codelist.Deleted = this.chkDeleted.Checked;
                    codelist.DisplayOrder = this.txtDisplayOrder.Value;
                    base.CodeService.UpdateCodeList(codelist);
                }
                else
                {
                    codelist = new HozestERP.BusinessLogic.Codes.CodeList();
                    codelist.CodeName = this.txtCodeName.Text.Trim();
                    codelist.CodeNO = this.txtCodeNo.Text.Trim();
                    codelist.CodeTypeID = this.CodeTypeID;
                    codelist.DisplayOrder = this.txtDisplayOrder.Value;
                    codelist.Deleted = this.chkDeleted.Checked;
                    base.CodeService.InsertCodeList(codelist);
                }
                var codeLists = base.CodeService.GetCodeListInfoByCodeTypeID(this.CodeTypeID);
                this.grdCode.DataSource = codeLists;
                this.grdCode.DataBind();
                base.ShowMessage("保存成功");
                this.Clear();
                this.txtCodeName.Focus();
            }
        }

        protected void grdCode_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                int codeID = 0;
                int.TryParse(e.CommandArgument.ToString(), out codeID);
                this.CodeID = codeID;
                var code = base.CodeService.GetCodeListInfoByCodeID(this.CodeID);
                if(code!=null)
                {
                    this.txtCodeName.Text = code.CodeName;
                    this.txtCodeNo.Text = code.CodeNO;
                    this.txtDisplayOrder.Value = code.DisplayOrder;
                    this.chkDeleted.Checked = code.Deleted;
                }
            }
        }

    }
}