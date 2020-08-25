using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageBusiness;

namespace HozestERP.Web.ManageBusiness
{
    public partial class OperatingResultsOperation : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageCreate.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/OperatingResults.aspx?Type=1";//创单时间
                this.PagePay.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/OperatingResults.aspx?Type=2";//付款时间
                this.PageDeliver.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/OperatingResults.aspx?Type=3";//发货时间
                this.PageComplete.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/OperatingResults.aspx?Type=4";//交易完成时间
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