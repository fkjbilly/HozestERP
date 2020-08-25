using Ext.Net;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManagePortlet
{
    public partial class OrderMonitorDetails : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            var data = XMOrderInfoService.getUnusualOrder();

            StoreWorker.DataSource = data.Where(a => a.ProjectId == projectID);
            StoreWorker.DataBind();
        }

        protected void Data_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            BindGrid();
        }

        private int projectID
        {
            get
            {
                return CommonHelper.QueryStringInt("projectID");
            }
        }

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

        }
    }
}