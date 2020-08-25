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
using HozestERP.BusinessLogic.ManageApplication;

namespace HozestERP.Web.ManageFinance
{
    public partial class XMReturnMoneyList : BaseAdministrationPage, ISearchPage
    {
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

        }

        public void Face_Init()
        {
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
                //其他
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

            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddlXMProjectNameId.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362);

                this.ddlXMProjectNameId.DataSource = projectList;
                this.ddlXMProjectNameId.DataTextField = "ProjectName";
                this.ddlXMProjectNameId.DataValueField = "Id";
                this.ddlXMProjectNameId.DataBind();
                this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                this.ddlXMProjectNameId.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });

                this.ddlXMProjectNameId.DataSource = projectList;
                this.ddlXMProjectNameId.DataTextField = "ProjectName";
                this.ddlXMProjectNameId.DataValueField = "Id";
                this.ddlXMProjectNameId.DataBind();
                this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));
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

            #region 项目类型绑定

            //项目类型绑定
            this.ddlXMProjectTypeId.Items.Clear();
            var codeProjectTypeLists = base.CodeService.GetCodeListInfoByCodeTypeID(189, false);
            var codenew = codeProjectTypeLists.Where(p => p.CodeID == 362);
            this.ddlXMProjectTypeId.DataSource = codenew;
            this.ddlXMProjectTypeId.DataTextField = "CodeName";
            this.ddlXMProjectTypeId.DataValueField = "CodeID";
            this.ddlXMProjectTypeId.DataBind();
            #endregion

            #region 品牌绑定

            this.ddlBrandType.Items.Clear();
            var BrandTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(187, false);
            this.ddlBrandType.DataSource = BrandTypeList;
            this.ddlBrandType.DataTextField = "CodeName";
            this.ddlBrandType.DataValueField = "CodeID";
            this.ddlBrandType.DataBind();
            this.ddlBrandType.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion

            this.ddlPlatform.SelectedValue = PlatformType;//平台
            this.ddlNick.SelectedValue = NickId;//店铺
            this.ddlXMProjectNameId.SelectedValue = ProjectNameId;//项目名称
            this.ddlTimeType.SelectedValue = OrderStatus;//时间类型
            this.txtBeginDate.ctlDateTime.Text = DateTime.Parse(min).ToString("yyyy-MM-dd");//开始时间
            this.txtEndDate.ctlDateTime.Text = DateTime.Parse(max).ToString("yyyy-MM-dd");//结束时间
            this.ddlXMProjectTypeId.SelectedValue = ProjectTypeId;//项目类型
            if (!string.IsNullOrEmpty(this.BrandType))
            {
                this.ddlBrandType.SelectedValue = this.BrandType;
            }
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            this.BindGrid(paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
        }

        public void BindGrid(int paramPageIndex, int paramPageSize, string sortExpression, string sortDirection)
        {
            //店铺集合
            List<int> nickIdList = new List<int>();
            var platform = int.Parse(this.ddlPlatform.SelectedValue);//平台
            var nickid = int.Parse(this.ddlNick.SelectedValue);//店铺
            var OrderCode = this.txtOrderCode.Text.Trim();//订单号
            var BeginDate = this.txtBeginDate.SelectedDate;//开始时间
            var EndDate = this.txtEndDate.SelectedDate;//结束时间
            //var projectNameId = this.ddlXMProjectNameId.SelectedValue;//项目名称
            var timeType = this.ddlTimeType.SelectedValue;//时间类型
            //var projectTypeId = this.ddlXMProjectTypeId.SelectedValue;//项目类型

            if (BeginDate == null)
            {
                var ti = DateTime.Now.AddDays(-7);
                var ti2 = DateTime.Now;
                this.txtBeginDate.SelectedDate = DateTime.Parse(ti.Year + "-" + ti.Month + "-" + ti.Day);
                this.txtEndDate.SelectedDate = DateTime.Parse(ti2.Year + "-" + ti2.Month + "-" + ti2.Day);
                BeginDate = DateTime.Parse(ti.Year + "-" + ti.Month + "-" + ti.Day);
                EndDate = ti2;
            }
            else
            {
                EndDate = EndDate.Value.AddDays(+1).AddSeconds(-1);
            }

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
            //店铺名称
            string cbNick = "-1";
            if (this.ddlNick.SelectedValue != null)
            {
                cbNick = this.ddlNick.SelectedValue.ToString();
            }

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
                    nickIdList.Add(Convert.ToInt32(this.ddlNick.SelectedValue));
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
                    nickIdList.Add(Convert.ToInt32(this.ddlNick.SelectedValue));
                }

            }
            #endregion

            List<int?> NickIdList = new List<int?>();
            foreach (int nick in nickIdList)
            {
                NickIdList.Add(nick);
            }
            var list = base.XMApplicationService.GetXMConsultationListByData(platform, NickIdList, OrderCode, BeginDate, EndDate, int.Parse(timeType));

            string BrandType = this.BrandType;
            if (this.ddlBrandType.SelectedValue != "")
            {
                BrandType = this.ddlBrandType.SelectedValue;
            }
            if (BrandType != "-1")
            {
                var Ids = base.XMApplicationService.GetXMConsultationListByDataByBrandType(list, int.Parse(BrandType)).Select(x=>x.ApplicationId).ToList();
                list = list.Where(x => Ids.Contains(x.ID)).ToList();
            }

            var pageList = new PagedList<XMApplication>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            if (this.Master.GridViewSortField == "")
            {
                pageList = new PagedList<XMApplication>(list, paramPageIndex, paramPageSize, "CreateDate", "DESC");
            }
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

        protected void gvQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var mXMQuestion = (XMApplication)e.Row.DataItem;
            LinkButton lbtnOrderNo = e.Row.FindControl("lbtnOrderNo") as LinkButton;
            ImageButton ImgBtnCR = e.Row.FindControl("ImgBtnCR") as ImageButton;
            Label lblApplicationType = e.Row.FindControl("lblApplicationType") as Label;
            HtmlInputCheckBox chkAll = e.Row.FindControl("chkAll") as HtmlInputCheckBox;
            ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
            CheckBox chkSelected = e.Row.FindControl("chkSelected") as CheckBox;
            LinkButton lbtnReservepriceOrder = e.Row.FindControl("lbtnReservepriceOrder") as LinkButton;
            if (lbtnOrderNo != null)
            {
                lbtnOrderNo.Text = mXMQuestion.OrderCode;
                lbtnOrderNo.OnClientClick = "return ShowWindowDetail('订单详情','" + CommonHelper.GetStoreLocation()
                                            + "ManageProject/XMOrderUpdate.aspx?XMApplicationOrderCode=" + lbtnOrderNo.CommandArgument.ToString()
                                            + "&XMOrderType=Application"
                                            + "', 1000, 750, this, function(){document.getElementById('" + this.hidBtnSearch.ClientID + "').click();});";
            }

            if (lbtnReservepriceOrder != null)
            {
                lbtnReservepriceOrder.Text = mXMQuestion.ReservepriceOrder;
                lbtnReservepriceOrder.OnClientClick = "return ShowWindowDetail('补价订单详情','" + CommonHelper.GetStoreLocation()
                                            + "ManageProject/XMOrderUpdate.aspx?XMApplicationOrderCode=" + lbtnReservepriceOrder.CommandArgument.ToString()
                                            + "&XMOrderType=Application"
                                            + "', 1000, 750, this, function(){document.getElementById('" + this.hidBtnSearch.ClientID + "').click();});";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (mXMQuestion != null)
                {
                    string paramScript1 = "return ShowWindowDetail('进退货申请详细','" + CommonHelper.GetStoreLocation() + "ManageApplication/XMApplicationAdd.aspx?type=2"
                         + "&scid=" + mXMQuestion.ID +
                        "',900,650, this, function(){document.getElementById('" + this.hidBtnSearch.ClientID + "').click();});";
                    if (ImgBtnCR != null) ImgBtnCR.Attributes.Add("onclick", paramScript1);
                }
            }
            if (mXMQuestion != null)
            {
                if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.tuihuo))
                {
                    lblApplicationType.Text = "先退货后退款";
                }
                else if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.huanhuo))
                {
                    lblApplicationType.Text = "换货";
                }
                else if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.weifahuo))
                {
                    lblApplicationType.Text = "未发货退款";
                }
                else if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.secondtuihuan))
                {
                    lblApplicationType.Text = "先退款后退货";
                }
                else if (mXMQuestion.ApplicationType.Value == Convert.ToInt32(AppStatusEnum.tuiyunfei))
                {
                    lblApplicationType.Text = "退运费";
                }
                else if (mXMQuestion.ApplicationType.Value == Convert.ToInt16(AppStatusEnum.shouhou))
                {
                    lblApplicationType.Text = "售后";
                }
                else if (mXMQuestion.ApplicationType.Value ==  Convert.ToInt16(AppStatusEnum.shouzhong))
                {
                    lblApplicationType.Text = "售中";
                }
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectNameId
        {
            get
            {
                return CommonHelper.QueryString("ProjectNameId");
            }
        }

        /// <summary>
        /// 时间类型
        /// </summary>
        public string OrderStatus
        {
            get
            {
                return CommonHelper.QueryString("OrderStatus");
            }
        }

        /// <summary>
        /// 项目类型
        /// </summary>
        public string ProjectTypeId
        {
            get
            {
                return CommonHelper.QueryString("ProjectTypeId");
            }
        }

        /// <summary>
        /// 平台
        /// </summary>
        public string PlatformType
        {
            get
            {
                return CommonHelper.QueryString("PlatformTypeId");
            }
        }

        /// <summary>
        /// 店铺
        /// </summary>
        public string NickId
        {
            get
            {
                return CommonHelper.QueryString("NickId");
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string min
        {
            get
            {
                return CommonHelper.QueryString("min");
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string max
        {
            get
            {
                return CommonHelper.QueryString("max");
            }
        }

        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandType
        {
            get
            {
                return CommonHelper.QueryString("BrandType");
            }
        }
    }
}
