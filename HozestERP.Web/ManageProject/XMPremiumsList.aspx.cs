using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMPremiumsList : BaseAdministrationPage, ISearchPage
    {
        public List<XMPremiums> ExportXMPremiumsList;

        /// <summary>
        /// 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                //buttons.Add("imgBtnEdit", "XMPremiumsList.Edit");//编辑
                buttons.Add("imgBtnDelete", "XMPremiumsList.Delete");//删除
                //buttons.Add("imgBtnUpdate", "XMPremiumsList.Save");//保存
                //buttons.Add("imgBtnCancel", "XMPremiumsList.Cancel");//取消
                //buttons.Add("btnFinanceIsAudit", "XMPremiumsList.FinanceIsAudit");//财务审核
                //buttons.Add("btnDirectorStatus", "XMPremiumsList.DirectorStatus");//总监审核
                //buttons.Add("btnDirectorStatusNO", "XMPremiumsList.DirectorStatusNO");//总监未通过 
                //buttons.Add("btnPremiumsStatusNO", "XMPremiumsList.PremiumsStatusNO");//异常未发货
                buttons.Add("btnIsSingleRow", "XMPremiumsList.IsSingleRow");//排单
                //buttons.Add("imgPremiumsDetails", "XMPremiumsList.PremiumsDetails");//赠品信息
                buttons.Add("btnManagerStatus", "XMPremiumsList.ManagerStatus");//项目审核
                buttons.Add("btnManagerStatusNo", "XMPremiumsList.ManagerStatusNo");//项目反审核
                buttons.Add("btnIsEvaluation_Click", "XMPremiumsList.IsEvaluation");//评价信息
                buttons.Add("AddCash", "XMPremiumsListAdd.add");//新增赠品 
                buttons.Add("ImgBtnCR", "XMPremiumsList.update");//编辑赠品信息

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

                if (TabPanelPremiumsType == "ManagerStatusAlreadyCheck")
                {
                    this.ddManagerStatus.SelectedValue = "4";//已审核
                    this.ddManagerStatus.Enabled = false;
                }
                if (TabPanelPremiumsType != "ManagerNoOrder")
                {
                    this.txtFullName.Visible = false;
                    this.txtMobile.Visible = false;
                    this.lblFullName.Visible = false;
                    this.lblMobile.Visible = false;
                }

                this.btnPremiumsAdd.OnClientClick = "return ShowWindowDetail('添加赠品申请','" + CommonHelper.GetStoreLocation()
            + "ManageProject/XMPremiumsAdd.aspx?Id=0"
            + "', 800, 500, this,  function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";

                this.btnBigGiftPacks.OnClientClick = "return ShowWindowDetail('9.9大礼包导入','" + CommonHelper.GetStoreLocation()
            + "ManageProject/ImportBigGiftPacks.aspx"
            + "', 500, 300, this,  function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                this.btnNoOrderImport.OnClientClick = "return ShowWindowDetail('无订单赠品导入','" + CommonHelper.GetStoreLocation()
            + "ManageProject/ImportNoOrder.aspx"
            + "', 500, 300, this,  function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                this.btnPremiumsImport.OnClientClick = "return ShowWindowDetail('赠品导入','" + CommonHelper.GetStoreLocation()
           + "ManageProject/ImportPremiums.aspx"
           + "', 500, 300, this,  function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //批量排单
                this.btnIsSingleRow.OnClientClick = "return CkeckShowWindowDetail(SavePremiunsInfoIDs(),'选择出库仓库','" + CommonHelper.GetStoreLocation() +
            "ManageProject/XMPremiumsSaleDelivery.aspx?Type=0&&TabPanelPremiumsType=" + TabPanelPremiumsType + "',300,170, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnManagerStatus.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnIsSingleRow.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnManagerStatusNo.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnFinanceIsAudit.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnDirectorStatus.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnDirectorStatusNO.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnPremiumsStatusNO.UniqueID, this.Page);
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

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 522)
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362);

                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
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
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "99"));
            }
            #endregion
            //var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362);
            //&& c.Id != 3 && c.Id != 5
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
                ////.Where(c => c.nick_id != 6 && c.nick_id != 8)
                //this.ddlNick.DataSource = nickList;
                //this.ddlNick.DataTextField = "nick";
                //this.ddlNick.DataValueField = "nick_id";
                //this.ddlNick.DataBind();
                //this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
        }

        /// <summary>
        /// 构造Lambda语句（where in）
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="propertySelector"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private static Expression<Func<TElement, bool>> BuildWhereInExpression<TElement, TValue>(Expression<Func<TElement, TValue>> propertySelector, IEnumerable<TValue> values)
        {
            ParameterExpression p = propertySelector.Parameters.Single();
            if (!values.Any())
                return e => false;

            var equals = values.Select(value => (Expression)Expression.Equal(propertySelector.Body, Expression.Constant(value, typeof(TValue))));
            var body = equals.Aggregate<Expression>((accumulate, equal) => Expression.Or(accumulate, equal));

            return Expression.Lambda<Func<TElement, bool>>(body, p);
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

            //int ddPremiumsStatus = Convert.ToInt32(this.ddPremiumsStatus.SelectedValue);//赠品状态
            int ddPremiumsStatus = -1;
            //int ddFinanceIsAudit = Convert.ToInt32(this.ddFinanceIsAudit.SelectedValue);//财务审核  
            //int ddDirectorStatus = Convert.ToInt32(this.ddDirectorStatus.SelectedValue);//总监审核
            int ddIsSingleRow = Convert.ToInt32(this.ddIsSingleRow.SelectedValue);//是否排单
            int ddPremiumsTypeId = Convert.ToInt32(this.ddPremiumsTypeId.SelectedValue);//申请类型：赠品:11、赔付：10
            int ManagerStatus = Convert.ToInt32(this.ddManagerStatus.SelectedValue);//项目审核
            int ddXMProject = Convert.ToInt32(this.ddXMProject.SelectedValue);//项目
            int ddlNick = Convert.ToInt32(this.ddlNick.SelectedValue);//店铺
            string nickids = "";
            string paramActivityExplanation = this.txtActivityExplanation.Text.Trim();
            string FullName = this.txtFullName.Text.Trim();//备用地址中的姓名
            string Mobile = this.txtMobile.Text.Trim();//备用地址中的手机

            //TabPanelPremiumsType = "ManagerStatusNotCheck"时，平台为亚马逊时，不检查订单状态。因为亚马逊同步不及时，客服无法发赠品
            bool IsYMX = false;

            if (ddlNick == 99) //某个项目店铺权限，选择有权限的店铺
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", -1, ddXMProject, HozestERPContext.Current.User.CustomerID, 0);
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
                nickids = ddlNick.ToString();
            }

            int ddlPlatform = Convert.ToInt32(this.ddlPlatform.SelectedValue);//平台
            var max = DateTime.Now;
            if (this.txtEndDate.SelectedDate.HasValue)
            {
                max = this.txtEndDate.SelectedDate.Value.AddDays(1).AddSeconds(-1);
            }

            List<XMPremiums> xMXMPremiumsList = new List<XMPremiums>();

            // 项目审核状态：-1：所有、3：未审核、4：已审核、5：未通过
            if (TabPanelPremiumsType == "All")
            {
                //根据 订单号、旺旺号、赠品、项目审核状态、是否排单、申请类型 查询。
                xMXMPremiumsList = base.XMPremiumsService.GetXMPremiumsList(this.txtBeginDate.SelectedDate, max, ddXMProject, nickids, ddlPlatform, txtOrderCode, txtWantNo, ddPremiumsStatus, ManagerStatus, ddIsSingleRow, ddPremiumsTypeId);
            }
            else if (TabPanelPremiumsType == "ManagerNoOrder")//无订单赠品
            {
                xMXMPremiumsList = base.XMPremiumsService.GetXMPremiumsListNoOrder(this.txtBeginDate.SelectedDate, max, ddPremiumsStatus, ManagerStatus, ddIsSingleRow, ddPremiumsTypeId, FullName, Mobile, txtOrderCode);
            }
            else if (TabPanelPremiumsType == "Pay")
            {
                //订单状态：完成
                List<string> OrderStatus = new List<string>();
                OrderStatus.Add("TRADE_CLOSED");
                OrderStatus.Add("TRADE_CANCELED");
                OrderStatus.Add("LOCKED");
                OrderStatus.Add("TRADE_CANCELED");
                OrderStatus.Add("ORDER_CANCEL");
                OrderStatus.Add("STATUS_97");
                OrderStatus.Add("ORDER_FINISH");
                OrderStatus.Add("40");

                //确认收货未好评
                //ManagerStatus = 3;
                //根据 订单号、旺旺号、赠品、项目审核状态、是否排单、申请类型 查询。
                xMXMPremiumsList = base.XMPremiumsService.GetXMPremiumsListByPay(this.txtBeginDate.SelectedDate, max, ddXMProject, nickids, ddlPlatform, txtOrderCode, txtWantNo, ddPremiumsStatus, ManagerStatus, ddIsSingleRow, ddPremiumsTypeId, OrderStatus, false, paramActivityExplanation);
            }
            else if (TabPanelPremiumsType == "ManagerStatusNoEvaluation")
            {
                //订单状态：完成
                List<string> OrderStatus = new List<string>();
                OrderStatus.Add("TRADE_FINISHED");
                OrderStatus.Add("FINISHED_L");
                OrderStatus.Add("STATUS_25");
                OrderStatus.Add("ORDER_FINISH");
                OrderStatus.Add("30");

                //确认收货未好评
                //ManagerStatus = 3;
                //根据 订单号、旺旺号、赠品、项目审核状态、是否排单、申请类型 查询。
                xMXMPremiumsList = base.XMPremiumsService.GetXMPremiumsListByOrderStatus(this.txtBeginDate.SelectedDate, max, ddXMProject, nickids, ddlPlatform, txtOrderCode, txtWantNo, ddPremiumsStatus, ManagerStatus, ddIsSingleRow, ddPremiumsTypeId, OrderStatus, false, paramActivityExplanation, IsYMX);
            }
            else if (TabPanelPremiumsType == "ManagerStatusNotCheck")
            {
                //订单状态：完成
                List<string> OrderStatus = new List<string>();
                OrderStatus.Add("TRADE_FINISHED");
                OrderStatus.Add("FINISHED_L");
                OrderStatus.Add("STATUS_25");
                OrderStatus.Add("ORDER_FINISH");
                OrderStatus.Add("30");

                if (ddlPlatform == 376)//亚马逊
                {
                    IsYMX = true;
                }

                //确认收货好评未审核
                //ManagerStatus = 3;
                //根据 订单号、旺旺号、赠品、项目审核状态、是否排单、申请类型 查询。
                xMXMPremiumsList = base.XMPremiumsService.GetXMPremiumsListByOrderStatus(this.txtBeginDate.SelectedDate, max, ddXMProject, nickids, ddlPlatform, txtOrderCode, txtWantNo, ddPremiumsStatus, ManagerStatus, ddIsSingleRow, ddPremiumsTypeId, OrderStatus, true, paramActivityExplanation, IsYMX);
            }
            else if (TabPanelPremiumsType == "ManagerStatusAlreadyCheck")
            {
                ManagerStatus = 4;
                //根据 订单号、旺旺号、赠品、项目审核状态、是否排单、申请类型 查询。
                xMXMPremiumsList = base.XMPremiumsService.GetXMPremiumsList(this.txtBeginDate.SelectedDate, max, ddXMProject, nickids, ddlPlatform, txtOrderCode, txtWantNo, ddPremiumsStatus, ManagerStatus, ddIsSingleRow, ddPremiumsTypeId);
            }

            //导出
            ExportXMPremiumsList = xMXMPremiumsList;

            //分页
            var xMXMPremiumsPageList = new PagedList<XMPremiums>(xMXMPremiumsList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.gvXMPremiumsList, xMXMPremiumsPageList, paramPageSize + 1);
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
            //ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            //ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvXMPremiumsList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            if (int.TryParse(this.gvXMPremiumsList.DataKeys[e.RowIndex].Value.ToString(), out Id))
            {
                // 产品信息
                var xMPremiums = base.XMPremiumsService.GetXMPremiumsById(Id);
                if (xMPremiums != null)
                {
                    xMPremiums.IsEnable = true;
                    xMPremiums.UpdatorID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    xMPremiums.UpdateTime = DateTime.Now;
                    base.XMPremiumsService.UpdateXMPremiums(xMPremiums);
                }

                //grid 绑定
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("删除成功.");

                //ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);
            }
        }

        #region 赠品主表信息修改
        //protected void gvXMPremiumsList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    this.RowEditIndex = -1;
        //    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

        //    ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);

        //}

        //protected void gvXMPremiumsList_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    this.RowEditIndex = e.NewEditIndex;
        //    this.RowEditTypeIndex = 1;
        //    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

        //    ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);
        //    // int Id = 0;
        //    // int.TryParse(this.gvXMPremiumsList.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
        //    // var row = this.gvXMPremiumsList.Rows[e.NewEditIndex];
        //    // var xMProject = base.XMPremiumsService.GetXMPremiumsById(Id);


        //}

        /// <summary>
        /// 记录行 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void gvXMPremiumsList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    int Id = 0;

        //    if (int.TryParse(this.gvXMPremiumsList.DataKeys[e.RowIndex].Value.ToString(), out Id))
        //    {
        //        var row = this.gvXMPremiumsList.Rows[e.RowIndex];

        //        #region 字符验证
        //        //订单号

        //        var txtOrderCode = this.gvXMPremiumsList.Rows[e.RowIndex].FindControl("txtOrderCode") as HtmlInputText;
        //        var lblOrderCode = row.FindControl("lblOrderCode") as Label;


        //        //旺旺号
        //        var txtWantNo = row.FindControl("txtWantNo") as TextBox;
        //        //var lblMsgWantNoVaule = row.FindControl("lblMsgWantNoVaule") as Label;
        //        //lblMsgWantNoVaule.Text = "";
        //        //if (txtWantNo.Text.Trim() == "")
        //        //{
        //        //    lblMsgWantNoVaule.Text = "不允许为空";
        //        //}

        //        //活动说明
        //        var txtActivityExplanation = row.FindControl("txtActivityExplanation") as TextBox;
        //        var lblMsgActivityExplanationVaule = row.FindControl("lblMsgActivityExplanationVaule") as Label;
        //        lblMsgActivityExplanationVaule.Text = "";
        //        if (txtActivityExplanation.Text.Trim() == "")
        //        {
        //            lblMsgActivityExplanationVaule.Text = "不允许为空";
        //        }



        //        DropDownList ddPremiumsTypeIdEdit = (DropDownList)row.FindControl("ddPremiumsTypeIdEdit");


        //        if (lblMsgActivityExplanationVaule.Text != "" )
        //        {
        //            return;
        //        }

        //        #endregion

        //        var xMPremiums = base.XMPremiumsService.GetXMPremiumsById(Id);
        //        var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(txtOrderCode.Value);

        //        #region 修改
        //        if (xMPremiums != null)
        //        {
        //            //if (xMOrderInfo == null)
        //            //{
        //            //    if (xMOrderInfo.Count == 0)
        //            //    {
        //            //        txtOrderCode.Value = "";
        //            //        txtWantNo.Text = ""; 
        //            //        this.Master.ShowMessage("订单号有误.");
        //            //        ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);
        //            //        return;
        //            //    }
        //            //}

        //            //异常未发  
        //            if (xMPremiums.PremiumsStatus == (int)StatusEnum.PremiumsAbnormalNoHair)
        //            {

        //               // xMPremiums.OrderCode = txtOrderCode.Value;
        //               // xMPremiums.WantId = txtWantNo.Text.Trim();
        //                xMPremiums.PremiumsTypeId = Convert.ToInt32(ddPremiumsTypeIdEdit.SelectedValue);
        //                xMPremiums.ActivityExplanation = txtActivityExplanation.Text.Trim();
        //                xMPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                xMPremiums.UpdateTime = DateTime.Now;
        //                base.XMPremiumsService.UpdateXMPremiums(xMPremiums);
        //            }
        //            else
        //            {
        //                // 除异常未返现状态  修改所有状态初始化

        //               // xMPremiums.OrderCode = txtOrderCode.Value;
        //                // xMPremiums.WantId = txtWantNo.Text.Trim();
        //                xMPremiums.PremiumsTypeId = Convert.ToInt32(ddPremiumsTypeIdEdit.SelectedValue);
        //                xMPremiums.ActivityExplanation = txtActivityExplanation.Text.Trim();
        //                //xMPremiums.FinanceIsAudit = false;
        //                xMPremiums.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
        //               // xMPremiums.DirectorStatus = Convert.ToInt32(StatusEnum.NotCheck);
        //                xMPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                xMPremiums.UpdateTime = DateTime.Now;
        //                base.XMPremiumsService.UpdateXMPremiums(xMPremiums);
        //            }
        //        }
        //        #endregion

        //        #region 新增
        //        else
        //        {

        //            if (xMOrderInfo.Count == 0)
        //            {
        //                txtOrderCode.Value = "";
        //                txtWantNo.Text = "";
        //                this.Master.ShowMessage("订单号有误.");
        //                ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);
        //                return;
        //            }

        //            xMPremiums = new XMPremiums();
        //            xMPremiums.OrderCode = txtOrderCode.Value;
        //            xMPremiums.WantId = txtWantNo.Text.Trim();
        //            xMPremiums.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsNoHair);
        //            xMPremiums.ActivityExplanation = txtActivityExplanation.Text.Trim(); 
        //            xMPremiums.PremiumsTypeId = Convert.ToInt32(ddPremiumsTypeIdEdit.SelectedValue);
        //            //xMPremiums.FinanceIsAudit = false;
        //            xMPremiums.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
        //            //xMPremiums.DirectorStatus = Convert.ToInt32(StatusEnum.NotCheck);
        //            xMPremiums.IsSingleRow = false;
        //            xMPremiums.IsEnable = false;
        //            xMPremiums.CreatorID = HozestERPContext.Current.User.CustomerID;
        //            xMPremiums.CreateTime = DateTime.Now;
        //            xMPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //            xMPremiums.UpdateTime = DateTime.Now;
        //            base.XMPremiumsService.InsertXMPremiums(xMPremiums);
        //        }
        //        #endregion
        //        this.RowEditIndex = -1;
        //        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //        this.Master.JsWrite("alert('保存成功！')", "");
        //        ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);
        //    }
        //}
        #endregion

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvXMPremiumsList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var XMConsultation = (XMPremiums)e.Row.DataItem;
            ImageButton ImgBtnCR = e.Row.FindControl("ImgBtnCR") as ImageButton;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (XMConsultation != null)
                {
                    #region 赠品修改
                    if (XMConsultation.Id != 0)
                    {
                        if (ImgBtnCR != null)
                        {
                            ImgBtnCR.OnClientClick = "return ShowWindowDetail('赠品信息','" + CommonHelper.GetStoreLocation()
                                + "ManageProject/XMPremiumsAdd.aspx?Id=" + XMConsultation.Id + "&TabPanelPremiumsType="
                                + TabPanelPremiumsType + "', 800, 500, this,  function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";
                        }
                    }
                    #endregion

                    #region 添加备用地址

                    ImageButton imgBtnSpareAddress = (ImageButton)e.Row.FindControl("imgBtnSpareAddress");
                    if (imgBtnSpareAddress != null)
                    {
                        imgBtnSpareAddress.OnClientClick = "return ShowWindowDetail('备用地址','" + CommonHelper.GetStoreLocation()
               + "ManageProject/XMSpareAddressEdit.aspx?Id=" + XMConsultation.Id.ToString() + "&TypeID=711', 400, 420, this, function(){});";
                    }

                    #endregion
                }
            }

            var xMPremiums = (XMPremiums)e.Row.DataItem;

            if (e.Row.RowState == DataControlRowState.Edit ||
                e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                #region 点击行的编辑按钮  订单号、旺旺号不可编辑
                if (RowEditTypeIndex == 1)
                {
                    HtmlInputText txtOrderCode = e.Row.FindControl("txtOrderCode") as HtmlInputText;
                    TextBox txtWantNo = e.Row.FindControl("txtWantNo") as TextBox;

                    Label lblOrderCode = e.Row.FindControl("lblOrderCode") as Label;
                    Label lblWantId = e.Row.FindControl("lblWantId") as Label;

                    //订单号、旺旺号编辑框不显示
                    if (txtOrderCode != null)
                    {
                        txtOrderCode.Visible = false;
                    }
                    if (txtWantNo != null)
                    {
                        txtWantNo.Visible = false;
                    }
                    //订单号、旺旺号lbl显示
                    if (lblOrderCode != null)
                    {
                        lblOrderCode.Visible = true;
                    }
                    if (lblWantId != null)
                    {
                        lblWantId.Visible = true;
                    }
                }
                #endregion

                DropDownList ddPremiumsTypeIdEdit = (DropDownList)e.Row.FindControl("ddPremiumsTypeIdEdit");
                if (ddPremiumsTypeIdEdit != null)
                {
                    if (xMPremiums.PremiumsTypeId != null)
                    {
                        ddPremiumsTypeIdEdit.SelectedValue = xMPremiums.PremiumsTypeId.Value.ToString();
                    }
                }

                //CheckBox chkSelected = e.Row.FindControl("chkSelected") as CheckBox;
                //if (chkSelected != null)
                //{
                //    chkSelected.Visible = false;
                //}

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                #region 申请类型
                Label lblPremiumsTypeId = e.Row.FindControl("lblPremiumsTypeId") as Label;
                if (lblPremiumsTypeId != null)
                {
                    if (xMPremiums.PremiumsTypeId != null)
                        if (xMPremiums.PremiumsTypeId.Value == Convert.ToInt32(StatusEnum.ChildPremiums))
                        {

                            lblPremiumsTypeId.Text = "赠品";
                        }
                        else if (xMPremiums.PremiumsTypeId.Value == Convert.ToInt32(StatusEnum.ChildPayment))
                        {
                            lblPremiumsTypeId.Text = "赔付";
                        }
                }
                #endregion

                #region 赠品状态
                Label lblPremiumsStatus = e.Row.FindControl("lblPremiumsStatus") as Label;
                if (xMPremiums.PremiumsStatus != null)
                {
                    if (Convert.ToInt32(StatusEnum.PremiumsNoHair) == xMPremiums.PremiumsStatus.Value)
                    {

                        //if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                        //{
                        lblPremiumsStatus.Text = "未排单";
                        e.Row.Cells[8].BackColor = System.Drawing.Color.Yellow;
                        //}
                    }
                    else if (Convert.ToInt32(StatusEnum.PremiumsIssued) == xMPremiums.PremiumsStatus.Value)
                    {

                        lblPremiumsStatus.Text = "已排单";
                        e.Row.Cells[8].BackColor = System.Drawing.Color.Green;

                    }
                    //else if (Convert.ToInt32(StatusEnum.PremiumsAbnormalNoHair) == xMPremiums.PremiumsStatus.Value)
                    //{

                    //    lblPremiumsStatus.Text = "异常未发";
                    //    e.Row.Cells[6].BackColor = System.Drawing.Color.Red;

                    //}
                }
                #endregion

                #region 运营审核
                Label lblManagerStatus = e.Row.FindControl("lblManagerStatus") as Label;
                if (xMPremiums.ManagerStatus != null)
                {
                    if (Convert.ToInt32(StatusEnum.NotCheck) == xMPremiums.ManagerStatus.Value)
                    {

                        //if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                        //{
                        lblManagerStatus.Text = "未审核";
                        e.Row.Cells[9].BackColor = System.Drawing.Color.Yellow;
                        //}
                    }
                    else if (Convert.ToInt32(StatusEnum.AlreadyCheck) == xMPremiums.ManagerStatus.Value)
                    {

                        lblManagerStatus.Text = "已审核";
                        e.Row.Cells[9].BackColor = System.Drawing.Color.Green;

                    }
                    //else if (Convert.ToInt32(StatusEnum.DidNotPass) == xMPremiums.ManagerStatus.Value)
                    //{

                    //    lblManagerStatus.Text = "未通过";
                    //    e.Row.Cells[7].BackColor = System.Drawing.Color.Red;

                    //}
                }
                #endregion

                #region 财务审核
                Label lblFinanceIsAudit = e.Row.FindControl("lblFinanceIsAudit") as Label;
                if (xMPremiums.FinanceIsAudit == null || !(bool)xMPremiums.FinanceIsAudit)
                {
                    lblFinanceIsAudit.Text = "未审核";
                    e.Row.Cells[10].BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    lblFinanceIsAudit.Text = "已审核";
                    e.Row.Cells[10].BackColor = System.Drawing.Color.Green;
                }
                #endregion

                #region 运营未审核说明
                //Label lblManagerExplanation = e.Row.FindControl("lblManagerExplanation") as Label;
                //if (xMPremiums.ManagerExplanation != null && xMPremiums.ManagerExplanation != "")
                //{
                //    if (xMPremiums.ManagerExplanation.Length > 8)
                //    {
                //        //var SdeliveryAddress = CutStr(deliveryAddress, 20);
                //        string strExplanation = xMPremiums.ManagerExplanation.ToString().Substring(0, 8);
                //        lblManagerExplanation.Text = strExplanation + "...";
                //        lblManagerExplanation.ToolTip = xMPremiums.ManagerExplanation.ToString();
                //    }
                //    else
                //    {
                //        lblManagerExplanation.Text = xMPremiums.ManagerExplanation.ToString();
                //        lblManagerExplanation.ToolTip = xMPremiums.ManagerExplanation.ToString();
                //    }
                //}
                //else
                //{
                //    lblManagerExplanation.Text = "";

                //}
                #endregion

                #region 运营审核通过 不可修改
                //ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                if (imgBtnDelete != null)
                {
                    if ((xMPremiums.ManagerStatus == (int)StatusEnum.AlreadyCheck && xMPremiums.PremiumsStatus == (int)StatusEnum.PremiumsIssued) ||
                       (xMPremiums.ManagerStatus == (int)StatusEnum.AlreadyCheck && xMPremiums.PremiumsStatus == (int)StatusEnum.PremiumsNoHair))
                    {
                        //imgBtnEdit.Visible = false;
                        imgBtnDelete.Visible = false;
                    }
                    else
                    {

                        //imgBtnEdit.Visible = true;
                        imgBtnDelete.Visible = true;
                    }
                }

                #endregion

                #region 已经排单的赠品信息  不显示复选框
                //CheckBox chkSelected = e.Row.FindControl("chkSelected") as CheckBox;
                //if (chkSelected != null)
                //{
                //    if (xMPremiums.IsSingleRow == true)
                //    {
                //        chkSelected.Visible = false;
                //    }
                //    else
                //    {
                //        chkSelected.Visible = true;
                //    }
                //}
                #endregion

                #region 赠品信息
                //弹出赠品信息
                //ImageButton imgPremiumsDetails = e.Row.FindControl("imgPremiumsDetails") as ImageButton;

                //if (imgPremiumsDetails != null)
                //{
                //    imgPremiumsDetails.OnClientClick = "return ShowWindowDetail('赠品信息','" + CommonHelper.GetStoreLocation()
                //   + "ManageProject/XMPremiumsDetailsManage.aspx?PremiumsId=" + xMPremiums.Id + "',800, 450, this, function(){document.getElementById('"
                //   + this.btnRefresh.ClientID + "').click();});";
                //}

                #endregion

                #region 总监审核
                //Label lblDirectorStatus = e.Row.FindControl("lblDirectorStatus") as Label;
                //if (xMPremiums.DirectorStatus != null)
                //{
                //    if (Convert.ToInt32(StatusEnum.NotCheck) == xMPremiums.DirectorStatus.Value)
                //    {

                //        //if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                //        //{
                //        lblDirectorStatus.Text = "未审核";
                //        e.Row.Cells[8].BackColor = System.Drawing.Color.Yellow;
                //        //}
                //    }
                //    else if (Convert.ToInt32(StatusEnum.AlreadyCheck) == xMPremiums.DirectorStatus.Value)
                //    {

                //        lblDirectorStatus.Text = "已审核";
                //        e.Row.Cells[8].BackColor = System.Drawing.Color.Green;

                //    }
                //    else if (Convert.ToInt32(StatusEnum.DidNotPass) == xMPremiums.DirectorStatus.Value)
                //    {

                //        lblDirectorStatus.Text = "未通过";
                //        e.Row.Cells[8].BackColor = System.Drawing.Color.Red;

                //    }
                //}
                #endregion

                #region 总监未审核说明
                //Label lblDirectorExplanation = e.Row.FindControl("lblDirectorExplanation") as Label;
                //if (xMPremiums.DirectorExplanation != null && xMPremiums.DirectorExplanation != "")
                //{
                //    if (xMPremiums.DirectorExplanation.Length > 8)
                //    {
                //        //var SdeliveryAddress = CutStr(deliveryAddress, 20);
                //        string strExplanation = xMPremiums.DirectorExplanation.ToString().Substring(0, 8);
                //        lblDirectorExplanation.Text = strExplanation + "...";
                //        lblDirectorExplanation.ToolTip = xMPremiums.DirectorExplanation.ToString();
                //    }
                //    else
                //    {
                //        lblDirectorExplanation.Text = xMPremiums.DirectorExplanation.ToString();
                //        lblDirectorExplanation.ToolTip = xMPremiums.DirectorExplanation.ToString();
                //    }
                //}
                //else
                //{
                //    lblDirectorExplanation.Text = "";

                //}
                #endregion

                LinkButton lbtnOrderNo = e.Row.FindControl("lbtnOrderNo") as LinkButton;
                if (lbtnOrderNo != null)
                {
                    //lbtnOrderNo.Text = mXMQuestion.OrderNO;
                    lbtnOrderNo.OnClientClick = "return ShowWindowDetail('订单详情','" + CommonHelper.GetStoreLocation()
                                                + "ManageProject/XMOrderUpdate.aspx?XMPremiumsId=" + lbtnOrderNo.CommandArgument.ToString()
                                                + "&XMOrderType=XMPremiumsValue"
                                                + "', 1000, 750, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";
                }
            }
        }

        /// <summary>
        /// 财务审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnFinanceIsAudit_Click(object sender, EventArgs e)
        //{
        //    List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
        //    if (IDs.Count <= 0)
        //    {
        //        base.ShowMessage("你没有选择任何记录");
        //        return;
        //    }
        //    else
        //    {
        //        var XMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
        //        var FinanceIsAuditTrue = XMPremiumsList.Where(a => a.FinanceIsAudit.Value == true).ToList();

        //        if (FinanceIsAuditTrue.Count > 0)
        //        {
        //            base.ShowMessage("请选择财务未审核的数据.");
        //            return;
        //        }
        //        foreach (GridViewRow row in gvXMPremiumsList.Rows)
        //        {
        //            CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //            if (chkSelected.Checked)
        //            {
        //                int Id = 0;
        //                int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                XMPremiums premiums = base.XMPremiumsService.GetXMPremiumsById(Id);

        //                if (premiums != null)
        //                {
        //                    premiums.FinancePeople = HozestERPContext.Current.User.CustomerID;
        //                    premiums.FinanceIsAudit = true;
        //                    premiums.FinanceTime = DateTime.Now;
        //                    premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                    premiums.UpdateTime = DateTime.Now;
        //                    base.XMPremiumsService.UpdateXMPremiums(premiums);
        //                }
        //            }
        //        }
        //    }
        //    this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
        //    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //    ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);

        //}

        /// <summary>
        /// 项目审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManagerStatus_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                var xMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
                //var FinanceIsAuditFalse = xMPremiumsList.Where(a => a.FinanceIsAudit.Value == false).ToList();
                var NotCheckList = xMPremiumsList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCheck)).ToList();//运营已审核
                // var DidNotPassList = xMPremiumsList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//运营未通过

                //if (FinanceIsAuditFalse.Count > 0)
                //{
                //    base.ShowMessage("请选择财务已审核的数据.");
                //    return;
                //}

                if (NotCheckList.Count > 0)
                {
                    base.ShowMessage("请选择运营未审核的数据.");
                    return;
                }
                else
                {
                    foreach (GridViewRow row in gvXMPremiumsList.Rows)
                    {
                        CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                        if (chkSelected.Checked)
                        {
                            int Id = 0;
                            int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                            XMPremiums premiums = base.XMPremiumsService.GetXMPremiumsById(Id);

                            if (premiums != null)
                            {
                                if (premiums.PaymentPerson == null && premiums.PremiumsTypeId == Convert.ToInt32(StatusEnum.ChildPayment))
                                {
                                    base.ShowMessage("请先选择赔付方后，再审核！");
                                    return;
                                }
                            }
                        }
                    }
                }

                foreach (GridViewRow row in gvXMPremiumsList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        XMPremiums premiums = base.XMPremiumsService.GetXMPremiumsById(Id);

                        if (premiums != null)
                        {
                            premiums.ManagerPeople = HozestERPContext.Current.User.CustomerID;
                            premiums.ManagerStatus = Convert.ToInt32(StatusEnum.AlreadyCheck);
                            premiums.ManagerTime = DateTime.Now;
                            premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            premiums.UpdateTime = DateTime.Now;
                            base.XMPremiumsService.UpdateXMPremiums(premiums);
                        }
                    }
                }
            }
            base.ShowMessage("审核成功！");
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        /// <summary>
        /// 财务审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinanceStatus_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                var xMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
                var EndList = xMPremiumsList.Where(a => a.PremiumsStatus.Value == Convert.ToInt32(StatusEnum.PremiumsIssued)).ToList();//已排单
                if (EndList.Count > 0)
                {
                    base.ShowMessage("已排单数据不允许操作！");
                    return;
                }

                foreach (GridViewRow row in gvXMPremiumsList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        XMPremiums premiums = base.XMPremiumsService.GetXMPremiumsById(Id);

                        if (premiums != null)
                        {
                            premiums.FinanceIsAudit = true;
                            premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            premiums.UpdateTime = DateTime.Now;
                            base.XMPremiumsService.UpdateXMPremiums(premiums);
                        }
                    }
                }
            }

            base.ShowMessage("财务审核成功！");
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        /// <summary>
        /// 项目反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManagerStatusNo_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                var xMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
                var NotCheckList = xMPremiumsList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.NotCheck)).ToList();//项目未审核
                var DidNotPassList = xMPremiumsList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.PremiumsIssued)).ToList();//运营未通过
                var EndList = xMPremiumsList.Where(a => a.PremiumsStatus.Value == Convert.ToInt32(StatusEnum.PremiumsIssued)).ToList();//已排单
                if (EndList.Count > 0)
                {
                    base.ShowMessage("已排单数据不允许反审核");
                    return;
                }
                if (NotCheckList.Count > 0 || DidNotPassList.Count > 0)
                {
                    base.ShowMessage("请选择项目已审核、未排单的数据.");
                    return;
                }
                foreach (GridViewRow row in gvXMPremiumsList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        XMPremiums premiums = base.XMPremiumsService.GetXMPremiumsById(Id);

                        if (premiums != null)
                        {
                            premiums.ManagerPeople = HozestERPContext.Current.User.CustomerID;
                            premiums.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                            premiums.ManagerTime = DateTime.Now;
                            premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            premiums.UpdateTime = DateTime.Now;
                            base.XMPremiumsService.UpdateXMPremiums(premiums);
                        }
                    }
                }
            }
            base.ShowMessage("反审核成功！");
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

        }

        /// <summary>
        /// 财务反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinanceStatusNo_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                var xMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
                var EndList = xMPremiumsList.Where(a => a.PremiumsStatus.Value == Convert.ToInt32(StatusEnum.PremiumsIssued)).ToList();//已排单
                if (EndList.Count > 0)
                {
                    base.ShowMessage("已排单数据不允许操作！");
                    return;
                }

                foreach (GridViewRow row in gvXMPremiumsList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        XMPremiums premiums = base.XMPremiumsService.GetXMPremiumsById(Id);

                        if (premiums != null)
                        {
                            premiums.FinanceIsAudit = false;
                            premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            premiums.UpdateTime = DateTime.Now;
                            base.XMPremiumsService.UpdateXMPremiums(premiums);
                        }
                    }
                }
            }

            base.ShowMessage("财务审核成功！");
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        /// <summary>
        /// 运营未通过  (店长未通过说明处理)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void hidBtnManagerStatusNO_Click(object sender, EventArgs e)
        //{
        //    if (Session["SelectPremiumsExplanation"] == null)
        //        return;
        //    try
        //    {
        //        List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);

        //        if (IDs.Count > 0)
        //        {

        //            foreach (GridViewRow row in gvXMPremiumsList.Rows)
        //            {
        //                CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //                if (chkSelected.Checked)
        //                {
        //                    int Id = 0;
        //                    int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                    XMPremiums premiums = base.XMPremiumsService.GetXMPremiumsById(Id);

        //                    if (premiums != null)
        //                    {

        //                        //premiums.FinanceIsAudit = false;
        //                        //premiums.FinancePeople = HozestERPContext.Current.User.CustomerID;
        //                        //premiums.FinanceTime = DateTime.Now;

        //                        premiums.ManagerPeople = HozestERPContext.Current.User.CustomerID;
        //                        premiums.ManagerStatus = Convert.ToInt32(StatusEnum.DidNotPass);
        //                        premiums.ManagerExplanation = Session["SelectPremiumsExplanation"].ToString();
        //                        premiums.ManagerTime = DateTime.Now;
        //                        premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                        premiums.UpdateTime = DateTime.Now;
        //                        base.XMPremiumsService.UpdateXMPremiums(premiums);
        //                    }
        //                }
        //            }
        //        }
        //        base.ShowMessage("保存成功!");


        //        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

        //        ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);

        //    }
        //    catch (Exception err)
        //    {
        //        base.ProcessException(err);
        //    }
        //}

        /// <summary>
        /// 运营未通过     弹出未通过说明窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void hidBtnManagerStatusNOM_Click(object sender, EventArgs e)
        //{

        //    string paramScript = "ShowWindowDetail1('b-win','未通过说明','" + CommonHelper.GetStoreLocation() +
        //            "ManageProject/XMPremiumsDistribution.aspx',500,200, this, function(){document.getElementById('"
        //            + this.hidBtnManagerStatusNO.ClientID + "').click();});";
        //    this.Master.JsWrite(paramScript, "");
        //}

        /// <summary>
        /// 运营未通过 判断 （判断已选择数据是否通过财务审核、店长已审核、店长未通过）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnManagerStatusNO_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
        //        if (IDs.Count <= 0)
        //        {
        //            base.ShowMessage("你没有选择任何记录");
        //            return;
        //        }
        //        else
        //        {
        //            var xMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
        //            //var FinanceIsAuditFalse = xMPremiumsList.Where(a => a.FinanceIsAudit.Value == false).ToList();
        //            var NotCheckList = xMPremiumsList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCheck)).ToList();//店长已审核
        //            var DidNotPassList = xMPremiumsList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//店长未通过

        //            //if (FinanceIsAuditFalse.Count > 0)
        //            //{
        //            //    base.ShowMessage("请选择财务已审核的数据.");
        //            //    return;
        //            //}

        //            if (NotCheckList.Count > 0 || DidNotPassList.Count > 0)
        //            {
        //                base.ShowMessage("请选择运营未审核的数据.");
        //                return;
        //            }
        //            //运营未审核、运营未通过 （弹出未通过说明窗口）
        //            if ( NotCheckList.Count == 0 && DidNotPassList.Count == 0)
        //            {

        //                Session["SelectPremiumsExplanation"] = null;
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

        /// <summary>
        /// 总监审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnDirectorStatus_Click(object sender, EventArgs e)
        //{
        //    List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
        //    if (IDs.Count <= 0)
        //    {
        //        base.ShowMessage("你没有选择任何记录");
        //        return;
        //    }
        //    else
        //    {
        //        var xMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
        //        var MNotCheckList = xMPremiumsList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.NotCheck)).ToList();//店长未审核
        //        var MDidNotPassList = xMPremiumsList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//店长未通过

        //        var DAlreadyCheckList = xMPremiumsList.Where(a => a.DirectorStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCheck)).ToList();//总监已审核
        //        var DDidNotPassList = xMPremiumsList.Where(a => a.DirectorStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//总监未通过

        //        if (MNotCheckList.Count > 0 || MDidNotPassList.Count > 0 || DAlreadyCheckList.Count > 0 || DDidNotPassList.Count > 0)
        //        {
        //            base.ShowMessage("请选择店长已审核的数据.");
        //            return;
        //        }


        //        foreach (GridViewRow row in gvXMPremiumsList.Rows)
        //        {
        //            CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //            if (chkSelected.Checked)
        //            {
        //                int Id = 0;
        //                int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                XMPremiums premiums = base.XMPremiumsService.GetXMPremiumsById(Id);

        //                if (premiums != null)
        //                {
        //                    premiums.DirectorPeople = HozestERPContext.Current.User.CustomerID;
        //                    premiums.DirectorStatus = Convert.ToInt32(StatusEnum.AlreadyCheck);
        //                    premiums.DirectorTime = DateTime.Now;
        //                    premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                    premiums.UpdateTime = DateTime.Now;
        //                    base.XMPremiumsService.UpdateXMPremiums(premiums);
        //                }
        //            }
        //        }
        //    }
        //    this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
        //    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //    ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);

        //}

        /// <summary>
        /// 总监未通过  (总监未通过说明处理)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void hidBtnDirectorStatusNO_Click(object sender, EventArgs e)
        //{
        //    if (Session["SelectPremiumsExplanation"] == null)
        //        return;
        //    try
        //    {
        //        List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);

        //        if (IDs.Count > 0)
        //        {

        //            foreach (GridViewRow row in gvXMPremiumsList.Rows)
        //            {
        //                CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //                if (chkSelected.Checked)
        //                {
        //                    int Id = 0;
        //                    int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                    XMPremiums premiums = base.XMPremiumsService.GetXMPremiumsById(Id);

        //                    if (premiums != null)
        //                    {
        //                        //premiums.FinanceIsAudit = false;
        //                        //premiums.FinancePeople = HozestERPContext.Current.User.CustomerID;
        //                        //premiums.FinanceTime = DateTime.Now;

        //                        premiums.DirectorPeople = HozestERPContext.Current.User.CustomerID;
        //                        premiums.DirectorStatus = Convert.ToInt32(StatusEnum.DidNotPass);
        //                        premiums.DirectorTime = DateTime.Now;

        //                        premiums.DirectorExplanation = Session["SelectPremiumsExplanation"].ToString();
        //                        premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                        premiums.UpdateTime = DateTime.Now;
        //                        base.XMPremiumsService.UpdateXMPremiums(premiums);
        //                    }
        //                }
        //            }
        //        }
        //        this.Master.JsWrite("alert('确认成功。');RefreshSearch();", "");
        //        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //        ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);

        //    }
        //    catch (Exception err)
        //    {
        //        base.ProcessException(err);
        //    }
        //}

        /// <summary>
        /// 总监未通过    弹出未通过说明窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void hidBtnDirectorStatusNOD_Click(object sender, EventArgs e)
        //{

        //    string paramScript = "ShowWindowDetail1('b-win','未通过说明','" + CommonHelper.GetStoreLocation() +
        //            "ManageProject/XMPremiumsDistribution.aspx',500,200, this, function(){document.getElementById('"
        //            + this.hidBtnDirectorStatusNO.ClientID + "').click();});";
        //    this.Master.JsWrite(paramScript, "");
        //}

        /// <summary>
        /// 总监未通过 判断 （判断已选择数据是否通过财务审核、店长已审核、店长未通过）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnDirectorStatusNO_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
        //        if (IDs.Count <= 0)
        //        {
        //            base.ShowMessage("你没有选择任何记录");
        //            return;
        //        }
        //        else
        //        {
        //            var XMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);

        //            var MNotCheckList = XMPremiumsList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.NotCheck)).ToList();//店长未审核
        //            var MDidNotPassList = XMPremiumsList.Where(a => a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//店长未通过

        //            var DAlreadyCheckList = XMPremiumsList.Where(a => a.DirectorStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCheck)).ToList();//总监已审核
        //            var DDidNotPassList = XMPremiumsList.Where(a => a.DirectorStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//总监未通过

        //            if (MNotCheckList.Count > 0 || MDidNotPassList.Count > 0 || DAlreadyCheckList.Count > 0 || DDidNotPassList.Count > 0)
        //            {
        //                base.ShowMessage("请选择店长已审核的数据.");
        //                return;
        //            }
        //            //财务已经审核通过、店长未审核、店长未通过 （弹出未通过说明窗口）
        //            if (MNotCheckList.Count == 0 && MDidNotPassList.Count == 0 && DAlreadyCheckList.Count == 0 && DDidNotPassList.Count == 0)
        //            {
        //                Session["SelectPremiumsExplanation"] = null;
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

        #region 排单
        /// <summary>
        /// 排单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnIsSingleRow_Click(object sender, EventArgs e)
        //{
        //    //事务
        //    using (TransactionScope scope = new TransactionScope())
        //    {
        //        List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
        //        if (IDs.Count <= 0)
        //        {
        //            base.ShowMessage("你没有选择任何记录！");
        //            return;
        //        }
        //        else
        //        {
        //            //a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)  || 
        //            //查询所有选中的赠品信息
        //            var XMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
        //            var DDidNotPassList = XMPremiumsList.Where(a =>
        //                a.ManagerStatus.Value == Convert.ToInt32(StatusEnum.NotCheck)
        //                || a.PremiumsStatus == Convert.ToInt32(StatusEnum.PremiumsIssued)
        //                ).ToList();//运营未通过、赠品状态未发

        //            if (DDidNotPassList.Count > 0)
        //            {
        //                base.ShowMessage("请选择运营已审核赠品状态是未发的数据！");
        //                return;
        //            }

        //            #region 判断库存
        //            ////取赠品信息id
        //            //List<int> premiumsIdList = XMPremiumsList.Select(p => p.Id).ToList();
        //            ////根据赠品Id查询明细（根据商品编辑统计数量）
        //            //var PSumProductNumList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsIdList(premiumsIdList);

        //            //if (PSumProductNumList.Count > 0)
        //            //{

        //            //    for (int i = 0; i < PSumProductNumList.Count; i++)
        //            //    {
        //            //        //根据赠品商家编码 查询商品表 返回单个商品信息
        //            //        var productList = base.XMProductService.getXMProductListByManufacturersCode(PSumProductNumList[i].PlatformMerchantCode);


        //            //        var productListNow = productList.Where(p => p.ManufacturersCode.Equals(PSumProductNumList[i].PlatformMerchantCode)).ToList();

        //            //        if (productListNow.Count == 0)
        //            //        {
        //            //            base.ShowMessage("无赠品信息,请维护商品信息!");
        //            //            return;
        //            //        }
        //            //        else
        //            //        {
        //            //            if (productListNow[0].ManufacturersInventory < PSumProductNumList[i].SumProductNum)
        //            //            {

        //            //                base.ShowMessage(productListNow[0].ProductName + "实际库存数:" + productListNow[0].ManufacturersInventory + ",所需库存数:" + PSumProductNumList[i].SumProductNum + ",库存不足!");
        //            //                return;
        //            //            }
        //            //            if (productListNow[0].ManufacturersInventory == 0)
        //            //            {
        //            //                base.ShowMessage("无库存!");
        //            //                return;
        //            //            }
        //            //        }
        //            //    }

        //            //}

        //            #endregion

        //            #region 排单
        //            foreach (GridViewRow row in gvXMPremiumsList.Rows)
        //            {
        //                CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //                if (chkSelected.Checked)
        //                {
        //                    int Id = 0;
        //                    int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                    XMPremiums xMPremiums = base.XMPremiumsService.GetXMPremiumsById(Id);

        //                    if (xMPremiums != null)
        //                    {
        //                        List<XMPremiumsDetails> XMPremiumsDetailsList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(xMPremiums.Id);

        //                        if (XMPremiumsDetailsList.Count == 0)
        //                        {
        //                            base.ShowMessage("赠品明细无数据！");
        //                            return;
        //                        }
        //                        else
        //                        {
        //                            List<int> ShipperType = new List<int>();
        //                            //var ShipperList=base.CodeService.GetCodeListInfoByCodeTypeID(226);
        //                            //if(ShipperList.Count>0)
        //                            //{
        //                            //    ShipperType.Add(ShipperList[0].CodeID);
        //                            //}
        //                            foreach (XMPremiumsDetails info in XMPremiumsDetailsList)
        //                            {
        //                                if (info.Shipper != null && ShipperType.IndexOf((int)info.Shipper) == -1)
        //                                {
        //                                    ShipperType.Add((int)info.Shipper);
        //                                }
        //                            }

        //                            foreach (int Shipper in ShipperType)
        //                            {
        //                                //返回明细数据
        //                                //根据订单号 、是否发货：否0、未打印:0  查询发货单 
        //                                var xmDeliveryList = base.XMDeliveryService.GetXMDeliveryListByOrderCodeShipper(xMPremiums.OrderCode, Shipper);

        //                                //发货单对象
        //                                HozestERP.BusinessLogic.ManageProject.XMDelivery xd = new HozestERP.BusinessLogic.ManageProject.XMDelivery();

        //                                //未返回明细数据 新增发货单主表信息
        //                                if (xmDeliveryList.Count == 0)//根据订单号、未发货查询 未返回数据 则新增发货单
        //                                {
        //                                    //新增
        //                                    #region 生成发货单
        //                                    xd.DeliveryTypeId = 481;//非正常
        //                                    xd.DeliveryNumber = "ZP" + DateTime.Now.ToString("yyyyMMddHHmmssfff");//赠品发货单号（自动生成）
        //                                    xd.OrderCode = xMPremiums.OrderCode;
        //                                    xd.Price = 0;//运费
        //                                    xd.Shipper = Shipper;//发货方
        //                                    //备用地址
        //                                    var SpareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(xMPremiums.Id, 711);
        //                                    if (SpareAddress != null)
        //                                    {
        //                                        xd.FullName = SpareAddress.FullName;
        //                                        xd.Mobile = SpareAddress.Mobile;
        //                                        xd.Tel = SpareAddress.Tel;
        //                                        xd.Province = SpareAddress.Province;
        //                                        xd.City = SpareAddress.City;
        //                                        xd.County = SpareAddress.County;
        //                                        xd.DeliveryAddress = SpareAddress.DeliveryAddress;
        //                                    }
        //                                    else
        //                                    {
        //                                        if (TabPanelPremiumsType == "ManagerNoOrder")//无订单赠品
        //                                        {
        //                                            base.ShowMessage("无订单赠品必须填写备用地址！");
        //                                            return;
        //                                        }

        //                                        var OrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(xMPremiums.OrderCode);
        //                                        if (OrderInfo != null)
        //                                        {
        //                                            xd.FullName = OrderInfo.FullName;
        //                                            xd.Mobile = OrderInfo.Mobile;
        //                                            xd.Tel = OrderInfo.Tel;
        //                                            xd.Province = OrderInfo.Province;
        //                                            xd.City = OrderInfo.City;
        //                                            xd.County = OrderInfo.County;
        //                                            xd.DeliveryAddress = OrderInfo.DeliveryAddress;
        //                                        }
        //                                        else
        //                                        {
        //                                            base.ShowMessage("此订单号不存在！");
        //                                            return;
        //                                        }
        //                                    }

        //                                    xd.IsDelivery = false;//是否发货
        //                                    xd.IsEnabled = false;
        //                                    xd.CreateId = HozestERPContext.Current.User.CustomerID;
        //                                    xd.CreateDate = DateTime.Now;
        //                                    xd.UpdateId = HozestERPContext.Current.User.CustomerID;
        //                                    xd.UpdateDate = DateTime.Now;
        //                                    xd.PrintQuantity = 0;//打印次数
        //                                    xd.PrintBatch = 0;//打印批次
        //                                    base.XMDeliveryService.InsertXMDelivery(xd);
        //                                    #endregion
        //                                }
        //                                else
        //                                {
        //                                    //返回明细数据 ，根据明细主表Id查询主表信息 
        //                                    xd = xmDeliveryList[0];
        //                                }
        //                                if (xd != null)//发货单记录 不未空
        //                                {
        //                                    if (xd.Id != 0)
        //                                    {
        //                                        for (int i = 0; i < XMPremiumsDetailsList.Count; i++)
        //                                        {
        //                                            if (XMPremiumsDetailsList[i].Shipper == Shipper)
        //                                            {
        //                                                #region 尺寸
        //                                                string Specifications = "";
        //                                                if (XMPremiumsDetailsList[i].ProductDetaislId != null)
        //                                                {
        //                                                    var product = base.XMProductService.GetXMProductById(XMPremiumsDetailsList[i].ProductDetaislId.Value);
        //                                                    if (product != null)
        //                                                    {
        //                                                        //尺寸  
        //                                                        Specifications = product.Specifications;
        //                                                    }
        //                                                }

        //                                                if (Specifications == "")
        //                                                {
        //                                                    var productDetails = base.XMProductService.GetXMProductListByPlatformMerchantCode(XMPremiumsDetailsList[i].PlatformMerchantCode, -1);
        //                                                    if (productDetails != null && productDetails.Count > 0)
        //                                                    {
        //                                                        var product = base.XMProductService.GetXMProductById((int)productDetails[0].ProductId);
        //                                                        if (product != null)
        //                                                        {
        //                                                            //尺寸  
        //                                                            Specifications = product.Specifications;
        //                                                        }
        //                                                    }
        //                                                }
        //                                                #endregion

        //                                                #region 发货点明细  新增
        //                                                XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
        //                                                deliverDetails.OrderNo = xMPremiums.OrderCode;
        //                                                deliverDetails.DetailsTypeId = xMPremiums.PremiumsTypeId.Value;
        //                                                deliverDetails.DeliveryId = xd.Id;
        //                                                deliverDetails.ProductlId = XMPremiumsDetailsList[i].ProductDetaislId;
        //                                                deliverDetails.PlatformMerchantCode = XMPremiumsDetailsList[i].PlatformMerchantCode;
        //                                                deliverDetails.PrdouctName = XMPremiumsDetailsList[i].PrdouctName;
        //                                                deliverDetails.Specifications = Specifications;
        //                                                deliverDetails.ProductNum = XMPremiumsDetailsList[i].ProductNum;
        //                                                deliverDetails.IsEnabled = false;
        //                                                deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                                deliverDetails.CreateDate = DateTime.Now;
        //                                                deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                                deliverDetails.UpdateDate = DateTime.Now;
        //                                                base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);
        //                                                #endregion

        //                                                #region 修改产品库存数

        //                                                //if (XMPremiumsDetailsList[i].ProductDetaislId != null)
        //                                                //{
        //                                                //    var xmproduct = base.XMProductService.GetXMProductById(XMPremiumsDetailsList[i].ProductDetaislId.Value);
        //                                                //    if (xmproduct != null)
        //                                                //    {
        //                                                //        //原库存数
        //                                                //        int ManufacturersInventoryOld = xmproduct.ManufacturersInventory.Value;
        //                                                //        //新库存数=原库存数-赠品排单数量 
        //                                                //        int ManufacturersInventoryNew = xmproduct.ManufacturersInventory.Value - XMPremiumsDetailsList[i].ProductNum.Value;

        //                                                //        xmproduct.ManufacturersInventory = ManufacturersInventoryNew;
        //                                                //        xmproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                                //        xmproduct.UpdateDate = DateTime.Now;
        //                                                //        base.XMProductService.UpdateXMProduct(xmproduct);
        //                                                //    }
        //                                                //}
        //                                                #endregion
        //                                            }
        //                                        }

        //                                        #region 修改赠品状态 （已发）

        //                                        xMPremiums.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsIssued);
        //                                        xMPremiums.IsSingleRow = true;
        //                                        xMPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                                        xMPremiums.UpdateTime = DateTime.Now;
        //                                        base.XMPremiumsService.UpdateXMPremiums(xMPremiums);

        //                                        #endregion

        //                                        #region 若发货单中有发票记录,发票中同订单号排单

        //                                        var DeliveryList = base.XMDeliveryService.GetXMDeliveryByOrderCodeAndDeliveryTypeId(xd.OrderCode, 722)
        //                                            .Where(x => x.IsDelivery == false).ToList();//发票;
        //                                        if (DeliveryList != null && DeliveryList.Count > 0)
        //                                        {
        //                                            foreach (var item in DeliveryList)
        //                                            {
        //                                                //插入发货单明细
        //                                                XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
        //                                                deliverDetails.OrderNo = xd.OrderCode;
        //                                                deliverDetails.DetailsTypeId = 11;//赠品
        //                                                deliverDetails.DeliveryId = xd.Id;
        //                                                deliverDetails.ProductlId = 0;
        //                                                deliverDetails.PlatformMerchantCode = "";
        //                                                deliverDetails.PrdouctName = "发票";
        //                                                deliverDetails.Specifications = "";
        //                                                deliverDetails.ProductNum = 1;
        //                                                if (item.XM_Delivery_Details != null && item.XM_Delivery_Details.Count > 0)
        //                                                {
        //                                                    deliverDetails.InvoiceInfoID = (item.XM_Delivery_Details.ToList())[0].InvoiceInfoID;
        //                                                }
        //                                                deliverDetails.IsEnabled = false;
        //                                                deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                                deliverDetails.CreateDate = DateTime.Now;
        //                                                deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                                deliverDetails.UpdateDate = DateTime.Now;
        //                                                base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);

        //                                                item.IsEnabled = true;
        //                                                item.UpdateId = HozestERPContext.Current.User.CustomerID;
        //                                                item.UpdateDate = DateTime.Now;
        //                                                base.XMDeliveryService.UpdateXMDelivery(item);
        //                                            }
        //                                        }

        //                                        var InvoiceInfoList = base.XMInvoiceInfoService.GetXMInvoiceInfoListByOrderCode(xd.OrderCode)
        //                                            .Where(x => x.IsScrap != true && x.IsSingleRow != true && x.InvoiceType != null).ToList();//发票
        //                                        if (InvoiceInfoList != null && InvoiceInfoList.Count > 0)
        //                                        {
        //                                            foreach (var item in InvoiceInfoList)
        //                                            {
        //                                                if (item != null)
        //                                                {
        //                                                    List<XMInvoiceInfoDetail> InvoiceDetailsList = base.XMInvoiceInfoDetailService.GetXMInvoiceInfoDetailListByInvoiceInfoID(item.ID);
        //                                                    if (InvoiceDetailsList.Count > 0)
        //                                                    {
        //                                                        //插入发货单明细
        //                                                        XMDeliveryDetails deliverDetails = new XMDeliveryDetails();
        //                                                        deliverDetails.OrderNo = xd.OrderCode;
        //                                                        deliverDetails.DetailsTypeId = 11;//赠品
        //                                                        deliverDetails.DeliveryId = xd.Id;
        //                                                        deliverDetails.ProductlId = 0;
        //                                                        deliverDetails.PlatformMerchantCode = "";
        //                                                        deliverDetails.PrdouctName = "发票";
        //                                                        deliverDetails.Specifications = "";
        //                                                        deliverDetails.ProductNum = 1;
        //                                                        deliverDetails.InvoiceInfoID = item.ID;
        //                                                        deliverDetails.IsEnabled = false;
        //                                                        deliverDetails.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                                        deliverDetails.CreateDate = DateTime.Now;
        //                                                        deliverDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                                        deliverDetails.UpdateDate = DateTime.Now;
        //                                                        base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliverDetails);

        //                                                        item.IsSingleRow = true;
        //                                                        item.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                                        item.UpdateDate = DateTime.Now;
        //                                                        base.XMInvoiceInfoService.UpdateXMInvoiceInfo(item);
        //                                                    }
        //                                                }
        //                                            }
        //                                        }

        //                                        #endregion

        //                                        #region 理赔管理，赠品生成理赔自动确认
        //                                        var ClaimInfo = base.XMClaimInfoService.GetXMClaimInfoByPremiumsId(Id);
        //                                        if (ClaimInfo != null)
        //                                        {
        //                                            var ClaimInfoDetail = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(ClaimInfo.Id);
        //                                            if (ClaimInfoDetail != null && ClaimInfoDetail.Count > 0)
        //                                            {
        //                                                foreach (var a in ClaimInfoDetail)
        //                                                {
        //                                                    a.IsConfirm = true;
        //                                                    a.UpdateDate = DateTime.Now;
        //                                                    a.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                                    base.XMClaimInfoDetailService.UpdateXMClaimInfoDetail(a);
        //                                                }
        //                                            }
        //                                        }
        //                                        #endregion
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            #endregion
        //            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //            scope.Complete();
        //            base.ShowMessage("保存成功!");
        //            ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);
        //        }
        //    }
        //}
        #endregion

        #region 核对
        /// <summary>
        /// 核对
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsEvaluation_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            var xMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
            var NotEvaluationList = xMPremiumsList.Where(a => a.IsEvaluation == true).ToList();//已核对
            if (NotEvaluationList.Count > 0)
            {
                base.ShowMessage("请选择未核对数据！");
                return;
            }
            foreach (GridViewRow row in gvXMPremiumsList.Rows)
            {
                CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                if (chkSelected.Checked)
                {
                    int Id = 0;
                    int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                    XMPremiums premiums = base.XMPremiumsService.GetXMPremiumsById(Id);

                    if (premiums != null)
                    {
                        premiums.IsEvaluation = true;
                        premiums.EvaluationDate = DateTime.Now;
                        premiums.EvaluationID = HozestERPContext.Current.User.CustomerID;//核对人
                        premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        premiums.UpdateTime = DateTime.Now;
                        base.XMPremiumsService.UpdateXMPremiums(premiums);
                    }
                }
            }
            base.ShowMessage("核对成功！");
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }
        #endregion

        /// <summary>
        /// 异常未返现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnPremiumsStatusNO_Click(object sender, EventArgs e)
        //{
        //    List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
        //    if (IDs.Count <= 0)
        //    {
        //        base.ShowMessage("你没有选择任何记录");
        //        return;
        //    }
        //    else
        //    {
        //        var XMPremiumsList = base.XMPremiumsService.GetXMPremiumsByListIds(IDs);
        //        var DDidNotPassList = XMPremiumsList.Where(a => a.ManagerPeople.Value == Convert.ToInt32(StatusEnum.DidNotPass)).ToList();//运营未通过

        //        if (DDidNotPassList.Count > 0)
        //        {
        //            base.ShowMessage("请选择运营已审核的数据.");
        //            return;
        //        }

        //        foreach (GridViewRow row in gvXMPremiumsList.Rows)
        //        {
        //            CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //            if (chkSelected.Checked)
        //            {
        //                int Id = 0;
        //                int.TryParse(this.gvXMPremiumsList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                XMPremiums premiums = base.XMPremiumsService.GetXMPremiumsById(Id);

        //                if (premiums != null)
        //                {
        //                    premiums.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsAbnormalNoHair);
        //                    premiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                    premiums.UpdateTime = DateTime.Now;
        //                    base.XMPremiumsService.UpdateXMPremiums(premiums);
        //                }
        //            }
        //        }
        //    }
        //    base.ShowMessage("保存成功!");
        //    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //    ScriptManager.RegisterStartupScript(this.gvXMPremiumsList, this.Page.GetType(), "XMPremiumsList", "autoCompleteBind()", true);

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

        public int RowEditTypeIndex = 0;

        /// <summary>
        /// 赠品TabPane 类型
        /// </summary>
        public string TabPanelPremiumsType
        {
            get
            {
                return CommonHelper.QueryString("TabPanelPremiumsType");
            }
        }

        //导出明细
        protected void btnExportInfoList_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> IDs = this.Master.GetSelectedIds(this.gvXMPremiumsList);
                if (IDs.Count <= 0)
                {
                    base.ShowMessage("你没有选择任何记录！");
                    return;
                }

                string fileName = string.Format("GiftInfoList_{0}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                string filePath = string.Format("{0}Upload\\GiftInfoList", HttpContext.Current.Request.PhysicalApplicationPath);
                if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = filePath + "//" + fileName;
                this.BindGrid(1, Master.PageSize);
                if (ExportXMPremiumsList != null && ExportXMPremiumsList.Count > 0)
                {
                    List<XMPremiums> list = new List<XMPremiums>();
                    foreach (int id in IDs)
                    {
                        foreach (XMPremiums a in ExportXMPremiumsList)
                        {
                            if (a.Id == id)
                            {
                                list.Add(a);
                            }
                        }
                    }
                    base.ExportManager.ExportPremiumsXls(filePath, list);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                    ExportXMPremiumsList = null;
                }
                else
                {
                    base.ShowMessage("数据为空，请先查询！");
                }
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }
    }
}