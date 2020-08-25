using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Top.Api.Domain;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.Common;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Codes;
using System.Text.RegularExpressions;
using JdSdk.Domains;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using JdSdk.Domain;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Yhd.Api.Object;
using Yhd.Api;
using Yhd.Api.Request;
using Yhd.Api.Response;
using System.Reflection;
using HozestERP.BusinessLogic.ManageStock;

namespace HozestERP.Web.ManageStock
{
    public partial class XMWarehouseList : BaseAdministrationPage, ISearchPage
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
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }
        public void Face_Init()
        {
            this.ddlProvince.Items.Clear();
            var ProvinceList = base.XMWarehouseService.GetProvinceList();
            this.ddlProvince.DataSource = ProvinceList;
            this.ddlProvince.DataTextField = "City";
            this.ddlProvince.DataValueField = "NumberID";
            this.ddlProvince.DataBind();
            this.ddlProvince.Items.Insert(0, new ListItem("", ""));

            this.btnAdd.OnClientClick = "return ShowWindowDetail('仓库添加','" + CommonHelper.GetStoreLocation()
           + "ManageStock/XMWarehouseAdd.aspx?Id=-1',500, 300, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";
        }

        protected void ddlProvince_Change(object sender, EventArgs e)
        {
            //市
            string ProvinceID = this.ddlProvince.SelectedValue.ToString();
            var CityList = base.XMWarehouseService.GetCityList(ProvinceID);
            this.ddlCity.Items.Clear();
            this.ddlCity.DataSource = CityList;
            this.ddlCity.DataTextField = "City";
            this.ddlCity.DataValueField = "NumberID";
            this.ddlCity.DataBind();
            this.ddlCity.Items.Insert(0, new ListItem("", ""));
            //区（县）
            string CityID = this.ddlCity.SelectedValue.ToString();
            var CountyList = base.XMWarehouseService.GetCountyList(CityID);
            this.ddlCounty.Items.Clear();
            this.ddlCounty.DataSource = CountyList;
            this.ddlCounty.DataTextField = "City";
            this.ddlCounty.DataValueField = "NumberID";
            this.ddlCounty.DataBind();
            this.ddlCounty.Items.Insert(0, new ListItem("", ""));
        }

        protected void ddlCity_Change(object sender, EventArgs e)
        {
            //区（县）
            string CityID = this.ddlCity.SelectedValue.ToString();
            var CountyList = base.XMWarehouseService.GetCountyList(CityID);
            this.ddlCounty.Items.Clear();
            this.ddlCounty.DataSource = CountyList;
            this.ddlCounty.DataTextField = "City";
            this.ddlCounty.DataValueField = "NumberID";
            this.ddlCounty.DataBind();
            this.ddlCounty.Items.Insert(0, new ListItem("", ""));
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            //省
            string ProvinceID = this.ddlProvince.SelectedValue.Trim();
            //市
            string CityID = this.ddlCity.SelectedValue.Trim();
            //区
            string CountyID = this.ddlCounty.SelectedValue.Trim();
            //仓库名
            string WarehouseName = this.txtWarehouseName.Text.Trim();

            //根据项目名称和平台类型查询。
            var xMProjectList = base.XMWarehouseService.GetXMWarehouseList(ProvinceID, CityID, CountyID, WarehouseName);
            
            //分页
            var xMProjectPageList = new PagedList<XMWarehouse>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, xMProjectPageList, paramPageSize + 1);
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
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMScalpingApplication = e.Row.DataItem as XMWarehouse;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('仓库编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageStock/XMWarehouseAdd.aspx?Id=" + xMScalpingApplication.ID + "',500, 300, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";

                }

            }
        }
        /// <summary>
        /// 删除行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Delete"))
            {
                var orderinfoapp = base.XMWarehouseService.GetXMWarehouseByID(Convert.ToInt32(e.CommandArgument));
                if (orderinfoapp != null)//删除
                {
                    orderinfoapp.IsEnable = true;
                    orderinfoapp.UpdateID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.UpdateDate = DateTime.Now;
                    base.XMWarehouseService.UpdateXMWarehouse(orderinfoapp);

                    //省
                    string ProvinceID = this.ddlProvince.SelectedValue.Trim();
                    //市
                    string CityID = this.ddlCity.SelectedValue.Trim();
                    //区
                    string CountyID = this.ddlCounty.SelectedValue.Trim();
                    //仓库名
                    string WarehouseName = this.txtWarehouseName.Text.Trim();

                    //根据项目名称和平台类型查询。
                    var xMProjectList = base.XMWarehouseService.GetXMWarehouseList(ProvinceID, CityID, CountyID, WarehouseName);
                    int rowscount = xMProjectList.Count();//获取行数;
                    if (rowscount % this.Master.PageSize == 0)
                    { 
                        this.BindGrid(this.Master.PageIndex-1, this.Master.PageSize); 
                    }
                    else
                    {
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize); 
                    }
                   
                    base.ShowMessage("操作成功.");
                }

            }
            #endregion
        }
        /// <summary>
        /// 删除行数据之前执行的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

    }

}