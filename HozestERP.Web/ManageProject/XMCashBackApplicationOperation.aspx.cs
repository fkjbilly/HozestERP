using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMCashBackApplicationOperation : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("PageCashBackApplicationOperationAll", "ManageProject.XMCashBackApplicationOperation.All");//全部
                buttons.Add("PageManagerStatusNotCheck", "ManageProject.XMCashBackApplicationOperation.ManagerStatusNotCheck");//未审核 
                buttons.Add("PageManagerStatuAlreadyCheck", "ManageProject.XMCashBackApplicationOperation.ManagerStatusAlreadyCheck");//已审核 
                buttons.Add("PageManagerStatusNoOrder", "ManageProject.XMCashBackApplicationOperation.ManagerStatusNoOrder");//无订单返现
                //buttons.Add("PageManagerStatusDidNotPass", "ManageProject.XMCashBackApplicationOperation.ManagerStatusDidNotPass");//未通过
                return buttons;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageCashBackApplicationOperationAll.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMCashBackApplicationList.aspx?TabPanelCashBackApplicationType=All";//全部
                this.PageManagerStatusNotCheck.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMCashBackApplicationList.aspx?TabPanelCashBackApplicationType=ManagerStatusNotCheck"; //未审核
                this.PageManagerStatusAlreadyCheck.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMCashBackApplicationList.aspx?TabPanelCashBackApplicationType=ManagerStatusAlreadyCheck"; //已审核
                this.PageManagerStatusNoOrder.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMCashBackApplicationList.aspx?TabPanelCashBackApplicationType=ManagerStatusNoOrder"; //已审核
                //this.PageManagerStatusDidNotPass.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMCashBackApplicationList.aspx?TabPanelCashBackApplicationType=ManagerStatusDidNotPass"; //未通过
            }
        }


        public void SetTrigger()
        {
            throw new NotImplementedException();
        }

        public void Face_Init()
        {
            throw new NotImplementedException();
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            throw new NotImplementedException();
        }
    }
}