using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using JdSdk.Domain;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageCustomerService;
using System.Data;
using HozestERP.Common;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class ChatRecordManage : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindGrid();
                this.BindGrid(1, Master.PageSize);
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
            var Waiter = this.txtSearchWaiter.Text.Trim();
            var Customer = this.txtSearchCustomer.Text.Trim();
            var KFChatLog = base.KFChatLogService.GetKFChatLogList(Customer, Waiter).GroupBy(x => new { x.Waiter, x.Customer }).Select(x => x.First()).ToList();
            this.Master.BindData(this.gvContent, new PagedList<KFChatLog>(KFChatLog, paramPageIndex, paramPageSize, "", ""));
        }

        //private void BindGrid()
        //{
        //    this.BindGrid(1, this.Master.PageSize);
        //}
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        //隐藏行绑定数据
        protected void gvContent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((GridView)e.Row.FindControl("gvContent1") != null)
                {
                    GridView gvContent1 = (GridView)e.Row.FindControl("gvContent1");
                    var val = (KFChatLog)e.Row.DataItem;
                    var logList = base.KFChatLogService.GetKFChatLogList(val.Customer, val.Waiter);
                    gvContent1.DataSource = logList;
                    gvContent1.DataBind();
                    //this.Master.BindData((GridView)e.Row.FindControl("gvContent1"), new PagedList<KFChatLog>(logList, 1000, 1000, "", ""));
                }
            }
        }

        protected void gvContent1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Attributes.Add("style", "word-break :break-all ; word-wrap:break-word"); 
                var val = (KFChatLog)e.Row.DataItem;
                Label lb = (Label)e.Row.FindControl("lblContent");
                string FinContent = val.Content.Replace("/></a>"," style=\" width:800px;\" /></a>");
                if (val.WaiterSend == true)
                {
                    //客服发送
                    lb.Text = val.Waiter + "：  " + val.Content;
                }
                else
                { 
                    //顾客发送
                    lb.Text = val.Customer + "：  " + val.Content;
                }
            }
        }

        protected string ReturnChannel(string channel)
        {
            switch (channel)
            { 
                case "11":
                    return "客户发送的普通消息";
                case "12":
                    return "客户接收到的转接消息";
                case "13":
                    return "客户发送的留言消息";
                case "14":
                    return "app-sdk客户普通消息 - 在线咨询";
                case "15":
                    return "app-sdk客户普通消息 - 离线咨询";
                case "16":
                    return "app-sdk客户普通消息 - 语音消息";
                case "21":
                    return "客服发送的普通消息";
                case "22":
                    return "客服发送的自动回复";
                case "23":
                    return "客服快捷回复";
                case "24":
                    return "发给发起转接客服的消息";
                case "25":
                    return "发给被转接客服的消息";
                case "26":
                    return "客服发送的留言消息";
                case "27":
                    return "客服的欢迎语";
                case "28":
                    return "客服发送的离线消息";
                case "29":
                    return "客服之间对话";
                case "31":
                    return "客服邀评信息";
                default:
                    return "";
            }
        }
    }
}