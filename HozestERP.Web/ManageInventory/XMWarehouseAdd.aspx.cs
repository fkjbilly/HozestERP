using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageInventory
{
    public partial class XMWarehouseAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        public void loadDate()
        {
            if (this.Type == 0)
            {
                this.Face_Init();
            }
            else
            {
                this.Face_Init();
                var XMWarehouse = base.XMWareHousesService.GetXMWareHousesById(Id);
                string ProvinceId = "";
                string countryID = "";
                if (XMWarehouse != null && XMWarehouse.CityId != "")
                {
                    ProvinceId = XMWarehouse.CityId.Substring(0, 6);
                }
              
                var c = base.XMWareHousesService.GetProvinceByProvinceId(ProvinceId);
                if (c != null)
                {
                    this.ddlProvince.SelectedValue = c.NumberID;
                    bindInfo(c.NumberID);             //绑定该省份下城市列表
                }

                this.ddlMainWareHourese.SelectedValue = XMWarehouse.ParentID == 0 ? "-1" : XMWarehouse.ParentID.ToString();
                if (XMWarehouse.CityId.Length == 12)          //有地区
                {
                    this.ddlCity.SelectedValue = XMWarehouse.CityId.ToString().Trim().Substring(0, 9);
                    //绑定地区
                    bindCounturyInfo(XMWarehouse.CityId.ToString().Trim().Substring(0, 9));
                    this.ddlCounty.SelectedValue = XMWarehouse.CityId.ToString().Trim();
                }
                else
                {
                    this.ddlCity.SelectedValue = XMWarehouse.CityId.ToString().Trim();
                }
                this.txtWarehouseName.Text = XMWarehouse.Name.ToString().Trim();
                this.ddXMProject.SelectedValue = XMWarehouse.ProjectId.ToString().Trim();
                this.ddlNick.SelectedValue = XMWarehouse.NickId.ToString().Trim();
            }
        }

        ////绑定该省份下城市列表
        private void bindInfo(string id)
        {
            var CityList = base.XMWareHousesService.GetCityList(id);
            this.ddlCity.Items.Clear();
            this.ddlCity.DataSource = CityList;
            this.ddlCity.DataTextField = "City";
            this.ddlCity.DataValueField = "NumberID";
            this.ddlCity.DataBind();
        }
        /// <summary>
        /// 
        /// </summary>
        private void bindCounturyInfo(string cityID)
        {
            var CountyList = base.XMWareHousesService.GetCountyList(cityID);
            this.ddlCounty.Items.Clear();
            this.ddlCounty.DataSource = CountyList;
            this.ddlCounty.DataTextField = "City";
            this.ddlCounty.DataValueField = "NumberID";
            this.ddlCounty.DataBind();
        }

        public void Face_Init()
        {
            if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
            {
                List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                if (XMProjectList.Count > 0)
                {
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                }
            }
            else
            {
                this.BindddXMProject();//项目
            }

            this.ddXMProject_SelectedIndexChanged(null, null);//店铺

            this.ddlProvince.Items.Clear();
            var ProvinceList = base.XMWareHousesService.GetProvinceList();
            this.ddlProvince.DataSource = ProvinceList;
            this.ddlProvince.DataTextField = "City";
            this.ddlProvince.DataValueField = "NumberID";
            this.ddlProvince.DataBind();

            //市
            string ProvinceID = this.ddlProvince.SelectedValue.ToString();
            var CityList = base.XMWareHousesService.GetCityList(ProvinceID);
            this.ddlCity.Items.Clear();
            this.ddlCity.DataSource = CityList;
            this.ddlCity.DataTextField = "City";
            this.ddlCity.DataValueField = "NumberID";
            this.ddlCity.DataBind();

            //绑定主仓
            var MainWarehoursesList = base.XMWareHousesService.GetXMWareHousesListByParentID(0);
            this.ddlMainWareHourese.Items.Clear();
            this.ddlMainWareHourese.DataSource = MainWarehoursesList;
            this.ddlMainWareHourese.DataTextField = "Name";
            this.ddlMainWareHourese.DataValueField = "Id";
            this.ddlMainWareHourese.DataBind();
            this.ddlMainWareHourese.Items.Insert(0, new ListItem("", "-1"));
            this.ddlMainWareHourese.Items[0].Selected = true;
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
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
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
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
                    else
                    {
                        if (nickList.Count() > 0)
                        {
                            this.ddlNick.DataSource = nickList;
                            this.ddlNick.DataTextField = "nick";
                            this.ddlNick.DataValueField = "nick_id";
                            this.ddlNick.DataBind();
                        }
                        this.ddlNick.Items.Insert(0, new ListItem("---所有---", "99"));
                    }
                }
                //this.ddlNick.Items.Clear();
                //var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue));
                //this.ddlNick.DataSource = nickList;
                //this.ddlNick.DataTextField = "nick";
                //this.ddlNick.DataValueField = "nick_id";
                //this.ddlNick.DataBind();
                //this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
        }

        protected void ddlProvince_Change(object sender, EventArgs e)
        {
            //市
            string ProvinceID = this.ddlProvince.SelectedValue.ToString();
            var CityList = base.XMWareHousesService.GetCityList(ProvinceID);
            this.ddlCity.Items.Clear();
            this.ddlCity.DataSource = CityList;
            this.ddlCity.DataTextField = "City";
            this.ddlCity.DataValueField = "NumberID";
            this.ddlCity.DataBind();
            this.ddlCity.Items.Insert(0, new ListItem("", "-1"));
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            //市
            int mainWareHourseID = Convert.ToInt16(ddlMainWareHourese.SelectedValue);         //主仓ID
            string CityID = this.ddlCity.SelectedValue.Trim();
            string CountyID = this.ddlCounty.SelectedValue.Trim();
            string WarehouseName = this.txtWarehouseName.Text.ToString().Trim();
            int ProjectId = ddXMProject.SelectedValue == "" ? -1 : Convert.ToInt16(ddXMProject.SelectedValue);
            int nickId = Convert.ToInt16(ddlNick.SelectedValue);
            string ProvinceId = ddlProvince.SelectedValue.Trim();
            var Province = base.XMWareHousesService.GetProvinceByProvinceId(ProvinceId);
            if (!(Province != null && (Province.City == "北京" || Province.City == "上海" || Province.City == "重庆" || Province.City == "天津")))
            {
                if (int.Parse(CityID) == -1)
                {
                    base.ShowMessage("请选择相应的城市!");
                    return;
                }
            }
            else
            {
                switch (Province.City)
                {
                    case "北京":
                        CityID = "001001";
                        break;
                    case "天津":
                        CityID = "001002";
                        break;
                    case "上海":
                        CityID = "001009";
                        break;
                    case "重庆":
                        CityID = "001022";
                        break;
                }
            }
            if (string.IsNullOrEmpty(WarehouseName))
            {
                base.ShowMessage("仓库名不能为空!");
                return;
            }
            //if (ProjectId == -1)
            //{
            //    base.ShowMessage("项目必须选择!");
            //    return;
            //}
            if (this.Type == 0)            //新增仓库
            {
                var ware = base.XMWareHousesService.GetXMWarehouseByParm(CityID, nickId, WarehouseName);
                if (ware != null && ware.Count() > 0)
                {
                    base.ShowMessage("该店铺下仓库名重复，请重新输入!");
                    return;
                }
                XMWareHouses info = new XMWareHouses();
                info.CityId = (CountyID == "" || int.Parse(CountyID) == -1) ? CityID : CountyID;
                info.ParentID = mainWareHourseID == -1 ? 0 : mainWareHourseID;
                info.NickId = nickId;
                info.ProjectId = ProjectId;
                info.Name = WarehouseName;
                info.isEnable = false;
                info.UpdateDate = info.CreateDate = DateTime.Now;
                info.UpdateID = info.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMWareHousesService.InsertXMWareHouses(info);
            }
            else                                 //编辑仓库
            {
                XMWareHouses Info = base.XMWareHousesService.GetXMWareHousesById(Id);
                if (Info != null)
                {
                    Info.CityId = (CountyID == "" || int.Parse(CountyID) == -1) ? CityID : CountyID;
                    Info.ParentID = mainWareHourseID == -1 ? 0 : mainWareHourseID;
                    Info.NickId = nickId;
                    Info.ProjectId = ProjectId;
                    Info.Name = WarehouseName;
                    Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDate = DateTime.Now;
                    base.XMWareHousesService.UpdateXMWareHouses(Info);
                }
            }
            this.Master.JsWrite("alert('保存成功.');window.PopClose();", "");
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

        public int Type
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }

        public void SetTrigger()
        {
        }
    }
}