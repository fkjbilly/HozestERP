using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    public partial class CWProfitListOperation : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.pageQuestionDeal.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageFinance/CWProfitListSS.aspx"; //实时毛利
                this.PageQuestion.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageFinance/CWProfitListSSY.aspx";//管理报表
                this.PageAnalysis.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageFinance/CWProfitListAnalysisSSY.aspx";//统计分析
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