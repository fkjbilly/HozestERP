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
    public partial class BusinessDataOtherOperation : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageBusinessDataOtherF.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/BusinessDataOther.aspx?Type=0";//财务审核
                this.PageBusinessDataOtherC.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/BusinessDataOther.aspx?Type=1";//公司审核
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