using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Customers;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageBusiness
{
    public partial class CompanyOperation : BaseAdministrationPage, ISearchPage
    {
        public string TableList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                #region 项目名称绑定

                //项目名称绑定--选取自运营项目
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    this.ddlXMProjectNameId.Items.Clear();
                    var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362);

                    this.ddlXMProjectNameId.DataSource = projectList;
                    this.ddlXMProjectNameId.DataTextField = "ProjectName";
                    this.ddlXMProjectNameId.DataValueField = "Id";
                    this.ddlXMProjectNameId.DataBind();
                    //this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    this.ddlXMProjectNameId.Items.Clear();
                    var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362)
                        .GroupBy(p => new { p.Id, p.ProjectName })
                        .Select(p => new
                        {
                            Id = p.Key.Id,
                            ProjectName = p.Key.ProjectName
                        });

                    this.ddlXMProjectNameId.DataSource = projectList;
                    this.ddlXMProjectNameId.DataTextField = "ProjectName";
                    this.ddlXMProjectNameId.DataValueField = "Id";
                    this.ddlXMProjectNameId.DataBind();
                    //this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                this.ddlXMProjectNameId.Items.Add(new ListItem("B2B事业部", "B2B"));
                this.ddlXMProjectNameId.Items.Add(new ListItem("B2C服务部", "B2C"));
                this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
                #endregion

                #region 店铺名称绑定

                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    this.ddlNickList.Items.Clear();
                    var NickList = base.XMNickService.GetXMNickList();
                    var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                    this.ddlNickList.DataSource = newNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    //其他
                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362);

                    if (xMNickList.Count > 0)
                    {
                        this.ddlNickList.Items.Clear();
                        this.ddlNickList.DataSource = xMNickList;
                        this.ddlNickList.DataTextField = "nick";
                        this.ddlNickList.DataValueField = "nick_id";
                        this.ddlNickList.DataBind();
                        this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                    }
                }

                #endregion

                this.ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

                StringBuilder str = Total("year", DateTime.Now.Year.ToString(), false);
                TableList = str.ToString();
            }
        }

        public StringBuilder Total(string DateType, string Year, bool Repeat)
        {
            var list = GetDataTotal(DateType, PageType.ToString(), Repeat);
            if (list != null && list.Count > 0)
            {
                list = list.OrderBy(x => x.Date).ToList();
            }

            StringBuilder str = new StringBuilder();
            str.Append("<tr><th align='center' style='height:7%;'></th><th align='center' style='height:8%;'>1月</th><th align='center' style='height:8%;'>2月</th>"
                + "<th align='center' style='height:8%;'>3月</th><th align='center' style='height:8%;'>4月</th><th align='center' style='height:8%;'>5月</th>"
                + "<th align='center' style='height:8%;'>6月</th><th align='center' style='height:8%;'>7月</th><th align='center' style='height:8%;'>8月</th>"
                + "<th align='center' style='height:8%;'>9月</th><th align='center' style='height:7%;'>10月</th><th align='center' style='height:7%;'>11月</th>"
                + "<th align='center' style='height:7%;'>12月</th></tr>");

            str.Append("<tr><td align='center'>税前利润</td>");
            str.Append(MonthData("SQLRMonthMoney", list, Year));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>毛利</td>");
            str.Append(MonthData("MLMonthMoney", list, Year));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>增值税</td>");
            str.Append(MonthData("ZZSMonthMoney", list, Year));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>营业费用</td>");
            str.Append(MonthData("ManagementFee", list, Year));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>人工成本</td>");
            str.Append(MonthData("ZJRGMonthMoney", list, Year));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>营业成本</td>");
            str.Append(MonthData("YYCBMonthMoney", list, Year));
            str.Append("</tr>");

            str.Append("<tr><td align='center'>营业收入</td>");
            str.Append(MonthData("CountMoneySum1", list, Year));
            str.Append("</tr>");

            return str;
        }

        public StringBuilder MonthData(string Group, List<OperatingCostData> List, string Year)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 1; i < 13; i++)
            {
                bool exist = false;
                foreach (OperatingCostData Info in List)
                {
                    string month = Year + "/" + i.ToString().PadLeft(2, '0');
                    Type type = Info.GetType();
                    System.Reflection.PropertyInfo[] ps = type.GetProperties();
                    foreach (System.Reflection.PropertyInfo property in ps)
                    {
                        if (property.Name == Group && Info.Date == month)
                        {
                            a.Append("<td>" + property.GetValue(Info, null) + "</td>");
                            exist = true;
                            break;
                        }
                    }
                }
                if (!exist)
                {
                    a.Append("<td>0</td>");
                }
            }
            return a;
        }

        private List<OperatingCostData> GetDataTotal(string DateType, string PageType, bool Repeat)
        {
            string Format = "yyyy/MM";
            CompanyTool tool = new CompanyTool();
            string ProjectId = this.ddlXMProjectNameId.SelectedValue;
            string NickId = this.ddlNickList.SelectedValue;

            string Year = this.ddlYear.SelectedValue;
            int Month;
            if (DateType == "year")
            {
                Month = DateTime.Now.Month;
            }
            else
            {
                Month = 12;
            }

            List<OperatingCostData> list = new List<OperatingCostData>();
            string now = DateTime.Now.ToLongDateString();
            for (int i = 1; i <= Month; i++)
            {
                OperatingCostData Item = new OperatingCostData();
                Item.Date = Year + "/" + i.ToString().PadLeft(2, '0');
                list.Add(Item);
            }
            DateTime begin = DateTime.Parse(Year + "/01/01");
            DateTime end;
            if (Year == DateTime.Now.Year.ToString())
            {
                end = DateTime.Parse(now).AddDays(1);
            }
            else
            {
                end = DateTime.Parse((int.Parse(Year) + 1) + "/01/01");
            }

            string mark = "";
            if (Session["Mark"] != null)
            {
                mark = Session["Mark"].ToString();
            }

            if (Repeat)
            {
                tool.GetDayTotal(DateType, PageType, begin, end, list, Format, Year, ProjectId, NickId, "Table");
            }
            else
            {
                if (mark == DateType + "," + ProjectId + "," + NickId)
                {
                    if (Session["HightChartsLineYear"] != null)
                    {
                        list = (List<OperatingCostData>)Session["HightChartsLineYear"];
                    }
                }
                else
                {
                    tool.GetTableDayTotal(DateType, PageType, begin, end, list, Format, Year, ProjectId, NickId);
                    if (Session["HightChartsLine"] != null)
                    {
                        list = (List<OperatingCostData>)Session["HightChartsLine"];
                    }
                }
            }
            return list;
        }

        public int PageType
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Year = this.ddlYear.SelectedValue;
            string Month = this.ddlMonth.SelectedValue;
            string DateType = "";
            string TableDateType = "";
            bool Repeat = false;
            if (Year == DateTime.Now.Year.ToString() && Month == DateTime.Now.Month.ToString())
            {
                DateType = "month";
                TableDateType = "year";
            }
            else if (Year == DateTime.Now.Year.ToString() && Month == "-1")
            {
                DateType = "year";
                TableDateType = "year";
                Repeat = true;
            }
            else if (Month == "-1")
            {
                DateType = "custom_year";
                TableDateType = "custom_year";
                Repeat = true;
            }
            else
            {
                DateType = "custom_month";
                TableDateType = "custom_year";
            }
            ScriptManager.RegisterStartupScript(this.btnSearch, this.Page.GetType(), "btnSearch", "dataBind('" + DateType + "')", true);

            StringBuilder str = Total(TableDateType, Year, Repeat);
            TableList = str.ToString();
        }

        protected void btnWeek_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.btnWeek, this.Page.GetType(), "btnWeek", "dataBind('week')", true);

            this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            this.ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            StringBuilder str = Total("year", DateTime.Now.Year.ToString(), false);
            TableList = str.ToString();
        }

        protected void btnMonth_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.btnMonth, this.Page.GetType(), "btnMonth", "dataBind('month')", true);

            this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            this.ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            StringBuilder str = Total("year", DateTime.Now.Year.ToString(), false);
            TableList = str.ToString();
        }

        protected void btnYear_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.btnYear, this.Page.GetType(), "btnYear", "dataBind('year')", true);

            this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            this.ddlMonth.SelectedValue = "-1";
            StringBuilder str = Total("year", DateTime.Now.Year.ToString(), true);
            TableList = str.ToString();
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlXMProjectNameId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string XMProjectNameId = this.ddlXMProjectNameId.SelectedValue;
            this.ddlNickList.Items.Clear();
            if (XMProjectNameId != "B2B" && XMProjectNameId != "B2C")
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue));
                    //this.ddlNickList.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    this.ddlNickList.DataSource = nickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    //其他
                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), HozestERPContext.Current.User.CustomerID, 362);
                    //this.ddlNickList.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    this.ddlNickList.DataSource = nickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Add(new ListItem("B2B事业部", "B2B"));
                    this.ddlNickList.Items.Add(new ListItem("B2BB2C服务部", "B2C"));
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }
            //if (XMProjectNameId == "B2C")
            //{
            //    List<XMNick> NickList = new List<XMNick>();
            //    var ProjectList = base.XMProjectService.GetXMProjectListByDepID(63);
            //    if (ProjectList.Count > 0)
            //    {
            //        foreach (XMProject project in ProjectList)
            //        {
            //            var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), project.Id);
            //            if (nickList.Count > 0)
            //            {
            //                foreach (XMNick one in nickList)
            //                {
            //                    NickList.Add(one);
            //                }
            //            }
            //        }
            //    }
            //    this.ddlNickList.DataSource = NickList;
            //    this.ddlNickList.DataTextField = "nick";
            //    this.ddlNickList.DataValueField = "nick_id";
            //    this.ddlNickList.DataBind();
            //    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
            //}
            btnSearch_Click(sender, e);
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
        }

        #endregion
    }
}