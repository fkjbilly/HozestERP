using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMPremiumsOperation : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("PageXMPremiumsOperationAll", "ManageProject.XMPremiumsOperation.All");//全部
                buttons.Add("PageManagerStatusPay", "ManageProject.XMPremiumsOperation.Pay");//已付款客服未核对
                buttons.Add("PageManagerStatusNotEvaluation", "ManageProject.XMPremiumsOperation.ManagerStatusNoEvaluation");//确认收货客服未核对
                buttons.Add("PageManagerStatusNotCheck", "ManageProject.XMPremiumsOperation.ManagerStatusNotCheck");//已核对未审核 
                buttons.Add("PageManagerStatuAlreadyCheck", "ManageProject.XMPremiumsOperation.ManagerStatusAlreadyCheck");//已审核 
                //buttons.Add("PageManagerStatusDidNotPass", "ManageProject.XMPremiumsOperation.ManagerStatusDidNotPass");//未通过
                return buttons;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageXMPremiumsOperationAll.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMPremiumsList.aspx?TabPanelPremiumsType=All";//全部
                this.PageManagerStatusPay.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMPremiumsList.aspx?TabPanelPremiumsType=Pay"; //已付款客服未核对
                this.PageManagerStatusNotEvaluation.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMPremiumsList.aspx?TabPanelPremiumsType=ManagerStatusNoEvaluation"; //确认收货客服未核对
                this.PageManagerStatusNotCheck.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMPremiumsList.aspx?TabPanelPremiumsType=ManagerStatusNotCheck"; //已核对未审核
                this.PageManagerStatusAlreadyCheck.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMPremiumsList.aspx?TabPanelPremiumsType=ManagerStatusAlreadyCheck"; //已审核
                this.PageManagerNoOrder.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMPremiumsList.aspx?TabPanelPremiumsType=ManagerNoOrder"; //无订单赠品
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