using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{ 
    public partial class QuestionOperation : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("PageQuestion", "ManageProject.Question.PageView");//问题反馈
                buttons.Add("pageQuestionDeal", "ManageProject.QuestionDeal.PageView");//问题处理 
                buttons.Add("pageDataAnalysis", "ManageProject.XMDataAnalysisQuestion.PageView");//问题数据分析-客服
                buttons.Add("pageDataAnalysisType", "ManageProject.XMDataAnalysisQuestionType.PageView");//问题数据分析-问题类型
                return buttons;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageQuestion.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/Question.aspx?QuestionType=Feedback";//问题反馈
                this.pageQuestionDeal.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/Question.aspx?QuestionType=DealWith"; //问题处理
                this.pageDataAnalysis.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMDataAnalysisQuestion.aspx"; //问题数据分析-客服
                this.pageDataAnalysisType.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMDataAnalysisQuestionType.aspx"; //问题数据分析-问题类型
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