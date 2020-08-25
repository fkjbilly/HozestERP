using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using Newtonsoft.Json.Linq;
using System.Web;
using System.IO;

namespace HozestERP.Web.ManageProject
{
    public partial class XMExpressListManagement : BaseAdministrationPage, ISearchPage
    {
        /// <summary>
        /// 按钮 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnImprtExpressList", "ManageProject.XMExpressListManagement.ImprtExpressList"); // 导入快递账单
                buttons.Add("btnExport", "ManageProject.XMExpressListManagement.Export"); // 导出快递账单
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
                this.BindGrid(1, Master.PageSize);

                this.btnImprtExpressList.OnClientClick = "return ShowWindowDetail('导入快递账单','" + CommonHelper.GetStoreLocation()
          + "ManageProject/ImportExpressListData.aspx', 800, 450, this, function(){document.getElementById('"
      + this.btnSearch.ClientID + "').click();});";
            }
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string Number = txtNumber.Text.Trim();                  //物流单号
            int year = int.Parse(ddlYear.SelectedValue);
            int month = int.Parse(ddlMonth.SelectedValue);
            string expressID = ddlExpress.SelectedValue;
            string provinceID = ddlProvince.SelectedValue;

            var list = base.XMExpressListManagementService.GetXMExpressListManagementByParm(Number, year, month, expressID, provinceID);
            var pageList = new PagedList<HozestERP.BusinessLogic.ManageProject.XMExpressListManagement>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, pageList);
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
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        //导出数据(快递账单)
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string Number = txtNumber.Text.Trim();                  //物流单号
                    int year = int.Parse(ddlYear.SelectedValue);
                    int month = int.Parse(ddlMonth.SelectedValue);
                    string expressID = ddlExpress.SelectedValue;
                    string provinceID = ddlProvince.SelectedValue;

                    var list = base.XMExpressListManagementService.GetXMExpressListManagementByParm(Number, year, month, expressID, provinceID);
                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\ExpressListManageExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    base.ExportManager.ExpressListManage(filePath, list);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
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

        }

        /// <summary>
        /// 删除行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        #region
        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            //快递绑定
            //快递绑定
            this.ddlExpress.Items.Clear();
            var xMCompanyCustomList = base.XMCompanyCustomService.GetXMCompanyCustomList();
            this.ddlExpress.DataSource = xMCompanyCustomList;
            this.ddlExpress.DataTextField = "LogisticsName";
            this.ddlExpress.DataValueField = "LogisticsId";
            this.ddlExpress.DataBind();
            this.ddlExpress.SelectedValue = "470";


            //绑定省
            this.ddlProvince.Items.Clear();
            var ProvinceList = base.AreaCodeService.GetAreaCode("001");
            this.ddlProvince.DataSource = ProvinceList;
            this.ddlProvince.DataTextField = "City";
            this.ddlProvince.DataValueField = "NumberID";
            this.ddlProvince.DataBind();
            this.ddlProvince.Items.Insert(0, new ListItem("其它", "-1"));
        }

        #endregion
    }
}