using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageInventory
{
    public partial class ImportDaliySaleProduct : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                txtBeginDate.Value = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
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

        protected void ddlNick_SelectedIndexChanged(object sender, EventArgs e)
        {
            int NickId = Convert.ToInt32(this.ddlNick.SelectedValue.ToString());
            if (NickId == 29)             //显示京东自营销量模板
            {
                SaleDeliveryModel.Visible = true;
                this.SaleDeliveryModel.Text = "下载京东自营销售模板";
                this.SaleDeliveryModel.NavigateUrl = "~/Template/自营动销表格.xlsx";
            }
            else
            {
                SaleDeliveryModel.Visible = false;
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {

        }

        public void SetTrigger()
        {

        }

        #endregion

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                //店铺id
                int ProjectId = Convert.ToInt16(this.ddXMProject.SelectedValue.ToString());
                int NickId = Convert.ToInt32(this.ddlNick.SelectedValue.ToString());
                string Begin = this.txtBeginDate.Value.Trim();
                if (ProjectId == -1)
                {
                    base.ShowMessage("请选择需要导入日销单所属项目！");
                    return;
                }
                if (NickId == -1 || NickId == 99)
                {
                    base.ShowMessage("请选择需要导入日销售单所属店铺！");
                    return;
                }
                DateTime date = DateTime.Now;
                if (Begin != "")
                {
                    if (Begin == "" || !DateTime.TryParse(Begin, out date))
                    {
                        base.ShowMessage("日期格式不正确！");
                        return;
                    }
                }
                string serpath = string.Empty;
                if (DataFilePath.HasFile)
                {
                    string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    if (typ == "xls" || typ == "xlsx")
                    {
                        string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                        string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\XMDailySaleInfo";
                        if (!Directory.Exists(partpath))
                        {
                            Directory.CreateDirectory(partpath);
                        }
                        serpath = partpath + "\\" + partname;
                        DataFilePath.SaveAs(serpath);
                        string paramMessage = string.Empty;
                        base.ImportManager.ImportDailySaleProductList(serpath, ref paramMessage, NickId, Begin);
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