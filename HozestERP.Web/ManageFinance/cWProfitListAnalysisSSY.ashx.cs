using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    /// <summary>
    /// operatingCost 的摘要说明
    /// </summary>
    public class cWProfitListAnalysisSSY : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "Analysis":
                    try
                    {
                        string Year = CommonHelper.QueryString("Year");
                        List<List<HighChart>> Data = new List<List<HighChart>>();
                        List<HighChart> MonthData = new List<HighChart>();
                        List<HighChart> YearData = new List<HighChart>();
                        List<HighChart> ReachData = new List<HighChart>();
                        List<HighChart> GrowthData = new List<HighChart>();
                        List<CWStaffSpendingMapping> MonthList = (List<CWStaffSpendingMapping>)context.Session["MonthListMark"];
                        if (MonthList.Count > 0)
                        {
                            HighChart A = new HighChart();
                            HighChart B = new HighChart();
                            HighChart C = new HighChart();
                            A.Group = "年目标";
                            B.Group = "年实际";
                            C.Group = "年同比";
                            A.Name = Year;
                            B.Name = Year;
                            C.Name = Year;
                            foreach (CWStaffSpendingMapping info in MonthList)
                            {
                                HighChart a = new HighChart();
                                HighChart b = new HighChart();
                                HighChart c = new HighChart();
                                HighChart reach = new HighChart();
                                HighChart growth = new HighChart();
                                a.Name = info.YearStr + "-" + info.MonthStr.PadLeft(2, '0');
                                b.Name = a.Name;
                                c.Name = a.Name;
                                reach.Name = a.Name;
                                growth.Name = a.Name;
                                a.Group = "目标";
                                b.Group = "实际";
                                c.Group = "同比";
                                reach.Group = "达成率";
                                growth.Group = "增长率";
                                a.Value = info.MonthTarget;
                                b.Value = (decimal)info.MonthTotal;
                                c.Value = info.LastMonthTotal;
                                reach.Value = info.MonthReachRate * 100;
                                growth.Value = info.MonthGrowthRate * 100;

                                MonthData.Add(a);
                                MonthData.Add(b);
                                MonthData.Add(c);

                                ReachData.Add(reach);
                                GrowthData.Add(growth);

                                A.Value += a.Value;
                                B.Value += b.Value;
                                C.Value += c.Value;
                            }
                            YearData.Add(A);
                            YearData.Add(B);
                            YearData.Add(C);
                        }
                        Data.Add(MonthData);
                        Data.Add(YearData);
                        Data.Add(ReachData);
                        Data.Add(GrowthData);

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(Data, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                case "BindDepartmentType":
                    try
                    {
                        List<CodeList> List = new List<CodeList>();

                        var DepartmentTypeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(1);
                        if (DepartmentTypeList.Count > 0)
                        {
                            foreach (CodeList info in DepartmentTypeList)
                            {
                                CodeList item = new CodeList();
                                item.CodeID = info.CodeID;
                                item.CodeName = info.CodeName;
                                List.Add(item);
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
                case "BindProjectId":
                    try
                    {
                        int DepartmentTypeID = CommonHelper.QueryStringInt("DepartmentTypeID");
                        List<HighChart> ProjectList = new List<HighChart>();

                        var DepartmentTypeList = IoC.Resolve<IEnterpriseService>().GetDepartmentListByDepType(DepartmentTypeID);
                        if (DepartmentTypeList.Count > 0)
                        {
                            foreach (Department Info in DepartmentTypeList)
                            {
                                var projectList = IoC.Resolve<IXMProjectService>().GetXMProjectListByDepID(Info.DepartmentID);
                                if (projectList.Count > 0)
                                {
                                    List<HighChart> list = new List<HighChart>();
                                    foreach (XMProject info in projectList)
                                    {
                                        HighChart item = new HighChart();
                                        item.Value = info.Id;
                                        item.Name = info.ProjectName;
                                        item.Group = info.ProjectTypeId.ToString();
                                        list.Add(item);
                                    }
                                    ProjectList.AddRange(list);
                                }
                            }
                        }

                        //项目名称绑定--选取自运营项目
                        if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                        {
                            ProjectList = ProjectList.Where(c => c.Group == "362").ToList();
                        }
                        else
                        {
                            List<decimal> list = ProjectList.Select(p => p.Value).ToList();
                            var projectList = IoC.Resolve<IXMProjectService>().GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362)
                                .GroupBy(p => new { p.Id, p.ProjectName })
                                .Select(p => new
                                {
                                    Id = p.Key.Id,
                                    ProjectName = p.Key.ProjectName
                                });
                            for (int i = 0; i < projectList.Count(); i++)
                            {
                                if (list.IndexOf((projectList.ToList())[i].Id) == -1)
                                {
                                    projectList.ToList().Remove((projectList.ToList())[i]);
                                }
                            }
                            if (projectList.Count() > 0)
                            {
                                List<HighChart> List = new List<HighChart>();
                                foreach (var info in projectList)
                                {
                                    HighChart item = new HighChart();
                                    item.Value = info.Id;
                                    item.Name = info.ProjectName;
                                    List.Add(item);
                                }
                                ProjectList.AddRange(List);
                            }
                        }
                        if (DepartmentTypeID != 505)
                        {
                            HighChart add = new HighChart();
                            add.Value = -1;
                            add.Name = "---所有---";
                            ProjectList.Insert(0, add);
                        }

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(ProjectList, josn);
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