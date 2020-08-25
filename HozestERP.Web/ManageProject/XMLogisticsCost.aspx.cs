using Ext.Net;
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
    public partial class XMLogisticsCost : BaseAdministrationPage, ISearchPage
    {
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

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
                //DataLoad();
                this.btnImport.OnClientClick = "return ShowWindowDetail('导入物流单号','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportLogisticsInfo.aspx',660,280, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";
                BindGrid();
            }
        }

        private void BindGrid()
        {
            var list = XMLogisticsCostService.GetXMLogisticsCostList();
            StoreWorker.DataSource = list;
            StoreWorker.DataBind();
        }

        protected void Data_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            BindGrid();
        }
    }
}