using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using HozestERP.Common;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageFinance
{
    public partial class XMCashBackApplicationDetailsSS : BaseAdministrationPage, ISearchPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlXMProjectTypeId.SelectedValue = this.ProjectTypeId;
                this.ddlXMProjectNameId.SelectedValue = this.ProjectNameId;
                this.ddlNickList.SelectedValue = this.NickId;
                this.ddlPlatformTypeId.SelectedValue = this.PlatformTypeId;
                //this.ddlOrderStatus.SelectedValue = this.OrderStatusId;

                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {
             this.Master.SetTitle("返现明细");  

            #region 平台类型绑定

            //平台类型动态数据绑定
            this.ddlPlatformTypeId.Items.Clear();
            var codeLists = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatformTypeId.DataSource = codeLists;
            this.ddlPlatformTypeId.DataTextField = "CodeName";
            this.ddlPlatformTypeId.DataValueField = "CodeID";
            this.ddlPlatformTypeId.DataBind();
            this.ddlPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));
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

            #region 店铺名称绑定

            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddlNickList.Items.Clear();
                var NickList = base.XMNickService.GetXMNickList();
                var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                this.ddlNickList.DataSource = newNickList;
                this.ddlNickList.DataTextField = "nick";
                this.ddlNickList.DataValueField = "nick_id";
                this.ddlNickList.DataBind();
                this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                //其他
                //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 362);

                if (xMNickList.Count > 0)
                {
                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = xMNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }
            #endregion


        }


        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //List<int> nickIdListInt = new List<int>();
            //if (this.nickIdList != "")
            //{
            //    int[] sts = new int[this.nickIdList.Split(',').Length];
            //    for (int i = 0; i < this.nickIdList.Split(',').Length; i++)
            //    {
            //        string Id = this.nickIdList.Split(',')[i];
            //        sts[i] = Convert.ToInt32(Id);
            //    } 
            //    nickIdListInt = new List<int>(sts); 
            //}
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
            DateTime? OrderInfoModifiedStart = DateTime.Now.AddYears(-100);//开始时间
            if (this.min != "")
            {
                OrderInfoModifiedStart = DateTime.Parse(min);

            }
            if (this.txtBeginDate.SelectedDate.HasValue)
            {
                OrderInfoModifiedStart = this.txtBeginDate.SelectedDate;
            }
            DateTime? OrderInfoModifiedEnd = DateTime.Now;//结束时间
            if (this.max != "")
            {
                OrderInfoModifiedEnd = DateTime.Parse(max).AddDays(1).AddSeconds(-1);

            }
            if (this.txtEndDate.SelectedDate.HasValue)
            {
                OrderInfoModifiedEnd = this.txtEndDate.SelectedDate.Value.AddDays(1).AddSeconds(-1);
            }
            if (OrderInfoModifiedStart != DateTime.Now.AddYears(-100))  //默认值设置
            {
                this.txtBeginDate.SelectedDate = OrderInfoModifiedStart;
            }
            else
            {
                this.txtBeginDate.SelectedDate = this.txtBeginDate.SelectedDate;
            }
            if (OrderInfoModifiedEnd != DateTime.Now)
            {
                this.txtEndDate.SelectedDate = OrderInfoModifiedEnd;
            }
            else
            {
                this.txtEndDate.SelectedDate = this.txtEndDate.SelectedDate;
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
            string cbNick = "-1";

            if (this.ddlNickList.SelectedValue != null)
            {
                cbNick = this.ddlNickList.SelectedValue.ToString();
            }

            //店铺集合
            List<int> nickIdList = new List<int>();

            //合并新的list
            //List<CWProfitMapping> CWProfitMappingList = new List<CWProfitMapping>();

            #region 店铺条件查询集合 处理
            //选择某项目  
            if (cbXMProject != "-1")
            {
                if (cbNick == "-1")//项目下的所有店铺
                {
                    var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                   // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

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

                    //var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    nickIdList = NickList.Select(a => a.nick_id).ToList();
                }
                else
                {
                    nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                }

            }
            #endregion
             //返现明细集合
            List<OrderInfoSalesDetails> XMCashBackApplicationDetailsList = base.XMCashBackApplicationService.GetXMCashBackApplicationDetailsList(
               Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32((this.OrderStatusId)));

            var pageList = new PagedList<OrderInfoSalesDetails>(XMCashBackApplicationDetailsList, paramPageIndex, paramPageSize);

            this.Master.BindData(this.grdXMCashBackApplicationDetailsList, pageList);

        }

        #endregion



        /// <summary>
        /// 查询
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

            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue));
                this.ddlNickList.Items.Clear();
                // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                this.ddlNickList.DataSource = nickList;
                this.ddlNickList.DataTextField = "nick";
                this.ddlNickList.DataValueField = "nick_id";
                this.ddlNickList.DataBind();
                this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                //其他
                //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), HozestERPContext.Current.User.CustomerID, 362);
                this.ddlNickList.Items.Clear();
                // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                this.ddlNickList.DataSource = nickList;
                this.ddlNickList.DataTextField = "nick";
                this.ddlNickList.DataValueField = "nick_id";
                this.ddlNickList.DataBind();
                this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
            }

        }



        protected void grdXMCashBackApplicationDetailsList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


            }
        }


        /// <summary>
        /// 平台Id
        /// </summary>
        public string PlatformTypeId
        {
            get
            {
                return CommonHelper.QueryString("PlatformTypeId");
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
        /// 店铺Id
        /// </summary>
        public string NickId
        {
            get
            {
                return CommonHelper.QueryString("NickId");
            }
        }

        /// <summary>
        /// 时间类型
        /// </summary>
        public string OrderStatusId
        {
            get
            {
                return CommonHelper.QueryString("OrderStatusId");
                //return "1";
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
                //return min;
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
                //return max;
            }
        }



    }
}