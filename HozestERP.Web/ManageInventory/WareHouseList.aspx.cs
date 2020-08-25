using System;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using System.Collections.Generic;

namespace HozestERP.Web.ManageInventory
{
    public partial class WareHouseList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                    this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                    this.ddXMProject.Items[0].Selected = true;
                }
                else
                {
                    this.BindddXMProject();//项目
                }
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                this.BindGrid(1, Master.PageSize);
            }
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
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            }
        }


        /// <summary>
        /// 根据用户customerID  获取用户 包含店铺列表
        /// </summary>
        /// <returns></returns>
        private string GetCustomerMappingNickIDs()
        {
            string nickids = "";
            int cutomerId = HozestERPContext.Current.User.CustomerID;
            var nicklist = base.XMNickCustomerMappingService.GetProjectXMNickCustomerMappingListByCustomerID(cutomerId);
            if (nicklist != null && nicklist.Count > 0)         //存在店铺列表
            {
                foreach (XMNickCustomerMapping map in nicklist)
                {
                    nickids = nickids + map.NickId + ",";
                }
            }
            if (nickids != "" && nickids.Length > 0)
            {
                nickids = nickids.Substring(0, nickids.Length - 1);
            }
            return nickids;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetXMWarehouseListByProjectID()
        {
            string projectIds = "-1,";
            int cutomerId = HozestERPContext.Current.User.CustomerID;
            var nicklist = base.XMNickCustomerMappingService.GetProjectXMNickCustomerMappingListByCustomerID(cutomerId);
            if (nicklist != null && nicklist.Count > 0)         //存在店铺列表
            {
                foreach (XMNickCustomerMapping map in nicklist)
                {
                    var nick = base.XMNickService.GetXMNickByID(map.NickId.Value);
                    if (nick != null)
                    {
                        projectIds = projectIds + nick.ProjectId + ",";
                    }
                }
            }
            if (projectIds != "" && projectIds.Length > 0)
            {
                projectIds = projectIds.Substring(0, projectIds.Length - 1);
            }
            return projectIds;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string nickids2 = GetCustomerMappingNickIDs();
            if (nickids2 == "")
            {
                base.ShowMessage("您无权限查看!");
                return;
            }
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
            var NickId = Convert.ToInt32(this.ddlNick.SelectedValue);
            string nickids = "";
            if (NickId == 99) //某个项目店铺权限，选择有权限的店铺
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), xMProjectId, HozestERPContext.Current.User.CustomerID, 0);
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
                nickids = NickId.ToString();
            }
            //省
            string ProvinceID = this.ddlProvince.SelectedValue.Trim();
            //市
            string CityID = this.ddlCity.SelectedValue.Trim();
            //区县
            string CountyID = this.ddlCounty.SelectedValue.Trim();
            //仓库名
            string WarehouseName = txtWareHouse.Text.Trim();
            string projectId = ddXMProject.SelectedValue;
            string nickId = ddlNick.SelectedValue;
            var xMWareHouseList = base.XMWareHousesService.GetXMWarehouseList(ProvinceID, CityID, CountyID, WarehouseName, nickids, Convert.ToInt16(projectId), nickids2);

            //查询店铺ID为-1或99
            string pids = GetXMWarehouseListByProjectID();      //项目ID集合
            //未选择店铺记录查询
            if (NickId == -1 || NickId == 99)
            {
                var xMWareHouseNoNickIDList2 = base.XMWareHousesService.GetXMWarehouseListByProjectID(ProvinceID, CityID, CountyID, WarehouseName, pids, xMProjectId);
                //将两个记录拼接
                if (xMWareHouseNoNickIDList2 != null && xMWareHouseNoNickIDList2.Count > 0)            //无店铺  有项目ID
                {
                    foreach (XMWareHouses Info in xMWareHouseNoNickIDList2)
                    {
                        xMWareHouseList.Add(Info);
                    }
                }
            }
            //分页
            var pageList = new PagedList<XMWareHouses>(xMWareHouseList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvWareHouses, pageList);
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvWareHouses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var Info = e.Row.DataItem as XMWareHouses;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('仓库编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageInventory/XMWarehouseAdd.aspx?Type=1&&Id=" + Info.Id + "',500, 300, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }
            }
        }

        protected void grdvWareHouses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                var Info = base.XMWareHousesService.GetXMWareHousesById(Convert.ToInt16(id));
                if (!string.IsNullOrEmpty(id))//删除
                {
                    //判断仓库在进销存系统各个模块中是否正在使用，如果已使用将无法删除！(入库单 出库单 退货单 库存管理 调整单)
                    var storages = base.XMStorageService.GetXMStorageByWareHoursesId(int.Parse(id));
                    if (storages != null && storages.Count > 0)        //入库单判断
                    {
                        base.ShowMessage("仓库[" + Info.Name + "] 在入库单中已经被使用，无法删除！");
                        return;
                    }
                    var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryListByWareHoursesID(int.Parse(id));
                    if (saleDelivery != null && saleDelivery.Count > 0)     //出库单判断
                    {
                        base.ShowMessage("仓库[" + Info.Name + "] 在出库单中已经被使用，无法删除！");
                        return;
                    }
                    var saleReturn = base.XMSaleReturnService.GetXMSaleReturnListByWareHoursesID(int.Parse(id));
                    if (saleReturn != null && saleReturn.Count > 0)     //退货单判断
                    {
                        base.ShowMessage("仓库[" + Info.Name + "] 在销售退货单中已经被使用，无法删除！");
                        return;
                    }
                    var inventeryInfo = base.XMInventoryInfoService.GetXMInventoryInfoListByWareHouesesID(int.Parse(id));
                    if (inventeryInfo != null && inventeryInfo.Count > 0)     //库存管理判断
                    {
                        base.ShowMessage("仓库[" + Info.Name + "] 在库存管理中已经被使用，无法删除！");
                        return;
                    }
                    var adjusted = base.XMAdjustedInfoService.GetXMAdjustedInfoByWareHousesID(int.Parse(id));
                    if (adjusted != null && adjusted.Count > 0)       //调增单判断
                    {
                        base.ShowMessage("仓库[" + Info.Name + "] 在调整单中已经被使用，无法删除！");
                        return;
                    }
                    if (Info != null)
                    {
                        Info.isEnable = true;
                        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        Info.UpdateDate = DateTime.Now;
                        base.XMWareHousesService.UpdateXMWareHouses(Info);
                        base.ShowMessage("操作成功！");
                    }
                    else
                    {
                        base.ShowMessage("未查到该数据！");
                    }
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                }
            }
            #endregion
        }

        public string getCreaterName(string createID)
        {
            string name = "";
            var info = base.CustomerInfoService.GetCustomerInfoByID(int.Parse(createID));
            if (info != null)
            {
                name = info.FullName;
            }
            return name;
        }
        /// <summary>
        /// 根据cityID  查询城市名称
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public string getCityNameByCityID(string cityID)
        {
            string cityName = "";
            string ProvinceId = "";
            if (cityID != "" && cityID.Length >= 6)
            {
                ProvinceId = cityID.Substring(0, 6);
            }
            var Province = base.XMWareHousesService.GetProvinceByProvinceId(ProvinceId);
            if (Province != null && (Province.City == "北京" || Province.City == "上海" || Province.City == "重庆" || Province.City == "天津"))
            {
                cityName = Province.City;
            }
            else
            {
                if (cityID != "" && cityID.Length == 9)         //城市
                {
                    var info = base.XMWareHousesService.GetCityInfoByCityId(cityID, 3);
                    if (info != null)
                    {
                        cityName = info.City;
                    }
                }
                if (cityID != "" && cityID.Length == 12)     //县区
                {
                    var info = base.XMWareHousesService.GetCityInfoByCityId(cityID, 4);
                    if (info != null)
                    {
                        cityName = info.City;
                    }
                }
            }
            return cityName;
        }


        ///// <summary>
        ///// 批量删除
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    List<int> WareHousesIDs = this.Master.GetSelectedIds(this.grdvWareHouses);
        //    if (WareHousesIDs.Count <= 0)
        //    {
        //        base.ShowMessage("你没有选择任何记录！");
        //        return;
        //    }
        //    //事务
        //    using (TransactionScope scope = new TransactionScope())
        //    {
        //        foreach (var item in WareHousesIDs)
        //        {
        //            if (!Delete(item))
        //            {
        //                base.ShowMessage("数据库不存在该数据！");
        //            }
        //        }
        //        scope.Complete();
        //    }
        //    base.ShowMessage("操作成功！");
        //    this.BindGrid(Master.PageIndex, Master.PageSize);
        //}

        ///// <summary>
        ///// 删除仓库
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <returns></returns>
        //public bool Delete(int ID)
        //{
        //    var Info = base.XMWareHousesService.GetXMWareHousesById(ID);
        //    if (Info != null)
        //    {
        //        Info.isEnable = true;
        //        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
        //        Info.UpdateDate = DateTime.Now;
        //        base.XMWareHousesService.UpdateXMWareHouses(Info);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}



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
            this.ddlCity.Items.Insert(0, new ListItem("", ""));
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

        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {
            //绑定省份下拉框
            this.ddlProvince.Items.Clear();
            var ProvinceList = base.XMWareHousesService.GetProvinceList();
            this.ddlProvince.DataSource = ProvinceList;
            this.ddlProvince.DataTextField = "City";
            this.ddlProvince.DataValueField = "NumberID";
            this.ddlProvince.DataBind();
            this.ddlProvince.Items.Insert(0, new ListItem("", ""));

            this.btnAdd.OnClientClick = "return ShowWindowDetail('新建仓库','" + CommonHelper.GetStoreLocation()
         + "ManageInventory/XMWarehouseAdd.aspx?Type=0',500, 300, this, function(){document.getElementById('"
         + this.btnSearch.ClientID + "').click();});";
        }

        #endregion
    }
}