using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRM.BusinessLogic.ManageContract;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    public partial class CWProfitListAnalysisSSY : BaseAdministrationPage, ISearchPage
    {
        public string TabStr = "";
        CWProfitListSSYTool tool = new CWProfitListSSYTool();
        CWProfitModel MonthData = new CWProfitModel();
        CWProfitModel YearData = new CWProfitModel();
        List<CWStaffSpendingMapping> MonthList = new List<CWStaffSpendingMapping>();
        List<int> parent = new List<int>();
        List<int> son = new List<int>();
        List<int> FinancialFieldList = new List<int>();
        List<int> IntegratedManagementIDList = new List<int>();//为管理费用的营业费用字段

        int[] SpecialID = { 64, 71 };//营业收入，广告费补贴ID
        int[] UnSetting = { 67, 68, 72, 73, 70, 74, 106, 66, 69 };//不可填字段ID
        int[] NickSetting = { 64, 78, 79, 86, 107, 109, 110 };//选择店铺时可填字段ID
        int[] ProjectSetting = { 108, 89, 90, 91, 111, 98, 101, 100, 112, 113, 71 };//不选择店铺时可填字段ID

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtYearStr.Value = DateTime.Now.Year.ToString();
                this.txtMonthStr.Value = DateTime.Now.Month.ToString();
                //this.BindData();
            }
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            #region 部门类型绑定

            //部门类型绑定
            //this.ddlDepartmentType.Items.Clear();
            //var DepartmentTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(1, false);
            //this.ddlDepartmentType.DataSource = DepartmentTypeList;
            //this.ddlDepartmentType.DataTextField = "CodeName";
            //this.ddlDepartmentType.DataValueField = "CodeID";
            //this.ddlDepartmentType.DataBind();
            #endregion
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
        }

        public CWProfitModel GetB2BCMonthData(int departmentType, List<int?> NickIdList, string year, string month)
        {
            CWProfitModel monthData = new CWProfitModel();
            List<CWStaffSpending> CWStaffSpendingList = tool.GetAllResult(FinancialFieldList, year, month, -1, departmentType, -1);
            foreach (int ID in son)
            {
                monthData = tool.B2BOrB2C(monthData, ID, NickIdList, year, month, -1, departmentType, CWStaffSpendingList);
            }
            foreach (int ID in parent)
            {
                monthData = tool.B2BOrB2C(monthData, ID, NickIdList, year, month, -1, departmentType, CWStaffSpendingList);
            }
            return monthData;
        }

        public CWProfitModel GetProjectMonthData(int ProjectId, List<int> nickIdList, string year, string month)
        {
            CWProfitModel MonthCacheData = new CWProfitModel();
            List<CWStaffSpending> NickSettingDataList = tool.GetAllResult(NickSetting.ToList(), year, month, ProjectId, -1, -1);
            MonthCacheData = GetAuxiliaryParameters(MonthCacheData, ProjectId, year, month);
            foreach (int ID in NickSetting)
            {
                MonthCacheData = GetValue(MonthCacheData, year, month, ID, ProjectId, -1, NickSettingDataList, "-1");
            }

            List<CWStaffSpending> ProjectSettingDataList = tool.GetAllResult(ProjectSetting.ToList(), year, month, ProjectId, -1, -1);
            MonthCacheData = tool.AddOfflineData(MonthCacheData, nickIdList, year, month);
            foreach (int ID in ProjectSetting)
            {
                MonthCacheData = GetValue(MonthCacheData, year, month, ID, ProjectId, -1, ProjectSettingDataList, "-1");
            }
            foreach (int ID in parent)
            {
                MonthCacheData = GetValue(MonthCacheData, year, month, ID, ProjectId, -1, null, "");
            }
            return MonthCacheData;
        }

        public void GetB2BC(int departmentType, List<int?> NickIdList, string year, string month, string ProjectId)
        {
            CWProfitModel monthData = GetB2BCMonthData(departmentType, NickIdList, year, month);
            MonthData = tool.AccumulationValue(MonthData, monthData);

            DateTime end = new DateTime();
            if (month == "12")
            {
                end = DateTime.Parse((int.Parse(year) + 1) + "/" + month.ToString() + "/01");
            }
            else
            {
                end = DateTime.Parse(year + "/" + (int.Parse(month) + 1).ToString() + "/01");
            }

            for (int i = 1; i <= 12; i++)
            {
                DateTime begin = DateTime.Parse(year + "/" + i + "/01");
                if (begin < end)
                {
                    monthData = GetB2BCMonthData(departmentType, NickIdList, year, i.ToString());
                    MonthList.AddRange(GetMonthListDataList(monthData, year, i.ToString(), ProjectId, NickIdList, null, departmentType));
                    YearData = tool.AccumulationValue(YearData, monthData);
                }
                else
                {
                    break;
                }
            }
        }

        public CWStaffSpendingMapping GetMonthListData(CWProfitModel monthData, string year, string month, string ProjectId, List<int?> NickIdList, List<int> nickIdList, int FinancialFieldId, int DepartmentType)
        {
            int projectId = int.Parse(ProjectId);
            CWStaffSpendingMapping data = new CWStaffSpendingMapping();
            CWStaffSpendingMapping LastData = new CWStaffSpendingMapping();
            CWProfitModel LastMonthData = new CWProfitModel();
            if (DepartmentType != 505)
            {
                LastMonthData = GetB2BCMonthData(DepartmentType, NickIdList, (int.Parse(year) - 1).ToString(), month);
            }
            else
            {
                LastMonthData = GetProjectMonthData(projectId, nickIdList, (int.Parse(year) - 1).ToString(), month);
            }

            if (FinancialFieldId == 64)
            {
                if (DepartmentType != 505)
                {
                    data = GetData(63, year, month, projectId, DepartmentType);
                    data.MonthTotal = monthData.OperatingPerformance;
                    data.LastMonthTotal = LastMonthData.OperatingPerformance;
                }
                else
                {
                    data = GetData(64, year, month, projectId, DepartmentType);
                    data.MonthTotal = monthData.BusinessIncome;
                    data.LastMonthTotal = LastMonthData.BusinessIncome;
                }
            }
            else if (FinancialFieldId == 66)
            {
                data = GetData(66, year, month, projectId, DepartmentType);
                data.MonthTotal = monthData.YYCBMoney;
                data.LastMonthTotal = LastMonthData.YYCBMoney;
            }
            else if (FinancialFieldId == 68)
            {
                data = GetData(68, year, month, projectId, DepartmentType);
                data.MonthTotal = monthData.MLMoney;
                data.LastMonthTotal = LastMonthData.MLMoney;
            }
            else if (FinancialFieldId == 73)
            {
                data = GetData(73, year, month, projectId, DepartmentType);
                data.MonthTotal = monthData.SQLRMoney;
                data.LastMonthTotal = LastMonthData.SQLRMoney;
            }

            data.MonthStr = month;
            data.YearStr = year;
            data.FinancialFieldId = FinancialFieldId;

            if (data.MonthTarget != 0)//统计图表中的增长率，达成率的值
            {
                data.MonthReachRate = Math.Round((decimal)data.MonthTotal / data.MonthTarget, 4);
            }
            if (data.LastMonthTotal != 0)
            {
                data.MonthGrowthRate = Math.Round(((decimal)data.MonthTotal - data.LastMonthTotal) / data.LastMonthTotal, 4);
            }

            return data;
        }

        public List<CWStaffSpendingMapping> GetMonthListDataList(CWProfitModel monthData, string year, string month, string ProjectId, List<int?> NickIdList, List<int> nickIdList, int DepartmentType)
        {
            List<CWStaffSpendingMapping> list = new List<CWStaffSpendingMapping>();
            list.Add(GetMonthListData(monthData, year, month, ProjectId, NickIdList, nickIdList, 64, DepartmentType));
            list.Add(GetMonthListData(monthData, year, month, ProjectId, NickIdList, nickIdList, 66, DepartmentType));
            list.Add(GetMonthListData(monthData, year, month, ProjectId, NickIdList, nickIdList, 68, DepartmentType));
            list.Add(GetMonthListData(monthData, year, month, ProjectId, NickIdList, nickIdList, 73, DepartmentType));
            return list;
        }

        private void BindData()
        {
            #region 条件查询

            //部门类型
            string DepartmentType = Request.Form["ddlDepartmentType"];//this.ddlDepartmentType.SelectedValue.Trim();

            //项目类型： 自运营
            string cbXMProjectTypeId = "362";

            //项目名称
            string cbXMProject = Request.Form["ddlProjectId"];//this.ddlXMProjectNameId.SelectedValue.Trim();

            //B2C的金立
            if (DepartmentType == "197" && cbXMProject != "-1")
            {
                DepartmentType = "505";//家居事业部
            }

            //预算字段
            string Fields = "";
            #region 预算字段
            if (DepartmentType == "505" || DepartmentType == "-1")//家具事业部,所有
            {
                if (cbXMProject == "-1")
                {
                    //项目名称绑定--选取自运营项目
                    if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                    {
                        var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362);
                        foreach (var info in projectList)
                        {
                            var item = base.XMIncludeFieldsService.GetXMIncludeFieldsListByProjectID(info.Id);
                            if (item != null)
                            {
                                Fields = Fields + "," + item.Fields;
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
                        foreach (var info in projectList)
                        {
                            var item = base.XMIncludeFieldsService.GetXMIncludeFieldsListByProjectID(info.Id);
                            if (item != null)
                            {
                                Fields = Fields + "," + item.Fields;
                            }
                        }
                    }
                }
                else
                {
                    var item = base.XMIncludeFieldsService.GetXMIncludeFieldsListByProjectID(int.Parse(cbXMProject));
                    if (item != null)
                    {
                        Fields = Fields + "," + item.Fields;
                    }
                }
            }

            if (DepartmentType != "505")
            {
                if (DepartmentType == "6" || DepartmentType == "-1")
                {
                    var B2BItem = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(297);//B2B
                    if (B2BItem != null)
                    {
                        Fields = Fields + "," + B2BItem.Fields;
                    }
                }
                if (DepartmentType == "197" || DepartmentType == "-1")
                {
                    var B2CItem = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(63);//B2C
                    if (B2CItem != null)
                    {
                        Fields = Fields + "," + B2CItem.Fields;
                    }
                }
                if (DepartmentType == "507" || DepartmentType == "-1")
                {
                    Fields = Fields + ",70";//营业费用
                    var IntegratedManagementItem = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(507);//综管
                    if (IntegratedManagementItem != null)
                    {
                        string[] Arr = IntegratedManagementItem.Fields.Replace("，", ",").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        var IntegratedManagementList = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(70).Where(x => x.IsManagementField == true);//管理费用字段
                        if (IntegratedManagementList.Count() > 0)
                        {
                            foreach (XMFinancialField item in IntegratedManagementList)
                            {
                                if (Arr.Contains(item.Id.ToString()))
                                {
                                    Fields = Fields + "," + item.Id;
                                    IntegratedManagementIDList.Add(item.Id);
                                }
                            }
                        }
                    }
                }
            }

            Fields = Fields.Replace("，", ",");
            string[] arr = Fields.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length > 0)
            {
                foreach (string a in arr)
                {
                    if (FinancialFieldList.IndexOf(int.Parse(a)) == -1)
                    {
                        FinancialFieldList.Add(int.Parse(a));
                    }
                }
            }
            #endregion

            //店铺集合
            List<int> nickIdList = new List<int>();
            #region 店铺条件查询集合 处理
            //选择某项目
            if (DepartmentType == "505")
            {
                var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(cbXMProject), Convert.ToInt32(cbXMProjectTypeId));
                if (nickList.Count > 0)
                {
                    nickIdList = nickList.Select(p => p.nick_id).ToList();
                }
            }
            #endregion

            FinancialFieldList = GetFinancialFieldListInTurn();
            foreach (int id in SpecialID)
            {
                if (FinancialFieldList.IndexOf(id) != -1)
                {
                    son.Insert(0, id);//查询不用计算的字段
                    parent.Remove(id);
                }
            }

            #endregion

            //该年月
            string year = this.txtYearStr.Value.Trim();
            string month = this.txtMonthStr.Value.Trim();

            string type = this.ddlType.SelectedValue.Trim();
            List<CWStaffSpendingMapping> monthList = new List<CWStaffSpendingMapping>();

            List<CWStaffSpendingMapping> Tab = GetDataByDateTime(DepartmentType, cbXMProject, nickIdList, year, month);
            if (DepartmentType != "507")
            {
                foreach (CWStaffSpendingMapping Info in Tab)
                {
                    foreach (CWStaffSpendingMapping info in MonthList)
                    {
                        if (Info.FinancialFieldId == info.FinancialFieldId && Info.YearStr == info.YearStr && Info.MonthStr == info.MonthStr)
                        {
                            Info.LastMonthTotal = (decimal)info.LastMonthTotal;
                            Info.LastYearTotal = MonthList.Where(x => x.FinancialFieldId == Info.FinancialFieldId).Sum(x => x.LastMonthTotal);
                        }
                    }
                }
            }
            TabStr = GetTable(Tab);

            foreach (CWStaffSpendingMapping Info in MonthList)
            {
                if (type == "1" && Info.FinancialFieldId == 64)
                {
                    monthList.Add(Info);
                }
                if (type == "2" && Info.FinancialFieldId == 66)
                {
                    monthList.Add(Info);
                }
                if (type == "3" && Info.FinancialFieldId == 68)
                {
                    monthList.Add(Info);
                }
                if (type == "4" && Info.FinancialFieldId == 73)
                {
                    monthList.Add(Info);
                }
            }

            Session["MonthListMark"] = monthList;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "BindData", "dataBind(" + year + ")", true);//ajax

            //消除Content4的隐藏效果
            System.Web.UI.HtmlControls.HtmlTable GridTable = Master.FindControl("GridTable") as System.Web.UI.HtmlControls.HtmlTable;
            GridTable.Style.Add("display", "''");
        }

        public string GetTable(List<CWStaffSpendingMapping> List)
        {
            string tab = "";
            StringBuilder st = new StringBuilder();
            foreach (CWStaffSpendingMapping TrStr in List)
            {
                if (TrStr.MonthTarget != 0)
                {
                    TrStr.MonthReachRate = Math.Round((decimal)TrStr.MonthTotal / TrStr.MonthTarget, 4);
                }
                if (TrStr.YearTarget != 0)
                {
                    TrStr.YearReachRate = Math.Round((decimal)TrStr.YearTotal / TrStr.YearTarget, 4);
                }
                if (TrStr.LastMonthTotal != 0)
                {
                    TrStr.MonthGrowthRate = Math.Round(((decimal)TrStr.MonthTotal - TrStr.LastMonthTotal) / TrStr.LastMonthTotal, 4);
                }
                if (TrStr.LastYearTotal != 0)
                {
                    TrStr.YearGrowthRate = Math.Round(((decimal)TrStr.YearTotal - TrStr.LastYearTotal) / TrStr.LastYearTotal, 4);
                }
                st.Append("<tr style='height: 30px;font-size:inherit;' align='center'>");
                st.Append("<td>" + TrStr.TypeName + "</td>");
                st.Append("<td>" + TrStr.MonthTarget + "</td>");
                st.Append("<td>" + TrStr.MonthTotal + "</td>");
                st.Append("<td>" + Math.Round(TrStr.MonthReachRate * 100, 2) + " %</td>");
                st.Append("<td>" + TrStr.LastMonthTotal + "</td>");
                st.Append("<td>" + Math.Round(TrStr.MonthGrowthRate * 100, 2) + " %</td>");
                st.Append("<td>" + TrStr.YearTarget + "</td>");
                st.Append("<td>" + TrStr.YearTotal + "</td>");
                st.Append("<td>" + Math.Round(TrStr.YearReachRate * 100, 2) + " %</td>");
                st.Append("<td>" + TrStr.LastYearTotal + "</td>");
                st.Append("<td>" + Math.Round(TrStr.YearGrowthRate * 100, 2) + " %</td>");
                st.Append("</tr>");
            }
            tab = st.ToString();
            return tab;
        }

        public List<CWStaffSpendingMapping> GetDataByDateTime(string DepartmentType, string cbXMProject, List<int> nickIdList, string year, string month)
        {
            MonthData = new CWProfitModel();
            YearData = new CWProfitModel();
            int ProjectId = 0;
            List<int?> NickIdList = new List<int?>();
            CWProfitModel monthData = new CWProfitModel();
            List<CWStaffSpendingMapping> data = new List<CWStaffSpendingMapping>();

            foreach (int nick in nickIdList)
            {
                NickIdList.Add(nick);
            }

            if (DepartmentType == "197")
            {
                GetB2BC(197, NickIdList, year, month, cbXMProject);
            }
            else if (DepartmentType == "6")
            {
                GetB2BC(6, NickIdList, year, month, cbXMProject);
            }

            if (DepartmentType == "505")
            {
                ProjectId = int.Parse(cbXMProject);
                MonthData = GetProjectMonthData(ProjectId, nickIdList, year, month);

                DateTime end = new DateTime();
                if (month == "12")
                {
                    end = DateTime.Parse((int.Parse(year) + 1) + "/" + month.ToString() + "/01");
                }
                else
                {
                    end = DateTime.Parse(year + "/" + (int.Parse(month) + 1).ToString() + "/01");
                }

                for (int i = 1; i <= 12; i++)
                {
                    DateTime begin = DateTime.Parse(year + "/" + i + "/01");
                    if (begin < end)
                    {
                        CWProfitModel MonthCacheData = GetProjectMonthData(ProjectId, nickIdList, year, i.ToString());
                        MonthList.AddRange(GetMonthListDataList(MonthCacheData, year, i.ToString(), cbXMProject, NickIdList, nickIdList, int.Parse(DepartmentType)));
                        YearData = tool.AccumulationValue(YearData, MonthCacheData);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (DepartmentType != "507")
            {
                foreach (int ID in son)
                {
                    data.Add(GetData(ID, year, month, int.Parse(cbXMProject), int.Parse(DepartmentType)));
                }
                foreach (int ID in parent)
                {
                    data.Add(GetData(ID, year, month, int.Parse(cbXMProject), int.Parse(DepartmentType)));
                }
                data = tool.GetCompleteData(data, MonthData, YearData);
            }
            else
            {
                //综管的数据
                List<CWStaffSpendingMapping> FinanceFeeList = new List<CWStaffSpendingMapping>();

                if (IntegratedManagementIDList.Count() > 0)
                {
                    for (int i = 0; i < DateTime.Now.Month; i++)
                    {
                        CWStaffSpendingMapping Item = GetIntegratedManagementData(int.Parse(year), i + 1);
                        Item.FinancialFieldId = 73;//利润
                        MonthList.Add(Item);
                        if (int.Parse(month) == (i + 1))
                        {
                            Item.YearTotal = MonthList.Sum(x => x.MonthTotal);
                            Item.LastYearTotal = MonthList.Sum(x => x.LastMonthTotal);
                            if (Item.LastYearTotal != 0)
                            {
                                Item.MonthGrowthRate = (decimal)(Item.YearTotal - Item.LastYearTotal) / Item.LastYearTotal;
                            }
                            else
                            {
                                Item.MonthGrowthRate = 0;
                            }
                            data.Add(Item);
                        }
                    }
                }
            }

            List<CWStaffSpendingMapping> Data = GetBindTableData(data, DepartmentType);
            return Data;
        }

        public List<CWStaffSpendingMapping> GetBindTableData(List<CWStaffSpendingMapping> data, string DepartmentType)
        {
            List<CWStaffSpendingMapping> List = new List<CWStaffSpendingMapping>();

            foreach (CWStaffSpendingMapping info in data)
            {
                if ((info.ProjectId == -1 && info.FinancialFieldId == 63) || (info.ProjectId != -1 && info.FinancialFieldId == 64))
                {
                    CWStaffSpendingMapping Data = new CWStaffSpendingMapping();
                    Data.YearStr = info.YearStr;
                    Data.MonthStr = info.MonthStr;
                    Data = BeInitialization(Data);
                    Data.FinancialFieldId = 64;
                    Data.TypeName = "收入";
                    Data.MonthTarget = info.MonthTarget;
                    Data.YearTarget = info.YearTarget;
                    Data.MonthTotal = info.MonthTotal;
                    Data.YearTotal = info.YearTotal;
                    List.Add(Data);
                }
                if (info.FinancialFieldId == 66)
                {
                    CWStaffSpendingMapping Data = new CWStaffSpendingMapping();
                    Data.YearStr = info.YearStr;
                    Data.MonthStr = info.MonthStr;
                    Data = BeInitialization(Data);
                    Data.FinancialFieldId = 66;
                    Data.TypeName = "成本";
                    Data.MonthTarget = info.MonthTarget;
                    Data.YearTarget = info.YearTarget;
                    Data.MonthTotal = info.MonthTotal;
                    Data.YearTotal = info.YearTotal;
                    List.Add(Data);
                }
                if (info.FinancialFieldId == 68)
                {
                    CWStaffSpendingMapping Data = new CWStaffSpendingMapping();
                    Data.YearStr = info.YearStr;
                    Data.MonthStr = info.MonthStr;
                    Data = BeInitialization(Data);
                    Data.FinancialFieldId = 68;
                    Data.TypeName = "毛利";
                    Data.MonthTarget = info.MonthTarget;
                    Data.YearTarget = info.YearTarget;
                    Data.MonthTotal = info.MonthTotal;
                    Data.YearTotal = info.YearTotal;
                    List.Add(Data);
                }
                if (info.FinancialFieldId == 73)
                {
                    CWStaffSpendingMapping Data = new CWStaffSpendingMapping();
                    Data.YearStr = info.YearStr;
                    Data.MonthStr = info.MonthStr;
                    Data = BeInitialization(Data);
                    Data.FinancialFieldId = 73;
                    Data.TypeName = "利润";
                    Data.MonthTarget = info.MonthTarget;
                    Data.YearTarget = info.YearTarget;
                    Data.LastMonthTotal = info.LastMonthTotal;
                    Data.LastYearTotal = info.LastYearTotal;
                    Data.MonthTotal = info.MonthTotal;
                    Data.YearTotal = info.YearTotal;
                    List.Add(Data);
                }
            }
            return List;
        }

        public CWStaffSpendingMapping GetData(int ID, string year, string month, int ProjectId, int DepartmentType)
        {
            List<XMProjectCostDetail> exist = new List<XMProjectCostDetail>();
            CWStaffSpendingMapping info = new CWStaffSpendingMapping();
            info.YearStr = year;
            info.MonthStr = month;
            info.MonthTotal = 0;
            info.YearTotal = 0;
            info.MonthTarget = 0;
            info.YearTarget = 0;
            info.FinancialFieldId = ID;
            if (DepartmentType != 505)
            {
                int departmentID = -1;
                XMProjectCostDetail other = new XMProjectCostDetail();
                other.FinancialFieldID = ID;
                other.OneMonthCost = 0;
                other.TwoMonthCost = 0;
                other.ThreeMonthCost = 0;
                other.FourMonthCost = 0;
                other.FiveMonthCost = 0;
                other.SixMonthCost = 0;
                other.SevenMonthCost = 0;
                other.EightMonthCost = 0;
                other.NineMonthCost = 0;
                other.TenMonthCost = 0;
                other.ElevenMonthCost = 0;
                other.TwelMonthCost = 0;

                if (DepartmentType == 197)
                {
                    departmentID = 63;
                }
                else if (DepartmentType == 6)
                {
                    departmentID = 297;
                }
                else if (DepartmentType == 507)
                {
                    departmentID = 507;
                }

                var otherTarget = base.XMOtherCostDetailService.GetXMOtherCostDataAudit(ID, departmentID, int.Parse(year));
                if (otherTarget.Count > 0)
                {
                    foreach (XMOtherCostDetail item in otherTarget)
                    {
                        if (FinancialFieldList.IndexOf(item.FinancialFieldID) != -1)
                        {
                            other.OneMonthCost += item.OneMonthCost;
                            other.TwoMonthCost += item.TwoMonthCost;
                            other.ThreeMonthCost += item.ThreeMonthCost;
                            other.FourMonthCost += item.FourMonthCost;
                            other.FiveMonthCost += item.FiveMonthCost;
                            other.SixMonthCost += item.SixMonthCost;
                            other.SevenMonthCost += item.SevenMonthCost;
                            other.EightMonthCost += item.EightMonthCost;
                            other.NineMonthCost += item.NineMonthCost;
                            other.TenMonthCost += item.TenMonthCost;
                            other.ElevenMonthCost += item.ElevenMonthCost;
                            other.TwelMonthCost += item.TwelMonthCost;
                        }
                    }
                    exist.Add(other);
                    info.MonthTarget = GetMonthData(exist, month, false);
                    info.YearTarget = GetMonthData(exist, "-1", true);
                }
            }
            if (DepartmentType == 505 || DepartmentType == -1)
            {
                var target = base.XMProjectCostDetailService.GetXMProjectCostByData(ProjectId, int.Parse(year), ID);
                if (target.Count > 0)
                {
                    foreach (XMProjectCostDetail item in target)
                    {
                        if (FinancialFieldList.IndexOf(item.FinancialFieldID) != -1)
                        {
                            exist.Add(item);
                        }
                    }
                    info.MonthTarget += GetMonthData(exist, month, false);
                    info.YearTarget += GetMonthData(exist, "-1", true);
                }
            }
            info.ProjectId = ProjectId;
            return info;
        }

        public decimal GetMonthData(List<XMProjectCostDetail> list, string Month, bool Till)
        {
            decimal value = 0;
            int month = int.Parse(Month);
            List<decimal?> ValueList = new List<decimal?>();
            ValueList.Add(list.Sum(x => x.OneMonthCost));
            ValueList.Add(list.Sum(x => x.TwoMonthCost));
            ValueList.Add(list.Sum(x => x.ThreeMonthCost));
            ValueList.Add(list.Sum(x => x.FourMonthCost));
            ValueList.Add(list.Sum(x => x.FiveMonthCost));
            ValueList.Add(list.Sum(x => x.SixMonthCost));
            ValueList.Add(list.Sum(x => x.SevenMonthCost));
            ValueList.Add(list.Sum(x => x.EightMonthCost));
            ValueList.Add(list.Sum(x => x.NineMonthCost));
            ValueList.Add(list.Sum(x => x.TenMonthCost));
            ValueList.Add(list.Sum(x => x.ElevenMonthCost));
            ValueList.Add(list.Sum(x => x.TwelMonthCost));

            if (Till)
            {
                value = (decimal)ValueList.Sum();
            }
            else if (Month == "1")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "2")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "3")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "4")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "5")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "6")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "7")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "8")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "9")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "10")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "11")
            {
                value = (decimal)ValueList[month - 1];
            }
            else if (Month == "12")
            {
                value = (decimal)ValueList[month - 1];
            }
            return value;
        }

        public List<int> GetFinancialFieldListInTurn()
        {
            List<int> List = new List<int>();
            foreach (int info in FinancialFieldList)
            {
                var item = base.XMFinancialFieldService.GetXMFinancialFieldById(info);
                if (item != null && item.ParentID == 0)
                {
                    parent.Add(info);
                }
            }

            foreach (int info in parent)
            {
                List.Add(info);
                var list = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(info);
                if (list.Count > 0)
                {
                    foreach (XMFinancialField item in list)
                    {
                        if (FinancialFieldList.IndexOf(item.Id) != -1)
                        {
                            List.Add(item.Id);
                            son.Add(item.Id);
                        }
                    }
                }
            }
            return List;
        }

        public CWStaffSpendingMapping BeInitialization(CWStaffSpendingMapping Data)
        {
            Data.MonthTotal = 0;
            Data.YearTotal = 0;
            Data.MonthTarget = 0;
            Data.YearTarget = 0;
            Data.MonthReachRate = 0;
            Data.MonthGrowthRate = 0;
            Data.YearReachRate = 0;
            Data.YearGrowthRate = 0;
            Data.LastMonthTotal = 0;
            Data.LastYearTotal = 0;
            return Data;
        }

        /// <summary>
        /// 查询
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        public CWProfitModel GetAuxiliaryParameters(CWProfitModel model, int ProjectId, string year, string month)
        {
            model.ReturnMoney = GetProfitValue(114, ProjectId, year, month);
            model.ReturnCost = GetProfitValue(115, ProjectId, year, month);
            return model;
        }

        public decimal GetProfitValue(int FinancialFieldId, int ProjectId, string Year, string Month)
        {
            decimal value = 0;
            var cwProfitList = base.CWProfitService.GetCWProfitListByData(FinancialFieldId, ProjectId, Year, Month);
            if (cwProfitList.Count > 0)
            {
                value = (decimal)cwProfitList.Sum(x => x.CountMoney);
            }
            return value;
        }

        public CWProfitModel GetValue(CWProfitModel model, string year, string month, int FinancialFieldID, int ProjectId, int NickId, List<CWStaffSpending> CWStaffSpendingList, string cbNickId)
        {
            decimal value = 0;
            if (CWStaffSpendingList != null)
            {
                var a = CWStaffSpendingList.Where(x => x.FinancialFieldId == FinancialFieldID);
                if (a.Count() > 0)
                {
                    value = (decimal)(a.ToList())[0].CountMoney;
                }
            }

            //营业收入
            if (FinancialFieldID == 64)
            {
                model.BusinessIncome = value;
                if (value != 0)
                {
                    return model;
                }
                model.BusinessIncome = GetProfitValue(FinancialFieldID, ProjectId, year, month);
                value = model.BusinessIncome;
            }

            //进货成本
            if (FinancialFieldID == 78)
            {
                model.PurchaseCost = value;
                if (value != 0)
                {
                    return model;
                }
                model.PurchaseCost = GetProfitValue(FinancialFieldID, ProjectId, year, month);
                value = model.PurchaseCost;
            }

            //赠品成本
            if (FinancialFieldID == 79)
            {
                model.PremiumsCost = value;
                if (value != 0)
                {
                    return model;
                }
                model.PremiumsCost = GetProfitValue(FinancialFieldID, ProjectId, year, month);
                value = model.PremiumsCost;
            }

            //广告费用
            if (FinancialFieldID == 86)
            {
                model.AdvertisementFEE = value;
                if (value != 0)
                {
                    return model;
                }
                model.AdvertisementFEE = GetProfitValue(FinancialFieldID, ProjectId, year, month);
                value = model.AdvertisementFEE;
            }
            //平台费用
            if (FinancialFieldID == 107)
            {
                model.PlatformFee = value;
                if (value != 0)
                {
                    return model;
                }
                model.PlatformFee = GetProfitValue(FinancialFieldID, ProjectId, year, month);
                value = model.PlatformFee;
            }
            //刷拍成本
            if (FinancialFieldID == 109)
            {
                model.TakeBrush = value;
                if (value != 0)
                {
                    return model;
                }
                model.TakeBrush = GetProfitValue(FinancialFieldID, ProjectId, year, month);
                value = model.TakeBrush;
            }
            //返现成本
            if (FinancialFieldID == 110)
            {
                model.Cashback = value;
                if (value != 0)
                {
                    return model;
                }
                model.Cashback = GetProfitValue(FinancialFieldID, ProjectId, year, month);
                value = model.Cashback;
            }
            //运费
            if (FinancialFieldID == 108)
            {
                model.Freight = value;
                if (value != 0)
                {
                    return model;
                }

                //根据项目 查询运费比例 
                var xmproject = base.XMProjectService.GetXMProjectById(ProjectId);
                if (xmproject != null)
                {
                    if (xmproject.ShipmentProportion != null)
                    {
                        decimal ShipmentProportion = xmproject.ShipmentProportion.Value / 100;

                        model.Freight = Math.Round((model.BusinessIncome - model.ReturnMoney) * ShipmentProportion, 2);
                    }
                }
                value = model.Freight;
            }
            //运营部门人员工资
            if (FinancialFieldID == 89)
            {
                model.CountMoneySum1 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //运营部门人员社保
            if (FinancialFieldID == 90)
            {
                model.CountMoneySum2 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //运营部门人员奖金
            if (FinancialFieldID == 91)
            {
                model.CountMoneySum3 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //运营部门销售奖金
            if (FinancialFieldID == 111)
            {
                model.CountMoneySum4 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //差旅费
            if (FinancialFieldID == 98)
            {
                model.CountMoneySum5 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //办公费用
            if (FinancialFieldID == 101)
            {
                model.CountMoneySum6 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //其他费用
            if (FinancialFieldID == 100)
            {
                model.CountMoneySum7 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //固定资产折旧
            if (FinancialFieldID == 112)
            {
                model.CountMoneySum8 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //摊销费用
            if (FinancialFieldID == 113)
            {
                model.CountMoneySum9 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //广告费补贴
            if (FinancialFieldID == 71)
            {
                model.CountMoneySum10 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //增值税
            if (FinancialFieldID == 67)
            {
                model.ZZSMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.ZZSMoney = Math.Round((model.BusinessIncome - model.ReturnMoney - (model.PurchaseCost - model.ReturnCost)) / (decimal)1.17 * (decimal)0.17 - model.Freight / (decimal)1.06 * (decimal)0.06, 2);
                    value = model.ZZSMoney;
                    return model;
                }
            }
            //营业成本=进货成本+赠品成本+平台成本费用+运费+刷拍成本+返现成本+广告费
            if (FinancialFieldID == 66)
            {
                model.YYCBMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.YYCBMoney = Convert.ToDecimal(model.PurchaseCost - model.ReturnCost) + Convert.ToDecimal(model.PremiumsCost) + model.PlatformFee + model.Freight + Convert.ToDecimal(model.TakeBrush) + Convert.ToDecimal(model.Cashback) + Convert.ToDecimal(model.AdvertisementFEE);
                    value = model.YYCBMoney;
                    return model;
                }
            }
            //毛利=营业收入-增值税-营业成本
            if (FinancialFieldID == 68)
            {
                model.MLMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.MLMoney = Math.Round(model.BusinessIncome - model.ReturnMoney - Convert.ToDecimal(model.ZZSMoney) - Convert.ToDecimal(model.YYCBMoney));
                    value = model.MLMoney;
                    return model;
                }
            }
            //直接人工=运营部门人员工资+运营部门人员社保+运营部门人员奖金
            if (FinancialFieldID == 69)
            {
                model.ZJRGMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.ZJRGMoney = Math.Round(model.CountMoneySum1 + model.CountMoneySum2 + model.CountMoneySum3, 2);
                    value = model.ZJRGMoney;
                    return model;
                }
            }
            //营业费用=运营部门销售奖金+差旅费+办公费用+其他费用+固定资产折旧+摊销费用
            if (FinancialFieldID == 70)
            {
                model.YYFYMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.YYFYMoney = Math.Round(model.CountMoneySum4 + model.CountMoneySum5 + model.CountMoneySum6 + model.CountMoneySum7 + model.CountMoneySum8 + model.CountMoneySum9, 2);
                    value = model.YYFYMoney;
                    return model;
                }
            }
            //营业税金及附加=增值税*0.12+营业收入/1.17*0.001
            if (FinancialFieldID == 72)
            {
                model.YYSJMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.YYSJMoney = Math.Round(Convert.ToDecimal(model.ZZSMoney) * (decimal)0.12 + model.BusinessIncome / (decimal)1.17 * (decimal)0.001, 2);
                    value = model.YYSJMoney;
                    return model;
                }
            }
            //税前利润=毛利-直接人工-营业费用-营业税金及附加-广告费补贴-平台其他费用
            if (FinancialFieldID == 73)
            {
                model.SQLRMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.SQLRMoney = Math.Round(Convert.ToDecimal(model.MLMoney) - Convert.ToDecimal(model.ZJRGMoney)
                    - Convert.ToDecimal(model.YYFYMoney) - Convert.ToDecimal(model.YYSJMoney) - Convert.ToDecimal(model.CountMoneySum10), 2);
                    value = model.SQLRMoney;
                    return model;
                }
            }
            return model;
        }

        public decimal GetIntegratedManagementValue(int year, int month)
        {
            decimal Value = 0;
            foreach (int FinancialFieldId in IntegratedManagementIDList)
            {
                decimal value = 0;
                var Info = base.CWStaffSpendingService.GetCWStaffSpendingInfo("-1", -1, year.ToString(), month.ToString(), FinancialFieldId, 507);
                if (Info != null)
                {
                    value = (decimal)Info.CountMoney;
                }

                if (value == 0)
                {
                    var info = base.CWProfitService.GetCWProfitByData(FinancialFieldId, -1, -1, 507, year.ToString(), month.ToString());
                    if (info != null)
                    {
                        value = (decimal)info.CountMoney;
                    }
                }
                Value += value;
            }
            return Value;
        }

        public CWStaffSpendingMapping GetIntegratedManagementData(int year, int month)
        {
            //decimal YearTotal = 0;
            CWStaffSpendingMapping Info = new CWStaffSpendingMapping();
            Info.MonthTotal = -GetIntegratedManagementValue(year, month);
            Info.LastMonthTotal = -GetIntegratedManagementValue(year - 1, month);
            if (Info.LastMonthTotal != 0)
            {
                Info.MonthGrowthRate = (decimal)(Info.MonthTotal - Info.LastMonthTotal) / Info.LastMonthTotal;
            }
            else
            {
                Info.MonthGrowthRate = 0;
            }
            Info.YearStr = year.ToString();
            Info.MonthStr = month.ToString();

            //var target = GetData(FinancialFieldId, year.ToString(), month.ToString(), -1, 507);
            //Info.MonthTarget = (decimal)target.MonthTarget;
            //Info.YearTarget = (decimal)target.YearTarget;
            //DateTime end = new DateTime();
            //if (month == 12)
            //{
            //    end = DateTime.Parse((year + 1) + "/" + month.ToString() + "/01");
            //}
            //else
            //{
            //    end = DateTime.Parse(year + "/" + (month + 1).ToString() + "/01");
            //}
            //for (int i = 1; i <= 12; i++)
            //{
            //    DateTime begin = DateTime.Parse(year + "/" + i + "/01");
            //    if (begin < end)
            //    {
            //        YearTotal += GetIntegratedManagementValue(year, i);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            //Info.YearTotal = YearTotal;
            return Info;
        }
    }
}