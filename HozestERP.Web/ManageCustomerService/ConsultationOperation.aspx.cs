using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class ConsultationOperation : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("PageConsultation", "ManageCustomerService.XMConsultation.PageView");//销售跟进
                buttons.Add("PageDataAnalysis", "ManageCustomerService.XMDataAnalysis.PageView");//销售数据分析
                buttons.Add("PageNoDeal", "ManageCustomerService.XMDataAnalysisNoDeal.PageView");//未成交数据分析 
                return buttons;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageConsultation.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageCustomerService/XMConsultation.aspx";//销售跟进
                this.PageDataAnalysis.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageCustomerService/XMDataAnalysis.aspx"; //销售数据分析
                this.PageNoDeal.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageCustomerService/XMDataAnalysisNoDeal.aspx"; //未成交数据分析
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