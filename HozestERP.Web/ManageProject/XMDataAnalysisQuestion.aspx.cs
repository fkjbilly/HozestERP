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
    public partial class XMDataAnalysisQuestion : BaseAdministrationPage, ISearchPage
    {
        public List<XMDataAnalysy> xmConsultationAll;
        public List<XMDataAnalysy> xmConsultationTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
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

            #region 店铺名称绑定

            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 522)
            {
                this.ddlNick.Items.Clear();
                var NickList = base.XMNickService.GetXMNickList();
                var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                if (newNickList.Count() > 0)
                {
                    this.ddlNick.DataSource = newNickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }
            else
            {
                var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                if (xMNickList.Count() == 0)
                {
                    this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                }
                if (xMNickList.Count > 0)
                {
                    this.ddlNick.Items.Clear();
                    this.ddlNick.DataSource = xMNickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-2"));
                }
            }

            #endregion

            #region 平台类型
            //平台类型动态数据绑定
            this.ddlPlatform.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatform.DataSource = codeList;
            this.ddlPlatform.DataTextField = "CodeName";
            this.ddlPlatform.DataValueField = "CodeID";
            this.ddlPlatform.DataBind();
            this.ddlPlatform.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));
            #endregion

            #region 售后客服
            //客服部DepCode
            string DepCode = "QC1403-3,QC1403-4,QC1506-2";//售前客服
            this.ddlCustomerService.Items.Clear();
            var CustomerServiceList = base.XMConsultationService.GetCustomerServiceList(DepCode);
            this.ddlCustomerService.DataSource = CustomerServiceList;
            this.ddlCustomerService.DataTextField = "FullName";
            this.ddlCustomerService.DataValueField = "CustomerID";
            this.ddlCustomerService.DataBind();
            this.ddlCustomerService.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));
            this.ddlCustomerService.Items.Insert(1, new ListItem("未接单", "0"));

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
            this.ddlQuestionLevel.Items.Clear();
            var QuestionLevelList = base.CodeService.GetCodeListInfoByCodeTypeID(213, false);
            this.ddlQuestionLevel.DataSource = QuestionLevelList;
            this.ddlQuestionLevel.DataTextField = "CodeName";
            this.ddlQuestionLevel.DataValueField = "CodeID";
            this.ddlQuestionLevel.DataBind();
            this.ddlQuestionLevel.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            #endregion

            this.txtBeginDate.ctlDateTime.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "-01";
            this.txtEndDate.ctlDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            var PlatformId = int.Parse(this.ddlPlatform.SelectedValue);
            var NickId = int.Parse(this.ddlNick.SelectedValue);
            var BeginDate = this.txtBeginDate.SelectedDate;
            var EndDate = this.txtEndDate.SelectedDate;
            var CustomerId = this.ddlCustomerService.SelectedValue;
            var QuestionType = this.ddlQuestionType.SelectedValue;
            var QuestionLevel = this.ddlQuestionLevel.SelectedValue;
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
            var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
            List<int?> a = new List<int?> { };
            if (NickId == -2)
            {
                foreach (var list in xMNickList)
                {
                    a.Add(list.nick_id);
                }
            }

            //查出对应问题列表  （问题类型为子节点类型）
            //var Questionlist = base.XMQuestionService.GetDataAnalysisList(PlatformId, NickId, BeginDate, EndDate, int.Parse(CustomerId), a, int.Parse(QuestionType), int.Parse(QuestionLevel));
            var Questionlist = base.XMQuestionService.GetQuestionAnalysisList(PlatformId, NickId, BeginDate, EndDate, int.Parse(CustomerId), a, questionTypeIDs, int.Parse(QuestionLevel));
            List<XMDataAnalysy> List = new List<XMDataAnalysy>();
            List<XMDataAnalysy> ALL = new List<XMDataAnalysy>();
            var Group_CreatorID = Questionlist.GroupBy(x => new { x.CreatorID });
            foreach (var Info in Group_CreatorID)
            {
                int no = 1;
                //int DealTotal = 0;
                //int ProcessingCount = 0;
                decimal TimeTotal = 0;
                int TimeCount = 0;
                XMDataAnalysy record = new XMDataAnalysy();
                var InfoList = Info.ToList<XMDataAnalysy>();
                record.ID = No;
                record.CreatorID = InfoList[0].CreatorID;
                No++;
                if (int.Parse(ddlQuestionType.SelectedValue) > 0)
                {
                    var group = InfoList.GroupBy(x => new { x.PlatformTypeId, x.NickId, x.QuestionLevel });
                    foreach (var data in group)
                    {
                        var info = data.ToList<XMDataAnalysy>();
                        List<string> CustomerIDList = new List<string>();
                        XMDataAnalysy one = new XMDataAnalysy();
                        one.ID = no;
                        one.PlatformTypeId = info[0].PlatformTypeId;
                        one.NickId = info[0].NickId;
                        one.CreatorID = info[0].CreatorID;
                        one.QuestionType = info[0].QuestionType;
                        one.QuestionLevel = info[0].QuestionLevel;
                        one.DealCount = info.Count;
                        ALL.Add(one);
                        no++;
                        string QuestionLevelName = one.QuestionLevelName == null ? "" : one.QuestionLevelName.CodeName;
                        string QuestionTypeName = one.QuestionTypeName == null ? "" : one.QuestionTypeName.CodeName;
                        record.DetailTab = record.DetailTab + "<tr><td>" + one.ID.ToString() + "</td><td>" + one.PlatformType + "</td><td>" + one.NickName
                            + "</td><td>" + one.ParentQuestionTypeName + "</td><td>" + QuestionLevelName + "</td><td>" + one.DealCount + "</td></tr>";
                        //DealTotal = DealTotal + one.DealCount;
                    }
                }
                else//选择所有
                {
                    var group = InfoList.GroupBy(x => new { x.PlatformTypeId, x.NickId, x.ParentQuestionType, x.QuestionLevel });
                    List<XMDataAnalysy> List2 = new List<XMDataAnalysy>();
                    foreach (var data in group)
                    {
                        string categoryName = string.Empty;
                        var info = data.ToList<XMDataAnalysy>();

                        XMDataAnalysy one = new XMDataAnalysy();
                        one.ID = no;
                        one.PlatformTypeId = info[0].PlatformTypeId;
                        one.NickId = info[0].NickId;
                        one.CreatorID = info[0].CreatorID;
                        one.QuestionType = info[0].QuestionType;
                        one.QuestionLevel = info[0].QuestionLevel;
                        one.DealCount = info.Count;
                        ALL.Add(one);
                        no++;
                        string QuestionLevelName = one.QuestionLevelName == null ? "" : one.QuestionLevelName.CodeName;
                        string QuestionTypeName = info[0].QuestionCategoryName;
                        var f = base.XMQuestionCategoryService.GetXMQuestionCategoryById(info[0].ParentQuestionType);
                        if (f != null)
                        {
                            categoryName = f.CategoryName;
                        }
                        record.DetailTab = record.DetailTab + "<tr><td>" + one.ID.ToString() + "</td><td>" + one.PlatformType + "</td><td>" + one.NickName
                            + "</td><td>" + categoryName + "</td><td>" + QuestionLevelName + "</td><td>" + one.DealCount + "</td></tr>";
                        //DealTotal = DealTotal + one.DealCount;
                    }
                }

                record.DealCount = 0;//数量
                record.ProcessingCount = 0;//处理中数量
                record.CompleteRate = 0;//完成率
                record.OrderAmount = 0;//订单金额
                List<int> questionIdList = InfoList.Select(x => x.QuestionID).Distinct().ToList();
                var QuestionList = base.XMQuestionService.GetQuestionsListByIDs(questionIdList);
                if (QuestionList != null && QuestionList.Count > 0)
                {
                    record.DealCount = QuestionList.Count;
                    var processingCount = QuestionList.Where(x => x.Status == (int)QuestionStatusEnum.Deal || x.Status == (int)QuestionStatusEnum.Submit);
                    if (processingCount != null && processingCount.Count() > 0)
                    {
                        record.ProcessingCount = processingCount.Count();
                    }
                    var completeCount = QuestionList.Where(x => x.Status == (int)QuestionStatusEnum.Complete);
                    if (completeCount != null && completeCount.Count() > 0)
                    {
                        record.CompleteCount = completeCount.Count();
                        record.CompleteRate = Math.Round(decimal.Parse(completeCount.Count().ToString()) / decimal.Parse(record.DealCount.ToString()), 4);

                        List<string> orderCodeList = completeCount.Select(x => x.OrderNO).Distinct().ToList();
                        var OrderList = base.XMOrderInfoService.GetXMOrderInfoByOrderCodeList(orderCodeList);
                        if (OrderList != null && OrderList.Count > 0)
                        {
                            record.OrderAmount = (decimal)OrderList.Sum(x => x.PayPrice);
                        }
                    }
                }

                //处理中问题数量
                foreach (var data in InfoList)
                {
                    //if (data.Status == (int)QuestionStatusEnum.Deal)
                    //{
                    //    ProcessingCount++;
                    //}
                    if (data.Status == (int)QuestionStatusEnum.Complete)
                    {
                        if (!data.IsReturns)
                        {
                            TimeCount++;
                            TimeSpan ts = (TimeSpan)(data.LastModifyTime - data.OrdersTime);
                            TimeTotal += (decimal)ts.TotalHours;
                        }
                    }
                }
                //record.ProcessingCount = ProcessingCount;
                if (TimeCount > 0)
                {
                    record.TimeEfficiency = Math.Round((TimeTotal / TimeCount), 2);
                }
                else
                {
                    record.TimeEfficiency = 0;
                }

                //int CompleteCount = base.XMQuestionService.GetCompleteCount(Questionlist, (int)InfoList[0].CreatorID, "Complete");
                //record.CompleteRate = Math.Round(decimal.Parse(CompleteCount.ToString()) / decimal.Parse(DealTotal.ToString()), 4);
                int ReturnCount = base.XMQuestionService.GetCompleteCount(Questionlist, (int)InfoList[0].CreatorID, "ReturnCount");
                int ReturnTotal = base.XMQuestionService.GetCompleteCount(Questionlist, (int)InfoList[0].CreatorID, "ReturnTotal");
                //实际退货数量
                record.RealReturnCount = ReturnCount;
                record.ReturnTotal = ReturnTotal;
                //申请退货问题数量
                record.ApplicationReturnCount = ReturnTotal;

                if (ReturnTotal != 0)
                {
                    record.ReturnRate = Math.Round(decimal.Parse((ReturnTotal - ReturnCount).ToString()) / decimal.Parse(ReturnTotal.ToString()), 4);
                }
                else
                {
                    record.ReturnRate = 0;
                }
                List.Add(record);
            }
            xmConsultationTotal = List;
            xmConsultationAll = ALL;
            var pageList = new PagedList<XMDataAnalysy>(List, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.gvQuestion, pageList, paramPageSize + 1);
        }

        #endregion

        protected void hidBtnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        private decimal SumDealCount = 0;    //数量
        private decimal SumProcessingCount = 0;    //处理中数量
        private decimal SumApplicationReturnCount = 0;   //申请退货数量
        private decimal SumCompleteCount = 0;     //完成数量
        private decimal CompleteRate = 0;    //完成率
        private decimal SumTimeEfficiency = 0;    //时效
        private decimal SumOrderAmount = 0;   //订单金额
        private decimal SumRealReturnCount = 0;  //实际退货数量
        private decimal SumReturnTotal = 0;
        private decimal ReturnRate = 0;     //退货挽回率

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int rowIndex = e.Row.RowIndex;
                var info = e.Row.DataItem as XMDataAnalysy;
                int currentPage = this.Master.PageIndex;
                int pageCount = this.Master.PageSize;
                if (rowIndex >= 0 && rowIndex < pageCount)
                {
                    int ADealCount = info.DealCount;
                    SumDealCount += ADealCount;
                    int AProcessingCount = info.ProcessingCount;
                    SumProcessingCount += AProcessingCount;
                    int ASumApplicationReturnCount = info.ApplicationReturnCount;
                    SumApplicationReturnCount += ASumApplicationReturnCount;
                    int AcompleteCount = info.CompleteCount;
                    SumCompleteCount += AcompleteCount;
                    if (SumDealCount != 0)
                    {
                        CompleteRate = Math.Round(SumCompleteCount / SumDealCount, 2) * 100;
                    }
                    decimal ATimeEfficiency = info.TimeEfficiency;
                    SumTimeEfficiency += ATimeEfficiency;
                    decimal AOrderAcount = info.OrderAmount;
                    SumOrderAmount += AOrderAcount;
                    decimal ARealReturnCount = info.RealReturnCount;
                    SumRealReturnCount += ARealReturnCount;
                    decimal AReturnTotal = info.ReturnTotal;
                    SumReturnTotal += AReturnTotal;
                    if (SumReturnTotal != 0)
                    {
                        ReturnRate = Math.Round((SumReturnTotal - SumRealReturnCount) / SumReturnTotal, 2) * 100;
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                Literal ltADealCount = e.Row.Cells[3].FindControl("lblSumDealCount") as Literal;
                ltADealCount.Text = SumDealCount.ToString();

                Literal ltAProcessingCount = e.Row.Cells[4].FindControl("lblSumProcessingCount") as Literal;
                ltAProcessingCount.Text = SumProcessingCount.ToString();

                Literal ltApplicationReturnCount = e.Row.Cells[5].FindControl("lblSumApplicationReturnCount") as Literal;
                ltApplicationReturnCount.Text = SumApplicationReturnCount.ToString();

                Literal lblCompleteRate = e.Row.Cells[6].FindControl("lblCompleteRate") as Literal;
                lblCompleteRate.Text = CompleteRate.ToString() + "%";

                Literal lblTimeEfficiency = e.Row.Cells[7].FindControl("lblTimeEfficiency") as Literal;
                lblTimeEfficiency.Text = SumTimeEfficiency.ToString();

                Literal lblSumOrderAmount = e.Row.Cells[8].FindControl("lblSumOrderAmount") as Literal;
                lblSumOrderAmount.Text = SumOrderAmount.ToString();

                Literal lblRealReturnCount = e.Row.Cells[9].FindControl("lblRealReturnCount") as Literal;
                lblRealReturnCount.Text = SumRealReturnCount.ToString();

                Literal lblReturnRate = e.Row.Cells[10].FindControl("lblReturnRate") as Literal;
                lblReturnRate.Text = ReturnRate.ToString() + "%";
            }
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
                    string filePath = string.Format("{0}Upload\\DataAnalysyQuestion", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    this.BindGrid(Master.PageIndex, Master.PageSize);
                    base.ExportManager.ExportDataAnalysisXlsQuestion(filePath, xmConsultationAll, xmConsultationTotal);

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
