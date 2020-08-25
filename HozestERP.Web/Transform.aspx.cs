using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;

using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.Web
{
    public partial class Transform : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
   
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            base.CustomerService.ChangePassWordHash();
            base.ShowMessage("密码已转换完成!");
        }



        public void SetTrigger()
        {
            
        }

        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            
        }
    }
}