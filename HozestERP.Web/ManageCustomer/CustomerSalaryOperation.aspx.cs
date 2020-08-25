using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageCustomer
{
    public partial class CustomerSalaryOperation : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("PageCustomerSalary", "ManageCustomer.CustomerSalary.PageView");//人员薪资
                return buttons;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageCustomerSalary.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageCustomer/CustomerSalary.aspx";//人员薪资
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