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
using System.Text;

namespace HozestERP.Web.ManageBusiness
{
    public partial class XMBusinessDataB2BServiceType : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(1, Master.PageSize);
            }
        }

        /// <summary>
        /// grid 数据绑定
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
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

            if (list != null && list.Count > 0)
            {
                if (FinancialType == 1)                //收入
                {

                    var List2 = from l in list
                                group l by new { l.ReceivablesType } into g
                                select new
                                {
                                    ReceivablesType = g.Key.ReceivablesType,
                                    Amount = g.Sum(a => a.Amount)
                                };

                    if (List2 != null && List2.Count() > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        string str = "";
                        sb.Append("[");
                        foreach (var parm in List2)
                        {
                            var codes = base.CodeService.GetCodeListInfoByCodeID(parm.ReceivablesType.Value);
                            if (codes != null)
                            {
                                if (str == "")
                                {
                                    str = "['" + codes.CodeName + "'," + parm.Amount.ToString() + "],";
                                }
                                else
                                {
                                    str += "['" + codes.CodeName + "'," + parm.Amount.ToString() + "],";
                                }
                            }
                        }
                        if (str != "" && str.Length > 0)
                        {
                            str = str.Substring(0, str.Length - 1);
                            sb.Append(str);
                        }
                        sb.Append("]");
                        hiddContent.Value = sb.ToString();    //将值给Hidden
                    }
                    else
                    {
                        hiddContent.Value = "[]";
                    }
                }
                else
                {
                    var List2 = from l in list
                                group l by new { l.BudgetType } into g
                                select new
                                {
                                    BudgetType = g.Key.BudgetType,
                                    Amount = g.Sum(a => a.Amount)
                                };
                    if (List2 != null && List2.Count() > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        string str = "";
                        sb.Append("[");
                        foreach (var parm in List2)
                        {
                            var FinancialField = base.XMFinancialFieldService.GetBudgetSettingByID(parm.BudgetType.Value);
                            if (FinancialField != null)
                            {
                                if (str == "")
                                {
                                    str = "['" + FinancialField.FieldName + "'," + parm.Amount.ToString() + "],";
                                }
                                else
                                {
                                    str += "['" + FinancialField.FieldName + "'," + parm.Amount.ToString() + "],";
                                }
                            }
                        }
                        if (str != "" && str.Length > 0)
                        {
                            str = str.Substring(0, str.Length - 1);
                            sb.Append(str);
                        }
                        sb.Append("]");
                        hiddContent.Value = sb.ToString();    //将值给Hidden
                    }
                    else
                    {
                        hiddContent.Value = "[]";
                    }
                }
            }
        }

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

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            this.ddlBelongingDep.Items.Clear();
            var BelongingDepList = base.CodeService.GetCodeListInfoByCodeTypeID(1);
            this.ddlBelongingDep.DataSource = BelongingDepList;
            this.ddlBelongingDep.DataTextField = "CodeName";
            this.ddlBelongingDep.DataValueField = "CodeID";
            this.ddlBelongingDep.DataBind();
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
        }

        #endregion

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