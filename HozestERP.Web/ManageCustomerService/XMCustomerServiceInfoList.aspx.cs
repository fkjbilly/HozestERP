using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Top.Api.Domain;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.Common;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Codes;
using System.Text.RegularExpressions;
using JdSdk.Domains;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using JdSdk.Domain;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Yhd.Api.Object;
using Yhd.Api;
using Yhd.Api.Request;
using Yhd.Api.Response;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMCustomerServiceInfoList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
            }

        }

        #region ISearchPage 成员
        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnSynchronousOrderData.UniqueID, this.Page);

        }
        public void Face_Init()
        {
            this.ddlRank.Items.Clear();
            var codePlatformTypeList = base.XMCustomerServiceLevelService.GetXMCustomerServiceLevelList("");
            this.ddlRank.DataSource = codePlatformTypeList;
            this.ddlRank.DataTextField = "RankName";
            this.ddlRank.DataValueField = "RankName";
            this.ddlRank.DataBind();
            this.ddlRank.Items.Insert(0, new ListItem("---所有---", ""));

            string DepCode = "QC1403-3,QC1403-4,QC1506-2,QC1403-1,QC1403-2,QC1506-1";
            this.ddlGroup.Items.Clear();
            var CoustomerServiceGroup = base.XMCustomerServiceLevelService.GetXMCoustomerServiceGroupList(DepCode);
            this.ddlGroup.DataSource = CoustomerServiceGroup;
            this.ddlGroup.DataTextField = "DepName";
            this.ddlGroup.DataValueField = "DepartmentID";
            this.ddlGroup.DataBind();
            this.ddlGroup.Items.Insert(0, new ListItem("---所有---", "-1"));
        }
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            //组别
            int GroupID = int.Parse(this.ddlGroup.SelectedValue);
            //姓名
            string Name = this.ddlName.Text.ToString();
            //级别
            string Rank = this.ddlRank.Text.ToString();
            //客服部DepCode
            string DepCode = "QC1403-3,QC1403-4,QC1506-2,QC1403-1,QC1403-2,QC1506-1";

            //根据项目名称和平台类型查询
            var xMProjectList = base.CustomerInfoService.GetCustomerServiceInfoList(GroupID, Name, DepCode, Rank);

            //分页
            var xMProjectPageList = new PagedList<XMCustomerServiceWangNo>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            for (int i = 0; i < xMProjectPageList.Count; i++)
            {
                int CustomerID = (int)xMProjectPageList[i].CustomerID;
                var xMWangNoList = base.XMCustomerWangNoService.GetXMCustomerWangNoByCustomerID(CustomerID);
                string wangNo = "";
                string str = "";
                int no = 1;
                for (int j = 0; j < xMWangNoList.Count; j++)
                {
                    string WangNoName = base.XMCustomerWangNoService.GetXMCustomerWangNoName((int)xMWangNoList[j].WangNoID).WangNo;
                    if (str == "")
                    {
                        str = "<td style='width: 200px;text-align:center;'>" + WangNoName + "</td>";
                    }
                    else
                    {
                        str = str + "<td style='width: 200px;;text-align:center;'>" + WangNoName + "</td>";
                    }
                    if (no == 5 || j == xMWangNoList.Count - 1)
                    {
                        wangNo = wangNo + "<tr>" + str + "</tr>";
                        str = "";
                        no = 0;
                    }
                    no++;
                }
                xMProjectPageList[i].WangNo = wangNo;
            }
            this.Master.BindData(this.grdvClients, xMProjectPageList, paramPageSize + 1);
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
        /// 更新旺旺号
        /// </summary>
        protected void btnUpdateWaqngNo_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 选择旺旺号
        /// </summary>
        protected void imgBtnDistribution_Click(object sender, EventArgs e)
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
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CustomerWangNoOpen", "<script>CustomerWangNoOpen();</script>");

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
                var xMScalpingApplication = e.Row.DataItem as XMCustomerServiceWangNo;
                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnDistribution") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('客服与旺旺关系管理','" + CommonHelper.GetStoreLocation() + "ManageCustomerService/XMCustomerServiceWangNoList.aspx?CustomerID = " + xMScalpingApplication.CustomerID + "'"//&PageID = XMCustomerServiceInfoList'"
                        + ",930, 470, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";
                }

            }

            if (e.Row.RowState == DataControlRowState.Edit ||
                 e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                //项目名称
                DropDownList ddllist = (DropDownList)e.Row.FindControl("ddlRankList");
                ddllist.Items.Clear();
                //var itemList = base.XMProjectService.GetXMProjectList();

                var codePlatformTypeList = base.XMCustomerServiceLevelService.GetXMCustomerServiceLevelList("");
                ddllist.DataSource = codePlatformTypeList;
                ddllist.DataTextField = "RankName";
                ddllist.DataValueField = "ID";
                ddllist.DataBind();
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
            if (e.CommandName.Equals("Delete"))
            {
                var XMCustomerRankList = base.XMCustomerRankService.GetXMCustomerRankByCustomerID(Convert.ToInt32(e.CommandArgument));
                var XMCustomerWangNoList = base.XMCustomerWangNoService.GetXMCustomerWangNoByCustomerID(Convert.ToInt32(e.CommandArgument));
                if (XMCustomerRankList != null)//删除客服等级
                {
                    XMCustomerRankList.IsEnabled = true;
                    XMCustomerRankList.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    XMCustomerRankList.UpdateTime = DateTime.Now;
                    base.XMCustomerRankService.UpdateXMCustomerRank(XMCustomerRankList);
                }
                if (XMCustomerWangNoList != null)//删除客服旺旺号
                {
                    for (int i = 0; i < XMCustomerWangNoList.Count; i++)
                    {
                        XMCustomerWangNoList[i].IsEnabled = true;
                        XMCustomerWangNoList[i].UpdatorID = HozestERPContext.Current.User.CustomerID;
                        XMCustomerWangNoList[i].UpdateTime = DateTime.Now;
                        base.XMCustomerWangNoService.UpdateXMCustomerWangNo(XMCustomerWangNoList[i]);
                    }
                }
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功.");
            }
            #endregion
        }
        /// <summary>
        /// 删除行数据之前执行的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        /// <summary>
        /// 编辑行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //组别
            int GroupID = int.Parse(this.ddlGroup.SelectedValue);
            //姓名
            string Name = this.ddlName.Text.ToString();
            //级别
            string Rank = this.ddlRank.Text.ToString();
            //客服部DepCode
            string DepCode = "QC1403-3,QC1403-4,QC1506-2,QC1403-1,QC1403-2,QC1506-1";

            this.grdvClients.EditIndex = e.NewEditIndex;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            int Id = 0;
            int.TryParse(this.grdvClients.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
            var row = this.grdvClients.Rows[e.NewEditIndex];

            var xMProjectList = base.CustomerInfoService.GetCustomerServiceInfoListByID(GroupID, Name, DepCode, Rank, Id);
            if (xMProjectList != null)
            {
                DropDownList ddlRankList = (DropDownList)row.FindControl("ddlRankList");
                if (xMProjectList.RankID != null)
                {
                    ddlRankList.SelectedValue = xMProjectList.RankID.Value.ToString();
                }

                TextBox txtPaymentAmount = (TextBox)row.FindControl("txtPaymentAmount");
                if (xMProjectList.PaymentAmount != null)
                {
                    txtPaymentAmount.Text = xMProjectList.PaymentAmount.ToString();
                }
                else
                {
                    txtPaymentAmount.Text = "0";
                }
            }
        }
        /// <summary>
        /// 更新行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int nickId = 0;
            int.TryParse(this.grdvClients.DataKeys[e.RowIndex].Value.ToString(), out nickId);
            var row = this.grdvClients.Rows[e.RowIndex];
            var ddlRankList = row.FindControl("ddlRankList") as DropDownList;
            var txtPaymentAmount = row.FindControl("txtPaymentAmount") as TextBox;
            var nick = base.XMCustomerRankService.GetXMCustomerRankByCustomerID(nickId);
            decimal PaymentAmount = 0;
            decimal.TryParse(txtPaymentAmount.Text.Trim(), out PaymentAmount);

            if (nick != null)
            {
                XMCustomerRank CustomerRank = base.XMCustomerRankService.GetXMCustomerRankByCustomerID(nickId);
                CustomerRank.CustomerID = nickId;
                CustomerRank.PaymentAmount = PaymentAmount;
                CustomerRank.RankID = int.Parse(ddlRankList.SelectedValue.ToString());
                CustomerRank.UpdatorID = HozestERPContext.Current.User.CustomerID;
                CustomerRank.UpdateTime = DateTime.Now;
                CustomerRank.IsEnabled = false;
                base.XMCustomerRankService.UpdateXMCustomerRank(CustomerRank);
            }
            else
            {
                XMCustomerRank CustomerRank = new XMCustomerRank();
                CustomerRank.CustomerID = nickId;
                CustomerRank.PaymentAmount = PaymentAmount;
                CustomerRank.RankID = int.Parse(ddlRankList.SelectedValue.ToString());
                CustomerRank.UpdatorID = HozestERPContext.Current.User.CustomerID;
                CustomerRank.UpdateTime = DateTime.Now;
                CustomerRank.IsEnabled = false;
                CustomerRank.CreatorID = HozestERPContext.Current.User.CustomerID;
                CustomerRank.CreateTime = DateTime.Now;
                base.XMCustomerRankService.InsertXMCustomerRank(CustomerRank);
            }
            base.ShowMessage("保存成功!");
            this.grdvClients.EditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }
        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.grdvClients.EditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }
    }
}