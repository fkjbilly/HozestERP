using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Audit;

namespace HozestERP.Web.ManageSystem
{
    public partial class Logs : BaseAdministrationPage,ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillDropDowns();
                this.BindGrid(1, 10);
            }
        }

        protected void FillDropDowns()
        {
            ddlLogType.Items.Clear();

            var allItem = new ListItem("--所有--", "0");
            ddlLogType.Items.Add(allItem);

            CommonHelper.FillDropDownWithEnum(this.ddlLogType, typeof(LogTypeEnum), false);
        }

        #region ISearchPage 成员

        /// <summary>
        /// 添加事件
        /// </summary>
        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnDel.UniqueID, this.Page);
            this.Master.SetTrigger(this.ddlLogType.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitle("参数设置 > 查看活动日志");
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            int logTypeId = int.Parse(this.ddlLogType.SelectedItem.Value);
            var logList = base.LogService.GetAllLogs(null, null, string.Empty, logTypeId, paramPageIndex, paramPageSize);
            this.Master.BindData<Log>(this.grdvMessage, logList);
        }

        #endregion

        /// <summary>
        /// 判断当前页面是否有权限
        /// </summary>
        /// <returns></returns>
        protected override bool ValidatePageSecurity()
        {
            return base.ValidatePageSecurity();
        }


        protected void grdvMessage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgbtnDetail1 = (ImageButton)e.Row.Cells[4].FindControl("imgbtnDetail1");
                if (imgbtnDetail1 != null)
                {
                    imgbtnDetail1.Attributes.Add("onclick", "return ShowDetail('LogDetails.aspx?LogID=" + imgbtnDetail1.CommandArgument.ToString() + "');");
                }          
            }
        }

        protected void ddlLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid(1, 10);
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            this.LogService.ClearLog();
            this.BindGrid(1, 10);
        }
    }
}