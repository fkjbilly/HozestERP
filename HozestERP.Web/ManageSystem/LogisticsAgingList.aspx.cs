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
    public partial class LogisticsAgingList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
                btnAdd.OnClientClick = "return ShowWindowDetail('物流时效添加','" + CommonHelper.GetStoreLocation()
                   + "ManageSystem/LogisticsAgingAdd.aspx?Id=-1',390, 400, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";

                btnImport.OnClientClick = "return ShowWindowDetail('物流时效导入','" + CommonHelper.GetStoreLocation()
                   + "ManageSystem/ImportLogisticsAging.aspx',500, 290, this, function(){document.getElementById('"
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
            //始发城市
            string DepartureCity = this.txtDepartureCity.Text.Trim();
            //目的城市
            string DestinationCity = this.txtDestinationCity.Text.Trim();
            //途径城市
            string Pathway = this.txtPathway.Text.Trim();

            //根据项目名称和平台类型查询。
            var list = base.LogisticsAgingService.GetLogisticsAgingListByParam(DepartureCity, DestinationCity, Pathway);

            //分页
            var List = new PagedList<LogisticsAging>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
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
                var Info = e.Row.DataItem as LogisticsAging;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('物流时效编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageSystem/LogisticsAgingAdd.aspx?Id=" + Info.ID + "',390, 400, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }

            }
        }

        /// <summary>
        /// 删除行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("ToDelete"))
            {
                var Info = base.LogisticsAgingService.GetLogisticsAgingByID(Convert.ToInt32(e.CommandArgument));
                if (Info != null)//删除
                {
                    Info.IsEnabled = true;
                    Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateTime = DateTime.Now;
                    base.LogisticsAgingService.UpdateLogisticsAging(Info);

                    //始发城市
                    string DepartureCity = this.txtDepartureCity.Text.Trim();
                    //目的城市
                    string DestinationCity = this.txtDestinationCity.Text.Trim();
                    //途径城市
                    string Pathway = this.txtPathway.Text.Trim();

                    //根据项目名称和平台类型查询。
                    var list = base.LogisticsAgingService.GetLogisticsAgingListByParam(DepartureCity, DestinationCity, Pathway);
                    int rowscount = list.Count();//获取行数;
                    if (rowscount % this.Master.PageSize == 0)
                    {
                        this.BindGrid(this.Master.PageIndex - 1, this.Master.PageSize);
                    }
                    else
                    {
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    }

                    base.ShowMessage("操作成功！");
                }
            }
            #endregion
        }
    }
}