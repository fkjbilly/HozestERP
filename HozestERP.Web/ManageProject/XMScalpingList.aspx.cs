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
using System.IO;
using HozestERP.Common;

namespace HozestERP.Web.ManageProject
{
    public partial class XMScalpingList : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnDelete", "ManageProject.XMScalpingListt.Delete");//删除
                buttons.Add("btnAdd", "ManageProject.XMScalpingList.Add");//新增
                buttons.Add("imgbtnEdit", "ManageProject.XMScalpingList.Edit");//编辑
                buttons.Add("btnImportingPage", "ManageProject.XMScalpingList.ImportingPage");//导入刷单记录
                buttons.Add("btnMatchScalpingCode", "ManageProject.XMScalpingList.MatchScalpingCode");//匹配刷单单号 
                buttons.Add("But_pldyyd", "ManageProject.XMScalpingList.pldyyd");//批量打印运单 
                return buttons;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtOrderCreateDateStart.Value = Convert.ToDateTime(DateTime.Now).AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
                this.txtOrderCreateDateEnd.Value = Convert.ToDateTime(DateTime.Now).AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss");
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnImportingPage.UniqueID, this.Page);
        }

        public void Face_Init()
        {

            this.Master.SetTitle("刷单查询");
            //this.Master.SetTitleVisible = false; 
            //平台类型动态数据绑定
            this.ddlPlatformTypeId.Items.Clear();
            var codePlatformTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatformTypeId.DataSource = codePlatformTypeList;
            this.ddlPlatformTypeId.DataTextField = "CodeName";
            this.ddlPlatformTypeId.DataValueField = "CodeID";
            this.ddlPlatformTypeId.DataBind();
            this.ddlPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));

            #region 店铺名称绑定

            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddlNickId.Items.Clear();
                var NickList = base.XMNickService.GetXMNickList();
                var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                this.ddlNickId.DataSource = newNickList;
                this.ddlNickId.DataTextField = "nick";
                this.ddlNickId.DataValueField = "nick_id";
                this.ddlNickId.DataBind();
                this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                //其他
                //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                if (xMNickList.Count() == 0)
                {
                    this.ddlNickId.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                }
                if (xMNickList.Count > 0)
                {
                    this.ddlNickId.Items.Clear();
                    this.ddlNickId.DataSource = xMNickList;
                    this.ddlNickId.DataTextField = "nick";
                    this.ddlNickId.DataValueField = "nick_id";
                    this.ddlNickId.DataBind();
                    //this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }

            #endregion

            ////店铺数据源 
            //if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84)
            //{
            //    this.ddlNickId.Items.Clear();
            //    var NickList = base.XMNickService.GetXMNickList();
            //    var newNickList = NickList.Where(p => p.isEnable == true).ToList();
            //    this.ddlNickId.DataSource = newNickList;
            //    this.ddlNickId.DataTextField = "nick";
            //    this.ddlNickId.DataValueField = "nick_id";
            //    this.ddlNickId.DataBind();
            //    this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //}
            //else
            //{
            //    //项目经理
            //    var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ProjectManager);

            //    if (xMNickList.Count > 0)
            //    {
            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = xMNickList;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }

            //    //店长
            //    var xMNickListShopOwner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ShopOwner);
            //    if (xMNickListShopOwner.Count > 0)
            //    {

            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = xMNickListShopOwner;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }

            //    //推广专员
            //    var xMNickListPromotionSpecialist = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.PromotionSpecialist);
            //    if (xMNickListPromotionSpecialist.Count > 0)
            //    {

            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = xMNickListPromotionSpecialist;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }

            //    //文案专员
            //    var xMNickListCopywriterCommissioner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.CopywriterCommissioner);
            //    if (xMNickListCopywriterCommissioner.Count > 0)
            //    {

            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = xMNickListCopywriterCommissioner;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }


            //    //运营专员
            //    var xMNickListOperationCommissioner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.OperationCommissioner);
            //    if (xMNickListOperationCommissioner.Count > 0)
            //    {

            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = xMNickListOperationCommissioner;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }

            //    //项目负责人
            //    List<int> projectIdList = new List<int>();
            //    var XMProjectList = base.XMProjectService.GetXMProjectCustomerId(HozestERPContext.Current.User.CustomerID);
            //    if (XMProjectList.Count > 0)
            //    {
            //        projectIdList = XMProjectList.Select(p => p.Id).ToList();
            //    }

            //    var XMNickList = base.XMNickService.GetXMNickListByProjectId(projectIdList);
            //    if (XMNickList.Count > 0)
            //    {

            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = XMNickList;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }


            //    //项目经理、店长、推广专员、文案专员、运营专员、项目负责人 都返回店铺信息  以项目负责人为准
            //    if (xMNickList.Count > 0 && xMNickListShopOwner.Count > 0 && xMNickListPromotionSpecialist.Count > 0 && xMNickListCopywriterCommissioner.Count>0 && xMNickListOperationCommissioner.Count>0 && XMNickList.Count > 0)
            //    {
            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = XMNickList;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }

            //    //项目经理、店长 都返回店铺信息  以项目经理为准
            //    if (xMNickList.Count > 0 && xMNickListShopOwner.Count > 0)
            //    {
            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = xMNickList;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }

            //    //项目经理、项目负责人 都返回店铺信息  以项目负责人为准
            //    if (xMNickList.Count > 0 && XMNickList.Count > 0)
            //    {
            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = XMNickList;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }

            //    //店长、项目负责人 都返回店铺信息  以项目负责人为准
            //    if (xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
            //    {
            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = XMNickList;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }
            //    //推广专员、项目负责人 都返回店铺信息  以项目负责人为准
            //    if (xMNickListPromotionSpecialist.Count > 0 && XMNickList.Count > 0)
            //    {
            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = XMNickList;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }
            //    //文案专员、项目负责人 都返回店铺信息  以项目负责人为准
            //    if (xMNickListCopywriterCommissioner.Count > 0 && XMNickList.Count > 0)
            //    {
            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = XMNickList;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }
            //    //运营专员、项目负责人 都返回店铺信息  以项目负责人为准
            //    if (xMNickListOperationCommissioner.Count > 0 && XMNickList.Count > 0)
            //    {
            //        this.ddlNickId.Items.Clear();
            //        this.ddlNickId.DataSource = XMNickList;
            //        this.ddlNickId.DataTextField = "nick";
            //        this.ddlNickId.DataValueField = "nick_id";
            //        this.ddlNickId.DataBind();
            //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //    }

            //}



            this.btnAdd.OnClientClick = "return ShowWindowDetail('新增刷单','" + CommonHelper.GetStoreLocation()
          + "ManageProject/XMScalpingAdd.aspx?ScalpingId=-1',900, 260, this, function(){document.getElementById('"
          + this.btnSearch.ClientID + "').click();});";

            //弹出导入订单窗口
            this.btnImportingPage.OnClientClick = "return ShowWindowDetail('导入刷单记录','" + CommonHelper.GetStoreLocation() +
             "ManageProject/ImportScalpingRecord.aspx',950,300, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";


        }


        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            DateTime? OrderCreateDateStart = Convert.ToDateTime(txtOrderCreateDateStart.Value.Trim());
            DateTime? OrderCreateDateEnd = Convert.ToDateTime(txtOrderCreateDateEnd.Value.Trim());
            List<int> nickIdList = new List<int>();

            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84)
            {

                nickIdList.Add(Convert.ToInt32(this.ddlNickId.SelectedValue));

            }
            else
            {
                if (this.ddlNickId.SelectedValue != "")
                {

                    if (this.ddlNickId.SelectedValue == "-1")
                    {
                        //项目经理
                        var xMNickListProjectManager = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ProjectManager);

                        if (xMNickListProjectManager.Count > 0)
                        {
                            nickIdList = xMNickListProjectManager.Select(p => p.nick_id).ToList();
                        }

                        //店长
                        var xMNickListShopOwner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ShopOwner);
                        if (xMNickListShopOwner.Count > 0)
                        {

                            nickIdList = xMNickListShopOwner.Select(p => p.nick_id).ToList();
                        }

                        //推广专员
                        var xMNickListPromotionSpecialist = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.PromotionSpecialist);
                        if (xMNickListPromotionSpecialist.Count > 0)
                        {
                            nickIdList = xMNickListPromotionSpecialist.Select(p => p.nick_id).ToList();
                        }
                        //文案专员
                        var xMNickListCopywriterCommissioner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.CopywriterCommissioner);
                        if (xMNickListCopywriterCommissioner.Count > 0)
                        {

                            nickIdList = xMNickListCopywriterCommissioner.Select(p => p.nick_id).ToList();
                        }
                        //运营专员
                        var xMNickListOperationCommissioner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.OperationCommissioner);
                        if (xMNickListOperationCommissioner.Count > 0)
                        {

                            nickIdList = xMNickListOperationCommissioner.Select(p => p.nick_id).ToList();
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
                        if (xMNickListProjectManager.Count > 0 && xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
                        {

                            nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                        }
                        //项目经理、店长 都返回店铺信息  以项目经理为准
                        if (xMNickListProjectManager.Count > 0 && xMNickListShopOwner.Count > 0)
                        {

                            nickIdList = xMNickListProjectManager.Select(p => p.nick_id).ToList();
                        }
                        //项目经理、项目负责人 都返回店铺信息  以项目负责人为准
                        if (xMNickListProjectManager.Count > 0 && XMNickList.Count > 0)
                        {

                            nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                        }
                        //店长、项目负责人 都返回店铺信息  以项目负责人为准
                        if (xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
                        {

                            nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                        }

                        //推广专员、项目负责人 都返回店铺信息  以项目负责人为准
                        if (xMNickListPromotionSpecialist.Count > 0 && XMNickList.Count > 0)
                        {

                            nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                        }
                        //文案专员、项目负责人 都返回店铺信息  以项目负责人为准
                        if (xMNickListCopywriterCommissioner.Count > 0 && XMNickList.Count > 0)
                        {

                            nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                        }
                        //运营专员、项目负责人 都返回店铺信息  以项目负责人为准
                        if (xMNickListOperationCommissioner.Count > 0 && XMNickList.Count > 0)
                        {
                            nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                        }
                    }
                    else
                    {

                        nickIdList.Add(Convert.ToInt32(this.ddlNickId.SelectedValue));
                    }
                }
                else
                {
                    nickIdList.Add(0);
                }

            }
            var list = base.XMScalpingService.SearchXMScalping(Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue)
               , nickIdList, this.txtScalpingCode.Text.Trim(), this.txtOrderCode.Text.Trim(), Convert.ToInt32(this.ddIsAbnormal.SelectedValue), OrderCreateDateStart, OrderCreateDateEnd);
            var pageList = new PagedList<XMScalping>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdXMScalpingList, pageList);

            //已付款刷单，财务打印空包面单使用
            if (this.ddlPlatformTypeId.SelectedItem.Text == "天猫" || this.ddlPlatformTypeId.SelectedItem.Text == "京东" || this.ddlPlatformTypeId.SelectedItem.Text == "京东闪购"
                || this.ddlPlatformTypeId.SelectedItem.Text == "集市店")
            {
                if (this.chkfukuan.Checked)
                {
                    var list2 = base.XMScalpingService.SearchXMScalpingYFK(Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue)
                       , nickIdList, this.txtScalpingCode.Text.Trim(), this.txtOrderCode.Text.Trim(), Convert.ToInt32(this.ddIsAbnormal.SelectedValue), OrderCreateDateStart, OrderCreateDateEnd);
                    var pageList2 = new PagedList<XMScalping>(list2, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                    this.Master.BindData(this.grdXMScalpingList, pageList2);
                }
            }
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
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

        }

        protected void ddlNickId_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
        protected void grdXMScalpingList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {

                switch (e.CommandName)
                {
                    #region 删除
                    case "ScalpingDelete":

                        var xMScalping = base.XMScalpingService.GetXMScalpingByID(Convert.ToInt32(e.CommandArgument));

                        if (xMScalping != null)//删除
                        {
                            xMScalping.IsEnable = true;
                            xMScalping.UpdateID = HozestERPContext.Current.User.CustomerID;
                            xMScalping.UpdateDate = DateTime.Now;
                            base.XMScalpingService.UpdateXMScalping(xMScalping);
                            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                            base.ShowMessage("操作成功.");
                        }

                        break;
                    #endregion

                    //case"FeeEdit":  
                    //    if (e.Row.RowType == DataControlRowType.Footer)
                    //    {
                    //        ImageButton imgBtnFeeEdit = e.Row.FindControl("imgBtnFeeEdit") as ImageButton;
                    //        ImageButton imgBtnFeeUpdate = e.Row.FindControl("imgBtnFeeUpdate") as ImageButton;

                    //        imgBtnFeeEdit.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnFeeEdit_Click);//注册

                    //    }
                    //    break;

                }
            }
            catch
            { }


            //if (e.CommandName.Equals("ScalpingDelete"))
            //{

            //    var xMScalping = base.XMScalpingService.GetXMScalpingByID(Convert.ToInt32(e.CommandArgument));

            //    if (xMScalping != null)//删除
            //    { 
            //        xMScalping.IsEnable = true;
            //        xMScalping.UpdateID = HozestERPContext.Current.User.CustomerID;
            //        xMScalping.UpdateDate = DateTime.Now;
            //        base.XMScalpingService.UpdateXMScalping(xMScalping);
            //        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            //        base.ShowMessage("操作成功.");
            //    }

            //}


        }

        protected void grdXMScalpingList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var XMScalping = e.Row.DataItem as XMScalping;
                //查看详情
                ImageButton imgbtnEdit = e.Row.FindControl("imgbtnEdit") as ImageButton;
                if (imgbtnEdit != null)
                {
                    imgbtnEdit.OnClientClick = "return ShowWindowDetail('刷单信息','" + CommonHelper.GetStoreLocation() + "ManageProject/XMScalpingAdd.aspx?ScalpingId="
                        + XMScalping.ID + "',900, 350, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";
                }

                if (XMScalping.IsAbnormal != null)
                {
                    if (XMScalping.IsAbnormal.Value == true)
                    {
                        //e.Row.BackColor = System.Drawing.Color.Red;

                        e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[2].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[3].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[4].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[9].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[10].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[11].BackColor = System.Drawing.Color.Red;
                    }
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {


                ImageButton imgBtnFeeEdit = e.Row.FindControl("imgBtnFeeEdit") as ImageButton;
                ImageButton imgBtnFeeUpdate = e.Row.FindControl("imgBtnFeeUpdate") as ImageButton;
                ImageButton imgBtnFeeCancel = e.Row.FindControl("imgBtnFeeCancel") as ImageButton;

                //显示编辑按钮
                if (imgBtnFeeEdit != null)
                {
                    imgBtnFeeEdit.Visible = true;
                }
                //隐藏保存按钮
                if (imgBtnFeeUpdate != null)
                {
                    imgBtnFeeUpdate.Visible = false;
                }
                //隐藏取消按钮
                if (imgBtnFeeCancel != null)
                {
                    imgBtnFeeCancel.Visible = false;
                }
            }

        }

        //编辑佣金列 
        protected void imgBtnFeeEdit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow item in grdXMScalpingList.Rows)
            {
                if (item.RowIndex != grdXMScalpingList.EditIndex)
                {
                    // 设置txtInventory 为可编辑控件
                    Label lblFee = item.FindControl("lblFee") as Label;
                    TextBox txtFee = item.FindControl("txtFee") as TextBox;
                    lblFee.Visible = false;
                    txtFee.Visible = true;
                    txtFee.Text = txtFee.Text == "" ? "0" : txtFee.Text;
                }
            }

            if (this.grdXMScalpingList.FooterRow.RowType == DataControlRowType.Footer)
            {
                ImageButton imgBtnFeeEdit = this.grdXMScalpingList.FooterRow.FindControl("imgBtnFeeEdit") as ImageButton;
                ImageButton imgBtnFeeUpdate = this.grdXMScalpingList.FooterRow.FindControl("imgBtnFeeUpdate") as ImageButton;
                ImageButton imgBtnFeeCancel = this.grdXMScalpingList.FooterRow.FindControl("imgBtnFeeCancel") as ImageButton;
                //隐藏编辑按钮
                if (imgBtnFeeEdit != null)
                {
                    imgBtnFeeEdit.Visible = false;
                }
                //显示保存按钮
                if (imgBtnFeeUpdate != null)
                {
                    imgBtnFeeUpdate.Visible = true;
                }
                //显示取消按钮
                if (imgBtnFeeCancel != null)
                {
                    imgBtnFeeCancel.Visible = true;
                }
            }
        }

        /// <summary>
        /// 保存佣金
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgBtnFeeUpdate_Click(object sender, EventArgs e)
        {
            #region 字符验证
            int errorcount = 0;
            //循环所有行
            foreach (GridViewRow msgReach in grdXMScalpingList.Rows)
            {
                if (msgReach.RowIndex != grdXMScalpingList.EditIndex)
                {
                    TextBox txtFee = msgReach.FindControl("txtFee") as TextBox;
                    Label lblMsgManufacturersInventoryVaule = msgReach.FindControl("lblMsgManufacturersInventoryVaule") as Label;
                    decimal temp = 0;
                    if (!decimal.TryParse(txtFee.Text.Trim(), out temp))
                    {
                        if (txtFee.Text.Trim() != "")
                        {
                            lblMsgManufacturersInventoryVaule.Text = "请输入正确的数值";//确保输入的达成值都是数字
                            //lblFee.Style.Add("color", "red");
                            lblMsgManufacturersInventoryVaule.Visible = true;
                            errorcount++;
                        }
                    }
                    else
                    {
                        lblMsgManufacturersInventoryVaule.Visible = false;
                    }
                }
            }
            if (errorcount > 0)
            {
                return;
            }
            #endregion

            bool isEdit = false;
            //循环grid 每行 
            foreach (GridViewRow item in grdXMScalpingList.Rows)
            {
                if (item.RowIndex != grdXMScalpingList.EditIndex)
                {
                    //库存控件
                    TextBox txtFee = item.FindControl("txtFee") as TextBox;
                    string id = grdXMScalpingList.DataKeys[item.RowIndex].Values[0].ToString();
                    if (txtFee.Visible)
                    {
                        isEdit = true;
                        var scalping = base.XMScalpingService.GetXMScalpingByID(Convert.ToInt32(id));
                        //数据转换
                        if (txtFee.Text.Trim() != "")
                        {
                            scalping.Fee = Convert.ToDecimal(txtFee.Text.Trim());
                        }
                        else
                        {
                            scalping.Fee = 0;
                        }
                        scalping.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        scalping.UpdateDate = DateTime.Now;
                        //数据数据
                        base.XMScalpingService.UpdateXMScalping(scalping);
                    }
                }
            }
            if (isEdit)
                base.ShowMessage("保存成功!");
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        //取消按钮
        protected void imgBtnFeeCancel_Click(object sender, EventArgs e)
        {

            //this.BindGrid();

            BindGrid(this.Master.PageIndex, this.Master.PageSize);

        }


        /// <summary>
        /// 刷单反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnScalpingAudit_Click(object sender, EventArgs e)
        {
            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdXMScalpingList);
            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (GridViewRow row in grdXMScalpingList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int scalpingId = 0;
                        int.TryParse(this.grdXMScalpingList.DataKeys[row.RowIndex].Value.ToString(), out scalpingId);
                        //刷单信息
                        var ScalpingInfo = base.XMScalpingService.GetXMScalpingByID(scalpingId);
                        if (ScalpingInfo != null)
                        {
                            ScalpingInfo.IsEnable = true;//删除
                            base.XMScalpingService.UpdateXMScalping(ScalpingInfo);

                            //修改订单
                            var xmorderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(ScalpingInfo.OrderCode);
                            xmorderinfo.IsScalping = false;
                            base.XMOrderInfoService.UpdateXMOrderInfo(xmorderinfo);

                            //操作记录
                            XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                            record1.PropertyName = "ScalpingRecord";
                            record1.OldValue = System.Convert.ToString(true);

                            record1.NewValue = System.Convert.ToString(false);
                            record1.OrderInfoId = xmorderinfo.ID;
                            record1.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            record1.UpdateTime = DateTime.Now;
                            base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record1);

                        }
                    }

                }

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功.");

            }
        }



        /// <summary>
        ///匹配刷单单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void hidBtnMatchScalpingCode_Click(object sender, EventArgs e)
        {
            if (Session["SessionScalpingId"] == null)
                return;
            try
            {
                var IDs = this.Master.GetSelectedIds(this.grdXMScalpingList);

                if (IDs.Count > 0)
                {

                    var IDsList = base.XMScalpingService.GetXMScalpingByIDs(IDs);

                    XMScalping xMScalping = null;

                    for (int i = 0; i < IDsList.Count; i++)
                    {
                        xMScalping = IDsList[i];

                        string ScalpingId = Session["SessionScalpingId"].ToString();
                        xMScalping.ScalpingApplication = Convert.ToInt32(ScalpingId);//刷单单号 Id
                        xMScalping.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xMScalping.UpdateDate = DateTime.Now;
                        base.XMScalpingService.UpdateXMScalping(xMScalping);
                    }
                }
                this.Master.JsWrite("alert('分配成功。');RefreshSearch();", "");

                this.BindGrid(Master.PageIndex, Master.PageSize);

            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }
        }

        /// <summary>
        /// 匹配刷单单号（弹出财务确认窗口)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void hidBtnMatchScalpingCodePrompt_Click(object sender, EventArgs e)
        {
            //int PlatformTypeId = Convert.ToInt32( this.ddlPlatformTypeId.SelectedValue);
            //int NickId = Convert.ToInt32(this.ddlNickId.SelectedValue);

            //选择复选框 刷单记录Id
            List<int> IDs = this.Master.GetSelectedIds(this.grdXMScalpingList);

            int PlatformTypeId = 0;
            int NickId = 0;

            string IDsStr = "";
            if (IDs.Count >= 1)
            {

                foreach (var id in IDs)
                {
                    IDsStr += id + ",";
                }
                if (!string.IsNullOrEmpty(IDsStr))
                {
                    IDsStr = IDsStr.Substring(0, IDsStr.Length - 1);
                }

                var IDsList = base.XMScalpingService.GetXMScalpingByIDs(IDs);

                //判断是否选择同平台并同店铺数据 
                var NewPlatformTypeIdAndNickId = (from p in IDsList
                                                  group p by new
                                                  {
                                                      PlatformTypeId = p.PlatformTypeId,
                                                      NickId = p.NickId
                                                  } into g
                                                  select new
                                                  {
                                                      PlatformTypeId = g.Key.PlatformTypeId,
                                                      NickId = g.Key.NickId
                                                  }
                                                  ).ToList();
                if (NewPlatformTypeIdAndNickId.Count > 0)
                {
                    PlatformTypeId = NewPlatformTypeIdAndNickId[0].PlatformTypeId.Value;
                    NickId = NewPlatformTypeIdAndNickId[0].NickId.Value;
                }
            }

            string paramScript = "ShowWindowDetail1('b-win','匹配刷单单号','" + CommonHelper.GetStoreLocation() +
                     "ManageProject/MatchScalpingCode.aspx?PlatformTypeId=" + PlatformTypeId +
                     "&NickId=" + NickId +
                     "&PlatformTypeName=" + this.ddlPlatformTypeId.SelectedItem +
                     "&NickName=" + this.ddlNickId.SelectedItem +
                     "&IDsStr=" + IDsStr + "',900,200, this, function(){document.getElementById('"
                     + this.hidBtnMatchScalpingCode.ClientID + "').click();});";
            this.Master.JsWrite(paramScript, "");
        }


        /// <summary>
        /// 匹配刷单单号 (判断)  选择刷单单号是空的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMatchScalpingCode_Click(object sender, EventArgs e)
        {

            try
            {
                //var ddlPlatformTypeId= this.ddlPlatformTypeId.SelectedValue;
                //var ddlNickId = this.ddlNickId.SelectedValue;

                //if (ddlPlatformTypeId == "-1" || ddlNickId == "-1") {

                //    base.ShowMessage("请选择平台类型或店铺名称.");
                //    return; 
                //}

                var IDs = this.Master.GetSelectedIds(this.grdXMScalpingList);

                if (IDs.Count > 0)
                {
                    var IDsList = base.XMScalpingService.GetXMScalpingByIDs(IDs);

                    //判断是否选择同平台并同店铺数据 
                    var NewPlatformTypeIdAndNickId = (from p in IDsList
                                                      group p by new
                                                     {
                                                         PlatformTypeId = p.PlatformTypeId,
                                                         NickId = p.NickId
                                                     } into g
                                                      select new
                                                      {
                                                          PlatformTypeId = g.Key.PlatformTypeId,
                                                          NickId = g.Key.NickId
                                                      }
                                                      ).ToList();

                    if (NewPlatformTypeIdAndNickId.Count > 1)
                    {

                        base.ShowMessage("请选择同平台并同店铺的刷单记录.");
                        return;
                    }

                    //查询刷单单号不等于NULL的记录
                    var NewIDsList = IDsList.Where(p => p.ScalpingApplication != null).ToList();
                    if (NewIDsList.Count > 0)
                    {
                        base.ShowMessage("请选择未分配刷单单号的记录.");
                        return;
                    }

                    //已选数据的刷单单号Id都是NULL 弹出确认窗口
                    if (NewIDsList.Count == 0)
                    {
                        Session["SessionScalpingId"] = null;
                        string s = "document.getElementById('" + this.hidBtnMatchScalpingCodePrompt.ClientID + "').click();";
                        this.Master.JsWrite(s, "");

                    }
                }

            }
            catch (Exception err)
            {
                base.ProcessException(err);
            }


        }


        protected void btnExortData_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    List<XMScalping> List = new List<XMScalping>();

                    DateTime? OrderCreateDateStart = Convert.ToDateTime(txtOrderCreateDateStart.Value.Trim());
                    DateTime? OrderCreateDateEnd = Convert.ToDateTime(txtOrderCreateDateEnd.Value.Trim());
                    List<int> nickIdList = new List<int>();

                    if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84)
                    {
                        nickIdList.Add(Convert.ToInt32(this.ddlNickId.SelectedValue));

                    }
                    else
                    {
                        if (this.ddlNickId.SelectedValue != "")
                        {

                            if (this.ddlNickId.SelectedValue == "-1")
                            {
                                //项目经理
                                var xMNickListProjectManager = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ProjectManager);

                                if (xMNickListProjectManager.Count > 0)
                                {
                                    nickIdList = xMNickListProjectManager.Select(p => p.nick_id).ToList();
                                }

                                //店长
                                var xMNickListShopOwner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ShopOwner);
                                if (xMNickListShopOwner.Count > 0)
                                {

                                    nickIdList = xMNickListShopOwner.Select(p => p.nick_id).ToList();
                                }

                                //推广专员
                                var xMNickListPromotionSpecialist = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.PromotionSpecialist);
                                if (xMNickListPromotionSpecialist.Count > 0)
                                {
                                    nickIdList = xMNickListPromotionSpecialist.Select(p => p.nick_id).ToList();
                                }
                                //文案专员
                                var xMNickListCopywriterCommissioner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.CopywriterCommissioner);
                                if (xMNickListCopywriterCommissioner.Count > 0)
                                {

                                    nickIdList = xMNickListCopywriterCommissioner.Select(p => p.nick_id).ToList();
                                }
                                //运营专员
                                var xMNickListOperationCommissioner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.OperationCommissioner);
                                if (xMNickListOperationCommissioner.Count > 0)
                                {

                                    nickIdList = xMNickListOperationCommissioner.Select(p => p.nick_id).ToList();
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
                                if (xMNickListProjectManager.Count > 0 && xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
                                {

                                    nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                                }
                                //项目经理、店长 都返回店铺信息  以项目经理为准
                                if (xMNickListProjectManager.Count > 0 && xMNickListShopOwner.Count > 0)
                                {

                                    nickIdList = xMNickListProjectManager.Select(p => p.nick_id).ToList();
                                }
                                //项目经理、项目负责人 都返回店铺信息  以项目负责人为准
                                if (xMNickListProjectManager.Count > 0 && XMNickList.Count > 0)
                                {

                                    nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                                }
                                //店长、项目负责人 都返回店铺信息  以项目负责人为准
                                if (xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
                                {

                                    nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                                }

                                //推广专员、项目负责人 都返回店铺信息  以项目负责人为准
                                if (xMNickListPromotionSpecialist.Count > 0 && XMNickList.Count > 0)
                                {

                                    nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                                }
                                //文案专员、项目负责人 都返回店铺信息  以项目负责人为准
                                if (xMNickListCopywriterCommissioner.Count > 0 && XMNickList.Count > 0)
                                {

                                    nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                                }
                                //运营专员、项目负责人 都返回店铺信息  以项目负责人为准
                                if (xMNickListOperationCommissioner.Count > 0 && XMNickList.Count > 0)
                                {
                                    nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                                }
                            }
                            else
                            {

                                nickIdList.Add(Convert.ToInt32(this.ddlNickId.SelectedValue));
                            }
                        }
                        else
                        {
                            nickIdList.Add(0);
                        }

                    }

                    List = base.XMScalpingService.SearchXMScalping(Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue)
                     , nickIdList, this.txtScalpingCode.Text.Trim(), this.txtOrderCode.Text.Trim(), Convert.ToInt32(this.ddIsAbnormal.SelectedValue), OrderCreateDateStart, OrderCreateDateEnd);

                    //已付款刷单，财务打印空包面单使用
                    if (this.ddlPlatformTypeId.SelectedItem.Text == "天猫" || this.ddlPlatformTypeId.SelectedItem.Text == "京东" || this.ddlPlatformTypeId.SelectedItem.Text == "京东闪购"
                        || this.ddlPlatformTypeId.SelectedItem.Text == "集市店")
                    {
                        if (this.chkfukuan.Checked)
                        {
                            List = base.XMScalpingService.SearchXMScalpingYFK(Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue)
                               , nickIdList, this.txtScalpingCode.Text.Trim(), this.txtOrderCode.Text.Trim(), Convert.ToInt32(this.ddIsAbnormal.SelectedValue), OrderCreateDateStart, OrderCreateDateEnd);
                        }
                    }

                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\SclalpingDataExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    base.ExportManager.ExportScalpingInfoToXls(filePath, List);
                    CommonHelper.WriteResponseXls(filePath, fileName);



                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        /// <summary>
        /// 打印物流运单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void But_pldyyd_Click(object sender, EventArgs e)
        {
            List<int> ordercodes = this.Master.GetSelectedIds(this.grdXMScalpingList);
            if (ordercodes.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {

                //string ids = "";//订单ids
                //foreach (GridViewRow row in grdvClients.Rows)
                //{
                //    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                //    if (chkSelected.Checked)
                //    {
                //        int DeliveryID = 0;
                //        int.TryParse(this.grdvClients.DataKeys[row.RowIndex].Value.ToString(), out DeliveryID);

                //        var deliveryinfo = base.XMDeliveryService.GetXMDeliveryById(DeliveryID);
                //        if (deliveryinfo.OrderCode != null && deliveryinfo.OrderCode != "")
                //        {
                //            var orderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(deliveryinfo.OrderCode);//订单信息
                //            if (orderinfo != null)
                //            {
                //                if (ids != "")
                //                    ids += ",";
                //                ids += orderinfo.ID;
                //            }
                //        }

                //    }
                //}

                //发货单Id
                string deliveryId = string.Join(",", ordercodes);

                string strdiqu = "YTO";

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "openscript_yd", "window.open('dyYD.aspx?kd=" + strdiqu
                    + "&ids=" + deliveryId
                    + "&PrintTypeId=Empty"
                    + "','批量打印运单', 'height=900, width=870, top=0, left=0, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=n o, status=no');", true);
            }


        }

    }
}