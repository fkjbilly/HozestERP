using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageInventory
{
    public partial class PdList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.btnPdAdd.OnClientClick = "return ShowWindowDetail('新建盘点单','" + CommonHelper.GetStoreLocation() +
"ManageInventory/PdAdd.aspx?Type=0"
+ "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                BindGrid(1, Master.PageSize);
                loadData();
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
        private string GetXMPdInfoByProjectID()
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
            if (nickids == "")
            {
                base.ShowMessage("您无权限查看盘点单!");
                return;
            }
            int status = int.Parse(ddlStatus.SelectedValue);    //状态
            string pdCode = txtPurChaseCode.Text.Trim();    //盘点单号自动生成
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            int projectId = ddXMProject.SelectedValue == "" ? -1 : Convert.ToInt16(ddXMProject.SelectedValue);
            int wareHousesId = ddlWareHourses.SelectedValue == "" ? -1 : Convert.ToInt16(ddlWareHourses.SelectedValue);
            DateTime date = DateTime.Now;
            if (Begin != "" || End != "")
            {
                if (Begin == "" || End == "" || !DateTime.TryParse(Begin, out date) || !DateTime.TryParse(End, out date))
                {
                    base.ShowMessage("日期格式不正确！");
                    return;
                }
            }
            if (End != "")
            {
                End = DateTime.Parse(End).AddDays(1).ToString("yyyy-MM-dd");
            }

            string paramwareHourseIDs = "";
            string paramwareHourseIDSelect = ddlWareHourses.SelectedValue == "" ? "-1" : ddlWareHourses.SelectedValue;
            if (paramwareHourseIDSelect == "-1")
            {
                for (int i = 0; i < this.ddlWareHourses.Items.Count; i++)
                {
                    if (this.ddlWareHourses.Items[i].Value != "-1")
                        paramwareHourseIDs = paramwareHourseIDs + this.ddlWareHourses.Items[i].Value + ",";
                }
                if (paramwareHourseIDs.Length > 0)
                {
                    paramwareHourseIDs = paramwareHourseIDs.Substring(0, paramwareHourseIDs.Length - 1) + ",-1";
                }
                else 
                {
                    paramwareHourseIDs = "-1";
                }
            }
            else
            {
                paramwareHourseIDs = paramwareHourseIDSelect;
            }
            var list = base.XMPdInfoService.GetXMPdInfoListByParm(pdCode, Begin, End, paramwareHourseIDs, status, projectId, nickids);
           
            list = list.OrderByDescending(p => p.BizDt).ToList();
            var pageList = new PagedList<XMPdInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvPd, pageList);
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
                string paramprojectIDs = "";
                string paramprojectIDSelect = this.ddXMProject.SelectedValue;
                if (paramprojectIDSelect == "-1" || paramprojectIDSelect == "99")
                {
                    for (int i = 0; i < this.ddXMProject.Items.Count; i++)
                    {
                        if (this.ddXMProject.Items[i].Value != "-1")
                            paramprojectIDs = paramprojectIDs + this.ddXMProject.Items[i].Value + ",";
                    }
                    paramprojectIDs = paramprojectIDs.Substring(0, paramprojectIDs.Length - 1) + ",-1";
                }
                else
                {
                    paramprojectIDs = paramprojectIDSelect;
                }
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(paramprojectIDs);
                this.ddlWareHourses.Items.Clear();
                this.ddlWareHourses.DataSource = wareHouses;
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
                    this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "99"));
                }

                string paramprojectIDs = "";
                string paramprojectIDSelect = this.ddXMProject.SelectedValue;
                if (paramprojectIDSelect == "-1" || paramprojectIDSelect == "99")
                {
                    for (int i = 0; i < this.ddXMProject.Items.Count; i++)
                    {
                        if (this.ddXMProject.Items[i].Value != "-1")
                            paramprojectIDs = paramprojectIDs + this.ddXMProject.Items[i].Value + ",";
                    }
                    paramprojectIDs = paramprojectIDs.Substring(0, paramprojectIDs.Length - 1) + ",-1";
                }
                else
                {
                    paramprojectIDs = paramprojectIDSelect;
                }
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(paramprojectIDs);
                this.ddlWareHourses.Items.Clear();
                this.ddlWareHourses.DataSource = wareHouses;
                this.ddlWareHourses.DataTextField = "Name";
                this.ddlWareHourses.DataValueField = "Id";
                this.ddlWareHourses.DataBind();
                this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {

                string paramprojectIDs = "";
                string paramprojectIDSelect = this.ddXMProject.SelectedValue;
                if (paramprojectIDSelect == "-1" || paramprojectIDSelect == "99")
                {
                    for (int i = 0; i < this.ddXMProject.Items.Count; i++)
                    {
                        if (this.ddXMProject.Items[i].Value != "-1")
                            paramprojectIDs = paramprojectIDs + this.ddXMProject.Items[i].Value + ",";
                    }
                    paramprojectIDs = paramprojectIDs.Substring(0, paramprojectIDs.Length - 1) + ",-1";
                }
                else
                {
                    paramprojectIDs = paramprojectIDSelect;
                }
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(paramprojectIDs);
                this.ddlWareHourses.Items.Clear();
                this.ddlWareHourses.DataSource = wareHouses;
                this.ddlWareHourses.DataTextField = "Name";
                this.ddlWareHourses.DataValueField = "Id";
                this.ddlWareHourses.DataBind();
                this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));

            }
        }

        public string CustomerName(string customerID)
        {
            string name = "";
            var customer = base.CustomerInfoService.GetCustomerInfoByID(Convert.ToInt16(customerID));
            if (customer != null)
            {
                name = customer.FullName;
            }
            return name;
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

        protected void grdvPd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool isNotSame = true ;                   //盘点库存与实际库存一致-->原来是false现在改成ture 相当于取消这个判断了
                var info = e.Row.DataItem as XMPdInfo;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                ImageButton imgjustedInfo = e.Row.FindControl("imgjustedInfo") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑盘点单','" + CommonHelper.GetStoreLocation() +
        "ManageInventory/PdAdd.aspx?Type=1"
          + "&&PdID=" + info.Id
        + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('查看盘点单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/PdAdd.aspx?Type=2"
       + "&&PdID=" + info.Id
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgjustedInfo != null)                            //添加调整单
                {
                    imgjustedInfo.OnClientClick = "return ShowWindowDetail('生成调整单','" + CommonHelper.GetStoreLocation() +
    "ManageInventory/AdjustedAdd.aspx?Type=0"
      + "&&PdID=" + info.Id
    + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }

                //判断盘点产品数量与实际库存数量是否一致 如不一致，显示生成调整单按钮
                int pdId = info.Id;
                var pdInfo = base.XMPdInfoService.GetXMPdInfoById(pdId);
                var pdProductDetail = base.XMPdInfoProductDetailsService.GetXMPdInfoProductDetailsListByPdID(pdId);
                if (pdProductDetail != null && pdProductDetail.Count > 0)
                {
                    foreach (XMPdInfoProductDetails Info in pdProductDetail)
                    {
                        //查询当前产品库存是否与盘点数量一致
                        var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(Info.PlatformMerchantCode, pdInfo.WarehouseId);
                        if (InventoryInfo != null && InventoryInfo.StockNumber != Info.PCount)
                        {
                            isNotSame = true;
                        }
                    }
                }
                if (isNotSame)           //如果不一致 显示生成调整单按钮
                {
                    imgjustedInfo.Visible = true;
                }
                else
                {
                    imgjustedInfo.Visible = false;
                }
                switch (info.BillStatus)
                {
                    case 0:                          //状态为待盘点  可进行编辑和删除
                        if (imgBtnEdit != null)
                        {
                            imgBtnEdit.Visible = true;
                        }
                        if (imgBtnDelete != null)
                        {
                            imgBtnDelete.Visible = true;
                        }
                        if (imgProductDetails != null)
                        {
                            imgProductDetails.Visible = false;
                        }
                        break;
                    case 1000:                  //状态为已盘点  无法编辑和删除只能产看
                        if (imgBtnEdit != null)
                        {
                            imgBtnEdit.Visible = false;
                        }
                        if (imgBtnDelete != null)
                        {
                            imgBtnDelete.Visible = false;
                        }
                        if (imgProductDetails != null)
                        {
                            imgProductDetails.Visible = true;
                        }
                        if (imgjustedInfo != null)
                        {
                            imgjustedInfo.Visible = false;
                        }
                        break;
                }
            }
        }

        protected void grdvPd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    //删除盘点主表信息和盘点产品明细表
                    var pdInfo = base.XMPdInfoService.GetXMPdInfoById(Convert.ToInt16(id));
                    if (pdInfo != null)
                    {
                        //删除主表
                        pdInfo.IsEnable = true;
                        pdInfo.UpdateDate = DateTime.Now;
                        pdInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMPdInfoService.UpdateXMPdInfo(pdInfo);
                        var details = base.XMPdInfoProductDetailsService.GetXMPdInfoProductDetailsListByPdID(pdInfo.Id);
                        if (details != null && details.Count > 0)
                        {
                            foreach (XMPdInfoProductDetails parm in details)
                            {
                                parm.IsEnable = true;
                                parm.Updatedate = DateTime.Now;
                                parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMPdInfoProductDetailsService.UpdateXMPdInfoProductDetails(parm);
                            }
                        }
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