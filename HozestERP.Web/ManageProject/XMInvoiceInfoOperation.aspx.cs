using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMInvoiceInfoOperation : BaseAdministrationPage, ISearchPage
    {
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("PageXMPremiumsOperationAll", "ManageProject.XMInvoiceInfoOperation.All");//全部
                buttons.Add("PageManagerStatusNotEvaluation", "ManageProject.XMInvoiceInfoOperation.ManagerStatusNoEvaluation");//确认收货客服未核对
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageXMPremiumsOperationAll.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMInvoiceInfoList.aspx?TabPanelInvoiceInfoType=All";//全部
                this.PageManagerStatusNotEvaluation.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMInvoiceInfoList.aspx?TabPanelInvoiceInfoType=ManagerStatusNoEvaluation"; //确认收货客服未核对
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