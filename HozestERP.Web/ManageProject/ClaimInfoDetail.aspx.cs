using System;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;
using System.Linq;
using System.Collections.Generic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Controls;
using System.Transactions;

namespace HozestERP.Web.ManageProject
{
    public partial class ClaimInfoDetail : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
            }
        }

        public string CustomerName(string customerID)
        {
            string name = "";
            var customer = base.CustomerInfoService.GetCustomerInfoByID(Convert.ToInt16(customerID));
            if (customer != null)
            {
                name = customer.FullName;
            }
            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var list = base.XMClaimInfoService.GetXMClaimInfoListByParm(this.RealName, this.OrderCode, this.ClaimRef, this.Begin, this.End, IsReturn, ProjectID, NickIDs, ClaimTypeID, IsConfirm);
            var pageList = new PagedList<HozestERP.BusinessLogic.ManageProject.XMClaimInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClaimInfo, pageList);
        }

        protected void grdvClaimInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as HozestERP.BusinessLogic.ManageProject.XMClaimInfo;
                ImageCheckBox imageIsComfirm = e.Row.FindControl("chkManagerIsAudit") as ImageCheckBox;
                ImageButton imgClaimDetail = e.Row.FindControl("imgClaimDetail") as ImageButton;
                if (imgClaimDetail != null)
                {
                    imgClaimDetail.OnClientClick = "return ShowWindowDetail('查看理赔单','" + CommonHelper.GetStoreLocation() +
        "ManageProject/XMClaimInfoAdd.aspx?Type=2"
          + "&&ClaimInfoID=" + info.Id
        + "',1200,500, this,null);";
                }
                bool isConfirm = true;
                var claimDetai = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(info.Id);
                if (claimDetai != null && claimDetai.Count > 0)
                {
                    foreach (XMClaimInfoDetail q in claimDetai)
                    {
                        if (!q.IsConfirm.Value)
                        {
                            isConfirm = false;
                        }
                    }
                }
                imageIsComfirm.Checked = isConfirm;
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

        public string RealName
        {
            get
            {
                return CommonHelper.QueryString("RealName");
            }
        }

        public string OrderCode
        {
            get
            {
                return CommonHelper.QueryString("OrderCode");
            }
        }

        public string ClaimRef
        {
            get
            {
                return CommonHelper.QueryString("ClaimRef");
            }
        }

        public string Begin
        {
            get
            {
                return CommonHelper.QueryString("Begin");
            }
        }

        public string End
        {
            get
            {
                return CommonHelper.QueryString("End");
            }
        }

        public int IsReturn
        {
            get
            {
                return CommonHelper.QueryStringInt("IsReturn");
            }
        }

        public int ProjectID
        {
            get
            {
                return CommonHelper.QueryStringInt("ProjectID");
            }
        }

        public string NickIDs
        {
            get
            {
                return CommonHelper.QueryString("NickIds");
            }
        }

        public int ClaimTypeID
        {
            get
            {
                return CommonHelper.QueryStringInt("ClaimTypeID");
            }
        }

        public int IsConfirm
        {
            get
            {
                return CommonHelper.QueryStringInt("IsConfirm");
            }
        }
    }
}