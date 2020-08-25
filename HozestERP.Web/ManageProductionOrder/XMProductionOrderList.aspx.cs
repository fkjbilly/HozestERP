using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageProductionOrder;
using HozestERP.Common;
using HozestERP.Common.Utils;
using System.Transactions;
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.Web.ManageProductionOrder
{
    public partial class XMProductionOrderList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //批量排单
                this.btnBatchSingleRow.OnClientClick = "return CkeckShowWindowDetail(SaveOrderInfoIDs(),'批量排单','" + CommonHelper.GetStoreLocation() +
           "ManageProject/XMOrderInfoManualPlanBill.aspx',300,170, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                //生产单号导入
                this.btnImportProductionNumber.OnClientClick = "return ShowWindowDetail('生产单号导入','" + CommonHelper.GetStoreLocation() +
            "ManageProductionOrder/ImportProductionNumber.aspx',500,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
                {
                    List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                    if (XMProjectList.Count > 0)
                    {
                        this.ddXMProject.Items.Clear();
                        this.ddXMProject.Items.Clear();
                        this.ddXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                    }
                    this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                    this.ddXMProject.Items[0].Selected = true;
                }
                else
                {
                    this.BindddXMProject();//项目
                }

                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                this.BindGrid(1, Master.PageSize);
            }
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                //.Where(c => c.ProjectTypeId == 362)

                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    this.ddXMProject.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                }
                if (projectList.Count() > 0)
                {
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                }
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion

            //this.ddXMProject.Items.Clear();
            //var projectList = base.XMProjectService.GetXMProjectList();
            //this.ddXMProject.DataSource = projectList;
            //this.ddXMProject.DataTextField = "ProjectName";
            //this.ddXMProject.DataValueField = "Id";
            //this.ddXMProject.DataBind();
            //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue));
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    this.ddlNick.DataSource = nickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    //其他
                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue), HozestERPContext.Current.User.CustomerID, 0);
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    if (nickList.Count() == 0)
                    {
                        this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                    }
                    else
                    {
                        if (nickList.Count() > 0)
                        {
                            this.ddlNick.DataSource = nickList;
                            this.ddlNick.DataTextField = "nick";
                            this.ddlNick.DataValueField = "nick_id";
                            this.ddlNick.DataBind();
                        }
                        this.ddlNick.Items.Insert(0, new ListItem("---所有---", "99"));
                    }
                }
                //this.ddlNick.Items.Clear();
                //var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue));
                //this.ddlNick.DataSource = nickList;
                //this.ddlNick.DataTextField = "nick";
                //this.ddlNick.DataValueField = "nick_id";
                //this.ddlNick.DataBind();
                //this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
            var NickId = Convert.ToInt32(this.ddlNick.SelectedValue);

            //  生产单状态
            int OrderStatusId = Convert.ToInt16(this.ddOrderStatusId.SelectedValue.Trim());
            //平台类型Id
            int PlatformTypeId = Convert.ToInt32(this.ddPlatformTypeId.SelectedValue.ToString());
            //预计入库时间
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            DateTime date = DateTime.Now;
            if (Begin != "" || End != "")
            {
                if (Begin == "" || End == "" || !DateTime.TryParse(Begin, out date) || !DateTime.TryParse(End, out date))
                {
                    base.ShowMessage("日期格式不正确！");
                    return;
                }
            }
            if (End != "")
            {
                End = DateTime.Parse(End).AddDays(1).ToString("yyyy-MM-dd");
            }
            //网名
            string WantID = this.txtWantID.Text.Trim();
            //排单
            int SingleRow = int.Parse(this.ddlSingleRow.SelectedValue);
            int status = int.Parse(this.ddlStorageStatus.SelectedValue);
            //手机号码
            string Mobile = this.txtMobile.Text.Trim();
            //地址
            string Address = this.txtAddress.Text.Trim();
            //产品编码
            string ManufacturersCode = this.txtManufacturersCode.Text.Trim();
            var productionOrderList = base.XMProductionOrderService.GetXMProductionOrderInfoListSearch(xMProjectId, NickId, OrderStatusId, PlatformTypeId, Begin, End, WantID, SingleRow, Mobile, Address, ManufacturersCode, status);
            var pageList = new PagedList<XMProductionOrder>(productionOrderList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, pageList);
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
        /// 批量入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStorage_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdvClients);
                if (customerInfoIDs.Count <= 0)
                {
                    base.ShowMessage("你没有选择任何记录");
                    return;
                }
                else
                {
                    foreach (int ID in customerInfoIDs)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            var productionOrderInfo = base.XMProductionOrderService.GetXMProductionOrderById(ID);
                            if (productionOrderInfo != null)
                            {
                                productionOrderInfo.Status = 1004;  //已入库
                                productionOrderInfo.UpdateDate = DateTime.Now;
                                productionOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMProductionOrderService.UpdateXMProductionOrder(productionOrderInfo);
                                var productionOrderDetails = base.XMProductionOrderDetailsService.GetXMProductionOrderDetailsListByProductionOrderID(ID);
                                if (productionOrderDetails != null && productionOrderDetails.Count > 0)
                                {
                                    foreach (XMProductionOrderDetails parm in productionOrderDetails)
                                    {
                                        parm.Status = true;
                                        parm.UpdateDate = DateTime.Now;
                                        parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMProductionOrderDetailsService.UpdateXMProductionOrderDetails(parm);
                                    }
                                }
                            }
                            scope.Complete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.ShowMessage("错误信息：" + ex.Message);
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                #region 删除
                if (e.CommandName.Equals("XMProductionOrderInfoDelete"))
                {
                    var xMProductionOrderInfo = base.XMProductionOrderService.GetXMProductionOrderById(Convert.ToInt32(e.CommandArgument));

                    if (xMProductionOrderInfo != null)//删除
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            xMProductionOrderInfo.IsEnable = true;
                            xMProductionOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            xMProductionOrderInfo.UpdateDate = DateTime.Now;
                            base.XMProductionOrderService.UpdateXMProductionOrder(xMProductionOrderInfo);
                            var xMProductionOrderDetails = base.XMProductionOrderDetailsService.GetXMProductionOrderDetailsListByProductionOrderID(xMProductionOrderInfo.Id);
                            if (xMProductionOrderDetails != null && xMProductionOrderDetails.Count > 0)
                            {
                                foreach (XMProductionOrderDetails parm in xMProductionOrderDetails)
                                {
                                    parm.IsEnable = true;
                                    parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    parm.UpdateDate = DateTime.Now;
                                    base.XMProductionOrderDetailsService.UpdateXMProductionOrderDetails(parm);
                                }
                            }
                            scope.Complete();
                        }
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                        base.ShowMessage("操作成功.");
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }
        }

        /// <summary>
        /// 判断是否排单
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        protected int IsSingleRow(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                var productionOrderInfo = base.XMProductionOrderService.GetXMProductionOrderById(int.Parse(ID));
                if (productionOrderInfo != null)
                {
                    if (productionOrderInfo.SingleRowStatus != null)
                    {
                        if (productionOrderInfo.SingleRowStatus == 0 || productionOrderInfo.SingleRowStatus == 2)
                        {
                            return 0;
                        }
                        else if (productionOrderInfo.SingleRowStatus == 1)
                        {
                            return 1;
                        }
                    }
                }
            }
            return 0;//false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMProductionOrder;
                Literal lblStorageStatus = e.Row.FindControl("lblStorageStatus") as Literal;
                switch (info.Status)
                {
                    case 1000:
                        lblStorageStatus.Text = "未入库";
                        break;
                    case 1002:
                        lblStorageStatus.Text = "部分入库";
                        break;
                    case 1004:
                        lblStorageStatus.Text = "已入库";
                        break;
                }

                #region 平台名称
                Literal PlatformTypeId = e.Row.FindControl("PlatformTypeId") as Literal;
                List<CodeList> codeList = base.CodeService.GetCodeList(Convert.ToInt32(info.PlatformTypeId));
                if (codeList.Count > 0)
                    PlatformTypeId.Text = codeList[0].CodeName;
                #endregion
                //查看详情
                ImageButton imgbtnProductionOrderDetail = e.Row.FindControl("imgbtnProductionOrderDetail") as ImageButton;
                if (imgbtnProductionOrderDetail != null)
                {
                    imgbtnProductionOrderDetail.OnClientClick = "return ShowWindowDetail('生产单信息','" + CommonHelper.GetStoreLocation()
                   + "ManageProductionOrder/XMProductionOrderOperation.aspx?ID=" + info.Id + "&IsCM=1',950, 500, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }
            }
        }



        #region
        public void SetTrigger()
        {
        }
        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;

            //平台类型动态数据绑定
            this.ddPlatformTypeId.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            // var newList = codeList.Where(p => p.CodeID != 250).ToList();
            this.ddPlatformTypeId.DataSource = codeList;
            this.ddPlatformTypeId.DataTextField = "CodeName";
            this.ddPlatformTypeId.DataValueField = "CodeID";
            this.ddPlatformTypeId.DataBind();
            this.ddPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));

        }
        #endregion

    }
}