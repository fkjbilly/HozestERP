using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    public partial class OrderInfoProductDetails : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlXMProjectTypeId.SelectedValue = this.ProjectTypeId;
                this.ddlXMProjectNameId.SelectedValue = this.ProjectNameId;
                this.ddlNickList.SelectedValue = this.NickId;
                this.ddlPlatformTypeId.SelectedValue = this.PlatformTypeId;
                this.ddlOrderStatus.SelectedValue = this.OrderStatusId;
                this.ddlDateTime.SelectedValue = this.DateTimeId;

                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            this.Master.SetTitle("产品明细");

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

            //平台类型动态数据绑定
            this.ddlXMProjectTypeId.Items.Clear();
            var codeProjectTypeLists = base.CodeService.GetCodeListInfoByCodeTypeID(189, false);
            this.ddlXMProjectTypeId.DataSource = codeProjectTypeLists;
            this.ddlXMProjectTypeId.DataTextField = "CodeName";
            this.ddlXMProjectTypeId.DataValueField = "CodeID";
            this.ddlXMProjectTypeId.DataBind();
            this.ddlXMProjectTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion

            #region 项目名称绑定

            //平台类型动态数据绑定
            this.ddlXMProjectNameId.Items.Clear();
            var projectList = base.XMProjectService.GetXMProjectList();
            this.ddlXMProjectNameId.DataSource = projectList;
            this.ddlXMProjectNameId.DataTextField = "ProjectName";
            this.ddlXMProjectNameId.DataValueField = "Id";
            this.ddlXMProjectNameId.DataBind();
            this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));

            #endregion

            #region 店铺名称绑定


            this.ddlNickList.Items.Clear();
            var NickList = base.XMNickService.GetXMNickList();
            //var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
            this.ddlNickList.DataSource = NickList;
            this.ddlNickList.DataTextField = "nick";
            this.ddlNickList.DataValueField = "nick_id";
            this.ddlNickList.DataBind();
            this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));

            #endregion
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            DateTime dt1 = DateTime.Now;//当前时间 

            //时间：本月、本季、本年
            string ddlDateTime = this.ddlDateTime.SelectedValue.ToString();

            string OrderInfoModifiedStart = "";//开始时间
            string OrderInfoModifiedEnd = "";//结束时间

            DateTime dt = Convert.ToDateTime(dt1.ToString("yyyy-MM-dd"));

            if (ddlDateTime == "本月")
            {
                //本月第一天时间   
                DateTime dt_First = dt.AddDays(-(dt.Day) + 1);
                //将本月月数+1   
                DateTime dt2 = dt.AddMonths(1);
                //本月最后一天时间   
                DateTime dt_Last = dt2.AddDays(-(dt.Day));

                OrderInfoModifiedStart = dt_First.ToString();
                OrderInfoModifiedEnd = dt_Last.AddDays(1).AddSeconds(-1).ToString();//结束时间设置到该天23：59：59 

            }
            else if (ddlDateTime == "本季")
            {
                DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day); //本季度初
                OrderInfoModifiedStart = startQuarter.ToString();
                OrderInfoModifiedEnd = startQuarter.AddMonths(3).AddSeconds(-1).ToString(); //本季度末
            }
            else if (ddlDateTime == "本年")
            {
                DateTime startYear = new DateTime(dt.Year, 1, 1); //本年年初  
                DateTime endYear = new DateTime(dt.Year, 12, 31); //本年年末 

                OrderInfoModifiedStart = startYear.ToString();
                OrderInfoModifiedEnd = endYear.AddSeconds(-1).ToString(); //本季度末
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

                    //var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

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

            //产品明细 
            var OrderInfoSalesDetailsList = base.XMOrderInfoProductDetailsService.GetOrderInfoSalesDetailsList(Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(this.OrderStatusId));

            //去掉重复的数据源
            var NotOrderInfoSalesDetailsList = OrderInfoSalesDetailsList.GroupBy(p => p.OrderCode).Select(g => g.First()).ToList();

            //重复数据源(重新给成交金额赋值)
            var NotDate = (from a in OrderInfoSalesDetailsList
                           where !NotOrderInfoSalesDetailsList.Contains(a)
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

            //去掉重复的数据源 + 重复数据源
            var OrderInfoSalesDetailsListNew = NotOrderInfoSalesDetailsList.Concat(NotDate).OrderByDescending(p => p.OrderCode).ToList();

            var pageList = new PagedList<OrderInfoSalesDetails>(OrderInfoSalesDetailsListNew, paramPageIndex, paramPageSize);

            this.Master.BindData(this.grdOrderInfoProductDetailsList, pageList);
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
            var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue));
            this.ddlNickList.Items.Clear();
            // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
            this.ddlNickList.DataSource = nickList;
            this.ddlNickList.DataTextField = "nick";
            this.ddlNickList.DataValueField = "nick_id";
            this.ddlNickList.DataBind();
            this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));

        }

        protected void grdOrderInfoProductDetailsList_RowDataBound(object sender, GridViewRowEventArgs e)
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
            }
        }

        /// <summary>
        /// 时间
        /// </summary>
        public string DateTimeId
        {
            get
            {
                return CommonHelper.QueryString("DateTimeId");
            }
        }
    }
}