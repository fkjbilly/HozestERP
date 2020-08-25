 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

using Ext.Net;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ModuleManagement;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils.Html;
using HozestERP.BusinessLogic.Configuration.Settings;

namespace HozestERP.Web
{
    public partial class Default : BaseAdministrationPage
    {


        //protected override Dictionary<string, string> ButtonSecuritys
        //{
        //    get
        //    {
        //        Dictionary<string, string> buttons = new Dictionary<string, string>();
        //        buttons.Add("plNavigationSearch", "Default.NavigationSearch"); 
        //        return buttons;
        //    }
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.BindModule();
                //合同审核提示信息
                var alertTimeSet = base.SettingManager.GetAlertTimeSetByAlertIDAndCustomerID(1, HozestERPContext.Current.User.CustomerID);
                if (alertTimeSet!=null)
                    this.TaskManager2.Tasks[0].Interval = alertTimeSet.Cycletime!=null ? alertTimeSet.Cycletime.Value : 3600000;
            }
            //if (!IsPostBack)
            //{
            //    if(this.RepairTypeId!=-1){

            //        this.PanelPages.Title = "主界面";
            //        this.PanelPages.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBXRepairInformation/TheMainInterface.aspx?RepairTypeId=" + RepairTypeId;//主界面
                    
            //    }else{

            //        this.PanelPages.Title = "管理员页面";
            //        this.PanelPages.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBXRepairInformation/MaintenanceAdministratorInterface.aspx?RepairTypeId=" + RepairTypeId;//管理员页面
            //    }

            //}
        }
        
        private void BindModule()
        {
            var modules = base.ACLService.GetModulesByModuleID(0);
            foreach (var item in modules)
            {
                TreePanel treePanel = new TreePanel();
                treePanel.AutoScroll = true;
                treePanel.RootVisible = false;
                treePanel.Border = false;
                treePanel.Lines = false;
                treePanel.EnableDD = false;
                treePanel.ContainerScroll = true;
                treePanel.Title = "&nbsp;&nbsp;&nbsp;<font color='white'><b>" + item.ModuleName + "</b></font>";
                treePanel.Width = 170;
                treePanel.IconCls = item.iconCls;
                treePanel.Listeners.BeforeLoad.Fn = "nodeLoad";
                AsyncTreeNode asyncNode = new AsyncTreeNode();
                asyncNode.Text = item.ModuleName;
                asyncNode.NodeID = item.ModuleID.ToString();
                asyncNode.SingleClickExpand = true;
                treePanel.Root.Add(asyncNode);
                treePanel.LayoutConfig.Add(new AccordionLayoutConfig() { Animate = true });

                this.pnlModule.Items.Add(treePanel);
            }
        }

        [DirectMethod(Namespace = "CompanyX")]
        public string NodeLoad(string nodeID)
        {
            Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();
            if (!string.IsNullOrEmpty(nodeID))
            {
                int moduleID = 0;
                int.TryParse(nodeID, out moduleID);
                var modules = base.ACLService.GetModulesByModuleID(moduleID);

                foreach (var item in modules)
                {
                    if (item.childModules.Count() > 0)
                    {
                        AsyncTreeNode asyncNode = new AsyncTreeNode();
                        asyncNode.Text = item.ModuleName;
                        asyncNode.NodeID = item.ModuleID.ToString();
                        asyncNode.Expanded = item.Expand;
                        asyncNode.SingleClickExpand = true;
                        nodes.Add(asyncNode);
                    }
                    else
                    {
                        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                        treeNode.Text = item.ModuleName;
                        treeNode.NodeID = item.ModuleID.ToString();
                        treeNode.Listeners.Click.Handler = "addTab(#{TabPanel1}, '" + item.ModuleID + "', '" + CommonHelper.ModifyQueryString(item.href,"WebModuleID=" + item.ModuleID, "") + "', '" + item.ModuleName + "', '" + item.iconCls + "');";

                        //treeNode.Href = item.href;
                        //if (item.isTarget)
                        //{
                        //    treeNode.HrefTarget = "ContentPage";
                        //}
                        //else
                        //{
                        //    treeNode.HrefTarget = "_blank";
                        //}
                        treeNode.IconCls = item.iconCls;

                        treeNode.Leaf = true;
                        nodes.Add(treeNode);
                    }
                }
            }

            return nodes.ToJson();
        }

        [DirectMethod(Namespace = "CompanyX")]
        public int OnlineUserService()
        {
            if (base.OnlineUserService.Enabled)
            {
                var allUsers = base.OnlineUserService.GetRegisteredUsersOnline();
                return allUsers.Count();
            }
            else
            {
                return 0;
            }
        }

        public class NewNote
        {
            public string NoteID { get; set; }

            public string Created { get; set; }

            public string Title { get; set; }

            public string FullName { get; set; }
        }


        ///// <summary>
        ///// 报修类型
        ///// </summary>
        //public int RepairTypeId
        //{
        //    get
        //    {
        //        return CommonHelper.QueryStringInt("RepairTypeId");
        //    }
        //}

    }
}