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
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageBusiness
{
    /// <summary>
    /// operatingCost 的摘要说明
    /// </summary>
    public class productSales : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "productSales":
                    try
                    {
                        List<ProductSalesData> list = new List<ProductSalesData>();
                        List<HighChart> List = new List<HighChart>();
                        if (System.Web.HttpContext.Current.Session["ProductSalesDataList"] != null)
                        {
                            list = (List<ProductSalesData>)System.Web.HttpContext.Current.Session["ProductSalesDataList"];
                        }

                        foreach (ProductSalesData Info in list)
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
                case "ProjectIdBind":
                    try
                    {
                        string Str = "";
                        //项目名称绑定--选取自运营项目
                        if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                        {
                            var projectList = IoC.Resolve<IXMProjectService>().GetXMProjectList().Where(c => c.ProjectTypeId == 362);

                            foreach (XMProject info in projectList)
                            {
                                Str = Str + info.ProjectName + "," + info.Id + ";";
                            }
                        }
                        else
                        {
                            var projectList = IoC.Resolve<IXMProjectService>().GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362)
                                .GroupBy(p => new { p.Id, p.ProjectName })
                                .Select(p => new
                                {
                                    Id = p.Key.Id,
                                    ProjectName = p.Key.ProjectName
                                });

                            foreach (var info in projectList)
                            {
                                Str = Str + info.ProjectName + "," + info.Id + ";";
                            }
                        }

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(Str, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                case "WarehouseBind":
                    try
                    {
                        var WarehouseList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(227);
                        string Str = "---所有---,-1;";
                        foreach (var info in WarehouseList)
                        {
                            Str = Str + info.CodeName + "," + info.CodeID + ";";
                        }

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(Str, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                case "NickList":
                    try
                    {
                        string Str = "";
                        string ProjectId = CommonHelper.QueryString("ProjectId");

                        if (ProjectId != "")
                        {
                            //店铺数据源 
                            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                            {
                                var nickList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMNickList("", 1, Convert.ToInt32(ProjectId));

                                foreach (var info in nickList)
                                {
                                    Str = Str + info.nick + "," + info.nick_id + ";";
                                }

                                Str = Str + "---所有---,-1;";
                            }
                            else
                            {
                                var nickList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMNickListSS("", 1, Convert.ToInt32(ProjectId), HozestERPContext.Current.User.CustomerID, 0);

                                if (nickList.Count() == 0)
                                {
                                    Str = Str + "---无店铺权限---,0;";
                                }
                                else
                                {
                                    if (nickList.Count() > 0)
                                    {
                                        foreach (var info in nickList)
                                        {
                                            Str = Str + info.nick + "," + info.nick_id + ";";
                                        }
                                    }
                                    Str = Str + "---所有---,99;";
                                }
                            }
                        }

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(Str, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                case "Province":
                    try
                    {
                        string Str = "";
                        int Warehouse = CommonHelper.QueryStringInt("Warehouse");
                        var ProvinceList = IoC.Resolve<IProvinceWarehouseService>().GetProvinceWarehouseListByWarehouseID(Warehouse);
                        foreach (var info in ProvinceList)
                        {
                            Str = Str + info.ProvinceName + "," + info.ID + ";";
                        }
                        Str += "---所有---,-1;";

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(Str, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;

                case "JdReturn":
                    try
                    {
                        string Begin = CommonHelper.QueryString("Begin");
                        string End = CommonHelper.QueryString("End");
                        string NickIDs = CommonHelper.QueryString("NickIDs");
                        var JdReturnList = IoC.Resolve<IXMJDSaleRejectedService>().GetXMJDSaleReportData(Begin, End, NickIDs);
                        List<HighChart> HighChartList = new List<HighChart>();
                        foreach (var item in JdReturnList)
                        {
                            HighChart one = new HighChart();
                            one.Name = item.ReturnType;
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