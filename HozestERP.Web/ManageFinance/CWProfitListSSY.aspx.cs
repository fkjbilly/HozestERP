using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
    public partial class CWProfitListSSY : BaseAdministrationPage, ISearchPage
    {
        CWProfitListSSYTool tool = new CWProfitListSSYTool();
        CWProfitModel MonthData = new CWProfitModel();
        CWProfitModel YearData = new CWProfitModel();
        List<int> parent = new List<int>();
        List<int> son = new List<int>();
        List<int> FinancialFieldList = new List<int>();
        List<int> IntegratedManagementIDList = new List<int>();//为管理费用的营业费用字段

        int[] SpecialID = { 64, 71 };//营业收入，广告费补贴ID
        int[] UnSetting = { 67, 68, 72, 73, 70, 74, 106, 66, 69, 63 };//不可填字段ID
        int[] NickSetting = { 64, 78, 79, 107, 109, 110 };//选择店铺时可填字段ID
        int[] ProjectSetting = { 108, 89, 90, 91, 111, 98, 101, 100, 112, 113, 71, 148 };//不选择店铺时可填字段ID

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["CWProfitListSSY-Year-Mark"] = "";
                Session["CWProfitListSSY-Month-Mark"] = "";
                this.txtYearStr.Value = DateTime.Now.Year.ToString();
                this.txtMonthStr.Value = DateTime.Now.Month.ToString();
                this.BindData();
            }
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            #region 平台类型绑定
            //平台类型动态数据绑定
            //this.ddlPlatformTypeId.Items.Clear();
            //var codeLists = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            //this.ddlPlatformTypeId.DataSource = codeLists;
            //this.ddlPlatformTypeId.DataTextField = "CodeName";
            //this.ddlPlatformTypeId.DataValueField = "CodeID";
            //this.ddlPlatformTypeId.DataBind();
            //this.ddlPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion

            #region 项目类型绑定

            //项目类型绑定
            this.ddlXMProjectTypeId.Items.Clear();
            var codeProjectTypeLists = base.CodeService.GetCodeListInfoByCodeTypeID(189, false);
            var codenew = codeProjectTypeLists.Where(p => p.CodeID == 362);
            this.ddlXMProjectTypeId.DataSource = codenew;
            this.ddlXMProjectTypeId.DataTextField = "CodeName";
            this.ddlXMProjectTypeId.DataValueField = "CodeID";
            this.ddlXMProjectTypeId.DataBind();
            //this.ddlXMProjectTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion

            #region 部门类型绑定

            //部门类型绑定
            this.ddlDepartmentType.Items.Clear();
            var DepartmentTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(1, false);
            this.ddlDepartmentType.DataSource = DepartmentTypeList;
            this.ddlDepartmentType.DataTextField = "CodeName";
            this.ddlDepartmentType.DataValueField = "CodeID";
            this.ddlDepartmentType.DataBind();
            this.ddlDepartmentType.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion

            #region 项目名称绑定

            ////项目名称绑定--选取自运营项目
            //if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            //{
            //    this.ddlXMProjectNameId.Items.Clear();
            //    var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362);

            //    this.ddlXMProjectNameId.DataSource = projectList;
            //    this.ddlXMProjectNameId.DataTextField = "ProjectName";
            //    this.ddlXMProjectNameId.DataValueField = "Id";
            //    this.ddlXMProjectNameId.DataBind();
            //    //this.ddlXMProjectNameId.Items.Add(new ListItem("B2B", "B2B"));
            //    //this.ddlXMProjectNameId.Items.Add(new ListItem("B2C", "B2C"));
            //    this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //}
            //else
            //{
            //    this.ddlXMProjectNameId.Items.Clear();
            //    var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362)
            //        .GroupBy(p => new { p.Id, p.ProjectName })
            //        .Select(p => new
            //    {
            //        Id = p.Key.Id,
            //        ProjectName = p.Key.ProjectName
            //    });

            //    this.ddlXMProjectNameId.DataSource = projectList;
            //    this.ddlXMProjectNameId.DataTextField = "ProjectName";
            //    this.ddlXMProjectNameId.DataValueField = "Id";
            //    this.ddlXMProjectNameId.DataBind();
            //    //this.ddlXMProjectNameId.Items.Add(new ListItem("B2B", "B2B"));
            //    //this.ddlXMProjectNameId.Items.Add(new ListItem("B2C", "B2C"));
            //    this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //}
            this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));

            #endregion

            #region 店铺名称绑定

            //店铺数据源 
            //if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            //{
            //    this.ddlNickList.Items.Clear();
            //    var NickList = base.XMNickService.GetXMNickList();
            //    var newNickList = NickList.Where(p => p.isEnable == true).ToList();
            //    this.ddlNickList.DataSource = newNickList;
            //    this.ddlNickList.DataTextField = "nick";
            //    this.ddlNickList.DataValueField = "nick_id";
            //    this.ddlNickList.DataBind();
            //    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
            //}
            //else
            //{
            //    //其他
            //    var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362);
            //    if (xMNickList.Count > 0)
            //    {
            //        this.ddlNickList.Items.Clear();
            //        this.ddlNickList.DataSource = xMNickList;
            //        this.ddlNickList.DataTextField = "nick";
            //        this.ddlNickList.DataValueField = "nick_id";
            //        this.ddlNickList.DataBind();
            //        this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }
            //}
            this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));

            #endregion
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
        }

        public void GetB2BC(int departmentType, List<int?> NickIdList, string year, string month, string mark)
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
            MonthData = tool.AccumulationValue(MonthData, monthData);

            if (mark == Session["CWProfitListSSY-Year-Mark"].ToString())
            {
                YearData = (CWProfitModel)Session["CWProfitListSSY-Year-Data"];
            }
            else
            {
                DateTime end = DateTime.Now;
                if (int.Parse(year) == DateTime.Now.Year)
                {
                    end = DateTime.Parse(year + "/" + DateTime.Now.Month + "/01").AddMonths(1);
                }
                else
                {
                    end = DateTime.Parse(int.Parse(year) + 1 + "/01/01");
                }
                for (int i = 1; i <= 12; i++)
                {
                    DateTime begin = DateTime.Parse(year + "/" + i + "/01");
                    if (begin < end)
                    {
                        CWStaffSpendingList = tool.GetAllResult(FinancialFieldList, year, i.ToString(), -1, departmentType, -1);
                        foreach (int ID in son)
                        {
                            monthData = tool.B2BOrB2C(monthData, ID, NickIdList, year, i.ToString(), -1, departmentType, CWStaffSpendingList);
                        }
                        foreach (int ID in parent)
                        {
                            monthData = tool.B2BOrB2C(monthData, ID, NickIdList, year, i.ToString(), -1, departmentType, CWStaffSpendingList);
                        }
                        YearData = tool.AccumulationValue(YearData, monthData);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public decimal GetIntegratedManagementValue(int year, int month, int FinancialFieldId)
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
            return value;
        }

        public CWStaffSpendingMapping GetIntegratedManagementData(int year, int month, int FinancialFieldId)
        {
            decimal YearTotal = 0;
            CWStaffSpendingMapping Info = new CWStaffSpendingMapping();
            Info.MonthTotal = GetIntegratedManagementValue(year, month, FinancialFieldId);
            var target = GetData(FinancialFieldId, year.ToString(), month.ToString(), -1, 507);
            Info.MonthTarget = (decimal)target.MonthTarget;
            Info.YearTarget = (decimal)target.YearTarget;

            DateTime end = DateTime.Now;
            if (year == DateTime.Now.Year)
            {
                end = DateTime.Parse(year + "/" + DateTime.Now.Month + "/01").AddMonths(1);
            }
            else
            {
                end = DateTime.Parse(year + 1 + "/01/01");
            }

            for (int i = 1; i <= 12; i++)
            {
                DateTime begin = DateTime.Parse(year + "/" + i + "/01");
                if (begin < end)
                {
                    YearTotal += GetIntegratedManagementValue(year, i, FinancialFieldId);
                }
                else
                {
                    break;
                }
            }

            Info.YearTotal = YearTotal;
            return Info;
        }

        public List<CWStaffSpendingMapping> GetIntegratedManagementData(List<CWStaffSpendingMapping> data, CWStaffSpendingMapping Info, int Index)
        {
            if (Index != -1)
            {
                data[Index].MonthTotal += Info.MonthTotal;
                data[Index].YearTotal += Info.YearTotal;
            }
            else
            {
                data.Add(Info);
            }

            if (data[Index].FinancialFieldId != 158 && data[Index].FinancialFieldId != 159 && data[Index].FinancialFieldId != 160)
            {
                foreach (CWStaffSpendingMapping info in data)
                {
                    if (info.FinancialFieldId == 70)
                    {
                        info.MonthTotal += Info.MonthTotal;
                        info.YearTotal += Info.YearTotal;
                    }
                    if (info.FinancialFieldId == 73)
                    {
                        info.MonthTotal -= Info.MonthTotal;
                        info.YearTotal -= Info.YearTotal;
                    }
                }
            }
            return data;
        }

        private void BindData()
        {
            #region 条件查询
            //部门类型
            string DepartmentType = this.ddlDepartmentType.SelectedValue.Trim();

            //平台类型
            //string PlatformTypeId = this.ddlPlatformTypeId.SelectedValue.Trim();

            //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
            var cbOrderStatusId = "3";//this.ddlOrderStatus.SelectedValue.Trim();

            //项目类型： 自运营、代运营
            string cbXMProjectTypeId = this.ddlXMProjectTypeId.SelectedValue.Trim();

            //项目名称
            string cbXMProject = this.ddlXMProjectNameId.SelectedValue.Trim();

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

            //绑定数据
            List<CWStaffSpendingMapping> data = new List<CWStaffSpendingMapping>();
            List<CWStaffSpendingMapping> Data = new List<CWStaffSpendingMapping>();

            //店铺集合
            string cbNick = this.ddlNickList.SelectedValue.ToString();

            List<int> nickIdList = new List<int>();
            List<int?> NickIdList = new List<int?>();

            #region 店铺条件查询集合 处理
            //选择某项目
            if (DepartmentType == "-1" || DepartmentType == "505")
            {
                if (cbXMProject != "-1")
                {
                    if (cbNick == "-1")//项目下的所有店铺
                    {
                        var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(cbXMProject), Convert.ToInt32(cbXMProjectTypeId));
                        if (nickList.Count > 0)
                        {
                            nickIdList = nickList.Select(p => p.nick_id).ToList();
                        }
                    }
                    else
                    {
                        nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                    }
                }
                else
                {
                    if (cbNick == "-1")
                    {
                        var NickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(cbXMProject), Convert.ToInt32(cbXMProjectTypeId));
                        nickIdList = NickList.Select(a => a.nick_id).ToList();
                    }
                    else
                    {
                        nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                    }
                }
            }
            #endregion

            #region 店铺平台筛选
            //if (PlatformTypeId != "-1")
            //{
            //    var PlatformTypeNickList = base.XMNickService.GetMyNickListByProjectNick(int.Parse(PlatformTypeId), int.Parse(cbXMProject));
            //    if (PlatformTypeNickList.Count > 0)
            //    {
            //        List<int> nickList = new List<int>();
            //        for (int i = 0; i < nickIdList.Count(); i++)
            //        {
            //            foreach (XMNick info in PlatformTypeNickList)
            //            {
            //                if (nickIdList[i] == info.nick_id)
            //                {
            //                    nickList.Add(nickIdList[i]);
            //                    break;
            //                }
            //            }
            //        }
            //        nickIdList = nickList;
            //    }
            //    else
            //    {
            //        nickIdList = new List<int>();
            //    }
            //}
            #endregion

            foreach (int nick in nickIdList)
            {
                NickIdList.Add(nick);
            }

            string year = this.txtYearStr.Value.Trim();
            string month = this.txtMonthStr.Value.Trim();

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

            int ProjectId = 0;
            CWProfitModel monthData = new CWProfitModel();
            string mark = DepartmentType + "-" + cbXMProject + "-" + cbNick + "-" + cbOrderStatusId + year;

            if (DepartmentType != "505")
            {
                if (DepartmentType == "197")//B2C
                {
                    GetB2BC(197, NickIdList, year, month, mark);
                }
                else if (DepartmentType == "6")//B2B
                {
                    GetB2BC(6, NickIdList, year, month, mark);
                }
                else if (DepartmentType != "507")
                {
                    GetB2BC(197, NickIdList, year, month, mark);
                    GetB2BC(6, NickIdList, year, month, mark);
                }
            }

            if (DepartmentType == "505" || DepartmentType == "-1")//家居事业部,所有
            {
                ProjectId = int.Parse(cbXMProject);
                foreach (int nick in nickIdList)
                {
                    List<CWStaffSpending> NickSettingDataList = tool.GetAllResult(NickSetting.ToList(), year, month, ProjectId, -1, nick);
                    monthData = new CWProfitModel();
                    monthData = tool.GetAuxiliaryParameters(monthData, ProjectId, nick, year, month);
                    foreach (int ID in NickSetting)
                    {
                        monthData = tool.GetValue(monthData, year, month, ID, ProjectId, nick, NickSettingDataList, cbNick, cbXMProjectTypeId);
                    }
                    MonthData = tool.AccumulationValue(MonthData, monthData);
                }
                List<CWStaffSpending> ProjectSettingDataList = tool.GetAllResult(ProjectSetting.ToList(), year, month, ProjectId, -1, -1);
                MonthData = tool.AddOfflineData(MonthData, nickIdList, year, month);
                foreach (int ID in ProjectSetting)
                {
                    MonthData = tool.GetValue(MonthData, year, month, ID, ProjectId, -1, ProjectSettingDataList, cbNick, cbXMProjectTypeId);
                }
                foreach (int ID in parent)
                {
                    MonthData = tool.GetValue(MonthData, year, month, ID, ProjectId, int.Parse(cbNick), null, "", cbXMProjectTypeId);
                }

                if (mark == Session["CWProfitListSSY-Year-Mark"].ToString())
                {
                    YearData = (CWProfitModel)Session["CWProfitListSSY-Year-Data"];
                }
                else
                {
                    DateTime end = DateTime.Now;
                    if (int.Parse(year) == DateTime.Now.Year)
                    {
                        end = DateTime.Parse(year + "/" + DateTime.Now.Month + "/01").AddMonths(1);
                    }
                    else
                    {
                        end = DateTime.Parse(int.Parse(year) + 1 + "/01/01");
                    }
                    for (int i = 1; i <= 12; i++)
                    {
                        DateTime begin = DateTime.Parse(year + "/" + i + "/01");
                        if (begin < end)
                        {
                            CWProfitModel MonthCacheData = new CWProfitModel();
                            foreach (int nick in nickIdList)
                            {
                                List<CWStaffSpending> NickSettingDataList = tool.GetAllResult(NickSetting.ToList(), year, i.ToString(), ProjectId, -1, nick);
                                monthData = new CWProfitModel();
                                monthData = tool.GetAuxiliaryParameters(monthData, ProjectId, nick, year, i.ToString());
                                foreach (int ID in NickSetting)
                                {
                                    monthData = tool.GetValue(monthData, year, i.ToString(), ID, ProjectId, nick, NickSettingDataList, cbNick, cbXMProjectTypeId);
                                }
                                MonthCacheData = tool.AccumulationValue(MonthCacheData, monthData);
                            }
                            ProjectSettingDataList = new List<CWStaffSpending>();
                            ProjectSettingDataList = tool.GetAllResult(ProjectSetting.ToList(), year, i.ToString(), ProjectId, -1, -1);
                            MonthCacheData = tool.AddOfflineData(MonthCacheData, nickIdList, year, i.ToString());
                            foreach (int ID in ProjectSetting)
                            {
                                MonthCacheData = tool.GetValue(MonthCacheData, year, i.ToString(), ID, ProjectId, -1, ProjectSettingDataList, cbNick, cbXMProjectTypeId);
                            }
                            foreach (int ID in parent)
                            {
                                MonthCacheData = tool.GetValue(MonthCacheData, year, i.ToString(), ID, ProjectId, int.Parse(cbNick), null, "", cbXMProjectTypeId);
                            }

                            YearData = tool.AccumulationValue(YearData, MonthCacheData);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            if (mark != Session["CWProfitListSSY-Year-Mark"].ToString())
            {
                Session["CWProfitListSSY-Year-Mark"] = mark;
                Session["CWProfitListSSY-Month-Mark"] = month;
            }
            else
            {
                if (month != Session["CWProfitListSSY-Month-Mark"].ToString())
                {
                    Session["CWProfitListSSY-Month-Mark"] = month;
                }
                else
                {
                    monthData = (CWProfitModel)Session["CWProfitListSSY-Month-Data"];
                    Type MonthDataType = MonthData.GetType();
                    Type monthDataType = monthData.GetType();
                    System.Reflection.PropertyInfo[] Ps = MonthDataType.GetProperties();
                    System.Reflection.PropertyInfo[] ps = monthDataType.GetProperties();
                    foreach (System.Reflection.PropertyInfo Property in Ps)
                    {
                        foreach (System.Reflection.PropertyInfo property in ps)
                        {
                            if (Property.Name == property.Name && (decimal)Property.GetValue(MonthData, null) != (decimal)property.GetValue(monthData, null))
                            {
                                decimal value = (decimal)Property.GetValue(MonthData, null) - (decimal)property.GetValue(monthData, null);
                                Type YearDataType = YearData.GetType();
                                System.Reflection.PropertyInfo[] PS = YearDataType.GetProperties();
                                foreach (System.Reflection.PropertyInfo PROPERTY in PS)
                                {
                                    if (PROPERTY.Name == property.Name)
                                    {
                                        decimal Value = (decimal)property.GetValue(YearData, null) + value;
                                        PROPERTY.SetValue(YearData, Value, null);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Session["CWProfitListSSY-Month-Data"] = MonthData;
            Session["CWProfitListSSY-Year-Data"] = YearData;

            foreach (int ID in son)
            {
                data.Add(GetData(ID, year, month, int.Parse(cbXMProject), int.Parse(DepartmentType)));
            }
            foreach (int ID in parent)
            {
                data.Add(GetData(ID, year, month, int.Parse(cbXMProject), int.Parse(DepartmentType)));
            }
            data = tool.GetCompleteData(data, MonthData, YearData);

            //综管的数据
            CWStaffSpendingMapping FinanceFee = new CWStaffSpendingMapping();
            FinanceFee.FinancialFieldId = 666;
            FinanceFee.MonthTotal = 0;
            FinanceFee.YearTotal = 0;
            FinanceFee.MonthTarget = 0;
            FinanceFee.YearTarget = 0;
            List<CWStaffSpendingMapping> FinanceFeeList = new List<CWStaffSpendingMapping>();
            if (DepartmentType == "507" || DepartmentType == "-1")//综管,所有
            {
                List<int?> dataFinancialFieldId = data.Select(x => x.FinancialFieldId).ToList();
                if (IntegratedManagementIDList.Count() > 0)
                {
                    foreach (int item in IntegratedManagementIDList)
                    {
                        CWStaffSpendingMapping Info = GetIntegratedManagementData(int.Parse(year), int.Parse(month), item);
                        if (dataFinancialFieldId.IndexOf(item) != -1)
                        {
                            int Index = dataFinancialFieldId.IndexOf(item);
                            data = GetIntegratedManagementData(data, Info, Index);
                        }
                        else
                        {
                            Info.FinancialFieldId = item;
                            data = GetIntegratedManagementData(data, Info, -1);
                        }

                        if (item == 158 || item == 159 || item == 160)//利息收入,利息支出,手续费
                        {
                            FinanceFee.MonthTotal += Info.MonthTotal;
                            FinanceFee.YearTotal += Info.YearTotal;
                            FinanceFee.MonthTarget += Info.MonthTarget;
                            FinanceFee.YearTarget += Info.YearTarget;
                        }
                    }
                    FinanceFeeList.Add(FinanceFee);
                }
            }

            for (int i = 0; i < data.Count(); i++)
            {
                if (data[i].FinancialFieldId == 158 || data[i].FinancialFieldId == 159 || data[i].FinancialFieldId == 160)//利息收入,利息支出,手续费
                {
                    FinanceFeeList.Add(data[i]);
                    data.Remove(data[i]);
                    i--;
                }
            }

            bool HaveAdd = false;
            foreach (int id in FinancialFieldList)
            {
                foreach (CWStaffSpendingMapping one in data)
                {
                    if (id == one.FinancialFieldId)
                    {
                        if (id == 71)//广告费补贴
                        {
                            HaveAdd = true;
                            Data.AddRange(FinanceFeeList);
                        }

                        Data.Add(one);
                        break;
                    }
                }
            }
            if (!HaveAdd)
            {
                Data.AddRange(FinanceFeeList);
            }

            var BindList = new PagedList<CWStaffSpendingMapping>(Data, 1, 100, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, BindList);
        }

        public CWStaffSpendingMapping GetData(int ID, string year, string month, int ProjectId, int DepartmentType)
        {
            List<XMProjectCostDetail> exist = new List<XMProjectCostDetail>();
            CWStaffSpendingMapping info = new CWStaffSpendingMapping();
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
                    info.MonthTarget = GetMonthData(exist, month);
                    info.YearTarget = GetMonthData(exist, "-1");
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
                    info.MonthTarget += GetMonthData(exist, month);
                    info.YearTarget += GetMonthData(exist, "-1");
                }
            }
            return info;
        }

        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var Info = e.Row.DataItem as CWStaffSpendingMapping;
                string DepartmentType = this.ddlDepartmentType.SelectedValue.Trim();
                string ProjectId = this.ddlXMProjectNameId.SelectedValue.Trim();
                string NickId = this.ddlNickList.SelectedValue.ToString();
                string Year = this.txtYearStr.Value.Trim();
                string Month = this.txtMonthStr.Value.Trim();

                //B2C的金立
                if (DepartmentType == "197" && ProjectId != "-1")
                {
                    DepartmentType = "505";//家居事业部
                }

                if (DepartmentType != "-1")
                {
                    if (DepartmentType == "505" && ProjectId != "-1")
                    {
                        if (NickId == "-1")
                        {
                            if (ProjectSetting.Contains((int)Info.FinancialFieldId))
                            {
                                e.Row.Attributes.Add("ondblclick", "return ShowWindowDetail('" + Title + "','" + CommonHelper.GetStoreLocation()
                               + "ManageFinance/OpenProfitOtherDataInput.aspx?DepartmentType=" + DepartmentType + "&ProjectId=" + ProjectId
                            + "&NickId=" + NickId + "&Year=" + Year + "&Month=" + Month + "&FinancialFieldId=" + Info.FinancialFieldId + "',440,225, this, function(){document.getElementById('"
                            + this.btnSearch.ClientID + "').click();});");
                            }
                        }
                        else
                        {
                            if (NickSetting.Contains((int)Info.FinancialFieldId))
                            {
                                e.Row.Attributes.Add("ondblclick", "return ShowWindowDetail('" + Title + "','" + CommonHelper.GetStoreLocation()
                               + "ManageFinance/OpenProfitOtherDataInput.aspx?DepartmentType=" + DepartmentType + "&ProjectId=" + ProjectId
                            + "&NickId=" + NickId + "&Year=" + Year + "&Month=" + Month + "&FinancialFieldId=" + Info.FinancialFieldId + "',440,225, this, function(){document.getElementById('"
                            + this.btnSearch.ClientID + "').click();});");
                            }
                        }
                    }
                    else if (DepartmentType != "505")
                    {
                        if (!UnSetting.Contains((int)Info.FinancialFieldId) || (DepartmentType == "6" && Info.FinancialFieldId == 66)
                            || (DepartmentType == "6" && Info.FinancialFieldId == 63) || (DepartmentType == "507" && IntegratedManagementIDList.IndexOf((int)Info.FinancialFieldId) != -1))
                        {
                            e.Row.Attributes.Add("ondblclick", "return ShowWindowDetail('" + Title + "','" + CommonHelper.GetStoreLocation()
                                   + "ManageFinance/OpenProfitOtherDataInput.aspx?DepartmentType=" + DepartmentType + "&ProjectId=" + ProjectId
                                + "&NickId=" + NickId + "&Year=" + Year + "&Month=" + Month + "&FinancialFieldId=" + Info.FinancialFieldId + "',440,225, this, function(){document.getElementById('"
                                + this.btnSearch.ClientID + "').click();});");
                        }
                    }
                }

                if (parent.IndexOf((int)Info.FinancialFieldId) != -1 || SpecialID.Contains((int)Info.FinancialFieldId) == true || Info.FinancialFieldId == 666)
                {
                    e.Row.Font.Bold = true;
                    e.Row.Font.Size = 11;
                    //e.Row.BackColor = Color.FromName("#BFBFBF");
                }

                DateTime min = DateTime.Parse(this.txtYearStr.Value + "-" + this.txtMonthStr.Value + "-" + "01");
                DateTime imax = DateTime.Parse(this.txtYearStr.Value + "-" + this.txtMonthStr.Value + "-" + "01").AddMonths(1).AddDays(-1);
                string PlatformTypeId = "-1";// this.ddlPlatformTypeId.SelectedValue.Trim();
                //查看详情
                ImageButton imgInfoDetail = e.Row.FindControl("imgInfoDetail") as ImageButton;
                if (imgInfoDetail != null)
                {
                    bool show = false;
                    #region  订单明细
                    if (Info.FinancialFieldId == 64)
                    {
                        imgInfoDetail.OnClientClick = "return ShowWindowDetail('订单明细','" + CommonHelper.GetStoreLocation()
                        + "ManageFinance/OrderInfoDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
                        + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
                        + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
                        + "&NickId=" + this.ddlNickList.SelectedValue
                        + "&OrderStatusId=3"// + this.ddlOrderStatus.SelectedValue
                        + "&min=" + min
                        + "&max=" + imax
                        + "', 1200, 690, this, function(){});";
                        show = true;
                    }
                    #endregion

                    #region  进货成本
                    if (Info.FinancialFieldId == 78)
                    {
                        imgInfoDetail.OnClientClick = "return ShowWindowDetail('产品明细','" + CommonHelper.GetStoreLocation()
                        + "ManageFinance/OrderInfoProductDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
                        + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
                        + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
                        + "&NickId=" + this.ddlNickList.SelectedValue
                        + "&OrderStatusId=3"// + this.ddlOrderStatus.SelectedValue
                        + "&min=" + min
                        + "&max=" + imax
                        + "', 1200, 700, this, function(){});";
                        show = true;
                    }
                    #endregion

                    #region  赠品明细
                    if (Info.FinancialFieldId == 79)
                    {
                        imgInfoDetail.OnClientClick = "return ShowWindowDetail('赠品明细','" + CommonHelper.GetStoreLocation()
                        + "ManageFinance/PremiumsDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
                        + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
                        + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
                        + "&NickId=" + this.ddlNickList.SelectedValue
                        + "&OrderStatusId=3"// + this.ddlOrderStatus.SelectedValue
                        + "&min=" + min
                        + "&max=" + imax
                        + "', 1000, 500, this, function(){});";
                        show = true;
                    }
                    #endregion

                    #region 平台费用明细
                    if (Info.FinancialFieldId == 107)
                    {
                        imgInfoDetail.OnClientClick = "return ShowWindowDetail('平台费用明细','" + CommonHelper.GetStoreLocation()
                        + "ManageFinance/CWPlatformSpendingDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
                        + "&min=" + min
                        + "&max=" + imax
                        + "&NickId=" + this.ddlNickList.SelectedValue
                        + "&OrderStatusId=3"// + this.ddlOrderStatus.SelectedValue
                        + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
                        + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
                        + "', 1000, 620, this, function(){});";
                        show = true;
                    }
                    #endregion

                    #region  刷单明细
                    if (Info.FinancialFieldId == 109)
                    {
                        imgInfoDetail.OnClientClick = "return ShowWindowDetail('刷单明细','" + CommonHelper.GetStoreLocation()
                        + "ManageFinance/XMScalpingDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
                        + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
                        + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
                        + "&NickId=" + this.ddlNickList.SelectedValue
                        + "&OrderStatusId=3"// + this.ddlOrderStatus.SelectedValue
                        + "&min=" + min
                        + "&max=" + imax
                        + "', 1000, 500, this, function(){});";
                        show = true;
                    }
                    #endregion

                    #region  返现明细
                    if (Info.FinancialFieldId == 110)
                    {
                        imgInfoDetail.OnClientClick = "return ShowWindowDetail('返现明细','" + CommonHelper.GetStoreLocation()
                        + "ManageFinance/XMCashBackApplicationDetailsSS.aspx?PlatformTypeId=" + PlatformTypeId
                        + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
                        + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
                        + "&NickId=" + this.ddlNickList.SelectedValue
                        + "&OrderStatusId=3"// + this.ddlOrderStatus.SelectedValue
                        + "&min=" + min
                        + "&max=" + imax
                        + "', 1000, 500, this, function(){});";
                        show = true;
                    }
                    #endregion

                    #region  广告费用
                    if (Info.FinancialFieldId == 86)
                    {
                        imgInfoDetail.OnClientClick = "return ShowWindowDetail('广告费用','" + CommonHelper.GetStoreLocation()
                        + "ManageFinance/XWAdvertisingSS.aspx?ProjectId=" + this.ddlXMProjectNameId.SelectedValue
                        + "&NickId=" + this.ddlNickList.SelectedValue
                        + "&DateTimeMin=" + min
                        + "&DateTimeMax=" + imax
                        + "', 1000, 500, this, function(){});";
                        show = true;
                    }
                    #endregion

                    if (!show)
                    {
                        imgInfoDetail.Visible = false;
                    }
                }
            }
        }

        public decimal GetMonthData(List<XMProjectCostDetail> list, string Month)
        {
            decimal value = 0;
            if (Month == "-1")
            {
                value = (decimal)(list.Sum(x => x.OneMonthCost) + list.Sum(x => x.TwoMonthCost) + list.Sum(x => x.ThreeMonthCost) + list.Sum(x => x.FourMonthCost) + list.Sum(x => x.FiveMonthCost)
                    + list.Sum(x => x.SixMonthCost) + list.Sum(x => x.SevenMonthCost) + list.Sum(x => x.EightMonthCost) + list.Sum(x => x.NineMonthCost) + list.Sum(x => x.TenMonthCost)
                    + list.Sum(x => x.ElevenMonthCost) + list.Sum(x => x.TwelMonthCost));
            }
            else if (Month == "1")
            {
                value = (decimal)list.Sum(x => x.OneMonthCost);
            }
            else if (Month == "2")
            {
                value = (decimal)list.Sum(x => x.TwoMonthCost);
            }
            else if (Month == "3")
            {
                value = (decimal)list.Sum(x => x.ThreeMonthCost);
            }
            else if (Month == "4")
            {
                value = (decimal)list.Sum(x => x.FourMonthCost);
            }
            else if (Month == "5")
            {
                value = (decimal)list.Sum(x => x.FiveMonthCost);
            }
            else if (Month == "6")
            {
                value = (decimal)list.Sum(x => x.SixMonthCost);
            }
            else if (Month == "7")
            {
                value = (decimal)list.Sum(x => x.SevenMonthCost);
            }
            else if (Month == "8")
            {
                value = (decimal)list.Sum(x => x.EightMonthCost);
            }
            else if (Month == "9")
            {
                value = (decimal)list.Sum(x => x.NineMonthCost);
            }
            else if (Month == "10")
            {
                value = (decimal)list.Sum(x => x.TenMonthCost);
            }
            else if (Month == "11")
            {
                value = (decimal)list.Sum(x => x.ElevenMonthCost);
            }
            else if (Month == "12")
            {
                value = (decimal)list.Sum(x => x.TwelMonthCost);
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

        /// <summary>
        /// 项目类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlXMProjectTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue) > 0)
            {
                var ProjectTypeList = base.XMProjectService.GetXMProjectProjectTypeId(Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));
                this.ddlXMProjectNameId.Items.Clear();
                this.ddlXMProjectNameId.DataSource = ProjectTypeList;
                this.ddlXMProjectNameId.DataTextField = "ProjectName";
                this.ddlXMProjectNameId.DataValueField = "Id";
                this.ddlXMProjectNameId.DataBind();
                this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlXMProjectNameId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ProjectId = this.ddlXMProjectNameId.SelectedValue.Trim();
            this.ddlNickList.Items.Clear();
            if (ProjectId != "B2B" && ProjectId != "B2C")
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(ProjectId));
                    //this.ddlNickList.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    this.ddlNickList.DataSource = nickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    //this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    //其他
                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(ProjectId), HozestERPContext.Current.User.CustomerID, 362);
                    //this.ddlNickList.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    this.ddlNickList.DataSource = nickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    //this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }
            this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));

            //this.BindData();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOrderInfoSalesDetailsExport_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                string filePath = string.Format("{0}Upload\\OrderInfoSalesDetailsExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                #region 条件查询

                //平台类型
                string PlatformTypeId = "-1";
                //if (this.ddlPlatformTypeId.SelectedValue != null)
                //{
                //    PlatformTypeId = this.ddlPlatformTypeId.SelectedValue.ToString();
                //}
                DateTime OrderInfoModifiedStart = DateTime.Parse(this.txtYearStr.Value + "-" + this.txtMonthStr.Value + "-" + "01");
                DateTime OrderInfoModifiedEnd = DateTime.Parse(this.txtYearStr.Value + "-" + this.txtMonthStr.Value + "-" + "01").AddMonths(1).AddSeconds(-1);


                DateTime dt1 = DateTime.Now;//当前时间 
                DateTime dt = Convert.ToDateTime(dt1.ToString("yyyy-MM-dd"));

                //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
                var cbOrderStatusId = "3";//this.ddlOrderStatus.SelectedValue;


                //项目类型： 自运营、代运营
                string cbXMProjectTypeId = "-1";

                if (this.ddlXMProjectTypeId.SelectedValue != null)
                {
                    cbXMProjectTypeId = this.ddlXMProjectTypeId.SelectedValue.ToString();
                }


                //项目名称
                string cbXMProject = "-1";
                if (this.ddlXMProjectNameId.SelectedValue != null)
                {
                    cbXMProject = this.ddlXMProjectNameId.SelectedValue.ToString();
                }
                string cbNick = "-1";

                if (this.ddlNickList.SelectedValue != null)
                {
                    cbNick = this.ddlNickList.SelectedValue.ToString();
                }

                //店铺集合
                List<int> nickIdList = new List<int>();

                #region 店铺条件查询集合 处理
                //选择某项目  
                if (cbXMProject != "-1")
                {
                    if (cbNick == "-1")//项目下的所有店铺
                    {
                        var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                        if (nickList.Count > 0)
                        {
                            nickIdList = nickList.Select(p => p.nick_id).ToList();
                        }
                    }
                    else
                    {

                        nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                    }
                }
                else
                {
                    if (cbNick == "-1")
                    {
                        var NickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                        nickIdList = NickList.Select(a => a.nick_id).ToList();
                    }
                    else
                    {
                        nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                    }

                }
                #endregion

                #region
                if (PlatformTypeId != "-1")
                {
                    var PlatformTypeNickList = base.XMNickService.GetXMNickListByPlatformType(int.Parse(PlatformTypeId));
                    if (PlatformTypeNickList.Count > 0)
                    {
                        for (int i = 0; i < nickIdList.Count(); i++)
                        {
                            bool exist = false;
                            foreach (XMNick info in PlatformTypeNickList)
                            {
                                if (nickIdList[i] == info.nick_id)
                                {
                                    exist = true;
                                    break;
                                }
                            }
                            if (!exist)
                            {
                                nickIdList.Remove(nickIdList[i]);
                            }
                        }
                    }
                    else
                    {
                        nickIdList = new List<int>();
                    }
                }
                #endregion

                #endregion

                #region 订单明细
                var xmOrderInfoList = base.XMOrderInfoService.getXMOrderInfoList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId), "");

                #region 取京东数据 （销售额=应收金额+配送运费）
                var OrderInfoJdList = (from p in xmOrderInfoList
                                       where p.PlatformTypeId == 251
                                       select new OrderInfoSalesDetails
                                       {
                                           ID = p.ID,
                                           PlatformTypeId = p.PlatformTypeId,
                                           NickID = p.NickID,
                                           OrderCode = p.OrderCode,
                                           WantID = p.WantID,
                                           OrderInfoCreateDate = p.OrderInfoCreateDate,
                                           PayDate = p.PayDate,
                                           DeliveryTime = p.DeliveryTime,
                                           CompletionTime = p.CompletionTime,
                                           FullName = p.FullName,
                                           Mobile = p.Mobile,
                                           Tel = p.Tel,
                                           DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                                           ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                                           PayPrice = p.ReceivablePrice + p.DistributePrice,
                                           SalesPrice = 0,
                                           ProjectId = p.ProjectId,
                                           ProjectName = p.ProjectName,
                                           PlatformTypeName = p.PlatformTypeName,
                                           NickName = p.NickName
                                       }).ToList();
                #endregion

                #region 排除京东数据
                var OrderInfoNotJdList = (from p in xmOrderInfoList
                                          where p.PlatformTypeId != 251
                                          select new OrderInfoSalesDetails
                                          {
                                              ID = p.ID,
                                              PlatformTypeId = p.PlatformTypeId,
                                              NickID = p.NickID,
                                              OrderCode = p.OrderCode,
                                              WantID = p.WantID,
                                              OrderInfoCreateDate = p.OrderInfoCreateDate,
                                              PayDate = p.PayDate,
                                              DeliveryTime = p.DeliveryTime,
                                              CompletionTime = p.CompletionTime,
                                              FullName = p.FullName,
                                              Mobile = p.Mobile,
                                              Tel = p.Tel,
                                              DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                                              ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                                              PayPrice = p.PayPrice,
                                              SalesPrice = 0,
                                              ProjectId = p.ProjectId,
                                              ProjectName = p.ProjectName,
                                              PlatformTypeName = p.PlatformTypeName,
                                              NickName = p.NickName
                                          }).ToList();

                #endregion

                //合并数据源

                var OrderInfoListNew = OrderInfoJdList.Concat(OrderInfoNotJdList).OrderByDescending(p => p.OrderCode).ToList();

                #endregion

                #region 产品明细

                //原数据源

                var OrderInfoSalesDetailsList = base.XMOrderInfoProductDetailsService.GetOrderInfoSalesDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId));

                //去掉重复订单 数据源
                var OrderInfoSalesDetailsListNew = OrderInfoSalesDetailsList.GroupBy(p => p.OrderCode).Select(g => g.First()).ToList();

                // 取出重复订单
                var NotDate = (from a in OrderInfoSalesDetailsList
                               where !OrderInfoSalesDetailsListNew.Contains(a)
                               select new OrderInfoSalesDetails
                               {
                                   ID = a.ID,
                                   OrderCode = a.OrderCode,
                                   PlatformTypeId = a.PlatformTypeId,
                                   DeliveryTime = a.DeliveryTime,
                                   PayDate = a.PayDate,
                                   DetailsID = a.DetailsID,
                                   PlatformMerchantCode = a.PlatformMerchantCode,
                                   ProductName = a.ProductName,
                                   Specifications = a.Specifications,
                                   ProductNum = a.ProductNum,
                                   FactoryPrice = a.FactoryPrice,
                                   PayPrice = 0,
                                   NickID = a.NickID,
                                   PlatformTypeName = a.PlatformTypeName,
                                   ProjectId = a.ProjectId,
                                   ProjectName = a.ProjectName,
                                   NickName = a.NickName,
                                   ManufacturersCode = a.ManufacturersCode,
                                   ProductId = a.ProductId
                               }).ToList();

                var OrderInfoSalesDetailsListDealWithNew = OrderInfoSalesDetailsListNew.Concat(NotDate).OrderByDescending(p => p.OrderCode).ToList();

                #endregion

                #region 产品统计
                List<OrderInfoSalesDetails> ProductSalesDetailsList =
                              OrderInfoSalesDetailsList.GroupBy(g => new { g.ProductName }).
                              Select(group => new OrderInfoSalesDetails()
                              {
                                  ProductName = group.Key.ProductName,
                                  FactoryPrice = group.Sum(l => l.FactoryPrice),
                                  ProductNum = group.Sum(l => l.ProductNum),
                                  AvgFactoryPrice = Math.Round(group.Sum(l => l.FactoryPrice.Value) / Convert.ToDecimal(group.Sum(l => l.ProductNum)), 2)
                              }).ToList();

                #endregion

                #region 返现明细
                List<OrderInfoSalesDetails> XMCashBackApplicationDetailsList = base.XMCashBackApplicationService.GetXMCashBackApplicationDetailsList(
              Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32(cbOrderStatusId));

                #endregion

                #region 刷单记录明细

                //刷单记录明细
                List<OrderInfoSalesDetails> XMScalpingDetailsList = base.XMScalpingService.GetXMScalpingDetailsList
                   (Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId));

                #endregion

                #region 赠品明细


                //赠品明细
                var XMOrderInfoAndPremiumsDetailsList = base.XMOrderInfoService.getXMOrderInfoAndPremiumsDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId));

                #endregion

                //退换货明细
                var XMApplication = base.XMApplicationService.GetXMEXList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd));

                //退货明细
                var BackProductDetails = base.XMOrderInfoProductDetailsService.GetBackProductDetails(Convert.ToInt32(PlatformTypeId), nickIdList, "", OrderInfoModifiedStart, OrderInfoModifiedEnd, Convert.ToInt32(cbOrderStatusId));

                base.ExportManager.ExportOrderInfoSalesDetailsXls(filePath, OrderInfoListNew, OrderInfoSalesDetailsListDealWithNew, ProductSalesDetailsList, XMCashBackApplicationDetailsList, XMScalpingDetailsList, XMOrderInfoAndPremiumsDetailsList, XMApplication, BackProductDetails);

                CommonHelper.WriteResponseXls(filePath, fileName);

            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }

        protected void ddlDepartmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<XMProject> ProjectList = new List<XMProject>();
            int DepartmentTypeID = int.Parse(this.ddlDepartmentType.SelectedValue);
            var DepartmentTypeList = base.EnterpriseService.GetDepartmentListByDepType(DepartmentTypeID);
            if (DepartmentTypeList.Count > 0)
            {
                foreach (Department Info in DepartmentTypeList)
                {
                    var projectList = base.XMProjectService.GetXMProjectListByDepID(Info.DepartmentID);
                    if (projectList.Count > 0)
                    {
                        ProjectList.AddRange(projectList);
                    }
                }
            }

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddlXMProjectNameId.Items.Clear();
                //var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362);
                ProjectList = ProjectList.Where(c => c.ProjectTypeId == 362).ToList();
                this.ddlXMProjectNameId.DataSource = ProjectList;
                this.ddlXMProjectNameId.DataTextField = "ProjectName";
                this.ddlXMProjectNameId.DataValueField = "Id";
                this.ddlXMProjectNameId.DataBind();
                //this.ddlXMProjectNameId.Items.Add(new ListItem("B2B", "B2B"));
                //this.ddlXMProjectNameId.Items.Add(new ListItem("B2C", "B2C"));
                //this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                List<int> list = ProjectList.Select(p => p.Id).ToList();
                this.ddlXMProjectNameId.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362)
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
                this.ddlXMProjectNameId.DataSource = projectList;
                this.ddlXMProjectNameId.DataTextField = "ProjectName";
                this.ddlXMProjectNameId.DataValueField = "Id";
                this.ddlXMProjectNameId.DataBind();
                //this.ddlXMProjectNameId.Items.Add(new ListItem("B2B", "B2B"));
                //this.ddlXMProjectNameId.Items.Add(new ListItem("B2C", "B2C"));
                //this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
        }
    }
}