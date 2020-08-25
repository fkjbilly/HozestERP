using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.Codes;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageApplication;

namespace HozestERP.Web.ManageBusiness
{
    public partial class CompanyOperationTab : BaseAdministrationPage, ISearchPage
    {
        public string TableList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CompanyOperationTab", "dataBind()", true);//ajax
            }
        }

        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
        }

        #endregion
    }
}