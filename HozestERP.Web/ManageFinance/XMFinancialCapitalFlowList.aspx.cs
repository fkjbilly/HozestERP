using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Common;
using HozestERP.Common.Utils;
using System.Web;
using System.IO;
using System.Web.UI;

namespace HozestERP.Web.ManageFinance
{
    public partial class XMFinancialCapitalFlowList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["RecordAssociatedPersonValue"] = null;
                //ddlBelongingDep_Changed(sender, e);
                if (this.DepartmentID != 0)
                {
                    ddlBelongingCompany.SelectedValue = "3";
                    ddlBelongingCompany_SelectedIndexChanged(null, null);
                }
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员
        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            ddlBelongingCompany.Items.Clear();
            var belongingCompany = EnterpriseService.GetAllEnterprises();
            ddlBelongingCompany.DataSource = belongingCompany;
            ddlBelongingCompany.DataTextField = "EntName";
            ddlBelongingCompany.DataValueField = "EntId";
            ddlBelongingCompany.DataBind();
            ddlBelongingCompany.Items.Insert(0, new ListItem("", "-1"));
            //ddlBelongingCompany.Items.Add(new ListItem("合众互联", "0"));

            //CommonMethod.DropDownListDepartment(this.ddlBelongingDep, true);
            //this.ddlBelongingDep.Items.Clear();
            //var BelongingDepList = base.CodeService.GetCodeListInfoByCodeTypeID(1);
            //this.ddlBelongingDep.DataSource = BelongingDepList;
            //this.ddlBelongingDep.DataTextField = "CodeName";
            //this.ddlBelongingDep.DataValueField = "CodeID";
            //this.ddlBelongingDep.DataBind();
            this.ddlBelongingDep.Items.Insert(0, new ListItem("", "-1"));

            this.ddlPaymentCollectionType.Items.Clear();
            var PaymentCollectionTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(223);
            this.ddlPaymentCollectionType.DataSource = PaymentCollectionTypeList;
            this.ddlPaymentCollectionType.DataTextField = "CodeName";
            this.ddlPaymentCollectionType.DataValueField = "CodeID";
            this.ddlPaymentCollectionType.DataBind();
            this.ddlPaymentCollectionType.Items.Insert(0, new ListItem("", "-1"));

            this.ddlBelongingProject.Items.Clear();
            var list = base.XMProjectService.GetXMProjectList();
            if (list != null && list.Count > 0)
            {
                this.ddlBelongingProject.DataSource = list;
                this.ddlBelongingProject.DataTextField = "ProjectName";
                this.ddlBelongingProject.DataValueField = "Id";
                this.ddlBelongingProject.DataBind();
            }
            this.ddlBelongingProject.Items.Insert(0, new ListItem("", "-1"));

            //收款类别绑定
            var ReceivablesTypes = base.CodeService.GetCodeListInfoByCodeTypeID(224);
            this.ddlReceivablesType.DataSource = ReceivablesTypes;
            this.ddlReceivablesType.DataTextField = "CodeName";
            this.ddlReceivablesType.DataValueField = "CodeID";
            this.ddlReceivablesType.DataBind();
            this.ddlReceivablesType.Items.Insert(0, new ListItem("", "-1"));

            var BudgetTypes = XMFinancialFieldService.GetXMFinancialFieldByParentID(70);
            this.ddlBudgetType.DataSource = BudgetTypes;
            this.ddlBudgetType.DataTextField = "FieldName";
            this.ddlBudgetType.DataValueField = "Id";
            this.ddlBudgetType.DataBind();
            this.ddlBudgetType.Items.Insert(0, new ListItem("", "-1"));

            #region 注释-交款人绑定

            ////开始日期
            //string Begin = this.txtBeginDate.Value.Trim();
            ////结束日期
            //string End = this.txtEndDate.Value.Trim();

            //var List = base.XMFinancialCapitalFlowService.GetXMFinancialCapitalFlowListByDate(Begin, End);
            //this.ddlAssociatedPerson.Items.Clear();
            //this.ddlAssociatedPerson.DataSource = List.Distinct(new Compare<XMFinancialCapitalFlow>((x, y) => x.AssociatedPerson == y.AssociatedPerson));//去重规则
            //this.ddlAssociatedPerson.DataTextField = "AssociatedPerson";
            //this.ddlAssociatedPerson.DataValueField = "AssociatedPerson";
            //this.ddlAssociatedPerson.DataBind();
            //this.ddlAssociatedPerson.Items.Insert(0, new ListItem("---所有---", "-1"));

            #endregion

            this.btnAdd.OnClientClick = "return ShowWindowDetail('资金流水添加','" + CommonHelper.GetStoreLocation()
           + "ManageFinance/XMFinancialCapitalFlowAdd.aspx?Id=-1',800, 390, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";

            //认领交款人/报销人
            this.btnPaymentPerson.OnClientClick = "return ShowWindowDetail('认领交款人/报销人','" + CommonHelper.GetStoreLocation()
           + "ManageBusiness/XMClaimPaymentPerson.aspx',300, 160, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";
        }
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //公司
            int companyID = int.Parse(ddlBelongingCompany.SelectedValue);
            //项目
            int ProjectID = Convert.ToInt32(this.ddlBelongingProject.SelectedValue);
            //部门
            int DepartmentID = this.DepartmentID == 0 ? Convert.ToInt32(this.ddlBelongingDep.SelectedValue) : this.DepartmentID;
            if (this.DepartmentID != 0)
            {
                this.ddlBelongingDep.SelectedValue = this.DepartmentID.ToString();
            }
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            //收入/支出
            int FinancialType = Convert.ToInt32(this.ddlFinancialType.SelectedValue);
            //审核
            int Audit = Convert.ToInt32(this.ddlAudit.SelectedValue);
            //摘要
            string Abstract = this.txtAbstract.Text.Trim();
            //收款支付方式
            int PaymentCollectionType = Convert.ToInt32(this.ddlPaymentCollectionType.SelectedValue);
            //收款类别
            int ReceivablesType = Convert.ToInt32(this.ddlReceivablesType.SelectedValue);
            //对应预算科目
            int BudgetType= Convert.ToInt32(this.ddlBudgetType.SelectedValue);
            //交款人/报销人
            string AssociatedPerson = "-1";//this.ddlAssociatedPerson.SelectedValue.Trim();
            if (Session["RecordAssociatedPersonValue"] != null)
            {
                AssociatedPerson = Session["RecordAssociatedPersonValue"].ToString();
            }

            DateTime date = DateTime.Now;
            if (Begin != "" || End != "")
            {
                if (Begin == "" || End == "" || !DateTime.TryParse(Begin, out date) || !DateTime.TryParse(End, out date))
                {
                    base.ShowMessage("日期格式不正确！");
                    return;
                }
            }
            if (End != "")
            {
                End = DateTime.Parse(End).AddDays(1).ToString("yyyy-MM-dd");
            }

            var list = base.XMFinancialCapitalFlowService.GetListByData(Begin, End, companyID, DepartmentID, ProjectID, FinancialType, Audit, Abstract, PaymentCollectionType, ReceivablesType, BudgetType, AssociatedPerson);

            //分页
            var PageList = new PagedList<XMFinancialCapitalFlow>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, PageList, paramPageSize + 1);
        }
        #endregion

        /// <summary>
        /// 条件查询
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //项目
                    int ProjectID = Convert.ToInt32(this.ddlBelongingProject.SelectedValue);
                    //部门
                    int DepartmentID = this.DepartmentID == 0 ? Convert.ToInt32(this.ddlBelongingDep.SelectedValue) : this.DepartmentID;
                    //开始日期
                    string Begin = this.txtBeginDate.Value.Trim();
                    //结束日期
                    string End = this.txtEndDate.Value.Trim();
                    //收入/支出
                    int FinancialType = Convert.ToInt32(this.ddlFinancialType.SelectedValue);
                    //审核
                    int Audit = Convert.ToInt32(this.ddlAudit.SelectedValue);
                    //摘要
                    string Abstract = this.txtAbstract.Text.Trim();
                    //收款支付方式
                    int PaymentCollectionType = Convert.ToInt32(this.ddlPaymentCollectionType.SelectedValue);

                    DateTime date = DateTime.Now;
                    if (Begin != "" || End != "")
                    {
                        if (Begin == "" || End == "" || !DateTime.TryParse(Begin, out date) || !DateTime.TryParse(End, out date))
                        {
                            base.ShowMessage("日期格式不正确！");
                            return;
                        }
                    }
                    if (End != "")
                    {
                        End = DateTime.Parse(End).AddDays(1).ToString("yyyy-MM-dd");
                    }

                    var list = base.XMFinancialCapitalFlowService.GetListByData(Begin, End, DepartmentID, ProjectID, FinancialType, Audit, Abstract, PaymentCollectionType);

                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\FinancialCapitalFlowExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    base.ExportManager.ExportFinancialCapitalFlowToXls(filePath, list);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMFinancial = e.Row.DataItem as XMFinancialCapitalFlow;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtncliamSalePerson = e.Row.FindControl("imgBtnClaimedSalePerson") as ImageButton;
                if (imgBtnEdit != null)
                {
                    if (xMFinancial.Audit != null && (bool)xMFinancial.Audit)
                    {
                        imgBtnEdit.OnClientClick = "return alert('已审核的数据不可修改！');";
                    }
                    else
                    {
                        imgBtnEdit.OnClientClick = "return ShowWindowDetail('资金流水添加编辑','" + CommonHelper.GetStoreLocation()
                       + "ManageFinance/XMFinancialCapitalFlowAdd.aspx?Id=" + xMFinancial.ID + "&&EditType=Edit" + "',800, 390, this, function(){document.getElementById('"
                       + this.btnRefresh.ClientID + "').click();});";
                    }
                }

                if (imgBtncliamSalePerson != null)
                {
                    if (xMFinancial.Audit != null && (bool)xMFinancial.Audit)
                    {
                        imgBtncliamSalePerson.OnClientClick = "return alert('已审核的数据不可修改！');";
                    }
                    else
                    {
                        imgBtncliamSalePerson.OnClientClick = "return ShowWindowDetail('编辑业务员','" + CommonHelper.GetStoreLocation()
                   + "ManageFinance/XMFinancialCapitalFlowAdd.aspx?Id=" + xMFinancial.ID + "&&EditType=ClaimSalePerson" + "',800, 390, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                    }
                }
            }
        }

        /// <summary>
        /// 删除行数据
        /// </summary>
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("ToDel"))
            {
                var Info = base.XMFinancialCapitalFlowService.GetXMFinancialCapitalFlowByID(Convert.ToInt32(e.CommandArgument));
                if (Info != null)//删除
                {
                    if (Info.Audit != null && (bool)Info.Audit)
                    {
                        base.ShowMessage("已审核的数据不可删除！");
                        return;
                    }
                    Info.IsEnabled = true;
                    Info.Updater = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDate = DateTime.Now;
                    base.XMFinancialCapitalFlowService.UpdateXMFinancialCapitalFlow(Info);

                    //项目
                    int ProjectID = Convert.ToInt32(this.ddlBelongingProject.SelectedValue);
                    //部门
                    int DepartmentID = Convert.ToInt32(this.ddlBelongingDep.SelectedValue);
                    //开始日期
                    string Begin = this.txtBeginDate.Value.Trim();
                    //结束日期
                    string End = this.txtEndDate.Value.Trim();
                    //收入/支出
                    int FinancialType = Convert.ToInt32(this.ddlFinancialType.SelectedValue);
                    //审核
                    int Audit = Convert.ToInt32(this.ddlAudit.SelectedValue);
                    //摘要
                    string Abstract = this.txtAbstract.Text.Trim();
                    //收款支付方式
                    int PaymentCollectionType = Convert.ToInt32(this.ddlPaymentCollectionType.SelectedValue);

                    DateTime date = DateTime.Now;
                    if (Begin != "" || End != "")
                    {
                        if (Begin == "" || End == "" || !DateTime.TryParse(Begin, out date) || !DateTime.TryParse(End, out date))
                        {
                            base.ShowMessage("日期格式不正确！");
                            return;
                        }
                    }
                    if (End != "")
                    {
                        End = DateTime.Parse(End).AddDays(1).ToString("yyyy-MM-dd");
                    }

                    var list = base.XMFinancialCapitalFlowService.GetListByData(Begin, End, DepartmentID, ProjectID, FinancialType, Audit, Abstract, PaymentCollectionType);

                    int rowscount = list.Count();//获取行数;
                    if (rowscount % this.Master.PageSize == 0)
                    {
                        this.BindGrid(this.Master.PageIndex - 1, this.Master.PageSize);
                    }
                    else
                    {
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    }

                    base.ShowMessage("操作成功！");
                }

            }
            #endregion
        }

        //protected void ddlBelongingDep_Changed(Object sender, EventArgs e)
        //{
        //    this.ddlBelongingProject.Items.Clear();
        //    var list = base.XMProjectService.GetXMProjectListByDepID(int.Parse(this.ddlBelongingDep.SelectedValue));
        //    if (list != null && list.Count > 0)
        //    {
        //        this.ddlBelongingProject.DataSource = list;
        //        this.ddlBelongingProject.DataTextField = "ProjectName";
        //        this.ddlBelongingProject.DataValueField = "Id";
        //        this.ddlBelongingProject.DataBind();
        //    }
        //    this.ddlBelongingProject.Items.Insert(0, new ListItem("", "-1"));
        //}


        /// <summary>
        /// 审核
        /// </summary>
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            //保存交款人session 清空
            Session["IDs"] = null;

            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
                return;
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in IDs)
                {
                    var Info = base.XMFinancialCapitalFlowService.GetXMFinancialCapitalFlowByID(item);
                    if (Info != null)
                    {
                        if ((Info.Audit == false || Info.Audit == null) && Info.IsEnabled == false)
                        {
                            Info.Audit = true;
                            Info.Updater = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.XMFinancialCapitalFlowService.UpdateXMFinancialCapitalFlow(Info);
                        }
                        else
                        {
                            base.ShowMessage("审核失败，只有未审核的记录才能审核！");
                            return;
                        }
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("审核成功！");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 反审核
        /// </summary>
        protected void btnNoAudit_Click(object sender, EventArgs e)
        {
            //保存交款人session 清空
            Session["IDs"] = null;

            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
                return;
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in IDs)
                {
                    var Info = base.XMFinancialCapitalFlowService.GetXMFinancialCapitalFlowByID(item);
                    if (Info != null)
                    {
                        if (Info.Audit == true && Info.IsEnabled == false)
                        {
                            Info.Audit = false;
                            Info.Updater = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.XMFinancialCapitalFlowService.UpdateXMFinancialCapitalFlow(Info);
                        }
                        else
                        {
                            base.ShowMessage("反审核失败，只有审核通过的记录才能反审核！");
                            return;
                        }
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("反审核成功！");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            string str = "";
            CheckBox chk = (CheckBox)sender;
            DataControlFieldCell dcf = (DataControlFieldCell)chk.Parent;    //这个对象的父类为cell  
            GridViewRow gr = (GridViewRow)dcf.Parent;                   //cell的父类就是row，这样就得到了该checkbox所在的该行  
            //另外一种NamingContainer获得 GridViewRow  
            HiddenField hidd = gr.FindControl("InfoID") as HiddenField;
            foreach (GridViewRow list in this.grdvClients.Rows)
            {
                CheckBox ck = list.FindControl("chkSelected") as CheckBox;
                HiddenField hiddID = list.FindControl("InfoID") as HiddenField;
                if (ck != null && ck.Checked)
                {
                    if (str == "")
                    {
                        str = hiddID.Value;
                    }
                    else
                    {
                        str = str + "," + hiddID.Value;
                    }
                }
            }
            Session["IDs"] = str;
        }

        protected void ddlBelongingCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            string enterpriseID = ddlBelongingCompany.SelectedValue;
            if(enterpriseID!="-1")
            {
                var departmentList = EnterpriseService.GetDepartmentByParentID(int.Parse(enterpriseID), 0);
                ddlBelongingDep.Items.Clear();
                ddlBelongingDep.DataSource = departmentList;
                ddlBelongingDep.DataTextField = "DepName";
                ddlBelongingDep.DataValueField = "DepartmentID";
                ddlBelongingDep.DataBind();
                ddlBelongingDep.Items.Insert(0, new ListItem("", "-1"));
                if (enterpriseID=="3")
                {
                    ddlBelongingDep.Items.Add(new ListItem("家居事业部", "505"));
                    ddlBelongingDep.Items.Add(new ListItem("综管部", "507"));
                    ddlBelongingDep.Items.Add(new ListItem("唯家居", "707"));
                }
            }
            else
            {
                ddlBelongingDep.Items.Clear();
                ddlBelongingDep.Items.Insert(0, new ListItem("", "-1"));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int DepartmentID
        {
            get
            {
                return CommonHelper.QueryStringInt("DepartmentID");
            }
        }


    }
}