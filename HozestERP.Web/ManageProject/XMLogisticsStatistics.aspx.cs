using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManageProject
{
    public partial class XMLogisticsStatistics : BaseAdministrationPage, ISearchPage
    {
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            try
            {
                string BeginDate = txtBeginDate.Value.Trim();
                string EndDate = txtEndDate.Value.Trim();

                List<XMLogisticsProject> list = XMLogisticsInfoService.getXMLogisticsProjectList(BeginDate, EndDate,ddlLogisticsCompany.Text);
                Ext.Net.Store Store1 = GridPanel1.GetStore();
                Store1.DataSource = list;
                Store1.DataBind();
            }
            catch(Exception ex)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", ex.Message).Show();
            }
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlLogisticsCompany.Items.Clear();
                List<XMCompanyCustom> xMCompanyCustomList = base.XMCompanyCustomService.GetXMCompanyCustomList();
                this.ddlLogisticsCompany.DataSource = xMCompanyCustomList;
                this.ddlLogisticsCompany.DataTextField = "LogisticsName";
                this.ddlLogisticsCompany.DataValueField = "LogisticsId";
                this.ddlLogisticsCompany.DataBind();
                this.ddlLogisticsCompany.Items.Insert(0, new ListItem("---所有---", "-1"));
                BindGrid(0, 0);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(0, 0);
        }

        protected void DataExport_Click(object sender, EventArgs e)
        {
            try
            {
                //导出存放路径
                string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                string filePath = string.Format("{0}Upload\\ImportLogisticsNumberData\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                string BeginDate = txtBeginDate.Value.Trim();
                string EndDate = txtEndDate.Value.Trim();

                List<XMLogisticsProject> list = XMLogisticsInfoService.getXMLogisticsProjectList(BeginDate, EndDate, ddlLogisticsCompany.Text);

                base.ExportManager.ExportLogisticsStatistics(filePath, list);
                CommonHelper.WriteResponseXls(filePath, fileName);
            }
            catch(Exception ex)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", ex.Message).Show();
            }
        }
    }
}