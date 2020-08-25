using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    public partial class ProjectCapitalChanges : BaseAdministrationPage, ISearchPage
    {
        public string TableStr = "";
        public string Title = "";
        public List<string> ExportList=new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTitle();
                btnSearch_Click(sender, e);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void GetTitle()
        {
            string Year = this.ddlYear.SelectedValue;
            string Month = this.ddlMonth.SelectedValue;
            string Project = this.ddlProject.SelectedItem.Text;

            if (Month == "-1")
            {
                Month = "全年";
            }
            else
            {
                Month = Month + "月";
            }

            if (Project == "-1")
            {
                Project = "";
            }

            Title = Year + "年" + Month + Project + "资金变动表";
        }

        public void Face_Init()
        {
            this.ddlYear.Items.Clear();
            List<string> YearList = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                int year = DateTime.Now.Year;
                YearList.Add((year - i).ToString());
            }
            this.ddlYear.DataSource = YearList;
            this.ddlYear.DataBind();
            this.ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

            this.ddlProject.Items.Clear();
            var list = base.XMProjectService.GetXMProjectList();
            if (list != null && list.Count > 0)
            {
                this.ddlProject.DataSource = list;
                this.ddlProject.DataTextField = "ProjectName";
                this.ddlProject.DataValueField = "Id";
                this.ddlProject.DataBind();
            }
            this.ddlProject.Items.Insert(0, new ListItem("--所有--", "-1"));
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
        }
        #endregion

        /// <summary>
        /// 条件查询
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetTitle();
            string Year = this.ddlYear.SelectedValue;
            string Month = this.ddlMonth.SelectedValue;
            string Project = this.ddlProject.SelectedValue;
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now;
            DateTime Begin = DateTime.Parse(Year + "/01/01");
            DateTime End = DateTime.Parse(Year + "/12/31").AddDays(1);

            if (Month == "-1")
            {
                begin = DateTime.Parse(Year + "/01/01");
                if (Year != DateTime.Now.Year.ToString())
                {
                    end = DateTime.Parse(Year + "/12/31");
                }
                else
                {
                    end = DateTime.Parse(Year + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.DaysInMonth(int.Parse(Year), DateTime.Now.Month).ToString());
                }
            }
            else
            {
                begin = DateTime.Parse(Year + "/" + Month + "/01");
                end = DateTime.Parse(Year + "/" + Month + "/" + DateTime.DaysInMonth(int.Parse(Year), int.Parse(Month)).ToString());
            }
            end = end.AddDays(1);

            var List = base.XMFinancialCapitalFlowService.GetListByYearMonth(int.Parse(Project),-1, begin, end, false);
            var YearList = base.XMFinancialCapitalFlowService.GetListByYearMonth(int.Parse(Project),-1, Begin, End, false);
            var Codelist = base.CodeService.GetCodeListInfoByCodeTypeID(224);
            var Budgetlist = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(70);

            StringBuilder str = new StringBuilder();
            int no = 1;
            decimal RevenuesValue = 0;
            decimal RevenuesTotal = 0;
            decimal PayValue = 0;
            decimal PayTotal = 0;

            foreach (CodeList Info in Codelist)
            {
                decimal value = (decimal)List.Where(x => x.ReceivablesType == Info.CodeID).Where(x => x.IsIncome == true).Sum(x => x.Amount);
                decimal total = (decimal)YearList.Where(x => x.ReceivablesType == Info.CodeID).Where(x => x.IsIncome == true).Sum(x => x.Amount);
                if (value == 0 && total == 0)
                {
                    continue;
                }

                string color = "#F7F7F7";
                if (no % 2 == 0)
                {
                    color = "#FFFFFF";
                }
                no++;
                str.Append("<tr style='background-color:" + color + ";border: 1px solid;'>");
                str.Append("<td align='center' style='border: 1px solid;'><font size='2'><b>" + Info.CodeName + "</b></font></td>");
                ExportList.Add(Info.CodeName);

                RevenuesValue += value;
                RevenuesTotal += total;
                str.Append("<td align='center' style='border: 1px solid;'>");
                if (value < 0)
                {
                    str.Append("<font color='red'>" + value + "</font></td>");
                }
                else
                {
                    str.Append(value + "</td>");
                }

                str.Append("<td align='center' style='border: 1px solid;'>");
                if (total < 0)
                {
                    str.Append("<font color='red'>" + total + "</font></td>");
                }
                else
                {
                    str.Append(total + "</td>");
                }
                ExportList.Add(value.ToString());
                ExportList.Add(total.ToString());
            }
            str.Append("<tr style='background-color:#FFFF00;border: 1px solid;height:36px;'>").Append("<td align='center' style='border: 1px solid;'><font size='3' color='blue'><b>经营活动资金流入</b></font></td>");
            ExportList.Add("经营活动资金流入");

            if (RevenuesValue >= 0)
            {
                str.Append("<td align='center' style='border: 1px solid;'><font size='3'>" + RevenuesValue + "</font></td>");
            }
            else
            {
                str.Append("<td align='center' style='border: 1px solid;'><font color='red' size='3'>" + RevenuesValue + "</font></td>");
            }
            if (RevenuesTotal >= 0)
            {
                str.Append("<td align='center' style='border: 1px solid;'><font size='3'>" + RevenuesTotal + "</font></td></tr>");
            }
            else
            {
                str.Append("<td align='center' style='border: 1px solid;'><font color='red' size='3'>" + RevenuesTotal + "</font></td></tr>");
            }
            ExportList.Add(RevenuesValue.ToString());
            ExportList.Add(RevenuesTotal.ToString());

            foreach (XMFinancialField Info in Budgetlist)
            {
                decimal value = (decimal)List.Where(x => x.BudgetType == Info.Id).Where(x => x.IsIncome == false).Sum(x => x.Amount);
                decimal total = (decimal)YearList.Where(x => x.BudgetType == Info.Id).Where(x => x.IsIncome == false).Sum(x => x.Amount);
                if (value == 0 && total == 0)
                {
                    continue;
                }

                string color = "#F7F7F7";
                if (no % 2 == 0)
                {
                    color = "#FFFFFF";
                }
                no++;
                str.Append("<tr style='background-color:" + color + ";border: 1px solid;'>");
                str.Append("<td align='center' style='border: 1px solid;'><font size='2'><b>" + Info.FieldName + "</b></font></td>");
                ExportList.Add(Info.FieldName);

                PayValue += value;
                PayTotal += total;
                str.Append("<td align='center' style='border: 1px solid;'>");
                if (value < 0)
                {
                    str.Append("<font color='red'>" + value + "</font></td>");
                }
                else
                {
                    str.Append(value + "</td>");
                }

                str.Append("<td align='center' style='border: 1px solid;'>");
                if (total < 0)
                {
                    str.Append("<font color='red'>" + total + "</font></td>");
                }
                else
                {
                    str.Append(total + "</td>");
                }
                ExportList.Add(value.ToString());
                ExportList.Add(total.ToString());
            }
            str.Append("<tr style='background-color:#B4EEB4;border: 1px solid;height:36px;'>").Append("<td align='center' style='border: 1px solid;'><font size='3' color='blue'><b>经营活动资金流出</b></font></td>");
            ExportList.Add("经营活动资金流出");

            if (PayValue >= 0)
            {
                str.Append("<td align='center' style='border: 1px solid;'><font size='3'>" + PayValue + "</font></td>");
            }
            else
            {
                str.Append("<td align='center' style='border: 1px solid;'><font color='red' size='3'>" + PayValue + "</font></td>");
            }
            if (PayTotal >= 0)
            {
                str.Append("<td align='center' style='border: 1px solid;'><font size='3'>" + PayTotal + "</font></td></tr>");
            }
            else
            {
                str.Append("<td align='center' style='border: 1px solid;'><font color='red' size='3'>" + PayTotal + "</font></td></tr>");
            }
            ExportList.Add(PayValue.ToString());
            ExportList.Add(PayTotal.ToString());

            //净额
            str.Append("<tr style='background-color:#191970;border: 1px solid;height:36px;'>").Append("<td align='center' style='border: 1px solid;'><font size='3' color='#97FFFF'><b>净额</b></font></td>");
            str.Append("<td align='center' style='border: 1px solid;'><font color='#97FFFF' size='3'><b>" + (RevenuesValue - PayValue).ToString() + "</b></font></td>");
            str.Append("<td align='center' style='border: 1px solid;'><font color='#97FFFF' size='3'><b>" + (RevenuesTotal - PayTotal).ToString() + "</b></font></td></tr>");
            ExportList.Add("净额");
            ExportList.Add((RevenuesValue - PayValue).ToString());
            ExportList.Add((RevenuesTotal - PayTotal).ToString());

            TableStr = str.ToString();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    btnSearch_Click(sender, e);
                    string fileName = string.Format("ProjectCapitalChanges_{0}{1}.xls", DateTime.Now.ToString("yyMMddHHmmssfff"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\ProjectCapitalChanges", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    this.BindGrid(Master.PageIndex, Master.PageSize);
                    base.ExportManager.ExportProjectCapitalChangesXls(filePath, ExportList);

                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }
    }
}