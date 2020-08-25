using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Common.Utils;
using HozestERP.Web.Modules;

namespace HozestERP.Web.ManageFinance
{
    public partial class XMFinancialCapitalFlowAdd : BaseAdministrationPage, IEditPage
    {
        public string ReceivablesValue = "";
        public string BudgetValue = "";
        public string FinancialValue = "";
        public List<List<int>> MatchingList = new List<List<int>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.EditType != "" && this.EditType == "ClaimSalePerson")
                {
                    initControl();
                }
                loadDate();
                if (Id != -1)
                {
                    var Info = base.XMFinancialCapitalFlowService.GetXMFinancialCapitalFlowByID(Id);
                    if (Info != null)
                    {
                        this.txtDate.Value = ((DateTime)Info.Date).ToString("yyyy-MM-dd");
                        this.txtPerson.Text = Info.AssociatedPerson;
                        var department = EnterpriseService.GetDepartmentById((int)Info.DepartmentID);
                        if(department == null)
                        {
                            ddlBelongingCompany.SelectedValue = "0";
                        }
                        else
                        {
                            ddlBelongingCompany.SelectedValue = department.EnterpriseID.ToString();
                        }
                        ddlBelongingCompany_SelectedIndexChanged(sender, e);
                        this.ddlBelongingDep.SelectedValue = Info.DepartmentID.ToString();
                        ddlBelongingDep_SelectedIndexChanged(sender, e);
                        if (Info.BelongingProjectID != null)
                        {
                            this.ddlBelongingProject.SelectedValue = Info.BelongingProjectID.ToString();
                        }
                        this.ddlPaymentCollectionType.SelectedValue = Info.PaymentCollectionType.ToString();
                        this.txtAmount.Text = Info.Amount.ToString();
                        ReceivablesValue = GetCodeName(Info.ReceivablesType.ToString(), 224);
                        BudgetValue = GetBudgetSettingName(Info.BudgetType.ToString());
                        FinancialValue = Info.IsIncome == true ? "1" : "0";
                        this.txtAbstract.Text = Info.Abstract.ToString();
                        this.txtRemark.Text = Info.Remark.ToString();
                    }
                }
            }
        }

        private void initControl()
        {
            txtDate.Disabled = true;
            txtAbstract.Enabled = false;
            ddlBelongingDep.Enabled = false;
            ddlBelongingProject.Enabled = false;
            ddlPaymentCollectionType.Enabled = false;
            txtAmount.Enabled = false;
            txtRemark.Enabled = false;
        }

        protected void Page_init(object sender, EventArgs e)
        {
            hiddEditType.Value = this.EditType;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Date = this.txtDate.Value.Trim();
            string Person = this.txtPerson.Text.Trim();
            string DepartmentID = this.ddlBelongingDep.SelectedValue;
            string ProjectID = this.ddlBelongingProject.SelectedValue;
            string PaymentCollectionType = this.ddlPaymentCollectionType.SelectedValue;
            string Amount = this.txtAmount.Text.Trim();
            string Abstract = this.txtAbstract.Text.Trim();
            string Remark = this.txtRemark.Text.Trim();

            string FinancialType = Request.Form["ddlFinancialType"];
            ReceivablesValue = Request.Form["txtComboReceivables"];
            BudgetValue = Request.Form["txtComboBudget"];
            FinancialValue = FinancialType;
            string ReceivablesType = GetCodeID(ReceivablesValue, 224);
            string BudgetType = GetBudgetSettingID(BudgetValue);
            DateTime date = DateTime.Now;

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "btnSave", "<script>ReceivablesBudgetBind();</script>");

            if (Date == "")
            {
                base.ShowMessage("日期不能为空!");
                return;
            }
            else if (!DateTime.TryParse(Date, out date))
            {
                base.ShowMessage("日期格式不正确!");
                return;
            }
            else if (Amount == "")
            {
                base.ShowMessage("金额不能为空!");
                return;
            }
            else if (FinancialType == "")
            {
                base.ShowMessage("收入/支出类型不能为空!");
                return;
            }
            else if (Abstract == "")
            {
                base.ShowMessage("摘要不能为空!");
                return;
            }
            else if (FinancialType == "1" && ReceivablesType == "-1")
            {
                base.ShowMessage("请选择正确的收款类别!");
                return;
            }
            else if (FinancialType == "0" && BudgetType == "-1")
            {
                base.ShowMessage("请选择正确的对应预算科目!");
                return;
            }
            else
            {
                if (Id == -1)//添加
                {
                    XMFinancialCapitalFlow info = new XMFinancialCapitalFlow();
                    info.Date = DateTime.Parse(Date);
                    info.AssociatedPerson = Person;
                    info.DepartmentID = int.Parse(DepartmentID);
                    if (ProjectID != "")
                    {
                        info.BelongingProjectID = int.Parse(ProjectID);
                    }
                    info.PaymentCollectionType = int.Parse(PaymentCollectionType);
                    info.Amount = decimal.Parse(Amount);
                    info.IsIncome = FinancialType == "1" ? true : false;
                    info.ReceivablesType = int.Parse(ReceivablesType);
                    info.BudgetType = int.Parse(BudgetType);
                    info.Abstract = Abstract;
                    info.Remark = Remark;
                    info.Audit = false;
                    info.IsEnabled = false;
                    info.Creator = HozestERPContext.Current.User.CustomerID;
                    info.CreateDate = DateTime.Now;
                    info.Updater = HozestERPContext.Current.User.CustomerID;
                    info.UpdateDate = DateTime.Now;
                    base.XMFinancialCapitalFlowService.InsertXMFinancialCapitalFlow(info);
                    base.ShowMessage("保存成功!");
                    EmptyValue();//清空
                }
                else//编辑
                {

                    if (this.EditType != "" && this.EditType == "Edit")                //普通编辑  可以修改所有选项
                    {
                        XMFinancialCapitalFlow info = base.XMFinancialCapitalFlowService.GetXMFinancialCapitalFlowByID(Id);
                        if (info != null)//判断有没有这条数据
                        {
                            info.Date = DateTime.Parse(Date);
                            info.AssociatedPerson = Person;
                            info.DepartmentID = int.Parse(DepartmentID);
                            if (ProjectID != "")
                            {
                                info.BelongingProjectID = int.Parse(ProjectID);
                            }
                            info.PaymentCollectionType = int.Parse(PaymentCollectionType);
                            info.Amount = decimal.Parse(Amount);
                            info.IsIncome = FinancialType == "1" ? true : false;
                            info.ReceivablesType = int.Parse(ReceivablesType);
                            info.BudgetType = int.Parse(BudgetType);
                            info.Abstract = Abstract;
                            info.Remark = Remark;
                            info.Updater = HozestERPContext.Current.User.CustomerID;
                            info.UpdateDate = DateTime.Now;
                            base.XMFinancialCapitalFlowService.UpdateXMFinancialCapitalFlow(info);
                            base.ShowMessage("保存成功!");
                        }
                    }
                    else                                                                                //认领业务员  （只可以更新业务员 其他所有选项无法更新）
                    {
                        XMFinancialCapitalFlow info = base.XMFinancialCapitalFlowService.GetXMFinancialCapitalFlowByID(Id);
                        if (info != null)//判断有没有这条数据
                        {
                            info.AssociatedPerson = Person;
                            info.Updater = HozestERPContext.Current.User.CustomerID;
                            info.UpdateDate = DateTime.Now;
                            base.XMFinancialCapitalFlowService.UpdateXMFinancialCapitalFlow(info);
                            base.ShowMessage("保存成功！");

                        }
                    }
                }

                //审核B2B，B2C部门的单子
                if (FinancialType == "1")//收入
                {
                    if (DepartmentID == "63" || DepartmentID == "297")
                    {
                        AuditB2BorB2C(DepartmentID, Abstract, Amount);
                    }
                }
            }
        }

        public void EmptyValue()
        {
            this.txtDate.Value = "";
            this.txtPerson.Text = "";
            this.txtAbstract.Text = "";
            this.txtAmount.Text = "";

            string FinancialType = "";
            FinancialValue = FinancialType;

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "EmptyValue", "<script>ReceivablesBudgetBind();</script>");
            this.txtRemark.Text = "";
        }

        /// <summary>
        /// 审核
        /// </summary>
        public void AuditB2BorB2C(string DepartmentID, string Abstract, string Amount)
        {
            bool ToOut = false;
            var list = base.XMBusinessDataService.GetXMBusinessDataListByData("", "", "", int.Parse(DepartmentID));
            if (list != null && list.Count > 0)
            {
                foreach (XMBusinessData Info in list)
                {
                    if (Info.BelongingDepID.ToString() == DepartmentID)
                    {
                        if ((!string.IsNullOrEmpty(Info.ClientCompany) && Abstract.Contains(Info.ClientCompany))
                            || (!string.IsNullOrEmpty(Info.PayPerson) && Abstract.Contains(Info.PayPerson)))
                        {
                            var DatailList = base.XMBusinessDataDetailService.GetXMBusinessDataDetailListByBusinessDataIDReceivables(Info.ID);
                            if (DatailList != null && DatailList.Count > 0)
                            {
                                GetMatchingList(DatailList.Count);
                                foreach (List<int> matchingList in MatchingList)
                                {
                                    decimal matchingTotal = 0;
                                    foreach (int matching in matchingList)
                                    {
                                        matchingTotal += (decimal)DatailList[matching].Amount;
                                    }
                                    if (matchingTotal == decimal.Parse(Amount))
                                    {
                                        foreach (int matching in matchingList)
                                        {
                                            DatailList[matching].FinancialStatus = true;
                                            DatailList[matching].Updater = HozestERPContext.Current.User.CustomerID;
                                            DatailList[matching].UpdateDate = DateTime.Now;
                                            base.XMBusinessDataDetailService.UpdateXMBusinessDataDetail(DatailList[matching]);
                                        }
                                        Info.ActualAmount = Info.ActualAmount + decimal.Parse(Amount);
                                        Info.Updater = HozestERPContext.Current.User.CustomerID;
                                        Info.UpdateDate = DateTime.Now;
                                        base.XMBusinessDataService.UpdateXMBusinessData(Info);

                                        ToOut = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (ToOut)
                    {
                        break;
                    }
                }
            }
        }

        public void GetMatchingList(int Count)
        {
            int[] a = new int[Count];
            for (int i = 0; i < Count; i++)
            {
                a[i] = i;
            }
            for (int i = 1; i <= Count; i++)
            {
                int[] b = new int[i];
                Matching(a, Count, i, b, i);
            }
        }

        public void Matching(int[] a, int n, int m, int[] b, int M)
        {
            //a 存放候选数字
            //b 存放选出结果
            //n 总项数
            //m 取出项数
            List<int> list = new List<int>();
            for (int i = n; i >= m; i--)
            {
                b[m - 1] = i - 1;
                if (m > 1)
                    Matching(a, i - 1, m - 1, b, M);
                else
                {
                    for (int j = M - 1; j >= 0; j--)
                    {
                        list.Add(a[b[j]]);
                    }
                    MatchingList.Add(list);
                    list = new List<int>();
                }
            }
        }

        public void loadDate()
        {
            this.Face_Init();
        }

        public string GetCodeID(string CodeName, int CodeTypeID)
        {
            var List = base.CodeService.GetCodeListInfoByCodeTypeID(CodeTypeID);
            if (List.Count > 0)
            {
                foreach (CodeList Info in List)
                {
                    if (Info.CodeName == CodeName)
                    {
                        return Info.CodeID.ToString();
                    }
                }
            }
            return "-1";
        }

        public string GetBudgetSettingID(string Name)
        {
            var List = base.XMFinancialFieldService.GetBudgetSettingListByData(Name);
            if (List.Count > 0)
            {
                foreach (XMFinancialField Info in List)
                {
                    if (Info.FieldName == Name)
                    {
                        return Info.Id.ToString();
                    }
                }
            }
            return "-1";
        }

        public string GetCodeName(string CodeID, int CodeTypeID)
        {
            var List = base.CodeService.GetCodeListInfoByCodeTypeID(CodeTypeID);
            if (List.Count > 0)
            {
                foreach (CodeList Info in List)
                {
                    if (Info.CodeID.ToString() == CodeID)
                    {
                        return Info.CodeName;
                    }
                }
            }
            return "";
        }

        public string GetBudgetSettingName(string ID)
        {
            var Info = base.XMFinancialFieldService.GetBudgetSettingByID(int.Parse(ID));
            if (Info != null)
            {
                return Info.FieldName;
            }
            return "";
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }
        /// <summary>
        /// 编辑类型  （Edit  普通编辑   ClaimSalePerson 编辑认领人）
        /// </summary>
        public string EditType
        {
            get
            {
                return CommonHelper.QueryString("EditType");
            }
        }

        public void Face_Init()
        {
            //CommonMethod.DropDownListDepartment(this.ddlBelongingDep, false);

            this.ddlPaymentCollectionType.Items.Clear();
            var PaymentCollectionTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(223);
            this.ddlPaymentCollectionType.DataSource = PaymentCollectionTypeList;
            this.ddlPaymentCollectionType.DataTextField = "CodeName";
            this.ddlPaymentCollectionType.DataValueField = "CodeID";
            this.ddlPaymentCollectionType.DataBind();

            //this.ddlBelongingDep.Items.Clear();
            //var BelongingDepList = base.CodeService.GetCodeListInfoByCodeTypeID(1);
            //this.ddlBelongingDep.DataSource = BelongingDepList;
            //this.ddlBelongingDep.DataTextField = "CodeName";
            //this.ddlBelongingDep.DataValueField = "CodeID";
            //this.ddlBelongingDep.DataBind();

            ddlBelongingCompany.Items.Clear();
            var belongingCompany= EnterpriseService.GetAllEnterprises();
            ddlBelongingCompany.DataSource = belongingCompany;
            ddlBelongingCompany.DataTextField = "EntName";
            ddlBelongingCompany.DataValueField = "EntId";
            ddlBelongingCompany.DataBind();
            ddlBelongingCompany.Items.Insert(0, new ListItem("", "-1"));
            ddlBelongingCompany.Items.Add(new ListItem("和众互联", "0"));
            #region
            //this.ddlBelongingProject.Items.Clear();
            //var list = base.XMProjectService.GetXMProjectList();
            //if (list != null && list.Count > 0)
            //{
            //    this.ddlBelongingProject.DataSource = list;
            //    this.ddlBelongingProject.DataTextField = "ProjectName";
            //    this.ddlBelongingProject.DataValueField = "Id";
            //    this.ddlBelongingProject.DataBind();
            //}
            //this.ddlBelongingProject.Items.Insert(0, new ListItem("", "-1"));

            //this.ddlReceivablesType.Items.Clear();
            //var ReceivablesTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(224);
            //this.ddlReceivablesType.DataSource = ReceivablesTypeList;
            //this.ddlReceivablesType.DataTextField = "CodeName";
            //this.ddlReceivablesType.DataValueField = "CodeID";
            //this.ddlReceivablesType.DataBind();
            //this.ddlReceivablesType.Items.Insert(0, new ListItem("", "-1"));

            //this.ddlBudgetType.Items.Clear();
            //var BudgetTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(225);
            //this.ddlBudgetType.DataSource = BudgetTypeList;
            //this.ddlBudgetType.DataTextField = "CodeName";
            //this.ddlBudgetType.DataValueField = "CodeID";
            //this.ddlBudgetType.DataBind();
            //this.ddlBudgetType.Items.Insert(0, new ListItem("", "-1"));
            #endregion
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlBelongingDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string depID = this.ddlBelongingDep.SelectedValue;
            List<XMProject> ProjectList = new List<XMProject>();
            //List<Department> DepartmentList = new List<Department>();
            //if (DepartmentType == "-1")
            //{
            //    DepartmentList = base.EnterpriseService.GetDepartmentAll();
            //}
            //else
            //{
            //    DepartmentList = base.EnterpriseService.GetDepartmentListByDepType(int.Parse(DepartmentType));
            //}
            //if (DepartmentList.Count > 0)
            //{
            //    foreach (Department info in DepartmentList)
            //    {
            //        var list = base.XMProjectService.GetXMProjectListByDepID(info.DepartmentID);
            //        if (list.Count > 0)
            //        {
            //            ProjectList.AddRange(list);
            //        }
            //    }
            //}
            if(!string.IsNullOrEmpty(depID))
            {
                ProjectList = XMProjectService.GetXMProjectListByDepID(int.Parse(depID));
                if(ProjectList.Count>0)
                {
                    this.ddlBelongingProject.Items.Clear();
                    this.ddlBelongingProject.DataSource = ProjectList;
                    this.ddlBelongingProject.DataTextField = "ProjectName";
                    this.ddlBelongingProject.DataValueField = "Id";
                    this.ddlBelongingProject.DataBind();
                    this.ddlBelongingProject.Items.Insert(0, new ListItem("", "-1"));
                }
                else
                {
                    var DepartmentList= base.EnterpriseService.GetDepartmentListByDepType(int.Parse(depID));
                    foreach (Department info in DepartmentList)
                    {
                        var list = base.XMProjectService.GetXMProjectListByDepID(info.DepartmentID);
                        if (list.Count > 0)
                        {
                            ProjectList.AddRange(list);
                        }
                    }
                    this.ddlBelongingProject.Items.Clear();
                    this.ddlBelongingProject.DataSource = ProjectList;
                    this.ddlBelongingProject.DataTextField = "ProjectName";
                    this.ddlBelongingProject.DataValueField = "Id";
                    this.ddlBelongingProject.DataBind();
                    this.ddlBelongingProject.Items.Insert(0, new ListItem("", "-1"));
                }


                ReceivablesValue = Request.Form["txtComboReceivables"];
                BudgetValue = Request.Form["txtComboBudget"];
                FinancialValue = Request.Form["ddlFinancialType"];

                ScriptManager.RegisterStartupScript(this.ddlBelongingDep, this.Page.GetType(), "ddlBelongingDep", "Load()", true);//ajax
            }
        }

        
        protected void ddlBelongingCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            string enterpriseID = ddlBelongingCompany.SelectedValue;
            if(enterpriseID=="0")
            {
                this.ddlBelongingDep.Items.Clear();
                var BelongingDepList = base.CodeService.GetCodeListInfoByCodeTypeID(1);
                this.ddlBelongingDep.DataSource = BelongingDepList;
                this.ddlBelongingDep.DataTextField = "CodeName";
                this.ddlBelongingDep.DataValueField = "CodeID";
                this.ddlBelongingDep.DataBind();
                ddlBelongingDep.Items.Insert(0, new ListItem("", "-1"));
            }
            else
            {
                var departmentList = EnterpriseService.GetDepartmentByParentID(int.Parse(enterpriseID), 0);
                ddlBelongingDep.Items.Clear();
                ddlBelongingDep.DataSource = departmentList;
                ddlBelongingDep.DataTextField = "DepName";
                ddlBelongingDep.DataValueField = "DepartmentID";
                ddlBelongingDep.DataBind();
                ddlBelongingDep.Items.Insert(0, new ListItem("", "-1"));
            }
        }

        public void SetTrigger()
        {
            //throw new NotImplementedException();
        }
    }
}