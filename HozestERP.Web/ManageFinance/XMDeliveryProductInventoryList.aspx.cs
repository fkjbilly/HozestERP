using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.Web.ManageFinance
{
    public partial class XMDeliveryProductInventoryList : BaseAdministrationPage, ISearchPage
    {
        public List<XMDeliveryProductInventory> ExportList = new List<XMDeliveryProductInventory>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                if (DateTime.Now.Month == 1)
                {
                    this.ddlYear.SelectedValue = (DateTime.Now.Year - 1).ToString();
                    this.ddlMonth.SelectedValue = "12";
                }
                else
                {
                    this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                    this.ddlMonth.SelectedValue = (DateTime.Now.Month - 1).ToString();
                }

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
                    this.ddlXMProject.Items.Clear();
                    this.ddlXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                }
                //this.ddlXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddlXMProject.Items[0].Selected = true;
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
                this.ddlXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                //.Where(c => c.ProjectTypeId == 362)

                this.ddlXMProject.DataSource = projectList;
                this.ddlXMProject.DataTextField = "ProjectName";
                this.ddlXMProject.DataValueField = "Id";
                this.ddlXMProject.DataBind();
                //this.ddlXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                this.ddlXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    this.ddlXMProject.Items.Insert(0, new ListItem("---无项目权限---", "0"));
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
                    this.ddlXMProject.DataSource = projectList;
                    this.ddlXMProject.DataTextField = "ProjectName";
                    this.ddlXMProject.DataValueField = "Id";
                    this.ddlXMProject.DataBind();
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
            //控件绑定年份
            this.ddlYear.Items.Clear();
            List<CodeList> YearList = new List<CodeList>();
            for (int i = 0; i < 4; i++)
            {
                CodeList year = new CodeList();
                year.CodeID = DateTime.Now.Year - i;
                year.CodeName = (DateTime.Now.Year - i).ToString() + "年";
                YearList.Add(year);
            }
            this.ddlYear.DataSource = YearList;
            this.ddlYear.DataTextField = "CodeName";
            this.ddlYear.DataValueField = "CodeID";
            this.ddlYear.DataBind();
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            int ProjectId = int.Parse(this.ddlXMProject.SelectedValue);//项目
            int NickId = int.Parse(this.ddlNick.SelectedValue);//店铺
            int Year = int.Parse(this.ddlYear.SelectedValue);//年
            int Month = int.Parse(this.ddlMonth.SelectedValue);//月
            List<int?> NickIds = new List<int?>();

            if (NickId == -1 || NickId == 99)
            {
                foreach (var nick in GetNickList())
                {
                    NickIds.Add(nick.nick_id);
                }
            }
            else
            {
                NickIds.Add(NickId);
            }

            var list = base.XMDeliveryProductInventoryService.GetXMDeliveryProductInventoryListByParam(NickIds, Year, Month);

            //店铺为所有，显示该项目该产品所有店铺中的总数量
            if (NickId == -1 || NickId == 99)
            {
                list = GetManufacturersCodeGroup(list);
            }

            ExportList = list;

            //分页
            var List = new PagedList<XMDeliveryProductInventory>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, List, paramPageSize + 1);
        }

        #endregion

        public List<XMDeliveryProductInventory> GetManufacturersCodeGroup(List<XMDeliveryProductInventory> list)
        {
            List<XMDeliveryProductInventory> List = new List<XMDeliveryProductInventory>();
            var ManufacturersCodeGroup = list.GroupBy(x => x.ManufacturersCode).ToList();
            foreach (var Item in ManufacturersCodeGroup)
            {
                var ProductList = Item.ToList();
                XMDeliveryProductInventory one = new XMDeliveryProductInventory();
                one.NickId = 0;
                one.Year = list[0].Year;
                one.Month = list[0].Month;
                one.ManufacturersCode = ProductList[0].ManufacturersCode;
                one.ProductName = ProductList[0].ProductName;
                one.Specifications = ProductList[0].Specifications;
                //剩余库存
                one.SurplusInventory = ProductList.Sum(x => x.SurplusInventory);
                //入库
                one.StorageCount = ProductList.Sum(x => x.StorageCount);
                one.StorageAmount = ProductList.Sum(x => x.StorageAmount);
                //出库
                one.DeliveryCount = ProductList.Sum(x => x.DeliveryCount);
                one.DeliveryAmount = ProductList.Sum(x => x.DeliveryAmount);
                //库存
                one.InventoryCount = ProductList.Sum(x => x.InventoryCount);
                one.InventoryAmount = ProductList.Sum(x => x.InventoryAmount);

                List.Add(one);
            }
            return List;
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

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = GetNickList();
                    this.ddlNick.Items.Clear();
                    this.ddlNick.DataSource = nickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    var nickList = GetNickList();
                    this.ddlNick.Items.Clear();
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

        public List<XMNick> GetNickList()
        {
            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddlXMProject.SelectedValue));
                return nickList;
            }
            else
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(this.ddlXMProject.SelectedValue), HozestERPContext.Current.User.CustomerID, 0);
                return nickList;
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string ProjectName = this.ddlXMProject.SelectedItem.Text.Trim();//项目
                    //导出存放路径
                    string fileName = string.Format("DeliveryProductInventoryExport_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\DeliveryProductInventoryExport", HttpContext.Current.Request.PhysicalApplicationPath);

                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;

                    this.BindGrid(1, Master.PageSize);

                    base.ExportManager.DeliveryProductInventoryExportList(filePath, ExportList, ProjectName);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }
    }
}