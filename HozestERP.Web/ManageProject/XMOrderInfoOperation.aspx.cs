using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderInfoOperation : BaseAdministrationPage, ISearchPage
    {
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("PageXMOrderInfoList", "ManageProject.XMOrderInfoList.PageView"); //订单管理
                buttons.Add("PageXMOrderInfoProductDetailsList", "ManageProject.XMOrderInfoProductDetailsList.PageView"); //详细信息
                buttons.Add("PageXM_LogisticsInfoList", "ManageProject.XMOrderInfoProductDetailsList.PageView"); //物流跟踪信息
                //buttons.Add("PageXMOrderInfoRemarkList", "ManageProject.XMOrderInfoRemarkList.PageView"); //备注信息
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string OrderID = CommonHelper.QueryString("ID");
                string IsCM = CommonHelper.QueryString("IsCM");
                this.PageXMOrderInfoList.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMOrderInfoEdit.aspx?ID=" + OrderID + "&IsCM=" + IsCM;//基础信息
                this.PageXMOrderInfoProductDetailsList.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMOrderInfoProductDetailsEdit.aspx?ID=" + OrderID + "&IsCM=" + IsCM;//详细信息
                this.PageXM_LogisticsInfoList.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMLogisticsInfoList.aspx?ID=" + OrderID;//物流信息
                this.PageXMLogisticsFeeDetail.AutoLoad.Url= CommonHelper.GetStoreLocation()+ "ManageProject/XMLogisticsFeeDetail.aspx?ID=" + OrderID;
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