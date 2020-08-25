using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class ClaimOperation : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PageClaimInfo.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMClaimInfo.aspx";//理赔单管理 
                this.pageCliamAnalysisType.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMClaimAnalysisType.aspx"; //理赔单管理 - 理赔类型
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