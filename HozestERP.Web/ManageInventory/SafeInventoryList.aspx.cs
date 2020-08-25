using System;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using System.Collections.Generic;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageInventory
{
    public partial class SafeInventoryList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                this.BindGrid(1, Master.PageSize);
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
        private string GetXMSafeInventoryByProjectID()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string nickids = GetCustomerMappingNickIDs();
            string nicks = "";
            if (nickids == "")
            {
                base.ShowMessage("您无权限查看安全库存明细!");
                return;
            }
            string code = txtPlatFormCode.Text.Trim();    //  商品编码 
            string productName = txtProductName.Text.Trim();    // 商品名称
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
            var NickId = Convert.ToInt32(this.ddlNick.SelectedValue);
            if (NickId == 99) //某个项目店铺权限，选择有权限的店铺
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), xMProjectId, HozestERPContext.Current.User.CustomerID, 0);
                for (int i = 0; i < nickList.Count; i++)
                {
                    nicks = nicks + nickList[i].nick_id + ",";
                }
                if (nicks.Length > 0)
                {
                    nicks = nicks.Substring(0, nicks.Length - 1);
                }
            }
            else
            {
                nicks = NickId.ToString();
            }

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
            var list = base.XMInventoryInfoService.GetXMInventoryInfoByLessWarningNumber(code, productName, nicks, paramwareHourseIDs, xMProjectId, nickids);
            var pageList = new PagedList<XMInventoryInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvInventory, pageList);
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
                    projectids = projectids.Substring(0, projectids.Length - 1) + ",-1";
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
                        projectids = projectids.Substring(0, projectids.Length - 1) + ",-1";
                    }
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                    this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "99"));
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
                                var projectIDs = "";
                                if (projectID == 99)
                                {
                                    projectIDs = GetXMSafeInventoryByProjectID();
                                }
                                else
                                {
                                    projectIDs = projectID.ToString();
                                }
                                //根据项目绑定仓库
                                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(projectIDs);
                                this.ddlWareHourses.Items.Clear();
                                this.ddlWareHourses.DataSource = wareHouses;
                                this.ddlWareHourses.DataTextField = "Name";
                                this.ddlWareHourses.DataValueField = "Id";
                                this.ddlWareHourses.DataBind();
                                this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
                                this.ddlWareHourses.Items[0].Selected = true;
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
                projectIds = projectIds.Substring(0, projectIds.Length - 1) + ",-1";
            }
            return projectIds;
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
                    this.ddlWareHourses.Items.Clear();
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvInventory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMInventoryInfo;
                //计算库存缺口
                int stockNumber = info.StockNumber.Value;
                int warningValue = info.WarningValue.Value;
                int inventorygap = warningValue - stockNumber;        //库存缺口
                Label lblInventoryGap = e.Row.FindControl("lblInventoryGap") as Label;
                lblInventoryGap.Text = inventorygap.ToString();
                lblInventoryGap.CssClass = "InventoryGap";
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