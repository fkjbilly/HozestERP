using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageBusiness
{
    public partial class XMNickManageOperatation : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!string.IsNullOrEmpty(this.NickID.ToString()))
                //{
                //    XMNick nick = base.XMNickService.GetXMNickByID(this.NickID);
                //}
                if (!string.IsNullOrEmpty(this.NickID.ToString()) && this.NickID != 29)
                {
                    PageBusinessDataOtherC.Visible = false;
                }
                this.PageBusinessDataOtherF.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/NickMonthlyTargetList.aspx?NickId=" + this.NickID;//目标值设定
                this.PageBusinessDataOtherD.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageProject/XMNickAdvertisingCost.aspx?NickId=" + this.NickID;//广告费用设定
                this.PageBusinessDataOtherC.AutoLoad.Url = CommonHelper.GetStoreLocation() + "ManageBusiness/XMNickAchieveValueList.aspx?NickId=" + this.NickID;//达成值设定
            }
        }


        public void SetTrigger()
        {
            throw new NotImplementedException();
        }

        public void Face_Init()
        {
         
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 店铺id
        /// </summary>
        public int NickID
        {
            get
            {
                return CommonHelper.QueryStringInt("NickId");
            }
        }
    }
}