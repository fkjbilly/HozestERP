using System;
using System.Linq;
using System.Collections.Generic;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using System.Web.UI.WebControls;
using System.Web;
using System.IO;

namespace HozestERP.Web.ManageInventory
{
    public partial class XMDailySaleInfo : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                //弹出导入产品日销量窗口
                this.btnImportDaliySale.OnClientClick = "return ShowWindowDetail('导入日销量表','" + CommonHelper.GetStoreLocation() +
            "ManageInventory/ImportDaliySaleProduct.aspx',800,400, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                BindGrid(1, Master.PageSize);
            }
        }
        /// <summary>
        /// 
        /// </summary>
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
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            int nickId = int.Parse(ddlNick.SelectedValue);
            int projectId = int.Parse(ddXMProject.SelectedValue);
            string productCode = txtPurChaseCode.Text.Trim();
            string productName = txtPorductName.Text.Trim();
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
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

            var list = base.XMDailySaleInfoService.GetXMDailySaleInfoListByParm(productCode, productName, Begin, End, projectId, nickId);
            var pageList = new PagedList<HozestERP.BusinessLogic.ManageInventory.XMDailySaleInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvDailySaleInfo, pageList);
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

        protected void grdvDailySaleInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    var dailySaleInfo = base.XMDailySaleInfoService.GetXMDailySaleInfoById(Convert.ToInt16(id));
                    if (dailySaleInfo != null)
                    {
                        dailySaleInfo.IsEnable = true;
                        dailySaleInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        dailySaleInfo.UpdateDate = DateTime.Now;
                        base.XMDailySaleInfoService.UpdateXMDailySaleInfo(dailySaleInfo);
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

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> dailySaleInfoIDs = this.Master.GetSelectedIds(this.grdvDailySaleInfo);
            if (dailySaleInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in dailySaleInfoIDs)
                {
                    var dailySaleInfo = base.XMDailySaleInfoService.GetXMDailySaleInfoById(ID);
                    if (dailySaleInfo != null)
                    {
                        dailySaleInfo.IsEnable = true;
                        dailySaleInfo.UpdateDate = DateTime.Now;
                        dailySaleInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMDailySaleInfoService.UpdateXMDailySaleInfo(dailySaleInfo);
                    }
                }
            }
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("操作成功.");
        }

         /// <summary>
        /// 导出日销数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExportDaliySale_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\ExportDaliySale", HttpContext.Current.Request.PhysicalApplicationPath, fileName);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    int nickId = int.Parse(ddlNick.SelectedValue);
                    int projectId = int.Parse(ddXMProject.SelectedValue);
                    string productCode = txtPurChaseCode.Text.Trim();
                    string productName = txtPorductName.Text.Trim();
                    //开始日期
                    string Begin = this.txtBeginDate.Value.Trim();
                    //结束日期
                    string End = this.txtEndDate.Value.Trim();
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
                    var list = base.XMDailySaleInfoService.GetXMDailySaleInfoListByParm(productCode, productName, Begin, End, projectId, nickId);
                    base.ExportManager.ExportDaliySaleToXls(filePath, list.Distinct().ToList());
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception ex) 
                {
                    ProcessException(ex);
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