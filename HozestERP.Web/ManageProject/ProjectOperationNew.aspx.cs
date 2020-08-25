using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class ProjectOperationNew : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                //buttons.Add("pageNickMarketingCampaignInfoNew", "ManageProject.NickMarketingCampaignInfoNew.PageView");
                buttons.Add("PageTargetOperation", "ManageProject.TargetOperation.PageView");//目标设定
                buttons.Add("pagePRProductManageNew", "ManageProject.PRProductManageNew.PageView");//产品管理
                buttons.Add("PagePRReachedValueOperation", "ManageProject.PRReachedValueOperation.PageView");//达成数据
                buttons.Add("PagePRNickManageInfoNew", "ManageProject.PRNickManageInfoNew.PageView");
                //buttons.Add("PagePRTransactionAnalysisOperation", "ManageProject.PRTransactionAnalysisOperation.PageView"); //成交分析 
                //buttons.Add("PagePRTransformationAnalysisOperation", "ManageProject.PRTransformationAnalysisOperation.PageView"); //转化分析  
                //buttons.Add("PageZTCOperation", "ManageProject.ZTCOperation.PageView");//直通车
                //buttons.Add("PageCustomerServiceOperation", "ManageProject.CustomerServiceOperation.PageView");//客服   
                //buttons.Add("PagePRFlow", "ManageProject.PRFlows.PageView");//流量   
                //buttons.Add("PagePRSingleProduct", "ManageProject.PRSingleProduct.PageView");//单品     
                //buttons.Add("PagePRNickManageInfoNewDetail", "ManageProject.PRNickManageInfoNewDetail.PageView");
                //buttons.Add("PagePRNickRefundStatistics", "ManageProject.PRNickRefundStatistics.PageView");//店铺退款统计
                //buttons.Add("PageWithBrandsNick", "ManageProject.WithBrandsNick.PageView");//同品牌数据分析  
                return buttons;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.pageNickMarketingCampaignInfoNew.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/NickMarketingCampaignInfoNew.aspx?nick_id=" + this.nick_id;
                this.PageTargetOperation.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/TargetOperation.aspx?nick_id=" + this.nick_id;
                this.pagePRProductManageNew.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/PRProductManageNew.aspx?nick_id=" + this.nick_id + "&Nick="+this.Nick; 
                
                this.PagePRReachedValueOperation.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/PRReachedValueOperation.aspx?nick_id=" + this.nick_id;
                //this.PagePRNickManageInfoNew.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/PRNickManageInfoNew.aspx?nick_id=" + this.nick_id;
                this.PagePRNickManageInfoNew.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/ShopOperators.aspx?nick_id=" + this.nick_id;
                //this.PagePRTransactionAnalysisOperation.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/PRTransactionAnalysisOperation.aspx?nick_id=" + this.nick_id;
                //this.PagePRTransformationAnalysisOperation.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/PRTransformationAnalysisOperation.aspx?nick_id=" + this.nick_id;
                //this.PageZTCOperation.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/ZTCOperation.aspx?nick_id=" + this.nick_id;
                //this.PageCustomerServiceOperation.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/CustomerServiceOperation.aspx?nick_id=" + this.nick_id;
                //this.PagePRFlow.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/PRFlow.aspx?nick_id=" + this.nick_id;
                //this.PagePRSingleProduct.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/PRSingleProduct.aspx?nick_id=" + this.nick_id;
                //this.PagePRNickManageInfoNewDetail.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/PRNickManageInfoNewDetail.aspx?nick_id=" + this.nick_id;
                //this.PagePRNickRefundStatistics.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/PRNickRefundStatistics.aspx?NickID=" + this.nick_id;
                //this.PageWithBrandsNick.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/WithBrandsNick.aspx";//同品牌数据分析
            }
        }

        public int nick_id
        {
            get
            {
                return CommonHelper.QueryStringInt("nick_id");
            }
        }

        public string Nick
        {
            get
            {
                return CommonHelper.QueryString("Nick");
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