using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageStock;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;

namespace HozestERP.Web.ManageStock
{
    public partial class XMWarehouseAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { loadDate(); }
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //省
            string ProvinceID = this.ddlProvince.SelectedValue.Trim();
            //市
            string CityID = this.ddlCity.SelectedValue.Trim();
            //区
            string CountyID = this.ddlCounty.SelectedValue.Trim();
            string WarehouseName = this.txtWarehouseName.Text.ToString().Trim();
            string Position = this.txtPosition.Text.ToString().Trim();

            if (string.IsNullOrEmpty(WarehouseName))
            {
                base.ShowMessage("仓库名不能为空!");
                return;
            }
            else
            {
                if (Id == -1)//添加
                {
                    XMWarehouse orderinfoapp = new XMWarehouse();
                    orderinfoapp.ProvinceID = ProvinceID;
                    orderinfoapp.CityID = CityID;
                    orderinfoapp.CountyID = CountyID;
                    orderinfoapp.WarehouseName = WarehouseName;
                    orderinfoapp.Position = Position;
                    orderinfoapp.IsEnable = false;
                    orderinfoapp.CreateID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.CreateDate = DateTime.Now;
                    orderinfoapp.UpdateID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.UpdateDate = DateTime.Now;
                    base.XMWarehouseService.InsertXMWarehouse(orderinfoapp);
                    base.ShowMessage("保存成功!");
                }
                else  //编辑
                {
                    XMWarehouse orderinfoapp = base.XMWarehouseService.GetXMWarehouseByID(Id);
                    if (orderinfoapp != null)//判断有没有这条数据
                    {
                        orderinfoapp.ProvinceID = ProvinceID;
                        orderinfoapp.CityID = CityID;
                        orderinfoapp.CountyID = CountyID;
                        orderinfoapp.WarehouseName = WarehouseName;
                        orderinfoapp.Position = Position;
                        orderinfoapp.IsEnable = false;
                        orderinfoapp.UpdateID = HozestERPContext.Current.User.CustomerID;
                        orderinfoapp.UpdateDate = DateTime.Now;
                        base.XMWarehouseService.UpdateXMWarehouse(orderinfoapp);
                        base.ShowMessage("保存成功!");
                    }
                }
            }
        }

        public void loadDate() {
            if (Id == -1)
            {
                this.Face_Init();
            }
            else
            {
                this.Face_Init();
                var XMWarehouse = base.XMWarehouseService.GetXMWarehouseByID(Id);
                this.ddlProvince.SelectedValue = XMWarehouse.ProvinceID.ToString().Trim();
                this.ddlCity.SelectedValue = XMWarehouse.CityID.ToString().Trim();
                this.ddlCounty.SelectedValue = XMWarehouse.CountyID.ToString().Trim();
                this.txtWarehouseName.Text = XMWarehouse.WarehouseName.ToString().Trim();
                this.txtPosition.Text = XMWarehouse.Position.ToString().Trim();
            }
        }
            
        

        /// <summary>
        /// 操作类型
        /// </summary>
        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        public void Face_Init()
        {
            this.ddlProvince.Items.Clear();
            var ProvinceList = base.XMWarehouseService.GetProvinceList();
            this.ddlProvince.DataSource = ProvinceList;
            this.ddlProvince.DataTextField = "City";
            this.ddlProvince.DataValueField = "NumberID";
            this.ddlProvince.DataBind();

            //市
            string ProvinceID = this.ddlProvince.SelectedValue.ToString();
            var CityList = base.XMWarehouseService.GetCityList(ProvinceID);
            this.ddlCity.Items.Clear();
            this.ddlCity.DataSource = CityList;
            this.ddlCity.DataTextField = "City";
            this.ddlCity.DataValueField = "NumberID";
            this.ddlCity.DataBind();
            //区（县）
            string CityID = this.ddlCity.SelectedValue.ToString();
            var CountyList = base.XMWarehouseService.GetCountyList(CityID);
            this.ddlCounty.Items.Clear();
            this.ddlCounty.DataSource = CountyList;
            this.ddlCounty.DataTextField = "City";
            this.ddlCounty.DataValueField = "NumberID";
            this.ddlCounty.DataBind();
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
            this.ddlCity.Items.Insert(0, new ListItem("", "-1"));
            //区（县）
            string CityID = this.ddlCity.SelectedValue.ToString();
            var CountyList = base.XMWarehouseService.GetCountyList(CityID);
            this.ddlCounty.Items.Clear();
            this.ddlCounty.DataSource = CountyList;
            this.ddlCounty.DataTextField = "City";
            this.ddlCounty.DataValueField = "NumberID";
            this.ddlCounty.DataBind();
            this.ddlCounty.Items.Insert(0, new ListItem("", "-1"));
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
            this.ddlCounty.Items.Insert(0, new ListItem("", "-1"));
        }

        public void SetTrigger()
        {
        }
    }
}