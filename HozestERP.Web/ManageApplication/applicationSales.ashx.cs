using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageApplication
{
    /// <summary>
    /// operatingCost 的摘要说明
    /// </summary>
    public class applicationSales : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "applicationSales":
                    try
                    {
                        List<XMApplicationExchange> list = new List<XMApplicationExchange>();
                        List<HighChart> List = new List<HighChart>();
                        if (System.Web.HttpContext.Current.Session["ApplicationSalesDataList"] != null)
                        {
                            list = (List<XMApplicationExchange>)System.Web.HttpContext.Current.Session["ApplicationSalesDataList"];
                        }

                        foreach (XMApplicationExchange Info in list)
                        {
                            HighChart one = new HighChart();
                            one.Name = Info.ProductName.Trim();
                            one.Value = decimal.Parse(Info.ProductNum.ToString());

                            if (List.FirstOrDefault(x => x.Name == Info.ProductName.Trim()) != null)
                            {
                                HighChart search = List.FirstOrDefault(x => x.Name == Info.ProductName.Trim());
                                search.Value = search.Value + one.Value;
                            }
                            else
                            {
                                List.Add(one);
                            }
                        }
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(List, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                case "applicationSalesHuan":
                    try
                    {
                        string ddlPlatform = CommonHelper.QueryString("ddlPlatform");
                        string nickid = CommonHelper.QueryString("nickid");
                        string timetype = CommonHelper.QueryString("timetype");
                        string ApplicaType = CommonHelper.QueryString("ApplicaType");
                        string BeginDate = CommonHelper.QueryString("BeginDate");
                        string EndDate = CommonHelper.QueryString("EndDate");

                        var list = IoC.Resolve<IXMApplicationService>().GetXMApplicationReportData(int.Parse(ddlPlatform), int.Parse(nickid), int.Parse(timetype), int.Parse(ApplicaType), Convert.ToDateTime(BeginDate), Convert.ToDateTime(EndDate),1);
                        List<HighChart> HighChartList = new List<HighChart>();
                        foreach (var item in list)
                        {
                            HighChart one = new HighChart();
                            one.Name = item.ProductName;
                            one.Value = decimal.Parse(item.Num.ToString());
                            HighChartList.Add(one);
                        }
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(HighChartList, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {

                    }
                    break;

                case "applicationSalesTui":
                    try
                    {
                        string ddlPlatform = CommonHelper.QueryString("ddlPlatform");
                        string nickid = CommonHelper.QueryString("nickid");
                        string timetype = CommonHelper.QueryString("timetype");
                        string ApplicaType = CommonHelper.QueryString("ApplicaType");
                        string BeginDate = CommonHelper.QueryString("BeginDate");
                        string EndDate = CommonHelper.QueryString("EndDate");

                        var list = IoC.Resolve<IXMApplicationService>().GetXMApplicationReportData(int.Parse(ddlPlatform), int.Parse(nickid), int.Parse(timetype), int.Parse(ApplicaType), Convert.ToDateTime(BeginDate), Convert.ToDateTime(EndDate), 2);
                        List<HighChart> HighChartList = new List<HighChart>();
                        foreach (var item in list)
                        {
                            HighChart one = new HighChart();
                            one.Name = item.ProductName;
                            one.Value = decimal.Parse(item.Num.ToString());
                            HighChartList.Add(one);
                        }
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(HighChartList, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {

                    }
                    break;
            }
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