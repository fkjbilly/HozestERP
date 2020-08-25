using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web.ManageBusiness
{
    public partial class BusinessDataOtherAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal a = 0;
            string StrObject = this.txtObject.Text.Trim();
            int BusinessType = this.ddlBusinessType.SelectedValue;
            string BelongingDep = this.ddlBelongingDep.SelectedValue;//归属部门
            string BelongingName = this.ShibrBelongingName.Value.Trim();//归属人
            string BelongingProject = this.ddlBelongingProject.SelectedValue;//归属项目
            int AmountType = this.ddlAmountType.SelectedValue;
            string Amount = this.txtAmount.Text.Trim();
            string Remark = this.txtRemark.Text.Trim();

            if (Amount == "")
            {
                base.ShowMessage("金额不能为空！");
                return;
            }

            if (decimal.TryParse(Amount, out a) == false)
            {
                base.ShowMessage("金额格式错误！");
                return;
            }

            if (Id == 0 && Type == 0)
            {
                if (StatusID != 0)
                {
                    //更新数据
                    UpdateXMBusinessDataOtherByID(StatusID);
                }
                else
                {
                    //新增数据
                    XMBusinessDataOther Info = new XMBusinessDataOther();
                    Info.Object = StrObject;
                    Info.SubmitDate = DateTime.Now;
                    Info.BelongingDepID = int.Parse(BelongingDep);
                    Info.BelongingProjectID = int.Parse(BelongingProject);
                    Info.BelongingName = BelongingName;
                    Info.AmountType = AmountType;
                    Info.Amount = decimal.Parse(Amount);
                    Info.BusinessType = BusinessType;
                    Info.Remark = Remark;
                    Info.FinancialStatus = false;
                    Info.ContractlStatus = false;
                    Info.IsEnabled = false;
                    Info.Creator = HozestERPContext.Current.User.CustomerID;
                    Info.CreateDate = DateTime.Now;
                    Info.Updater = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDate = DateTime.Now;
                    base.XMBusinessDataOtherService.InsertXMBusinessDataOther(Info);
                    //屏蔽重复插入的问题
                    StatusID = Info.ID;
                }
            }
            else
            {
                //更新数据
                UpdateXMBusinessDataOtherByID(Id);
            }
            base.ShowMessage("保存成功！");
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="ID"></param>
        public void UpdateXMBusinessDataOtherByID(int ID)
        {
            string StrObject = this.txtObject.Text.Trim();
            int BusinessType = this.ddlBusinessType.SelectedValue;
            string BelongingDep = this.ddlBelongingDep.SelectedValue;//归属部门
            string BelongingName = this.ShibrBelongingName.Value.Trim();//归属人
            string BelongingProject = this.ddlBelongingProject.SelectedValue;//归属项目
            int AmountType = this.ddlAmountType.SelectedValue;
            string Amount = this.txtAmount.Text.Trim();
            string Remark = this.txtRemark.Text.Trim();
            XMBusinessDataOther Info = base.XMBusinessDataOtherService.GetXMBusinessDataOtherByID(ID);
            Info.Object = StrObject;
            Info.BelongingDepID = int.Parse(BelongingDep);
            Info.BelongingProjectID = int.Parse(BelongingProject);
            Info.BelongingName = BelongingName;
            Info.AmountType = AmountType;
            Info.Amount = decimal.Parse(Amount);
            Info.BusinessType = BusinessType;
            Info.Remark = Remark;
            Info.Updater = HozestERPContext.Current.User.CustomerID;
            Info.UpdateDate = DateTime.Now;
            base.XMBusinessDataOtherService.UpdateXMBusinessDataOther(Info);
        }

        public void loadDate()
        {
            this.Face_Init();
            XMBusinessDataOther Info = base.XMBusinessDataOtherService.GetXMBusinessDataOtherByID(Id);
            if (Id != 0)
            {
                this.txtObject.Text = Info.Object.ToString();
                this.ddlBusinessType.SelectedValue = (int)Info.BusinessType;
                this.ddlBelongingDep.SelectedValue = Info.BelongingDepID.ToString();
                this.ddlAmountType.SelectedValue = (int)Info.AmountType;
                this.txtAmount.Text = Info.Amount.ToString();
                this.txtRemark.Text = Info.Remark.ToString();
                this.ShibrBelongingName.Value = Info.BelongingName.ToString();
            }

            this.ddlBelongingProject.Items.Clear();
            var list = base.XMProjectService.GetXMProjectListByDepID(int.Parse(this.ddlBelongingDep.SelectedValue));
            if (list != null && list.Count > 0)
            {
                this.ddlBelongingProject.DataSource = list;
                this.ddlBelongingProject.DataTextField = "ProjectName";
                this.ddlBelongingProject.DataValueField = "Id";
                this.ddlBelongingProject.DataBind();
            }
            this.ddlBelongingProject.Items.Insert(0, new ListItem("", "-1"));
            if (Id != 0)
            {
                this.ddlBelongingProject.SelectedValue = Info.BelongingProjectID.ToString();
            }

            if (Id != 0 && Type == 0)
            {
                this.btnSave.Visible = false;
            }
        }

        protected void ddlBelongingDep_Changed(Object sender, EventArgs e)
        {
            this.ddlBelongingProject.Items.Clear();
            var list = base.XMProjectService.GetXMProjectListByDepID(int.Parse(this.ddlBelongingDep.SelectedValue));
            if (list != null && list.Count > 0)
            {
                this.ddlBelongingProject.DataSource = list;
                this.ddlBelongingProject.DataTextField = "ProjectName";
                this.ddlBelongingProject.DataValueField = "Id";
                this.ddlBelongingProject.DataBind();
            }
            this.ddlBelongingProject.Items.Insert(0, new ListItem("", "-1"));
        }

        public int StatusID
        {
            get { return ViewState["StatusID"] == null ? 0 : (int)ViewState["StatusID"]; }

            set { ViewState["StatusID"] = value; }
        }

        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("ID");
            }
        }

        public int Type
        {
            get
            {
                return CommonHelper.QueryStringInt("DataType");
            }
        }

        public void Face_Init()
        {
            CommonMethod.DropDownListDepartment(this.ddlBelongingDep, false);
        }

        public void SetTrigger()
        {
        }
    }
}