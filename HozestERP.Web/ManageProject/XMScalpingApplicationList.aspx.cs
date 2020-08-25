using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using CRM.BusinessLogic.ManageContract;

namespace HozestERP.Web.ManageProject
{ 
    public partial class XMScalpingApplicationList : BaseAdministrationPage, ISearchPage
    {
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnEdit", "ManageProject.XMScalpingApplicationList.Edit");//编辑
                buttons.Add("imgBtnDelete", "ManageProject.XMScalpingApplicationList.Delete");//删除
                buttons.Add("btnAdd", "ManageProject.XMScalpingApplicationList.Add");//新增
                buttons.Add("btnManagerIsAudit", "ManageProject.XMScalpingApplicationList.ManagerIsAudit");//部门审核
                buttons.Add("btnManagerIsAuditNO", "ManageProject.XMScalpingApplicationList.ManagerIsAuditNO");//部门反审核 
                
                return buttons;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 店铺名称绑定

                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    this.ddlNick.Items.Clear();
                    var NickList = base.XMNickService.GetXMNickList();
                    var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                    if (newNickList.Count() > 0)
                    {
                        this.ddlNick.DataSource = newNickList;
                        this.ddlNick.DataTextField = "nick";
                        this.ddlNick.DataValueField = "nick_id";
                        this.ddlNick.DataBind();
                        this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                    }
                }
                else
                {
                    //其他
                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                    if (xMNickList.Count() == 0)
                    {
                        this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                    }
                    if (xMNickList.Count > 0)
                    {
                        this.ddlNick.Items.Clear();
                        this.ddlNick.DataSource = xMNickList;
                        this.ddlNick.DataTextField = "nick";
                        this.ddlNick.DataValueField = "nick_id";
                        this.ddlNick.DataBind();
                        //this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                    }
                }

                #endregion 
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnManagerIsAudit.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnManagerIsAuditNO.UniqueID, this.Page);
        }

        public void Face_Init()
        {

            this.Master.SetTitle("刷单查询"); 
            
             
            this.btnAdd.OnClientClick = "return ShowWindowDetail('刷单申请','" + CommonHelper.GetStoreLocation()
          + "ManageProject/XMScalpingApplicationAdd.aspx?ScalpingId=-1',1000, 390, this, function(){document.getElementById('"
          + this.btnSearch.ClientID + "').click();});";
            Session["SessionPayTypeId"] = null;
             

        }


        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            List<int> nickIdList = new List<int>();

             //项目部—主管管理—刷单管理
            if (this.SDParametersTypeId == 2)
            {

                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84)
                {

                    nickIdList.Add(Convert.ToInt32(this.ddlNick.SelectedValue));

                }
                else
                {
                    if (this.ddlNick.SelectedValue != "")
                    {
                        if (this.ddlNick.SelectedValue == "-1")
                        {
                            //项目经理
                            var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ProjectManager);

                            if (xMNickList.Count > 0)
                            {
                                nickIdList = xMNickList.Select(p => p.nick_id).ToList();
                            }

                            //店长
                            var xMNickListShopOwner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ShopOwner);
                            if (xMNickListShopOwner.Count > 0)
                            {

                                nickIdList = xMNickListShopOwner.Select(p => p.nick_id).ToList();
                            }

                            //项目负责人
                            List<int> projectIdList = new List<int>();
                            var XMProjectList = base.XMProjectService.GetXMProjectCustomerId(HozestERPContext.Current.User.CustomerID);
                            if (XMProjectList.Count > 0)
                            {
                                projectIdList = XMProjectList.Select(p => p.Id).ToList();
                            }

                            var XMNickList = base.XMNickService.GetXMNickListByProjectId(projectIdList);
                            if (XMNickList.Count > 0)
                            {

                                nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                            }

                            //项目经理、店长、项目负责人 都返回店铺信息  以项目负责人为准
                            if (xMNickList.Count > 0 && xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
                            {

                                nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                            }
                            //项目经理、店长 都返回店铺信息  以项目经理为准
                            if (xMNickList.Count > 0 && xMNickListShopOwner.Count > 0)
                            {

                                nickIdList = xMNickList.Select(p => p.nick_id).ToList();
                            }
                            //项目经理、项目负责人 都返回店铺信息  以项目负责人为准
                            if (xMNickList.Count > 0 && XMNickList.Count > 0)
                            {

                                nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                            }
                            //店长、项目负责人 都返回店铺信息  以项目负责人为准
                            if (xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
                            {

                                nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                            }
                        }
                        else
                        {

                            nickIdList.Add(Convert.ToInt32(this.ddlNick.SelectedValue));
                        }
                    }
                    else {
                        nickIdList.Add(0);
                    }

                }
            }
            else { 
                nickIdList.Add(Convert.ToInt32(this.ddlNick.SelectedValue));
            }
            this.Master.BindData<XMScalpingApplication>(this.gvXMScalpingApplication
               , base.XMScalpingApplicationService.SearchXMScalpingApplication(Convert.ToInt32(this.ccPlatformTypeId.SelectedValue)
               , nickIdList, this.txtScalpingCode.Text.Trim()
               , paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString()));
        }

        //private void BindGrid()
        //{
        //    this.BindGrid(1, this.Master.PageSize);
        //}
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void ddlNick_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
        

        protected void gvXMScalpingApplication_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("ScalpingApplicationDelete"))
            {

                var xMScalpingApplication = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(Convert.ToInt32(e.CommandArgument));

                if (xMScalpingApplication != null)//删除
                {
                    xMScalpingApplication.IsEnable = true;
                    xMScalpingApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    xMScalpingApplication.UpdateTime = DateTime.Now;
                    base.XMScalpingApplicationService.UpdateXMScalpingApplication(xMScalpingApplication);
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    base.ShowMessage("操作成功.");
                }

            }
            #endregion
        }

        protected void gvXMScalpingApplication_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                var xMScalpingApplication = e.Row.DataItem as XMScalpingApplication;

                #region 说明
                Label lblExplanation = e.Row.FindControl("lblExplanation") as Label; 
                if (xMScalpingApplication.Explanation != null && xMScalpingApplication.Explanation != "" )
                {
                    if (xMScalpingApplication.Explanation.Length > 8)
                    {
                        //var SdeliveryAddress = CutStr(deliveryAddress, 20);
                        string strExplanation = xMScalpingApplication.Explanation.ToString().Substring(0, 8);
                        lblExplanation.Text = strExplanation + "...";
                        lblExplanation.ToolTip = xMScalpingApplication.Explanation.ToString();
                    }
                    else {
                        lblExplanation.Text = xMScalpingApplication.Explanation.ToString();
                        lblExplanation.ToolTip = xMScalpingApplication.Explanation.ToString();
                    }
                }
                else
                {
                    lblExplanation.Text = "";

                }
                #endregion 

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('刷单详情','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMScalpingApplicationAdd.aspx?ScalpingId=" + xMScalpingApplication.ScalpingId + "',1000, 415, this, function(){document.getElementById('"
                   + this.btnSearch.ClientID + "').click();});";

                }

            }
        }



        /// <summary>
        /// 部门审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManagerIsAudit_Click(object sender, EventArgs e)
        {
            List<int> gvXMScalpingApplicationIDs = this.Master.GetSelectedIds(this.gvXMScalpingApplication);
            if (gvXMScalpingApplicationIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (GridViewRow row in gvXMScalpingApplication.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.gvXMScalpingApplication.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        XMScalpingApplication xMScalpingApplication = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(Id);

                        if (xMScalpingApplication != null)
                        {
                            xMScalpingApplication.ManagerPeople = HozestERPContext.Current.User.CustomerID;
                            xMScalpingApplication.ManagerIsAudit = true;
                            xMScalpingApplication.ManagerTime = DateTime.Now;
                            xMScalpingApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            xMScalpingApplication.UpdateTime = DateTime.Now;
                            base.XMScalpingApplicationService.UpdateXMScalpingApplication(xMScalpingApplication);
                        }

                    }
                }
            }

            this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
            this.BindGrid(Master.PageIndex, Master.PageSize);

        }


        
        /// <summary>
        /// 部门反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManagerIsAuditNO_Click(object sender, EventArgs e)
        {
            List<int> gvXMScalpingApplicationIDs = this.Master.GetSelectedIds(this.gvXMScalpingApplication);
            if (gvXMScalpingApplicationIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {

                var AdvanceApplicationList = base.AdvanceApplicationService.GetAdvanceApplicationListById(gvXMScalpingApplicationIDs);
                var FinanceIsAudittFalse = AdvanceApplicationList.Where(a => a.FinanceIsAudit.Value == true).ToList();

                if (FinanceIsAudittFalse.Count > 0)
                {
                    base.ShowMessage("请选择财务未审核的数据.");
                    return;
                }


                foreach (GridViewRow row in gvXMScalpingApplication.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.gvXMScalpingApplication.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        XMScalpingApplication xMScalpingApplication = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(Id);

                        if (xMScalpingApplication != null)
                        {
                            xMScalpingApplication.ManagerPeople = HozestERPContext.Current.User.CustomerID;
                            xMScalpingApplication.ManagerIsAudit = false;
                            xMScalpingApplication.ManagerTime = DateTime.Now;
                            xMScalpingApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            xMScalpingApplication.UpdateTime = DateTime.Now;
                            base.XMScalpingApplicationService.UpdateXMScalpingApplication(xMScalpingApplication);
                        }

                    }
                }
            }

            this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
            this.BindGrid(Master.PageIndex, Master.PageSize);

        }

        
        /// <summary>
        /// 刷单参数类型Id
        /// </summary>
        public int SDParametersTypeId
        {
            get
            {
                return CommonHelper.QueryStringInt("SDParametersTypeId");
            }
        }
    }
}