using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProductionOrder
{
    public partial class XMProductionOrderOperation : BaseAdministrationPage, ISearchPage
    {
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("PageXMProductionOrderInfoList", "ManageProductionOrder.XMProductionOrderList.PageView"); //生产单管理
                buttons.Add("PageXMProductionOrderInfoProductDetailsList", "ManageProductionOrder.XMProductionOrderProductDetailsList.PageView"); //详细信息
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ID = CommonHelper.QueryString("ID");
                this.PageXMProductionOrderInfoList.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProductionOrder/XMProductionOrderInfoEdit.aspx?ID=" + ID;//基础信息
                this.PageXMOrderInfoProductDetailsList.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProductionOrder/XMProductionOrderDetailEdit.aspx?ID=" + ID;//详细信息
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