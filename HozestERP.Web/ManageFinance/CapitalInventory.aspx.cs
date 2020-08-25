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
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    public partial class CapitalInventory : BaseAdministrationPage, ISearchPage
    {
        public string TableStr = "";
        public List<string> ExportList = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSearch_Click(sender, e);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
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

            ddlCompany.Items.Clear();
            var belongingCompany = EnterpriseService.GetAllEnterprises();
            ddlCompany.DataSource = belongingCompany;
            ddlCompany.DataTextField = "EntName";
            ddlCompany.DataValueField = "EntId";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("", "-1"));
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
            string Year = this.ddlYear.SelectedValue;
            string Month = this.ddlMonth.SelectedValue;
            string company = ddlCompany.SelectedValue;
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now;
            DateTime BalanceEnd = DateTime.Now;
            if (Month == "-1")
            {
                begin = DateTime.Parse(Year + "/01/01");
                BalanceEnd = DateTime.Parse(Year + "/01/01");
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
                BalanceEnd = end.AddDays(1).AddMonths(-1);
            }
            end = end.AddDays(1);

            var BalanceList = base.XMFinancialCapitalFlowService.GetListByYearMonth(-1,int.Parse(company), begin, BalanceEnd, true);
            var List = base.XMFinancialCapitalFlowService.GetListByYearMonth(-1, int.Parse(company), begin, end, false);
            var Codelist = base.CodeService.GetCodeListInfoByCodeTypeID(223);

            StringBuilder str = new StringBuilder();
            decimal TotalBalance = 0;
            decimal TotalRevenues = 0;
            decimal TotalPayment = 0;
            decimal LastBalance = 0;
            int no = 1;
            foreach (CodeList Info in Codelist)
            {
                string color = "#F7F7F7";
                if (no % 2 == 0)
                {
                    color = "#FFFFFF";
                }
                no++;
                str.Append("<tr style='background-color:" + color + ";border: 1px solid;'>");
                str.Append("<td align='center' style='border: 1px solid;'><font size='2'><b>" + Info.CodeName + "</b></font></td>");
                ExportList.Add(Info.CodeName);

                decimal balance = (decimal)BalanceList.Where(x => x.PaymentCollectionType == Info.CodeID).Where(x => x.IsIncome == true).Sum(x => x.Amount)
                    - (decimal)BalanceList.Where(x => x.PaymentCollectionType == Info.CodeID).Where(x => x.IsIncome == false).Sum(x => x.Amount);
                decimal revenues = (decimal)List.Where(x => x.PaymentCollectionType == Info.CodeID).Where(x => x.IsIncome == true).Sum(x => x.Amount);
                decimal payment = (decimal)List.Where(x => x.PaymentCollectionType == Info.CodeID).Where(x => x.IsIncome == false).Sum(x => x.Amount);
                TotalBalance += balance;
                TotalRevenues += revenues;
                TotalPayment += payment;
                LastBalance += balance + revenues - payment;

                if (balance != 0)
                {
                    str.Append("<td align='center' style='border: 1px solid;'>" + balance + "</td>");
                }
                else
                {
                    str.Append("<td align='center' style='border: 1px solid;'>-</td>");
                }

                if (revenues != 0)
                {
                    str.Append("<td align='center' style='border: 1px solid;'>" + revenues + "</td>");
                }
                else
                {
                    str.Append("<td align='center' style='border: 1px solid;'>-</td>");
                }

                if (payment != 0)
                {
                    str.Append("<td align='center' style='border: 1px solid;'>" + payment + "</td>");
                }
                else
                {
                    str.Append("<td align='center' style='border: 1px solid;'>-</td>");
                }

                str.Append("<td align='center' style='border: 1px solid;'>" + (balance + revenues - payment).ToString() + "</td></tr>");
                ExportList.Add(balance.ToString());
                ExportList.Add(revenues.ToString());
                ExportList.Add(payment.ToString());
                ExportList.Add((balance + revenues - payment).ToString());
            }
            str.Append("<tr style='background-color:#9F79EE;border: 1px solid;'><td align='center' style='border: 1px solid;'><font size='2'><b>合计</b></font></td>").Append("<td align='center' style='border: 1px solid;'><font size='2'><b>" + TotalBalance + "</b></font></td>").Append("<td align='center' style='border: 1px solid;'><font size='2'><b>"
                + TotalRevenues + "</b></font></td>").Append("<td align='center' style='border: 1px solid;'><font size='2'><b>" + TotalPayment + "</b></font></td>").Append("<td align='center' style='border: 1px solid;'><font size='2'><b>" + LastBalance + "</b></font></td></tr>");
            ExportList.Add("合计");
            ExportList.Add(TotalBalance.ToString());
            ExportList.Add(TotalRevenues.ToString());
            ExportList.Add(TotalPayment.ToString());
            ExportList.Add(LastBalance.ToString());

            TableStr = str.ToString();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    btnSearch_Click(sender, e);
                    string fileName = string.Format("CapitalInventory_{0}{1}.xls", DateTime.Now.ToString("yyMMddHHmmssfff"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\CapitalInventory", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    this.BindGrid(Master.PageIndex, Master.PageSize);
                    base.ExportManager.ExportCapitalInventoryXls(filePath, ExportList);

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