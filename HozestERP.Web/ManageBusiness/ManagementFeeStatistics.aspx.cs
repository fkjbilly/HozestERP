using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Enterprises;

namespace HozestERP.Web.ManageBusiness
{
    public partial class ManagementFeeStatistics : BaseAdministrationPage, ISearchPage
    {
        public string TableList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDepartmentType_SelectedIndexChanged(sender, e);
                Total("year");
            }
        }

        public void Total(string DateType)
        {
            StringBuilder str = new StringBuilder();
            string begin = "";
            string end = "";
            int Department = int.Parse(this.ddlDepartmentType.SelectedValue);
            int ProjectID = int.Parse(this.ddlProject.SelectedValue);

            str.Append("<tr><th align='center' style='height:7%;'></th><th align='center' style='height:8%;'>1月</th><th align='center' style='height:8%;'>2月</th>"
                + "<th align='center' style='height:8%;'>3月</th><th align='center' style='height:8%;'>4月</th><th align='center' style='height:8%;'>5月</th>"
                + "<th align='center' style='height:8%;'>6月</th><th align='center' style='height:8%;'>7月</th><th align='center' style='height:8%;'>8月</th>"
                + "<th align='center' style='height:8%;'>9月</th><th align='center' style='height:7%;'>10月</th><th align='center' style='height:7%;'>11月</th>"
                + "<th align='center' style='height:7%;'>12月</th></tr>");

            var RowsList = base.BudgetSettingService.GetBudgetSettingListByData("", 1);//预算科目为管理费用的项

            if (DateType == "year")
            {
                begin = this.ddlYear.SelectedValue + "-01-01";
                end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            }
            else
            {
                begin = this.ddlYear.SelectedValue + "-01-01";
                end = (int.Parse(this.ddlYear.SelectedValue) + 1).ToString() + "-01-01";
            }

            foreach (BudgetSetting Info in RowsList)
            {
                var BudgetSettingList = base.XMFinancialCapitalFlowService.GetListByDataToTable(begin, end, Department, ProjectID, Info.ID);
                if (BudgetSettingList.Count > 0)
                {
                    str.Append("<tr><td align='center'>" + Info.Name + "</td>");
                    for (int i = 1; i <= 12; i++)
                    {
                        DateTime Begin = DateTime.Parse(DateTime.Parse(begin).Year.ToString() + "-" + i + "-01");
                        DateTime End = DateTime.Now;
                        if (i == 12)
                        {
                            End = DateTime.Parse((DateTime.Parse(begin).Year + 1).ToString() + "-01-01");
                        }
                        else
                        {
                            End = DateTime.Parse(DateTime.Parse(begin).Year.ToString() + "-" + (i + 1) + "-01");
                        }
                        decimal? total = BudgetSettingList.Where(q => q.Date >= Begin).Where(q => q.Date < End).Sum(x => x.Amount);
                        str.Append("<td align='center'>" + total + "</td>");
                    }
                    str.Append("</tr>");
                }
            }
            TableList = str.ToString();
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDepartmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string DepartmentType = this.ddlDepartmentType.SelectedValue;
            List<XMProject> List = new List<XMProject>();
            List<XMProject> ProjectList = new List<XMProject>();
            List<Department> DepartmentList = new List<Department>();
            if (DepartmentType == "-1")
            {
                DepartmentList = base.EnterpriseService.GetDepartmentAll();
            }
            else
            {
                DepartmentList = base.EnterpriseService.GetDepartmentListByDepType(int.Parse(DepartmentType));
            }
            if (DepartmentList.Count > 0)
            {
                foreach (Department info in DepartmentList)
                {
                    var list = base.XMProjectService.GetXMProjectListByDepID(info.DepartmentID);
                    if (list.Count > 0)
                    {
                        ProjectList.AddRange(list);
                    }
                }
            }

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 508)
            {
                var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362).ToList();
                foreach (XMProject Info in ProjectList)
                {
                    foreach (XMProject info in projectList)
                    {
                        if (Info.Id == info.Id)
                        {
                            List.Add(Info);
                        }
                    }
                }
            }
            else
            {
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                foreach (XMProject Info in ProjectList)
                {
                    foreach (var info in projectList)
                    {
                        if (Info.Id == info.Id)
                        {
                            List.Add(Info);
                        }
                    }
                }
            }

            this.ddlProject.Items.Clear();
            this.ddlProject.DataSource = List;
            this.ddlProject.DataTextField = "ProjectName";
            this.ddlProject.DataValueField = "Id";
            this.ddlProject.DataBind();
            this.ddlProject.Items.Insert(0, new ListItem("---所有---", "-1"));

            btnSearch_Click(sender, e);
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            this.ddlYear.Items.Clear();
            List<string> list = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                int year = DateTime.Now.Year;
                list.Add((year - i).ToString());
            }
            this.ddlYear.DataSource = list;
            this.ddlYear.DataBind();
            this.ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

            this.ddlDepartmentType.Items.Clear();
            var DepartmentList = base.CodeService.GetCodeListInfoByCodeTypeID(1);
            this.ddlDepartmentType.DataSource = DepartmentList;
            this.ddlDepartmentType.DataTextField = "CodeName";
            this.ddlDepartmentType.DataValueField = "CodeID";
            this.ddlDepartmentType.DataBind();
            this.ddlDepartmentType.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        #endregion

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.ddlYear.SelectedValue == DateTime.Now.Year.ToString())
            {
                Total("year");
            }
            else
            {
                Total("custom_year");
            }

            string DateType = "";
            string Year = this.ddlYear.SelectedValue;
            string Month = this.ddlMonth.SelectedValue;
            if (Month == "-1")
            {
                if (Year == DateTime.Now.Year.ToString())
                {
                    DateType = "year";
                }
                else
                {
                    DateType = "custom_year";
                }
            }
            else
            {
                if (Year == DateTime.Now.Year.ToString() && Month == DateTime.Now.Month.ToString())
                {
                    DateType = "month";
                }
                else
                {
                    DateType = "custom_month";
                }
            }
            ScriptManager.RegisterStartupScript(this.btnSearch, this.Page.GetType(), "btnSearch", "dataBind('" + DateType + "')", true);
        }

        protected void btnWeek_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.btnWeek, this.Page.GetType(), "btnWeek", "dataBind('week')", true);

            this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            this.ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            Total("year");
        }

        protected void btnMonth_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.btnMonth, this.Page.GetType(), "btnMonth", "dataBind('month')", true);

            this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            this.ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            Total("year");
        }

        protected void btnYear_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.btnYear, this.Page.GetType(), "btnYear", "dataBind('year')", true);

            this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            this.ddlMonth.SelectedValue = "-1";
            Total("year");
        }
    }
}