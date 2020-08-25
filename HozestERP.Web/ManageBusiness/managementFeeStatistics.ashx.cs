using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageBusiness
{
    /// <summary>
    /// managementFeeStatistics 的摘要说明
    /// </summary>
    public class managementFeeStatistics : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "managementFeeStatistics": //根据国家 获取省
                    try
                    {
                        List<HighChart> List = new List<HighChart>();
                        List<HighChart> DataList = new List<HighChart>();
                        string DateType = CommonHelper.QueryString("DateType");
                        string Year = CommonHelper.QueryString("Year");
                        string Month = CommonHelper.QueryString("Month");
                        string DepartmentType = CommonHelper.QueryString("DepartmentType");
                        string Project = CommonHelper.QueryString("Project");

                        var list = GetDataTotal(DateType, Year, Month, DepartmentType, Project);
                        if (list.Count > 0)
                        {
                            list = list.OrderBy(x => x.Name).ThenBy(x => x.Group).ToList();
                        }
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(list, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;

            }
        }

        private List<HighChart> GetDataTotal(string DateType, string Year, string Month, string DepartmentType, string Project)
        {
            DateTime begin = new DateTime();
            DateTime end = new DateTime();
            List<string> list = new List<string>();
            List<HighChart> HighChartList = new List<HighChart>();
            string now = DateTime.Now.ToLongDateString();

            string Format = "";
            if ((DateType == "year") || DateType == "custom_year")
            {
                Format = "yyyy/MM";
            }
            else
            {
                Format = "MM/dd";
            }

            if (DateType == "week")
            {
                for (int i = 6; i >= 0; i--)
                {
                    string Item = "";
                    if (DateTime.Now.Day < 7 && DateTime.Now.AddDays(-i).Day > 7)
                    {
                        Item = (DateTime.Now.Month - 1).ToString().PadLeft(2, '0') + "/" + (DateTime.Now.AddDays(-i).Day).ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        Item = DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + (DateTime.Now.AddDays(-i).Day).ToString().PadLeft(2, '0');
                    }
                    list.Add(Item);
                }
                begin = DateTime.Parse(now).AddDays(-6);
                end = DateTime.Parse(now).AddDays(1).AddSeconds(-1);
            }
            else if (DateType == "month")
            {
                for (int i = DateTime.Now.Day - 1; i >= 0; i--)
                {
                    string Item = "";
                    Item = DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + (DateTime.Now.AddDays(-i).Day).ToString().PadLeft(2, '0');
                    list.Add(Item);
                }
                begin = DateTime.Parse(now).AddDays(-DateTime.Now.Day + 1);
                end = DateTime.Parse(now).AddDays(1).AddSeconds(-1);
            }
            else if (DateType == "year")
            {
                for (int i = 1; i <= DateTime.Now.Month; i++)
                {
                    string Item = "";
                    Item = DateTime.Now.Year + "/" + i.ToString().PadLeft(2, '0');
                    list.Add(Item);
                }
                begin = DateTime.Parse(DateTime.Now.Year + "/01/01");
                end = DateTime.Parse(now).AddDays(1).AddSeconds(-1);
            }
            else if (DateType == "custom_year")
            {
                for (int i = 1; i <= 12; i++)
                {
                    string Item = "";
                    Item = Year + "/" + i.ToString().PadLeft(2, '0');
                    list.Add(Item);
                }
                begin = DateTime.Parse(Year + "/01/01");
                end = DateTime.Parse((int.Parse(Year) + 1) + "/01/01");
            }
            else if (DateType == "custom_month")
            {
                int days = DateTime.DaysInMonth(int.Parse(Year), int.Parse(Month));
                for (int i = days - 1; i >= 0; i--)
                {
                    string Item = "";
                    Item = Month.PadLeft(2, '0') + "/" + (days - i).ToString().PadLeft(2, '0');
                    list.Add(Item);
                }
                begin = DateTime.Parse(Year + "/" + Month + "/01");
                if (Month != "12")
                {
                    end = DateTime.Parse(Year + "/" + (int.Parse(Month) + 1) + "/01");
                }
                else
                {
                    end = DateTime.Parse((int.Parse(Year) + 1) + "/01/01");
                }
            }
            var List = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTable(begin.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd")
                , int.Parse(DepartmentType), int.Parse(Project), -1);
            if (List.Count > 0)
            {
                foreach (XMFinancialCapitalFlow Info in List)
                {
                    HighChart one = new HighChart();
                    foreach (string date in list)
                    {
                        if (((DateTime)Info.Date).ToString(Format) == date)
                        {
                            one.Name = ((DateTime)Info.Date).ToString(Format);
                            one.Group = Info.BudgetTypeName;
                            one.Value = (decimal)Info.Amount;
                            HighChartList.Add(one);
                            break;
                        }
                    }
                }
            }
            return HighChartList;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}