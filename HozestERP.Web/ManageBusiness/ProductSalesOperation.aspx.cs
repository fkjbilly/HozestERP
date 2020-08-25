using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageBusiness
{
    public partial class ProductSalesOperation : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ProductSales.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/ProductSales.aspx";//产品销量统计
                this.WarehouseSales.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/WarehouseSales.aspx";//仓库销量统计
                this.NotShippedSales.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/NotShippedSales.aspx";//仓库销量统计
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