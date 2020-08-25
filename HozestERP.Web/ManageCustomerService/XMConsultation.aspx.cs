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
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.Controls;
using HozestERP.Web.Modules;
using JdSdk.Domain;
using Top.Api.Domain;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMConsultations : BaseAdministrationPage, ISearchPage
    {
        private int childindex = -1;
        private XMOrderInfo xmorderinfo;//订单信息

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnSearch", "XMConsultation.Search");
                buttons.Add("Button1", "XMConsultation.Daochu");//导出
                buttons.Add("imgBtnList", "XMConsultation.GridView.ListEdit");//咨询跟进主表编辑按钮
                buttons.Add("LeaderComments", "XMConsultation.GridView.LeaderEdit");//组长点评
                buttons.Add("ImgBtnCR", "XMConsultation.GridView.CommunicationRecord");//咨询跟进沟通记录
                buttons.Add("imgBtnDelete", "XMConsultation.GridView.Delete");//单条删除 
                buttons.Add("imgBtnUpdate", "XMConsultation.GridView.Save");//咨询跟进主表保存
                buttons.Add("imgBtnCancel", "XMConsultation.GridView.Cancel");//咨询跟进主表取消  
                buttons.Add("btnDelete", "XMConsultation.AllDelete");//批量删除
                return buttons;
            }
        }

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
            this.BindGrid(paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
        }

        public void BindGrid(int paramPageIndex, int paramPageSize, string sortExpression, string sortDirection)
        {
            var ddlPlatform = int.Parse(this.ddlPlatform.SelectedValue);
            var nickid = int.Parse(this.ddlNick.SelectedValue);
            var count = int.Parse(this.count.SelectedValue);
            var cust = this.txtSrvAfterCustomerID.Text.Trim();
            var creat = this.creat.Text.Trim();
            var grade = this.FollowGrade2.SelectedValue;
            var IsOrder = this.ddlIsOrder.SelectedValue;
            var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
            List<int?> a = new List<int?> { };
            if (nickid == -2)
            {
                foreach (var list in xMNickList)
                {
                    a.Add(list.nick_id);
                }
            }
            var xmConsultation = base.XMConsultationService.GetXMConsultationList(IsOrder, ddlPlatform, nickid, this.txtBeginDate.SelectedDate, this.txtEndDate.SelectedDate, cust, creat, paramPageIndex, paramPageSize, count, grade, a);
            var pageList = new PagedList<XMConsultation>(xmConsultation, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            //if (QuestionType == "Feedback")
            //{
            if (this.RowEditIndex == -1)
            {
                //新增编码行
                this.gvQuestion.EditIndex = pageList.Count();
                pageList.Add(new XMConsultation());
            }
            else
            {
                this.gvQuestion.EditIndex = this.RowEditIndex;
            }
            //}
            this.Master.BindData(this.gvQuestion, pageList, paramPageSize + 1);
        }

        #endregion

        protected void hidBtnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
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

        protected void gvQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ddlNick = (DropDownList)e.Row.FindControl("ddlNick");
            DropDownList ddlPlatform = (DropDownList)e.Row.FindControl("Platform");
            DropDownList NoCause = (DropDownList)e.Row.FindControl("NoCause");
            DropDownList NoTurnoverType = (DropDownList)e.Row.FindControl("ddlNoTurnoverType");
            if (e.Row.RowState == DataControlRowState.Edit ||
    e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                #region 店铺名称绑定

                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 522)
                {
                    ddlNick.Items.Clear();
                    var NickList2 = base.XMNickService.GetXMNickList();
                    var newNickList = NickList2.Where(p => p.isEnable == true).ToList();
                    ddlNick.DataSource = newNickList;
                    ddlNick.DataTextField = "nick";
                    ddlNick.DataValueField = "nick_id";
                    ddlNick.DataBind();
                    //ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    //其他
                    var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var newNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0).Where(p => p.isEnable == true).ToList();
                    if (newNickList.Count() == 0)
                    {
                        ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                    }
                    if (newNickList.Count > 0)
                    {
                        ddlNick.Items.Clear();
                        ddlNick.DataSource = newNickList;
                        ddlNick.DataTextField = "nick";
                        ddlNick.DataValueField = "nick_id";
                        ddlNick.DataBind();
                        //ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                    }
                }

                #endregion

                #region 平台类型动态数据绑定
                //平台类型动态数据绑定
                ddlPlatform.Items.Clear();
                var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
                ddlPlatform.DataSource = codeList;
                ddlPlatform.DataTextField = "CodeName";
                ddlPlatform.DataValueField = "CodeID";
                ddlPlatform.DataBind();

                #endregion

                #region 不跟进原因绑定
                //不跟进原因绑定
                NoCause.Items.Clear();
                var codeList2 = base.CodeService.GetCodeListInfoByCodeTypeID(208, false);
                NoCause.DataSource = codeList2;
                NoCause.DataTextField = "CodeName";
                NoCause.DataValueField = "CodeID";
                NoCause.DataBind();
                NoCause.Items.Insert(0, new ListItem("", "-1"));
                #endregion

                #region 未成交类型
                NoTurnoverType.Items.Clear();
                var codeList3 = base.CodeService.GetCodeListInfoByCodeTypeID(212, false);
                NoTurnoverType.DataSource = codeList3;
                NoTurnoverType.DataTextField = "CodeName";
                NoTurnoverType.DataValueField = "CodeName";
                NoTurnoverType.DataBind();
                NoTurnoverType.Items.Insert(0, new ListItem("", "-1"));
                #endregion
            }
            var XMConsultation = (XMConsultation)e.Row.DataItem;
            ImageButton ImgBtnCR = e.Row.FindControl("ImgBtnCR") as ImageButton;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (XMConsultation != null)
                {
                    #region 咨询跟进 主表绑定
                    if (XMConsultation.Id != 0)
                    {

                        string paramScript1 = "return ShowWindowDetail('沟通记录','" + CommonHelper.GetStoreLocation() + "ManageCustomerService/XMConsultationDetails.aspx?ConsultationId="
                            + XMConsultation.Id +
                            "',900,650, this, function(){document.getElementById('" + this.hidBtnSearch.ClientID + "').click();});";
                        if (ImgBtnCR != null) ImgBtnCR.Attributes.Add("onclick", paramScript1);
                    }
                    #endregion
                }
            }
        }

        protected void gvQuestion_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

            int Id = 0;
            int index = e.NewEditIndex;
            int Nindex = index;
            int.TryParse(this.gvQuestion.DataKeys[Nindex].Value.ToString(), out Id);
            var row = this.gvQuestion.Rows[Nindex];
            var product = base.XMConsultationService.GetXMConsultationById(Id);
            if (product != null)
            {
                var deptId = base.CustomerInfoService.GetCustomerInfoByID(int.Parse(product.CreatorID.ToString()));

                var zhuguan = base.EnterpriseService.GetDepartmentById(int.Parse(deptId.DepartmentID.ToString()));
                if (HozestERPContext.Current.User.CustomerID == 7)
                {
                }
                else
                {
                    var zgtop = base.EnterpriseService.GetDepartmentById(int.Parse(zhuguan.ParentID.ToString()));
                    if (product.CreatorID != HozestERPContext.Current.User.CustomerID && zhuguan.DepManagerID != HozestERPContext.Current.User.CustomerID && HozestERPContext.Current.User.CustomerID != 7 && zgtop.DepManagerID != HozestERPContext.Current.User.CustomerID)
                    {
                        base.ShowMessage("只有创建人和该组组长和客服总监才能修改此条咨询跟进");
                        this.RowEditIndex = -1;
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                        return;
                    }
                }
            }

            if (product != null)
            {
                //店铺
                DropDownList ddlNick = (DropDownList)row.FindControl("ddlNick");
                if (ddlNick != null)
                {
                    ddlNick.SelectedValue = product.NickId.Value.ToString();
                }

                //平台
                DropDownList ddlPlatform = (DropDownList)row.FindControl("Platform");
                if (ddlPlatform != null)
                {
                    ddlPlatform.SelectedValue = product.PlatformTypeId.Value.ToString();
                }
                var LeaderComments = row.FindControl("LeaderComments") as TextBox; //组长点评
                var LeaderComments3 = row.FindControl("LeaderComments3") as Label; //组长点评 label
                var deptId = base.CustomerInfoService.GetCustomerInfoByID(int.Parse(product.CreatorID.ToString()));
                var zhuguan = base.EnterpriseService.GetDepartmentById(int.Parse(deptId.DepartmentID.ToString()));
                if (HozestERPContext.Current.User.CustomerID == 7)
                {
                    LeaderComments.ReadOnly = false;
                    LeaderComments.Visible = true;
                }
                else
                {
                    var zgtop = base.EnterpriseService.GetDepartmentById(int.Parse(zhuguan.ParentID.ToString()));
                    if (zhuguan.DepManagerID == HozestERPContext.Current.User.CustomerID || HozestERPContext.Current.User.CustomerID == 7 || zgtop.DepManagerID == HozestERPContext.Current.User.CustomerID)
                    {
                        LeaderComments.ReadOnly = false;
                        LeaderComments.Visible = true;
                    }
                    else
                    {
                        LeaderComments3.Visible = true;
                    }
                }
                //跟进等级
                DropDownList FollowGrade = (DropDownList)row.FindControl("FollowGrade");
                if (FollowGrade != null)
                {
                    FollowGrade.SelectedValue = product.FollowGrade;
                }
                //未成交类型
                DropDownList NoTurnoverType = (DropDownList)row.FindControl("ddlNoTurnoverType");
                if (NoTurnoverType != null)
                {
                    NoTurnoverType.SelectedValue = product.NoTurnoverType;
                }
                //不跟进原因
                DropDownList NoCause = (DropDownList)row.FindControl("NoCause");
                if (NoCause != null)
                {
                    NoCause.SelectedValue = product.NoCause.ToString();
                }
                //是否下订单
                CheckBox chkIsOrder = (CheckBox)row.FindControl("chkIsOrder");
                if (chkIsOrder != null)
                {
                    chkIsOrder.Checked = product.IsOrder == null ? false : (bool)product.IsOrder;
                }
                //厂家编码
                TextBox txtManufacturersCode = (TextBox)row.FindControl("txtManufacturersCode");
                if (txtManufacturersCode != null)
                {
                    txtManufacturersCode.Text = product.ManufacturersCode == null ? "" : product.ManufacturersCode;
                }
            }
            //ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        protected void gvQuestion_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            this.BindGrid(Master.PageIndex, Master.PageSize);
            ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        protected void gvQuestion_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool mark = false;
            var row = this.gvQuestion.Rows[e.RowIndex];
            var hfPlatformId = row.FindControl("Platform") as DropDownList;//平台Id
            var bqPlatformId = row.FindControl("lblPlatform") as Label;//平台Id 标签
            var hftxtNickId = row.FindControl("ddlNick") as DropDownList; //店铺Id
            var hftxtWantID = row.FindControl("txtNickName") as TextBox; //顾客
            var bqtxtWantID = row.FindControl("lbltxtNickName") as Label; //顾客 biaoqian
            //var txtOrderNO = row.FindControl("txtPayDateStart") as TextBox; //接待时间
            var lblOrderNO = row.FindControl("ddlNoTurnoverType") as DropDownList;//未成交类型
            var txtPlatformName = row.FindControl("txtWantID3") as TextBox;//原因  
            //var txtNickName = row.FindControl("txtWantID4") as TextBox;//客服  
            var txtWantID = row.FindControl("NoCause") as DropDownList;//不跟进原因
            var FollowGrade = row.FindControl("FollowGrade") as DropDownList;//跟进等级
            var LeaderComments = row.FindControl("LeaderComments") as TextBox; //组长点评
            var lbltxtNickName = row.FindControl("lbltxtNickName") as Label; //顾客
            var lbltxtOrderNO = row.FindControl("lbltxtPayDateStart") as Label; //接待时间
            var chkIsOrder = row.FindControl("chkIsOrder") as CheckBox; //是否下单 
            var txtOrderCode = row.FindControl("txtOrderCode") as TextBox; //下单单号
            var txtManufacturersCode = row.FindControl("txtManufacturersCode") as TextBox; //厂家编码

            int QID = Convert.ToInt32(gvQuestion.DataKeys[e.RowIndex].Value.ToString());

            if (string.IsNullOrEmpty(hftxtWantID.Text.Trim()))
            {
                base.ShowMessage("顾客id不能为空！");
                lbltxtNickName.Text = "顾客id不能为空";
                lbltxtNickName.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (chkIsOrder.Checked)
            {
                //订单单个同步
                if (!OrderUpdate(txtOrderCode.Text.Trim()))
                {
                    base.ShowMessage("无法找到此订单，请确认该订单号是否正确！");
                    return;
                }
                if (string.IsNullOrEmpty(txtOrderCode.Text.Trim()))
                {
                    base.ShowMessage("已下单订单，订单号不能为空！");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtPlatformName.Text.Trim()))
                {
                    base.ShowMessage("当日未成交原因不能为空！");
                    return;
                }
                if (lblOrderNO.SelectedValue == "-1")
                {
                    base.ShowMessage("请选择未成交类型！");
                    return;
                }
                if (FollowGrade.SelectedValue == "-1")
                {
                    base.ShowMessage("请选择跟进等级！");
                    return;
                }
                if (txtWantID.SelectedValue == "-1")
                {
                    base.ShowMessage("请选择不跟进原因！");
                    return;
                }
            }

            //客服跟进
            var mXMQuestion = base.XMConsultationService.GetXMConsultationById(QID);
            //查询平台客户是否重复
            var iscf = base.XMConsultationService.GetXMConsultationByCx(int.Parse(hfPlatformId.SelectedValue), hftxtWantID.Text.Trim(), txtManufacturersCode.Text.Trim());

            XMConsultation info = null;
            if (chkIsOrder.Checked)
            {
                info = base.XMConsultationService.GetXMConsultationByOrderCode(txtOrderCode.Text.Trim(), txtManufacturersCode.Text.Trim());
            }
            if (mXMQuestion == null)
            {
                if ((!chkIsOrder.Checked && iscf == null) || (chkIsOrder.Checked && info == null))//新增
                {
                    mark = true;
                    XMConsultation mxmConsultation = new XMConsultation();
                    mxmConsultation.NickId = Convert.ToInt32(hftxtNickId.SelectedValue);  //店铺id
                    mxmConsultation.PlatformTypeId = int.Parse(hfPlatformId.SelectedValue);//平台
                    mxmConsultation.CustomerID = hftxtWantID.Text.Trim();//顾客
                    mxmConsultation.ReceptionDate = DateTime.Now;  //接待时间
                    mxmConsultation.NoTurnoverType = lblOrderNO.SelectedValue;//未成交类型
                    mxmConsultation.DateReason = txtPlatformName.Text;//原因
                    //mxmConsultation.CustomerService = txtNickName.Text;//客服
                    mxmConsultation.NoCause = int.Parse(txtWantID.SelectedValue);//不跟进原因
                    mxmConsultation.FollowGrade = FollowGrade.SelectedValue;//跟进等级
                    mxmConsultation.LeaderComments = LeaderComments.Text;
                    mxmConsultation.IsOrder = chkIsOrder.Checked;//是否下单
                    mxmConsultation.ManufacturersCode = txtManufacturersCode.Text.Trim();//厂家编码
                    if (chkIsOrder.Checked)
                    {
                        mxmConsultation.OrderCode = txtOrderCode.Text.Trim();//订单号
                    }
                    else
                    {
                        mxmConsultation.OrderCode = "";//订单号
                    }
                    mxmConsultation.CreatorID = HozestERPContext.Current.User.CustomerID;//创建人
                    mxmConsultation.Created = DateTime.Now;//创建时间
                    mxmConsultation.UpdatorID = HozestERPContext.Current.User.CustomerID;//更新人
                    mxmConsultation.Updated = DateTime.Now;//更新时间
                    mxmConsultation.IsEnable = false;//是否删除
                    base.XMConsultationService.InsertXMConsultation(mxmConsultation);
                    base.ShowMessage("添加成功.");
                }
            }
            else
            {
                if ((!chkIsOrder.Checked && (iscf == null || (hftxtWantID.Text.Trim() == bqtxtWantID.Text.Trim() && int.Parse(hfPlatformId.SelectedValue) == int.Parse(bqPlatformId.Text) && !(bool)mXMQuestion.IsOrder))) ||
                        (chkIsOrder.Checked && (info == null || (info != null && info.Id == QID))))
                {
                    mark = true;
                    mXMQuestion.NickId = Convert.ToInt32(hftxtNickId.SelectedValue);//店铺id
                    mXMQuestion.PlatformTypeId = int.Parse(hfPlatformId.SelectedValue);//平台
                    mXMQuestion.CustomerID = hftxtWantID.Text.Trim();//顾客
                    //mXMQuestion.ReceptionDate = DateTime.Parse(txtOrderNO.Text);  //接待时间
                    mXMQuestion.NoTurnoverType = lblOrderNO.SelectedValue;//未成交类型
                    mXMQuestion.DateReason = txtPlatformName.Text;//原因
                    mXMQuestion.FollowGrade = FollowGrade.SelectedValue;//跟进等级
                    //mXMQuestion.CustomerService = txtNickName.Text;//客服
                    mXMQuestion.IsOrder = chkIsOrder.Checked;//是否下单
                    mXMQuestion.ManufacturersCode = txtManufacturersCode.Text.Trim();//厂家编码
                    if (chkIsOrder.Checked)
                    {
                        mXMQuestion.OrderCode = txtOrderCode.Text.Trim();//订单号
                    }
                    else
                    {
                        mXMQuestion.OrderCode = "";//订单号
                    }
                    mXMQuestion.NoCause = int.Parse(txtWantID.SelectedValue);//不跟进原因
                    mXMQuestion.LeaderComments = LeaderComments.Text;
                    mXMQuestion.UpdatorID = HozestERPContext.Current.User.CustomerID;//更新人
                    mXMQuestion.Updated = DateTime.Now;//更新时间
                    base.XMConsultationService.UpdateXMConsultation(mXMQuestion);
                    base.ShowMessage("更新成功！");
                }
            }
            if (!mark)
            {
                if (!chkIsOrder.Checked)
                {
                    base.ShowMessage("同平台同客户同厂家编码的数据只能有一条！");
                }
                else
                {
                    base.ShowMessage("同订单号同厂家编码的数据只能有一条！");
                }
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
                var xMQuestion = base.XMConsultationService.GetXMConsultationById(Id);
                if (xMQuestion != null)
                {
                    xMQuestion.IsEnable = true;
                    base.XMConsultationService.UpdateXMConsultation(xMQuestion);
                }
                //grid 绑定
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("删除成功.");
                ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
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
                var xMQuestion = base.XMConsultationService.GetXMConsultationById(item);
                if (xMQuestion != null)
                {
                    xMQuestion.IsEnable = true;
                    base.XMConsultationService.UpdateXMConsultation(xMQuestion);
                }
            }
            base.ShowMessage("删除成功.");
            this.BindGrid(Master.PageIndex, Master.PageSize);
            ScriptManager.RegisterStartupScript(this.gvQuestion, this.Page.GetType(), "QuestionList", "autoCompleteBind()", true);
        }

        //导出
        protected void btnDaochu_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
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
                    var ddlPlatform = int.Parse(this.ddlPlatform.SelectedValue);
                    var nickid = int.Parse(this.ddlNick.SelectedValue);
                    var count = int.Parse(this.count.SelectedValue);
                    var cust = this.txtSrvAfterCustomerID.Text.Trim();
                    var creat = this.creat.Text.Trim();
                    var grade = this.FollowGrade2.SelectedValue;
                    var IsOrder = this.ddlIsOrder.SelectedValue;
                    var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                    List<int?> a = new List<int?> { };
                    if (nickid == -2)
                    {
                        foreach (var list in xMNickList)
                        {
                            a.Add(list.nick_id);
                        }
                    }
                    var xmConsultation = base.XMConsultationService.GetXMConsultationList(IsOrder, ddlPlatform, nickid, this.txtBeginDate.SelectedDate, this.txtEndDate.SelectedDate, cust, creat, 0, 0, count, grade, a);
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\QuestionDetailExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                    base.ExportManager.ExportConsultationXls(filePath, xmConsultation);

                    CommonHelper.WriteResponseXls(filePath, fileName);

                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
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

        public bool OrderUpdate(string OrderCode)
        {
            bool successful = false;
            //订单号查询
            xmorderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(OrderCode);
            int TMInsertCount = 0;
            int TMUpdateCount = 0;

            int JDInsertCount = 0;
            int JDUpdateCount = 0;

            int TMCDInsertCount = 0;
            int TMCDUpdateCount = 0;

            int VPHInsertCount = 0;
            int VPHUpdateCount = 0;

            int YHDInsertCount = 0;
            int YHDUpdateCount = 0;

            int SuningInsertCount = 0;
            int SuningUpdateCount = 0;

            //订单号订单表 已经存在  
            if (this.xmorderinfo != null)
            {
                #region 各平台单个订单同步

                var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();

                switch (xmorderinfo.PlatformTypeId)
                {
                    //天猫
                    case 250:
                        XMOrderInfoApp xMorderInfoAppTMNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 250 && q.NickId == xmorderinfo.NickID).FirstOrDefault();
                        if (xMorderInfoAppTMNew != null)
                        {
                            Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(xmorderinfo.OrderCode), xMorderInfoAppTMNew);
                            if (trade != null)
                            {
                                base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoAppTMNew);
                            }
                        }
                        break;
                    //京东 (喜临门、嘟丽)
                    case 251:

                        List<XMOrderInfoApp> xMorderInfoAppJDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 251 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoAppJDNew.Count > 0)
                        {
                            for (int j = 0; j < xMorderInfoAppJDNew.Count; j++)
                            {
                                HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xmorderinfo.OrderCode, xMorderInfoAppJDNew[j].AppKey, xMorderInfoAppJDNew[j].AppSecret, xMorderInfoAppJDNew[j].ServerUrl, xMorderInfoAppJDNew[j].AccessToken);
                                if (orderInfo != null)
                                {
                                    base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDNew[j]);
                                }
                            }
                        }
                        break;

                    //京东闪购
                    case 382:
                        List<XMOrderInfoApp> xMorderInfoAppJDSJNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 382 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoAppJDSJNew.Count > 0)
                        {
                            for (int j = 0; j < xMorderInfoAppJDSJNew.Count; j++)
                            {
                                HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xmorderinfo.OrderCode, xMorderInfoAppJDSJNew[j].AppKey, xMorderInfoAppJDSJNew[j].AppSecret, xMorderInfoAppJDSJNew[j].ServerUrl, xMorderInfoAppJDSJNew[j].AccessToken);
                                if (orderInfo != null)
                                {
                                    base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDSJNew[j]);
                                }
                            }
                        }
                        break;
                    //淘宝集市店
                    case 381:
                        List<XMOrderInfoApp> xMorderInfoAppTMCDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 381 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoAppTMCDNew.Count > 0)
                        {
                            for (int j = 0; j < xMorderInfoAppTMCDNew.Count; j++)
                            {
                                Trade trade = base.XMOrderInfoAPIService.GetTrade(long.Parse(xmorderinfo.OrderCode), xMorderInfoAppTMCDNew[j]);
                                if (trade != null)
                                {
                                    base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMCDInsertCount, ref  TMCDUpdateCount, xMorderInfoAppTMCDNew[j]);
                                }
                            }
                        }
                        break;
                    //唯品会
                    case 259:
                        List<XMOrderInfoApp> xMorderInfoVPHNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 259 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoVPHNew.Count > 0)
                        {
                            base.XMOrderInfoAPIService.getOrderVPH("", "", xmorderinfo.OrderCode, ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoVPHNew[0]);
                        }
                        break;
                    //一号店
                    case 375:
                        List<XMOrderInfoApp> xMorderInfoYHDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 375 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoYHDNew.Count > 0)
                        {
                            for (int j = 0; j < xMorderInfoYHDNew.Count; j++)
                            {
                                base.XMOrderInfoAPIService.getOrderYHD(xmorderinfo.OrderCode, ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoYHDNew[j]);
                            }
                        }
                        break;
                    //苏宁易购
                    case 383:
                        List<XMOrderInfoApp> xMorderInfoSuningNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 383 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoSuningNew.Count > 0)
                        {
                            for (int j = 0; j < xMorderInfoSuningNew.Count; j++)
                            {
                                base.XMOrderInfoAPIService.getOrderSuning(xmorderinfo.OrderCode, ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoSuningNew[j]);
                            }
                        }
                        break;
                }

                int count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;

                if (count > 0)
                {
                    //修改公公参数
                    base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");
                    #region 订单单个同步记录操作

                    int UpsatorID1 = 0;
                    if (HozestERPContext.Current.User != null)
                    {
                        UpsatorID1 = HozestERPContext.Current.User.CustomerID;

                    }
                    else
                    {
                        string UserName = "admin";
                        List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                        if (customer.Count > 0)
                        {
                            UpsatorID1 = customer[0].CustomerID;
                        }
                    }

                    XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                    record1.OrderInfoId = this.xmorderinfo.ID;
                    record1.PropertyName = "订单单个同步";
                    record1.OldValue = "同步成功";
                    record1.NewValue = "同步成功";
                    record1.UpdatorID = UpsatorID1;
                    record1.UpdateTime = DateTime.Now;
                    IoC.Resolve<XMOrderInfoOperatingRecordService>().InsertXMOrderInfoOperatingRecord(record1);// base.ProjectService.InsertXMOrderInfoOperatingRecord(record);

                    #endregion
                    successful = true;
                    //更新数据
                    //GetValue(this.txtSearchOrderCode.Text.Trim());
                    //base.ShowMessage("订单编码:" + xmorderinfo.OrderCode + " 数据同步成功！");
                }
                else
                {
                    //修改公共参数
                    base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");

                    #region 订单单个同步记录操作
                    int UpsatorID1 = 0;
                    if (HozestERPContext.Current.User != null)
                    {
                        UpsatorID1 = HozestERPContext.Current.User.CustomerID;
                    }
                    else
                    {
                        string UserName = "admin";
                        List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                        if (customer.Count > 0)
                        {
                            UpsatorID1 = customer[0].CustomerID;
                        }
                    }

                    XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                    record1.OrderInfoId = this.xmorderinfo.ID;
                    record1.PropertyName = "订单单个同步";
                    record1.OldValue = "同步失败";
                    record1.NewValue = "同步失败";
                    record1.UpdatorID = UpsatorID1;
                    record1.UpdateTime = DateTime.Now;
                    IoC.Resolve<XMOrderInfoOperatingRecordService>().InsertXMOrderInfoOperatingRecord(record1);// base.ProjectService.InsertXMOrderInfoOperatingRecord(record);
                    #endregion

                    //base.ShowMessage("订单编码:" + xmorderinfo.OrderCode + " 数据同步失败！");
                }
                #endregion
            }
            else //订单号 在订单表不存在
            {
                int count = 0;

                #region 订单号 在订单表不存在
                var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();
                List<XMOrderInfoApp> xMorderInfoAppTMList = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 250).ToList();
                List<XMOrderInfoApp> xMorderInfoAppJDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 251).ToList();
                List<XMOrderInfoApp> xMorderInfoAppJDSJNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 382).ToList();
                List<XMOrderInfoApp> xMorderInfoAppTMCDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 381).ToList();
                // List<XMOrderInfoApp> xMorderInfoAppJDCDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 309).ToList();
                List<XMOrderInfoApp> xMorderInfoVPHNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 259).ToList();
                List<XMOrderInfoApp> xMorderInfoYHDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 375).ToList();
                List<XMOrderInfoApp> xMorderInfoSuningNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 383).ToList();

                //天猫 
                if (xMorderInfoAppTMList.Count > 0)
                {
                    for (int t = 0; t < xMorderInfoAppTMList.Count; t++)
                    {
                        XMOrderInfoApp xMorderInfoAppTMNew = xMorderInfoAppTMList[t];

                        if (xMorderInfoAppTMNew != null)
                        {
                            Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(OrderCode), xMorderInfoAppTMNew);
                            if (trade != null)
                            {
                                base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoAppTMNew);
                                count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;
                            }
                        }
                    }
                }
                //京东 (喜临门、嘟丽)  
                if (count == 0)
                {
                    if (xMorderInfoAppJDNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoAppJDNew.Count; j++)
                        {
                            HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                            HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(OrderCode, xMorderInfoAppJDNew[j].AppKey, xMorderInfoAppJDNew[j].AppSecret, xMorderInfoAppJDNew[j].ServerUrl, xMorderInfoAppJDNew[j].AccessToken);
                            if (orderInfo != null)
                            {
                                base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDNew[j]);
                                count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;
                            }
                        }
                    }
                }
                //京东闪购 
                if (count == 0)
                {
                    if (xMorderInfoAppJDSJNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoAppJDSJNew.Count; j++)
                        {
                            HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                            HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(OrderCode, xMorderInfoAppJDSJNew[j].AppKey, xMorderInfoAppJDSJNew[j].AppSecret, xMorderInfoAppJDSJNew[j].ServerUrl, xMorderInfoAppJDSJNew[j].AccessToken);
                            if (orderInfo != null)
                            {
                                base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDSJNew[j]);
                                count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;
                            }
                        }
                    }
                }
                //淘宝集市店 
                if (count == 0)
                {
                    if (xMorderInfoAppTMCDNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoAppTMCDNew.Count; j++)
                        {
                            Trade trade = base.XMOrderInfoAPIService.GetTrade(long.Parse(OrderCode), xMorderInfoAppTMCDNew[j]);
                            if (trade != null)
                            {
                                base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMCDInsertCount, ref  TMCDUpdateCount, xMorderInfoAppTMCDNew[j]);
                                count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;
                            }
                        }
                    }
                }
                //C店 
                //if (count == 0)
                //{
                //    if (xMorderInfoAppJDCDNew.Count > 0)
                //    {
                //        for (int j = 0; j < xMorderInfoAppJDCDNew.Count; j++)
                //        {
                //            OrderInfo orderInfo = base.XMOrderInfoAPIService.getOrderInfo(this.txtSearchOrderCode.Text.Trim(), xMorderInfoAppJDCDNew[j]);
                //            if (orderInfo != null)
                //            {
                //                base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDCDNew[j]);
                //                count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;


                //            }
                //        }
                //    }
                //}
                //唯品会 
                if (count == 0)
                {
                    if (xMorderInfoVPHNew.Count > 0)
                    {
                        base.XMOrderInfoAPIService.getOrderVPH(Convert.ToDateTime(DateTime.Now).AddDays(-10).ToString("yyyy-MM-dd HH:mm:ss"), Convert.ToDateTime(DateTime.Now).AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss"), OrderCode, ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoVPHNew[0]);
                        count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;
                    }
                }
                //一号店 
                if (count == 0)
                {
                    if (xMorderInfoYHDNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoYHDNew.Count; j++)
                        {
                            base.XMOrderInfoAPIService.getOrderYHD(OrderCode, ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoYHDNew[j]);
                            count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;
                        }
                    }
                }
                //苏宁易购 
                if (count == 0)
                {
                    if (xMorderInfoSuningNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoSuningNew.Count; j++)
                        {
                            base.XMOrderInfoAPIService.getOrderSuning(OrderCode, ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoSuningNew[j]);
                            count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;
                        }
                    }
                }
                if (count > 0)
                {
                    //修改公共参数
                    base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");
                    successful = true;
                    //更新数据
                    //GetValue(this.txtSearchOrderCode.Text.Trim());
                    //base.ShowMessage("订单编码:" + xmorderinfo.OrderCode + " 数据同步成功！");
                }

                #endregion
            }
            return successful;
        }
    }
}
