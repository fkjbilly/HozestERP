using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageSystem
{
    public partial class ZMtypelist : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
                btnAdd.OnClientClick = "return ShowWindowDetail('安装类型添加','" + CommonHelper.GetStoreLocation()
                   + "ManageSystem/ZMtypeAdd.aspx?Id=-1',390, 400, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
            }
        }

        #region ISearchPage 成员
        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }
        public void Face_Init()
        {
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            var list = base.XMTypeTestService.GetXMTypeTestList();

            //分页

            var List = new PagedList<XMTypeTest>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, List, paramPageSize + 1);
        }
        #endregion

        /// <summary>
        /// 条件查询
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
            this.BindGrid(Master.PageIndex, Master.PageSize);
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
                var Info = e.Row.DataItem as XMTypeTest;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('安装类型编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageSystem/ZMtypeAdd.aspx?Id=" + Info.ID + "',390, 400, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }

            }
        }

        /// <summary>
        /// 删除行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = 0;
            if (int.TryParse(this.grdvClients.DataKeys[e.RowIndex].Value.ToString(), out ID))
            {
                var Info = base.XMTypeTestService.GetXMTypeTestByID(ID);
                if (Info != null)
                {
                    base.XMTypeTestService.DeleteXMTypeTest(ID);
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("删除成功！");
            }
        }
    }
}