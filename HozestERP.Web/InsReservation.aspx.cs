using System;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageCustomerService;
using Ext.Net;

namespace HozestERP.Web
{
    public partial class InsReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }

        public void BindGrid()
        {
            //int id = 0;
            //string OrderCode = this.txtNumber.Text.Trim();
            //id = IoC.Resolve<IXMInstallationListService>().GetXMInstallationIDByOrderCode(OrderCode);
            var List = IoC.Resolve<IXMTypeTestService>().GetXMTypeTestList();

            gvXMProduct.DataSource = List;
            gvXMProduct.DataBind();
        }

        protected void gvXMProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var Tid = (XMTypeTest)e.Row.DataItem;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RadioButtonList ddlDemand = (RadioButtonList)e.Row.FindControl("ddlDemand");
                var DemandList = IoC.Resolve<IXMZMDemandService>().GetXMZMDemandListByTid(Tid.ID);
                ddlDemand.DataSource = DemandList;
                ddlDemand.DataTextField = "requirements";
                ddlDemand.DataValueField = "ID";
                ddlDemand.DataBind();
                ddlDemand.SelectedIndex = 1;

                DataControlFieldCell cell = (DataControlFieldCell)ddlDemand.Parent;
                System.Web.UI.WebControls.Label lblPrice = (System.Web.UI.WebControls.Label)cell.FindControl("lblPrice");

                if (ddlDemand.SelectedValue.ToString().Trim().Length > 0)
                {
                    if (Convert.ToInt16(ddlDemand.SelectedValue.ToString().Trim()) != -1)
                    {
                        int Did = Convert.ToInt32(ddlDemand.SelectedValue);
                        var DemandList2 = IoC.Resolve<IXMZMDemandService>().GetXMZMDemandByID(Did);
                        lblPrice.Text = DemandList2.Price.ToString();
                        lblPrice.DataBind();
                    }
                }
            }

        }

        protected void ddlDemand_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList ddlDemand = (RadioButtonList)sender;
            DataControlFieldCell cell = (DataControlFieldCell)ddlDemand.Parent;
            System.Web.UI.WebControls.Label lblPrice = (System.Web.UI.WebControls.Label)cell.FindControl("lblPrice");

            if (ddlDemand.SelectedValue.ToString().Trim().Length > 0)
            {
                if (Convert.ToInt16(ddlDemand.SelectedValue.ToString().Trim()) != -1)
                {
                    int Did = Convert.ToInt32(ddlDemand.SelectedValue);
                    var DemandList = IoC.Resolve<IXMZMDemandService>().GetXMZMDemandByID(Did);
                    lblPrice.Text = DemandList.Price.ToString();
                    lblPrice.DataBind();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    XMInstallationList Info = new XMInstallationList();
                    string OrderCode = this.txtNumber.Text.Trim();
                    string CustomerName = this.txtName.Text.Trim();
                    string CustomerTel = this.txtTel.Text.Trim();
                    string InstallAddress = this.txtAddress.Text.Trim();
                    string WantID = this.txtWantID.Text.Trim();
                    int ProjectId = 25;
                    int id = 0;

                    if (OrderCode == "请输入订单编号" || WantID == "请输入买家ID" || CustomerName == "请输入姓名" || CustomerTel == "请输入电话" || InstallAddress == "请输入安装地址")
                    {
                        Response.Write("<script language='javascript'>alert('个人信息不能为空，请重新输入');</script>");
                        return;
                    }
                    var isRe = IoC.Resolve<IXMInstallationListService>().GetXMInstallationOrderCode(OrderCode);
                    if (isRe == OrderCode)
                    {
                        Response.Write("<script language='javascript'>alert('订单号重复，请重新输入');</script>");
                        return;
                    }

                    bool c = CheckPhoneIsAble(CustomerTel);
                    if (!c)
                    {
                        Response.Write("<script language='javascript'>alert('手机号不正确，请重新输入');</script>");
                        return;
                    }

                    Info.OrderCode = OrderCode;
                    Info.CustomerName = CustomerName;
                    Info.CustomerTel = CustomerTel;
                    Info.InstallAddress = InstallAddress;
                    Info.ProjectId = ProjectId;
                    //Info.CreateID = HozestERPContext.Current.User.CustomerID;
                    //Info.IsArrange = false;
                    //Info.IsInstall = false;
                    Info.WantID = WantID;
                    Info.CreateDate = DateTime.Now;
                    IoC.Resolve<IXMInstallationListService>().InsertXMInstallationList(Info);

                    id = IoC.Resolve<IXMInstallationListService>().GetXMInstallationIDByOrderCode(OrderCode);
                    var lbl = IoC.Resolve<IXMInstallationListService>().GetXMInstallationListByID(id);

                    decimal sum = 0;
                    int Type=0;
                    foreach (GridViewRow row in gvXMProduct.Rows)
                    {
                        var ddlDemand = row.FindControl("ddlDemand") as RadioButtonList;
                        int Demand = int.Parse(ddlDemand.SelectedValue);
                        Type = IoC.Resolve<IXMZMDemandService>().GetXMZMDemandTidByID(Demand);
                        decimal lblPrice = Convert.ToDecimal(((System.Web.UI.WebControls.Label)row.FindControl("lblPrice")).Text.Trim());
                        sum += lblPrice;
                        
                        XMZMReservation Info2 = new XMZMReservation();
                        Info2.Remarks = lblPrice.ToString();
                        Info2.DemandID = Demand;
                        Info2.TypeID = Type;
                        Info2.InstallationID = id;
                        Info.CreateDate = DateTime.Now;
                        IoC.Resolve<IXMZMReservationService>().InsertXMZMReservation(Info2);
                    }                     
                    Info.InstallationFee = sum;
                    IoC.Resolve<IXMInstallationListService>().UpdateXMInstallationList(Info);
                    Response.Write("<script language='javascript'>alert('提交成功！');</script>");
                    scope.Complete();
                }
                catch (Exception err)
                {
                    //this.ProcessException(err);
                    Response.Write(err);
                }
            }
        }

        private bool CheckPhoneIsAble(string input)
        {
            if (input.Length < 11)
            {
                return false;
            }
            string tel = @"^1[3|4|5|7|8][0-9]{9}$";
            Regex regexDX = new Regex(tel);
            if (regexDX.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}