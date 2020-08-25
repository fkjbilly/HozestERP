using System;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using System.Collections.Generic;
using System.Transactions;
using System.Web;
using System.IO;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageCustomerService;


namespace HozestERP.Web.ManageInventory
{
    public partial class XMMonthInventoryStatistics : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlMonth.SelectedValue = (DateTime.Now.Month - 1).ToString();
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

                //绑定仓库
                List<XMWareHouses> WareList = new List<XMWareHouses>();
                if (projectList != null && projectList.Count > 0)
                {
                    foreach (XMProject pro in projectList)
                    {
                        var wareHouesse = base.XMWareHousesService.GetXMWarehouseListByProjectId(pro.Id);
                        if (wareHouesse != null && wareHouesse.Count > 0)
                        {
                            foreach (XMWareHouses ware in wareHouesse)
                            {
                                WareList.Add(ware);
                            }
                        }
                    }
                }
                this.ddlWareHourses.Items.Clear();
                this.ddlWareHourses.DataSource = WareList;
                this.ddlWareHourses.DataTextField = "Name";
                this.ddlWareHourses.DataValueField = "Id";
                this.ddlWareHourses.DataBind();
                this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));

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

                //绑定仓库
                List<XMWareHouses> WareList = new List<XMWareHouses>();
                if (projectList != null && projectList.Count() > 0)
                {
                    foreach (var pro in projectList)
                    {
                        var wareHouesse = base.XMWareHousesService.GetXMWarehouseListByProjectId(pro.Id);
                        if (wareHouesse != null && wareHouesse.Count > 0)
                        {
                            foreach (XMWareHouses ware in wareHouesse)
                            {
                                WareList.Add(ware);
                            }
                        }
                    }
                }
                this.ddlWareHourses.Items.Clear();
                this.ddlWareHourses.DataSource = WareList;
                this.ddlWareHourses.DataTextField = "Name";
                this.ddlWareHourses.DataValueField = "Id";
                this.ddlWareHourses.DataBind();
                this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                int projectID = Convert.ToInt32(this.ddXMProject.SelectedValue);
                if (Convert.ToInt16(this.ddXMProject.SelectedValue.ToString().Trim()) != -1)
                {
                    var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectId(projectID);
                    this.ddlWareHourses.Items.Clear();
                    this.ddlWareHourses.DataSource = wareHouses;
                    this.ddlWareHourses.DataTextField = "Name";
                    this.ddlWareHourses.DataValueField = "Id";
                    this.ddlWareHourses.DataBind();
                    this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    BindddXMProject();
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
        private string GetXMStorageListByProjectID()
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
            int projectId = ddXMProject.SelectedValue == "" ? -1 : Convert.ToInt16(ddXMProject.SelectedValue);
            int wareHousesId = ddlWareHourses.SelectedValue == "" ? -1 : Convert.ToInt16(ddlWareHourses.SelectedValue);
            int year = int.Parse(ddlYear.SelectedValue);
            int month = int.Parse(ddlMonth.SelectedValue);
            string nickids = GetCustomerMappingNickIDs();
            //查询店铺ID为-1或99
            string pids = GetXMStorageListByProjectID();

            var list = base.XMInventoryInfoStatisticsService.GetXMInventoryInfoStatisticsListByParm(year, month, wareHousesId, projectId, nickids);

            //未选择店铺记录查询(nickid== -1 ||  nickid ==99 &&  projectid != -1  )
            var list2 = base.XMInventoryInfoStatisticsService.GetXMInventoryInfoStatisticsListByProjectIds(year, month, wareHousesId, projectId, pids);
            if (list2 != null && list2.Count > 0)
            {
                foreach (XMInventoryInfoStatistics Info in list2)
                {
                    list.Add(Info);
                }
            }
            list = list.OrderByDescending(p => p.CreateDate).ToList();
            var pageList = new PagedList<XMInventoryInfoStatistics>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, pageList);
        }

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month - 1;
                DateTime startDate = new DateTime(year, month, 1, 0, 0, 0);
                DateTime endDate = DateTime.Now;
                var info = e.Row.DataItem as XMInventoryInfoStatistics;
                var Statistics = base.XMInventoryInfoStatisticsService.GetXMInventoryInfoStatisticsById(info.Id);
                if (Statistics != null)
                {
                    int storageRejectedCount = 0;           //入库退货数量
                    var Info = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsListByParm(startDate, endDate, Statistics.WfID.Value, Statistics.ManufacturersCode);
                    //返回入库退货数量
                    if (Info != null && Info.Count > 0)
                    {
                        foreach (XMPurchaseRejectedProductDetails p in Info)
                        {
                            storageRejectedCount += p.RejectionCount;
                        }
                    }
                    //数量不符 标红
                    if (((Statistics.InitialCount.Value + Statistics.StorageCount.Value - Statistics.DeliveryCount.Value - storageRejectedCount) != Statistics.InventoryCount))
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void grdvClients_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //判断创建的行是否为表头行
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //获取表头所在行的所有单元格
                TableCellCollection tcHeader = e.Row.Cells;
                //清除自动生成的表头
                tcHeader.Clear();
                //第一行
                tcHeader.Add(new TableHeaderCell());
                tcHeader[0].RowSpan = 2;
                tcHeader[0].Text = "年份";
                tcHeader[0].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[1].RowSpan = 2;
                tcHeader[1].Text = "月份";
                tcHeader[1].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[2].RowSpan = 2;
                tcHeader[2].Text = "商品编码";
                tcHeader[2].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[3].RowSpan = 2;
                tcHeader[3].Text = "商品名称";
                tcHeader[3].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].RowSpan = 2;
                tcHeader[4].Text = "规格型号";
                tcHeader[4].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[5].RowSpan = 2;
                tcHeader[5].Text = "所属仓库";
                tcHeader[5].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[6].ColumnSpan = 2;
                tcHeader[6].Text = "期初数据";
                tcHeader[6].HorizontalAlign = HorizontalAlign.Center;//居中显示

                tcHeader.Add(new TableHeaderCell());
                tcHeader[7].ColumnSpan = 2;
                tcHeader[7].Text = "采购入库";
                tcHeader[7].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[8].ColumnSpan = 2;
                tcHeader[8].Text = "出库";
                tcHeader[8].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[9].ColumnSpan = 2;
                tcHeader[9].Text = "库存</th></tr><tr>";
                tcHeader[9].HorizontalAlign = HorizontalAlign.Center;

                ////第二行
                tcHeader.Add(new TableHeaderCell());
                tcHeader[10].Text = "数量";
                tcHeader[10].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[11].Text = "金额";
                tcHeader[11].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[12].Text = "数量";
                tcHeader[12].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[13].Text = "金额";
                tcHeader[13].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[14].Text = "数量";
                tcHeader[14].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[15].Text = "金额";
                tcHeader[15].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[16].Text = "数量";
                tcHeader[16].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[17].Text = "金额";
                tcHeader[17].HorizontalAlign = HorizontalAlign.Center;

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnInventoryStatistics_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\MonthInventoryStatisticsExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;

                    int projectId = ddXMProject.SelectedValue == "" ? -1 : Convert.ToInt16(ddXMProject.SelectedValue);
                    int wareHousesId = ddlWareHourses.SelectedValue == "" ? -1 : Convert.ToInt16(ddlWareHourses.SelectedValue);
                    int year = int.Parse(ddlYear.SelectedValue);
                    int month = int.Parse(ddlMonth.SelectedValue);
                    string nickids = GetCustomerMappingNickIDs();
                    //查询店铺ID为-1或99
                    string pids = GetXMStorageListByProjectID();

                    var list = base.XMInventoryInfoStatisticsService.GetXMInventoryInfoStatisticsListByParm(year, month, wareHousesId, projectId, nickids);

                    //未选择店铺记录查询(nickid== -1 ||  nickid ==99 &&  projectid != -1  )
                    var list2 = base.XMInventoryInfoStatisticsService.GetXMInventoryInfoStatisticsListByProjectIds(year, month, wareHousesId, projectId, pids);
                    if (list2 != null && list2.Count > 0)
                    {
                        foreach (XMInventoryInfoStatistics Info in list2)
                        {
                            list.Add(Info);
                        }
                    }
                    list = list.OrderByDescending(p => p.CreateDate).ToList();

                    base.ExportManager.MonthInventoryStatisticsInfoToXls(filePath, list);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
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