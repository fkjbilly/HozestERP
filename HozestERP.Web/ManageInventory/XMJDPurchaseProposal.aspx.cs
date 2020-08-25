using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;
using System.IO;

namespace HozestERP.Web.ManageInventory
{
    public partial class XMJDPurchaseProposal : BaseAdministrationPage, ISearchPage
    {
        public string TableStr = "";
        public List<PuchaseStrategyInfo> List1 = new List<PuchaseStrategyInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                this.BindGrid(1, Master.PageSize);

                //京东自营实时库存数据导入
                this.btnJDRealTimeInventoryExport.OnClientClick = "return ShowWindowDetail('京东自营实时库存导入','" + CommonHelper.GetStoreLocation() +
            "ManageInventory/ImportJDRealTimeInventory.aspx',500,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            }
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            //部门
            //CommonMethod.DropDownListDepartment(this.ddlDepartment, true);
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

        public void BindGrid2(int paramPageIndex, int paramPageSize)
        {
            int no = 1;
            int change = 0;
            StringBuilder str = new StringBuilder();
            string nickids = "";
            string nickids2 = GetCustomerMappingNickIDs();
            if (nickids2 == "")
            {
                base.ShowMessage("您无权限查看!");
                return;
            }
            var jdSaleCoeffcients = base.XMJDZYSaleCoefficientsService.GetXMJDZYSaleCoefficientsByParm("29", DateTime.Now.Month);
            if (jdSaleCoeffcients != null && jdSaleCoeffcients.Count == 0)
            {
                base.ShowMessage("店铺销售系数未设置，请先设置系数!");
                return;
            }
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
            string code = txtPlatFormCode.Text.Trim();    //  厂家编码 
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
            string paramwareHourseIDs = "";
            string paramwareHourseIDSelect = this.ddlWareHourses.SelectedValue;
            if (paramwareHourseIDSelect == "-1")
            {
                for (int i = 0; i < this.ddlWareHourses.Items.Count; i++)
                {
                    if (this.ddlWareHourses.Items[i].Value != "-1")
                        paramwareHourseIDs = paramwareHourseIDs + this.ddlWareHourses.Items[i].Value + ",";
                }
                paramwareHourseIDs = paramwareHourseIDs.Substring(0, paramwareHourseIDs.Length - 1) + ",-1";
            }
            else
            {
                paramwareHourseIDs = paramwareHourseIDSelect;
            }

            var list = base.XMInventoryInfoService.GetXMInventoryInfoByPorjectID(code, productName, paramwareHourseIDs, xMProjectId.ToString(), xMProjectId, -1);
            var pageList = new PagedList<XMInventoryInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            for (int j = 0; j < pageList.Count; j++)
            {
                if (no == 1)
                {
                    str.Append("<table   style='width:100%;border-style:solid' rules='all'>");
                    str.Append("<tr  style='height:30px;background-color:#EEEEEE'>");
                    str.Append("<th  nowrap='noWrap' align='center' style='width:10px;white-space:nowrap;cursor:pointer;' scope='col'>序号</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>厂家编码</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:180px;white-space:nowrap;cursor:pointer;' scope='col'>商品名称</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>规格</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>品牌</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:120px;white-space:nowrap;cursor:pointer;' scope='col'>仓库</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>机构名称</th>");
                    str.Append("</tr>");
                }
                string color = "#FFFFFF";
                if (no % 2 == 0)
                {
                    color = "#F7F7F7";
                }
                str.Append("<tr class='GridRow' align='center' style='background-color:" + color + ";height:33px;' oldcolor='" + color + "'>");
                str.Append("<td style='width:10px;' align='center'>" + no + "</td>");
                str.Append("<td style='width:100px;'>" + pageList[j].PlatformMerchantCode + "</td>");
                string pName = "";
                if (pageList[j].ProductName.Length > 8)
                {
                    pName = pageList[j].ProductName.Substring(0, 8);
                }
                else
                {
                    pName = pageList[j].ProductName;
                }
                str.Append("<td style='width:180px;'>" + pName + "</td>");
                str.Append("<td style='width:100px;'>" + pageList[j].Specifications + "</td>");
                str.Append("<td style='width:100px;'>" + pageList[j].BrandTypeCodeName + "</td>");
                str.Append("<td style='width:120px;'>" + pageList[j].WfName + "</td>");
                str.Append("<td style='width:100px;'>" + getCityName(pageList[j].WfId.ToString()) + "</td>");
                str.Append("</tr>");
                no++;
            }
            if (pageList.Count > 0)
            {
                change = 1;
                str.Append("<tr class='GridRow' style='background-color:#F7F7F7'><td style='height:30px;' colspan='9'></td></tr><tr class='GridRow' style='background-color:#F7F7F7'><td style='height:10px;' colspan='9'></td></tr></table>");
            }
            TableStr = str.ToString();
            ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "BindGrid", "ChangeOverflow('" + change + "')", true);//ajax

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetXMInventoryByProjectID()
        {
            string projectIds = "";
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
            int no = 1;
            int change = 0;
            StringBuilder str = new StringBuilder();
            string nickids = "";
            string nickids2 = GetCustomerMappingNickIDs();
            if (nickids2 == "")
            {
                base.ShowMessage("您无权限查看!");
                return;
            }
            var jdSaleCoeffcients = base.XMJDZYSaleCoefficientsService.GetXMJDZYSaleCoefficientsByParm("29", DateTime.Now.Month);
            if (jdSaleCoeffcients != null && jdSaleCoeffcients.Count == 0)
            {
                base.ShowMessage("店铺销售系数未设置，请先设置系数!");
                return;
            }
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
            string code = txtPlatFormCode.Text.Trim();    //  厂家编码 
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
            string paramwareHourseIDs = "";
            string paramwareHourseIDSelect = this.ddlWareHourses.SelectedValue;
            if (paramwareHourseIDSelect == "-1")
            {
                for (int i = 0; i < this.ddlWareHourses.Items.Count; i++)
                {
                    if (this.ddlWareHourses.Items[i].Value != "-1")
                        paramwareHourseIDs = paramwareHourseIDs + this.ddlWareHourses.Items[i].Value + ",";
                }
                paramwareHourseIDs = paramwareHourseIDs.Substring(0, paramwareHourseIDs.Length - 1) + ",-1";
            }
            else
            {
                paramwareHourseIDs = paramwareHourseIDSelect;
            }

            var list = base.XMInventoryInfoService.GetXMInventoryInfoByPorjectID(code, productName, paramwareHourseIDs, xMProjectId.ToString(), xMProjectId, -1);
            var pageList = new PagedList<XMInventoryInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, pageList);

            for (int j = 0; j < pageList.Count; j++)
            {
                if (no == 1)
                {
                    str.Append("<table   style='width:100%;border-style:solid' rules='all'>");
                    str.Append("<tr  style='height:30px;background-color:#EEEEEE'>");
                    str.Append("<th  nowrap='noWrap' align='center' style='width:10px;white-space:nowrap;cursor:pointer;' scope='col'>序号</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>厂家编码</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:180px;white-space:nowrap;cursor:pointer;' scope='col'>商品名称</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>规格</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>品牌</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:120px;white-space:nowrap;cursor:pointer;' scope='col'>仓库</th>");
                    str.Append("<th nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>机构名称</th>");
                    str.Append("</tr>");
                }
                string color = "#FFFFFF";
                if (no % 2 == 0)
                {
                    color = "#F7F7F7";
                }
                str.Append("<tr class='GridRow' align='center' style='background-color:" + color + ";height:33px;' oldcolor='" + color + "'>");
                str.Append("<td style='width:10px;' align='center'>" + no + "</td>");
                str.Append("<td style='width:100px;'>" + pageList[j].PlatformMerchantCode + "</td>");
                string pName = "";
                if (pageList[j].ProductName.Length > 8)
                {
                    pName = pageList[j].ProductName.Substring(0, 8);
                }
                else
                {
                    pName = pageList[j].ProductName;
                }
                str.Append("<td style='width:180px;'>" + pName + "</td>");
                str.Append("<td style='width:100px;'>" + pageList[j].Specifications + "</td>");
                str.Append("<td style='width:100px;'>" + pageList[j].BrandTypeCodeName + "</td>");
                str.Append("<td style='width:120px;'>" + pageList[j].WfName + "</td>");
                str.Append("<td style='width:100px;'>" + getCityName(pageList[j].WfId.ToString()) + "</td>");
                str.Append("</tr>");
                no++;
            }
            if (pageList.Count > 0)
            {
                change = 1;
                str.Append("<tr class='GridRow' style='background-color:#F7F7F7'><td style='height:30px;' colspan='9'></td></tr><tr class='GridRow' style='background-color:#F7F7F7'><td style='height:10px;' colspan='9'></td></tr></table>");
            }
            TableStr = str.ToString();
            ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "BindGrid", "ChangeOverflow('" + change + "')", true);//ajax
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
                    this.BindGrid(1, Master.PageSize);
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
                    this.BindGrid(1, Master.PageSize);
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
                                this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
                            }
                        }
                        this.BindGrid(1, Master.PageSize);
                    }
                    else
                    {
                        BindddXMProject();

                    }
                }
            }
        }


        protected void ddlNick_Change(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
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
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                var info = e.Row.DataItem as XMInventoryInfo;
                Literal lblLastFourWeekSaleCount = e.Row.FindControl("lblLastFourWeekSaleCount") as Literal;
                Literal lblLastEnghtWeekSaleCount = e.Row.FindControl("lblLastEnghtWeekSaleCount") as Literal;
                Literal lblYCCount = e.Row.FindControl("lblYCCount") as Literal;
                Literal lblSuggestCount = e.Row.FindControl("lblSuggestCount") as Literal;
                Literal lblCike = e.Row.FindControl("lblCike") as Literal;
                decimal saleJDZYSaleCoefficients = 0;    //京东自营月份销售系数
                var JDZYSaleCoefficients = base.XMJDZYSaleCoefficientsService.GetXMJDZYSaleCoefficientsByParm("29", DateTime.Now.Month);    //京东自营
                if (JDZYSaleCoefficients != null && JDZYSaleCoefficients.Count > 0)
                {
                    saleJDZYSaleCoefficients = JDZYSaleCoefficients[0].Value;
                }
                int[] fontSaleCount = new int[8];     // 前几周的销量
                int s1 = 0;
                int s2 = 0;                                      //历史四周销量和  历史八周销量和
                DateTime startDate, endDate;
                //前第8周销量
                startDate = DateTime.Now.AddDays(-7);
                endDate = DateTime.Now;
                fontSaleCount[7] = GetSaleCountByParm(DateTime.Now.AddDays(-7), DateTime.Now, info.WfId, info.PlatformMerchantCode);    //前第八周销量
                //循环计算前七周销量
                for (int i = 6; i >= 0; i--)
                {
                    endDate = startDate;
                    startDate = startDate.AddDays(-7);
                    fontSaleCount[i] = GetSaleCountByParm(startDate, endDate, info.WfId, info.PlatformMerchantCode);
                }
                //计算历史四周销量和
                for (int j = 0; j < 4; j++)
                {
                    s1 += fontSaleCount[j];
                }
                //计算历史八周销量和
                for (int t = 0; t < 8; t++)
                {
                    s2 += fontSaleCount[t];
                }

                for (int t = 0; t < 8; t++)
                {
                    Literal l = e.Row.FindControl("lblSaleCount_" + t) as Literal;
                    l.Text = fontSaleCount[t].ToString();
                }
                lblLastFourWeekSaleCount.Text = s1.ToString();           //历史四周销量和
                lblLastEnghtWeekSaleCount.Text = s2.ToString();         //历史八周销量和


                if (Session["PuchaseStrategyInfo"] == null)             //未更改过相关数据
                {
                    /*计算采购总数    公式 ： (历史四周销量和/28+ 历史八周销量和/56)/2* 天数*每月设定的系数          */
                    var saleDay = base.SettingManager.GetSettingByName("JDZYPuchaseProposalOfDays");            // 销量天数
                    int day = 0;
                    if (saleDay != null)
                    {
                        day = int.Parse(saleDay.Value.Trim());
                    }
                    decimal c = Math.Round((decimal)s1 / (decimal)28, 2);
                    decimal d = Math.Round((decimal)s2 / (decimal)56, 2);
                    decimal saleCount = ((c + d) / 2) * day * saleJDZYSaleCoefficients;           //预算出来的总数
                    lblYCCount.Text = Convert.ToInt16(saleCount).ToString();
                    lblSuggestCount.Text = (Convert.ToInt16(saleCount) - info.StockNumber).ToString();
                    lblCike.Text = "";
                }
                else
                {
                    bool isExsit = false;
                    var List = Session["PuchaseStrategyInfo"] as List<PuchaseStrategyInfo>;
                    foreach (PuchaseStrategyInfo i in List)
                    {
                        if (info.Id == i.Id)
                        {
                            isExsit = true;
                            lblYCCount.Text = i.ForecastNumber.ToString();
                            lblSuggestCount.Text = (i.ForecastNumber - info.StockNumber).ToString();
                        }
                    }
                    if (!isExsit)
                    {
                        /*计算采购总数    公式 ： (历史四周销量和/28+ 历史八周销量和/56)/2* 天数*每月设定的系数          */
                        var saleDay = base.SettingManager.GetSettingByName("JDZYPuchaseProposalOfDays");            // 销量天数
                        int day = 0;
                        if (saleDay != null)
                        {
                            day = int.Parse(saleDay.Value.Trim());
                        }
                        decimal c = Math.Round((decimal)s1 / (decimal)28, 2);
                        decimal d = Math.Round((decimal)s2 / (decimal)56, 2);
                        decimal saleCount = ((c + d) / 2) * day * saleJDZYSaleCoefficients;           //预算出来的总数
                        lblYCCount.Text = Convert.ToInt16(saleCount).ToString();
                        lblSuggestCount.Text = (Convert.ToInt16(saleCount) - info.StockNumber).ToString();
                        lblCike.Text = "";
                    }
                }
            }
            if (e.Row.RowState == DataControlRowState.Edit ||
            e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {



            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnUpdate = e.Row.FindControl("imgBtnUpdate") as ImageButton;
                ImageButton imgBtnCancel = e.Row.FindControl("imgBtnCancel") as ImageButton;

                //隐藏编辑按钮
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.Visible = true;
                }
                //显示保存按钮
                if (imgBtnUpdate != null)
                {
                    imgBtnUpdate.Visible = false;
                }
                //显示取消按钮
                if (imgBtnCancel != null)
                {
                    imgBtnCancel.Visible = false;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgBtnEdit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow item in grdvClients.Rows)
            {
                if (item.RowIndex != grdvClients.EditIndex)
                {
                    int id = 0;
                    int stocknum = 0;
                    int wareHourseID = 1;
                    string PlatformMerchantCode = "";
                    HiddenField hiddID = item.FindControl("hiddID") as HiddenField;
                    Literal stockNumber = item.FindControl("lblStockNumber") as Literal;
                    Literal lblSuggestCount = item.FindControl("lblSuggestCount") as Literal;
                    HiddenField hiddWareHouresID = item.FindControl("hiddWareHouresID") as HiddenField;
                    HiddenField hiddPlatformMerchantCode = item.FindControl("hiddPlatformMerchantCode") as HiddenField;
                    Literal lblYCCount = item.FindControl("lblYCCount") as Literal;
                    TextBox txtYCCount = item.FindControl("txtYCCount") as TextBox;
                    if (lblYCCount != null && txtYCCount != null)
                    {
                        lblYCCount.Visible = false;
                        txtYCCount.Visible = true;


                        if (hiddID != null)
                        {
                            id = int.Parse(hiddID.Value);
                        }
                        if (stockNumber != null)
                        {
                            stocknum = int.Parse(stockNumber.Text);
                        }
                        if (hiddWareHouresID != null)
                        {
                            wareHourseID = Convert.ToInt16(hiddWareHouresID.Value);
                        }
                        if (hiddPlatformMerchantCode != null)
                        {
                            PlatformMerchantCode = hiddPlatformMerchantCode.Value;
                        }
                        bool isexsit = false;
                        if (Session["PuchaseStrategyInfo"] != null)
                        {
                            var List = Session["PuchaseStrategyInfo"] as List<PuchaseStrategyInfo>;
                            foreach (PuchaseStrategyInfo i in List)
                            {
                                if (id == i.Id)
                                {
                                    isexsit = true;
                                    txtYCCount.Text = i.ForecastNumber.ToString();
                                    if (lblSuggestCount != null)
                                    {
                                        lblSuggestCount.Text = (i.ForecastNumber - stocknum).ToString();
                                    }
                                }
                            }
                        }
                        if (!isexsit)
                        {
                            decimal saleJDZYSaleCoefficients = 0;    //京东自营月份销售系数
                            var JDZYSaleCoefficients = base.XMJDZYSaleCoefficientsService.GetXMJDZYSaleCoefficientsByParm("29", DateTime.Now.Month);    //京东自营
                            if (JDZYSaleCoefficients != null && JDZYSaleCoefficients.Count > 0)
                            {
                                saleJDZYSaleCoefficients = JDZYSaleCoefficients[0].Value;
                            }
                            int[] fontSaleCount = new int[8];     // 前几周的销量
                            int s1 = 0;
                            int s2 = 0;                                      //历史四周销量和  历史八周销量和
                            DateTime startDate, endDate;
                            //前第8周销量
                            startDate = DateTime.Now.AddDays(-7);
                            endDate = DateTime.Now;
                            fontSaleCount[7] = GetSaleCountByParm(DateTime.Now.AddDays(-7), DateTime.Now, wareHourseID, PlatformMerchantCode);    //前第八周销量
                            //循环计算前七周销量
                            for (int i = 6; i >= 0; i--)
                            {
                                endDate = startDate;
                                startDate = startDate.AddDays(-7);
                                fontSaleCount[i] = GetSaleCountByParm(startDate, endDate, wareHourseID, PlatformMerchantCode);
                            }
                            //计算历史四周销量和
                            for (int j = 0; j < 4; j++)
                            {
                                s1 += fontSaleCount[j];
                            }
                            //计算历史八周销量和
                            for (int t = 0; t < 8; t++)
                            {
                                s2 += fontSaleCount[t];
                            }
                            /*计算采购总数    公式 ： (历史四周销量和/28+ 历史八周销量和/56)/2* 天数*每月设定的系数          */
                            var saleDay = base.SettingManager.GetSettingByName("JDZYPuchaseProposalOfDays");            // 销量天数
                            int day = 0;
                            if (saleDay != null)
                            {
                                day = int.Parse(saleDay.Value.Trim());
                            }
                            decimal c = Math.Round((decimal)s1 / (decimal)28, 2);
                            decimal d = Math.Round((decimal)s2 / (decimal)56, 2);
                            decimal saleCount = ((c + d) / 2) * day * saleJDZYSaleCoefficients;           //预算出来的总数
                            txtYCCount.Text = Convert.ToInt16(saleCount).ToString();
                            lblSuggestCount.Text = (Convert.ToInt16(saleCount) - stocknum).ToString();
                        }

                    }
                }
            }
            if (this.grdvClients.FooterRow.RowType == DataControlRowType.Footer)
            {
                ImageButton imgBtnEdit = this.grdvClients.FooterRow.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnUpdate = this.grdvClients.FooterRow.FindControl("imgBtnUpdate") as ImageButton;
                ImageButton imgBtnCancel = this.grdvClients.FooterRow.FindControl("imgBtnCancel") as ImageButton;
                //隐藏编辑按钮
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.Visible = false;
                }
                //显示保存按钮
                if (imgBtnUpdate != null)
                {
                    imgBtnUpdate.Visible = true;
                }
                //显示取消按钮
                if (imgBtnCancel != null)
                {
                    imgBtnCancel.Visible = true;
                }
            }
            BindGrid2(this.Master.PageIndex, this.Master.PageSize);
        }
        /// <summary>
        /// 保存 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgBtnUpdate_Click(object sender, EventArgs e)
        {
            #region 字符验证
            int errorcount = 0;
            //循环所有行
            foreach (GridViewRow msgReach in grdvClients.Rows)
            {
                if (msgReach.RowIndex != grdvClients.EditIndex)
                {
                    int a = 0;
                    TextBox txtYCCount = msgReach.FindControl("txtYCCount") as TextBox;
                    Literal lblYCCount = msgReach.FindControl("lblYCCount") as Literal;
                    Label lblMsgYCCount = msgReach.FindControl("lblMsgYCCount") as Label;

                    if (string.IsNullOrEmpty(txtYCCount.Text.Trim()))
                    {
                        lblMsgYCCount.Text = "请输入预测总数。";
                        errorcount++;
                    }
                    if (!int.TryParse(txtYCCount.Text.Trim(), out a))
                    {
                        lblMsgYCCount.Text = "l输入数据类型不正确！";
                        errorcount++;
                    }

                }
            }
            if (errorcount > 0)
            {
                return;
            }
            bool isEdit = false;
            List<PuchaseStrategyInfo> Proposal = new List<PuchaseStrategyInfo>();
            foreach (GridViewRow item in grdvClients.Rows)
            {
                if (item.RowIndex != grdvClients.EditIndex)
                {
                    TextBox txtYCCount = item.FindControl("txtYCCount") as TextBox;
                    Literal lblYCCount = item.FindControl("lblYCCount") as Literal;
                    Literal lblStockNumber = item.FindControl("lblStockNumber") as Literal;
                    Literal lblSuggestCount = item.FindControl("lblSuggestCount") as Literal;
                    HiddenField hiddID = item.FindControl("hiddID") as HiddenField;
                    lblYCCount.Text = txtYCCount.Text.Trim();
                    if (!string.IsNullOrEmpty(lblYCCount.Text.Trim()))
                    {
                        lblSuggestCount.Text = (int.Parse(lblYCCount.Text.Trim()) - int.Parse(lblStockNumber.Text.Trim())).ToString();
                    }
                    if (Session["PuchaseStrategyInfo"] != null)
                    {
                        Proposal = Session["PuchaseStrategyInfo"] as List<PuchaseStrategyInfo>;
                        if (hiddID != null)
                        {
                            int id = int.Parse(hiddID.Value);
                            PuchaseStrategyInfo info = new PuchaseStrategyInfo();
                            info.Id = id;
                            info.ForecastNumber = int.Parse(txtYCCount.Text.Trim());
                            Proposal = RemoveOther(id, Proposal);
                            Proposal.Add(info);
                        }
                    }
                    else
                    {
                        int id = int.Parse(hiddID.Value);
                        PuchaseStrategyInfo info = new PuchaseStrategyInfo();
                        info.Id = id;
                        info.ForecastNumber = int.Parse(txtYCCount.Text.Trim());
                        Proposal.Add(info);
                    }

                    isEdit = true;
                }
            }

            Session["PuchaseStrategyInfo"] = Proposal;
            #endregion
            if (isEdit)
                base.ShowMessage("保存成功!");
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        //取消按钮
        protected void imgBtnCancel_Click(object sender, EventArgs e)
        {
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }
        /// <summary>
        /// 
        /// </summary>
        private List<PuchaseStrategyInfo> RemoveOther(int id, List<PuchaseStrategyInfo> Info)
        {
            List<PuchaseStrategyInfo> parm = new List<PuchaseStrategyInfo>();
            parm = Info;
            int index = 0;
            bool isExsit = false;
            for (int i = 0; i < Info.Count; i++)
            {
                if (id == Info[i].Id)
                {
                    isExsit = true;
                    index = i;
                }
            }
            if (isExsit)
            {
                parm.RemoveAt(index);
            }
            return parm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="wfID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <returns></returns>
        private int GetSaleCountByParm(DateTime startDate, DateTime endDate, int wfID, string platformMerchantCode)
        {
            int total = 0;
            var saleDeliveryProductDetail = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsByParm(startDate, endDate, wfID, platformMerchantCode);
            if (saleDeliveryProductDetail != null && saleDeliveryProductDetail.Count > 0)
            {
                total = saleDeliveryProductDetail.Sum(p => p.SaleCount).Value;
            }
            return total;
        }


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
        /// 判断是否是京东自营产品
        /// </summary>
        /// <param name="wfId"></param>
        /// <returns></returns>
        private bool isJDZYProduct(int wfId)
        {
            bool isExsit = false;
            var wareHourses = base.XMWareHousesService.GetXMWareHousesById(wfId);
            if (wareHourses != null && wareHourses.NickId == 29)
            {
                isExsit = true;
            }
            return isExsit;
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEstablishPurchase_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    List<PuchaseStrategyInfo> List = new List<PuchaseStrategyInfo>();
                    List<string> WareHouseNameList = new List<string>();
                    List<string> PlatformMerchantCodeList = new List<string>();    //厂家编码
                    string nickids = "";
                    string nickids2 = GetCustomerMappingNickIDs();
                    if (nickids2 == "")
                    {
                        base.ShowMessage("您无权限查看!");
                        return;
                    }
                    var jdSaleCoeffcients = base.XMJDZYSaleCoefficientsService.GetXMJDZYSaleCoefficientsByParm("29", DateTime.Now.Month);
                    if (jdSaleCoeffcients != null && jdSaleCoeffcients.Count == 0)
                    {
                        base.ShowMessage("店铺销售系数未设置，请先设置系数!");
                        return;
                    }
                    var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
                    string code = txtPlatFormCode.Text.Trim();    //  厂家编码 
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
                    var list = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, productName, nickids, wareHourseID.ToString(), xMProjectId, nickids2, -1, false);
                    if (list != null && list.Count > 0)
                    {
                        foreach (XMInventoryInfo info in list)
                        {
                            string cityName = getCityName(info.WfId.ToString());
                            if (!WareHouseNameList.Contains(info.WfName))
                            {
                                WareHouseNameList.Add(info.WfName);
                            }
                            if (!PlatformMerchantCodeList.Contains(info.PlatformMerchantCode) && isJDZYProduct(info.WfId))
                            {
                                PlatformMerchantCodeList.Add(info.PlatformMerchantCode);
                            }
                            if (Session["PuchaseStrategyInfo"] == null)     //建议采购量未修改过
                            {
                                //计算与采购值值
                                PuchaseStrategyInfo parm = new PuchaseStrategyInfo();
                                parm.Id = info.Id;
                                parm.PlatformMerchantCode = info.PlatformMerchantCode;
                                parm.PrductName = info.ProductName;
                                parm.WfId = info.WfId;
                                parm.WfName = info.WfName;
                                parm.OrganizationName = cityName;
                                parm.ForecastNumber = GetPuchaseNumber(info.WfId, info.PlatformMerchantCode);
                                parm.StockNumber = info.StockNumber;
                                parm.RealityNumber = parm.ForecastNumber - parm.StockNumber;
                                List.Add(parm);
                            }
                            else
                            {
                                bool isExsit = false;
                                int count = 0;
                                var PuchaseStrategyInfo = Session["PuchaseStrategyInfo"] as List<PuchaseStrategyInfo>;
                                if (PuchaseStrategyInfo != null && PuchaseStrategyInfo.Count > 0)
                                {
                                    foreach (PuchaseStrategyInfo a in PuchaseStrategyInfo)
                                    {
                                        if (a.Id == info.Id)
                                        {
                                            isExsit = true;
                                            count = a.ForecastNumber.Value;
                                        }
                                    }
                                }
                                if (!isExsit)       //session中不存在这个id
                                {
                                    //计算与采购值值
                                    PuchaseStrategyInfo parm = new PuchaseStrategyInfo();
                                    parm.Id = info.Id;
                                    parm.PlatformMerchantCode = info.PlatformMerchantCode;
                                    parm.PrductName = info.ProductName;
                                    parm.WfId = info.WfId;
                                    parm.WfName = info.WfName;
                                    parm.OrganizationName = cityName;
                                    parm.ForecastNumber = GetPuchaseNumber(info.WfId, info.PlatformMerchantCode);
                                    parm.StockNumber = info.StockNumber;
                                    parm.RealityNumber = parm.ForecastNumber - parm.StockNumber;
                                    List.Add(parm);
                                }
                                else
                                {
                                    //计算与采购值值
                                    PuchaseStrategyInfo parm = new PuchaseStrategyInfo();
                                    parm.Id = info.Id;
                                    parm.PlatformMerchantCode = info.PlatformMerchantCode;
                                    parm.PrductName = info.ProductName;
                                    parm.WfId = info.WfId;
                                    parm.WfName = info.WfName;
                                    parm.OrganizationName = cityName;
                                    parm.ForecastNumber = count;
                                    parm.StockNumber = info.StockNumber;
                                    parm.RealityNumber = parm.ForecastNumber - parm.StockNumber;
                                    List.Add(parm);
                                }
                            }
                        }
                    }
                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\JDPuchaseProposalExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    base.ExportManager.ExportJDPurchaseProposalToXls(filePath, List, WareHouseNameList, PlatformMerchantCodeList);
                    CommonHelper.WriteResponseXls(filePath, fileName);

                    BindGrid(this.Master.PageIndex, this.Master.PageSize);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        /// <summary>
        /// 计算与采购数值
        /// </summary>
        /// <returns></returns>
        private int GetPuchaseNumber(int wfID, string PlatformMerchantCode)
        {
            decimal saleCount = 0;
            decimal saleJDZYSaleCoefficients = 0;    //京东自营月份销售系数
            var JDZYSaleCoefficients = base.XMJDZYSaleCoefficientsService.GetXMJDZYSaleCoefficientsByParm("29", DateTime.Now.Month);    //京东自营
            if (JDZYSaleCoefficients != null && JDZYSaleCoefficients.Count > 0)
            {
                saleJDZYSaleCoefficients = JDZYSaleCoefficients[0].Value;
            }
            int[] fontSaleCount = new int[8];     // 前几周的销量
            int s1 = 0;
            int s2 = 0;                                      //历史四周销量和  历史八周销量和
            DateTime startDate, endDate;
            //前第8周销量
            startDate = DateTime.Now.AddDays(-7);
            endDate = DateTime.Now;
            fontSaleCount[7] = GetSaleCountByParm(DateTime.Now.AddDays(-7), DateTime.Now, wfID, PlatformMerchantCode);    //前第八周销量
            //循环计算前七周销量
            for (int i = 6; i >= 0; i--)
            {
                endDate = startDate;
                startDate = startDate.AddDays(-7);
                fontSaleCount[i] = GetSaleCountByParm(startDate, endDate, wfID, PlatformMerchantCode);
            }
            //计算历史四周销量和
            for (int j = 0; j < 4; j++)
            {
                s1 += fontSaleCount[j];
            }
            //计算历史八周销量和
            for (int t = 0; t < 8; t++)
            {
                s2 += fontSaleCount[t];
            }
            /*计算采购总数    公式 ： (历史四周销量和/28+ 历史八周销量和/56)/2* 天数*每月设定的系数          */
            var saleDay = base.SettingManager.GetSettingByName("JDZYPuchaseProposalOfDays");            // 销量天数
            int day = 0;
            if (saleDay != null)
            {
                day = int.Parse(saleDay.Value.Trim());
            }
            decimal c = Math.Round((decimal)s1 / (decimal)28, 2);
            decimal d = Math.Round((decimal)s2 / (decimal)56, 2);
            saleCount = ((c + d) / 2) * day * saleJDZYSaleCoefficients;           //预算出来的总数
            return Decimal.ToInt16(saleCount);
        }


    }
}