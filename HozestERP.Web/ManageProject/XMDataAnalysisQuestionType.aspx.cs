using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.Web.Modules;
using HozestERP.Controls;
using System.Web.UI.HtmlControls;
using JdSdk.Domain;
using Top.Api.Domain;
using System.Transactions;
using HozestERP.BusinessLogic.ManageCustomerService;
using System.IO;

namespace HozestERP.Web.ManageProject
{
    public partial class XMDataAnalysisQuestionType : BaseAdministrationPage, ISearchPage
    {
        public List<XMDataAnalysy> xmConsultationAll;
        public List<XMDataAnalysy> xmConsultationTotal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
                {
                    List<XMProject> XMProjectList = base.XMProjectService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                    if (XMProjectList.Count > 0)
                    {
                        this.ddXMProject.Items.Clear();
                        this.ddXMProject.Items.Clear();
                        this.ddXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                        this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                        this.ddXMProject.Items[0].Selected = true;
                    }
                }
                else
                {
                    this.BindddXMProject();//项目  
                }
                this.BindGrid(1, Master.PageSize);

            }
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 522)
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                //.Where(c => c.ProjectTypeId == 362)
                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    this.ddXMProject.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                }
                if (projectList.Count() > 0)
                {
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                }
                // this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "99"));
            }
            #endregion
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 522)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue));
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    this.ddlNick.DataSource = nickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    //其他
                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue), HozestERPContext.Current.User.CustomerID, 0);
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    if (nickList.Count() == 0)
                    {
                        this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                    }
                    if (nickList.Count() > 0)
                    {
                        this.ddlNick.DataSource = nickList;
                        this.ddlNick.DataTextField = "nick";
                        this.ddlNick.DataValueField = "nick_id";
                        this.ddlNick.DataBind();
                    }
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "99"));
                }
            }
        }



        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;
            #region 售后客服
            //客服部DepCode
            //string DepCode = "HZ-005-1";//售前客服
            //this.ddlCustomerService.Items.Clear();
            //var CustomerServiceList = base.XMConsultationService.GetCustomerServiceList(DepCode);
            //this.ddlCustomerService.DataSource = CustomerServiceList;
            //this.ddlCustomerService.DataTextField = "FullName";
            //this.ddlCustomerService.DataValueField = "CustomerID";
            //this.ddlCustomerService.DataBind();
            //this.ddlCustomerService.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            #endregion

            #region 问题类型
            this.ddlQuestionType.Items.Clear();
            //获取所有父节点问题类型
            var categoryList = base.XMQuestionCategoryService.GetXMQuestionCategoryPrarentList(0);
            this.ddlQuestionType.DataSource = categoryList;
            this.ddlQuestionType.DataTextField = "CategoryName";
            this.ddlQuestionType.DataValueField = "Id";
            this.ddlQuestionType.DataBind();
            this.ddlQuestionType.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            #endregion

            #region 问题等级
            //this.ddlQuestionLevel.Items.Clear();
            //var QuestionLevelList = base.CodeService.GetCodeListInfoByCodeTypeID(213, false);
            //this.ddlQuestionLevel.DataSource = QuestionLevelList;
            //this.ddlQuestionLevel.DataTextField = "CodeName";
            //this.ddlQuestionLevel.DataValueField = "CodeID";
            //this.ddlQuestionLevel.DataBind();
            //this.ddlQuestionLevel.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            #endregion

            this.txtBeginDate.ctlDateTime.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "-01";
            this.txtEndDate.ctlDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");


            if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
            {
                List<XMProject> XMProjectList = base.XMProjectService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                if (XMProjectList.Count > 0)
                {
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                    this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                    this.ddXMProject.Items[0].Selected = true;
                }
            }
            else
            {
                this.BindddXMProject();//项目  
            }
            this.ddlNick.Items.Clear();
            this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            if (string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()) || string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
            {
                base.ShowMessage("请输入开始日期和结束日期！");
                return;
            }

            if (!string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("请输入结束日期！");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("请输入开始日期！");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim())
                && !string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
            {
                DateTime dt = new DateTime();
                if (!DateTime.TryParse(txtBeginDate.ctlDateTime.Text.Trim(), out dt))
                {
                    base.ShowMessage("开始日期输入错误！");
                    return;
                }
                if (!DateTime.TryParse(txtEndDate.ctlDateTime.Text.Trim(), out dt))
                {
                    base.ShowMessage("结束日期输入错误！");
                    return;
                }

                if (DateTime.Parse(txtEndDate.ctlDateTime.Text.Trim()) < DateTime.Parse(txtBeginDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("结束日期不能小于开始日期！");
                    return;
                }
            }
            this.BindGrid(paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
        }

        public void BindGrid(int paramPageIndex, int paramPageSize, string sortExpression, string sortDirection)
        {
            int No = 1;
            var BeginDate = this.txtBeginDate.SelectedDate;
            var EndDate = this.txtEndDate.SelectedDate;
            var QuestionType = this.ddlQuestionType.SelectedValue;
            List<int?> questionTypeIDs = new List<int?>();     //子节点集合
            if (Convert.ToInt16(QuestionType) > 0)
            {
                var questionType = base.XMQuestionCategoryService.GetXMQuestionCategoryById(int.Parse(QuestionType));
                if (questionType != null)
                {
                    //查询该父节点下子节点列表
                    var childQuestion = base.XMQuestionCategoryService.GetXMQuestionCategoryByParentID(questionType.Id);
                    if (childQuestion != null && childQuestion.Count() > 0)
                    {
                        foreach (XMQuestionCategory str in childQuestion)
                        {
                            questionTypeIDs.Add(str.Id);
                        }
                    }
                }
            }
            List<XMDataAnalysy> List = new List<XMDataAnalysy>();
            List<XMDataAnalysy> ALL = new List<XMDataAnalysy>();
            //选择问题类型了
            if (int.Parse(QuestionType) > 0)
            {
                //获取选定问题类型信息
                var f = base.XMQuestionCategoryService.GetXMQuestionCategoryById(int.Parse(QuestionType));
                if (f != null)
                {
                    XMDataAnalysy record = new XMDataAnalysy();
                    int no = 1;
                    int total = 0;
                    record.ID = No;
                    record.QuestionType = f.Id;
                    record.ParentQuestionTypeName = f.CategoryName;
                    //查询该父节点下的所有子节点
                    var cCategoryList = base.XMQuestionCategoryService.GetXMQuestionCategoryPrarentList(f.Id);      //该节点下所有子节点
                    if (cCategoryList != null)
                    {
                        int sum = getPCategoryCount(f.Id, BeginDate, EndDate);
                        foreach (var t in cCategoryList)
                        {
                            XMDataAnalysy one = new XMDataAnalysy();
                            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
                            int nickID = -1;
                            int.TryParse(this.ddlNick.SelectedValue, out nickID);
                            string nickids = "";
                            if (nickID == 99) //某个项目店铺权限，选择有权限的店铺
                            {
                                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), xMProjectId, HozestERPContext.Current.User.CustomerID, 0);
                                for (int i = 0; i < nickList.Count; i++)
                                {
                                    nickids = nickids + nickList[i].nick_id + ",";
                                }
                                if (nickids.Length > 0)
                                {
                                    nickids = nickids.Substring(0, nickids.Length - 1);
                                }
                            }
                            else
                            {
                                nickids = nickID.ToString();
                            }
                            var info = base.XMQuestionDetailService.GetQuestionDetailsByParm(xMProjectId, nickids, BeginDate, EndDate, t.Id);
                            if (info != null && info.Count() > 0)
                            {
                                total += info.Count();
                                one.ID = no;
                                one.NickId = nickID;
                                one.QuestionType = info[0].QuestionTypeID;
                                int count = info.Count();
                                one.TotalRate = sum != 0 ? Math.Round(count / decimal.Parse(sum.ToString()), 4) : 0;
                                string rate = (Math.Round(one.TotalRate * 100, 2)).ToString() + "%";
                                one.DealCount = info.Count;
                                ALL.Add(one);
                                no++;
                                record.DetailTab = record.DetailTab + "<tr><td>" + one.ID.ToString() + "</td><td>" + info[0].QuestionCategoryType
                           + "</td><td>" + one.DealCount + "</td><td>" + rate + "</td></tr>";
                            }
                        }
                    }
                    record.DealCount = total;
                    List.Add(record);
                }
            }
            else               //所有
            {
                var pCategoryList = base.XMQuestionCategoryService.GetXMQuestionCategoryByParentID(0);      //查询所有父节点
                //遍历父节点
                foreach (var q in pCategoryList)
                {
                    XMDataAnalysy record = new XMDataAnalysy();
                    int no = 1;
                    int total = 0;
                    record.ID = No;
                    record.QuestionType = q.Id;
                    record.ParentQuestionTypeName = q.CategoryName;
                    No++;
                    //查询该父节点下的所有子节点
                    var cCategoryList = base.XMQuestionCategoryService.GetXMQuestionCategoryPrarentList(q.Id);      //该节点下所有子节点
                    if (cCategoryList != null)
                    {
                        int sum = getPCategoryCount(q.Id, BeginDate, EndDate);
                        foreach (var t in cCategoryList)
                        {
                            XMDataAnalysy one = new XMDataAnalysy();
                            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
                            int nickID = -1;
                            int.TryParse(this.ddlNick.SelectedValue, out nickID);
                            string nickids = "";
                            if (nickID == 99) //某个项目店铺权限，选择有权限的店铺
                            {
                                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), xMProjectId, HozestERPContext.Current.User.CustomerID, 0);
                                for (int i = 0; i < nickList.Count; i++)
                                {
                                    nickids = nickids + nickList[i].nick_id + ",";
                                }
                                if (nickids.Length > 0)
                                {
                                    nickids = nickids.Substring(0, nickids.Length - 1);
                                }
                            }
                            else
                            {
                                nickids = nickID.ToString();
                            }
                            var info = base.XMQuestionDetailService.GetQuestionDetailsByParm(xMProjectId, nickids, BeginDate, EndDate, t.Id);
                            if (info != null && info.Count() > 0)
                            {
                                total += info.Count();
                                one.ID = no;
                                one.NickId = nickID;
                                one.QuestionType = info[0].QuestionTypeID;
                                int count = info.Count();
                                one.TotalRate = sum != 0 ? Math.Round(count / decimal.Parse(sum.ToString()), 4) : 0;
                                string rate = (Math.Round(one.TotalRate * 100, 2)).ToString() + "%";
                                one.DealCount = info.Count;
                                ALL.Add(one);
                                no++;
                                record.DetailTab = record.DetailTab + "<tr><td>" + one.ID.ToString() + "</td><td>" + info[0].QuestionCategoryType
                           + "</td><td>" + one.DealCount + "</td><td>" + rate + "</td></tr>";
                            }
                        }
                    }
                    record.DealCount = total;
                    List.Add(record);
                }
            }
            xmConsultationTotal = List;
            xmConsultationAll = ALL;
            var pageList = new PagedList<XMDataAnalysy>(List, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.gvQuestion, pageList, paramPageSize + 1);
        }

        #endregion

        //获取相应父节点问题个数
        private int getPCategoryCount(int QuestionType, DateTime? BeginDate, DateTime? EndDate)
        {
            int total = 0;
            List<int?> questionTypeIDs = new List<int?>();     //子节点集合
            //查询该父节点下子节点列表
            var childQuestion = base.XMQuestionCategoryService.GetXMQuestionCategoryByParentID(QuestionType);
            if (childQuestion != null && childQuestion.Count() > 0)
            {
                foreach (XMQuestionCategory str in childQuestion)
                {
                    questionTypeIDs.Add(str.Id);
                }
            }
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
            int nickID = -1;
            int.TryParse(this.ddlNick.SelectedValue, out nickID);
            string nickids = "";
            if (nickID == 99) //某个项目店铺权限，选择有权限的店铺
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), xMProjectId, HozestERPContext.Current.User.CustomerID, 0);
                for (int i = 0; i < nickList.Count; i++)
                {
                    nickids = nickids + nickList[i].nick_id + ",";
                }
                if (nickids.Length > 0)
                {
                    nickids = nickids.Substring(0, nickids.Length - 1);
                }
            }
            else
            {
                nickids = nickID.ToString();
            }
            if (questionTypeIDs.Count() > 0)
            {
                var details = base.XMQuestionDetailService.GetQuestionDetailByCategoryIDs(xMProjectId, nickids, BeginDate, EndDate, questionTypeIDs);
                if (details != null)
                {
                    total = details.Count();
                }
            }
            return total;
        }

        protected void hidBtnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        //导出
        protected void btnDaochu_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    var BeginDate = this.txtBeginDate.SelectedDate;
                    var EndDate = this.txtEndDate.SelectedDate;
                    string DateRange = ((DateTime)BeginDate).ToString("yyyy-MM-dd") + "to" + ((DateTime)EndDate).ToString("yyyy-MM-dd");
                    string fileName = string.Format("DataAnalysy_" + DateRange + "_{0}{1}.xls", DateTime.Now.ToString("yyMMddHHmmssfff"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\DataAnalysyQuestionType", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    this.BindGrid(Master.PageIndex, Master.PageSize);
                    int nickid = Convert.ToInt16(ddlNick.SelectedValue);
                    base.ExportManager.ExportDataAnalysisXlsQuestionType(filePath, xmConsultationAll, xmConsultationTotal, nickid);

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
