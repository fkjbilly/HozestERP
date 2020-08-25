using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Web;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Web.Modules;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Enterprises;

namespace HozestERP.Web.ManageProject
{ 


    public partial class XMProjectList : BaseAdministrationPage, ISearchPage
    {
        /// <summary>
        /// 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnEdit", "XMProjectList.Edit");
                //buttons.Add("imgBtnDelete", "XMProjectList.Delete");
                buttons.Add("imgBtnUpdate", "XMProjectList.Save");
                buttons.Add("imgBtnCancel", "XMProjectList.Cancel"); 
                buttons.Add("imgbtnDeduction", "ManageProject.XMProjectList.Deduction");//扣点设置
                buttons.Add("imgBtnLook", "XMProjectList.Product");//产品管理

                buttons.Add("imgbtnCashBack", "ManageProject.XMProjectList.CashBack");//返现设置
                

                
                return buttons;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //弹出业务数据导入
                this.btnImportProject.OnClientClick = "return ShowWindowDetail('产品导入','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportProduct.aspx',500,280, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true) {

                    List<XMProject> XMProjectList= base.XMProjectService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                    if (XMProjectList.Count > 0)
                    {


                        this.txtProjectName.Text = XMProjectList[0].ProjectName;
                    }

                    txtProjectName.ReadOnly = true; 
                } 

                //if (HozestERPContext.Current.User.CustomerID == 442) { 
                //    this.txtProjectName.Text = "喜临门";
                //    txtProjectName.ReadOnly = true;
                //} 
                //if (HozestERPContext.Current.User.CustomerID == 492)
                //{
                //    this.txtProjectName.Text = "利豪";
                //    txtProjectName.ReadOnly = true;
                //}


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


            //项目名称
            string ProjectName = this.txtProjectName.Text.Trim();

            int ccSProjectTypeId = this.ccSProjectTypeId.SelectedValue;

            //是否在运营
            int IsEnable = Convert.ToInt32(this.ddIsEnable.SelectedValue.Trim());

            //根据 项目名称查询。
            var xMProjectList = base.XMProjectService.GetXMProjectList(ProjectName, ccSProjectTypeId, IsEnable);
            //分页
            var xMProjectPageList = new PagedList<XMProject>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            if (this.RowEditIndex == -1)
            {
                //新增编码行
                this.gvXMProjectList.EditIndex = xMProjectPageList.Count();
                xMProjectPageList.Add(new XMProject());
            }
            else
            {
                this.gvXMProjectList.EditIndex = this.RowEditIndex;
            }
            this.Master.BindData(this.gvXMProjectList, xMProjectPageList, paramPageSize + 1);
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
        
        protected void ddIsEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void gvXMProjectList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int Id = 0;
        //    if (int.TryParse(this.gvXMProjectList.DataKeys[e.RowIndex].Value.ToString(), out Id))
        //    {
        //        // 产品信息
        //        var xMProject = base.XMProjectService.GetXMProjectById(Id);
        //        if (xMProject != null)
        //        {
        //            xMProject.IsEnable = false;
        //            xMProject.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
        //            xMProject.UpdateDate = DateTime.Now;
        //            base.XMProjectService.UpdateXMProject(xMProject); 
        //        }
        //        //grid 绑定
        //        BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //        base.ShowMessage("删除成功.");
        //    }
        //}

        protected void gvXMProjectList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
              
        }

        protected void gvXMProjectList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize); 
            int Id = 0;
            int.TryParse(this.gvXMProjectList.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
            var row = this.gvXMProjectList.Rows[e.NewEditIndex];
            var xMProject = base.XMProjectService.GetXMProjectById(Id);
            if (xMProject != null)
            {
                //负责人
                SelectSingleCustomerControl txtcustomerId = (SelectSingleCustomerControl)row.FindControl("txtcustomerId");
                if (xMProject.customerId != null)
                {
                    txtcustomerId.SelectSingleCustomer = base.CustomerInfoService.GetCustomerInfoByID(xMProject.customerId.Value);
                    if (txtcustomerId.SelectSingleCustomer != null)
                        txtcustomerId.Value = txtcustomerId.SelectSingleCustomer.FullName;

                }

                //负责人
                if (xMProject.ClientId != null)
                {
                    SelectSingleCustomerControl txtClientId = (SelectSingleCustomerControl)row.FindControl("txtClientId");
                    txtClientId.SelectSingleCustomer = base.CustomerInfoService.GetCustomerInfoByID(xMProject.ClientId.Value);
                    if (txtClientId.SelectSingleCustomer != null)
                        txtClientId.Value = txtClientId.SelectSingleCustomer.FullName;
                }
                //项目类型
                CodeControl ccProjectTypeId = (CodeControl)row.FindControl("ccProjectTypeId");
                ccProjectTypeId.SelectedValue = xMProject.ProjectTypeId.Value;
                //所属部门
                DropDownList ddlDepartment = (DropDownList)row.FindControl("ddlDepartment");
                if (xMProject.DepartmentID != null)
                {
                    ddlDepartment.SelectedValue = xMProject.DepartmentID.ToString();
                }
                
            }
            
        }


        /// <summary>
        /// 记录行 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvXMProjectList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        { 
            int Id = 0;
           
            if (int.TryParse(this.gvXMProjectList.DataKeys[e.RowIndex].Value.ToString(), out Id))
            { 
                var row = this.gvXMProjectList.Rows[e.RowIndex];

                #region 字符验证 
                //产品名称
                var txtProjectName = row.FindControl("txtProjectName") as TextBox;
                var lblMsgProjectNameVaule = row.FindControl("lblMsgProjectNameVaule") as Label;
                var lblProjectName = row.FindControl("lblProjectName") as Label;
                var lblMsgShipmentProportionVaule = row.FindControl("lblMsgShipmentProportionVaule") as Label;
                var ccProjectTypeId = row.FindControl("ccProjectTypeId") as CodeControl;
                var chkIsEnable = row.FindControl("chkIsEnable") as CheckBox;
                var ddlDepartment = row.FindControl("ddlDepartment") as DropDownList;
                var ShipmentProportion=row.FindControl("txtShipmentProportion") as TextBox;
                decimal paramparse2 = 0;
                lblMsgProjectNameVaule.Text = "";
                if (txtProjectName.Text.Trim() == "")
                {
                    lblMsgProjectNameVaule.Text = "不允许为空";
                }

                //负责人
                SelectSingleCustomerControl txtcustomerId = (SelectSingleCustomerControl)row.FindControl("txtcustomerId");
                //客户
                SelectSingleCustomerControl txtClientId = (SelectSingleCustomerControl)row.FindControl("txtClientId"); 
                
                //备注
                var txtRemark = row.FindControl("txtRemark") as TextBox; 

                if (lblMsgProjectNameVaule.Text != "")
                {
                    return;
                }

                #endregion


                var xMProject = base.XMProjectService.GetXMProjectById(Id);

                var xMProjectList = base.XMProjectService.GetXMProjectList(txtProjectName.Text.Trim(), -1, -1);


                if (xMProject != null)
                {
                    if ((!txtProjectName.Text.Trim().Equals(lblProjectName.Text.Trim())) && xMProjectList.Count > 0)
                    {
                        base.ShowMessage("该项目名称已存在");
                        return;
                    }
                    xMProject.ProjectName = txtProjectName.Text.Trim();
                    xMProject.ProjectTypeId = ccProjectTypeId.SelectedValue;
                    xMProject.customerId = txtcustomerId.SelectSingleCustomer.CustomerID;
                    if (decimal.TryParse(ShipmentProportion.Text.Trim(), out paramparse2))
                    {
                        xMProject.ShipmentProportion = decimal.Parse(ShipmentProportion.Text.Trim());
                    }
                    else 
                    {
                        xMProject.ShipmentProportion = 0;
                    }
                    if (txtClientId != null)
                    {
                        if (txtClientId.SelectSingleCustomer != null)
                        {
                            xMProject.ClientId = txtClientId.SelectSingleCustomer.CustomerID;
                        }
                    }
                    if (txtRemark.Text.Trim() != "")
                    {
                        xMProject.Remark = txtRemark.Text.Trim();
                    }
                    else
                    {
                        xMProject.Remark = "";
                    }
                    xMProject.DepartmentID = int.Parse(ddlDepartment.SelectedValue.Trim());
                    if (!chkIsEnable.Checked && (bool)xMProject.IsEnable)
                    {
                        var NickList = base.XMNickService.GetXMNickListByProjectId(xMProject.Id);
                        if (NickList != null && NickList.Count > 0)
                        { 
                            foreach(XMNick info in NickList)
                            {
                                info.isEnable = false;
                                info.updatePerson = HozestERPContext.Current.User.CustomerID.ToString();
                                info.updateTime = DateTime.Now;
                                base.XMNickService.UpdateXMNick(info);
                            }
                        }
                    }

                    xMProject.IsEnable = chkIsEnable.Checked;//是否在运营
                    xMProject.UpdateID = HozestERPContext.Current.User.CustomerID;
                    xMProject.UpdateDate = DateTime.Now;
                    base.XMProjectService.UpdateXMProject(xMProject);
                }
                else
                {
                    if (xMProjectList.Count > 0)
                    {
                        base.ShowMessage("该项目名称已存在");
                        return;
                    }
                    xMProject = new XMProject();

                    xMProject.ProjectName = txtProjectName.Text.Trim();
                    xMProject.ProjectTypeId = ccProjectTypeId.SelectedValue;
                    xMProject.customerId = txtcustomerId.SelectSingleCustomer.CustomerID;
                    if (txtClientId != null)
                    {
                        if (txtClientId.SelectSingleCustomer != null)
                        {
                            xMProject.ClientId = txtClientId.SelectSingleCustomer.CustomerID;
                        }
                    }
                    if (txtRemark.Text.Trim() != "")
                    { 
                        xMProject.Remark = txtRemark.Text.Trim();
                    }
                    else
                    { 
                        xMProject.Remark = "";
                    }
                    xMProject.DepartmentID = int.Parse(ddlDepartment.SelectedValue.Trim());
                    xMProject.IsEnable = chkIsEnable.Checked;//是否在运营 
                    xMProject.CreateID = HozestERPContext.Current.User.CustomerID;
                    xMProject.CreateDate = DateTime.Now;
                    xMProject.UpdateID = HozestERPContext.Current.User.CustomerID;
                    xMProject.UpdateDate = DateTime.Now;
                    base.XMProjectService.InsertXMProject(xMProject); 
                }
              // SelectSingleCustomer //this.SelectSingleCustomer = null; 

                Session["OperationCustomerCustomerStatus"] = null;

                Session["OperationClientCustomerStatus"] = null;

                this.RowEditIndex = -1;
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            }
        }


        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvXMProjectList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == DataControlRowState.Edit ||
                e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                var ddlDepartment = (DropDownList)e.Row.FindControl("ddlDepartment");
                var departments = IoC.Resolve<IEnterpriseService>().GetDepartmentByParentID(3, 0);
                ddlDepartment.DataSource = departments;
                ddlDepartment.DataTextField = "DepName";
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataBind();
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMProject = (XMProject)e.Row.DataItem;
                #region 负责人
                if (xMProject.customerId != null)
                { 
                    var customerInfo = base.CustomerInfoService.GetCustomerInfoByID(xMProject.customerId.Value); 
                    Label lblcustomerId = e.Row.FindControl("lblcustomerId") as Label;
                    if (lblcustomerId != null)
                    {
                        if (customerInfo != null)
                        {
                            lblcustomerId.Text = customerInfo.FullName;
                        }
                    }
                }


                
                #endregion 

                #region 客户姓名
                if (xMProject.ClientId != null && xMProject.ClientId!=0)
                { 
                    var customerInfo = base.CustomerInfoService.GetCustomerInfoByID(xMProject.ClientId.Value);
                    Label lblClientId = e.Row.FindControl("lblClientId") as Label;
                    if (lblClientId != null)
                    {
                        if (customerInfo != null)
                        {
                            lblClientId.Text = customerInfo.FullName;
                        }
                    }
                }
                 
                #endregion 

                #region 所属部门
                if (xMProject.DepartmentID != null && xMProject.DepartmentID != 0)
                {
                    var departmentinfo = base.EnterpriseService.GetDepartmentById(xMProject.DepartmentID.Value);
                    Label lbldepartmentId = e.Row.FindControl("lblDepartment") as Label;
                    if (lbldepartmentId != null)
                    {
                        if (departmentinfo != null)
                        {
                            lbldepartmentId.Text = departmentinfo.DepName;
                        }
                    }
                }
                #endregion

                //扣点设置
                ImageButton imgbtnDeduction = (ImageButton)e.Row.FindControl("imgbtnDeduction");
                if (imgbtnDeduction != null)
                    imgbtnDeduction.OnClientClick = "return ShowWindowDetail('扣点设置', '" + CommonHelper.GetStoreLocation()
                                + "ManageProject/ProjectXMDeductionSetUp.aspx?ProjectId=" + xMProject.Id + 
                                "&ProjectName=" + xMProject.ProjectName+
                                "&SpeciesTypeId=475"
                                + "&rnd=' + Math.round(), 1000, 400, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";



                //限额设置
                ImageButton imgbtnCashBack = (ImageButton)e.Row.FindControl("imgbtnCashBack");
                if (imgbtnCashBack != null)
                    imgbtnCashBack.OnClientClick = "return ShowWindowDetail('限额设置', '" + CommonHelper.GetStoreLocation()
                                + "ManageProject/ProjectXMDeductionSetUpTypeCashBack.aspx?ProjectId=" + xMProject.Id +
                                "&ProjectName=" + xMProject.ProjectName +
                                "&SpeciesTypeId=476"
                                + "&rnd=' + Math.round(), 1000, 400, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";


                //项目预算录入
                ImageButton imgbtnCostSave = e.Row.FindControl("imgbtnCostSave") as ImageButton;
                if (imgbtnCostSave != null)
                {
                    imgbtnCostSave.OnClientClick = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageProject/XMProjectCostDetail.aspx?projectId="
                     + xMProject.Id +
                       "','XMNickCostDetail" + xMProject.Id + "','" + xMProject.ProjectName + "预算录入列表');";
                }
                 
                //行双击事件
                string paramScript = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageProject/NickManage.aspx?ProjectId="
                                    + xMProject.Id + "','NickManage" + xMProject.Id + "','" + xMProject.ProjectName + "');";
                e.Row.Attributes.Add("ondblclick", paramScript);

                ImageButton imgBtnSet = e.Row.FindControl("imgBtnSetField") as ImageButton;
                if (imgBtnSet != null)
                {
                    imgBtnSet.OnClientClick = "return ShowWindowDetail('财务字段设置', '" + CommonHelper.GetStoreLocation()
                                + "ManageProject/SetFinanceFields.aspx?ProjectId=" + xMProject.Id
                                + "&rnd=' + Math.round(), 1000, 600, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";
                }

                ImageButton imgBtnLook = e.Row.FindControl("imgBtnLook") as ImageButton;
                string paramScript1 = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageProject/XMProductManage.aspx?ProjectId="
                 + xMProject.Id + "','XMProductDetailsManage" + xMProject.Id + "','" + xMProject.ProjectName + "的产品信息');";
                //e.Row.Attributes.Add("ondblclick", paramScript1);
                if (imgBtnLook != null)
                    imgBtnLook.Attributes.Add("onclick", paramScript1);

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
         
    }
}