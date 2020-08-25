using System;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using System.Collections.Generic;
using HozestERP.BusinessLogic.ManageProject;
using System.Web;
using System.IO;

namespace HozestERP.Web.ManageInventory
{
    public partial class XMJDRealTimeInventory : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                this.BindGrid(1, Master.PageSize);
            }
        }

        private void loadData()
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
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string nickids = "";
            string nickids2 = GetCustomerMappingNickIDs();
            if (nickids2 == "")
            {
                base.ShowMessage("您无权限查看!");
                return;
            }
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
            string code = txtPlatFormCode.Text.Trim();    //  商品编码 
            string productName = txtProductName.Text.Trim();    // 商品名称
            var NickId = Convert.ToInt32(this.ddlNick.SelectedValue);
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
            int wareHourseID = ddlWareHourses.SelectedValue == "" ? -1 : int.Parse(ddlWareHourses.SelectedValue);
            var list = base.XMJDRealTimeInventoryService.GetXMJDRealTimeInventoryListByParm(code, productName, nickids, wareHourseID, xMProjectId, nickids2);
            var pageList = new PagedList<HozestERP.BusinessLogic.ManageInventory.XMJDRealTimeInventory>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvJDRealTimeInventory, pageList);
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定
            string projectids = "";
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


                for (int i = 0; i < projectList.Count; i++)
                {
                    projectids = projectids + projectList[i].Id + ",";
                }
                if (projectids.Length > 0)
                {
                    projectids = projectids.Substring(0, projectids.Length - 1);
                }
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
                    for (int i = 0; i < projectList.ToList().Count; i++)
                    {
                        projectids = projectids + projectList.ToList()[i].Id + ",";
                    }
                    if (projectids.Length > 0)
                    {
                        projectids = projectids.Substring(0, projectids.Length - 1);
                    }
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                }
            }
            var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(projectids);
            ddlWareHourses.DataSource = wareHouses;
            ddlWareHourses.DataTextField = "Name";
            ddlWareHourses.DataValueField = "Id";
            ddlWareHourses.DataBind();
            this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
            this.ddlWareHourses.Items[0].Selected = true;
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
                if (this.ddXMProject.SelectedValue.ToString().Trim() != "")
                {
                    var projectID = int.Parse(this.ddXMProject.SelectedValue.ToString().Trim());
                    if (projectID != -1)
                    {
                        if (this.ddlNick.SelectedValue != "")
                        {
                            var NickId = int.Parse(this.ddlNick.SelectedValue);
                            if (NickId == -1 || NickId == 99)
                            {
                                //根据项目绑定仓库
                                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectId(projectID);
                                this.ddlWareHourses.Items.Clear();
                                this.ddlWareHourses.DataSource = wareHouses;
                                this.ddlWareHourses.DataTextField = "Name";
                                this.ddlWareHourses.DataValueField = "Id";
                                this.ddlWareHourses.DataBind();
                            }
                        }
                    }
                    else
                    {
                        BindddXMProject();
                    }
                }
            }
        }

        /// <summary>
        /// 根据仓库ID 查询所在城市
        /// </summary>
        /// <param name="wfID"></param>
        /// <returns></returns>
        public string getCityName(string wfID)
        {
            string cityName = "";
            var wareHourses = base.XMWareHousesService.GetXMWareHousesById(int.Parse(wfID));
            if (wareHourses != null && wareHourses.CityId != null && wareHourses.CityId != "")
            {
                cityName = getCityNameByCityID(wareHourses.CityId);
            }
            return cityName;
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
            if (cityID != "" && cityID.Length > 0)
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
                if (cityID != "" && cityID.Length == 12)      //县区
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


        protected void ddlNick_Change(object sender, EventArgs e)
        {
            int projectId = int.Parse(ddXMProject.SelectedValue);
            int nickId = int.Parse(ddlNick.SelectedValue);
            if (projectId == -1 || projectId == 99)    //绑定所有仓库
            {
                if (nickId == -1 || nickId == 99)
                {
                    string projectids = "";
                    //项目名称绑定--选取自运营项目
                    if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                    {
                        var projectList = base.XMProjectService.GetXMProjectList();
                        for (int i = 0; i < projectList.Count; i++)
                        {
                            projectids = projectids + projectList[i].Id + ",";
                        }
                        if (projectids.Length > 0)
                        {
                            projectids = projectids.Substring(0, projectids.Length - 1);
                        }
                    }
                    else
                    {
                        var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                            .GroupBy(p => new { p.Id, p.ProjectName })
                            .Select(p => new
                            {
                                Id = p.Key.Id,
                                ProjectName = p.Key.ProjectName
                            });
                        for (int i = 0; i < projectList.ToList().Count; i++)
                        {
                            projectids = projectids + projectList.ToList()[i].Id + ",";
                        }
                        if (projectids.Length > 0)
                        {
                            projectids = projectids.Substring(0, projectids.Length - 1);
                        }
                    }
                    var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(projectids);
                    ddlWareHourses.DataSource = wareHouses;
                    ddlWareHourses.DataTextField = "Name";
                    ddlWareHourses.DataValueField = "Id";
                    ddlWareHourses.DataBind();
                    this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
                    this.ddlWareHourses.Items[0].Selected = true;
                }
                else
                {
                    //根据店铺ID 查询仓库绑定
                    var wareHouses = base.XMWareHousesService.GetXMWarehouseListByNickID(nickId);
                    ddlWareHourses.DataSource = wareHouses;
                    ddlWareHourses.DataTextField = "Name";
                    ddlWareHourses.DataValueField = "Id";
                    ddlWareHourses.DataBind();
                    this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
                    this.ddlWareHourses.Items[0].Selected = true;
                }
            }
            else
            {
                if (nickId == -1 || nickId == 99)
                {
                    //根据projectId 查询仓库并绑定
                    var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectId(projectId);
                    ddlWareHourses.DataSource = wareHouses;
                    ddlWareHourses.DataTextField = "Name";
                    ddlWareHourses.DataValueField = "Id";
                    ddlWareHourses.DataBind();
                    this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
                    this.ddlWareHourses.Items[0].Selected = true;
                }
                else
                {
                    //根据店铺ID 查询仓库绑定
                    var wareHouses = base.XMWareHousesService.GetXMWarehouseListByNickID(nickId);
                    ddlWareHourses.DataSource = wareHouses;
                    ddlWareHourses.DataTextField = "Name";
                    ddlWareHourses.DataValueField = "Id";
                    ddlWareHourses.DataBind();
                    this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
                    this.ddlWareHourses.Items[0].Selected = true;
                }
            }
        }


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
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }


        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        #endregion
    }
}