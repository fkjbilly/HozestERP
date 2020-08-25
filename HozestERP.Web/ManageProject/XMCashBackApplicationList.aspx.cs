using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{

    public partial class XMCashBackApplicationList : BaseAdministrationPage, ISearchPage
    {
        /// <summary>
        /// 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnDelete", "XMCashBackApplicationList.Delete");//删除
                buttons.Add("btnManagerStatus", "XMCashBackApplicationList.ManagerStatus");//项目审核
                buttons.Add("btnManagerStatusNo", "XMCashBackApplicationList.ManagerStatusNo");//项目反通过
                buttons.Add("btnCashBackStatus", "XMCashBackApplicationList.CashBackStatus");//已返现
                buttons.Add("ImgBtnCR", "XMCashBackApplicationList.update");//编辑
                buttons.Add("AddCash", "XMCashBackApplicationList.add");//新增
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindddXMProject();//项目 
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnFinanceIsAudit.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnManagerStatus.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnManagerStatusNo.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnDirectorStatus.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnDirectorStatusNO.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;

            //平台类型动态数据绑定
            this.ddlPlatform.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatform.DataSource = codeList;
            this.ddlPlatform.DataTextField = "CodeName";
            this.ddlPlatform.DataValueField = "CodeID";
            this.ddlPlatform.DataBind();
            this.ddlPlatform.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
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

            //订单号
            string txtOrderCode = this.txtOrderCode.Text.Trim();
            //旺旺号
            string txtWantNo = this.txtWantNo.Text.Trim();
            //收款账号
            string txtBuyerAlipayNo = this.txtBuyerAlipayNo.Text.Trim();

            //int ddFinanceIsAudit = Convert.ToInt32(this.ddFinanceIsAudit.SelectedValue);//财务审核
            //int ddDirectorStatus= Convert.ToInt32(this.ddDirectorStatus.SelectedValue);//总监审核
            int ddCashBackStatus = Convert.ToInt32(this.ddCashBackStatus.SelectedValue);//返现状态
            int ApplicationTypeId = Convert.ToInt32((this.ddApplicationTypeId.SelectedValue));//申请类型
            //int  ddManagerStatus= Convert.ToInt32(this.ddManagerStatus.SelectedValue);//项目审核
            int ddXMProject = Convert.ToInt32(this.ddXMProject.SelectedValue);//项目
            int ddlNick = Convert.ToInt32(this.ddlNick.SelectedValue);//店铺
            string nickids = "";
            //if (ddlNick == 99) //某个项目店铺权限，选择有权限的店铺
            //{
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", -1, ddXMProject, HozestERPContext.Current.User.CustomerID, 0);
                for (int i = 0; i < nickList.Count; i++)
                {
                    nickids = nickids + nickList[i].nick_id + ",";
                }
                if (nickids.Length > 0)
                {
                    nickids = nickids.Substring(0, nickids.Length - 1);
                }
            //}
            //else
            //{
            //    nickids = ddlNick.ToString();
            //}

            int ddlPlatform = Convert.ToInt32(this.ddlPlatform.SelectedValue);//平台

            // 项目审核状态：-1：所以、3：未审核、4：已审核、5：未通过
            int ManagerStatus = -1;
            if (TabPanelCashBackApplicationType == "All")
            {
                ManagerStatus = -1;
            }
            else if (TabPanelCashBackApplicationType == "ManagerStatusNotCheck")
            {
                //未审核
                ManagerStatus = 3;

            }
            else if (TabPanelCashBackApplicationType == "ManagerStatusAlreadyCheck")
            {
                //已审核
                ManagerStatus = 4;
            }
            //else if (TabPanelCashBackApplicationType == "ManagerStatusDidNotPass")
            //{
            //    //未通过
            //    ManagerStatus = 5;
            //}
            var max = DateTime.Now;
            if (this.txtEndDate.SelectedDate.HasValue)
            {
                max = this.txtEndDate.SelectedDate.Value.AddDays(1).AddSeconds(-1);
            }
            //根据 订单号、旺旺号、收款账号 查询。
            //var xMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationList(this.txtBeginDate.SelectedDate, max, ddXMProject, nickids, ddlPlatform, txtOrderCode, txtWantNo, txtBuyerAlipayNo, ManagerStatus, ddCashBackStatus, ApplicationTypeId);
            List<XMCashBackApplication> xMCashBackApplicationList = null;

            if (TabPanelCashBackApplicationType == "ManagerStatusNoOrder")
            {
                xMCashBackApplicationList = XMCashBackApplicationService.GetXMCashBackApplicationListNoOrder(this.txtBeginDate.SelectedDate, max, nickids, ddXMProject, txtOrderCode, txtWantNo, txtBuyerAlipayNo, ManagerStatus, ddCashBackStatus, ApplicationTypeId);
            }
            else
            {
                //根据 订单号、旺旺号、收款账号 查询。
                xMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationList(this.txtBeginDate.SelectedDate, max, ddXMProject, nickids, ddlPlatform, txtOrderCode, txtWantNo, txtBuyerAlipayNo, ManagerStatus, ddCashBackStatus, ApplicationTypeId);
            }

                //分页
            var xMCashBackApplicationPageList = new PagedList<XMCashBackApplication>(xMCashBackApplicationList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            //if (this.RowEditIndex == -1)
            //{
            //    //新增编码行
            //    this.gvXMCashBackApplicationList.EditIndex = xMCashBackApplicationPageList.Count();
            //    xMCashBackApplicationPageList.Add(new XMCashBackApplication());
            //}
            //else
            //{
            //    this.gvXMCashBackApplicationList.EditIndex = this.RowEditIndex;
            //}
            this.Master.BindData(this.gvXMCashBackApplicationList, xMCashBackApplicationPageList, paramPageSize + 1);
        }

        #endregion

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvXMCashBackApplicationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                int Id = 0;
                if (int.TryParse(this.gvXMCashBackApplicationList.DataKeys[e.RowIndex].Value.ToString(), out Id))
                {
                    // 产品信息
                    var xMCashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);
                    if (xMCashBackApplication != null)
                    {
                        xMCashBackApplication.IsEnable = true;
                        xMCashBackApplication.UpdatorID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        xMCashBackApplication.UpdateTime = DateTime.Now;
                        base.XMCashBackApplicationService.UpdateXMCashBackApplication(xMCashBackApplication);

                        //var xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMCashBackApplication.OrderCode);
                        //if (xMOrderInfo != null)
                        //{
                        //    #region 修改订单赔付状态
                        //    xMOrderInfo.IsEvaluate = false;//未赔付
                        //    xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        //    xMOrderInfo.UpdateDate = DateTime.Now;
                        //    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);

                        //    #endregion
                        //}

                    }
                }
                scope.Complete();
            }
            //grid 绑定
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("删除成功.");

            ScriptManager.RegisterStartupScript(this.gvXMCashBackApplicationList, this.Page.GetType(), "XMCashBackApplication", "autoCompleteBind()", true);
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 522)
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362);
                //.Where(c => c.ProjectTypeId == 362 && c.Id != 3 && c.Id != 5);

                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                //.Where(c => c.ProjectTypeId == 362 && c.Id != 3 && c.Id != 5)
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362)
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
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion
            //var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362 && c.Id != 3 && c.Id != 5);
            //this.ddXMProject.DataSource = projectList;
            //this.ddXMProject.DataTextField = "ProjectName";
            //this.ddXMProject.DataValueField = "Id";
            //this.ddXMProject.DataBind();
            //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        //店铺数据绑定
        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 522)
                {
                    //.Where(c => c.nick_id != 6 && c.nick_id != 8)
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
                    //其他.Where(c => c.nick_id != 6 && c.nick_id != 8)
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
                //var nickList = base.XMNickService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue))
                //    .Where(c => c.nick_id != 6 && c.nick_id != 8);
                //this.ddlNick.DataSource = nickList;
                //this.ddlNick.DataTextField = "nick";
                //this.ddlNick.DataValueField = "nick_id";
                //this.ddlNick.DataBind();
                //this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvXMCashBackApplicationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var XMConsultation = (XMCashBackApplication)e.Row.DataItem;
            ImageButton ImgBtnCR = e.Row.FindControl("ImgBtnCR") as ImageButton;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (XMConsultation != null)
                {
                    #region 返现修改
                    if (XMConsultation.Id != 0)
                    {
                        string paramScript1 = "return ShowWindowDetail('修改返现明细','" + CommonHelper.GetStoreLocation()
                            + "ManageProject/XMCashBackApplicationAdd.aspx?type=" + 2
                            + "&scid=" + XMConsultation.Id
                            + "', 800, 590, this,  function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";
                        if (ImgBtnCR != null) ImgBtnCR.Attributes.Add("onclick", paramScript1);
                    }
                    #endregion
                }
            }

            var xMCashBackApplication = (XMCashBackApplication)e.Row.DataItem;

            if (e.Row.RowState == DataControlRowState.Edit ||
                e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                DropDownList ddApplicationTypeIdEdit = (DropDownList)e.Row.FindControl("ddApplicationTypeIdEdit");
                if (ddApplicationTypeIdEdit != null)
                {
                    if (xMCashBackApplication.ApplicationTypeId != null)
                    {
                        ddApplicationTypeIdEdit.SelectedValue = xMCashBackApplication.ApplicationTypeId.Value.ToString();
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //申请类型
                Label lblApplicationTypeId = e.Row.FindControl("lblApplicationTypeId") as Label;
                if (lblApplicationTypeId != null)
                {
                    if (xMCashBackApplication.ApplicationTypeId != null)
                        if (xMCashBackApplication.ApplicationTypeId.Value == Convert.ToInt32(StatusEnum.ChildCashBack))
                        {

                            lblApplicationTypeId.Text = "返现";
                        }
                        else if (xMCashBackApplication.ApplicationTypeId.Value == Convert.ToInt32(StatusEnum.ChildPayment))
                        {
                            lblApplicationTypeId.Text = "赔付";
                        }
                }

                LinkButton lbtnOrderNo = e.Row.FindControl("lbtnOrderNo") as LinkButton;
                if (lbtnOrderNo != null)
                {

                    //lbtnOrderNo.Text = mXMQuestion.OrderNO;
                    lbtnOrderNo.OnClientClick = "return ShowWindowDetail('订单详情','" + CommonHelper.GetStoreLocation()
                                                + "ManageProject/XMOrderUpdate.aspx?XMCashBackApplicationId=" + lbtnOrderNo.CommandArgument.ToString()
                                                + "&XMOrderType=XMCashBackApplicationValue"
                                                + "', 1000, 750, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";
                }


                #region 返现状态
                Label lblCashBackStatus = e.Row.FindControl("lblCashBackStatus") as Label;
                if (xMCashBackApplication.CashBackStatus != null)
                {
                    if (Convert.ToInt32(StatusEnum.NotCashBack) == xMCashBackApplication.CashBackStatus.Value)
                    {

                        //if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                        //{
                        lblCashBackStatus.Text = "未返现";
                        e.Row.Cells[10].BackColor = System.Drawing.Color.Yellow;
                        //}
                    }
                    else if (Convert.ToInt32(StatusEnum.AlreadyCashBack) == xMCashBackApplication.CashBackStatus.Value)
                    {

                        lblCashBackStatus.Text = "已返现";
                        e.Row.Cells[10].BackColor = System.Drawing.Color.Green;

                    }
                    //else if (Convert.ToInt32(StatusEnum.AbnormalNotCashBack) == xMCashBackApplication.CashBackStatus.Value)
                    //{

                    //    lblCashBackStatus.Text = "异常未返现";
                    //    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;

                    //}
                }
                #endregion

                #region 项目审核
                Label lblManagerStatus = e.Row.FindControl("lblManagerStatus") as Label;
                if (xMCashBackApplication.ManagerStatus != null)
                {
                    if (Convert.ToInt32(StatusEnum.NotCheck) == xMCashBackApplication.ManagerStatus.Value)
                    {

                        //if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                        //{
                        lblManagerStatus.Text = "未审核";
                        e.Row.Cells[11].BackColor = System.Drawing.Color.Yellow;
                        //}
                    }
                    else if (Convert.ToInt32(StatusEnum.AlreadyCheck) == xMCashBackApplication.ManagerStatus.Value)
                    {

                        lblManagerStatus.Text = "已审核";
                        e.Row.Cells[11].BackColor = System.Drawing.Color.Green;

                    }
                    //else if (Convert.ToInt32(StatusEnum.DidNotPass) == xMCashBackApplication.ManagerStatus.Value)
                    //{

                    //    lblManagerStatus.Text = "未通过";
                    //    e.Row.Cells[9].BackColor = System.Drawing.Color.Red;

                    //}
                }
                #endregion

                #region 财务审核
                Label lblFinanceIsAudit = e.Row.FindControl("lblFinanceIsAudit") as Label;
                if(xMCashBackApplication.FinanceIsAudit==null|| !(bool)xMCashBackApplication.FinanceIsAudit)
                {
                    lblFinanceIsAudit.Text = "未审核";
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    lblFinanceIsAudit.Text = "已审核";
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Green;
                }
                #endregion

                #region 项目未审核说明
                //Label lblManagerExplanation = e.Row.FindControl("lblManagerExplanation") as Label;
                //if (xMCashBackApplication.ManagerExplanation != null && xMCashBackApplication.ManagerExplanation != "")
                //{
                //    if (xMCashBackApplication.ManagerExplanation.Length > 8)
                //    {
                //        //var SdeliveryAddress = CutStr(deliveryAddress, 20);
                //        string strExplanation = xMCashBackApplication.ManagerExplanation.ToString().Substring(0, 8);
                //        lblManagerExplanation.Text = strExplanation + "...";
                //        lblManagerExplanation.ToolTip = xMCashBackApplication.ManagerExplanation.ToString();
                //    }
                //    else
                //    {
                //        lblManagerExplanation.Text = xMCashBackApplication.ManagerExplanation.ToString();
                //        lblManagerExplanation.ToolTip = xMCashBackApplication.ManagerExplanation.ToString();
                //    }
                //}
                //else
                //{
                //    lblManagerExplanation.Text = "";

                //}
                #endregion

                #region 项目审核通过 不可修改
                //ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                if (imgBtnDelete != null)
                {
                    if ((xMCashBackApplication.ManagerStatus == (int)StatusEnum.AlreadyCheck && xMCashBackApplication.CashBackStatus == (int)StatusEnum.AlreadyCashBack) ||
                        (xMCashBackApplication.ManagerStatus == (int)StatusEnum.AlreadyCheck && xMCashBackApplication.CashBackStatus == (int)StatusEnum.NotCashBack))
                    {
                        // imgBtnEdit.Visible = false;
                        imgBtnDelete.Visible = false;
                    }
                    else
                    {

                        // imgBtnEdit.Visible = true;
                        imgBtnDelete.Visible = true;
                    }
                }

                #endregion

                #region 状态：已返现  不显示复选框
                CheckBox chkSelected = e.Row.FindControl("chkSelected") as CheckBox;
                if (chkSelected != null)
                {
                    if (xMCashBackApplication.CashBackStatus == (int)StatusEnum.AlreadyCashBack)
                    {
                        chkSelected.Visible = false;
                    }
                    else
                    {
                        chkSelected.Visible = true;
                    }
                }
                #endregion

                #region 总监审核
                //Label lblDirectorStatus = e.Row.FindControl("lblDirectorStatus") as Label;
                //if (xMCashBackApplication.DirectorStatus != null)
                //{
                //    if (Convert.ToInt32(StatusEnum.NotCheck) == xMCashBackApplication.DirectorStatus.Value)
                //    {

                //        //if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                //        //{
                //            lblDirectorStatus.Text = "未审核";
                //            e.Row.Cells[10].BackColor = System.Drawing.Color.Yellow;
                //        //}
                //    }
                //    else if (Convert.ToInt32(StatusEnum.AlreadyCheck) == xMCashBackApplication.DirectorStatus.Value)
                //    {

                //        lblDirectorStatus.Text = "已审核";
                //        e.Row.Cells[10].BackColor = System.Drawing.Color.Green;

                //    }
                //    else if (Convert.ToInt32(StatusEnum.DidNotPass) == xMCashBackApplication.DirectorStatus.Value)
                //    {

                //        lblDirectorStatus.Text = "未通过";
                //        e.Row.Cells[10].BackColor = System.Drawing.Color.Red;

                //    }
                //}
                #endregion

                #region 总监未审核说明
                //Label lblDirectorExplanation = e.Row.FindControl("lblDirectorExplanation") as Label;
                //if (xMCashBackApplication.DirectorExplanation != null && xMCashBackApplication.DirectorExplanation != "")
                //{
                //    if (xMCashBackApplication.DirectorExplanation.Length > 8)
                //    {
                //        //var SdeliveryAddress = CutStr(deliveryAddress, 20);
                //        string strExplanation = xMCashBackApplication.DirectorExplanation.ToString().Substring(0, 8);
                //        lblDirectorExplanation.Text = strExplanation + "...";
                //        lblDirectorExplanation.ToolTip = xMCashBackApplication.DirectorExplanation.ToString();
                //    }
                //    else
                //    {
                //        lblDirectorExplanation.Text = xMCashBackApplication.DirectorExplanation.ToString();
                //        lblDirectorExplanation.ToolTip = xMCashBackApplication.DirectorExplanation.ToString();
                //    }
                //}
                //else
                //{
                //    lblDirectorExplanation.Text = "";

                //}
                #endregion


            }
        }

        ///// <summary>
        ///// 财务审核
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnFinanceIsAudit_Click(object sender, EventArgs e)
        //{
        //    List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);
        //    if (IDs.Count <= 0)
        //    {
        //        base.ShowMessage("你没有选择任何记录");
        //        return;
        //    }
        //    else
        //    {
        //        var XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByIdList(IDs);
        //        var FinanceIsAuditTrue = XMCashBackApplicationList.Where(a => a.FinanceIsAudit.Value == true).ToList();

        //        if (FinanceIsAuditTrue.Count > 0)
        //        {
        //            base.ShowMessage("请选择财务未审核的数据.");
        //            return;
        //        }
        //        foreach (GridViewRow row in gvXMCashBackApplicationList.Rows)
        //        {
        //            CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //            if (chkSelected.Checked)
        //            {
        //                int Id = 0;
        //                int.TryParse(this.gvXMCashBackApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                XMCashBackApplication cashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);

        //                if (cashBackApplication != null)
        //                {
        //                    cashBackApplication.FinancePeople = HozestERPContext.Current.User.CustomerID;
        //                    cashBackApplication.FinanceIsAudit = true;
        //                    cashBackApplication.FinanceTime = DateTime.Now;
        //                    cashBackApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                    cashBackApplication.UpdateTime = DateTime.Now;
        //                    base.XMCashBackApplicationService.UpdateXMCashBackApplication(cashBackApplication);
        //                }
        //            }
        //        }
        //    } 
        //    this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
        //    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //    ScriptManager.RegisterStartupScript(this.gvXMCashBackApplicationList, this.Page.GetType(), "XMCashBackApplication", "autoCompleteBind()", true);

        //}

        /// <summary>
        /// 项目审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManagerStatus_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                var XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByIdList(IDs);
                var NotCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCheck)).ToList();//项目已审核
                //var DidNotPassList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//项目未通过

                if (NotCheckList.Count > 0)
                {
                    base.ShowMessage("请选择项目未审核的数据.");
                    return;
                }
                else
                {
                    foreach (GridViewRow row in gvXMCashBackApplicationList.Rows)
                    {
                        CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                        if (chkSelected.Checked)
                        {
                            int Id = 0;
                            int.TryParse(this.gvXMCashBackApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                            XMCashBackApplication cashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);

                            if (cashBackApplication != null)
                            {
                                if (cashBackApplication.PaymentPerson == null && cashBackApplication.ApplicationTypeId == Convert.ToInt32(StatusEnum.ChildPayment))//赔付
                                {
                                    base.ShowMessage("请先选择赔付方后，再审核！");
                                    return;
                                }
                            }
                        }
                    }
                }

                foreach (GridViewRow row in gvXMCashBackApplicationList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.gvXMCashBackApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        XMCashBackApplication cashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);

                        if (cashBackApplication != null)
                        {
                            cashBackApplication.ManagerPeople = HozestERPContext.Current.User.CustomerID;
                            cashBackApplication.ManagerStatus = Convert.ToInt32(StatusEnum.AlreadyCheck);
                            cashBackApplication.ManagerTime = DateTime.Now;
                            cashBackApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            cashBackApplication.UpdateTime = DateTime.Now;
                            base.XMCashBackApplicationService.UpdateXMCashBackApplication(cashBackApplication);
                        }
                    }
                }
            }

            base.ShowMessage("操作成功");
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

        }

        /// <summary>
        /// 财务审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinanceStatus_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                var XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByIdList(IDs);
                var NotCheckList = XMCashBackApplicationList.Where(a =>a.CashBackStatus.Value== Convert.ToInt32(StatusEnum.AlreadyCashBack)).ToList();

                if (NotCheckList.Count > 0)
                {
                    base.ShowMessage("数据状态异常,操作失败,请检查！");
                    return;
                }

                foreach (GridViewRow row in gvXMCashBackApplicationList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.gvXMCashBackApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        XMCashBackApplication cashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);
                        if (cashBackApplication != null)
                        {
                            cashBackApplication.FinanceIsAudit = true;
                            cashBackApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            cashBackApplication.UpdateTime = DateTime.Now;
                            base.XMCashBackApplicationService.UpdateXMCashBackApplication(cashBackApplication);
                        }
                    }
                }
            }

            base.ShowMessage("操作成功");
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        /// <summary>
        /// 项目反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManagerStatusNo_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                var XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByIdList(IDs);
                var NotCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.NotCheck)).ToList();//项目未审核
                var NotCashBackList = XMCashBackApplicationList.Where(a => a.CashBackStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCashBack)).ToList();//未返现

                if (NotCheckList.Count > 0 || NotCashBackList.Count > 0)
                {
                    base.ShowMessage("请选择项目已审核、未返现的数据.");
                    return;
                }

                foreach (GridViewRow row in gvXMCashBackApplicationList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.gvXMCashBackApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        XMCashBackApplication cashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);

                        if (cashBackApplication != null)
                        {
                            cashBackApplication.ManagerPeople = HozestERPContext.Current.User.CustomerID;
                            cashBackApplication.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                            cashBackApplication.ManagerTime = DateTime.Now;
                            cashBackApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            cashBackApplication.UpdateTime = DateTime.Now;
                            base.XMCashBackApplicationService.UpdateXMCashBackApplication(cashBackApplication);
                        }
                    }
                }
            }
            base.ShowMessage("操作成功");
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

        }

        protected void btnFinanceStatusNo_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                var XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByIdList(IDs);
                var NotCheckList = XMCashBackApplicationList.Where(a => a.CashBackStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCashBack)).ToList();
                if(NotCheckList.Count>0)
                {
                    base.ShowMessage("数据状态异常,操作失败,请检查！");
                    return;
                }

                foreach (GridViewRow row in gvXMCashBackApplicationList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    {
                        int Id = 0;
                        int.TryParse(this.gvXMCashBackApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        XMCashBackApplication cashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);
                        if (cashBackApplication != null)
                        {
                            cashBackApplication.FinanceIsAudit = false;
                            cashBackApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            cashBackApplication.UpdateTime = DateTime.Now;
                            base.XMCashBackApplicationService.UpdateXMCashBackApplication(cashBackApplication);
                        }
                    }
                }
            }

            base.ShowMessage("操作成功");
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        /// <summary>
        /// 添加返现申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManagerAdd_Click(object sender, EventArgs e)
        {
            AddCash.OnClientClick = "return ShowWindowDetail('添加返现申请','" + CommonHelper.GetStoreLocation()
            + "ManageProject/XMCashBackApplicationAdd.aspx?type=" + 1
            + "', 800, 590, this,  function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";

        }

        protected void btnExportInfoList_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                string filePath = string.Format("{0}Upload\\CashBackExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

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

                //订单号
                string txtOrderCode = this.txtOrderCode.Text.Trim();
                //旺旺号
                string txtWantNo = this.txtWantNo.Text.Trim();
                //收款账号
                string txtBuyerAlipayNo = this.txtBuyerAlipayNo.Text.Trim();

                //int ddFinanceIsAudit = Convert.ToInt32(this.ddFinanceIsAudit.SelectedValue);//财务审核
                //int ddDirectorStatus= Convert.ToInt32(this.ddDirectorStatus.SelectedValue);//总监审核
                int ddCashBackStatus = Convert.ToInt32(this.ddCashBackStatus.SelectedValue);//返现状态
                int ApplicationTypeId = Convert.ToInt32((this.ddApplicationTypeId.SelectedValue));//申请类型
                                                                                                  //int  ddManagerStatus= Convert.ToInt32(this.ddManagerStatus.SelectedValue);//项目审核
                int ddXMProject = Convert.ToInt32(this.ddXMProject.SelectedValue);//项目
                int ddlNick = Convert.ToInt32(this.ddlNick.SelectedValue);//店铺
                string nickids = "";
                //if (ddlNick == 99) //某个项目店铺权限，选择有权限的店铺
                //{
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", -1, ddXMProject, HozestERPContext.Current.User.CustomerID, 0);
                for (int i = 0; i < nickList.Count; i++)
                {
                    nickids = nickids + nickList[i].nick_id + ",";
                }
                if (nickids.Length > 0)
                {
                    nickids = nickids.Substring(0, nickids.Length - 1);
                }
                //}
                //else
                //{
                //    nickids = ddlNick.ToString();
                //}

                int ddlPlatform = Convert.ToInt32(this.ddlPlatform.SelectedValue);//平台

                // 项目审核状态：-1：所以、3：未审核、4：已审核、5：未通过
                int ManagerStatus = -1;
                if (TabPanelCashBackApplicationType == "All")
                {
                    ManagerStatus = -1;
                }
                else if (TabPanelCashBackApplicationType == "ManagerStatusNotCheck")
                {
                    //未审核
                    ManagerStatus = 3;

                }
                else if (TabPanelCashBackApplicationType == "ManagerStatusAlreadyCheck")
                {
                    //已审核
                    ManagerStatus = 4;
                }
                //else if (TabPanelCashBackApplicationType == "ManagerStatusDidNotPass")
                //{
                //    //未通过
                //    ManagerStatus = 5;
                //}
                var max = DateTime.Now;
                if (this.txtEndDate.SelectedDate.HasValue)
                {
                    max = this.txtEndDate.SelectedDate.Value.AddDays(1).AddSeconds(-1);
                }

                //根据 订单号、旺旺号、收款账号 查询。
                //var xMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationList(this.txtBeginDate.SelectedDate, max, ddXMProject, nickids, ddlPlatform, txtOrderCode, txtWantNo, txtBuyerAlipayNo, ManagerStatus, ddCashBackStatus, ApplicationTypeId);
                List<XMCashBackApplication> xMCashBackApplicationList = null;

                if (TabPanelCashBackApplicationType == "ManagerStatusNoOrder")
                {
                    xMCashBackApplicationList = XMCashBackApplicationService.GetXMCashBackApplicationListNoOrder(this.txtBeginDate.SelectedDate, max, nickids, ddXMProject, txtOrderCode, txtWantNo, txtBuyerAlipayNo, ManagerStatus, ddCashBackStatus, ApplicationTypeId);
                }
                else
                {
                    //根据 订单号、旺旺号、收款账号 查询。
                    xMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationList(this.txtBeginDate.SelectedDate, max, ddXMProject, nickids, ddlPlatform, txtOrderCode, txtWantNo, txtBuyerAlipayNo, ManagerStatus, ddCashBackStatus, ApplicationTypeId);
                }

                ExportManager.ExportCashBackExcel(filePath, xMCashBackApplicationList);
                CommonHelper.WriteResponseXls(filePath, fileName);
            }
            catch(Exception exc)
            {
                ProcessException(exc);
            }
        }

        /// <summary>
        /// 项目未通过  (项目未通过说明处理)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void hidBtnManagerStatusNO_Click(object sender, EventArgs e)
        //{
        //    if (Session["SelectExplanation"] == null )
        //        return;
        //    try
        //    {
        //        List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);

        //        if (IDs.Count > 0)
        //        {

        //            foreach (GridViewRow row in gvXMCashBackApplicationList.Rows)
        //            {
        //                CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //                if (chkSelected.Checked)
        //                {
        //                    int Id = 0;
        //                    int.TryParse(this.gvXMCashBackApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                    XMCashBackApplication cashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);

        //                    if (cashBackApplication != null)
        //                    {
        //                        //cashBackApplication.FinanceIsAudit = false;
        //                        //cashBackApplication.FinancePeople = HozestERPContext.Current.User.CustomerID;
        //                        //cashBackApplication.FinanceTime = DateTime.Now;
        //                        cashBackApplication.ManagerPeople = HozestERPContext.Current.User.CustomerID;
        //                        cashBackApplication.ManagerStatus = Convert.ToInt32(StatusEnum.DidNotPass);
        //                        cashBackApplication.ManagerExplanation = Session["SelectExplanation"].ToString();
        //                        cashBackApplication.ManagerTime = DateTime.Now;
        //                        cashBackApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                        cashBackApplication.UpdateTime = DateTime.Now;
        //                        base.XMCashBackApplicationService.UpdateXMCashBackApplication(cashBackApplication);
        //                    }
        //                }
        //            } 
        //        }
        //        this.Master.JsWrite("alert('确认成功。');RefreshSearch();", "");


        //        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

        //        ScriptManager.RegisterStartupScript(this.gvXMCashBackApplicationList, this.Page.GetType(), "XMCashBackApplication", "autoCompleteBind()", true);

        //    }
        //    catch (Exception err)
        //    {
        //        base.ProcessException(err);
        //    }
        //}

        /// <summary>
        /// 店长未通过     弹出未通过说明窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void hidBtnManagerStatusNOM_Click(object sender, EventArgs e)
        //{

        //    string paramScript = "ShowWindowDetail1('b-win','未通过说明','" + CommonHelper.GetStoreLocation() +
        //            "ManageProject/XMCashBackApplicationDistribution.aspx',500,200, this, function(){document.getElementById('"
        //            + this.hidBtnManagerStatusNO.ClientID + "').click();});";
        //    this.Master.JsWrite(paramScript, ""); 
        //}


        /// <summary>
        /// 项目未通过 判断 （判断已选择数据是否通过财务审核、店长已审核、店长未通过）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnManagerStatusNO_Click(object sender, EventArgs e)
        //{

        //    try
        //    { 
        //        List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);
        //        if (IDs.Count <= 0)
        //        {
        //            base.ShowMessage("你没有选择任何记录");
        //            return;
        //        }
        //        else
        //        {
        //            var XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByIdList(IDs);
        //            var NotCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCheck)).ToList();//项目已审核
        //            var DidNotPassList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//项目未通过

        //            if (NotCheckList.Count > 0 || DidNotPassList.Count > 0)
        //            {
        //                base.ShowMessage("请选择项目未审核的数据.");
        //                return;
        //            }
        //            //财务已经审核通过、店长未审核、店长未通过 （弹出未通过说明窗口）
        //            if ( NotCheckList.Count == 0 && DidNotPassList.Count == 0)
        //            {

        //                Session["SelectExplanation"] = null; 
        //                string s = "document.getElementById('" + this.hidManagerStatusNOM.ClientID + "').click();";
        //                this.Master.JsWrite(s, "");

        //            }
        //        }

        //    }
        //    catch (Exception err)
        //    {
        //        base.ProcessException(err);
        //    }


        //}

        ///// <summary>
        ///// 总监审核
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnDirectorStatus_Click(object sender, EventArgs e)
        //{
        //    List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);
        //    if (IDs.Count <= 0)
        //    {
        //        base.ShowMessage("你没有选择任何记录");
        //        return;
        //    }
        //    else
        //    {
        //        var XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByIdList(IDs);
        //        var MNotCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.NotCheck)).ToList();//店长未审核
        //        var MDidNotPassList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//店长未通过

        //        var DAlreadyCheckList = XMCashBackApplicationList.Where(a => a.DirectorStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCheck)).ToList();//总监已审核
        //        var DDidNotPassList = XMCashBackApplicationList.Where(a => a.DirectorStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//总监未通过

        //        if (MNotCheckList.Count > 0 || MDidNotPassList.Count > 0 || DAlreadyCheckList.Count > 0 || DDidNotPassList.Count > 0)
        //        {
        //            base.ShowMessage("请选择店长已审核的数据.");
        //            return;
        //        }


        //        foreach (GridViewRow row in gvXMCashBackApplicationList.Rows)
        //        {
        //            CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //            if (chkSelected.Checked)
        //            {
        //                int Id = 0;
        //                int.TryParse(this.gvXMCashBackApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                XMCashBackApplication cashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);

        //                if (cashBackApplication != null)
        //                {
        //                    cashBackApplication.DirectorPeople = HozestERPContext.Current.User.CustomerID;
        //                    cashBackApplication.DirectorStatus = Convert.ToInt32(StatusEnum.AlreadyCheck);
        //                    cashBackApplication.DirectorTime = DateTime.Now;
        //                    cashBackApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                    cashBackApplication.UpdateTime = DateTime.Now;
        //                    base.XMCashBackApplicationService.UpdateXMCashBackApplication(cashBackApplication);
        //                }
        //            }
        //        }
        //    }
        //    this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
        //    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //    ScriptManager.RegisterStartupScript(this.gvXMCashBackApplicationList, this.Page.GetType(), "XMCashBackApplication", "autoCompleteBind()", true);

        //}



        ///// <summary>
        ///// 总监未通过  (总监未通过说明处理)
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void hidBtnDirectorStatusNO_Click(object sender, EventArgs e)
        //{
        //    if (Session["SelectExplanation"] == null)
        //        return;
        //    try
        //    {
        //        List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);

        //        if (IDs.Count > 0)
        //        {

        //            foreach (GridViewRow row in gvXMCashBackApplicationList.Rows)
        //            {
        //                CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //                if (chkSelected.Checked)
        //                {
        //                    int Id = 0;
        //                    int.TryParse(this.gvXMCashBackApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                    XMCashBackApplication cashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);

        //                    if (cashBackApplication != null)
        //                    {
        //                        //cashBackApplication.FinanceIsAudit = false;
        //                        //cashBackApplication.FinancePeople = HozestERPContext.Current.User.CustomerID;
        //                        //cashBackApplication.FinanceTime = DateTime.Now;

        //                        //cashBackApplication.ManagerPeople = HozestERPContext.Current.User.CustomerID;
        //                        //cashBackApplication.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
        //                        //cashBackApplication.ManagerTime = DateTime.Now;

        //                        cashBackApplication.DirectorPeople = HozestERPContext.Current.User.CustomerID;
        //                        cashBackApplication.DirectorStatus = Convert.ToInt32(StatusEnum.DidNotPass);
        //                        cashBackApplication.DirectorTime = DateTime.Now;

        //                        cashBackApplication.DirectorExplanation = Session["SelectExplanation"].ToString();
        //                        cashBackApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                        cashBackApplication.UpdateTime = DateTime.Now;
        //                        base.XMCashBackApplicationService.UpdateXMCashBackApplication(cashBackApplication);
        //                    }
        //                }
        //            }
        //        }
        //        this.Master.JsWrite("alert('确认成功。');RefreshSearch();", ""); 
        //        this.BindGrid(this.Master.PageIndex, this.Master.PageSize); 
        //        ScriptManager.RegisterStartupScript(this.gvXMCashBackApplicationList, this.Page.GetType(), "XMCashBackApplication", "autoCompleteBind()", true);

        //    }
        //    catch (Exception err)
        //    {
        //        base.ProcessException(err);
        //    }
        //}



        ///// <summary>
        ///// 总监未通过    弹出未通过说明窗口
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void hidBtnDirectorStatusNOD_Click(object sender, EventArgs e)
        //{

        //    string paramScript = "ShowWindowDetail1('b-win','未通过说明','" + CommonHelper.GetStoreLocation() +
        //            "ManageProject/XMCashBackApplicationDistribution.aspx',500,200, this, function(){document.getElementById('"
        //            + this.hidBtnDirectorStatusNO.ClientID + "').click();});";
        //    this.Master.JsWrite(paramScript, "");
        //}

        ///// <summary>
        ///// 总监未通过 判断 （判断已选择数据是否通过财务审核、店长已审核、店长未通过）
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnDirectorStatusNO_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);
        //        if (IDs.Count <= 0)
        //        {
        //            base.ShowMessage("你没有选择任何记录");
        //            return;
        //        }
        //        else
        //        {
        //            var XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByIdList(IDs);

        //            var MNotCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.NotCheck)).ToList();//店长未审核
        //            var MDidNotPassList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//店长未通过

        //            var DAlreadyCheckList = XMCashBackApplicationList.Where(a => a.DirectorStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCheck)).ToList();//总监已审核
        //            var DDidNotPassList = XMCashBackApplicationList.Where(a => a.DirectorStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//总监未通过

        //            if (MNotCheckList.Count > 0 || MDidNotPassList.Count > 0 || DAlreadyCheckList.Count > 0 || DDidNotPassList.Count > 0)
        //            {
        //                base.ShowMessage("请选择店长已审核的数据.");
        //                return;
        //            }
        //            //财务已经审核通过、店长未审核、店长未通过 （弹出未通过说明窗口）
        //            if (MNotCheckList.Count == 0 && MDidNotPassList.Count == 0 && DAlreadyCheckList.Count == 0 && DDidNotPassList.Count == 0)
        //            {

        //                Session["SelectExplanation"] = null;
        //                string s = "document.getElementById('" + this.hidBtnDirectorStatusNOD.ClientID + "').click();";
        //                this.Master.JsWrite(s, "");

        //            }
        //        }

        //    }
        //    catch (Exception err)
        //    {
        //        base.ProcessException(err);
        //    }


        //}

        /// <summary>
        /// 返现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCashBackStatus_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                var XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByIdList(IDs);
                var NotCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.NotCheck)||a.FinanceIsAudit==false||a.FinanceIsAudit==null).ToList();//项目未审核

                if (NotCheckList.Count > 0)
                {
                    base.ShowMessage("请选择已审核的数据.");
                    return;
                }

                foreach (GridViewRow row in gvXMCashBackApplicationList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.gvXMCashBackApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        XMCashBackApplication cashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);

                        if (cashBackApplication != null)
                        {
                            cashBackApplication.CashBackStatus = Convert.ToInt32(StatusEnum.AlreadyCashBack);
                            cashBackApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            cashBackApplication.UpdateTime = DateTime.Now;
                            base.XMCashBackApplicationService.UpdateXMCashBackApplication(cashBackApplication);
                        }
                    }
                }
            }
            this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            ScriptManager.RegisterStartupScript(this.gvXMCashBackApplicationList, this.Page.GetType(), "XMCashBackApplication", "autoCompleteBind()", true);

        }

        /// <summary>
        /// 异常未返现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnCashBackStatusNO_Click(object sender, EventArgs e)
        //{
        //    List<int> IDs = this.Master.GetSelectedIds(this.gvXMCashBackApplicationList);
        //    if (IDs.Count <= 0)
        //    {
        //        base.ShowMessage("你没有选择任何记录");
        //        return;
        //    }
        //    else
        //    {
        //        var XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByIdList(IDs);
        //        var DDidNotPassList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//项目未通过

        //        if (DDidNotPassList.Count > 0)
        //        {
        //            base.ShowMessage("请选择项目已审核的数据.");
        //            return;
        //        }

        //        foreach (GridViewRow row in gvXMCashBackApplicationList.Rows)
        //        {
        //            CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //            if (chkSelected.Checked)
        //            {
        //                int Id = 0;
        //                int.TryParse(this.gvXMCashBackApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                XMCashBackApplication cashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(Id);

        //                if (cashBackApplication != null)
        //                {
        //                    cashBackApplication.CashBackStatus = Convert.ToInt32(StatusEnum.AbnormalNotCashBack); 
        //                    cashBackApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                    cashBackApplication.UpdateTime = DateTime.Now;
        //                    base.XMCashBackApplicationService.UpdateXMCashBackApplication(cashBackApplication);
        //                }
        //            }
        //        }
        //    }
        //    this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
        //    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //    ScriptManager.RegisterStartupScript(this.gvXMCashBackApplicationList, this.Page.GetType(), "XMCashBackApplication", "autoCompleteBind()", true);

        //}

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

        /// <summary>
        /// 返现申请 TabPane 类型
        /// </summary>
        public string TabPanelCashBackApplicationType
        {
            get
            {
                return CommonHelper.QueryString("TabPanelCashBackApplicationType");
            }
        }
    }
}