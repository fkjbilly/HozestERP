using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageSystem
{
    public partial class CustomerRole : BaseAdministrationPage, ISearchPage
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
            this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);

        }

        public void Face_Init()
        {
            this.Master.SetTitle("参数设置 > 角色管理");
            this.Master.JsWrite("var icon_show='" + HozestERP.Common.Utils.CommonHelper.GetStoreLocation() + "images/icon_show.gif';", "initColor1");
            this.Master.JsWrite("var icon_hide='" + HozestERP.Common.Utils.CommonHelper.GetStoreLocation() + "images/icon_hide.gif';", "initColor2");
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            this.Master.BindData<HozestERP.BusinessLogic.CustomerManagement.CustomerRole>(this.grdRole, base.CustomerService.GetAllCustomerRoles(this.txtName.Text, paramPageIndex, paramPageSize));
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

        protected void grdRole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail") || e.CommandName.Equals("SelectCustomer"))
            {
                this.BindGrid(this.grdRole.PageIndex+1, this.grdRole.PageSize);
            }
            else if (e.CommandName.Equals("CustomerRoleDelete"))
            {
                int customerRoleID = 0;
                int.TryParse(e.CommandArgument.ToString(), out customerRoleID);
                base.CustomerService.MarkCustomerRoleAsDeleted(customerRoleID);
                this.BindGrid(Master.PageIndex, Master.PageSize);
            }
        }

        protected void grdRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var customer = e.Row.DataItem as HozestERP.BusinessLogic.CustomerManagement.CustomerRole;

                ImageButton imgbtnDetail = (e.Row.FindControl("imgbtnDetail") as ImageButton);
                if (imgbtnDetail != null)
                {
                    imgbtnDetail.Attributes.Add("onclick", "return ShowDetail('CustomerRoleDetails.aspx?CustomerRoleID=" + imgbtnDetail.CommandArgument.ToString() + "');");
                }
                ImageButton imbtnSet = e.Row.FindControl("imbtnSet") as ImageButton;
                if (imbtnSet != null)
                {
                    imbtnSet.Attributes.Add("onclick", "return ShowModuleDetail('CustomerRoleModule.aspx?CustomerRoleID=" + imgbtnDetail.CommandArgument.ToString() + "');");
                }

                ImageButton imbtnSelectCustomer = e.Row.FindControl("imbtnSelectCustomer") as ImageButton;
                if (imbtnSelectCustomer != null)
                {
                    imbtnSelectCustomer.Attributes.Add("onclick", "return ShowModuleDetail('CustomerRoleMapping.aspx?CustomerRoleID=" + imgbtnDetail.CommandArgument.ToString() + "');");
                }
                try
                {
                    if (customer.ParentCustomerRoleID.ToString() != string.Empty)
                    {
                        List<HozestERP.BusinessLogic.CustomerManagement.CustomerRole> myDt = (List<HozestERP.BusinessLogic.CustomerManagement.CustomerRole>)this.grdRole.DataSource;
                        var myDr = myDt.Where(p=>p.CustomerRoleID==customer.ParentCustomerRoleID);
                        // 隐藏层
                        if (myDr.Count() > 0)
                        {
                            // 折叠第二层,第三层
                            e.Row.Style.Add("display", "none");
                            // 第几层数据
                            int iNumber = 0;
                            string strParentID = string.Empty;
                            List<HozestERP.BusinessLogic.CustomerManagement.CustomerRole> myDrs = myDr.ToList();
                            do
                            {
                                iNumber++;
                                if (myDrs.Count==0)
                                {
                                    break;
                                }
                                strParentID = myDrs.FirstOrDefault().ParentCustomerRoleID.ToString();
                                myDrs = myDt.Where(p => p.CustomerRoleID == int.Parse(strParentID)).ToList();
                            }
                            while (strParentID != string.Empty);
                            string strTab = "&nbsp;&nbsp;&nbsp;&nbsp;";
                            string strNbsp = string.Empty;
                            for (int i = 0; i < iNumber; i++)
                            {
                                strNbsp += strTab;
                            }
                            Label lblTab = (Label)e.Row.Cells[1].FindControl("lblTab");
                            lblTab.Text = strNbsp;
                        }
                    }
                    ImageButton myExpand = (ImageButton)e.Row.Cells[1].FindControl("IbtnExpand");

                    if (myExpand != null)
                    {
                        List<HozestERP.BusinessLogic.CustomerManagement.CustomerRole> myDt = (List<HozestERP.BusinessLogic.CustomerManagement.CustomerRole>)this.grdRole.DataSource;
                        List<HozestERP.BusinessLogic.CustomerManagement.CustomerRole> myDr = myDt.Where(p => p.ParentCustomerRoleID == customer.CustomerRoleID).ToList();

                        if (myDr.Count == 0)
                        {
                            myExpand.Visible = false;
                        }
                        myExpand.CommandArgument = e.Row.RowIndex.ToString();
                        Literal litName = (Literal)e.Row.Cells[1].FindControl("litName");
                        myExpand.Attributes.Add("onclick", "Load('" + customer.CustomerRoleID.ToString() + "','" + this.grdRole.ClientID + "',this);return false;");
                    }
                }
                catch (Exception myEx)
                {
                    throw myEx;
                }
            }
        }
    }
}