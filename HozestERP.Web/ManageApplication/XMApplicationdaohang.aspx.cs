using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageApplication
{
    public partial class XMApplicationdaohang : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("PageQuestion", "ManageApplication.Daohang.index");//退换货
                buttons.Add("pageQuestionDeal", "ManageApplication.Daohang.Sup");//主管审核 
                //buttons.Add("Panel1", "ManageApplication.Daohang.Fin");//财务审核 
                buttons.Add("PageDataAnalysis", "ManageApplication.XMDataAnalysisApplication.PageView");//退换货数据分析-客服
                buttons.Add("PageDataAnalysisType", "ManageApplication.XMDataAnalysisApplicationType.PageView");//退换货数据分析-退换货类型
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageQuestion.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageApplication/XMApplicationList.aspx?type=1";//退换货
                this.pageQuestionDeal.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageApplication/XMApplicationList.aspx?type=2"; //主管审核
                //this.Panel1.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageApplication/XMApplicationList.aspx?type=3"; //财务审核
                this.PageDataAnalysis.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageApplication/XMDataAnalysisApplication.aspx"; //退换货数据分析-客服
                this.PageDataAnalysisType.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageApplication/XMDataAnalysisApplicationType.aspx"; //退换货数据分析-退换货类型
                PageDataStatistics.AutoLoad.Url= CommonHelper.GetStoreLocation() + "ManageApplication/XMDataStatisticsApplication.aspx"; 
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