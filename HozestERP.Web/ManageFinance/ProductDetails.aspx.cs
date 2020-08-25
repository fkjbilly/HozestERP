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

    public partial class ProductDetails : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.ddlPlatformTypeId.SelectedValue = this.PlatformTypeId;
                //this.ddlXMProjectTypeId.SelectedValue = this.ddlXMProjectTypeId;
                //this.ddlXMProject.SelectedValue = this.ddlXMProject;

                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {
            // this.Master.SetTitle("订单明细");  

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
            this.ddlXMProject.Items.Clear();
            var projectList = base.XMProjectService.GetXMProjectList();
            this.ddlXMProject.DataSource = projectList;
            this.ddlXMProject.DataTextField = "ProjectName";
            this.ddlXMProject.DataValueField = "Id";
            this.ddlXMProject.DataBind();
            this.ddlXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));

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
            List<int> nickIdListInt = new List<int>();
            if (this.nickIdList != "")
            {
                int[] sts = new int[this.nickIdList.Split(',').Length];
                for (int i = 0; i < this.nickIdList.Split(',').Length; i++)
                {
                    string Id = this.nickIdList.Split(',')[i];
                    sts[i] = Convert.ToInt32(Id);
                }
                nickIdListInt = new List<int>(sts);
            }

            //原数据源
            var OrderInfoSalesDetailsList = base.XMOrderInfoProductDetailsService.GetOrderInfoSalesDetailsList(Convert.ToInt32(this.PlatformTypeId), nickIdListInt, Convert.ToDateTime(this.OrderInfoModifiedStart), Convert.ToDateTime(this.OrderInfoModifiedEnd), Convert.ToInt32(this.OrderStatusId));

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

            var pageList = new PagedList<OrderInfoSalesDetails>(OrderInfoSalesDetailsListNew.ToList(), paramPageIndex, paramPageSize);

            this.Master.BindData(this.grdProductDetailsList, pageList);

        }

        #endregion

        protected void grdProductDetailsList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


            }
        }

        public string PlatformTypeId
        {
            get
            {
                return CommonHelper.QueryString("PlatformTypeId");
            }
        }


        public string nickIdList
        {
            get
            {
                return CommonHelper.QueryString("nickIdList");
            }
        }

        public string OrderInfoModifiedStart
        {
            get
            {
                return CommonHelper.QueryString("OrderInfoModifiedStart");
            }
        }

        public string OrderInfoModifiedEnd
        {
            get
            {
                return CommonHelper.QueryString("OrderInfoModifiedEnd");
            }
        }

        public string OrderStatusId
        {
            get
            {
                return CommonHelper.QueryString("OrderStatusId");
            }
        }

        public string ManufacturersCode
        {
            get
            {
                return CommonHelper.QueryString("ManufacturersCode");
            }
        }
    }
}