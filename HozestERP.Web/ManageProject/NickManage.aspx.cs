using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.Web;
using HozestERP.BusinessLogic.CustomerManagement;
using CRM.BusinessLogic.ManageContract;


namespace HozestERP.Web.ManageProject
{
    public partial class NickManage : BaseAdministrationPage, ISearchPage
    {
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnSearch", "NickManage.Search");
                buttons.Add("imgBtnEdit", "NickManage.Edit");
                buttons.Add("imgProduct", "Product.Search");
                buttons.Add("imgBtnUpdate", "NickManage.Save");
                buttons.Add("imgBtnCancel", "NickManage.Cancel");
                buttons.Add("imgbtnCustomer", "NickManage.Customer");
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var SearchProjectId = base.XMProjectService.GetXMProjectList();

                if (this.ProjectId == -1)
                {
                    #region 项目名称绑定

                    //项目名称绑定--选取自运营项目
                    if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                    {
                        this.ddSearchProjectId.Items.Clear();
                        var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362);

                        this.ddSearchProjectId.DataSource = projectList;
                        this.ddSearchProjectId.DataTextField = "ProjectName";
                        this.ddSearchProjectId.DataValueField = "Id";
                        this.ddSearchProjectId.DataBind();
                        this.ddSearchProjectId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    }
                    else
                    {
                        this.ddSearchProjectId.Items.Clear();
                        var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                            .GroupBy(p => new { p.Id, p.ProjectName })
                            .Select(p => new
                            {
                                Id = p.Key.Id,
                                ProjectName = p.Key.ProjectName
                            });
                        if (projectList.Count() == 0)
                        {
                            this.ddSearchProjectId.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                        }
                        if (projectList.Count() > 0)
                        {
                            this.ddSearchProjectId.DataSource = projectList;
                            this.ddSearchProjectId.DataTextField = "ProjectName";
                            this.ddSearchProjectId.DataValueField = "Id";
                            this.ddSearchProjectId.DataBind();
                        }
                        //this.ddSearchProjectId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    }
                    #endregion
                }
                else if (this.ProjectId == 1)
                {
                    var nickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, txtNick.Text.Trim(), 0);
                    List<int> ProjectIdIdList = nickList.Select(p => p.ProjectId.Value).ToList();

                    var projectList = base.XMProjectService.GetXMProjectProjectIdList(ProjectIdIdList);
                    this.ddSearchProjectId.Items.Clear();
                    this.ddSearchProjectId.DataSource = projectList;
                    this.ddSearchProjectId.DataTextField = "ProjectName";
                    this.ddSearchProjectId.DataValueField = "Id";
                    this.ddSearchProjectId.DataBind();
                }
                else
                {
                    this.gvNick.Columns[1].Visible = false;
                    var SearchProjectNew = SearchProjectId.Where(p => p.Id == this.ProjectId).ToList();
                    this.ddSearchProjectId.Items.Clear();
                    this.ddSearchProjectId.DataSource = SearchProjectNew;
                    this.ddSearchProjectId.DataTextField = "ProjectName";
                    this.ddSearchProjectId.DataValueField = "Id";
                    this.ddSearchProjectId.DataBind();
                }
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
            this.Master.SetTitleVisible = false;

        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //是否在运营
            int IsEnable = Convert.ToInt32(this.ddIsEnable.SelectedValue.Trim());


            int ProjectId = 0;
            int.TryParse(this.ddSearchProjectId.SelectedValue, out ProjectId);

            List<XMNick> nickList = new List<XMNick>();
            if (this.ProjectId == -1)//从左边菜单查看店铺信息
            {
                nickList = base.XMNickService.GetXMNickList(txtNick.Text.Trim(), IsEnable, ProjectId);
            }
            else if (this.ProjectId == 1)
            {
                nickList = base.XMNickService.GetMyNickListByCustomerList(HozestERPContext.Current.User.CustomerID, txtNick.Text.Trim(), ProjectId);
                this.RowEditIndex = nickList.Count();
            }
            else
            { //从项目点进店铺
                nickList = base.XMNickService.GetXMNickList(txtNick.Text.Trim(), IsEnable, this.ProjectId);
            }
            var nickPageList = new PagedList<XMNick>(nickList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            if (this.RowEditIndex == -1)
            {
                this.gvNick.EditIndex = nickPageList.Count();
                nickPageList.Add(new XMNick());
            }
            else
            {
                this.gvNick.EditIndex = this.RowEditIndex;
            }

            this.Master.BindData(this.gvNick, nickPageList, paramPageSize + 1);
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void ddIsEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected string selectPlatformTypeName(int platFormTypeId)
        {
            string platFormID = "";
            var platFormTypeList = base.CodeService.GetCodeList(Convert.ToInt32(platFormTypeId));
            if (platFormTypeList.Count > 0)
            {
                platFormID = platFormTypeList[0].CodeName;
            }
            return platFormID;
        }


        protected void gvNick_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            int Id = 0;
            int.TryParse(this.gvNick.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
            var row = this.gvNick.Rows[e.NewEditIndex];
            var xMNick = base.XMNickService.GetXMNickByID(Id);
            if (xMNick != null)
            {
                string platFormId = xMNick.PlatformTypeId.ToString();
                DropDownList ddlPlatFormList = row.FindControl("ddlPlatformTypeId") as DropDownList;
                if (!string.IsNullOrEmpty(platFormId))
                {
                    ddlPlatFormList.SelectedValue = platFormId;
                }

                DropDownList ddProjectId = (DropDownList)row.FindControl("ddProjectId");
                ddProjectId.SelectedValue = xMNick.ProjectId.Value.ToString();
            }


        }

        protected void gvNick_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int nickId = 0;
            int.TryParse(this.gvNick.DataKeys[e.RowIndex].Value.ToString(), out nickId);
            var row = this.gvNick.Rows[e.RowIndex];
            var txtNick = row.FindControl("txtNick") as TextBox;
            var lblNick = row.FindControl("lblNick") as Label;
            var chkIsEnable = row.FindControl("chkIsEnable") as CheckBox;
            var ddlPlatFormType = row.FindControl("ddlPlatformTypeId") as DropDownList;

            int projectId = 0;
            int platFormTypeID = Convert.ToInt16(ddlPlatFormType.SelectedValue.ToString());
            if (this.ProjectId == -1)
            {
                var ddProjectId = row.FindControl("ddProjectId") as DropDownList;   //项目名称
                projectId = int.Parse(ddProjectId.SelectedValue.Trim());//项目id
            }
            else
            {
                projectId = this.ProjectId;
            }
            //判断店铺名称不能为空
            if (txtNick.Text.Equals(""))
            {
                base.ShowMessage("店铺名称不能为空");
                return;
            }
            if (nickId == 0)    //新增
            {
                List<XMNick> nickList = base.XMNickService.GetXMNickListByNick(txtNick.Text.Trim()).Where(p => p.PlatformTypeId == platFormTypeID).ToList();
                if (nickList != null && nickList.Count > 0)
                {
                    base.ShowMessage("该店铺名称已存在,请选择其他平台");
                    return;
                }
                else
                {
                    XMNick nick = new XMNick();
                    nick.nick = txtNick.Text.Trim();
                    nick.isEnable = chkIsEnable.Checked;
                    nick.ProjectId = projectId; //项目Id
                    nick.createPerson = HozestERPContext.Current.User.SCustomerInfo.FullName;
                    nick.createTime = DateTime.Now;
                    nick.updateTime = DateTime.Now;
                    nick.updatePerson = HozestERPContext.Current.User.SCustomerInfo.FullName;
                    nick.PlatformTypeId = int.Parse(ddlPlatFormType.SelectedValue.Trim());
                    base.XMNickService.InsertXMNick(nick);
                }
            }
            else
            {
                //更新这条数据
                var nick = base.XMNickService.GetXMNickByID(nickId);
                if (nick != null)
                {
                    nick.nick = txtNick.Text.Trim();
                    nick.isEnable = chkIsEnable.Checked;//是否在运营 
                    nick.ProjectId = projectId;//项目Id
                    nick.updatePerson = HozestERPContext.Current.User.SCustomerInfo.FullName;
                    nick.updateTime = DateTime.Now;
                    nick.PlatformTypeId = int.Parse(ddlPlatFormType.SelectedValue.Trim());
                    base.XMNickService.UpdateXMNick(nick);
                }
            }

            this.RowEditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void gvNick_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void gvNick_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bool isSucess = false;
            string id = gvNick.DataKeys[e.RowIndex].Value.ToString();
            if (!string.IsNullOrEmpty(id))
            {
                var nicks = base.XMNickService.GetXMNickByID(int.Parse(id));
                if (nicks != null)
                {
                    base.XMNickService.DeleteXMNick(nicks);
                    isSucess = true;
                }
            }
            if (isSucess)
            {
                base.ShowMessage("删除成功！");
            }
            else
            {
                base.ShowMessage("删除失败！");
            }

            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void gvNick_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMNick = (XMNick)e.Row.DataItem;
                if (xMNick.nick_id != 0)
                {
                    //ImageButton imgBtnLook = e.Row.FindControl("imgBtnLook") as ImageButton;
                    //string paramScript = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageProject/NickOperation.aspx?nick_id="
                    // + xMNick.nick_id + "','NickOperation" + xMNick.nick_id + "','" + xMNick.nick + "的详细计划信息');";
                    //e.Row.Attributes.Add("ondblclick", paramScript);
                    //if (imgBtnLook != null)
                    //    imgBtnLook.Attributes.Add("onclick", paramScript);

                    ImageButton imgBtnLook = e.Row.FindControl("imgBtnLook") as ImageButton;
                    //string paramScript = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageProject/ProjectOperationNew.aspx?nick_id="
                    // + xMNick.nick_id +
                    // "&Nick=" + xMNick.nick + "','ProjectOperationNew" + xMNick.nick_id + "','" + xMNick.nick + "的详细计划信息');";
                    //e.Row.Attributes.Add("ondblclick", paramScript);
                    string paramScript = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageBusiness/XMNickManageOperatation.aspx?NickId="
                     + xMNick.nick_id +
                       "','XMProductDetailsManage" + xMNick.nick_id + "','" + xMNick.nick + "列表');";
                    e.Row.Attributes.Add("ondblclick", paramScript);
                    if (imgBtnLook != null)
                        imgBtnLook.Attributes.Add("onclick", paramScript);

                    ImageButton imgBtnSet = e.Row.FindControl("imgBtnSetField") as ImageButton;
                    if (imgBtnSet != null)
                    {
                        imgBtnSet.OnClientClick = "return ShowWindowDetail('财务字段设置', '" + CommonHelper.GetStoreLocation()
                                    + "ManageProject/SetFinanceFields.aspx?NickID=" + xMNick.nick_id
                                    + "&rnd=' + Math.round(), 1000, 600, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                    }
                    //ImageButton imgProduct = e.Row.FindControl("imgProduct") as ImageButton;
                    //string paramScript1 = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageProject/XMProductManage.aspx?NickId="
                    // + xMNick.nick_id +
                    // "&Nick=" + xMNick.nick + "','XMProductManage" + xMNick.nick_id + "','" + xMNick.nick + "的产品信息');";
                    //if (imgProduct != null)
                    //    imgProduct.Attributes.Add("onclick", paramScript1);
                }

                ImageButton imgbtnCustomer = (ImageButton)e.Row.FindControl("imgbtnCustomer");

                if (imgbtnCustomer != null)
                    imgbtnCustomer.OnClientClick = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageProject/ProjectCustomerDistribution.aspx?nick_id="
                 + xMNick.nick_id + "&&CustomerRoleID=5" +
                   "','XMProductDetailsManage" + xMNick.nick_id + "','" + xMNick.nick + "的业务员分配');";

                //项目预算录入
                ImageButton imgbtnCostSave = e.Row.FindControl("imgbtnCostSave") as ImageButton;
                if (imgbtnCostSave != null)
                {
                    imgbtnCostSave.OnClientClick = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageProject/XMProjectCostDetail.aspx?NickID="
                     + xMNick.nick_id +
                       "','XMNickCostDetail" + xMNick.nick_id + "','" + xMNick.nick + "预算录入列表');";
                }

                ////运营专员
                //CustomerInfo customerOperationCommissioner = base.XMNickService.GetProjectXMNickCustomer(xMNick.nick_id, (int)CustomerTypeEnum.OperationCommissioner);
                //Label lblOperationCommissioner = e.Row.FindControl("lblOperationCommissioner") as Label;
                //if (customerOperationCommissioner != null)
                //    lblOperationCommissioner.Text = customerOperationCommissioner.FullName;
                ////文案专员
                //CustomerInfo customerCopywriterCommissioner = base.XMNickService.GetProjectXMNickCustomer(xMNick.nick_id, (int)CustomerTypeEnum.CopywriterCommissioner);
                //Label lblCopywriterCommissioner = e.Row.FindControl("lblCopywriterCommissioner") as Label;
                //if (customerCopywriterCommissioner != null)
                //    lblCopywriterCommissioner.Text = customerCopywriterCommissioner.FullName;
                ////店长
                //CustomerInfo customerCustomerManager = base.XMNickService.GetProjectXMNickCustomer(xMNick.nick_id, (int)CustomerTypeEnum.ShopOwner);
                //Label lblShopOwner = e.Row.FindControl("lblShopOwner") as Label;
                //if (customerCustomerManager != null)
                //    lblShopOwner.Text = customerCustomerManager.FullName;
                ////推广专员
                //CustomerInfo customerPromotionSpecialist = base.XMNickService.GetProjectXMNickCustomer(xMNick.nick_id, (int)CustomerTypeEnum.PromotionSpecialist);
                //Label lblPromotionSpecialist = e.Row.FindControl("lblPromotionSpecialist") as Label;
                //if (customerPromotionSpecialist != null)
                //    lblPromotionSpecialist.Text = customerPromotionSpecialist.FullName;

                ////项目经理
                //CustomerInfo customerProjectManager = base.XMNickService.GetProjectXMNickCustomer(xMNick.nick_id, (int)CustomerTypeEnum.ProjectManager);
                //Label lblProjectManager = e.Row.FindControl("lblProjectManager") as Label;
                //if (customerProjectManager != null)
                //    lblProjectManager.Text = customerProjectManager.FullName;


                //日期为空 隐藏产品目标按钮
                if (xMNick.nick == null)
                {
                    imgbtnCustomer.Visible = false;
                }
                //显示产品目标按钮
                else
                {
                    imgbtnCustomer.Visible = true;

                }


            }


            if (e.Row.RowState == DataControlRowState.Edit ||
                 e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {

                #region 项目名称绑定
                DropDownList ddllist = (DropDownList)e.Row.FindControl("ddProjectId");
                //项目名称绑定--选取自运营项目
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    ddllist.Items.Clear();
                    var projectList = base.XMProjectService.GetXMProjectList().Where(c => c.ProjectTypeId == 362);

                    ddllist.DataSource = projectList;
                    ddllist.DataTextField = "ProjectName";
                    ddllist.DataValueField = "Id";
                    ddllist.DataBind();
                    ddllist.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    ddllist.Items.Clear();
                    var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                        .GroupBy(p => new { p.Id, p.ProjectName })
                        .Select(p => new
                        {
                            Id = p.Key.Id,
                            ProjectName = p.Key.ProjectName
                        });
                    if (projectList.Count() == 0)
                    {
                        ddllist.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                    }
                    if (projectList.Count() > 0)
                    {
                        ddllist.DataSource = projectList;
                        ddllist.DataTextField = "ProjectName";
                        ddllist.DataValueField = "Id";
                        ddllist.DataBind();
                    }
                    //ddllist.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                #endregion
                ////项目名称
                //DropDownList ddllist = (DropDownList)e.Row.FindControl("ddProjectId");
                //ddllist.Items.Clear();
                //var itemList = base.XMProjectService.GetXMProjectList();
                //ddllist.DataSource = itemList;
                //ddllist.DataTextField = "ProjectName";
                //ddllist.DataValueField = "Id";
                //ddllist.DataBind();  


                DropDownList ddlPlatformTypeList = (DropDownList)e.Row.FindControl("ddlPlatformTypeId");
                //平台类型动态数据绑定
                ddlPlatformTypeList.Items.Clear();
                var codePlatformTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
                ddlPlatformTypeList.DataSource = codePlatformTypeList;
                ddlPlatformTypeList.DataTextField = "CodeName";
                ddlPlatformTypeList.DataValueField = "CodeID";
                ddlPlatformTypeList.DataBind();
                ddlPlatformTypeList.Items.Insert(0, new ListItem("---所有---", "-1"));



            }
        }

        public int RowEditIndex
        {
            get
            {
                int editIndex = -1;
                try
                {
                    int.TryParse(ViewState["RowEditIndex"].ToString(), out editIndex);
                }
                catch
                {
                }
                return editIndex;
            }
            set
            {
                ViewState["RowEditIndex"] = value;
            }
        }

        /// <summary>
        /// 项目Id
        /// </summary>
        public int ProjectId
        {
            get
            {
                return CommonHelper.QueryStringInt("ProjectId");
            }
        }


    }
}