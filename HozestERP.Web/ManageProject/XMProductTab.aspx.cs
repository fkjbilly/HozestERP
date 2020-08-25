using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMProductTab : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("PageProductManage", "ManageProject.ProductManage.PageView");//产品管理
                buttons.Add("pageCombinationManage", "ManageProject.CombinationManage.PageView");//组合管理
                return buttons;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageQuestion.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMProductManage.aspx?NickId=-1";//产品管理
                this.pageQuestionDeal.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMCombinationManage.aspx?NickId=-1"; //组合管理
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