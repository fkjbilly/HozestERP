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
    public partial class BusinessDataB2BDetail : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        protected void btnContractNumber_Click(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                string ContractNumber = this.txtContractNumber.Text.Trim();
                if (ContractNumber == "")
                {
                    base.ShowMessage("合同编号不能为空！");
                    return;
                }

                var list = base.XMBusinessDataDetailService.GetXMBusinessDataDetailListByBusinessDataID(Id);
                if (list != null & list.Count > 0)
                {
                    foreach (XMBusinessDataDetail one in list)
                    {
                        if (IsFinancialStatus((int)one.AmountType) == 2 && (bool)one.FinancialStatus)//为收款，且已审核
                        {
                            base.ShowMessage("财务已审核，不能修改！");
                            return;
                        }
                    }
                }

                var ContractNumberExist = base.XMBusinessDataService.GetXMBusinessDataDetailListByContractNumber(ContractNumber, Id);
                if (ContractNumberExist != null && ContractNumberExist.Count > 0)
                {
                    base.ShowMessage("该合同编号已存在！");
                    return;
                }
                XMBusinessData Info = base.XMBusinessDataService.GetXMBusinessDataByID(Id);
                if (Info.ContractNumber == ContractNumber)
                {
                    base.ShowMessage("合同编号未作修改！");
                    return;
                }
                Info.ContractNumber = ContractNumber;
                Info.Updater = HozestERPContext.Current.User.CustomerID;
                Info.UpdateDate = DateTime.Now;
                base.XMBusinessDataService.UpdateXMBusinessData(Info);
                base.ShowMessage("合同编号修改成功！");
            }
            else
            {
                base.ShowMessage("请先添加合同信息！");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime a = DateTime.Now;
            decimal b = 0;
            string ContractNumber = this.txtContractNumber.Text.Trim();
            string ContractAmount = this.txtContractAmount.Text.Trim();
            string ClientCompany = this.txtClientCompany.Text.Trim();
            string SubmitLimit = this.txtSubmitLimit.Text.Trim();
            string Date = this.txtSubmitDate.Value.Trim();
            string PayPerson = this.txtPayPerson.Text.Trim();

            if (ContractNumber == "" || ContractAmount == "" || ClientCompany == "" || SubmitLimit == ""
                || Date == "")
            {
                base.ShowMessage("数据不能为空！");
                return;
            }
            if (!DateTime.TryParse(Date, out a))
            {
                base.ShowMessage("提交时间格式错误！");
                return;
            }

            if (decimal.TryParse(ContractAmount, out b)==false)
            {
                base.ShowMessage("合同金额格式错误！");
                return;
            }

            //if (int.TryParse(SubmitLimit, out c) == false)
            //{
            //    base.ShowMessage("提交年限格式错误！");
            //    return;
            //}

            if (Id == 0 && Type == 0)
            {
                var ContractNumberExist = base.XMBusinessDataService.GetXMBusinessDataDetailListByContractNumber(ContractNumber, Id);
                if (ContractNumberExist != null && ContractNumberExist.Count > 0)
                {
                    base.ShowMessage("该合同编号已存在！");
                    return;
                }
                XMBusinessData Info = new XMBusinessData();
                Info.ContractNumber = ContractNumber;
                Info.ContractAmount = decimal.Parse(ContractAmount);
                Info.ClientCompany = ClientCompany;
                Info.SubmitLimit = SubmitLimit;
                Info.SubmitDate = DateTime.Parse(Date);
                Info.ActualAmount = 0;
                Info.BelongingDepID = 297;
                Info.PayPerson = PayPerson;
                Info.IsEnabled = false;
                Info.Creator = HozestERPContext.Current.User.CustomerID;
                Info.CreateDate = DateTime.Now;
                Info.Updater = HozestERPContext.Current.User.CustomerID;
                Info.UpdateDate = DateTime.Now;
                base.XMBusinessDataService.InsertXMBusinessData(Info);
                Response.Redirect(CommonHelper.GetStoreLocation() + "ManageBusiness/BusinessDataB2BDetail.aspx?ID=" + Info.ID + "&Type=1");
            }
            else
            {
                var ContractNumberExist = base.XMBusinessDataService.GetXMBusinessDataDetailListByContractNumber(ContractNumber, Id);
                if (ContractNumberExist != null && ContractNumberExist.Count > 0)
                {
                    base.ShowMessage("该合同编号已存在！");
                    return;
                }
                XMBusinessData Info = base.XMBusinessDataService.GetXMBusinessDataByID(Id);
                var list = base.XMBusinessDataDetailService.GetXMBusinessDataDetailListByBusinessDataID(Id);
                if (list != null & list.Count > 0)
                {
                    foreach (XMBusinessDataDetail one in list)
                    {
                        if (IsFinancialStatus((int)one.AmountType) == 2 && (bool)one.FinancialStatus)//为收款，且已审核
                        {
                            base.ShowMessage("财务已审核，不能修改！");
                            return;
                        }
                    }
                }
                Info.ContractNumber = ContractNumber;
                Info.ContractAmount = decimal.Parse(ContractAmount);
                Info.ClientCompany = ClientCompany;
                Info.SubmitLimit = SubmitLimit;
                Info.PayPerson = PayPerson;
                Info.SubmitDate = DateTime.Parse(Date);
                Info.Updater = HozestERPContext.Current.User.CustomerID;
                Info.UpdateDate = DateTime.Now;
                base.XMBusinessDataService.UpdateXMBusinessData(Info);
            }
            base.ShowMessage("保存成功！");
            BindGrid();
        }

        public void loadDate()
        {
            this.btnSpendingAuthority.Visible = false;
            this.Face_Init();
            if (Id != 0 && Type == 0)
            {
                this.btnSave.Visible = false;
                this.btnContractNumber.Visible = false;
                this.grdvClients.Columns[12].Visible = false;//操作列屏蔽
            }
            if (Id != 0)
            {
                BindGrid();
            }
            if (Id == 0 && Type == 0)
            {
                this.txtDepartmentName.Text = "B2B事业部";
                this.txtActualAmount.Text = "0.00";
            }
        }

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 审核
            if (e.CommandName.Equals("Audit"))
            {
                var Info = base.XMBusinessDataDetailService.GetXMBusinessDataDetailByID(int.Parse(e.CommandArgument.ToString()));
                if (Info != null)
                {
                    if ((bool)Info.FinancialStatus)
                    {
                        base.ShowMessage("财务已审核！");
                    }
                    else
                    {
                        Info.FinancialStatus = true;
                        Info.AuditPerson = HozestERPContext.Current.User.CustomerID;
                        Info.AuditDate = DateTime.Now;
                        //Info.Updater = HozestERPContext.Current.User.CustomerID;
                        //Info.UpdateDate = DateTime.Now;
                        base.XMBusinessDataDetailService.UpdateXMBusinessDataDetail(Info);

                        var data = base.XMBusinessDataService.GetXMBusinessDataByID((int)Info.BusinessDataID);
                        if (data != null)
                        {
                            if (IsFinancialStatus((int)Info.AmountType) == 2)//收款
                            {
                                data.ActualAmount = data.ActualAmount + Info.Amount;
                                data.Updater = HozestERPContext.Current.User.CustomerID;
                                data.UpdateDate = DateTime.Now;
                                base.XMBusinessDataService.UpdateXMBusinessData(data);
                            }
                        }

                        base.ShowMessage("审核成功！");
                        BindGrid();
                    }
                }
                else
                {
                    base.ShowMessage("该数据不存在！");
                }
            }
            #endregion

            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var Info = base.XMBusinessDataDetailService.GetXMBusinessDataDetailByID(int.Parse(e.CommandArgument.ToString()));
                if (Info != null)
                {
                    Info.IsEnabled = true;
                    Info.Updater = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDate = DateTime.Now;
                    base.XMBusinessDataDetailService.UpdateXMBusinessDataDetail(Info);
                    base.ShowMessage("删除成功！");
                    BindGrid();
                }
                else
                {
                    base.ShowMessage("该数据不存在！");
                }
            }
            #endregion
        }

        public void BindGrid(bool IsEdit = true)
        {
            List<XMBusinessDataDetail> List = new List<XMBusinessDataDetail>();
            XMBusinessData Info = base.XMBusinessDataService.GetXMBusinessDataByID(Id);
            this.txtContractNumber.Text = Info.ContractNumber.ToString();
            this.txtContractAmount.Text = Info.ContractAmount.ToString();
            this.txtClientCompany.Text = Info.ClientCompany.ToString();
            this.txtSubmitLimit.Text = Info.SubmitLimit.ToString();
            this.txtSubmitDate.Value = Info.SubmitDate.ToString();
            this.txtActualAmount.Text = Info.ActualAmount.ToString();
            this.txtDepartmentName.Text = Info.DepartmentName.ToString();
            this.txtAuthorName.Text = Info.AuthorName.ToString();
            this.txtPayPerson.Text = Info.PayPerson == null ? "" : Info.PayPerson;
            bool authority = false;

            var list = base.XMBusinessDataDetailService.GetXMBusinessDataDetailListByBusinessDataID(Id);
            //支付查看权限
            var RoleIDList = base.CustomerService.GetRolesByCustomerId(HozestERPContext.Current.User.CustomerID);
            if (RoleIDList != null && RoleIDList.Count > 0)
            {
                foreach (CustomerRole one in RoleIDList)
                {
                    var exist = base.XMBusinessDataDetailService.GetSpendingAuthority(one.CustomerRoleID);
                    if (exist)
                    {
                        authority = true;
                        break;
                    }
                }
            }

            foreach (XMBusinessDataDetail one in list)
            {
                if (!authority)
                {
                    if (IsFinancialStatus((int)one.AmountType) != 1)
                    {
                        List.Add(one);
                    }
                }
                else
                {
                    List.Add(one);
                }
            }

            if (Id != 0 && Type != 0 && IsEdit)//编辑时才会显示
            {
                int no = 0;
                if (List != null && List.Count > 0)
                {
                    no = List.Count;
                }
                this.grdvClients.EditIndex = no;
                List.Insert(no, new XMBusinessDataDetail
                {
                    FinancialStatus = false
                });
            }
            if (List != null && List.Count > 0)
            {
                this.grdvClients.DataSource = List;
                //绑定数据源
                this.grdvClients.DataBind();
            }
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //绑定编辑行DropDownList控件数据
            if (e.Row.RowState == DataControlRowState.Edit ||
                 e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                //金额类型
                DropDownList ddlAmountType = (DropDownList)e.Row.FindControl("ddlAmountType");
                ddlAmountType.Items.Clear();
                var AmountTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(214);
                ddlAmountType.DataSource = AmountTypeList;
                ddlAmountType.DataTextField = "CodeName";
                ddlAmountType.DataValueField = "CodeID";
                ddlAmountType.DataBind();

                //业务类型
                DropDownList ddlBusinessType = (DropDownList)e.Row.FindControl("ddlBusinessType");
                ddlBusinessType.Items.Clear();
                var BusinessTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(215);
                ddlBusinessType.DataSource = BusinessTypeList;
                ddlBusinessType.DataTextField = "CodeName";
                ddlBusinessType.DataValueField = "CodeID";
                ddlBusinessType.DataBind();
            }
        }

        /// <summary>
        /// 编辑行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int ID = 0;
            int.TryParse(this.grdvClients.DataKeys[e.NewEditIndex].Value.ToString(), out ID);
            var Info = base.XMBusinessDataDetailService.GetXMBusinessDataDetailByID(ID);
            if (Info != null)
            {
                if ((bool)Info.FinancialStatus && IsFinancialStatus((int)Info.AmountType) == 2)
                {
                    base.ShowMessage("财务审核过的数据不可修改！");
                    e.Cancel = true;//取消编辑模式
                    return;
                }
                this.grdvClients.EditIndex = e.NewEditIndex;
                BindGrid(false);
                var row = this.grdvClients.Rows[e.NewEditIndex];
                //金额类型
                DropDownList ddlAmountType = (DropDownList)row.FindControl("ddlAmountType");
                ddlAmountType.Items.Clear();
                var AmountTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(214);
                ddlAmountType.DataSource = AmountTypeList;
                ddlAmountType.DataTextField = "CodeName";
                ddlAmountType.DataValueField = "CodeID";
                ddlAmountType.DataBind();

                //业务类型
                DropDownList ddlBusinessType = (DropDownList)row.FindControl("ddlBusinessType");
                ddlBusinessType.Items.Clear();
                var BusinessTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(215);
                ddlBusinessType.DataSource = BusinessTypeList;
                ddlBusinessType.DataTextField = "CodeName";
                ddlBusinessType.DataValueField = "CodeID";
                ddlBusinessType.DataBind();

                ddlAmountType.SelectedValue = Info.AmountType.ToString();
                ddlBusinessType.SelectedValue = Info.BusinessType.ToString();

                TextBox Amount = (TextBox)row.FindControl("txtAmount");
                TextBox DomainName = (TextBox)row.FindControl("txtDomainName");
                TextBox Remark1 = (TextBox)row.FindControl("txtRemark1");
                TextBox Remark2 = (TextBox)row.FindControl("txtRemark2");
                //HtmlInputText ServiceBeginDate = (HtmlInputText)row.FindControl("txtServiceBeginDate");
                //HtmlInputText ServiceEndDate = (HtmlInputText)row.FindControl("txtServiceEndDate");
                TextBox BelongingName = (TextBox)row.FindControl("txtBelongingName");
                Amount.Text = Info.Amount.ToString();
                DomainName.Text = Info.DomainName.ToString();
                Remark1.Text = Info.Remark1.ToString();
                Remark2.Text = Info.Remark2.ToString();
                //ServiceBeginDate.Value = Info.ServiceBeginDate.ToString();
                //ServiceEndDate.Value = Info.ServiceEndDate.ToString();
                BelongingName.Text = Info.BelongingName.ToString();
            }

        }

        /// <summary>
        /// 更新行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int ID = 0;
            int.TryParse(this.grdvClients.DataKeys[e.RowIndex].Value.ToString(), out ID);
            var row = this.grdvClients.Rows[e.RowIndex];
            var AmountType = row.FindControl("ddlAmountType") as DropDownList;
            var Amount = row.FindControl("txtAmount") as TextBox;
            var DomainName = row.FindControl("txtDomainName") as TextBox;
            var BusinessType = row.FindControl("ddlBusinessType") as DropDownList;
            var Remark1 = row.FindControl("txtRemark1") as TextBox;
            var Remark2 = row.FindControl("txtRemark2") as TextBox;
            //var ServiceBeginDate = row.FindControl("txtServiceBeginDate") as HtmlInputText;
            //var ServiceEndDate = row.FindControl("txtServiceEndDate") as HtmlInputText;
            var BelongingName = row.FindControl("txtBelongingName") as TextBox;
            DateTime a = DateTime.Now;
            decimal b = 0;
            //if (!string.IsNullOrEmpty(ServiceBeginDate.Value.Trim()) || !string.IsNullOrEmpty(ServiceEndDate.Value.Trim()))
            //{
            //    if (!DateTime.TryParse(ServiceBeginDate.Value.Trim(), out a) || !DateTime.TryParse(ServiceEndDate.Value.Trim(), out a))
            //    {
            //        base.ShowMessage("服务时间格式不正确！");
            //        return;
            //    }
            //}

            //var data = base.XMBusinessDataService.GetXMBusinessDataByID(Id);
            //data.Updater = HozestERPContext.Current.User.CustomerID;
            //data.UpdateDate = DateTime.Now;

            if (decimal.TryParse(Amount.Text.Trim(), out b) == false)
            {
                base.ShowMessage("金额格式错误！");
                return;
            }

            if (string.IsNullOrEmpty(BelongingName.Text.Trim()))
            {
                base.ShowMessage("归属人不能为空！");
                return;
            }

            XMBusinessDataDetail Info = new XMBusinessDataDetail();
            if (ID == 0)
            {
                Info.BusinessDataID = Id;
                Info.AmountType = int.Parse(AmountType.SelectedValue);
                Info.Amount = decimal.Parse(Amount.Text == "" ? "0" : Amount.Text.Trim());
                Info.DomainName = DomainName.Text.Trim();
                Info.BusinessType = int.Parse(BusinessType.SelectedValue);
                Info.Remark1 = Remark1.Text.Trim();
                Info.Remark2 = Remark2.Text.Trim();
                Info.BelongingName = BelongingName.Text.Trim().Replace("，", ",");
                if (IsFinancialStatus((int)Info.AmountType) == 2)
                {
                    Info.FinancialStatus = false;
                    //更新BusinessData表数据
                    //data.ActualAmount = data.ActualAmount + Info.Amount;
                }
                else
                {
                    Info.FinancialStatus = true;
                }
                //if (!string.IsNullOrEmpty(ServiceBeginDate.Value.Trim()))
                //{
                //    Info.ServiceBeginDate = DateTime.Parse(ServiceBeginDate.Value.Trim());
                //}
                //if (!string.IsNullOrEmpty(ServiceEndDate.Value.Trim()))
                //{
                //    Info.ServiceEndDate = DateTime.Parse(ServiceEndDate.Value.Trim());
                //}
                Info.IsEnabled = false;
                Info.Creator = HozestERPContext.Current.User.CustomerID;
                Info.CreateDate = DateTime.Now;
                Info.Updater = HozestERPContext.Current.User.CustomerID;
                Info.UpdateDate = DateTime.Now;
                base.XMBusinessDataDetailService.InsertXMBusinessDataDetail(Info);
            }
            else
            {
                Info = base.XMBusinessDataDetailService.GetXMBusinessDataDetailByID(ID);

                //int amountType = (int)Info.AmountType;
                //decimal amount = (decimal)Info.Amount;
                Info.AmountType = int.Parse(AmountType.SelectedValue);
                Info.Amount = decimal.Parse(Amount.Text == "" ? "0" : Amount.Text.Trim());
                Info.DomainName = DomainName.Text.Trim();
                Info.BusinessType = int.Parse(BusinessType.SelectedValue);
                Info.Remark1 = Remark1.Text.Trim();
                Info.Remark2 = Remark2.Text.Trim();
                //if (!string.IsNullOrEmpty(ServiceBeginDate.Value.Trim()))
                //{
                //    Info.ServiceBeginDate = DateTime.Parse(ServiceBeginDate.Value.Trim());
                //}
                //if (!string.IsNullOrEmpty(ServiceEndDate.Value.Trim()))
                //{
                //    Info.ServiceEndDate = DateTime.Parse(ServiceEndDate.Value.Trim());
                //}
                if (IsFinancialStatus((int)Info.AmountType) == 2)//付款
                {
                    //if (IsFinancialStatus(amountType) == 2)
                    //{
                    //    data.ActualAmount = data.ActualAmount - amount + Info.Amount;
                    //}
                    //else
                    //{
                    //    data.ActualAmount = data.ActualAmount + Info.Amount;
                    //}
                    Info.FinancialStatus = false;
                }
                else
                {
                    //if (IsFinancialStatus(amountType) == 2)
                    //{
                    //    data.ActualAmount = data.ActualAmount - amount;
                    //}
                    Info.FinancialStatus = true;
                }
                Info.BelongingName = BelongingName.Text.Trim().Replace("，", ",");
                Info.Updater = HozestERPContext.Current.User.CustomerID;
                Info.UpdateDate = DateTime.Now;
                base.XMBusinessDataDetailService.UpdateXMBusinessDataDetail(Info);
            }

            //base.XMBusinessDataService.UpdateXMBusinessData(data);
            base.ShowMessage("保存成功！");
            this.grdvClients.EditIndex = -1;
            BindGrid();
        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.grdvClients.EditIndex = -1;
            BindGrid();
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
                return CommonHelper.QueryStringInt("Type");
            }
        }

        public int IsFinancialStatus(int AmountType)
        {
            var list = base.CodeService.GetCodeListInfoByCodeTypeID(214);
            if (list != null && list.Count > 0)
            {
                foreach (CodeList info in list)
                {
                    if (info.CodeID == AmountType)
                    {
                        return info.DisplayOrder;
                    }
                }
            }
            return 0;
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }
    }
}