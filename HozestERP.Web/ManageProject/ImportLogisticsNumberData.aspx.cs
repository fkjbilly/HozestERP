using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageProject
{
    public partial class ImportLogisticsNumberData : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnImport", "ImportOrder.ImportLogisticsNumberData");//数据导入按钮
                return buttons;
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
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
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

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SettrEditHeadVisible = false;
            //发货单类型
            this.ddDeliveryTypeId.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(204, false);
            this.ddDeliveryTypeId.DataSource = codeList;
            this.ddDeliveryTypeId.DataTextField = "CodeName";
            this.ddDeliveryTypeId.DataValueField = "CodeID";
            this.ddDeliveryTypeId.DataBind();

            //this.ddDeliveryTypeId.Enabled = false;
        }

        public void SetTrigger()
        {
        }

        #endregion

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string serpath = string.Empty;
                if (DataFilePath.HasFile)
                {
                    int xMProjectID = int.Parse(ddXMProject.SelectedValue);
                    int wareHoueseID = int.Parse(ddlWareHourses.SelectedValue);
                    //平台类型 
                    // int PlatformTypeId = int.Parse(this.ddPlatformTypeId.SelectedValue);
                    int DeliveryTypeId = Convert.ToInt32(this.ddDeliveryTypeId.SelectedValue.ToString());//发货单类型Id
                    string DeliveryTypeIdName = this.ddDeliveryTypeId.SelectedItem.ToString();//发货单类型名称
                    string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    // string FileName = DataFilePath.FileName.Substring(0, DataFilePath.FileName.Length - (typ.Length + 1));

                    if (xMProjectID == -1)
                    {
                        base.ShowMessage("请先选择项目！");
                        return;
                    }

                    if (typ == "xls" || typ == "xlsx")
                    {
                        string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                        string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\ImportLogisticsNumberData";
                        if (!Directory.Exists(partpath))
                        {
                            Directory.CreateDirectory(partpath);
                        }
                        serpath = partpath + "\\" + partname;
                        DataFilePath.SaveAs(serpath);
                        string paramMessage = string.Empty;
                        base.ImportManager.ImportLogisticsNumberDataFromXls(serpath, DateTime.Now, DeliveryTypeId, DeliveryTypeIdName, ref paramMessage, xMProjectID, wareHoueseID);
                        this.txtResult.Text = paramMessage;
                    }
                }
            }
            catch (Exception err)
            {
                base.ProcessException(err, false);
                this.txtResult.Text = err.Message;
            }
        }
    }
}