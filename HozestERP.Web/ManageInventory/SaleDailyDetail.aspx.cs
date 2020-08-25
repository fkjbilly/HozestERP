using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.Common;

namespace HozestERP.Web.ManageInventory
{
    public partial class SaleDailyDetail : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(1, Master.PageSize);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var activities = base.XMActivityService.GetXMActivityById(this.Id);
            if (activities != null)
            {
                int nickID = activities.NickId == null ? -1 : activities.NickId.Value;
                var saleDailyInfo = base.XMDailySaleInfoService.GetXMDailySaleInfoByParm(activities.PlatformMerchantCode, activities.ActivityDate, activities.ProjectId.Value, nickID);
                var pageList = new PagedList<HozestERP.BusinessLogic.ManageInventory.XMDailySaleInfo>(saleDailyInfo, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.grdvDailySaleInfo, pageList);
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

        #endregion


    }
}