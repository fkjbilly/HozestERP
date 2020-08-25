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
using System.Data;
using System.Web.UI;

namespace HozestERP.Web.ManageBusiness
{
    public partial class XMBusinessDataSalePerson : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hititle.Value = "B2B数据分析-业务员";
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

                var List2 = from l in list
                            group l by new { l.AssociatedPerson } into g
                            select new
                            {
                                AssociatedPerson = g.Key.AssociatedPerson,
                                Amount = g.Sum(a => a.Amount)
                            };
                grdvClients.DataSource = List2.ToList();
                grdvClients.DataBind();


                //获得数据 把数据拼写成相应的json数据
                if (List2 != null && List2.Count() > 0)
                {
                    //将table中的数据遍历到图形里面（拼接为它所要求的格式）
                    StringBuilder sbData = new StringBuilder();
                    string str = "";
                    sbData.Append("[");
                    foreach (var parm in List2)
                    {
                        string str2 = "未认领";
                        if (str == "")
                        {
                            if (parm.AssociatedPerson == null || parm.AssociatedPerson == "")
                            {
                                str = "{name:'" + str2 + "',data:[" + parm.Amount.ToString() + "]},";
                            }
                            else
                            {
                                str = "{name:'" + parm.AssociatedPerson + "',data:[" + parm.Amount.ToString() + "]},";
                            }
                        }
                        else
                        {
                            if (parm.AssociatedPerson == null || parm.AssociatedPerson == "")
                            {
                                str += "{name:'" + str2 + "',data:[" + parm.Amount.ToString() + "]},";
                            }
                            else
                            {
                                str += "{name:'" + parm.AssociatedPerson + "',data:[" + parm.Amount.ToString() + "]},";
                            }
                        }
                    }
                    if (str != "" && str.Length > 0)
                    {
                        str = str.Substring(0, str.Length - 1);
                        sbData.Append(str);
                    }
                    sbData.Append("]");
                    hiddcontent.Value = sbData.ToString();    //将值给Hidden
                }
                else
                {
                    hiddcontent.Value = "[]";
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
        private decimal SumAmount = 0;     //业务金额总和

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal amount = DataBinder.Eval(e.Row.DataItem, "Amount").ToString() == "" ? 0 : decimal.Parse(DataBinder.Eval(e.Row.DataItem, "Amount").ToString());
                SumAmount += amount;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                Literal ltSumAmount = e.Row.Cells[1].FindControl("lblSumAmount") as Literal;
                ltSumAmount.Text = SumAmount.ToString();
            }
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