using Ext.Net;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageCustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMClaimReasonPage : BaseAdministrationPage, ISearchPage
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

        private void DataLoad()
        {
            var list = XMProjectService.GetXMProjectList();
            StoreProject.DataSource = list;
            StoreProject.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataLoad();
                BindGrid();
            }
        }

        protected void Data_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            var list = XMClaimReasonService.GetXMClaimNewReasonList();
            StoreReason.DataSource = list;
            StoreReason.DataBind();
        }

        protected void btnSave_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            int? projectID = null;
            if(!string.IsNullOrEmpty(cbProject.Value.ToString()))
            {
                projectID = int.Parse(cbProject.Value.ToString());
            }
            string reason = txtReason.Text.Trim();

            XMClaimReason entity = XMClaimReasonService.getSingle(a => a.ProjectID == projectID && a.Reason == reason);
            if (entity != null)
            {
                ExtNet.Msg.Alert("提示", "已有相同的信息存在！").Show();
                return;
            }

            XMClaimReason model = new XMClaimReason();
            model.ProjectID = projectID;
            model.Reason = reason;
            model.IsEnable = false;
            model.CreateID = HozestERPContext.Current.User.CustomerID;
            model.CreateTime = DateTime.Now;
            model.UpdateID = HozestERPContext.Current.User.CustomerID;
            model.UpdateTime = DateTime.Now;

            XMClaimReasonService.InsertXMClaimReason(model);
        }

        protected void btnEdit_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            int? projectID = null;
            if (!string.IsNullOrEmpty(cbProject.Value.ToString()))
            {
                projectID = int.Parse(cbProject.Value.ToString());
            }
            string reason = txtReason.Text.Trim();

            XMClaimReason entity = XMClaimReasonService.getSingle(a => a.ID == ID);
            if (entity == null)
            {
                ExtNet.Msg.Alert("提示", "记录不存在！").Show();
                return;
            }

            entity.ProjectID = projectID;
            entity.Reason = reason;
            entity.CreateID = HozestERPContext.Current.User.CustomerID;
            entity.CreateTime = DateTime.Now;
            entity.UpdateID = HozestERPContext.Current.User.CustomerID;
            entity.UpdateTime = DateTime.Now;

            XMClaimReasonService.UpdateXMClaimReason(entity);
        }
    }
}