using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using HozestERP.BusinessLogic.Customers;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageBusiness
{
    /// <summary>
    /// operatingCost 的摘要说明
    /// </summary>
    public class companyOperation : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "companyOperation":
                    try
                    {
                        List<List<HighChart>> AllList = new List<List<HighChart>>();
                        for (int i = 0; i < 7; i++)
                        {
                            List<HighChart> empty = new List<HighChart>();
                            AllList.Add(empty);
                        }
                        List<HighChart> List = new List<HighChart>();
                        List<OperatingCostData> OperatingCostDataList = new List<OperatingCostData>();
                        List<List<HighChart>> list = new List<List<HighChart>>();

                        string DateType = CommonHelper.QueryString("DateType");
                        string PageType = CommonHelper.QueryString("PageType");
                        string Year = CommonHelper.QueryString("Year");
                        string Month = CommonHelper.QueryString("Month");
                        string ProjectId = CommonHelper.QueryString("ProjectId");
                        string NickId = CommonHelper.QueryString("NickId");
                        string mark = "";
                        //var list = GetDataTotal(DateType, PageType, Year, Month, ProjectId, NickId);
                        if (System.Web.HttpContext.Current.Session["Mark"] != null)
                        {
                            mark = System.Web.HttpContext.Current.Session["Mark"].ToString(); ;
                        }

                        if ((DateType == "year" || DateType == "custom_year") && mark == (DateType + "," + ProjectId + "," + NickId))
                        {

                            if (System.Web.HttpContext.Current.Session["HightChartsLineYear"] != null)
                            {
                                OperatingCostDataList = (List<OperatingCostData>)System.Web.HttpContext.Current.Session["HightChartsLineYear"];
                            }
                            if (System.Web.HttpContext.Current.Session["HightChartsPieYear"] != null)
                            {
                                list = (List<List<HighChart>>)System.Web.HttpContext.Current.Session["HightChartsPieYear"];
                            }
                        }
                        else
                        {
                            GetDataTotal(DateType, PageType, Year, Month, ProjectId, NickId);
                            if (System.Web.HttpContext.Current.Session["HightChartsLine"] != null)
                            {
                                OperatingCostDataList = (List<OperatingCostData>)System.Web.HttpContext.Current.Session["HightChartsLine"];
                            }
                            if (System.Web.HttpContext.Current.Session["HightChartsPie"] != null)
                            {
                                list = (List<List<HighChart>>)System.Web.HttpContext.Current.Session["HightChartsPie"];
                            }
                        }

                        if (list != null && list.Count > 0)
                        {
                            foreach (OperatingCostData info in OperatingCostDataList)
                            {
                                HighChart one = new HighChart();
                                HighChart two = new HighChart();
                                HighChart three = new HighChart();
                                HighChart four = new HighChart();
                                HighChart five = new HighChart();
                                HighChart six = new HighChart();
                                HighChart seven = new HighChart();
                                one.Name = info.Date;
                                two.Name = info.Date;
                                three.Name = info.Date;
                                four.Name = info.Date;
                                five.Name = info.Date;
                                six.Name = info.Date;
                                seven.Name = info.Date;
                                one.Group = "营业收入";
                                one.Value = info.CountMoneySum1;
                                List.Add(one);
                                two.Group = "营业成本";
                                two.Value = info.YYCBMonthMoney;
                                List.Add(two);
                                three.Group = "管理费用";
                                three.Value = info.ManagementFee;
                                List.Add(three);
                                four.Group = "人工成本";
                                four.Value = info.ZJRGMonthMoney;
                                List.Add(four);
                                five.Group = "增值税";
                                five.Value = info.ZZSMonthMoney;
                                List.Add(five);
                                six.Group = "毛利";
                                six.Value = info.MLMonthMoney;
                                List.Add(six);
                                seven.Group = "净利润";
                                seven.Value = info.SQLRMonthMoney;
                                List.Add(seven);
                            }
                            AllList[0] = List;
                            AllList[1] = ObjToHighChart(list[0]);
                            AllList[2] = ObjToHighChart(list[1]);
                            AllList[3] = ObjToHighChart(list[2]);
                            AllList[4] = ObjToHighChart(list[3]);
                            AllList[5] = ObjToHighChart(list[4]);
                            AllList[6] = ObjToHighChart(list[5]);
                        }

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(AllList, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
            }
        }

        public List<HighChart> ObjToHighChart(List<HighChart> list)
        {
            //list = GetPieGraphData(list, "Name");
            if (list != null && list.Count > 0)
            {
                list = list.OrderBy(x => x.Name).ToList();
            }
            return list;
        }

        private void GetDataTotal(string DateType, string PageType, string Year, string Month, string ProjectId, string NickId)
        {
            CompanyTool tool = new CompanyTool();
            string Format = "";
            if ((DateType == "year") || DateType == "custom_year")
            {
                Format = "yyyy/MM";
            }
            else
            {
                Format = "MM/dd";
            }
            List<OperatingCostData> list = new List<OperatingCostData>();
            //List<List<HighChart>> List = new List<List<HighChart>>();
            string now = DateTime.Now.ToLongDateString();
            DateTime begin = new DateTime();
            DateTime end = new DateTime();

            if (DateType == "week")
            {
                for (int i = 6; i >= 0; i--)
                {
                    OperatingCostData Item = new OperatingCostData();
                    if (DateTime.Now.Day < 7 && DateTime.Now.AddDays(-i).Day > 7)
                    {
                        Item.Date = (DateTime.Now.Month - 1).ToString().PadLeft(2, '0') + "/" + (DateTime.Now.AddDays(-i).Day).ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        Item.Date = DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + (DateTime.Now.AddDays(-i).Day).ToString().PadLeft(2, '0');
                    }
                    list.Add(Item);
                }
                begin = DateTime.Parse(now).AddDays(-6);
                end = DateTime.Parse(now).AddDays(1);
                //List = tool.GetDayTotal(DateType, PageType, begin, end, list, Format, Year, ProjectId, NickId);
            }
            else if (DateType == "month")
            {
                for (int i = DateTime.Now.Day - 1; i >= 0; i--)
                {
                    OperatingCostData Item = new OperatingCostData();
                    Item.Date = DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + (DateTime.Now.AddDays(-i).Day).ToString().PadLeft(2, '0');
                    list.Add(Item);
                }
                begin = DateTime.Parse(now).AddDays(-DateTime.Now.Day + 1);
                end = DateTime.Parse(now).AddDays(1);
                //List = tool.GetDayTotal(DateType, PageType, begin, end, list, Format, Year, ProjectId, NickId);
            }
            else if (DateType == "year")
            {
                for (int i = 1; i <= DateTime.Now.Month; i++)
                {
                    OperatingCostData Item = new OperatingCostData();
                    Item.Date = DateTime.Now.Year + "/" + i.ToString().PadLeft(2, '0');
                    list.Add(Item);
                }
                begin = DateTime.Parse(DateTime.Now.Year + "/01/01");
                end = DateTime.Parse(now).AddDays(1);
                //List = tool.GetDayTotal(DateType, PageType, begin, end, list, Format, Year, ProjectId, NickId);
            }
            else if (DateType == "custom_year")
            {
                begin = DateTime.Parse(Year + "/01/01");
                for (int i = 1; i <= 12; i++)
                {
                    OperatingCostData Item = new OperatingCostData();
                    Item.Date = Year + "/" + i.ToString().PadLeft(2, '0');
                    list.Add(Item);
                }
                end = DateTime.Parse((int.Parse(Year) + 1) + "/01/01");
                //List = tool.GetDayTotal(DateType, PageType, begin, end, list, Format, Year, ProjectId, NickId);
            }
            else if (DateType == "custom_month")
            {
                int days = DateTime.DaysInMonth(int.Parse(Year), int.Parse(Month));
                for (int i = days - 1; i >= 0; i--)
                {
                    OperatingCostData Item = new OperatingCostData();
                    Item.Date = Month.PadLeft(2, '0') + "/" + (days - i).ToString().PadLeft(2, '0');
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
                //List = tool.GetDayTotal(DateType, PageType, begin, end, list, Format, Year, ProjectId, NickId);
            }
            tool.GetDayTotal(DateType, PageType, begin, end, list, Format, Year, ProjectId, NickId);
            return;
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