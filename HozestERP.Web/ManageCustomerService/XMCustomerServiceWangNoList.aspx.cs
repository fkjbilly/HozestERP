using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.Web.Modules;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMCustomerServiceWangNoList : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.BindTree();
                this.BindSelectCustomerGrid();
                this.EnterpriseID = 0;
                this.BindCustomerGrid(1, this.GridNevigator1.PageSize);
                if (this.SelectCustomers!=null)
                {
                    this.SelectCustomers.Clear();
                }
                this.SelectCustomers = base.XMWangNoService.GetXMCustomerWangNoList(CustomerID);
                BindSelectCustomerGrid();
            }
        }

        public void BindCustomerGrid(int pageIndex, int pageSize, int type = 0)
        {
            if (type != 1)
            {
                this.ddlPlatformTypeId.Items.Clear();
                var codePlatformTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
                this.ddlPlatformTypeId.DataSource = codePlatformTypeList;
                this.ddlPlatformTypeId.DataTextField = "CodeName";
                this.ddlPlatformTypeId.DataValueField = "CodeID";
                this.ddlPlatformTypeId.DataBind();
                this.ddlPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));

                this.ddlNickId.Items.Clear();
                var NickList = base.XMNickService.GetXMNickList();
                var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                this.ddlNickId.DataSource = newNickList;
                this.ddlNickId.DataTextField = "nick";
                this.ddlNickId.DataValueField = "nick_id";
                this.ddlNickId.DataBind();
                this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            var xMProjectList = base.XMWangNoService.GetXMWangNoList(int.Parse(this.ddlNickId.SelectedValue), int.Parse(this.ddlPlatformTypeId.SelectedValue), this.ddlWangNo.Text.Trim());
            //分页
            var xMProjectPageList = new PagedList<XMWangNo>(xMProjectList, pageIndex, pageSize);

            this.GridNevigator1.BindData(grdCustomer, xMProjectPageList);

            if (xMProjectPageList.Count > 0)
                this.GridNevigator1.Visible = true;
            else
                this.GridNevigator1.Visible = false;


        }

        public void GridNevigator1_PageSizeChange(object sender, OnChageEventArg e)
        {
            this.GridNevigator1.PageIndex = 1;
            // 改变页面大小
            this.BindCustomerGrid(1, e.newPageSize, 1);

        }

        public void GridNevigator1_PageChange(object sender, OnChageEventArg e)
        {
            // 改变页码
            this.BindCustomerGrid(e.newPageIndex, e.newPageSize, 1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindCustomerGrid(1, this.GridNevigator1.PageSize, 1);
        }

        public void BindSelectCustomerGrid()
        {
            this.grdSelectCustomer.DataSource = this.SelectCustomers;
            this.grdSelectCustomer.DataBind();
        }

        protected void grdCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SelectCustomer"))
            {
                int ID = 0;
                int.TryParse(e.CommandArgument.ToString(), out ID);
                var customerInfo = base.XMWangNoService.GetXMWangNoByID(ID);
                if (customerInfo != null)
                {
                    if (this.SelectCustomers != null)
                    {
                        if (this.SelectCustomers.Where(p => p.ID.Equals(ID)).SingleOrDefault() != null)
                        {
                            return;
                        }
                    }
                    this.SelectCustomers.Add(customerInfo);
                    this.BindSelectCustomerGrid();
                }
            }
        }

        protected void grdSelectCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DetailDelete"))
            {
                int ID = 0;
                int.TryParse(e.CommandArgument.ToString(), out ID);
                var customerInfo = this.SelectCustomers.Where(p => p.ID.Equals(ID)).SingleOrDefault();
                if (customerInfo != null)
                {
                    this.SelectCustomers.Remove(customerInfo);
                    this.BindSelectCustomerGrid();
                }
            }
        }

        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdCustomer.Rows.Count; i++)
            {
                int ID = 0;
                int.TryParse(this.grdCustomer.DataKeys[i].Value.ToString(), out ID);
                var customerInfo = base.XMWangNoService.GetXMWangNoByID(ID);
                if (customerInfo != null)
                {
                    if (this.SelectCustomers.Where(p => p.ID.Equals(ID)).SingleOrDefault() != null)
                    {
                        continue;
                    }
                    this.SelectCustomers.Add(customerInfo);
                    this.BindSelectCustomerGrid();
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            List<XMCustomerWangNo> XMCustomerWangNoList = base.XMCustomerWangNoService.GetXMCustomerWangNoByCustomerID(CustomerID);//获取客服原旺旺号
            for (int i = 0; i < XMCustomerWangNoList.Count; i++)//删除原旺旺号
            {
                XMCustomerWangNo orderinfoapp = XMCustomerWangNoList[i];
                orderinfoapp.IsEnabled = true;
                orderinfoapp.UpdatorID = HozestERPContext.Current.User.CustomerID;
                orderinfoapp.UpdateTime = DateTime.Now;
                base.XMCustomerWangNoService.UpdateXMCustomerWangNo(orderinfoapp);
            }


            for (int i = 0; i < this.SelectCustomers.Count; i++)
            {
                XMCustomerWangNo orderinfoapp = new XMCustomerWangNo();
                orderinfoapp.CustomerID = CustomerID;
                orderinfoapp.WangNoID = this.SelectCustomers[i].ID;
                orderinfoapp.IsEnabled = false;
                orderinfoapp.CreatorID = HozestERPContext.Current.User.CustomerID;
                orderinfoapp.CreateTime = DateTime.Now;
                orderinfoapp.UpdatorID = HozestERPContext.Current.User.CustomerID;
                orderinfoapp.UpdateTime = DateTime.Now;
                base.XMCustomerWangNoService.InsertXMCustomerWangNo(orderinfoapp);
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "close", "<script>alert('保存成功!');</script>");
        }

        /// <summary>
        /// 移除全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = this.grdSelectCustomer.Rows.Count-1; i < this.grdSelectCustomer.Rows.Count; i--)
            {
                if (i >= 0)
                {
                    int customerID = 0;
                    int.TryParse(this.grdSelectCustomer.DataKeys[i].Value.ToString(), out customerID);

                    var customerInfo = this.SelectCustomers.Where(p => p.ID.Equals(customerID)).SingleOrDefault();
                    if (customerInfo != null)
                    {
                        this.SelectCustomers.Remove(customerInfo);

                    }
                }
                else
                {
                    break;
                }
            }
            this.BindSelectCustomerGrid();
        }
        
        public int EnterpriseID
        {
            get
            {
                int _enterpriseID = 0;
                try
                {
                    int.TryParse(ViewState["EnterpriseID"].ToString(), out _enterpriseID);
                }
                catch
                {
                    return 0;
                }
                return _enterpriseID;
            }
            set
            {
                ViewState["EnterpriseID"] = value;
            }
        }

        public int DepartmentID
        {
            get
            {
                int _deparetmentID = 0;
                try
                {
                    int.TryParse(ViewState["DepartmentID"].ToString(), out _deparetmentID);
                }
                catch
                {
                    return 0;
                }
                return _deparetmentID;
            }
            set
            {
                ViewState["DepartmentID"] = value;
            }
        }

        public List<XMWangNo> SelectCustomers
        {
            get
            {
                try
                {
                    return (Session["CustomerRoleStaffPrivilegesSelectCustomer"] as List<XMWangNo>);
                }
                catch
                {
                }
                return new List<XMWangNo>();
            }
            set
            {
                Session["CustomerRoleStaffPrivilegesSelectCustomer"] = value;
            }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public int CustomerID
        {
            get
            {
                string url = HttpContext.Current.Request.Url.Query;
                url = url.Replace("?CustomerID%20=%20", "").Replace("?CustomerID+=+", "");
                return int.Parse(url);
            }
        }
        
    }
}