using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using System.Transactions;
using HozestERP.BusinessLogic.Customers;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageBusiness;

namespace HozestERP.Web.ManageBusiness
{
    public partial class NickMonthlyTargetList : BaseAdministrationPage, ISearchPage
    {

        /// <summary>
        /// 权限控制
        /// </summary>
        //protected override Dictionary<string, string> ButtonSecuritys
        //{
        //    get
        //    {
        //        Dictionary<string, string> buttons = new Dictionary<string, string>();
        //        buttons.Add("btnSearch", "PRGoalSettingNew.Search");//查询
        //        buttons.Add("imgBtnEdit", "PRGoalSettingNew.Edit");//编辑
        //        buttons.Add("imgBtnDelete", "PRGoalSettingNew.Delete");//删除
        //        buttons.Add("imgBtnUpdate", "PRGoalSettingNew.Save");//保存
        //        buttons.Add("imgBtnCancel", "PRGoalSettingNew.Cancel");// 取消
        //        buttons.Add("imgBtnSingleTargetSetting", "PRGoalSettingNew.SingleTargetSetting"); //产品目标
        //        buttons.Add("btnIsAudit", "PRGoalSettingNew.IsAudit");//审核
        //        buttons.Add("btnIsAuditFalse", "PRGoalSettingNew.IsAuditFalse");//反审核
        //        buttons.Add("btnPRGoalSettingTotalAdd", "PRGoalSettingTotalAdd.LogAdd");//新增总目标
        //        return buttons;
        //    }
        //}



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                this.btnNickMonthlyTargetAdd.OnClientClick = "return ShowWindowDetail('月度目标录入','" + CommonHelper.GetStoreLocation() +
            "ManageBusiness/NickMonthlyTargetAdd.aspx?NickId=" + this.NickID + "&&Type=0"
             + "&PlatformTypeId=" + this.PlatformTypeId
            + "',900,500, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                BindGrid(1, Master.PageSize);
            }
        }

        public bool getIsAudit(int id)
        {
            bool isAudit = false;
            var Info = base.XMNickMonthlyTargetService.GetXMNickMonthlyTargetByID(id);
            if (Info != null)
            {
                isAudit = (bool)Info.IsAudit;
            }
            return isAudit;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

        }


        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMNickMonthlyTarget;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;

                if (imgBtnEdit != null)
                {

                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('店铺月度目标值修改','" + CommonHelper.GetStoreLocation() +
        "ManageBusiness/NickMonthlyTargetAdd.aspx?NickId=" + this.NickID + "&&Type=1"
         + "&PlatformTypeId=" + this.PlatformTypeId + "&&Id=" + info.ID
        + "',900,500, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                }
            }
        }


        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    var Info = base.XMNickMonthlyTargetService.GetXMNickMonthlyTargetByID(Convert.ToInt16(id));
                    if ((bool)!Info.IsAudit)
                    {
                        if (Info != null)
                        {
                            Info.IsEnable = true;
                            Info.Updater = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.XMNickMonthlyTargetService.UpdateXMNickMonthlyTarget(Info);
                            base.ShowMessage("操作成功！");
                        }
                        else
                        {
                            base.ShowMessage("未查到该数据！");
                        }
                    }
                    else
                    {
                        base.ShowMessage("已审核，不能删除！");
                    }
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                }
            }
            #endregion
        }


        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAudit_Click(object sender, EventArgs e)
        {

            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.gvNickTitle);


            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in customerInfoIDs)
                {
                    var Product = base.XMNickMonthlyTargetService.GetXMNickMonthlyTargetByID(Convert.ToInt32(ID));
                    if (Product != null)
                    {
                        Product.IsAudit = true;
                        Product.Updater = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        Product.UpdateDate = DateTime.Now;
                        base.XMNickMonthlyTargetService.UpdateXMNickMonthlyTarget(Product);
                    }

                }

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功成功.");
            }
        }


        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAuditFalse_Click(object sender, EventArgs e)
        {
            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.gvNickTitle);


            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in customerInfoIDs)
                {
                    var Product = base.XMNickMonthlyTargetService.GetXMNickMonthlyTargetByID(Convert.ToInt32(ID));
                    if (Product != null)
                    {
                        Product.IsAudit = false;
                        Product.Updater = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        Product.UpdateDate = DateTime.Now;
                        base.XMNickMonthlyTargetService.UpdateXMNickMonthlyTarget(Product);
                    }

                }

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功成功.");
            }
        }


        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string Year = this.ddlYear.SelectedValue;//年
            var list = base.XMNickMonthlyTargetService.GetXMNickMonthlyTargetListByYear(Convert.ToInt16(Year), this.NickID);
            var pageList = new PagedList<XMNickMonthlyTarget>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            this.Master.BindData(this.gvNickTitle, pageList);
        }


        //public bool Delete(int ID)
        //{
        //    var Info = base.XMNickMonthlyTargetService.GetXMNickMonthlyTargetByID(ID);
        //    if ((bool)!Info.IsAudit)
        //    {
        //        if (Info != null)
        //        {
        //            Info.IsEnable = true;
        //            Info.Updater = HozestERPContext.Current.User.CustomerID;
        //            Info.UpdateDate = DateTime.Now;
        //            base.XMNickMonthlyTargetService.UpdateXMNickMonthlyTarget(Info);
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        base.ShowMessage("已审核，不能删除！");
        //        return false;
        //    }
        //}


        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        #endregion


        protected string selectNickName(string nickId)
        {
            string nickName = "";
            if (!string.IsNullOrEmpty(nickId))
            {
                var nickDetail = base.XMNickService.GetXMNickByID(Convert.ToInt16(nickId));
                nickName = nickDetail.nick;
            }
            return nickName;
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

        /// <summary>
        /// 平台类型Id
        /// </summary>
        public int PlatformTypeId
        {
            get
            {
                return CommonHelper.QueryStringInt("PlatformTypeId");
            }
        }
    }
}