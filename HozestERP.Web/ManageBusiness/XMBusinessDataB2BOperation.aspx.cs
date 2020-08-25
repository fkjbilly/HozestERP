using System;
using HozestERP.Common.Utils;
namespace HozestERP.Web.ManageBusiness
{
    public partial class XMBusinessDataB2BOperation : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //B2B管理
                pageB2BMamager.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageFinance/XMFinancialCapitalFlowList.aspx?DepartmentID=6";
                //B2B管理数据分析-业务员
                pageB2BDataBySalePerson.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/XMBusinessDataSalePerson.aspx?DepartmentID=6";
                //2B管理数据分析- 业务类型
                PageAnalysis.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/XMBusinessDataB2BServiceType.aspx?DepartmentID=6";
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