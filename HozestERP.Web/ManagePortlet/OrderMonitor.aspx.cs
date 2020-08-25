using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using System.Text;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManagePortlet
{
    public partial class OrderMonitor : BaseAdministrationPage, ISearchPage
    {
        public string str = "";
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            
        }

        public void Face_Init()
        {

        }

        public void SetTrigger()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //DataBind();
        }

        public void DataBind()
        {
            StringBuilder sb = new StringBuilder();
            List<XMProject> projectList = null;

            var data = XMOrderInfoService.getUnusualOrder();

            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 682 || HozestERPContext.Current.User.CustomerID == 670)
            {
                projectList = base.XMProjectService.GetXMProjectList();
            }
            else
            {
                projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
            }

            foreach (var item in projectList)
            {
                int count = data.Where(a => a.ProjectId == item.Id).Count();
                if(count!=0)
                {
                    //sb.Append("<label>"+ item .ProjectName+"异常订单："+ count + "</label><button type='button' value='test'>详情</button></br>");
                    sb.Append("<input type=\"image\" name=\"setBarCode\" id=\"setBarCodes\"  title=\"查看条形码\" src=\"../App_Themes/Blue/Image/ButtonImages/meeting.gif\"  onclick=\"return ShowWindowDetail('查看商品条形码','" + CommonHelper.GetStoreLocation() + "ManageInventory/ProductBarCodeList.aspx?Status=Storage&&ID=" + 0 + "',400,600, this);\"/>");
                }
            }

            str = "";
        }
    }
}