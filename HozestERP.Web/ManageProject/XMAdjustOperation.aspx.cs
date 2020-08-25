using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMAdjustOperation : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("PageFactroyPrice", "ManageProject.XMAdjustOperation.FactroyPrice");//调整出厂价
                buttons.Add("PagePurchasePrice", "ManageProject.XMAdjustOperation.PurchasePrice");//调整采购单价
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageFactroyPrice.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMAdjustFactroyPrice.aspx?MerchantCode=" + MerchantCode;//调整出厂价
                this.PagePurchasePrice.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMAdjustPurchasePrice.aspx?MerchantCode=" + MerchantCode;//调整采购单价
            }
        }

        public string MerchantCode
        {
            get
            {
                return CommonHelper.QueryString("MerchantCode");
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