using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.Controls;
using HozestERP.Web.Modules;
using JdSdk.Domain;
using Top.Api.Domain;

namespace HozestERP.Web.ManageProject
{
    public partial class Question : BaseAdministrationPage, ISearchPage
    {
        private int childindex = -1;
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            { 

                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnSearch", "Question.Search");
                buttons.Add("btnExport", "ManageProject.Question.Export");//导出数据
                buttons.Add("imgBtnList", "Question.GridView.ListEdit");//问题反馈主表编辑按钮
                buttons.Add("ImgBtnCR", "Question.GridView.CommunicationRecord");//沟通记录
                buttons.Add("imgBtnDelete", "Question.GridView.Delete");//单条删除 
                buttons.Add("imgBtnDealEdit", "QuestionEdit.GridView.Edit");//问题反馈—明细编辑按钮  
                buttons.Add("imgBtnDirector", "QuestionEdit.GridView.DirectorEdit");//问题反馈—明细总监编辑按钮
                buttons.Add("imgBtnDealUpload", "QuestionEdit.GridView.Upload");//问题反馈—明细上传按钮 
                buttons.Add("imgBtnDealDelete", "QuestionEdit.GridView.Delete");//问题反馈—明细删除按钮 
                buttons.Add("imgBtnDealUpdate", "QuestionEdit.GridView.Save");//问题反馈—明细保存按钮 
                buttons.Add("imgBtnDealCancel", "QuestionEdit.GridView.Cancel");//问题反馈—明细取消按钮   
                buttons.Add("imgBtnUpdate", "Question.GridView.Save");//问题反馈主表保存
                buttons.Add("imgBtnCancel", "Question.GridView.Cancel");//问题反馈主表取消
                buttons.Add("btnDelete", "ManageProject.Question.AllDelete");//批量删除
                buttons.Add("btnTransfer", "ManageProject.Question.Transfer");//移交
                //buttons.Add("imgBtnDealPremiums", "QuestionEdit.GridView.Premiums");//问题处理—明细赠品生成按钮 
                //buttons.Add("imgBtnDealCashBack", "QuestionEdit.GridView.CashBack");//问题处理—明细赠品、返现生成按钮 
                buttons.Add("imgBtnDealPayment", "QuestionEdit.GridView.Payment");//问题处理—明细赔付生成按钮
                buttons.Add("ImageButton1", "ManageApplication.Add");//问题处理—生成退换货申请单
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (QuestionType == "feedback")
                {
                    this.DIVExport.Visible = false;
                    //this.DIVTransfer.Visible = false;
                    this.DIVCompleteRateResult.Visible = false;
                    this.ddlTheResults.Enabled = false;
                    this.DIVDelete.Visible = true;
                }
                else if (QuestionType == "dealwith")
                {
                    this.DIVExport.Visible = true;
                    //this.DIVTransfer.Visible = true;
                    this.DIVCompleteRateResult.Visible = true;
                    this.ddlTheResults.Enabled = true;
                    this.DIVDelete.Visible = false;
                }

                if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
                {
                    List<XMProject> XMProjectList = base.XMProjectService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                    if (XMProjectList.Count > 0)
                    {
                        this.ddXMProject.Items.Clear();
                        this.ddXMProject.Items.Clear();
                        this.ddXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                        this.ddXMProject.Items[0].Selected = true;
                        this.btnDelete.Enabled = false;
                    }
                }
                else
                {
                    this.BindddXMProject();//项目  
                    this.btnDelete.Enabled = true;
                }

                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
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
            //this.btnAdd.OnClientClick = "return ShowWindowDetail('问题新增','" + CommonHelper.GetStoreLocation() + "ManageProject/QuestionEdit.aspx',1100,600, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

            //绑定店铺
            //var nickList = base.ProjectService.GetXMNickList("", Convert.ToInt32(true),-1);
            //this.ddlNick.Items.Clear();
            //this.ddlNick.DataSource = nickList;
            //this.ddlNick.DataTextField = "nick";
            //this.ddlNick.DataValueField = "nick_id";
            //this.ddlNick.DataBind();
            //this.ddlNick.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            //平台类型动态数据绑定
            this.ddlPlatform.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatform.DataSource = codeList;
            this.ddlPlatform.DataTextField = "CodeName";
            this.ddlPlatform.DataValueField = "CodeID";
            this.ddlPlatform.DataBind();
            this.ddlPlatform.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            //绑定问题类型下拉框
            BindQuestionCategoryDropdonList(this.ddlQCategory);
            this.ddlQCategory.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            //问题等级
            this.ddlQuestionLevel.Items.Clear();
            var QuestionLevelList = base.CodeService.GetCodeListInfoByCodeTypeID(213, false);
            this.ddlQuestionLevel.DataSource = QuestionLevelList;
            this.ddlQuestionLevel.DataTextField = "CodeName";
            this.ddlQuestionLevel.DataValueField = "CodeID";
            this.ddlQuestionLevel.DataBind();
            this.ddlQuestionLevel.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));
        }

        /// <summary>
        /// //绑定问题类型下拉框
        /// </summary>
        private void BindQuestionCategoryDropdonList(DropDownList ddlCategory)
        {
            ddlCategory.Items.Clear();
            //查询所有父节点
            var moduleList = base.XMQuestionCategoryService.GetXMQuestionCategoryByParentID(0);
            this.BindCategoryList(string.Empty, moduleList, ddlCategory);
        }

        /// <summary>
        /// 递归获取字段
        /// </summary>
        /// <param name="parentString"></param>
        /// <param name="fields"></param>
        public void BindCategoryList(string parentString, List<XMQuestionCategory> categorys, DropDownList ddlCategory)
        {
            string newParentString = parentString;
            for (int i = 0; i < categorys.Count; i++)
            {
                var category = categorys[i];
                bool isLast = false;
                if ((i + 1) == categorys.Count)
                {
                    isLast = true;
                }
                var childCategorys = base.XMQuestionCategoryService.GetXMQuestionCategoryByParentID(category.Id);
                bool hasChild = childCategorys.Count > 0 ? true : false;
                newParentString = GetPreFix(isLast, hasChild, parentString);
                ListItem item = new ListItem(newParentString + category.CategoryName, category.Id.ToString());
                ddlCategory.Items.Add(item);
                if (hasChild)
                {
                    BindCategoryList(newParentString, childCategorys, ddlCategory);
                }
            }
        }

        /// <summary>
        /// 用于树的前缀
        /// </summary>
        /// <param name="IsLast">是否是同级节点中的最后一个</param>
        /// <param name="HasChild">本节点是否拥有子节点</param>
        /// <param name="ParentString">父节点前缀符号</param>
        /// <returns>本节点的前缀</returns>
        private static string GetPreFix(bool isLast, bool hasChild, string parentString)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(parentString))
            {
                parentString = parentString.Remove(parentString.Length - 1).Replace("├", "│").Replace("└", "　");
                result += parentString;
            }
            if (isLast)
            {
                result += "└";
            }
            else
            {
                result += "├";
            }
            if (hasChild)
            {
                result += "┬";
            }
            else
            {
                result += "─";
            }
            return result;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            this.BindGrid(paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
        }

        public void BindGrid(int paramPageIndex, int paramPageSize, string sortExpression, string sortDirection)
        {
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);

            int nickID = 0;
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
            if (nickids == "")
            {
                return;
            }
            int platFormID = 0;
            int.TryParse(this.ddlPlatform.SelectedValue, out platFormID);
            int QuestionLevel = 0;
            int.TryParse(this.ddlQuestionLevel.SelectedValue, out QuestionLevel);
            int statusID = 0;
            int.TryParse(this.ddlStatus.SelectedValue, out statusID);
            //选中问题类型（如是父节点，查询所有子节点。如是子节点，查询子节点）
            List<int> questionTypeIDs = new List<int>();
            if (int.Parse(ddlQCategory.SelectedValue) > 0)
            {
                //判断是否是父节点
                int categoryID = int.Parse(ddlQCategory.SelectedValue);
                var category = base.XMQuestionCategoryService.GetXMQuestionCategoryById(categoryID);
                if (category != null && category.ParentId == 0)                                        //该问题类型为父节点
                {
                    //查询该父节点类型下的子节点
                    var childCategory = base.XMQuestionCategoryService.GetXMQuestionCategoryByParentID(category.Id);
                    if (childCategory != null && childCategory.Count() > 0)
                    {
                        foreach (XMQuestionCategory str in childCategory)
                        {
                            questionTypeIDs.Add(str.Id);
                        }
                    }
                }
                else                                                                                           //该问题类型为子节点
                {
                    questionTypeIDs.Add(categoryID);
                }
            }
            //是否超时
            int TheResults = -1;
            int.TryParse(this.ddlTheResults.SelectedValue, out TheResults);

            var xMQuestionList = base.XMQuestionService.XMQuestionSearch(this.txtOrderNO.Text.Trim(), xMProjectId, nickids, this.txtBeginDate.SelectedDate
                , this.txtEndDate.SelectedDate, platFormID, statusID, "", "", this.txtSrvAfterCustomerID.Text.Trim(), questionTypeIDs, ""
                , paramPageIndex, paramPageSize, sortExpression, sortDirection, this.lastStartDate.SelectedDate, this.lastEndDate.SelectedDate, TheResults, this.txtBuyer.Text.Trim(), QuestionLevel);

            if (QuestionType == "feedback")
            {
                if (this.RowEditIndex == -1)
                {
                    //新增编码行
                    this.gvQuestion.EditIndex = xMQuestionList.Count();
                    xMQuestionList.Add(new XMQuestion());
                }
                else
                {
                    this.gvQuestion.EditIndex = this.RowEditIndex;
                }
            }
            this.Master.BindData(this.gvQuestion, xMQuestionList, paramPageSize + 1);

            if (QuestionType == "dealwith")
            {
                if (!string.IsNullOrEmpty(lastStartDate.ctlDateTime.Text.Trim())
               && !string.IsNullOrEmpty(lastEndDate.ctlDateTime.Text.Trim()))
                {
                    //及时接单率
                    this.CompletionRate(questionTypeIDs);
                    //退货挽回率
                    this.ReturnsRedeemRate();
                }
            }
        }

        #endregion

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

            //var projectList = base.XMProjectService.GetXMProjectList();
            //this.ddXMProject.DataSource = projectList;
            //this.ddXMProject.DataTextField = "ProjectName";
            //this.ddXMProject.DataValueField = "Id";
            //this.ddXMProject.DataBind();
            //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
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
                //var nickList = base.XMNickService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue));
                //this.ddlNick.DataSource = nickList;
                //this.ddlNick.DataTextField = "nick";
                //this.ddlNick.DataValueField = "nick_id";
                //this.ddlNick.DataBind();
                //this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
        }

        protected void hidBtnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
            //ScriptManager.RegisterStartupScript(ab, this.Page.GetType(), "", "LoadDetailsBound();", true);
            //ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionOpenList", "CustomerWangNoOpen()", true);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "QuestionOpenList", "<script>CustomerWangNoOpen();</script>");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("请输入结束日期");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("请输入开始日期");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim())
                && !string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
            {
                DateTime dt = new DateTime();
                if (!DateTime.TryParse(txtBeginDate.ctlDateTime.Text.Trim(), out dt))
                {
                    base.ShowMessage("开始日期输入错误");
                    return;
                }
                if (!DateTime.TryParse(txtEndDate.ctlDateTime.Text.Trim(), out dt))
                {
                    base.ShowMessage("结束日期输入错误");
                    return;
                }

                if (DateTime.Parse(txtEndDate.ctlDateTime.Text.Trim()) < DateTime.Parse(txtBeginDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("结束日期不能小于开始日期");
                    return;
                }
            }

            this.BindGrid(1, Master.PageSize);
            ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        /// <summary>
        /// 添加退换货申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManagerAdd2_Click(object sender, EventArgs e)
        {
            //Button1.OnClientClick = "";
            //List<int> questionIDs2 = this.Master.GetSelectedIds(this.gvQuestion);


            //if (questionIDs2.Count <= 0)
            //    return;
            //int questionIDs = this.Master.GetSelectedIds(this.gvQuestion).FirstOrDefault();
            ////    foreach (var item in questionIDs)
            ////    {
            //        var cou = base.XMQuestionService.GetById(questionIDs);
            //        if (cou != null)
            //        {
            //            Button1.OnClientClick = "return ShowWindowDetail('添加退换货申请','" + CommonHelper.GetStoreLocation()
            //            + "../ManageApplication/XMApplicationAdd.aspx?type=" + 1
            //            + "&orderid=" + cou.OrderNO
            //            + "', 900, 650, this,  function(){document.getElementById('').click();});";
            //        }
            //    //}
            ////}
            ////else
            ////{
            ////    return;
            ////}
            //        this.BindGrid(Master.PageIndex, Master.PageSize);
            //        ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        protected void gvQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var mXMQuestion = (XMQuestion)e.Row.DataItem;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (mXMQuestion != null)
                {
                    //明细
                    var QuestionDetailsList = base.XMQuestionDetailService.GetQuestionDetails(mXMQuestion.ID);
                    //聊天记录
                    var xMCommunicationRecordList = base.XMCommunicationRecordService.GetXMCommunicationRecordListByQuestionID(mXMQuestion.ID);

                    ImageButton imgBtnList = e.Row.FindControl("imgBtnList") as ImageButton;
                    ImageButton ImgBtnCR = e.Row.FindControl("ImgBtnCR") as ImageButton;
                    ImageButton ImageButton1 = e.Row.FindControl("ImageButton1") as ImageButton;

                    int count = QuestionDetailsList.Where(p => p.Status.Value == Convert.ToInt32(QuestionStatusEnum.Submit)).Count();
                    if (imgBtnList != null)
                    {
                        if (QuestionType == "feedback")
                        {
                            ImageButton1.Visible = false;
                            if (QuestionDetailsList.Count != count) //问题状态全部为“提交中”,允许修改
                            {
                                imgBtnList.Visible = false;
                                // ImgBtnCR.Visible = false;
                            }
                            else
                            {
                                imgBtnList.Visible = true;
                                //ImgBtnCR.Visible = false;
                            }
                        }
                        else if (QuestionType == "dealwith")
                        {
                            imgBtnList.Visible = false;
                            //ImgBtnCR.Visible = true;
                        }
                    }
                    LinkButton lbtnOrderNo = e.Row.FindControl("lbtnOrderNo") as LinkButton;
                    if (lbtnOrderNo != null)
                    {
                        lbtnOrderNo.Text = mXMQuestion.OrderNO;
                        lbtnOrderNo.OnClientClick = "return ShowWindowDetail('订单详情','" + CommonHelper.GetStoreLocation()
                                                    + "ManageProject/XMOrderUpdate.aspx?XMQuestionId=" + lbtnOrderNo.CommandArgument.ToString()
                                                    + "&XMOrderType=QuestionValue"
                                                    + "', 1000, 750, this, function(){document.getElementById('" + this.hidBtnSearch.ClientID + "').click();});";

                        ImageButton1.OnClientClick = "return ShowWindowDetail('添加退换货申请','" + CommonHelper.GetStoreLocation()
                            + "ManageApplication/XMApplicationAdd.aspx?type=" + 1
                            + "&orderid=" + mXMQuestion.OrderNO
                            + "', 1000, 650, this,  function(){document.getElementById('" + this.hidBtnSearch.ClientID + "').click();});";
                    }



                    #region 问题反馈 主表绑定
                    if (mXMQuestion.ID != 0)
                    {

                        string paramScript1 = "return ShowWindowDetail('沟通记录','" + CommonHelper.GetStoreLocation() + "ManageProject/XMCommunicationRecordEdit.aspx?QuestionID="
                            + mXMQuestion.ID
                            + "&QuestionType=" + this.QuestionType +
                            "',900,450, this, function(){document.getElementById('" + this.hidBtnSearch.ClientID + "').click();});";
                        if (ImgBtnCR != null) ImgBtnCR.Attributes.Add("onclick", paramScript1);

                        #region 是否解决

                        //var chkSelected = e.Row.FindControl("imgChkIsSolve") as ImageCheckBox;
                        //var imgBtnIsSolve = e.Row.FindControl("imgBtnIsSolveOK") as ImageButton;

                        ////隐藏 是否解决 ImageCheckBox、ImageButton
                        //if (chkSelected != null && imgBtnIsSolve != null) {

                        //    chkSelected.Visible = false;
                        //    imgBtnIsSolve.Visible = false;
                        //}
                        ////问题处理 状态是完成时
                        //if (mXMQuestion.Status == (int)QuestionStatusEnum.Complete)
                        //{
                        //    if (mXMQuestion.IsSolve != null)
                        //    {
                        //        if (mXMQuestion.IsSolve.Value == true)
                        //        {
                        //            //显示ImageCheckBox
                        //            if (chkSelected != null)
                        //            {
                        //                chkSelected.Visible = true;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            //显示ImageButton
                        //            if (imgBtnIsSolve != null)
                        //            {
                        //                imgBtnIsSolve.Visible = true;
                        //            }
                        //        }
                        //    }
                        //}
                        //else
                        //{//问题处理 状态是提交中、处理中 时

                        //    if (chkSelected != null)
                        //    {//隐藏ImageCheckBox
                        //        chkSelected.Visible = false;
                        //    }
                        //    //显示 ImageButton
                        //    if (imgBtnIsSolve != null) {
                        //        imgBtnIsSolve.Visible = true; 
                        //    }
                        //}
                        #endregion

                        //（处理人）售后
                        Label lblSrvAfterCustomerID = e.Row.FindControl("lblSrvAfterCustomerID") as Label;
                        if (lblSrvAfterCustomerID != null)
                        {
                            if (mXMQuestion.LastModifyByID != null && mXMQuestion.LastModifyByID.HasValue)
                            {
                                CustomerInfo mCustomerB = base.CustomerInfoService.GetCustomerInfoByID(mXMQuestion.LastModifyByID.Value);
                                lblSrvAfterCustomerID.Text = mCustomerB.FullName;
                            }
                            else
                            {
                                lblSrvAfterCustomerID.Text = "";
                            }
                        }
                        #region 明细显示最后问题提交时间
                        //明细
                        var QuestionDetailsListNow = (from u in QuestionDetailsList
                                                      orderby u.CreateTime descending
                                                      select u).ToList();
                        //问题
                        var lblQuestionTypeID = e.Row.FindControl("lblQuestionTypeID") as Label;
                        //最后提交时间
                        var lblLastSubmitTime = e.Row.FindControl("lblLastSubmitTime") as Label;
                        //是否退换
                        var imgChkIsReturns = e.Row.FindControl("imgChkIsReturns") as ImageCheckBox;
                        //处理结果
                        var lblResultsId = e.Row.FindControl("lblResultsId") as Label;

                        //状态
                        Label lblQuestionStatus = e.Row.FindControl("lblQuestionStatus") as Label;

                        if (QuestionDetailsListNow.Count > 0)
                        {
                            if (lblQuestionTypeID != null)
                            {
                                lblQuestionTypeID.Text = QuestionDetailsListNow[0].QuestionCategoryType;

                            }

                            if (lblLastSubmitTime != null)
                            {

                                lblLastSubmitTime.Text = QuestionDetailsListNow[0].CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            if (imgChkIsReturns != null)
                            {

                                imgChkIsReturns.Checked = QuestionDetailsListNow[0].IsReturns == null ? false : QuestionDetailsListNow[0].IsReturns.Value;
                            }

                            if (lblResultsId != null)
                            {

                                lblResultsId.Text = QuestionDetailsListNow[0].ResultsType == null ? "" : QuestionDetailsListNow[0].ResultsType.CodeName;
                            }
                        }

                        lblQuestionStatus.Text = mXMQuestion.StatusDescription;
                        switch (mXMQuestion.Status.GetValueOrDefault(0))
                        {
                            case (int)QuestionStatusEnum.Submit:
                                e.Row.Cells[14].BackColor = System.Drawing.Color.Red;
                                break;
                            case (int)QuestionStatusEnum.Deal:
                                e.Row.Cells[14].BackColor = System.Drawing.Color.Yellow;
                                break;
                            default:
                                e.Row.Cells[14].BackColor = System.Drawing.Color.Green;
                                break;
                        }

                        #endregion

                        #region 聊天记录 最近联系时间
                        //最近联系时间
                        Label lblContactTime = e.Row.FindControl("lblContactTime") as Label;
                        //联系内容
                        Label lblContactContent = e.Row.FindControl("lblContactContent") as Label;

                        var xMCommunicationRecordListNow = (from c in xMCommunicationRecordList
                                                            orderby c.ContactTime descending
                                                            select c).ToList();

                        if (xMCommunicationRecordListNow.Count > 0)
                        {
                            if (lblContactTime != null)
                            {
                                lblContactTime.Text = xMCommunicationRecordListNow[0].ContactTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            if (lblContactContent != null)
                            {
                                if (xMCommunicationRecordListNow[0].ContactContent != null && xMCommunicationRecordListNow[0].ContactContent != "")
                                {
                                    if (xMCommunicationRecordListNow[0].ContactContent.Length > 8)
                                    {

                                        string strContactContent = xMCommunicationRecordListNow[0].ContactContent.Substring(0, 2);
                                        lblContactContent.Text = strContactContent + "...";
                                        lblContactContent.ToolTip = xMCommunicationRecordListNow[0].ContactContent;
                                    }
                                    else
                                    {

                                        lblContactContent.Text = xMCommunicationRecordListNow[0].ContactContent;
                                        lblContactContent.ToolTip = xMCommunicationRecordListNow[0].ContactContent;
                                    }
                                }
                                else
                                {

                                    lblContactContent.Text = "";
                                    lblContactContent.ToolTip = "";
                                }
                            }
                        }
                        #endregion

                    }
                    #endregion

                    #region 问题反馈 明细绑定
                    if ((GridView)e.Row.FindControl("gvQuestionDetail") != null)
                    {
                        GridView gvQuestionDetail = (GridView)e.Row.FindControl("gvQuestionDetail");

                        if (QuestionType == "feedback")
                        {
                            if (childindex == -1)
                            {
                                //新增编码行
                                gvQuestionDetail.EditIndex = QuestionDetailsList.Count();
                                QuestionDetailsList.Add(new XMQuestionDetail());
                            }
                            else
                            {
                                gvQuestionDetail.EditIndex = childindex;
                            }
                        }

                        gvQuestionDetail.DataSource = QuestionDetailsList;
                        gvQuestionDetail.DataBind();
                    }
                    #endregion


                }
            }

        }

        protected void gvQuestion_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            this.BindGrid(Master.PageIndex, Master.PageSize);
            ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        protected void gvQuestion_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            this.BindGrid(Master.PageIndex, Master.PageSize);
            ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        protected void gvQuestion_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row = this.gvQuestion.Rows[e.RowIndex];
            //var ccPlatformID = row.FindControl("ccPlatformID") as CodeControl;//平台类型 
            //var ddlNick = row.FindControl("ddlEditNick") as DropDownList;//店铺Id

            var hfPlatformId = row.FindControl("hfPlatformId") as HtmlInputHidden;//平台Id
            var hftxtNickId = row.FindControl("hftxtNickId") as HtmlInputHidden; //店铺Id
            var hftxtWantID = row.FindControl("hftxtWantID") as HtmlInputHidden; //旺旺

            var txtOrderNO = row.FindControl("txtOrderCode") as HtmlInputText; //订单号 
            var lblOrderNO = row.FindControl("lblOrderNO") as Label;//订单号（隐藏）

            var txtPlatformName = row.FindControl("txtPlatformName") as TextBox;//平台名称  
            var txtNickName = row.FindControl("txtNickName") as TextBox;//店铺名称  
            var txtWantID = row.FindControl("txtWantID") as TextBox;//买家  

            int QID = Convert.ToInt32(gvQuestion.DataKeys[e.RowIndex].Value.ToString());

            //根据订单号查询问题处理信息
            var xMQuestionList = base.XMQuestionService.GetQuestionsByOrderNo(txtOrderNO.Value);
            //根据订单号查询订单信息
            var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(txtOrderNO.Value);
            var xMSaleInfo = base.XMSaleInfoService.GetXMSaleInfoListByRef(txtOrderNO.Value);

            //问题处理
            var mXMQuestion = base.XMQuestionService.GetById(QID);
            if (mXMQuestion == null) //新增
            {
                if (xMQuestionList.Count > 0)
                {
                    txtOrderNO.Value = "";
                    txtPlatformName.Text = "";
                    txtNickName.Text = "";
                    txtBuyer.Text = "";
                    hfPlatformId.Value = "";
                    hftxtNickId.Value = "";
                    hftxtWantID.Value = "";
                    base.ShowMessage("该订单号存在！");
                    ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
                    return;
                }
                if (xMOrderInfo.Count == 0 && xMSaleInfo.Count == 0)
                {
                    txtOrderNO.Value = "";
                    txtPlatformName.Text = "";
                    txtNickName.Text = "";
                    txtBuyer.Text = "";
                    hfPlatformId.Value = "";
                    hftxtNickId.Value = "";
                    hftxtWantID.Value = "";
                    this.Master.ShowMessage("订单号有误！");
                    ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
                    return;
                }


                XMQuestion mXMQuestionAdd = new XMQuestion();
                mXMQuestionAdd.PlatformID = Convert.ToInt32(hfPlatformId.Value);
                mXMQuestionAdd.NickID = int.Parse(hftxtNickId.Value);
                mXMQuestionAdd.OrderNO = txtOrderNO.Value;
                mXMQuestionAdd.Buyer = hftxtWantID.Value;
                mXMQuestionAdd.Status = Convert.ToInt32(QuestionStatusEnum.Submit);
                mXMQuestionAdd.CreateByID = HozestERPContext.Current.User.CustomerID;
                mXMQuestionAdd.CreateTime = DateTime.Now;
                mXMQuestionAdd.LastModifyByID = HozestERPContext.Current.User.CustomerID;
                mXMQuestionAdd.LastModifyTime = DateTime.Now;
                mXMQuestionAdd.IsEnable = false;
                mXMQuestionAdd.IsSolve = false;//是否解决
                base.XMQuestionService.Insert(mXMQuestionAdd);
            }
            else //修改
            {
                if ((!txtOrderNO.Value.Trim().Equals(lblOrderNO.Text.Trim())) && xMQuestionList.Count > 0)
                {
                    txtOrderNO.Value = "";
                    txtPlatformName.Text = "";
                    txtNickName.Text = "";
                    txtBuyer.Text = "";
                    hfPlatformId.Value = "";
                    hftxtNickId.Value = "";
                    hftxtWantID.Value = "";
                    base.ShowMessage("该订单号存在");
                    ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
                    return;
                }


                if (xMOrderInfo.Count == 0)
                {
                    txtOrderNO.Value = "";
                    txtPlatformName.Text = "";
                    txtNickName.Text = "";
                    txtBuyer.Text = "";
                    hfPlatformId.Value = "";
                    hftxtNickId.Value = "";
                    hftxtWantID.Value = "";
                    this.Master.ShowMessage("订单号有误.");
                    ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
                    return;
                }

                mXMQuestion.PlatformID = Convert.ToInt32(hfPlatformId.Value);
                mXMQuestion.NickID = int.Parse(hftxtNickId.Value);
                mXMQuestion.OrderNO = txtOrderNO.Value;
                mXMQuestion.Buyer = hftxtWantID.Value;
                mXMQuestion.LastModifyByID = HozestERPContext.Current.User.CustomerID;
                mXMQuestion.LastModifyTime = DateTime.Now;
                base.XMQuestionService.Update(mXMQuestion);
            }

            //重新绑定
            this.RowEditIndex = -1;
            this.BindGrid(Master.PageIndex, Master.PageSize);
            ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        protected void gvQuestion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            if (int.TryParse(this.gvQuestion.DataKeys[e.RowIndex].Value.ToString(), out Id))
            {
                // 问题处理
                var xMQuestion = base.XMQuestionService.GetById(Id);
                if (xMQuestion != null)
                {
                    xMQuestion.IsEnable = true;
                    xMQuestion.LastModifyByID = HozestERPContext.Current.User.CustomerID;
                    xMQuestion.LastModifyTime = DateTime.Now;
                    base.XMQuestionService.Update(xMQuestion);

                    var xMQuestionDetail = base.XMQuestionDetailService.GetQuestionDetails(xMQuestion.ID);
                    if (xMQuestionDetail != null)
                    {
                        foreach (XMQuestionDetail info in xMQuestionDetail)
                        {
                            info.IsEnable = true;
                            info.LastModifyTime = DateTime.Now;
                            info.LastModifyByID = HozestERPContext.Current.User.CustomerID;
                            base.XMQuestionDetailService.Update(info);
                        }
                    }
                }
                //grid 绑定
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("删除成功.");
                ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
            }
        }

        protected void gvQuestion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>ShowHidde(" + aa + ",event)</script>", true);
            try
            {
                #region 是否解决
                //if (e.CommandName.Equals("XMQuestionIsSolveOK"))
                //{

                //    var xMQuestion = base.XMQuestionService.GetById(Convert.ToInt32(e.CommandArgument));

                //    if (xMQuestion != null)//删除
                //    {
                //        if (xMQuestion.Status == (int)QuestionStatusEnum.Complete)
                //        {
                //            xMQuestion.IsSolve = true;
                //            base.XMQuestionService.Update(xMQuestion);
                //            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                //            base.ShowMessage("操作成功.");
                //            return;
                //        }
                //        else {

                //            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                //            base.ShowMessage("该记录未处理完成,只有处理完成的才能解决通过.");
                //            return; 
                //        }
                //    }

                //}
                #endregion
            }
            catch (Exception ex)
            {

                base.ProcessException(ex);
            }

        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> questionIDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (questionIDs.Count <= 0)
                return;
            foreach (var item in questionIDs)
            {
                base.XMQuestionDetailService.BatchDeleteXMQuestionDetails(item);
                base.XMQuestionService.Delete(item);
            }
            base.ShowMessage("删除成功.");
            this.BindGrid(Master.PageIndex, Master.PageSize);
            ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        //protected void txtOrderNO_TextChanged(object sender, EventArgs e)
        //{


        //    var PUNameList = base.XMOrderInfoService.GetXMOrderInfoByOrderCodeList(this.txtOrderNO.Text.Trim());

        //    if (PUNameList.Count > 0)
        //    {

        //        //if (PUNameList.Count == 1)
        //        //{
        //        //    this.lblPUName.Text = PUNameList[0].PrdouctName + ", " + PUNameList[0].PartNo + ", " + PUNameList[0].Specifications;
        //        //}
        //        //else if (PUNameList.Count > 1)
        //        //{
        //        //    string str = "";
        //        //    foreach (var lists in PUNameList)
        //        //    {
        //        //        str += lists.PrdouctName + ", " + lists.PartNo + "," + lists.Specifications + "<br/>";
        //        //    } 
        //        //    this.lblPUName.Text = str;

        //        //}
        //        //else
        //        //{

        //        //    this.lblPUName.Text = "";
        //        //}


        //    }
        //}

        #region 明细绑定

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QuestionId">主表Id</param>
        /// <param name="gv">明细grid</param>
        /// <param name="childindex"></param>
        /// <param name="rowId">明细当前选中行的索引</param>
        public void loadDateDeal(int QuestionId, GridView gv, int childindex, int rowId)
        {
            if (QuestionId > 0 && gv != null)
            {
                //明细数据源
                var QuestionDetailsList = base.XMQuestionDetailService.GetQuestionDetails(QuestionId);

                if (QuestionType == "feedback")
                {
                    if (childindex == -1)
                    {
                        //新增编码行
                        gv.EditIndex = QuestionDetailsList.Count();
                        QuestionDetailsList.Add(new XMQuestionDetail());
                    }
                    else
                    {
                        gv.EditIndex = childindex;
                    }
                }
                else if (QuestionType == "dealwith")
                {
                    gv.EditIndex = childindex;
                }

                gv.DataSource = QuestionDetailsList;
                gv.DataBind();

                if (rowId != -1)
                {

                    //问题类型
                    var ccQuestionType = (DropDownList)gv.Rows[rowId].FindControl("ddlQuestionCategory");
                    //是否退货
                    var ddlIsReturns = (DropDownList)gv.Rows[rowId].FindControl("ddlIsReturns");
                    //处理结果说明 
                    var txtResultMsgEdit = (TextBox)gv.Rows[rowId].FindControl("txtResultMsgEdit");
                    //处理结果 
                    var ccResultsId = (DropDownList)gv.Rows[rowId].FindControl("ccResultsId");

                    if (ccQuestionType != null && ddlIsReturns != null && txtResultMsgEdit != null && ccResultsId != null)
                    {
                        ccQuestionType.Enabled = true;
                        ddlIsReturns.Enabled = true;
                        txtResultMsgEdit.ReadOnly = false;
                        ccResultsId.Enabled = true;

                        ccResultsId.Items.Clear();
                        var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(201, false);
                        ccResultsId.DataSource = codeList;
                        ccResultsId.DataTextField = "CodeName";
                        ccResultsId.DataValueField = "CodeID";
                        ccResultsId.DataBind();

                    }

                }

            }
        }

        protected void gvQuestionDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //string resultMsgEdit = "";
            //if (Session["ResultMsgEdit"] != null && Session["ResultMsgEdit"] != "")
            //{
            //    resultMsgEdit = Session["ResultMsgEdit"].ToString();
            //}
            var item = (XMQuestionDetail)e.Row.DataItem;

            #region 明细绑定

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //获取父级Id
                var a = (HiddenField)e.Row.Parent.Parent.Parent.FindControl("hdQuestionId");

                ImageButton imgBtnDealEdit = e.Row.FindControl("imgBtnDealEdit") as ImageButton;//编辑按钮 
                ImageButton imgBtnDealDelete = e.Row.FindControl("imgBtnDealDelete") as ImageButton;
                ImageButton imgBtnDealUpload = e.Row.FindControl("imgBtnDealUpload") as ImageButton;
                ImageButtonSelectSingleCustomerControl btnTransfer = e.Row.FindControl("btnTransfer") as ImageButtonSelectSingleCustomerControl;

                //ImageButton imgBtnDealPremiums = e.Row.FindControl("imgBtnDealPremiums") as ImageButton;//赠品按钮  
                //ImageButton imgBtnDealCashBack = e.Row.FindControl("imgBtnDealCashBack") as ImageButton;//赠品、返现按钮 
                ImageButton imgBtnDealPayment = e.Row.FindControl("imgBtnDealPayment") as ImageButton;//赔付按钮 

                //明细控件 绑定主表Id
                HiddenField hdQId = e.Row.FindControl("hdQId") as HiddenField;

                if (hdQId != null)
                {
                    hdQId.Value = a.Value;
                }

                if (imgBtnDealPayment != null)
                {
                    imgBtnDealPayment.OnClientClick = "return ShowWindowDetail('返现赠品管理','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/CashbackPremiums.aspx?Id=" + item.ID + "', 1000, 500, this, function(){document.getElementById('"
                   + this.hidBtnSearch.ClientID + "').click();});";
                }

                #region 列表数据绑定
                Label lblStatus = e.Row.FindControl("lblStatus") as Label;
                //问题处理 处理状态
                DropDownList ddlStatus = e.Row.FindControl("ddlStatus") as DropDownList;
                //Label lblSrvBeforeCustomerID = e.Row.FindControl("lblSrvBeforeCustomerID") as Label;
                //Label lblSrvAfterCustomerID = e.Row.FindControl("lblSrvAfterCustomerID") as Label;
                // Label lblCreateTime = e.Row.FindControl("lblCreateTime") as Label;
                //Label lblLastModifyTime = e.Row.FindControl("lblLastModifyTime") as Label;

                //问题描述(TemplateField)
                TextBox txtDescription = e.Row.FindControl("txtDescription") as TextBox;
                //处理结果说明 (TemplateField)
                //TextBox txtResultMsgEdit = e.Row.FindControl("txtResultMsgEdit") as TextBox;

                //问题描述
                TextBox txtDescriptionEdit = e.Row.FindControl("txtDescriptionEdit") as TextBox;

                //问题类型
                DropDownList ccQuestionType = e.Row.FindControl("ddlQuestionCategory") as DropDownList;

                //问题等级
                CodeControl ccQuestionLevel = e.Row.FindControl("ccQuestionLevel") as CodeControl;

                //是否退货
                DropDownList ddlIsReturns = e.Row.FindControl("ddlIsReturns") as DropDownList;

                //处理结果说明
                TextBox txtResultMsgEdit = e.Row.FindControl("txtResultMsgEdit") as TextBox;
                //处理结果
                DropDownList ccResultsId = e.Row.FindControl("ccResultsId") as DropDownList;
                if (QuestionType == "feedback")
                {
                    #region 问题反馈
                    if (btnTransfer != null)
                    {

                        btnTransfer.Visible = false;
                    }

                    //if (imgBtnDealPremiums != null) {
                    //    imgBtnDealPremiums.Visible = false;
                    //}
                    //if (imgBtnDealCashBack != null) {
                    //    imgBtnDealCashBack.Visible = false;
                    //}
                    if (imgBtnDealPayment != null)
                    {
                        imgBtnDealPayment.Visible = false;
                    }
                    if (txtDescriptionEdit != null)
                    {
                        txtDescriptionEdit.ReadOnly = false;
                    }
                    if (ccQuestionType != null)
                    {
                        ccQuestionType.Enabled = true;
                    }
                    if (ccQuestionLevel != null)
                    {
                        ccQuestionLevel.Enabled = true;
                    }
                    if (ddlIsReturns != null)
                    {
                        ddlIsReturns.Visible = true;
                    }
                    if (txtResultMsgEdit != null)
                    {
                        txtResultMsgEdit.ReadOnly = true;
                    }
                    if (ccResultsId != null)
                    {
                        ccResultsId.Enabled = false;
                    }
                    //if (lblStatus != null) { 
                    //    lblStatus.Visible = true;
                    //}
                    if (ddlStatus != null)
                    {

                        ddlStatus.Visible = false;
                    }
                    #endregion
                }
                else if (QuestionType == "dealwith")
                {
                    #region 问题处理

                    #region 赠品、返现、赔付 按钮处理

                    //根据问题反馈明细中的主表Id 查询主表信息 在根据主表中的订单号查询 订单信息 
                    XMOrderInfo xMOrderInfo = new XMOrderInfo();
                    if (item != null)
                    {
                        //查询问题反馈主表信息
                        XMQuestion xMQuestion = base.XMQuestionService.GetById(item.QuestionID);
                        //根据订单号查询
                        if (xMQuestion != null)
                        {
                            xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMQuestion.OrderNO);
                        }
                    }
                    #region 赠品
                    //if (imgBtnDealPremiums != null)
                    //{ 
                    //    if (item.ResultsId != null)
                    //    {
                    //        //处理结果是赠品
                    //        if (item.ResultsId.Value == 442)
                    //        {
                    //            //未发赠品
                    //            if (xMOrderInfo.IsSentGifts == false)
                    //            { 
                    //                imgBtnDealPremiums.Visible = true;//显示赠品按钮
                    //                imgBtnDealPremiums.Enabled = true;//可操作
                    //            }
                    //            else {
                    //                //已发赠品  按钮不可操作 并显示已发
                    //                imgBtnDealPremiums.Visible = true;//显示赠品按钮
                    //                imgBtnDealPremiums.ToolTip = "已发赠品";
                    //                imgBtnDealPremiums.Enabled = false;//不可操作
                    //            }
                    //        }
                    //        else {
                    //            imgBtnDealPremiums.Visible = false;//隐藏赠品按钮
                    //        }
                    //    }
                    //    else {
                    //        imgBtnDealPremiums.Visible = false;
                    //    }
                    //}
                    #endregion

                    #region 赠品、返现
                    //if (imgBtnDealCashBack != null)
                    //{ 
                    //    if (item.ResultsId != null)
                    //    {
                    //        //处理结果是返现
                    //        if (item.ResultsId.Value == 440)
                    //        {
                    //            //未返现 //未发赠品 
                    //            if (xMOrderInfo.IsCashBack == false && xMOrderInfo.IsSentGifts == false)
                    //            {
                    //                imgBtnDealCashBack.Visible = true;//显示返现按钮
                    //                imgBtnDealCashBack.Enabled = true;//可操作
                    //            }
                    //            else {
                    //                //已发返现  按钮不可操作 并显示已返现
                    //                imgBtnDealCashBack.Visible = true;//显示返现按钮
                    //                imgBtnDealCashBack.ToolTip = "已发赠品/已返现";
                    //                imgBtnDealCashBack.Enabled = false; //不可操作
                    //            }
                    //        }
                    //        else
                    //        {
                    //            imgBtnDealCashBack.Visible = false;//隐藏返现按钮
                    //        }
                    //    }
                    //    else
                    //    {
                    //        imgBtnDealCashBack.Visible = false;
                    //    }

                    //}
                    #endregion

                    if (imgBtnDealPayment != null)
                    {
                        if (item.ResultsId != null)
                        {
                            //处理结果是赔付
                            if (item.ResultsId.Value == 473)
                            {
                                if (xMOrderInfo.IsEvaluate == false)
                                {
                                    imgBtnDealPayment.Visible = true;//显示赔付按钮
                                    imgBtnDealPayment.Enabled = true;//可操作
                                }
                                else
                                {
                                    //已赔付 按钮不可操作 并显示已赔付
                                    imgBtnDealPayment.Visible = true;//显示赔付按钮
                                    imgBtnDealPayment.ToolTip = "已赔付";
                                    //imgBtnDealPayment.Enabled = false; //不可操作
                                    imgBtnDealPayment.Enabled = true; //可操作
                                }
                            }
                            else
                            {
                                imgBtnDealPayment.Visible = false;//隐藏赔付按钮
                            }
                        }
                        else
                        {
                            imgBtnDealPayment.Visible = false;
                        }
                    }

                    #endregion

                    //移交
                    if (btnTransfer != null)
                    {
                        //if (item.SrvAfterCustomerID != null)
                        //{
                        //btnTransfer.Visible = true;
                        btnTransfer.BtnOnClientClick = btnTransfer.OnClientClick;
                        //}
                        //else
                        //{ 
                        //btnTransfer.Visible = false;
                        //}
                    }
                    if (txtDescription != null)
                    {
                        txtDescription.ReadOnly = true;
                    }
                    if (txtDescriptionEdit != null)
                    {
                        txtDescriptionEdit.ReadOnly = true;
                    }
                    if (ccQuestionType != null)
                    {
                        ccQuestionType.Enabled = false;
                    }
                    if (ccQuestionLevel != null)
                    {
                        ccQuestionLevel.Enabled = false;
                    }
                    if (ddlIsReturns != null)
                    {
                        //ddlIsReturns.Visible = false;
                        ddlIsReturns.Enabled = false;
                    }
                    if (txtResultMsgEdit != null)
                    {
                        txtResultMsgEdit.ReadOnly = false;
                    }
                    if (ccResultsId != null)
                    {
                        ccResultsId.Enabled = true;
                    }
                    //if (lblStatus != null)
                    //{
                    //    lblStatus.Visible = false;
                    //}
                    if (ddlStatus != null)
                    {
                        ddlStatus.Visible = true;
                    }
                    #endregion
                }
                string paramScript1 = "return ShowWindowDetail('图片附件','" + CommonHelper.GetStoreLocation() + "ManageProject/QuestionUploadEdit.aspx?QuestionID="
                    + item.ID
                    + "&Status=" + item.Status
                    + "&SrvBeforeCustomerID=" + item.SrvBeforeCustomerID
                    + "&SrvAfterCustomerID=" + item.SrvAfterCustomerID + " ',650,600, this, function(){});";
                if (imgBtnDealUpload != null) imgBtnDealUpload.Attributes.Add("onclick", paramScript1);


                if (QuestionType == "feedback")
                {
                    #region 问题反馈

                    //问题反馈列表中隐藏 总监编辑按钮
                    //if (imgBtnDirector != null) { 
                    //    imgBtnDirector.Visible = false;
                    //}

                    if (item != null)
                    {
                        //客服
                        //lblSrvBeforeCustomerID.Text = item.SrvBeforeCustomer == null ? "" : item.SrvBeforeCustomer.FullName;
                        //lblCreateTime.Text = item.CreateTime.HasValue == false ? "" : item.CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        //售后
                        //lblSrvAfterCustomerID.Text = item.SrvAfterCustomer == null ? "" : item.SrvAfterCustomer.FullName;
                        //lblLastModifyTime.Text = item.LastModifyTime.HasValue == false ? "" : item.LastModifyTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        if (item.Status != null)
                        {
                            switch (item.Status.Value)
                            {
                                case (int)QuestionStatusEnum.Submit:
                                    e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
                                    break;
                                case (int)QuestionStatusEnum.Deal:
                                    e.Row.Cells[7].BackColor = System.Drawing.Color.Yellow;
                                    break;
                                case (int)QuestionStatusEnum.Complete:
                                    e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
                                    break;
                            }
                        }
                        if (lblStatus != null)
                        {
                            lblStatus.Text = item.StatusDescription;
                        }
                        if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                        {
                            if (imgBtnDealEdit != null && imgBtnDealDelete != null)
                            {
                                if (txtDescription != null)
                                {
                                    txtDescription.ReadOnly = true;
                                }
                                if (txtResultMsgEdit != null)
                                {
                                    txtResultMsgEdit.ReadOnly = true;
                                }
                                imgBtnDealEdit.Visible = false;
                                imgBtnDealDelete.Visible = false;
                                if (item.SrvBeforeCustomerID == HozestERPContext.Current.User.CustomerID
                                    && item.Status == (int)QuestionStatusEnum.Submit)
                                {
                                    imgBtnDealEdit.Visible = true;
                                    imgBtnDealUpload.Visible = true;
                                    imgBtnDealDelete.Visible = true;
                                }
                            }

                        }
                        else
                        {
                            if (txtDescription != null)
                            {
                                txtDescription.ReadOnly = false;
                            }
                            if (txtResultMsgEdit != null)
                            {
                                txtResultMsgEdit.ReadOnly = false;
                            }
                            if (ccQuestionType != null)
                            {
                                if (item.QuestionTypeID != null)
                                {
                                    ccQuestionType.SelectedValue = item.QuestionTypeID.Value.ToString();
                                }
                            }
                            if (ccQuestionLevel != null)
                            {
                                if (item.QuestionLevel != null)
                                {
                                    ccQuestionLevel.SelectedValue = item.QuestionLevel.Value;
                                }
                            }
                        }
                    }
                    #endregion
                }
                else if (QuestionType == "dealwith")
                {
                    #region 问题处理

                    //控制 
                    //只允许第一个售后修改
                    //if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    //{
                    //    var mXMQuestion = base.XMQuestionService.GetById(Convert.ToInt32(a.Value));
                    //    if (mXMQuestion != null)
                    //    {
                    //        if (mXMQuestion.LastModifyByID.HasValue && mXMQuestion.LastModifyByID.Value != 0)
                    //        {
                    //            //ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                    //            if (HozestERPContext.Current.User.CustomerID != mXMQuestion.LastModifyByID)
                    //                imgBtnDealEdit.Visible = false;
                    //            else imgBtnDealEdit.Visible = true;
                    //        }
                    //    }
                    //}
                    //控制

                    //问题明细 状态是处理中 只允许同一个售后处理
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {

                        if (item != null)
                        {
                            if (item.Status != null)
                            {

                                if (item.Status.Value == Convert.ToInt32(QuestionStatusEnum.Deal))
                                {
                                    if (item.LastModifyByID != null)
                                    {
                                        if (item.LastModifyByID.HasValue && item.LastModifyByID.Value != 0)
                                        {
                                            if (HozestERPContext.Current.User.CustomerID != item.SrvAfterCustomerID.Value && HozestERPContext.Current.User.CustomerID != item.SrvBeforeCustomerID.Value)
                                            {
                                                imgBtnDealEdit.Visible = false;
                                            }
                                            else
                                            {
                                                imgBtnDealEdit.Visible = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    imgBtnDealEdit.Visible = false;
                                }
                            }
                        }
                    }
                    if (e.Row.RowState == DataControlRowState.Edit ||
                    e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
                    {
                        // var ccQuestionType = e.Row.FindControl("ccQuestionType") as CodeControl;
                        ccQuestionType.Enabled = false;
                        ccQuestionLevel.Enabled = false;
                        txtResultMsgEdit.ReadOnly = false;
                        //txtResultMsg.Enabled = true;
                    }
                    else
                    {
                        txtResultMsgEdit.ReadOnly = true;
                        //txtResultMsg.Enabled = false;
                    }

                    //int questionDetailID = item.ID;
                    //XMQuestionDetail mXMQuestionDetail = base.XMQuestionDetailService.GetById(questionDetailID);
                    if (item != null)
                    {
                        //客服
                        //lblSrvBeforeCustomerID.Text = item.SrvBeforeCustomer == null ? "" : item.SrvBeforeCustomer.FullName;
                        //lblCreateTime.Text = item.CreateTime.HasValue == false ? "" : item.CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        //售后
                        //lblSrvAfterCustomerID.Text = item.SrvAfterCustomer == null ? "" : item.SrvAfterCustomer.FullName;
                        //lblLastModifyTime.Text = item.LastModifyTime.HasValue == false ? "" : item.LastModifyTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        if (Convert.ToInt32(QuestionStatusEnum.Submit) == item.Status)
                        {
                            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                            {
                                //Label lblStatus = e.Row.FindControl("lblStatus") as Label;
                                lblStatus.Text = "提交中";
                                e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
                            }
                        }
                        else if (Convert.ToInt32(QuestionStatusEnum.Deal) == item.Status)
                        {
                            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                            {
                                //Label lblStatus = e.Row.FindControl("lblStatus") as Label;
                                lblStatus.Text = "处理中";
                                e.Row.Cells[7].BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (e.Row.RowState == DataControlRowState.Edit
                                || e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))
                            {
                                //DropDownList ddlStatus = e.Row.FindControl("ddlStatus") as DropDownList;
                                ddlStatus.SelectedValue = item.Status.ToString();
                            }
                        }
                        else if (Convert.ToInt32(QuestionStatusEnum.Complete) == item.Status)
                        {
                            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                            {
                                //Label lblStatus = e.Row.FindControl("lblStatus") as Label;
                                lblStatus.Text = "完成";
                                e.Row.Cells[7].BackColor = System.Drawing.Color.Green;

                                //ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;

                                imgBtnDealEdit.Visible = false;
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            }


            if (e.Row.RowState == DataControlRowState.Edit ||
                e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {

                //问题描述
                TextBox txtDescriptionEdit = e.Row.FindControl("txtDescriptionEdit") as TextBox;
                //处理结果说明
                TextBox txtResultMsgEdit = e.Row.FindControl("txtResultMsgEdit") as TextBox;
                //处理结果
                DropDownList ccResultsId = e.Row.FindControl("ccResultsId") as DropDownList;

                if (ccResultsId != null)
                {
                    ccResultsId.Items.Clear();
                    var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(201, false);
                    ccResultsId.DataSource = codeList;
                    ccResultsId.DataTextField = "CodeName";
                    ccResultsId.DataValueField = "CodeID";
                    ccResultsId.DataBind();
                }

                if (QuestionType == "feedback")
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Red;

                    if (txtDescriptionEdit != null)
                    {
                        txtDescriptionEdit.ReadOnly = false;
                    }
                    if (txtResultMsgEdit != null)
                    {

                        txtResultMsgEdit.ReadOnly = true;
                    }
                }
                else if (QuestionType == "dealwith")
                {
                    if (txtDescriptionEdit != null)
                    {
                        txtDescriptionEdit.ReadOnly = true;
                    }
                    if (txtResultMsgEdit != null)
                    {

                        txtResultMsgEdit.ReadOnly = false;
                    }
                }

                if (item != null)
                {
                    //问题类型
                    DropDownList ccQuestionType = e.Row.FindControl("ddlQuestionCategory") as DropDownList;

                    if (ccQuestionType != null)
                    {
                        BindQuestionCategoryDropdonList(ccQuestionType);
                    }

                    if (ccQuestionType != null)
                    {
                        ccQuestionType.SelectedValue = item.QuestionTypeID != null ? item.QuestionTypeID.Value.ToString() : "0";
                    }

                    DropDownList ddlIsReturns = (DropDownList)e.Row.FindControl("ddlIsReturns");
                    if (ddlIsReturns != null)
                    {
                        if (item.IsReturns != null)
                        {
                            string vl = item.IsReturns.Value ? "1" : "0";

                            ddlIsReturns.SelectedValue = vl;
                        }
                    }
                    if (ccResultsId != null)
                    {
                        ccResultsId.SelectedValue = item.ResultsId != null ? item.ResultsId.Value.ToString() : "0";
                    }
                }
            }
            #endregion
        }

        protected void gvQuestionDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView a = (GridView)sender;

            var ab = this.Master.FindControl("UpdatePanel1");

            #region 总监编辑
            if (e.CommandName.Equals("ChildDirectorEdit"))
            {
                try
                {
                    this.ButType = "ChildDirectorEdit";

                    //获取父级Id 
                    var hdQId = (HiddenField)(a.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("hdQId"));

                    int rowInt = int.Parse(e.CommandArgument.ToString());

                    int QuestionId = Convert.ToInt32(hdQId.Value);
                    childindex = int.Parse(e.CommandArgument.ToString());
                    //编辑
                    if (childindex != -1)
                    {
                        a.EditIndex = childindex;
                    }

                    loadDateDeal(QuestionId, a, childindex, rowInt);

                    ScriptManager.RegisterStartupScript(ab, this.Page.GetType(), "", "LoadDetailsBound();", true);
                    ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
                }
                catch (Exception err)
                {
                    base.ProcessException(err);
                }
            }
            #endregion

            #region 编辑
            if (e.CommandName.Equals("ChildEdit"))
            {
                try
                {
                    //获取父级Id 
                    var hdQId = (HiddenField)(a.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("hdQId"));

                    int QuestionId = Convert.ToInt32(hdQId.Value);
                    childindex = int.Parse(e.CommandArgument.ToString());
                    //编辑
                    if (childindex != -1)
                    {
                        a.EditIndex = childindex;
                    }

                    loadDateDeal(QuestionId, a, childindex, -1);

                    ScriptManager.RegisterStartupScript(ab, this.Page.GetType(), "", "LoadDetailsBound();", true);
                    ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);

                }
                catch (Exception err)
                {
                    base.ProcessException(err);
                }
            }
            #endregion

            #region 取消
            if (e.CommandName.Equals("ChildCancel"))
            {
                try
                {
                    //获取父级Id 
                    var hdQId = (HiddenField)(a.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("hdQId"));

                    int QuestionId = Convert.ToInt32(hdQId.Value);

                    childindex = -1;
                    a.EditIndex = -1;

                    loadDateDeal(QuestionId, a, childindex, -1);
                    ScriptManager.RegisterStartupScript(ab, this.Page.GetType(), "", "LoadDetailsBound();", true);
                    ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
                }
                catch (Exception err)
                {
                    base.ProcessException(err);
                }
            }
            #endregion

            #region 删除
            if (e.CommandName.Equals("ChildDelete"))
            {
                try
                {
                    //获取父级Id 
                    var hdQId = (HiddenField)(a.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("hdQId"));

                    int QuestionId = Convert.ToInt32(hdQId.Value);
                    //当前行Id
                    var hdId = (HiddenField)(a.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("hdId"));
                    int Id = Convert.ToInt32(hdId.Value);
                    // 问题处理
                    var xMQuestionDetail = base.XMQuestionDetailService.GetById(Id);
                    if (xMQuestionDetail != null)
                    {
                        xMQuestionDetail.IsEnable = true;
                        base.XMQuestionDetailService.Update(xMQuestionDetail);

                        var question = base.XMQuestionService.GetById(xMQuestionDetail.QuestionID);
                        XMQuestionDetail one = GetPriority(xMQuestionDetail.QuestionID);
                        question.Status = one.Status;
                        question.QuestionLevel = one.QuestionLevel;
                        question.LastModifyTime = DateTime.Now;
                        question.LastModifyByID = HozestERPContext.Current.User.CustomerID;
                        base.XMQuestionService.Update(question);

                        base.ShowMessage("删除成功.");
                    }
                    childindex = -1;
                    a.EditIndex = -1;
                    loadDateDeal(QuestionId, a, childindex, -1);
                    this.BindGrid(Master.PageIndex, Master.PageSize);
                    ScriptManager.RegisterStartupScript(ab, this.Page.GetType(), "", "LoadDetailsBound();", true);
                    ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
                }
                catch (Exception err)
                {
                    base.ProcessException(err);
                }
            }
            #endregion

            #region 赠品
            //if (e.CommandName.Equals("ChildPremiums"))
            //{
            //    int ints = 0;

            //    //获取父级Id 
            //    var hdQId = (HiddenField)(a.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("hdQId"));
            //    int QuestionId = Convert.ToInt32(hdQId.Value);
            //    //当前行Id
            //    var hdId = (HiddenField)(a.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("hdId"));
            //    int Id = Convert.ToInt32(hdId.Value);

            //    //赠品处理
            //    //根据问题反馈明细中的主表Id 查询主表信息 在根据主表中的订单号查询 订单信息 
            //    XMOrderInfo xMOrderInfo = new XMOrderInfo();
            //    //查询问题反馈主表信息
            //    XMQuestion xMQuestion = base.XMQuestionService.GetById(QuestionId);
            //    //根据订单号查询
            //    if (xMQuestion != null)
            //    {
            //        xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMQuestion.OrderNO);

            //        if (xMOrderInfo != null)
            //        {
            //            //生成赠品发货单 
            //            if (xMOrderInfo.CustomerServiceRemark != null && xMOrderInfo.CustomerServiceRemark != "")
            //            {
            //                string paramMessage = string.Empty;

            //                ints = base.XMOrderInfoAPIService.XMPremiumsInst(xMOrderInfo.CustomerServiceRemark, xMOrderInfo.WantID, xMOrderInfo.OrderCode, ref paramMessage);

            //                if (ints == 0)
            //                {
            //                    base.ShowMessage(paramMessage);
            //                }
            //            }
            //            else
            //            {
            //                base.ShowMessage("请确认订单备注信息.");
            //            }
            //        }
            //        else
            //        {
            //            base.ShowMessage("订单号不存在,请确认订单号!");
            //        }
            //        //修改订单赠品状态(导入物流单号 才修改订单赠品状态) 
            //    } 
            //    if (ints > 0)
            //    { 
            //        base.ShowMessage("操作成功.");
            //    }

            //    childindex = -1;
            //    a.EditIndex = -1;
            //    loadDateDeal(QuestionId, a, childindex, -1);

            //    ScriptManager.RegisterStartupScript(ab, this.Page.GetType(), "", "LoadDetailsBound();", true);
            //    ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
            //}
            #endregion

            #region 赠品/返现
            //if (e.CommandName.Equals("ChildCashBackAndChildPremiums"))
            //{
            //    try
            //    {
            //        //返回赠品条数
            //        int PremiumsInst = 0;
            //        //返回返现条数
            //        int CashBackApplicationInst = 0;

            //        string paramMessage = string.Empty;

            //        //返回赠品信息
            //        //string paramMessagePremiums = string.Empty;
            //        //返回返现信息系
            //        //string paramMessageCashBackApplication = string.Empty;
            //        //获取父级Id 
            //        var hdQId = (HiddenField)(a.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("hdQId"));
            //        int QuestionId = Convert.ToInt32(hdQId.Value);
            //        //当前行Id
            //        var hdId = (HiddenField)(a.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("hdId"));
            //        int Id = Convert.ToInt32(hdId.Value);

            //        //赠品处理
            //        //根据问题反馈明细中的主表Id 查询主表信息 在根据主表中的订单号查询 订单信息 
            //        XMOrderInfo xMOrderInfo = new XMOrderInfo();
            //        //查询问题反馈主表信息
            //        XMQuestion xMQuestion = base.XMQuestionService.GetById(QuestionId);
            //        //根据订单号查询
            //        if (xMQuestion != null)
            //        {
            //            xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMQuestion.OrderNO);
            //            if (xMOrderInfo != null)
            //            {
            //                if (xMOrderInfo.CustomerServiceRemark != null && xMOrderInfo.CustomerServiceRemark != "")
            //                {
            //                    if (xMOrderInfo.CustomerServiceRemark.IndexOf("赠品") > -1 || xMOrderInfo.CustomerServiceRemark.IndexOf("返现") > -1)
            //                    {
            //                        #region 赠品
            //                        if (xMOrderInfo.CustomerServiceRemark.IndexOf("赠品") > -1)
            //                        { 
            //                            PremiumsInst = base.XMOrderInfoAPIService.XMPremiumsInst(xMOrderInfo.CustomerServiceRemark, xMOrderInfo.WantID, xMOrderInfo.OrderCode, Convert.ToInt32(StatusEnum.ChildPremiums), ref paramMessage);

            //                        }
            //                        //else
            //                        //{
            //                        //    paramMessage += "无赠品信息.";
            //                        //}
            //                        #endregion

            //                        #region 返现
            //                        if (xMOrderInfo.CustomerServiceRemark.IndexOf("返现") > -1)
            //                        {
            //                            //生成返现申请
            //                            if (xMOrderInfo.NickID != null && xMOrderInfo.PlatformTypeId != null)
            //                            {
            //                                if (xMOrderInfo.NickID.Value > 0 && xMOrderInfo.PlatformTypeId.Value > 0)
            //                                {
            //                                    int ProjectId = 0;
            //                                    //根据店铺Id查询  取项目Id
            //                                    var XMNick = base.XMNickService.GetXMNickByID(xMOrderInfo.NickID.Value);
            //                                    if (XMNick != null)
            //                                    {
            //                                        if (XMNick.ProjectId != null)
            //                                        {
            //                                            ProjectId = XMNick.ProjectId.Value;
            //                                        }
            //                                    }
            //                                    //根据项目Id 平台类型查询 返现金额
            //                                    var xMDeductionSetUp = base.XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(ProjectId, 476, xMOrderInfo.PlatformTypeId.Value);

            //                                    if (xMDeductionSetUp != null)
            //                                    {
            //                                        //返现
            //                                        if (xMDeductionSetUp.Deduction != null)
            //                                        {
            //                                            CashBackApplicationInst = base.XMOrderInfoAPIService.CashBackApplicationInst(xMOrderInfo.CustomerServiceRemark, xMOrderInfo.WantID, xMOrderInfo.OrderCode, xMOrderInfo.FullName, Convert.ToInt32(StatusEnum.ChildCashBack), xMDeductionSetUp.Deduction.Value, ref paramMessage);
            //                                        }
            //                                    }
            //                                    else
            //                                    {
            //                                        paramMessage += "请设置返现金额.";
            //                                    }
            //                                }
            //                            }
            //                        }
            //                        //else { 
            //                        //    paramMessage += "无返现信息.";
            //                        //}

            //                        #endregion
            //                    }
            //                    else
            //                    { 
            //                        paramMessage += "请确认订单备注信息."; 
            //                    }
            //                }
            //                else
            //                { 
            //                    paramMessage += "请确认订单备注信息."; 
            //                }
            //            }
            //            else
            //            {
            //                paramMessage += "订单号不存在,请确认订单号!.";  
            //            }
            //            if (paramMessage == "")
            //            {
            //                #region 赠品、返现 （修改订单表是否赠品、是否返现）
            //                //赠品、返现 同时返现
            //                if (CashBackApplicationInst > 0 && PremiumsInst > 0)
            //                {
            //                    xMOrderInfo.IsCashBack = true;
            //                    xMOrderInfo.IsSentGifts = true;
            //                    xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
            //                    xMOrderInfo.UpdateDate = DateTime.Now;
            //                    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
            //                    base.ShowMessage("操作成功.");
            //                }
            //                else if (CashBackApplicationInst > 0 || PremiumsInst > 0) //赠品、返现 单个返回
            //                {
            //                    //修改订单返现状态 
            //                    if (CashBackApplicationInst > 0)
            //                    {
            //                        xMOrderInfo.IsCashBack = true;
            //                        xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
            //                        xMOrderInfo.UpdateDate = DateTime.Now;
            //                        base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
            //                        base.ShowMessage("操作成功.");
            //                    }

            //                    //修改订单赠品状态 
            //                    if (PremiumsInst > 0)
            //                    {
            //                        xMOrderInfo.IsSentGifts = true;
            //                        xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
            //                        xMOrderInfo.UpdateDate = DateTime.Now;
            //                        base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
            //                        base.ShowMessage("操作成功.");
            //                    }
            //                }

            //                if (CashBackApplicationInst == 0 && PremiumsInst == 0) //赠品、返现 单个返回
            //                {
            //                    paramMessage += "无赠品、返现信息."; 
            //                }
            //            }
            //            else {

            //                base.ShowMessage(paramMessage);
            //            }

            //            #endregion
            //        }

            //        childindex = -1;
            //        a.EditIndex = -1;
            //        loadDateDeal(QuestionId, a, childindex, -1);

            //        ScriptManager.RegisterStartupScript(ab, this.Page.GetType(), "", "LoadDetailsBound();", true);
            //        ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
            //    }
            //    catch (Exception err)
            //    {
            //        base.ProcessException(err);
            //    }
            //}
            #endregion
        }

        protected void gvQuestionDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridView a = (GridView)sender;

            //最外层UpdatePanel （模板中）
            var ab = this.Master.FindControl("UpdatePanel1");

            var Id = a.DataKeys[e.RowIndex].Value;//取主键Id

            //旧赔付信息
            string OdlResultMsg = "";
            var xMQuestionDetailOdl = base.XMQuestionDetailService.GetById(Convert.ToInt32(Id));

            if (xMQuestionDetailOdl != null)
            {
                if (xMQuestionDetailOdl.ResultsId != null)
                {
                    //处理结果是赔付
                    if (xMQuestionDetailOdl.ResultsId.Value == 473)
                    {
                        if (xMQuestionDetailOdl.ResultMsg != null)
                        {
                            OdlResultMsg = xMQuestionDetailOdl.ResultMsg;
                        }
                    }
                }
            }


            #region  取控件值

            //主表Id
            var hdQId = (HiddenField)a.Rows[e.RowIndex].FindControl("hdQId");
            //问题描述
            var lblEditDescription = (Label)a.Rows[e.RowIndex].FindControl("lblDescriptionEdit");
            //问题描述
            var txtEditDescription = (TextBox)a.Rows[e.RowIndex].FindControl("txtDescriptionEdit");
            //处理结果说明
            var txtResultMsgEdit = (TextBox)a.Rows[e.RowIndex].FindControl("txtResultMsgEdit");

            var lblStatus = (Label)a.Rows[e.RowIndex].FindControl("lblStatus");
            //问题类型
            var ccQuestionType = (DropDownList)a.Rows[e.RowIndex].FindControl("ddlQuestionCategory");
            //问题等级
            var ccQuestionLevel = (CodeControl)a.Rows[e.RowIndex].FindControl("ccQuestionLevel");
            //是否退货
            var ddlIsReturns = (DropDownList)a.Rows[e.RowIndex].FindControl("ddlIsReturns");
            //处理结果
            var ccResultsId = (DropDownList)a.Rows[e.RowIndex].FindControl("ccResultsId");
            //处理状态
            var ddlStatus = (DropDownList)a.Rows[e.RowIndex].FindControl("ddlStatus");

            //是否退货
            int Isreturns = Convert.ToInt32(ddlIsReturns.SelectedValue);
            //处理结果
            int ResultsId = Convert.ToInt32(ccResultsId.SelectedValue);
            #endregion

            //判断选中的问题类型是否是子节点，如不是无法保存，弹出提示框。
            string categoryId = string.Empty;
            if (ccQuestionType != null)
            {
                categoryId = ccQuestionType.SelectedValue;
            }
            if (!string.IsNullOrEmpty(categoryId))
            {
                //查询该问题类型是否是父节点
                var category = base.XMQuestionCategoryService.GetXMQuestionCategoryById(int.Parse(categoryId));
                if (category != null && category.ParentId == 0)
                {
                    base.ShowMessage("问题类型必须选择子级！");
                    return;
                }
            }

            if (QuestionType == "feedback")
            {
                //事务
                using (TransactionScope scope = new TransactionScope())
                {
                    lblEditDescription.Text = "";
                    if (string.IsNullOrEmpty(txtEditDescription.Text.Trim()))
                    {
                        lblEditDescription.Text = "问题描述不能为空";
                        lblEditDescription.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    #region 新增 、修改
                    XMQuestionDetail mXMQuestionDetail = new XMQuestionDetail();
                    if (Convert.ToInt32(Id) == 0) //新增
                    {
                        mXMQuestionDetail.QuestionID = Convert.ToInt32(hdQId.Value);
                        mXMQuestionDetail.QuestionTypeID = Convert.ToInt16(ccQuestionType.SelectedValue);
                        mXMQuestionDetail.Description = txtEditDescription.Text.Trim();
                        mXMQuestionDetail.Status = Convert.ToInt32(QuestionStatusEnum.Submit);
                        mXMQuestionDetail.SrvBeforeCustomerID = HozestERPContext.Current.User.CustomerID; //售前
                        mXMQuestionDetail.IsEnable = false;
                        mXMQuestionDetail.QuestionLevel = ccQuestionLevel.SelectedValue;
                        mXMQuestionDetail.IsReturns = Isreturns == 0 ? false : true;
                        mXMQuestionDetail.CreateTime = DateTime.Now;
                        mXMQuestionDetail.CreateByID = HozestERPContext.Current.User.CustomerID;
                        mXMQuestionDetail.LastModifyByID = HozestERPContext.Current.User.CustomerID;
                        mXMQuestionDetail.LastModifyTime = DateTime.Now;
                        base.XMQuestionDetailService.Insert(mXMQuestionDetail);

                        //修改主表状态
                        IList<XMQuestionDetail> mXMQuestionDetails = base.XMQuestionDetailService.GetQuestionDetails(Convert.ToInt32(hdQId.Value))
                            .OrderBy(p => p.Status.Value).ToList();
                        int iStatus = mXMQuestionDetails[0].Status.Value; //默认将最初开始的状态赋值给订单问题的状态
                        if (Convert.ToInt32(hdQId.Value) != 0)
                        {
                            XMQuestion mXMQuestion = new XMQuestion();
                            mXMQuestion = base.XMQuestionService.GetById(Convert.ToInt32(hdQId.Value));
                            XMQuestionDetail Priority = GetPriority(Convert.ToInt32(hdQId.Value));
                            mXMQuestion.QuestionLevel = Priority.QuestionLevel;
                            mXMQuestion.Status = iStatus;
                            mXMQuestion.LastModifyTime = DateTime.Now;
                            mXMQuestion.LastModifyByID = HozestERPContext.Current.User.CustomerID; //售后
                            base.XMQuestionService.Update(mXMQuestion);
                        }


                    }
                    else //修改
                    {
                        if (Session["ButType"] != null && Session["ButType"] != "")
                        {
                            if (Session["ButType"].ToString() == "ChildDirectorEdit")
                            {
                                //新的处理结果
                                string NewResultMsg = txtResultMsgEdit.Text.Trim();

                                mXMQuestionDetail = base.XMQuestionDetailService.GetById(Convert.ToInt32(Id));
                                mXMQuestionDetail.QuestionTypeID = Convert.ToInt16(ccQuestionType.SelectedValue);
                                mXMQuestionDetail.QuestionLevel = ccQuestionLevel.SelectedValue;
                                mXMQuestionDetail.Description = txtEditDescription.Text.Trim();
                                mXMQuestionDetail.IsReturns = Isreturns == 0 ? false : true;
                                if (txtResultMsgEdit.Text.Trim() != "")
                                {
                                    mXMQuestionDetail.ResultMsg = txtResultMsgEdit.Text.Trim();
                                }
                                if (ResultsId > 0)
                                {
                                    mXMQuestionDetail.ResultsId = ResultsId;
                                }
                                mXMQuestionDetail.LastModifyTime = DateTime.Now;
                                mXMQuestionDetail.LastModifyByID = HozestERPContext.Current.User.CustomerID;
                                base.XMQuestionDetailService.Update(mXMQuestionDetail);

                                Session["ButType"] = null;

                                #region 修改平台备注
                                //处理结果是赔付类型
                                if (ResultsId == 473)
                                {
                                    if (OdlResultMsg != "")
                                    {
                                        //原值与新的值不同
                                        if (OdlResultMsg != txtResultMsgEdit.Text.Trim())
                                        {
                                            XMOrderInfo xMOrderInfo = new XMOrderInfo();

                                            // 根据明细主表Id 查询主表信息
                                            var xMQuestion = base.XMQuestionService.GetById(xMQuestionDetailOdl.QuestionID);

                                            if (xMQuestion != null)
                                            {
                                                //根据订单号 查询订单信息
                                                xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMQuestion.OrderNO);

                                                if (xMOrderInfo != null)
                                                {
                                                    //修改平台备注
                                                    this.PlatformRemark(xMOrderInfo, OdlResultMsg, NewResultMsg);
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion

                                //修改主表状态
                                IList<XMQuestionDetail> mXMQuestionDetails = base.XMQuestionDetailService.GetQuestionDetails(Convert.ToInt32(hdQId.Value))
                                    .OrderBy(p => p.Status.Value).ToList();
                                int iStatus = mXMQuestionDetails[0].Status.Value; //默认将最初开始的状态赋值给订单问题的状态
                                if (Convert.ToInt32(hdQId.Value) != 0)
                                {
                                    XMQuestion mXMQuestion = new XMQuestion();
                                    mXMQuestion = base.XMQuestionService.GetById(Convert.ToInt32(hdQId.Value));
                                    XMQuestionDetail Priority = GetPriority(Convert.ToInt32(hdQId.Value));
                                    mXMQuestion.QuestionLevel = Priority.QuestionLevel;
                                    mXMQuestion.Status = iStatus;
                                    mXMQuestion.LastModifyTime = DateTime.Now;
                                    mXMQuestion.LastModifyByID = HozestERPContext.Current.User.CustomerID; //售后
                                    base.XMQuestionService.Update(mXMQuestion);
                                }
                            }
                        }
                        else
                        {
                            if (lblStatus.Text.Trim() == "提交中")
                            {
                                mXMQuestionDetail = base.XMQuestionDetailService.GetById(Convert.ToInt32(Id));
                                mXMQuestionDetail.QuestionTypeID = Convert.ToInt16(ccQuestionType.SelectedValue);
                                mXMQuestionDetail.Description = txtEditDescription.Text.Trim();
                                mXMQuestionDetail.QuestionLevel = ccQuestionLevel.SelectedValue;
                                mXMQuestionDetail.IsReturns = Isreturns == 0 ? false : true;
                                mXMQuestionDetail.SrvBeforeCustomerID = HozestERPContext.Current.User.CustomerID; //售前
                                mXMQuestionDetail.LastModifyTime = DateTime.Now;
                                mXMQuestionDetail.LastModifyByID = HozestERPContext.Current.User.CustomerID;
                                base.XMQuestionDetailService.Update(mXMQuestionDetail);

                                //修改主表状态
                                IList<XMQuestionDetail> mXMQuestionDetails = base.XMQuestionDetailService.GetQuestionDetails(Convert.ToInt32(hdQId.Value))
                                    .OrderBy(p => p.Status.Value).ToList();
                                int iStatus = mXMQuestionDetails[0].Status.Value; //默认将最初开始的状态赋值给订单问题的状态
                                if (Convert.ToInt32(hdQId.Value) != 0)
                                {
                                    XMQuestion mXMQuestion = new XMQuestion();
                                    mXMQuestion = base.XMQuestionService.GetById(Convert.ToInt32(hdQId.Value));
                                    XMQuestionDetail Priority = GetPriority(Convert.ToInt32(hdQId.Value));
                                    mXMQuestion.QuestionLevel = Priority.QuestionLevel;
                                    mXMQuestion.Status = iStatus;
                                    mXMQuestion.LastModifyTime = DateTime.Now;
                                    mXMQuestion.LastModifyByID = HozestERPContext.Current.User.CustomerID; //售后
                                    base.XMQuestionService.Update(mXMQuestion);
                                }
                            }
                        }
                    }
                    #endregion


                    //重新绑定 
                    childindex = -1;
                    loadDateDeal(Convert.ToInt32(hdQId.Value), a, childindex, -1);


                    this.BindGrid(Master.PageIndex, Master.PageSize);

                    ScriptManager.RegisterStartupScript(ab, this.Page.GetType(), "", "LoadDetailsBound();", true);

                    scope.Complete();

                }
            }
            else if (QuestionType == "dealwith")
            {

                //事务
                using (TransactionScope scope = new TransactionScope())
                {

                    //总监编辑
                    if (Session["ButType"] != null && Session["ButType"] != "")
                    {
                        if (Session["ButType"].ToString() == "ChildDirectorEdit")
                        {
                            if (Convert.ToInt32(Id) != 0) //修改
                            {
                                string NewResultMsg = txtResultMsgEdit.Text.Trim();

                                XMQuestionDetail mXMQuestionDetail = base.XMQuestionDetailService.GetById(Convert.ToInt32(Id));

                                if (Convert.ToInt16(ccQuestionType.SelectedValue) > 0)
                                {
                                    mXMQuestionDetail.QuestionTypeID = Convert.ToInt16(ccQuestionType.SelectedValue);
                                }
                                mXMQuestionDetail.IsReturns = Isreturns == 0 ? false : true;
                                mXMQuestionDetail.QuestionLevel = ccQuestionLevel.SelectedValue;
                                mXMQuestionDetail.ResultMsg = txtResultMsgEdit.Text.Trim();
                                mXMQuestionDetail.ResultsId = ResultsId;
                                //mXMQuestionDetail.Status = Convert.ToInt32(ddlStatus.SelectedValue);
                                mXMQuestionDetail.LastModifyTime = DateTime.Now;
                                mXMQuestionDetail.LastModifyByID = HozestERPContext.Current.User.CustomerID;
                                base.XMQuestionDetailService.Update(mXMQuestionDetail);

                                #region 修改平台备注

                                //处理结果是赔付类型
                                if (ResultsId == 473)
                                {
                                    if (OdlResultMsg != "")
                                    {
                                        //原值与新的值不同
                                        if (OdlResultMsg != txtResultMsgEdit.Text.Trim())
                                        {
                                            XMOrderInfo xMOrderInfo = new XMOrderInfo();

                                            // 根据明细主表Id 查询主表信息
                                            var xMQuestion = base.XMQuestionService.GetById(xMQuestionDetailOdl.QuestionID);

                                            if (xMQuestion != null)
                                            {
                                                //根据订单号 查询订单信息
                                                xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMQuestion.OrderNO);

                                                if (xMOrderInfo != null)
                                                {
                                                    //修改平台备注
                                                    this.PlatformRemark(xMOrderInfo, OdlResultMsg, NewResultMsg);
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion

                                //保存主表数据
                                IList<XMQuestionDetail> mXMQuestionDetails = base.XMQuestionDetailService.GetQuestionDetails(Convert.ToInt32(hdQId.Value))
                                    .OrderBy(p => p.Status.Value).ToList();
                                int iStatus = mXMQuestionDetails[0].Status.Value; //默认将最初开始的状态赋值给订单问题的状态
                                if (Convert.ToInt32(hdQId.Value) != 0)
                                {
                                    XMQuestion mXMQuestion = new XMQuestion();
                                    mXMQuestion = base.XMQuestionService.GetById(Convert.ToInt32(hdQId.Value));
                                    XMQuestionDetail Priority = GetPriority(Convert.ToInt32(hdQId.Value));
                                    mXMQuestion.QuestionLevel = Priority.QuestionLevel;
                                    mXMQuestion.Status = iStatus;
                                    if (Convert.ToInt32(ddlStatus.SelectedValue) == Convert.ToInt32(QuestionStatusEnum.Complete))
                                    {
                                        mXMQuestion.LastModifyTime = DateTime.Now;//完成时间
                                    }
                                    mXMQuestion.LastModifyByID = HozestERPContext.Current.User.CustomerID; //售后
                                    base.XMQuestionService.Update(mXMQuestion);
                                }
                            }
                            Session["ButType"] = null;

                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtResultMsgEdit.Text.Trim()))
                        {
                            txtResultMsgEdit.Text = "处理结果说明不能为空";
                            txtResultMsgEdit.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        //保存从表数据
                        //int QuestionDetailID = Convert.ToInt32(gvQuestionDetail.DataKeys[e.RowIndex].Value.ToString());
                        if (Convert.ToInt32(Id) != 0) //修改
                        {
                            string NewResultMsg = txtResultMsgEdit.Text.Trim();

                            XMQuestionDetail mXMQuestionDetail = base.XMQuestionDetailService.GetById(Convert.ToInt32(Id));

                            if (Convert.ToInt16(ccQuestionType.SelectedValue) > 0)
                            {
                                mXMQuestionDetail.QuestionTypeID = Convert.ToInt16(ccQuestionType.SelectedValue);
                            }
                            mXMQuestionDetail.IsReturns = Isreturns == 0 ? false : true;

                            mXMQuestionDetail.ResultMsg = txtResultMsgEdit.Text.Trim();
                            mXMQuestionDetail.QuestionLevel = ccQuestionLevel.SelectedValue;
                            mXMQuestionDetail.ResultsId = ResultsId;
                            mXMQuestionDetail.Status = Convert.ToInt32(ddlStatus.SelectedValue);
                            mXMQuestionDetail.SrvAfterCustomerID = HozestERPContext.Current.User.CustomerID; //售后
                            if (Convert.ToInt32(ddlStatus.SelectedValue) == Convert.ToInt32(QuestionStatusEnum.Complete))
                            {
                                mXMQuestionDetail.LastModifyTime = DateTime.Now;//完成时间
                            }
                            mXMQuestionDetail.LastModifyByID = HozestERPContext.Current.User.CustomerID;
                            // mXMQuestionDetail.OrdersTime = DateTime.Now;//接单时间
                            base.XMQuestionDetailService.Update(mXMQuestionDetail);

                            #region 修改平台备注

                            //处理结果是赔付类型
                            if (ResultsId == 473)
                            {
                                if (OdlResultMsg != "")
                                {
                                    //原值与新的值不同
                                    if (OdlResultMsg != txtResultMsgEdit.Text.Trim())
                                    {
                                        XMOrderInfo xMOrderInfo = new XMOrderInfo();

                                        // 根据明细主表Id 查询主表信息
                                        var xMQuestion = base.XMQuestionService.GetById(xMQuestionDetailOdl.QuestionID);

                                        if (xMQuestion != null)
                                        {
                                            //根据订单号 查询订单信息
                                            xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMQuestion.OrderNO);

                                            if (xMOrderInfo != null)
                                            {
                                                //修改平台备注
                                                this.PlatformRemark(xMOrderInfo, OdlResultMsg, NewResultMsg);
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion

                        }
                        //保存主表数据
                        IList<XMQuestionDetail> mXMQuestionDetails = base.XMQuestionDetailService.GetQuestionDetails(Convert.ToInt32(hdQId.Value))
                            .OrderBy(p => p.Status.Value).ToList();
                        int iStatus = mXMQuestionDetails[0].Status.Value; //默认将最初开始的状态赋值给订单问题的状态
                        if (Convert.ToInt32(hdQId.Value) != 0)
                        {
                            XMQuestion mXMQuestion = new XMQuestion();
                            mXMQuestion = base.XMQuestionService.GetById(Convert.ToInt32(hdQId.Value));
                            XMQuestionDetail Priority = GetPriority(Convert.ToInt32(hdQId.Value));
                            mXMQuestion.QuestionLevel = Priority.QuestionLevel;
                            mXMQuestion.Status = iStatus;
                            if (Convert.ToInt32(ddlStatus.SelectedValue) == Convert.ToInt32(QuestionStatusEnum.Complete))
                            {
                                mXMQuestion.LastModifyTime = DateTime.Now;//完成时间
                            }
                            mXMQuestion.LastModifyByID = HozestERPContext.Current.User.CustomerID; //售后
                            base.XMQuestionService.Update(mXMQuestion);
                        }
                    }

                    childindex = a.EditIndex;
                    loadDateDeal(Convert.ToInt32(hdQId.Value), a, childindex, -1);

                    this.BindGrid(Master.PageIndex, Master.PageSize);

                    ScriptManager.RegisterStartupScript(ab, this.Page.GetType(), "", "LoadDetailsBound();", true);

                    ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);

                    scope.Complete();

                }
            }
        }

        #endregion

        /// <summary>
        /// 处理结果：赔付 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void hidBtnDealPaymentdealwith_Click(object sender, EventArgs e)
        //{

        //    if (Session["SelectPaymentDetails"] == null)
        //        return;
        //    try
        //    {
        //         if (Session["ddlPaymentControls"] != null && Session["ddlPaymentControls"] != "")
        //        { 
        //            var upl = this.Master.FindControl("UpdatePanel1"); 
        //            //处理结果下拉框 
        //            DropDownList ddl = (DropDownList)Session["ddlPaymentControls"];

        //            var hdQId = (HiddenField)(ddl.FindControl("hdQId"));//父级Id

        //             int QuestionId=-1;

        //             if (hdQId != null)
        //             {
        //                 QuestionId = Convert.ToInt32(hdQId.Value);
        //             }


        //            //处理结果说明
        //             var txtResultMsgEditId = "";
        //            var txtResultMsgEdit = (TextBox)(ddl.FindControl("txtResultMsgEdit"));
        //            if (txtResultMsgEdit != null)
        //            {
        //                //txtResultMsgEdit.Text = Session["SelectPaymentDetails"].ToString();
        //              txtResultMsgEditId= txtResultMsgEdit.ClientID;
        //            }
        //            //ctl00_ContentPlaceHolder2_gvQuestion_ctl02_gvQuestionDetail_ctl03_txtResultMsgEdit

        //            var SelectPaymentDetailsValue = Session["SelectPaymentDetails"].ToString();

        //            ScriptManager.RegisterStartupScript(this.hidBtnDealPaymentdealwith, this.Page.GetType(), "", "LoadDetailsBoundIndexId(" + QuestionId + ",'" + txtResultMsgEditId + "','" + SelectPaymentDetailsValue + "');", true);
        //            //ScriptManager.RegisterStartupScript(this.hidBtnDealPaymentdealwith, this.Page.GetType(), "", "LoadDetailsBoundIndexId(" + QuestionId + "," + txtResultMsgEditId + ");", true);


        //            //明细锁定在当前行
        //            //ScriptManager.RegisterStartupScript(upl, this.Page.GetType(), "", "LoadDetailsBound();", true);
        //            //主表订单号处理
        //            //ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);

        //            Session["SelectPaymentDetails"] = null;
        //            Session["ddlPaymentControls"] = null;

        //        }


        //       // this.Master.JsWrite("alert('确认成功。');RefreshSearch();", ""); 

        //    }
        //    catch (Exception err)
        //    {
        //        base.ProcessException(err);
        //    }
        //}

        /// <summary>
        /// 处理结果 ：赔付 （弹出赔付窗口）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void ccResultsId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddl = (DropDownList)sender;

        //    //最外层UpdatePanel （模板中）
        //    var upl = this.Master.FindControl("UpdatePanel1");

        //    GridView gv = (GridView)ddl.Parent.Parent.Parent.Parent; 

        //    //处理结果：赔付
        //    if (ddl.SelectedValue.ToString() == "473")
        //    { 
        //        //处理结果下拉框
        //        this.ddlPaymentControls = ddl;


        //        string paramScript = "ShowWindowDetail1('b-win','赔付说明','" + CommonHelper.GetStoreLocation() +
        //            "ManageProject/PaymentDetailsManage.aspx',500,200, this, function(){document.getElementById('"
        //            + this.hidBtnDealPaymentdealwith.ClientID + "').click();});";
        //        this.Master.JsWrite(paramScript, ""); 

        //    }
        //    else {
        //         //明细锁定在当前行
        //        ScriptManager.RegisterStartupScript(upl, this.Page.GetType(), "", "LoadDetailsBound();", true);
        //        //主表订单号处理
        //        ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);

        //    } 
        //}

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    #region 订单创建日期
                    if (!string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()))
                    {
                        if (string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
                        {
                            base.ShowMessage("请输入问题结束日期");
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
                    {
                        if (string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()))
                        {
                            base.ShowMessage("请输入问题开始日期");
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim())
                        && !string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
                    {
                        DateTime dt = new DateTime();
                        if (!DateTime.TryParse(txtBeginDate.ctlDateTime.Text.Trim(), out dt))
                        {
                            base.ShowMessage("问题开始日期输入错误");
                            return;
                        }
                        if (!DateTime.TryParse(txtEndDate.ctlDateTime.Text.Trim(), out dt))
                        {
                            base.ShowMessage("问题结束日期输入错误");
                            return;
                        }

                        if (DateTime.Parse(txtEndDate.ctlDateTime.Text.Trim()) < DateTime.Parse(txtBeginDate.ctlDateTime.Text.Trim()))
                        {
                            base.ShowMessage("问题结束日期不能小于开始日期");
                            return;
                        }
                    }

                    #endregion

                    var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
                    int nickID = 0;
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
                    int platFormID = 0;
                    int.TryParse(this.ddlPlatform.SelectedValue, out platFormID);
                    int statusID = 0;
                    int.TryParse(this.ddlStatus.SelectedValue, out statusID);
                    List<int> questionTypeIDs = new List<int>();
                    if (int.Parse(ddlQCategory.SelectedValue) > 0)
                    {
                        //判断是否是父节点
                        int categoryID = int.Parse(ddlQCategory.SelectedValue);
                        var category = base.XMQuestionCategoryService.GetXMQuestionCategoryById(categoryID);
                        if (category != null && category.ParentId == 0)                                        //该问题类型为父节点
                        {
                            //查询该父节点类型下的子节点
                            var childCategory = base.XMQuestionCategoryService.GetXMQuestionCategoryByParentID(category.Id);
                            if (childCategory != null && childCategory.Count() > 0)
                            {
                                foreach (XMQuestionCategory str in childCategory)
                                {
                                    questionTypeIDs.Add(str.Id);
                                }
                            }
                        }
                        else                                                                                           //该问题类型为子节点
                        {
                            questionTypeIDs.Add(categoryID);
                        }
                    }
                    //是否超时
                    int TheResults = -1;
                    int.TryParse(this.ddlTheResults.SelectedValue, out TheResults);

                    var QuestionDetailList = base.XMQuestionService.XMQuestionSearchList(this.txtOrderNO.Text.Trim(), xMProjectId, nickids, this.txtBeginDate.SelectedDate
                        , this.txtEndDate.SelectedDate, platFormID, statusID, "", "", this.txtSrvAfterCustomerID.Text.Trim(), questionTypeIDs, ""
                        , this.lastStartDate.SelectedDate, this.lastEndDate.SelectedDate, TheResults, this.txtBuyer.Text.Trim(), int.Parse(this.ddlQuestionLevel.SelectedValue));

                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\QuestionDetailExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                    base.ExportManager.ExportQuestionDetailToXls(filePath, QuestionDetailList);

                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }

                ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
            }

        }

        /// <summary>
        /// 移交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTransfer_SelectedCustomer(object sender, Modules.SelectedCustomerEventArgs e)
        {
            if (e.SelectSingleCustomer == null)
                return;
            try
            {

                string commandArgument = ((ImageButton)sender).CommandArgument.ToString();

                var ab = this.Master.FindControl("UpdatePanel1");

                if (commandArgument != "")
                {

                    int ID = 0;
                    int.TryParse(commandArgument, out ID);
                    //移交的售后
                    int LastModifyByID = e.SelectSingleCustomer.SCustomer.CustomerID;
                    if (Convert.ToInt32(ID) != 0)
                    {
                        var questionDetail = base.XMQuestionDetailService.GetById(ID);
                        if (questionDetail != null)
                        {
                            questionDetail.SrvAfterCustomerID = LastModifyByID;
                            base.XMQuestionDetailService.Update(questionDetail);

                            //保存主表数据 (修改售后)

                            XMQuestion mXMQuestion = new XMQuestion();
                            mXMQuestion = base.XMQuestionService.GetById(questionDetail.QuestionID);
                            mXMQuestion.LastModifyByID = LastModifyByID; //售后
                            base.XMQuestionService.Update(mXMQuestion);
                        }

                    }
                    //loadDateDeal(Id, a, -1, -1); 
                    this.BindGrid(Master.PageIndex, Master.PageSize);
                    //ScriptManager.RegisterStartupScript(ab, this.Page.GetType(), "", "LoadDetailsBound();", true);
                    base.ShowMessage("操作成功.");
                }

            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
            ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        ///// <summary>
        ///// 赠品
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void imgBtnDealPremiums_Click(object sender, EventArgs e)
        //{

        //}

        ///// <summary>
        ///// 返现
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void imgBtnDealCashBack_Click(object sender, EventArgs e)
        //{
        //}

        ///// <summary>
        ///// 赔付
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void imgBtnDealPayment_Click(object sender, EventArgs e)
        //{
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="QuestionId"></param>
        //private void PremiumsGenerate(int QuestionId) {   
        //}
        /// <summary>
        /// 完成率计算
        /// </summary>
        private void CompletionRate(List<int> questionTypeIDs)
        {

            //及时接单率统计
            if (!string.IsNullOrEmpty(lastStartDate.ctlDateTime.Text.Trim())
                && !string.IsNullOrEmpty(lastEndDate.ctlDateTime.Text.Trim()))
            {
                //string questionTypeIDs = "-1";
                //var codelist = base.CodeService.GetCodeListByCodeTypeIDCodeNo(175, "NoPerformance");
                //if (codelist.Count != 0)
                //{
                //    questionTypeIDs = string.Join(",", codelist.Select(p => p.CodeID));
                //}

                //问题类型
                string questionTypeIDstr = "-1";
                if (questionTypeIDs.Count > 0)
                {
                    questionTypeIDstr = string.Join(",", questionTypeIDs);
                }
                //完成总条数 （排除带* 号的问题类型）
                int iCount = base.XMQuestionDetailService.GetQuestionDetailsBySubmit(lastStartDate.ctlDateTime.Text.Trim(),
                    lastEndDate.ctlDateTime.Text.Trim(), txtSrvAfterCustomerID.Text.Trim(), questionTypeIDstr).Count;
                if (iCount == 0)
                {
                    this.lblCompleteRateResult.Text = "0%";
                    //CompleteRateResult = "0%";
                }
                else
                {
                    //完成条数（最后处理时间与创建时间小于3天）
                    int iComplete = base.XMQuestionDetailService.GetQuestionDetailsByComplete(lastStartDate.ctlDateTime.Text.Trim(),
                   lastEndDate.ctlDateTime.Text.Trim(), txtSrvAfterCustomerID.Text.Trim(), questionTypeIDstr).Count;
                    decimal d = Convert.ToDecimal(iComplete) / Convert.ToDecimal(iCount);
                    this.lblCompleteRateResult.Text = " " + iComplete + " / " + iCount + "=" + (Math.Round(d * 100, 2)).ToString() + "%";
                    //CompleteRateResult = " " + iComplete + " / " + iCount + "=" + (Math.Round(d * 100, 2)).ToString() + "%";
                }
            }
        }

        /// <summary>
        /// 退货挽回率
        /// </summary>
        /// <param name="questionTypeIDs"></param>
        private void ReturnsRedeemRate()
        {


            //退货挽回率统计
            if (!string.IsNullOrEmpty(lastStartDate.ctlDateTime.Text.Trim())
                && !string.IsNullOrEmpty(lastEndDate.ctlDateTime.Text.Trim()))
            {

                //根据问题提交时间获取是退货集合
                int iCount = base.XMQuestionDetailService.GetQuestionDetailsByIsReturnsTrue(lastStartDate.ctlDateTime.Text.Trim(),
                    lastEndDate.ctlDateTime.Text.Trim(), txtSrvAfterCustomerID.Text.Trim()).Count;
                if (iCount == 0)
                {
                    this.lblReturnsRedeemRate.Text = "0%";
                    //CompleteRateResult = "0%";

                }
                else
                {
                    //根据问题提交时间查找处理结果是退货（实际退货）
                    int iReturns = base.XMQuestionDetailService.GetQuestionDetailsByResultsCount(lastStartDate.ctlDateTime.Text.Trim(),
                   lastEndDate.ctlDateTime.Text.Trim(), txtSrvAfterCustomerID.Text.Trim()).Count;

                    decimal d = Convert.ToDecimal(iCount - iReturns) / Convert.ToDecimal(iCount);
                    this.lblReturnsRedeemRate.Text = " (" + iCount + "-" + iReturns + ") / " + iCount + "=" + (Math.Round(d * 100, 2)).ToString() + "%";
                }
            }
        }

        /// <summary>
        /// 平台备注修改
        /// </summary>
        private void PlatformRemark(XMOrderInfo xMOrderInfo, string OdlResultMsg, string NewResultMsg)
        {

            //新的备注信息
            string NewRemark = "";

            #region 修改平台后台备注信息

            var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();
            List<XMOrderInfoApp> xMorderInfoAppNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == xMOrderInfo.PlatformTypeId.Value && q.NickId == xMOrderInfo.NickID.Value).ToList();
            for (int i = 0; i < xMorderInfoAppNew.Count; i++)
            {
                #region  京东、京东闪购
                if (xMorderInfoAppNew[i].PlatformTypeId == 251 || xMorderInfoAppNew[i].PlatformTypeId == 382)//|| xMorderInfoAppNew[i].PlatformTypeId == 310)
                {
                    VenderRemark VResult = new VenderRemark();
                    string OrderRemark = "";//商家备注
                    if (xMOrderInfo.OrderCode != "")
                    {
                        #region 同步平台备注信息
                        VResult = base.XMOrderInfoAPIService.GetOrderVenderRemark(xMOrderInfo.OrderCode, xMorderInfoAppNew[i]);// base.ProjectService.GetOrderVenderRemark(OrderId);//,orderInfoApp
                        if (VResult != null)
                        {
                            OrderRemark = VResult.Remark;
                            if (OrderRemark != "")
                            {
                                // string a = "1111222333";
                                // string aO="222";
                                // string aN="555"; 
                                //string c = a.Replace(aO, aN); 

                                string NewOrderRemark = "";
                                if (OrderRemark.IndexOf(OdlResultMsg) > -1)
                                {
                                    //最新备注信息
                                    NewOrderRemark = OrderRemark.Replace(OdlResultMsg, NewResultMsg);

                                    NewRemark = NewOrderRemark;
                                }
                                else
                                {
                                    //从新拼接 备注信息
                                    NewRemark = OrderRemark + "/" + NewResultMsg;
                                }

                                #region 平台后台修改备注、订单备注
                                if (NewRemark != "")
                                {
                                    //修改备注
                                    var orderVenderRemark = base.XMOrderInfoAPIService.SetOrderVenderRemark(xMOrderInfo.OrderCode, NewRemark, "", xMorderInfoAppNew[i]);

                                    xMOrderInfo.CustomerServiceRemark = NewRemark;

                                    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                    //新的备注信息
                                    NewRemark = "";
                                }
                                #endregion

                            }
                        }
                        #endregion

                    }
                }
                #endregion

                #region  淘宝、淘宝集市店
                else if (xMorderInfoAppNew[i].PlatformTypeId == 250 || xMorderInfoAppNew[i].PlatformTypeId == 381)
                {

                    int TMInsertCount = 0;
                    int TMUpdateCount = 0;

                    Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(xMOrderInfo.OrderCode), xMorderInfoAppNew[i]);
                    if (trade != null)
                    {
                        base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoAppNew[i]);

                        if (TMUpdateCount > 0)
                        {

                            #region 同步最新订单信息 并取备注信息

                            var xMOrderInfoTMNew = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(xMOrderInfo.OrderCode);

                            if (xMOrderInfoTMNew.Count > 0)
                            {
                                if (xMOrderInfoTMNew[0].CustomerServiceRemark != "")
                                {
                                    string OrderRemark = xMOrderInfoTMNew[0].CustomerServiceRemark;

                                    string NewOrderRemark = "";
                                    if (OrderRemark.IndexOf(OdlResultMsg) > -1)
                                    {
                                        //最新备注信息
                                        NewOrderRemark = OrderRemark.Replace(OdlResultMsg, NewResultMsg);

                                        NewRemark = NewOrderRemark;
                                    }
                                    else
                                    {
                                        //从新拼接 备注信息
                                        NewRemark = OrderRemark + "/" + NewResultMsg;
                                    }

                                    #region 平台后台修改备注
                                    if (NewRemark != "")
                                    {
                                        //修改备注
                                        var tradeMemoUpdate = base.XMOrderInfoAPIService.ReturnTradeMemoUpdate(Convert.ToInt64(xMOrderInfo.OrderCode), NewRemark, xMorderInfoAppNew[i]);

                                        xMOrderInfo.CustomerServiceRemark = NewRemark;
                                        base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                        //新的备注信息
                                        NewRemark = "";

                                    }

                                    #endregion

                                }
                            }
                            #endregion

                        }
                    }

                }
                #endregion

                #region 一号店
                else if (xMorderInfoAppNew[i].PlatformTypeId == 375)
                {
                    int YHDInsertCount = 0;
                    int YHDUpdateCount = 0; //返回更新的条数

                    //根据订单号获取一号店 订单信息
                    base.XMOrderInfoAPIService.getOrderYHD(xMOrderInfo.OrderCode, ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoAppNew[i]);

                    if (YHDUpdateCount > 0)
                    {

                        #region 同步最新订单信息 并取备注信息

                        var xMOrderInfoTMNew = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(xMOrderInfo.OrderCode);

                        if (xMOrderInfoTMNew.Count > 0)
                        {
                            if (xMOrderInfoTMNew[0].CustomerServiceRemark != "")
                            {
                                string OrderRemark = xMOrderInfoTMNew[0].CustomerServiceRemark;

                                string NewOrderRemark = "";
                                if (OrderRemark.IndexOf(OdlResultMsg) > -1)
                                {
                                    //最新备注信息
                                    NewOrderRemark = OrderRemark.Replace(OdlResultMsg, NewResultMsg);

                                    NewRemark = NewOrderRemark;
                                }
                                else
                                {
                                    //从新拼接 备注信息
                                    NewRemark = OrderRemark + "/" + NewResultMsg;
                                }

                                #region 平台后台修改备注
                                if (NewRemark != "")
                                {
                                    //修改备注 
                                    base.XMOrderInfoAPIService.OrderMerchantRemarkUpdate(xMOrderInfo.OrderCode, NewRemark, xMorderInfoAppNew[i]);


                                    xMOrderInfo.CustomerServiceRemark = NewRemark;
                                    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);

                                    //新的备注信息
                                    NewRemark = "";

                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                }
                #endregion

                #region  苏宁易购
                else if (xMorderInfoAppNew[i].PlatformTypeId == 383)
                {
                    int SuningInsertCount = 0;
                    int SuningUpdateCount = 0;

                    base.XMOrderInfoAPIService.getOrderSuning(xMOrderInfo.OrderCode, ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoAppNew[i]);

                    if (SuningUpdateCount > 0)
                    {


                        #region 同步最新订单信息 并取备注信息

                        var xMOrderInfoSNNew = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(xMOrderInfo.OrderCode);

                        if (xMOrderInfoSNNew.Count > 0)
                        {
                            if (xMOrderInfoSNNew[0].CustomerServiceRemark != "")
                            {
                                string OrderRemark = xMOrderInfoSNNew[0].CustomerServiceRemark;

                                string NewOrderRemark = "";
                                if (OrderRemark.IndexOf(OdlResultMsg) > -1)
                                {
                                    //最新备注信息
                                    NewOrderRemark = OrderRemark.Replace(OdlResultMsg, NewResultMsg);

                                    NewRemark = NewOrderRemark;
                                }
                                else
                                {
                                    //从新拼接 备注信息
                                    NewRemark = OrderRemark + "/" + NewResultMsg;
                                }

                                #region 平台后台修改备注
                                if (NewRemark != "")
                                {
                                    string colorMarkFlag = "";
                                    if (OrderRemark.IndexOf("已提单") > -1)
                                    {
                                        colorMarkFlag = "2";//交易备注旗帜, 空表示灰色， 1表示红色， 2表示黄色， 3表示绿色， 4表示蓝色， 5表示紫色
                                    }
                                    else
                                    {
                                        colorMarkFlag = "1";
                                    }

                                    //修改备注
                                    var tradeMemoUpdate = base.XMOrderInfoAPIService.OrdernoteModifyUpdate(xMOrderInfo.OrderCode, NewRemark, colorMarkFlag, xMorderInfoAppNew[i]);

                                    if (tradeMemoUpdate != null && tradeMemoUpdate != "")
                                    {
                                        if (tradeMemoUpdate == "Y")
                                        {
                                            xMOrderInfo.CustomerServiceRemark = NewRemark;
                                            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                        }
                                    }
                                    //新的备注信息
                                    NewRemark = "";

                                }

                                #endregion

                            }
                        }
                        #endregion

                    }

                }
                #endregion

                #region  唯品会
                //else if (xMorderInfoAppNew[i].PlatformTypeId == 259)
                //{

                //    int VPHInsertCount = 0;
                //    int VPHUpdateCount = 0;

                //    base.XMOrderInfoAPIService.getOrderVPH(xMOrderInfo.OrderInfoCreateDate.Value.AddDays(-2).ToString("yyyy-MM-dd HH:mm:ss"),
                //        xMOrderInfo.OrderInfoCreateDate.Value.AddDays(+2).ToString("yyyy-MM-dd HH:mm:ss"), xMOrderInfo.OrderCode, ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoAppNew[i]);

                //    if (VPHUpdateCount > 0)
                //    { 
                //        #region 同步最新订单信息 并取备注信息

                //        var xMOrderInfoVPHNew = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(xMOrderInfo.OrderCode);

                //        if (xMOrderInfoVPHNew.Count > 0)
                //        {
                //            if (xMOrderInfoVPHNew[0].CustomerServiceRemark != "")
                //            {
                //                string OrderRemark = xMOrderInfoVPHNew[0].CustomerServiceRemark;

                //                //从新拼接 备注信息
                //                NewRemark = OrderRemark + "/" + xMQuestionDetail.ResultMsg;

                //                #region 平台后台修改备注
                //                if (NewRemark != "")
                //                {
                //                    //修改备注
                //                    //var tradeMemoUpdate = base.XMOrderInfoAPIService.OrdernoteModifyUpdate(xMOrderInfo.OrderCode, NewRemark, xMorderInfoAppNew[i]);

                //                    xMOrderInfo.CustomerServiceRemark = NewRemark;
                //                    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                //                    //新的备注信息
                //                    NewRemark = "";

                //                }

                //                #endregion

                //            }
                //        }
                //        #endregion

                //    }
                //}
                #endregion
            }

            #endregion
        }

        public int RowEditIndex
        {
            get
            {
                int editIndex = -1;
                try
                {
                    int.TryParse(ViewState["RowEditIndex"].ToString(), out editIndex);
                }
                catch
                {
                }
                return editIndex;
            }
            set
            {
                ViewState["RowEditIndex"] = value;
            }
        }

        public int RowEditIndexDetail
        {
            get
            {
                int editIndex = -1;
                try
                {
                    int.TryParse(ViewState["RowEditIndexDetail"].ToString(), out editIndex);
                }
                catch
                {
                }
                return editIndex;
            }
            set
            {
                ViewState["RowEditIndexDetail"] = value;
            }
        }

        //public int QuestionId = 0;

        /// <summary>
        /// 问题类型： feedback：反馈 ；dealwith：处理
        /// </summary>
        public string QuestionType
        {
            get
            {
                return CommonHelper.QueryString("QuestionType");// Request.Params["QuestionType"];
            }
        }

        //总监编辑
        public string ButType
        {
            get
            {
                try
                {
                    return (Session["ButType"] as string);
                }
                catch
                {
                }
                return string.Empty;
            }
            set
            {
                Session["ButType"] = value;
            }
        }

        /// <summary>
        /// 处理结果控件（处理结果：赔付） 上级GridView
        /// </summary>
        //public Control GridViewPaymentControls
        //{
        //    get
        //    {
        //        try
        //        {
        //            return (Session["GridViewPaymentControls"] as Control);
        //        }
        //        catch
        //        {
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        Session["GridViewPaymentControls"] = value;
        //    }
        //}

        /// <summary>
        /// 处理结果控件（处理结果：赔付） 当前选中的控件
        /// </summary>
        public Control ddlPaymentControls
        {
            get
            {
                try
                {
                    return (Session["ddlPaymentControls"] as Control);
                }
                catch
                {
                }
                return null;
            }
            set
            {
                Session["ddlPaymentControls"] = value;
            }
        }

        public XMQuestionDetail GetPriority(int QuestionID)
        {
            XMQuestionDetail a = new XMQuestionDetail();
            var list = base.XMQuestionDetailService.GetQuestionDetails(QuestionID);
            if (list != null && list.Count > 0)
            {
                int QuestionStatus = 3;
                int QuestionLevel = 0;
                int CodeOrder = 0;
                foreach (XMQuestionDetail info in list)
                {
                    if (info.Status < QuestionStatus)
                    {
                        QuestionStatus = (int)info.Status;
                    }
                    if (info.QuestionLevel != null)
                    {
                        var code = base.CodeService.GetCodeListInfoByCodeID((int)info.QuestionLevel);
                        if (code.DisplayOrder > CodeOrder)
                        {
                            QuestionLevel = (int)info.QuestionLevel;
                            CodeOrder = code.DisplayOrder;
                        }
                    }
                }
                a.Status = QuestionStatus;
                a.QuestionLevel = QuestionLevel;
                return a;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 处理结果说明
        /// </summary>
        //public string ResultMsgEdit
        //{
        //    get
        //    {
        //        try
        //        {
        //            return (Session["ResultMsgEdit"] as string);
        //        }
        //        catch
        //        {
        //        }
        //        return string.Empty;
        //    }
        //    set
        //    {
        //        Session["ResultMsgEdit"] = value;
        //    }
        //}
    }
}
